// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// The operator to be applied between <see cref="MetricAlertConfiguration"/>s in the same
    /// <see cref="AnomalyAlertConfiguration"/> instance.
    /// </summary>
    [CodeGenModel("AnomalyAlertingConfigurationLogicType")]
    public readonly partial struct MetricAlertConfigurationsOperator
    {
        /// <summary>
        /// The anomaly will be included in the alert if the conditions in every
        /// <see cref="MetricAlertConfiguration"/> are satisfied. Be aware that if two metric alert
        /// configurations have no intersection between their scopes, an alert will never be triggered.
        /// </summary>
        [CodeGenMember("AND")]
        public static MetricAlertConfigurationsOperator And { get; } = new MetricAlertConfigurationsOperator(AndValue);

        /// <summary>
        /// The anomaly will be included in the alert if the conditions of at least one
        /// <see cref="MetricAlertConfiguration"/> are satisfied.
        /// </summary>
        [CodeGenMember("OR")]
        public static MetricAlertConfigurationsOperator Or { get; } = new MetricAlertConfigurationsOperator(OrValue);

        /// <summary>
        /// This value can only be used when there are exactly two <see cref="MetricAlertConfiguration"/>
        /// instances defined. The anomaly will be included in the alert if the conditions of exactly one
        /// of the configurations are satisfied.
        /// </summary>
        [CodeGenMember("XOR")]
        public static MetricAlertConfigurationsOperator Xor { get; } = new MetricAlertConfigurationsOperator(XorValue);
    }
}
