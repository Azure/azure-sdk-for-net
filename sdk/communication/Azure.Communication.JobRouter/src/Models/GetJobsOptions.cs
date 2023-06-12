// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.JobRouter
{
    /// <summary>
    /// Options for filter while retrieving jobs.
    /// </summary>
    public class GetJobsOptions
    {
        /// <summary>
        /// If specified, filter jobs by status.
        /// </summary>
        public JobStateSelector? Status { get; set; } = null;

        /// <summary>
        /// If specified, filter jobs by queue.
        /// </summary>
        public string QueueId { get; set; }

        /// <summary>
        /// If specified, filter jobs by channel.
        /// </summary>
        public string ChannelId { get; set; }

        /// <summary>
        /// If specified, filter jobs by classification policy.
        /// </summary>
        public string ClassificationPolicyId { get; set; }

        /// <summary>
        /// If specified, filter on jobs that was scheduled before or at given timestamp. Range: (-Inf, scheduledBefore].
        /// </summary>
        public DateTimeOffset? ScheduledBefore { get; set; }

        /// <summary>
        /// If specified, filter on jobs that was scheduled at or after given value. Range: [scheduledAfter, +Inf).
        /// </summary>
        public DateTimeOffset? ScheduledAfter { get; set; }
    }
}
