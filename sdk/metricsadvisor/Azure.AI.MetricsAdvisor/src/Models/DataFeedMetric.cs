// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// </summary>
    [CodeGenModel("Metric")]
    public partial class DataFeedMetric
    {
        /// <summary>
        /// Creates a new instance of the <see cref="DataFeedMetric"/> class.
        /// </summary>
        /// <param name="metricName"></param>
        public DataFeedMetric(string metricName)
        {
            Argument.AssertNotNullOrEmpty(metricName, nameof(metricName));

            MetricName = metricName;
        }

        /// <summary>
        /// </summary>
        public string MetricId { get; }

        /// <summary>
        /// </summary>
        public string MetricName { get; }

        /// <summary>
        /// </summary>
        public string MetricDisplayName { get; }

        /// <summary>
        /// </summary>
        public string MetricDescription { get; }
    }
}
