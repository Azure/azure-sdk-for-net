// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

#pragma warning disable CS1591
namespace Azure.ResourceManager.Sql.Models
{
    public partial class ManagedInstanceResourceGetTopQueriesOptions
    {
        [WirePath("numberOfQueries")]
        public int? NumberOfQueries { get; set; }
        [WirePath("databases")]
        public string Databases { get; set; }
        [WirePath("startTime")]
        public string StartTime { get; set; }
        [WirePath("endTime")]
        public string EndTime { get; set; }
        [WirePath("interval")]
        public QueryTimeGrainType? Interval { get; set; }
        [WirePath("aggregationFunction")]
        public AggregationFunctionType? AggregationFunction { get; set; }
        [WirePath("observationMetric")]
        public SqlMetricType? ObservationMetric { get; set; }
    }
}
