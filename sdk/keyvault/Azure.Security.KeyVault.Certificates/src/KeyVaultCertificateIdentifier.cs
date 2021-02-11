// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Security.KeyVault.Certificates
{
    /// <summary>
    /// Information about a <see cref="KeyVaultCertificate"/> parsed from a <see cref="Uri"/>.
    /// You can use this information when calling methods of a <see cref="CertificateClient"/>.
    /// </summary>
    public readonly struct KeyVaultCertificateIdentifier : IEquatable<KeyVaultCertificateIdentifier>
    {
        /// <summary>
        /// Creates a new instance of the <see cref="KeyVaultCertificateIdentifier"/> class.
        /// </summary>
        /// <param name="id">The <see cref="Uri"/> to a certificate or deleted certificate.</param>
        /// <exception cref="ArgumentException"><paramref name="id"/> is not a valid Key Vault certificate ID.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="id"/> is null.</exception>
        public KeyVaultCertificateIdentifier(Uri id)
        {
            Argument.AssertNotNull(id, nameof(id));

            if (KeyVaultIdentifier.TryParse(id, out KeyVaultIdentifier identifier))
            {
                SourceId = id;
                VaultUri = identifier.VaultUri;
                Name = identifier.Name;
                Version = identifier.Version;
            }
            else
            {
                throw new ArgumentException($"{id} is not a valid Key Vault certificate ID", nameof(id));
            }
        }

        /// <summary>
        /// Gets the source <see cref="Uri"/> passed to <see cref="KeyVaultCertificateIdentifier(Uri)"/>.
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

        /// <inheritdoc/>
        public override bool Equals(object obj) =>
            obj is KeyVaultCertificateIdentifier other && Equals(other);

        /// <inheritdoc/>
        public bool Equals(KeyVaultCertificateIdentifier other) =>
            SourceId.Equals(other.SourceId);

        /// <inheritdoc/>
        public override int GetHashCode() =>
            SourceId.GetHashCode();
    }
}
