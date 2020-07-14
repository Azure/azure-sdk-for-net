// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.Blobs.ChangeFeed.Models
{
    /// <summary>
    /// Segment Cursor.
    /// </summary>
    internal class SegmentCursor
    {
        /// <summary>
        /// Shard Cursors.
        /// </summary>
        public List<ShardCursor> ShardCursors { get; set; }

        /// <summary>
        /// Index of the current Shard.
        /// </summary>
        public int ShardIndex { get; set; }

        /// <summary>
        /// The DateTimeOffset of the Segment.
        /// </summary>
        public DateTimeOffset SegmentTime { get; set; }

        internal SegmentCursor(
            DateTimeOffset segmentDateTime,
            List<ShardCursor> shardCursors,
            int shardIndex)
        {
            SegmentTime = segmentDateTime;
            ShardCursors = shardCursors;
            ShardIndex = shardIndex;
        }

        public SegmentCursor() { }
    }
}
