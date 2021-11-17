
namespace MotionDetectionWinFormsApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxCaptureDevice = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBoxCalculateMotionInfo = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxMotionPixelCountThresholdPerCentArea = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxMotionThreshold = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.selectFileButton = new System.Windows.Forms.Button();
            this.inputGroupBox = new System.Windows.Forms.GroupBox();
            this.rtspURITextBox = new System.Windows.Forms.TextBox();
            this.rtspURILabel = new System.Windows.Forms.Label();
            this.settingsGroupBox = new System.Windows.Forms.GroupBox();
            this.outputGroupBox = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.forgroundImageBox = new Emgu.CV.UI.ImageBox();
            this.label2 = new System.Windows.Forms.Label();
            this.motionImageBox = new Emgu.CV.UI.ImageBox();
            this.label1 = new System.Windows.Forms.Label();
            this.capturedImageBox = new Emgu.CV.UI.ImageBox();
            this.inputGroupBox.SuspendLayout();
            this.settingsGroupBox.SuspendLayout();
            this.outputGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.forgroundImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.motionImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.capturedImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 421);
            this.label3.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 37);
            this.label3.TabIndex = 4;
            this.label3.Text = "label3";
            // 
            // comboBoxCaptureDevice
            // 
            this.comboBoxCaptureDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCaptureDevice.FormattingEnabled = true;
            this.comboBoxCaptureDevice.Location = new System.Drawing.Point(272, 68);
            this.comboBoxCaptureDevice.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.comboBoxCaptureDevice.Name = "comboBoxCaptureDevice";
            this.comboBoxCaptureDevice.Size = new System.Drawing.Size(551, 45);
            this.comboBoxCaptureDevice.TabIndex = 7;
            this.comboBoxCaptureDevice.SelectedIndexChanged += new System.EventHandler(this.comboBoxCaptureDevice_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 72);
            this.label5.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(203, 37);
            this.label5.TabIndex = 8;
            this.label5.Text = "Capture Device:";
            // 
            // checkBoxCalculateMotionInfo
            // 
            this.checkBoxCalculateMotionInfo.AutoSize = true;
            this.checkBoxCalculateMotionInfo.Location = new System.Drawing.Point(1224, 151);
            this.checkBoxCalculateMotionInfo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBoxCalculateMotionInfo.Name = "checkBoxCalculateMotionInfo";
            this.checkBoxCalculateMotionInfo.Size = new System.Drawing.Size(305, 41);
            this.checkBoxCalculateMotionInfo.TabIndex = 11;
            this.checkBoxCalculateMotionInfo.Text = "Calculate Motion Info";
            this.checkBoxCalculateMotionInfo.UseVisualStyleBackColor = true;
            this.checkBoxCalculateMotionInfo.CheckedChanged += new System.EventHandler(this.checkBoxCalculateMotionInfo_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(34, 272);
            this.label7.Margin = new System.Windows.Forms.Padding(14, 0, 14, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(535, 37);
            this.label7.TabIndex = 17;
            this.label7.Text = "Motion Pixel Count Threshold PerCent Area:";
            // 
            // textBoxMotionPixelCountThresholdPerCentArea
            // 
            this.textBoxMotionPixelCountThresholdPerCentArea.Location = new System.Drawing.Point(616, 266);
            this.textBoxMotionPixelCountThresholdPerCentArea.Margin = new System.Windows.Forms.Padding(14, 16, 14, 16);
            this.textBoxMotionPixelCountThresholdPerCentArea.MaxLength = 4;
            this.textBoxMotionPixelCountThresholdPerCentArea.Name = "textBoxMotionPixelCountThresholdPerCentArea";
            this.textBoxMotionPixelCountThresholdPerCentArea.Size = new System.Drawing.Size(339, 43);
            this.textBoxMotionPixelCountThresholdPerCentArea.TabIndex = 16;
            this.textBoxMotionPixelCountThresholdPerCentArea.TextChanged += new System.EventHandler(this.textBoxMotionPixelCountThresholdPerCentArea_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(43, 160);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(234, 37);
            this.label6.TabIndex = 15;
            this.label6.Text = "Motion Threshold:";
            // 
            // textBoxMotionThreshold
            // 
            this.textBoxMotionThreshold.Location = new System.Drawing.Point(616, 155);
            this.textBoxMotionThreshold.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxMotionThreshold.Name = "textBoxMotionThreshold";
            this.textBoxMotionThreshold.Size = new System.Drawing.Size(339, 43);
            this.textBoxMotionThreshold.TabIndex = 14;
            this.textBoxMotionThreshold.TextChanged += new System.EventHandler(this.textBoxMotionThreshold_TextChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // selectFileButton
            // 
            this.selectFileButton.Location = new System.Drawing.Point(986, 68);
            this.selectFileButton.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.selectFileButton.Name = "selectFileButton";
            this.selectFileButton.Size = new System.Drawing.Size(634, 52);
            this.selectFileButton.TabIndex = 18;
            this.selectFileButton.Text = "Select A Video File...";
            this.selectFileButton.UseVisualStyleBackColor = true;
            this.selectFileButton.Click += new System.EventHandler(this.selectFileButton_Click);
            // 
            // inputGroupBox
            // 
            this.inputGroupBox.Controls.Add(this.rtspURITextBox);
            this.inputGroupBox.Controls.Add(this.rtspURILabel);
            this.inputGroupBox.Controls.Add(this.selectFileButton);
            this.inputGroupBox.Controls.Add(this.comboBoxCaptureDevice);
            this.inputGroupBox.Controls.Add(this.label5);
            this.inputGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.inputGroupBox.Location = new System.Drawing.Point(0, 0);
            this.inputGroupBox.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.inputGroupBox.Name = "inputGroupBox";
            this.inputGroupBox.Padding = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.inputGroupBox.Size = new System.Drawing.Size(3481, 171);
            this.inputGroupBox.TabIndex = 19;
            this.inputGroupBox.TabStop = false;
            this.inputGroupBox.Text = "Input";
            // 
            // rtspURITextBox
            // 
            this.rtspURITextBox.Location = new System.Drawing.Point(1892, 65);
            this.rtspURITextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rtspURITextBox.Name = "rtspURITextBox";
            this.rtspURITextBox.Size = new System.Drawing.Size(479, 43);
            this.rtspURITextBox.TabIndex = 19;
            this.rtspURITextBox.TextChanged += new System.EventHandler(this.rtspURITextBox_TextChanged);
            // 
            // rtspURILabel
            // 
            this.rtspURILabel.AutoSize = true;
            this.rtspURILabel.Location = new System.Drawing.Point(1760, 70);
            this.rtspURILabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.rtspURILabel.Name = "rtspURILabel";
            this.rtspURILabel.Size = new System.Drawing.Size(129, 37);
            this.rtspURILabel.TabIndex = 20;
            this.rtspURILabel.Text = "RTSP URI:";
            // 
            // settingsGroupBox
            // 
            this.settingsGroupBox.Controls.Add(this.checkBoxCalculateMotionInfo);
            this.settingsGroupBox.Controls.Add(this.label3);
            this.settingsGroupBox.Controls.Add(this.label7);
            this.settingsGroupBox.Controls.Add(this.textBoxMotionThreshold);
            this.settingsGroupBox.Controls.Add(this.textBoxMotionPixelCountThresholdPerCentArea);
            this.settingsGroupBox.Controls.Add(this.label6);
            this.settingsGroupBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.settingsGroupBox.Location = new System.Drawing.Point(0, 1210);
            this.settingsGroupBox.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.settingsGroupBox.Name = "settingsGroupBox";
            this.settingsGroupBox.Padding = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.settingsGroupBox.Size = new System.Drawing.Size(3481, 502);
            this.settingsGroupBox.TabIndex = 20;
            this.settingsGroupBox.TabStop = false;
            this.settingsGroupBox.Text = "Settings";
            // 
            // outputGroupBox
            // 
            this.outputGroupBox.Controls.Add(this.label4);
            this.outputGroupBox.Controls.Add(this.forgroundImageBox);
            this.outputGroupBox.Controls.Add(this.label2);
            this.outputGroupBox.Controls.Add(this.motionImageBox);
            this.outputGroupBox.Controls.Add(this.label1);
            this.outputGroupBox.Controls.Add(this.capturedImageBox);
            this.outputGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outputGroupBox.Location = new System.Drawing.Point(0, 171);
            this.outputGroupBox.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.outputGroupBox.Name = "outputGroupBox";
            this.outputGroupBox.Padding = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.outputGroupBox.Size = new System.Drawing.Size(3481, 1039);
            this.outputGroupBox.TabIndex = 21;
            this.outputGroupBox.TabStop = false;
            this.outputGroupBox.Text = "Output";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1224, 171);
            this.label4.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(211, 37);
            this.label4.TabIndex = 12;
            this.label4.Text = "Forground Mask";
            // 
            // forgroundImageBox
            // 
            this.forgroundImageBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.forgroundImageBox.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.forgroundImageBox.Location = new System.Drawing.Point(1231, 261);
            this.forgroundImageBox.Margin = new System.Windows.Forms.Padding(9, 7, 9, 7);
            this.forgroundImageBox.Name = "forgroundImageBox";
            this.forgroundImageBox.Size = new System.Drawing.Size(1042, 638);
            this.forgroundImageBox.TabIndex = 11;
            this.forgroundImageBox.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2358, 171);
            this.label2.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 37);
            this.label2.TabIndex = 10;
            this.label2.Text = "Motion";
            // 
            // motionImageBox
            // 
            this.motionImageBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.motionImageBox.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.motionImageBox.Location = new System.Drawing.Point(2367, 261);
            this.motionImageBox.Margin = new System.Windows.Forms.Padding(9, 7, 9, 7);
            this.motionImageBox.Name = "motionImageBox";
            this.motionImageBox.Size = new System.Drawing.Size(1042, 638);
            this.motionImageBox.TabIndex = 9;
            this.motionImageBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(81, 171);
            this.label1.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 37);
            this.label1.TabIndex = 8;
            this.label1.Text = "Captured Image:";
            // 
            // capturedImageBox
            // 
            this.capturedImageBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.capturedImageBox.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.capturedImageBox.Location = new System.Drawing.Point(70, 261);
            this.capturedImageBox.Margin = new System.Windows.Forms.Padding(9, 7, 9, 7);
            this.capturedImageBox.Name = "capturedImageBox";
            this.capturedImageBox.Size = new System.Drawing.Size(1073, 638);
            this.capturedImageBox.TabIndex = 7;
            this.capturedImageBox.TabStop = false;
            this.capturedImageBox.Paint += new System.Windows.Forms.PaintEventHandler(this.capturedImageBox_Paint);
            this.capturedImageBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.capturedImageBox_MouseDown);
            this.capturedImageBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.capturedImageBox_MouseMove);
            this.capturedImageBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.capturedImageBox_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(216F, 216F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(3481, 1712);
            this.Controls.Add(this.outputGroupBox);
            this.Controls.Add(this.settingsGroupBox);
            this.Controls.Add(this.inputGroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(9, 7, 9, 7);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.inputGroupBox.ResumeLayout(false);
            this.inputGroupBox.PerformLayout();
            this.settingsGroupBox.ResumeLayout(false);
            this.settingsGroupBox.PerformLayout();
            this.outputGroupBox.ResumeLayout(false);
            this.outputGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.forgroundImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.motionImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.capturedImageBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxCaptureDevice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBoxCalculateMotionInfo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxMotionPixelCountThresholdPerCentArea;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxMotionThreshold;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button selectFileButton;
        private System.Windows.Forms.GroupBox inputGroupBox;
        private System.Windows.Forms.GroupBox settingsGroupBox;
        private System.Windows.Forms.GroupBox outputGroupBox;
        private System.Windows.Forms.Label label4;
        private Emgu.CV.UI.ImageBox forgroundImageBox;
        private System.Windows.Forms.Label label2;
        private Emgu.CV.UI.ImageBox motionImageBox;
        private System.Windows.Forms.Label label1;
        private Emgu.CV.UI.ImageBox capturedImageBox;
        private System.Windows.Forms.TextBox rtspURITextBox;
        private System.Windows.Forms.Label rtspURILabel;
    }
}

