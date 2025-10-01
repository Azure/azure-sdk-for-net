// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;

namespace Azure.Storage.DataMovement.Blobs
{
    /// <summary>
    /// The Storage Resource class for the Blob Client. Supports blob prefix directories as well as the root container.
    /// </summary>
    internal class BlobStorageResourceContainer : StorageResourceContainerInternal
    {
        internal BlobContainerClient BlobContainerClient { get; }
        internal string DirectoryPrefix { get; }
        private BlobStorageResourceContainerOptions _options;
        private Uri _uri;

        private bool IsDirectory => DirectoryPrefix != null;

        /// <summary>
        /// Gets Uri of the Storage Resource.
        /// </summary>
        public override Uri Uri => _uri;

        public override string ProviderId => "blob";

        /// <summary>
        /// For mocking.
        /// </summary>
        protected BlobStorageResourceContainer()
        {
        }

        /// <summary>
        /// The constructor to create an instance of the BlobStorageResourceContainer.
        /// </summary>
        /// <param name="blobContainerClient">
        /// The blob client which represents the storage container
        /// to perform the transfer source or destination.
        /// </param>
        /// <param name="options">Options for the storage resource. See <see cref="BlobStorageResourceContainerOptions"/>.</param>
        public BlobStorageResourceContainer(BlobContainerClient blobContainerClient, BlobStorageResourceContainerOptions options = default)
        {
            BlobContainerClient = blobContainerClient;
            _options = options;
            DirectoryPrefix = _options?.BlobPrefix;

            _uri = DirectoryPrefix != null
                ? new BlobUriBuilder(BlobContainerClient.Uri)
                {
                    BlobName = DirectoryPrefix,
                }.ToUri()
                : BlobContainerClient.Uri;
        }

        /// <summary>
        /// Retrieves a single blob resource based on this respective resource.
        /// </summary>
        /// <param name="path">The path to the storage resource, relative to the directory prefix if any.</param>
        /// <param name="resourceId">Defines the resource id type.</param>
        protected override StorageResourceItem GetStorageResourceReference(string path, string resourceId)
        {
            BlobType type = BlobType.Block;
            if (_options == default || !_options._isBlobTypeSet)
            {
                type = ToBlobType(resourceId);
            }
            else
            {
                // If the user has set the blob type in the options, use that instead of the resourceId
                type = _options?.BlobType ?? BlobType.Block;
            }
            return GetBlobAsStorageResource(ApplyOptionalPrefix(path), type: type);
        }

        private BlobType ToBlobType(string resourceId)
        {
            if (string.IsNullOrEmpty(resourceId))
            {
                return BlobType.Block;
            }

            if (DataMovementBlobConstants.ResourceId.BlockBlob.Equals(resourceId))
            {
                return BlobType.Block;
            }
            else if (DataMovementBlobConstants.ResourceId.PageBlob.Equals(resourceId))
            {
                return BlobType.Page;
            }
            else if (DataMovementBlobConstants.ResourceId.AppendBlob.Equals(resourceId))
            {
                return BlobType.Append;
            }
            else
            {
                // By default, return BlockBlob for other resource types (e.g. ShareFile, local file)
                // when we call GetStorageResourceReference we will check the options bag if they manually
                // set the blob type.
                return BlobType.Block;
            }
        }

        /// <summary>
        /// Retrieves a single blob resource based on this respective resource.
        /// </summary>
        /// <param name="blobName">Full path to the blob in flat namespace.</param>
        /// <param name="type">The type of <see cref="BlobType"/> that the storage resource is.</param>
        /// <param name="resourceProperties">The properties for the storage resource.</param>
        /// <returns>
        /// <see cref="StorageResourceItem"/> which represents the child blob client of
        /// this respective blob virtual directory resource.
        /// </returns>
        private StorageResourceItem GetBlobAsStorageResource(
            string blobName,
            BlobType type = BlobType.Block,
            StorageResourceItemProperties resourceProperties = default)
        {
            // Recreate the blobName using the existing parent directory path
            if (type == BlobType.Append)
            {
                AppendBlobClient client = BlobContainerClient.GetAppendBlobClient(blobName);
                return new AppendBlobStorageResource(
                    client,
                    resourceProperties,
                    _options.ToAppendBlobStorageResourceOptions());
            }
            else if (type == BlobType.Page)
            {
                PageBlobClient client = BlobContainerClient.GetPageBlobClient(blobName);
                return new PageBlobStorageResource(
                    client,
                    resourceProperties,
                    _options.ToPageBlobStorageResourceOptions());
            }
            else // (type == BlobType.Block)
            {
                BlockBlobClient client = BlobContainerClient.GetBlockBlobClient(blobName);
                return new BlockBlobStorageResource(
                    client,
                    resourceProperties,
                    _options.ToBlockBlobStorageResourceOptions());
            }
        }

