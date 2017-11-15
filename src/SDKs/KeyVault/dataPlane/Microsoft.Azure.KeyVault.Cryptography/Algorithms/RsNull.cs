//
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

#if FullNetFx

using System;
using System.Security.Cryptography;
using Microsoft.Win32.SafeHandles;

namespace Microsoft.Azure.KeyVault.Cryptography.Algorithms
{
    public class RsNull : AsymmetricSignatureAlgorithm
    {
        public const string AlgorithmName = "RSNULL";

        public RsNull()
            : base( AlgorithmName )
        {
        }

        public override ISignatureTransform CreateSignatureTransform( AsymmetricAlgorithm key )
        {
            return new RsNullSignatureTransform( key );
        }

        internal class RsNullSignatureTransform : ISignatureTransform
        {
            private RSACryptoServiceProvider _key;

            public RsNullSignatureTransform( AsymmetricAlgorithm key )
            {
                if ( key == null )
                    throw new ArgumentNullException( "key" );

                if ( !( key is RSACryptoServiceProvider ) )
                    throw new ArgumentException( string.Format( "key must be of type {0}", typeof( RSACryptoServiceProvider ).AssemblyQualifiedName ), "key" );

                _key = key as RSACryptoServiceProvider;
            }

            public byte[] Sign( byte[] digest )
            {
                SafeNCryptProviderHandle hProvider;
                var errorCode = NativeMethods.NCryptOpenStorageProvider( out hProvider, "Microsoft Software Key Storage Provider", 0 );
                if ( errorCode != NativeMethods.Success )
                    throw new CryptographicException( errorCode );

                var blob = NativeMethods.NewNCryptPrivateBlob( _key.ExportParameters( true ) );
                SafeNCryptKeyHandle hKey;
                errorCode = NativeMethods.NCryptImportKey( hProvider, IntPtr.Zero, "RSAPRIVATEBLOB", null, out hKey, blob, blob.Length, 0 );
                if ( errorCode != NativeMethods.Success )
                    throw new CryptographicException( errorCode );

                var pkcs1Info = new NativeMethods.NCRYPT_PKCS1_PADDING_INFO { pszAlgId = null };

                int cbResult;
                errorCode = NativeMethods.NCryptSignHash( hKey, ref pkcs1Info, digest, digest.Length, null, 0, out cbResult, NativeMethods.AsymmetricPaddingMode.Pkcs1 );
                if ( errorCode != NativeMethods.Success )
                    throw new CryptographicException( errorCode );

                var signature = new byte[cbResult];
                errorCode = NativeMethods.NCryptSignHash( hKey, ref pkcs1Info, digest, digest.Length, signature, signature.Length, out cbResult, NativeMethods.AsymmetricPaddingMode.Pkcs1 );
                if ( errorCode != NativeMethods.Success )
                    throw new CryptographicException( errorCode );

                if ( cbResult != signature.Length )
                {
                    var temp = new byte[cbResult];
                    Array.Copy( signature, temp, cbResult );
                    signature = temp;
                }

                return signature;
            }

            public bool Verify( byte[] digest, byte[] signature )
            {
                SafeNCryptProviderHandle hProvider;
                var errorCode = NativeMethods.NCryptOpenStorageProvider( out hProvider, "Microsoft Software Key Storage Provider", 0 );
                if ( errorCode != NativeMethods.Success )
                    throw new CryptographicException( errorCode );

                var blob = NativeMethods.NewNCryptPublicBlob( _key.ExportParameters( false ) );
                SafeNCryptKeyHandle hKey;
                errorCode = NativeMethods.NCryptImportKey( hProvider, IntPtr.Zero, "RSAPUBLICBLOB", null, out hKey, blob, blob.Length, 0 );
                if ( errorCode != NativeMethods.Success )
                    throw new CryptographicException( errorCode );

                var pkcs1Info = new NativeMethods.NCRYPT_PKCS1_PADDING_INFO { pszAlgId = null };

                errorCode = NativeMethods.NCryptVerifySignature( hKey, ref pkcs1Info, digest, digest.Length, signature, signature.Length, NativeMethods.AsymmetricPaddingMode.Pkcs1 );
                if ( errorCode != NativeMethods.Success && errorCode != NativeMethods.BadSignature && errorCode != NativeMethods.InvalidParameter )
                    throw new CryptographicException( errorCode );

                return ( errorCode == NativeMethods.Success );
            }
        }
    }
}

#endif