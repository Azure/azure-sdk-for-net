// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.AI.MetricsAdvisor.Administration;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// Specifies which values, such as metrics and dimensions, will be ingested from the <see cref="DataFeedSource"/>.
    /// </summary>
    /// <remarks>
    /// At least one metric must be added to <see cref="MetricColumns"/> when creating a <see cref="DataFeed"/>,
    /// otherwise the creation operation will fail. Other properties are optional.
    /// </remarks>
    public class DataFeedSchema
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataFeedSchema"/> class.
        /// </summary>
        public DataFeedSchema()
        {
            MetricColumns = new ChangeTrackingList<DataFeedMetric>();
            DimensionColumns = new ChangeTrackingList<DataFeedDimension>();
        }

        internal DataFeedSchema(DataFeedDetail dataFeedDetail)
        {
            DimensionColumns = dataFeedDetail.Dimension;
            MetricColumns = dataFeedDetail.Metrics;
            TimestampColumn = dataFeedDetail.TimestampColumn;
        }

        /// <summary>
        /// The metrics used to monitor and assess the status of specific business processes. The service will monitor
        /// how these values vary over time in search of any anomalous behavior.
        /// </summary>
        /// <remarks>
        /// At least one metric must be added to this property when creating a <see cref="DataFeed"/>, otherwise the
        /// creation operation will fail. Once the data feed containing this schema is created, this property cannot
        /// be changed anymore.
        /// </remarks>
        public IList<DataFeedMetric> MetricColumns { get; }

        /// <summary>
        /// The dimensions ingested from the data source. Given a metric, for each set of values these dimensions can
        /// assume, one time series is generated in the service and monitored in search of anomalies.
        /// </summary>
        /// <remarks>
        /// Once the data feed containing this schema is created, this property cannot be changed anymore.
        /// </remarks>
        public IList<DataFeedDimension> DimensionColumns { get; }

        /// <summary>
        /// The name of column of the <see cref="DataFeedSource"/> with date or string values to be used as timestamp.
        /// If not specified, the value of this property defaults to an empty string, and the start time of each data
        /// ingestion will be used instead.
        /// </summary>
        /// <remarks>
        /// If set to null during an update operation, this property is set to its default value.
        /// </remarks>
        public string TimestampColumn { get; set; }
    }
}
