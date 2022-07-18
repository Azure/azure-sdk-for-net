// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Security.Cryptography;

namespace Azure.Storage.Cryptography
{
    internal class ClientSideEncryptionValueGenerator
    {
        /// <summary>
        /// Securely generate a key.
        /// </summary>
        /// <param name="numBits">Key size.</param>
        /// <returns>The generated key bytes.</returns>
        public static byte[] CreateKey(int numBits)
        {
            using (var secureRng = new RNGCryptoServiceProvider())
            {
                var buff = new byte[numBits / 8];
                secureRng.GetBytes(buff);
                return buff;
            }
        }

        public static AesCryptoServiceProvider GetAesProvider(byte[] contentEncryptionKey)
        {
            return new AesCryptoServiceProvider()
            {
                Key = contentEncryptionKey
            };
        }
    }
}
