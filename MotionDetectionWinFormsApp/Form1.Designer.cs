﻿
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
            this.textBoxMotionThreshold = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBoxCalculateMotionInfo = new System.Windows.Forms.CheckBox();
            this.textBoxMotionPixelCountThresholdPerCentArea = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.motionImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.capturedImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.forgroundImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 71);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Captured Image:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(977, 71);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Motion";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 572);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "label3";
            // 
            // motionImageBox
            // 
            this.motionImageBox.Location = new System.Drawing.Point(981, 111);
            this.motionImageBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.motionImageBox.Name = "motionImageBox";
            this.motionImageBox.Size = new System.Drawing.Size(463, 415);
            this.motionImageBox.TabIndex = 2;
            this.motionImageBox.TabStop = false;
            // 
            // capturedImageBox
            // 
            this.capturedImageBox.Location = new System.Drawing.Point(8, 111);
            this.capturedImageBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.capturedImageBox.Name = "capturedImageBox";
            this.capturedImageBox.Size = new System.Drawing.Size(477, 415);
            this.capturedImageBox.TabIndex = 0;
            this.capturedImageBox.TabStop = false;
            // 
            // forgroundImageBox
            // 
            this.forgroundImageBox.Location = new System.Drawing.Point(501, 111);
            this.forgroundImageBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.forgroundImageBox.Name = "forgroundImageBox";
            this.forgroundImageBox.Size = new System.Drawing.Size(463, 415);
            this.forgroundImageBox.TabIndex = 5;
            this.forgroundImageBox.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(498, 71);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Forground Mask";
            // 
            // comboBoxCaptureDevice
            // 
            this.comboBoxCaptureDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCaptureDevice.FormattingEnabled = true;
            this.comboBoxCaptureDevice.Location = new System.Drawing.Point(114, 18);
            this.comboBoxCaptureDevice.Name = "comboBoxCaptureDevice";
            this.comboBoxCaptureDevice.Size = new System.Drawing.Size(247, 23);
            this.comboBoxCaptureDevice.TabIndex = 7;
            this.comboBoxCaptureDevice.SelectedIndexChanged += new System.EventHandler(this.comboBoxCaptureDevice_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 26);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Capture Device:";
            // 
            // textBoxMotionThreshold
            // 
            this.textBoxMotionThreshold.Location = new System.Drawing.Point(599, 19);
            this.textBoxMotionThreshold.Margin = new System.Windows.Forms.Padding(1);
            this.textBoxMotionThreshold.Name = "textBoxMotionThreshold";
            this.textBoxMotionThreshold.Size = new System.Drawing.Size(153, 23);
            this.textBoxMotionThreshold.TabIndex = 9;
            this.textBoxMotionThreshold.TextChanged += new System.EventHandler(this.textBoxMotionThreshold_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(487, 21);
            this.label6.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "Motion Threshold:";
            // 
            // checkBoxCalculateMotionInfo
            // 
            this.checkBoxCalculateMotionInfo.AutoSize = true;
            this.checkBoxCalculateMotionInfo.Location = new System.Drawing.Point(784, 18);
            this.checkBoxCalculateMotionInfo.Margin = new System.Windows.Forms.Padding(1);
            this.checkBoxCalculateMotionInfo.Name = "checkBoxCalculateMotionInfo";
            this.checkBoxCalculateMotionInfo.Size = new System.Drawing.Size(141, 19);
            this.checkBoxCalculateMotionInfo.TabIndex = 11;
            this.checkBoxCalculateMotionInfo.Text = "Calculate Motion Info";
            this.checkBoxCalculateMotionInfo.UseVisualStyleBackColor = true;
            this.checkBoxCalculateMotionInfo.CheckedChanged += new System.EventHandler(this.checkBoxCalculateMotionInfo_CheckedChanged);
            // 
            // textBoxMotionPixelCountThresholdPerCentArea
            // 
            this.textBoxMotionPixelCountThresholdPerCentArea.Location = new System.Drawing.Point(599, 43);
            this.textBoxMotionPixelCountThresholdPerCentArea.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.textBoxMotionPixelCountThresholdPerCentArea.MaxLength = 4;
            this.textBoxMotionPixelCountThresholdPerCentArea.Name = "textBoxMotionPixelCountThresholdPerCentArea";
            this.textBoxMotionPixelCountThresholdPerCentArea.Size = new System.Drawing.Size(153, 23);
            this.textBoxMotionPixelCountThresholdPerCentArea.TabIndex = 12;
            this.textBoxMotionPixelCountThresholdPerCentArea.TextChanged += new System.EventHandler(this.textBoxMotionPixelCountThresholdPerCentArea_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(347, 43);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(240, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "Motion Pixel Count Threshold PerCent Area:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1493, 602);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxMotionPixelCountThresholdPerCentArea);
            this.Controls.Add(this.checkBoxCalculateMotionInfo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxMotionThreshold);
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
        private System.Windows.Forms.TextBox textBoxMotionThreshold;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBoxCalculateMotionInfo;
        private System.Windows.Forms.TextBox textBoxMotionPixelCountThresholdPerCentArea;
        private System.Windows.Forms.Label label7;
    }
}

