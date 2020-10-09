// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// Specifies which time property of an <see cref="MetricFeedback"/> will be used to filter results
    /// in the <see cref="MetricsAdvisorClient.GetMetricFeedbacks"/> and the <see cref="MetricsAdvisorClient.GetMetricFeedbacksAsync"/>
    /// operations.
    /// </summary>
    public readonly partial struct FeedbackQueryTimeMode
    {
        /// <summary>
        /// Filters feedbacks by its metric's timestamps.
        /// </summary>
        public static FeedbackQueryTimeMode MetricTimestamp { get; } = new FeedbackQueryTimeMode(MetricTimestampValue);

        /// <summary>
        /// Filters feedbacks by <see cref="MetricFeedback.CreatedTime"/>.
        /// </summary>
        public static FeedbackQueryTimeMode FeedbackCreatedTime { get; } = new FeedbackQueryTimeMode(FeedbackCreatedTimeValue);
    }
}
