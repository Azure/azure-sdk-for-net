// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary> The ChangePointFeedback. </summary>
    public partial class ChangePointFeedback : MetricFeedback
    {
        /// <summary> Initializes a new instance of ChangePointFeedback. </summary>
        /// <param name="metricId"> The metric unique id. </param>
        /// <param name="dimensionFilter"> The dimension filter. </param>
        /// <param name="startTime"> The start timestamp of feedback timerange. </param>
        /// <param name="endTime"> The end timestamp of feedback timerange, when equals to startTime means only one timestamp. </param>
        /// <param name="value"> The value for the feedback. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="dimensionFilter"/> or <paramref name="value"/> is null. </exception>
        public ChangePointFeedback(Guid metricId, FeedbackDimensionFilter dimensionFilter, DateTimeOffset startTime, DateTimeOffset endTime, ChangePointValue value) : base(metricId, dimensionFilter)
        {
            if (dimensionFilter == null)
            {
                throw new ArgumentNullException(nameof(dimensionFilter));
            }
            if (value == default)
            {
                throw new ArgumentNullException(nameof(value));
            }

            StartTime = startTime;
            EndTime = endTime;
            Value = new ChangePointFeedbackValue(value);
            FeedbackType = FeedbackType.ChangePoint;
        }

        /// <summary> Initializes a new instance of ChangePointFeedback. </summary>
        /// <param name="metricId"> metric unique id. </param>
        /// <param name="dimensionFilter"> . </param>
        /// <param name="startTime"> the start timestamp of feedback timerange. </param>
        /// <param name="endTime"> the end timestamp of feedback timerange, when equals to startTime means only one timestamp. </param>
        /// <param name="value"> . </param>
        /// <exception cref="ArgumentNullException"> <paramref name="dimensionFilter"/> or <paramref name="value"/> is null. </exception>
        internal ChangePointFeedback(Guid metricId, FeedbackDimensionFilter dimensionFilter, DateTimeOffset startTime, DateTimeOffset endTime, ChangePointFeedbackValue value) : base(metricId, dimensionFilter)
        {
            if (dimensionFilter == null)
            {
                throw new ArgumentNullException(nameof(dimensionFilter));
            }
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            StartTime = startTime;
            EndTime = endTime;
            Value = value;
            FeedbackType = Models.FeedbackType.ChangePoint;
        }

        /// <summary>
        /// The value of the feedback.
        /// </summary>
        public ChangePointFeedbackValue Value { get; set; }
    }
}
