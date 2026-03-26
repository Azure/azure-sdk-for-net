// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.ChangeFeed.Common
{
    /// <summary>
    /// Top-level cursor that captures the full state needed to resume change feed consumption.
    /// Serialized as the continuation token in paginated responses.
    /// </summary>
    internal class ChangeFeedCursor
    {
        /// <summary>
        /// Schema version of the cursor, used for forward-compatibility checks.
        /// </summary>
        public int CursorVersion { get; set; }

        /// <summary>
        /// Host portion of the storage account URL, used to validate that a cursor matches the target account.
        /// </summary>
        public string UrlHost { get; set; }

        /// <summary>
        /// The end time boundary originally requested, preserved so a resumed cursor applies the same window.
        /// </summary>
        public DateTimeOffset? EndTime { get; set; }

        /// <summary>
        /// Cursor for the segment that was being read when the page was produced.
        /// </summary>
        public SegmentCursor CurrentSegmentCursor { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeFeedCursor"/> class.
        /// </summary>
        /// <param name="urlHost">Storage account host name.</param>
        /// <param name="endDateTime">Optional end time for the change feed window.</param>
        /// <param name="currentSegmentCursor">Cursor for the current segment position.</param>
        internal ChangeFeedCursor(string urlHost, DateTimeOffset? endDateTime, SegmentCursor currentSegmentCursor)
        {
            // TODO: If the cursor schema diverges from Blob CF's format, bump this version
            // so that old cursors are rejected gracefully.
            CursorVersion = 1;
            UrlHost = urlHost;
            EndTime = endDateTime;
            CurrentSegmentCursor = currentSegmentCursor;
        }

        /// <summary>
        /// Parameterless constructor for deserialization.
        /// </summary>
        public ChangeFeedCursor() { }
    }
}
