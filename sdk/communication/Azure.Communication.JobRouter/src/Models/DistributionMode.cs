// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    public abstract partial class DistributionMode : IUtf8JsonSerializable
    {
        /// <summary> The type discriminator describing a sub-type of DistributionMode. </summary>
        public DistributionModeKind Kind { get; protected set; }

        /// <summary>
        /// Governs the minimum desired number of active concurrent offers a job can have.
        /// </summary>
        public int MinConcurrentOffers { get; set; } = 1;

        /// <summary>
        /// Governs the maximum number of active concurrent offers a job can have.
        /// </summary>
        public int MaxConcurrentOffers { get; set; } = 1;

        /// <summary>
        /// If set to true, then router will match workers to jobs even if they don't match label selectors.
        /// Warning: You may get workers that are not qualified for a job they are matched with if you set this variable to true.
        /// This flag is intended more for temporary usage. By default, set to false.
        /// </summary>
        public bool? BypassSelectors { get; set; }

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("kind"u8);
            writer.WriteStringValue(Kind.ToString());
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
