// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
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
        protected internal BlobDirectoryDownloadOptions Options;

        /// <summary>
        /// Stores the source of each transfer item
        /// </summary>
#pragma warning disable CA1823 // Avoid unused private fields
        private Queue<Uri> _sourceTransferItems;
#pragma warning restore CA1823 // Avoid unused private fields

        /// <summary>
        /// Stores the source of each transfer item
        /// </summary>
        protected internal Queue<Uri> SourceTransferItems;

        /// <summary>
        /// Creates Download Transfer Job
        /// </summary>
        /// <param name="jobId"></param>
        /// <param name="sourceClient"></param>
        /// <param name="destinationPath"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        public BlobDownloadDirectoryTransferJob(
            string jobId,
            BlobVirtualDirectoryClient sourceClient,
            string destinationPath,
            BlobDirectoryDownloadOptions options,
            CancellationToken cancellationToken)
            : base(jobId)
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
            return _sourceBlobClient.DownloadAsync(DestinationLocalPath, options: Options, cancellationToken: CancellationToken);
        }
    }
}
