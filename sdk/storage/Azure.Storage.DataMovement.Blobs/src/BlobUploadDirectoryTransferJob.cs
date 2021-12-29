// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.DataMovement.Blobs.Models;

namespace Azure.Storage.DataMovement.Blobs
{
    /// <summary>
    /// Blob Directory Upload Job
    /// </summary>
    internal class BlobUploadDirectoryTransferJob : StorageTransferJob
    {
        private string _sourceLocalPath;

        /// <summary>
        /// Gets the local path of the source file.
        /// </summary>
        public string SourceLocalPath => _sourceLocalPath;

        internal BlobVirtualDirectoryClient _destinationBlobClient;

        public BlobVirtualDirectoryClient DestinationBlobClient => _destinationBlobClient;

        internal BlobDirectoryUploadOptions _uploadOptions;

        // Should only be used for upload options. Felt redudant
        // to create a whole other class that inherited this just
        // for uploads. Is it worth it to make a whole other class
        // for each operation type.
        public BlobDirectoryUploadOptions UploadOptions => _uploadOptions;

        private bool _overwrite;

        /// <summary>
        /// Defines whether to overwrite the blobs within the Blob Virtual Directory if they already exist.
        ///
        /// If the blob already exist and the Overwrite value is set to false
        /// then we will follow error handling based on what the user has set.
        ///
        /// If this value is not defined it is defaulted false.
        /// </summary>
        public bool Overwrite => _overwrite;

        /// <summary>
        /// Creates Upload Transfer Job.
        ///
        /// TODO: better decription and parameters descriptions
        /// </summary>
        /// <param name="jobId"></param>
        /// <param name="sourceLocalPath"></param>
        /// <param name="destinationClient"></param>
        /// <param name="overwrite"></param>
        /// <param name="uploadOptions"></param>
        /// <param name="cancellationToken"></param>
        public BlobUploadDirectoryTransferJob(
            string jobId,
            string sourceLocalPath,
            bool overwrite,
            BlobVirtualDirectoryClient destinationClient,
            BlobDirectoryUploadOptions uploadOptions,
            CancellationToken cancellationToken)
            : base(jobId)
        {
            _sourceLocalPath = sourceLocalPath;
            // Should we worry about concurrency issue and people using the client they pass elsewhere?
            _destinationBlobClient = destinationClient;
            _uploadOptions = uploadOptions;
            _overwrite = overwrite;
            CancellationToken = cancellationToken;
        }

        /// <summary>
        /// Create next TransferItem/Task to be processed.
        /// </summary>
        /// <returns>The Task to perform the Upload operation.</returns>
        public override Task StartTransferTaskAsync()
        {
            // Do only blockblob upload for now for now
            return DestinationBlobClient.UploadAsync(SourceLocalPath, Overwrite, UploadOptions, CancellationToken);
        }
    }
}
