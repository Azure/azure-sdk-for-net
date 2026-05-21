// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Security.Cryptography;

namespace Azure.Storage.Blobs
{
    internal static class BlobHelpers
    {
#if NETSTANDARD2_0
        private static readonly RandomNumberGenerator s_rng = RandomNumberGenerator.Create();
#endif

        /// <summary>
        /// Generates a unique, randomly generated block ID as a Base64 string.
        /// Block ID must be a valid Base64 string with length &lt;= 64 characters.
        /// 48 raw bytes => 64 character Base64 string.
        /// </summary>
        public static string GenerateBlockId()
        {
            byte[] id = new byte[48];
#if NETSTANDARD2_0
            lock (s_rng)
            {
                s_rng.GetBytes(id);
            }
#else
            RandomNumberGenerator.Fill(id);
#endif
            return Convert.ToBase64String(id);
        }
    }
}
