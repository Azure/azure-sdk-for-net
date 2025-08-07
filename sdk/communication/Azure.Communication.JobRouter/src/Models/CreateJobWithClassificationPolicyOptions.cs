// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    /// <summary>
    /// Options for creating a new job to be routed with classification property.
    /// </summary>
    public class CreateJobWithClassificationPolicyOptions
    {
        /// <summary>
        /// Initializes a new instance of CreateJobWithClassificationPolicyOptions.
        /// </summary>
        /// <param name="jobId"> Id of a job. </param>
        /// <param name="channelId"> The channel identifier. eg. voice, chat, etc. </param>
        /// <param name="classificationPolicyId"> Id of a classification policy used for classifying this job. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="channelId"/> is null. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="classificationPolicyId"/> is null. </exception>
        public CreateJobWithClassificationPolicyOptions(string jobId, string channelId, string classificationPolicyId)
        {
            Argument.AssertNotNullOrWhiteSpace(jobId, nameof(jobId));
            Argument.AssertNotNullOrWhiteSpace(channelId, nameof(channelId));
            Argument.AssertNotNullOrWhiteSpace(classificationPolicyId, nameof(classificationPolicyId));

            JobId = jobId;
            ChannelId = channelId;
            ClassificationPolicyId = classificationPolicyId;
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
        /// Id of a classification policy used for classifying this job.
        /// </summary>
        public string ClassificationPolicyId { get; set; }

        /// <summary> Reference to an external parent context, eg. call ID. </summary>
        public string ChannelReference { get; set; }

        /// <summary> Id of a queue that this job is queued to. </summary>
        public string QueueId { get; set; }

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
