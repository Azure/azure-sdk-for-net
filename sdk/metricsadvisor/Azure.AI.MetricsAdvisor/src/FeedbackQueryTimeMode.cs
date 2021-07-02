// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.MetricsAdvisor
{
    /// <summary>
    /// Specifies which time property of a <see cref="MetricFeedback"/> will be used to filter results
    /// in the <see cref="MetricsAdvisorClient.GetAllFeedback"/> and the <see cref="MetricsAdvisorClient.GetAllFeedbackAsync"/>
    /// operations.
    /// </summary>
    [CodeGenModel("FeedbackQueryTimeMode")]
    public enum FeedbackQueryTimeMode
    {
        /// <summary>
        /// Filters feedbacks by its metric's timestamps.
        /// </summary>
        MetricTimestamp,

        /// <summary>
        /// Filters feedbacks by <see cref="MetricFeedback.CreatedOn"/>.
        /// </summary>
        [CodeGenMember("FeedbackCreatedTime")]
        FeedbackCreatedOn
    }
}
