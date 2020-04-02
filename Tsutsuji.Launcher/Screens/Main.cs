using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Tsutsuji.Framework.Encoding;
using Reloaded.Injector;

namespace Tsutsuji.Launcher.Screens
{
    public partial class Main : Form
    {
        [DllImport("user32.dll")]
        static extern IntPtr SetWindowText(IntPtr hWnd, string windowName);

        private Process gdProcess;
        private string[] loginDetails;
        private Injector injector;

        public Main()
        {
            InitializeComponent();

            if (File.Exists(Path.Combine(Directory.GetCurrentDirectory(), @"data\_upwcombo")))
            {
                loginDetails = this.CheckLogin();
                Debug.WriteLine(loginDetails[0]);
                this.Username.Text = "Hello, " + loginDetails[0] + "!";
            }
        }

        private void RunHyperflux_Click(object sender, EventArgs e)
        {
            Debug.WriteLine(Path.Combine(Directory.GetCurrentDirectory(), "Tsutsuji.Updater.exe"));
            Process updater = Process.Start(Path.Combine(Directory.GetCurrentDirectory(), "Tsutsuji.Updater.exe"), "--launcher");
            updater.EnableRaisingEvents = true;

            updater.Exited += (s, ev) =>
            {
                ProcessStartInfo _processStartInfo = new ProcessStartInfo(@"C:\Program Files (x86)\Steam\steamapps\common\Geometry Dash\_hyperflux\HyperfluxGMD.exe");
                _processStartInfo.WorkingDirectory = @"C:\Program Files (x86)\Steam\steamapps\common\Geometry Dash\_hyperflux";
                _processStartInfo.UseShellExecute = false;

                try
                {
                    Process gmd = Process.Start(_processStartInfo);

                    SpinWait.SpinUntil(() => gmd.MainWindowHandle != IntPtr.Zero);
                    SetWindowText(gmd.MainWindowHandle, "Hyperflux");

                    gdProcess = gmd;
                    //injector = new Injector(gdProcess);

                    // attempt injection
                    // disable injection for now
                    //injector.Inject(Path.Combine(Directory.GetCurrentDirectory(), @"libhyperflux.dll"));
                }
                catch (Win32Exception er)
                {
                    Debug.WriteLine(er.Message);
                }
            };
        }
        private string[] CheckLogin()
        {
            string[] res = { };

            using(StreamReader sr = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), @"data\_upwcombo")))
            {
                res = Base64.Decode(sr.ReadToEnd()).Split(':');
            }

            return res;
        }

        private void Injectbutton_Click(object sender, EventArgs e)
        {
            Debug.WriteLine(Path.Combine(Directory.GetCurrentDirectory(), "libhyperflux.dll"));
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            Login loginScreen = new Login();
            loginScreen.Show();

            loginScreen.FormClosed += (s, e2) =>
            {
                if (File.Exists(Path.Combine(Directory.GetCurrentDirectory(), @"data\_upwcombo")))
                {
                    loginDetails = this.CheckLogin();
                    this.Username.Text = "Hello, " + loginDetails[0];
                }
            };
        }
    }
}
