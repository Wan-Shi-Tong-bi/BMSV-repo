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
        private const int GroupA = 1;
        private const int GroupB = 2;
        private const int GroupC = 3;
        private const int Line0 = 0;

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
                USBInterface.DigitalDirection[GroupA] = 0x0000; //OutPuts
                USBInterface.DigitalDirection[GroupB] = 0x0000; //OutPuts
                USBInterface.DigitalDirection[GroupC] = 0xffff; //Inputs

                lblStatus.Text = "USB connected! Success!";
                lblStatus.BackColor = Color.Green;

                trbPWM.Enabled = true;
                SetPWMValue(trbPWM.Value);
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
    }
}
