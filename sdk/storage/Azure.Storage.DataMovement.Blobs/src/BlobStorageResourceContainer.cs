// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.DataMovement.Models;
using static Azure.Storage.Constants.Sas;

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
        public override StorageResourceSingle GetChildStorageResource(string path)
            => GetBlobAsStorageResource(ApplyOptionalPrefix(path), type: _options?.BlobType ?? BlobType.Block);

        /// <summary>
        /// Retrieves a single blob resource based on this respective resource.
        /// </summary>
        /// <param name="blobName">Full path to the blob in flat namespace.</param>
        /// <param name="length">The content length of the blob.</param>
        /// <param name="type">The type of <see cref="BlobType"/> that the storage resource is.</param>
        /// <param name="etagLock">Etag for the resource to lock on.</param>
        /// <returns>
        /// <see cref="StorageResourceSingle"/> which represents the child blob client of
        /// this respective blob virtual directory resource.
        /// </returns>
        private StorageResourceSingle GetBlobAsStorageResource(
            string blobName,
            long? length = default,
            BlobType type = BlobType.Block,
            ETag? etagLock = null)
        {
            // Recreate the blobName using the existing parent directory path
            if (type == BlobType.Append)
            {
                AppendBlobClient client = _blobContainerClient.GetAppendBlobClient(blobName);
                return new AppendBlobStorageResource(
                    client,
                    length,
                    etagLock,
                    _options.ToAppendBlobStorageResourceOptions());
            }
            else if (type == BlobType.Page)
            {
                PageBlobClient client = _blobContainerClient.GetPageBlobClient(blobName);
                return new PageBlobStorageResource(
                    client,
                    length,
                    etagLock,
                    _options.ToPageBlobStorageResourceOptions());
            }
            else // (type == BlobType.Block)
            {
                BlockBlobClient client = _blobContainerClient.GetBlockBlobClient(blobName);
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
        public override async IAsyncEnumerable<StorageResource> GetStorageResourcesAsync(
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
                    blobItem.Properties.BlobType.HasValue ? blobItem.Properties.BlobType.Value : BlobType.Block,
                    blobItem.Properties.ETag);
            }
        }

        /// <summary>
        /// Rehydrates from Checkpointer.
        /// </summary>
        /// <param name="checkpointer">
        /// The checkpointer where the transfer state was saved to.
        /// </param>
        /// <param name="transferId">
        /// Transfer Id where we want to rehydrate the resource from the job from.
        /// </param>
        /// <param name="isSource">
        /// Whether or not we are rehydrating the source or destination. True if the source, false if the destination.
        /// </param>
        /// <param name="cancellationToken">
        /// Whether or not to cancel the operation.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/> to rehdyrate a <see cref="LocalFileStorageResource"/> from
        /// a stored checkpointed transfer state.
        /// </returns>
        internal static async Task<BlobStorageResourceContainer> RehydrateResource(
            TransferCheckpointer checkpointer,
            string transferId,
            bool isSource,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(checkpointer, nameof(checkpointer));

            string storedPath = await checkpointer.GetPathFromCheckpointer(transferId, isSource, cancellationToken).ConfigureAwait(false);
            // TODO: get options BlockBlobStorageResourceOptions from stored file

            return new BlobStorageResourceContainer(new BlobContainerClient(new Uri(storedPath)));
        }

        /// <summary>
        /// Rehydrates from Checkpointer.
        /// </summary>
        /// <param name="checkpointer">
        /// The checkpointer where the transfer state was saved to.
        /// </param>
        /// <param name="transferId">
        /// Transfer Id where we want to rehydrate the resource from the job from.
        /// </param>
        /// <param name="isSource">
        /// Whether or not we are rehydrating the source or destination. True if the source, false if the destination.
        /// </param>
        /// <param name="sharedKeyCredential">
        /// Credentials which allows the storage resource to authenticate during the transfer.
        /// </param>
        /// <param name="cancellationToken">
        /// Whether or not to cancel the operation.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/> to rehdyrate a <see cref="LocalFileStorageResource"/> from
        /// a stored checkpointed transfer state.
        /// </returns>
        internal static async Task<BlobStorageResourceContainer> RehydrateResource(
            TransferCheckpointer checkpointer,
            string transferId,
            bool isSource,
            StorageSharedKeyCredential sharedKeyCredential,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(checkpointer, nameof(checkpointer));

            string storedPath = await checkpointer.GetPathFromCheckpointer(transferId, isSource, cancellationToken).ConfigureAwait(false);
            // TODO: get options BlockBlobStorageResourceOptions from stored file

            return new BlobStorageResourceContainer(new BlobContainerClient(
                new Uri(storedPath),
                sharedKeyCredential));
        }

        /// <summary>
        /// Rehydrates from Checkpointer.
        /// </summary>
        /// <param name="checkpointer">
        /// The checkpointer where the transfer state was saved to.
        /// </param>
        /// <param name="transferId">
        /// Transfer Id where we want to rehydrate the resource from the job from.
        /// </param>
        /// <param name="isSource">
        /// Whether or not we are rehydrating the source or destination. True if the source, false if the destination.
        /// </param>
        /// <param name="tokenCredential">
        /// Credentials which allows the storage resource to authenticate during the transfer.
        /// </param>
        /// <param name="cancellationToken">
        /// Whether or not to cancel the operation.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/> to rehdyrate a <see cref="LocalFileStorageResource"/> from
        /// a stored checkpointed transfer state.
        /// </returns>
        internal static async Task<BlobStorageResourceContainer> RehydrateResource(
            TransferCheckpointer checkpointer,
            string transferId,
            bool isSource,
            TokenCredential tokenCredential,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(checkpointer, nameof(checkpointer));

            string storedPath = await checkpointer.GetPathFromCheckpointer(transferId, isSource, cancellationToken).ConfigureAwait(false);
            // TODO: get options BlockBlobStorageResourceOptions from stored file
            return new BlobStorageResourceContainer(new BlobContainerClient(
                new Uri(storedPath),
                tokenCredential));
        }

        /// <summary>
        /// Rehydrates from Checkpointer.
        /// </summary>
        /// <param name="checkpointer">
        /// The checkpointer where the transfer state was saved to.
        /// </param>
        /// <param name="transferId">
        /// Transfer Id where we want to rehydrate the resource from the job from.
        /// </param>
        /// <param name="isSource">
        /// Whether or not we are rehydrating the source or destination. True if the source, false if the destination.
        /// </param>
        /// <param name="sasCredential">
        /// Credentials which allows the storage resource to authenticate during the transfer.
        /// </param>
        /// <param name="cancellationToken">
        /// Whether or not to cancel the operation.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/> to rehdyrate a <see cref="LocalFileStorageResource"/> from
        /// a stored checkpointed transfer state.
        /// </returns>
        internal static async Task<BlobStorageResourceContainer> RehydrateResource(
            TransferCheckpointer checkpointer,
            string transferId,
            bool isSource,
            AzureSasCredential sasCredential,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(checkpointer, nameof(checkpointer));

            string storedPath = await checkpointer.GetPathFromCheckpointer(transferId, isSource, cancellationToken).ConfigureAwait(false);
            // TODO: get options BlockBlobStorageResourceOptions from stored file
            return new BlobStorageResourceContainer(new BlobContainerClient(
                new Uri(storedPath),
                sasCredential));
        }

        private string ApplyOptionalPrefix(string path)
            => IsDirectory
                ? string.Join("/", _directoryPrefix, path)
                : path;
    }
}
