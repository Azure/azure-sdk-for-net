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
    public class AesKw128 : AesKw
    {
        public const string AlgorithmName = "A128KW";

        public AesKw128()
            : base( AlgorithmName )
        {
        }

        public override ICryptoTransform CreateDecryptor( byte[] key, byte[] iv = null )
        {
            if ( key == null )
                throw new ArgumentNullException( "key" );

            if ( key.Length << 3 != 128 )
                throw new ArgumentOutOfRangeException( "key", "key must be 128 bits long" );

            return base.CreateDecryptor( key, iv );
        }

        public override ICryptoTransform CreateEncryptor( byte[] key, byte[] iv = null )
        {
            if ( key == null )
                throw new ArgumentNullException( "key" );

            if ( key.Length << 3 != 128 )
                throw new ArgumentOutOfRangeException( "key", "key must be 128 bits long" );

            return base.CreateEncryptor( key, iv );
        }
    }
}
