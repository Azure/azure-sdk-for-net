// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// Contains information about a <see cref="DataFeed"/>'s attempt to ingest data
    /// from its data source.
    /// </summary>
    [CodeGenModel("IngestionStatus")]
    public partial class DataFeedIngestionStatus
    {
        /// <summary>
        /// The date and time, in UTC, of the ingestion attempt.
        /// </summary>
        public DateTimeOffset Timestamp { get; }

        /// <summary>
        /// The ingestion status for this <see cref="Timestamp"/>. This is the status of the
        /// latest attempt.
        /// </summary>
        public IngestionStatusType Status { get; }

        /// <summary>
        /// A message created by the service with additional information about the latest
        /// ingestion attempt.
        /// </summary>
        public string Message { get; }
    }
}
