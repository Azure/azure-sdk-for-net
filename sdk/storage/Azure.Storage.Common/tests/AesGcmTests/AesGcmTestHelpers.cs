// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Globalization;
using Azure.Storage.Test;

namespace Azure.Storage.Common.AesGcm.Tests
{
    internal static class AesGcmTestHelpers
    {
        internal static byte[] HexToByteArray(this string hexString)
        {
            byte[] bytes = new byte[hexString.Length / 2];

            for (int i = 0; i < hexString.Length; i += 2)
            {
                string s = hexString.Substring(i, 2);
                bytes[i / 2] = byte.Parse(s, NumberStyles.HexNumber, null);
            }

            return bytes;
        }

        public static byte[] GetRandomBuffer(long size) => TestHelper.GetRandomBuffer(size);
    }
}
