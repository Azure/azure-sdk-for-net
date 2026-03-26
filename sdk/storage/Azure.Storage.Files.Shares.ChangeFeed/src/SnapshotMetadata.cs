// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Files.Shares.ChangeFeed
{
    /// <summary>
    /// Represents the metadata parsed from a snapshot <c>meta.json</c> file located at
    /// <c>idx/snapshots/YYYY/MM/DD/HH/mm/ss/meta.json</c> within the change feed blob container.
    /// This metadata describes a point-in-time snapshot of the file share and is used
    /// to correlate snapshot boundaries with change feed events.
    /// </summary>
    internal class SnapshotMetadata
    {
        /// <summary>
        /// The schema version of the snapshot metadata format.
        /// </summary>
        public int Version { get; set; }

        /// <summary>
        /// The timestamp when the snapshot was taken.
        /// </summary>
        public DateTimeOffset SnapshotTimestamp { get; set; }

        /// <summary>
        /// The container version ID (CvId) at the time of the snapshot. This is used
        /// to filter change feed events when querying between two snapshots.
        /// </summary>
        public long CvId { get; set; }

        /// <summary>
        /// The earliest log window timestamp from which the next snapshot's events may appear.
        /// Used as the start time when building a change feed query between snapshots.
        /// </summary>
        public DateTimeOffset MinLogWindowForNextSnapshot { get; set; }

        /// <summary>
        /// The latest log window timestamp covered by this snapshot's events.
        /// Used as the end time when building a change feed query between snapshots.
        /// </summary>
        public DateTimeOffset MaxLogWindowForCurrentSnapshot { get; set; }

        /// <summary>
        /// The finalization status of the snapshot (e.g., "Finalized").
        /// A snapshot must be finalized before it can be used as an endpoint for between-snapshot queries.
        /// </summary>
        public string Status { get; set; }
    }
}
