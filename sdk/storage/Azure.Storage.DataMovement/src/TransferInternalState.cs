// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Common;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Defines the state of the transfer
    /// </summary>
    internal class TransferInternalState
    {
        private string _id;
        private TransferStatus _status;
        public TransferManager TransferManager;

        public TaskCompletionSource<TransferStatus> CompletionSource;

        public CancellationTokenSource CancellationTokenSource { get; internal set; }

        public TransferStatus Status => _status;

        /// <summary>
        /// Constructor to resume current jobs
        /// </summary>
        /// <param name="id">The transfer ID of the transfer object.</param>
        /// <param name="status">The Transfer Status of the Transfer. See <see cref="TransferStatus"/>.</param>
        public TransferInternalState(
            string id = default,
            TransferStatus status = default)
        {
            _id = string.IsNullOrEmpty(id) ? Guid.NewGuid().ToString() : id;
            _status = status;
            CompletionSource = new TaskCompletionSource<TransferStatus>(
                _status,
                TaskCreationOptions.RunContinuationsAsynchronously);
            if (TransferState.Completed == status.State)
            {
                CompletionSource.TrySetResult(status);
            }
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
            get {
                return TransferState.Completed == _status.State;
            }
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
        public TransferStatus GetTransferStatus()
        {
            return _status;
        }

        /// <summary>
        /// Sets the completion status
        /// </summary>
        /// <param name="state"></param>
        /// <returns>Returns whether or not the status has been changed from its original state.</returns>
        public bool SetTransferState(TransferState state)
        {
            Argument.AssertNotNull(TransferManager, nameof(TransferManager));
            if (_status.SetTransferStateChange(state))
            {
                if (TransferState.Completed == _status.State ||
                    TransferState.Paused == _status.State)
                {
                    DataMovementEventSource.Singleton.TransferCompleted(Id, _status);
                    // If the _completionSource has been cancelled or the exception
                    // has been set, we don't need to check if TrySetResult returns false
                    // because it's acceptable to cancel or have an error occur before then.

                    CompletionSource.TrySetResult(_status);

                    // Tell the transfer manager to clean up the completed/paused job.
                    TransferManager.TryRemoveTransfer(_id);

                    // Once we reach a Completed/Paused, Dispose the CancellationTokenSource to release resources (since it is no longer needed).
                    DisposeCancellationTokenSource();
                }
                return true;
            }
            return false;
        }

        public bool SetFailedItemsState() => _status.SetFailedItem();

        public bool SetSkippedItemsState() => _status.SetSkippedItem();

        internal bool CanPause()
            => TransferState.InProgress == _status.State || TransferState.Queued == _status.State;

        public async Task PauseIfRunningAsync(CancellationToken cancellationToken)
        {
            if (!CanPause())
            {
                return;
            }
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            // Call the inner cancellation token to stop the transfer job
            SetTransferState(TransferState.Pausing);
            if (TriggerCancellation())
            {
                // Wait until full pause has completed.
                await CompletionSource.Task.AwaitWithCancellation(cancellationToken);
            }
        }

        internal bool TriggerCancellation()
        {
            if (CancellationTokenSource?.IsCancellationRequested == false)
            {
                CancellationTokenSource.Cancel();
                return true;
            }
            return false;
        }

        private void DisposeCancellationTokenSource()
        {
            if (CancellationTokenSource != null)
            {
                CancellationTokenSource.Dispose();
                CancellationTokenSource = null;
            }
        }
    }
}
