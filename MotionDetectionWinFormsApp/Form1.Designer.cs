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
            ((System.ComponentModel.ISupportInitialize)(this.motionImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.capturedImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.forgroundImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 175);
            this.label1.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Captured Image:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2094, 175);
            this.label2.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 37);
            this.label2.TabIndex = 3;
            this.label2.Text = "Motion";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 1411);
            this.label3.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 37);
            this.label3.TabIndex = 4;
            this.label3.Text = "label3";
            // 
            // motionImageBox
            // 
            this.motionImageBox.Location = new System.Drawing.Point(2102, 274);
            this.motionImageBox.Margin = new System.Windows.Forms.Padding(9, 7, 9, 7);
            this.motionImageBox.Name = "motionImageBox";
            this.motionImageBox.Size = new System.Drawing.Size(992, 1024);
            this.motionImageBox.TabIndex = 2;
            this.motionImageBox.TabStop = false;
            // 
            // capturedImageBox
            // 
            this.capturedImageBox.Location = new System.Drawing.Point(17, 274);
            this.capturedImageBox.Margin = new System.Windows.Forms.Padding(9, 7, 9, 7);
            this.capturedImageBox.Name = "capturedImageBox";
            this.capturedImageBox.Size = new System.Drawing.Size(1022, 1024);
            this.capturedImageBox.TabIndex = 0;
            this.capturedImageBox.TabStop = false;
            // 
            // forgroundImageBox
            // 
            this.forgroundImageBox.Location = new System.Drawing.Point(1074, 274);
            this.forgroundImageBox.Margin = new System.Windows.Forms.Padding(9, 7, 9, 7);
            this.forgroundImageBox.Name = "forgroundImageBox";
            this.forgroundImageBox.Size = new System.Drawing.Size(992, 1024);
            this.forgroundImageBox.TabIndex = 5;
            this.forgroundImageBox.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1067, 175);
            this.label4.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(211, 37);
            this.label4.TabIndex = 6;
            this.label4.Text = "Forground Mask";
            // 
            // comboBoxCaptureDevice
            // 
            this.comboBoxCaptureDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCaptureDevice.FormattingEnabled = true;
            this.comboBoxCaptureDevice.Location = new System.Drawing.Point(244, 44);
            this.comboBoxCaptureDevice.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.comboBoxCaptureDevice.Name = "comboBoxCaptureDevice";
            this.comboBoxCaptureDevice.Size = new System.Drawing.Size(525, 45);
            this.comboBoxCaptureDevice.TabIndex = 7;
            this.comboBoxCaptureDevice.SelectedIndexChanged += new System.EventHandler(this.comboBoxCaptureDevice_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 64);
            this.label5.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(203, 37);
            this.label5.TabIndex = 8;
            this.label5.Text = "Capture Device:";
            // 
            // textBoxMotionThreshold
            // 
            this.textBoxMotionThreshold.Location = new System.Drawing.Point(1284, 46);
            this.textBoxMotionThreshold.Name = "textBoxMotionThreshold";
            this.textBoxMotionThreshold.Size = new System.Drawing.Size(323, 43);
            this.textBoxMotionThreshold.TabIndex = 9;
            this.textBoxMotionThreshold.TextChanged += new System.EventHandler(this.textBoxMotionThreshold_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1044, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(234, 37);
            this.label6.TabIndex = 10;
            this.label6.Text = "Motion Threshold:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(3146, 1502);
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
            this.Margin = new System.Windows.Forms.Padding(9, 7, 9, 7);
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
    }
}

