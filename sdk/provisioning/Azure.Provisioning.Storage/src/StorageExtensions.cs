// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.ResourceManager;
using Azure.ResourceManager.Storage.Models;

namespace Azure.Provisioning.Storage
{
    /// <summary>
    /// Extension methods for <see cref="IConstruct"/>.
    /// </summary>
    public static class StorageExtensions
    {
        /// <summary>
        /// Adds a <see cref="StorageAccount"/> to the construct.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="kind">The kind.</param>
        /// <param name="sku">The sku.</param>
        /// <param name="parent">The parent.</param>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public static StorageAccount AddStorageAccount(this IConstruct scope, StorageKind kind, StorageSkuName sku, ResourceGroup? parent = null, string name = "sa")
        {
            return new StorageAccount(scope, kind, sku, parent, name);
        }

        /// <summary>
        /// Adds a <see cref="BlobService"/> to the construct.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <returns></returns>
        public static BlobService AddBlobService(this IConstruct scope)
        {
            return new BlobService(scope);
        }
    }
}
