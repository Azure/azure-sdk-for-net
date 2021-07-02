// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.MetricsAdvisor.Models;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor
{
    /// <summary> The CommentFeedback. </summary>
    [CodeGenModel("CommentFeedback")]
    [CodeGenSuppress(nameof(MetricCommentFeedback), typeof(string), typeof(FeedbackDimensionFilter))]
    public partial class MetricCommentFeedback : MetricFeedback
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MetricCommentFeedback"/> class.
        /// </summary>
        /// <param name="metricId">The identifier of the metric to which the <see cref="MetricCommentFeedback"/> applies.</param>
        /// <param name="dimensionKey">
        /// A key that identifies a set of time series to which the <see cref="MetricCommentFeedback"/> applies.
        /// If all possible dimensions are set, this key uniquely identifies a single time series
        /// for the specified <paramref name="metricId"/>. If only a subset of dimensions are set, this
        /// key uniquely identifies a group of time series.
        /// </param>
        /// <param name="comment">The comment content for the feedback.</param>
        /// <exception cref="ArgumentNullException"><paramref name="metricId"/>, <paramref name="dimensionKey"/>, or <paramref name="comment"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException"><paramref name="metricId"/> or <paramref name="comment"/> is empty.</exception>
        public MetricCommentFeedback(string metricId, DimensionKey dimensionKey, string comment)
            : base(metricId, dimensionKey)
        {
            Argument.AssertNotNullOrEmpty(comment, nameof(comment));

            ValueInternal = new CommentFeedbackValue(comment);
            Kind = MetricFeedbackKind.Comment;
        }

        /// <summary> Initializes a new <see cref="MetricCommentFeedback"/> instance. </summary>
        /// <param name="metricId"> The metric unique id. </param>
        /// <param name="dimensionFilter"> The <see cref="FeedbackDimensionFilter"/> to apply to the feedback. </param>
        /// <param name="comment"> The comment content for the feedback. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="dimensionFilter"/> or <paramref name="comment"/> is null. </exception>
        internal MetricCommentFeedback(string metricId, FeedbackDimensionFilter dimensionFilter, CommentFeedbackValue comment)
            : base(metricId, dimensionFilter.DimensionKey)
        {
            Argument.AssertNotNullOrEmpty(comment?.CommentValue, nameof(comment.CommentValue));

            ValueInternal = comment;
            Kind = MetricFeedbackKind.Comment;
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
        public string Comment => ValueInternal.CommentValue;

        [CodeGenMember("Value")]
        internal CommentFeedbackValue ValueInternal { get; }
    }
}
