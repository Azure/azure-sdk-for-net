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
        private static BlobServiceData Empty(string name) => ArmStorageModelFactory.BlobServiceData();

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobService"/>.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="parent">The parent.</param>
        /// <param name="version">The version.</param>
        public BlobService(IConstruct scope, StorageAccount? parent = null, string version = StorageAccount.DefaultVersion)
            : this(scope, parent, "default", version, (name) => ArmStorageModelFactory.BlobServiceData(
                name: name,
                resourceType: ResourceTypeName))
        {
        }

        private BlobService(IConstruct scope,
            StorageAccount? parent,
            string name,
            string version = StorageAccount.DefaultVersion,
            Func<string, BlobServiceData>? creator = null,
            bool isExisting = false)
            : base(scope, parent, name, ResourceTypeName, version, creator ?? Empty, isExisting)
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="BlobService"/> class referencing an existing instance.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="name">The resource name.</param>
        /// <param name="parent">The resource group.</param>
        /// <returns>The BlobService instance.</returns>
        public static BlobService FromExisting(IConstruct scope, string name, StorageAccount parent)
            => new BlobService(scope, parent: parent, name: name, isExisting: true);

        /// <inheritdoc/>
        protected override Resource? FindParentInScope(IConstruct scope)
        {
            return scope.GetSingleResource<StorageAccount>() ?? new StorageAccount(scope, StorageKind.BlockBlobStorage, StorageSkuName.PremiumLrs);
        }
    }
}
