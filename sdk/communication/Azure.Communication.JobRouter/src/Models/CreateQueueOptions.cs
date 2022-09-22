// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    /// <summary>
    /// Options for creating a job queue.
    /// </summary>
    public class CreateQueueOptions
    {
        /// <summary>
        /// Public constructor.
        /// </summary>
        /// <param name="queueId"> The id of this queue. </param>
        /// <param name="distributionPolicyId"> The ID of the distribution policy that will determine how a job is distributed to workers. </param>
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
        /// Unique key that identifies this queue.
        /// </summary>
        public string QueueId { get; }

        /// <summary>
        /// The ID of the distribution policy that will determine how a job is distributed to workers.
        /// </summary>
        public string DistributionPolicyId { get; }

        /// <summary> The name of this queue. </summary>
        public string Name { get; set; }
        /// <summary> (Optional) The ID of the exception policy that determines various job escalation rules. </summary>
        public string ExceptionPolicyId { get; set; }

        /// <summary>
        /// A set of key/value pairs that are identifying attributes used by the rules engines to make decisions.
        /// </summary>
#pragma warning disable CA2227 // Collection properties should be read only
        public IDictionary<string, LabelValue> Labels { get; set; } = new Dictionary<string, LabelValue>();
#pragma warning restore CA2227 // Collection properties should be read only
    }
}
