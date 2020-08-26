// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// </summary>
    public class DataFeedSchema
    {
        private IList<MetricDimension> _dimensionColumns;

        /// <summary>
        /// Creates a new instance of the <see cref="DataFeedSchema"/> class.
        /// </summary>
        public DataFeedSchema(IList<DataFeedMetric> metricColumns)
        {
            Argument.AssertNotNull(metricColumns, nameof(metricColumns));

            MetricColumns = metricColumns;
            DimensionColumns = new ChangeTrackingList<MetricDimension>();
        }

        internal DataFeedSchema(DataFeedDetail dataFeedDetail)
        {
            DimensionColumns = dataFeedDetail.Dimension;
            MetricColumns = dataFeedDetail.Metrics;
            TimestampColumn = dataFeedDetail.TimestampColumn;
        }

        /// <summary>
        /// </summary>
        public IList<DataFeedMetric> MetricColumns { get; }

        /// <summary>
        /// </summary>
        public IList<MetricDimension> DimensionColumns
        {
            get => _dimensionColumns;
            set
            {
                Argument.AssertNotNull(value, nameof(DimensionColumns));
                _dimensionColumns = value;
            }
        }

        /// <summary>
        /// </summary>
        public string TimestampColumn { get; set; }
    }
}
