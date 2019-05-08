// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using Microsoft.Win32.SafeHandles;

namespace Microsoft.Azure.KeyVault.Cryptography.Algorithms
{
    internal static class NativeMethods
    {
        internal const int Success = 0x00000000;                              // ERROR_SUCCESS
        internal const int BadSignature = unchecked( (int)0x80090006 );        // NTE_BAD_SIGNATURE
        internal const int InvalidParameter = unchecked( (int)0x80090027 );    // NTE_INVALID_PARAMETER

        internal const int BCRYPT_RSAPUBLIC_MAGIC      = 0x31415352;
        internal const int BCRYPT_RSAPRIVATE_MAGIC     = 0x32415352;
        internal const int BCRYPT_RSAFULLPRIVATE_MAGIC = 0x33415352;

        internal const int BCRYPT_ECDSA_PUBLIC_P256_MAGIC = 0x31534345;
        internal const int BCRYPT_ECDSA_PRIVATE_P256_MAGIC = 0x32534345;
        internal const int BCRYPT_ECDSA_PUBLIC_P384_MAGIC = 0x33534345;
        internal const int BCRYPT_ECDSA_PRIVATE_P384_MAGIC = 0x34534345;
        internal const int BCRYPT_ECDSA_PUBLIC_P521_MAGIC = 0x35534345;
        internal const int BCRYPT_ECDSA_PRIVATE_P521_MAGIC = 0x36534345;
        internal const int BCRYPT_ECDSA_PUBLIC_GENERIC_MAGIC = 0x50444345;
        internal const int BCRYPT_ECDSA_PRIVATE_GENERIC_MAGIC = 0x56444345;

        internal const string BCRYPT_ECCFULLPUBLIC_BLOB = "ECCFULLPUBLICBLOB";
        internal const string BCRYPT_ECCFULLPRIVATE_BLOB = "ECCFULLPRIVATEBLOB";
        internal const string BCRYPT_ECC_PARAMETERS = "ECCParameters";

        internal const int BCRYPT_ECC_PRIME_SHORT_WEIERSTRASS_CURVE = 0x1;
        internal const int BCRYPT_ECC_PRIME_TWISTED_EDWARDS_CURVE = 0x2;
        internal const int BCRYPT_ECC_PRIME_MONTGOMERY_CURVE = 0x3;

        internal const int BCRYPT_NO_CURVE_GENERATION_ALG_ID = 0x0;

        [StructLayout( LayoutKind.Sequential )]
        internal struct NCRYPT_PKCS1_PADDING_INFO
        {
            [MarshalAs( UnmanagedType.LPWStr )]
            public string pszAlgId;
        }

        /// <summary>
        ///     Padding modes 
        /// </summary>
        internal enum AsymmetricPaddingMode
        {
            None = 1,                       // BCRYPT_PAD_NONE
            Pkcs1 = 2,                      // BCRYPT_PAD_PKCS1
            Oaep = 4,                       // BCRYPT_PAD_OAEP
            Pss = 8                         // BCRYPT_PAD_PSS
        }

        [DllImport( "ncrypt.dll" )]
        internal static extern int NCryptOpenStorageProvider( [Out] out SafeNCryptProviderHandle phProvider,
                                                            [MarshalAs( UnmanagedType.LPWStr )] string pszProviderName,
                                                            int dwFlags );

        [DllImport( "ncrypt.dll" )]
        internal static extern int NCryptImportKey( SafeNCryptProviderHandle hProvider,
                                                            IntPtr hImportKey,
                                                            [MarshalAs( UnmanagedType.LPWStr )] string pszBlobType,
                                                            [In, MarshalAs( UnmanagedType.LPArray )] byte[] pParameterList,
                                                            out SafeNCryptKeyHandle phKey,
                                                            [In, MarshalAs( UnmanagedType.LPArray )] byte[] pbData,
                                                            int cbData,
                                                            int dwFlags );

        [DllImport( "ncrypt.dll" )]
        internal static extern int NCryptSignHash(
            SafeNCryptKeyHandle hKey,
            [In] ref NCRYPT_PKCS1_PADDING_INFO pPaddingInfo,
            [In, MarshalAs( UnmanagedType.LPArray )] byte[] pbHashValue,
            int cbHashValue,
            [In, MarshalAs( UnmanagedType.LPArray )] byte[] pbSignature,
            int cbSignature,
            [Out] out int pcbResult,
            AsymmetricPaddingMode dwFlags );

        [DllImport( "ncrypt.dll" )]
        internal static extern int NCryptVerifySignature( SafeNCryptKeyHandle hKey,
                                                               [In] ref NCRYPT_PKCS1_PADDING_INFO pPaddingInfo,
                                                               [In, MarshalAs( UnmanagedType.LPArray )] byte[] pbHashValue,
                                                               int cbHashValue,
                                                               [In, MarshalAs( UnmanagedType.LPArray )] byte[] pbSignature,
                                                               int cbSignature,
                                                               AsymmetricPaddingMode dwFlags );

        internal static byte[] NewNCryptPublicBlob( RSAParameters rsaParams )
        {
            // Builds a BCRYPT_RSAKEY_BLOB strucutre ( http://msdn.microsoft.com/en-us/library/windows/desktop/aa375531(v=vs.85).aspx ).
            var size = 6 * 4 + rsaParams.Exponent.Length + rsaParams.Modulus.Length;
            var data = new byte[size];
            var stream = new MemoryStream( data );
            var writer = new BinaryWriter( stream );
            writer.Write( (int)0x31415352 );
            writer.Write( (int)rsaParams.Modulus.Length * 8 );
            writer.Write( (int)rsaParams.Exponent.Length );
            writer.Write( (int)rsaParams.Modulus.Length );
            writer.Write( (int)0 );
            writer.Write( (int)0 );
            writer.Write( rsaParams.Exponent );
            writer.Write( rsaParams.Modulus );
            return data;
        }

        internal static byte[] NewNCryptPrivateBlob( RSAParameters rsaParams )
        {
            // Builds a BCRYPT_RSAKEY_BLOB strucutre ( http://msdn.microsoft.com/en-us/library/windows/desktop/aa375531(v=vs.85).aspx ).
            var size = 6 * 4 + rsaParams.Exponent.Length + rsaParams.Modulus.Length + rsaParams.P.Length + rsaParams.Q.Length;
            var data = new byte[size];
            var stream = new MemoryStream( data );
            var writer = new BinaryWriter( stream );
            writer.Write( BCRYPT_RSAPRIVATE_MAGIC );
            writer.Write( rsaParams.Modulus.Length * 8 ); // BitLength
            writer.Write( rsaParams.Exponent.Length ); // cbPublicExp
            writer.Write( rsaParams.Modulus.Length ); // cbModulus
            writer.Write( rsaParams.P.Length ); // cbPrime1
            writer.Write( rsaParams.Q.Length ); // cbPrime2
            writer.Write( rsaParams.Exponent );
            writer.Write( rsaParams.Modulus );
            writer.Write( rsaParams.P );
            writer.Write( rsaParams.Q );
            return data;
        }
    }
}
