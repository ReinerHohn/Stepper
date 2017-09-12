#License
#-------
#This code is published and shared by Numato Systems Pvt Ltd under GNU LGPL 
#license with the hope that it may be useful. Read complete license at 
#http://www.gnu.org/licenses/lgpl.html or write to Free Software Foundation,
#51 Franklin Street, Fifth Floor, Boston, MA 02110-1301, USA

#Simplicity and understandability is the primary philosophy followed while
#writing this code. Sometimes at the expence of standard coding practices and
#best practices. It is your responsibility to independantly assess and implement
#coding practices that will satisfy safety and security necessary for your final
#application.

#This demo code demonstrates how to write to a GPIO

import sys
import serial

import RPi.GPIO as GPIO
import time
 
coil_A_1_pin = 1
coil_A_2_pin = 2
coil_B_1_pin = 3
coil_B_2_pin = 4
enable_pin   = 5
 
# anpassen, falls andere Sequenz
StepCount = 8
Seq = list(range(0, StepCount))
Seq[0] = [0,1,0,0]
Seq[1] = [0,1,0,1]
Seq[2] = [0,0,0,1]
Seq[3] = [1,0,0,1]
Seq[4] = [1,0,0,0]
Seq[5] = [1,0,1,0]
Seq[6] = [0,0,1,0]
Seq[7] = [0,1,1,0]
 

def gpioPinCommand(command, gpioNum):
	if (int(gpioNum) < 10):
	    gpioIndex = str(gpioNum)
	else:
	    gpioIndex = chr(55 + int(gpioNum))

	#Send "gpio write" command. GPIO number 10 and beyond are
	#referenced in the command by using alphabets starting A. For example
	#GPIO10 willbe A, GPIO11 will be B and so on. Please note that this is
	#not intended to be hexadecimal notation so the the alphabets can go 
	#beyond F.
	serPort.write("gpio "+ command +" "+ gpioIndex  + "\r")

def setStep(w1, w2, w3, w4):
	gpioPinCommand("set", coil_A_1_pin, w1)
	gpioPinCommand("set", coil_A_2_pin, w2)
	gpioPinCommand("set", coil_B_1_pin, w3)
	gpioPinCommand("set", coil_B_2_pin, w4)
 
def forward(delay, steps):
    for i in range(steps):
        for j in range(StepCount):
            setStep(Seq[j][0], Seq[j][1], Seq[j][2], Seq[j][3])
            time.sleep(delay)
 
def backwards(delay, steps):
    for i in range(steps):
        for j in reversed(range(StepCount)):
            setStep(Seq[j][0], Seq[j][1], Seq[j][2], Seq[j][3])
            time.sleep(delay)
            
if __name__ == '__main__':
	#Open port for communication	
	serPort = serial.Serial(portName, 19200, timeout=1)

	while True:
		delay = raw_input("Zeitverzoegerung (ms)?")
		steps = raw_input("Wie viele Schritte vorwaerts? ")
		forward(int(delay) / 1000.0, int(steps))
		steps = raw_input("Wie viele Schritte rueckwaerts? ")
		backwards(int(delay) / 1000.0, int(steps))

	#Close the port
	serPort.close()