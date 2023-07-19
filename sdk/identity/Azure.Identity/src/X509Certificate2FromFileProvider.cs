// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Identity
{
    /// <summary>
    /// X509Certificate2FromFileProvider provides an X509Certificate2 from a file on disk.  It supports both
    /// "pfx" and "pem" encoded certificates.
    /// </summary>
    internal class X509Certificate2FromFileProvider : IX509Certificate2Provider
    {
        // Lazy initialized on the first call to GetCertificateAsync, based on CertificatePath.
        private X509Certificate2 Certificate { get; set; }
        internal string CertificatePath { get; }
        internal string CertificatePassword { get; }

        public X509Certificate2FromFileProvider(string clientCertificatePath, string certificatePassword)
        {
            Argument.AssertNotNull(clientCertificatePath, nameof(clientCertificatePath));
            CertificatePath = clientCertificatePath ?? throw new ArgumentNullException(nameof(clientCertificatePath));
            CertificatePassword = certificatePassword;
        }

        public ValueTask<X509Certificate2> GetCertificateAsync(bool async, CancellationToken cancellationToken)
        {
            if (!(Certificate is null))
            {
                return new ValueTask<X509Certificate2>(Certificate);
            }

            string fileType = Path.GetExtension(CertificatePath);

            switch (fileType.ToLowerInvariant())
            {
                case ".pfx":
                    return LoadCertificateFromPfxFileAsync(async, CertificatePath, CertificatePassword, cancellationToken);
                case ".pem":
                    if (CertificatePassword != null)
                    {
                        throw new CredentialUnavailableException("Password protection for PEM encoded certificates is not supported.");
                    }
                    return LoadCertificateFromPemFileAsync(async, CertificatePath, cancellationToken);
                default:
                    throw new CredentialUnavailableException("Only .pfx and .pem files are supported.");
            }
        }

        private async ValueTask<X509Certificate2> LoadCertificateFromPfxFileAsync(bool async, string clientCertificatePath, string certificatePassword, CancellationToken cancellationToken)
        {
            const int BufferSize = 4 * 1024;

            if (!(Certificate is null))
            {
                return Certificate;
            }

            try
            {
                if (!async)
                {
                    Certificate = new X509Certificate2(clientCertificatePath, certificatePassword);
                }
                else
                {
                    List<byte> certContents = new List<byte>();
                    byte[] buf = new byte[BufferSize];
                    int offset = 0;
                    using (Stream s = File.OpenRead(clientCertificatePath))
                    {
                        while (true)
                        {
                            int read = await s.ReadAsync(buf, offset, buf.Length, cancellationToken).ConfigureAwait(false);
                            for (int i = 0; i < read; i++)
                            {
                                certContents.Add(buf[i]);
                            }

                            if (read == 0)
                            {
                                break;
                            }
                        }
                    }

                    Certificate = new X509Certificate2(certContents.ToArray(), certificatePassword);
                }

                return Certificate;
            }
            catch (Exception e) when (!(e is OperationCanceledException))
            {
                throw new CredentialUnavailableException("Could not load certificate file", e);
            }
        }

        private async ValueTask<X509Certificate2> LoadCertificateFromPemFileAsync(bool async, string clientCertificatePath, CancellationToken cancellationToken)
        {
            if (!(Certificate is null))
            {
                return Certificate;
            }

            string certficateText;

            try
            {
                if (!async)
                {
                    certficateText = File.ReadAllText(clientCertificatePath);
                }
                else
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    using (StreamReader sr = new StreamReader(clientCertificatePath))
                    {
                        certficateText = await sr.ReadToEndAsync().ConfigureAwait(false);
                    }
                }

                Certificate = PemReader.LoadCertificate(certficateText.AsSpan(), keyType: PemReader.KeyType.RSA);

                return Certificate;
            }
            catch (Exception e) when (!(e is OperationCanceledException))
            {
                throw new CredentialUnavailableException("Could not load certificate file", e);
            }
        }

        private delegate void ImportPkcs8PrivateKeyDelegate(ReadOnlySpan<byte> blob, out int bytesRead);
    }
}
