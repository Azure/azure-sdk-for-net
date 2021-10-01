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
        /// Returns the metric result for the name.
        /// </summary>
        /// <param name="name"></param>
        public MetricResult GetMetricByName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException(name);
            IEnumerator<MetricResult> enumerator = Metrics.GetEnumerator();
            while (enumerator.MoveNext())
            {
                MetricResult current = enumerator.Current;
                if (current.Name.Equals(name))
                    return current;
            }
            throw new ArgumentException(name);
        }
    }
}
