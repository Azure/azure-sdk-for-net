// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// The operator to be applied between conditions in the same <see cref="MetricWholeSeriesDetectionCondition"/>
    /// instance.
    /// </summary>
    [CodeGenModel("AnomalyDetectionConfigurationLogicType")]
    public readonly partial struct DetectionConditionOperator
    {
        /// <summary>
        /// The data point is considered an anomaly if all conditions defined in <see cref="MetricWholeSeriesDetectionCondition"/>
        /// are satisfied.
        /// </summary>
        [CodeGenMember("AND")]
        public static DetectionConditionOperator And { get; } = new DetectionConditionOperator(AndValue);

        /// <summary>
        /// The data point is considered an anomaly if at least one of the conditions defined in
        /// <see cref="MetricWholeSeriesDetectionCondition"/> is satisfied.
        /// </summary>
        [CodeGenMember("OR")]
        public static DetectionConditionOperator Or { get; } = new DetectionConditionOperator(OrValue);
    }
}
