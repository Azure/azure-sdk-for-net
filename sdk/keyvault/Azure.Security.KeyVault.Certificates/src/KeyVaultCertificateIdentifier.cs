// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Security.KeyVault.Certificates
{
    /// <summary>
    /// Information about a <see cref="KeyVaultCertificate"/> parsed from a <see cref="Uri"/>.
    /// You can use this information when calling methods of a <see cref="CertificateClient"/>.
    /// </summary>
    public readonly struct KeyVaultCertificateIdentifier
    {
        private KeyVaultCertificateIdentifier(Uri sourceId, Uri vaultUri, string name, string version)
        {
            SourceId = sourceId;
            VaultUri = vaultUri;
            Name = name;
            Version = version;
        }

        /// <summary>
        /// Gets the source <see cref="Uri"/> passed to <see cref="Parse(Uri)"/> or <see cref="TryParse(Uri, out KeyVaultCertificateIdentifier)"/>.
        /// </summary>
        public Uri SourceId { get; }

        /// <summary>
        /// Gets the <see cref="Uri"/> of the Key Vault.
        /// </summary>
        public Uri VaultUri { get; }

        /// <summary>
        /// Gets the name of the certificate.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the optional version of the certificate.
        /// </summary>
        public string Version { get; }

        /// <summary>
        /// Parses a <see cref="Uri"/> to a certificate or deleted certificate.
        /// </summary>
        /// <param name="id">The <see cref="Uri"/> to a certificate or deleted certificate.</param>
        /// <returns>A <see cref="KeyVaultCertificateIdentifier"/> containing information about the certificate or deleted certificate.</returns>
        /// <exception cref="ArgumentException">The <paramref name="id"/> is not a valid Key Vault certificate ID.</exception>
        public static KeyVaultCertificateIdentifier Parse(Uri id)
        {
            if (TryParse(id, out KeyVaultCertificateIdentifier certificateId))
            {
                return certificateId;
            }

            throw new ArgumentException($"{id} is not a valid Key Vault certificate ID", nameof(id));
        }

        /// <summary>
        /// Tries to parse a <see cref="Uri"/> to a certificate or deleted certificate.
        /// </summary>
        /// <param name="id">The <see cref="Uri"/> to a certificate or deleted certificate.</param>
        /// <param name="certificateId">A <see cref="KeyVaultCertificateIdentifier"/> containing information about the certificate or deleted certificate.</param>
        /// <returns>True if the <paramref name="id"/> could be parsed successfully; otherwise, false.</returns>
        public static bool TryParse(Uri id, out KeyVaultCertificateIdentifier certificateId)
        {
            if (KeyVaultIdentifier.TryParse(id, out KeyVaultIdentifier identifier))
            {
                certificateId = new KeyVaultCertificateIdentifier(
                    id,
                    identifier.VaultUri,
                    identifier.Name,
                    identifier.Version);

                return true;
            }

            certificateId = default;
            return false;
        }
    }
}
