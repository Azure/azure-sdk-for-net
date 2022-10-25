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

namespace Azure.Storage.Blobs.DataMovement
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
        public override List<string> Path => _blobClient.Name.Split('/').ToList();

        /// <summary>
        /// Defines whether the object can produce a SAS URL
        /// </summary>
        /// <returns></returns>
        public override ProduceUriType CanProduceUri => ProduceUriType.ProducesUri;

        /// <summary>
        /// Defines whether the object can consume a stream
        /// </summary>
        /// <returns></returns>
        public override StreamConsumableType CanCreateOpenReadStream => StreamConsumableType.Consumable;

        /// <summary>
        /// Does not require Commit List operation.
        /// </summary>
        /// <returns></returns>
        public override RequiresCompleteTransferType RequiresCompleteTransfer => RequiresCompleteTransferType.None;

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
        /// Creates readable stream to download
        /// </summary>
        /// <returns></returns>
        public override Task<Stream> OpenReadStreamAsync(long? position = default)
        {
            return _blobClient.OpenReadAsync();
        }

        /// <summary>
        /// Creates writable stream to upload
        /// </summary>
        /// <returns></returns>
        public override Task<Stream> OpenWriteStreamAsync()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Consumes stream to upload
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public override async Task WriteFromStreamAsync(
            Stream stream,
            CancellationToken token)
        {
            // TODO: change depending on type of blob and type single shot or parallel transfer
            await _blobClient.UploadPagesAsync(stream, default, cancellationToken: token).ConfigureAwait(false);
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
        /// <param name="stream"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async Task WriteStreamToOffsetAsync(
            long offset,
            long length,
            Stream stream,
            ConsumePartialReadableStreamOptions options,
            CancellationToken cancellationToken = default)
        {
            await _blobClient.UploadPagesAsync(stream, default, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Consumes blob Url to upload / copy
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public override async Task CopyFromUriAsync(Uri uri)
        {
            // Change depending on type of copy
            await _blobClient.SyncCopyFromUriAsync(uri).ConfigureAwait(false);
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
            throw new NotSupportedException();
        }
    }
}
