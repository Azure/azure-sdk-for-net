﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    /// <summary>
    /// Options for creating job with classification properties.
    /// </summary>
    public class CreateJobWithClassificationPolicyOptions
    {
        /// <summary>
        /// Public constructor.
        /// </summary>
        /// <param name="jobId"> Id of the job. </param>
        /// <param name="channelId"> The channel or modality upon which this job will be executed. </param>
        /// <param name="classificationPolicyId"> The classification policy that will determine queue, priority and required abilities. </param>
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
        /// Id of the job.
        /// </summary>
        public string JobId { get; }

        /// <summary>
        /// The channel or modality upon which this job will be executed.
        /// </summary>
        public string ChannelId { get; }

        /// <summary>
        /// The classification policy that will determine queue, priority and required abilities.
        /// </summary>
        public string ClassificationPolicyId { get; set; }

        /// <summary> Reference to an external parent context, eg. call ID. </summary>
        public string ChannelReference { get; set; }

        /// <summary> The Id of the Queue that this job is queued to. </summary>
        public string QueueId { get; set; }

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

        /// <summary>
        /// A flag indicating this job is ready for being matched with workers.
        /// When set to true, job matching will not be started. If set to false, job matching will start automatically
        /// </summary>
        public bool? UnavailableForMatching { get; set; }
        /// <summary> If set, job will be scheduled to be enqueued at a given time. </summary>
        public DateTimeOffset? ScheduledTimeUtc { get; set; }
    }
}
