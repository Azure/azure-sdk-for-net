// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Storage.Common;
using static Azure.Storage.DataMovement.TransferInternalState;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Containers information about the transfer and its status as well as provides
    /// hooks to perform operations on the transfer.
    /// </summary>
    public class TransferOperation
    {
        /// <summary>
        /// Defines whether the transfer has completed.
        /// </summary>
        public bool HasCompleted => _state.HasCompleted;

        /// <summary>
        /// Defines the current Transfer Status of the Data Transfer.
        /// </summary>
        public TransferStatus Status => _state.Status;

        /// <summary>
        /// Transfer id.
        /// </summary>
        public string Id => _state.Id;

        /// <summary>
        /// The <see cref="TransferManager"/> responsible for this transfer.
        /// </summary>
        public TransferManager TransferManager { get; internal set; }

        /// <summary>
        /// Defines the current state of the transfer.
        /// </summary>
        internal TransferInternalState _state;

        /// <summary>
        /// For mocking.
        /// </summary>
        internal TransferOperation()
        {
        }

        /// <summary>
        /// Constructing a TransferOperation object.
        /// </summary>
        /// <param name="removeTransferDelegate">Delegate to call to remove transfer from the respective TransferManager.</param>
        /// <param name="id">The transfer ID of the transfer object.</param>
        /// <param name="status">The Transfer Status of the Transfer. See <see cref="TransferStatus"/>.</param>
        internal TransferOperation(
            RemoveTransferDelegate removeTransferDelegate,
            string id,
            TransferStatus status = default)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));
            status ??= new TransferStatus();
            _state = new TransferInternalState(
                removeTransferDelegate,
                id,
                status);
        }

        /// <summary>
        /// Disposes the TransferOperation.
        /// </summary>
        public void Dispose()
        {
            // Set TransferManager to null to break the reference cycle.
            // We cannot dispose TransferManager here as it may still be in use.
            TransferManager = null;
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Waits until the transfer has completed.
        /// </summary>
        /// <param name="cancellationToken"></param>
        public async Task WaitForCompletionAsync(CancellationToken cancellationToken = default)
        {
            await _state.CompletionSource.Task.AwaitWithCancellation(cancellationToken);
        }

        /// <summary>
        /// Attempts to pause the current transfer.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>
        /// Will return false if the transfer has already been completed.
        ///
        /// Will return true if the pause has taken place.
        /// </returns>
        public virtual async Task PauseAsync(CancellationToken cancellationToken = default)
        {
            await _state.PauseIfRunningAsync(cancellationToken).ConfigureAwait(false);
        }

        internal virtual bool CanPause() => _state.CanPause();
    }
}
