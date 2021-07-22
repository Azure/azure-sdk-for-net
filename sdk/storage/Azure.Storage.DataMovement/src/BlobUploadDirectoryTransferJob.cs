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
    /// Blob Directory Upload Job
    /// </summary>
    internal class BlobUploadDirectoryTransferJob : StorageTransferJob
    {
        private string _localPath;

        /// <summary>
        /// Gets the source l
        /// </summary>
        public string localPath => _localPath;

        internal BlobDirectoryClient _destinationBlobClient;

        public BlobDirectoryClient destinationBlobClient => _destinationBlobClient;

        internal BlobDirectoryUploadOptions _uploadOptions;

        // Should only be used for upload options. Felt redudant
        // to create a whole other class that inherited this just
        // for uploads. Is it worth it to make a whole other class
        // for each operation type.
        public BlobDirectoryUploadOptions options => _uploadOptions;

        // this is if we decide to prescan everything instead of
        // scanning right before upload/downloading
        internal Queue<string> localTransferItems;

        /// <summary>
        /// Creates Upload Transfer Job.
        ///
        /// TODO: better decription and parameters descriptions
        /// </summary>
        /// <param name="sourceLocalPath"></param>
        /// <param name="destinationClient"></param>
        /// <param name="uploadOptions"></param>
        /// <param name="cancellationToken"></param>
        public BlobUploadDirectoryTransferJob(
            string sourceLocalPath,
            BlobDirectoryClient destinationClient,
            BlobDirectoryUploadOptions uploadOptions,
            CancellationToken cancellationToken)
        {
            _localPath = sourceLocalPath;
            // Should we worry about concurrency issue and people using the client they pass elsewhere?
            _destinationBlobClient = destinationClient;
            _uploadOptions = uploadOptions;
            CancellationToken = cancellationToken;
        }

        /// <summary>
        /// Create next TransferItem/Task to be processed.
        /// </summary>
        /// <returns>The Task to perform the Upload operation.</returns>
        public override Task StartTransferTaskAsync()
        {
            // Do only blockblob upload for now for now
            return destinationBlobClient.UploadAsync(_localPath, _uploadOptions, CancellationToken);
        }
    }
}
