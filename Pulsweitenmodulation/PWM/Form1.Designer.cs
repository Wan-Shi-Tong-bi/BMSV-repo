namespace PWM
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
            this.components = new System.ComponentModel.Container();
            this.cboSelectUSB = new System.Windows.Forms.ComboBox();
            this.btnOpenUsbInterface = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.trbPWM = new System.Windows.Forms.TrackBar();
            this.lblMinimum = new System.Windows.Forms.Label();
            this.lblValue = new System.Windows.Forms.Label();
            this.lblMaximum = new System.Windows.Forms.Label();
            this.tmrPWM = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.trbPWM)).BeginInit();
            this.SuspendLayout();
            // 
            // cboSelectUSB
            // 
            this.cboSelectUSB.FormattingEnabled = true;
            this.cboSelectUSB.Items.AddRange(new object[] {
            "USB-PIO",
            "USB-AD"});
            this.cboSelectUSB.Location = new System.Drawing.Point(32, 31);
            this.cboSelectUSB.Name = "cboSelectUSB";
            this.cboSelectUSB.Size = new System.Drawing.Size(121, 21);
            this.cboSelectUSB.TabIndex = 0;
            this.cboSelectUSB.Text = "USB-PIO";
            // 
            // btnOpenUsbInterface
            // 
            this.btnOpenUsbInterface.Location = new System.Drawing.Point(32, 72);
            this.btnOpenUsbInterface.Name = "btnOpenUsbInterface";
            this.btnOpenUsbInterface.Size = new System.Drawing.Size(121, 23);
            this.btnOpenUsbInterface.TabIndex = 1;
            this.btnOpenUsbInterface.Text = "Open USB-Interface";
            this.btnOpenUsbInterface.UseVisualStyleBackColor = true;
            this.btnOpenUsbInterface.Click += new System.EventHandler(this.btnOpenUsbInterface_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(25, 110);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(147, 23);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "USB-Interface not opened";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trbPWM
            // 
            this.trbPWM.Location = new System.Drawing.Point(195, 31);
            this.trbPWM.Maximum = 100;
            this.trbPWM.Name = "trbPWM";
            this.trbPWM.Size = new System.Drawing.Size(529, 45);
            this.trbPWM.TabIndex = 3;
            this.trbPWM.TickFrequency = 5;
            this.trbPWM.Scroll += new System.EventHandler(this.trbPWM_Scroll);
            // 
            // lblMinimum
            // 
            this.lblMinimum.AutoSize = true;
            this.lblMinimum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinimum.Location = new System.Drawing.Point(201, 72);
            this.lblMinimum.Name = "lblMinimum";
            this.lblMinimum.Size = new System.Drawing.Size(34, 20);
            this.lblMinimum.TabIndex = 4;
            this.lblMinimum.Text = "0%";
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValue.Location = new System.Drawing.Point(462, 72);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(34, 20);
            this.lblValue.TabIndex = 5;
            this.lblValue.Text = "0%";
            // 
            // lblMaximum
            // 
            this.lblMaximum.AutoSize = true;
            this.lblMaximum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaximum.Location = new System.Drawing.Point(680, 72);
            this.lblMaximum.Name = "lblMaximum";
            this.lblMaximum.Size = new System.Drawing.Size(54, 20);
            this.lblMaximum.TabIndex = 6;
            this.lblMaximum.Text = "100%";
            // 
            // tmrPWM
            // 
            this.tmrPWM.Tick += new System.EventHandler(this.tmrPWM_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblMaximum);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.lblMinimum);
            this.Controls.Add(this.trbPWM);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnOpenUsbInterface);
            this.Controls.Add(this.cboSelectUSB);
            this.Name = "Form1";
            this.Text = "PulsWidthModulation";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trbPWM)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboSelectUSB;
        private System.Windows.Forms.Button btnOpenUsbInterface;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TrackBar trbPWM;
        private System.Windows.Forms.Label lblMinimum;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.Label lblMaximum;
        private System.Windows.Forms.Timer tmrPWM;
    }
}

