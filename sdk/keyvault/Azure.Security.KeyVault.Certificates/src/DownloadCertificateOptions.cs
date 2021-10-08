// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Security.Cryptography.X509Certificates;

namespace Azure.Security.KeyVault.Certificates
{
    /// <summary>
    /// Additional options for downloading and creating an <see cref="X509Certificate2"/>.
    /// </summary>
    public class DownloadCertificateOptions
    {
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
