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

using System.Security.Cryptography;

namespace Microsoft.Azure.KeyVault.Cryptography.Algorithms
{
    /// <summary>
    /// AESCBC with PKCS7 Padding
    /// </summary>
    public abstract class AesCbc : SymmetricEncryptionAlgorithm
    {
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
                aes.KeySize = key.Length*8;
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
        public const string AlgorithmName = "A128CBC";

        public Aes128Cbc()
            : base( AlgorithmName )
        {
        }

    }

    /// <summary>
    /// AESCBC 192bit key with PKCS7 Padding
    /// </summary>
    public class Aes192Cbc : AesCbc
    {
        public const string AlgorithmName = "A192CBC";

        public Aes192Cbc()
            : base( AlgorithmName )
        {
        }

    }

    /// <summary>
    /// AESCBC 256bit key with PKCS7 Padding
    /// </summary>
    public class Aes256Cbc : AesCbc
    {
        public const string AlgorithmName = "A256CBC";

        public Aes256Cbc()
            : base( AlgorithmName )
        {
        }

    }
}
