// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;

namespace Azure.Storage.Files.Shares.ChangeFeed
{
    /// <summary>
    /// Validates inputs and parsed metadata for snapshot-range change feed queries
    /// (<see cref="ShareChangeFeedSnapshotPageable"/> / <see cref="ShareChangeFeedSnapshotAsyncPageable"/>).
    /// </summary>
    internal static class SnapshotInputValidator
    {
        /// <summary>
        /// Validates the raw begin/end snapshot strings supplied by the caller.
        /// Throws synchronously for argument errors so the user sees the problem at the
        /// call site rather than during enumeration.
        /// </summary>
        public static void ValidateInputStrings(string beginSnapshot, string endSnapshot)
        {
            ValidateInputString(beginSnapshot, nameof(beginSnapshot));
            ValidateInputString(endSnapshot, nameof(endSnapshot));
        }

        /// <summary>
        /// Validates a single raw snapshot string supplied by the caller. Throws synchronously
        /// for argument errors so the user sees the problem at the call site.
        /// </summary>
        public static void ValidateInputString(string snapshot, string paramName)
        {
            if (string.IsNullOrEmpty(snapshot))
                throw ShareChangeFeedErrors.ArgumentNull(paramName);

            if (!IsValidUtcSnapshot(snapshot))
                throw ShareChangeFeedErrors.InvalidSnapshotTimestamp(snapshot, paramName);
        }

        // Snapshot timestamps are surfaced by the service in UTC ISO 8601 with an uppercase 'Z'
        // suffix and are used verbatim to derive the meta blob path. Accepting any other offset
        // would let two strings that name the same UTC instant resolve to different paths
        // (and thus the wrong blob), so we require the canonical form here.
        private static bool IsValidUtcSnapshot(string s)
            => s.EndsWith("Z", StringComparison.Ordinal)
            && DateTimeOffset.TryParse(
                s,
                CultureInfo.InvariantCulture,
                DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal,
                out _);

        /// <summary>
        /// Validates the parsed snapshot metadata after it has been read from the change feed container.
        /// Enforces that both snapshots are finalized, that begin precedes end, and that the
        /// container version range is non-empty.
        /// </summary>
        public static void ValidateMetadata(
            SnapshotMetadata beginMeta,
            string beginSnapshot,
            SnapshotMetadata endMeta,
            string endSnapshot)
        {
            if (!beginMeta.Status.Equals("Finalized", StringComparison.OrdinalIgnoreCase))
                throw ShareChangeFeedErrors.SnapshotNotFinalized("Begin", beginSnapshot, beginMeta.Status, nameof(beginSnapshot));

            if (!endMeta.Status.Equals("Finalized", StringComparison.OrdinalIgnoreCase))
                throw ShareChangeFeedErrors.SnapshotNotFinalized("End", endSnapshot, endMeta.Status, nameof(endSnapshot));

            if (beginMeta.SnapshotTimestamp > endMeta.SnapshotTimestamp)
                throw ShareChangeFeedErrors.BeginSnapshotAfterEnd(
                    beginSnapshot,
                    beginMeta.SnapshotTimestamp,
                    endSnapshot,
                    endMeta.SnapshotTimestamp,
                    nameof(beginSnapshot));

            if (beginMeta.CvId > endMeta.CvId)
                throw ShareChangeFeedErrors.BeginSnapshotCvIdExceedsEnd(beginMeta.CvId, endMeta.CvId, nameof(beginSnapshot));

            if (beginMeta.CvId == endMeta.CvId)
                throw ShareChangeFeedErrors.EmptySnapshotRange(beginMeta.CvId, nameof(endSnapshot));
        }
    }
}
