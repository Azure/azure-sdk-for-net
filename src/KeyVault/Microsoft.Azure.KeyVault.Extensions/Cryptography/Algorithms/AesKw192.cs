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
    public class AesKw192 : AesKw
    {
        public const string AlgorithmName = "A192KW";

        const int KeySizeInBytes = 192 >> 3;

        public AesKw192()
            : base( AlgorithmName )
        {
        }

        public override ICryptoTransform CreateDecryptor( byte[] key, byte[] iv )
        {
            if ( key == null )
                throw new ArgumentNullException( "key" );

            if ( key.Length < KeySizeInBytes )
                throw new ArgumentOutOfRangeException( "key", "key must be at least 192 bits long" );

            return base.CreateDecryptor( AesKw.Take( KeySizeInBytes, key ), iv );
        }

        public override ICryptoTransform CreateEncryptor( byte[] key, byte[] iv )
        {
            if ( key == null )
                throw new ArgumentNullException( "key" );

            if ( key.Length < KeySizeInBytes )
                throw new ArgumentOutOfRangeException( "key", "key must be at least 192 bits long" );

            return base.CreateEncryptor( AesKw.Take( KeySizeInBytes, key ), iv );
        }
    }
}
