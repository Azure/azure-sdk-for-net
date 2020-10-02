// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    [CodeGenModel("AnomalyScope")]
    public readonly partial struct MetricAnomalyAlertScopeType
    {
        /// <summary>
        /// </summary>
        [CodeGenMember("All")]
        public static MetricAnomalyAlertScopeType WholeSeries { get; } = new MetricAnomalyAlertScopeType(WholeSeriesValue);

        /// <summary>
        /// </summary>
        [CodeGenMember("Dimension")]
        public static MetricAnomalyAlertScopeType SeriesGroup { get; } = new MetricAnomalyAlertScopeType(SeriesGroupValue);
    }
}
