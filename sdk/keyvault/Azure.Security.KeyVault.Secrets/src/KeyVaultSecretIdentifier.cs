// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Security.KeyVault.Secrets
{
    /// <summary>
    /// Information about a <see cref="KeyVaultSecret"/> parsed from a <see cref="Uri"/>.
    /// You can use this information when calling methods of a <see cref="SecretClient"/>.
    /// </summary>
    public readonly struct KeyVaultSecretIdentifier : IEquatable<KeyVaultSecretIdentifier>
    {
        /// <summary>
        /// Creates a new instance of the <see cref="KeyVaultSecretIdentifier"/> class.
        /// </summary>
        /// <param name="id">The <see cref="Uri"/> to a secret or deleted secret.</param>
        /// <exception cref="ArgumentException"><paramref name="id"/> is not a valid Key Vault secret ID.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="id"/> is null.</exception>
        public KeyVaultSecretIdentifier(Uri id)
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
                throw new ArgumentException($"{id} is not a valid Key Vault secret ID", nameof(id));
            }
        }

        /// <summary>
        /// Gets the source <see cref="Uri"/> passed to <see cref="KeyVaultSecretIdentifier(Uri)"/>.
        /// </summary>
        public Uri SourceId { get; }

        /// <summary>
        /// Gets the <see cref="Uri"/> of the Key Vault.
        /// </summary>
        public Uri VaultUri { get; }

        /// <summary>
        /// Gets the name of the secret.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the optional version of the secret.
        /// </summary>
        public string Version { get; }

        /// <inheritdoc/>
        public override bool Equals(object obj) =>
            obj is KeyVaultSecretIdentifier other && Equals(other);

        /// <inheritdoc/>
        public bool Equals(KeyVaultSecretIdentifier other) =>
            SourceId.Equals(other.SourceId);

        /// <inheritdoc/>
        public override int GetHashCode() =>
            SourceId.GetHashCode();
    }
}
