// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    public partial class RouterChannel
    {
        /// <summary>
        /// Represents the capacity a job in this channel will consume from a worker.
        /// </summary>
        /// <param name="channelId"> Id of a channel. </param>
        /// <param name="capacityCostPerJob"> The amount of capacity that an instance of a job of this channel will consume of the total worker capacity. </param>
        public RouterChannel(string channelId, int capacityCostPerJob)
        {
            if (channelId == null)
            {
                throw new ArgumentNullException(nameof(channelId));
            }
            if (string.IsNullOrWhiteSpace(channelId))
            {
                throw new ArgumentException("Value cannot be empty or contain only white-space characters.", nameof(channelId));
            }
            if (capacityCostPerJob < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacityCostPerJob), "Value is less than the minimum allowed.");
            }

            ChannelId = channelId;
            CapacityCostPerJob = capacityCostPerJob;
        }

        /// <summary> The maximum number of jobs that can be supported concurrently for this channel. </summary>
        public int? MaxNumberOfJobs { get; set; }
    }
}
