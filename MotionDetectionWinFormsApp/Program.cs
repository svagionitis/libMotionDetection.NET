using Serilog;
using System;
using System.Windows.Forms;

namespace MotionDetectionWinFormsApp
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

            Application.EnableVisualStyles ();
            Application.SetCompatibleTextRenderingDefault (false);
            Application.Run (new Form1 ());
        }
    }
}
