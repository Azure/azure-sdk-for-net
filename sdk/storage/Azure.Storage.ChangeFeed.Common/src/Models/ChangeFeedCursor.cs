// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.ChangeFeed.Common
{
    internal class ChangeFeedCursor
    {
        public int CursorVersion { get; set; }
        public string UrlHost { get; set; }
        public DateTimeOffset? EndTime { get; set; }
        public SegmentCursor CurrentSegmentCursor { get; set; }

        internal ChangeFeedCursor(string urlHost, DateTimeOffset? endDateTime, SegmentCursor currentSegmentCursor)
        {
            CursorVersion = 1;
            UrlHost = urlHost;
            EndTime = endDateTime;
            CurrentSegmentCursor = currentSegmentCursor;
        }

        public ChangeFeedCursor() { }
    }
}
