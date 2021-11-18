using Serilog;
using System;
using System.Windows.Forms;

namespace MotionDetectionWithOpticalFlowWinFormsApp
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main ()
        {
            Log.Logger = new LoggerConfiguration ()
                .ReadFrom.AppSettings ()
                .CreateLogger ();

            Application.SetHighDpiMode (HighDpiMode.SystemAware);
            Application.EnableVisualStyles ();
            Application.SetCompatibleTextRenderingDefault (false);
            Application.Run (new Form1 ());
        }
    }
}
