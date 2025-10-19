#include "Global.h"
#include "FADC.h"

MyTimer MyTimer_FADC_motorDelay;
byte cnt_FADC_motorTrigger = 255;
byte FADC_motorDelayTime = 0;
void FADC_MotorTrigger()
{
    
    if(cnt_FADC_motorTrigger == 255)
    {
         
         if(flag_FADC_motorTrigger == true) 
         {
             mySerial.println(F("(255)FADC_MotorTrigger,wait trigger.."));
             mcp.digitalWrite(DC_MOTOR_OUTPUT , false);
             mySerial.println(F("(255)FADC_MotorTrigger,wait trigger done.."));
             cnt_FADC_motorTrigger = 1;
         }
    }
    if(cnt_FADC_motorTrigger == 1)
    {
        
        if(mcp.digitalRead(LIGHT_SENSOR_INPUT) == false)
        {      
           mySerial.println(F("(1)FADC_MotorTrigger,motor run.."));
           cnt_FADC_motorTrigger++;
        }
        
    }
    if(cnt_FADC_motorTrigger == 2)
    {
        if(mcp.digitalRead(LIGHT_SENSOR_INPUT) == true)
        {
          MyTimer_FADC_motorDelay.TickStop();
          MyTimer_FADC_motorDelay.StartTickTime(FADC_motorDelayTime);
          mySerial.println(F("(2)FADC_MotorTrigger,light sensor on.."));
          cnt_FADC_motorTrigger++;
        }
    }
    if(cnt_FADC_motorTrigger == 3)
    {
        if(MyTimer_FADC_motorDelay.IsTimeOut())
        {
          mySerial.println(F("(3)FADC_MotorTrigger,light sensor delay time until..."));            
          cnt_FADC_motorTrigger = 254;
        }
    }
    if(cnt_FADC_motorTrigger != 255) 
    {
        if(flag_FADC_motorTrigger == false)
        {
           cnt_FADC_motorTrigger = 254;
        }
    }
    if(cnt_FADC_motorTrigger == 254)
    {
       mySerial.println(F("(4)FADC_MotorTrigger,motor stop..."));  
       cnt_FADC_motorTrigger = 255;
       MyTimer_FADC_motorDelay.TickStop();
       mcp.digitalWrite(DC_MOTOR_OUTPUT , true);
       flag_FADC_motorTrigger = false;
    }
}
