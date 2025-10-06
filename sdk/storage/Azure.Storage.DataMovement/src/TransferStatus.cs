// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Defines the status of the Transfer Job.
    /// </summary>
    public class TransferStatus : IEquatable<TransferStatus>
    {
        private int _hasFailedItemValue;
        private int _hasSkippedItemValue;
        private int _stateValue;

        /// <summary>
        /// Defines the state of the transfer.
        /// </summary>
        public TransferState State => (TransferState)_stateValue;

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
        public bool HasFailedItems => _hasFailedItemValue != 0;

        /// <summary>
        /// Represents if transfer has any skipped items.
        ///
        /// If set to `true`, the transfer has at least one item it has skipped.
        /// If set to `false`, the transfer currently has no items that has been skipped.
        ///
        /// It's possible to never have any items skipped if
        /// <see cref="StorageResourceCreationMode.SkipIfExists"/> is not enabled in the <see cref="TransferOptions.CreationMode"/>.
        /// </summary>
        public bool HasSkippedItems => _hasSkippedItemValue != 0;

        /// <summary>
        /// Constructor to set the initial state to <see cref="TransferState.Queued"/> with no failures or skipped items.
        /// </summary>
        protected internal TransferStatus()
        {
            _stateValue = (int)TransferState.Queued;
            _hasFailedItemValue = 0; // Initialized to false
            _hasSkippedItemValue = 0; // Initialized to false
        }

        /// <summary>
        /// Constructor to have a custom state, failure state, and skipped state.
        /// </summary>
        protected internal TransferStatus(TransferState state, bool hasFailureItems, bool hasSkippedItems)
        {
            _stateValue = (int)state;
            _hasFailedItemValue = hasFailureItems ? 1 : 0;
            _hasSkippedItemValue = hasSkippedItems ? 1 : 0;
        }

        internal bool IsCompletedWithFailedItems => State.Equals(TransferState.Completed) && HasFailedItems;
        internal bool IsCompletedWithSkippedItems => State.Equals(TransferState.Completed) && HasSkippedItems;

        /// <summary>
        /// Accordingly update the <see cref="HasFailedItems"/> to true. If already set to true, nothing will happen.
        ///
        /// This should only be triggered when a failed item has been seen.
        /// </summary>
        /// <returns>True if this was the first time <see cref="HasFailedItems"/> was updated. False otherwise.</returns>
        internal bool SetFailedItem()
        {
            return Interlocked.Exchange(ref _hasFailedItemValue, 1) != 1;
        }

        /// <summary>
        /// Accordingly update the <see cref="HasSkippedItems"/> to true. If already set to true, nothing will happen.
        ///
        /// This should only be triggered when a skipped item has been seen.
        /// </summary>
        /// /// <returns>True if this was the first time <see cref="HasSkippedItems"/> was updated. False otherwise.</returns>
        internal bool SetSkippedItem()
        {
            return Interlocked.Exchange(ref _hasSkippedItemValue, 1) != 1;
        }

        /// <summary>
        /// Accordingly update the <see cref="State"/>. If the current State is the same as the parameter,
        /// then nothing will happen.
        ///
        /// This should only be triggered when the state updates.
        /// </summary>
        /// <returns>True if <see cref="State"/> was changed from its original state. False otherwise.</returns>
        internal bool SetTransferStateChange(TransferState state)
        {
            return Interlocked.Exchange(ref _stateValue, (int)state) != (int)state;
        }

        /// <inheritdoc/>
        public bool Equals(TransferStatus other)
        {
            if (other == null)
            {
                return false;
            }

            return State.Equals(other.State) &&
                HasFailedItems.Equals(other.HasFailedItems) &&
                HasSkippedItems.Equals(other.HasSkippedItems);
        }

        /// <summary>
        /// Equality operator.
        /// </summary>
        /// <param name="left">The left hand side.</param>
        /// <param name="right">The right hand side.</param>
        /// <returns>True, if the two values are equal; otherwise false.</returns>
        public static bool operator ==(TransferStatus left, TransferStatus right)
        {
            if (left is null != right is null)
            {
                return false;
            }
            return left?.Equals(right) ?? true;
        }

        /// <summary>
        /// Inequality operator.
        /// </summary>
        /// <param name="left">The left hand side.</param>
        /// <param name="right">The right hand side.</param>
        /// <returns>True, if the two values are not equal; otherwise false.</returns>
        public static bool operator !=(TransferStatus left, TransferStatus right) => !(left == right);

        /// <inheritdoc/>
        public override bool Equals(object obj) => Equals(obj as TransferStatus);

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1225395075;
            hashCode = hashCode * -1521134295 + State.GetHashCode();
            hashCode = hashCode * -1521134295 + HasFailedItems.GetHashCode();
            hashCode = hashCode * -1521134295 + HasSkippedItems.GetHashCode();
            return hashCode;
        }

        /// <summary>
        /// Performs a Deep Copy of the <see cref="TransferStatus"/>.
        /// </summary>
        /// <returns>A deep copy of the respective <see cref="TransferStatus"/>.</returns>
        internal TransferStatus DeepCopy()
            => new()
            {
                _stateValue = _stateValue,
                _hasFailedItemValue = _hasFailedItemValue,
                _hasSkippedItemValue = _hasSkippedItemValue,
            };
    }
}
