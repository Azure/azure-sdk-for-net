// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.MetricsAdvisor.Administration;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// Configures how a <see cref="DataFeed"/> should ingest data from its <see cref="DataFeedSource"/>.
    /// </summary>
    public class DataFeedIngestionSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataFeedIngestionSettings"/> class.
        /// </summary>
        /// <param name="ingestionStartsOn">The starting point in time from which data will be ingested from the data source. Subsequent ingestions happen periodically according to the <see cref="DataFeed.Granularity"/>.</param>
        public DataFeedIngestionSettings(DateTimeOffset ingestionStartsOn)
        {
            IngestionStartsOn = ingestionStartsOn;
        }

        internal DataFeedIngestionSettings(DataFeedDetail dataFeedDetail)
        {
            IngestionStartsOn = dataFeedDetail.DataStartFrom;
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
        /// The starting point in time from which data will be ingested from the data source. Subsequent
        /// ingestions happen periodically according to the <see cref="DataFeed.Granularity"/>.
        /// </summary>
        public DateTimeOffset IngestionStartsOn { get; set; }

        /// <summary>
        /// If the associated <see cref="DataFeedSource"/> supports limited concurrency, this can be set to specify
        /// the maximum limit. Defaults to -1 (limited concurrency not supported).
        /// </summary>
        /// <remarks>
        /// If set to null during an update operation, this property is set to its default value.
        /// </remarks>
        public int? DataSourceRequestConcurrency { get; set; }

        /// <summary>
        /// The minimum delay between two consecutive retry attempts, in case data ingestion
        /// fails. If not specified, defaults to -1 seconds, and the service's behavior depends
        /// on the <see cref="DataFeed.Granularity"/>. See the
        /// <see href="https://aka.ms/metricsadvisor/ingestionoptions">documentation</see> for details.
        /// </summary>
        /// <remarks>
        /// If set to null during an update operation, this property is set to its default value.
        /// </remarks>
        public TimeSpan? IngestionRetryDelay { get; set; }

        /// <summary>
        /// An offset to change the next expected data ingestion start times. It can be
        /// used to delay (if positive) or to advance (if negative) the ingestion start
        /// time. Defaults to <see cref="TimeSpan.Zero"/>.
        /// </summary>
        /// <remarks>
        /// If set to null during an update operation, this property is set to its default value.
        /// </remarks>
        public TimeSpan? IngestionStartOffset { get; set; }

        /// <summary>
        /// Specifies the maximum amount of time in which to attempt a retry if ingestion fails.
        /// If not specified, defaults to -1 seconds, and the service's behavior depends on the
        /// <see cref="DataFeed.Granularity"/>. See the
        /// <see href="https://aka.ms/metricsadvisor/ingestionoptions">documentation</see> for details.
        /// </summary>
        /// <remarks>
        /// If set to null during an update operation, this property is set to its default value.
        /// </remarks>
        public TimeSpan? StopRetryAfter { get; set; }
    }
}
