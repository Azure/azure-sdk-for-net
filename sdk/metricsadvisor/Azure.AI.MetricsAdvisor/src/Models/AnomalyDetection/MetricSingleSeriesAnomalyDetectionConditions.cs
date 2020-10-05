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
    [CodeGenSuppress(nameof(MetricSingleSeriesAnomalyDetectionConditions), typeof(SeriesIdentity))]
    public partial class MetricSingleSeriesAnomalyDetectionConditions : MetricAnomalyDetectionConditions
    {
        /// <summary>
        /// Creates a new instance of the <see cref="MetricSingleSeriesAnomalyDetectionConditions"/> class.
        /// </summary>
        /// <param name="seriesKey">The key that uniquely identifies the time series to which these conditions apply within a metric. All possible dimension values for the associated data feed must be set.</param>
        /// <exception cref="ArgumentNullException"><paramref name="seriesKey"/> is null.</exception>
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
        /// The key that uniquely identifies the time series to which these conditions apply within a metric.
        /// All possible dimensions for the associated data feed must be set.
        /// </summary>
        public DimensionKey SeriesKey { get; }

        /// <summary>
        /// Used by CodeGen during serialization.
        /// </summary>
        internal SeriesIdentity Series => SeriesKey.ConvertToSeriesIdentity();
    }
}
