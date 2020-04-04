using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Tsutsuji.Framework.IO
{
    public class Steam
    {
        public static string InstallDir()
        {
            string value = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Valve\Steam", "InstallPath", null);
            string value64 = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Valve\Steam", "InstallPath", null);
            
            if (value != null)
            {
                return value;
            } else if (value64 != null)
            {
                return value64;
            }

            return null;
        }

        public static string AppDir(int gameId)
        {
            string appDir = null;
            Regex appRegex = new Regex("\"installdir\".{0,}\"(.{0,})\"");
            using (StreamReader sr = new StreamReader(Path.Combine(Steam.InstallDir(), @"steamapps\appmanifest_" + gameId + ".acf")))
            {
                string text = sr.ReadToEnd();
                foreach (Match match in appRegex.Matches(text))
                {
                    CaptureCollection captures = match.Captures;
                    GroupCollection groups = match.Groups;

                    appDir = groups[1].Value;
                }
            }

            return (appDir != null) ? Path.Combine(Steam.InstallDir(), @"steamapps\common\" + appDir) : null;
        }
    }
}
