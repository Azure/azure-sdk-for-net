// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary> The CommentFeedback. </summary>
    [CodeGenModel("CommentFeedback")]
    [CodeGenSuppress(nameof(MetricCommentFeedback), typeof(string), typeof(FeedbackDimensionFilter))]
    public partial class MetricCommentFeedback : MetricFeedback
    {
        /// <summary> Initializes a new <see cref="MetricCommentFeedback"/> instance. </summary>
        /// <param name="metricId"> The metric unique id. </param>
        /// <param name="dimensionFilter"> The <see cref="FeedbackDimensionFilter"/> to apply to the feedback. </param>
        /// <param name="comment"> The comment content for the feedback. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="dimensionFilter"/> or <paramref name="comment"/> is null. </exception>
        public MetricCommentFeedback(string metricId, FeedbackDimensionFilter dimensionFilter, string comment) : base(metricId, dimensionFilter)
        {
            Argument.AssertNotNullOrEmpty(comment, nameof(comment));

            ValueInternal = new CommentFeedbackValue(comment);
            Type = FeedbackType.Comment;
        }

        /// <summary> Initializes a new <see cref="MetricCommentFeedback"/> instance. </summary>
        /// <param name="metricId"> The metric unique id. </param>
        /// <param name="dimensionFilter"> The <see cref="FeedbackDimensionFilter"/> to apply to the feedback. </param>
        /// <param name="comment"> The comment content for the feedback. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="dimensionFilter"/> or <paramref name="comment"/> is null. </exception>
        internal MetricCommentFeedback(string metricId, FeedbackDimensionFilter dimensionFilter, CommentFeedbackValue comment) : base(metricId, dimensionFilter)
        {
            Argument.AssertNotNullOrEmpty(comment?.CommentValue, nameof(comment.CommentValue));

            ValueInternal = comment;
            Type = FeedbackType.Comment;
        }

        /// <summary>
        /// The start timestamp of feedback time range.
        /// </summary>
        public DateTimeOffset? StartTime { get; set; }

        /// <summary>
        /// The end timestamp of feedback timerange. When this is equal to <see cref="StartTime"/> it indicates a single timestamp.
        /// </summary>
        public DateTimeOffset? EndTime { get; set; }

        /// <summary>
        /// The comment content for the feedback.
        /// </summary>
        public string Comment { get => ValueInternal.CommentValue; }

        [CodeGenMember("Value")]
        internal CommentFeedbackValue ValueInternal { get; }
    }
}
