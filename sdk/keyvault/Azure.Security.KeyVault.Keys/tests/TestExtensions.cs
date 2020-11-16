// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Security.KeyVault.Keys.Tests
{
    public static class TestExtensions
    {
        /// <summary>
        /// Performs little-endian conversation of byte array <= 4 bytes.
        /// <see cref="BitConverter.ToInt32(byte[], int)"/> requires 4 bytes and will use big-endian conversation on some platforms.
        /// </summary>
        /// <param name="buffer">Byte array to convert.</param>
        /// <returns>The converted integer value.</returns>
        public static int ToInt32(this byte[] buffer)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException(nameof(buffer));
            }

            if (buffer.Length > 4)
            {
                throw new ArgumentOutOfRangeException(nameof(buffer));
            }

            int value = 0;
            for (int i = 0; i < buffer.Length; i++)
            {
                value |= buffer[i] << i * 8;
            }

            return value;
        }
    }
}
