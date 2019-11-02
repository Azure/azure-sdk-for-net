// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Security.KeyVault.Certificates
{
    public static class WellKnownIssuerNames
    {
        /// <summary>
        /// Create a self-issued certificate.
        /// </summary>
        public const string Self = "Self";

        /// <summary>
        /// Creates a certificate that requires merging an external X.509 certificate using <see cref="CertificateClient.MergeCertificateAsync(MergeCertificateOptions, System.Threading.CancellationToken)"/>.
        /// </summary>
        public const string Unknown = "Unknown";
    }
}
