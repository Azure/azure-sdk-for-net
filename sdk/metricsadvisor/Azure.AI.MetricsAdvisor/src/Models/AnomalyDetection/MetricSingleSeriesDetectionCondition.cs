// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// Defines which conditions a data point must satisfy to be considered an anomaly. Applied to a single
    /// time series.
    /// </summary>
    [CodeGenModel("SeriesConfiguration")]
    [CodeGenSuppress(nameof(MetricSingleSeriesDetectionCondition), typeof(SeriesIdentity))]
    public partial class MetricSingleSeriesDetectionCondition : MetricWholeSeriesDetectionCondition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MetricSingleSeriesDetectionCondition"/> class.
        /// </summary>
        /// <param name="seriesKey">The key that uniquely identifies the time series to which these conditions apply within a metric. All possible dimensions must be assigned a value.</param>
        /// <exception cref="ArgumentNullException"><paramref name="seriesKey"/> is <c>null</c>.</exception>
        public MetricSingleSeriesDetectionCondition(DimensionKey seriesKey)
        {
            Argument.AssertNotNull(seriesKey, nameof(seriesKey));

            SeriesKey = seriesKey;
        }

        internal MetricSingleSeriesDetectionCondition(DetectionConditionOperator? crossConditionsOperator, SmartDetectionCondition smartDetectionCondition, HardThresholdCondition hardThresholdCondition, ChangeThresholdCondition changeThresholdCondition, SeriesIdentity series)
            : base(crossConditionsOperator, smartDetectionCondition, hardThresholdCondition, changeThresholdCondition)
        {
            SeriesKey = new DimensionKey(series.Dimension);
        }

        /// <summary>
        /// The key that uniquely identifies the time series to which these conditions apply within a metric.
        /// All possible dimensions must be assigned a value.
        /// </summary>
        public DimensionKey SeriesKey { get; set; }

        /// <summary>
        /// Used by CodeGen during serialization.
        /// </summary>
        internal SeriesIdentity Series => SeriesKey.ConvertToSeriesIdentity();
    }
}
