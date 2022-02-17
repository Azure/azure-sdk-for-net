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
    public class BlobDownloadDirectoryProgress
    {
        /// <summary>
        /// Number of Blobs that succeeded in transfer
        /// </summary>
        public long BlobsSuccesfullyTransferred { get; internal set; }

        /// <summary>
        /// Number of Blobs that succeeded in transfer
        /// </summary>
        public long BlobsSkippedTransferred { get; internal set; }

        /// <summary>
        /// Number of blobs that failed transferred.
        /// </summary>
        public long BlobsFailedTransferred { get; internal set; }
        /// <summary>
        /// Number of bytes transferred succesfully.
        /// </summary>
        public long TotalBytesTransferred { get; internal set; }
    }
}
