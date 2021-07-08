// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.MetricsAdvisor.Models;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor
{
    /// <summary>
    /// Adds comments to annotate and provide context to your data. This has no impact in the process of
    /// detecting anomalies.
    /// </summary>
    /// <remarks>
    /// In order to create comment feedback, you must pass this instance to the method
    /// <see cref="MetricsAdvisorClient.AddFeedbackAsync"/>.
    /// </remarks>
    [CodeGenModel("CommentFeedback")]
    [CodeGenSuppress(nameof(MetricCommentFeedback), typeof(string), typeof(FeedbackFilter))]
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
            FeedbackKind = MetricFeedbackKind.Comment;
        }

        /// <summary> Initializes a new <see cref="MetricCommentFeedback"/> instance. </summary>
        /// <param name="metricId"> The metric unique id. </param>
        /// <param name="feedbackFilter"> The <see cref="FeedbackFilter"/> to apply to the feedback. </param>
        /// <param name="comment"> The comment content for the feedback. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="feedbackFilter"/> or <paramref name="comment"/> is null. </exception>
        internal MetricCommentFeedback(string metricId, FeedbackFilter feedbackFilter, CommentFeedbackValue comment)
            : base(metricId, feedbackFilter.DimensionKey)
        {
            Argument.AssertNotNullOrEmpty(comment?.CommentValue, nameof(comment.CommentValue));

            ValueInternal = comment;
            FeedbackKind = MetricFeedbackKind.Comment;
        }

        /// <summary>
        /// The start timestamp of feedback time range.
        /// </summary>
        [CodeGenMember("StartTime")]
        public DateTimeOffset? StartsOn { get; set; }

        /// <summary>
        /// The end timestamp of feedback timerange. When this is equal to <see cref="StartsOn"/> it indicates a single timestamp.
        /// </summary>
        [CodeGenMember("EndTime")]
        public DateTimeOffset? EndsOn { get; set; }

        /// <summary>
        /// The comment content for the feedback.
        /// </summary>
        public string Comment => ValueInternal.CommentValue;

        [CodeGenMember("Value")]
        internal CommentFeedbackValue ValueInternal { get; }
    }
}
