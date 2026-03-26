// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Storage.ChangeFeed.Common
{
    /// <summary>
    /// Cursor that captures the read position within a single segment (time window).
    /// </summary>
    internal class SegmentCursor
    {
        /// <summary>
        /// Per-shard cursors tracking the read position in each shard of this segment.
        /// </summary>
        public List<ShardCursor> ShardCursors { get; set; }

        /// <summary>
        /// Path of the shard that was being read when the cursor was captured, used to resume round-robin iteration.
        /// </summary>
        public string CurrentShardPath { get; set; }

        /// <summary>
        /// Blob path of the segment manifest (e.g. "idx/segments/2020/03/25/0200/meta.json").
        /// </summary>
        public string SegmentPath { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SegmentCursor"/> class.
        /// </summary>
        /// <param name="segmentPath">Blob path of the segment manifest.</param>
        /// <param name="shardCursors">Cursors for each shard in the segment.</param>
        /// <param name="currentShardPath">Path of the shard that was last read.</param>
        internal SegmentCursor(string segmentPath, List<ShardCursor> shardCursors, string currentShardPath)
        {
            SegmentPath = segmentPath;
            ShardCursors = shardCursors;
            CurrentShardPath = currentShardPath;
        }

        /// <summary>
        /// Parameterless constructor for deserialization.
        /// </summary>
        public SegmentCursor() { }
    }
}
