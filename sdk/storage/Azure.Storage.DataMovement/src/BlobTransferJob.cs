// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
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
        internal string _sourceLocalPath;

        public string sourceLocalPath => _sourceLocalPath;

        internal BlobBaseClient _destinationBlobClient;

        public BlobBaseClient destinationBlobClient => _destinationBlobClient;

        private BlobBaseClient _sourceBlobClient;

        public BlobBaseClient sourceBlobClient => _sourceBlobClient;

        internal BlobUploadOptions _uploadOptions;

        // Should only be used for upload options. Felt redudant
        // to create a whole other class that inherited this just
        // for uploads
        public BlobUploadOptions UploadOptions => _uploadOptions;

        public IProgress<StorageTransferStatus> ProgressTracker;

        public BlobTransferJob(
            string localpath,
            BlobBaseClient client,
            StorageTransferOptions transferOptions,
            BlobUploadOptions uploadOptions,
            IProgress<StorageTransferStatus> progressTracker,
            CancellationToken cancellationToken)
        {
            _sourceLocalPath = localpath;
            // Should we worry about concurrency issue and people using the client they pass elsewhere?
            _sourceBlobClient = client.CloneClient();
            _transferOptions = transferOptions;
            _uploadOptions = uploadOptions;
            TransferType = StorageTransferType.Upload;
            ProgressTracker = progressTracker;
            CancellationToken = cancellationToken;
        }

        public BlobTransferJob(
            BlobBaseClient sourceClient,
            string destinationPath,
            StorageTransferOptions transferOptions,
            IProgress<StorageTransferStatus> progressTracker,
            CancellationToken cancellationToken)
        {
            _sourceLocalPath = destinationPath;
            _sourceBlobClient = sourceClient.CloneClient();
            _transferOptions = transferOptions;
            TransferType = StorageTransferType.Download;
            ProgressTracker = progressTracker;
            CancellationToken = cancellationToken;
        }
    }
}
