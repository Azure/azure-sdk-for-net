﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.DataMovement.Blobs
{
    /// <summary>
    /// Uploading BLobTransfer Job
    /// </summary>
    internal class BlobUploadTransferJob : StorageTransferJob
    {
        /// <summary>
        /// The path to the local file where the contents to be upload to the blob is stored.
        /// </summary>
        internal string _localPath;

        /// <summary>
        /// Gets the path to the local file where the contents to be upload to the blob is stored.
        /// </summary>
        public string localPath => _localPath;

        // Might have to change BlobBaseClient to other client, when we do page blob and append blob
        internal BlobClient _destinationBlobClient;

        public BlobClient destinationBlobClient => _destinationBlobClient;

        internal BlobUploadOptions _uploadOptions;
        public BlobUploadOptions UploadOptions => _uploadOptions;

        /// <summary>
        /// Constructor. Creates Single Upload Transfer Job.
        ///
        /// TODO: better description; better param descriptions.
        /// </summary>
        /// <param name="jobId"></param>
        /// <param name="sourceLocalPath">
        /// Local File Path that contains the contents to upload.
        /// </param>
        /// <param name="destinationClient">
        /// Destination Blob where the contents will be uploaded to.
        /// </param>
        /// <param name="uploadOptions">
        /// Upload Transfer Options for the specific job.
        /// </param>
        public BlobUploadTransferJob(
            string jobId,
            string sourceLocalPath,
            BlobClient destinationClient,
            BlobUploadOptions uploadOptions)
            : base(jobId)
        {
            _localPath = sourceLocalPath;
            // Should we worry about concurrency issue and people using the client they pass elsewhere?
            _destinationBlobClient = destinationClient;
            _uploadOptions = uploadOptions;
        }

        /// <summary>
        /// Create next TransferItem/Task to be processed.
        /// </summary>
        /// <returns>The Task to perform the Upload operation.</returns>
        public Task StartTransferTaskAsync()
        {
            // Do only blockblob upload for now for now
            return destinationBlobClient.UploadAsync(_localPath, _uploadOptions);
        }
    }
}
