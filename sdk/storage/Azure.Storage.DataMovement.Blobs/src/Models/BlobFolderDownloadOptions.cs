// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using Azure.Core;
using Azure.Storage.DataMovement;
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.DataMovement.Blobs.Models
{
    /// <summary>
    /// Optional parameters for downloading to a Blob Directory.
    /// </summary>
    internal class BlobFolderDownloadOptions
    {
        /// <summary>
        /// Optional <see cref="IProgress{BlobDownloadDirectoryProgress}"/> to provide
        /// progress updates about data transfers.
        /// TODO: replace long value with appropriate model similar to BlobUploadDirectoryResponse
        /// </summary>
        public IProgress<BlobFolderDownloadProgress> ProgressHandler { get; set; }

        /// <summary>
        /// Optional <see cref="StorageTransferOptions"/> to configure
        /// parallel transfer behavior.
        /// </summary>
        public StorageTransferOptions TransferOptions { get; set; }

        /// <summary>
        /// Transactional hashing options for data integrity checks.
        /// </summary>
        ///public DownloadTransactionalHashingOptions TransactionalHashingOptions { get; set; }

        /// <summary>
        /// Optional <see cref="StorageResourceCreateMode"/> to configure overwrite
        /// behavior. Will default to <see cref="StorageResourceCreateMode.Overwrite"/>.
        /// </summary>
        public StorageResourceCreateMode OverwriteOptions { get; set; }
    }
}
