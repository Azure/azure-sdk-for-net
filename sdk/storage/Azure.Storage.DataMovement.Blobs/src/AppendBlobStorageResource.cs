// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
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

        protected override string ResourceId => DataMovementBlobConstants.ResourceId.AppendBlob;

        public override Uri Uri => BlobClient.Uri;

        public override string ProviderId => "blob";

        protected override TransferOrder TransferType => TransferOrder.Sequential;

        protected override long MaxSupportedSingleTransferSize => Constants.Blob.Append.MaxAppendBlockBytes;

        protected override long MaxSupportedChunkSize => Constants.Blob.Append.MaxAppendBlockBytes;

        protected override int MaxSupportedChunkCount => Constants.Blob.Append.MaxBlocks;

        protected override long? Length => ResourceProperties?.ResourceLength;

        internal AppendBlobStorageResource()
        {
        }

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
        /// <param name="resourceProperties">Properties specific to the resource.</param>
        /// <param name="options">Options for the storage resource. See <see cref="AppendBlobStorageResourceOptions"/>.</param>
        internal AppendBlobStorageResource(
            AppendBlobClient blobClient,
            StorageResourceItemProperties resourceProperties,
            AppendBlobStorageResourceOptions options = default)
            : this(blobClient, options)
        {
            ResourceProperties = resourceProperties;
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
            long position = options?.Position != default ? options.Position.Value : 0;
            if (position == 0)
            {
                await BlobClient.CreateAsync(
                    DataMovementBlobsExtensions.GetCreateOptions(
                        _options,
                        overwrite,
                        options?.SourceProperties),
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
                options: DataMovementBlobsExtensions.GetCreateOptions(
                    _options,
                    overwrite,
                    options?.SourceProperties),
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
                    DataMovementBlobsExtensions.GetCreateOptions(
                        _options,
                        overwrite,
                        options?.SourceProperties),
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
        protected override Task CompleteTransferAsync(
            bool overwrite,
            StorageResourceCompleteTransferOptions completeTransferOptions = default,
            CancellationToken cancellationToken = default)
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

        protected override StorageResourceCheckpointDetails GetSourceCheckpointDetails()
        {
            return new BlobSourceCheckpointDetails();
        }

        protected override StorageResourceCheckpointDetails GetDestinationCheckpointDetails()
        {
            return new BlobDestinationCheckpointDetails(
                isBlobTypeSet: true,
                blobType: BlobType.Append,
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
