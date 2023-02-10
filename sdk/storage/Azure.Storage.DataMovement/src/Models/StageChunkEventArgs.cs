// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// This class is interchangable for
    /// Stage Block (Put Block), Stage Block From Uri (Put Block From URL),
    /// Append Block (Append Block), Append Block From Uri (Append Block From URL),
    /// Upload Page (Put Page), Upload Pages From Uri (Put Pages From URL)
    ///
    /// Basically any transfer operation that must end in a Commit Block List
    /// will end up using this internal event argument to track the success
    /// and the bytes transferred to ensure the correct amount of bytes are tranferred.
    /// </summary>
    internal class StageChunkEventArgs : StorageTransferEventArgs
    {
        public bool Success { get; }

        public long Offset { get; }

        /// <summary>
        /// Will be 0 if Success is false
        /// </summary>
        public long BytesTransferred { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="transferId"></param>
        /// <param name="success"></param>
        /// <param name="offset"></param>
        /// <param name="bytesTransferred"></param>
        /// <param name="isRunningSynchronously"></param>
        /// <param name="cancellationToken"></param>
        public StageChunkEventArgs(
            string transferId,
            bool success,
            long offset,
            long bytesTransferred,
            bool isRunningSynchronously,
            CancellationToken cancellationToken) :
            base(transferId, isRunningSynchronously, cancellationToken)
        {
            Success = success;
            Offset = offset;
            BytesTransferred = bytesTransferred;
        }
    }
}
