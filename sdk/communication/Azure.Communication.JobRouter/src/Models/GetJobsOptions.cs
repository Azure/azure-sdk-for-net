// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
        public JobStateSelector Status { get; set; }

        /// <summary>
        /// If specified, filter jobs by queue.
        /// </summary>
        public string QueueId { get; set; }

        /// <summary>
        /// If specified, filter jobs by channel.
        /// </summary>
        public string ChannelId { get; set; }
    }
}
