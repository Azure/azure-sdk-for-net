﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
    ///
    /// TODO: better description
    /// </summary>
    internal class BlobDownloadDirectoryTransferJob : StorageTransferJob
    {
        /// <summary>
        /// The source blob where it's contents will be downloaded when the job is performed.
        /// </summary>
        private BlobDirectoryClient _sourceBlobClient;

        public BlobDirectoryClient sourceBlobClient => _sourceBlobClient;

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
        internal BlobDirectoryDownloadOptions _options;
        /// <summary>
        /// Gets the <see cref="StorageTransferOptions"/>.
        /// </summary>
        public BlobDirectoryDownloadOptions options => _options;

        // this is if we decide to prescan everything instead of
        // scanning right before upload/downloading
        internal Queue<Uri> sourceTransferItems;

        /// <summary>
        /// Creates Download Transfer Job
        /// </summary>
        /// <param name="sourceClient"></param>
        /// <param name="destinationPath"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        public BlobDownloadDirectoryTransferJob(
            BlobDirectoryClient sourceClient,
            string destinationPath,
            BlobDirectoryDownloadOptions options,
            CancellationToken cancellationToken)
        {
            // Should we worry about concurrency issue and people using the client they pass elsewhere?
            _destinationLocalPath = destinationPath;
            _sourceBlobClient = sourceClient;
            _options = options;
            CancellationToken = cancellationToken;
        }

        /// <summary>
        /// Create next TransferItem/Task to be processed.
        /// </summary>
        /// <returns>The Task to perform the Upload operation.</returns>
        public override Task StartTransferTaskAsync()
        {
            // Do only blockblob upload for now for now
            return _sourceBlobClient.DownloadAsync(_destinationLocalPath, options:options, cancellationToken:CancellationToken);
        }
    }
}
