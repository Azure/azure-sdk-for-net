// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.ResourceManager.Storage;
using Azure.ResourceManager.Storage.Models;

namespace Azure.Provisioning.Storage
{
    /// <summary>
    /// Represents a blob service.
    /// </summary>
    public class BlobService : Resource<BlobServiceData>
    {
        private const string ResourceTypeName = "Microsoft.Storage/storageAccounts/blobServices";
        private static readonly Func<string, BlobServiceData> Empty = (name) => ArmStorageModelFactory.BlobServiceData();

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobService"/>.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="parent">The parent.</param>
        public BlobService(IConstruct scope, StorageAccount? parent = null)
            : this(scope, parent, null, false, (name) => ArmStorageModelFactory.BlobServiceData(
                name: name ?? "default",
                resourceType: ResourceTypeName))
        {
        }

        private BlobService(IConstruct scope, StorageAccount? parent = null, string? name = null, bool isExisting = false, Func<string, BlobServiceData>? creator = null)
            : base(scope, parent, name ?? "default", ResourceTypeName, "2022-09-01", creator ?? Empty, isExisting)
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="BlobService"/> class referencing an existing instance.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="name">The resource name.</param>
        /// <param name="parent">The resource group.</param>
        /// <returns>The KeyVault instance.</returns>
        public static BlobService FromExisting(IConstruct scope, string name, StorageAccount parent)
            => new BlobService(scope, parent: parent, name: name, isExisting: true);

        /// <inheritdoc/>
        protected override Resource? FindParentInScope(IConstruct scope)
        {
            var result = base.FindParentInScope(scope);
            if (result is null)
            {
                result = scope.GetSingleResource<StorageAccount>() ?? new StorageAccount(scope, StorageKind.BlockBlobStorage, StorageSkuName.PremiumLrs);
            }
            return result;
        }
    }
}
