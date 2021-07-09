// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.DataMovement
{
    // Consideration: Should we make a Job type for each type of job?  We might have some overlap
    // so we would have BlobSingleUploadTransferJob, BlobSingleDownloadTransferJob, BlobSIngleCopyTransferJob,
    // BlobUploadDirectoryTransferJob
    internal class BlobDirectoryTransferJob : StorageTransferJob
    {
        private string _localPath;

        // if the upload path is local or will be the destination of the download
        public string localPath => _localPath;

        internal BlobDirectoryClient _destinationBlobClient;

        public BlobDirectoryClient destinationBlobClient => _destinationBlobClient;

        private BlobDirectoryClient _sourceBlobClient;

        public BlobDirectoryClient sourceBlobClient => _sourceBlobClient;

        internal BlobUploadOptions _uploadOptions;

        public readonly CopyMethod _copyMethod;

        // Should only be used for upload options. Felt redudant
        // to create a whole other class that inherited this just
        // for uploads. Is it worth it to make a whole other class
        // for each operation type.
        public BlobUploadOptions options => _uploadOptions;

        // this is if we decide to prescan everything instead of
        // scanning right before upload/downloading
        internal Queue<string> localTransferItems;
        internal Queue<Uri> sourceTransferItems;

        // Creates Upload Transfer Job
        public BlobDirectoryTransferJob(
            string sourceLocalPath,
            BlobDirectoryClient destinationClient,
            StorageTransferOptions transferOptions,
            BlobUploadOptions uploadOptions,
            IProgress<StorageTransferStatus> progressTracker,
            CancellationToken cancellationToken)
        {
            // Should we worry about concurrency issue and people using the client they pass elsewhere?
            _localPath = sourceLocalPath;
            _destinationBlobClient = destinationClient;
            _transferOptions = transferOptions;
            _uploadOptions = uploadOptions;
            TransferType = StorageTransferType.Upload;
            ProgressTracker = progressTracker;
            CancellationToken = cancellationToken;
        }

        // Creates Download Transfer Job
        public BlobDirectoryTransferJob(
            BlobDirectoryClient sourceClient,
            string destinationPath,
            StorageTransferOptions transferOptions,
            IProgress<StorageTransferStatus> progressTracker,
            CancellationToken cancellationToken)
        {
            // Should we worry about concurrency issue and people using the client they pass elsewhere?
            _localPath = destinationPath;
            _sourceBlobClient = sourceClient;
            _transferOptions = transferOptions;
            TransferType = StorageTransferType.Download;
            ProgressTracker = progressTracker;
            CancellationToken = cancellationToken;
        }

        // Creates Copy Transfer Job
        public BlobDirectoryTransferJob(
            BlobDirectoryClient sourceClient,
            BlobDirectoryClient destinationClient,
            CopyMethod copyMethod,
            StorageTransferOptions transferOptions,
            CancellationToken cancellationToken)
        {
            _sourceBlobClient = sourceClient;
            _destinationBlobClient = destinationClient;
            switch (copyMethod)
            {
                case CopyMethod.SyncCopy:
                    TransferType = StorageTransferType.SyncCopy;
                    break;
                case CopyMethod.ServiceSideSyncCopy:
                    TransferType = StorageTransferType.ServiceSideSyncCopy;
                    break;
                default: //CopyMethod.ServiceSideAsyncCopy
                    TransferType = StorageTransferType.ServiceSideAsyncCopy;
                    break;
            }
            _transferOptions = transferOptions;
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
                BlobUploadDirectoryOptions options = (BlobUploadDirectoryOptions)_uploadOptions;

                return destinationBlobClient.UploadAsync(_localPath, _transferOptions, options);
            }
            else // (TransferType == StorageTransferType.Download)
            {
                return Task.CompletedTask;
            }
        }
    }
}
