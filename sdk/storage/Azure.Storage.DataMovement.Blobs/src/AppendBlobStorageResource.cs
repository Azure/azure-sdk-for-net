// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
    /// The AppendBlobStorageResource class.
    /// </summary>
    public class AppendBlobStorageResource : StorageResource
    {
        private AppendBlobClient _blobClient;
        private AppendBlobStorageResourceOptions _options;
        private long? _length;

        /// <summary>
        /// Gets the URL of the storage resource.
        /// </summary>
        public override Uri Uri => _blobClient.Uri;

        /// <summary>
        /// Gets the path of the storage resource.
        /// </summary>
        public override string Path => _blobClient.Name;

        /// <summary>
        /// Defines whether the storage resource type can produce a URL.
        /// </summary>
        public override ProduceUriType CanProduceUri => ProduceUriType.ProducesUri;

        /// <summary>
        /// Returns the preferred method of how to perform service to service
        /// transfers. See <see cref="TransferCopyMethod"/>. This value can be set when specifying
        /// the options bag, see <see cref="AppendBlobStorageResourceOptions.CopyMethod"/>
        /// </summary>
        public override TransferCopyMethod ServiceCopyMethod => _options?.CopyMethod ?? TransferCopyMethod.SyncCopy;

        /// <summary>
        /// Defines the recommended Transfer Type for the storage resource.
        /// </summary>
        public override TransferType TransferType => TransferType.Sequential;

        /// <summary>
        /// Defines the maximum chunk size for the storage resource.
        /// </summary>
        public override long MaxChunkSize => Constants.Blob.Append.MaxAppendBlockBytes;

        /// <summary>
        /// Length of the storage resource. This information is obtained during a GetStorageResources API call.
        ///
        /// Will return default if the length was not set by a GetStorageResources API call.
        /// </summary>
        public override long? Length => _length;

        /// <summary>
        /// The constructor for a new instance of the <see cref="AppendBlobStorageResource"/>
        /// class.
        /// </summary>
        /// <param name="blobClient">The blob client <see cref="BlobClient"/>
        /// which will service the storage resource operations.</param>
        /// <param name="options">Options for the storage resource. See <see cref="AppendBlobStorageResourceOptions"/>.</param>
        public AppendBlobStorageResource(AppendBlobClient blobClient, AppendBlobStorageResourceOptions options = default)
        {
            _blobClient = blobClient;
            _options = options;
        }

        /// <summary>
        /// Internal Constructor for constructing the resource retrieved by a GetStorageResources.
        /// </summary>
        /// <param name="blobClient">The blob client which will service the storage resource operations.</param>
        /// <param name="length">The content length of the blob.</param>
        /// <param name="options">Options for the storage resource. See <see cref="AppendBlobStorageResourceOptions"/>.</param>
        internal AppendBlobStorageResource(
            AppendBlobClient blobClient,
            long? length,
            AppendBlobStorageResourceOptions options = default)
            : this(blobClient, options)
        {
            _length = length;
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
            Response<BlobDownloadStreamingResult> response = await _blobClient.DownloadStreamingAsync(
                _options.ToBlobDownloadOptions(new HttpRange(position, length)),
                cancellationToken).ConfigureAwait(false);
            return response.Value.ToReadStreamStorageResourceInfo();
        }

        /// <summary>
        /// Consumes the readable stream to upload.
        /// </summary>
        /// <param name="position">The offset at which which the stream will be copied to. Default value is 0.</param>
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
            if (position == 0)
            {
                await _blobClient.CreateAsync(
                    _options.ToCreateOptions(overwrite),
                    cancellationToken).ConfigureAwait(false);
            }
            if (streamLength > 0)
            {
                await _blobClient.AppendBlockAsync(
                    content: stream,
                    options: _options.ToAppendBlockOptions(overwrite),
                    cancellationToken: cancellationToken).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Uploads/copy the blob from a URL.
        /// </summary>
        /// <param name="sourceResource">An instance of <see cref="StorageResource"/>
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
            StorageResource sourceResource,
            bool overwrite,
            long completeLength,
            StorageResourceCopyFromUriOptions options = default,
            CancellationToken cancellationToken = default)
        {
            if (ServiceCopyMethod == TransferCopyMethod.AsyncCopy)
            {
                await _blobClient.StartCopyFromUriAsync(
                    sourceResource.Uri,
                    _options.ToBlobCopyFromUriOptions(overwrite, options?.SourceAuthentication),
                    cancellationToken: cancellationToken).ConfigureAwait(false);
            }
            else //(ServiceCopyMethod == TransferCopyMethod.SyncCopy)
            {
                // Create Append blob beforehand
                await _blobClient.CreateAsync(
                    options: _options.ToCreateOptions(overwrite),
                    cancellationToken: cancellationToken).ConfigureAwait(false);

                await _blobClient.SyncCopyFromUriAsync(
                    sourceResource.Uri,
                    _options.ToBlobCopyFromUriOptions(overwrite, options?.SourceAuthentication),
                    cancellationToken: cancellationToken).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Uploads/copy the blob from a URL. Supports ranged operations.
        /// </summary>
        /// <param name="sourceResource">An instance of <see cref="StorageResource"/>
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
        public override async Task CopyBlockFromUriAsync(
            StorageResource sourceResource,
            HttpRange range,
            bool overwrite,
            long completeLength = 0,
            StorageResourceCopyFromUriOptions options = default,
            CancellationToken cancellationToken = default)
        {
            if (ServiceCopyMethod == TransferCopyMethod.SyncCopy)
            {
                if (range.Offset == 0)
                {
                    await _blobClient.CreateAsync(
                        _options.ToCreateOptions(overwrite),
                        cancellationToken).ConfigureAwait(false);
                }
                await _blobClient.AppendBlockFromUriAsync(
                sourceResource.Uri,
                options: _options.ToAppendBlockFromUriOptions(
                    overwrite,
                    range,
                    options?.SourceAuthentication),
                cancellationToken: cancellationToken).ConfigureAwait(false);
            }
            else
            {
                throw new NotSupportedException("TransferCopyMethod specified is not supported in this resource");
            }
        }

        /// <summary>
        /// Get properties of the resource.
        ///
        /// See <see cref="StorageResourceProperties"/>.
        /// </summary>
        /// <returns>Returns the properties of the Append Blob Storage Resource. See <see cref="StorageResourceProperties"/>.</returns>
        public override async Task<StorageResourceProperties> GetPropertiesAsync(CancellationToken cancellationToken = default)
        {
            BlobProperties properties = await _blobClient.GetPropertiesAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
            return properties.ToStorageResourceProperties();
        }

        /// <summary>
        /// Commits the block list given.
        /// </summary>
        public override Task CompleteTransferAsync(CancellationToken cancellationToken = default)
        {
            // no-op for now
            return Task.CompletedTask;
        }
    }
}