        protected override async IAsyncEnumerable<StorageResource> GetStorageResourcesAsync(
            StorageResourceContainer destinationContainer = default,
            [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            // Suffix the slash when searching if there's a prefix specified,
            // to only list blobs in the specified virtual directory.
            string sourcePrefix = string.IsNullOrEmpty(DirectoryPrefix) ?
                "" :
                string.Concat(DirectoryPrefix, Constants.PathBackSlashDelimiter);

            Queue<string> paths = new();
            paths.Enqueue(sourcePrefix); // Start with the initial prefix

            while (paths.Count > 0)
            {
                string currentPath = paths.Dequeue();

                int childCount = 0;
                await foreach (BlobHierarchyItem blobHierarchyItem in BlobContainerClient.GetBlobsByHierarchyAsync(
                    traits: BlobTraits.Metadata,
                    prefix: currentPath,
                    delimiter: Constants.PathBackSlashDelimiter,
                    cancellationToken: cancellationToken).ConfigureAwait(false))
                {
                    childCount++;
                    if (blobHierarchyItem.IsBlob)
                    {
                        // Return the blob as a StorageResourceItem
                        yield return GetBlobAsStorageResource(
                            blobHierarchyItem.Blob.Name,
                            blobHierarchyItem.Blob.Properties.BlobType ?? BlobType.Block,
                            blobHierarchyItem.Blob.ToResourceProperties());
                    }
                    else if (blobHierarchyItem.IsPrefix)
                    {
                        // Return the blob virtual directory as a StorageResourceContainer
                        yield return GetChildStorageResourceContainer(blobHierarchyItem.Prefix.Substring(sourcePrefix.Length));
                        // Enqueue the prefix for further traversal
                        paths.Enqueue(blobHierarchyItem.Prefix);
                    }
                }

                // Empty directory - This can only happen on HNS accounts as empty directories do not exist on FNS
                // accounts and will not show up as a prefix.
                //
                // If the destination is Blob, we need to manually create the empty directory here as the regular
                // path for creating directories is a no-op for Blob. This will always create an empty Block Blob
                // with the folder metadata set which represents a directory stub on HNS accounts. No other
                // properties will be copied from the source. We only do this for empty directories because non-empty
                // directories are created automatically.
                if (childCount == 0 &&
                    currentPath != sourcePrefix && // If doing an empty copy
                    destinationContainer is BlobStorageResourceContainer destBlobContainer)
                {
                    // Remove source prefix and add destination prefix
                    BlockBlobStorageResource destinationDirectoryResource = destBlobContainer.GetBlobAsStorageResource(
                        destBlobContainer.ApplyOptionalPrefix(currentPath.Substring(sourcePrefix.Length)),
                        BlobType.Block) as BlockBlobStorageResource;
                    await destinationDirectoryResource.CreateEmptyDirectoryStubAsync(cancellationToken).ConfigureAwait(false);
                }
            }
        }

        protected override StorageResourceCheckpointDetails GetSourceCheckpointDetails()
        {
            // Source blob type does not matter for container
            return new BlobSourceCheckpointDetails();
        }

        protected override StorageResourceCheckpointDetails GetDestinationCheckpointDetails()
            => new BlobDestinationCheckpointDetails(_options);

        internal string ApplyOptionalPrefix(string path)
            => IsDirectory
                ? string.Join("/", DirectoryPrefix, path)
                : path;

        // We will require containers to be created before the transfer starts
        // Since blobs is a flat namespace, we do not need to create directories (as they are virtual).
        protected override Task CreateIfNotExistsAsync(CancellationToken cancellationToken)
            => Task.CompletedTask;

        protected override StorageResourceContainer GetChildStorageResourceContainer(string path)
        {
            BlobStorageResourceContainerOptions options = _options.DeepCopy();
            options.BlobPrefix = string.Join("/", DirectoryPrefix, path);
            return new BlobStorageResourceContainer(
                BlobContainerClient,
                options);
        }

        protected override Task<StorageResourceContainerProperties> GetPropertiesAsync(CancellationToken cancellationToken = default)
        {
            // Not implemented for now
            return Task.FromResult(new StorageResourceContainerProperties());
        }
    }
}
