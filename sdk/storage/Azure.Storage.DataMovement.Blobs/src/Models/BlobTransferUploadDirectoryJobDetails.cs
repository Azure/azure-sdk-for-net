// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.DataMovement.Blobs.Models
{
    /// <summary>
    /// Job Details of a Blob Upload Directory Job
    /// </summary>
    public class BlobTransferUploadDirectoryJobDetails : StorageTransferJobDetails
    {
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
