// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.DataMovement.Blobs
{
    /// <summary>
    /// The PageBlobStorageResource class.
    /// </summary>
    public class PageBlobStorageResource : StorageResourceSingle
    {
        internal PageBlobClient BlobClient { get; set; }
        private PageBlobStorageResourceOptions _options;
        private long? _length;
        private ETag? _etagDownloadLock = default;

        /// <summary>
        /// The identifier for the type of storage resource.
        /// </summary>
        public override string ResourceId => "PageBlob";

        /// <summary>
        /// Gets the URL of the storage resource.
        /// </summary>
        public override Uri Uri => BlobClient.Uri;

        /// <summary>
        /// Gets the path of the resource.
        /// </summary>
        public override string Path => BlobClient.Name;

        /// <summary>
        /// Defines whether the storage resource type can produce a URL.
        /// </summary>
        public override ProduceUriType CanProduceUri => ProduceUriType.ProducesUri;

        /// <summary>
        /// Defines the recommended Transfer Type for the storage resource.
        /// </summary>
        public override TransferType TransferType => TransferType.Concurrent;

        /// <summary>
        /// Defines the maximum chunk size for the storage resource.
        /// </summary>
        public override long MaxChunkSize => Constants.Blob.Page.MaxPageBlockBytes;

        /// <summary>
        /// Length of the storage resource. This information is obtained during a GetStorageResources API call.
        ///
        /// Will return default if the length was not set by a GetStorageResources API call.
        /// </summary>
        public override long? Length => _length;

        /// <summary>
        /// The constructor for a new instance of the <see cref="PageBlobStorageResource"/>
        /// class.
        /// </summary>
        /// <param name="blobClient"></param>
        /// <param name="options"></param>
        public PageBlobStorageResource(PageBlobClient blobClient, PageBlobStorageResourceOptions options = default)
        {
            BlobClient = blobClient;
            _options = options;
        }

        /// <summary>
        /// Internal Constructor for constructing the resource retrieved by a GetStorageResources
        /// </summary>
        /// <param name="blobClient">The blob client which will service the storage resource operations.</param>
        /// <param name="length">The content length of the blob.</param>
        /// <param name="etagLock">Preset etag to lock on for reads.</param>
        /// <param name="options">Options for the storage resource. See <see cref="PageBlobStorageResourceOptions"/>.</param>
        internal PageBlobStorageResource(
            PageBlobClient blobClient,
            long? length,
            ETag? etagLock,
            PageBlobStorageResourceOptions options = default)
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
        /// <returns>The <see cref="ReadStreamStorageResourceResult"/> resulting from the upload operation.</returns>
        public override async Task<ReadStreamStorageResourceResult> ReadStreamAsync(
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
        /// <param name="position">
        /// The offset at which which the stream will be copied to. Default value is 0.
        /// </param>
        /// <param name="overwrite">
        /// If set to true, will overwrite the blob if it currently exists.
        /// </param>
        /// <param name="streamLength">
        /// The length of the content stream.
        /// </param>
        /// <param name="completeLength">
        /// The expected complete length of the blob.
        /// </param>
        /// <param name="stream">The stream containing the data to be consumed and uploaded.</param>
        /// <param name="options">Options for the storage resource. See <see cref="StorageResourceWriteToOffsetOptions"/>.</param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns></returns>
        public override async Task WriteFromStreamAsync(
            Stream stream,
            long streamLength,
            bool overwrite,
            long position = 0,
            long completeLength = 0,
            StorageResourceWriteToOffsetOptions options = default,
            CancellationToken cancellationToken = default)
        {
            // Create the blob first before uploading the pages
            if (position == 0)
            {
                await BlobClient.CreateAsync(
                    size: completeLength,
                    options: _options.ToCreateOptions(overwrite),
                    cancellationToken: cancellationToken).ConfigureAwait(false);
            }
            if (streamLength > 0)
            {
                await BlobClient.UploadPagesAsync(
                    content: stream,
                    offset: position,
                    options: _options.ToUploadPagesOptions(overwrite),
                    cancellationToken: cancellationToken).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Uploads/copy the blob from a URL.
        /// </summary>
        /// <param name="sourceResource">An instance of <see cref="StorageResourceSingle"/>
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
        public override async Task CopyFromUriAsync(
            StorageResourceSingle sourceResource,
            bool overwrite,
            long completeLength,
            StorageResourceCopyFromUriOptions options = default,
            CancellationToken cancellationToken = default)
        {
            await BlobClient.CreateAsync(
                size: completeLength,
                options: _options.ToCreateOptions(overwrite),
                cancellationToken: cancellationToken).ConfigureAwait(false);

            // There is no synchronous single-call copy API for Append/Page -> Page Blob
            // so use a single Put Page from URL instead.
            if (completeLength > 0)
            {
                HttpRange range = new HttpRange(0, completeLength);
                await BlobClient.UploadPagesFromUriAsync(
                    sourceResource.Uri,
                    sourceRange: range,
                    range: range,
                    options: _options.ToUploadPagesFromUriOptions(overwrite, options?.SourceAuthentication),
                    cancellationToken: cancellationToken).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Uploads/copy the blob from a url
        /// </summary>
        /// <param name="sourceResource">An instance of <see cref="StorageResourceSingle"/>
        /// that contains the data to be uploaded.</param>
        /// <param name="overwrite">
        ///  If set to true, will overwrite the blob if it already exists.
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
        public override async Task CopyBlockFromUriAsync(
            StorageResourceSingle sourceResource,
            HttpRange range,
            bool overwrite,
            long completeLength = 0,
            StorageResourceCopyFromUriOptions options = default,
            CancellationToken cancellationToken = default)
        {
            // Create the blob first before uploading the pages
            PageBlobRequestConditions conditions = new PageBlobRequestConditions
            {
                // TODO: copy over the other conditions from the uploadOptions
                IfNoneMatch = overwrite ? null : new ETag(Constants.Wildcard),
            };
            if (range.Offset == 0)
            {
                await BlobClient.CreateAsync(
                    size: completeLength,
                    _options.ToCreateOptions(overwrite),
                    cancellationToken).ConfigureAwait(false);
            }
            await BlobClient.UploadPagesFromUriAsync(
                sourceResource.Uri,
                sourceRange: range,
                range: range,
                options: _options.ToUploadPagesFromUriOptions(overwrite, options?.SourceAuthentication),
                cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get properties of the resource.
        ///
        /// See <see cref="StorageResourceProperties"/>.
        /// </summary>
        /// <returns>Returns the properties of the Page Blob Storage Resource. See <see cref="StorageResourceProperties"/></returns>
        public override async Task<StorageResourceProperties> GetPropertiesAsync(CancellationToken cancellationToken = default)
        {
            Response<BlobProperties> response = await BlobClient.GetPropertiesAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
            GrabEtag(response.GetRawResponse());
            return response.Value.ToStorageResourceProperties();
        }

        /// <summary>
        /// Commits the block list given.
        /// </summary>
        public override Task CompleteTransferAsync(bool overwrite, CancellationToken cancellationToken = default)
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
        public override async Task<bool> DeleteIfExistsAsync(CancellationToken cancellationToken = default)
        {
            return await BlobClient.DeleteIfExistsAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Rehydrates from Checkpointer.
        /// </summary>
        /// <param name="transferProperties">
        /// The properties of the transfer to rehydrate.
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
        internal static async Task<PageBlobStorageResource> RehydrateResourceAsync(
            DataTransferProperties transferProperties,
            bool isSource,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(transferProperties, nameof(transferProperties));
            TransferCheckpointer checkpointer = transferProperties.Checkpointer.GetCheckpointer();

            PageBlobStorageResourceOptions options =
                await checkpointer.GetPageBlobResourceOptionsAsync(
                    transferProperties.TransferId,
                    isSource,
                    cancellationToken).ConfigureAwait(false);

            string storedPath = isSource ? transferProperties.SourcePath : transferProperties.DestinationPath;

            return new PageBlobStorageResource(
                new PageBlobClient(new Uri(storedPath)),
                options);
        }

        /// <summary>
        /// Rehydrates from Checkpointer.
        /// </summary>
        /// <param name="transferProperties">
        /// The properties of the transfer to rehydrate.
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
        internal static async Task<PageBlobStorageResource> RehydrateResourceAsync(
            DataTransferProperties transferProperties,
            bool isSource,
            StorageSharedKeyCredential sharedKeyCredential,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(transferProperties, nameof(transferProperties));
            TransferCheckpointer checkpointer = transferProperties.Checkpointer.GetCheckpointer();

            PageBlobStorageResourceOptions options =
                await checkpointer.GetPageBlobResourceOptionsAsync(
                    transferProperties.TransferId,
                    isSource,
                    cancellationToken).ConfigureAwait(false);

            string storedPath = isSource ? transferProperties.SourcePath : transferProperties.DestinationPath;

            return new PageBlobStorageResource(
                new PageBlobClient(new Uri(storedPath), sharedKeyCredential),
                options);
        }

        /// <summary>
        /// Rehydrates from Checkpointer.
        /// </summary>
        /// <param name="transferProperties">
        /// The properties of the transfer to rehydrate.
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
        internal static async Task<PageBlobStorageResource> RehydrateResourceAsync(
            DataTransferProperties transferProperties,
            bool isSource,
            TokenCredential tokenCredential,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(transferProperties, nameof(transferProperties));
            TransferCheckpointer checkpointer = transferProperties.Checkpointer.GetCheckpointer();

            PageBlobStorageResourceOptions options =
                await checkpointer.GetPageBlobResourceOptionsAsync(
                    transferProperties.TransferId,
                    isSource,
                    cancellationToken).ConfigureAwait(false);

            string storedPath = isSource ? transferProperties.SourcePath : transferProperties.DestinationPath;

            // TODO: get options PageBlobStorageResourceOptions from stored file
            return new PageBlobStorageResource(
                new PageBlobClient(new Uri(storedPath), tokenCredential),
                options);
        }

        /// <summary>
        /// Rehydrates from Checkpointer.
        /// </summary>
        /// <param name="transferProperties">
        /// The properties of the transfer to rehydrate.
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
        internal static async Task<PageBlobStorageResource> RehydrateResourceAsync(
            DataTransferProperties transferProperties,
            bool isSource,
            AzureSasCredential sasCredential,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(transferProperties, nameof(transferProperties));
            TransferCheckpointer checkpointer = transferProperties.Checkpointer.GetCheckpointer();

            PageBlobStorageResourceOptions options =
                await checkpointer.GetPageBlobResourceOptionsAsync(
                    transferProperties.TransferId,
                    isSource,
                    cancellationToken).ConfigureAwait(false);

            string storedPath = isSource ? transferProperties.SourcePath : transferProperties.DestinationPath;

            return new PageBlobStorageResource(
                new PageBlobClient(new Uri(storedPath), sasCredential),
                options);
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
