namespace Visualisierung4M_grp_A
{
    partial class frmVisualisation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cboSelectUSBInterface = new System.Windows.Forms.ComboBox();
            this.btnOpenUSBInterface = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblVoltage = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblDistance = new System.Windows.Forms.Label();
            this.pboChart = new System.Windows.Forms.PictureBox();
            this.tmrSampling = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pboChart)).BeginInit();
            this.SuspendLayout();
            // 
            // cboSelectUSBInterface
            // 
            this.cboSelectUSBInterface.FormattingEnabled = true;
            this.cboSelectUSBInterface.Items.AddRange(new object[] {
            "USB-AD",
            "USB-PIO"});
            this.cboSelectUSBInterface.Location = new System.Drawing.Point(12, 12);
            this.cboSelectUSBInterface.Name = "cboSelectUSBInterface";
            this.cboSelectUSBInterface.Size = new System.Drawing.Size(192, 21);
            this.cboSelectUSBInterface.TabIndex = 0;
            this.cboSelectUSBInterface.Text = "USB-AD";
            // 
            // btnOpenUSBInterface
            // 
            this.btnOpenUSBInterface.Location = new System.Drawing.Point(13, 50);
            this.btnOpenUSBInterface.Name = "btnOpenUSBInterface";
            this.btnOpenUSBInterface.Size = new System.Drawing.Size(191, 23);
            this.btnOpenUSBInterface.TabIndex = 1;
            this.btnOpenUSBInterface.Text = "Open USB-Interface";
            this.btnOpenUSBInterface.UseVisualStyleBackColor = true;
            this.btnOpenUSBInterface.Click += new System.EventHandler(this.btnOpenUSBInterface_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(12, 89);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(192, 45);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "USB-Inteface not opened!";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(-6, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Voltage:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblVoltage
            // 
            this.lblVoltage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVoltage.Location = new System.Drawing.Point(100, 156);
            this.lblVoltage.Name = "lblVoltage";
            this.lblVoltage.Size = new System.Drawing.Size(100, 23);
            this.lblVoltage.TabIndex = 4;
            this.lblVoltage.Text = "0,0 V";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(-6, 199);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 5;
            this.label4.Text = "Distance:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblDistance
            // 
            this.lblDistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDistance.Location = new System.Drawing.Point(103, 199);
            this.lblDistance.Name = "lblDistance";
            this.lblDistance.Size = new System.Drawing.Size(100, 23);
            this.lblDistance.TabIndex = 6;
            this.lblDistance.Text = "0,0 cm";
            // 
            // pboChart
            // 
            this.pboChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pboChart.BackColor = System.Drawing.Color.Black;
            this.pboChart.Location = new System.Drawing.Point(210, 12);
            this.pboChart.Name = "pboChart";
            this.pboChart.Size = new System.Drawing.Size(578, 426);
            this.pboChart.TabIndex = 7;
            this.pboChart.TabStop = false;
            this.pboChart.Paint += new System.Windows.Forms.PaintEventHandler(this.pboChart_Paint);
            // 
            // tmrSampling
            // 
            this.tmrSampling.Interval = 50;
            this.tmrSampling.Tick += new System.EventHandler(this.tmrSampling_Tick);
            // 
            // frmVisualisation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pboChart);
            this.Controls.Add(this.lblDistance);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblVoltage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnOpenUSBInterface);
            this.Controls.Add(this.cboSelectUSBInterface);
            this.Name = "frmVisualisation";
            this.Text = "Infrared-Distance-Sensor Visualisation";
            this.Load += new System.EventHandler(this.frmVisualisation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pboChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboSelectUSBInterface;
        private System.Windows.Forms.Button btnOpenUSBInterface;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblVoltage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblDistance;
        private System.Windows.Forms.PictureBox pboChart;
        private System.Windows.Forms.Timer tmrSampling;
    }
}

