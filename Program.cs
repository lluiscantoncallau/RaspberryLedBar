using System;
using System.Device.Gpio;
using System.Threading;

namespace RaspberryLedBar
{
    class Program
    {
        static void Main(string[] args)
        {
            var controller = new GpioController();
            int[] ledPin = { 17, 18, 19, 20, 21, 22, 23, 24, 25, 26 };
           
            try
            {
                Console.WriteLine("Start Led Bar");

               while (true)
                {
                    foreach(var item in ledPin)
                    {
                        controller.Write(item, PinValue.High);
                        Thread.Sleep(100);
                        controller.Write(item, PinValue.Low);
                    }
                    for (var i = ledPin.Length -1; i>0; i--)
                    {
                        controller.Write(ledPin[i], PinValue.High);
                        Thread.Sleep(100);
                        controller.Write(ledPin[i], PinValue.Low);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                foreach (var item in ledPin)
                {
                    controller.ClosePin(item);
                    
                }               
            }
        }
    }
}

