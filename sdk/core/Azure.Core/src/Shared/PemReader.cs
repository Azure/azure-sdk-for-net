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
    /// <remarks>
    /// This class provides a downlevel PEM decoder since <c>PemEncoding</c> wasn't added until net5.0.
    /// The <c>PemEncoding</c> class takes advantage of other implementation changes in net5.0 and,
    /// based on conversations with the .NET team, runtime changes.
    /// </remarks>
    internal static partial class PemReader
    {
        // The following implementation was based on PemEncoding and reviewed by @bartonjs on the .NET / cryptography team.
        private delegate void ImportPrivateKeyDelegate(ReadOnlySpan<byte> blob, out int bytesRead);

        private const string Prolog = "-----BEGIN ";
        private const string Epilog = "-----END ";
        private const string LabelEnd = "-----";

        private const string RSAAlgorithmId = "1.2.840.113549.1.1.1";
        private const string ECDsaAlgorithmId = "1.2.840.10045.2.1";

        private static bool s_rsaInitializedImportPkcs8PrivateKeyMethod;
        private static MethodInfo s_rsaImportPkcs8PrivateKeyMethod;
        private static MethodInfo s_rsaCopyWithPrivateKeyMethod;

        /// <summary>
        /// Loads an <see cref="X509Certificate2"/> from PEM data.
        /// </summary>
        /// <param name="data">The PEM data to parse.</param>
        /// <param name="cer">Optional public certificate data if not defined within the PEM data.</param>
        /// <param name="keyType">
        /// Optional <see cref="KeyType"/> of the certificate private key. The default is <see cref="KeyType.Auto"/> to automatically detect.
        /// Only support for <see cref="KeyType.RSA"/> is implemented by shared code.
        /// </param>
        /// <param name="allowCertificateOnly">Whether to create an <see cref="X509Certificate2"/> if no private key is read.</param>
        /// <param name="keyStorageFlags">A combination of the enumeration values that control where and how to import the certificate.</param>
        /// <returns>An <see cref="X509Certificate2"/> loaded from the PEM data.</returns>
        /// <exception cref="CryptographicException">A cryptographic exception occurred when trying to create the <see cref="X509Certificate2"/>.</exception>
        /// <exception cref="InvalidDataException"><paramref name="cer"/> is null and no CERTIFICATE field is defined in PEM, or no PRIVATE KEY is defined in PEM.</exception>
        /// <exception cref="NotSupportedException">The <paramref name="keyType"/> is not supported.</exception>
        /// <exception cref="PlatformNotSupportedException">Creating a <see cref="X509Certificate2"/> from PEM data is not supported on the current platform.</exception>
        public static X509Certificate2 LoadCertificate(ReadOnlySpan<char> data, byte[] cer = null, KeyType keyType = KeyType.Auto, bool allowCertificateOnly = false, X509KeyStorageFlags keyStorageFlags = X509KeyStorageFlags.DefaultKeySet)
        {
            byte[] priv = null;

            while (TryRead(data, out PemField field))
            {
                // TODO: Consider building up a chain to determine the leaf certificate: https://github.com/Azure/azure-sdk-for-net/issues/19043
                if (field.Label.Equals("CERTIFICATE".AsSpan(), StringComparison.Ordinal))
                {
                    cer = field.FromBase64Data();
                }
                else if (field.Label.Equals("PRIVATE KEY".AsSpan(), StringComparison.Ordinal))
                {
                    priv = field.FromBase64Data();
                }

                int offset = field.Start + field.Length;
                if (offset >= data.Length)
                {
                    break;
                }

                data = data.Slice(offset);
            }

            if (cer is null)
            {
                throw new InvalidDataException("The certificate is missing the public key");
            }

            if (priv is null)
            {
                if (allowCertificateOnly)
                {
#if NET9_0_OR_GREATER
                    switch (X509Certificate2.GetCertContentType(cer))
                    {
                        case X509ContentType.Pkcs12:
                            return X509CertificateLoader.LoadPkcs12(cer, (string)null, keyStorageFlags);
                        default:
                            return X509CertificateLoader.LoadCertificate(cer);
                    }
#else
                    return new X509Certificate2(cer, (string)null, keyStorageFlags);
#endif
                }

                throw new InvalidDataException("The certificate is missing the private key");
            }

            if (keyType == KeyType.Auto)
            {
                string oid = LightweightPkcs8Decoder.DecodePrivateKeyOid(priv);

                keyType = oid switch
                {
                    RSAAlgorithmId => KeyType.RSA,
                    ECDsaAlgorithmId => KeyType.ECDsa,
                    _ => throw new NotSupportedException($"The private key algorithm ID {oid} is not supported"),
                };
            }

            if (keyType == KeyType.ECDsa)
            {
                X509Certificate2 certificate = null;
                CreateECDsaCertificate(cer, priv, keyStorageFlags, ref certificate);

                return certificate ?? throw new NotSupportedException("Reading an ECDsa certificate from a PEM file is not supported");
            }

            return CreateRsaCertificate(cer, priv, keyStorageFlags);
        }

        static partial void CreateECDsaCertificate(byte[] cer, byte[] key, X509KeyStorageFlags keyStorageFlags, ref X509Certificate2 certificate);

        private static X509Certificate2 CreateRsaCertificate(byte[] cer, byte[] key, X509KeyStorageFlags keyStorageFlags)
        {
            if (!s_rsaInitializedImportPkcs8PrivateKeyMethod)
            {
                // ImportPkcs8PrivateKey was added in .NET Core 3.0 and is only present on Core. We will fall back to a lightweight decoder if this method is missing from the current runtime.
                s_rsaImportPkcs8PrivateKeyMethod = typeof(RSA).GetMethod("ImportPkcs8PrivateKey", BindingFlags.Instance | BindingFlags.Public, null, new[] { typeof(ReadOnlySpan<byte>), typeof(int).MakeByRefType() }, null);
                s_rsaInitializedImportPkcs8PrivateKeyMethod = true;
            }

            if (s_rsaCopyWithPrivateKeyMethod is null)
            {
                s_rsaCopyWithPrivateKeyMethod = typeof(RSACertificateExtensions).GetMethod("CopyWithPrivateKey", BindingFlags.Static | BindingFlags.Public, null, new[] { typeof(X509Certificate2), typeof(RSA) }, null)
                    ?? throw new PlatformNotSupportedException("The current platform does not support reading a private key from a PEM file");
            }

            RSA privateKey = null;
            try
            {
                if (s_rsaImportPkcs8PrivateKeyMethod != null)
                {
                    privateKey = RSA.Create();

                    // Because ImportPkcs8PrivateKey declares an out parameter we cannot call it directly using MethodInfo.Invoke since all arguments are passed as an object array.
                    // Instead we create a delegate with the correct signature and invoke it.
                    ImportPrivateKeyDelegate importPkcs8PrivateKey = (ImportPrivateKeyDelegate)s_rsaImportPkcs8PrivateKeyMethod.CreateDelegate(typeof(ImportPrivateKeyDelegate), privateKey);
                    importPkcs8PrivateKey.Invoke(key, out int bytesRead);

                    if (key.Length != bytesRead)
                    {
                        throw new InvalidDataException("Invalid PKCS#8 Data");
                    }
                }
                else
                {
                    privateKey = LightweightPkcs8Decoder.DecodeRSAPkcs8(key);
                }

                X509Certificate2 certificateWithoutPrivateKey;

#if NET9_0_OR_GREATER
                switch (X509Certificate2.GetCertContentType(cer))
                {
                    case X509ContentType.Pkcs12:
                        certificateWithoutPrivateKey = X509CertificateLoader.LoadPkcs12(cer, (string)null, keyStorageFlags);
                        break;
                    default:
                        certificateWithoutPrivateKey = X509CertificateLoader.LoadCertificate(cer);
                        break;
                }
#else
                certificateWithoutPrivateKey = new X509Certificate2(cer, (string)null, keyStorageFlags);
#endif

                X509Certificate2 certificate = (X509Certificate2)s_rsaCopyWithPrivateKeyMethod.Invoke(null, [certificateWithoutPrivateKey, privateKey]);
                certificateWithoutPrivateKey.Dispose();

                // On .NET Framework the PrivateKey member is not initialized after calling CopyWithPrivateKey.
                // This class only compiles against NET6.0 in tests and never in SDK libraries suppress the warning
#pragma warning disable SYSLIB0028 // Use CopyWithPrivateKey instead
                if (certificate.PrivateKey is null)
                {
                    certificate.PrivateKey = privateKey;
                }
#pragma warning restore SYSLIB0028

                // Make sure the private key doesn't get disposed now that it's used.
                privateKey = null;

                return certificate;
            }
            finally
            {
                // If we created and did not use the RSA private key, make sure it's disposed.
                privateKey?.Dispose();
            }
        }

        /// <summary>
        /// Attempts to read the next PEM field from the given data.
        /// </summary>
        /// <param name="data">The PEM data to parse.</param>
        /// <param name="field">The PEM first complete PEM field that was found.</param>
        /// <returns>True if a valid PEM field was parsed; otherwise, false.</returns>
        /// <remarks>
        /// To find subsequent fields, pass a slice of <paramref name="data"/> past the found <see cref="PemField.Length"/>.
        /// </remarks>
        public static bool TryRead(ReadOnlySpan<char> data, out PemField field)
        {
            field = default;

            int start = data.IndexOf(Prolog.AsSpan());
            if (start < 0)
            {
                return false;
            }

            ReadOnlySpan<char> label = data.Slice(start + Prolog.Length);
            int end = label.IndexOf(LabelEnd.AsSpan());
            if (end < 0)
            {
                return false;
            }

            // Slice the label.
            label = label.Slice(0, end);

            // Slice the remaining data after the label.
            int dataOffset = start + Prolog.Length + end + LabelEnd.Length;
            data = data.Slice(dataOffset);

            // Find the label end.
            string labelEpilog = Epilog + label.ToString() + LabelEnd;
            end = data.IndexOf(labelEpilog.AsSpan());
            if (end < 0)
            {
                return false;
            }

            int fieldLength = dataOffset + end + labelEpilog.Length - start;
            field = new PemField(start, label, data.Slice(0, end), fieldLength);

            return true;
        }

        /// <summary>
        /// Key type of the certificate private key.
        /// </summary>
        public enum KeyType
        {
            /// <summary>
            /// The key type is unknown.
            /// </summary>
            Unknown = -1,

            /// <summary>
            /// Attempt to detect the key type.
            /// </summary>
            Auto,

            /// <summary>
            /// RSA key type.
            /// </summary>
            RSA,

            /// <summary>
            /// ECDsa key type.
            /// </summary>
            ECDsa,
        }

        /// <summary>
        /// A PEM field including its section header and encoded data.
        /// </summary>
        public ref struct PemField
        {
            internal PemField(int start, ReadOnlySpan<char> label, ReadOnlySpan<char> data, int length)
            {
                Start = start;
                Label = label;
                Data = data;
                Length = length;
            }

            /// <summary>
            /// The offset of the section from the start of the input PEM stream.
            /// </summary>
            public int Start { get; }

            /// <summary>
            /// A span of the section label from within the PEM stream.
            /// </summary>
            public ReadOnlySpan<char> Label { get; }

            /// <summary>
            /// A span of the section data from within the PEM stream.
            /// </summary>
            public ReadOnlySpan<char> Data { get; }

            /// <summary>
            /// The length of the section from the <see cref="Start"/>.
            /// </summary>
            public int Length { get; }

            /// <summary>
            /// Decodes the base64-encoded <see cref="Data"/>
            /// </summary>
            /// <returns></returns>
            public byte[] FromBase64Data() => Convert.FromBase64String(Data.ToString());
        }
    }
}
