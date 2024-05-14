// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    /// <summary>
    /// Options for creating a worker.
    /// </summary>
    public class CreateWorkerOptions
    {
        /// <summary>
        /// Initializes a new instance of CreateWorkerOptions.
        /// </summary>
        /// <param name="workerId"> Id of a worker. </param>
        /// <param name="capacity"> The total capacity score this worker has to manage multiple concurrent jobs. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="workerId"/> is null. </exception>
        public CreateWorkerOptions(string workerId, int capacity)
        {
            Argument.AssertNotNullOrWhiteSpace(workerId, nameof(workerId));

            WorkerId = workerId;
            Capacity = capacity;
        }

        /// <summary>
        /// Id of a worker.
        /// </summary>
        public string WorkerId { get; }

        /// <summary>
        /// The total capacity score this worker has to manage multiple concurrent jobs.
        /// </summary>
        public int Capacity { get; }

        /// <summary> A flag indicating whether this worker is open to receive offers or not. </summary>
        public bool AvailableForOffers { get; set; }

        /// <summary>
        /// A set of key/value pairs that are identifying attributes used by the rules engines to make decisions. Values must be primitive values - number, string, boolean.
        /// </summary>
        public IDictionary<string, RouterValue> Labels { get; } = new Dictionary<string, RouterValue>();

        /// <summary>
        /// A set of non-identifying attributes attached to this worker. Values must be primitive values - number, string, boolean.
        /// </summary>
        public IDictionary<string, RouterValue> Tags { get; } = new Dictionary<string, RouterValue>();

        /// <summary> Collection of channel(s) this worker can handle and their impact on the workers capacity. </summary>
        public IList<RouterChannel> Channels { get; } = new List<RouterChannel>();

        /// <summary> Collection of queue(s) that this worker can receive work from. </summary>
        public IList<string> Queues { get; } = new List<string>();

        /// <summary>
        /// The content to send as the request conditions of the request.
        /// </summary>
        public RequestConditions RequestConditions { get; set; } = new();
    }
}
