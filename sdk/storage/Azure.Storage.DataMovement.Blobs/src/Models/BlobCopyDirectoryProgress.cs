// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.DataMovement.Blobs.Models
{
    /// <summary>
    /// Blob Upload Progress Handler to track how many files and bytes were transferred, along with blobs that failed or were skipped in transfer
    /// </summary>
    public class BlobCopyDirectoryProgress
    {
        /// <summary>
        /// Number of Blobs that succeeded in transfer
        /// </summary>
        public int BlobsSuccesfullyTransferred { get; internal set; }

        /// <summary>
        /// Number of blobs that failed transferred.
        /// </summary>
        public int BlobsFailedTransferred { get; internal set; }

        /// <summary>
        /// Number of virtual directories transferred fully successfully.
        /// </summary>
        public int DirectoriesSuccessfullyTranferred { get; internal set; }

        /// <summary>
        /// Number of virtual directories that failed transfering any one file.
        /// </summary>
        public int DirectoriesFailedTranferred { get; internal set; }

        /// <summary>
        /// Transfer Status
        /// </summary>
        public StorageJobTransferStatus TransferStatus { get; internal set; }
    }
}
