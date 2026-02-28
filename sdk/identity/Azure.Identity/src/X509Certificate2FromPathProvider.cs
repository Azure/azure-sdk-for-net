// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Identity
{
    /// <summary>
    /// X509Certificate2FromPathProvider provides an X509Certificate2 from "pfx"- and "pem"-encoded certificates
    /// on disk and the platform certificate store.
    /// </summary>
    internal sealed class X509Certificate2FromPathProvider : IX509Certificate2Provider
    {
        // Lazy initialized on the first call to GetCertificateAsync, based on CertificatePath.
        private X509Certificate2 Certificate { get; set; }
        internal string CertificatePath { get; }
        internal string CertificatePassword { get; }

        public X509Certificate2FromPathProvider(string clientCertificatePath, string certificatePassword)
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

            // not compiled or cached because this should be a rare operation, and the source generator is not supported on all targets
            Regex certStorePathRegex = new(@"^cert:[\\/]{1,2}(\w+)[\\/](\w+)[\\/](\w+)$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);

            // if path is in format cert:/StoreLocation/StoreName/Thumbprint, attempt to load from cert store.  Otherwise, treat as file path.
            // windows style paths are supported: cert:\CurrentUser\My\THUMBPRINT
            Match match = certStorePathRegex.Match(CertificatePath);
            if (match.Success)
            {
                string storeLocation = match.Groups[1].Value;
                if (!Enum.TryParse(storeLocation, ignoreCase: true, out StoreLocation storeLocationEnum))
                {
                    throw new CredentialUnavailableException($"Invalid store location '{storeLocation}' specified in certificate path. Valid values are: {string.Join(", ", Enum.GetNames(typeof(StoreLocation)))}");
                }
                string storeName = match.Groups[2].Value;
                string thumbprint = match.Groups[3].Value;

                if (!string.IsNullOrEmpty(CertificatePassword))
                {
                    throw new CredentialUnavailableException("Password protection for certificates from the certificate store is not supported.");
                }

                return LoadCertificateFromStore(storeLocationEnum, storeName, thumbprint);
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
                    throw new CredentialUnavailableException("Certificate path must be in format cert:/StoreLocation/StoreName/Thumbprint, or a file path with .pfx or .pem extension. For example, cert:/CurrentUser/My/THUMBPRINT. Certificate path provided: " + CertificatePath);
            }
        }

        private async ValueTask<X509Certificate2> LoadCertificateFromStore(StoreLocation storeLocation, string storeName, string thumbprint)
        {
            using X509Store store = new(storeName, storeLocation);
            store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);

            // self signed certificates may be valid here, so don't perform chain validation
            var certs = store.Certificates.Find(X509FindType.FindByThumbprint, thumbprint, validOnly: false);

            return certs.Count switch
            {
                1 => Certificate = certs[0],
                0 => throw new CredentialUnavailableException($"No certificate found in {storeLocation}/{storeName} store with thumbprint {thumbprint}"),
                _ => throw new CredentialUnavailableException($"{certs.Count} certificates found in {storeLocation}/{storeName} store with thumbprint {thumbprint}")
            };
        }

        // X509Certificate2.X509Certificate2 was made obsolete in .NET 10.0 and replaced by X509CertificateLoader.
        // However, the loader is not available in earlier versions.
        private async ValueTask<X509Certificate2> LoadCertificateFromPfxFileAsync(bool async, string clientCertificatePath, string certificatePassword, CancellationToken cancellationToken)
        {
            try
            {
                if (!async)
                {
#if NET10_0_OR_GREATER
                    Certificate = X509CertificateLoader.LoadPkcs12FromFile(clientCertificatePath, certificatePassword);
#else
                    Certificate = new X509Certificate2(clientCertificatePath, certificatePassword);
#endif
                }
                else
                {
                    byte[] certContents = await ReadAllCertificateBytesAsync(clientCertificatePath, cancellationToken).ConfigureAwait(false);
#if NET10_0_OR_GREATER
                    Certificate = X509CertificateLoader.LoadPkcs12(certContents, certificatePassword);
#else
                    Certificate = new X509Certificate2(certContents, certificatePassword);
#endif
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

        private async Task<byte[]> ReadAllCertificateBytesAsync(string path, CancellationToken cancellationToken)
        {
#if !NETSTANDARD2_0
            return await File.ReadAllBytesAsync(path, cancellationToken).ConfigureAwait(false);
#else
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, true))
            using (MemoryStream ms = new MemoryStream())
            {
                await fs.CopyToAsync(ms, 81920, cancellationToken).ConfigureAwait(false);
                return ms.ToArray();
            }
#endif
        }

        private delegate void ImportPkcs8PrivateKeyDelegate(ReadOnlySpan<byte> blob, out int bytesRead);
    }
}
