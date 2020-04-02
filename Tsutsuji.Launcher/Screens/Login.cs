using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows.Forms;
using System.Diagnostics;
using Tsutsuji.Framework.IO;
using System.IO;
using Tsutsuji.Framework.Encoding;

namespace Tsutsuji.Launcher.Screens
{
    public partial class Login : Form
    {
        private Configuration config = new Configuration(Path.Combine(Directory.GetCurrentDirectory(), @"data\program.hfcfg"));
        public Login()
        {
            InitializeComponent();
        }

        private async void LoginButton_Click(object sender, EventArgs e)
        {
            using (HttpClient webClient = new HttpClient())
            {
                webClient.BaseAddress = new Uri("http://gd.hyperflux.moe/");
                var request = new HttpRequestMessage(HttpMethod.Post, "/database/accounts/loginGJAccount.php");

                var values = new List<KeyValuePair<string, string>>();

                values.Add(new KeyValuePair<string, string>("userName", UsernameBox.Text));
                values.Add(new KeyValuePair<string, string>("password", PasswordBox.Text));

                request.Content = new FormUrlEncodedContent(values);
                
                using (HttpResponseMessage response = await webClient.SendAsync(request))
                {
                    using (StreamReader reader = new StreamReader(await response.Content.ReadAsStreamAsync())) {
                        switch (reader.ReadToEnd())
                        {
                            case "-12":
                                MessageBox.Show("The password provided to login with the account \"" + UsernameBox.Text + "\" is incorrect. Please try again.", "Hyperflux Login",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            case "-1":
                                MessageBox.Show("The account provided does not exist! If this issue occurs repeatedly, please contact a developer.", "Hyperflux Login",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            default:

                                using (StreamWriter sr = new StreamWriter(File.Create(Path.Combine(Directory.GetCurrentDirectory(), @"data\_upwcombo"))))
                                {
                                    sr.Write(Base64.Encode(UsernameBox.Text + ":" + PasswordBox.Text));
                                    sr.Close();
                                }

                                this.Close();
                                break;
                        }
                    }
                }
            }
        }
    }
}
