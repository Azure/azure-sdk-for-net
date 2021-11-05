// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.MetricsAdvisor
{
    /// <summary>
    /// Specifies which time property of a <see cref="MetricFeedback"/> will be used to filter results
    /// in the <see cref="MetricsAdvisorClient.GetAllFeedback"/> and the <see cref="MetricsAdvisorClient.GetAllFeedbackAsync"/>
    /// operations. Defaults to <see cref="None"/>.
    /// </summary>
    [CodeGenModel("FeedbackQueryTimeMode")]
    public enum FeedbackQueryTimeMode
    {
        /// <summary>
        /// No time filter is applied.
        /// </summary>
        None,

        /// <summary>
        /// Filters feedback by its metric's timestamps.
        /// </summary>
        MetricTimestamp,

        /// <summary>
        /// Filters feedback by <see cref="MetricFeedback.CreatedOn"/>.
        /// </summary>
        [CodeGenMember("FeedbackCreatedTime")]
        FeedbackCreatedOn
    }
}
