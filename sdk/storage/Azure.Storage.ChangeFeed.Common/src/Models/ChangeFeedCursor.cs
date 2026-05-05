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
        /// Whether the producing run had <c>IncludeUnfinalizedEvents</c> enabled. Used by Files
        /// Change Feed to validate cursor replays: a cursor produced with this flag set may
        /// not be replayed against a run that has the flag cleared, since events past the
        /// finalized watermark may have been emitted that a flag-off replay would silently skip.
        /// Always <c>false</c> for Blob Change Feed (which does not expose the option).
        /// V1 cursors (produced before this property was added) deserialize to <c>false</c>,
        /// which is the correct safe default.
        /// </summary>
        public bool IncludeUnfinalizedEvents { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeFeedCursor"/> class.
        /// </summary>
        /// <param name="urlHost">Storage account host name.</param>
        /// <param name="endDateTime">Optional end time for the change feed window.</param>
        /// <param name="currentSegmentCursor">Cursor for the current segment position.</param>
        /// <param name="includeUnfinalizedEvents">
        /// Whether the producing run had <c>IncludeUnfinalizedEvents</c> enabled. Defaults to
        /// <c>false</c> so existing callers (including Blob Change Feed) get the safe value.
        /// </param>
        internal ChangeFeedCursor(
            string urlHost,
            DateTimeOffset? endDateTime,
            SegmentCursor currentSegmentCursor,
            bool includeUnfinalizedEvents = false)
        {
            CursorVersion = 2;
            UrlHost = urlHost;
            EndTime = endDateTime;
            CurrentSegmentCursor = currentSegmentCursor;
            IncludeUnfinalizedEvents = includeUnfinalizedEvents;
        }

        /// <summary>
        /// Parameterless constructor for deserialization.
        /// </summary>
        public ChangeFeedCursor() { }
    }
}
