// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.DataMovement.Blobs.Models
{
    /// <summary>
    /// Job Details of a Blob Upload Directory Job
    /// </summary>
    public class BlobTransferUploadDirectoryJobDetails : StorageTransferJobDetails
    {
        internal BlobTransferUploadDirectoryJobDetails() : base() { }

        internal BlobTransferUploadDirectoryJobDetails(
            string jobId,
            StorageJobTransferStatus status,
            DateTimeOffset? jobStartTime,
            string sourceLocalPath,
            BlobVirtualDirectoryClient destinationBlobClient,
            BlobDirectoryUploadOptions options) :
            base(
                jobId,
                status,
                jobStartTime)
        {
            SourceLocalPath = sourceLocalPath;
            DestinationBlobClient = destinationBlobClient;
            UploadOptions = options;
        }

        /// <summary>
        /// Gets the local path of the source file.
        /// </summary>
        public string SourceLocalPath { get; internal set; }

        /// <summary>
        /// The destination blob dreictory client.
        /// </summary>
        public BlobVirtualDirectoryClient DestinationBlobClient { get; internal set; }

        /// <summary>
        /// Upload options for the directory upload
        /// </summary>
        public BlobDirectoryUploadOptions UploadOptions { get; internal set; }
    }
}
