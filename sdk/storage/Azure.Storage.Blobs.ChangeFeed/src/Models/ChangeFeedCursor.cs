// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.Blobs.ChangeFeed.Models
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
        /// UrlHash.
        /// </summary>
        public long UrlHash { get; set; }

        /// <summary>
        /// EndDateTime.
        /// </summary>
        public DateTimeOffset? EndTime { get; set; }

        /// <summary>
        /// The Segment Cursor for the current segment.
        /// </summary>
        public SegmentCursor CurrentSegmentCursor { get; set; }

        internal ChangeFeedCursor(
            long urlHash,
            DateTimeOffset? endDateTime,
            SegmentCursor currentSegmentCursor)
        {
            CursorVersion = 1;
            UrlHash = urlHash;
            EndTime = endDateTime;
            CurrentSegmentCursor = currentSegmentCursor;
        }

        public ChangeFeedCursor() { }
    }
}
