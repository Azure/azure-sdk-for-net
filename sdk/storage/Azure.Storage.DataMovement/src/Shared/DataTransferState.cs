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
        private readonly object statusLock = new object();
        private string _id;
        private StorageTransferStatus _status;
        private long _currentTransferredBytes;
        public TaskCompletionSource<StorageTransferStatus> _completionSource;

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
            _completionSource = new TaskCompletionSource<StorageTransferStatus>(
                _status,
                TaskCreationOptions.RunContinuationsAsynchronously);
            if (StorageTransferStatus.Completed == status ||
                        StorageTransferStatus.CompletedWithSkippedTransfers == status ||
                        StorageTransferStatus.CompletedWithFailedTransfers == status)
            {
                _completionSource.SetResult(status);
            }
        }

        /// <summary>
        /// Constructor to resume current jobs
        /// </summary>
        public DataTransferState(string id, long bytesTransferred)
        {
            _id = id;
            _status = StorageTransferStatus.Queued;
            _currentTransferredBytes = bytesTransferred;
            _completionSource = new TaskCompletionSource<StorageTransferStatus>(
                _status,
                TaskCreationOptions.RunContinuationsAsynchronously);
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
        /// Sets the completion status
        /// </summary>
        /// <param name="status"></param>
        public Task SetTransferStatus(StorageTransferStatus status)
        {
            lock (statusLock)
            {
                if (_status != status)
                {
                    if (StorageTransferStatus.Completed == status ||
                        StorageTransferStatus.CompletedWithSkippedTransfers == status ||
                        StorageTransferStatus.CompletedWithFailedTransfers == status)
                    {
                        _completionSource.SetResult(status);
                    }
                    _status = status;
                }
            }
            return Task.CompletedTask;
        }

        /// <summary>
        /// Incrementes the amount of bytes to the current value
        /// </summary>
        public void ResetTransferredBytes()
        {
            Volatile.Write(ref _currentTransferredBytes, 0);
        }

        /// <summary>
        /// Incrementes the amount of bytes to the current value
        /// </summary>
        /// <param name="transferredBytes"></param>
        public void UpdateTransferBytes(long transferredBytes)
        {
            Interlocked.Add(ref _currentTransferredBytes, transferredBytes);
        }
    }
}
