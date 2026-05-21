// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Security.Cryptography;

namespace Azure.Storage.Blobs
{
    internal static class BlobHelpers
    {
        /// <summary>
        /// Generates a unique, randomly generated block ID as a Base64 string.
        /// Block ID must be a valid Base64 string with length &lt;= 64 characters.
        /// 48 raw bytes => 64 character Base64 string.
        /// </summary>
        public static string GenerateBlockId()
        {
            byte[] id = new byte[48];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(id);
            }
            return Convert.ToBase64String(id);
        }
    }
}
