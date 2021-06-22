// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Threading;
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

        // Should only be used for upload options. Felt redudant
        // to create a whole other class that inherited this just
        // for uploads. Is it worth it to make a whole other class
        // for each operation type.
        public BlobUploadOptions options => _uploadOptions;
        
        Queue<string> localTransferItems;
        Queue<Uri> sourceTransferItems;
        
        // Creates Upload Transfer Job
        public BlobDirectoryTransferJob(
            string sourceLocalPath,
            BlobDirectoryClient destinationClient,
            StorageTransferOptions transferOptions,
            BlobUploadOptions uploadOptions,
            IProgressTracker<StorageTransferResults> progressTracker,
            CancellationToken cancellationToken)
        {
            // Should we worry about concurrency issue and people using the client they pass elsewhere?
            _localPath = sourceLocalPath;
            _destinationBlobClient = destinationClient.CloneClient();
            _transferOptions = transferOptions;
            _uploadOptions = uploadOptions;
            TransferType = StorageTransferType.Upload;
            CancellationToken = cancellationToken;
        }

        // Creates Download Transfer Job
        public BlobDirectoryTransferJob(
            BlobDirectoryClient sourceClient,
            string destinationPath,
            StorageTransferOptions transferOptions,
            CancellationToken cancellationToken)
        {
            // Should we worry about concurrency issue and people using the client they pass elsewhere?
            _localPath = destinationPath;
            _sourceBlobClient = sourceClient.CloneClient();
            _transferOptions = transferOptions;
            TransferType = StorageTransferType.Download;
        }

        // Creates Copy Transfer Job
        public BlobDirectoryClientJob(
            BlobDirectoryClient sourceClient,
            BlobDirectoryClient destinationClient,
            CopyMethod copyMethod,
            StorageTransferOptions transferOptions)
        {

        }
    }
}
