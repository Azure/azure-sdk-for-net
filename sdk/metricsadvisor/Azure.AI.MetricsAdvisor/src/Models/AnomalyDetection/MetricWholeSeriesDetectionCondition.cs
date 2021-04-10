// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// Defines which conditions a data point must satisfy to be considered an anomaly.
    /// </summary>
    [CodeGenModel("WholeMetricConfiguration")]
    public partial class MetricWholeSeriesDetectionCondition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MetricWholeSeriesDetectionCondition"/> class.
        /// </summary>
        public MetricWholeSeriesDetectionCondition()
        {
        }

        /// <summary>
        /// The operator to be applied between conditions in this <see cref="MetricWholeSeriesDetectionCondition"/>
        /// instance. This property must be set if at least two conditions properties in this instance are defined.
        /// </summary>
        [CodeGenMember("ConditionOperator")]
        public DetectionConditionsOperator? CrossConditionsOperator { get; set; }

        /// <summary>
        /// Configures anomaly detection using multiple machine learning algorithms.
        /// </summary>
        public SmartDetectionCondition SmartDetectionCondition { get; set; }

        /// <summary>
        /// Sets fixed upper and/or lower bounds to specify the range in which data points are expected to be.
        /// Values outside of upper or lower bounds are anomalies.
        /// </summary>
        public HardThresholdCondition HardThresholdCondition { get; set; }

        /// <summary>
        /// Using the value of a previously ingested data point as reference, sets bounds to specify the range in
        /// which data points are expected to be.
        /// </summary>
        public ChangeThresholdCondition ChangeThresholdCondition { get; set; }
    }
}
