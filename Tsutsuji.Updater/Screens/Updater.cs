﻿using System;
using System.IO;
using System.Windows.Forms;
using System.Net;
using System.Diagnostics;
using System.Text;
using Newtonsoft.Json.Linq;
using Tsutsuji.Framework;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using Tsutsuji.Framework.IO;

namespace Tsutsuji.Updater.Screens
{
    public partial class Updater : Form
    {
        private Queue<string> _items = new Queue<string>();
        private static string hyperfluxPath = Path.Combine(Steam.AppDir(322170), "_hyperflux");
        private static readonly string[] necessaryFiles =
        {
            "fmod.dll",
            "glew32.dll",
            "iconv.dll",
            "libcocos2d.dll",
            "libcurl.dll",
            "libExtensions.dll",
            "libtiff.dll",
            "pthreadVCE2.dll",
            "sdkencryptedappticket.dll",
            "sqlite3.dll",
            "websockets.dll",
            "zlib1.dll"
        };

        private static readonly string[] hyperfluxGmd = {
            "HyperfluxGMD.exe",
            "steam_api.dll",
            "Resources/GJ_GameSheet-uhd.png"
        };

        public Updater(string type)
        {
            InitializeComponent();

            if (type == "first")
            {
                Show();
                firstUpdate();
            }
            else if (type == "update")
            {
                Show();
                RunUpdate();
            }
        }

        private void firstUpdate()
        {
            var current = 0;

            var files = Directory.GetFiles(Program.GeometryDashPath + @"\Resources");

            SizeText.Text = @"0 of " + (necessaryFiles.Length + files.Length) + @" files";

            foreach (string file in files)
            {
                var fileName = Path.GetFileName(file);
                var destFile = Path.Combine(Program.HyperfluxResourcesPath, fileName);

                File.Copy(file, destFile, true);

                UpdateContents(fileName);
            }

            foreach (var filename in necessaryFiles)
            {
                var file = Path.Combine(Steam.AppDir(322170), filename);
                var fileName = Path.GetFileName(file);

                var destFile = Path.Combine(Program.HyperfluxPath, fileName);

                File.Copy(file, destFile, true);

                UpdateContents(fileName);
            }
            
            // mine
            void ResetContents()
            {
                FileName.Text = @"Downloading: ???";
                ProgressBar.Value = 0;

                SizeText.Update();
                FileName.Update();
            }

            void UpdateContents(string fileName)
            {
                current++;

                var progress = (int)((float)current / (necessaryFiles.Length + files.Length) * 100);

                FileName.Text = @"Copying: " + fileName;

                SizeText.Text = current + @" of " + (necessaryFiles.Length + files.Length) + @" files";
                ProgressBar.Value = progress;

                SizeText.Update();
                FileName.Update();

                if (progress == 100)
                {
                    ResetContents();
                    RunUpdate();
                }
            }
        }

        private void RunUpdate()
        {
            int current = 0;
            var request = WebRequest.Create(@"https://api.hyperflux.moe/rel/checksum");
            request.ContentType = "application/json; charset=utf-8";
            request.Headers.Add("hyperflux-auth", "Hyperflux Launcher" + Program.version);

            using (var response = request.GetResponse())
            {
                using (StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    JObject obj = JObject.Parse(sr.ReadToEnd());
                    Debug.WriteLine(obj["code"].ToString());

                    if (obj["code"].ToString() == "-1")
                    {
                        DialogResult dialog = MessageBox.Show("This version of the launcher is out of date! Head to GitHub to get a newer version.", "Tsutsuji Launcher",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                        if (dialog == DialogResult.OK)
                        {
                            Application.Exit();
                            return;
                        }
                    }

                    Checksum[] checksums =
                    {
                        new Checksum(obj["checksums"]["HyperfluxGMD.exe"].ToString()),
                        new Checksum(obj["checksums"]["steam_api.dll"].ToString()),
                        new Checksum(obj["checksums"]["Resources/GJ_GameSheet-uhd.png"].ToString())
                    };

                    foreach (Checksum checksum in checksums)
                    {
                        string fileName = hyperfluxGmd[current];
                        if (File.Exists(Path.Combine(hyperfluxPath, fileName)))
                        {
                            Checksum newChecksum = checksum;
                            Checksum oldChecksum = Checksum.Get(Path.Combine(hyperfluxPath, fileName));

                            if (newChecksum.Compare(oldChecksum) == true)
                            {
                                UpdateContents(fileName);
                            } else
                            {
                                UpdateContents(fileName);
                                _items.Enqueue(fileName);
                            }
                        } else
                        {
                            UpdateContents(fileName);
                            _items.Enqueue(fileName);
                        }

                        current++;
                    }

                    DownloadFile();
                }
            }

            void DownloadFile()
            {
                if (_items.Any())
                {
                    WebClient webClient = new WebClient();

                    webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Complete);
                    webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChange);

                    var file = _items.Dequeue();
                    UpdateContents(file);
                    webClient.DownloadFileAsync(new Uri(@"https://api.hyperflux.moe/rel/file?f=" + file), Path.Combine(hyperfluxPath, file));
                    return;
                }

                this.Dispose();
                this.Close();
            }

            void ProgressChange(object sender, DownloadProgressChangedEventArgs e)
            {
                ProgressBar.Value = e.ProgressPercentage;
            }

            void Complete(object sender, AsyncCompletedEventArgs e)
            {
                ProgressBar.Value = 0;
                current++;
                DownloadFile();
            }

            void UpdateContents(string fileName)
            {
                FileName.Text = @"Downloading: " + fileName;
                SizeText.Text = current -1 + " of " + hyperfluxGmd.Length + " files";

                SizeText.Update();
                FileName.Update();
            }
        }
    }
}