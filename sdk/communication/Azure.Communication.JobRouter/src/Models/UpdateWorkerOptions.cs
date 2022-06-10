// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Communication.JobRouter
{
    /// <summary>
    /// Options for updating a router worker.
    /// </summary>
    public class UpdateWorkerOptions
    {
        /// <summary> The total capacity score this worker has to manage multiple concurrent jobs. </summary>
        public int? TotalCapacity { get; set; }

        /// <summary> A flag indicating this worker is open to receive offers or not. </summary>
        public bool? AvailableForOffers { get; set; }

        /// <summary>
        /// A set of key/value pairs that are identifying attributes used by the rules engines to make decisions.
        /// </summary>
        public LabelCollection Labels { get; set; }

        /// <summary>
        /// A set of non-identifying attributes attached to this worker.
        /// </summary>
        public LabelCollection Tags { get; set; }

#pragma warning disable CA2227 // Collection properties should be read only
        /// <summary> The channel(s) this worker can handle and their impact on the workers capacity. </summary>
        public IDictionary<string, ChannelConfiguration> ChannelConfigurations { get; set; }

        /// <summary> The queue(s) that this worker can receive work from. </summary>
        public IEnumerable<string> QueueIds { get; set; }
#pragma warning restore CA2227 // Collection properties should be read only
    }
}
