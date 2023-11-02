// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    public partial class DistributionPolicy : IUtf8JsonSerializable
    {
        /// <summary> Initializes a new instance of DistributionPolicy. </summary>
        /// <param name="distributionPolicyId"> Id of the policy. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="distributionPolicyId"/> is null. </exception>
        public DistributionPolicy(string distributionPolicyId)
        {
            Argument.AssertNotNullOrWhiteSpace(distributionPolicyId, nameof(distributionPolicyId));

            Id = distributionPolicyId;
        }

        /// <summary> Initializes a new instance of DistributionPolicy. </summary>
        /// <param name="offerExpiresAfter"> The expiry time of any offers created under this policy will be governed by the offer time to live. </param>
        /// <param name="mode"> Abstract base class for defining a distribution mode. </param>
        internal DistributionPolicy(TimeSpan? offerExpiresAfter, DistributionMode mode)
        {
            OfferExpiresAfter = offerExpiresAfter;
            Mode = mode;
        }

        /// <summary> The expiry time of any offers created under this policy will be governed by the offer time to live. </summary>
        public TimeSpan? OfferExpiresAfter { get; set; }

        [CodeGenMember("OfferExpiresAfterSeconds")]
        internal double? _offerExpiresAfterSeconds
        {
            get
            {
                return OfferExpiresAfter?.TotalSeconds is null or 0 ? null : OfferExpiresAfter?.TotalSeconds;
            }
            set
            {
                OfferExpiresAfter = value != null ? TimeSpan.FromSeconds(value.Value) : null;
            }
        }

        /// <summary> (Optional) The name of the distribution policy. </summary>
        public string Name { get; set; }

        /// <summary>
        /// Abstract base class for defining a distribution mode
        /// Please note <see cref="DistributionMode"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="BestWorkerMode"/>, <see cref="LongestIdleMode"/> and <see cref="RoundRobinMode"/>.
        /// </summary>
        public DistributionMode Mode { get; set; }

        [CodeGenMember("Etag")]
        internal string _etag
        {
            get
            {
                return ETag.ToString();
            }
            set
            {
                ETag = new ETag(value);
            }
        }

        /// <summary> Concurrency Token. </summary>
        public ETag ETag { get; internal set; }

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Name))
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            if (Optional.IsDefined(_offerExpiresAfterSeconds))
            {
                writer.WritePropertyName("offerExpiresAfterSeconds"u8);
                writer.WriteNumberValue(_offerExpiresAfterSeconds.Value);
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
