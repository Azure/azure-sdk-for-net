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
    public class BlobStorageResourceContainer : StorageResourceContainer
    {
        private BlobContainerClient _blobContainerClient;
        private string _directoryPrefix;
        private BlobStorageResourceContainerOptions _options;

        private bool IsDirectory => _directoryPrefix != null;

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
            _directoryPrefix = _options?.DirectoryPrefix;

            Uri = _directoryPrefix != null
                ? new BlobUriBuilder(_blobContainerClient.Uri)
                {
                    BlobName = _directoryPrefix,
                }.ToUri()
                : _blobContainerClient.Uri;
        }

        /// <summary>
        /// Defines whether the storage resource type can produce a URL.
        /// </summary>
        public override ProduceUriType CanProduceUri => ProduceUriType.ProducesUri;

        /// <summary>
        /// Gets the path of the storage resource.
        /// Return empty string since we are using the root of the container.
        /// </summary>
        public override string Path => _directoryPrefix ?? string.Empty;

        /// <summary>
        /// Gets the URL of the storage resource.
        /// </summary>
        public override Uri Uri { get; }

        /// <summary>
        /// Retrieves a single blob resource based on this respective resource.
        /// </summary>
        /// <param name="path">The path to the storage resource, relative to the directory prefix if any.</param>
        public override StorageResource GetChildStorageResource(string path)
            => GetBlobAsStorageResource(ApplyOptionalPrefix(path), type: _options?.BlobType ?? BlobType.Block);

        /// <summary>
        /// Retrieves a single blob resource based on this respective resource.
        /// </summary>
        /// <param name="blobName">Full path to the blob in flat namespace.</param>
        /// <param name="length">The content length of the blob.</param>
        /// <param name="type">The type of <see cref="BlobType"/> that the storage resource is.</param>
        /// <returns>
        /// <see cref="StorageResource"/> which represents the child blob client of
        /// this respective blob virtual directory resource.
        /// </returns>
        private StorageResource GetBlobAsStorageResource(string blobName, long? length = default, BlobType type = BlobType.Block)
        {
            // Recreate the blobName using the existing parent directory path
            if (type == BlobType.Append)
            {
                AppendBlobClient client = _blobContainerClient.GetAppendBlobClient(blobName);
                return new AppendBlobStorageResource(
                    client,
                    length,
                    _options.ToAppendBlobStorageResourceOptions());
            }
            else if (type == BlobType.Page)
            {
                PageBlobClient client = _blobContainerClient.GetPageBlobClient(blobName);
                return new PageBlobStorageResource(
                    client,
                    length,
                    _options.ToPageBlobStorageResourceOptions());
            }
            else // (type == BlobType.Block)
            {
                BlockBlobClient client = _blobContainerClient.GetBlockBlobClient(blobName);
                return new BlockBlobStorageResource(
                    client,
                    length,
                    _options.ToBlockBlobStorageResourceOptions());
            }
        }

        /// <summary>
        /// Gets the parent container resource for this container resource. The parent container
        /// can represent either a directory prefix or the blob container itself.
        /// </summary>
        /// <returns>
        /// The parent resource container.
        /// </returns>
        /// <exception cref="NotSupportedException">
        /// A container resource that represents the blob container itself has no parent.
        /// </exception>
        public override StorageResourceContainer GetParentStorageResourceContainer()
        {
            // TODO: should this throw? Perhaps we return null or refactor base class for a try pattern.
            if (!IsDirectory)
            {
                throw new NotSupportedException();
            }

            // TODO: if there's no parent directory, that means we should return the BlobStorageResourceContainer instead
            // Recreate the blobName using the existing parent directory path
            int delimiter = _directoryPrefix.LastIndexOf('/');
            if (delimiter > -1)
            {
                return new BlobStorageResourceContainer(_blobContainerClient, new BlobStorageResourceContainerOptions
                {
                    DirectoryPrefix = _directoryPrefix.Substring(0, delimiter)
                });
            }
            else
            {
                return new BlobStorageResourceContainer(_blobContainerClient);
            }
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
                prefix: _directoryPrefix,
                cancellationToken: cancellationToken);
            await foreach (BlobItem blobItem in pages.ConfigureAwait(false))
            {
                yield return GetBlobAsStorageResource(
                    blobItem.Name,
                    blobItem.Properties.ContentLength,
                    blobItem.Properties.BlobType.HasValue ? blobItem.Properties.BlobType.Value : BlobType.Block);
            }
        }

        private string ApplyOptionalPrefix(string path)
            => IsDirectory
                ? string.Join("/", _directoryPrefix, path)
                : path;
    }
}
