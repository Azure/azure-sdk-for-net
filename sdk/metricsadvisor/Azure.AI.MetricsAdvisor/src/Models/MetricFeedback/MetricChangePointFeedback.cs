// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// Feedback indicating that this is the start of a trend change.
    /// </summary>
    [CodeGenModel("ChangePointFeedback")]
    [CodeGenSuppress(nameof(MetricChangePointFeedback), typeof(string), typeof(FeedbackDimensionFilter))]
    public partial class MetricChangePointFeedback : MetricFeedback
    {
        /// <summary> Initializes a new <see cref="MetricChangePointFeedback"/> instance. </summary>
        /// <param name="metricId"> The metric unique id. </param>
        /// <param name="dimensionFilter"> The dimension filter. </param>
        /// <param name="startTime"> The start timestamp of feedback timerange. </param>
        /// <param name="endTime"> The end timestamp of feedback timerange. When this is equal to <paramref name="startTime"/> it indicates a single timestamp. </param>
        /// <param name="value"> The <see cref="Models.ChangePointValue"/> for the feedback. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="dimensionFilter"/> or <paramref name="value"/> is null. </exception>
        public MetricChangePointFeedback(string metricId, FeedbackDimensionFilter dimensionFilter, DateTimeOffset startTime, DateTimeOffset endTime, ChangePointValue value) : base(metricId, dimensionFilter)
        {
            if (value == default)
            {
                throw new ArgumentNullException(nameof(value));
            }

            StartTime = startTime;
            EndTime = endTime;
            ValueInternal = new ChangePointFeedbackValue(value);
            Type = FeedbackType.ChangePoint;
        }

        /// <summary> Initializes a new <see cref="MetricChangePointFeedback"/> instance. </summary>
        /// <param name="metricId"> The metric unique id. </param>
        /// <param name="dimensionFilter"> The dimension filter. </param>
        /// <param name="startTime"> The start timestamp of feedback timerange. </param>
        /// <param name="endTime"> The end timestamp of feedback timerange. When this is equal to <paramref name="startTime"/> it indicates a single timestamp. </param>
        /// <param name="value"> The <see cref="Models.ChangePointFeedbackValue"/> for the feedback. </param>
        internal MetricChangePointFeedback(string metricId, FeedbackDimensionFilter dimensionFilter, DateTimeOffset startTime, DateTimeOffset endTime, ChangePointFeedbackValue value) : base(metricId, dimensionFilter)
        {
            Argument.AssertNotNull(value, nameof(value));

            StartTime = startTime;
            EndTime = endTime;
            ValueInternal = value;
            Type = Models.FeedbackType.ChangePoint;
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
        /// The <see cref="Models.ChangePointValue"/> for the feedback.
        /// </summary>
        public ChangePointValue ChangePointValue { get => ValueInternal.ChangePointValue; }

        [CodeGenMember("Value")]
        internal ChangePointFeedbackValue ValueInternal { get; }
    }
}
