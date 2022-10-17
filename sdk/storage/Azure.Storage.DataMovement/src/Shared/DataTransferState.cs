// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using Azure.Core;
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Defines the state of the transfer
    /// </summary>
    internal class DataTransferState
    {
        private string _id;
        private StorageTransferStatus _status;
        private long _currentTransferredBytes;

        /// <summary>
        /// constructor
        /// </summary>
        public DataTransferState()
        {
            _id = Guid.NewGuid().ToString();
            _status = StorageTransferStatus.Queued;
            _currentTransferredBytes = 0;
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
        public bool IsCompleted
        {
            get { return _status == StorageTransferStatus.Completed; }
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
        public void SetTransferStatus(StorageTransferStatus status)
        {
            if (_status != status)
            {
                _status = status;
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
