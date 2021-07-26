// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.MetricsAdvisor.Administration;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// A quantifiable measure used to monitor and assess the status of a specific business process. The service will monitor
    /// how this value varies over time in search of any anomalous behavior.
    /// </summary>
    [CodeGenModel("Metric")]
    public partial class DataFeedMetric
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataFeedMetric"/> class.
        /// </summary>
        /// <param name="name">The name of the metric as it appears in its corresponding <see cref="DataFeedSource"/> column.</param>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="name"/> is empty.</exception>
        public DataFeedMetric(string name)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            Name = name;
        }

        /// <summary>
        /// The unique identifier of this <see cref="DataFeedMetric"/>.
        /// </summary>
        /// <remarks>
        /// If <c>null</c>, it means the <see cref="DataFeed"/> containing this metric has not been sent to
        /// the service to be created yet. This property will be set by the service after creation.
        /// </remarks>
        [CodeGenMember("MetricId")]
        public string Id { get; }

        /// <summary>
        /// The name of the metric as it appears in its corresponding <see cref="DataFeedSource"/> column.
        /// </summary>
        [CodeGenMember("MetricName")]
        public string Name { get; }

        /// <summary>
        /// The metric name to be displayed on the web portal. Defaults to the original column name, <see cref="Name"/>.
        /// </summary>
        /// <remarks>
        /// Once the <see cref="DataFeed"/> containing this metric is created, this property cannot be changed anymore.
        /// </remarks>
        [CodeGenMember("MetricDisplayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// A description of what the values in this <see cref="DataFeedMetric"/> represent.
        /// </summary>
        /// <remarks>
        /// Once the <see cref="DataFeed"/> containing this metric is created, this property cannot be changed anymore.
        /// </remarks>
        [CodeGenMember("MetricDescription")]
        public string Description { get; set; }
    }
}
