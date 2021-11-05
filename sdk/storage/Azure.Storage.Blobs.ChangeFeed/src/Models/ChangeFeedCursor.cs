// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Blobs.ChangeFeed
{
    /// <summary>
    /// BlobChangeFeedCursor.
    /// </summary>
    internal class ChangeFeedCursor
    {
        /// <summary>
        /// CursorVersion.
        /// </summary>
        public int CursorVersion { get; set; }

        /// <summary>
        /// UrlHost. The host component of the container URL.
        /// </summary>
        public string UrlHost { get; set; }

        /// <summary>
        /// EndDateTime.
        /// </summary>
        public DateTimeOffset? EndTime { get; set; }

        /// <summary>
        /// The Segment Cursor for the current segment.
        /// </summary>
        public SegmentCursor CurrentSegmentCursor { get; set; }

        internal ChangeFeedCursor(
            string urlHost,
            DateTimeOffset? endDateTime,
            SegmentCursor currentSegmentCursor)
        {
            CursorVersion = 1;
            UrlHost = urlHost;
            EndTime = endDateTime;
            CurrentSegmentCursor = currentSegmentCursor;
        }

        public ChangeFeedCursor() { }
    }
}
