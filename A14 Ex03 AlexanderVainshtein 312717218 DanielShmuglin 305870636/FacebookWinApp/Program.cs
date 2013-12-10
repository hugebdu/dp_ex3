using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Ex2.FacebookApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new EntryForm());
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var exception = e.ExceptionObject as Exception;
            var message = exception != null ? exception.Message : null;
            MessageBox.Show(string.Format("Unhandled error occured: {0}", message));
        }
    }
}
