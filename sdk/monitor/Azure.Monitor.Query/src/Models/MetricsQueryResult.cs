// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.Monitor.Query.Models
{
    [CodeGenModel("Response")]
    public partial class MetricsQueryResult
    {
        [CodeGenMember("Timespan")]
        private readonly string _timespan;

        /// <summary> Metrics returned as the result of the query. </summary>
        [CodeGenMember("Value")]
        public IReadOnlyList<MetricResult> Metrics { get; }

        /// <summary>
        /// The timespan for which the data was retrieved.
        /// This may be adjusted in the future and returned back from what was originally requested.
        /// </summary>
        public QueryTimeRange TimeSpan => QueryTimeRange.Parse(_timespan);

        /// <summary> The region of the resource being queried for metrics. </summary>
        [CodeGenMember("Resourceregion")]
        public string ResourceRegion { get; }

        /// <summary> The interval (window size) for which the metric data was returned in.  This may be adjusted in the future and returned back from what was originally requested.  This is not present if a metadata request was made. </summary>
        [CodeGenMember("Interval")]
        public TimeSpan? Granularity { get; }

        /// <summary>
        /// Returns the MetricResult for the name.
        /// </summary>
        /// <param name="name">The name of the Metric.</param>
        public MetricResult GetMetricByName(string name)
        {
            Argument.CheckNotNullOrEmpty(name, nameof(name));
            foreach (var metric in Metrics)
            {
                if (metric.Name == name)
                    return metric;
            }
            throw new KeyNotFoundException($"Could not find Metric with name: {name}");
        }
    }
}
