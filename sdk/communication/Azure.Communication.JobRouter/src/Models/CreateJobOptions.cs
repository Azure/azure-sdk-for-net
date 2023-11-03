// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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

        /// <summary> The priority of this job (range from -100 to 100). </summary>
        public int? Priority { get; set; }

        /// <summary> A collection of manually specified label selectors, which a worker must satisfy in order to process this job. </summary>
        public IList<RouterWorkerSelector> RequestedWorkerSelectors { get; } = new List<RouterWorkerSelector>();

        /// <summary> Notes attached to a job, sorted by timestamp. </summary>
        public IList<RouterJobNote> Notes { get; } = new List<RouterJobNote>();

        /// <summary> A set of non-identifying attributes attached to this job. </summary>
        public IDictionary<string, RouterValue> Tags { get; } = new Dictionary<string, RouterValue>();

        /// <summary>
        /// A set of key/value pairs that are identifying attributes used by the rules engines to make decisions.
        /// </summary>
        public IDictionary<string, RouterValue> Labels { get; } = new Dictionary<string, RouterValue>();

        /// <summary>
        /// If provided, will determine how job matching will be carried out. Default mode: QueueAndMatchMode.
        /// </summary>
        public JobMatchingMode MatchingMode { get; set; }

        /// <summary>
        /// The content to send as the request conditions of the request.
        /// </summary>
        public RequestConditions RequestConditions { get; set; } = new();
    }
}
