// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Communication.JobRouter
{
    /// <summary>
    /// Options for updating a job.
    /// </summary>
    public class UpdateJobOptions
    {
        /// <summary>
        /// A set of key/value pairs that are identifying attributes used by the rules engines to make decisions.
        /// </summary>
        public LabelCollection Labels { get; set; }

        /// <summary> Reference to an external parent context, eg. call ID. </summary>
        public string ChannelReference { get; set; }

        /// <summary> The Id of the Queue that this job is queued to. </summary>
        public string QueueId { get; set; }

        /// <summary> The Id of the Classification policy used for classifying a job. </summary>
        public string ClassificationPolicyId { get; set; }

        /// <summary> The channel identifier. eg. voice, chat, etc. </summary>
        public string ChannelId { get; set; }

        /// <summary> The priority of this job. </summary>
        public int? Priority { get; set; }

        /// <summary> Reason code for cancelled or closed jobs. </summary>
        public string DispositionCode { get; set; }

#pragma warning disable CA2227 // Collection properties should be read only
        /// <summary> A collection of manually specified label selectors, which a worker must satisfy in order to process this job. </summary>
        public IList<WorkerSelector> RequestedWorkerSelectors { get; set; }

        /// <summary> Notes attached to a job, sorted by timestamp. </summary>
        public SortedDictionary<DateTimeOffset, string> Notes { get; set; }

        /// <summary> A set of non-identifying attributes attached to this job. </summary>
        public LabelCollection Tags { get; set; }

#pragma warning restore CA2227 // Collection properties should be read only
    }
}
