// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// Defines how a <see cref="DataFeed"/> structures the data ingested from the data source in terms
    /// of metrics and dimensions. This schema defines how many time series are generated for anomaly
    /// detection.
    /// </summary>
    public class DataFeedSchema
    {
        private IList<DataFeedDimension> _dimensionColumns;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataFeedSchema"/> class.
        /// </summary>
        /// <param name="metricColumns">The metrics ingested from the data feed. The values of these metrics are monitored in search of anomalies. Cannot be empty.</param>
        /// <exception cref="ArgumentNullException"><paramref name="metricColumns"/> is null.</exception>
        public DataFeedSchema(IList<DataFeedMetric> metricColumns)
        {
            Argument.AssertNotNull(metricColumns, nameof(metricColumns));

            MetricColumns = metricColumns;
            DimensionColumns = new ChangeTrackingList<DataFeedDimension>();
        }

        internal DataFeedSchema(DataFeedDetail dataFeedDetail)
        {
            DimensionColumns = dataFeedDetail.Dimension;
            MetricColumns = dataFeedDetail.Metrics;
            TimestampColumn = dataFeedDetail.TimestampColumn;
        }

        /// <summary>
        /// The metrics ingested from the data source. The values of these metrics are
        /// monitored in search of anomalies. Cannot be empty.
        /// </summary>
        public IList<DataFeedMetric> MetricColumns { get; }

        /// <summary>
        /// The dimensions ingested from the data source. Given a metric, for each set of
        /// values this set of dimensions can assume, one time series is generated and
        /// monitored in search of anomalies.
        /// </summary>
        /// <exception cref="ArgumentNullException"><see cref="DimensionColumns"/> is null.</exception>
#pragma warning disable CA2227 // Collection properties should be readonly
        public IList<DataFeedDimension> DimensionColumns
        {
            get => _dimensionColumns;
            set
            {
                Argument.AssertNotNull(value, nameof(DimensionColumns));
                _dimensionColumns = value;
            }
        }
#pragma warning restore CA2227 // Collection properties should be readonly

        /// <summary>
        /// The name of the data source's column with date or string values to be used as timestamp.
        /// If not specified, the time when a data point is ingested will be used instead.
        /// </summary>
        public string TimestampColumn { get; set; }
    }
}
