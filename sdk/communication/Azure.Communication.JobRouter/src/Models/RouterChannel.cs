// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    public partial class RouterChannel : IUtf8JsonSerializable
    {
        /// <summary>
        /// Represents the capacity a job in this channel will consume from a worker.
        /// </summary>
        /// <param name="channelId"> Id of the channel. </param>
        /// <param name="capacityCostPerJob"> The amount of capacity that an instance of a job of this channel will consume of the total worker capacity. </param>
        public RouterChannel(string channelId, int capacityCostPerJob)
        {
            Argument.AssertNotNullOrWhiteSpace(channelId, nameof(channelId));
            Argument.AssertInRange(capacityCostPerJob, 0, int.MaxValue, nameof(capacityCostPerJob));

            ChannelId = channelId;
            CapacityCostPerJob = capacityCostPerJob;
        }

        /// <summary> The maximum number of jobs that can be supported concurrently for this channel. </summary>
        public int? MaxNumberOfJobs { get; set; }

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("channelId"u8);
            writer.WriteStringValue(ChannelId);
            writer.WritePropertyName("capacityCostPerJob"u8);
            writer.WriteNumberValue(CapacityCostPerJob);

            if (Optional.IsDefined(MaxNumberOfJobs))
            {
                writer.WritePropertyName("maxNumberOfJobs"u8);
                writer.WriteNumberValue(MaxNumberOfJobs.Value);
            }

            writer.WriteEndObject();
        }
    }
}
