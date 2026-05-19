#define RFID_RX_SIZE 512                         // RFID 接收暫存區大小
#define RFID_CARD_EMPTY "00000000000000"         // 成功讀取但沒有卡片時的回傳值
#define RFID_CARD_ERROR "EEEEEEEEEEEEEE"         // 讀取失敗時的回傳值，讓上位機知道此站異常
#define RFID_READ_RESPONSE_LEN 13                // 讀卡 Modbus 回應長度
#define RFID_WRITE_RESPONSE_LEN 8                // 寫入/蜂鳴 Modbus 回應長度
#define RFID_FIRST_BYTE_TIMEOUT_MS 100           // 發送命令後等待第一個 byte 的逾時時間
#define RFID_INTER_BYTE_TIMEOUT_MS 100           // 已開始接收後，等待下一個 byte 的逾時時間
#define RFID_IGNORED_DEBUG_SIZE 16               // 記錄被忽略 byte 的最大數量，用於漏首 byte 修復
#define RFID_BUS_QUIET_BEFORE_TX_US 500          // 每次發送前等待 RS485 匯流排安靜的時間
#define RFID_AFTER_FAIL_DELAY_MS 50               // 單次 retry 失敗後的短暫間隔；讀卡輪詢使用跨站間隔，不在同站連續重打
#define RFID_READ_RETRY_COUNT 3                  // 同站跨輪詢累積失敗幾次後，才回報讀取錯誤
#define RFID_WRITE_RETRY_COUNT 1                 // 初始化蜂鳴寫入最多重試次數，避免異常站被連續寫入
#define RFID_CARD_EMPTY_INTERVAL_MS 500          // 成功讀取但沒有卡片後，下一次讀取該站的間隔
#define RFID_CARD_SUCCESS_INTERVAL_MS 1000        // 成功讀到卡片後，下一次讀取該站的間隔
#define RFID_CARD_FAIL_INTERVAL_MS 500          // 每次讀取失敗後，下一次讀取該站的間隔
#define RFID_CARD_CHANGE_PAUSE_MS 500            // 任一站讀到的卡號改變後，全部站暫停讀取的時間
#define RFID_REPORT_INTERVAL_MS 3000             // 有錯誤時，統計訊息回報間隔
#define RFID_DEBUG_ENABLE 1                      // RFID 診斷輸出總開關，1=開啟，0=關閉
#define RFID_VERBOSE_DEBUG 0                     // RFID 細節輸出開關，1=印出每包收發細節，0=只印統計訊息

static byte RFID_RX[RFID_RX_SIZE];

byte rFID_Enable = 0;
byte rFID_Enable_buf = -1;
bool RFID_Init = true;
String CardID_temp = "";
int RFID_Error = 0;
bool RFID_LastRecovered = false;
unsigned long RFID_LastReportTime = 0;
unsigned long RFID_SuccessCount[5] = {0, 0, 0, 0, 0};
unsigned long RFID_ErrorCount[5] = {0, 0, 0, 0, 0};
unsigned long RFID_RecoveredCount[5] = {0, 0, 0, 0, 0};
unsigned long RFID_NextReadTime[5] = {0, 0, 0, 0, 0};
unsigned long RFID_GlobalPauseUntil = 0;
byte RFID_ConsecutiveFailCount[5] = {0, 0, 0, 0, 0};

void Clear_RFID_485_RX()
{
    unsigned long startTime = millis();
    while(mySerial_485.available() && (millis() - startTime) < 5)
    {
        mySerial_485.read();
    }
}

String RFID_ByteToHex(byte value)
{
    String hex = String(value, HEX);
    if(hex.length() < 2) hex = "0" + hex;
    hex.toUpperCase();
    return hex;
}

void RFID_DebugPrintBytes(const char* title, const byte* data, int len)
{
#if RFID_DEBUG_ENABLE && RFID_VERBOSE_DEBUG

    mySerial.print(title);
    mySerial.print(" [");
    mySerial.print(len);
    mySerial.print("] ");
    for(int i = 0 ; i < len ; i++)
    {
        if(data[i] < 0x10) mySerial.print("0");
        mySerial.print(data[i], HEX);
        if(i < len - 1) mySerial.print(" ");
    }
    mySerial.println();
#else
    (void)title;
    (void)data;
    (void)len;
#endif
}

