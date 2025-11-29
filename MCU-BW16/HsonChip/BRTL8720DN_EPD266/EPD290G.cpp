#include "Arduino.h"
#include <SPI.h>
#include "EPD290G.h"

void EPD290G::melloc_init() 
{
    if(flag_melloc_init)return;
    mySerial->print("epd malloc : ");
    mySerial->print(9472);
    mySerial->println(" bytes");

    framebuffer = (byte*) malloc(9472);
    buffer_max = 9472;
    flag_melloc_init = true;
}

void EPD290G::Clear() 
{
    SPI_Begin();
    SendCommand(0x10);

    int Width, Height;
    Width = 32;
    Height = 296;

    SendCommand(0x10);
    for (int j = 0; j < Height / 2; j++) 
    {
        for (int i = 0; i < Width; i++) 
        {
            SendData((EPD_290G_YELLOW << 6) | (EPD_290G_YELLOW << 4) | (EPD_290G_YELLOW << 2) | EPD_290G_YELLOW);
        }
    }    
    for (int j = 0; j < Height / 2; j++) 
    {
        for (int i = 0; i < Width; i++) 
        {
            SendData((EPD_290G_RED << 6) | (EPD_290G_RED << 4) | (EPD_290G_RED << 2) | EPD_290G_RED);
        }
    } 
    
    RefreshCanvas();
    SPI_End();
}

void EPD290G::DrawFrame_BW() 
{
    SPI_Begin();
    SendCommand(0x10);
    for (int i = 0; i < 9472; i++) 
    {
      SendData(*(framebuffer + i));
    }
    SPI_End();
}

void EPD290G::DrawFrame_RW() 
{
    SPI_Begin();
    SendCommand(0x10);
    for (int i = 0; i < 9472; i++) 
    {
      SendData(*(framebuffer + i));
    }
    SPI_End();
}

void EPD290G::RefreshCanvas() 
{
    SPI_Begin();
    SendCommand(0x12); // DISPLAY_REFRESH
    SendData(0x00);
    SPI_End();
    Sleep();
    mySerial -> println("EPD290G RefreshCanvas...");
    
}

void EPD290G::Sleep() 
{
    SPI_Begin();
    SendCommand(0x07); // DEEP_SLEEP
    SendData(0XA5);
    SPI_End();
}

void EPD290G::BW_Command() 
{
    
}

void EPD290G::RW_Command() 
{
   
}

void EPD290G::Wakeup() 
{
    mySerial -> println("EPD290G Init...");
    this -> MyTimer_SleepWaitTime.TickStop();  
    this -> MyTimer_SleepWaitTime.StartTickTime(90000);
    this -> SetToSleep = false;    
    HardwareReset();
    delay(100);
    SPI_Begin();
    SendCommand(0x4D);
    SendData(0x78);
  
    SendCommand(0x00); //PSR
    SendData(0x0F);
    SendData(0x29);
  
    SendCommand(0x01); //PWRR
    SendData(0x07);
    SendData(0x00);
    
    SendCommand(0x03); //POFS
    SendData(0x10);
    SendData(0x54);
    SendData(0x44);
    
    SendCommand(0x06); //BTST_P
    SendData(0x05);
    SendData(0x00);
    SendData(0x3F);
    SendData(0x0A);
    SendData(0x25);
    SendData(0x12);
    SendData(0x1A); 
  
    SendCommand(0x50); //CDI
    SendData(0x37);
    
    SendCommand(0x60); //TCON
    SendData(0x02);
    SendData(0x02);
    
    SendCommand(0x61); //TRES
    SendData(128/256);   // Source_BITS_H
    SendData(128%256);   // Source_BITS_L
    SendData(296/256);     // Gate_BITS_H
    SendData(296%256);     // Gate_BITS_L  
    
    SendCommand(0xE7);
    SendData(0x1C);
    
    SendCommand(0xE3); 
    SendData(0x22);
    
    SendCommand(0xB4);
    SendData(0xD0);
    SendCommand(0xB5);
    SendData(0x03);
    
    SendCommand(0xE9);
    SendData(0x01); 
  
    SendCommand(0x30);
    SendData(0x08);  
    
    SendCommand(0x04);
    WaitUntilIdle();
    SPI_End();
    mySerial -> println("EPD290G done...");
}


void EPD290G::WaitUntilIdle() 
{
    mySerial -> println("WaitUntilIdle....");
    delay(200);
//    while(!digitalRead(this -> PIN_BUSY))
//    {
//       delay(10);
//       
//    }
    mySerial -> println("WaitUntilIdle OK....");
}

void EPD290G::SPI_Begin() 
{
    SPI.beginTransaction(SPISettings(2000000, MSBFIRST, SPI_MODE0));
}

void EPD290G::SetCursor(int Xstart, int Ystart)
{
  
}
void EPD290G::SetWindows(int Xstart, int Ystart, int Xend, int Yend)
{
  
}
