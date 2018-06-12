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
    public class Rs384 : RsaSignature
    {
        public const string AlgorithmName = "RS384";

        internal const string OID_OIWSEC_SHA256 = "2.16.840.1.101.3.4.2.1";
        internal const string OID_OIWSEC_SHA384 = "2.16.840.1.101.3.4.2.2";
        internal const string OID_OIWSEC_SHA512 = "2.16.840.1.101.3.4.2.3";

        internal const int SHA384_LENGTH = 48;
        public Rs384()
            : base( AlgorithmName )
        {
        }

        public override ISignatureTransform CreateSignatureTransform( AsymmetricAlgorithm key )
        {
            return new Rs384SignatureTransform( key );
        }

        class Rs384SignatureTransform : ISignatureTransform
        {
            private RSA _key;

            public Rs384SignatureTransform( AsymmetricAlgorithm key )
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

                if ( digest.Length != SHA384_LENGTH )
                    throw new ArgumentOutOfRangeException( "digest", String.Format("The digest must be {0} bytes for SHA-384", SHA384_LENGTH ));

#if NET45
                if ( _key is RSACryptoServiceProvider )
                {
                    return ((RSACryptoServiceProvider)_key).SignHash( digest, OID_OIWSEC_SHA384 );
                }

                throw new CryptographicException( string.Format( "{0} is not supported", _key.GetType().FullName ) );
#elif NETSTANDARD
                return _key.SignHash( digest, HashAlgorithmName.SHA384, RSASignaturePadding.Pkcs1 );
#else
                #error Unknown Framework
#endif
            }

            public bool Verify( byte[] digest, byte[] signature )
            {
                if ( digest == null || digest.Length == 0 )
                    throw new ArgumentNullException( "digest" );

                if ( digest.Length != SHA384_LENGTH)
                    throw new ArgumentOutOfRangeException( "digest", String.Format("The digest must be {0} bytes for SHA-384", SHA384_LENGTH ));

                if ( signature == null || signature.Length == 0 )
                    throw new ArgumentNullException( "signature" );


#if NET45
                if ( _key is RSACryptoServiceProvider )
                {
                    return ((RSACryptoServiceProvider)_key).VerifyHash( digest, OID_OIWSEC_SHA384, signature );
                }

                throw new CryptographicException( string.Format( "{0} is not supported", _key.GetType().FullName ) );
#elif NETSTANDARD
                return _key.VerifyHash( digest, signature, HashAlgorithmName.SHA384, RSASignaturePadding.Pkcs1 );
#else
                #error Unknown Framework
#endif
            }
        }
    }
}
