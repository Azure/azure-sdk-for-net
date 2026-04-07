// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// The enrichment status of a metric. Enrichment status is described by the service as the process
    /// of detecting which data points of an ingested set of data can be classified as anomalies. An
    /// instance of this class represents the status of a single data source ingestion.
    /// </summary>
    public partial class EnrichmentStatus
    {
        /// <summary>
        /// The date and time, in UTC, of the enrichment attempt.
        /// </summary>
        public DateTimeOffset Timestamp { get; }

        /// <summary>
        /// The enrichment status for this <see cref="Timestamp"/>. This is the status of the
        /// latest attempt.
        /// </summary>
        public string Status { get; }

        /// <summary>
        /// A message created by the service with additional information about the latest
        /// enrichment attempt.
        /// </summary>
        public string Message { get; }
    }
}
