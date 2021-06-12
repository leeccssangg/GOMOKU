using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CO_CARO_2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /* ConnectServer connect = new ConnectServer();
             ConnectServer.StartClient();*/

            /*SampleForm1 sampleForm1 = new SampleForm1();
            sampleForm1.StartToConnect();*/

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new fmCoCaro());
        }
    }
}
