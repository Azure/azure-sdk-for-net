// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
    /// Blob Storage Resource
    /// </summary>
    public class PageBlobStorageResource : StorageResource
    {
        private PageBlobClient _blobClient;
        private PageBlobStorageResourceOptions _options;

        /// <summary>
        /// Returns URL
        /// </summary>
        /// <returns></returns>
        public override Uri Uri => _blobClient.Uri;

        /// <summary>
        /// Gets the path of the resource.
        /// </summary>
        public override string Path => _blobClient.Name;

        /// <summary>
        /// Defines whether the object can produce a SAS URL
        /// </summary>
        /// <returns></returns>
        public override ProduceUriType CanProduceUri => ProduceUriType.ProducesUri;

        /// <summary>
        /// Returns the preferred method of how to perform service to service
        /// transfers. See <see cref="TransferCopyMethod"/>. This value can be set when specifying
        /// the options bag, see <see cref="PageBlobStorageResourceServiceCopyOptions.CopyMethod"/> in
        /// <see cref="PageBlobStorageResourceOptions.CopyOptions"/>.
        /// </summary>
        public override TransferCopyMethod ServiceCopyMethod => _options?.CopyOptions?.CopyMethod ?? TransferCopyMethod.SyncCopy;

        /// <summary>
        /// Defines the recommended Transfer Type of the resource
        /// </summary>
        public override TransferType TransferType => TransferType.Concurrent;

        /// <summary>
        /// Defines the maximum chunk size for the storage resource.
        /// </summary>
        public override long MaxChunkSize => Constants.Blob.Block.MaxStageBytes;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="blobClient"></param>
        /// <param name="options"></param>
        public PageBlobStorageResource(PageBlobClient blobClient, PageBlobStorageResourceOptions options = default)
        {
            _blobClient = blobClient;
            _options = options;
        }

        /// <summary>
        /// Creates the local page blob.
        /// </summary>
        /// <param name="overwrite"></param>
        /// <param name="size"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async Task CreateAsync(
            bool overwrite,
            long size = 0,
            CancellationToken cancellationToken = default)
        {
            try
            {
                PageBlobRequestConditions conditions = new PageBlobRequestConditions
                {
                    // TODO: copy over the other conditions from the uploadOptions
                    IfNoneMatch = !overwrite ? new ETag(Constants.Wildcard) : null,
                };
                await _blobClient.CreateAsync(
                    size: size,
                    new PageBlobCreateOptions()
                    {
                        Conditions = conditions,
                    }, cancellationToken).ConfigureAwait(false);
            }
            catch (RequestFailedException storageRequestFailedException)
                when (overwrite && storageRequestFailedException.ErrorCode == BlobErrorCode.BlobAlreadyExists)
            {
                return;
            }
            // Let the exception throw if the above the conditions aren't met.
        }

        /// <summary>
        /// Consumes the readable stream to upload
        /// </summary>
        /// <param name="position">
        /// The offset which the stream will be copied to.
        /// </param>
        /// <param name="length">
        /// The length of the stream.
        /// </param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async Task<ReadStreamStorageResourceResult> ReadStreamAsync(
            long position = 0,
            long? length = default,
            CancellationToken cancellationToken = default)
        {
            Response<BlobDownloadStreamingResult> response = await _blobClient.DownloadStreamingAsync(
                new BlobDownloadOptions()
                {
                    Range = new HttpRange(position, length)
                },
                cancellationToken).ConfigureAwait(false);
            return response.Value.ToReadStreamStorageResourceInfo();
        }

        /// <summary>
        /// Consumes the readable stream to upload
        /// </summary>
        /// <param name="position">
        /// The offset which the stream will be copied to.
        /// </param>
        /// <param name="overwrite">
        /// If set to true, will overwrite the blob if exists.
        /// </param>
        /// <param name="length">
        /// The length of the stream.
        /// </param>
        /// <param name="stream"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async Task WriteFromStreamAsync(
            Stream stream,
            bool overwrite,
            long position = 0,
            long? length = default,
            StorageResourceWriteToOffsetOptions options = default,
            CancellationToken cancellationToken = default)
        {
            if (length > 0)
            {
                await _blobClient.UploadPagesAsync(
                    content: stream,
                    offset: position,
                    options: default,
                    cancellationToken: cancellationToken).ConfigureAwait(false);
            }
            else
            {
                throw new ArgumentException("Cannot upload stream of 0 length");
            }
        }

        /// <summary>
        /// Consumes blob Url to upload / copy
        /// </summary>
        /// <param name="sourceResource"></param>
        /// <param name="overwrite">
        /// If set to true, will overwrite the blob if exists.
        /// </param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async Task CopyFromUriAsync(
            StorageResource sourceResource,
            bool overwrite,
            StorageResourceCopyFromUriOptions options = default,
            CancellationToken cancellationToken = default)
        {
            if (ServiceCopyMethod == TransferCopyMethod.AsyncCopy)
            {
                await _blobClient.StartCopyFromUriAsync(sourceResource.Uri, cancellationToken: cancellationToken).ConfigureAwait(false);
            }
            else //(ServiceCopyMethod == TransferCopyMethod.SyncCopy)
            {
                // TODO: subject to change as we scale to suppport resource types outside of blobs.
                await _blobClient.SyncCopyFromUriAsync(sourceResource.Uri, cancellationToken: cancellationToken).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Uploads/copy the blob from a url
        /// </summary>
        /// <param name="sourceResource"></param>
        /// <param name="overwrite">
        /// If set to true, will overwrite the blob if exists.
        /// </param>
        /// <param name="range"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async Task CopyBlockFromUriAsync(
            StorageResource sourceResource,
            HttpRange range,
            bool overwrite,
            StorageResourceCopyFromUriOptions options = default,
            CancellationToken cancellationToken = default)
        {
            if (ServiceCopyMethod == TransferCopyMethod.SyncCopy)
            {
                await _blobClient.UploadPagesFromUriAsync(
                sourceResource.Uri,
                sourceRange: range,
                range: range,
                options: new PageBlobUploadPagesFromUriOptions()
                {
                    SourceAuthentication = options?.SourceAuthentication,
                    DestinationConditions = _options?.CopyOptions.DestinationConditions
                },
                cancellationToken: cancellationToken).ConfigureAwait(false);
            }
            else
            {
                throw new NotSupportedException("TransferCopyMethod specified is not supported in this resource");
            }
        }

        /// <summary>
        /// Get properties of the resource.
        /// </summary>
        /// <returns>Returns the length of the storage resource</returns>
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
