using System;
using System.Diagnostics;
using System.IO;
using Tsutsuji.Framework.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using Tsutsuji.Launcher.Screens;
using Tsutsuji.Framework.Encoding;

namespace Tsutsuji.Launcher
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "data"))) {
                Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "data"));
            }

            Configuration config = new Configuration(Path.Combine(Directory.GetCurrentDirectory(), @"data\program.hfcfg"), SetupBaseConfiguration());

            Application.Run(new Main());
        }

        static BaseConfiguration SetupBaseConfiguration()
        {
            Dictionary<string, List<KeyValuePair<string, dynamic>>> configValues = new Dictionary<string, List<KeyValuePair<string, dynamic>>>();

            configValues.Add("general", new List<KeyValuePair<string, dynamic>>());
            configValues.Add("core", new List<KeyValuePair<string, dynamic>>());
            configValues.Add("debug", new List<KeyValuePair<string, dynamic>>());

            // general config values
            //configValues["core"].Add(new KeyValuePair<string, dynamic>("_upwcombo", Base64.Encode("0:0")));

            return new BaseConfiguration(configValues);
        }
    }
}
