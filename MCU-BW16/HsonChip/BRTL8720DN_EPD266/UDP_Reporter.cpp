#include "Arduino.h"
#include "UDP_Reporter.h"

int cnt_UDP_Send = 65534;
MyTimer UDP_Send_Timer;
DynamicJsonDocument doc(1024);
String JsonOutput = "";

int RSSI;
void sub_UDP_Send()
{
  if(cnt_UDP_Send == 65534)
  {

      cnt_UDP_Send = 65535;
  }
  if(cnt_UDP_Send == 65535)
  {
      if(flag_boradInit)cnt_UDP_Send = 1;
  }
  if(cnt_UDP_Send == 1)
  {  
      if(wiFiConfig.uDP_SemdTime == 0)
      {
          cnt_UDP_Send = 1;
      }
      else
      {
          UDP_Send_Timer.TickStop();
          UDP_Send_Timer.StartTickTime(wiFiConfig.uDP_SemdTime);
          cnt_UDP_Send++;
      }
      
  }
  if(cnt_UDP_Send == 2)
  {      
      if(UDP_Send_Timer.IsTimeOut() || flag_JsonSend)
      {
         doc["Version"] = VERSION;
         #ifdef EPD_TYPE
         doc["EPD_TYPE"] = EPD_TYPE;
         #endif
         doc["IP"] = wiFiConfig.Get_IPAdress_Str();
         doc["Port"] = wiFiConfig.Get_Localport();
         doc["RSSI"] = wiFiConfig.GetRSSI();                
         doc["Input"] = Input;
         doc["Output"] = Output;
         doc["Input_dir"] = Input_dir;
         doc["Output_dir"] = Output_dir;        
         doc["WS2812_State"] = myWS2812.IsON(200);    
          
         #ifdef HandSensor       
         doc["LASER_ON_num"] = LASER_ON_num;
         doc["LaserDistance"] = LaserDistance;  
         doc["LASER_ON"] = LASER_ON;
         #endif  
         #ifdef DHTSensor
         doc["dht_h"] = dht_h;
         doc["dht_t"] = dht_t;
         #endif
         #ifdef FADC
         doc["FADC_lokerInput"] = flag_FADC_lokerInput;
         doc["FADC_lokerInput"] = flag_FADC_lokerInput;
         doc["FADC_buttonInput"] = flag_FADC_buttonInput;
         #endif
         
         JsonOutput = "";
         serializeJson(doc, JsonOutput);
         #ifdef MQTT
         #ifdef DHTSensor
         wiFiConfig.MQTT_publishMessage("DHTSensor" , JsonOutput.c_str() , false);  
         #endif
         #else
         Send_StringTo(JsonOutput, wiFiConfig.server_IPAdress, wiFiConfig.serverport);      
         #endif
//         if(flag_udp_232back)mySerial.println(JsonOutput);

              
         flag_JsonSend = false;
         cnt_UDP_Send++;
      }
  }
  if(cnt_UDP_Send == 3)
  {
     cnt_UDP_Send = 65535;
  }
}
