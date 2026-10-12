// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Files.Shares.ChangeFeed
{
    /// <summary>
    /// Parsed representation of an immutable per-event reset marker blob
    /// (<c>meta/resets/&lt;20-digit-FILETIME&gt;.json</c>) in the change feed container.
    /// Exactly one blob is written per reset event.
    /// </summary>
    internal class ShareChangeFeedResetMarker
    {
        /// <summary>
        /// Add-only contract version of the per-event JSON. Today the service emits <c>1</c>.
        /// </summary>
        public int SchemaVersion { get; set; }

        /// <summary>
        /// Server-generated GUID (<c>controlEventId</c>) for this reset event.
        /// </summary>
        public Guid ResetId { get; set; }

        /// <summary>
        /// Windows FILETIME ticks (100 ns since 1601 UTC) at which the reset was emitted.
        /// </summary>
        public long ResetFileTime { get; set; }

        /// <summary>
        /// Human-readable ISO-8601 UTC representation of <see cref="ResetFileTime"/>.
        /// </summary>
        public DateTimeOffset ResetTimeUtc { get; set; }

        /// <summary>
        /// Unversioned account name recorded on the reset event.
        /// </summary>
        public string AccountName { get; set; }

        /// <summary>
        /// Unversioned share (container) name recorded on the reset event.
        /// </summary>
        public string ContainerName { get; set; }

        /// <summary>
        /// Verbatim, human-readable cause of the reset. The service emits the reason directly
        /// (e.g. "Customer-managed unplanned failover" or "Tracking State Reset").
        /// </summary>
        public string Reason { get; set; }
    }
}
