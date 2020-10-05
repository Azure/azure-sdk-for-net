// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// </summary>
    public class DataFeedIngestionSettings
    {
        /// <summary>
        /// Creates a new instance of the <see cref="DataFeedIngestionSettings"/> class.
        /// </summary>
        public DataFeedIngestionSettings(DateTimeOffset ingestionStartTime)
        {
            IngestionStartTime = ingestionStartTime;
        }

        internal DataFeedIngestionSettings(DataFeedDetail dataFeedDetail)
        {
            IngestionStartTime = dataFeedDetail.DataStartFrom;
            DataSourceRequestConcurrency = dataFeedDetail.MaxConcurrency;
            IngestionRetryDelay = dataFeedDetail.MinRetryIntervalInSeconds.HasValue
                ? TimeSpan.FromSeconds(dataFeedDetail.MinRetryIntervalInSeconds.Value) as TimeSpan?
                : null;
            IngestionStartOffset = dataFeedDetail.StartOffsetInSeconds.HasValue
                ? TimeSpan.FromSeconds(dataFeedDetail.StartOffsetInSeconds.Value) as TimeSpan?
                : null;
            StopRetryAfter = dataFeedDetail.StopRetryAfterInSeconds.HasValue
                ? TimeSpan.FromSeconds(dataFeedDetail.StopRetryAfterInSeconds.Value) as TimeSpan?
                : null;
        }

        /// <summary>
        /// </summary>
        public DateTimeOffset IngestionStartTime { get; set; }

        /// <summary>
        /// </summary>
        public int? DataSourceRequestConcurrency { get; set; }

        /// <summary>
        /// </summary>
        public TimeSpan? IngestionRetryDelay { get; set; }

        /// <summary>
        /// </summary>
        public TimeSpan? IngestionStartOffset { get; set; }

        /// <summary>
        /// </summary>
        public TimeSpan? StopRetryAfter { get; set; }
    }
}
