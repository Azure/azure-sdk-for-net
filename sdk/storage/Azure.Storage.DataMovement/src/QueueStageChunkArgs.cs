// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// This class is interchangeable for
    /// Stage Block (Put Block), Stage Block From Uri (Put Block From URL),
    /// Append Block (Append Block), Append Block From Uri (Append Block From URL),
    /// Upload Page (Put Page), Upload Pages From Uri (Put Pages From URL)
    ///
    /// Basically any transfer operation that must end in a Commit Block List
    /// will end up using this internal event argument to track the success
    /// and the bytes transferred to ensure the correct amount of bytes are transferred.
    /// </summary>
    internal class QueueStageChunkArgs
    {
        public long Offset { get; }
        public long BytesTransferred { get; }

        public QueueStageChunkArgs(long offset, long bytesTransferred)
        {
            Offset = offset;
            BytesTransferred = bytesTransferred;
        }
    }
}
