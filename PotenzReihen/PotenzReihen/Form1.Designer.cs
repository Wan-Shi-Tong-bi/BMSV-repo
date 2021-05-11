namespace PotenzReihen
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.lblAnzahlSummanden = new System.Windows.Forms.Label();
            this.lblWinkel = new System.Windows.Forms.Label();
            this.nudWinkel = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCosinusMath = new System.Windows.Forms.Label();
            this.lblSinusMath = new System.Windows.Forms.Label();
            this.lblCosinusPot = new System.Windows.Forms.Label();
            this.lblSinusPot = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWinkel)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBar
            // 
            this.trackBar.Location = new System.Drawing.Point(22, 28);
            this.trackBar.Maximum = 100;
            this.trackBar.Minimum = 1;
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(565, 45);
            this.trackBar.TabIndex = 0;
            this.trackBar.Value = 1;
            this.trackBar.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // lblAnzahlSummanden
            // 
            this.lblAnzahlSummanden.AutoSize = true;
            this.lblAnzahlSummanden.Location = new System.Drawing.Point(593, 37);
            this.lblAnzahlSummanden.Name = "lblAnzahlSummanden";
            this.lblAnzahlSummanden.Size = new System.Drawing.Size(13, 13);
            this.lblAnzahlSummanden.TabIndex = 1;
            this.lblAnzahlSummanden.Text = "1";
            // 
            // lblWinkel
            // 
            this.lblWinkel.AutoSize = true;
            this.lblWinkel.Location = new System.Drawing.Point(171, 81);
            this.lblWinkel.Name = "lblWinkel";
            this.lblWinkel.Size = new System.Drawing.Size(13, 13);
            this.lblWinkel.TabIndex = 2;
            this.lblWinkel.Text = "0";
            // 
            // nudWinkel
            // 
            this.nudWinkel.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudWinkel.Location = new System.Drawing.Point(32, 79);
            this.nudWinkel.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.nudWinkel.Name = "nudWinkel";
            this.nudWinkel.Size = new System.Drawing.Size(120, 20);
            this.nudWinkel.TabIndex = 3;
            this.nudWinkel.ValueChanged += new System.EventHandler(this.nudWinkel_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Sinus:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 205);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Cosinus";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(279, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Potzenzreihe";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(70, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Mathfunktion";
            // 
            // lblCosinusMath
            // 
            this.lblCosinusMath.AutoSize = true;
            this.lblCosinusMath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCosinusMath.Location = new System.Drawing.Point(95, 205);
            this.lblCosinusMath.Name = "lblCosinusMath";
            this.lblCosinusMath.Size = new System.Drawing.Size(25, 16);
            this.lblCosinusMath.TabIndex = 9;
            this.lblCosinusMath.Text = "0,0";
            // 
            // lblSinusMath
            // 
            this.lblSinusMath.AutoSize = true;
            this.lblSinusMath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSinusMath.Location = new System.Drawing.Point(95, 179);
            this.lblSinusMath.Name = "lblSinusMath";
            this.lblSinusMath.Size = new System.Drawing.Size(25, 16);
            this.lblSinusMath.TabIndex = 8;
            this.lblSinusMath.Text = "0,0";
            // 
            // lblCosinusPot
            // 
            this.lblCosinusPot.AutoSize = true;
            this.lblCosinusPot.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCosinusPot.Location = new System.Drawing.Point(299, 205);
            this.lblCosinusPot.Name = "lblCosinusPot";
            this.lblCosinusPot.Size = new System.Drawing.Size(25, 16);
            this.lblCosinusPot.TabIndex = 11;
            this.lblCosinusPot.Text = "0,0";
            // 
            // lblSinusPot
            // 
            this.lblSinusPot.AutoSize = true;
            this.lblSinusPot.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSinusPot.Location = new System.Drawing.Point(299, 179);
            this.lblSinusPot.Name = "lblSinusPot";
            this.lblSinusPot.Size = new System.Drawing.Size(25, 16);
            this.lblSinusPot.TabIndex = 10;
            this.lblSinusPot.Text = "0,0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblCosinusPot);
            this.Controls.Add(this.lblSinusPot);
            this.Controls.Add(this.lblCosinusMath);
            this.Controls.Add(this.lblSinusMath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudWinkel);
            this.Controls.Add(this.lblWinkel);
            this.Controls.Add(this.lblAnzahlSummanden);
            this.Controls.Add(this.trackBar);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWinkel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.Label lblAnzahlSummanden;
        private System.Windows.Forms.Label lblWinkel;
        private System.Windows.Forms.NumericUpDown nudWinkel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCosinusMath;
        private System.Windows.Forms.Label lblSinusMath;
        private System.Windows.Forms.Label lblCosinusPot;
        private System.Windows.Forms.Label lblSinusPot;
    }
}

