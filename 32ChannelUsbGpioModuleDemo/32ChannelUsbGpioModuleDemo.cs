//Calling default system parameters.
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace _32ChannelUsbGpioDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Seq = new bool[8][];
            Seq[0] = new bool[4]{false,true,false,false};
            Seq[1] = new bool[4]{false,true,false,true};
            Seq[2] = new bool[4]{false,false,false,true};
            Seq[3] = new bool[4]{true,false,false,true};
            Seq[4] = new bool[4]{true,false,false,false};
            Seq[5] = new bool[4]{true,false,true,false};
            Seq[6] = new bool[4]{false,false,true,false};
            Seq[7] = new bool[4]{false,true,true,false};
        }
        int coil_A_1_pin = 1;
        int coil_A_2_pin = 2;
        int coil_B_1_pin = 3;
        int coil_B_2_pin = 4;
        int enable_pin   = 5;
        // anpassen, falls andere Sequenz
        int StepCount = 8;

        bool[][] Seq;
       
        void gpioPinCommand(int gpioNum, bool value)
        {
            string gpioIndex;
	        if (gpioNum < 10)
	            gpioIndex = gpioNum.ToString();
	        else
	            gpioIndex = (char)55 + gpioNum.ToString();

	        //Send "gpio write" command. GPIO number 10 and beyond are
	        //referenced in the command by using alphabets starting A. For example
	        //GPIO10 willbe A, GPIO11 will be B and so on. Please note that this is
	        //not intended to be hexadecimal notation so the the alphabets can go 
	        //beyond F.
            if(value)
            {
	            serialPort1.Write("gpio "+ "set" +" "+ gpioIndex  + "\r");
            }
            else
            {
                serialPort1.Write("gpio "+ "clear" +" "+ gpioIndex  + "\r");
            }
        }

        void setStep(bool w1, bool w2, bool w3, bool w4)
        {
	        gpioPinCommand(coil_A_1_pin, w1);
	        gpioPinCommand(coil_A_2_pin, w2);
	        gpioPinCommand(coil_B_1_pin, w3);
	        gpioPinCommand(coil_B_2_pin, w4);
        }
        void forward(int delay, int steps)
        {
            for(int i = 0; i < steps; i++)
            {
                for(int j = 0; j < StepCount; j++)
                {
                    setStep(Seq[j][0], Seq[j][1], Seq[j][2], Seq[j][3]);
                    //System.Threading.Thread.Sleep(delay);
                }
            }
            setStep(false, false, false, false);
        }
        void backwards(int delay, int steps)
        {
            for(int i = 0; i < steps; i++)
            {
                for (int j = StepCount - 1; j >= 0; j--)
                {
                    setStep(Seq[j][0], Seq[j][1], Seq[j][2], Seq[j][3]);
                    //System.Threading.Thread.Sleep(delay);
                }
            }
            setStep(false, false, false, false);
        }
        
        private void openportButton_Click(object sender, EventArgs e)
        {
            if ((serialPort1.IsOpen) == false)                                                                   //condition
            {
                serialPort1.PortName = "COM" + comportNumberbox.Text;                                            //initializing serial port with proper argument from text box
                serialPort1.BaudRate = 9600;                                                                     //specifying baudrate              
                try                                                                                              //do or act
                {
                    serialPort1.Open();                                                                          //open serial port
                    openportButton.Text = "Close COM Port";                                                      //display changed according to button state of action
                    gpiosetButton.Enabled = true;                                                                //condition
                    gpioreadButton.Enabled = true;                                                               //condition
                }
                catch                                                                                            //exception
                {
                    MessageBox.Show("Could Not Open Specified Port !");                                          //display
                }
            }
            else                                                                                                  //condition
            {
                try                                                                                               //do or act
                {
                    serialPort1.Close();                                                                          //close serial port
                    openportButton.Text = "Open COM Port";                                                        //display changed
                    gpiosetButton.Enabled = false;                                                                //condition
                    gpioreadButton.Enabled = false;                                                               //condition
                    comportNumberbox.Text = String.Empty;                                                         //conditional case
              }
                catch                                                                                             //exception
                {
                    MessageBox.Show("Could Not Open Specified Port !");                                           //display
                }
            }
        }

        private void gpiosetButton_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)  
                serialPort1.Open();
            {     
                serialPort1.DiscardInBuffer();                                                    //discard input buffer
                backwards(1, 30);
                                    //system sleep
                serialPort1.DiscardOutBuffer();                                                   //discard output buffer
            }      
        }

        private void gpioreadButton_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)                                                                          //condition
                serialPort1.Open();
            {
                serialPort1.DiscardInBuffer();
                forward(1, 30);
            }  
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gpiosetButton.Enabled = false;                                                                         //condition
            gpioreadButton.Enabled = false;                                                                        //condition
        }
    }
}
