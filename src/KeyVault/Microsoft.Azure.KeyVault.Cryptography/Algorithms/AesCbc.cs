// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System.Security.Cryptography;

namespace Microsoft.Azure.KeyVault.Cryptography.Algorithms
{
    public abstract class AesCbc : SymmetricEncryptionAlgorithm
    {
        private static Aes Create( byte[] key, byte[] iv )
        {
            var aes = Aes.Create();

            aes.Mode    = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            aes.KeySize = key.Length * 8;
            aes.Key     = key;
            aes.IV      = iv;

            return aes;
        }

        protected AesCbc( string name )
            : base( name )
        {
        }

        public override ICryptoTransform CreateDecryptor( byte[] key, byte[] iv, byte[] authenticationData )
        {
            if ( key == null )
                throw new CryptographicException( "No key material" );

            if ( iv == null )
                throw new CryptographicException( "No initialization vector" );

            // Create the AES provider
            using ( var aes = Create( key, iv ) )
            {
                return aes.CreateDecryptor();
            }
        }

        public override ICryptoTransform CreateEncryptor( byte[] key, byte[] iv, byte[] authenticationData )
        {
            if ( key == null )
                throw new CryptographicException( "No key material" );

            if ( iv == null )
                throw new CryptographicException( "No initialization vector" );

            // Create the AES provider
            using ( var aes = Create(key, iv ) )
            {
                return aes.CreateEncryptor();
            }
        }
    }

    /// <summary>
    /// AESCBC 128bit key with PKCS7 Padding
    /// </summary>
    public class Aes128Cbc : AesCbc
    {
        public const string AlgorithmName  = "A128CBC";

        const int KeySizeInBytes = 128 >> 3;

        public Aes128Cbc()
            : base( AlgorithmName )
        {
        }

        public override ICryptoTransform CreateDecryptor( byte[] key, byte[] iv, byte[] authenticationData )
        {
            if ( key == null )
                throw new CryptographicException( "key" );

            if ( key.Length < KeySizeInBytes )
                throw new CryptographicException( "key", "key must be at least 128 bits" );

            return base.CreateDecryptor( key.Take( KeySizeInBytes ), iv, authenticationData );
        }

        public override ICryptoTransform CreateEncryptor( byte[] key, byte[] iv, byte[] authenticationData )
        {
            if ( key == null )
                throw new CryptographicException( "key" );

            if ( key.Length < KeySizeInBytes )
                throw new CryptographicException( "key", "key must be at least 128 bits long" );

            return base.CreateEncryptor( key.Take( KeySizeInBytes ), iv, authenticationData );
        }
    }

    /// <summary>
    /// AESCBC 192bit key with PKCS7 Padding
    /// </summary>
    public class Aes192Cbc : AesCbc
    {
        public const string AlgorithmName = "A192CBC";

        const int KeySizeInBytes = 192 >> 3;

        public Aes192Cbc()
            : base( AlgorithmName )
        {
        }

        public override ICryptoTransform CreateDecryptor( byte[] key, byte[] iv, byte[] authenticationData )
        {
            if ( key == null )
                throw new CryptographicException( "key" );

            if ( key.Length < KeySizeInBytes )
                throw new CryptographicException( "key", "key must be at least 192 bits" );

            return base.CreateDecryptor( key.Take( KeySizeInBytes ), iv, authenticationData );
        }

        public override ICryptoTransform CreateEncryptor( byte[] key, byte[] iv, byte[] authenticationData )
        {
            if ( key == null )
                throw new CryptographicException( "key" );

            if ( key.Length < KeySizeInBytes )
                throw new CryptographicException( "key", "key must be at least 192 bits long" );

            return base.CreateEncryptor( key.Take( KeySizeInBytes ), iv, authenticationData );
        }
    }

    /// <summary>
    /// AESCBC 256bit key with PKCS7 Padding
    /// </summary>
    public class Aes256Cbc : AesCbc
    {
        public const string AlgorithmName = "A256CBC";

        const int KeySizeInBytes = 256 >> 3;

        public Aes256Cbc()
            : base( AlgorithmName )
        {
        }

        public override ICryptoTransform CreateDecryptor( byte[] key, byte[] iv, byte[] authenticationData )
        {
            if ( key == null )
                throw new CryptographicException( "key" );

            if ( key.Length < KeySizeInBytes )
                throw new CryptographicException( "key", "key must be at least 256 bits" );

            return base.CreateDecryptor( key.Take( KeySizeInBytes ), iv, authenticationData );
        }

        public override ICryptoTransform CreateEncryptor( byte[] key, byte[] iv, byte[] authenticationData )
        {
            if ( key == null )
                throw new CryptographicException( "key" );

            if ( key.Length < KeySizeInBytes )
                throw new CryptographicException( "key", "key must be at least 256 bits long" );

            return base.CreateEncryptor( key.Take( KeySizeInBytes ), iv, authenticationData );
        }
    }
}
