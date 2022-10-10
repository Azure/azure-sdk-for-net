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
    internal class PageBlobStorageResource : StorageResource
    {
        private PageBlobClient blobClient;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="blobClient"></param>
        public PageBlobStorageResource(PageBlobClient blobClient)
        {
            this.blobClient = blobClient;
        }

        /// <summary>
        /// Creates readable stream to download
        /// </summary>
        /// <returns></returns>
        public override Stream ReadableInputStream()
        {
            return blobClient.OpenRead();
        }

        /// <summary>
        /// Creates writable stream to upload
        /// </summary>
        /// <returns></returns>
        public override Stream ConsumableStream()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Consumes stream to upload
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="options"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public override async Task ConsumeReadableStream(
            Stream stream,
            ConsumeReadableStreamOptions options,
            CancellationToken token)
        {
            // TODO: change depending on type of blob and type single shot or parallel transfer
            await blobClient.UploadPagesAsync(stream, default, cancellationToken: token).ConfigureAwait(false);
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
        public override async Task ConsumePartialOffsetReadableStream(
            long offset,
            long length,
            Stream stream,
            ConsumePartialReadableStreamOptions options,
            CancellationToken cancellationToken = default)
        {
            await blobClient.UploadPagesAsync(stream, default, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns URL with SAS
        /// </summary>
        /// <returns></returns>
        public override Uri GetUri()
        {
            // TODO: remove need to set all permissions and 7 days is how long the staged blocks live on the service
            return blobClient.GenerateSasUri(Sas.BlobSasPermissions.All, DateTimeOffset.UtcNow.AddDays(7));
        }

        /// <summary>
        /// Consumes blob Url to upload / copy
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public override async Task ConsumeUri(Uri uri)
        {
            // Change depending on type of copy
            await blobClient.SyncCopyFromUriAsync(uri).ConfigureAwait(false);
        }

        /// <summary>
        /// returns path split up
        /// </summary>
        /// <returns></returns>
        public override List<string> GetPath()
        {
            return blobClient.Name.Split('/').ToList();
        }

        /// <summary>
        /// Defines whether the object can consume a stream
        /// </summary>
        /// <returns></returns>
        public override StreamConsumableType CanConsumeReadableStream()
        {
            return StreamConsumableType.Consumable;
        }

        /// <summary>
        /// Defines whether the object can produce a SAS URL
        /// </summary>
        /// <returns></returns>
        public override ProduceUriType CanProduceUri()
        {
            return ProduceUriType.ProducesUri;
        }

        /// <summary>
        /// Get properties of the resource.
        /// </summary>
        /// <returns>Returns the length of the storage resource</returns>
        public override async Task<StorageResourceProperties> GetPropertiesAsync(CancellationToken cancellationToken)
        {
            BlobProperties properties = await blobClient.GetPropertiesAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
            return properties.ToStorageResourceProperties();
        }

        /// <summary>
        /// Does not require Commit List operation.
        /// </summary>
        /// <returns></returns>
        public override CanCommitListType CanCommitBlockListType()
        {
            return CanCommitListType.None;
        }

        /// <summary>
        /// Commits the block list given.
        /// </summary>
        public override Task CommitBlockList(IEnumerable<string> base64BlockIds, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }
    }
}
