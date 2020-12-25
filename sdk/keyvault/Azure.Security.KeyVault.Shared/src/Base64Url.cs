// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;

namespace Azure.Security.KeyVault
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
