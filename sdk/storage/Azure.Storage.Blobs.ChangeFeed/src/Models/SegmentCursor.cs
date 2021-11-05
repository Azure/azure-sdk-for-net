// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.Blobs.ChangeFeed
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
        /// The path to the current Shard.
        /// </summary>
        public string CurrentShardPath { get; set; }

        /// <summary>
        /// The path of the Segment.
        /// </summary>
        public string SegmentPath { get; set; }

        internal SegmentCursor(
            string segmentPath,
            List<ShardCursor> shardCursors,
            string currentShardPath)
        {
            SegmentPath = segmentPath;
            ShardCursors = shardCursors;
            CurrentShardPath = currentShardPath;
        }

        public SegmentCursor() { }
    }
}
