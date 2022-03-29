// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
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
        /// <remarks>
        /// Successfully parsing the given <see cref="Uri"/> does not guarantee that the <paramref name="id"/> is a valid Key Vault certificate identifier:
        /// only that it contains the necessary number of path parts that look like a Key Vault certificate identifier. If the <see cref="VaultUri"/> references
        /// a valid Key Vault, the service will return an error if the <see cref="Name"/> and <see cref="Version"/> do not specify a valid certificate.
        /// </remarks>
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

        private KeyVaultCertificateIdentifier(Uri sourceId, Uri vaultUri, string name, string version)
        {
            SourceId = sourceId;
            VaultUri = vaultUri;
            Name = name;
            Version = version;
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

        /// <summary>
        /// Tries to create a new instance of the <see cref="KeyVaultCertificateIdentifier"/> from the given <paramref name="id"/>.
        /// </summary>
        /// <param name="id">A <see cref="Uri"/> to a Key Vault certificate with or without a version.</param>
        /// <param name="identifier">A <see cref="KeyVaultCertificateIdentifier"/> from the given <paramref name="id"/> if valid; otherwise, an empty structure if invalid.</param>
        /// <returns>True if the <see cref="Uri"/> contains a <see cref="VaultUri"/>, <see cref="Name"/>, and optional <see cref="Version"/>; otherwise, false.</returns>
        /// <remarks>
        /// Successfully parsing the given <see cref="Uri"/> does not guarantee that the <paramref name="id"/> is a valid Key Vault certificate identifier:
        /// only that it contains the necessary number of path parts that look like a Key Vault certificate identifier. If the <see cref="VaultUri"/> references
        /// a valid Key Vault, the service will return an error if the <see cref="Name"/> and <see cref="Version"/> do not specify a valid certificate.
        /// </remarks>
        public static bool TryCreate(Uri id, out KeyVaultCertificateIdentifier identifier)
        {
            if (KeyVaultIdentifier.TryParse(id, out KeyVaultIdentifier value))
            {
                identifier = new KeyVaultCertificateIdentifier(value.Id, value.VaultUri, value.Name, value.Version);
                return true;
            }

            identifier = default;
            return false;
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) =>
            obj is KeyVaultCertificateIdentifier other && Equals(other);

        /// <inheritdoc/>
        public bool Equals(KeyVaultCertificateIdentifier other) =>
            SourceId == other.SourceId;

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() =>
            SourceId?.GetHashCode() ?? 0;

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() =>
            base.ToString();
    }
}
