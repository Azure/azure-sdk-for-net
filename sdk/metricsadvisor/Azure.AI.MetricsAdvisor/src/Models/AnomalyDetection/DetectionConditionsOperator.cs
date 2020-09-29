// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// </summary>
    [CodeGenModel("WholeMetricConfigurationConditionOperator")]
    public readonly partial struct DetectionConditionsOperator
    {
        /// <summary>
        /// </summary>
        [CodeGenMember("AND")]
        public static DetectionConditionsOperator And { get; } = new DetectionConditionsOperator(AndValue);

        /// <summary>
        /// </summary>
        [CodeGenMember("OR")]
        public static DetectionConditionsOperator Or { get; } = new DetectionConditionsOperator(OrValue);
    }
}
