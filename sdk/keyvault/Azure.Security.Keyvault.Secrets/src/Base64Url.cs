using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Security.KeyVault.Secrets
{
    internal static class Base64Url
    {
        public static byte[] Decode(string str)
        {
            str = new StringBuilder(str).Replace('-', '+').Replace('_', '/').Append('=', (str.Length % 4 == 0) ? 0 : 4 - (str.Length % 4)).ToString();

            return Convert.FromBase64String(str);
        }

        public static string Encode(byte[] bytes)
        {
            return new StringBuilder(Convert.ToBase64String(bytes)).Replace('+', '-').Replace('/', '_').Replace("=", "").ToString();
        }

    }
}
