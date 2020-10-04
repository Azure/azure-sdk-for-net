// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary> The <see cref="MetricChangePointFeedback"/>. </summary>
    [CodeGenModel("ChangePointFeedback")]
    public partial class MetricChangePointFeedback : MetricFeedback
    {
        /// <summary> Initializes a new instance of <see cref="MetricChangePointFeedback"/>. </summary>
        /// <param name="metricId"> The metric unique id. </param>
        /// <param name="dimensionFilter"> The dimension filter. </param>
        /// <param name="startTime"> The start timestamp of feedback timerange. </param>
        /// <param name="endTime"> The end timestamp of feedback timerange, when equals to startTime means only one timestamp. </param>
        /// <param name="value"> The value for the feedback. </param>
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

        /// <summary> Initializes a new instance of ChangePointFeedback. </summary>
        /// <param name="metricId"> metric unique id. </param>
        /// <param name="dimensionFilter"> . </param>
        /// <param name="startTime"> the start timestamp of feedback timerange. </param>
        /// <param name="endTime"> the end timestamp of feedback timerange, when equals to startTime means only one timestamp. </param>
        /// <param name="value"> . </param>
        /// <exception cref="ArgumentNullException"> <paramref name="dimensionFilter"/> or <paramref name="value"/> is null. </exception>
        internal MetricChangePointFeedback(string metricId, FeedbackDimensionFilter dimensionFilter, DateTimeOffset startTime, DateTimeOffset endTime, ChangePointFeedbackValue value) : base(metricId, dimensionFilter)
        {
            Argument.AssertNotNull(value, nameof(value));

            StartTime = startTime;
            EndTime = endTime;
            ValueInternal = value;
            Type = Models.FeedbackType.ChangePoint;
        }

        /// <summary>
        /// The changepoint value.
        /// </summary>
        public ChangePointValue ChangePointValue { get => ValueInternal.ChangePointValue; }

        [CodeGenMember("Value")]
        internal ChangePointFeedbackValue ValueInternal { get; }
    }
}
