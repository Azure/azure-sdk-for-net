// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Threading;
using Azure.Storage.DataMovement;

namespace Azure.Storage.Blobs.DataMovement.Models
{
    /// <summary>
    /// Blob Upload Progress Handler to track how many files and bytes were transferred, along with blobs that failed or were skipped in transfer
    /// </summary>
    public class BlobFolderDownloadProgress
    {
        private long _totalDownloadsCompleted;
        private long _totalDownloadsSkipped;
        private long _totalDownloadsFailed;
        private long _totalBytesTransferred;
        // convert transferStatus back to StorageTransferStatus, when performing set
        private long _transferStatus;

        /// <summary>
        /// Number of Blobs that succeeded in transfer
        /// </summary>
        public long TotalDownloadsCompleted
        {
            get
            {
                return Interlocked.Read(ref _totalDownloadsCompleted);
            }
            set
            {
                Interlocked.Exchange(ref _totalDownloadsCompleted, value);
            }
        }

        /// <summary>
        /// Number of Blobs that succeeded in transfer
        /// </summary>
        public long TotalDownloadsSkipped
        {
            get
            {
                return Interlocked.Read(ref _totalDownloadsSkipped);
            }
            set
            {
                Interlocked.Exchange(ref _totalDownloadsSkipped, value);
            }
        }

        /// <summary>
        /// Number of blobs that failed transferred.
        /// </summary>
        public long TotalDownloadsFailed
        {
            get
            {
                return Interlocked.Read(ref _totalDownloadsFailed);
            }
            set
            {
                Interlocked.Exchange(ref _totalDownloadsFailed, value);
            }
        }

        /// <summary>
        /// Number of bytes transferred succesfully.
        /// </summary>
        public long TotalBytesTransferred
        {
            get
            {
                return Interlocked.Read(ref _totalBytesTransferred);
            }
            set
            {
                Interlocked.Exchange(ref _totalBytesTransferred, value);
            }
        }

        /// <summary>
        /// Transfer Status
        /// </summary>
        public StorageTransferStatus TransferStatus
        {
            get
            {
                return (StorageTransferStatus)Interlocked.Read(ref _transferStatus);
            }
            set
            {
                Interlocked.Exchange(ref _transferStatus, (long)value);
            }
        }

        /// <summary>
        /// Transfer Job Id.
        /// </summary>
        public string TransferId { get; internal set; }
    }
}
