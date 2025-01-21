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
            DirectoryPrefix = _options?.BlobDirectoryPrefix;

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

        /// <summary>
        /// Lists the blob resources in the storage blob container.
        ///
        /// Because blobs is a flat namespace, virtual directories will not be returned.
        /// </summary>
        /// <returns>List of the child resources in the storage container.</returns>
        protected override async IAsyncEnumerable<StorageResource> GetStorageResourcesAsync(
            StorageResourceContainer destinationContainer = default,
            [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            // Suffix the backwards slash when searching if there's a prefix specified,
            // to only list blobs in the specified virtual directory.
            string fullPrefix = string.IsNullOrEmpty(DirectoryPrefix) ?
                "" :
                string.Concat(DirectoryPrefix, Constants.PathBackSlashDelimiter);

            AsyncPageable<BlobItem> pages = BlobContainerClient.GetBlobsAsync(
                traits: BlobTraits.Metadata,
                prefix: fullPrefix,
                cancellationToken: cancellationToken);

            HashSet<string> subDirectories = new HashSet<string>();
            await foreach (BlobItem blobItem in pages.ConfigureAwait(false))
            {
                // List blob / GetBlobs will always return blob names with the source prefix with them
                // Trim the blob name of the source prefix
                string relativePath = blobItem.Name.Substring(fullPrefix.Length);

                // Remove known prefix from blob name
                // Parse subdirectories
                string[] paths = relativePath.Split(DataMovementConstants.PathForwardSlashDelimiterChar);
                string currentPath = "";

                // Since the last path will always be the blob name, leave out the last one.
                for (int i = 0; i < paths.Length - 1; i++)
                {
                    // Combine the parent path with the next child path
                    if (string.IsNullOrEmpty(currentPath))
                    {
                        currentPath = paths[i];
                    }
                    else
                    {
                        currentPath = string.Join(Constants.PathBackSlashDelimiter, currentPath, paths[i]);
                    }

                    if (!subDirectories.Contains(currentPath))
                    {
                        subDirectories.Add(currentPath);
                        // Return the blob virtual directory as a StorageResourceContainer
                        yield return GetChildStorageResourceContainer(currentPath);
                    }
                }

                // Return the blob as a StorageResourceItem
                yield return GetBlobAsStorageResource(
                    blobItem.Name,
                    blobItem.Properties.BlobType.HasValue ? blobItem.Properties.BlobType.Value : BlobType.Block,
                    blobItem.ToResourceProperties());
            }
        }

        protected override StorageResourceCheckpointDetails GetSourceCheckpointDetails()
        {
            // Source blob type does not matter for container
            return new BlobSourceCheckpointDetails();
        }

        protected override StorageResourceCheckpointDetails GetDestinationCheckpointDetails()
            => new BlobDestinationCheckpointDetails(_options);

        private string ApplyOptionalPrefix(string path)
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
            options.BlobDirectoryPrefix = string.Join("/", DirectoryPrefix, path);
            return new BlobStorageResourceContainer(
                BlobContainerClient,
                options);
        }
    }
}
