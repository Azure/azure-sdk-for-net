// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Provisioning.ResourceManager;
using Azure.ResourceManager.Storage;
using Azure.ResourceManager.Storage.Models;

namespace Azure.Provisioning.Storage
{
    /// <summary>
    /// Represents a storage account.
    /// </summary>
    public class StorageAccount : Resource<StorageAccountData>
    {
        // https://learn.microsoft.com/azure/templates/microsoft.storage/2022-09-01/storageaccounts?pivots=deployment-language-bicep
        private const string ResourceTypeName = "Microsoft.Storage/storageAccounts";
        // https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Azure.ResourceManager.Storage/src/Generated/RestOperations/BlobContainersRestOperations.cs#L36
        internal const string DefaultVersion = "2022-09-01";

        private static StorageAccountData Empty(string name) => ArmStorageModelFactory.StorageAccountData();

        /// <summary>
        /// Initializes a new instance of the <see cref="StorageAccount"/>.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="kind">The kind.</param>
        /// <param name="sku">The sku.</param>
        /// <param name="parent">The parent.</param>
        /// <param name="name">The name.</param>
        /// <param name="version">The version.</param>
        public StorageAccount(IConstruct scope, StorageKind kind, StorageSkuName sku, ResourceGroup? parent = null, string name = "sa", string version = DefaultVersion)
            : this(scope, parent, name, version, (name) => ArmStorageModelFactory.StorageAccountData(
                name: name,
                resourceType: ResourceTypeName,
                location: Environment.GetEnvironmentVariable("AZURE_LOCATION") ?? AzureLocation.WestUS,
                sku: new StorageSku(sku),
                kind: kind,
                // access tier cannot be set for premium accounts
                accessTier: kind == StorageKind.BlobStorage || kind == StorageKind.StorageV2 ? StorageAccountAccessTier.Hot : null))
        {
            AssignProperty(data => data.Name, GetAzureName(scope, name));
        }

        private StorageAccount(IConstruct scope,
            ResourceGroup? parent,
            string name,
            string version = DefaultVersion,
            Func<string, StorageAccountData>? creator = null,
            bool isExisting = false)
            : base(scope, parent, name, ResourceTypeName, version, creator ?? Empty, isExisting)
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="StorageAccount"/> class referencing an existing instance.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="name">The resource name.</param>
        /// <param name="parent">The resource group.</param>
        /// <returns>The KeyVault instance.</returns>
        public static StorageAccount FromExisting(IConstruct scope, string name, ResourceGroup? parent = null)
            => new StorageAccount(scope, parent: parent, name: name, isExisting: true);

        /// <inheritdoc/>
        protected override string GetAzureName(IConstruct scope, string resourceName) => GetGloballyUniqueName(resourceName);
    }
}
