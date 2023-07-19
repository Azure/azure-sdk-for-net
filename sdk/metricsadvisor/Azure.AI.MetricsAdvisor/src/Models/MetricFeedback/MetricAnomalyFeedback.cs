// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.MetricsAdvisor.Models;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor
{
    /// <summary>
    /// Feedback indicating that a data point was incorrectly labeled by the service.
    /// You can specify whether a point should or shouldn't be an anomaly with <see cref="Models.AnomalyValue"/>
    /// </summary>
    /// <remarks>
    /// In order to create anomaly feedback, you must pass this instance to the method
    /// <see cref="MetricsAdvisorClient.AddFeedbackAsync"/>.
    /// </remarks>
    [CodeGenModel("AnomalyFeedback")]
    [CodeGenSuppress(nameof(MetricAnomalyFeedback), typeof(string), typeof(FeedbackFilter))]
    public partial class MetricAnomalyFeedback : MetricFeedback
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MetricAnomalyFeedback"/> class.
        /// </summary>
        /// <param name="metricId">The identifier of the metric to which the <see cref="MetricAnomalyFeedback"/> applies.</param>
        /// <param name="dimensionKey">
        /// A key that identifies a set of time series to which the <see cref="MetricAnomalyFeedback"/> applies.
        /// If all possible dimensions are set, this key uniquely identifies a single time series
        /// for the specified <paramref name="metricId"/>. If only a subset of dimensions are set, this
        /// key uniquely identifies a group of time series.
        /// </param>
        /// <param name="startsOn">The start timestamp of feedback time range.</param>
        /// <param name="endsOn">The end timestamp of feedback time range. When this is equal to <paramref name="startsOn"/> it indicates a single timestamp.</param>
        /// <param name="value">Indicates whether or not the data points should have been labeled as anomalies by the service.</param>
        /// <exception cref="ArgumentNullException"><paramref name="metricId"/> or <paramref name="dimensionKey"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException"><paramref name="metricId"/> is empty.</exception>
        public MetricAnomalyFeedback(string metricId, DimensionKey dimensionKey, DateTimeOffset startsOn, DateTimeOffset endsOn, AnomalyValue value)
            : base(metricId, dimensionKey)
        {
            StartsOn = startsOn;
            EndsOn = endsOn;
            ValueInternal = new AnomalyFeedbackValue(value);
            FeedbackKind = MetricFeedbackKind.Anomaly;
        }

        /// <summary> Initializes a new instance of <see cref="MetricAnomalyFeedback"/>. </summary>
        /// <param name="metricId"> The metric unique id. </param>
        /// <param name="feedbackFilter"> The dimension filter. </param>
        /// <param name="startsOn"> The start timestamp of feedback timerange. </param>
        /// <param name="endsOn"> The end timestamp of feedback timerange. When this is equal to <paramref name="startsOn"/> it indicates a single timestamp. </param>
        /// <param name="value"> The <see cref="AnomalyFeedbackValue"/> for the feedback. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="feedbackFilter"/> or <paramref name="value"/> is null. </exception>
        internal MetricAnomalyFeedback(string metricId, FeedbackFilter feedbackFilter, DateTimeOffset startsOn, DateTimeOffset endsOn, AnomalyFeedbackValue value)
            : base(metricId, feedbackFilter.DimensionKey)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            StartsOn = startsOn;
            EndsOn = endsOn;
            ValueInternal = value;
            FeedbackKind = MetricFeedbackKind.Anomaly;
        }

        /// <summary>
        /// The start timestamp of feedback time range.
        /// </summary>
        [CodeGenMember("StartTime")]
        public DateTimeOffset StartsOn { get; }

        /// <summary>
        /// The end timestamp of feedback timerange. When this is equal to <see cref="StartsOn"/> it indicates a single timestamp.
        /// </summary>
        [CodeGenMember("EndTime")]
        public DateTimeOffset EndsOn { get; }

        /// <summary>
        /// The ID of the <see cref="AnomalyDetectionConfiguration"/> to which this feedback applies. If
        /// <c>null</c>, this feedback applies to all anomalies within the specified time range, defined
        /// by <see cref="StartsOn"/> and <see cref="EndsOn"/>, without regard for the configuration used
        /// to detect them.
        /// </summary>
        [CodeGenMember("AnomalyDetectionConfigurationId")]
        public string DetectionConfigurationId { get; set; }

        /// <summary>
        /// A snapshot of the <see cref="AnomalyDetectionConfiguration"/> to which this feedback applies,
        /// taken at the moment this feedback was created. Even if the original configuration changes, this
        /// snapshot will remain unaltered. If no <see cref="DetectionConfigurationId"/> was specified
        /// during creation, this property will be <c>null</c>.
        /// </summary>
        [CodeGenMember("AnomalyDetectionConfigurationSnapshot")]
        public AnomalyDetectionConfiguration DetectionConfigurationSnapshot { get; }

        /// <summary>
        /// Indicates whether or not the data points should have been labeled as anomalies by the service.
        /// </summary>
        public AnomalyValue AnomalyValue => ValueInternal.AnomalyValue;

        [CodeGenMember("Value")]
        internal AnomalyFeedbackValue ValueInternal { get; }
    }
}
