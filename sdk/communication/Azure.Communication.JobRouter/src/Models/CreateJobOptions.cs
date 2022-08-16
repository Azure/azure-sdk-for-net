// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    /// <summary>
    /// Options for creating job with direct queue assignment.
    /// </summary>
    public class CreateJobOptions
    {
        /// <summary>
        /// Public constructor.
        /// </summary>
        /// <param name="jobId"> Id of the job. </param>
        /// <param name="channelId"> The channel or modality upon which this job will be executed. </param>
        /// <param name="queueId"> The classification policy that will determine queue, priority and required abilities. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="channelId"/> is null. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="queueId"/> is null. </exception>
        public CreateJobOptions(string jobId, string channelId, string queueId)
        {
            Argument.AssertNotNullOrWhiteSpace(jobId, nameof(jobId));
            Argument.AssertNotNullOrWhiteSpace(channelId, nameof(channelId));
            Argument.AssertNotNullOrWhiteSpace(queueId, nameof(queueId));

            JobId = jobId;
            ChannelId = channelId;
            QueueId = queueId;
        }

        /// <summary>
        /// Id of the job.
        /// </summary>
        public string JobId { get; }

        /// <summary>
        /// The channel or modality upon which this job will be executed.
        /// </summary>
        public string ChannelId { get; }

        /// <summary>
        /// If classification policy does not specify a queue selector or a default queue id, then you must specify a queue. Otherwise, queue will be selected based on classification policy.
        /// </summary>
        public string QueueId { get; }

        /// <summary> Reference to an external parent context, eg. call ID. </summary>
        public string ChannelReference { get; set; }

        /// <summary> The priority of this job. </summary>
        public int? Priority { get; set; }

#pragma warning disable CA2227 // Collection properties should be read only
        /// <summary> A collection of manually specified label selectors, which a worker must satisfy in order to process this job. </summary>
        public IList<WorkerSelector> RequestedWorkerSelectors { get; set; } = new List<WorkerSelector>();

        /// <summary> Notes attached to a job, sorted by timestamp. </summary>
        public IDictionary<DateTimeOffset, string> Notes { get; set; } = new Dictionary<DateTimeOffset, string>();

        /// <summary> A set of non-identifying attributes attached to this job. </summary>
        public IDictionary<string, LabelValue> Tags { get; set; } = new Dictionary<string, LabelValue>();

        /// <summary>
        /// A set of key/value pairs that are identifying attributes used by the rules engines to make decisions.
        /// </summary>
        public IDictionary<string, LabelValue> Labels { get; set; } = new Dictionary<string, LabelValue>();

#pragma warning restore CA2227 // Collection properties should be read only
    }
}
