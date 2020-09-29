// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// </summary>
    [CodeGenModel("WholeMetricConfiguration")]
    public partial class MetricAnomalyDetectionConditions
    {
        /// <summary>
        /// </summary>
        [CodeGenMember("ConditionOperator")]
        public DetectionConditionsOperator? CrossConditionsOperator { get; set; }

        /// <summary>
        /// </summary>
        public SmartDetectionCondition SmartDetectionCondition { get; set; }

        /// <summary>
        /// </summary>
        public HardThresholdCondition HardThresholdCondition { get; set; }

        /// <summary>
        /// </summary>
        public ChangeThresholdCondition ChangeThresholdCondition { get; set; }
    }
}
