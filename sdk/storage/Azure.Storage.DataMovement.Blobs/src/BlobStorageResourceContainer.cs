// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;

namespace Azure.Storage.DataMovement.Blobs
{
    /// <summary>
    /// The Storage Resource class for the Blob Client. Supports blob prefix directories as well as the root container.
    /// </summary>
    public class BlobStorageResourceContainer : StorageResourceContainer
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
        protected override StorageResourceItem GetStorageResourceReference(string path)
            => GetBlobAsStorageResource(ApplyOptionalPrefix(path), type: _options?.BlobType ?? BlobType.Block);

        /// <summary>
        /// Retrieves a single blob resource based on this respective resource.
        /// </summary>
        /// <param name="blobName">Full path to the blob in flat namespace.</param>
        /// <param name="length">The content length of the blob.</param>
        /// <param name="type">The type of <see cref="BlobType"/> that the storage resource is.</param>
        /// <param name="etagLock">Etag for the resource to lock on.</param>
        /// <returns>
        /// <see cref="StorageResourceItem"/> which represents the child blob client of
        /// this respective blob virtual directory resource.
        /// </returns>
        private StorageResourceItem GetBlobAsStorageResource(
            string blobName,
            long? length = default,
            BlobType type = BlobType.Block,
            ETag? etagLock = null)
        {
            // Recreate the blobName using the existing parent directory path
            if (type == BlobType.Append)
            {
                AppendBlobClient client = BlobContainerClient.GetAppendBlobClient(blobName);
                return new AppendBlobStorageResource(
                    client,
                    length,
                    etagLock,
                    _options.ToAppendBlobStorageResourceOptions());
            }
            else if (type == BlobType.Page)
            {
                PageBlobClient client = BlobContainerClient.GetPageBlobClient(blobName);
                return new PageBlobStorageResource(
                    client,
                    length,
                    etagLock,
                    _options.ToPageBlobStorageResourceOptions());
            }
            else // (type == BlobType.Block)
            {
                BlockBlobClient client = BlobContainerClient.GetBlockBlobClient(blobName);
                return new BlockBlobStorageResource(
                    client,
                    length,
                    etagLock,
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
            [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            AsyncPageable<BlobItem> pages = BlobContainerClient.GetBlobsAsync(
                prefix: DirectoryPrefix,
                cancellationToken: cancellationToken);
            await foreach (BlobItem blobItem in pages.ConfigureAwait(false))
            {
                yield return GetBlobAsStorageResource(
                    blobItem.Name,
                    blobItem.Properties.ContentLength,
                    blobItem.Properties.BlobType.HasValue ? blobItem.Properties.BlobType.Value : BlobType.Block,
                    blobItem.Properties.ETag);
            }
        }

        private string ApplyOptionalPrefix(string path)
            => IsDirectory
                ? string.Join("/", DirectoryPrefix, path)
                : path;
    }
}
