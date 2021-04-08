// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Models;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Optional paratmers for downloading a Blob.
    /// </summary>
    public class BlobDownloadOptions
    {
        /// <summary>
        /// Optional <see cref="BlobRequestConditions"/> to add
        /// conditions on the upload of this Block Blob.
        /// </summary>
        public BlobRequestConditions Conditions { get; set; }

        /// <summary>
        /// Optional <see cref="StorageTransferOptions"/> to configure
        /// parallel transfer behavior.
        /// </summary>
        public StorageTransferOptions TransferOptions { get; set; }

        /// <summary>
        /// Optional <see cref="DownloadTransactionalHashingOptions"/> to configure
        /// checksum behavior.
        /// </summary>
        public DownloadTransactionalHashingOptions HashingOptions { get; set; }

        ///// <param name="progressHandler">
        ///// Optional <see cref="IProgress{Long}"/> to provide
        ///// progress updates about data transfers.
        ///// </param>
        //IProgress<long> ProgressHandler { get; set; } // TODO: #8506
    }
}
