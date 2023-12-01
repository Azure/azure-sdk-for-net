// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;

namespace Azure.Core
{
    internal static class Base64Url
    {
        /// <summary> Converts a Base64URL encoded string to a string.</summary>
        /// <param name="encoded">The Base64Url encoded string containing UTF8 bytes for a string.</param>
        /// <returns>The string represented by the Base64URL encoded string.</returns>
        public static byte[] Decode(string encoded)
        {
            encoded = new StringBuilder(encoded).Replace('-', '+').Replace('_', '/').Append('=', (encoded.Length % 4 == 0) ? 0 : 4 - (encoded.Length % 4)).ToString();

            return Convert.FromBase64String(encoded);
        }

        /// <summary>Encode a byte array as a Base64URL encoded string.</summary>
        /// <param name="bytes">Raw byte input buffer.</param>
        /// <returns>The bytes, encoded as a Base64URL string.</returns>
        public static string Encode(byte[] bytes)
        {
            return new StringBuilder(Convert.ToBase64String(bytes)).Replace('+', '-').Replace('/', '_').Replace("=", "").ToString();
        }

        /// <summary> Converts a Base64URL encoded string to a string.</summary>
        /// <param name="encoded">The Base64Url encoded string containing UTF8 bytes for a string.</param>
        /// <returns>The string represented by the Base64URL encoded string.</returns>
        internal static string DecodeString(string encoded)
        {
            return UTF8Encoding.UTF8.GetString(Decode(encoded));
        }

        /// <summary>Encode a string as a Base64URL encoded string.</summary>
        /// <param name="value">String input buffer.</param>
        /// <returns>The UTF8 bytes for the string, encoded as a Base64URL string.</returns>
        internal static string EncodeString(string value)
        {
            return Encode(UTF8Encoding.UTF8.GetBytes(value));
        }
    }
}
