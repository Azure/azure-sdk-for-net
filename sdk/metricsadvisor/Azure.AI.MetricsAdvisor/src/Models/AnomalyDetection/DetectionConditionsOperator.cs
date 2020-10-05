// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// The operator to be applied between conditions in the same <see cref="MetricAnomalyDetectionConditions"/>
    /// instance.
    /// </summary>
    [CodeGenModel("WholeMetricConfigurationConditionOperator")]
    public readonly partial struct DetectionConditionsOperator
    {
        /// <summary>
        /// The data point is considered an anomaly if all conditions defined in <see cref="MetricAnomalyDetectionConditions"/>
        /// are satisfied.
        /// </summary>
        [CodeGenMember("AND")]
        public static DetectionConditionsOperator And { get; } = new DetectionConditionsOperator(AndValue);

        /// <summary>
        /// The data point is considered an anomaly if at least one of the conditions defined in
        /// <see cref="MetricAnomalyDetectionConditions"/> is satisfied.
        /// </summary>
        [CodeGenMember("OR")]
        public static DetectionConditionsOperator Or { get; } = new DetectionConditionsOperator(OrValue);
    }
}
