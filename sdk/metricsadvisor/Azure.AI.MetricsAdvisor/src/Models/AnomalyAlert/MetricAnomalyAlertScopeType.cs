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
        /// The scope is all time series within the associated metric.
        /// </summary>
        [CodeGenMember("All")]
        public static MetricAnomalyAlertScopeType WholeSeries { get; } = new MetricAnomalyAlertScopeType(WholeSeriesValue);

        /// <summary>
        /// The scope is a fixed group of time series.
        /// </summary>
        [CodeGenMember("Dimension")]
        public static MetricAnomalyAlertScopeType SeriesGroup { get; } = new MetricAnomalyAlertScopeType(SeriesGroupValue);

        // TODODOCS.
        /// <summary>
        /// </summary>
        public static MetricAnomalyAlertScopeType TopN { get; } = new MetricAnomalyAlertScopeType(TopNValue);
    }
}
