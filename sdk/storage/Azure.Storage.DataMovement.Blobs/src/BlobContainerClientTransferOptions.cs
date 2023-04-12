// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.DataMovement.Blobs;
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.Blobs
{
    /// <summary>
    /// Options applying to data transfer uploads and downloads using the <see cref="BlobContainerClient"/> extension methods
    /// <see cref="BlobContainerClientExtensions.StartDownloadDirectoryAsync"/> and <see cref="BlobContainerClientExtensions.StartUploadDirectoryAsync"/>
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
        public ContainerTransferOptions TransferOptions { get; set; }
    }
}
