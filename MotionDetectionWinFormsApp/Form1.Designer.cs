
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.motionImageBox = new Emgu.CV.UI.ImageBox();
            this.capturedImageBox = new Emgu.CV.UI.ImageBox();
            this.forgroundImageBox = new Emgu.CV.UI.ImageBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxCaptureDevice = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBoxCalculateMotionInfo = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxMotionPixelCountThresholdPerCentArea = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxMotionThreshold = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.selectFileButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.motionImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.capturedImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.forgroundImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 169);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Captured Image:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(977, 169);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 37);
            this.label2.TabIndex = 3;
            this.label2.Text = "Motion";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 851);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 37);
            this.label3.TabIndex = 4;
            this.label3.Text = "label3";
            // 
            // motionImageBox
            // 
            this.motionImageBox.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.motionImageBox.Location = new System.Drawing.Point(981, 209);
            this.motionImageBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.motionImageBox.Name = "motionImageBox";
            this.motionImageBox.Size = new System.Drawing.Size(463, 415);
            this.motionImageBox.TabIndex = 2;
            this.motionImageBox.TabStop = false;
            // 
            // capturedImageBox
            // 
            this.capturedImageBox.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.capturedImageBox.Location = new System.Drawing.Point(8, 209);
            this.capturedImageBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.capturedImageBox.Name = "capturedImageBox";
            this.capturedImageBox.Size = new System.Drawing.Size(477, 415);
            this.capturedImageBox.TabIndex = 0;
            this.capturedImageBox.TabStop = false;
            this.capturedImageBox.Paint += new System.Windows.Forms.PaintEventHandler(this.capturedImageBox_Paint);
            this.capturedImageBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.capturedImageBox_MouseDown);
            this.capturedImageBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.capturedImageBox_MouseMove);
            this.capturedImageBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.capturedImageBox_MouseUp);
            // 
            // forgroundImageBox
            // 
            this.forgroundImageBox.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.forgroundImageBox.Location = new System.Drawing.Point(501, 209);
            this.forgroundImageBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.forgroundImageBox.Name = "forgroundImageBox";
            this.forgroundImageBox.Size = new System.Drawing.Size(463, 415);
            this.forgroundImageBox.TabIndex = 5;
            this.forgroundImageBox.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(498, 169);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(211, 37);
            this.label4.TabIndex = 6;
            this.label4.Text = "Forground Mask";
            // 
            // comboBoxCaptureDevice
            // 
            this.comboBoxCaptureDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCaptureDevice.FormattingEnabled = true;
            this.comboBoxCaptureDevice.Location = new System.Drawing.Point(239, 24);
            this.comboBoxCaptureDevice.Name = "comboBoxCaptureDevice";
            this.comboBoxCaptureDevice.Size = new System.Drawing.Size(247, 45);
            this.comboBoxCaptureDevice.TabIndex = 7;
            this.comboBoxCaptureDevice.SelectedIndexChanged += new System.EventHandler(this.comboBoxCaptureDevice_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 26);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(203, 37);
            this.label5.TabIndex = 8;
            this.label5.Text = "Capture Device:";
            // 
            // checkBoxCalculateMotionInfo
            // 
            this.checkBoxCalculateMotionInfo.AutoSize = true;
            this.checkBoxCalculateMotionInfo.Location = new System.Drawing.Point(981, 667);
            this.checkBoxCalculateMotionInfo.Margin = new System.Windows.Forms.Padding(1);
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
            this.label7.Location = new System.Drawing.Point(23, 726);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(535, 37);
            this.label7.TabIndex = 17;
            this.label7.Text = "Motion Pixel Count Threshold PerCent Area:";
            // 
            // textBoxMotionPixelCountThresholdPerCentArea
            // 
            this.textBoxMotionPixelCountThresholdPerCentArea.Location = new System.Drawing.Point(570, 726);
            this.textBoxMotionPixelCountThresholdPerCentArea.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.textBoxMotionPixelCountThresholdPerCentArea.MaxLength = 4;
            this.textBoxMotionPixelCountThresholdPerCentArea.Name = "textBoxMotionPixelCountThresholdPerCentArea";
            this.textBoxMotionPixelCountThresholdPerCentArea.Size = new System.Drawing.Size(153, 43);
            this.textBoxMotionPixelCountThresholdPerCentArea.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 668);
            this.label6.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(234, 37);
            this.label6.TabIndex = 15;
            this.label6.Text = "Motion Threshold:";
            // 
            // textBoxMotionThreshold
            // 
            this.textBoxMotionThreshold.Location = new System.Drawing.Point(282, 666);
            this.textBoxMotionThreshold.Margin = new System.Windows.Forms.Padding(1);
            this.textBoxMotionThreshold.Name = "textBoxMotionThreshold";
            this.textBoxMotionThreshold.Size = new System.Drawing.Size(153, 43);
            this.textBoxMotionThreshold.TabIndex = 14;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // selectFileButton
            // 
            this.selectFileButton.Location = new System.Drawing.Point(600, 24);
            this.selectFileButton.Name = "selectFileButton";
            this.selectFileButton.Size = new System.Drawing.Size(282, 45);
            this.selectFileButton.TabIndex = 18;
            this.selectFileButton.Text = "Select A Video File...";
            this.selectFileButton.UseVisualStyleBackColor = true;
            this.selectFileButton.Click += new System.EventHandler(this.selectFileButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1536, 931);
            this.Controls.Add(this.selectFileButton);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxMotionPixelCountThresholdPerCentArea);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxMotionThreshold);
            this.Controls.Add(this.checkBoxCalculateMotionInfo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBoxCaptureDevice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.forgroundImageBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.motionImageBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.capturedImageBox);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.motionImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.capturedImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.forgroundImageBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox capturedImageBox;
        private System.Windows.Forms.Label label1;
        private Emgu.CV.UI.ImageBox motionImageBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Emgu.CV.UI.ImageBox forgroundImageBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxCaptureDevice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBoxCalculateMotionInfo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxMotionPixelCountThresholdPerCentArea;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxMotionThreshold;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button selectFileButton;
    }
}

