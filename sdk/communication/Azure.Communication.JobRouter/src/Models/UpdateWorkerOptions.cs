// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable
using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    /// <summary>
    /// Options for updating a router worker.
    /// </summary>
    public class UpdateWorkerOptions
    {
        /// <summary>
        /// Public constructor.
        /// </summary>
        /// <param name="workerId"> Id of the job. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="workerId"/> is null. </exception>
        public UpdateWorkerOptions(string workerId)
        {
            Argument.AssertNotNullOrWhiteSpace(workerId, nameof(workerId));

            WorkerId = workerId;
        }

        /// <summary>
        /// Unique key that identifies this worker.
        /// </summary>
        public string WorkerId { get; }

        /// <summary> The total capacity score this worker has to manage multiple concurrent jobs. </summary>
        public int? TotalCapacity { get; set; }

        /// <summary> A flag indicating this worker is open to receive offers or not. </summary>
        public bool? AvailableForOffers { get; set; }

        /// <summary>
        /// A set of key/value pairs that are identifying attributes used by the rules engines to make decisions.
        /// </summary>
        public IDictionary<string, LabelValue?> Labels { get; } = new Dictionary<string, LabelValue?>();

        /// <summary>
        /// A set of non-identifying attributes attached to this worker.
        /// </summary>
        public IDictionary<string, LabelValue?> Tags { get; } = new Dictionary<string, LabelValue?>();

        /// <summary> The channel(s) this worker can handle and their impact on the workers capacity. </summary>
        public IDictionary<string, ChannelConfiguration?> ChannelConfigurations { get; } = new Dictionary<string, ChannelConfiguration?>();

        /// <summary> The queue(s) that this worker can receive work from. </summary>
        public IDictionary<string, RouterQueueAssignment?> QueueAssignments { get; } = new Dictionary<string, RouterQueueAssignment?>();

        /// <summary>
        /// The content to send as the request conditions of the request.
        /// </summary>
        public RequestConditions RequestConditions { get; set; } = new();
    }
}
