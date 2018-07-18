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

        public override byte[] SignHash( AsymmetricAlgorithm key, byte[] digest )
        {
            var csp = key as RSACryptoServiceProvider;

            SafeNCryptProviderHandle hProvider;
            var errorCode = NativeMethods.NCryptOpenStorageProvider( out hProvider, "Microsoft Software Key Storage Provider", 0 );
            if ( errorCode != NativeMethods.Success )
                throw new CryptographicException( errorCode );

            var blob = NativeMethods.NewNCryptPrivateBlob( csp.ExportParameters( true ) );
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

        public override bool VerifyHash( AsymmetricAlgorithm key, byte[] digest, byte[] signature )
        {
            var csp = key as RSACryptoServiceProvider;

            SafeNCryptProviderHandle hProvider;
            var errorCode = NativeMethods.NCryptOpenStorageProvider( out hProvider, "Microsoft Software Key Storage Provider", 0 );
            if ( errorCode != NativeMethods.Success )
                throw new CryptographicException( errorCode );

            var blob = NativeMethods.NewNCryptPublicBlob( csp.ExportParameters( false ) );
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
