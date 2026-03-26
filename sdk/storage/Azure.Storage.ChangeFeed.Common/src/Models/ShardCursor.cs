// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.ChangeFeed.Common
{
    internal class ShardCursor
    {
        public string CurrentChunkPath { get; set; }
        public long BlockOffset { get; set; }
        public long EventIndex { get; set; }

        internal ShardCursor(string currentChunkPath, long blockOffset, long eventIndex)
        {
            CurrentChunkPath = currentChunkPath;
            BlockOffset = blockOffset;
            EventIndex = eventIndex;
        }

        public ShardCursor() { }
    }
}
