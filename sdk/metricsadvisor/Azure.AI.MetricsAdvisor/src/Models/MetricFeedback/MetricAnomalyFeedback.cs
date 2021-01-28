// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// Feedback indicating that the point was incorrectly labeled by the service.
    /// You can specify whether a point should or shouldn't be an anomaly.
    /// </summary>
    [CodeGenModel("AnomalyFeedback")]
    public partial class MetricAnomalyFeedback : MetricFeedback
    {
        /// <summary> Initializes a new instance of <see cref="MetricAnomalyFeedback"/>. </summary>
        /// <param name="metricId"> The metric unique id. </param>
        /// <param name="dimensionFilter"> The dimension filter. </param>
        /// <param name="startTime"> The start timestamp of feedback timerange. </param>
        /// <param name="endTime"> The end timestamp of feedback timerange. When this is equal to <paramref name="startTime"/> it indicates a single timestamp. </param>
        /// <param name="value"> The <see cref="Models.AnomalyValue"/> for the feedback. </param>
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

        /// <summary> Initializes a new instance of <see cref="MetricAnomalyFeedback"/>. </summary>
        /// <param name="metricId"> The metric unique id. </param>
        /// <param name="dimensionFilter"> The dimension filter. </param>
        /// <param name="startTime"> The start timestamp of feedback timerange. </param>
        /// <param name="endTime"> The end timestamp of feedback timerange. When this is equal to <paramref name="startTime"/> it indicates a single timestamp. </param>
        /// <param name="value"> The <see cref="AnomalyFeedbackValue"/> for the feedback. </param>
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
        /// The start timestamp of feedback time range.
        /// </summary>
        public DateTimeOffset StartTime { get; set; }

        /// <summary>
        /// The end timestamp of feedback timerange. When this is equal to <see cref="StartTime"/> it indicates a single timestamp.
        /// </summary>
        public DateTimeOffset EndTime { get; set; }

        /// <summary>
        /// The ID of the <see cref="AnomalyDetectionConfiguration"/> to which this feedback applies. If
        /// <c>null</c>, this feedback applies to all anomalies within the specified time range, defined
        /// by <see cref="StartTime"/> and <see cref="EndTime"/>, without regard for the configuration used
        /// to detect them.
        /// </summary>
        public string AnomalyDetectionConfigurationId { get; set; }

        /// <summary>
        /// A snapshot of the <see cref="AnomalyDetectionConfiguration"/> to which this feedback applies,
        /// taken at the moment this feedback was created. Even if the original configuration changes, this
        /// snapshot will remain unaltered. If no <see cref="AnomalyDetectionConfigurationId"/> was specified
        /// during creation, this property will be <c>null</c>.
        /// </summary>
        public AnomalyDetectionConfiguration AnomalyDetectionConfigurationSnapshot { get; }

        /// <summary>
        /// The <see cref="Models.AnomalyValue"/> for the feedback.
        /// </summary>
        public AnomalyValue AnomalyValue { get => ValueInternal.AnomalyValue; }

        [CodeGenMember("Value")]
        internal AnomalyFeedbackValue ValueInternal { get; }
    }
}
