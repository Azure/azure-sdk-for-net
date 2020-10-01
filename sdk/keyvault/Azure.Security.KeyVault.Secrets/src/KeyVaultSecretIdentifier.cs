// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Security.KeyVault.Secrets
{
    /// <summary>
    /// Information about a <see cref="KeyVaultSecret"/> parsed from a <see cref="Uri"/>.
    /// You can use this information when calling methods of a <see cref="SecretClient"/>.
    /// </summary>
    public readonly struct KeyVaultSecretIdentifier
    {
        private KeyVaultSecretIdentifier(Uri sourceId, Uri vaultUri, string name, string version)
        {
            SourceId = sourceId;
            VaultUri = vaultUri;
            Name = name;
            Version = version;
        }

        /// <summary>
        /// Gets the source <see cref="Uri"/> passed to <see cref="Parse(Uri)"/> or <see cref="TryParse(Uri, out KeyVaultSecretIdentifier)"/>.
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

        /// <summary>
        /// Parses a <see cref="Uri"/> to a secret or deleted secret.
        /// </summary>
        /// <param name="id">The <see cref="Uri"/> to a secret or deleted secret.</param>
        /// <returns>A <see cref="KeyVaultSecretIdentifier"/> containing information about the secret or deleted secret.</returns>
        /// <exception cref="ArgumentException">The <paramref name="id"/> is not a valid Key Vault secret ID.</exception>
        public static KeyVaultSecretIdentifier Parse(Uri id)
        {
            if (TryParse(id, out KeyVaultSecretIdentifier secretId))
            {
                return secretId;
            }

            throw new ArgumentException($"{id} is not a valid Key Vault secret ID", nameof(id));
        }

        /// <summary>
        /// Tries to parse a <see cref="Uri"/> to a secret or deleted secret.
        /// </summary>
        /// <param name="id">The <see cref="Uri"/> to a secret or deleted secret.</param>
        /// <param name="secretId">A <see cref="KeyVaultSecretIdentifier"/> containing information about the secret or deleted secret.</param>
        /// <returns>True if the <paramref name="id"/> could be parsed successfully; otherwise, false.</returns>
        public static bool TryParse(Uri id, out KeyVaultSecretIdentifier secretId)
        {
            if (KeyVaultIdentifier.TryParse(id, out KeyVaultIdentifier identifier))
            {
                secretId = new KeyVaultSecretIdentifier(
                    id,
                    identifier.VaultUri,
                    identifier.Name,
                    identifier.Version);

                return true;
            }

            secretId = default;
            return false;
        }
    }
}
