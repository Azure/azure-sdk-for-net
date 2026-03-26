// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Storage.ChangeFeed.Common
{
    internal class SegmentCursor
    {
        public List<ShardCursor> ShardCursors { get; set; }
        public string CurrentShardPath { get; set; }
        public string SegmentPath { get; set; }

        internal SegmentCursor(string segmentPath, List<ShardCursor> shardCursors, string currentShardPath)
        {
            SegmentPath = segmentPath;
            ShardCursors = shardCursors;
            CurrentShardPath = currentShardPath;
        }

        public SegmentCursor() { }
    }
}
