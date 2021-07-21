// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.MetricsAdvisor.Models;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor
{
    /// <summary>
    /// Specifies which time property of a <see cref="MetricFeedback"/> will be used to filter results
    /// in the <see cref="MetricsAdvisorClient.GetAllFeedback"/> and the <see cref="MetricsAdvisorClient.GetAllFeedbackAsync"/>
    /// operations.
    /// </summary>
    [CodeGenModel("FeedbackQueryTimeMode")]
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
