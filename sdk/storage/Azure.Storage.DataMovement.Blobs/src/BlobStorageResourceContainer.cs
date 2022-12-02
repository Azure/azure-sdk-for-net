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
    /// Blob Container Resource (no directories because of the flat namespace)
    /// </summary>
    public class BlobStorageResourceContainer : StorageResourceContainer
    {
        private BlobContainerClient _blobContainerClient;
        private BlobStorageResourceContainerOptions _options;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="blobContainerClient"></param>
        /// <param name="options"></param>
        public BlobStorageResourceContainer(BlobContainerClient blobContainerClient, BlobStorageResourceContainerOptions options = default)
        {
            _blobContainerClient = blobContainerClient;
            _options = options;
        }

        /// <summary>
        /// Can produce uri
        /// </summary>
        public override ProduceUriType CanProduceUri => ProduceUriType.ProducesUri;

        /// <summary>
        /// Returns the path
        /// </summary>
        public override string Path => _blobContainerClient.Name;

        /// <summary>
        /// Obtains the Uri of the blob directory resource, which means we can list
        /// </summary>
        public override Uri Uri => _blobContainerClient.Uri;

        /// <summary>
        /// Creates new blob client based on the parent container client
        /// </summary>
        /// <param name="path"></param>
        public override StorageResource GetChildStorageResource(string path)
        {
            return new BlockBlobStorageResource(_blobContainerClient.GetBlockBlobClient(string.Join("/", path)));
        }

        /// <summary>
        /// Retrieves a single blob resoruce based on this respective resource.
        /// </summary>
        /// <param name="encodedPath"></param>
        /// <param name="length"></param>
        /// <param name="type"></param>
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
        /// Will throw because Blob container is considered root level.
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
