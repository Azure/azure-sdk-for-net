﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.DataMovement;
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.DataMovement.Blobs
{
    /// <summary>
    /// The Storage Resource class for the Blob Virtual Directory Client.
    /// </summary>
    public class BlobDirectoryStorageResourceContainer : StorageResourceContainer
    {
        private BlobContainerClient _blobContainerClient;
        private string _directoryPrefix;
        private BlobStorageResourceContainerOptions _options;

        /// <summary>
        /// Defines whether the storage resource type can produce a URL.
        /// </summary>
        public override ProduceUriType CanProduceUri => ProduceUriType.ProducesUri;

        /// <summary>
        /// Gets the path of the storage resource.
        /// </summary>
        public override string Path => _directoryPrefix;

        internal Uri _uri;

        /// <summary>
        /// Gets the URL of the storage resource.
        /// </summary>
        public override Uri Uri => _uri;

        /// <summary>
        /// The constructor to create an instance of the BlobDirectoryStorageResourceContainer.
        ///
        /// Listing is a container level operation, which is why the constructor
        /// accepts a container client rather than a base blob client.
        /// </summary>
        /// <param name="containerClient">
        /// The blob client which represents the virtual blob directory
        /// to perform the transfer source or destination.
        /// </param>
        /// <param name="directoryPrefix">
        /// The directory path of the blob virtual directory.
        /// </param>
        /// <param name="options">Options for the storage resource. See <see cref="BlobStorageResourceContainerOptions"/>.</param>
        public BlobDirectoryStorageResourceContainer(
            BlobContainerClient containerClient,
            string directoryPrefix,
            BlobStorageResourceContainerOptions options = default)
        {
            Argument.AssertNotNull(containerClient, nameof(BlobContainerClient));
            Argument.AssertNotNullOrEmpty(directoryPrefix, nameof(directoryPrefix));
            _blobContainerClient = containerClient;
            _directoryPrefix = directoryPrefix;
            _options = options;

            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(_blobContainerClient.Uri);
            blobUriBuilder.BlobName = string.Join("/", _directoryPrefix);
            _uri = blobUriBuilder.ToUri();
        }

        /// <summary>
        /// Retrieves a single blob resource based on this respective resource.
        /// </summary>
        /// <param name="encodedPath">A path as it would appear in a request URI.</param>
        /// <returns>
        /// <see cref="StorageResource"/> which represents the child blob client of
        /// this respective blob virtual directory resource.
        /// </returns>
        public override StorageResource GetChildStorageResource(string encodedPath)
        {
            // Recreate the blobName using the existing parent directory path
            return new BlockBlobStorageResource(
                _blobContainerClient.GetBlockBlobClient(string.Concat(_directoryPrefix, "/", encodedPath)),
                new BlockBlobStorageResourceOptions()
                {
                    CopyOptions = _options?.CopyOptions,
                    UploadOptions = _options?.UploadOptions,
                    DownloadOptions = _options?.DownloadOptions,
                }); ;
        }

        /// <summary>
        /// Retrieves a single blob resource based on this respective resource.
        /// </summary>
        /// <param name="encodedPath">A path as it would appear in a request URI.</param>
        /// <param name="type">The type of <see cref="BlobType"/> that the storage resource is.</param>
        /// <returns>
        /// <see cref="StorageResource"/> which represents the child blob client of
        /// this respective blob virtual directory resource.
        /// </returns>
        internal StorageResource GetChildStorageResource(string encodedPath, BlobType type = BlobType.Block)
        {
            // Recreate the blobName using the existing parent directory path
            if (type == BlobType.Append)
            {
                AppendBlobClient client = _blobContainerClient.GetAppendBlobClient(encodedPath);
                return new AppendBlobStorageResource(
                    client,
                    new AppendBlobStorageResourceOptions()
                    {
                        // TODO: change options bag to be applicable to child resources
                        CopyOptions = new AppendBlobStorageResourceServiceCopyOptions()
                        {
                            CopyMethod = (TransferCopyMethod) _options?.CopyOptions?.CopyMethod,
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
                    new BlockBlobStorageResourceOptions()
                    {
                        CopyOptions = _options?.CopyOptions,
                        UploadOptions = _options?.UploadOptions,
                        DownloadOptions = _options?.DownloadOptions,
                    });
            }
        }

        /// <summary>
        /// Retrieves a directory blob resource based on this respective resource.
        /// </summary>
        /// <returns>An instance of <see cref="StorageResourceContainer"/>.</returns>
        public override StorageResourceContainer GetParentStorageResourceContainer()
        {
            // TODO: if there's no parent directory, that means we should return the BlobStorageResourceContainer instead
            // Recreate the blobName using the existing parent directory path
            int delimiter = _directoryPrefix.LastIndexOf('/');
            if (delimiter > -1)
            {
                return new BlobDirectoryStorageResourceContainer(_blobContainerClient, _directoryPrefix.Substring(0, delimiter));
            }
            else
            {
                return new BlobStorageResourceContainer(_blobContainerClient);
            }
        }

        /// <summary>
        /// Retrieves a directory blob resource based on this respective resource.
        /// </summary>
        /// <returns>An instance of <see cref="StorageResourceContainer"/>.</returns>
        internal StorageResourceContainer GetStorageResourceParentContainer()
        {
            // Recreate the blobName using the existing parent directory path
            return new BlobStorageResourceContainer(_blobContainerClient);
        }

        /// <summary>
        /// Lists the child paths in the storage resource.
        /// </summary>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>List of the child resources in the storage container.</returns>
        public override async IAsyncEnumerable<StorageResourceBase> GetStorageResourcesAsync(
            [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            AsyncPageable<BlobItem> pages = _blobContainerClient.GetBlobsAsync(
                prefix: string.Join("/", _directoryPrefix),
                cancellationToken: cancellationToken);
            await foreach (BlobItem blobItem in pages.ConfigureAwait(false))
            {
                yield return GetChildStorageResource(
                    blobItem.Name,
                    blobItem.Properties.BlobType.HasValue ? blobItem.Properties.BlobType.Value : BlobType.Block);
            }
        }
    }
}
