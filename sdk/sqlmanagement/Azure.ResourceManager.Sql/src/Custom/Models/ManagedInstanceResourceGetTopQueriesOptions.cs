// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Sql.Models
{
    /// <summary>
    /// Options for <see cref="ManagedInstanceResource.GetTopQueries(ManagedInstanceResourceGetTopQueriesOptions, System.Threading.CancellationToken)"/>.
    /// </summary>
    [Obsolete("This options class is obsolete and will be removed in a future release.", false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ManagedInstanceResourceGetTopQueriesOptions
    {
        /// <summary> Initializes a new instance of <see cref="ManagedInstanceResourceGetTopQueriesOptions"/>. </summary>
        public ManagedInstanceResourceGetTopQueriesOptions()
        {
        }

        /// <summary> The number of queries to return. </summary>
        public int? NumberOfQueries { get; set; }

        /// <summary> Filter by database names. </summary>
        public string Databases { get; set; }

        /// <summary> Start time of the query window. </summary>
        public string StartTime { get; set; }

        /// <summary> End time of the query window. </summary>
        public string EndTime { get; set; }

        /// <summary> Query time grain. </summary>
        public QueryTimeGrainType? Interval { get; set; }

        /// <summary> Aggregation function used. </summary>
        public AggregationFunctionType? AggregationFunction { get; set; }

        /// <summary> The metric on which to rank queries. </summary>
        public SqlMetricType? ObservationMetric { get; set; }
    }
}
