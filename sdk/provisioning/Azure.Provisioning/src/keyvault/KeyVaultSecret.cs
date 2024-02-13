// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Provisioning.Sql;
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

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyVaultSecret"/>.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="name">The name.</param>
        /// <param name="version">The version.</param>
        public KeyVaultSecret(IConstruct scope, string name, string version = "2023-02-01")
            : base(scope, null, GetName(scope, name), ResourceTypeName, version, ArmKeyVaultModelFactory.KeyVaultSecretData(
                name: GetName(scope, name),
                resourceType: ResourceTypeName,
                properties: ArmKeyVaultModelFactory.SecretProperties(
                    value: Guid.Empty.ToString())
                ))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyVaultSecret"/>.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="name">The name.</param>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="version">The version.</param>
        public KeyVaultSecret(IConstruct scope, string name, ConnectionString connectionString, string version = "2023-02-01")
            : base(scope, null, GetName(scope, name), ResourceTypeName, version, ArmKeyVaultModelFactory.KeyVaultSecretData(
                name: GetName(scope, name),
                resourceType: ResourceTypeName,
                properties: ArmKeyVaultModelFactory.SecretProperties(
                    value: connectionString.Value)
                ))
        {
        }

        private static string GetName(IConstruct scope, string? name) => name is null ? $"kvs-{scope.EnvironmentName}" : name;

        /// <inheritdoc/>
        protected override Resource? FindParentInScope(IConstruct scope)
        {
            var result = base.FindParentInScope(scope);
            if (result is null)
            {
                result = scope.GetSingleResource<KeyVault>() ?? new KeyVault(scope, "kv");
            }
            return result;
        }
    }
}
