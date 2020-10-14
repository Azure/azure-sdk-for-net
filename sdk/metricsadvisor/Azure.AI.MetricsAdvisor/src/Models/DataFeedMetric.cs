// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// A <see cref="DataFeedMetric"/> is a quantifiable measure that is used to monitor and assess the status of a specific business process.
    /// It can be a combination of multiple time series values divided into dimensions.
    /// For example, a web health metric might contain dimensions for user count in a specific market.
    /// </summary>
    [CodeGenModel("Metric")]
    public partial class DataFeedMetric
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataFeedMetric"/> class.
        /// </summary>
        /// <param name="metricName">The name of the data source's column with numeric values to be used as a metric. Values of this metric will be read only from the specified column.</param>
        /// <exception cref="ArgumentNullException"><paramref name="metricName"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="metricName"/> is empty.</exception>
        public DataFeedMetric(string metricName)
        {
            Argument.AssertNotNullOrEmpty(metricName, nameof(metricName));

            MetricName = metricName;
        }

        /// <summary>
        /// The unique identifier of this <see cref="DataFeedMetric"/>. Set by the service.
        /// </summary>
        public string MetricId { get; }

        /// <summary>
        /// The name of the data source's column with numeric values to be used as a metric. Values
        /// of this metric will be read only from the specified column.
        /// </summary>
        public string MetricName { get; }

        /// <summary>
        /// The name to be displayed on the web portal instead of the original column name.
        /// </summary>
        public string MetricDisplayName { get; set; }

        /// <summary>
        /// A description of what the values in this <see cref="DataFeedMetric"/> represent.
        /// </summary>
        public string MetricDescription { get; set; }
    }
}
