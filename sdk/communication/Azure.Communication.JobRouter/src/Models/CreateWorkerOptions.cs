// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    /// <summary>
    /// Options for creating a router worker.
    /// </summary>
    public class CreateWorkerOptions
    {
        /// <summary>
        /// Public constructor.
        /// </summary>
        /// <param name="workerId"> Id of the job. </param>
        /// <param name="totalCapacity"> The total capacity score this worker has to manage multiple concurrent jobs. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="workerId"/> is null. </exception>
        public CreateWorkerOptions(string workerId, int totalCapacity)
        {
            Argument.AssertNotNullOrWhiteSpace(workerId, nameof(workerId));
            Argument.AssertNotNull(totalCapacity, nameof(totalCapacity));

            WorkerId = workerId;
            TotalCapacity = totalCapacity;
        }

        /// <summary>
        /// Unique key that identifies this worker.
        /// </summary>
        public string WorkerId { get; }

        /// <summary>
        /// The total capacity score this worker has to manage multiple concurrent jobs.
        /// </summary>
        public int TotalCapacity { get; }

        /// <summary> A flag indicating this worker is open to receive offers or not. </summary>
        public bool AvailableForOffers { get; set; }

#pragma warning disable CA2227 // Collection properties should be read only
        /// <summary>
        /// A set of key/value pairs that are identifying attributes used by the rules engines to make decisions.
        /// </summary>
        public IDictionary<string, LabelValue> Labels { get; set; } = new Dictionary<string, LabelValue>();

        /// <summary>
        /// A set of non-identifying attributes attached to this worker.
        /// </summary>
        public IDictionary<string, LabelValue> Tags { get; set; } = new Dictionary<string, LabelValue>();

        /// <summary> The channel(s) this worker can handle and their impact on the workers capacity. </summary>
        public IDictionary<string, ChannelConfiguration> ChannelConfigurations { get; set; } =
            new Dictionary<string, ChannelConfiguration>();

        /// <summary> The queue(s) that this worker can receive work from. </summary>
        public IDictionary<string, QueueAssignment> QueueIds { get; set; } =
            new Dictionary<string, QueueAssignment>();
#pragma warning restore CA2227 // Collection properties should be read only
    }
}
