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
using Microsoft.Azure.KeyVault.WebKey;

namespace Microsoft.Azure.KeyVault.Cryptography
{
    public static class AesExtensions
    {
        /// <summary>
        /// Converts an AES object to a JsonWebKey of type Octet
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static JsonWebKey ToJsonWebKey( this Aes self )
        {
            if ( self == null )
                throw new ArgumentNullException( "self" );

            return new JsonWebKey()
            {
                Kty = JsonWebKeyType.Octet,
                K   = self.Key,
            };
        }
    }
}
