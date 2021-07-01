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
    [CodeGenSuppress(nameof(MetricChangePointFeedback), typeof(string), typeof(FeedbackDimensionFilter))]
    public partial class MetricChangePointFeedback : MetricFeedback
    {
        /// <summary> Initializes a new <see cref="MetricChangePointFeedback"/> instance. </summary>
        /// <param name="metricId"> The metric unique id. </param>
        /// <param name="dimensionFilter"> The dimension filter. </param>
        /// <param name="startOn"> The start timestamp of feedback timerange. </param>
        /// <param name="endOn"> The end timestamp of feedback timerange. When this is equal to <paramref name="startOn"/> it indicates a single timestamp. </param>
        /// <param name="value"> The <see cref="Models.ChangePointValue"/> for the feedback. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="dimensionFilter"/> or <paramref name="value"/> is null. </exception>
        public MetricChangePointFeedback(string metricId, FeedbackDimensionFilter dimensionFilter, DateTimeOffset startOn, DateTimeOffset endOn, ChangePointValue value) : base(metricId, dimensionFilter)
        {
            if (value == default)
            {
                throw new ArgumentNullException(nameof(value));
            }

            StartOn = startOn;
            EndOn = endOn;
            ValueInternal = new ChangePointFeedbackValue(value);
            Kind = MetricFeedbackKind.ChangePoint;
        }

        /// <summary> Initializes a new <see cref="MetricChangePointFeedback"/> instance. </summary>
        /// <param name="metricId"> The metric unique id. </param>
        /// <param name="dimensionFilter"> The dimension filter. </param>
        /// <param name="startOn"> The start timestamp of feedback timerange. </param>
        /// <param name="endOn"> The end timestamp of feedback timerange. When this is equal to <paramref name="startOn"/> it indicates a single timestamp. </param>
        /// <param name="value"> The <see cref="Models.ChangePointFeedbackValue"/> for the feedback. </param>
        internal MetricChangePointFeedback(string metricId, FeedbackDimensionFilter dimensionFilter, DateTimeOffset startOn, DateTimeOffset endOn, ChangePointFeedbackValue value) : base(metricId, dimensionFilter)
        {
            Argument.AssertNotNull(value, nameof(value));

            StartOn = startOn;
            EndOn = endOn;
            ValueInternal = value;
            Kind = MetricFeedbackKind.ChangePoint;
        }

        /// <summary>
        /// The start timestamp of feedback time range.
        /// </summary>
        [CodeGenMember("StartTime")]
        public DateTimeOffset StartOn { get; set; }

        /// <summary>
        /// The end timestamp of feedback timerange. When this is equal to <see cref="StartOn"/> it indicates a single timestamp.
        /// </summary>
        [CodeGenMember("EndTime")]
        public DateTimeOffset EndOn { get; set; }

        /// <summary>
        /// The <see cref="Models.ChangePointValue"/> for the feedback.
        /// </summary>
        public ChangePointValue ChangePointValue { get => ValueInternal.ChangePointValue; }

        [CodeGenMember("Value")]
        internal ChangePointFeedbackValue ValueInternal { get; }
    }
}
