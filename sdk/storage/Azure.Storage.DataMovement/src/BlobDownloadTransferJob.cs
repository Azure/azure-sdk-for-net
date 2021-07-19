// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.DataMovement
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
        /// The <see cref="StorageTransferOptions"/>.
        /// </summary>
        internal StorageTransferOptions _transferOptions;
        /// <summary>
        /// Gets the <see cref="StorageTransferOptions"/>.
        /// </summary>
        public StorageTransferOptions TransferOptions => _transferOptions;

        /// <summary>
        /// Constructor. Creates Single Blob Download Job.
        ///
        /// TODO: better description, also for parameters.
        /// </summary>
        /// <param name="sourceClient">
        /// Source Blob to download.
        /// </param>
        /// <param name="destinationPath">
        /// Local Path to download the blob to.
        /// </param>
        /// <param name="transferOptions">
        /// Transfer Options for the specific download job.
        /// See <see cref="StorageTransferOptions"/>.
        /// </param>
        /// <param name="cancellationToken">
        /// <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        public BlobDownloadTransferJob(
            BlobBaseClient sourceClient,
            string destinationPath,
            StorageTransferOptions transferOptions,
            // TODO: make options bag to include progressTracker
            //IProgress<StorageTransferStatus> progressTracker,
            CancellationToken cancellationToken)
        {
            _sourceBlobClient = sourceClient;
            _destinationLocalPath = destinationPath;
            _transferOptions = transferOptions;
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
            return _sourceBlobClient.DownloadToAsync(_destinationLocalPath, transferOptions: _transferOptions, cancellationToken: CancellationToken);
        }
    }
}
