// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Files.Shares.ChangeFeed
{
    /// <summary>
    /// Pure decision logic for whether a reset referenced by <c>meta/reset-latest.json</c>
    /// should be surfaced to the caller. Shared by the streaming/batched and snapshot
    /// pageables (sync and async) so the surface/dedup rules live in a single, unit-testable
    /// place.
    /// </summary>
    internal static class ResetDetector
    {
        /// <summary>
        /// Decides whether the latest reset described by the pointer should be surfaced.
        /// </summary>
        /// <param name="resetTime">
        /// UTC time of the latest reset (<see cref="ShareChangeFeedResetPointer.LatestResetTimeUtc"/>).
        /// </param>
        /// <param name="resetFileTime">
        /// FILETIME of the latest reset (<see cref="ShareChangeFeedResetPointer.LatestResetFileTime"/>),
        /// used as the ordering anchor against the resumed last-seen value.
        /// </param>
        /// <param name="resetId">
        /// Id of the latest reset (<see cref="ShareChangeFeedResetPointer.LatestResetId"/>),
        /// used to de-duplicate a reset that was already surfaced on a prior page.
        /// </param>
        /// <param name="lastSeenResetFileTime">
        /// Last-seen reset FILETIME carried on the resume token, or <c>null</c> on a fresh enumeration.
        /// </param>
        /// <param name="lastSeenResetId">
        /// Last-seen reset id carried on the resume token, or <c>null</c> on a fresh enumeration.
        /// </param>
        /// <param name="rangeStart">
        /// Lower bound of the requested range (start time or begin-snapshot timestamp), or
        /// <c>null</c> when unbounded (streaming) or unavailable (resume).
        /// </param>
        /// <param name="rangeEnd">
        /// Upper bound of the requested range (end time or end-snapshot timestamp), or
        /// <c>null</c> when unbounded (streaming) or unavailable (resume). Only used to detect
        /// the unbounded/resume case; the reset time is intentionally not compared against it,
        /// since the pointer only ever references the latest reset and an in-range reset must be
        /// surfaced even when a newer reset lands past the end of the range.
        /// </param>
        /// <returns><c>true</c> when the reset should be surfaced (yielded or thrown).</returns>
        public static bool ShouldSurface(
            DateTimeOffset resetTime,
            long resetFileTime,
            Guid resetId,
            long? lastSeenResetFileTime,
            Guid? lastSeenResetId,
            DateTimeOffset? rangeStart,
            DateTimeOffset? rangeEnd)
        {
            bool resetIsNewer = !lastSeenResetFileTime.HasValue
                || resetFileTime > lastSeenResetFileTime.Value;

            // Avoid re-emitting a reset we already surfaced: the resumed token carries the id of
            // the last-seen reset, so skip when the pointer still references that same id.
            bool sameReset = lastSeenResetId.HasValue && resetId == lastSeenResetId.Value;

            // The pointer only ever references the latest reset. A reset in range must be surfaced
            // even when a newer reset lands past the end of the range, so only the lower bound is
            // checked.
            bool resetInRange = rangeStart.HasValue && resetTime >= rangeStart.Value;

            // Unbounded (streaming) or a resume where the range bounds were not re-derived: the
            // pointer being strictly newer than the resume state is enough.
            bool unbounded = !rangeStart.HasValue && !rangeEnd.HasValue;

            return resetIsNewer && !sameReset && (unbounded || resetInRange);
        }
    }
}
