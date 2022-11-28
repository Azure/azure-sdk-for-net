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
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.DataMovement;
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.DataMovement.Blobs
{
    /// <summary>
    /// Blob Container Resource (no directories because of the flat namespace)
    /// </summary>
    internal class BlobStorageResourceContainer : StorageResourceContainer
    {
        private BlobContainerClient _blobContainerClient;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="blobContainerClient"></param>
        public BlobStorageResourceContainer(BlobContainerClient blobContainerClient)
        {
            _blobContainerClient = blobContainerClient;
        }

        /// <summary>
        /// Can produce uri
        /// </summary>
        /// <returns></returns>
        public override ProduceUriType CanProduceUri => ProduceUriType.ProducesUri;

        /// <summary>
        /// Returns the path
        /// </summary>
        /// <returns></returns>
        public override string Path => _blobContainerClient.Name;

        /// <summary>
        /// Obtains the Uri of the blob directory resource, which means we can list
        /// </summary>
        /// <returns></returns>
        public override Uri Uri => _blobContainerClient.Uri;

        /// <summary>
        /// Creates new blob client based on the parent container client
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public override StorageResource GetChildStorageResource(string path)
        {
            return new BlockBlobStorageResource(_blobContainerClient.GetBlockBlobClient(string.Join("/", path)));
        }

        /// <summary>
        /// Not supported
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
                yield return GetChildStorageResource(blobItem.Name);
            }
        }
    }
}
