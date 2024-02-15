// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobService"/>.
        /// </summary>
        /// <param name="scope">The scope.</param>
        public BlobService(IConstruct scope)
            : base(scope, null, "default", ResourceTypeName, "2022-09-01", ArmStorageModelFactory.BlobServiceData(
                name: "default",
                resourceType: ResourceTypeName))
        {
        }

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
