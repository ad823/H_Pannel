#include "Global.h"
#include "FADC.h"

#ifdef FADC
bool flag_FADC_motorTrigger = false;
bool flag_FADC_lockerTrigger = false;

MyTimer MyTimer_FADC_motorDelay;
byte cnt_FADC_motorTrigger = 255;
int FADC_motorDelayTime = 0;
bool flag_FADC_motorOutput = true;

MyTimer MyTimer_FADC_lockerDelay;
byte cnt_FADC_lockerTrigger = 255;
int FADC_lockerDelayTime = 1000;

bool flag_FADC_lokerInput = false;
bool flag_FADC_lokerInput_buf = false;
bool flag_FADC_lokerOutput = false;

bool flag_FADC_buttonInput = false;
bool flag_FADC_buttonInput_buf = false;

void FADC_LockerInputRead()
{
     flag_FADC_lokerInput = !mcp.digitalRead(LOCKER_INPUT);
     if(flag_FADC_lokerInput != flag_FADC_lokerInput_buf)
     {
        flag_FADC_lokerInput_buf = flag_FADC_lokerInput;
        bool lock_input = flag_FADC_lokerInput_buf;
        if(((Input_dir >> 0) % 2 ) ==  1) lock_input = !lock_input;
        Input = lock_input ? 1 : 0 ; 
        flag_JsonSend = true;
        mySerial.println(String(F("(*)FADC_LockerInputRead,Input (")) + flag_FADC_lokerInput_buf + F(")"));
     }
}
void FADC_ButtonInputRead()
{
     flag_FADC_buttonInput = !mcp.digitalRead(BUTTON_EX_INPUT);
     if(flag_FADC_buttonInput != flag_FADC_buttonInput_buf)
     {
        flag_FADC_buttonInput_buf = flag_FADC_buttonInput;
        flag_JsonSend = true;
        mySerial.println(String(F("(*)FADC_ButtonInputRead,Input (")) + flag_FADC_buttonInput_buf + F(")"));
     }
}
void FADC_LockerTrigger()
{
    if(cnt_FADC_lockerTrigger == 255)
    {
         
         if(flag_FADC_lockerTrigger == true) 
         {
             mySerial.println(F("(255)FADC_lockerTrigger,wait trigger.."));
             flag_FADC_lokerOutput = true;
             mcp.digitalWrite(LOCKER_OUTPUT , false);
             cnt_FADC_lockerTrigger = 1;
         }
    }
    if(cnt_FADC_lockerTrigger == 1)
    {
        MyTimer_FADC_lockerDelay.TickStop();
        MyTimer_FADC_lockerDelay.StartTickTime(FADC_lockerDelayTime);
        mySerial.print(F("(1)FADC_lockerTrigger,StartTickTime("));
        mySerial.print(FADC_lockerDelayTime);
        mySerial.println(F(")"));
        cnt_FADC_lockerTrigger++;
    }
    if(cnt_FADC_lockerTrigger == 2)
    {
        if(MyTimer_FADC_lockerDelay.IsTimeOut())
        {
          mySerial.println(F("(2)FADC_lockerTrigger,delay time until..."));            
          cnt_FADC_lockerTrigger = 254;
        }
    }
    if(cnt_FADC_lockerTrigger != 255) 
    {
        if(flag_FADC_lockerTrigger == false)
        {
           cnt_FADC_lockerTrigger = 254;
        }
    }
    if(cnt_FADC_lockerTrigger == 254)
    {
       mySerial.println(F("(254)FADC_lockerTrigger,locker stop..."));  
       cnt_FADC_lockerTrigger = 255;
       MyTimer_FADC_lockerDelay.TickStop();
       flag_FADC_lokerOutput = false;
       mcp.digitalWrite(LOCKER_OUTPUT , true);
       flag_FADC_lockerTrigger = false;
    }
}

void FADC_MotorTrigger()
{
    
    if(cnt_FADC_motorTrigger == 255)
    {
         
         if(flag_FADC_motorTrigger == true) 
         {
             mySerial.println(F("(255)FADC_MotorTrigger,trigger.."));
             flag_FADC_motorOutput = true;
             mcp.digitalWrite(DC_MOTOR_OUTPUT , false);
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
       mySerial.println(F("(254)FADC_MotorTrigger,motor stop..."));  
       cnt_FADC_motorTrigger = 255;
       MyTimer_FADC_motorDelay.TickStop();
       flag_FADC_motorOutput = false;
       mcp.digitalWrite(DC_MOTOR_OUTPUT , true);
       flag_FADC_motorTrigger = false;
    }
}
#endif
