using System;
using static System.Text.Encoding;
using Convert = System.Convert;

namespace Tsutsuji.Framework.Encoding
{
    public class Base64
    {
        private string text;
        public Base64(string textFormat)
        {
            text = textFormat;
        }

        // encode
        public string Encode()
        {
            text = Convert.ToBase64String(UTF8.GetBytes(text));
            return text;
        }

        public static string Encode(string textFormat)
        {
            return Convert.ToBase64String(UTF8.GetBytes(textFormat));
        }

        // decode
        public string Decode()
        {
            text = UTF8.GetString(Convert.FromBase64String(text));
            return text;
        }

        public static string Decode(string textFormat)
        {
            return UTF8.GetString(Convert.FromBase64String(textFormat));
        }
    }
}
