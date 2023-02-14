// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Holds transfer information
    /// </summary>
    public class DataTransfer
    {
        /// <summary>
        /// Defines whether the DataTransfer has completed.
        /// </summary>
        public bool HasCompleted => _state.HasCompleted;

        /// <summary>
        /// Defines the current Transfer Status of the Data Transfer.
        /// </summary>
        public StorageTransferStatus TransferStatus => _state.Status;

        /// <summary>
        /// DataTransfer Identification.
        /// </summary>
        public string Id => _state.Id;

        /// <summary>
        /// Defines the current state of the transfer.
        /// </summary>
        internal DataTransferState _state;

        /// <summary>
        /// Only to be created internally by the transfer manager.
        /// </summary>
        internal DataTransfer()
        {
            _state = new DataTransferState();
        }

        /// <summary>
        /// For mocking
        /// </summary>
        /// <param name="status"></param>
        internal DataTransfer(StorageTransferStatus status)
        {
            _state = new DataTransferState(status);
        }

        /// <summary>
        /// Only to be created internally by the transfer manager when someone
        /// provides a valid job plan file to resume from.
        /// </summary>
        internal DataTransfer(string id, long bytesTransferred)
        {
            _state = new DataTransferState(id, bytesTransferred);
        }

        /// <summary>
        /// Ensures completion of the DataTransfer and attempts to get result
        /// </summary>
        public void EnsureCompleted(CancellationToken cancellationToken = default)
        {
#pragma warning disable AZC0107 // Public asynchronous method shouldn't be called in synchronous scope. Use synchronous version of the method if it is available.
            AwaitCompletion(cancellationToken).EnsureCompleted();
#pragma warning restore AZC0107 // Public asynchronous method shouldn't be called in synchronous scope. Use synchronous version of the method if it is available.
        }

        /// <summary>
        /// Waits until the data transfer itself has completed
        /// </summary>
        /// <param name="cancellationToken"></param>
        public async Task AwaitCompletion(CancellationToken cancellationToken = default)
        {
            cancellationToken.Register(() => _state._completionSource.TrySetCanceled(cancellationToken), useSynchronizationContext: false);
            await _state._completionSource.Task.ConfigureAwait(false);
        }
    }
}
