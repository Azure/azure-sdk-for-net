// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.JobRouter
{
    /// <summary>
    /// Options for filtering while retrieving router workers.
    /// </summary>
    public class GetWorkersOptions
    {
        /// <summary>
        /// If specified, filter workers by worker status.
        /// </summary>
        public WorkerStateSelector Status { get; set; }

        /// <summary>
        /// Worker available in the particular channel.
        /// </summary>
        public string ChannelId { get; set; }

        /// <summary>
        /// If specified, select workers who are assigned to this queue.
        /// </summary>
        public string QueueId { get; set; }

        /// <summary>
        /// If set to true, select only workers who have capacity for the channel specified by <see cref="ChannelId"/> or for any channel if <see cref="ChannelId"/> not specified.
        /// If set to false, then will return all workers including workers without any capacity for jobs. Defaults to false.
        /// </summary>
        public bool HasCapacity { get; set; }
    }
}
