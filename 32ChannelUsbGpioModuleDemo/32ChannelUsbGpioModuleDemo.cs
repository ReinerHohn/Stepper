﻿//Calling default system parameters.
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
                    MessageBox.Show("Port Opened Successfully !");                                               //display
                    openportButton.Text = "Close COM Port";                                                      //display changed according to button state of action

                    verButton.Enabled = true;                                                                    //condition                                              
                    verButton.Enabled = true;                                                                    //condition
                    idsetButton.Enabled = true;                                                                  //condition
                    idgetButton.Enabled = true;                                                                  //condition
                    adcButton.Enabled = true;                                                                    //condition
                    gpiosetButton.Enabled = true;                                                                //condition
                    gpioreadButton.Enabled = true;                                                               //condition
                    iomaskButton.Enabled = true;                                                                 //condition
                    iodirButton.Enabled = true;                                                                  //condition
                    writeallButton.Enabled = true;                                                               //condition
                    readallButton.Enabled = true;                                                                //condition
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
                    MessageBox.Show("Port Closed Successfully !");                                                //display
                    openportButton.Text = "Open COM Port";                                                        //display changed
                    verButton.Enabled = false;                                                                    //condition                                              
                    verButton.Enabled = false;                                                                    //condition
                    idsetButton.Enabled = false;                                                                  //condition
                    idgetButton.Enabled = false;                                                                  //condition
                    adcButton.Enabled = false;                                                                    //condition
                    gpiosetButton.Enabled = false;                                                                //condition
                    gpioreadButton.Enabled = false;                                                               //condition
                    iomaskButton.Enabled = false;                                                                 //condition
                    iodirButton.Enabled = false;                                                                  //condition
                    writeallButton.Enabled = false;                                                               //condition
                    readallButton.Enabled = false;                                                                //condition

                    verBox.Text = String.Empty;                                                                   //conditional case
                    comportNumberbox.Text = String.Empty;                                                         //conditional case
                    idnumberBox.Text = String.Empty;                                                              //conditional case
                    idgetBox.Text = String.Empty;                                                                 //conditional case
                    gpioNumberBox.Text = String.Empty;                                                            //conditional case
                    setStatusBox.Text = String.Empty;                                                             //conditional case
                    gpioNumberReadBox.Text = String.Empty;                                                        //conditional case
                    gpiostatusShowBox.Text = String.Empty;                                                        //conditional case
                    adcNumberBox.Text = String.Empty;                                                             //conditional case
                    adcstatusBox.Text = String.Empty;                                                             //conditional case
                    readallBox.Text = String.Empty;                                                               //conditional case
                    writeallBox.Text = String.Empty;                                                              //conditional case
                    dirBox.Text = String.Empty;                                                                   //conditional case
                    maskBox.Text = String.Empty;                                                                  //conditional case
                }
                catch                                                                                             //exception
                {
                    MessageBox.Show("Could Not Open Specified Port !");                                           //display
                }
            }
        }

        private void verButton_Click(object sender, EventArgs e)
        {
            serialPort1.DiscardInBuffer();                                                                        //discard input buffer
            if (!serialPort1.IsOpen)                                                                              //condition
                serialPort1.Open();
            {
                try                                                                                               //do or act
                {
                    serialPort1.DiscardInBuffer();                                                                //discard input buffer
                    serialPort1.Write("ver\r");                                                                   //writing "ver" command to serial port
                    System.Threading.Thread.Sleep(10);                                                            //system sleep
                    string response = serialPort1.ReadExisting();                                                 //read response string
                    verBox.Text = response.Substring(5, 8);                                                       //extracting string from front end
                    serialPort1.DiscardOutBuffer();                                                               //discard output buffer
                }
                catch                                                                                             //exception
                {
                }
            }         
        }

        private void idsetButton_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)                                                                              //condition
                serialPort1.Open();
            {
                serialPort1.DiscardInBuffer();                                                                    //discard input buffer
                serialPort1.Write("id set " + idnumberBox.Text + "\r");                                           //writing "id set XXXXXXXX" command to serial port
                System.Threading.Thread.Sleep(10);                                                                //system sleep
            }
        }

        private void idgetButton_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)                                                                              //condition
                serialPort1.Open();
            {
                try                                                                                               //do or act
                {
                    serialPort1.DiscardInBuffer();                                                                //discard input buffer
                    serialPort1.Write("id get\r");                                                                //writing "id get" command to serial port
                    System.Threading.Thread.Sleep(10);                                                            //system sleep
                    string response = serialPort1.ReadExisting();                                                 //read response string
                    response = response.Remove(0, 7);                                                             //extracting string from front end
                    response = response.TrimEnd(response[response.Length - 1]);                                   //extracting string from back end
                    idgetBox.Text = response;                                                                     //display
                    serialPort1.DiscardOutBuffer();                                                               //discard output buffer
                }
                catch                                                                                             //exception
                {
                }
            }          
        }

        private void gpiosetButton_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)                                                                          //condition
                serialPort1.Open();
            {
                if (gpioNumberBox.Text.Length != 0)                                                           //condition       
                {
                    if (int.Parse(gpioNumberBox.Text) < 32)                                                   //condition
                    {
                        if ((int.Parse(setStatusBox.Text) == 1) == true)                                      //condition
                        {
                            serialPort1.DiscardInBuffer();                                                    //discard input buffer
                            backwards(1, 30);
                            
                            //serialPort1.Write("gpio set " + gpioNumberBox.Text + "\r");                       //writing "gpio set X" command to serial port
                            //System.Threading.Thread.Sleep(10);                                                //system sleep
                            serialPort1.DiscardOutBuffer();                                                   //discard output buffer
                        }
                        else if ((int.Parse(setStatusBox.Text) == 0) == true)                                 //condition
                        {
                            try                                                                               //do or act
                            {
                                serialPort1.DiscardInBuffer();                                                //discard input buffer
                                //serialPort1.Write("gpio clear " + gpioNumberBox.Text + "\r");                 //writing "gpio set X" command to serial port
                                //System.Threading.Thread.Sleep(10);                                            //system sleep
                                serialPort1.DiscardOutBuffer();                                               //discard output buffer
                            }
                            catch                                                                             //exception
                            {
                            }
                        }
                        else
                        {
                            MessageBox.Show("GPIO status should be 0 or 1 !");                                //display
                        }
                    }
                    else                                                                                      //condition
                    {
                        MessageBox.Show("Please enter a valid gpio number !");                                //display
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a gpio number and gpio status first !");                    //display
                }

            }      
        }

        private void gpioreadButton_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)                                                                          //condition
                serialPort1.Open();
            {
                if (gpioNumberReadBox.Text.Length != 0)                                                       //condition
                {

                    if (int.Parse(gpioNumberReadBox.Text) < 32)                                               //condition
                    {
                        try
                        {
                            serialPort1.DiscardInBuffer();
                            forward(1, 30);
                            //discard input buffer
                            //serialPort1.Write("gpio read " + gpioNumberReadBox.Text + "\r");                  //writing "gpio read X" command to serial port
                            //System.Threading.Thread.Sleep(10);                                                //system sleep
                            //string response = serialPort1.ReadExisting();                                     //read response string
                            //gpiostatusShowBox.Text = response.Substring(13, 1);                               //extracting string from front end
                            //serialPort1.DiscardOutBuffer();                                                   //discard output buffer
                        }
                        catch                                                                                 //exception
                        {
                        }
                    }
                    else                                                                                      //condition
                    {
                        MessageBox.Show("Please enter a valid gpio number !");                                //display
                    }
                }
                else                                                                                          //condition
                {
                    MessageBox.Show("Please enter a gpio number first !");                                    //display
                }
            }  
        }

        private void adcButton_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)                                                                              //condition
                serialPort1.Open();
            if (adcNumberBox.Text.Length != 0)                                                                    //condition
            {
                if (int.Parse(adcNumberBox.Text) < 8)                                                             //condition
                {
                    serialPort1.DiscardInBuffer();                                                                //discard input buffer
                    serialPort1.Write("adc read " + adcNumberBox.Text + "\r");                                    //writing "adc read X" command to serial port
                    System.Threading.Thread.Sleep(10);                                                            //system sleep
                    string response = serialPort1.ReadExisting();                                                 //read response string
                    response = response.Remove(0, 11);                                                            //extracting string from front end
                    response = response.TrimEnd(response[response.Length - 1]);                                   //extracting string from back end
                    adcstatusBox.Text = response;                                                                 //display
                    serialPort1.DiscardOutBuffer();                                                               //discard output buffer
                }
                else                                                                                              //condition
                {
                    MessageBox.Show("Please enter a valid adc number !");                                         //display
                }
            }
            else                                                                                                  //condition
            {
                MessageBox.Show("Please enter a valid adc number first !");                                       //display
            }   
        }

        private void iomaskButton_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)                                                                              //condition
                serialPort1.Open();
            {
                if (maskBox.Text.Length != 0)                                                                     //condition
                {
                    if (maskBox.Text.Length == 8)                                                                 //condition
                    {
                        int convertedinput = int.Parse(maskBox.Text, System.Globalization.NumberStyles.HexNumber);    //hexadecimal to 32bit integer conversion
                            serialPort1.DiscardInBuffer();                                                            //discard input buffer
                            serialPort1.Write("gpio iomask " + maskBox.Text + "\r");                                  //writing "gpio iomask XXXXXXXX" command to serial port
                            System.Threading.Thread.Sleep(10);                                                        //system sleep
                            serialPort1.DiscardOutBuffer();                                                           //discard output buffer
                    }
                    else
                    {
                        MessageBox.Show("Please enter a number within range of 00000000 to ffffffff !");            //display
                    }
                }
                else                                                                                                //condition
                {
                    MessageBox.Show("Please enter a valid iomask number first !");                                  //display
                }
            }  
       }

        private void iodirButton_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)                                                                               //condition
                serialPort1.Open();
            {
                if (dirBox.Text.Length != 0)                                                                       //condition
                {
                    if (dirBox.Text.Length == 8)                                                                   //condition
                    
                        {
                            serialPort1.DiscardInBuffer();                                                          //discard input buffer
                            serialPort1.Write("gpio iodir " + dirBox.Text + "\r");                                  //writing "gpio writeall XXXXXXXX" command to serial port
                            System.Threading.Thread.Sleep(10);                                                      //system sleep
                            serialPort1.DiscardOutBuffer();                                                         //discard output buffer
                        }
                    
                    else
                    {
                        MessageBox.Show("Please enter a number within range of 00000000 to ffffffff !");            //display
                    }
                }
                else                                                                                                //condition
                {
                    MessageBox.Show("Please enter a valid iodir number first !");                                   //display
                }
            }
        }

        private void writeallButton_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)                                                                               //condition
                serialPort1.Open();
            {
                if (writeallBox.Text.Length != 0)                                                                  //condition
                {
                    if (writeallBox.Text.Length == 8)                                                              //condition
                      
                        {
                            serialPort1.DiscardInBuffer();                                                         //discard input buffer
                            serialPort1.Write("gpio writeall " + writeallBox.Text + "\r");                         //writing "gpio writeall XXXXXXXX" command to serial port
                            System.Threading.Thread.Sleep(10);                                                     //system sleep
                            serialPort1.DiscardOutBuffer();                                                        //discard output buffer
                        }
                    
                    else
                    {
                        MessageBox.Show("Please enter a number within range of 00000000 to ffffffff !");           //display
                    }
                }
                else                                                                                               //condition
                {
                    MessageBox.Show("Please enter a valid writeall number first !");                               //display
                }
            }
        }

        private void readallButton_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)                                                                               //condition
                serialPort1.Open();
            {
                serialPort1.DiscardInBuffer();                                                                     //discard input buffer
                serialPort1.Write("gpio readall\r");
                System.Threading.Thread.Sleep(10);                                                                 //system sleep
                string response = serialPort1.ReadExisting();                                                      //read response string
                response = response.Remove(0, 12);                                                                 //extracting string from front end
                response = response.TrimEnd(response[response.Length - 1]);                                        //extracting string from back end
                readallBox.Text = response;                                                                        //display
                serialPort1.DiscardOutBuffer();                                                                    //discard output buffer
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            verButton.Enabled = false;                                                                             //condition
            idsetButton.Enabled = false;                                                                           //condition
            idgetButton.Enabled = false;                                                                           //condition
            adcButton.Enabled = false;                                                                             //condition
            gpiosetButton.Enabled = false;                                                                         //condition
            gpioreadButton.Enabled = false;                                                                        //condition
            iomaskButton.Enabled = false;                                                                          //condition
            iodirButton.Enabled = false;                                                                           //condition
            writeallButton.Enabled = false;                                                                        //condition
            readallButton.Enabled = false;                                                                         //condition
        }
    }
}
