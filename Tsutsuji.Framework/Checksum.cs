using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Tsutsuji.Framework
{
    public class Checksum
    {
        private string checksum;
        public Checksum(string check)
        {
            checksum = check;
        }

        public static Checksum Get(string file)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(file))
                {
                    return new Checksum(BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "").ToLower());
                }
            }
        }

        public string Get()
        {
            return checksum;
        }

        public bool Compare(string check)
        {
            return check == checksum;
        }
        public bool Compare(Checksum check)
        {
            return check.Get() == checksum;
        }

        public static bool Compare(string check1, string check2)
        {
            return check1 == check2;
        }

        public static bool Compare(Checksum check1, Checksum check2)
        {
            return check1.Get() == check2.Get();
        }
    }
}
