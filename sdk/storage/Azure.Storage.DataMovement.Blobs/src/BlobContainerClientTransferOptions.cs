// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Blobs;

namespace Azure.Storage.DataMovement.Blobs
{
    /// <summary>
    /// Options applying to data transfer uploads and downloads using the <see cref="BlobContainerClient"/> extension methods
    /// <see cref="BlobContainerClientExtensions.StartDownloadToDirectoryAsync(BlobContainerClient, string, BlobContainerClientTransferOptions)"/> and
    /// <see cref="BlobContainerClientExtensions.StartUploadDirectoryAsync(BlobContainerClient, string, BlobContainerClientTransferOptions)"/>.
    /// </summary>
    public class BlobContainerClientTransferOptions
    {
        /// <summary>
        /// Options pertaining to the blob storage container used in the data transfer.
        /// </summary>
        public BlobStorageResourceContainerOptions BlobContainerOptions { get; set; }

        /// <summary>
        /// Options pertaining to the data tranfer.
        /// </summary>
        public DataTransferOptions TransferOptions { get; set; }
    }
}
