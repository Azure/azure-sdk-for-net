// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Blobs.Models;
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.DataMovement.Blobs
{
    internal class BlobDownloadTransferJob : StorageTransferJob
    {
        // Might have to change BlobBaseClient to other client, when we do page blob and append blob
        internal BlobBaseClient _sourceBlobClient;

        /// <summary>
        /// The source blob client. This client contains the information and methods required to perform
        /// the download from the source blob.
        /// </summary>
        public BlobBaseClient sourceBlobClient => _sourceBlobClient;

        /// <summary>
        /// The local path which will store the contents of the blob to be downloaded.
        /// </summary>
        internal string _destinationLocalPath;

        /// <summary>
        /// Gets the local path which will store the contents of the blob to be downloaded.
        /// </summary>
        public string DestinationLocalPath => _destinationLocalPath;

        /// <summary>
        /// The <see cref="BlobDownloadOptions"/>.
        /// </summary>
        internal BlobDownloadToOptions _options;
        /// <summary>
        /// Gets the <see cref="BlobDownloadOptions"/>.
        /// </summary>
        public BlobDownloadToOptions Options => _options;

        /// <summary>
        /// Constructor. Creates Single Blob Download Job.
        ///
        /// TODO: better description, also for parameters.
        /// </summary>
        /// <param name="jobId"></param>
        /// <param name="sourceClient">
        /// Source Blob to download.
        /// </param>
        /// <param name="destinationPath">
        /// Local Path to download the blob to.
        /// </param>
        /// <param name="options">
        /// Transfer Options for the specific download job.
        /// See <see cref="StorageTransferOptions"/>.
        /// </param>
        /// <param name="cancellationToken">
        /// <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        public BlobDownloadTransferJob(
            string jobId,
            BlobBaseClient sourceClient,
            string destinationPath,
            BlobDownloadToOptions options,
            CancellationToken cancellationToken)
            : base(jobId)
        {
            _sourceBlobClient = sourceClient;
            _destinationLocalPath = destinationPath;
            _options = options;
            //ProgressTracker = progressTracker;
            CancellationToken = cancellationToken;
        }

        /// <summary>
        /// Creates Download TransferItem/Task to be processed.
        /// </summary>
        /// <returns>The Task to perform the Download operation</returns>
        public override Task StartTransferTaskAsync()
        {
            // Do only blockblob upload for now for now
            return _sourceBlobClient.DownloadToAsync(_destinationLocalPath, transferOptions:_options.TransferOptions, cancellationToken: CancellationToken);
        }
    }
}
