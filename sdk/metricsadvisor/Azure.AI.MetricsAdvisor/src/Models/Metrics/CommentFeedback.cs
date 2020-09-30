// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary> The CommentFeedback. </summary>
    public partial class CommentFeedback : MetricFeedback
    {
        /// <summary> Initializes a new instance of CommentFeedbackInternal. </summary>
        /// <param name="metricId"> The metric unique id. </param>
        /// <param name="dimensionFilter"> The dimension filter. </param>
        /// <param name="value"> The value for the feedback. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="dimensionFilter"/> or <paramref name="value"/> is null. </exception>
        public CommentFeedback(Guid metricId, FeedbackDimensionFilter dimensionFilter, string value) : base(metricId, dimensionFilter)
        {
            if (dimensionFilter == null)
            {
                throw new ArgumentNullException(nameof(dimensionFilter));
            }
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            Value = new CommentFeedbackValue(value);
            FeedbackType = FeedbackType.Comment;
        }

        /// <summary> Initializes a new instance of CommentFeedback. </summary>
        /// <param name="metricId"> metric unique id. </param>
        /// <param name="dimensionFilter"> . </param>
        /// <param name="value"> . </param>
        /// <exception cref="ArgumentNullException"> <paramref name="dimensionFilter"/> or <paramref name="value"/> is null. </exception>
        internal CommentFeedback(Guid metricId, FeedbackDimensionFilter dimensionFilter, CommentFeedbackValue value) : base(metricId, dimensionFilter)
        {
            if (dimensionFilter == null)
            {
                throw new ArgumentNullException(nameof(dimensionFilter));
            }
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            Value = value;
            FeedbackType = Models.FeedbackType.Comment;
        }

        /// <summary>
        /// The value of the feedback.
        /// </summary>
        public CommentFeedbackValue Value { get; set; }
    }
}
