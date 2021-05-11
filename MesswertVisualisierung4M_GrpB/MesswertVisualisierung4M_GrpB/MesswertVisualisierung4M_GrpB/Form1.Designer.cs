namespace MesswertVisualisierung4M_GrpB
{
    partial class frmUSBInterface
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
            this.picChart = new System.Windows.Forms.PictureBox();
            this.tmrSampling = new System.Windows.Forms.Timer(this.components);
            this.lboDiffValues = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.picChart)).BeginInit();
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
            this.cboSelectUSBInterface.Size = new System.Drawing.Size(182, 21);
            this.cboSelectUSBInterface.TabIndex = 0;
            this.cboSelectUSBInterface.Text = "USB-AD";
            // 
            // btnOpenUSBInterface
            // 
            this.btnOpenUSBInterface.Location = new System.Drawing.Point(12, 39);
            this.btnOpenUSBInterface.Name = "btnOpenUSBInterface";
            this.btnOpenUSBInterface.Size = new System.Drawing.Size(182, 23);
            this.btnOpenUSBInterface.TabIndex = 1;
            this.btnOpenUSBInterface.Text = "Open USB-Interface";
            this.btnOpenUSBInterface.UseVisualStyleBackColor = true;
            this.btnOpenUSBInterface.Click += new System.EventHandler(this.btnOpenUSBInterface_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(12, 78);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(182, 42);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "USB-Interface not opened!";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Voltage:";
            // 
            // lblVoltage
            // 
            this.lblVoltage.AutoSize = true;
            this.lblVoltage.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVoltage.Location = new System.Drawing.Point(125, 120);
            this.lblVoltage.Name = "lblVoltage";
            this.lblVoltage.Size = new System.Drawing.Size(69, 24);
            this.lblVoltage.TabIndex = 4;
            this.lblVoltage.Text = "0,00 V";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 24);
            this.label4.TabIndex = 5;
            this.label4.Text = "Distance:";
            // 
            // lblDistance
            // 
            this.lblDistance.AutoSize = true;
            this.lblDistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDistance.Location = new System.Drawing.Point(125, 153);
            this.lblDistance.Name = "lblDistance";
            this.lblDistance.Size = new System.Drawing.Size(72, 24);
            this.lblDistance.TabIndex = 6;
            this.lblDistance.Text = "0,0 cm";
            // 
            // picChart
            // 
            this.picChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picChart.BackColor = System.Drawing.Color.Black;
            this.picChart.Location = new System.Drawing.Point(200, 12);
            this.picChart.Name = "picChart";
            this.picChart.Size = new System.Drawing.Size(588, 425);
            this.picChart.TabIndex = 7;
            this.picChart.TabStop = false;
            this.picChart.Paint += new System.Windows.Forms.PaintEventHandler(this.picChart_Paint);
            // 
            // tmrSampling
            // 
            this.tmrSampling.Interval = 50;
            this.tmrSampling.Tick += new System.EventHandler(this.tmrSampling_Tick);
            // 
            // lboDiffValues
            // 
            this.lboDiffValues.FormattingEnabled = true;
            this.lboDiffValues.Location = new System.Drawing.Point(0, 180);
            this.lboDiffValues.Name = "lboDiffValues";
            this.lboDiffValues.Size = new System.Drawing.Size(194, 264);
            this.lboDiffValues.TabIndex = 8;
            // 
            // frmUSBInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lboDiffValues);
            this.Controls.Add(this.picChart);
            this.Controls.Add(this.lblDistance);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblVoltage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnOpenUSBInterface);
            this.Controls.Add(this.cboSelectUSBInterface);
            this.Name = "frmUSBInterface";
            this.Text = "Distance visualisation";
            this.Load += new System.EventHandler(this.frmUSBInterface_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboSelectUSBInterface;
        private System.Windows.Forms.Button btnOpenUSBInterface;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblVoltage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblDistance;
        private System.Windows.Forms.PictureBox picChart;
        private System.Windows.Forms.Timer tmrSampling;
        private System.Windows.Forms.ListBox lboDiffValues;
    }
}

