// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.CompilerServices;
using System.Threading;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Defines the status of the Transfer Job.
    /// </summary>
    public class DataTransferStatus
    {
        /// <summary>
        /// Defines the types of the state a transfer can have.
        /// </summary>
        public enum TransferState
        {
            /// <summary>
            /// Default value.
            /// </summary>
            None = 0,

            /// <summary>
            /// The transfer has been queued up but has not yet started.
            /// </summary>
            Queued = 1,

            /// <summary>
            /// The transfer has started, but has not yet completed.
            /// </summary>
            InProgress = 2,

            /// <summary>
            /// The transfer has started and is in the process of being paused.
            ///
            /// Transfer can be stopped if  <see cref="TransferManager.PauseTransferIfRunningAsync(string, System.Threading.CancellationToken)"/>
            /// or <see cref="DataTransfer.PauseAsync(CancellationToken)"/> is called.
            /// </summary>
            Pausing = 3,

            /// <summary>
            /// The transfer has started and is in the process of being stopped.
            ///
            /// Transfer can be stopped if <see cref="DataTransferErrorMode.StopOnAnyFailure"/> is
            /// enabled in the <see cref="TransferManagerOptions.ErrorHandling"/>.
            /// </summary>
            Stopping = 4,

            /// <summary>
            /// The transfer has been paused. When transfer is paused
            /// (e.g. see <see cref="TransferManager.PauseTransferIfRunningAsync(string, System.Threading.CancellationToken)"/>)
            /// during the transfer, this will be the value.
            /// </summary>
            Paused = 5,

            /// <summary>
            /// The transfer has come to a completed state. If the transfer has started and
            /// has fully stopped will also come to this state.
            /// </summary>
            Completed = 6
        }

        /// <summary>
        /// Defines the state of the transfer.
        /// </summary>
        public TransferState State { get; internal set; }

        /// <summary>
        /// Represents if the transfer has completed successfully without any failure or skipped items.
        /// </summary>
        public bool HasCompletedSuccessfully =>
            (State == TransferState.Completed) &&
            !HasFailedItems &&
            !HasSkippedItems;

        /// <summary>
        /// Represents if transfer has any failure items.
        ///
        /// If set to `true`, the transfer has at least one failure item.
        /// If set to `false`, the transfer currently has no failures.
        /// </summary>
        public bool HasFailedItems { get; internal set; }

        /// <summary>
        /// Represents if transfer has any skipped items.
        ///
        /// If set to `true`, the transfer has at least one item it has skipped.
        /// If set to `false`, the transfer currently has no items that has been skipped.
        ///
        /// It's possible to never have any items skipped if
        /// <see cref="StorageResourceCreationPreference.SkipIfExists"/> is not enabled in the <see cref="DataTransferOptions.CreationPreference"/>.
        /// </summary>
        public bool HasSkippedItems { get; internal set; }

        /// <summary>
        /// Constructor to set the initial state to <see cref="TransferState.Queued"/> with no failures or skipped items.
        /// </summary>
        protected internal DataTransferStatus()
        {
            State = TransferState.Queued;
            HasFailedItems = false;
            HasSkippedItems = false;
        }

        /// <summary>
        /// Constructor to have a custom state, failure state, and skipped state.
        /// </summary>
        protected internal DataTransferStatus(TransferState state, bool hasFailureItems, bool hasSkippedItems)
        {
            State = state;
            HasFailedItems = hasFailureItems;
            HasSkippedItems = hasSkippedItems;
        }

        internal bool IsCompletedWithFailedItems => State.Equals(TransferState.Completed) && HasFailedItems;
        internal bool IsCompletedWithSkippedItems => State.Equals(TransferState.Completed) && HasSkippedItems;
    }
}
