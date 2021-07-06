// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.Monitor.Query.Models;

namespace Azure.Monitor.Query
{
    /// <summary>
    /// Options for <see cref="MetricsQueryClient.QueryAsync"/>.
    /// </summary>
    public class MetricsQueryOptions
    {
        /// <summary>
        /// Gets or sets the timespan over which the metric will be queried.
        /// </summary>
        public DateTimeRange? TimeSpan { get; set; }

        /// <summary>
        /// Gets or sets the interval at which to sample metrics.
        /// </summary>
        public TimeSpan? Interval { get; set; }

        /// <summary>
        /// Gets the list of metric aggregations to retrieve.
        /// </summary>
        public IList<MetricAggregationType> Aggregations { get; } = new List<MetricAggregationType>();

        /// <summary>
        /// Gets or sets the maximum number of records to retrieve. Valid only when <see cref="Filter"/> is specified. Defaults to <c>null</c>.
        /// </summary>
        public int? Top { get; set; }

        /// <summary>
        /// Gets or sets the filter that is used to refine the set of metric data returned.
        /// <example>
        /// Metric contains metadata A, B and C.<br/>
        /// <br/>
        ///     - Return all time series of C where A = a1 and B = b1 or b2:<br/>
        ///         <c>A eq 'a1' and B eq 'b1' or B eq 'b2' and C eq '*'</c><br/>
        ///     - Invalid variant:<br/>
        ///         <c>A eq 'a1' and B eq 'b1' and C eq '*' or B = 'b2'</c><br/>
        ///         This is invalid because the logical or operator cannot separate two different metadata names.<br/>
        ///     - Return all time series where A = a1, B = b1 and C = c1:<br/>
        ///         <c>A eq 'a1' and B eq 'b1' and C eq 'c1'</c><br/>
        ///     - Return all time series where A = a1<br/>
        ///         <c>A eq 'a1' and B eq '*' and C eq '*'.</c><br/>
        /// </example>
        /// </summary>
        public string Filter { get; set; }

        /// <summary>
        /// Gets or sets the aggregation to use for sorting results and the direction of the sort.
        /// Only one order can be specified.
        /// Examples: sum asc.
        /// </summary>
        public string OrderBy { get; set; }

        /// <summary>
        /// Gets or sets the metric namespace to query.
        /// </summary>
        public string MetricNamespace { get; set; }
    }
}
