// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// The type of a <see cref="MetricAnomalyAlertScope"/>.
    /// </summary>
    [CodeGenModel("AnomalyScope")]
    public readonly partial struct MetricAnomalyAlertScopeType
    {
        /// <summary>
        /// The scope includes all time series of the metric.
        /// </summary>
        [CodeGenMember("All")]
        public static MetricAnomalyAlertScopeType WholeSeries { get; } = new MetricAnomalyAlertScopeType(WholeSeriesValue);

        /// <summary>
        /// The scope only includes a specified set of time series of the metric, defined by a <see cref="DimensionKey"/>.
        /// </summary>
        [CodeGenMember("Dimension")]
        public static MetricAnomalyAlertScopeType SeriesGroup { get; } = new MetricAnomalyAlertScopeType(SeriesGroupValue);

        /// <summary>
        /// The scope only includes anomalies detected in the top N series.
        /// </summary>
        public static MetricAnomalyAlertScopeType TopN { get; } = new MetricAnomalyAlertScopeType(TopNValue);
    }
}
