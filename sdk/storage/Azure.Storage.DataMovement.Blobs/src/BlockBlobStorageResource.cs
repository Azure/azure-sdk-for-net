// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;

namespace Azure.Storage.DataMovement.Blobs
{
    /// <summary>
    /// The BlockBlobStorageResource class.
    /// </summary>
    internal class BlockBlobStorageResource : StorageResourceItemInternal
    {
        internal BlockBlobClient BlobClient { get; set; }
        internal BlockBlobStorageResourceOptions _options;

        /// <summary>
        /// In order to ensure the block list is sent in the correct order
        /// we will order them by the offset (i.e. {offset, block_id}).
        /// </summary>
        private ConcurrentDictionary<long, string> _blocks;

        protected override string ResourceId => DataMovementBlobConstants.ResourceId.BlockBlob;

        public override Uri Uri => BlobClient.Uri;

        public override string ProviderId => "blob";

        protected override TransferOrder TransferType => TransferOrder.Unordered;

        protected override long MaxSupportedSingleTransferSize => Constants.Blob.Block.MaxUploadBytes;

        protected override long MaxSupportedChunkSize => Constants.Blob.Block.MaxStageBytes;

        protected override long? Length => ResourceProperties?.ResourceLength;

        /// <summary>
        /// For mocking.
        /// </summary>
        internal BlockBlobStorageResource()
        {
            _blocks = new ConcurrentDictionary<long, string>();
        }

        /// <summary>
        /// The constructor for a new instance of the <see cref="AppendBlobStorageResource"/>
        /// class.
        /// </summary>
        /// <param name="blobClient">The blob client <see cref="BlockBlobClient"/>
        /// which will service the storage resource operations.</param>
        /// <param name="options">Options for the storage resource. See <see cref="BlockBlobStorageResourceOptions"/>.</param>
        public BlockBlobStorageResource(
            BlockBlobClient blobClient,
            BlockBlobStorageResourceOptions options = default)
        {
            BlobClient = blobClient;
            _blocks = new ConcurrentDictionary<long, string>();
            _options = options;
        }

        /// <summary>
        /// Internal Constructor for constructing the resource retrieved by a GetStorageResources.
        /// </summary>
        /// <param name="blobClient">The blob client which will service the storage resource operations.</param>
        /// <param name="resourceProperties">Properties specific to the resource.</param>
        /// <param name="options">Options for the storage resource. See <see cref="BlockBlobStorageResourceOptions"/>.</param>
        internal BlockBlobStorageResource(
            BlockBlobClient blobClient,
            StorageResourceItemProperties resourceProperties,
            BlockBlobStorageResourceOptions options = default)
            : this(blobClient, options)
        {
            ResourceProperties = resourceProperties;
        }

        /// <summary>
        /// Consumes the readable stream to upload.
        /// </summary>
        /// <param name="position">
        /// The offset at which which the stream will be copied to. Default value is 0.
        /// </param>
        /// <param name="length">
        /// The length of the content stream.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.</param>
        /// <returns>The <see cref="StorageResourceReadStreamResult"/> resulting from the upload operation.</returns>
        protected override async Task<StorageResourceReadStreamResult> ReadStreamAsync(
            long position = 0,
            long? length = default,
            CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            Response<BlobDownloadStreamingResult> response =
                await BlobClient.DownloadStreamingAsync(
                    _options.ToBlobDownloadOptions(new HttpRange(position, length), ResourceProperties?.ETag),
                    cancellationToken).ConfigureAwait(false);
            // Set the resource properties if we currently do not have any stored on the resource.
            if (ResourceProperties == default)
            {
                ResourceProperties = response.Value.ToStorageResourceItemProperties();
            }
            return response.Value.ToReadStreamStorageResourceInfo();
        }

        /// <summary>
        /// Consumes the readable stream to upload.
        /// </summary>
        /// <param name="stream">
        /// The stream containing the data to be consumed and uploaded.
        /// </param>
        /// <param name="streamLength">
        /// The length of the content stream.
        /// </param>
        /// <param name="overwrite">
        /// If set to true, will overwrite the blob if it currently exists.
        /// </param>
        /// <param name="completeLength">
        /// The expected complete length of the resource item.
        /// </param>
        /// <param name="options">
        /// Options for the storage resource. See <see cref="StorageResourceWriteToOffsetOptions"/>.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns></returns>
        protected override async Task CopyFromStreamAsync(
            Stream stream,
            long streamLength,
            bool overwrite,
            long completeLength,
            StorageResourceWriteToOffsetOptions options = default,
            CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);

            long position = options?.Position != default ? options.Position.Value : 0;
            if ((streamLength == completeLength) && position == 0)
            {
                // Default to Upload
                await BlobClient.UploadAsync(
                    stream,
                    DataMovementBlobsExtensions.GetBlobUploadOptions(
                        _options,
                        overwrite,
                        MaxSupportedSingleTransferSize,  // We don't want any internal partioning
                        options?.SourceProperties),
                    cancellationToken: cancellationToken).ConfigureAwait(false);
                return;
            }