void RFID_DebugError(byte station, byte function, const char* reason, const byte* rx, int len)
{
#if RFID_DEBUG_ENABLE && RFID_VERBOSE_DEBUG

    mySerial.print("RFID ERR station=");
    mySerial.print(station);
    mySerial.print(" func=0x");
    if(function < 0x10) mySerial.print("0");
    mySerial.print(function, HEX);
    mySerial.print(" reason=");
    mySerial.println(reason);
    if(len > 0)
    {
        RFID_DebugPrintBytes("RFID RX", rx, len);
    }
#else
    (void)station;
    (void)function;
    (void)reason;
    (void)rx;
    (void)len;
#endif
}

void RFID_DebugIgnoredBytes(byte station, byte function, const byte* ignored, int len, int total)
{
#if RFID_DEBUG_ENABLE && RFID_VERBOSE_DEBUG
    if(total <= 0) return;

    mySerial.print("RFID ignored before station=");
    mySerial.print(station);
    mySerial.print(" func=0x");
    if(function < 0x10) mySerial.print("0");
    mySerial.print(function, HEX);
    mySerial.print(" total=");
    mySerial.println(total);
    RFID_DebugPrintBytes("RFID ignored sample", ignored, len);
#else
    (void)station;
    (void)function;
    (void)ignored;
    (void)len;
    (void)total;
#endif
}

bool RFID_TryRecoverMissingStation(byte station, byte function, byte* rx, int expectedLen, const byte* ignored, int ignoredLen)
{
    int shortLen = expectedLen - 1;
    if(expectedLen > RFID_READ_RESPONSE_LEN) return false;
    if(shortLen <= 0 || ignoredLen < shortLen) return false;

    for(int start = 0 ; start <= ignoredLen - shortLen ; start++)
    {
        byte recovered[RFID_READ_RESPONSE_LEN];
        recovered[0] = station;
        for(int i = 0 ; i < shortLen ; i++)
        {
            recovered[i + 1] = ignored[start + i];
        }

        if(recovered[1] != function) continue;
        if(function == 0x03 && recovered[2] != 0x08) continue;

        if(Get_CRC16(recovered , expectedLen) == 0)
        {
            for(int i = 0 ; i < expectedLen ; i++)
            {
                rx[i] = recovered[i];
            }
            RFID_LastRecovered = true;
#if RFID_DEBUG_ENABLE && RFID_VERBOSE_DEBUG
            RFID_DebugPrintBytes("RFID RX RECOVERED_MISSING_STATION", rx, expectedLen);
#endif
            return true;
        }
    }

    return false;
}

void RFID_ReportStats()
{
#if RFID_DEBUG_ENABLE

    bool hasError = false;
    for(int i = 0 ; i < 5 ; i++)
    {
        if(RFID_ErrorCount[i] > 0)
        {
            hasError = true;
            break;
        }
    }
    if(!hasError) return;

    unsigned long now = millis();
    if((now - RFID_LastReportTime) < RFID_REPORT_INTERVAL_MS) return;
    RFID_LastReportTime = now;

    mySerial.println("RFID station stats:");
    for(int i = 0 ; i < 5 ; i++)
    {
        mySerial.print("  station=");
        mySerial.print(i + 1);
        mySerial.print(" success=");
        mySerial.print(RFID_SuccessCount[i]);
        mySerial.print(" error=");
        mySerial.print(RFID_ErrorCount[i]);
        mySerial.print(" recovered=");
        mySerial.println(RFID_RecoveredCount[i]);
    }
#endif
}

