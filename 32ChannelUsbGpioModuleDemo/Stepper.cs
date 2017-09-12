using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _32ChannelUsbGpioDemo
{
    class Stepper
    {
        public Stepper(ref string port, System.IO.Ports.SerialPort serialPort1)
        {
            numato = new Numato(ref port, serialPort1);
            Seq = new bool[8][];
            Seq[0] = new bool[4] { false, true, false, false };
            Seq[1] = new bool[4] { false, true, false, true };
            Seq[2] = new bool[4] { false, false, false, true };
            Seq[3] = new bool[4] { true, false, false, true };
            Seq[4] = new bool[4] { true, false, false, false };
            Seq[5] = new bool[4] { true, false, true, false };
            Seq[6] = new bool[4] { false, false, true, false };
            Seq[7] = new bool[4] { false, true, true, false };
        }
        ~ Stepper()
        {
            numato = null;
        }
        void setStep(bool w1, bool w2, bool w3, bool w4)
        {
            numato.gpioPinCommand(coil_A_1_pin, w1);
            numato.gpioPinCommand(coil_A_2_pin, w2);
            numato.gpioPinCommand(coil_B_1_pin, w3);
            numato.gpioPinCommand(coil_B_2_pin, w4);
        }
        public void forward(int delay, int steps)
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
        public void backwards(int delay, int steps)
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
        private Numato numato;
        private bool[][] Seq;
        private int coil_A_1_pin = 1;
        private int coil_A_2_pin = 2;
        private int coil_B_1_pin = 3;
        private int coil_B_2_pin = 4;
        private int enable_pin = 5;
            // anpassen, falls andere Sequenz
        private int StepCount = 8;
    }
}
