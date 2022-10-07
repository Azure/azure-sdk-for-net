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

namespace Azure.Storage.Blobs.DataMovement
{
    /// <summary>
    /// Blob Storage Resource
    /// </summary>
    internal class BlobStorageResource : StorageResource
    {
        private BlobBaseClient blobClient;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="blobClient"></param>
        public BlobStorageResource(BlobClient blobClient)
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
            // TODO: check for proper conversion
            BlockBlobClient blockBlobClient = (BlockBlobClient)blobClient;
            return blockBlobClient.OpenWrite(overwrite: false);
        }

        /// <summary>
        /// Consumes stream to upload
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public override async Task ConsumeReadableStream(Stream stream, CancellationToken token)
        {
            // TODO: change depending on type of blob and type single shot or parallel transfer
            BlockBlobClient blockBlobClient = (BlockBlobClient)blobClient;
            await blockBlobClient.UploadAsync(stream, default, cancellationToken:token).ConfigureAwait(false);
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
            // TODO: check for proper conversion
            BlockBlobClient blockBlobClient = (BlockBlobClient)blobClient;
            // Change depending on type of copy
            await blockBlobClient.SyncUploadFromUriAsync(uri).ConfigureAwait(false);
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
        /// Returns the length of the blob
        ///
        /// TODO: remove if needed
        /// </summary>
        /// <returns></returns>
        internal async Task<long?> GetLength()
        {
            BlobProperties properties = await blobClient.GetPropertiesAsync().ConfigureAwait(false);
            return properties.ContentLength;
        }
    }
}
