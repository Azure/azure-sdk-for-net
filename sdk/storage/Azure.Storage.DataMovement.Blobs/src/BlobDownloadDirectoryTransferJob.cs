// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.DataMovement.Blobs.Models;

namespace Azure.Storage.DataMovement.Blobs
{
    /// <summary>
    /// Blob Directory Download Transfer Job
    ///
    /// TODO: better description
    /// </summary>
    internal class BlobDownloadDirectoryTransferJob : StorageTransferJob
    {
        /// <summary>
        /// The source blob where it's contents will be downloaded when the job is performed.
        /// </summary>
        private BlobVirtualDirectoryClient _sourceBlobClient;

        public BlobVirtualDirectoryClient SourceBlobClient => _sourceBlobClient;

        /// <summary>
        /// Local Path to store the downloaded contents from the source blob
        /// </summary>
        private string _destinationLocalPath;

        /// <summary>
        /// Gets the local Path to store the downloaded contents from the source blob
        /// </summary>
        public string DestinationLocalPath => _destinationLocalPath;

        /// <summary>
        /// The <see cref="StorageTransferOptions"/>.
        /// </summary>
        private BlobDirectoryDownloadOptions _options;

        /// <summary>
        /// The <see cref="BlobDirectoryDownloadOptions"/>.
        /// </summary>
        protected internal BlobDirectoryDownloadOptions Options => _options;

        /// <summary>
        /// Creates Download Transfer Job
        /// </summary>
        /// <param name="jobId"></param>
        /// <param name="sourceClient"></param>
        /// <param name="destinationPath"></param>
        /// <param name="options"></param>
        public BlobDownloadDirectoryTransferJob(
            string jobId,
            BlobVirtualDirectoryClient sourceClient,
            string destinationPath,
            BlobDirectoryDownloadOptions options)
            : base(jobId)
        {
            // Should we worry about concurrency issue and people using the client they pass elsewhere?
            _destinationLocalPath = destinationPath;
            _sourceBlobClient = sourceClient;
            _options = options;
        }

        /// <summary>
        /// Create next TransferItem/Task to be processed.
        /// </summary>
        /// <param name="blobName">Name of the blob in the directory that will be downloaded</param>
        /// <returns>The Task to perform the Upload operation.</returns>
        public async Task<Response> GetSingleDownloadTaskAsync(string blobName)
        {
            BlobRequestConditions conditions = new BlobRequestConditions()
            {
                IfModifiedSince = Options.DirectoryRequestConditions.IfModifiedSince ?? null,
                IfUnmodifiedSince = Options.DirectoryRequestConditions.IfUnmodifiedSince ?? null,
            };

            BlockBlobClient blockBlobClient = SourceBlobClient.GetBlockBlobClient(blobName);
            string downloadPath = Path.Combine(DestinationLocalPath, blobName);

            Directory.CreateDirectory(Path.GetDirectoryName(downloadPath));
            Response response;
            using (Stream destination = File.Create(downloadPath))
            {
                response = await blockBlobClient.DownloadToAsync(
                    downloadPath,
                    conditions,
                    Options.TransferOptions)
                    .ConfigureAwait(false);
            }
            return response;
        }
    }
}
