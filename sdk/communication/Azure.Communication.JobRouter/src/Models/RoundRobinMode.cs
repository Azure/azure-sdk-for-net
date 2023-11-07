// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

#nullable disable

namespace Azure.Communication.JobRouter
{
    /// <summary> Jobs are distributed in order to workers, starting with the worker that is after the last worker to receive a job. </summary>
    public partial class RoundRobinMode : IUtf8JsonSerializable
    {
        /// <summary> Initializes a new instance of RoundRobinModePolicy. </summary>
        public RoundRobinMode()
        {
            Kind = "round-robin";
        }

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("kind"u8);
            writer.WriteStringValue(Kind);
            if (Optional.IsDefined(MinConcurrentOffers))
            {
                writer.WritePropertyName("minConcurrentOffers"u8);
                writer.WriteNumberValue(MinConcurrentOffers);
            }
            if (Optional.IsDefined(MaxConcurrentOffers))
            {
                writer.WritePropertyName("maxConcurrentOffers"u8);
                writer.WriteNumberValue(MaxConcurrentOffers);
            }
            if (Optional.IsDefined(BypassSelectors))
            {
                writer.WritePropertyName("bypassSelectors"u8);
                writer.WriteBooleanValue(BypassSelectors.Value);
            }
            writer.WriteEndObject();
        }
    }
}
