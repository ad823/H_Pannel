using System;
using System.Drawing;
using System.Drawing.Imaging;
using H_Pannel_lib;
public class Program
{
    static private EPD_Type EPD_Type = EPD_Type.EPD213_BRW_V0;
    static string ServerIP = "192.168.5.50";
    static string ClintIP = "192.168.43.251";

    static void Main(string[] args)
    {
  

        try
        {
            string ip = "192.168.42.172";
            UDP_Class uDP_Class1 = new UDP_Class(ip, 29008, false);
            string json = Communication.Get_JsonStrin(uDP_Class1, ip);

            return;

          


        }
        catch (Exception ex)
        
        {
            Console.WriteLine($"處理失敗: {ex.Message}");
        }
    }




}
