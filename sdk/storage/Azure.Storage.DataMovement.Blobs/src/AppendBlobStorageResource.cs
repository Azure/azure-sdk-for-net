// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;

namespace Azure.Storage.DataMovement.Blobs
{
    /// <summary>
    /// The AppendBlobStorageResource class.
    /// </summary>
    internal class AppendBlobStorageResource : StorageResourceItemInternal
    {
        internal AppendBlobClient BlobClient { get; set; }
        internal AppendBlobStorageResourceOptions _options;
        internal long? _length;
        internal ETag? _etagDownloadLock = default;

        protected override string ResourceId => "AppendBlob";

        public override Uri Uri => BlobClient.Uri;

        public override string ProviderId => "blob";

        /// <summary>
        /// Defines the recommended Transfer Type for the storage resource.
        /// </summary>
        protected override DataTransferOrder TransferType => DataTransferOrder.Sequential;

        /// <summary>
        /// Defines the maximum chunk size for the storage resource.
        /// </summary>
        protected override long MaxSupportedChunkSize => Constants.Blob.Append.MaxAppendBlockBytes;

        /// <summary>
        /// Length of the storage resource. This information is obtained during a GetStorageResources API call.
        ///
        /// Will return default if the length was not set by a GetStorageResources API call.
        /// </summary>
        protected override long? Length => _length;

        /// <summary>
        /// The constructor for a new instance of the <see cref="AppendBlobStorageResource"/>
        /// class.
        /// </summary>
        /// <param name="blobClient">The blob client <see cref="Storage.Blobs.BlobClient"/>
        /// which will service the storage resource operations.</param>
        /// <param name="options">Options for the storage resource. See <see cref="AppendBlobStorageResourceOptions"/>.</param>
        public AppendBlobStorageResource(AppendBlobClient blobClient, AppendBlobStorageResourceOptions options = default)
        {
            BlobClient = blobClient;
            _options = options;
        }

        /// <summary>
        /// Internal Constructor for constructing the resource retrieved by a GetStorageResources.
        /// </summary>
        /// <param name="blobClient">The blob client which will service the storage resource operations.</param>
        /// <param name="length">The content length of the blob.</param>
        /// <param name="etagLock">Preset etag to lock on for reads.</param>
        /// <param name="options">Options for the storage resource. See <see cref="AppendBlobStorageResourceOptions"/>.</param>
        internal AppendBlobStorageResource(
            AppendBlobClient blobClient,
            long? length,
            ETag? etagLock,
            AppendBlobStorageResourceOptions options = default)
            : this(blobClient, options)
        {
            _length = length;
            _etagDownloadLock = etagLock;
        }

        /// <summary>
        /// Consumes the readable stream to upload.
        /// </summary>
        /// <param name="position">
        /// The offset at which the stream will be copied to. Default value is 0.
        /// </param>
        /// <param name="length">
        /// The length of the content stream.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>The <see cref="StorageResourceReadStreamResult"/> resulting from the upload operation.</returns>
        protected override async Task<StorageResourceReadStreamResult> ReadStreamAsync(
            long position = 0,
            long? length = default,
            CancellationToken cancellationToken = default)
        {
            Response<BlobDownloadStreamingResult> response = await BlobClient.DownloadStreamingAsync(
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
            long position = options?.Position != default ? options.Position.Value : 0;
            if (position == 0)
            {
                await BlobClient.CreateAsync(
                    _options.ToCreateOptions(overwrite),
                    cancellationToken).ConfigureAwait(false);
            }
            if (streamLength > 0)
            {
                await BlobClient.AppendBlockAsync(
                    content: stream,
                    options: _options.ToAppendBlockOptions(overwrite),
                    cancellationToken: cancellationToken).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Uploads/copy the blob from a URL.
        /// </summary>
        /// <param name="sourceResource">An instance of <see cref="StorageResourceItem"/>
        /// that contains the data to be uploaded.</param>
        /// <param name="overwrite">
        /// If set to true, will overwrite the blob if it currently exists.
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
            // Create Append blob beforehand
            await BlobClient.CreateAsync(
                options: _options.ToCreateOptions(overwrite),
                cancellationToken: cancellationToken).ConfigureAwait(false);

            // There is no synchronous single-call copy API for Append/Page -> Append Blob
            // so use a single Append Block from URL instead.
            if (completeLength > 0)
            {
                HttpRange range = new HttpRange(0, completeLength);
                await BlobClient.AppendBlockFromUriAsync(
                    sourceResource.Uri,
                    options: _options.ToAppendBlockFromUriOptions(overwrite, range, options?.SourceAuthentication),
                    cancellationToken: cancellationToken).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Uploads/copy the blob from a URL. Supports ranged operations.
        /// </summary>
        /// <param name="sourceResource">An instance of <see cref="StorageResourceItem"/>
        /// that contains the data to be uploaded.</param>
        /// <param name="overwrite">
        /// If set to true, will overwrite the blob if it already exists.
        /// </param>
        /// <param name="completeLength">
        /// The expected complete length of the blob.
        /// </param>
        /// <param name="range">The range of the blob to upload/copy.</param>
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
            if (range.Offset == 0)
            {
                await BlobClient.CreateAsync(
                    _options.ToCreateOptions(overwrite),
                    cancellationToken).ConfigureAwait(false);
            }

            await BlobClient.AppendBlockFromUriAsync(
                sourceResource.Uri,
                options: _options.ToAppendBlockFromUriOptions(
                    overwrite,
                    range,
                    options?.SourceAuthentication),
                cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get properties of the resource.
        ///
        /// See <see cref="StorageResourceProperties"/>.
        /// </summary>
        /// <returns>Returns the properties of the Append Blob Storage Resource. See <see cref="StorageResourceProperties"/>.</returns>
        protected override async Task<StorageResourceProperties> GetPropertiesAsync(CancellationToken cancellationToken = default)
        {
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
        protected override Task CompleteTransferAsync(bool overwrite, CancellationToken cancellationToken = default)
        {
            // no-op for now
            return Task.CompletedTask;
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
            return new BlobSourceCheckpointData(BlobType.Append);
        }

        protected override StorageResourceCheckpointData GetDestinationCheckpointData()
        {
            return new BlobDestinationCheckpointData(
                BlobType.Append,
                _options?.HttpHeaders,
                _options?.AccessTier,
                _options?.Metadata,
                _options?.Tags,
                default); // TODO: Update when we support encryption scopes
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
