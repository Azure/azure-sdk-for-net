// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Monitor.Query.Metrics.Models
{
    public partial class MetricsQueryResult
    {
        private MetricsQueryTimeRange? _timeRange;

        /// <summary>
        /// The time span for which the data was retrieved.
        /// This may be adjusted in the future and returned back from what was originally requested.
        /// </summary>
        public MetricsQueryTimeRange TimeSpan => _timeRange ??= new MetricsQueryTimeRange(StartTime, EndTime);

        /// <summary> The resource that has been queried for metrics. </summary>
        internal string ResourceId { get; }

        /// <summary> The start time, in datetime format, for which the data was retrieved. </summary>
        internal string StartTime { get; }

        /// <summary> The end time, in datetime format, for which the data was retrieved. </summary>
        internal string EndTime { get; }

        /// <summary>
        /// Returns the MetricResult for the name.
        /// </summary>
        /// <param name="name">The name of the Metric.</param>
        public MetricResult GetMetricByName(string name)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            foreach (var metric in Metrics)
            {
                if (metric.Name == name)
                {
                    return metric;
                }
            }

            throw new KeyNotFoundException($"Could not find Metric with name: {name}");
        }
    }
}
