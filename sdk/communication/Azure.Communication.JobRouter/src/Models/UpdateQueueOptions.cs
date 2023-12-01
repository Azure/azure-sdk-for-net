// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable
using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    /// <summary>
    /// Options for updating a job queue.
    /// </summary>
    public class UpdateQueueOptions
    {
        /// <summary>
        /// Public constructor.
        /// </summary>
        /// <param name="queueId"> The id of this queue. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="queueId"/> is null. </exception>
        public UpdateQueueOptions(string queueId)
        {
            Argument.AssertNotNullOrWhiteSpace(queueId, nameof(queueId));

            QueueId = queueId;
        }

        /// <summary>
        /// Unique key that identifies this queue.
        /// </summary>
        public string QueueId { get; }

        /// <summary> The ID of the distribution policy that will determine how a job is distributed to workers. </summary>
        public string? DistributionPolicyId { get; set; }

        /// <summary> The name of this queue. </summary>
        public string? Name { get; set; }

        /// <summary> (Optional) The ID of the exception policy that determines various job escalation rules. </summary>
        public string? ExceptionPolicyId { get; set; }

        /// <summary>
        /// A set of key/value pairs that are identifying attributes used by the rules engines to make decisions.
        /// </summary>
        public IDictionary<string, LabelValue?> Labels { get; } = new Dictionary<string, LabelValue?>();

        /// <summary>
        /// The content to send as the request conditions of the request.
        /// </summary>
        public RequestConditions RequestConditions { get; set; } = new();
    }
}
