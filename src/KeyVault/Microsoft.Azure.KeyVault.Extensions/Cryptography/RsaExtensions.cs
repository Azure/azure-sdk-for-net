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
    public static class RsaExtensions
    {
        /// <summary>
        /// Converts a RSA object to a JsonWebKey of type RSA.
        /// </summary>
        /// <param name="self">The RSA object to convert</param>
        /// <param name="includePrivateParameters">True to include the RSA private key parameters</param>
        /// <returns>A WebKey representing the RSA object</returns>
        public static JsonWebKey ToJsonWebKey( this RSA self, bool includePrivateParameters = false )
        {
            if ( self == null )
                throw new ArgumentNullException( "self" );

            return ToJsonWebKey( self.ExportParameters( includePrivateParameters ) );
        }

        /// <summary>
        /// Converts a RSAParameters object to a WebKey of type RSA.
        /// </summary>
        /// <param name="self">The RSA parameters object to convert</param>
        /// <returns>A WebKey representing the RSA object</returns>
        public static JsonWebKey ToJsonWebKey( this RSAParameters self )
        {
            return new JsonWebKey()
            {
                Kty = JsonWebKeyType.Rsa,

                E  = self.Exponent,
                N  = self.Modulus,

                D  = self.D,
                DP = self.DP,
                DQ = self.DQ,
                QI = self.InverseQ,
                P  = self.P,
                Q  = self.Q,
            };
        }
    }
}
