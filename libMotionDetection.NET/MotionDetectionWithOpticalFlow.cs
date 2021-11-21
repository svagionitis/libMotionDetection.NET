using Emgu.CV;
using Emgu.CV.Util;
using Serilog;
using System.Collections.Generic;
using System.Drawing;

namespace libMotionDetection
{
    /// <summary>
    /// A class for motion detection using optical flow
    /// </summary>
    public class MotionDetectionWithOpticalFlow
    {
        private static readonly ILogger logger = Log.Logger.ForContext (typeof (MotionDetectionWithOpticalFlow));
        private readonly Mat flowBGR = new Mat ();

        // A list of motion zones.
        public List<Rectangle> MotionZones { get; set; } = new List<Rectangle> ();

        public struct MotionSetting
        {
            public int MotionThreshold { get; set; }

            public override string ToString () =>
                $"MotionThreshold: {MotionThreshold}";
        }
        public MotionSetting Setting { get; set; } = new MotionSetting {
            MotionThreshold = 1000,
        };

        public struct OpticalFlowSetting
        {
            public DISOpticalFlow.Preset OpticalFlowPreset { get; set; }

            public override string ToString () =>
                $"OpticalFlowPreset: {OpticalFlowPreset}";
        }
        public OpticalFlowSetting FlowSetting { get; set; } = new OpticalFlowSetting {
            OpticalFlowPreset = DISOpticalFlow.Preset.Fast,
        };

        private readonly DISOpticalFlow opticalFlow;
        public MotionDetectionWithOpticalFlow ()
        {
            opticalFlow = new DISOpticalFlow ();
        }

        public MotionDetectionWithOpticalFlow (OpticalFlowSetting setting)
        {
            opticalFlow = new DISOpticalFlow (setting.OpticalFlowPreset);
        }

        public Mat CalculateOpticalFlow (Mat prevFrame, Mat currFrame)
        {
            // The currFrame needs to have 1 channel
            if (currFrame.Depth != Emgu.CV.CvEnum.DepthType.Cv8U || currFrame.NumberOfChannels != 1) {
                CvInvoke.CvtColor (currFrame, currFrame, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);
            }

            // The prevFrame needs to have 1 channel
            if (prevFrame.Depth != Emgu.CV.CvEnum.DepthType.Cv8U || prevFrame.NumberOfChannels != 1) {
                CvInvoke.CvtColor (prevFrame, prevFrame, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);
            }

            Mat flow = new Mat (prevFrame.Size, Emgu.CV.CvEnum.DepthType.Cv32F, 2);
            // Based on the example here, https://docs.opencv.org/4.5.4/d4/dee/tutorial_optical_flow.html
            // Calculate the flow as a 2D vector
            opticalFlow.Calc (prevFrame, currFrame, flow);

            VectorOfMat flowParts = new VectorOfMat ();
            // Split the flow in two parts, the magnitude and the angle
            CvInvoke.Split (flow, flowParts);
            flow.Dispose ();

            // Calculate magnitude and angle from a 2D vector.
            Mat angle = new Mat ();
            Mat magnitude = new Mat ();
            CvInvoke.CartToPolar (flowParts[0], flowParts[1], magnitude, angle, true);
            flowParts.Dispose ();

            Mat angleNormalized = new Mat ();
            Mat magnitudeNormalized = new Mat ();
            // Normalize the magnitude and angle
            CvInvoke.Normalize (magnitude, magnitudeNormalized, 0.0f, 1.0f, Emgu.CV.CvEnum.NormType.MinMax);
            angleNormalized = angle * (1.0f / 360.0f) * (180.0f / 255.0f);
            magnitude.Dispose ();
            angle.Dispose ();

            Mat flowHSV8 = new Mat ();
            Mat flowHSV32 = new Mat ();
            VectorOfMat vectorOfFlowHSV = new VectorOfMat (angleNormalized,
                                                           Mat.Ones (angleNormalized.Height, angleNormalized.Width, Emgu.CV.CvEnum.DepthType.Cv32F, 1),
                                                           magnitudeNormalized);
            angleNormalized.Dispose ();
            magnitudeNormalized.Dispose ();

            CvInvoke.Merge (vectorOfFlowHSV, flowHSV32);
            vectorOfFlowHSV.Dispose ();
            flowHSV32.ConvertTo (flowHSV8, Emgu.CV.CvEnum.DepthType.Cv8U, 255.0f);
            flowHSV32.Dispose ();

            // Convert HSV color space to BGR
            CvInvoke.CvtColor (flowHSV8, flowBGR, Emgu.CV.CvEnum.ColorConversion.Hsv2Bgr);
            flowHSV8.Dispose ();

            return flowBGR;
        }
    }
}
