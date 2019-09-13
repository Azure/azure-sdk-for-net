// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;

namespace Azure.Identity
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


        public static string HexToBase64Url(string hex)
        {
            byte[] bytes = new byte[hex.Length / 2];

            for (int i = 0; i < hex.Length; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);

            return Base64Url.Encode(bytes);
        }
    }
}
