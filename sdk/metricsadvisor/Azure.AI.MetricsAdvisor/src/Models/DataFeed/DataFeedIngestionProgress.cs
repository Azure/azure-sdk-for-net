// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.MetricsAdvisor.Administration;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// Contains information about the ingestion progress of a <see cref="DataFeed"/>.
    /// </summary>
    public partial class DataFeedIngestionProgress
    {
        /// <summary>
        /// The date and time, in UTC, when the <see cref="DataFeed"/> succeeded in
        /// ingesting data from its data source for the last time. If <c>null</c>,
        /// this information is not available.
        /// </summary>
        public DateTimeOffset? LatestSuccessTimestamp { get; }

        /// <summary>
        /// The date and time, in UTC, when the <see cref="DataFeed"/> changed its
        /// <see cref="IngestionStatusType"/> for the last time. If <c>null</c>,
        /// this information is not available. You can check a data feed's ingestion
        /// status with the <see cref="MetricsAdvisorAdministrationClient.GetDataFeedIngestionStatuses"/>
        /// and the <see cref="MetricsAdvisorAdministrationClient.GetDataFeedIngestionStatusesAsync"/>
        /// operations.
        /// </summary>
        public DateTimeOffset? LatestActiveTimestamp { get; }
    }
}
