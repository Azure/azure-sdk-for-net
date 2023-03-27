// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Defines the state of the transfer
    /// </summary>
    internal class DataTransferState
    {
        private readonly object _statusLock = new object();
        private string _id;
        private StorageTransferStatus _status;

        private long _currentTransferredBytes;
        private object _lockCurrentBytes = new object();

        public TaskCompletionSource<StorageTransferStatus> CompletionSource;

        public CancellationTokenSource CancellationTokenSource { get; internal set; }

        public StorageTransferStatus Status => _status;

        /// <summary>
        /// constructor
        /// </summary>
        public DataTransferState()
            : this(StorageTransferStatus.Queued)
        {
        }

        /// <summary>
        /// constructor for mocking
        /// </summary>
        public DataTransferState(StorageTransferStatus status)
        {
            _id = Guid.NewGuid().ToString();
            _status = status;
            _currentTransferredBytes = 0;
            CompletionSource = new TaskCompletionSource<StorageTransferStatus>(
                _status,
                TaskCreationOptions.RunContinuationsAsynchronously);
            if (StorageTransferStatus.Completed == status ||
                        StorageTransferStatus.CompletedWithSkippedTransfers == status ||
                        StorageTransferStatus.CompletedWithFailedTransfers == status)
            {
                CompletionSource.TrySetResult(status);
            }
            CancellationTokenSource = new CancellationTokenSource();
        }

        /// <summary>
        /// Constructor to resume current jobs
        /// </summary>
        public DataTransferState(string id, long bytesTransferred)
        {
            _id = id;
            _status = StorageTransferStatus.Queued;
            _currentTransferredBytes = bytesTransferred;
            CompletionSource = new TaskCompletionSource<StorageTransferStatus>(
                _status,
                TaskCreationOptions.RunContinuationsAsynchronously);
            CancellationTokenSource = new CancellationTokenSource();
        }

        /// <summary>
        /// Gets the identifier of the transfer state
        /// </summary>
        public string Id
        {
            get { return _id; }
            internal set { }
        }

        /// <summary>
        /// Defines whether the transfer is completed
        /// </summary>
        public bool HasCompleted
        {
            get { return _status >= StorageTransferStatus.Completed; }
            internal set { }
        }

        /// <summary>
        /// Defines how many bytes are transferred to far
        /// </summary>
        public long TransferredBytes
        {
            get { return _currentTransferredBytes; }
            internal set { }
        }

        /// <summary>
        /// Sets the id of the transfer
        /// </summary>
        /// <param name="id"></param>
        public void SetId(string id)
        {
            _id = id;
        }

        /// <summary>
        /// Gets the status of the transfer
        /// </summary>
        /// <returns></returns>
        public StorageTransferStatus GetTransferStatus()
        {
            lock (_statusLock)
            {
                return _status;
            }
        }

        /// <summary>
        /// Sets the completion status
        /// </summary>
        /// <param name="status"></param>
        /// <returns>Returns whether or not the status has been changed/set</returns>
        public bool SetTransferStatus(StorageTransferStatus status)
        {
            lock (_statusLock)
            {
                if (_status != status)
                {
                    _status = status;
                    if (StorageTransferStatus.Completed == status ||
                        StorageTransferStatus.CompletedWithSkippedTransfers == status ||
                        StorageTransferStatus.CompletedWithFailedTransfers == status)
                    {
                        // If the _completionSource has been cancelled or the exception
                        // has been set, we don't need to check if TrySetResult returns false
                        // because it's acceptable to cancel or have an error occur before then.
                        CompletionSource.TrySetResult(status);
                    }
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// Incrementes the amount of bytes to the current value
        /// </summary>
        public void ResetTransferredBytes()
        {
            lock (_lockCurrentBytes)
            {
                Volatile.Write(ref _currentTransferredBytes, 0);
            }
        }

        /// <summary>
        /// Incrementes the amount of bytes to the current value
        /// </summary>
        /// <param name="transferredBytes"></param>
        public void UpdateTransferBytes(long transferredBytes)
        {
            lock (_lockCurrentBytes)
            {
                Interlocked.Add(ref _currentTransferredBytes, transferredBytes);
            }
        }

        public Task<bool> TryPauseAsync(CancellationToken cancellationToken)
        {
            if (StorageTransferStatus.Paused == _status ||
                StorageTransferStatus.Completed == _status ||
                StorageTransferStatus.CompletedWithSkippedTransfers == _status ||
                StorageTransferStatus.CompletedWithFailedTransfers == _status)
            {
                return Task.FromResult(false);
            }
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            // Call the inner cancellation token to stop the transfer job
            if (TriggerCancellation())
            {
                SetTransferStatus(StorageTransferStatus.Paused);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

        internal bool TriggerCancellation()
        {
            if (!CancellationTokenSource.IsCancellationRequested)
            {
                CancellationTokenSource.Cancel();
                return true;
            }
            return false;
        }
    }
}
