using System;
using System.IO;

namespace Tsutsuji.Framework.Extensions
{
    public class DirectoryExtensions
    {
        public static long GetDirectorySize(string path)
        {
            string[] files = Directory.GetFiles(path, "*");

            long res = 0;
            foreach (string file in files)
            {
                FileInfo info = new FileInfo(file);
                res += info.Length;
            }

            return res;
        }
    }
}
