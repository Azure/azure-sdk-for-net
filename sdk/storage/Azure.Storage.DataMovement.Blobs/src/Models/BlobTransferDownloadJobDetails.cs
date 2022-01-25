// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Text;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.DataMovement.Blobs.Models
{
    /// <summary>
    /// Job Detail summary for the job
    /// </summary>
    public class BlobTransferDownloadJobDetails : StorageTransferJobDetails
    {
        internal BlobTransferDownloadJobDetails() : base() { }

        internal BlobTransferDownloadJobDetails(
            string jobId,
            StorageJobTransferStatus status,
            DateTimeOffset? jobStartTime,
            BlobBaseClient sourceBlobClient,
            string destinationLocalPath,
            BlobDownloadToOptions options) :
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
        /// The source blob client. This client contains the information and methods required to perform
        /// the download from the source blob.
        /// </summary>
        public BlobBaseClient SourceBlobClient { get; internal set; }

        /// <summary>
        /// Gets the local path which will store the contents of the blob to be downloaded.
        /// </summary>
        public string DestinationLocalPath { get; internal set; }

        /// <summary>
        /// Gets the <see cref="BlobDownloadOptions"/>.
        /// </summary>
        public BlobDownloadToOptions Options { get; internal set; }
    }
}
