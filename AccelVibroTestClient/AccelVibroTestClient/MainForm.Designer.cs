namespace AccelVibroTestClient
{
    partial class MainForm
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
            this.startTestButton = new System.Windows.Forms.Button();
            this.stopTestButton = new System.Windows.Forms.Button();
            this.LogTextBox = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBoxResult = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.MeasureCount = new System.Windows.Forms.ComboBox();
            this.disable = new System.Windows.Forms.RadioButton();
            this.LPF = new System.Windows.Forms.RadioButton();
            this.HPF = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.Bandwidth = new System.Windows.Forms.ComboBox();
            this.StartMeasure = new System.Windows.Forms.Button();
            this.scale2g = new System.Windows.Forms.RadioButton();
            this.scale4g = new System.Windows.Forms.RadioButton();
            this.scale8g = new System.Windows.Forms.RadioButton();
            this.scale16g = new System.Windows.Forms.RadioButton();
            this.scale = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.sigProc = new System.Windows.Forms.CheckBox();
            this.Logs = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.axisZ = new System.Windows.Forms.RadioButton();
            this.axisY = new System.Windows.Forms.RadioButton();
            this.axisX = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.doFirmware = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResult)).BeginInit();
            this.scale.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // startTestButton
            // 
            this.startTestButton.AccessibleName = "startTest_button";
            this.startTestButton.Location = new System.Drawing.Point(29, 26);
            this.startTestButton.Name = "startTestButton";
            this.startTestButton.Size = new System.Drawing.Size(163, 65);
            this.startTestButton.TabIndex = 0;
            this.startTestButton.Text = "StartTest";
            this.startTestButton.UseVisualStyleBackColor = true;
            this.startTestButton.Click += new System.EventHandler(this.startTestButton_Click);
            // 
            // stopTestButton
            // 
            this.stopTestButton.Location = new System.Drawing.Point(29, 112);
            this.stopTestButton.Name = "stopTestButton";
            this.stopTestButton.Size = new System.Drawing.Size(163, 65);
            this.stopTestButton.TabIndex = 1;
            this.stopTestButton.Text = "Stop Test";
            this.stopTestButton.UseVisualStyleBackColor = true;
            this.stopTestButton.Click += new System.EventHandler(this.stopTestButton_Click);
            // 
            // LogTextBox
            // 
            this.LogTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LogTextBox.Location = new System.Drawing.Point(29, 195);
            this.LogTextBox.Name = "LogTextBox";
            this.LogTextBox.Size = new System.Drawing.Size(532, 430);
            this.LogTextBox.TabIndex = 3;
            this.LogTextBox.Text = "";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 6;
            // 
            // pictureBoxResult
            // 
            this.pictureBoxResult.Location = new System.Drawing.Point(587, 466);
            this.pictureBoxResult.Name = "pictureBoxResult";
            this.pictureBoxResult.Size = new System.Drawing.Size(249, 254);
            this.pictureBoxResult.TabIndex = 11;
            this.pictureBoxResult.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 18);
            this.label2.TabIndex = 13;
            this.label2.Text = "диапазон, g";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label3.Location = new System.Drawing.Point(610, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 18);
            this.label3.TabIndex = 14;
            this.label3.Text = "количество точек, тыс";
            // 
            // MeasureCount
            // 
            this.MeasureCount.FormattingEnabled = true;
            this.MeasureCount.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MeasureCount.Items.AddRange(new object[] {
            "10",
            "20",
            "30",
            "40",
            "50",
            "60",
            "70",
            "80",
            "100",
            "200",
            "1000",
            "1601",
            "3202",
            "4802",
            "8004"});
            this.MeasureCount.Location = new System.Drawing.Point(784, 144);
            this.MeasureCount.Name = "MeasureCount";
            this.MeasureCount.Size = new System.Drawing.Size(114, 21);
            this.MeasureCount.TabIndex = 15;
            // 
            // disable
            // 
            this.disable.AutoSize = true;
            this.disable.Checked = true;
            this.disable.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.disable.Location = new System.Drawing.Point(100, 18);
            this.disable.Name = "disable";
            this.disable.Size = new System.Drawing.Size(97, 22);
            this.disable.TabIndex = 16;
            this.disable.TabStop = true;
            this.disable.Text = "выключен";
            this.disable.UseVisualStyleBackColor = true;
            // 
            // LPF
            // 
            this.LPF.AutoSize = true;
            this.LPF.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LPF.Location = new System.Drawing.Point(100, 41);
            this.LPF.Name = "LPF";
            this.LPF.Size = new System.Drawing.Size(53, 22);
            this.LPF.TabIndex = 16;
            this.LPF.Text = "LPF";
            this.LPF.UseVisualStyleBackColor = true;
            // 
            // HPF
            // 
            this.HPF.AutoSize = true;
            this.HPF.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HPF.Location = new System.Drawing.Point(100, 63);
            this.HPF.Name = "HPF";
            this.HPF.Size = new System.Drawing.Size(56, 22);
            this.HPF.TabIndex = 16;
            this.HPF.Text = "HPF";
            this.HPF.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label4.Location = new System.Drawing.Point(589, 405);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 39);
            this.label4.TabIndex = 14;
            this.label4.Text = "Делитель полосы \r\nпропускания";
            this.label4.UseCompatibleTextRendering = true;
            // 
            // Bandwidth
            // 
            this.Bandwidth.FormattingEnabled = true;
            this.Bandwidth.Items.AddRange(new object[] {
            "4",
            "10",
            "20",
            "45",
            "100",
            "200",
            "400",
            "800"});
            this.Bandwidth.Location = new System.Drawing.Point(738, 419);
            this.Bandwidth.Name = "Bandwidth";
            this.Bandwidth.Size = new System.Drawing.Size(160, 21);
            this.Bandwidth.TabIndex = 15;
            // 
            // StartMeasure
            // 
            this.StartMeasure.Location = new System.Drawing.Point(233, 76);
            this.StartMeasure.Name = "StartMeasure";
            this.StartMeasure.Size = new System.Drawing.Size(150, 51);
            this.StartMeasure.TabIndex = 17;
            this.StartMeasure.Text = "Измерить";
            this.StartMeasure.UseVisualStyleBackColor = true;
            this.StartMeasure.Click += new System.EventHandler(this.StartMeasure_Click);
            // 
            // scale2g
            // 
            this.scale2g.AutoSize = true;
            this.scale2g.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.scale2g.Location = new System.Drawing.Point(114, 15);
            this.scale2g.Name = "scale2g";
            this.scale2g.Size = new System.Drawing.Size(42, 22);
            this.scale2g.TabIndex = 18;
            this.scale2g.Text = "2g";
            this.scale2g.UseVisualStyleBackColor = true;
            // 
            // scale4g
            // 
            this.scale4g.AutoSize = true;
            this.scale4g.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.scale4g.Location = new System.Drawing.Point(114, 43);
            this.scale4g.Name = "scale4g";
            this.scale4g.Size = new System.Drawing.Size(42, 22);
            this.scale4g.TabIndex = 18;
            this.scale4g.Text = "4g";
            this.scale4g.UseVisualStyleBackColor = true;
            // 
            // scale8g
            // 
            this.scale8g.AutoSize = true;
            this.scale8g.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.scale8g.Location = new System.Drawing.Point(115, 71);
            this.scale8g.Name = "scale8g";
            this.scale8g.Size = new System.Drawing.Size(42, 22);
            this.scale8g.TabIndex = 18;
            this.scale8g.Text = "8g";
            this.scale8g.UseVisualStyleBackColor = true;
            // 
            // scale16g
            // 
            this.scale16g.AutoSize = true;
            this.scale16g.Checked = true;
            this.scale16g.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.scale16g.Location = new System.Drawing.Point(115, 99);
            this.scale16g.Name = "scale16g";
            this.scale16g.Size = new System.Drawing.Size(50, 22);
            this.scale16g.TabIndex = 18;
            this.scale16g.TabStop = true;
            this.scale16g.Text = "16g";
            this.scale16g.UseVisualStyleBackColor = true;
            // 
            // scale
            // 
            this.scale.Controls.Add(this.scale16g);
            this.scale.Controls.Add(this.scale8g);
            this.scale.Controls.Add(this.scale4g);
            this.scale.Controls.Add(this.scale2g);
            this.scale.Controls.Add(this.label2);
            this.scale.Location = new System.Drawing.Point(670, 171);
            this.scale.Name = "scale";
            this.scale.Size = new System.Drawing.Size(227, 127);
            this.scale.TabIndex = 19;
            this.scale.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.HPF);
            this.groupBox1.Controls.Add(this.LPF);
            this.groupBox1.Controls.Add(this.disable);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(671, 304);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(226, 98);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label5.Location = new System.Drawing.Point(6, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 18);
            this.label5.TabIndex = 13;
            this.label5.Text = "фильтр";
            // 
            // sigProc
            // 
            this.sigProc.AutoSize = true;
            this.sigProc.Checked = true;
            this.sigProc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.sigProc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sigProc.Location = new System.Drawing.Point(700, 12);
            this.sigProc.Name = "sigProc";
            this.sigProc.Size = new System.Drawing.Size(161, 22);
            this.sigProc.TabIndex = 21;
            this.sigProc.Text = "обработка сигнала";
            this.sigProc.UseVisualStyleBackColor = true;
            // 
            // Logs
            // 
            this.Logs.Location = new System.Drawing.Point(855, 692);
            this.Logs.Name = "Logs";
            this.Logs.Size = new System.Drawing.Size(140, 24);
            this.Logs.TabIndex = 22;
            this.Logs.Text = "папка логов";
            this.Logs.UseVisualStyleBackColor = true;
            this.Logs.Click += new System.EventHandler(this.Logs_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.axisZ);
            this.groupBox2.Controls.Add(this.axisY);
            this.groupBox2.Controls.Add(this.axisX);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(670, 40);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(227, 98);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            // 
            // axisZ
            // 
            this.axisZ.AutoSize = true;
            this.axisZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.axisZ.Location = new System.Drawing.Point(155, 70);
            this.axisZ.Name = "axisZ";
            this.axisZ.Size = new System.Drawing.Size(35, 22);
            this.axisZ.TabIndex = 19;
            this.axisZ.Text = "Z";
            this.axisZ.UseVisualStyleBackColor = true;
            // 
            // axisY
            // 
            this.axisY.AutoSize = true;
            this.axisY.Checked = true;
            this.axisY.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.axisY.Location = new System.Drawing.Point(155, 44);
            this.axisY.Name = "axisY";
            this.axisY.Size = new System.Drawing.Size(35, 22);
            this.axisY.TabIndex = 18;
            this.axisY.TabStop = true;
            this.axisY.Text = "Y";
            this.axisY.UseVisualStyleBackColor = true;
            // 
            // axisX
            // 
            this.axisX.AutoSize = true;
            this.axisX.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.axisX.Location = new System.Drawing.Point(155, 16);
            this.axisX.Name = "axisX";
            this.axisX.Size = new System.Drawing.Size(36, 22);
            this.axisX.TabIndex = 18;
            this.axisX.Text = "X";
            this.axisX.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label6.Location = new System.Drawing.Point(6, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 18);
            this.label6.TabIndex = 13;
            this.label6.Text = "ось измерения";
            // 
            // doFirmware
            // 
            this.doFirmware.Location = new System.Drawing.Point(855, 652);
            this.doFirmware.Name = "doFirmware";
            this.doFirmware.Size = new System.Drawing.Size(140, 24);
            this.doFirmware.TabIndex = 24;
            this.doFirmware.Text = "Прошить";
            this.doFirmware.UseVisualStyleBackColor = true;
            this.doFirmware.Click += new System.EventHandler(this.doFirmware_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1021, 738);
            this.Controls.Add(this.doFirmware);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.Logs);
            this.Controls.Add(this.sigProc);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.scale);
            this.Controls.Add(this.StartMeasure);
            this.Controls.Add(this.Bandwidth);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.MeasureCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBoxResult);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LogTextBox);
            this.Controls.Add(this.stopTestButton);
            this.Controls.Add(this.startTestButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "MainForm";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_Closing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResult)).EndInit();
            this.scale.ResumeLayout(false);
            this.scale.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startTestButton;
        private System.Windows.Forms.Button stopTestButton;
        private System.Windows.Forms.RichTextBox LogTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBoxResult;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox MeasureCount;
        private System.Windows.Forms.RadioButton disable;
        private System.Windows.Forms.RadioButton LPF;
        private System.Windows.Forms.RadioButton HPF;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox Bandwidth;
        private System.Windows.Forms.Button StartMeasure;
        private System.Windows.Forms.RadioButton scale2g;
        private System.Windows.Forms.RadioButton scale4g;
        private System.Windows.Forms.RadioButton scale8g;
        private System.Windows.Forms.RadioButton scale16g;
        private System.Windows.Forms.GroupBox scale;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox sigProc;
        private System.Windows.Forms.Button Logs;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton axisZ;
        private System.Windows.Forms.RadioButton axisY;
        private System.Windows.Forms.RadioButton axisX;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button doFirmware;
    }
}