bool RFID_ReadResponse(byte station, byte function, byte* rx, int expectedLen, int firstByteTimeoutMs, int interByteTimeoutMs)
{
    int rxLen = 0;
    bool errorPrinted = false;
    int ignoredLen = 0;
    int ignoredTotal = 0;
    byte ignoredBytes[RFID_IGNORED_DEBUG_SIZE];
    unsigned long startTime = millis();
    unsigned long lastByteTime = startTime;
    RFID_LastRecovered = false;

    while((millis() - startTime) < (unsigned long)firstByteTimeoutMs)
    {
        while(mySerial_485.available())
        {
            byte value = mySerial_485.read();

            if(rxLen == 0 && value != station)
            {
                if(ignoredLen < RFID_IGNORED_DEBUG_SIZE)
                {
                    ignoredBytes[ignoredLen] = value;
                    ignoredLen++;
                }
                ignoredTotal++;
                continue;
            }

            if(rxLen >= expectedLen)
            {
                RFID_DebugError(station, function, "RX_OVERFLOW", rx, rxLen);
                errorPrinted = true;
                rxLen = 0;
                continue;
            }

            rx[rxLen] = value;
            rxLen++;
            lastByteTime = millis();

            if(rxLen == 2 && rx[1] != function)
            {
                RFID_DebugError(station, function, "FUNCTION_MISMATCH", rx, rxLen);
                errorPrinted = true;
                rxLen = 0;
                continue;
            }

            if(function == 0x03 && rxLen == 3 && rx[2] != 0x08)
            {
                RFID_DebugError(station, function, "BYTE_COUNT_MISMATCH", rx, rxLen);
                errorPrinted = true;
                rxLen = 0;
                continue;
            }

            if(rxLen == expectedLen)
            {
                if(Get_CRC16(rx , expectedLen) == 0)
                {
                    RFID_DebugIgnoredBytes(station, function, ignoredBytes, ignoredLen, ignoredTotal);
                    RFID_DebugPrintBytes("RFID RX OK", rx, rxLen);
                    return true;
                }
                RFID_DebugIgnoredBytes(station, function, ignoredBytes, ignoredLen, ignoredTotal);
                RFID_DebugError(station, function, "CRC_ERROR", rx, rxLen);
                errorPrinted = true;
                return false;
            }
        }

        if(rxLen > 0 && (millis() - lastByteTime) >= (unsigned long)interByteTimeoutMs)
        {
            RFID_DebugError(station, function, "INTER_BYTE_TIMEOUT", rx, rxLen);
            errorPrinted = true;
            break;
        }

        delay(0);
    }

    if(!errorPrinted)
    {
        RFID_DebugIgnoredBytes(station, function, ignoredBytes, ignoredLen, ignoredTotal);
        if(RFID_TryRecoverMissingStation(station, function, rx, expectedLen, ignoredBytes, ignoredLen))
        {
            return true;
        }
        RFID_DebugError(station, function, "FIRST_BYTE_TIMEOUT", rx, rxLen);
    }
    return false;
}

bool RFID_ModbusTransaction(byte station, const byte* tx, int txLen, byte* rx, int expectedLen, int firstByteTimeoutMs, int interByteTimeoutMs)
{
    byte function = tx[1];

    Clear_RFID_485_RX();
    if(RFID_BUS_QUIET_BEFORE_TX_US > 0)
    {
        delayMicroseconds(RFID_BUS_QUIET_BEFORE_TX_US);
    }
    RFID_DebugPrintBytes("RFID TX", tx, txLen);
    Set_RS485_Tx_Enable();
    mySerial_485.write(tx , txLen);
    mySerial_485.flush();
    Set_RS485_Rx_Enable();

    return RFID_ReadResponse(station, function, rx, expectedLen, firstByteTimeoutMs, interByteTimeoutMs);
}

