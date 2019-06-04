//
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

using System;
using System.Security.Cryptography;

namespace Microsoft.Azure.KeyVault.Cryptography.Algorithms
{
    /// <summary>
    /// RSA SHA-256 Signature algorithim.
    /// </summary>
    public class Rs256 : RsaSignature
    {
        public const string AlgorithmName = "RS256";

        internal const string OID_OIWSEC_SHA256 = "2.16.840.1.101.3.4.2.1";
        internal const string OID_OIWSEC_SHA384 = "2.16.840.1.101.3.4.2.2";
        internal const string OID_OIWSEC_SHA512 = "2.16.840.1.101.3.4.2.3";

        public Rs256()
            : base( AlgorithmName )
        {
        }

        public override ISignatureTransform CreateSignatureTransform( AsymmetricAlgorithm key )
        {
            return new Rs256SignatureTransform( key );
        }

        class Rs256SignatureTransform : ISignatureTransform
        {
            private RSA _key;

            public Rs256SignatureTransform( AsymmetricAlgorithm key )
            {
                if ( key == null )
                    throw new ArgumentNullException( "key" );

                if ( !( key is RSA ) )
                    throw new ArgumentException( string.Format( "key must be of type {0}", typeof( RSA ).AssemblyQualifiedName ), "key" );

                _key = key as RSA;
            }

            public byte[] Sign( byte[] digest )
            {
                if ( digest == null || digest.Length == 0 )
                    throw new ArgumentNullException( "digest" );

                if ( digest.Length != 32 )
                    throw new ArgumentOutOfRangeException( "digest", "The digest must be 32 bytes for SHA-256" );

#if FullNetFx
                if ( _key is RSACryptoServiceProvider )
                {
                    return ((RSACryptoServiceProvider)_key).SignHash( digest, OID_OIWSEC_SHA256 );
                }

                throw new CryptographicException( string.Format( "{0} is not supported", _key.GetType().FullName ) );
#elif NETSTANDARD
                return _key.SignHash( digest, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1 );
#else
                #error Unknown Framework
#endif
            }

            public bool Verify( byte[] digest, byte[] signature )
            {
                if ( digest == null || digest.Length == 0 )
                    throw new ArgumentNullException( "digest" );

                if ( digest.Length != 32 )
                    throw new ArgumentOutOfRangeException( "digest", "The digest must be 32 bytes for SHA-256" );

                if ( signature == null || signature.Length == 0 )
                    throw new ArgumentNullException( "signature" );


#if FullNetFx
                if ( _key is RSACryptoServiceProvider )
                {
                    return ((RSACryptoServiceProvider)_key).VerifyHash( digest, OID_OIWSEC_SHA256, signature );
                }

                throw new CryptographicException( string.Format( "{0} is not supported", _key.GetType().FullName ) );
#elif NETSTANDARD
                return _key.VerifyHash( digest, signature, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1 );
#else
                #error Unknown Framework
#endif
            }
        }
    }
}
