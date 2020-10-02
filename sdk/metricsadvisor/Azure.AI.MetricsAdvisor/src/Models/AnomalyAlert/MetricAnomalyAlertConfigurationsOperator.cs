// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// </summary>
    [CodeGenModel("AnomalyAlertingConfigurationCrossMetricsOperator")]
    public readonly partial struct MetricAnomalyAlertConfigurationsOperator
    {
        /// <summary>
        /// </summary>
        [CodeGenMember("AND")]
        public static MetricAnomalyAlertConfigurationsOperator And { get; } = new MetricAnomalyAlertConfigurationsOperator(AndValue);

        /// <summary>
        /// </summary>
        [CodeGenMember("OR")]
        public static MetricAnomalyAlertConfigurationsOperator Or { get; } = new MetricAnomalyAlertConfigurationsOperator(OrValue);

        /// <summary>
        /// </summary>
        [CodeGenMember("XOR")]
        public static MetricAnomalyAlertConfigurationsOperator Xor { get; } = new MetricAnomalyAlertConfigurationsOperator(XorValue);
    }
}
