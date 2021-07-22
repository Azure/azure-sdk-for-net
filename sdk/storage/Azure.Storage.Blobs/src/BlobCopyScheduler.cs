// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;

namespace Azure.Storage.Blobs
{
    internal class BlobCopyScheduler
    {
        private readonly Uri _uri;

        /// <summary>
        /// Gets the blob's primary <see cref="Uri"/> endpoint.
        /// </summary>
        public virtual Uri Uri => _uri;

        /// <summary>
        /// <see cref="BlobClientConfiguration"/>.
        /// </summary>
        internal readonly BlobClientConfiguration _clientConfiguration;

        /// <summary>
        /// <see cref="BlobClientConfiguration"/>.
        /// </summary>
        internal virtual BlobClientConfiguration ClientConfiguration => _clientConfiguration;

        /// <summary>
        /// The <see cref="ClientSideEncryptionOptions"/> to be used when sending/receiving requests.
        /// </summary>
        private readonly ClientSideEncryptionOptions _clientSideEncryption;

        /// <summary>
        /// The <see cref="ClientSideEncryptionOptions"/> to be used when sending/receiving requests.
        /// </summary>
        internal virtual ClientSideEncryptionOptions ClientSideEncryption => _clientSideEncryption;

        internal BlobCopyScheduler(Uri baseUri, BlobClientConfiguration clientConfiguration, ClientSideEncryptionOptions clientSideEncryption)
        {
            _uri = baseUri;
            _clientConfiguration = clientConfiguration;
            _clientSideEncryption = clientSideEncryption;
        }

        public virtual BlobClient GetBlobClient(string blobName)
        {
            return new BlobClient(
                Uri.AppendToPath(blobName),
                ClientConfiguration,
                ClientSideEncryption);
        }

        // TODO: Add options object usage and remove pragma
        public async Task<IEnumerable<Response<BlobCopyInfo>>> StartTransfer(
            Uri sourceUri,
            StorageTransferOptions transferOptions,
#pragma warning disable CA1801 // Review unused parameters
            BlobDirectoryUploadOptions options,
#pragma warning restore CA1801 // Review unused parameters
            bool async,
            CancellationToken cancellationToken = default)
        {
            BlobDirectoryClient sourceDirectory = new BlobDirectoryClient(sourceUri, ClientConfiguration, ClientSideEncryption);

            Pageable<BlobItem> sourceBlobs = sourceDirectory.GetBlobs(default, default, default, cancellationToken);

            int concurrency = (int)(transferOptions.MaximumConcurrency.HasValue && transferOptions.MaximumConcurrency > 0 ? transferOptions.MaximumConcurrency : 1);
            TaskThrottler throttler = new TaskThrottler(concurrency);

            List<Response<BlobCopyInfo>> responses = new List<Response<BlobCopyInfo>>();

            foreach (BlobItem sourceBlob in sourceBlobs)
            {
                BlobUriBuilder builder = new BlobUriBuilder(sourceUri)
                {
                    BlobName = sourceBlob.Name
                };
                Uri sourceBlobUri = builder.ToUri();

                string destBlobName = sourceBlobUri.ToString().Substring(sourceUri.ToString().Length + 1);

                throttler.AddTask(async () =>
                {
                    responses.Add(await GetBlobClient(destBlobName)
                       .SyncCopyFromUriAsync(
                           sourceBlobUri,
                           default,
                           cancellationToken)
                       .ConfigureAwait(false));
                });
            }

            if (async)
            {
                await throttler.WaitAsync().ConfigureAwait(false);
            }
            else
            {
                throttler.Wait();
            }

            return responses;
        }
    }
}
