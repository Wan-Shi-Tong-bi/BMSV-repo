using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PWM
{
    public partial class Form1 : Form
    {
        private const int GroupA = 2;
        private const int GroupB = 2;
        private const int GroupC = 3;
        private const int Line0 = 1;

        const int cAnalogIn1 = 1;
        const int cRange = 0; //Full Range

        public LIBADX.LIBADX USBInterface { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            USBInterface = new LIBADX.LIBADX();

            lblMinimum.Text = trbPWM.Minimum.ToString();
            lblMaximum.Text = trbPWM.Maximum.ToString();
            lblValue.Text = trbPWM.Value.ToString();

            trbPWM.Enabled = false;
        }

        private void btnOpenUsbInterface_Click(object sender, EventArgs e)
        {
            if (USBInterface.Open(cboSelectUSB.Text))
            {
                //USBInterface.DigitalDirection[GroupA] = 0x0000; //OutPuts
                //USBInterface.DigitalDirection[GroupB] = 0x0000; //OutPuts
                //USBInterface.DigitalDirection[GroupC] = 0xffff; //Inputs

                lblStatus.Text = "USB connected! Success!";
                lblStatus.BackColor = Color.Green;

                trbPWM.Enabled = true;
                SetPWMValue(trbPWM.Value);

                //Start sampling (Raummessung)
                tmrSampling.Start();
            }
            else
            {
                lblStatus.Text = "USB not connected! Failed!";
                lblStatus.BackColor = Color.Green;
            }
        }

        private void SetPWMValue(int PWMvalue)
        {
            lblValue.Text = PWMvalue.ToString();

            //0% oder 100% --> ein oder aus keine PWM erforderlich
            if(PWMvalue == trbPWM.Minimum || PWMvalue == trbPWM.Maximum)
            {
                tmrPWM.Stop();
                USBInterface.DigitalOutLine[GroupA, Line0] = PWMvalue == trbPWM.Maximum;
            }
            else //PWM mit 1% bis 99%
            {
                //Motor einschalten (Ausgang aktivieren) 
                USBInterface.DigitalOutLine[GroupA, Line0] = true;
                //Intervall einstellen (Wartezeit)
                tmrPWM.Interval = PWMvalue;
                //Timer starten
                tmrPWM.Start();
               
            }
            
        }

        private void trbPWM_Scroll(object sender, EventArgs e)
        {
            SetPWMValue(trbPWM.Value);
        }

        private void tmrPWM_Tick(object sender, EventArgs e)
        {
            //Motor ausschalten (Ausgang aktivieren) 
            USBInterface.DigitalOutLine[GroupA, Line0] = !USBInterface.DigitalOutLine[GroupA, Line0];
            tmrPWM.Interval = trbPWM.Maximum - tmrPWM.Interval;

        }

        private void trbSetTemperature_Scroll(object sender, EventArgs e)
        {
            lblSetTemperature.Text = trbSetTemperature.Value.ToString("#0.00 °C");
        }

        private void tmrSampling_Tick(object sender, EventArgs e)
        {
            //calculate temperatur
            double TempSensorVoltage = USBInterface.AnalogIn[cAnalogIn1, cRange];

            //resistor of tempSensor shunt = 12kOhm; supply voltage = 12V
            //TemSensorResistor = 12kOhm*TempSensorVoltage/(12V-TempSensorVoltage) --> Funktion selber berechnen
            double TemSensorResistor = 12*TempSensorVoltage/(12-TempSensorVoltage);
            //temperatur of tempSensor
            double TemSensorTemperature = 63.24 * TemSensorResistor - 103.68;
            lblCurrent.Text = TemSensorTemperature.ToString("#0.0 °C");

            // error signal Regeldifferenz
            double errorSignal = trbSetTemperature.Value - TemSensorTemperature;

            // acuating variable Stellgröße
            double k_pr = 10; // Proportionalbeiwert
            double actuatingVariable = k_pr * errorSignal;

            //Heating on on/off
            // if ( actuatingVariable < 0) heating = true; else heating = false;

            // fan
            actuatingVariable = Math.Abs(actuatingVariable);
            actuatingVariable = Math.Min(100, actuatingVariable);

            trbPWM.Value = (int) actuatingVariable;
        }
    }
}
