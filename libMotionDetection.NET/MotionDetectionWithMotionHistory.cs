using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Serilog;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace libMotionDetection
{
    /// <summary>
    /// A class for motion detection using motion history
    /// </summary>
    public class MotionDetectionWithMotionHistory
    {
        private static readonly ILogger logger = Log.Logger.ForContext (typeof (MotionDetectionWithMotionHistory));

        // Threshold to define a motion area, reduce the value to detect smaller motion. Default value is 1000.
        public int MotionThreshold { get; set; } = 1000;
        // An array of motion zones.
        public Rectangle[] MotionZones { get; set; } = new Rectangle[] { };

        /// <summary>
        /// This structure holds information of the region which detected motion.
        /// </summary>
        public struct MotionComponent
        {
            /// <summary>
            /// The rectangle area of the motion
            /// </summary>
            public Rectangle MotionBoundingRectangle { get; set; }

            /// <summary>
            /// The orientation of the motion
            /// </summary>
            public double MotionAngle { get; set; }

            /// <summary>
            /// The number of motion pixels of the motion
            /// </summary>
            public double MotionPixelCount { get; set; }

            public override string ToString () =>
                $"MotionBoundingRectangle: (X: {MotionBoundingRectangle.X}, Y: {MotionBoundingRectangle.Y}, " +
                $"Width: {MotionBoundingRectangle.Width}, Height: {MotionBoundingRectangle.Height}), " +
                $"MotionAngle: {MotionAngle}, MotionPixelCount: {MotionPixelCount}";
        }
        public MotionComponent[] MotionComponents { get; private set; } = new MotionComponent[] { };


        // See example https://github.com/emgucv/emgucv/blob/master/Emgu.CV.Example/MotionDetection
        private MotionHistory _motionHistory;
        private IBackgroundSubtractor _forgroundDetector;

        public Mat MotionMask { get; private set; } = new Mat ();
        public Mat MotionForgroundMask { get; private set; } = new Mat ();

        public MotionDetectionWithMotionHistory ()
        {
            // Initialize motion detection algorithms
            // See example here, https://github.com/emgucv/emgucv/blob/master/Emgu.CV.Example/MotionDetection/Form1.cs
            _motionHistory = new MotionHistory (
                2.0, //in second, the duration of motion history you wants to keep
                0.05, //in second, Any change happens between a time interval larger than this will not be considered
                0.5); //in second, Any change happens between a time interval smaller than this will not be considered

            _forgroundDetector = new BackgroundSubtractorMOG2 ();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mhiDuration">The duration of motion history you want to keep, in seconds</param>
        /// <param name="maxTimeDelta">Any change happens between a time interval larger than this will not be considered, in seconds</param>
        /// <param name="minTimeDelta">Any change happens between a time interval smaller than this will not be considered, in seconds</param>
        public MotionDetectionWithMotionHistory (double mhiDuration, double maxTimeDelta, double minTimeDelta)
        {
            // Initialize motion detection algorithms
            // See example here, https://github.com/emgucv/emgucv/blob/master/Emgu.CV.Example/MotionDetection/Form1.cs
            _motionHistory = new MotionHistory (mhiDuration, maxTimeDelta, minTimeDelta);

            _forgroundDetector = new BackgroundSubtractorMOG2 ();
        }

        /// <summary>
        /// Get the motion components of a frame
        /// </summary>
        /// <param name="frame">The frame to get the motion components</param>
        public void GetFrameMotionComponents (Mat frame)
        {
            MotionComponents = GetFrameMotionComponents (ref _motionHistory, ref _forgroundDetector, MotionForgroundMask,
                                                         MotionThreshold, MotionZones, frame);
        }

        /// <summary>
        /// Get the motion image of an image
        /// </summary>
        /// <returns></returns>
        public Mat GetMotionImage ()
        {
            return GetMotionImage (MotionMask, _motionHistory);
        }

        /// <summary>
        /// Draw the graphics for motion detection.
        /// </summary>
        /// <param name="frame">The frame to draw the motion detection graphics.</param>
        /// <param name="lineCrossing">A line indicating a line crossing. Default value is a zero length line.</param>
        public void MotionDetectionDrawGraphics (Mat frame, LineSegment2D lineCrossing = new LineSegment2D ())
        {
            MotionDetectionDrawGraphics (MotionComponents, MotionZones, frame, lineCrossing);
        }

        /// <summary>
        /// Reset motion detection
        /// </summary>
        /// <param name="mhiDuration">The duration of motion history you want to keep, in seconds. Default value 2.</param>
        /// <param name="maxTimeDelta">Any change happens between a time interval larger than this will not be considered, in seconds. Default value 0.05.</param>
        /// <param name="minTimeDelta">Any change happens between a time interval smaller than this will not be considered, in seconds. Default value 0.5.</param>
        public void Reset (double mhiDuration = 2.0, double maxTimeDelta = 0.05, double minTimeDelta = 0.5)
        {
            // Reset the motion masks and motion components
            MotionMask = new Mat ();
            MotionForgroundMask = new Mat ();
            MotionZones = new Rectangle[] { };
            MotionComponents = new MotionComponent[] { };

            _motionHistory = new MotionHistory (mhiDuration, maxTimeDelta, minTimeDelta);
            _forgroundDetector = new BackgroundSubtractorMOG2 ();
        }

        #region PrivateFunctions
        /// <summary>
        /// Get the motion components of a frame
        /// </summary>
        /// <remark>
        /// We first get the motion components with the function GetMotionComponents()
        /// which get the motion components as an array of rectangles.
        /// Then we filter those according to the following:
        /// 1. If it does not belong to a motion zone, it is removed from the motion components array.
        /// 2. If the area of the motion component is below the motion threshold, it is removed
        ///    from the motion components array.
        /// 3. If it has too few motion according to motion pixel count, it is removed
        ///    from the motion components array.
        /// </remark>
        /// <param name="motionHistory">The updated motion history instance.</param>
        /// <param name="forgroundDetector">The updated forground detector instance.</param>
        /// <param name="forgroundMask">The updated forground mask.</param>
        /// <param name="motionThreshold">The threshold to detect motion.</param>
        /// <param name="motionZones">The motion zones which is an array of rectangles.</param>
        /// <param name="frame">The frame to get the motion components</param>
        private MotionComponent[] GetFrameMotionComponents (ref MotionHistory motionHistory, ref IBackgroundSubtractor forgroundDetector, Mat forgroundMask,
                                                            int motionThreshold, Rectangle[] motionZones, Mat frame)
        {
            Mat segMask = new Mat ();

            if (forgroundDetector == null) {
                forgroundDetector = new BackgroundSubtractorMOG2 ();
            }
            // Update the background model, https://www.emgu.com/wiki/files/4.5.1/document/html/38240163-6e39-4ead-5e97-5c9646bef2f6.htm
            forgroundDetector.Apply (frame, forgroundMask);

            // Update the motion history with the specific image
            motionHistory.Update (forgroundMask);

            // Get the motion components as rectangles
            Rectangle[] motionBoundingRectangles;
            using (VectorOfRect boundingRect = new VectorOfRect ()) {
                motionHistory.GetMotionComponents (segMask, boundingRect);
                motionBoundingRectangles = boundingRect.ToArray ();
            }

            // Create a list of MotionComponent to store the motion components according to the following
            // * the rectangles that don't belong to a motion zone
            // * the rectangles that have small area according to a threshold
            // * the rectangles that contains too few motion
            List<MotionComponent> motionComponentsList = new List<MotionComponent> { };
            foreach (Rectangle motionBoundingRectangle in motionBoundingRectangles) {
                MotionComponent motionComponent = new MotionComponent ();

                // If there are motion zones, then check if the motion rectangles
                // are in those zones
                if (motionZones.Length != 0) {
                    bool isInMotionZone = false;
                    // Check if the motion component is in the motion zones
                    foreach (Rectangle motionZone in motionZones) {
                        if (motionZone.Contains (motionBoundingRectangle)) {
                            isInMotionZone = true;
                        }
                    }
                    // If the motion component does not belong in any motion
                    // area then continue to the next.
                    if (!isInMotionZone) {
                        continue;
                    }
                }

                // Remove the component that have small area
                int area = motionBoundingRectangle.Width * motionBoundingRectangle.Height;
                if (area < motionThreshold) {
                    continue;
                }

                // Find the angle and motion pixel count of the specific area
                double angle, motionPixelCount;
                motionHistory.MotionInfo (forgroundMask, motionBoundingRectangle, out angle, out motionPixelCount);
                // Remove the component that contains too few motion
                if (motionPixelCount < area * 0.05) {
                    continue;
                }

                motionComponent.MotionBoundingRectangle = motionBoundingRectangle;
                motionComponent.MotionAngle = angle;
                motionComponent.MotionPixelCount = motionPixelCount;

                motionComponentsList.Add (motionComponent);
            }

            // When finished, convert it to array
            MotionComponent[] motionComponents = motionComponentsList.ToArray ();

            return motionComponents;
        }

        /// <summary>
        /// Get the motion image of an image
        /// </summary>
        /// <param name="motionMask">The updated motion mask</param>
        /// <param name="motionHistory">The motion history instance</param>
        /// <returns></returns>
        private Mat GetMotionImage (Mat motionMask, MotionHistory motionHistory)
        {
            double[] minValues, maxValues;
            Point[] minLoc, maxLoc;

            motionHistory.Mask.MinMax (out minValues, out maxValues, out minLoc, out maxLoc);
            using (ScalarArray sa = new ScalarArray (255.0 / maxValues[0]))
                CvInvoke.Multiply (motionHistory.Mask, sa, motionMask, 1, DepthType.Cv8U);

            // Create the motion image 
            Mat motionImage = new Mat (motionMask.Size.Height, motionMask.Size.Width, DepthType.Cv8U, 3);
            motionImage.SetTo (new MCvScalar (0));
            CvInvoke.InsertChannel (motionMask, motionImage, 0);

            return motionImage;
        }

        /// <summary>
        /// Draws a circle for the motion region. If there is an angle value, it draws the direction.
        /// </summary>
        /// <param name="frame">The frame to draw the motion circle and direction.</param>
        /// <param name="motionComponent">A motion component to draw motion.</param>
        /// <param name="color">The color of the circle and the direction.</param>
        private void DrawMotion (Mat frame, MotionComponent motionComponent, Bgr color)
        {
            float circleRadius = (motionComponent.MotionBoundingRectangle.Width + motionComponent.MotionBoundingRectangle.Height) >> 2;
            Point center = new Point (motionComponent.MotionBoundingRectangle.X + (motionComponent.MotionBoundingRectangle.Width >> 1),
                                      motionComponent.MotionBoundingRectangle.Y + (motionComponent.MotionBoundingRectangle.Height >> 1));

            CircleF circle = new CircleF (center, circleRadius);
            CvInvoke.Circle (frame, Point.Round (circle.Center), (int) circle.Radius, color.MCvScalar);

            // If angle is not a valid value, don't draw the direction line
            if (!double.IsNaN (motionComponent.MotionAngle)) {
                int xDirection = (int) (Math.Cos (motionComponent.MotionAngle * (Math.PI / 180.0)) * circleRadius);
                int yDirection = (int) (Math.Sin (motionComponent.MotionAngle * (Math.PI / 180.0)) * circleRadius);
                Point pointOnCircle = new Point (
                    center.X + xDirection,
                    center.Y - yDirection);
                LineSegment2D line = new LineSegment2D (center, pointOnCircle);
                CvInvoke.Line (frame, line.P1, line.P2, color.MCvScalar);
            }
        }

        /// <summary>
        /// Draw the graphics for motion detection.
        /// </summary>
        /// <remarks>
        /// * If there is a line specified, draw it blue. If there is a line crossing, draw it red.
        /// * Draw the rectangles of the motion zones with dark red.
        /// * Draw the motion components as circle with color red.
        /// </remarks>
        /// <param name="motionComponents">The motion components to be used in order to draw the graphics.</param>
        /// <param name="motionZones">The motion zones which is an array of rectangles.</param>
        /// <param name="frame">The frame to draw the motion detection graphics.</param>
        /// <param name="lineCrossing">A line indicating a line crossing. Default value is a zero length line.</param>
        private void MotionDetectionDrawGraphics (MotionComponent[] motionComponents, Rectangle[] motionZones,
                                                  Mat frame, LineSegment2D lineCrossing = new LineSegment2D ())
        {
            // If there is a line, draw it blue
            if (lineCrossing.Length > 0.0) {
                CvInvoke.Line (frame, lineCrossing.P1, lineCrossing.P2, new Bgr (Color.Blue).MCvScalar, 2);
            }

            // Draw all the motion zones
            foreach (Rectangle motionZone in motionZones) {
                CvInvoke.Rectangle (frame, motionZone, new Bgr (Color.DarkRed).MCvScalar);
            }

            // Iterate through each of the motion components
            foreach (MotionComponent comp in motionComponents) {
                // Draw each individual motion in red
                DrawMotion (frame, comp, new Bgr (Color.Red));

                // If there is a line, take it into account
                if (lineCrossing.Length > 0.0) {
                    int crossing = 0;
                    foreach (Point p in GetPointsLine (lineCrossing.P1, lineCrossing.P2, 200)) {
                        if (p.X >= comp.MotionBoundingRectangle.Left && p.X <= comp.MotionBoundingRectangle.Right &&
                            p.Y >= comp.MotionBoundingRectangle.Top && p.Y <= comp.MotionBoundingRectangle.Bottom) {
                            crossing++;
                            break;
                        }
                    }

                    if (crossing > 0) {
                        // If there is a line crossing, then draw the line with red and set an alarm
                        CvInvoke.Line (frame, lineCrossing.P1, lineCrossing.P2, new Bgr (Color.Red).MCvScalar, 2);
                    }
                }
            }
        }

        private Point[] GetPointsLine (Point p1, Point p2, int quantity)
        {
            var points = new Point[quantity];
            int ydiff = p2.Y - p1.Y, xdiff = p2.X - p1.X;
            double x, y, slope = (double) (p2.Y - p1.Y) / (p2.X - p1.X);

            quantity--;
            for (double i = 0; i < quantity; i++) {
                y = slope == 0 ? 0 : ydiff * (i / quantity);
                x = slope == 0 ? xdiff * (i / quantity) : y / slope;
                points[(int) i] = new Point ((int) Math.Round (x) + p1.X, (int) Math.Round (y) + p1.Y);
            }
            points[quantity] = p2;
            return points;
        }
        #endregion // PrivateFunctions
    }
}
