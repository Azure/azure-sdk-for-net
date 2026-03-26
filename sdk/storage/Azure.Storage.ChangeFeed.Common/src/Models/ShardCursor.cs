// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.ChangeFeed.Common
{
    /// <summary>
    /// Cursor that captures the read position within a single shard, identifying the chunk, block, and event offset.
    /// </summary>
    internal class ShardCursor
    {
        /// <summary>
        /// Blob path of the chunk (Avro file) currently being read.
        /// </summary>
        public string CurrentChunkPath { get; set; }

        /// <summary>
        /// Byte offset of the current Avro block within the chunk, used to seek directly to the right block on resume.
        /// </summary>
        public long BlockOffset { get; set; }

        /// <summary>
        /// Zero-based index of the next event within the current block.
        /// </summary>
        public long EventIndex { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShardCursor"/> class.
        /// </summary>
        /// <param name="currentChunkPath">Blob path of the current chunk.</param>
        /// <param name="blockOffset">Byte offset of the current Avro block.</param>
        /// <param name="eventIndex">Event index within the current block.</param>
        internal ShardCursor(string currentChunkPath, long blockOffset, long eventIndex)
        {
            CurrentChunkPath = currentChunkPath;
            BlockOffset = blockOffset;
            EventIndex = eventIndex;
        }

        /// <summary>
        /// Parameterless constructor for deserialization.
        /// </summary>
        public ShardCursor() { }
    }
}
