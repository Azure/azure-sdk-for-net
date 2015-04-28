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
    public class Rs256 : AsymmetricSignatureAlgorithm
    {
        public const string AlgorithmName = "RS256";

        public Rs256()
            : base( AlgorithmName )
        {
        }

        public override byte[] SignHash( AsymmetricAlgorithm key, byte[] digest )
        {
            if ( key == null )
                throw new ArgumentNullException( "key" );

            if ( digest == null )
                throw new ArgumentNullException( "digest" );

            var rsa = key as RSACryptoServiceProvider;

            if ( rsa == null )
                throw new ArgumentException( "key must be an instance of RSACryptoServiceProvider", "key" );

            return rsa.SignHash( digest, CryptoConfig.MapNameToOID( "SHA256" ) );
        }


        public override bool VerifyHash( AsymmetricAlgorithm key, byte[] digest, byte[] signature )
        {
            if ( key == null )
                throw new ArgumentNullException( "key" );

            if ( digest == null )
                throw new ArgumentNullException( "digest" );

            var rsa = key as RSACryptoServiceProvider;

            if ( rsa == null )
                throw new ArgumentException( "key must be an instance of RSACryptoServiceProvider", "key" );

            return rsa.VerifyHash( digest, CryptoConfig.MapNameToOID( "SHA256" ), signature );
        }

    }
}
