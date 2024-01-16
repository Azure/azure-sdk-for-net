// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Azure.Monitor.Query.Models;

namespace Azure.Monitor.Query
{
    /// <summary>
    /// Provides the client configuration options for connecting to Azure Monitor Metrics service.
    /// </summary>
    public class MetricsBatchQueryOptions: ClientOptions
    {
        private readonly ServiceVersion _version;

        /// <summary>
        /// The latest service version supported by this client library.
        /// </summary>
        internal const ServiceVersion LatestVersion = ServiceVersion.V2023_05_01_PREVIEW;

        /// <summary>
        /// Initializes a new instance of the <see cref="MetricsBatchQueryOptions"/> class.
        /// </summary>
        /// <param name="version">
        /// The <see cref="ServiceVersion"/> of the service API used when
        /// making requests.
        /// </param>
        public MetricsBatchQueryOptions(ServiceVersion version = LatestVersion)
        {
            _version = version;
        }

        /// <summary>
        /// The versions of Azure Monitor Metrics service supported by this client
        /// library.
        /// </summary>
        public enum ServiceVersion
        {
#pragma warning disable CA1707 // Identifiers should not contain underscores
            /// <summary>
            /// Version 2023-05-01-preview of the service.
            /// </summary>
            V2023_05_01_PREVIEW = 1,
#pragma warning restore CA1707 // Identifiers should not contain underscores
        }

        /// <summary>
        /// Gets or sets the timespan over which the metric will be queried.
        /// </summary>
        [CodeGenMember("TimeSpan")]
        public QueryTimeRange? TimeRange { get; set; }

        /// <summary>
        /// <para>
        /// Gets the list of metric aggregations to retrieve.
        /// </para>
        /// <para>
        /// Although this collection cannot be set, it can be modified.
        /// See <see href="https://learn.microsoft.com/dotnet/csharp/programming-guide/classes-and-structs/object-and-collection-initializers#object-initializers-with-collection-read-only-property-initialization">Object initializers with collection read-only property initialization</see>.
        /// </para>
        /// </summary>
        public IList<MetricAggregationType> Aggregations { get; } = new List<MetricAggregationType>();

        /// <summary>
        /// Gets or sets the maximum number of records to retrieve. Valid only when <see cref="Filter"/> is specified. Defaults to <c>null</c>.
        /// </summary>
        [CodeGenMember("Top")]
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
        public IList<string> OrderBy { get; internal set; } = new List<string>();

        /// <summary>
        /// Join OrderBy so it can be sent as a comma separated string.
        /// </summary>
        [CodeGenMember("OrderBy")]
        internal string OrderByRaw
        {
            get => MetricsBatchExtensions.CommaJoin(OrderBy);
            set => OrderBy = MetricsBatchExtensions.CommaSplit(value);
        }

        /// <summary>
        /// Dimension name(s) to rollup results by.
        /// Examples: If you only want to see metric values with a filter like 'City eq Seattle or City eq Tacoma' but don't want to see separate values for each city, you can specify 'RollUpBy=City' to see the results for Seattle and Tacoma rolled up into one timeseries.
        /// </summary>
        public IList<string> RollUpBy { get; internal set; } = new List<string>();

        /// <summary>
        /// Join OrderBy so it can be sent as a comma separated string.
        /// </summary>
        [CodeGenMember("RollUpBy")]
        internal string RollUpByRaw
        {
            get => MetricsBatchExtensions.CommaJoin(RollUpBy);
            set => RollUpBy = MetricsBatchExtensions.CommaSplit(value);
        }

        /// <summary>
        /// Gets or sets the interval at which to sample metrics.
        /// </summary>
        [CodeGenMember("Interval")]
        public TimeSpan? Granularity { get; set; }
    }
}
