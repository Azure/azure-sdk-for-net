// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.ResourceManager.KeyVault;
using Azure.ResourceManager.KeyVault.Models;

namespace Azure.Provisioning.KeyVaults
{
    /// <summary>
    /// A key vault secret.
    /// </summary>
    public class KeyVaultSecret : Resource<KeyVaultSecretData>
    {
        private const string ResourceTypeName = "Microsoft.KeyVault/vaults/secrets";
        private static KeyVaultSecretData Empty(string name) => ArmKeyVaultModelFactory.KeyVaultSecretData();

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyVaultSecret"/>.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="parent">The parent vault.</param>
        /// <param name="name">The name.</param>
        /// <param name="version">The version.</param>
        public KeyVaultSecret(IConstruct scope, KeyVault? parent = null, string name = "kvs", string version = KeyVault.DefaultVersion)
            : this(scope, parent, name, version, false, (name) => ArmKeyVaultModelFactory.KeyVaultSecretData(
                name: name,
                resourceType: ResourceTypeName,
                properties: ArmKeyVaultModelFactory.SecretProperties(
                    value: Guid.Empty.ToString())
                ))
        {
        }

        private KeyVaultSecret(IConstruct scope, KeyVault? parent, string name, string version = KeyVault.DefaultVersion, bool isExisting = false, Func<string, KeyVaultSecretData>? createProperties = null)
            : base(scope, parent, name, ResourceTypeName, version, createProperties ?? Empty, isExisting)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyVaultSecret"/>.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="name">The name.</param>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="parent">The parent vault.</param>
        /// <param name="version">The version.</param>
        public KeyVaultSecret(IConstruct scope, string name, ConnectionString connectionString, KeyVault? parent = null, string version = KeyVault.DefaultVersion)
            : this(scope, parent, name, version, false, (name) => ArmKeyVaultModelFactory.KeyVaultSecretData(
                name: name,
                resourceType: ResourceTypeName,
                properties: ArmKeyVaultModelFactory.SecretProperties(
                    value: connectionString.Value)
                ))
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="KeyVaultSecret"/> class referencing an existing instance.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="name">The resource name.</param>
        /// <param name="parent">The parent vault.</param>
        /// <returns>The KeyVaultSecret instance.</returns>
        public static KeyVaultSecret FromExisting(IConstruct scope, string name, KeyVault parent)
            => new KeyVaultSecret(scope, parent, name, isExisting: true);

        /// <inheritdoc/>
        protected override Resource? FindParentInScope(IConstruct scope)
        {
            return scope.GetSingleResource<KeyVault>() ?? new KeyVault(scope);
        }
    }
}
