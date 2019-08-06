using System;
using System.IO.Ports;
namespace serial_port_monitor
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get a list of serial port names.
            string[] ports = SerialPort.GetPortNames();
            Console.WriteLine("The following serial ports were found:");
            // Display each port name to the console.
            foreach (string p in ports)
            {
                Console.WriteLine(p);
            }

            var serial = Environment.GetEnvironmentVariable("SERIAL_PORT");
            var _serialPort = new SerialPort(serial, 9600);

            // Set the read/write timeouts
            _serialPort.ReadTimeout = 1500;
            _serialPort.WriteTimeout = 1500;
            _serialPort.Open();
            while (true)
            {
                try
                {
                    string message = _serialPort.ReadLine();
                    Console.WriteLine(message);
                }
                catch (TimeoutException) { }
            }
        }
    }
}