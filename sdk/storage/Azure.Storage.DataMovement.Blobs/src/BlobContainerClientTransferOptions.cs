// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using Azure.Storage.Blobs;

namespace Azure.Storage.DataMovement.Blobs
{
    /// <summary>
    /// Options applying to data transfer uploads and downloads using the <see cref="BlobContainerClient"/> extension methods
    /// <see cref="BlobContainerClientExtensions.DownloadToDirectoryAsync(BlobContainerClient, WaitUntil, string, BlobContainerClientTransferOptions, CancellationToken)"/> and
    /// <see cref="BlobContainerClientExtensions.UploadDirectoryAsync(BlobContainerClient, WaitUntil, string, BlobContainerClientTransferOptions, CancellationToken)"/>.
    /// </summary>
    public class BlobContainerClientTransferOptions
    {
        /// <summary>
        /// Options pertaining to the blob storage container used in the data transfer.
        /// </summary>
        public BlobStorageResourceContainerOptions BlobContainerOptions { get; set; }

        /// <summary>
        /// Options pertaining to the data transfer.
        /// </summary>
        public TransferOptions TransferOptions { get; set; }
    }
}
