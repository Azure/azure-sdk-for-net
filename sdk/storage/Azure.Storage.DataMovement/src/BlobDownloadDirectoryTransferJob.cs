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
    /// <summary>
    /// Blob Directory Download Transfer Job
    /// </summary>
    internal class BlobDownloadDirectoryTransferJob : StorageTransferJob
    {
        private string _localPath;

        // if the upload path is local or will be the destination of the download
        public string localPath => _localPath;

        private BlobDirectoryClient _sourceBlobClient;

        public BlobDirectoryClient sourceBlobClient => _sourceBlobClient;

        /// <summary>
        /// The <see cref="StorageTransferOptions"/>.
        /// </summary>
        internal StorageTransferOptions _transferOptions;
        /// <summary>
        /// Gets the <see cref="StorageTransferOptions"/>.
        /// </summary>
        public StorageTransferOptions TransferOptions => _transferOptions;

        // this is if we decide to prescan everything instead of
        // scanning right before upload/downloading
        internal Queue<Uri> sourceTransferItems;

        /// <summary>
        /// Creates Download Transfer Job
        /// </summary>
        /// <param name="sourceClient"></param>
        /// <param name="destinationPath"></param>
        /// <param name="transferOptions"></param>
        /// <param name="cancellationToken"></param>
        public BlobDownloadDirectoryTransferJob(
            BlobDirectoryClient sourceClient,
            string destinationPath,
            StorageTransferOptions transferOptions,
            //TODO: make options bag to include progress tracker
            //IProgress<StorageTransferStatus> progressTracker,
            CancellationToken cancellationToken)
        {
            // Should we worry about concurrency issue and people using the client they pass elsewhere?
            _localPath = destinationPath;
            _sourceBlobClient = sourceClient;
            _transferOptions = transferOptions;
            CancellationToken = cancellationToken;
        }

        /// <summary>
        /// Create next TransferItem/Task to be processed.
        /// </summary>
        /// <returns>The Task to perform the Upload operation.</returns>
        public override Task CreateTransferTaskAsync()
        {
            // Do only blockblob upload for now for now
            return _sourceBlobClient.DownloadAsync(_localPath, transferOptions:TransferOptions, cancellationToken:CancellationToken);
        }
    }
}
