using Emgu.CV;
using libMotionDetection;
using libVideoCapture;
using Serilog;
using System;
using System.Windows.Forms;

namespace MotionDetectionWithOpticalFlowWinFormsApp
{
    public partial class Form1 : Form
    {
        private static readonly ILogger logger = Log.Logger.ForContext (typeof (Form1));

        private MotionDetectionWithDenseOpticalFlow motionDetectionWithDenseOpticalFlow;
        private VideoCaptureDevices videoCaptureDevices;
        private VideoCapture _capture = null;
        private string videoFilename = null;
        private string rtspURI = null;

        public Form1 ()
        {
            InitializeComponent ();

            videoCaptureDevices = new VideoCaptureDevices ();
            logger.Information ($"Capture Devices: {string.Join ("\n", videoCaptureDevices.VideoInputDevices)}");

            // Populate combo box with capture devices
            foreach (VideoCaptureDevices.DsVideoInputDevice capDevice in videoCaptureDevices.VideoInputDevices) {
                comboBoxCaptureDevice.Items.Add ($"{capDevice.VideoInputDevice.Name}");
            }
            // Initialie the combo box to first value
            comboBoxCaptureDevice.SelectedIndex = 0;
            InitializeCapture (comboBoxCaptureDevice.SelectedIndex);
        }

        /// <summary>
        /// Initialize capture device and start capturing frames
        /// </summary>
        private void InitializeCapture (int deviceIndex = 0)
        {
            if (_capture != null) {
                _capture.Stop ();
                _capture.ImageGrabbed -= ProcessFrame;
                _capture.Dispose ();
                _capture = null;
            }

            // Try to create the capture
            if (_capture == null) {
                try {
                    if (videoFilename != null) {
                        _capture = new VideoCapture (videoFilename);
                        videoFilename = null;
                    } else if (rtspURI != null) {
                        _capture = new VideoCapture (rtspURI);
                        rtspURI = null;
                    } else {
                        _capture = new VideoCapture (deviceIndex);
                    }
                } catch (NullReferenceException ex) {
                    MessageBox.Show (ex.Message);
                    logger.Error ($"{ex.Message}");
                }
            }

            //if camera capture has been successfully created
            if (_capture != null) {
                motionDetectionWithDenseOpticalFlow = new MotionDetectionWithDenseOpticalFlow ();

                _capture.ImageGrabbed += ProcessFrame;
                _capture.Start ();
            }
        }

        private Mat currentFrame = new Mat ();
        private Mat previousFrame = new Mat ();
        private void ProcessFrame (object sender, EventArgs e)
        {
            if (this.Disposing || this.IsDisposed)
                return;

            if (_capture.Retrieve (currentFrame)) {
                if (!currentFrame.Size.IsEmpty && !previousFrame.Size.IsEmpty &&
                    currentFrame.Size == previousFrame.Size) {

                    Mat flow = motionDetectionWithDenseOpticalFlow.CalculateDenseOpticalFlow (previousFrame, currentFrame);

                    motionImageBox.Image = motionDetectionWithDenseOpticalFlow.OpticalFlowVisualizationWithHSV (flow);
                    flow.Dispose ();
                    capturedImageBox.Image = currentFrame;

                    Mat frameDiff = currentFrame.Clone ();
                    CvInvoke.AbsDiff (previousFrame, currentFrame, frameDiff);
                    forgroundImageBox.Image = frameDiff;
                    frameDiff.Dispose ();
                }
                previousFrame = currentFrame.Clone ();
            }
        }

        private void Form1_FormClosed (object sender, FormClosedEventArgs e)
        {
            _capture.Stop ();
            _capture.ImageGrabbed -= ProcessFrame;
            _capture.Dispose ();
            _capture = null;
        }

        private void comboBoxCaptureDevice_SelectedIndexChanged (object sender, EventArgs e)
        {
            logger.Debug ($"Selected Capture device: {comboBoxCaptureDevice.Text}");
            string selectedCaptureDeviceName = comboBoxCaptureDevice.Text;
            int i = 0;

            foreach (VideoCaptureDevices.DsVideoInputDevice capDevice in videoCaptureDevices.VideoInputDevices) {
                if (capDevice.VideoInputDevice.Name.Equals (selectedCaptureDeviceName)) {
                    comboBoxCaptureDevice.SelectedIndex = i;

                    logger.Debug ($"Selected Capture device index: {comboBoxCaptureDevice.SelectedIndex}");
                    break;
                }
                i++;
            }

            // If there is a capture, stop it and reset the motion history
            if (_capture != null) {
                _capture.Stop ();
                _capture.ImageGrabbed -= ProcessFrame;
                _capture.Dispose ();
                _capture = null;
            }

            InitializeCapture (comboBoxCaptureDevice.SelectedIndex);
        }


        private void textBoxMotionThreshold_TextChanged (object sender, EventArgs e)
        {
        }

        private void checkBoxCalculateMotionInfo_CheckedChanged (object sender, EventArgs e)
        {
        }

        private void textBoxMotionPixelCountThresholdPerCentArea_TextChanged (object sender, EventArgs e)
        {
        }

        private void capturedImageBox_MouseDown (object sender, MouseEventArgs e)
        {
        }

        private void capturedImageBox_MouseMove (object sender, MouseEventArgs e)
        {
        }

        private void capturedImageBox_MouseUp (object sender, MouseEventArgs e)
        {
        }

        private void capturedImageBox_Paint (object sender, PaintEventArgs e)
        {
        }

        private void selectFileButton_Click (object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog () == DialogResult.OK) {
                logger.Debug ($"Selected file: {openFileDialog1.FileName}");

                // If there is a capture, stop it and reset the motion history
                if (_capture != null) {
                    _capture.Stop ();
                    _capture.ImageGrabbed -= ProcessFrame;
                    _capture.Dispose ();
                    _capture = null;
                }

                videoFilename = openFileDialog1.FileName;

                InitializeCapture (-1);
            }
        }

        private void rtspURITextBox_TextChanged (object sender, EventArgs e)
        {
            logger.Debug ($"RTSP URI: {rtspURITextBox.Text}");

            // If there is a capture, stop it and reset the motion history
            if (_capture != null) {
                _capture.Stop ();
                _capture.ImageGrabbed -= ProcessFrame;
                _capture.Dispose ();
                _capture = null;
            }

            rtspURI = rtspURITextBox.Text;

            InitializeCapture (-1);
        }
    }
}
