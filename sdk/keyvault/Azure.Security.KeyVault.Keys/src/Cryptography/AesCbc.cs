// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Security.Cryptography;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    /// <summary>
    /// Copied from Microsoft.Azure.KeyVault.Cryptography for vanilla AESCBC as defined in https://tools.ietf.org/html/rfc3394
    /// </summary>
    internal class AesCbc
    {
        public const int BlockByteSize = 16;

        public static readonly AesCbc Aes128Cbc = new AesCbc("A128CBC", 128, PaddingMode.Zeros);
        public static readonly AesCbc Aes192Cbc = new AesCbc("A192CBC", 192, PaddingMode.Zeros);
        public static readonly AesCbc Aes256Cbc = new AesCbc("A256CBC", 256, PaddingMode.Zeros);
        public static readonly AesCbc Aes128CbcPad = new AesCbc("A128CBCPAD", 128, PaddingMode.PKCS7);
        public static readonly AesCbc Aes192CbcPad = new AesCbc("A192CBCPAD", 192, PaddingMode.PKCS7);
        public static readonly AesCbc Aes256CbcPad = new AesCbc("A256CBCPAD", 256, PaddingMode.PKCS7);

        private AesCbc(string name, int keySize, PaddingMode padding)
        {
            Name = name;
            KeySizeInBytes = keySize >> 3;
            Padding = padding;
        }

        public string Name { get; }

        public int KeySizeInBytes { get; }

        public PaddingMode Padding { get; }

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

        public ICryptoTransform CreateDecryptor( byte[] key, byte[] iv )
        {
            if ( key == null )
                throw new CryptographicException( "No key material" );

            if (key.Length < KeySizeInBytes)
                throw new CryptographicException("key", $"key must be at least {KeySizeInBytes << 3} bits");

            if ( iv == null )
                throw new CryptographicException( "No initialization vector" );

            // Create the AES provider
            using ( var aes = Create( key.Take(KeySizeInBytes), iv, Padding ) )
            {
                return aes.CreateDecryptor();
            }
        }

        public ICryptoTransform CreateEncryptor( byte[] key, byte[] iv )
        {
            if ( key == null )
                throw new CryptographicException( "No key material" );

            if (key.Length < KeySizeInBytes)
                throw new CryptographicException("key", $"key must be at least {KeySizeInBytes << 3} bits");

            if ( iv == null )
                throw new CryptographicException( "No initialization vector" );

            // Create the AES provider
            using ( var aes = Create( key.Take(KeySizeInBytes), iv, Padding ) )
            {
                return aes.CreateEncryptor();
            }
        }
    }
}
