//
// Copyright © Microsoft Corporation, All Rights Reserved
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS
// OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION
// ANY IMPLIED WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A
// PARTICULAR PURPOSE, MERCHANTABILITY OR NON-INFRINGEMENT.
//
// See the Apache License, Version 2.0 for the specific language
// governing permissions and limitations under the License.

using System;
using System.Security.Cryptography;

namespace Microsoft.Azure.KeyVault.Cryptography.Algorithms
{
    /// <summary>
    /// AESCBC with PKCS7 Padding
    /// </summary>
    public abstract class AesCbc : SymmetricEncryptionAlgorithm
    {
        protected static byte[] Take( int count, byte[] source )
        {
            if ( source.Length == count )
                return source;

            var target = new byte[count];

            Array.Copy( source, target, count );

            return target;
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
            using ( var aes = Aes.Create() )
            {
                aes.Mode    = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;
                aes.KeySize = key.Length * 8;
                aes.Key     = key;
                aes.IV      = iv;

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
            using ( var aes = Aes.Create() )
            {
                aes.Mode    = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;
                aes.KeySize = key.Length * 8;
                aes.Key     = key;
                aes.IV      = iv;

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

            return base.CreateDecryptor( AesCbc.Take( KeySizeInBytes, key ), iv, authenticationData );
        }

        public override ICryptoTransform CreateEncryptor( byte[] key, byte[] iv, byte[] authenticationData )
        {
            if ( key == null )
                throw new CryptographicException( "key" );

            if ( key.Length < KeySizeInBytes )
                throw new CryptographicException( "key", "key must be at least 128 bits long" );

            return base.CreateEncryptor( AesCbc.Take( KeySizeInBytes, key ), iv, authenticationData );
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

            return base.CreateDecryptor( AesCbc.Take( KeySizeInBytes, key ), iv, authenticationData );
        }

        public override ICryptoTransform CreateEncryptor( byte[] key, byte[] iv, byte[] authenticationData )
        {
            if ( key == null )
                throw new CryptographicException( "key" );

            if ( key.Length < KeySizeInBytes )
                throw new CryptographicException( "key", "key must be at least 192 bits long" );

            return base.CreateEncryptor( AesCbc.Take( KeySizeInBytes, key ), iv, authenticationData );
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

            return base.CreateDecryptor( AesCbc.Take( KeySizeInBytes, key ), iv, authenticationData );
        }

        public override ICryptoTransform CreateEncryptor( byte[] key, byte[] iv, byte[] authenticationData )
        {
            if ( key == null )
                throw new CryptographicException( "key" );

            if ( key.Length < KeySizeInBytes )
                throw new CryptographicException( "key", "key must be at least 256 bits long" );

            return base.CreateEncryptor( AesCbc.Take( KeySizeInBytes, key ), iv, authenticationData );
        }
    }
}
