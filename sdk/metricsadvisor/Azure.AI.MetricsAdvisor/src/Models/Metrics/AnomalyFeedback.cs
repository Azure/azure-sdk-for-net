// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.MetricsAdvisor.Models
{
    internal partial class AnomalyFeedback : MetricFeedback
    {
        /// <summary> Initializes a new instance of AnomalyFeedback. </summary>
        /// <param name="metricId"> The metric unique id. </param>
        /// <param name="dimensionFilter"> The dimension filter. </param>
        /// <param name="startTime"> The start timestamp of feedback timerange. </param>
        /// <param name="endTime"> The end timestamp of feedback timerange, when equals to startTime means only one timestamp. </param>
        /// <param name="value"> The value for the feedback. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="dimensionFilter"/> or <paramref name="value"/> is null. </exception>
        public AnomalyFeedback(Guid metricId, FeedbackDimensionFilter dimensionFilter, DateTimeOffset startTime, DateTimeOffset endTime, AnomalyValue value) : base(metricId, dimensionFilter)
        {
            if (dimensionFilter == null)
            {
                throw new ArgumentNullException(nameof(dimensionFilter));
            }
            if (value == default)
            {
                throw new ArgumentNullException(nameof(value));
            }

            DimensionFilter = dimensionFilter;
            StartTime = startTime;
            EndTime = endTime;
            Value = new AnomalyFeedbackValue(value);
            FeedbackType = FeedbackType.Anomaly;
        }

        /// <summary> Initializes a new instance of AnomalyFeedback. </summary>
        /// <param name="metricId"> metric unique id. </param>
        /// <param name="dimensionFilter"> . </param>
        /// <param name="startTime"> the start timestamp of feedback timerange. </param>
        /// <param name="endTime"> the end timestamp of feedback timerange, when equals to startTime means only one timestamp. </param>
        /// <param name="value"> . </param>
        /// <exception cref="ArgumentNullException"> <paramref name="dimensionFilter"/> or <paramref name="value"/> is null. </exception>
        internal AnomalyFeedback(Guid metricId, FeedbackDimensionFilter dimensionFilter, DateTimeOffset startTime, DateTimeOffset endTime, AnomalyFeedbackValue value) : base(metricId, dimensionFilter)
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
            FeedbackType = Models.FeedbackType.Anomaly;
        }
    }
}
