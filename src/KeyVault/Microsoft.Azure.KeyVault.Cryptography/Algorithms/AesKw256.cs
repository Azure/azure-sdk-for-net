// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Security.Cryptography;

namespace Microsoft.Azure.KeyVault.Cryptography.Algorithms
{
    public class AesKw256 : AesKw
    {
        public const string AlgorithmName = "A256KW";

        const int KeySizeInBytes = 256 >> 3;

        public AesKw256()
            : base( AlgorithmName )
        {
        }

        public override ICryptoTransform CreateDecryptor( byte[] key, byte[] iv )
        {
            if ( key == null )
                throw new ArgumentNullException( "key" );

            if ( key.Length < KeySizeInBytes )
                throw new ArgumentOutOfRangeException( "key", "key must be at least 256 bits long" );

            return base.CreateDecryptor( key.Take( KeySizeInBytes ), iv );
        }

        public override ICryptoTransform CreateEncryptor( byte[] key, byte[] iv )
        {
            if ( key == null )
                throw new ArgumentNullException( "key" );

            if ( key.Length < KeySizeInBytes )
                throw new ArgumentOutOfRangeException( "key", "key must be at least 256 bits long" );

            return base.CreateEncryptor( key.Take( KeySizeInBytes ), iv );
        }
    }
}
