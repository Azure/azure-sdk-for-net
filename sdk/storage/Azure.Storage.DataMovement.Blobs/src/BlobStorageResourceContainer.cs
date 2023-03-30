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
    /// The Storage Resource class for the Blob Client. Directories are not supported
    /// as blobs only support a flat namespace structure. See <see cref="BlobDirectoryStorageResourceContainer"/>
    /// for directory support.
    /// </summary>
    public class BlobStorageResourceContainer : StorageResourceContainer
    {
        private BlobContainerClient _blobContainerClient;
        private BlobStorageResourceContainerOptions _options;

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
            _blobContainerClient = blobContainerClient;
            _options = options;
        }

        /// <summary>
        /// Defines whether the storage resource type can produce a URL.
        /// </summary>
        public override ProduceUriType CanProduceUri => ProduceUriType.ProducesUri;

        /// <summary>
        /// Gets the path of the storage resource.
        /// </summary>
        public override string Path => _blobContainerClient.Name;

        /// <summary>
        /// Gets the URL of the storage resource.
        /// </summary>
        public override Uri Uri => _blobContainerClient.Uri;

        /// <summary>
        /// Retrieves a single blob resource based on this respective resource.
        /// </summary>
        /// <param name="path">The path to the storage resource.</param>
        public override StorageResource GetChildStorageResource(string path)
        {
            if (_options?.BlobType == BlobType.Append)
            {
                return new AppendBlobStorageResource(
                    _blobContainerClient.GetAppendBlobClient(string.Join("/", path)),
                    _options?.ToAppendBlobStorageResourceOptions());
            }
            else if (_options?.BlobType == BlobType.Page)
            {
                return new PageBlobStorageResource(
                    _blobContainerClient.GetPageBlobClient(string.Join("/", path)),
                    _options?.ToPageBlobStorageResourceOptions());
            }
            else // BlobType.Block or null
            {
                return new BlockBlobStorageResource(
                    _blobContainerClient.GetBlockBlobClient(string.Join("/", path)),
                    _options?.ToBlockBlobStorageResourceOptions());
            }
        }

        /// <summary>
        /// Retrieves a single blob resource based on this respective resource.
        /// </summary>
        /// <param name="path">A path as it would appear in a request URI.</param>
        /// <param name="length">The content length of the blob.</param>
        /// <param name="type">The type of <see cref="BlobType"/> that the storage resource is.</param>
        /// <returns>
        /// <see cref="StorageResource"/> which represents the child blob client of
        /// this respective blob virtual directory resource.
        /// </returns>
        internal StorageResource GetChildStorageResource(string path, long? length, BlobType type = BlobType.Block)
        {
            // Recreate the blobName using the existing parent directory path
            if (type == BlobType.Append)
            {
                AppendBlobClient client = _blobContainerClient.GetAppendBlobClient(path);
                return new AppendBlobStorageResource(
                    client,
                    length,
                    _options.ToAppendBlobStorageResourceOptions());
                ;
            }
            else if (type == BlobType.Page)
            {
                PageBlobClient client = _blobContainerClient.GetPageBlobClient(path);
                return new PageBlobStorageResource(
                    client,
                    length,
                    _options.ToPageBlobStorageResourceOptions());
            }
            else // (type == BlobType.Block)
            {
                BlockBlobClient client = _blobContainerClient.GetBlockBlobClient(path);
                return new BlockBlobStorageResource(
                    client,
                    length,
                    _options.ToBlockBlobStorageResourceOptions());
            }
        }

        /// <summary>
        /// Will throw an NotSupported exception because Blob container is considered the root level.
        /// </summary>
        /// <returns></returns>
        public override StorageResourceContainer GetParentStorageResourceContainer()
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Lists the blob resources in the storage blob container.
        ///
        /// Because blobs is a flat namespace, virtual directories will not be returned.
        /// </summary>
        /// <returns>List of the child resources in the storage container.</returns>
        public override async IAsyncEnumerable<StorageResourceBase> GetStorageResourcesAsync(
            [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            AsyncPageable<BlobItem> pages = _blobContainerClient.GetBlobsAsync(
                cancellationToken: cancellationToken);
            await foreach (BlobItem blobItem in pages.ConfigureAwait(false))
            {
                yield return GetChildStorageResource(
                    blobItem.Name,
                    blobItem.Properties.ContentLength,
                    blobItem.Properties.BlobType.HasValue ? blobItem.Properties.BlobType.Value : BlobType.Block);
            }
        }
    }
}
