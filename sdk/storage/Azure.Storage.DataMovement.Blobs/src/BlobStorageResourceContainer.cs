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
using Azure.Storage.DataMovement.Models;

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
        /// Defines whether the storage resource type can produce a SAS URL.
        /// </summary>
        public override ProduceUriType CanProduceUri => ProduceUriType.ProducesUri;

        /// <summary>
        /// Gets the path of the storage resource.
        /// </summary>
        public override string Path => _blobContainerClient.Name;

        /// <summary>
        /// Gets the URL of the storage resource. If the URL can be obtained, this storage resource can be listed.
        /// </summary>
        public override Uri Uri => _blobContainerClient.Uri;

        /// <summary>
        /// Retrieves a single blob resource based on this respective resource.
        /// </summary>
        /// <param name="path">The path to the storage resource.</param>
        public override StorageResource GetChildStorageResource(string path)
        {
            return new BlockBlobStorageResource(_blobContainerClient.GetBlockBlobClient(string.Join("/", path)));
        }

        /// <summary>
        /// Retrieves a single blob resource based on this respective resource.
        /// </summary>
        /// <param name="encodedPath">A URL-encoded path as it would appear in a request URI.</param>
        /// <param name="length">The content length of the blob.</param>
        /// <param name="type">The type of <see cref="BlobType"/> that the storage resource is.</param>
        /// <returns>
        /// <see cref="StorageResource"/> which represents the child blob client of
        /// this respective blob virtual directory resource.
        /// </returns>
        internal StorageResource GetChildStorageResource(string encodedPath, long? length, BlobType type = BlobType.Block)
        {
            // Recreate the blobName using the existing parent directory path
            if (type == BlobType.Append)
            {
                AppendBlobClient client = _blobContainerClient.GetAppendBlobClient(encodedPath);
                return new AppendBlobStorageResource(
                    client,
                    length,
                    new AppendBlobStorageResourceOptions()
                    {
                        // TODO: change options bag to be applicable to child resources
                        CopyOptions = new AppendBlobStorageResourceServiceCopyOptions()
                        {
                            CopyMethod = (TransferCopyMethod)_options?.CopyOptions?.CopyMethod,
                        },
                        UploadOptions = new AppendBlobStorageResourceUploadOptions()
                        {
                            Conditions = new AppendBlobRequestConditions(),
                        },
                        DownloadOptions = new BlobStorageResourceDownloadOptions()
                        {
                            Conditions = _options?.UploadOptions?.Conditions,
                        }
                    });
            }
            else if (type == BlobType.Page)
            {
                PageBlobClient client = _blobContainerClient.GetPageBlobClient(encodedPath);
                return new PageBlobStorageResource(
                    client,
                    length,
                    new PageBlobStorageResourceOptions()
                    {
                        // TODO: change options bag to be applicable to child resources
                        CopyOptions = new PageBlobStorageResourceServiceCopyOptions()
                        {
                            CopyMethod = (TransferCopyMethod)_options?.CopyOptions?.CopyMethod,
                        },
                        UploadOptions = new PageBlobStorageResourceUploadOptions()
                        {
                            Conditions = new PageBlobRequestConditions(),
                        },
                        DownloadOptions = new BlobStorageResourceDownloadOptions()
                        {
                            Conditions = _options?.UploadOptions?.Conditions,
                        }
                    });
            }
            else // (type == BlobType.Block)
            {
                BlockBlobClient client = _blobContainerClient.GetBlockBlobClient(encodedPath);
                return new BlockBlobStorageResource(
                    client,
                    length,
                    new BlockBlobStorageResourceOptions()
                    {
                        CopyOptions = _options?.CopyOptions,
                        UploadOptions = _options?.UploadOptions,
                        DownloadOptions = _options?.DownloadOptions,
                    });
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
