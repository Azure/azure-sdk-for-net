// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.Security.KeyVault.Keys
{
    /// <summary>
    /// Information about a <see cref="KeyVaultKey"/> parsed from a <see cref="Uri"/>.
    /// You can use this information when calling methods of a <see cref="KeyClient"/>.
    /// </summary>
    public readonly struct KeyVaultKeyIdentifier : IEquatable<KeyVaultKeyIdentifier>
    {
        /// <summary>
        /// Creates a new instance of the <see cref="KeyVaultKeyIdentifier"/> class.
        /// </summary>
        /// <param name="id">The <see cref="Uri"/> to a key or deleted key.</param>
        /// <exception cref="ArgumentException"><paramref name="id"/> is not a valid Key Vault or Managed HSM key ID.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="id"/> is null.</exception>
        /// <remarks>
        /// Successfully parsing the given <see cref="Uri"/> does not guarantee that the <paramref name="id"/> is a valid Key Vault or Managed HSM key identifier:
        /// only that it contains the necessary number of path parts that look like a Key Vault key identifier. If the <see cref="VaultUri"/> references
        /// a valid Key Vault or Managed HSM, the service will return an error if the <see cref="Name"/> and <see cref="Version"/> do not specify a valid key.
        /// </remarks>
        public KeyVaultKeyIdentifier(Uri id)
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
                throw new ArgumentException($"{id} is not a valid key ID", nameof(id));
            }
        }

        private KeyVaultKeyIdentifier(Uri sourceId, Uri vaultUri, string name, string version)
        {
            SourceId = sourceId;
            VaultUri = vaultUri;
            Name = name;
            Version = version;
        }

        /// <summary>
        /// Gets the source <see cref="Uri"/> passed to <see cref="KeyVaultKeyIdentifier(Uri)"/>.
        /// </summary>
        public Uri SourceId { get; }

        /// <summary>
        /// Gets the <see cref="Uri"/> of the Key Vault or Managed HSM.
        /// </summary>
        public Uri VaultUri { get; }

        /// <summary>
        /// Gets the name of the key.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the optional version of the key.
        /// </summary>
        public string Version { get; }

        /// <summary>
        /// Tries to create a new instance of the <see cref="KeyVaultKeyIdentifier"/> from the given <paramref name="id"/>.
        /// </summary>
        /// <param name="id">A <see cref="Uri"/> to a Key Vault or Managed HSM key with or without a version.</param>
        /// <param name="identifier">A <see cref="KeyVaultKeyIdentifier"/> from the given <paramref name="id"/> if valid; otherwise, an empty structure if invalid.</param>
        /// <returns>True if the <see cref="Uri"/> contains a <see cref="VaultUri"/>, <see cref="Name"/>, and optional <see cref="Version"/>; otherwise, false.</returns>
        /// <remarks>
        /// Successfully parsing the given <see cref="Uri"/> does not guarantee that the <paramref name="id"/> is a valid Key Vault or Managed HSM key identifier:
        /// only that it contains the necessary number of path parts that look like a Key Vault key identifier. If the <see cref="VaultUri"/> references
        /// a valid Key Vault or Managed HSM, the service will return an error if the <see cref="Name"/> and <see cref="Version"/> do not specify a valid key.
        /// </remarks>
        public static bool TryCreate(Uri id, out KeyVaultKeyIdentifier identifier)
        {
            if (KeyVaultIdentifier.TryParse(id, out KeyVaultIdentifier value))
            {
                identifier = new KeyVaultKeyIdentifier(value.Id, value.VaultUri, value.Name, value.Version);
                return true;
            }

            identifier = default;
            return false;
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) =>
            obj is KeyVaultKeyIdentifier other && Equals(other);

        /// <inheritdoc/>
        public bool Equals(KeyVaultKeyIdentifier other) =>
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
