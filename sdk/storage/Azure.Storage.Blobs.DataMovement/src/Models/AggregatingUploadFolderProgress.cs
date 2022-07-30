// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Azure.Storage.DataMovement;

namespace Azure.Storage.Blobs.DataMovement.Models
{
    internal class AggregatingUploadFolderProgress : IProgress<long>
    {
        private BlobFolderUploadProgress _currentValue;

        private readonly IProgress<BlobFolderUploadProgress> _innerHandler;

        public AggregatingUploadFolderProgress(IProgress<BlobFolderUploadProgress> innerHandler) => _innerHandler = innerHandler;

        /// <summary>
        /// Increments the current value and reports it to the progress handler
        /// </summary>
        /// <param name="progress"></param>
        public void Report(BlobFolderUploadProgress progress)
        {
            _currentValue.TotalUploadsCompleted += progress.TotalUploadsCompleted;
            _currentValue.BlobsFailedTransferred += progress.BlobsFailedTransferred;
            _currentValue.TotalUploadsSkipped += progress.TotalUploadsSkipped;
            _currentValue.TotalBytesTransferred += progress.TotalBytesTransferred;
            _currentValue.TransferStatus = progress.TransferStatus;

            _innerHandler?.Report(Current);
        }

        /// <summary>
        /// Increments the current value and reports it to the progress handler
        /// </summary>
        /// <param name="bytes"></param>
        public void Report(long bytes)
        {
            _currentValue.TotalBytesTransferred += bytes;
            _innerHandler?.Report(Current);
        }

        /// <summary>
        /// Zeroes out the current accumulation, and reports it to the progress handler
        /// </summary>
        public void Reset()
        {
            _currentValue.TotalBytesTransferred = 0;
            _currentValue.TotalUploadsCompleted = 0;
            _currentValue.TotalUploadsSkipped = 0;
            _currentValue.BlobsFailedTransferred = 0;
            _currentValue.TransferStatus = StorageTransferStatus.Queued;
        }

        /// <summary>
        /// Returns an instance that no-ops accumulation.
        /// </summary>
        public static AggregatingProgressIncrementer None { get; } = new AggregatingProgressIncrementer(default);

        /// <summary>
        /// Returns a long instance representing the current progress value.
        /// </summary>
        public BlobFolderUploadProgress Current
        {
            get
            {
                return Volatile.Read(ref _currentValue);
            }
        }
    }
}
