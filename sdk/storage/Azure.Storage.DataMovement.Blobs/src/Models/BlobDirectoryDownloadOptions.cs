// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;

namespace Azure.Storage.DataMovement.Blobs.Models
{
    /// <summary>
    /// Optional parameters for downloading to a Blob Directory.
    /// </summary>
    public class BlobDirectoryDownloadOptions
    {
        /// <summary>
        /// Optional <see cref="BlobDownloadDirectoryEventHandler"/>.
        ///
        /// Can subscribe to blobs succeeding on transfer, failing transfer or being skipped.
        /// For those looking for fine grained details on each blob event that occurs should use this.
        /// </summary>
        public BlobDownloadDirectoryEventHandler EventHandler { get; set; }

        /// <summary>
        /// Optional <see cref="IProgress{BlobDownloadDirectoryProgress}"/> to provide
        /// progress updates about data transfers.
        /// TODO: replace long value with appropriate model similar to BlobUploadDirectoryResponse
        /// </summary>
        public IProgress<BlobDownloadDirectoryProgress> ProgressHandler { get; set; }

        /// <summary>
        /// Optional <see cref="StorageTransferOptions"/> to configure
        /// parallel transfer behavior.
        /// </summary>
        public StorageTransferOptions TransferOptions { get; set; }

        /// <summary>
        /// Transactional hashing options for data integrity checks.
        /// </summary>
        public DownloadTransactionalHashingOptions TransactionalHashingOptions { get; set; }

        /// <summary>
        /// Optional <see cref="DownloadOverwriteMethod"/> to configure overwrite
        /// behavior. Will default to <see cref="DownloadOverwriteMethod.Overwrite"/>.
        /// </summary>
        public DownloadOverwriteMethod OverwriteOptions { get; set; }
    }
}
