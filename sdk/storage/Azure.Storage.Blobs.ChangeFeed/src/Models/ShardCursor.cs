// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.Blobs.ChangeFeed.Models
{
    internal class ShardCursor
    {
        /// <summary>
        /// Index of the current Chunk.
        /// </summary>
        public long ChunkIndex { get; set; }

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
            long chunkIndex,
            long blockOffset,
            long eventIndex)
        {
            ChunkIndex = chunkIndex;
            BlockOffset = blockOffset;
            EventIndex = eventIndex;
        }

        /// <summary>
        ///
        /// </summary>
        public ShardCursor() { }
    }
}
