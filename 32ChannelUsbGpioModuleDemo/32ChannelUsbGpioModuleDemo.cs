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
        }
        private void openportButton_Click(object sender, EventArgs e)
        {
            var text = comportNumberbox.Text;
            stepper = new Stepper(ref text, serialPort1);
            gpiosetButton.Enabled = true;                                                                //condition
            gpioreadButton.Enabled = true;                                                               //condition
        }
        //System.IO.Ports.SerialPort
        private void gpiosetButton_Click(object sender, EventArgs e)
        {
            stepper.forward(0,10);
        }

        private void gpioreadButton_Click(object sender, EventArgs e)
        {
            stepper.backwards(0, 10);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gpiosetButton.Enabled = false;                                                                         //condition
            gpioreadButton.Enabled = false;                                                                        //condition
        }
        private Stepper stepper;
    }
}
