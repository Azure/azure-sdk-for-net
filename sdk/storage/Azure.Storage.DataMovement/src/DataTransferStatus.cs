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

        /// <summary>
        /// Defines the state of the transfer.
        /// </summary>
        public DataTransferState State { get; internal set; }

        /// <summary>
        /// Represents if the transfer has completed successfully without any failure or skipped items.
        /// </summary>
        public bool HasCompletedSuccessfully =>
            (State == DataTransferState.Completed) &&
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
        /// Constructor to set the initial state to <see cref="DataTransferState.Queued"/> with no failures or skipped items.
        /// </summary>
        protected internal DataTransferStatus()
        {
            State = DataTransferState.Queued;
            HasFailedItems = false;
            HasSkippedItems = false;
        }

        /// <summary>
        /// Constructor to have a custom state, failure state, and skipped state.
        /// </summary>
        protected internal DataTransferStatus(DataTransferState state, bool hasFailureItems, bool hasSkippedItems)
        {
            State = state;
            HasFailedItems = hasFailureItems;
            HasSkippedItems = hasSkippedItems;
        }

        internal bool IsCompletedWithFailedItems => State.Equals(DataTransferState.Completed) && HasFailedItems;
        internal bool IsCompletedWithSkippedItems => State.Equals(DataTransferState.Completed) && HasSkippedItems;

        /// <summary>
        /// Accordingly update the <see cref="HasFailedItems"/> to true. If already set to true, nothing will happen.
        ///
        /// This should only be triggered when a failed item has been seen.
        /// </summary>
        /// <returns>True if <see cref="HasFailedItems"/> was updated. False otherwise.</returns>
        internal bool TrySetFailedItem()
        {
            if (!HasFailedItems)
            {
                HasFailedItems = true;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Accordingly update the <see cref="HasSkippedItems"/> to true. If already set to true, nothing will happen.
        ///
        /// This should only be triggered when a skipped item has been seen.
        /// </summary>
        /// /// <returns>True if <see cref="HasSkippedItems"/> was updated. False otherwise.</returns>
        internal bool TrySetSkippedItem()
        {
            if (!HasSkippedItems)
            {
                HasSkippedItems = true;
                return true;
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
        internal bool TrySetTransferStateChange(DataTransferState state)
        {
            lock (_stateLock)
            {
                if (state != DataTransferState.None &&
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
