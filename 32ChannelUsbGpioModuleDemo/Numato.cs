using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _32ChannelUsbGpioDemo
{
    class Numato
    {
        public Numato(ref string port, System.IO.Ports.SerialPort serPort)
        {
            serialPort1 = serPort;
            if (!serialPort1.IsOpen)                                                                   //condition
            {
                serialPort1.PortName = "COM" + port;                                            //initializing serial port with proper argument from text box
                serialPort1.BaudRate = 9600;                                                                     //specifying baudrate              
                serialPort1.Open();                                                                          //open serial port
            }
            else                                                                                                  //condition
            {
                serialPort1.Close();                                                                          //close serial port
            }
        }

        public void gpioPinCommand(int gpioNum, bool value)
        {
            string gpioIndex;
            if (gpioNum < 10)
            {
                gpioIndex = gpioNum.ToString();
            }
            else
            {
                gpioIndex = (char)55 + gpioNum.ToString();
            }
            //Send "gpio write" command. GPIO number 10 and beyond are
            //referenced in the command by using alphabets starting A. For example
            //GPIO10 willbe A, GPIO11 will be B and so on. Please note that this is
            //not intended to be hexadecimal notation so the the alphabets can go 
            //beyond F.
            if (value)
            {
                serialPort1.Write("gpio " + "set" + " " + gpioIndex + "\r");
            }
            else
            {
                serialPort1.Write("gpio " + "clear" + " " + gpioIndex + "\r");
            }
        }
        private System.IO.Ports.SerialPort serialPort1;
    }
}