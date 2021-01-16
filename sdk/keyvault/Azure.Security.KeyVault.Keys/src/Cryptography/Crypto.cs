// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Security.Cryptography;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    /// <summary>
    /// Cryptography utilities.
    /// </summary>
    internal static class Crypto
    {
        private static readonly RandomNumberGenerator s_rng = RandomNumberGenerator.Create();

        /// <summary>
        /// Generates a cryptographically random initialization vector of the given size in bytes.
        /// </summary>
        /// <param name="byteSize">The size of the initialization vector in bytes.</param>
        /// <returns>An initialization vector of the given size in bytes.</returns>
        public static byte[] GenerateIv(int byteSize)
        {
            Debug.Assert(byteSize > 0, "requested IV size invalid");

            byte[] iv = new byte[byteSize];
            s_rng.GetBytes(iv);

            return iv;
        }
    }
}
