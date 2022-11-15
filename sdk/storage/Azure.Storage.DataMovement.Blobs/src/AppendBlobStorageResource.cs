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
    /// Blob Storage Resource
    /// </summary>
    public class AppendBlobStorageResource : StorageResource
    {
        private AppendBlobClient _blobClient;
        private AppendBlobStorageResourceOptions _options;

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
        /// the options bag, see <see cref="AppendBlobStorageResourceServiceCopyOptions.CopyMethod"/> in
        /// <see cref="AppendBlobStorageResourceOptions.CopyOptions"/>.
        /// </summary>
        public override TransferCopyMethod ServiceCopyMethod => _options?.CopyOptions?.CopyMethod ?? TransferCopyMethod.SyncCopy;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="blobClient"></param>
        /// <param name="options"></param>
        public AppendBlobStorageResource(AppendBlobClient blobClient, AppendBlobStorageResourceOptions options = default)
        {
            _blobClient = blobClient;
            _options = options;
        }

        /// <summary>
        /// Creates readable stream to download
        /// </summary>
        /// <returns></returns>
        public override async Task<ReadStreamStorageResourceResult> ReadStreamAsync(
            long? position = default,
            CancellationToken cancellationToken = default)
        {
            Response<BlobDownloadStreamingResult> response = await _blobClient.DownloadStreamingAsync(
                new HttpRange(position ?? 0, Constants.LargeBufferSize), // TODO: convert to take in max size
                default, // TODO: convert options to conditions
                false,
                cancellationToken).ConfigureAwait(false);
            return response.Value.ToReadStreamStorageResourceInfo();
        }

        /// <summary>
        /// Consumes the readable stream to upload
        /// </summary>
        /// <param name="offset">
        /// The offset which the stream will be copied to.
        /// </param>
        /// <param name="length">
        /// The length of the stream.
        /// </param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async Task<ReadStreamStorageResourceResult> ReadPartialStreamAsync(
            long offset,
            long length,
            CancellationToken cancellationToken = default)
        {
            Response<BlobDownloadStreamingResult> response = await _blobClient.DownloadStreamingAsync(
                new HttpRange(offset, length),
                default, // TODO: convert options to conditions
                false,
                cancellationToken).ConfigureAwait(false);
            return response.Value.ToReadStreamStorageResourceInfo();
        }

        /// <summary>
        /// Consumes stream to upload
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async Task WriteFromStreamAsync(
            Stream stream,
            CancellationToken cancellationToken)
        {
            // TODO: change depending on type of blob and type single shot or parallel transfer
            await _blobClient.AppendBlockAsync(stream, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Consumes the readable stream to upload
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <param name="stream"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async Task WriteStreamToOffsetAsync(
            long offset,
            long length,
            Stream stream,
            StorageResourceWriteToOffsetOptions options,
            CancellationToken cancellationToken = default)
        {
            await _blobClient.AppendBlockAsync(
                stream,
                cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Uploads/copy the blob from a url
        /// </summary>
        /// <param name="sourceResource"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async Task CopyFromUriAsync(
            StorageResource sourceResource,
            StorageResourceCopyFromUriOptions options = default,
            CancellationToken cancellationToken = default)
        {
             await _blobClient.AppendBlockFromUriAsync(
               sourceResource.Uri,
               options: new AppendBlobAppendBlockFromUriOptions()
               {
                   SourceAuthentication = options.SourceAuthentication,
                   //TODO: convert options to this options bag
               },
               cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Uploads/copy the blob from a url
        /// </summary>
        /// <param name="sourceResource"></param>
        /// <param name="range"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async Task CopyBlockFromUriAsync(
            StorageResource sourceResource,
            HttpRange range,
            StorageResourceCopyFromUriOptions options = default,
            CancellationToken cancellationToken = default)
        {
            await _blobClient.AppendBlockFromUriAsync(
                sourceResource.Uri,
                options: new AppendBlobAppendBlockFromUriOptions()
                {
                    SourceRange = range,
                    SourceAuthentication = options.SourceAuthentication,
                    //TODO: convert options to this options bag
                },
                cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get properties of the resource.
        /// </summary>
        /// <returns>Returns the length of the storage resource</returns>
        public override async Task<StorageResourceProperties> GetPropertiesAsync(CancellationToken cancellationToken)
        {
            BlobProperties properties = await _blobClient.GetPropertiesAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
            return properties.ToStorageResourceProperties();
        }

        /// <summary>
        /// Commits the block list given.
        /// </summary>
        public override Task CompleteTransferAsync(CancellationToken cancellationToken)
        {
            // no-op for now
            return Task.CompletedTask;
        }
    }
}
