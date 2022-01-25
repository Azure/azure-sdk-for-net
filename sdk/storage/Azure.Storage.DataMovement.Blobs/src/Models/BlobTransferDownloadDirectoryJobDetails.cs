// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.DataMovement.Blobs.Models
{
    /// <summary>
    /// Blob Diectory Download Details
    /// </summary>
    public class BlobTransferDownloadDirectoryJobDetails : StorageTransferJobDetails
    {
        internal BlobTransferDownloadDirectoryJobDetails() : base() { }

        internal BlobTransferDownloadDirectoryJobDetails(
            string jobId,
            StorageJobTransferStatus status,
            DateTimeOffset? jobStartTime,
            BlobVirtualDirectoryClient sourceBlobClient,
            string destinationLocalPath,
            BlobDirectoryDownloadOptions options) :
            base(
                jobId,
                status,
                jobStartTime)
        {
            SourceBlobClient = sourceBlobClient;
            DestinationLocalPath = destinationLocalPath;
            Options = options;
        }

        /// <summary>
        /// The source blob directory client. This client contains the information and methods required to perform
        /// the download from the source blob.
        /// </summary>
        public BlobVirtualDirectoryClient SourceBlobClient { get; internal set; }

        /// <summary>
        /// Gets the local path which will store the contents of the blob to be downloaded.
        /// </summary>
        public string DestinationLocalPath { get; internal set; }

        /// <summary>
        /// Gets the <see cref="BlobDirectoryDownloadOptions"/>.
        /// </summary>
        public BlobDirectoryDownloadOptions Options { get; internal set; }
    }
}
