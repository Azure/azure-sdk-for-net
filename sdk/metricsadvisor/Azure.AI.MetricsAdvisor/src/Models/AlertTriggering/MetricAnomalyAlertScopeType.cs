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
        /// Alerts will be triggered for anomalies in all series within the metric.
        /// </summary>
        [CodeGenMember("All")]
        public static MetricAnomalyAlertScopeType WholeSeries { get; } = new MetricAnomalyAlertScopeType(WholeSeriesValue);

        /// <summary>
        /// Alerts will only be triggered for anomalies in specific dimensions of the series group.
        /// </summary>
        [CodeGenMember("Dimension")]
        public static MetricAnomalyAlertScopeType SeriesGroup { get; } = new MetricAnomalyAlertScopeType(SeriesGroupValue);

        /// <summary>
        /// Alerts will only be triggered for anomalies in the top N series.
        /// You can set parameters to specify the number of timestamps to take into account, and how many anomalies must be in them to send the alert.
        /// </summary>
        public static MetricAnomalyAlertScopeType TopN { get; } = new MetricAnomalyAlertScopeType(TopNValue);
    }
}
