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
                foreach (var item in ledPin)
                {
                    controller.OpenPin(item, PinMode.Output);
                    controller.Write(item, PinValue.High);
                }
                while (true)
                {
                    foreach (var item in ledPin)
                    {
                        controller.Write(item, PinValue.Low);
                        Thread.Sleep(100);
                        controller.Write(item, PinValue.High);
                    }
                    for (var i = ledPin.Length - 1; i > 0; i--)
                    {
                        controller.Write(ledPin[i], PinValue.Low);
                        Thread.Sleep(100);
                        controller.Write(ledPin[i], PinValue.High);
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

