// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    /// <summary>
    /// Options for creating a queue.
    /// </summary>
    public class CreateQueueOptions
    {
        /// <summary>
        /// Initializes a new instance of CreateQueueOptions.
        /// </summary>
        /// <param name="queueId"> Id of a queue. </param>
        /// <param name="distributionPolicyId"> Id of a distribution policy that will determine how a job is distributed to workers. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="queueId"/> is null. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="distributionPolicyId"/> is null. </exception>
        public CreateQueueOptions(string queueId, string distributionPolicyId)
        {
            Argument.AssertNotNullOrWhiteSpace(queueId, nameof(queueId));
            Argument.AssertNotNullOrWhiteSpace(distributionPolicyId, nameof(distributionPolicyId));

            QueueId = queueId;
            DistributionPolicyId = distributionPolicyId;
        }

        /// <summary>
        /// Id of a queue.
        /// </summary>
        public string QueueId { get; }

        /// <summary>
        /// The ID of the distribution policy that will determine how a job is distributed to workers.
        /// </summary>
        public string DistributionPolicyId { get; }

        /// <summary> Friendly name of this queue. </summary>
        public string Name { get; set; }

        /// <summary> Id of an exception policy that determines various job escalation rules. </summary>
        public string ExceptionPolicyId { get; set; }

        /// <summary>
        /// A set of key/value pairs that are identifying attributes used by the rules engines to make decisions. Values must be primitive values - number, string, boolean.
        /// </summary>
        public IDictionary<string, RouterValue> Labels { get; } = new Dictionary<string, RouterValue>();

        /// <summary>
        /// The content to send as the request conditions of the request.
        /// </summary>
        public RequestConditions RequestConditions { get; set; } = new();
    }
}
