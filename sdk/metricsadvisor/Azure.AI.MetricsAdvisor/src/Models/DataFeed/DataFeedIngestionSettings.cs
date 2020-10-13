// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// Configures how a <see cref="DataFeed"/> behaves during data ingestion from its data source.
    /// </summary>
    public class DataFeedIngestionSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataFeedIngestionSettings"/> class.
        /// </summary>
        /// <param name="ingestionStartTime">The starting point in time from which data will be ingested from the data source. Subsequent ingestions happen periodically according to the specified <see cref="DataFeedGranularity"/>.</param>
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
        /// The starting point in time from which data will be ingested from the data source. Subsequent
        /// ingestions happen periodically according to the data feed's granularity.
        /// </summary>
        public DateTimeOffset IngestionStartTime { get; internal set; }

        /// <summary>
        /// If the specified data source supports limited concurrency, this can be set to specify the
        /// maximum limit.
        /// </summary>
        public int? DataSourceRequestConcurrency { get; set; }

        /// <summary>
        /// The minimum delay between two consecutive retry attempts, in case data ingestion
        /// fails. If not specified, the service's behavior depends on the data feed's granularity.
        /// See the <see href="https://docs.microsoft.com/azure/cognitive-services/metrics-advisor/how-tos/onboard-your-data#avoid-loading-partial-data">documentation></see> for details.
        /// </summary>
        public TimeSpan? IngestionRetryDelay { get; set; }

        /// <summary>
        /// An offset to change the next expected data ingestion start times. It can be
        /// used to delay (if positive) or to advance (if negative) the ingestion start
        /// time.
        /// </summary>
        public TimeSpan? IngestionStartOffset { get; set; }

        /// <summary>
        /// Specifies the maximum amount of time in which to attempt a retry if ingestion fails.
        /// </summary>
        public TimeSpan? StopRetryAfter { get; set; }
    }
}
