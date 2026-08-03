// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.ChangeFeed.Common;

namespace Azure.Storage.Files.Shares.ChangeFeed
{
    /// <summary>
    /// Outer continuation-token envelope produced by <see cref="ShareChangeFeedPageable"/> and
    /// <see cref="ShareChangeFeedAsyncPageable"/>. Wraps the underlying Common
    /// <see cref="ChangeFeedCursor"/> plus the last reset marker observed by this consumer so
    /// the SDK can decide on resume whether a new reset (with a strictly-greater
    /// <see cref="LastSeenResetFileTime"/>) has appeared since the token was issued.
    /// </summary>
    /// <remarks>
    /// This envelope is Files-only and is not shared with
    /// <c>Azure.Storage.Blobs.ChangeFeed</c>; the Common
    /// <see cref="ChangeFeedCursor"/> is left unchanged so Blob Change Feed cursors remain
    /// stable on the wire.
    ///
    /// Persisted as the JSON-serialized <see cref="Page{T}.ContinuationToken"/> string on
    /// pages emitted by the streaming pageables. When
    /// <see cref="ShareChangeFeedClientOptions.IncludeNonFinalizedEvents"/> is enabled,
    /// pages do not carry a continuation token and this envelope is not emitted.
    /// </remarks>
    internal class ShareChangeFeedCursor
    {
        /// <summary>
        /// Schema version of the envelope. Pinned at <c>1</c> today; bump and gate in
        /// <see cref="ShareChangeFeedCursorSerializer.Validate"/> when the shape changes.
        /// </summary>
        public int CursorVersion { get; set; }

        /// <summary>
        /// Host portion of the change-feed container URL, used to validate that a cursor
        /// matches the target account. Mirrors <see cref="ChangeFeedCursor.UrlHost"/> from Common.
        /// </summary>
        public string UrlHost { get; set; }

        /// <summary>
        /// Underlying Common change-feed cursor from the raw page. Forwarded back into
        /// <see cref="ChangeFeedFactoryBase{TEvent}.BuildChangeFeed(ChangeFeedCursor, bool, System.Threading.CancellationToken, bool)"/>
        /// on resume so the typed cursor crosses the layer boundary without a JSON round-trip.
        /// </summary>
        public ChangeFeedCursor InnerCursor { get; set; }

        /// <summary>
        /// GUID of the most recent reset marker observed by this consumer, or <c>null</c> when
        /// no reset marker has been observed. Compared against the pointer's
        /// <see cref="ShareChangeFeedResetPointer.LatestResetId"/> at resume time to detect
        /// resets that occurred while the caller held the token.
        /// </summary>
        public Guid? LastSeenResetId { get; set; }

        /// <summary>
        /// FILETIME ticks of the most recent reset marker observed by this consumer, or
        /// <c>null</c> when no reset marker has been observed. FILETIME is monotonic per stamp
        /// and is used as the actual ordering key when comparing against
        /// <see cref="ShareChangeFeedResetPointer.LatestResetFileTime"/>.
        /// </summary>
        public long? LastSeenResetFileTime { get; set; }

        /// <summary>
        /// Lower bound of the original query's time range, or <c>null</c> when the query was
        /// unbounded (streaming). Persisted so a resumed batched <c>GetChanges(start, end)</c>
        /// reconstructs its range and does not degrade to unbounded reset detection. Absent on
        /// tokens issued before this field was added, in which case it deserializes to <c>null</c>.
        /// </summary>
        public DateTimeOffset? RangeStart { get; set; }

        /// <summary>
        /// Upper bound of the original query's time range, or <c>null</c> when the query was
        /// unbounded (streaming). Persisted so a resumed batched <c>GetChanges(start, end)</c>
        /// does not read events past the requested end. Absent on tokens issued before this
        /// field was added, in which case it deserializes to <c>null</c>.
        /// </summary>
        public DateTimeOffset? RangeEnd { get; set; }

        /// <summary>
        /// <c>true</c> when the token was issued by a batched (time-range) query, <c>false</c>
        /// for a streaming query. Persisted so resume via <c>GetChanges(continuationToken)</c>
        /// reuses the original API's smart policy default instead of always resolving as
        /// streaming. Absent on tokens issued before this field was added, in which case it
        /// deserializes to <c>false</c>.
        /// </summary>
        public bool IsBatched { get; set; }

        /// <summary>
        /// Parameterless constructor for <c>JsonSerializer</c>.
        /// </summary>
        public ShareChangeFeedCursor() { }

        /// <summary>
        /// Initializes a new envelope wrapping <paramref name="innerCursor"/> and the supplied
        /// reset-observation state.
        /// </summary>
        internal ShareChangeFeedCursor(
            string urlHost,
            ChangeFeedCursor innerCursor,
            Guid? lastSeenResetId,
            long? lastSeenResetFileTime,
            DateTimeOffset? rangeStart = null,
            DateTimeOffset? rangeEnd = null,
            bool isBatched = false)
        {
            CursorVersion = 1;
            UrlHost = urlHost;
            InnerCursor = innerCursor;
            LastSeenResetId = lastSeenResetId;
            LastSeenResetFileTime = lastSeenResetFileTime;
            RangeStart = rangeStart;
            RangeEnd = rangeEnd;
            IsBatched = isBatched;
        }
    }
}
