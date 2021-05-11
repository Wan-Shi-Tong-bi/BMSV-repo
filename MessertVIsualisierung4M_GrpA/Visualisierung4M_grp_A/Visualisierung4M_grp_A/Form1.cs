using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Visualisierung4M_grp_A
{
    public partial class frmVisualisation : Form
    {
        private const bool bWithHardware = true;
        private const int cAnalogIn1 = 1;
        private const int cRange = 0; // Full range
        private const int cMaxNumOfMV = 100;

        private const double cBorderTop = 0.05;
        private const double cBorderBottom = 0.1;
        private const double cBorderLeft = 0.2;
        private const double cBorderLeft2 = 0.1;
        private const double cBorderRight = 0.05;

        private const float cPix2Add = 10;

        private  double cMinMV = 0.0; //Mindestabstand in cm
        private  double cMaxMV = 5.0; //Maximalabstand in cm

        private double cMinMV2 = -15.0;
        private double cMaxMV2 = +15.0;

        private const int NumOfScaleLines = 15;

        private const double cCritical1 = 50;
        private const double cCritical2 = 70;

        public LIBADX.LIBADX USBInterface { get; set; }
        public Random RandomVoltage { get; set; }

        public List<double> MVList { get; set; }
        public List<double> MVList2 { get; set; }
        public frmVisualisation()
        {
            InitializeComponent();
        }

        private void frmVisualisation_Load(object sender, EventArgs e)
        {
            if (bWithHardware)
            {
                USBInterface = new LIBADX.LIBADX();
            }
            else // No hardware -> simulation
            {
                RandomVoltage = new Random();
            }

            MVList = new List<double>();
            MVList2 = new List<double>();
        }

        private void btnOpenUSBInterface_Click(object sender, EventArgs e)
        {
            if (bWithHardware)
            {
                if (USBInterface.Open(cboSelectUSBInterface.Text))
                {
                    lblStatus.Text = "USB-Interface opened! Success!";
                    lblStatus.BackColor = Color.Green;

                    lblVoltage.BackColor = Color.Green;
                    lblDistance.BackColor = Color.Green;
                    USBInterface.DigitalOutLine[2, 0] = true;
                    //Start Samplingtimer
                    tmrSampling.Start();
                }
                else
                {
                    lblStatus.Text = "USB-Interface open failed! Lockekopf Raus, Tanktop rein! Error!";
                    lblStatus.BackColor = Color.Red;
                }
            }
            else // No hardware -> simulation
            {
                lblStatus.Text = "USB-Interface simulated";
                lblStatus.BackColor = Color.Orange;

                lblVoltage.BackColor = Color.Orange;
                lblDistance.BackColor = Color.Orange;

                //Start Samplingtimer for simulation
                tmrSampling.Start();
            }
        }

        private void tmrSampling_Tick(object sender, EventArgs e)
        {
            double voltage = 0.0;
            double mv2 = 0;
            if (bWithHardware)
            {
                voltage = (double)(USBInterface.AnalogIn[cAnalogIn1, cRange]);
            }
            else // No hardware -> simulation
            {
                // Randomnumber from 0.42 to 2.5 V
                voltage = RandomVoltage.NextDouble() * (2.5 - 0.42) + 0.42;
                //mv2 = 100 * Math.Sin(((double)DateTime.Now.Millisecond) / 1000.0 *2 * Math.PI);
            }

            //  Calculated with Excel 
            double distance = 29.071 * Math.Pow(voltage, -1.159);

            lblVoltage.Text = voltage.ToString("#0.000 V");
            lblDistance.Text = distance.ToString("#0.0 cm");

            MVList.Add(voltage);
            cMinMV = MVList.Min() - 0.2;
            cMaxMV = MVList.Max() + 0.2;


            //Differential der Funktion
            // Aktueller Wert minus Vorgänger = Änderung des Abstandes[m] /ms
            if (MVList.Count >= 2)
            {
                mv2 = 10 * (MVList[MVList.Count - 1] - MVList[MVList.Count - 2]) / tmrSampling.Interval;
            }
            else
            {
                mv2 = 10 * (MVList[MVList.Count - 1] - 0) / tmrSampling.Interval;
            }
            MVList2.Add(mv2);
           

            // Adapt Minimum and Maximum
            //double delta = (cMaxMV2 - cMinMV2) / NumOfScaleLines;
            while (mv2 < cMinMV2)
            {
                cMinMV2 -= 2;
            }
            while (mv2 > cMaxMV2)
            {
                cMaxMV2 += 2;
            }

            while (MVList.Count > cMaxNumOfMV)
            {
                MVList.RemoveAt(0);
            }
            while (MVList2.Count > cMaxNumOfMV)
            {
                MVList2.RemoveAt(0);
            }
            pboChart.Invalidate();
        }



        private void pboChart_Paint(object sender, PaintEventArgs e)
        {
            //if less than 2 measurement then no drawing
            if (MVList.Count < 2) return;

            Graphics g = e.Graphics;
            Pen myChartPen = null;
            Pen myGreenPen = new Pen(Color.LightGreen, 1);
            Pen myOrangePen = new Pen(Color.Orange, 1);
            Pen myRedPen = new Pen(Color.Red, 1);

            for (int index = 1; index < MVList.Count; index++)
            {
                myChartPen = myGreenPen;
                if (MVList[index] > cCritical1)
                    myChartPen = myOrangePen;

                if (MVList[index] > cCritical2)
                {
                    myChartPen = myRedPen;
                }

                g.DrawLine(myChartPen, Index2PixX(index - 1), MV2PixY(MVList[index - 1]),
                                        Index2PixX(index), MV2PixY(MVList[index]));
                // g.DrawLine(myRedPen, Index2PixX(index - 1), MV2PixY2(MVList2[index - 1]),
                //                       Index2PixX(index), MV2PixY2(MVList2[index]));
            }

            DrawCoordinateSystem(g);
        }

        private void DrawCoordinateSystem(Graphics g)
        {
            Pen myWhitePen = new Pen(Color.White, 1);
            Brush textBrush = new SolidBrush(Color.White);

            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            // X-Axis
            g.DrawLine(myWhitePen, Index2PixX(0) - cPix2Add, MV2PixY(cMinMV),
                                   Index2PixX(cMaxNumOfMV) + 2 * cPix2Add, MV2PixY(cMinMV));
            // X-Axis Arrows
            g.DrawLine(myWhitePen, Index2PixX(cMaxNumOfMV) + cPix2Add, MV2PixY(cMinMV) + cPix2Add / 2,
                                   Index2PixX(cMaxNumOfMV) + 2 * cPix2Add, MV2PixY(cMinMV));

            g.DrawLine(myWhitePen, Index2PixX(cMaxNumOfMV) + cPix2Add, MV2PixY(cMinMV) - cPix2Add / 2,
                                   Index2PixX(cMaxNumOfMV) + 2 * cPix2Add, MV2PixY(cMinMV));

            // Skala X-Axis
            for (int index = 0; index <= cMaxNumOfMV; index = index + 50)
            {
                g.DrawLine(myWhitePen, Index2PixX(index), MV2PixY(cMinMV) + cPix2Add,
                                       Index2PixX(index), MV2PixY(cMinMV) - cPix2Add);
                g.DrawString(index.ToString(), new Font("Arial", 12), textBrush,
                                            Index2PixX(index), MV2PixY(cMinMV) + 2 * cPix2Add, sf);
            }
            // Y-Axis
            g.DrawLine(myWhitePen, Index2PixX(0), MV2PixY(cMinMV) + cPix2Add,
                                   Index2PixX(0), MV2PixY(cMaxMV) - 2 * cPix2Add);

            // X-Axis Arrows
            g.DrawLine(myWhitePen, Index2PixX(0), MV2PixY(cMaxMV) - 2 * cPix2Add,
                                   Index2PixX(0) + cPix2Add / 2, MV2PixY(cMaxMV) - cPix2Add);

            g.DrawLine(myWhitePen, Index2PixX(0), MV2PixY(cMaxMV) - 2 * cPix2Add,
                                   Index2PixX(0) - cPix2Add / 2, MV2PixY(cMaxMV) - cPix2Add);

            double delta = (cMaxMV - cMinMV) / NumOfScaleLines;
            for (double actMV = cMinMV; actMV <= cMaxMV; actMV = actMV + delta)
            {
                g.DrawLine(myWhitePen, Index2PixX(0) - cPix2Add, MV2PixY(actMV),
                                        Index2PixX(0) + cPix2Add, MV2PixY(actMV));

                g.DrawString(Math.Round(actMV, 1).ToString(), new Font("Arial", 12), textBrush,
                                           Index2PixX(0) - 2 * cPix2Add, MV2PixY(actMV), sf);
            }
            // Y2-Axis
            g.DrawLine(myWhitePen, (float)(pboChart.Width * cBorderLeft2), MV2PixY(cMinMV) + cPix2Add,
                                   (float)(pboChart.Width * cBorderLeft2), MV2PixY(cMaxMV) - 2 * cPix2Add);

            // Y2-Axis Arrows
            g.DrawLine(myWhitePen, (float)(pboChart.Width * cBorderLeft2), MV2PixY(cMaxMV) - 2 * cPix2Add,
                                   (float)(pboChart.Width * cBorderLeft2) + cPix2Add / 2, MV2PixY(cMaxMV) - cPix2Add);

            g.DrawLine(myWhitePen, (float)(pboChart.Width * cBorderLeft2), MV2PixY(cMaxMV) - 2 * cPix2Add,
                                   (float)(pboChart.Width * cBorderLeft2) - cPix2Add / 2, MV2PixY(cMaxMV) - cPix2Add);

            delta = (cMaxMV2 - cMinMV2) / NumOfScaleLines;
            for (double actMV2 = cMinMV2; actMV2 <= cMaxMV2; actMV2 = actMV2 + delta)
            {
                g.DrawLine(myWhitePen, (float)(pboChart.Width * cBorderLeft2) - cPix2Add, MV2PixY2(actMV2),
                                         (float)(pboChart.Width * cBorderLeft2) + cPix2Add, MV2PixY2(actMV2));

                g.DrawString(Math.Round(actMV2, 1).ToString(), new Font("Arial", 12), textBrush,
                                            (float)(pboChart.Width * cBorderLeft2) - 3 * cPix2Add, MV2PixY2(actMV2), sf);
            }
        }

        private float MV2PixY(double actMV)
        {
            double percent = (actMV - cMinMV) / (cMaxMV - cMinMV);
            return (float)
                (pboChart.Height
                - (percent * pboChart.Height * (1.0 - cBorderTop - cBorderBottom)
                        + pboChart.Height * cBorderBottom));
        }
        private float MV2PixY2(double actMV)
        {
            double percent = (actMV - cMinMV2) / (cMaxMV2 - cMinMV2);
            return (float)
                (pboChart.Height
                - (percent * pboChart.Height * (1.0 - cBorderTop - cBorderBottom)
                        + pboChart.Height * cBorderBottom));
        }
        private float Index2PixX(double index)
        {
            double percent = index / cMaxNumOfMV;

            return (float)(percent * pboChart.Width * (1.0 - cBorderLeft - cBorderRight)
                            + pboChart.Width * cBorderLeft);
        }
    }
}
