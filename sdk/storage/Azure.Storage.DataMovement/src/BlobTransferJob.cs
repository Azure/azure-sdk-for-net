// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Uploading BLobTransfer Job
    /// </summary>
    internal class BlobTransferJob : StorageTransferJob
    {
        internal string _localPath;

        public string localPath => _localPath;

        // Might have to change BlobBaseClient to other client, when we do page blob and append blob
        internal BlobClient _destinationBlobClient;

        public BlobClient destinationBlobClient => _destinationBlobClient;

        private BlobClient _sourceBlobClient;

        public BlobClient sourceBlobClient => _sourceBlobClient;

        internal BlobUploadOptions _uploadOptions;

        // Should only be used for upload options. Felt redudant
        // to create a whole other class that inherited this just
        // for uploads
        public BlobUploadOptions UploadOptions => _uploadOptions;

        public BlobTransferJob(
            string localpath,
            BlobClient client,
            StorageTransferOptions transferOptions,
            BlobUploadOptions uploadOptions,
            IProgress<StorageTransferStatus> progressTracker,
            CancellationToken cancellationToken)
        {
            _localPath = localpath;
            // Should we worry about concurrency issue and people using the client they pass elsewhere?
            _sourceBlobClient = client;
            _transferOptions = transferOptions;
            _uploadOptions = uploadOptions;
            TransferType = StorageTransferType.Upload;
            ProgressTracker = progressTracker;
            CancellationToken = cancellationToken;
        }

        public BlobTransferJob(
            BlobClient sourceClient,
            string destinationPath,
            StorageTransferOptions transferOptions,
            IProgress<StorageTransferStatus> progressTracker,
            CancellationToken cancellationToken)
        {
            _localPath = destinationPath;
            _sourceBlobClient = sourceClient;
            _transferOptions = transferOptions;
            TransferType = StorageTransferType.Download;
            ProgressTracker = progressTracker;
            CancellationToken = cancellationToken;
        }

        /// <summary>
        /// Create next TransferItem/Task to be processed
        /// </summary>
        /// <returns></returns>
        public override Task CreateTransferTaskAsync()
        {
            // Stub to create Task
            if (TransferType == StorageTransferType.Upload)
            {
                // Do only blockblobs for now
                return destinationBlobClient.UploadAsync(_localPath);
            }
            else // (TransferType == StorageTransferType.Download)
            {
                return sourceBlobClient.DownloadToAsync(_localPath);
            }
        }
    }
}
