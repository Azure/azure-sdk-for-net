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
            if (string.IsNullOrEmpty(beginSnapshot))
                throw new ArgumentNullException(nameof(beginSnapshot));
            if (string.IsNullOrEmpty(endSnapshot))
                throw new ArgumentNullException(nameof(endSnapshot));

            if (!DateTimeOffset.TryParse(beginSnapshot, CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
                throw new ArgumentException(
                    $"'{beginSnapshot}' is not a valid ISO 8601 snapshot timestamp.",
                    nameof(beginSnapshot));

            if (!DateTimeOffset.TryParse(endSnapshot, CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
                throw new ArgumentException(
                    $"'{endSnapshot}' is not a valid ISO 8601 snapshot timestamp.",
                    nameof(endSnapshot));
        }

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
                throw new ArgumentException(
                    $"Begin snapshot '{beginSnapshot}' is not finalized (status: {beginMeta.Status}). " +
                    "Wait for the snapshot to be finalized before querying.",
                    nameof(beginSnapshot));

            if (!endMeta.Status.Equals("Finalized", StringComparison.OrdinalIgnoreCase))
                throw new ArgumentException(
                    $"End snapshot '{endSnapshot}' is not finalized (status: {endMeta.Status}). " +
                    "Wait for the snapshot to be finalized before querying.",
                    nameof(endSnapshot));

            if (beginMeta.SnapshotTimestamp > endMeta.SnapshotTimestamp)
                throw new ArgumentException(
                    $"Begin snapshot '{beginSnapshot}' (taken {beginMeta.SnapshotTimestamp:O}) is later than " +
                    $"end snapshot '{endSnapshot}' (taken {endMeta.SnapshotTimestamp:O}).",
                    nameof(beginSnapshot));

            if (beginMeta.CvId > endMeta.CvId)
                throw new ArgumentException(
                    $"Begin snapshot CvId ({beginMeta.CvId}) exceeds end snapshot CvId ({endMeta.CvId}).",
                    nameof(beginSnapshot));

            if (beginMeta.CvId == endMeta.CvId)
                throw new ArgumentException(
                    $"Begin and end snapshots have the same CvId ({beginMeta.CvId}); the query range is empty.",
                    nameof(endSnapshot));
        }
    }
}
