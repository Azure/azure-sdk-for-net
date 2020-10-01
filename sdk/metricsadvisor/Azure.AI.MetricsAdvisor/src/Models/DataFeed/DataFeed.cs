// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// </summary>
    public class DataFeed
    {
        internal DataFeed(DataFeedDetail dataFeedDetail)
        {
            Id = dataFeedDetail.DataFeedId;
            Status = dataFeedDetail.Status;
            CreatedTime = dataFeedDetail.CreatedTime;
            IsAdministrator = dataFeedDetail.IsAdmin;
            MetricIds = dataFeedDetail.Metrics.Select(metric => metric.MetricId).ToList();
            Name = dataFeedDetail.DataFeedName;
            SourceType = dataFeedDetail.DataSourceType;
            Schema = new DataFeedSchema(dataFeedDetail);
            Granularity = new DataFeedGranularity(dataFeedDetail);
            IngestionSettings = new DataFeedIngestionSettings(dataFeedDetail);
            Options = new DataFeedOptions(dataFeedDetail);
        }

        /// <summary>
        /// </summary>
        public string Id { get; internal set; }

        /// <summary>
        /// </summary>
        public DataFeedStatus? Status { get; }

        /// <summary>
        /// </summary>
        public DateTimeOffset? CreatedTime { get; }

        /// <summary>
        /// </summary>
        public bool? IsAdministrator { get; }

        /// <summary>
        /// </summary>
        public IReadOnlyList<string> MetricIds { get; }

        /// <summary>
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// </summary>
        public DataFeedSourceType SourceType { get; }

        /// <summary>
        /// </summary>
        public DataFeedSchema Schema { get; }

        /// <summary>
        /// </summary>
        public DataFeedGranularity Granularity { get; }

        /// <summary>
        /// </summary>
        public DataFeedIngestionSettings IngestionSettings { get; }

        /// <summary>
        /// </summary>
        public DataFeedOptions Options { get; }
    }
}
