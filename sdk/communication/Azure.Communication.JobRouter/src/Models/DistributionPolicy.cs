﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    public partial class DistributionPolicy : IUtf8JsonSerializable
    {
        /// <summary> Initializes a new instance of distribution policy. </summary>
        /// <param name="distributionPolicyId"> Id of a distribution policy. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="distributionPolicyId"/> is null. </exception>
        public DistributionPolicy(string distributionPolicyId)
        {
            Argument.AssertNotNullOrWhiteSpace(distributionPolicyId, nameof(distributionPolicyId));

            Id = distributionPolicyId;
        }

        /// <summary> Initializes a new instance of DistributionPolicy. </summary>
        /// <param name="offerExpiresAfter"> Number of seconds after which any offers created under this policy will be expired. </param>
        /// <param name="mode"> Mode governing the specific distribution method. </param>
        internal DistributionPolicy(TimeSpan? offerExpiresAfter, DistributionMode mode)
        {
            OfferExpiresAfter = offerExpiresAfter;
            Mode = mode;
        }

        /// <summary> Length of time after which any offers created under this policy will be expired. </summary>
        [CodeGenMember("OfferExpiresAfterSeconds")]
        [CodeGenMemberSerializationHooks(SerializationValueHook = nameof(WriteOfferExpiresAfter), DeserializationValueHook = nameof(ReadOfferExpiresAfter))]
        public TimeSpan? OfferExpiresAfter { get; set; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void WriteOfferExpiresAfter(Utf8JsonWriter writer)
        {
            writer.WriteNumberValue(OfferExpiresAfter.Value.TotalSeconds);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void ReadOfferExpiresAfter(JsonProperty property, ref Optional<TimeSpan> offerExpiresAfter)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
            {
                return;
            }
            var value = property.Value.GetDouble();
            offerExpiresAfter = TimeSpan.FromSeconds(value);
        }

        /// <summary> Friendly name of this policy. </summary>
        public string Name { get; set; }

        /// <summary>
        /// Mode governing the specific distribution method.
        /// </summary>
        public DistributionMode Mode { get; set; }

        /// <summary> The entity tag for this resource. </summary>
        [CodeGenMember("Etag")]
        public ETag ETag { get; }

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Name))
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            if (Optional.IsDefined(OfferExpiresAfter))
            {
                writer.WritePropertyName("offerExpiresAfterSeconds"u8);
                WriteOfferExpiresAfter(writer);
            }
            if (Optional.IsDefined(Mode))
            {
                writer.WritePropertyName("mode"u8);
                writer.WriteObjectValue(Mode);
            }
            if (Optional.IsDefined(ETag))
            {
                writer.WritePropertyName("etag"u8);
                writer.WriteStringValue(ETag.ToString());
            }
            writer.WriteEndObject();
        }

        /// <summary> Convert into a Utf8JsonRequestContent. </summary>
        internal virtual RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this);
            return content;
        }
    }
}
