// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    // TODODOCS: hard to explain.
    /// <summary>
    /// </summary>
    [CodeGenModel("Metric")]
    public partial class DataFeedMetric
    {
        /// <summary>
        /// Creates a new instance of the <see cref="DataFeedMetric"/> class.
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
