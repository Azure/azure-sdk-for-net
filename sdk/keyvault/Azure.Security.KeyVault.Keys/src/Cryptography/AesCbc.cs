// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Security.Cryptography;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    /// <summary>
    /// Copied from Microsoft.Azure.KeyVault.Cryptography for vanilla AESCBC as defined in https://tools.ietf.org/html/rfc3394
    /// </summary>
    internal abstract class AesCbc
    {
        private static Aes Create( byte[] key, byte[] iv, PaddingMode padding )
        {
            var aes = Aes.Create();

            aes.Mode    = CipherMode.CBC;
            aes.Padding = padding;
            aes.KeySize = key.Length * 8;
            aes.Key     = key;
            aes.IV      = iv;

            return aes;
        }

        public static ICryptoTransform CreateDecryptor( byte[] key, byte[] iv, PaddingMode padding )
        {
            if ( key == null )
                throw new CryptographicException( "No key material" );

            if ( iv == null )
                throw new CryptographicException( "No initialization vector" );

            // Note that authenticationData and authenticationTag are ignored.

            // Create the AES provider
            using ( var aes = Create( key, iv, padding ) )
            {
                return aes.CreateDecryptor();
            }
        }

        public static ICryptoTransform CreateEncryptor( byte[] key, byte[] iv, PaddingMode padding )
        {
            if ( key == null )
                throw new CryptographicException( "No key material" );

            if ( iv == null )
                throw new CryptographicException( "No initialization vector" );

            // Create the AES provider
            using ( var aes = Create(key, iv, padding ) )
            {
                return aes.CreateEncryptor();
            }
        }
    }
}
