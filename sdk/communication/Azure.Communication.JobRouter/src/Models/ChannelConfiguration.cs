// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    [CodeGenModel("ChannelConfiguration")]
    public partial class ChannelConfiguration: IUtf8JsonSerializable
    {
        /// <summary> The maximum number of jobs that can be supported concurrently for this channel. </summary>
        public int? MaxNumberOfJobs { get; set; }

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
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
