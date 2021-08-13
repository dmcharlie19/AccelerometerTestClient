using System;
using System.Windows.Forms;

namespace AccelVibroTestClient
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static int Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());

            return SystemParameters.RETURN_CODE_SUCCESS;
        }
    }
}
