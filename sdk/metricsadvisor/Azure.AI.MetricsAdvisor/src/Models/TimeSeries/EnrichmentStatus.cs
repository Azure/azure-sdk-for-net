// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary> The EnrichmentStatus. </summary>
    public partial class EnrichmentStatus
    {
        /// <summary> Data slice timestamp. </summary>
        public DateTimeOffset Timestamp { get; }

        /// <summary> Latest enrichment status for this data slice. </summary>
        public string Status { get; }

        /// <summary> The trimmed message describes details of the enrichment status. </summary>
        public string Message { get; }
    }
}
