// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Security.Cryptography.X509Certificates;
using Azure.Core;

namespace Azure.Security.KeyVault.Certificates
{
    /// <summary>
    /// Additional options for downloading and creating an <see cref="X509Certificate2"/>.
    /// </summary>
    public class DownloadCertificateOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DownloadCertificateOptions"/> class.
        /// </summary>
        /// <param name="certificateName">The name of the certificate to download.</param>
        public DownloadCertificateOptions(string certificateName)
        {
            Argument.AssertNotNullOrEmpty(certificateName, nameof(certificateName));

            CertificateName = certificateName;
        }

        /// <summary>
        /// Gets the name of the certificate to download.
        /// </summary>
        public string CertificateName { get; }

        /// <summary>
        /// Gets or sets the optional version of a certificate to download.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets the optional certificate content type in which the certificate will be downloaded. If a supported format is specified,
        /// the certificate content is converted to the requested format. Currently, only PFX to PEM conversion is supported.
        /// If an unsupported format is specified, the request is rejected. If not specified, the certificate is returned in its original
        /// format without conversion.
        /// </summary>
        public CertificateContentType? OutContentType { get; set; }

        /// <summary>
        /// Gets or sets a combination of the enumeration values that control where and how to import the certificate.
        /// The default is <see cref="X509KeyStorageFlags.DefaultKeySet"/>.
        /// </summary>
        /// <remarks>
        /// These <see cref="X509KeyStorageFlags"/> are passed to <see cref="X509Certificate2(string, string, X509KeyStorageFlags)"/>
        /// when constructing the certificate. The default is <see cref="X509KeyStorageFlags.DefaultKeySet"/> and behavior may vary across platforms.
        /// There may also be new values supported when targeting newer versions of .NET such as <c>EphemeralKeySet</c> that you set in this property
        /// to use when creating an <see cref="X509Certificate2"/>.
        /// </remarks>
        public X509KeyStorageFlags KeyStorageFlags { get; set; }
    }
}
