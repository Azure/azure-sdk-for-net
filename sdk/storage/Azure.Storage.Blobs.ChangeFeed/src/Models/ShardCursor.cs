// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Blobs.ChangeFeed
{
    internal class ShardCursor
    {
        /// <summary>
        /// The path of the current Chunk.
        /// </summary>
        public string CurrentChunkPath { get; set; }

        /// <summary>
        /// The byte offset of the beginning of
        /// the current Avro block.
        /// </summary>
        public long BlockOffset { get; set; }

        /// <summary>
        /// The index of the current event within
        /// the current Avro block.
        /// </summary>
        public long EventIndex { get; set; }

        internal ShardCursor(
            string currentChunkPath,
            long blockOffset,
            long eventIndex)
        {
            CurrentChunkPath = currentChunkPath;
            BlockOffset = blockOffset;
            EventIndex = eventIndex;
        }

        /// <summary>
        ///
        /// </summary>
        public ShardCursor() { }
    }
}
