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
    internal class BlobDownloadScheduler
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

        internal BlobDownloadScheduler(Uri baseUri, BlobClientConfiguration clientConfiguration, ClientSideEncryptionOptions clientSideEncryption)
        {
            _uri = baseUri;
            _clientConfiguration = clientConfiguration;
            _clientSideEncryption = clientSideEncryption;
        }

        // TODO: Add options object usage and remove pragma
        public async Task<IEnumerable<Response>> StartTransfer(
            string targetPath,
            BlobDirectoryDownloadOptions options,
            bool async,
            CancellationToken cancellationToken = default)
        {
            string fullPath = Path.GetFullPath(targetPath);

            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(Uri)
            {
                // erase parameters unrelated to container
                VersionId = null,
                Snapshot = null,
            };

            string directoryName = blobUriBuilder.BlobName;
            blobUriBuilder.BlobName = null;

            BlobContainerClient containerClient = new BlobContainerClient(
                blobUriBuilder.ToUri(),
                ClientConfiguration,
                ClientSideEncryption);

            Pageable<BlobItem> blobs = containerClient.GetBlobs(default, default, directoryName, cancellationToken);

            BlobRequestConditions conditions = new BlobRequestConditions()
            {
                IfModifiedSince = options.DirectoryRequestConditions.IfModifiedSince ?? null,
                IfUnmodifiedSince = options.DirectoryRequestConditions.IfUnmodifiedSince ?? null,
            };

            int concurrency = (int)(options.TransferOptions.MaximumConcurrency.HasValue && options.TransferOptions.MaximumConcurrency > 0 ? options.TransferOptions.MaximumConcurrency : 1);
            TaskThrottler throttler = new TaskThrottler(concurrency);

            List<Response> responses = new List<Response>();

            foreach (BlobItem blob in blobs)
            {
                BlobBaseClient client = containerClient.GetBlobBaseClient(blob.Name);
                string downloadPath = Path.Combine(fullPath, blob.Name.Substring(directoryName != null ? directoryName.Length + 1 : 0));

                throttler.AddTask(async () =>
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(downloadPath));
                    using (Stream destination = File.Create(downloadPath))
                    {
                        responses.Add(await client.DownloadToAsync(
                            destination,
                            conditions,
                            options.TransferOptions,
                            cancellationToken)
                            .ConfigureAwait(false));
                    }
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
