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
        /// instance. This property must be set if at least two conditions in this instance are defined.
        /// </summary>
        public DetectionConditionOperator? ConditionOperator { get; set; }

        /// <summary>
        /// A detection condition powered by machine learning that learns patterns from historical data, and uses them
        /// for future detection.
        /// </summary>
        /// <remarks>
        /// If set to <c>null</c> during an Update operation, this condition is removed from the configuration.
        /// If you're using other detection conditions in addition to this one, you need to set the property
        /// <see cref="ConditionOperator"/>.
        /// </remarks>
        public SmartDetectionCondition SmartDetectionCondition { get; set; }

        /// <summary>
        /// Sets fixed upper and/or lower bounds to specify the range in which data points are expected to be.
        /// Values outside of upper or lower bounds will be considered to be anomalous.
        /// </summary>
        /// <remarks>
        /// If set to <c>null</c> during an Update operation, this condition is removed from the configuration.
        /// If you're using other detection conditions in addition to this one, you need to set the property
        /// <see cref="ConditionOperator"/>.
        /// </remarks>
        public HardThresholdCondition HardThresholdCondition { get; set; }

        /// <summary>
        /// Normally used when metric values stay around a certain range. The threshold is set according to the percentage of change.
        /// The following scenarios are appropriate for this type of anomaly detection condition:
        /// <list type="bullet">
        ///   <item>Your data is normally stable and smooth. You want to be notified when there are fluctuations.</item>
        ///   <item>Your data is normally quite unstable and fluctuates a lot. You want to be notified when it becomes too stable or flat.</item>
        /// </list>
        /// </summary>
        /// <remarks>
        /// If set to <c>null</c> during an Update operation, this condition is removed from the configuration.
        /// If you're using other detection conditions in addition to this one, you need to set the property
        /// <see cref="ConditionOperator"/>.
        /// </remarks>
        public ChangeThresholdCondition ChangeThresholdCondition { get; set; }

        internal WholeMetricConfigurationPatch GetPatchModel() => new WholeMetricConfigurationPatch()
        {
            ConditionOperator = ConditionOperator,
            SmartDetectionCondition = SmartDetectionCondition?.GetPatchModel(),
            HardThresholdCondition = HardThresholdCondition?.GetPatchModel(),
            ChangeThresholdCondition = ChangeThresholdCondition?.GetPatchModel()
        };
    }
}
