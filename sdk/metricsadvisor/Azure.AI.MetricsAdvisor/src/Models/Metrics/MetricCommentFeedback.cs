// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary> The CommentFeedback. </summary>
    [CodeGenModel("CommentFeedback")]
    public partial class MetricCommentFeedback : MetricFeedback
    {
        /// <summary> Initializes a new instance of CommentFeedbackInternal. </summary>
        /// <param name="metricId"> The metric unique id. </param>
        /// <param name="dimensionFilter"> The dimension filter. </param>
        /// <param name="comment"> The comment for the feedback. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="dimensionFilter"/> or <paramref name="comment"/> is null. </exception>
        public MetricCommentFeedback(string metricId, FeedbackDimensionFilter dimensionFilter, string comment) : base(metricId, dimensionFilter)
        {
            Argument.AssertNotNullOrEmpty(comment, nameof(comment));

            ValueInternal = new CommentFeedbackValue(comment);
            Type = FeedbackType.Comment;
        }

        /// <summary> Initializes a new instance of CommentFeedback. </summary>
        /// <param name="metricId"> metric unique id. </param>
        /// <param name="dimensionFilter"> . </param>
        /// <param name="comment"> The comment for the feedback. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="dimensionFilter"/> or <paramref name="comment"/> is null. </exception>
        internal MetricCommentFeedback(string metricId, FeedbackDimensionFilter dimensionFilter, CommentFeedbackValue comment) : base(metricId, dimensionFilter)
        {
            Argument.AssertNotNullOrEmpty(comment?.CommentValue, nameof(comment.CommentValue));

            ValueInternal = comment;
            Type = Models.FeedbackType.Comment;
        }

        /// <summary>
        /// The comment.
        /// </summary>
        public string Comment { get => ValueInternal.CommentValue; }

        [CodeGenMember("Value")]
        internal CommentFeedbackValue ValueInternal { get; }
    }
}
