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
using Azure.Storage.DataMovement.Models;

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
        internal DataTransfer(string id, long bytesTransferred = 0)
        {
            _state = new DataTransferState(id, bytesTransferred);
        }

        /// <summary>
        /// Ensures completion of the DataTransfer and attempts to get result
        /// </summary>
        public void EnsureCompleted(CancellationToken cancellationToken = default)
        {
#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult(). Use the TaskExtensions.EnsureCompleted() extension method instead.
            AwaitCompletion(cancellationToken).GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult(). Use the TaskExtensions.EnsureCompleted() extension method instead.
        }

        /// <summary>
        /// Waits until the data transfer itself has completed
        /// </summary>
        /// <param name="cancellationToken"></param>
        public async Task AwaitCompletion(CancellationToken cancellationToken = default)
        {
            await _state.CompletionSource.Task.AwaitWithCancellation(cancellationToken);
        }

        /// <summary>
        /// Attempts to pause the current Data Transfer.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>
        /// Will return false if the data transfer has already been completed.
        ///
        /// Will return true if the pause has taken place.
        /// </returns>
        public virtual async Task PauseIfRunningAsync(CancellationToken cancellationToken = default)
        {
            await _state.PauseIfRunningAsync(cancellationToken).ConfigureAwait(false);
        }

        internal virtual bool CanPause() => _state.CanPause();
    }
}
