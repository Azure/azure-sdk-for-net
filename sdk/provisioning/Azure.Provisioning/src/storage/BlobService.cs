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

        private static string GetName(IConstruct scope, string? name)
        {
            return $"{name}-{scope.EnvironmentName}";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobService"/>.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="name">The name.</param>
        public BlobService(IConstruct scope, string name = "blob")
            : base(scope, null, GetName(scope, name), ResourceTypeName, "2022-09-01", ArmStorageModelFactory.BlobServiceData(
                name: GetName(scope, name),
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
