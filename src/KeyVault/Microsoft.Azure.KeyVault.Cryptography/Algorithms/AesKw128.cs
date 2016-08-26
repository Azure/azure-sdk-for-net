// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Security.Cryptography;

namespace Microsoft.Azure.KeyVault.Cryptography.Algorithms
{
    public class AesKw128 : AesKw
    {
        public const string AlgorithmName = "A128KW";

        const int KeySizeInBytes = 128 >> 3;

        public AesKw128()
            : base( AlgorithmName )
        {
        }

        public override ICryptoTransform CreateDecryptor( byte[] key, byte[] iv )
        {
            if ( key == null )
                throw new ArgumentNullException( "key" );

            if ( key.Length < KeySizeInBytes )
                throw new ArgumentOutOfRangeException( "key", "key must be at least 128 bits" );

            return base.CreateDecryptor( key.Take( KeySizeInBytes ), iv );
        }

        public override ICryptoTransform CreateEncryptor( byte[] key, byte[] iv )
        {
            if ( key == null )
                throw new ArgumentNullException( "key" );

            if ( key.Length < KeySizeInBytes )
                throw new ArgumentOutOfRangeException( "key", "key must be at least 128 bits long" );

            return base.CreateEncryptor( key.Take( KeySizeInBytes ), iv );
        }
    }
}
