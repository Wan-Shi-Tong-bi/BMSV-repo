using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MesswertVisualisierung4M_GrpB
{
    public partial class frmUSBInterface : Form
    {
        private const bool bWithHardware = false;
        private const int cAnalogIn1 = 1;
        private const int cRange = 0; // Full range

        private const int cMaxNumOfMV = 300;
        private const double cMaxMV = 80; // Max distance in cm
        private const double cMinMV = 10; // Min distance in cm

        private const double cMaxMVDiff = 2; // Max distance in cm
        private const double cMinMVDiff = -2; // Min distance in cm

        private const double cBorderLeft = 0.18; // Rand für die rechte Y-Achse
        private const double cBorderLeft2 = 0.09;// Rand für die linke Y-Achse

        private const double cBorderTop = 0.05;
        private const double cBorderRight = 0.05;
        private const double cBorderBottom = 0.1;

        private const float cPix2Add = 10;

        private double SinCount = 0;
        public LIBADX.LIBADX USBInterface { get; set; }
        public Random RandomVoltage { get; set; }

        public List<double> MVList { get; set; }
        public List<double> MVListDiff { get; set; }
        public frmUSBInterface()
        {
            InitializeComponent();
        }

        private void frmUSBInterface_Load(object sender, EventArgs e)
        {
            MVList = new List<double>();
            MVListDiff = new List<double>();

            if (bWithHardware)
            {
                USBInterface = new LIBADX.LIBADX();
            }
            else // without hardware
            {
                RandomVoltage = new Random();
            }
        }

        private void btnOpenUSBInterface_Click(object sender, EventArgs e)
        {
            if (bWithHardware)
            {
                if (USBInterface.Open(cboSelectUSBInterface.Text))
                {
                    lblStatus.Text = "USB-Interface opened";
                    lblStatus.BackColor = Color.Green;

                    // Abtasttimer starten
                    tmrSampling.Start();
                }
                else
                {
                    lblStatus.Text = "USB-Interface open failed";
                    lblStatus.BackColor = Color.Red;
                }
            }
            else // without hardware
            {
                lblStatus.Text = "USB-Interface simulated";
                lblStatus.BackColor = Color.Orange;

                // Abtasttimer starten
                tmrSampling.Start();
            }
        }

        private void tmrSampling_Tick(object sender, EventArgs e)
        {
            double voltage = 0.0;
            if (bWithHardware)
            {
                voltage = USBInterface.AnalogIn[cAnalogIn1, cRange];
            }
            else // without hardware
            {
                // Max 2,49 V  Min =0,415V

                // Zufallszahl im Bereich 0,415V bis 2,49V
                //voltage = (2.49 - 0.415) * RandomVoltage.NextDouble() + 0.415;

                // 2.49 - 0.42 = 2.07 /2 = 1.035
                // Verschieben in Y-Richtung 1.035 + 0.415 = 1.45
                voltage = 1.035 * Math.Sin(SinCount) + 1.45;

                SinCount = (SinCount +Math.PI*3/180.0) ;
            }

            voltage = Math.Max(0.415, Math.Min(2.49, voltage));

            lblVoltage.Text = voltage.ToString("#0.000 V");

            // Umrechungsformel mit Excel berechnet
            //double distance = 29.044 * Math.Pow(voltage, -1.162);
            double distance =  35 * Math.Sin(SinCount) + 45;

            lblDistance.Text = distance.ToString("#0.0 cm");

            double diff = 0;
            if (MVList.Count > 0)
                diff = distance - MVList[MVList.Count - 1]; 

            MVListDiff.Add(diff);
            lboDiffValues.Items.Add(diff);
            MVList.Add(distance);

            while (MVList.Count > cMaxNumOfMV)
            {
                MVList.RemoveAt(0);
                MVListDiff.RemoveAt(0);
            }
            // PictureBox ungültig setzen und daher wird die Paint-Methode zum Neuzeichen aufgerufen
            picChart.Invalidate();
        }

        private void picChart_Paint(object sender, PaintEventArgs e)
        {
            // Bei weniger als 2 Messwerten wird nichts gezeichnet
            if (MVList.Count < 2) return;

            Graphics g = e.Graphics;

            Pen yellowPen = new Pen(Color.Yellow, 1); 
            Pen greenPen = new Pen(Color.LightGreen, 1);

            for (int i = 1; i < MVList.Count; i++)
            {
                // Function
                g.DrawLine(yellowPen, Index2PixX(i - 1), MV2PixY(MVList[i - 1]), Index2PixX(i), MV2PixY(MVList[i]));

                //Differential function
                g.DrawLine(greenPen, Index2PixX(i - 1), MVDiff2PixY(MVListDiff[i - 1]), Index2PixX(i), MVDiff2PixY(MVListDiff[i]));
            }

            DrawCoordinateSystem(g);
            //g.DrawLine(yellowPen, 10, 20, 100, 200);
        }

        

        private void DrawCoordinateSystem(Graphics g)
        {
            Pen whitePen = new Pen(Color.White, 1);
            Brush whiteBrush = new SolidBrush(Color.White);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            // X-Axis
            g.DrawLine(whitePen,
                Index2PixX(0) - cPix2Add, MV2PixY(cMinMV),
                Index2PixX(cMaxNumOfMV) + 2 * cPix2Add, MV2PixY(cMinMV));

            // Arrow for X-Axis
            g.DrawLine(whitePen,
                Index2PixX(cMaxNumOfMV) + 2 * cPix2Add, MV2PixY(cMinMV),
                Index2PixX(cMaxNumOfMV) + cPix2Add, MV2PixY(cMinMV) + cPix2Add / 2);
            g.DrawLine(whitePen,
                Index2PixX(cMaxNumOfMV) + 2 * cPix2Add, MV2PixY(cMinMV),
                Index2PixX(cMaxNumOfMV) + cPix2Add, MV2PixY(cMinMV) - cPix2Add / 2);
            // Scala for X-Axis
            g.DrawString(DateTime.Now.ToString(), new Font("Arial", 12),
                    whiteBrush, Index2PixX(0) + 3 * cPix2Add, MV2PixY(cMinMV) + 3 * cPix2Add, sf);

            for (int index = 0; index <= cMaxNumOfMV; index = index + 20)
            {
                g.DrawLine(whitePen,
                Index2PixX(index), MV2PixY(cMinMV) + cPix2Add,
                Index2PixX(index), MV2PixY(cMinMV) - cPix2Add);
                g.DrawString((index * tmrSampling.Interval / 1000).ToString(), new Font("Arial", 12),
                    whiteBrush, Index2PixX(index), MV2PixY(cMinMV) + 2 * cPix2Add, sf);
            }

            // Y-Axis
            g.DrawLine(whitePen,
                Index2PixX(0), MV2PixY(cMinMV) + cPix2Add,
                Index2PixX(0), MV2PixY(cMaxMV) - 2 * cPix2Add);
            // Arrow for Y-Axis
            g.DrawLine(whitePen,
                Index2PixX(0), MV2PixY(cMaxMV) - 2 * cPix2Add,
                Index2PixX(0) + cPix2Add / 2, MV2PixY(cMaxMV) - cPix2Add);
            g.DrawLine(whitePen,
                Index2PixX(0), MV2PixY(cMaxMV) - 2 * cPix2Add,
                Index2PixX(0) - cPix2Add / 2, MV2PixY(cMaxMV) - cPix2Add);
            // Scala for Y-Axis
            for (double actMV = cMinMV; actMV <= cMaxMV; actMV = actMV + 5)
            {
                g.DrawLine(whitePen,
                Index2PixX(0) + cPix2Add/2, MV2PixY(actMV),
                Index2PixX(0) - cPix2Add/2, MV2PixY(actMV));


                if (actMV % 10 == 0)
                {
                    g.DrawLine(whitePen,
                        Index2PixX(0) + cPix2Add, MV2PixY(actMV),
                        Index2PixX(0) - cPix2Add, MV2PixY(actMV));

                    g.DrawString(actMV.ToString(), new Font("Arial", 12),
                        whiteBrush, Index2PixX(0) - 2 * cPix2Add, MV2PixY(actMV), sf);
                }
            }

            // Y-Axis Diff
            g.DrawLine(whitePen,
                IndexDiff2PixX(0), MVDiff2PixY(cMinMVDiff) + cPix2Add,
                IndexDiff2PixX(0), MVDiff2PixY(cMaxMVDiff) - 2 * cPix2Add);
            // Arrow for Y-Axis
            g.DrawLine(whitePen,
                IndexDiff2PixX(0), MVDiff2PixY(cMaxMVDiff) - 2 * cPix2Add,
                IndexDiff2PixX(0) + cPix2Add / 2, MVDiff2PixY(cMaxMVDiff) - cPix2Add);
            g.DrawLine(whitePen,
                IndexDiff2PixX(0), MVDiff2PixY(cMaxMVDiff) - 2 * cPix2Add,
                IndexDiff2PixX(0) - cPix2Add / 2, MVDiff2PixY(cMaxMVDiff) - cPix2Add);
            // Scala for Y-Axis
            for (double actMVDiff = cMinMVDiff; actMVDiff <= cMaxMVDiff; actMVDiff = actMVDiff + 0.2)
            {
                g.DrawLine(whitePen,
                IndexDiff2PixX(0) + cPix2Add / 2, MVDiff2PixY(actMVDiff),
                IndexDiff2PixX(0) - cPix2Add / 2, MVDiff2PixY(actMVDiff));


                if (Math.Round((actMVDiff * 10),2) % 4 == 0)
                {
                    g.DrawLine(whitePen,
                        IndexDiff2PixX(0) + cPix2Add, MVDiff2PixY(actMVDiff),
                        IndexDiff2PixX(0) - cPix2Add, MVDiff2PixY(actMVDiff));

                    g.DrawString(Math.Round(actMVDiff,2).ToString(), new Font("Arial", 12),
                        whiteBrush, IndexDiff2PixX(0) - 2 * cPix2Add, MVDiff2PixY(actMVDiff), sf);
                }
            }
        }

        private float MV2PixY(double mv)
        {
            // TODO
            // Schüler probieren zu Hause in Stunde DL durchbesprechen
            double percent = (mv - cMinMV) / (cMaxMV - cMinMV);

            return (float)(picChart.Height
                - (cBorderBottom * picChart.Height
                    + percent * picChart.Height * (1.0 - cBorderTop - cBorderBottom)));
        }

        private float Index2PixX(double index)
        {
            // Achtung Aufpassen das keine Integer-Division gemacht wird
            double percent = index / cMaxNumOfMV;

            return (float)(percent * picChart.Width * (1.0 - cBorderLeft - cBorderRight)
                + picChart.Width * cBorderLeft);
        }

        private float IndexDiff2PixX(double index)
        {
            // Achtung Aufpassen das keine Integer-Division gemacht wird
            double percent = index / cMaxNumOfMV;

            return (float)(percent * picChart.Width * (1.0 - cBorderLeft2 - cBorderRight)
                + picChart.Width * cBorderLeft2);
        }
        private float MVDiff2PixY(double mv)
        {
            double percent =  (mv - cMinMVDiff) / (cMaxMVDiff - cMinMVDiff);

            return (float)(picChart.Height
                - (cBorderBottom * picChart.Height
                    + percent * picChart.Height * (1.0 - cBorderTop - cBorderBottom)));
        }
    }
}
