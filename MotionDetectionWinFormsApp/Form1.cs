using Emgu.CV;
using libMotionDetection;
using System;
using System.Windows.Forms;

namespace MotionDetectionWinFormsApp
{
    public partial class Form1 : Form
    {
        private MotionDetectionWithMotionHistory motionDetectionWithMotionHistory;
        private VideoCapture _capture;

        public Form1 ()
        {
            InitializeComponent ();

            //try to create the capture
            if (_capture == null) {
                try {
                    _capture = new VideoCapture ();
                } catch (NullReferenceException excpt) {   //show errors if there is any
                    MessageBox.Show (excpt.Message);
                }
            }

            if (_capture != null) //if camera capture has been successfully created
            {
                motionDetectionWithMotionHistory = new MotionDetectionWithMotionHistory ();

                _capture.ImageGrabbed += ProcessFrame;
                _capture.Start ();
            }
        }

        private void ProcessFrame (object sender, EventArgs e)
        {
            Mat image = new Mat ();

            _capture.Retrieve (image);

            motionDetectionWithMotionHistory.GetFrameMotionComponents (image);

            //create the motion image 
            Mat motionImage = motionDetectionWithMotionHistory.GetMotionImage ();

            motionDetectionWithMotionHistory.MotionDetectionDrawGraphics (image);

            if (this.Disposing || this.IsDisposed)
                return;

            capturedImageBox.Image = image;
            forgroundImageBox.Image = motionDetectionWithMotionHistory.MotionForgroundMask;

            //Display the image of the motion
            motionImageBox.Image = motionImage;

            //Display the amount of motions found on the current image
            UpdateText (String.Format ($"Total Motions found: {motionDetectionWithMotionHistory.MotionComponents.Length}"));

            int i = 0;
            foreach (MotionDetectionWithMotionHistory.MotionComponent comp in motionDetectionWithMotionHistory.MotionComponents) {
                UpdateText (String.Format ($"Motion Component {i}: {comp}"));
                i++;
            }
        }

        private void UpdateText (String text)
        {
            if (!IsDisposed && !Disposing && InvokeRequired) {
                Invoke ((Action<String>) UpdateText, text);
            } else {
                label3.Text = text;
            }
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing)
        {

            if (disposing && (components != null)) {
                components.Dispose ();
            }

            base.Dispose (disposing);
        }

        private void Form1_FormClosed (object sender, FormClosedEventArgs e)
        {
            _capture.Stop ();
        }
    }
}
