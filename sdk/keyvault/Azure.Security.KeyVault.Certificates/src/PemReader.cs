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
                    ?? throw new PlatformNotSupportedException("The current platform does not support reading an ECDsa private key from a PEM file");
            }

            // Create the certificate without the private key to pass to our PKCS8 decoder if needed to copy the prime curve.
            using X509Certificate2 certificateWithoutPrivateKey = new X509Certificate2(cer);

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
                    // Copy the prime curve from the public key to mitigate risk parsing the ASN.1 structure ourselves.
                    using ECDsa publicKey = certificateWithoutPrivateKey.GetECDsaPublicKey();
                    privateKey = LightweightPkcs8Decoder.DecodeECDsaPkcs8(key, publicKey);
                }

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
