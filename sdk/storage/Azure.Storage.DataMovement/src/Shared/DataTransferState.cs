// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Defines the state of the transfer
    /// </summary>
    internal class DataTransferState : IAsyncDisposable
    {
        // To detect redundant calls
        private bool _disposedValue;

        private string _id;
        private StorageTransferStatus _status;
        private long _currentTransferredBytes;
        private SemaphoreSlim _statusSemaphore;

        public StorageTransferStatus Status => _status;

        /// <summary>
        /// constructor
        /// </summary>
        public DataTransferState()
        {
            _disposedValue = false;
            _statusSemaphore = new SemaphoreSlim(1, 1);
            _id = Guid.NewGuid().ToString();
            _status = StorageTransferStatus.Queued;
            _currentTransferredBytes = 0;
        }

        /// <summary>
        /// constructor for mocking
        /// </summary>
        public DataTransferState(StorageTransferStatus status)
        {
            _id = Guid.NewGuid().ToString();
            _status = status;
            _currentTransferredBytes = 0;
        }

        /// <summary>
        /// Constructor to resume current jobs
        /// </summary>
        public DataTransferState(string id, long bytesTransferred)
        {
            _id = id;
            _status = StorageTransferStatus.Queued;
            _currentTransferredBytes = bytesTransferred;
        }

        public async ValueTask DisposeAsync()
        {
            if (!_disposedValue)
            {
                _disposedValue = true;
                if (_statusSemaphore.CurrentCount == 0)
                {
                    await _statusSemaphore.WaitAsync().ConfigureAwait(false);
                    _statusSemaphore.Release();
                }
                _statusSemaphore.Dispose();
            }
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
        public async Task SetTransferStatus(StorageTransferStatus status)
        {
            if (!_disposedValue)
            {
                await _statusSemaphore.WaitAsync().ConfigureAwait(false);
                if (_status != status)
                {
                    _status = status;
                }
                _statusSemaphore.Release();
            }
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
