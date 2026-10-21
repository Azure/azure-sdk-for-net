// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Files.Shares.ChangeFeed
{
    /// <summary>
    /// Parsed representation of the mutable pointer blob <c>meta/reset-latest.json</c>
    /// in the change feed container. Rewritten on every reset to point at the newest
    /// per-event blob, so a single conditional GET lets a consumer detect a reset.
    /// </summary>
    internal class ShareChangeFeedResetPointer
    {
        /// <summary>
        /// The schema version of the pointer JSON. Today the service emits <c>1</c>.
        /// </summary>
        public int SchemaVersion { get; set; }

        /// <summary>
        /// Server-generated GUID identifying the latest reset event.
        /// Matches the <see cref="ShareChangeFeedResetMarker.ResetId"/> of the blob at
        /// <see cref="LatestMarkerPath"/>.
        /// </summary>
        public Guid LatestResetId { get; set; }

        /// <summary>
        /// Windows FILETIME ticks (100 ns since 1601 UTC) at which the reset was emitted.
        /// Monotonic per stamp and also encoded into the per-event blob key.
        /// </summary>
        public long LatestResetFileTime { get; set; }

        /// <summary>
        /// Human-readable ISO-8601 UTC representation of <see cref="LatestResetFileTime"/>.
        /// </summary>
        public DateTimeOffset LatestResetTimeUtc { get; set; }

        /// <summary>
        /// Relative blob key of the per-event reset marker
        /// (<c>meta/resets/&lt;20-digit-FILETIME&gt;.json</c>) — usable directly as the GET path.
        /// </summary>
        public string LatestMarkerPath { get; set; }

        /// <summary>
        /// Unversioned account name recorded on the reset event.
        /// </summary>
        public string AccountName { get; set; }

        /// <summary>
        /// Unversioned share (container) name recorded on the reset event.
        /// </summary>
        public string ContainerName { get; set; }

        /// <summary>
        /// Verbatim, human-readable cause of the reset (e.g. "Customer-managed unplanned failover"
        /// or "Tracking State Reset").
        /// </summary>
        public string Reason { get; set; }
    }
}
