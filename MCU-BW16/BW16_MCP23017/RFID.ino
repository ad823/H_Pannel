MyTimer MyTimer_RFID;
#define RFID_RX_SIZE 512
static byte RFID_RX[RFID_RX_SIZE];

int RFID_len;
byte rFID_Enable = 0;
byte rFID_Enable_buf = -1;
bool RFID_Init = true;
String CardID_temp = "";
int RFID_Error = 0;

void Clear_RFID_485_RX()
{
    while(mySerial_485.available())
    {
        mySerial_485.read();
    }
}

bool RFID_Check_CRC(int len)
{
    return Get_CRC16(RFID_RX , len) == 0;
}

String RFID_ByteToHex(byte value)
{
    String hex = String(value, HEX);
    if(hex.length() < 2) hex = "0" + hex;
    hex.toUpperCase();
    return hex;
}

void sub_RFID_program()
{
    rFID_Enable = Get_RFID_Enable();
    if(rFID_Enable_buf != rFID_Enable)
    {       
       if(flag_udp_232back)printf("RFID_Enable : %d\n" , rFID_Enable);
       rFID_Enable_buf = rFID_Enable;
       flag_JsonSend = true;
    }
    if(RFID_Init) 
    {
      wiFiConfig.Get_RFID_Enable();
      
    }
    for(int i = 0 ; i < 5 ; i++)
    {
      if(RFID_Init)
      {
        if(((wiFiConfig.rFID_Enable >> i) % 2) == 1)Set_Beep(i + 1);     
        CardID[i] = "00000000000000";
        CardID_buf[i] = "00000000000000";     
      }
      else
      {
        if(((wiFiConfig.rFID_Enable >> i) % 2) == 1)
        {
            CardID_temp = Get_7CardID(i + 1);
            CardID[i] = CardID_temp;
            
        }
        else
        {
           CardID[i] = "00000000000000";
           CardID_buf[i] = "00000000000000";     
        } 
      }
      if(RFID_Error >= 20)
      {
//         ESP.restart();       
      }
    }
    RFID_Init = false;
    
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
   byte flag_rx_ok = 0;
   byte read_temp;
   while(true)
   {
     if(retry >= 3) 
     {
        RFID_Error++;
        break;
     }
     flag_rx_ok = 0;
     Clear_RFID_485_RX();
     Set_RS485_Tx_Enable();
     mySerial_485.write(tx , 8);
     mySerial_485.flush();     
     Set_RS485_Rx_Enable();
     RFID_len = 0;
     for (int i = 0 ; i < RFID_RX_SIZE ; i++)
     {
         RFID_RX[i] = 0;         
     }
     MyTimer_RFID.TickStop();
     MyTimer_RFID.StartTickTime(100);
     while(true)
     {
        if (mySerial_485.available())
        {
          read_temp = mySerial_485.read();

          if(RFID_len == 0 && read_temp != station)
          {
             continue;
          }

          if(RFID_len < RFID_RX_SIZE)
          {
            RFID_RX[RFID_len] = read_temp;
//            if(flag_udp_232back)printf("value: %d , RFID_len : %d \n" ,read_temp,RFID_len);
            RFID_len++;
            MyTimer_RFID.TickStop();
            MyTimer_RFID.StartTickTime(100);
          }
          else
          {
             RFID_len = 0;
             break;
          }

          if(RFID_len == 2 && RFID_RX[1] != 0x03)
          {
             RFID_len = 0;
             MyTimer_RFID.TickStop();
             MyTimer_RFID.StartTickTime(100);
             continue;
          }

          if(RFID_len == 3 && RFID_RX[2] != 0x08)
          {
             RFID_len = 0;
             MyTimer_RFID.TickStop();
             MyTimer_RFID.StartTickTime(100);
             continue;
          }
        }
        if(RFID_len == 13)
        {
           flag_rx_ok = 0;
           if(station == RFID_RX[0]) flag_rx_ok++;
           if(0x03 == RFID_RX[1]) flag_rx_ok++;
           if(0x08 == RFID_RX[2]) flag_rx_ok++;  
           if(RFID_Check_CRC(13)) flag_rx_ok++;
           if(flag_rx_ok == 4)
           {
              break;    
           }
           RFID_len = 0;
           flag_rx_ok = 0;
        } 
        if (MyTimer_RFID.IsTimeOut())
        {
                           
           break;         
        }
        delay(1);
     }
     if(flag_rx_ok == 4)
     {
        String HEX_0 = RFID_ByteToHex(RFID_RX[3]);
        String HEX_1 = RFID_ByteToHex(RFID_RX[4]);
        String HEX_2 = RFID_ByteToHex(RFID_RX[5]);
        String HEX_3 = RFID_ByteToHex(RFID_RX[6]);
        String HEX_4 = RFID_ByteToHex(RFID_RX[7]);
        String HEX_5 = RFID_ByteToHex(RFID_RX[8]);
        String HEX_6 = RFID_ByteToHex(RFID_RX[9]);
        RFID_Error = 0;
        String CardID = HEX_0 + HEX_1 + HEX_2 + HEX_3 + HEX_4 + HEX_5 + HEX_6;
        if(flag_udp_232back)
        {
           printf("station : %d , ID : " ,station);
           mySerial.println(CardID);
        }
        return HEX_0 + HEX_1 + HEX_2 + HEX_3 + HEX_4 + HEX_5 + HEX_6;
     }
     else
     {
        if(flag_udp_232back)printf("station : %d , RFID_len : %d\n" ,station ,RFID_len);
        retry++;
     }
     delay(1);
   }
   return "";   
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
   byte flag_rx_ok = 0;
   byte read_temp;
   while(true)
   {
     if(retry >= 2) break;
     flag_rx_ok = 0;
     Clear_RFID_485_RX();
     Set_RS485_Tx_Enable();
     mySerial_485.write(tx , 8);     
     mySerial_485.flush();
     Set_RS485_Rx_Enable();
     RFID_len = 0;
     for (int i = 0 ; i < RFID_RX_SIZE ; i++)
     {
         RFID_RX[i] = 0;         
     }
     MyTimer_RFID.TickStop();
     MyTimer_RFID.StartTickTime(200);
     while(true)
     {
          if (mySerial_485.available())
          {
            read_temp = mySerial_485.read();
            if(RFID_len == 0 && read_temp != station)
            {
               continue;
            }
            if(RFID_len < RFID_RX_SIZE)
            {
               RFID_RX[RFID_len] = read_temp;
               RFID_len++;
               MyTimer_RFID.TickStop();
               MyTimer_RFID.StartTickTime(5);
            }
            else
            {
               RFID_len = 0;
               break;
            }
          }
          if(RFID_len == 8)
          {
             flag_rx_ok = 0;
             for(int i = 0 ; i < RFID_len ; i++)
             {
                 if(tx[i]== RFID_RX[i])
                 {
                    flag_rx_ok++;
                 }
             }
             if(flag_rx_ok == 8 && RFID_Check_CRC(8))
             {
                break;
             }
             RFID_len = 0;
             flag_rx_ok = 0;
          }  
          if (MyTimer_RFID.IsTimeOut())
          {
                    
            break;
          }
     }
     if(flag_rx_ok == 8)
     {
        if(flag_udp_232back)printf("RFID Set Beep sucess , station : %d \n",station);
        return true;
     }
     else
     {        
        retry++;
     }
   }
   if(flag_udp_232back)printf("RFID Set Beep failed , station : %d \n",station);
   return false;    
}
void Set_RS485_Rx_Enable()
{
    digitalWrite(PIN_485_Tx_Eanble, LOW);
    delayMicroseconds(100);
}
void Set_RS485_Tx_Enable()
{
    digitalWrite(PIN_485_Tx_Eanble, HIGH);
    delayMicroseconds(100);
}
