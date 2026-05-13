// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

#pragma warning disable CS1591
namespace Azure.ResourceManager.Sql.Models
{
    public partial class ManagedInstanceResourceGetTopQueriesOptions
    {
        public int? NumberOfQueries { get; set; }
        public string Databases { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public QueryTimeGrainType? Interval { get; set; }
        public AggregationFunctionType? AggregationFunction { get; set; }
        public SqlMetricType? ObservationMetric { get; set; }
    }
}
