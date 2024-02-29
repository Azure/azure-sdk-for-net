// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
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
        private const string ResourceTypeName = "Microsoft.Storage/storageAccounts";

        /// <summary>
        /// Initializes a new instance of the <see cref="StorageAccount"/>.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="kind">The kind.</param>
        /// <param name="sku">The sku.</param>
        /// <param name="parent">The parent.</param>
        /// <param name="name">The name.</param>
        public StorageAccount(IConstruct scope, StorageKind kind, StorageSkuName sku, ResourceGroup? parent = null, string name = "sa")
            : base(scope, parent, name, ResourceTypeName, "2022-09-01", (name) => ArmStorageModelFactory.StorageAccountData(
                name: name,
                resourceType: ResourceTypeName,
                location: Environment.GetEnvironmentVariable("AZURE_LOCATION") ?? AzureLocation.WestUS,
                sku: new StorageSku(sku),
                kind: StorageKind.StorageV2))
        {
            AssignProperty(data => data.Name, $"toLower(take(concat('{name}', uniqueString(resourceGroup().id)), 24))");
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
        protected override string GetAzureName(IConstruct scope, string resourceName)
        {
            var span = resourceName.AsSpan();
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < span.Length; i++)
            {
                char c = span[i];
                if (!char.IsLetterOrDigit(c))
                {
                    continue;
                }
                if (char.IsLetter(c))
                {
                    stringBuilder.Append(char.ToLowerInvariant(c));
                }
                else
                {
                    stringBuilder.Append(c);
                }
            }
            stringBuilder.Append(Guid.NewGuid().ToString("N"));

            return stringBuilder.ToString(0, Math.Min(stringBuilder.Length, 24));
        }
    }
}
