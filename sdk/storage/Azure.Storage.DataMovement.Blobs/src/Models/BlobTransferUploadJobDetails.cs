// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.DataMovement.Blobs.Models
{
    /// <summary>
    /// Job Details for Upload Blob
    /// </summary>
    public class BlobTransferUploadJobDetails : StorageTransferJobDetails
    {
        /// <summary>
        /// Gets the path to the local file where the contents to be upload to the blob is stored.
        /// </summary>
        public string LocalPath { get; internal set; }

        /// <summary>
        /// The destination blob client. This client contains the information and methods required to perform
        /// the upload on the destination blob.
        /// </summary>
        public BlobBaseClient DestinationBlobClient { get; internal set; }

        /// <summary>
        /// Upload options for the upload task
        /// </summary>
        public BlobUploadOptions UploadOptions { get; internal set; }
    }
}
