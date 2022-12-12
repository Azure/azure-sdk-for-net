// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.Storage.DataMovement.Models
{
    /// <summary>
    /// <see cref="SingleTransferOptions"/> is used to provide options for parallel transfers.
    /// </summary>
    public class SingleTransferOptions : IEquatable<SingleTransferOptions>
    {
        /// <summary>
        /// The maximum length of an transfer in bytes.
        ///
        /// On uploads, if the value is not set, it will be set at 4 MB if the total size is less than 100MB
        /// or will default to 8 MB if the total size is greater than or equal to 100MB.
        /// </summary>
        public long? MaximumTransferChunkSize { get; set; }

        /// <summary>
        /// The size of the first range request in bytes. Single Transfer sizes smaller than this
        /// limit will be Uploaded or Downloaded in a single request.
        /// Transfers larger than this limit will continue being downloaded or uploaded
        /// in chunks of size <see cref="MaximumTransferChunkSize"/>.
        ///
        /// On Uploads, if the value is not set, it will set at 256 MB. (TODO: We should lower to 32 MB)
        /// </summary>
        public long? InitialTransferSize { get; set; }

        /// <summary>
        /// Optional. Defines the checkpoint id that the transfer should continue from and will
        /// grab transfer information from TransferManagerOptions.Checkpointer.
        ///
        /// TODO: https://github.com/Azure/azure-sdk-for-net/issues/32955
        /// </summary>
        internal string ResumeFromCheckpointId { get; set; }

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
        public static bool operator ==(SingleTransferOptions left, SingleTransferOptions right) => left.Equals(right);

        /// <summary>
        /// Check if two ParallelTransferOptions instances are equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're not equal, false otherwise.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator !=(SingleTransferOptions left, SingleTransferOptions right) => !(left == right);

        /// <summary>
        /// Check if two ParallelTransferOptions instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Equals(SingleTransferOptions obj)
            => MaximumTransferChunkSize == obj?.MaximumTransferChunkSize
            && InitialTransferSize == obj?.InitialTransferSize;

        /// <summary>
        /// Optional <see cref="StorageResourceCreateMode"/> to configure overwrite
        /// behavior. Will default to <see cref="StorageResourceCreateMode.Overwrite"/>.
        /// </summary>
        public StorageResourceCreateMode CreateMode { get; set; }

        /// <summary>
        /// If the transfer status of the job changes then the event will get added to this handler.
        /// </summary>
        public event SyncAsyncEventHandler<TransferStatusEventArgs> TransferStatus;
        internal SyncAsyncEventHandler<TransferStatusEventArgs> GetTransferStatus() => TransferStatus;

        /// <summary>
        /// If the transfer has any failed events that occur the event will get added to this handler.
        /// </summary>
        public event SyncAsyncEventHandler<TransferFailedEventArgs> TransferFailed;

        internal SyncAsyncEventHandler<TransferFailedEventArgs> GetFailed() => TransferFailed;

        /// <summary>
        /// If the transfer has any skipped events that occur the event will get added to this handler.
        /// Skipped transfer occur during Transfer due to no overwrite allowed as specified in
        /// <see cref="CreateMode"/>
        /// </summary>
        public event SyncAsyncEventHandler<TransferSkippedEventArgs> TransferSkipped;

        internal SyncAsyncEventHandler<TransferSkippedEventArgs> GetSkipped() => TransferSkipped;
    }
}
