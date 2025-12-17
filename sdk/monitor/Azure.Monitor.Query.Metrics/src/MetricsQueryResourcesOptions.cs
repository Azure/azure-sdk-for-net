// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.Monitor.Query.Metrics.Models;

namespace Azure.Monitor.Query.Metrics
{
    /// <summary>
    /// Options for the <see cref="MetricsClient.QueryResourcesAsync(IEnumerable{ResourceIdentifier}, IEnumerable{string}, string, MetricsQueryResourcesOptions, System.Threading.CancellationToken)"/>
    /// and <see cref="MetricsClient.QueryResources(IEnumerable{ResourceIdentifier}, IEnumerable{string}, string, MetricsQueryResourcesOptions, System.Threading.CancellationToken)"/> methods.
    /// </summary>
    public class MetricsQueryResourcesOptions
    {
        /// <summary>
        /// Gets or sets the timespan over which the metric will be queried. If only the starttime is set, the endtime default becomes the current time. When the endtime is specified, the starttime is necessary as well. Duration is disregarded.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MetricsQueryTimeRange? TimeRange { get; set; }

        /// <summary>
        /// Gets the <see cref="StartTime"/> of the query. If only the <see cref="StartTime"/> is set, the <see cref="EndTime"/> default becomes the current time. When the <see cref="EndTime"/> is specified, the <see cref="StartTime"/> is necessary as well.
        /// </summary>
        public DateTimeOffset? StartTime { get; set; }

        /// <summary>
        /// Gets the <see cref="EndTime"/> of the query. If only the <see cref="StartTime"/> is set, the <see cref="EndTime"/> default becomes the current time. When the <see cref="EndTime"/> is specified, the <see cref="StartTime"/> is necessary as well.
        /// </summary>
        public DateTimeOffset? EndTime { get; set; }

        /// <summary>
        /// <para>
        /// Gets the list of metric aggregations to retrieve.
        /// </para>
        /// <para>
        /// Although this collection cannot be set, it can be modified.
        /// See <see href="https://learn.microsoft.com/dotnet/csharp/programming-guide/classes-and-structs/object-and-collection-initializers#object-initializers-with-collection-read-only-property-initialization">Object initializers with collection read-only property initialization</see>.
        /// </para>
        /// </summary>
        public IList<string> Aggregations { get; } = new List<string>();

        /// <summary>
        /// Gets or sets the maximum number of records to retrieve. Valid only when <see cref="Filter"/> is specified. Defaults to <c>null</c>.
        /// </summary>
        public int? Size { get; set; }

        /// <summary>
        /// Gets or sets the filter that is used to refine the set of metric data returned.
        /// <example>
        /// <see cref="MetricResult"/> contains metadata A, B, and C.<br/>
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
        /// Dimension name(s) to rollup results by.
        /// Examples: If you only want to see metric values with a filter like 'City eq Seattle or City eq Tacoma' but don't want to see separate values for each city, you can specify 'RollUpBy=City' to see the results for Seattle and Tacoma rolled up into one timeseries.
        /// </summary>
        public IList<string> RollUpBy { get; } = new List<string>();

        /// <summary>
        /// Gets or sets the interval at which to sample metrics.
        /// </summary>
        public TimeSpan? Granularity { get; set; }
    }
}
