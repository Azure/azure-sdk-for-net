// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.ResourceManager.Storage;
using Azure.ResourceManager.Storage.Models;

namespace Azure.Provisioning.Storage
{
    /// <summary>
    /// Represents a file service.
    /// </summary>
    public class FileService : Resource<FileServiceData>
    {
        private static FileServiceData Empty(string name) => ArmStorageModelFactory.FileServiceData();

        /// <summary>
        /// Initializes a new instance of the <see cref="FileService"/>.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="parent">The parent.</param>
        /// <param name="version">The version.</param>
        public FileService(IConstruct scope, StorageAccount? parent = null, string version = StorageAccount.DefaultVersion)
            : this(scope, parent, "default", version, (name) => ArmStorageModelFactory.FileServiceData(
                name: name,
                resourceType: FileServiceResource.ResourceType))
        {
        }

        private FileService(IConstruct scope,
            StorageAccount? parent,
            string name,
            string version = StorageAccount.DefaultVersion,
            Func<string, FileServiceData>? creator = null,
            bool isExisting = false)
            : base(scope, parent, name, FileServiceResource.ResourceType, version, creator ?? Empty, isExisting)
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="FileService"/> class referencing an existing instance.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="name">The resource name.</param>
        /// <param name="parent">The resource group.</param>
        /// <returns>The FileService instance.</returns>
        public static FileService FromExisting(IConstruct scope, string name, StorageAccount parent)
            => new FileService(scope, parent: parent, name: name, isExisting: true);

        /// <inheritdoc/>
        protected override Resource? FindParentInScope(IConstruct scope)
        {
            return scope.GetSingleResource<StorageAccount>() ?? new StorageAccount(scope, StorageKind.FileStorage, StorageSkuName.PremiumLrs);
        }
    }
}
