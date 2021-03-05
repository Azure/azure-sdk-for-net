// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// The operator to be applied between <see cref="MetricAnomalyAlertConfiguration"/>s in the same
    /// <see cref="AnomalyAlertConfiguration"/> instance.
    /// </summary>
    [CodeGenModel("AnomalyAlertingConfigurationLogicType")]
    public readonly partial struct MetricAnomalyAlertConfigurationsOperator
    {
        /// <summary>
        /// The data point will trigger an alert if every <see cref="MetricAnomalyAlertConfiguration"/> defined
        /// in <see cref="AnomalyAlertConfiguration"/> is satisfied. Note: If two
        /// <see cref="MetricAnomalyAlertConfiguration"/>s have different dimension names, an alert will never
        /// be triggered.
        /// </summary>
        [CodeGenMember("AND")]
        public static MetricAnomalyAlertConfigurationsOperator And { get; } = new MetricAnomalyAlertConfigurationsOperator(AndValue);

        /// <summary>
        /// The data point will trigger an alert if at least one <see cref="MetricAnomalyAlertConfiguration"/>
        /// defined in <see cref="AnomalyAlertConfiguration"/> is satisfied.
        /// </summary>
        [CodeGenMember("OR")]
        public static MetricAnomalyAlertConfigurationsOperator Or { get; } = new MetricAnomalyAlertConfigurationsOperator(OrValue);

        /// <summary>
        /// It can be used only when there are up to two <see cref="MetricAnomalyAlertConfiguration"/>s defined
        /// in <see cref="AnomalyAlertConfiguration"/>. The data point will trigger an alert if exactly one of the
        /// configurations is satisfied.
        /// </summary>
        [CodeGenMember("XOR")]
        public static MetricAnomalyAlertConfigurationsOperator Xor { get; } = new MetricAnomalyAlertConfigurationsOperator(XorValue);
    }
}
