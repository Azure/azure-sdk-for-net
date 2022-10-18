// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.DataMovement;
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.Blobs.DataMovement
{
    /// <summary>
    /// Storage Resource class for the a Blob Virtual Directory Client
    /// </summary>
    public class BlobDirectoryStorageResourceContainer : StorageResourceContainer
    {
        private BlobContainerClient _blobContainerClient;
        private List<string> _directoryPrefix;

        /// <summary>
        /// Constructor for directory client.
        ///
        /// Listing is a container level operation, which is why the constructor
        /// accepts a container client rather than a base blob client.
        /// </summary>
        /// <param name="containerClient">
        /// The blob client which represents the virtual blob directory
        /// to perform the transfer source or destination.
        /// </param>
        /// <param name="directoryPrefix">
        /// The directory path of the blob virtual directory
        /// </param>
        public BlobDirectoryStorageResourceContainer(BlobContainerClient containerClient, string directoryPrefix)
        {
            Argument.AssertNotNull(containerClient, nameof(BlobContainerClient));
            Argument.AssertNotNullOrEmpty(directoryPrefix, nameof(directoryPrefix));
            _blobContainerClient = containerClient;
            _directoryPrefix = directoryPrefix.Split('/').ToList();
        }

        /// <summary>
        /// Constructor for directory client
        /// </summary>
        /// <param name="containerClient">
        /// The blob client which represents the virtual blob directory
        /// to perform the transfer source or destination.
        /// </param>
        /// <param name="directoryPrefix">
        /// The directory path of the blob virtual directory
        /// </param>
        public BlobDirectoryStorageResourceContainer(BlobContainerClient containerClient, List<string> directoryPrefix)
        {
            _blobContainerClient = containerClient;
            _directoryPrefix = directoryPrefix;
        }

        /// <summary>
        /// Can produce uri
        /// </summary>
        /// <returns></returns>
        public override ProduceUriType CanProduceUri()
        {
            return ProduceUriType.ProducesUri;
        }

        /// <summary>
        /// Returns the path
        /// </summary>
        /// <returns></returns>
        public override List<string> GetPath()
        {
            return _blobContainerClient.Uri.AbsolutePath.Split('/').ToList();
        }

        /// <summary>
        /// Retrieves a single blob resoruce based on this respective resource.
        /// </summary>
        /// <param name="encodedPath"></param>
        /// <returns>
        /// <see cref="StorageResource"/> which represents the child blob client of
        /// this respective blob virtual directory resource.
        /// </returns>
        public override StorageResource GetStorageResource(List<string> encodedPath)
        {
            // Recreate the blobName using the existing parent directory path
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(_blobContainerClient.Uri);
            blobUriBuilder.BlobName += String.Join("/", encodedPath);
            return new BlockBlobStorageResource(new BlockBlobClient(blobUriBuilder.ToUri()));
        }

        /// <summary>
        /// Retrieves a directory blob resource based on this respective resource.
        /// </summary>
        /// <param name="encodedPath"></param>
        /// <returns></returns>
        public override StorageResourceContainer GetStorageResourceContainer(List<string> encodedPath)
        {
            // Recreate the blobName using the existing parent directory path
            List<string> fullDirectoryPath = new List<string>(_directoryPrefix);
            fullDirectoryPath.AddRange(encodedPath);
            return new BlobDirectoryStorageResourceContainer(_blobContainerClient, fullDirectoryPath);
        }

        /// <summary>
        /// Retrieves a directory blob resource based on this respective resource.
        /// </summary>
        /// <returns></returns>
        public StorageResourceContainer GetStorageResourceParentContainer()
        {
            // Recreate the blobName using the existing parent directory path
            return new BlobStorageResourceContainer(_blobContainerClient);
        }

        /// <summary>
        /// Obtains the Uri of the blob directory resource, which means we can list
        /// </summary>
        /// <returns></returns>
        public override Uri GetUri()
        {
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(_blobContainerClient.Uri);
            blobUriBuilder.BlobName = string.Join("/", _directoryPrefix);
            return blobUriBuilder.ToUri();
        }

        /// <summary>
        /// Lists the child paths in the resource
        /// </summary>
        /// <param name="options"></param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns>List of the child resources in the storage container</returns>
        public override async IAsyncEnumerable<StorageResource> ListStorageResources(
            ListStorageResourceOptions options = default,
            [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            AsyncPageable<BlobItem> pages = _blobContainerClient.GetBlobsAsync(
                prefix: string.Join("/", _directoryPrefix),
                cancellationToken: cancellationToken);
            await foreach (BlobItem blobItem in pages.ConfigureAwait(false))
            {
                yield return GetStorageResource(blobItem.Name.Split('/').ToList());
            }
        }
    }
}
