using System;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using Tsutsuji.Updater.Screens;

namespace Tsutsuji.Updater
{
    static class Program
    {
        public static string HyperfluxPath = @"C:\Program Files (x86)\Steam\steamapps\common\Geometry Dash\_hyperflux";
        public static string HyperfluxResourcesPath = HyperfluxPath + @"\Resources";
        public static string GeometryDashPath = @"C:\Program Files (x86)\Steam\steamapps\common\Geometry Dash";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length < 1 || args[0] != "--launcher")
            {
                DialogResult dialog = MessageBox.Show("You cannot properly run the updater executable by itself.", "Tsutsuji Launcher",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (dialog == DialogResult.OK)
                {
                    Application.Exit();
                    return;
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (!Directory.Exists(GeometryDashPath)) {
                DialogResult dialog = MessageBox.Show("You do not have Geometry Dash installed on this PC!", "Tsutsuji Launcher",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (dialog == DialogResult.OK)
                {
                    Application.Exit();
                    return;
                }
            }

            if (!Directory.Exists(HyperfluxPath))
            {
                // uwu
                Debug.WriteLine("sex");
                Directory.CreateDirectory(HyperfluxPath);
                Directory.CreateDirectory(HyperfluxResourcesPath);

                Application.Run(new Screens.Updater("first"));
                return;
            }

            try
            {
                Application.Run(new Screens.Updater("update"));
            } catch (ObjectDisposedException e)
            {
                return;
            }
        }
    }
}