void sub_RFID_program()
{
    rFID_Enable = Get_RFID_Enable();
    if(rFID_Enable_buf != rFID_Enable)
    {       
#if RFID_DEBUG_ENABLE && RFID_VERBOSE_DEBUG
       printf("RFID_Enable : %d\n" , rFID_Enable);
#endif
       rFID_Enable_buf = rFID_Enable;
       flag_JsonSend = true;
    }
    if(RFID_Init) 
    {
      wiFiConfig.Get_RFID_Enable();
      
    }
    if(!RFID_Init)
    {
        unsigned long now = millis();
        if((long)(now - RFID_GlobalPauseUntil) < 0)
        {
            RFID_ReportStats();
            return;
        }
    }
    for(int i = 0 ; i < 5 ; i++)
    {
      if(RFID_Init)
      {
        if(((wiFiConfig.rFID_Enable >> i) % 2) == 1)Set_Beep(i + 1);     
        CardID[i] = RFID_CARD_EMPTY;
        CardID_buf[i] = RFID_CARD_EMPTY;
      }
      else
      {
        if(((wiFiConfig.rFID_Enable >> i) % 2) == 1)
        {
            unsigned long now = millis();
            if((long)(now - RFID_GlobalPauseUntil) < 0)
            {
                break;
            }
            if((long)(now - RFID_NextReadTime[i]) < 0)
            {
                continue;
            }

            String previousCardID = CardID[i];
            CardID_temp = Get_7CardID(i + 1);
            unsigned long afterRead = millis();

            if(CardID_temp == RFID_CARD_ERROR)
            {
                if(RFID_ConsecutiveFailCount[i] < 255)
                {
                    RFID_ConsecutiveFailCount[i]++;
                }
                RFID_NextReadTime[i] = afterRead + RFID_CARD_FAIL_INTERVAL_MS;

                if(RFID_ConsecutiveFailCount[i] >= RFID_READ_RETRY_COUNT)
                {
                    RFID_ConsecutiveFailCount[i] = 0;
                    RFID_Error++;
                    RFID_ErrorCount[i]++;
                    CardID[i] = RFID_CARD_ERROR;
                }
                continue;
            }

            RFID_ConsecutiveFailCount[i] = 0;
            CardID[i] = CardID_temp;
            bool validCardChanged = (CardID_temp != previousCardID && CardID_temp != RFID_CARD_EMPTY && CardID_temp != RFID_CARD_ERROR);
            if(validCardChanged)
            {
                RFID_GlobalPauseUntil = afterRead + RFID_CARD_CHANGE_PAUSE_MS;
            }
            if(CardID_temp != RFID_CARD_EMPTY)
            {
                RFID_NextReadTime[i] = afterRead + RFID_CARD_SUCCESS_INTERVAL_MS;
            }
            else
            {
                RFID_NextReadTime[i] = afterRead + RFID_CARD_EMPTY_INTERVAL_MS;
            }
        }
        else
        {
           CardID[i] = RFID_CARD_EMPTY;
           CardID_buf[i] = RFID_CARD_EMPTY;
           RFID_NextReadTime[i] = 0;
           RFID_ConsecutiveFailCount[i] = 0;
        } 
      }
      if(RFID_Error >= 20)
      {
//         ESP.restart();       
      }
    }
    RFID_Init = false;
    RFID_ReportStats();
    
}
void Set_RFID_Enable(byte index , bool value)
{
    byte temp = wiFiConfig.Get_RFID_Enable();
    
    if(value)
    {
      temp = temp |(1 << index);
    }    
    else
    {
      temp = temp & ~(1 << index);
    }
    wiFiConfig.Set_RFID_Enable(temp);
}
byte Get_RFID_Enable()
{
    return wiFiConfig.rFID_Enable;
}
String Get_7CardID(byte station)
{
   int retry = 0;
   byte tx[8];
   tx[0] = station;
   tx[1] = 0x03;
   tx[2] = 0x00;
   tx[3] = 0x00;
   tx[4] = 0x00;
   tx[5] = 0x04;
   uint16_t CRC = Get_CRC16(tx , 6);
   tx[6] = CRC;
   tx[7] = (CRC >> 8);

   for(retry = 0 ; retry < 1 ; retry++)
   {
     for (int i = 0 ; i < RFID_RX_SIZE ; i++)
     {
         RFID_RX[i] = 0;         
     }

     if(RFID_ModbusTransaction(station, tx, 8, RFID_RX, RFID_READ_RESPONSE_LEN, RFID_FIRST_BYTE_TIMEOUT_MS, RFID_INTER_BYTE_TIMEOUT_MS))
     {
        if(station >= 1 && station <= 5)
        {
            RFID_SuccessCount[station - 1]++;
            if(RFID_LastRecovered)
            {
                RFID_RecoveredCount[station - 1]++;
            }
        }
        String HEX_0 = RFID_ByteToHex(RFID_RX[3]);
        String HEX_1 = RFID_ByteToHex(RFID_RX[4]);
        String HEX_2 = RFID_ByteToHex(RFID_RX[5]);
        String HEX_3 = RFID_ByteToHex(RFID_RX[6]);
        String HEX_4 = RFID_ByteToHex(RFID_RX[7]);
        String HEX_5 = RFID_ByteToHex(RFID_RX[8]);
        String HEX_6 = RFID_ByteToHex(RFID_RX[9]);
        RFID_Error = 0;
        String CardID = HEX_0 + HEX_1 + HEX_2 + HEX_3 + HEX_4 + HEX_5 + HEX_6;
#if RFID_DEBUG_ENABLE && RFID_VERBOSE_DEBUG
        {
           printf("station : %d , ID : " ,station);
           mySerial.println(CardID);
        }
#endif
        return CardID;
     }
     else
     {
#if RFID_DEBUG_ENABLE && RFID_VERBOSE_DEBUG
        printf("station : %d , RFID read retry : %d\n" ,station ,retry + 1);
#endif
        if(RFID_AFTER_FAIL_DELAY_MS > 0)
        {
            delay(RFID_AFTER_FAIL_DELAY_MS);
        }
     }
   }
   return RFID_CARD_ERROR;
}
bool Set_Beep(byte station)
{
   int retry = 0;
   byte tx[8];
   tx[0] = station;
   tx[1] = 0x06;
   tx[2] = 0x00;
   tx[3] = 0x04;
   tx[4] = 0x00;
   tx[5] = 0x02;   
   uint16_t CRC = Get_CRC16(tx , 6);
   tx[6] = CRC;
   tx[7] = (CRC >> 8);

   for(retry = 0 ; retry < RFID_WRITE_RETRY_COUNT ; retry++)
   {
     for (int i = 0 ; i < RFID_RX_SIZE ; i++)
     {
         RFID_RX[i] = 0;         
     }

     if(RFID_ModbusTransaction(station, tx, 8, RFID_RX, RFID_WRITE_RESPONSE_LEN, 200, RFID_INTER_BYTE_TIMEOUT_MS))
     {
        bool echoOk = true;
        for(int i = 0 ; i < RFID_WRITE_RESPONSE_LEN ; i++)
        {
            if(tx[i] != RFID_RX[i])
            {
                echoOk = false;
                break;
            }
        }
        if(echoOk)
        {
#if RFID_DEBUG_ENABLE && RFID_VERBOSE_DEBUG
            printf("RFID Set Beep sucess , station : %d \n",station);
#endif
            return true;
        }
        RFID_DebugError(station, tx[1], "WRITE_ECHO_MISMATCH", RFID_RX, RFID_WRITE_RESPONSE_LEN);
     }
     else
     {        
#if RFID_DEBUG_ENABLE && RFID_VERBOSE_DEBUG
        printf("RFID Set Beep retry , station : %d , retry : %d \n",station, retry + 1);
#endif
        if(RFID_AFTER_FAIL_DELAY_MS > 0)
        {
            delay(RFID_AFTER_FAIL_DELAY_MS);
        }
     }
   }
#if RFID_DEBUG_ENABLE && RFID_VERBOSE_DEBUG
   printf("RFID Set Beep failed , station : %d \n",station);
#endif
   return false;    
}
void Set_RS485_Rx_Enable()
{
    delayMicroseconds(1500);
    digitalWrite(PIN_485_Tx_Eanble, LOW);
}
void Set_RS485_Tx_Enable()
{
    digitalWrite(PIN_485_Tx_Eanble, HIGH);
}
