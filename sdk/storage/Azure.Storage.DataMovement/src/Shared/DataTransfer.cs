// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Holds transfer information.
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
        public DataTransferStatus TransferStatus => _state.Status;

        /// <summary>
        /// DataTransfer Identification.
        /// </summary>
        public string Id => _state.Id;

        /// <summary>
        /// The <see cref="TransferManager"/> responsible for this transfer.
        /// </summary>
        public TransferManager TransferManager { get; }

        /// <summary>
        /// Defines the current state of the transfer.
        /// </summary>
        internal DataTransferInternalState _state;

        /// <summary>
        /// For mocking.
        /// </summary>
        internal DataTransfer()
        {
        }

        /// <summary>
        /// Constructing a DataTransfer object.
        /// </summary>
        /// <param name="id">The transfer ID of the transfer object.</param>
        /// <param name="transferManager">Reference to the transfer manager running this transfer.</param>
        /// <param name="status">The Transfer Status of the Transfer. See <see cref="DataTransferStatus"/>.</param>
        internal DataTransfer(
            string id,
            TransferManager transferManager,
            DataTransferStatus status = default)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));
            Argument.AssertNotNull(transferManager, nameof(transferManager));
            status ??= new DataTransferStatus();
            _state = new DataTransferInternalState(id, status);
            TransferManager = transferManager;
        }

        /// <summary>
        /// Ensures completion of the DataTransfer and attempts to get result
        /// </summary>
        public void WaitForCompletion(CancellationToken cancellationToken = default)
        {
#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult(). Use the TaskExtensions.EnsureCompleted() extension method instead.
            WaitForCompletionAsync(cancellationToken).GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult(). Use the TaskExtensions.EnsureCompleted() extension method instead.
        }

        /// <summary>
        /// Waits until the data transfer itself has completed
        /// </summary>
        /// <param name="cancellationToken"></param>
        public async Task WaitForCompletionAsync(CancellationToken cancellationToken = default)
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
        public virtual async Task PauseAsync(CancellationToken cancellationToken = default)
        {
            await _state.PauseIfRunningAsync(cancellationToken).ConfigureAwait(false);
        }

        internal virtual bool CanPause() => _state.CanPause();
    }
}
