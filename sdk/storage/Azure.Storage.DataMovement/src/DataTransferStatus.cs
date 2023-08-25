// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Defines the status of the Transfer Job.
    /// </summary>
    public class DataTransferStatus : IEquatable<DataTransferStatus>
    {
        private object _stateLock = new object();
        private object _hasSkippedLock = new object();
        private object _hasFailedLock = new object();

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

        /// <summary>
        /// Accordingly update the <see cref="HasFailedItems"/> to true. If already set to true, nothing will happen.
        ///
        /// This should only be triggered when a failed item has been seen.
        /// </summary>
        /// <returns>True if <see cref="HasFailedItems"/> was updated. False otherwise.</returns>
        internal bool OnFailedItem()
        {
            lock (_hasFailedLock)
            {
                if (!HasFailedItems)
                {
                    HasFailedItems = true;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Accordingly update the <see cref="HasSkippedItems"/> to true. If already set to true, nothing will happen.
        ///
        /// This should only be triggered when a skipped item has been seen.
        /// </summary>
        /// /// <returns>True if <see cref="HasSkippedItems"/> was updated. False otherwise.</returns>
        internal bool OnSkippedItem()
        {
            lock (_hasSkippedLock)
            {
                if (!HasSkippedItems)
                {
                    HasSkippedItems = true;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Accordingly update the <see cref="State"/>. If the current State is the same as the parameter,
        /// then nothing will happen.
        ///
        /// This should only be triggered when the state updates.
        /// </summary>
        /// <returns>True if <see cref="State"/> was updated. False otherwise.</returns>
        internal bool OnTransferStateChange(TransferState state)
        {
            lock (_stateLock)
            {
                if (state != TransferState.None &&
                    State != state)
                {
                    State = state;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>Returns true if the current object is equal to the other parameter; otherwise, false.</returns>
        public bool Equals(DataTransferStatus other)
            => State.Equals(other.State) &&
            HasFailedItems.Equals(other.HasFailedItems) &&
            HasSkippedItems.Equals(other.HasSkippedItems);

        /// <summary>
        /// Performs a Deep Copy of the <see cref="DataTransferStatus"/>.
        /// </summary>
        /// <returns>A deep copy of the respective <see cref="DataTransferStatus"/>.</returns>
        internal DataTransferStatus DeepCopy()
            => new DataTransferStatus
            {
                State = State,
                HasFailedItems = HasFailedItems,
                HasSkippedItems =HasSkippedItems,
            };
    }
}
