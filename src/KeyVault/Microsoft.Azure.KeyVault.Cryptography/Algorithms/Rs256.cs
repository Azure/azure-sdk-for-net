// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Security.Cryptography;

namespace Microsoft.Azure.KeyVault.Cryptography.Algorithms
{
    public class Rs256 : AsymmetricSignatureAlgorithm
    {
        public const string AlgorithmName = "RS256";

        internal const string OID_OIWSEC_SHA256 = "2.16.840.1.101.3.4.2.1";
        internal const string OID_OIWSEC_SHA384 = "2.16.840.1.101.3.4.2.2";
        internal const string OID_OIWSEC_SHA512 = "2.16.840.1.101.3.4.2.3";

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

            return rsa.SignHash( digest, OID_OIWSEC_SHA256 );
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

            return rsa.VerifyHash( digest, OID_OIWSEC_SHA256, signature );
        }

    }
}
