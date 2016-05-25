using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CirclePOS
{
    static class Program
    {
        public static Model.ClientSetup theClientSetup;
        public static Model.Database theDatabase;
        public static System.Windows.Forms.Cursor preferredCursor;

        public static Renderer.Renderer currentRenderer;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new UI.IntroForm());
            doInit();
            Application.Run(new UI.MainForm());
        }

        public static void doInit()
        {
            theClientSetup = Model.ClientSetup.loadFromFile();
            theDatabase = Model.Database.loadFromDisk();
        }
    }
}
