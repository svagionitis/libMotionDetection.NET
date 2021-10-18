using Emgu.CV;
using libMotionDetection;
using libVideoCapture;
using Serilog;
using System;
using System.Windows.Forms;

namespace MotionDetectionWinFormsApp
{
    public partial class Form1 : Form
    {
        private static readonly ILogger logger = Log.Logger.ForContext (typeof (Form1));

        private MotionDetectionWithMotionHistory motionDetectionWithMotionHistory;
        private VideoCaptureDevices videoCaptureDevices;
        private VideoCapture _capture;

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

            // Initialize the text box of motion threshold
            textBoxMotionThreshold.Text = motionDetectionWithMotionHistory.Setting.MotionThreshold.ToString ();

            InitializeCapture (comboBoxCaptureDevice.SelectedIndex);
        }

        /// <summary>
        /// Initialize capture device and start capturing frames
        /// </summary>
        private void InitializeCapture (int deviceIndex = 0)
        {
            if (_capture != null) {
                _capture.Stop ();
                _capture.Dispose ();
                _capture = null;
            }

            //try to create the capture
            if (_capture == null) {
                try {
                    _capture = new VideoCapture (deviceIndex);
                } catch (NullReferenceException excpt) {   //show errors if there is any
                    MessageBox.Show (excpt.Message);
                    logger.Error ($"{excpt.Message}");
                }
            }

            //if camera capture has been successfully created
            if (_capture != null) {
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
            logger.Information ($"Total Motions found: {motionDetectionWithMotionHistory.MotionComponents.Length}");

            int i = 0;
            foreach (MotionDetectionWithMotionHistory.MotionComponent comp in motionDetectionWithMotionHistory.MotionComponents) {
                UpdateText (String.Format ($"Motion Component {i}: {comp}"));
                logger.Information ($"Motion Component {i}: {comp}");
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
                motionDetectionWithMotionHistory.Reset ();
                _capture.Stop ();
                _capture.Dispose ();
                _capture = null;
            }

            InitializeCapture (comboBoxCaptureDevice.SelectedIndex);
        }

        /// <summary>
        /// When the text is changed in the motion threshold text box, then update the motion threshold
        /// in the motion detection library instance.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxMotionThreshold_TextChanged (object sender, EventArgs e)
        {
            try {
                MotionDetectionWithMotionHistory.MotionSetting setting = motionDetectionWithMotionHistory.Setting;
                setting.MotionThreshold = Int32.Parse (textBoxMotionThreshold.Text);

                motionDetectionWithMotionHistory.Setting = setting;
            } catch (FormatException ex) {
                MessageBox.Show (ex.Message);
                logger.Error ($"{ex.Message}");
            }
        }
    }
}
