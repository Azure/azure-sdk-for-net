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
    public readonly partial struct DetectionConditionOperator
    {
        /// <summary>
        /// The data point will trigger an alert if every <see cref="MetricAlertConfiguration"/> defined
        /// in <see cref="AnomalyAlertConfiguration"/> is satisfied. Note: If two
        /// <see cref="MetricAlertConfiguration"/>s have different dimension names, an alert will never
        /// be triggered.
        /// </summary>
        [CodeGenMember("AND")]
        public static DetectionConditionOperator And { get; } = new DetectionConditionOperator(AndValue);

        /// <summary>
        /// The data point will trigger an alert if at least one <see cref="MetricAlertConfiguration"/>
        /// defined in <see cref="AnomalyAlertConfiguration"/> is satisfied.
        /// </summary>
        [CodeGenMember("OR")]
        public static DetectionConditionOperator Or { get; } = new DetectionConditionOperator(OrValue);

        /// <summary>
        /// It can be used only when there are up to two <see cref="MetricAlertConfiguration"/>s defined
        /// in <see cref="AnomalyAlertConfiguration"/>. The data point will trigger an alert if exactly one of the
        /// configurations is satisfied.
        /// </summary>
        [CodeGenMember("XOR")]
        public static DetectionConditionOperator Xor { get; } = new DetectionConditionOperator(XorValue);
    }
}
