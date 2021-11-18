using Emgu.CV;
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
    }
}
