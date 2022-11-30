// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
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
        public string DistributionPolicyId { get; set; }

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
