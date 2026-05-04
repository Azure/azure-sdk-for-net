// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Files.Shares.ChangeFeed
{
    /// <summary>
    /// Options for configuring the behavior of <see cref="ShareChangeFeedClient"/>.
    /// </summary>
    public class ShareChangeFeedClientOptions
    {
        /// <summary>
        /// The maximum size, in bytes, for a single blob download transfer when reading change feed segments.
        /// If not set, the default transfer size is used.
        /// </summary>
        public long? MaximumTransferSize { get; set; }

        /// <summary>
        /// When set to <c>true</c>, the change feed reader will return events whose timestamps
        /// are after the change feed's last consumable (finalized) watermark. By default
        /// (<c>false</c>), reads are capped at the watermark to ensure all events for a given
        /// time window are durably finalized before being returned.
        /// </summary>
        /// <remarks>
        /// Enable this option when consuming the most recent activity is more important than
        /// completeness. Events read past the watermark may be from segments the service has
        /// not yet finalized, which means: (1) the set of events returned for a given time
        /// window may be incomplete; (2) two consecutive reads of the same window may return
        /// different events; and (3) segments may appear, grow, or be partially written
        /// between calls.
        /// </remarks>
        public bool IncludeUnfinalizedEvents { get; set; }
    }
}
