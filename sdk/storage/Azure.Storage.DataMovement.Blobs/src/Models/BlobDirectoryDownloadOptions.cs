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
        /// Optional <see cref="BlobDirectoryRequestConditions"/> to add conditions on
        /// the copying of data to this blob.
        /// </summary>
        public BlobDirectoryRequestConditions DirectoryRequestConditions { get; set; }

        /// <summary>
        /// Optional <see cref="IProgress{StorageTransferStatus}"/> to provide
        /// progress updates about data transfers.
        /// TODO: replace long value with appropriate model similar to BlobUploadDirectoryResponse
        /// </summary>
        public IProgress<StorageTransferStatus> ProgressHandler { get; set; }

        /// <summary>
        /// Optional <see cref="StorageTransferOptions"/> to configure
        /// parallel transfer behavior.
        /// </summary>
        public StorageTransferOptions TransferOptions { get; set; }

        /// <summary>
        /// Setting to upload ONLY the contents of the directory. Default set to false.
        /// </summary>
        public bool ContentsOnly { get; set; }
    }
}
