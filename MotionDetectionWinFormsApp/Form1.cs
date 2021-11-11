using Emgu.CV;
using libMotionDetection;
using libVideoCapture;
using Serilog;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MotionDetectionWinFormsApp
{
    public partial class Form1 : Form
    {
        private static readonly ILogger logger = Log.Logger.ForContext (typeof (Form1));

        private MotionDetectionWithMotionHistory motionDetectionWithMotionHistory;
        private VideoCaptureDevices videoCaptureDevices;
        private VideoCapture _capture = null;

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

            // Initialize the text box of motion threshold
            textBoxMotionThreshold.Text = motionDetectionWithMotionHistory.Setting.MotionThreshold.ToString ();

            // Initialie the check box of capturing motion info
            checkBoxCalculateMotionInfo.Checked = motionDetectionWithMotionHistory.Setting.CalculateMotionInfo;

            // Initialize the text box of Motion Pixel Count Threshold PerCent Area
            textBoxMotionPixelCountThresholdPerCentArea.Text = motionDetectionWithMotionHistory.Setting.MotionPixelCountThresholdPerCentArea.ToString ();
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

            // If the check box for motion info is checked,
            // then calculate the motion image
            if (checkBoxCalculateMotionInfo.Checked) {
                //create the motion image
                Mat motionImage = motionDetectionWithMotionHistory.GetMotionImage ();
                //Display the image of the motion
                motionImageBox.Image = motionImage;
            }

            motionDetectionWithMotionHistory.MotionDetectionDrawGraphics (image);

            if (this.Disposing || this.IsDisposed)
                return;

            capturedImageBox.Image = image;
            forgroundImageBox.Image = motionDetectionWithMotionHistory.MotionForgroundMask;

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

        /// <summary>
        /// When the checked state of the check box is changed, update the CalculateMotionInfo setting.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxCalculateMotionInfo_CheckedChanged (object sender, EventArgs e)
        {
            MotionDetectionWithMotionHistory.MotionSetting setting = motionDetectionWithMotionHistory.Setting;
            setting.CalculateMotionInfo = checkBoxCalculateMotionInfo.Checked;

            motionDetectionWithMotionHistory.Setting = setting;
        }

        private void textBoxMotionPixelCountThresholdPerCentArea_TextChanged (object sender, EventArgs e)
        {
            try {
                MotionDetectionWithMotionHistory.MotionSetting setting = motionDetectionWithMotionHistory.Setting;
                setting.MotionPixelCountThresholdPerCentArea = double.Parse (textBoxMotionPixelCountThresholdPerCentArea.Text);

                motionDetectionWithMotionHistory.Setting = setting;
            } catch (FormatException ex) {
                MessageBox.Show (ex.Message);
                logger.Error ($"{ex.Message}");
            }
        }

        private Point MotionZoneStartPoint;
        private Point MotionZoneCurrentPoint;
        private Rectangle MotionZone = new Rectangle ();
        bool doRectangle = false;
        private void capturedImageBox_MouseDown (object sender, MouseEventArgs e)
        {
            // Determine the initial rectangle coordinates...
            MotionZoneStartPoint = e.Location;
            doRectangle = true;
        }

        private void capturedImageBox_MouseMove (object sender, MouseEventArgs e)
        {
            // Get the points while moving the mouse
            MotionZoneCurrentPoint = e.Location;
        }

        private void capturedImageBox_MouseUp (object sender, MouseEventArgs e)
        {
            if (doRectangle) {
                // We finished drawing the rectangle, so add it to the motion zones list and
                // make the doRectangle flag false
                Point motionZoneEndPoint = e.Location;

                MotionZone.Location = new Point (
                    Math.Min (MotionZoneStartPoint.X, motionZoneEndPoint.X),
                    Math.Min (MotionZoneStartPoint.Y, motionZoneEndPoint.Y));
                MotionZone.Size = new Size (
                    Math.Abs (MotionZoneStartPoint.X - motionZoneEndPoint.X),
                    Math.Abs (MotionZoneStartPoint.Y - motionZoneEndPoint.Y));

                motionDetectionWithMotionHistory.MotionZones.Add (MotionZone);

                doRectangle = false;
            }
        }

        private void capturedImageBox_Paint (object sender, PaintEventArgs e)
        {
            if (doRectangle) {
                MotionZone.Location = new Point (
                    Math.Min (MotionZoneStartPoint.X, MotionZoneCurrentPoint.X),
                    Math.Min (MotionZoneStartPoint.Y, MotionZoneCurrentPoint.Y));
                MotionZone.Size = new Size (
                    Math.Abs (MotionZoneStartPoint.X - MotionZoneCurrentPoint.X),
                    Math.Abs (MotionZoneStartPoint.Y - MotionZoneCurrentPoint.Y));

                e.Graphics.DrawRectangle (Pens.Red, MotionZone);
            }
        }
    }
}
