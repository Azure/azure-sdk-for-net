// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Azure.Core
{
    internal static class PemReader
    {
        private delegate void ImportPkcs8PrivateKeyDelegate(ReadOnlySpan<byte> blob, out int bytesRead);

        private const string Prolog = "-----BEGIN ";
        private const string Epilog = "-----END ";
        private const string LabelEnd = "-----";

        private static bool s_initializedImportPkcs8PrivateKeyMethod;
        private static MethodInfo s_importPkcs8PrivateKeyMethod;
        private static MethodInfo s_copyWithPrivateKeyMethod;

        /// <summary>
        /// Loads an <see cref="X509Certificate2"/> from PEM data.
        /// </summary>
        /// <param name="data">The PEM data to parse.</param>
        /// <param name="cer">Optional public certificate data if not defined within the PEM data.</param>
        /// <param name="allowCertificateOnly">Whether to create an <see cref="X509Certificate2"/> if no private key is read.</param>
        /// <returns>An <see cref="X509Certificate2"/> loaded from the PEM data.</returns>
        /// <exception cref="CryptographicException">A cryptographic exception occurred when trying to create the <see cref="X509Certificate2"/>.</exception>
        /// <exception cref="InvalidDataException"><paramref name="cer"/> is null and no CERTIFICATE field is defined in PEM, or no PRIVATE KEY is defined in PEM.</exception>
        /// <exception cref="PlatformNotSupportedException">Creating a <see cref="X509Certificate2"/> from PEM data is not supported on the current platform.</exception>
        public static X509Certificate2 LoadCertificate(ReadOnlySpan<char> data, byte[] cer = null, bool allowCertificateOnly = false)
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
                    return new X509Certificate2(cer);
                }

                throw new InvalidDataException("The certificate is missing the private key");
            }

            if (!s_initializedImportPkcs8PrivateKeyMethod)
            {
                // ImportPkcs8PrivateKey was added in .NET Core 3.0 and is only present on Core. We will fall back to a lightweight decoder if this method is missing from the current runtime.
                s_importPkcs8PrivateKeyMethod = typeof(RSA).GetMethod("ImportPkcs8PrivateKey", BindingFlags.Instance | BindingFlags.Public, null, new[] { typeof(ReadOnlySpan<byte>), typeof(int).MakeByRefType() }, null);
                s_initializedImportPkcs8PrivateKeyMethod = true;
            }

            if (s_copyWithPrivateKeyMethod is null)
            {
                s_copyWithPrivateKeyMethod = typeof(RSACertificateExtensions).GetMethod("CopyWithPrivateKey", BindingFlags.Static | BindingFlags.Public, null, new[] { typeof(X509Certificate2), typeof(RSA) }, null)
                    ?? throw new PlatformNotSupportedException("The current platform does not support reading a private key from a PEM file");
            }

            RSA privateKey = null;
            try
            {
                if (s_importPkcs8PrivateKeyMethod != null)
                {
                    privateKey = RSA.Create();

                    // Because ImportPkcs8PrivateKey declares an out parameter we cannot call it directly using MethodInfo.Invoke since all arguments are passed as an object array.
                    // Instead we create a delegate with the correct signature and invoke it.
                    ImportPkcs8PrivateKeyDelegate importPkcs8PrivateKey = (ImportPkcs8PrivateKeyDelegate)s_importPkcs8PrivateKeyMethod.CreateDelegate(typeof(ImportPkcs8PrivateKeyDelegate), privateKey);
                    importPkcs8PrivateKey.Invoke(priv, out _);
                }
                else
                {
                    privateKey = LightweightPkcs8Decoder.DecodeRSAPkcs8(priv);
                }

                using X509Certificate2 certificateWithoutPrivateKey = new X509Certificate2(cer);
                X509Certificate2 certificate = (X509Certificate2)s_copyWithPrivateKeyMethod.Invoke(null, new object[] { certificateWithoutPrivateKey, privateKey });

                // On .NET Framework the PrivateKey member is not initialized after calling CopyWithPRivateKey.
                if (certificate.PrivateKey is null)
                {
                    certificate.PrivateKey = privateKey;
                }

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

        public ref struct PemField
        {
            internal PemField(int start, ReadOnlySpan<char> label, ReadOnlySpan<char> data, int length)
            {
                Start = start;
                Label = label;
                Data = data;
                Length = length;
            }

            public int Start { get; }

            public ReadOnlySpan<char> Label { get; }

            public ReadOnlySpan<char> Data { get; }

            public int Length { get; }

            public byte[] FromBase64Data() => Convert.FromBase64String(Data.ToString());
        }
    }
}
