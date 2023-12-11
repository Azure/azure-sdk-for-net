// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    /// <summary>
    /// Options for creating a new job to be routed.
    /// </summary>
    public class CreateJobOptions
    {
        /// <summary>
        /// Initializes a new instance of CreateJobOptions.
        /// </summary>
        /// <param name="jobId"> Id of a job. </param>
        /// <param name="channelId"> The channel identifier. eg. voice, chat, etc. </param>
        /// <param name="queueId"> Id of a queue that this job is queued to. </param>
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
        /// Id of a job.
        /// </summary>
        public string JobId { get; }

        /// <summary>
        /// The channel identifier. eg. voice, chat, etc.
        /// </summary>
        public string ChannelId { get; }

        /// <summary>
        /// If classification policy does not specify a queue selector or a default queue id, then you must specify a queue. Otherwise, queue will be selected based on classification policy.
        /// </summary>
        public string QueueId { get; }

        /// <summary> Reference to an external parent context, eg. call ID. </summary>
        public string ChannelReference { get; set; }

        /// <summary> Priority of this job. </summary>
        public int? Priority { get; set; }

        /// <summary> A collection of manually specified worker selectors, which a worker must satisfy in order to process this job. </summary>
        public IList<RouterWorkerSelector> RequestedWorkerSelectors { get; } = new List<RouterWorkerSelector>();

        /// <summary> A collection of notes attached to a job. </summary>
        public IList<RouterJobNote> Notes { get; } = new List<RouterJobNote>();

        /// <summary> A set of non-identifying attributes attached to this job. Values must be primitive values - number, string, boolean. </summary>
        public IDictionary<string, RouterValue> Tags { get; } = new Dictionary<string, RouterValue>();

        /// <summary>
        /// A set of key/value pairs that are identifying attributes used by the rules engines to make decisions. Values must be primitive values - number, string, boolean.
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
