// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.Provisioning.ResourceManager;
using Azure.ResourceManager.KeyVault;
using Azure.ResourceManager.KeyVault.Models;

namespace Azure.Provisioning.KeyVaults
{
    /// <summary>
    /// Represents a KeyVault.
    /// </summary>
    public class KeyVault : Resource<KeyVaultData>
    {
        private const string ResourceTypeName = "Microsoft.KeyVault/vaults";
        private static readonly Func<string, KeyVaultData> Empty = (name) => ArmKeyVaultModelFactory.KeyVaultData();

        /// <summary>
        /// Creates a new instance of the <see cref="KeyVault"/> class referencing an existing instance.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="name">The resource name.</param>
        /// <param name="parent">The resource group.</param>
        /// <returns>The KeyVault instance.</returns>
        public static KeyVault FromExisting(IConstruct scope, string name, ResourceGroup? parent = null)
            => new KeyVault(scope, parent, name, isExisting: true);

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyVault"/> class.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="name">The name.</param>
        /// <param name="version">The version.</param>
        /// <param name="location">The location.</param>
        /// <param name="parent"></param>
        public KeyVault(IConstruct scope, ResourceGroup? parent = default, string name = "kv", string version = "2023-02-01", AzureLocation? location = default)
            : this(scope, parent, name, version, location, false, (name) => ArmKeyVaultModelFactory.KeyVaultData(
                name: name,
                resourceType: ResourceTypeName,
                location: location ?? Environment.GetEnvironmentVariable("AZURE_LOCATION") ?? AzureLocation.WestUS,
                properties: ArmKeyVaultModelFactory.KeyVaultProperties(
                    sku: new KeyVaultSku(KeyVaultSkuFamily.A, KeyVaultSkuName.Standard),
                    accessPolicies: Environment.GetEnvironmentVariable("AZURE_PRINCIPAL_ID") is not null ? new List<KeyVaultAccessPolicy>()
                    {
                        new KeyVaultAccessPolicy(scope.Root.Properties.TenantId!.Value, Environment.GetEnvironmentVariable("AZURE_PRINCIPAL_ID"), new IdentityAccessPermissions()
                        {
                            Secrets =
                            {
                                IdentityAccessSecretPermission.Get,
                                IdentityAccessSecretPermission.List
                            }
                        })
                    } : default,
                    enableRbacAuthorization: true)))
        {
            AssignProperty(data => data.Name, GetAzureName(scope, name));

            if (scope.Root.Properties.TenantId == Guid.Empty)
            {
                AssignProperty(kv => kv.Properties.TenantId, Tenant.TenantIdExpression);
            }
        }

        private KeyVault(IConstruct scope, ResourceGroup? parent = default, string name = "kv", string version = "2023-02-01", AzureLocation? location = default, bool isExisting = false, Func<string, KeyVaultData>? creator = null)
            : base(scope, parent, name, ResourceTypeName, version, creator ?? Empty, isExisting: isExisting)
        {
        }

        /// <summary>
        /// Adds an access policy to the <see cref="KeyVault"/>.
        /// </summary>
        /// <param name="output">The output containing the access policy principal.</param>
        public void AddAccessPolicy(Output output)
        {
            _ = new KeyVaultAddAccessPolicy(Scope, new Parameter(output), this);
        }

        /// <inheritdoc/>
        protected override Resource? FindParentInScope(IConstruct scope)
        {
            var result = base.FindParentInScope(scope);
            if (result is null)
            {
                result = scope.GetOrAddResourceGroup();
            }
            return result;
        }

        /// <inheritdoc/>
        protected override string GetAzureName(IConstruct scope, string resourceName) => GetGloballyUniqueName(resourceName);
    }
}
