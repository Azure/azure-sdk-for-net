// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// <see cref="TransferOptions"/> is used to provide options for a transfer.
    /// </summary>
    public class TransferOptions : IEquatable<TransferOptions>
    {
        /// <summary>
        /// The maximum size to use for each chunk when transferring data in chunks.
        /// The default value is 4 MiB.
        /// <para/>
        /// When resuming a transfer, the default value will be the value specified
        /// when the transfer was first started but can still be overriden.
        /// <para/>
        /// This value may be clamped to the maximum allowed for the particular transfer/resource type.
        /// </summary>
        public long? MaximumTransferChunkSize { get; set; }

        /// <summary>
        /// The size of the first range request in bytes. Single Transfer sizes smaller than this
        /// limit will be Uploaded or Downloaded in a single request. Transfers larger than this
        /// limit will continue being downloaded or uploaded in chunks of size
        /// <see cref="MaximumTransferChunkSize"/>.
        /// The default value is 32 MiB.
        /// <para/>
        /// When resuming a transfer, the default value will be the value specified
        /// when the transfer was first started but can still be overriden.
        /// <para/>
        /// This value may be clamped to the maximum allowed for the particular transfer/resource type.
        /// </summary>
        public long? InitialTransferSize { get; set; }

        /// <summary>
        /// Optional. Options for changing behavior of the ProgressHandler.
        /// </summary>
        public TransferProgressHandlerOptions ProgressHandlerOptions { get; set; }

        /// <summary>
        /// Check if two ParallelTransferOptions instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj)
            => obj is StorageTransferOptions other
            && Equals(other);

        /// <summary>
        /// Get a hash code for the ParallelTransferOptions.
        /// </summary>
        /// <returns>Hash code for the ParallelTransferOptions.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
            => MaximumTransferChunkSize.GetHashCode()
            ^ InitialTransferSize.GetHashCode();

        /// <summary>
        /// Check if two ParallelTransferOptions instances are equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator ==(TransferOptions left, TransferOptions right) => left.Equals(right);

        /// <summary>
        /// Check if two ParallelTransferOptions instances are equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're not equal, false otherwise.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator !=(TransferOptions left, TransferOptions right) => !(left == right);

        /// <summary>
        /// Check if two ParallelTransferOptions instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Equals(TransferOptions obj)
            => MaximumTransferChunkSize == obj?.MaximumTransferChunkSize
            && InitialTransferSize == obj?.InitialTransferSize;

        /// <summary>
        /// Configures the behavior when a transfer encounters a resource that
        /// already exists.
        /// <para/>
        /// Will default to <see cref="StorageResourceCreationMode.Default"/>
        /// which will be <see cref="StorageResourceCreationMode.FailIfExists"/> when
        /// starting a new transfer.
        /// When resuming a transfer, the value will default to the value used when first starting
        /// the transfer for all resources that were successfully enumerated and the regular default
        /// for any remaining resources.
        /// </summary>
        public StorageResourceCreationMode CreationPreference { get; set; }

        /// <summary>
        /// If the transfer status of the job changes then the event will get added to this handler.
        /// </summary>
        public event SyncAsyncEventHandler<TransferStatusEventArgs> TransferStatusChanged;
        internal SyncAsyncEventHandler<TransferStatusEventArgs> GetTransferStatus() => TransferStatusChanged;

        /// <summary>
        /// If the transfer has any failed events that occur the event will get added to this handler.
        /// </summary>
        public event SyncAsyncEventHandler<TransferItemFailedEventArgs> ItemTransferFailed;

        internal SyncAsyncEventHandler<TransferItemFailedEventArgs> GetFailed() => ItemTransferFailed;

        /// <summary>
        /// If a single transfer within the resource container gets transferred successfully the event
        /// will get added to this handler.
        ///
        /// Only applies to container transfers, not single resource transfers.
        /// </summary>
        public event SyncAsyncEventHandler<TransferItemCompletedEventArgs> ItemTransferCompleted;
        internal SyncAsyncEventHandler<TransferItemCompletedEventArgs> GetCompleted() => ItemTransferCompleted;

        /// <summary>
        /// If the transfer has any skipped events that occur the event will get added to this handler.
        /// Skipped transfer occur during Transfer due to no overwrite allowed as specified in
        /// <see cref="CreationPreference"/>
        /// </summary>
        public event SyncAsyncEventHandler<TransferItemSkippedEventArgs> ItemTransferSkipped;

        internal SyncAsyncEventHandler<TransferItemSkippedEventArgs> GetSkipped() => ItemTransferSkipped;
    }
}
