using DirectShowLib;
using Serilog;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;

namespace libVideoCapture
{
    /// <summary>
    /// A class for information for the video capture devices.
    /// Currently the name and the available resolutions are retrieved.
    /// </summary>
    public class VideoCaptureDevices
    {
        private static readonly ILogger logger = Log.Logger.ForContext (typeof (VideoCaptureDevices));

        /// <summary>
        /// A video input device struct which has the device
        /// and the available resolutions of the device
        /// </summary>
        public struct DsVideoInputDevice
        {
            public DsDevice VideoInputDevice { get; set; }

            public List<Size> AvailableResolutions { get; set; }

            public override string ToString () =>
                $"VideoInputDevice: {VideoInputDevice.Name} ({VideoInputDevice.DevicePath}), " +
                $"AvailableResolutions: {string.Join (", ", AvailableResolutions)}";
        }
        public DsVideoInputDevice[] VideoInputDevices { get; private set; } = { };

        public VideoCaptureDevices ()
        {
            GetAvailableVideoInputDevicesWithResolutions ();
        }

        /// <summary>
        /// Get available video input devices and their resolutions
        /// </summary>
        private void GetAvailableVideoInputDevicesWithResolutions ()
        {
            DsDevice[] videoInputDevices = DsDevice.GetDevicesOfCat (FilterCategory.VideoInputDevice);

            VideoInputDevices = new DsVideoInputDevice[videoInputDevices.Length];

            int i = 0;
            foreach (DsDevice videoInputDevice in videoInputDevices) {
                VideoInputDevices[i].VideoInputDevice = videoInputDevice;
                VideoInputDevices[i].AvailableResolutions = GetVideoCapabilities (videoInputDevice);
                i++;
            }
        }

        /// <summary>
        /// Get a list of available resolutions for a specific device.
        /// </summary>
        /// <param name="videoInputDevice">The device to get the capabilities</param>
        /// <returns>On success, the list of resolutions. On failure, an empty list</returns>
        private List<Size> GetVideoCapabilities (DsDevice videoInputDevice)
        {
            logger.Debug ($"videoInputDevice: {videoInputDevice.Name}, {videoInputDevice.DevicePath}");

            List<Size> availableResolutions = new List<Size> ();

            try {
                int hr;
                int max = 0;
                int bitCount = 0;

                VideoInfoHeader videoInfoHeader = new VideoInfoHeader ();
                AMMediaType[] mediaTypes = new AMMediaType[1];
                IntPtr fetched = IntPtr.Zero;

                IFilterGraph2 filterGraph = new FilterGraph () as IFilterGraph2;
                hr = filterGraph.AddSourceFilterForMoniker (videoInputDevice.Mon, null, videoInputDevice.Name, out IBaseFilter sourceFilter);
                DsError.ThrowExceptionForHR (hr);

                IPin pinRaw = DsFindPin.ByDirection (sourceFilter, PinDirection.Output, 0);
                hr = pinRaw.EnumMediaTypes (out IEnumMediaTypes mediaTypeEnum);
                DsError.ThrowExceptionForHR (hr);

                hr = mediaTypeEnum.Next (1, mediaTypes, fetched);
                DsError.ThrowExceptionForHR (hr);

                while (fetched != null && mediaTypes[0] != null) {
                    Marshal.PtrToStructure (mediaTypes[0].formatPtr, videoInfoHeader);
                    if (videoInfoHeader.BmiHeader.Size != 0 && videoInfoHeader.BmiHeader.BitCount != 0) {
                        if (videoInfoHeader.BmiHeader.BitCount > bitCount) {
                            availableResolutions.Clear ();
                            max = 0;
                            bitCount = videoInfoHeader.BmiHeader.BitCount;
                        }
                        availableResolutions.Add (new Size (videoInfoHeader.BmiHeader.Width, videoInfoHeader.BmiHeader.Height));
                        if (videoInfoHeader.BmiHeader.Width > max || videoInfoHeader.BmiHeader.Height > max)
                            max = (Math.Max (videoInfoHeader.BmiHeader.Width, videoInfoHeader.BmiHeader.Height));
                    }

                    hr = mediaTypeEnum.Next (1, mediaTypes, fetched);
                    DsError.ThrowExceptionForHR (hr);
                }

                logger.Debug ($"Resolutions: {string.Join (", ", availableResolutions)}");

            } catch (Exception ex) {
                logger.Error ($"Error: {ex.Message}");
            }

            return availableResolutions;
        }
    }
}