            string id = Azure.Storage.Shared.StorageExtensions.GenerateBlockId(position);
            if (!_blocks.TryAdd(position, id))
            {
                throw new ArgumentException($"Cannot Stage Block to the specific offset \"{position}\", it already exists in the block list.");
            }
            await BlobClient.StageBlockAsync(
                id,
                stream,
                _options.ToBlobStageBlockOptions(),
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Uploads/copy the blob from a URL.
        /// </summary>
        /// <param name="sourceResource">An instance of <see cref="StorageResourceItem"/>
        /// that contains the data to be uploaded.</param>
        /// <param name="overwrite">
        /// If set to true, will overwrite the blob if exists.
        /// </param>
        /// <param name="completeLength">
        /// The expected complete length of the blob.
        /// </param>
        /// <param name="options">Options for the storage resource. See <see cref="StorageResourceCopyFromUriOptions"/>.</param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns></returns>
        protected override async Task CopyFromUriAsync(
            StorageResourceItem sourceResource,
            bool overwrite,
            long completeLength,
            StorageResourceCopyFromUriOptions options = default,
            CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);

            // We use SyncUploadFromUri over SyncCopyUploadFromUri in this case because it accepts any blob type as the source.
            // TODO: subject to change as we scale to support resource types outside of blobs.
            await BlobClient.SyncUploadFromUriAsync(
                sourceResource.Uri,
                DataMovementBlobsExtensions.GetSyncUploadFromUriOptions(
                    _options,
                    overwrite,
                    options?.SourceAuthentication,
                    options?.SourceProperties),
                cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Uploads/copy the blob from a URL. Supports ranged operations.
        /// </summary>
        /// <param name="sourceResource">An instance of <see cref="StorageResourceItem"/>
        /// that contains the data to be uploaded.</param>
        /// <param name="range">The range of the blob to upload/copy.</param>
        /// <param name="overwrite">
        /// If set to true, will overwrite the blob if exists.
        /// </param>
        /// <param name="completeLength">
        /// The expected complete length of the blob.
        /// </param>
        /// <param name="options">Options for the storage resource. See <see cref="StorageResourceCopyFromUriOptions"/>.</param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns></returns>
        protected override async Task CopyBlockFromUriAsync(
            StorageResourceItem sourceResource,
            HttpRange range,
            bool overwrite,
            long completeLength,
            StorageResourceCopyFromUriOptions options = default,
            CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);

            string id = options?.BlockId ?? Storage.Shared.StorageExtensions.GenerateBlockId(range.Offset);
            if (!_blocks.TryAdd(range.Offset, id))
            {
                throw new ArgumentException($"Cannot Stage Block to the specific offset \"{range.Offset}\", it already exists in the block list");
            }
            await BlobClient.StageBlockFromUriAsync(
                sourceResource.Uri,
                id,
                options: _options.ToBlobStageBlockFromUriOptions(range, options?.SourceAuthentication),
                cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get properties of the resource.
        ///
        /// See <see cref="StorageResourceItemProperties"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>Returns the properties of the Storage Resource. See <see cref="StorageResourceItemProperties"/>.</returns>
        protected override async Task<StorageResourceItemProperties> GetPropertiesAsync(CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);

            // The properties could be populated during construction (from enumeration)
            if (ResourceProperties != default)
            {
                return ResourceProperties;
            }
            else
            {
                BlobProperties blobProperties = (await BlobClient.GetPropertiesAsync(cancellationToken: cancellationToken).ConfigureAwait(false)).Value;
                StorageResourceItemProperties resourceProperties = blobProperties.ToStorageResourceProperties();

                ResourceProperties = resourceProperties;
                return ResourceProperties;
            }
        }

        /// <summary>
        /// Gets the Authorization Header for the storage resource if available.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// Gets the HTTP Authorization header for the storage resource if available. If not available
        /// will return default.
        /// </returns>
        protected override async Task<HttpAuthorization> GetCopyAuthorizationHeaderAsync(CancellationToken cancellationToken = default)
        {
            return await BlobBaseClientInternals.GetCopyAuthorizationTokenAsync(BlobClient, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Commits the block list given.
        /// </summary>
        /// <param name="overwrite">
        /// If set to true, will overwrite the blob if exists.
        /// </param>
        /// <param name="completeTransferOptions">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>The Task which Commits the list of ids</returns>
        protected override async Task CompleteTransferAsync(
            bool overwrite,
            StorageResourceCompleteTransferOptions completeTransferOptions = default,
            CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            // Call commit block list if the blob was uploaded in chunks.
            if (_blocks != null && !_blocks.IsEmpty)
            {
                IEnumerable<string> blockIds = _blocks.OrderBy(x => x.Key).Select(x => x.Value);
                await BlobClient.CommitBlockListAsync(
                    blockIds,
                    DataMovementBlobsExtensions.GetCommitBlockOptions(
                        _options,
                        overwrite,
                        completeTransferOptions?.SourceProperties),
                    cancellationToken).ConfigureAwait(false);
                _blocks.Clear();
            }
        }

        /// <summary>
        /// Deletes the respective storage resource.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// If the storage resource exists and is deleted, true will be returned.
        /// Otherwise if the storage resource does not exist, false will be returned.
        /// </returns>
        protected override async Task<bool> DeleteIfExistsAsync(CancellationToken cancellationToken = default)
        {
            return await BlobClient.DeleteIfExistsAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        protected override StorageResourceCheckpointDetails GetSourceCheckpointDetails()
        {
            return new BlobSourceCheckpointDetails();
        }

        protected override StorageResourceCheckpointDetails GetDestinationCheckpointDetails()
        {
            return new BlobDestinationCheckpointDetails(
                isBlobTypeSet: true,
                blobType: BlobType.Block,
                blobOptions: _options);
        }

        // no-op for get permissions
        protected override Task<string> GetPermissionsAsync(
            StorageResourceItemProperties properties = default,
            CancellationToken cancellationToken = default)
            => Task.FromResult((string)default);

        // no-op for set permissions
        protected override Task SetPermissionsAsync(
            StorageResourceItem sourceResource,
            StorageResourceItemProperties sourceProperties,
            CancellationToken cancellationToken = default)
            => Task.CompletedTask;
    }
}
