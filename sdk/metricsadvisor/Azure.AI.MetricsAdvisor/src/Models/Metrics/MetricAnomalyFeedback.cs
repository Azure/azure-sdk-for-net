// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    [CodeGenModel("AnomalyFeedback")]
    public partial class MetricAnomalyFeedback : MetricFeedback
    {
        /// <summary> Initializes a new instance of AnomalyFeedback. </summary>
        /// <param name="metricId"> The metric unique id. </param>
        /// <param name="dimensionFilter"> The dimension filter. </param>
        /// <param name="startTime"> The start timestamp of feedback timerange. </param>
        /// <param name="endTime"> The end timestamp of feedback timerange, when equals to startTime means only one timestamp. </param>
        /// <param name="value"> The value for the feedback. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="dimensionFilter"/> or <paramref name="value"/> is null. </exception>
        public MetricAnomalyFeedback(string metricId, FeedbackDimensionFilter dimensionFilter, DateTimeOffset startTime, DateTimeOffset endTime, AnomalyValue value) : base(metricId, dimensionFilter)
        {
            if (value == default)
            {
                throw new ArgumentNullException(nameof(value));
            }

            DimensionFilter = dimensionFilter;
            StartTime = startTime;
            EndTime = endTime;
            ValueInternal = new AnomalyFeedbackValue(value);
            Type = FeedbackType.Anomaly;
        }

        /// <summary> Initializes a new instance of AnomalyFeedback. </summary>
        /// <param name="metricId"> metric unique id. </param>
        /// <param name="dimensionFilter"> . </param>
        /// <param name="startTime"> the start timestamp of feedback timerange. </param>
        /// <param name="endTime"> the end timestamp of feedback timerange, when equals to startTime means only one timestamp. </param>
        /// <param name="value"> . </param>
        /// <exception cref="ArgumentNullException"> <paramref name="dimensionFilter"/> or <paramref name="value"/> is null. </exception>
        internal MetricAnomalyFeedback(string metricId, FeedbackDimensionFilter dimensionFilter, DateTimeOffset startTime, DateTimeOffset endTime, AnomalyFeedbackValue value) : base(metricId, dimensionFilter)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            StartTime = startTime;
            EndTime = endTime;
            ValueInternal = value;
            Type = Models.FeedbackType.Anomaly;
        }

        /// <summary>
        /// The anomaly value.
        /// </summary>
        public AnomalyValue AnomalyValue { get => ValueInternal.AnomalyValue; }

        [CodeGenMember("Value")]
        internal AnomalyFeedbackValue ValueInternal { get; }

        /// <summary>
        /// The anomaly detection configuration snapshot.
        /// </summary>
        public MetricAnomalyDetectionConfiguration AnomalyDetectionConfigurationSnapshot { get; }
    }
}
