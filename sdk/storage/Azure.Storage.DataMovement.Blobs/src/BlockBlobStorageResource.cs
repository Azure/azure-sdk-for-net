﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
        internal long? _length;
        internal ETag? _etagDownloadLock = default;

        /// <summary>
        /// In order to ensure the block list is sent in the correct order
        /// we will order them by the offset (i.e. {offset, block_id}).
        /// </summary>
        private ConcurrentDictionary<long, string> _blocks;

        protected override string ResourceId => "BlockBlob";

        public override Uri Uri => BlobClient.Uri;

        public override string ProviderId => "blob";

        /// <summary>
        /// Defines the recommended Transfer Type of the storage resource.
        /// </summary>
        protected override DataTransferOrder TransferType => DataTransferOrder.Unordered;

        /// <summary>
        /// Store Max Initial Size that a Put Blob can get to.
        /// </summary>
        internal static long _maxInitialSize => Constants.Blob.Block.Pre_2019_12_12_MaxUploadBytes;

        /// <summary>
        /// Defines the maximum chunk size for the storage resource.
        /// </summary>
        protected override long MaxSupportedChunkSize => Constants.Blob.Block.MaxStageBytes;

        /// <summary>
        /// Length of the storage resource. This information is can obtained during a GetStorageResources API call.
        ///
        /// Will return default if the length was not set by a GetStorageResources API call.
        /// </summary>
        protected override long? Length => _length;

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
        /// <param name="length">The content length of the blob.</param>
        /// <param name="etagLock">Preset etag to lock on for reads.</param>
        /// <param name="options">Options for the storage resource. See <see cref="BlockBlobStorageResourceOptions"/>.</param>
        internal BlockBlobStorageResource(
            BlockBlobClient blobClient,
            long? length,
            ETag? etagLock,
            BlockBlobStorageResourceOptions options = default)
            : this(blobClient, options)
        {
            _length = length;
            _etagDownloadLock = etagLock;
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
                    _options.ToBlobDownloadOptions(new HttpRange(position, length), _etagDownloadLock),
                    cancellationToken).ConfigureAwait(false);
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
                    _options.ToBlobUploadOptions(overwrite, _maxInitialSize),
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
                _options.ToSyncUploadFromUriOptions(overwrite, options?.SourceAuthentication),
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

            string id = options?.BlockId ?? Shared.StorageExtensions.GenerateBlockId(range.Offset);
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
        /// See <see cref="StorageResourceProperties"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>Returns the properties of the Storage Resource. See <see cref="StorageResourceProperties"/>.</returns>
        protected override async Task<StorageResourceProperties> GetPropertiesAsync(CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            Response<BlobProperties> response = await BlobClient.GetPropertiesAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
            GrabEtag(response.GetRawResponse());
            return response.Value.ToStorageResourceProperties();
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
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>The Task which Commits the list of ids</returns>
        protected override async Task CompleteTransferAsync(
            bool overwrite,
            CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            if (_blocks != null && !_blocks.IsEmpty)
            {
                IEnumerable<string> blockIds = _blocks.OrderBy(x => x.Key).Select(x => x.Value);
                await BlobClient.CommitBlockListAsync(
                    blockIds,
                    _options.ToCommitBlockOptions(overwrite),
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

        protected override StorageResourceCheckpointData GetSourceCheckpointData()
        {
            return new BlobSourceCheckpointData(BlobType.Block);
        }

        protected override StorageResourceCheckpointData GetDestinationCheckpointData()
        {
            return new BlobDestinationCheckpointData(
                BlobType.Block,
                _options?.HttpHeaders,
                _options?.AccessTier,
                _options?.Metadata,
                _options?.Tags);
        }

        private void GrabEtag(Response response)
        {
            if (_etagDownloadLock == default && response.TryExtractStorageEtag(out ETag etag))
            {
                _etagDownloadLock = etag;
            }
        }
    }
}
