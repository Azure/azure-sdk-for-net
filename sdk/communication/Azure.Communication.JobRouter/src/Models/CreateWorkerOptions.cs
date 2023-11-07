// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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
        /// <param name="capacity"> The total capacity score this worker has to manage multiple concurrent jobs. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="workerId"/> is null. </exception>
        public CreateWorkerOptions(string workerId, int capacity)
        {
            Argument.AssertNotNullOrWhiteSpace(workerId, nameof(workerId));
            Argument.AssertNotNull(capacity, nameof(capacity));

            WorkerId = workerId;
            Capacity = capacity;
        }

        /// <summary>
        /// Unique key that identifies this worker.
        /// </summary>
        public string WorkerId { get; }

        /// <summary>
        /// The total capacity score this worker has to manage multiple concurrent jobs.
        /// </summary>
        public int Capacity { get; }

        /// <summary> A flag indicating this worker is open to receive offers or not. </summary>
        public bool AvailableForOffers { get; set; }

        /// <summary>
        /// A set of key/value pairs that are identifying attributes used by the rules engines to make decisions.
        /// </summary>
        public IDictionary<string, RouterValue> Labels { get; } = new Dictionary<string, RouterValue>();

        /// <summary>
        /// A set of non-identifying attributes attached to this worker.
        /// </summary>
        public IDictionary<string, RouterValue> Tags { get; } = new Dictionary<string, RouterValue>();

        /// <summary> The channel(s) this worker can handle and their impact on the workers capacity. </summary>
        public IList<RouterChannel> Channels { get; } = new List<RouterChannel>();

        /// <summary> The queue(s) that this worker can receive work from. </summary>
        public IList<string> Queues { get; } = new List<string>();

        /// <summary>
        /// The content to send as the request conditions of the request.
        /// </summary>
        public RequestConditions RequestConditions { get; set; } = new();
    }
}
