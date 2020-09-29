// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// </summary>
    [CodeGenModel("SeriesConfiguration")]
    [CodeGenSuppress(nameof(MetricSingleSeriesAnomalyDetectionConditions), typeof(SeriesIdentity))]
    public partial class MetricSingleSeriesAnomalyDetectionConditions : MetricAnomalyDetectionConditions
    {
        /// <summary>
        /// </summary>
        public MetricSingleSeriesAnomalyDetectionConditions(DimensionKey seriesKey)
        {
            Argument.AssertNotNull(seriesKey, nameof(seriesKey));

            SeriesKey = seriesKey;
        }

        internal MetricSingleSeriesAnomalyDetectionConditions(DetectionConditionsOperator? crossConditionsOperator, SmartDetectionCondition smartDetectionCondition, HardThresholdCondition hardThresholdCondition, ChangeThresholdCondition changeThresholdCondition, SeriesIdentity series)
            : base(crossConditionsOperator, smartDetectionCondition, hardThresholdCondition, changeThresholdCondition)
        {
            SeriesKey = new DimensionKey(series.Dimension);
        }

        /// <summary>
        /// </summary>
        public DimensionKey SeriesKey { get; }

        /// <summary>
        /// Used by CodeGen during serialization.
        /// </summary>
        internal SeriesIdentity Series => SeriesKey.ConvertToSeriesIdentity();
    }
}
