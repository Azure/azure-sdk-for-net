// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Threading;
using Azure.Storage.DataMovement;

namespace Azure.Storage.Blobs.DataMovement.Models
{
    /// <summary>
    /// Blob Upload Progress Handler to track how many files and bytes were transferred, along with blobs that failed or were skipped in transfer
    /// </summary>
    public class BlobFolderUploadProgress
    {
        private long _totalUploadsCompleted;
        private long _totalUploadsSkipped;
        private long _totalUploadsFailed;
        private long _totalBytesTransferred;
        // convert transferStatus back to StorageTransferStatus, when performing set
        private long _transferStatus;

        /// <summary>
        /// Number of Blobs that succeeded in transfer
        /// </summary>
        public long TotalUploadsCompleted
        {
            get
            {
                return Interlocked.Read(ref _totalUploadsCompleted);
            }
            set
            {
                Interlocked.Exchange(ref _totalUploadsCompleted, value);
            }
        }

        /// <summary>
        /// Number of blobs that were skipped in transfer due to overwrite being set to not overwrite files, but the files exists already
        /// </summary>
        public long TotalUploadsSkipped
        {
            get
            {
                return Interlocked.Read(ref _totalUploadsSkipped);
            }
            set
            {
                Interlocked.Exchange(ref _totalUploadsSkipped, value);
            }
        }

        /// <summary>
        /// Number of blobs that failed transferred.
        /// </summary>
        public long BlobsFailedTransferred
        {
            get
            {
                return Interlocked.Read(ref _totalUploadsSkipped);
            }
            set
            {
                Interlocked.Exchange(ref _totalUploadsFailed, value);
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
                return (StorageTransferStatus) Interlocked.Read(ref _transferStatus);
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
