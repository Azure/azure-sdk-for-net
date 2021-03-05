// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Azure.Core
{
    /// <summary>
    /// Reads PEM streams to parse PEM fields or load certificates.
    /// </summary>
    internal static partial class PemReader
    {
        private static bool s_ecInitializedImportPkcs8PrivateKeyMethod;
        private static MethodInfo s_ecImportPkcs8PrivateKeyMethod;
        private static MethodInfo s_ecCopyWithPrivateKeyMethod;

        static partial void CreateECDsaCertificate(byte[] cer, byte[] key, ref X509Certificate2 certificate)
        {
            if (!s_ecInitializedImportPkcs8PrivateKeyMethod)
            {
                // ImportPkcs8PrivateKey was added in .NET Core 3.0 and is only present on Core. We will fall back to a lightweight decoder if this method is missing from the current runtime.
                s_ecImportPkcs8PrivateKeyMethod = typeof(ECDsa).GetMethod("ImportPkcs8PrivateKey", BindingFlags.Instance | BindingFlags.Public, null, new[] { typeof(ReadOnlySpan<byte>), typeof(int).MakeByRefType() }, null);
                s_ecInitializedImportPkcs8PrivateKeyMethod = true;
            }

            if (s_ecCopyWithPrivateKeyMethod is null)
            {
                s_ecCopyWithPrivateKeyMethod = typeof(ECDsaCertificateExtensions).GetMethod("CopyWithPrivateKey", BindingFlags.Static | BindingFlags.Public, null, new[] { typeof(X509Certificate2), typeof(ECDsa) }, null)
                    ?? throw new PlatformNotSupportedException("The current platform does not support reading a private key from a PEM file");
            }

            ECDsa privateKey = null;
            try
            {
                if (s_ecImportPkcs8PrivateKeyMethod != null)
                {
                    privateKey = ECDsa.Create();

                    // Because ImportECPrivateKeyMethod declares an out parameter we cannot call it directly using MethodInfo.Invoke since all arguments are passed as an object array.
                    // Instead we create a delegate with the correct signature and invoke it.
                    ImportPrivateKeyDelegate importECPrivateKey = (ImportPrivateKeyDelegate)s_ecImportPkcs8PrivateKeyMethod.CreateDelegate(typeof(ImportPrivateKeyDelegate), privateKey);
                    importECPrivateKey.Invoke(key, out int bytesRead);

                    if (key.Length != bytesRead)
                    {
                        throw new InvalidDataException("Invalid PKCS#8 Data");
                    }
                }
                else
                {
                    privateKey = LightweightPkcs8Decoder.DecodeECDsaPkcs8(key);
                }

                using X509Certificate2 certificateWithoutPrivateKey = new X509Certificate2(cer);

                // TODO: This will fail for P-256K because the certificate uses OID 1.2.840.10045.1.1 while the private key was modified to use OID 1.3.132.0.10.
                certificate = (X509Certificate2)s_ecCopyWithPrivateKeyMethod.Invoke(null, new object[] { certificateWithoutPrivateKey, privateKey });

                // Make sure the private key doesn't get disposed now that it's used.
                privateKey = null;
            }
            finally
            {
                // If we created and did not use the RSA private key, make sure it's disposed.
                privateKey?.Dispose();
            }
        }
    }
}
