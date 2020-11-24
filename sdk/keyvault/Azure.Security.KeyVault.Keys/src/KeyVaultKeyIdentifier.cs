// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Security.KeyVault.Keys
{
    /// <summary>
    /// Information about a <see cref="KeyVaultKey"/> parsed from a <see cref="Uri"/>.
    /// You can use this information when calling methods of a <see cref="KeyClient"/>.
    /// </summary>
    public readonly struct KeyVaultKeyIdentifier
    {
        private KeyVaultKeyIdentifier(Uri sourceId, Uri vaultUri, string name, string version)
        {
            SourceId = sourceId;
            VaultUri = vaultUri;
            Name = name;
            Version = version;
        }

        /// <summary>
        /// Gets the source <see cref="Uri"/> passed to <see cref="Parse(Uri)"/> or <see cref="TryParse(Uri, out KeyVaultKeyIdentifier)"/>.
        /// </summary>
        public Uri SourceId { get; }

        /// <summary>
        /// Gets the <see cref="Uri"/> of the Key Vault.
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
        /// Parses a <see cref="Uri"/> to a key or deleted key.
        /// </summary>
        /// <param name="id">The <see cref="Uri"/> to a key or deleted key.</param>
        /// <returns>A <see cref="KeyVaultKeyIdentifier"/> containing information about the key or deleted key.</returns>
        /// <exception cref="ArgumentException">The <paramref name="id"/> is not a valid Key Vault key ID.</exception>
        public static KeyVaultKeyIdentifier Parse(Uri id)
        {
            if (TryParse(id, out KeyVaultKeyIdentifier keyId))
            {
                return keyId;
            }

            throw new ArgumentException($"{id} is not a valid Key Vault key ID", nameof(id));
        }

        /// <summary>
        /// Tries to parse a <see cref="Uri"/> to a key or deleted key.
        /// </summary>
        /// <param name="id">The <see cref="Uri"/> to a key or deleted key.</param>
        /// <param name="keyId">A <see cref="KeyVaultKeyIdentifier"/> containing information about the key or deleted key.</param>
        /// <returns>True if the <paramref name="id"/> could be parsed successfully; otherwise, false.</returns>
        public static bool TryParse(Uri id, out KeyVaultKeyIdentifier keyId)
        {
            if (KeyVaultIdentifier.TryParse(id, out KeyVaultIdentifier identifier))
            {
                keyId = new KeyVaultKeyIdentifier(
                    id,
                    identifier.VaultUri,
                    identifier.Name,
                    identifier.Version);

                return true;
            }

            keyId = default;
            return false;
        }
    }
}
