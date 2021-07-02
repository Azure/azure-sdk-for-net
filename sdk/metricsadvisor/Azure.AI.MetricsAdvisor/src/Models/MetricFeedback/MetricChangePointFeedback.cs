// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.MetricsAdvisor.Models;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor
{
    /// <summary>
    /// Feedback indicating that this is the start of a trend change.
    /// </summary>
    [CodeGenModel("ChangePointFeedback")]
    [CodeGenSuppress(nameof(MetricChangePointFeedback), typeof(string), typeof(FeedbackFilter))]
    public partial class MetricChangePointFeedback : MetricFeedback
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MetricChangePointFeedback"/> class.
        /// </summary>
        /// <param name="metricId">The identifier of the metric to which the <see cref="MetricChangePointFeedback"/> applies.</param>
        /// <param name="dimensionKey">
        /// A key that identifies a set of time series to which the <see cref="MetricChangePointFeedback"/> applies.
        /// If all possible dimension columns are set, this key uniquely identifies a single time series
        /// for the specified <paramref name="metricId"/>. If only a subset of dimension columns are set, this
        /// key uniquely identifies a group of time series.
        /// </param>
        /// <param name="startTime">The start timestamp of feedback time range.</param>
        /// <param name="endTime">The end timestamp of feedback time range. When this is equal to <paramref name="startTime"/> it indicates a single timestamp.</param>
        /// <param name="value">The <see cref="Models.ChangePointValue"/> for the feedback.</param>
        /// <exception cref="ArgumentNullException"><paramref name="metricId"/> or <paramref name="dimensionKey"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException"><paramref name="metricId"/> is empty.</exception>
        public MetricChangePointFeedback(string metricId, DimensionKey dimensionKey, DateTimeOffset startTime, DateTimeOffset endTime, ChangePointValue value)
            : base(metricId, dimensionKey)
        {
            StartTime = startTime;
            EndTime = endTime;
            ValueInternal = new ChangePointFeedbackValue(value);
            Kind = MetricFeedbackKind.ChangePoint;
        }

        /// <summary> Initializes a new <see cref="MetricChangePointFeedback"/> instance. </summary>
        /// <param name="metricId"> The metric unique id. </param>
        /// <param name="dimensionFilter"> The dimension filter. </param>
        /// <param name="startTime"> The start timestamp of feedback timerange. </param>
        /// <param name="endTime"> The end timestamp of feedback timerange. When this is equal to <paramref name="startTime"/> it indicates a single timestamp. </param>
        /// <param name="value"> The <see cref="Models.ChangePointFeedbackValue"/> for the feedback. </param>
        internal MetricChangePointFeedback(string metricId, FeedbackFilter dimensionFilter, DateTimeOffset startTime, DateTimeOffset endTime, ChangePointFeedbackValue value)
            : base(metricId, dimensionFilter.DimensionKey)
        {
            Argument.AssertNotNull(value, nameof(value));

            StartTime = startTime;
            EndTime = endTime;
            ValueInternal = value;
            Kind = MetricFeedbackKind.ChangePoint;
        }

        /// <summary>
        /// The start timestamp of feedback time range.
        /// </summary>
        public DateTimeOffset StartTime { get; }

        /// <summary>
        /// The end timestamp of feedback timerange. When this is equal to <see cref="StartTime"/> it indicates a single timestamp.
        /// </summary>
        public DateTimeOffset EndTime { get; }

        /// <summary>
        /// The <see cref="Models.ChangePointValue"/> for the feedback.
        /// </summary>
        public ChangePointValue ChangePointValue => ValueInternal.ChangePointValue;

        [CodeGenMember("Value")]
        internal ChangePointFeedbackValue ValueInternal { get; }
    }
}
