// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal static class HashHelper
    {
        internal static string GetSHA256Hash(string input)
        {
            byte[] inputBits = Encoding.Unicode.GetBytes(input);

            var hashString = new StringBuilder();
            using (var sha256 = SHA256.Create())
            {
                byte[] hashBits = sha256.ComputeHash(inputBits);
                foreach (byte b in hashBits)
                {
                    hashString.Append(b.ToString("x2", CultureInfo.InvariantCulture));
                }
            }
            return hashString.ToString();
        }
    }
}
