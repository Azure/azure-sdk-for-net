// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Threading;
using Azure.Storage.DataMovement;

namespace Azure.Storage.Blobs.DataMovement.Models
{
    /// <summary>
    /// Blob Upload Progress Handler to track how many files and bytes were transferred, along with blobs that failed or were skipped in transfer
    /// </summary>
    public class BlobFolderCopyProgress
    {
        private long _totalCopiesCompleted;
        private long _totalCopiesFailed;
        private long _totalDirectoriesCopiesCompleted;
        private long _totalDirectoriesCopiesFailed;
        // convert transferStatus back to StorageTransferStatus, when performing set
        private long _transferStatus;

        /// <summary>
        /// Number of Blobs that succeeded in transfer
        /// </summary>
        public long TotalCopiesCompleted
        {
            get
            {
                return Interlocked.Read(ref _totalCopiesCompleted);
            }
            set
            {
                Interlocked.Exchange(ref _totalCopiesCompleted, value);
            }
        }

        /// <summary>
        /// Number of blobs that failed transferred.
        /// </summary>
        public long TotalCopiesFailed
        {
            get
            {
                return Interlocked.Read(ref _totalCopiesFailed);
            }
            set
            {
                Interlocked.Exchange(ref _totalCopiesFailed, value);
            }
        }

        /// <summary>
        /// Number of virtual directories transferred fully successfully.
        /// </summary>
        public long TotalDirectoriesCopiesCompleted
        {
            get
            {
                return Interlocked.Read(ref _totalDirectoriesCopiesCompleted);
            }
            set
            {
                Interlocked.Exchange(ref _totalDirectoriesCopiesCompleted, value);
            }
        }

        /// <summary>
        /// Number of virtual directories that failed transfering any one file.
        /// </summary>
        public long TotalDirectoriesCopiesFailed
        {
            get
            {
                return Interlocked.Read(ref _totalDirectoriesCopiesFailed);
            }
            set
            {
                Interlocked.Exchange(ref _totalDirectoriesCopiesFailed, value);
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
