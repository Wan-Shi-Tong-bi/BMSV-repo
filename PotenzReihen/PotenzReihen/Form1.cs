using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PotenzReihen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            lblAnzahlSummanden.Text = trackBar.Value.ToString();
            berechnePotenzReihe();
       }

        private void berechnePotenzReihe()
        {
            double winkel = (double)nudWinkel.Value;
            winkel = winkel * Math.PI / 180.00;

            double sinus = Math.Sin(winkel);
            lblSinusMath.Text = sinus.ToString();

            double cosinus = Math.Cos(winkel);
            lblCosinusMath.Text = cosinus.ToString();

            double sinusPot = SinusPot(winkel);
            lblSinusPot.Text = sinusPot.ToString();

            double cosinusPot =CosinusPot(winkel);
            lblCosinusPot.Text = cosinusPot.ToString();
        }

        private double SinusPot(double winkel)
        {
            double sin = 0.00;
            for(int i = 0; i < trackBar.Value; i++)
            {
              sin += Math.Pow(-1, i) * Math.Pow(winkel, 2 * i + 1) / Fakultaet(2 * i + 1);
            }
            return sin;
        }

        private double CosinusPot(double winkel)
        {
            double cos = 0.00;
            for (int i = 0; i < trackBar.Value; i++)
            {
                cos += Math.Pow(-1, i) * Math.Pow(winkel, 2 * i) / Fakultaet(2 * i);
            }
            return cos;
        }

        private void nudWinkel_ValueChanged(object sender, EventArgs e)
        {
            lblWinkel.Text = nudWinkel.Value.ToString();
            berechnePotenzReihe();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public static double Fakultaet(long zahl)
        {
            if (zahl <= 1)
            {
                return 1.0;
            }
            return zahl * Fakultaet(zahl - 1);
        }
    }
}
