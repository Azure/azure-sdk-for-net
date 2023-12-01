// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    /// <summary>
    /// Options for creating distribution policy.
    /// </summary>
    public class CreateDistributionPolicyOptions
    {
        /// <summary>
        /// Public constructor.
        /// </summary>
        /// <param name="distributionPolicyId"> Id of the policy. </param>
        /// <param name="offerExpiresAfter"> The amount of time before an offer expires. </param>
        /// <param name="mode"> The amount of time before an offer expires. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="distributionPolicyId"/> is null. </exception>
        public CreateDistributionPolicyOptions(string distributionPolicyId, TimeSpan offerExpiresAfter, DistributionMode mode)
        {
            Argument.AssertNotNullOrWhiteSpace(distributionPolicyId, nameof(distributionPolicyId));
            Argument.AssertNotNull(offerExpiresAfter, nameof(offerExpiresAfter));
            Argument.AssertNotNull(mode, nameof(mode));

            DistributionPolicyId = distributionPolicyId;
            OfferExpiresAfter = offerExpiresAfter;
            Mode = mode;
        }

        /// <summary>
        /// The Id of this policy.
        /// </summary>
        public string DistributionPolicyId { get; }

        /// <summary>
        /// The amount of time before an offer expires.
        /// </summary>
        public TimeSpan OfferExpiresAfter { get; }

        /// <summary>
        /// The policy governing the specific distribution method.
        /// </summary>
        public DistributionMode Mode { get; }

        /// <summary> The human readable name of the policy. </summary>
        public string Name { get; set; }

        /// <summary>
        /// The content to send as the request conditions of the request.
        /// </summary>
        public RequestConditions RequestConditions { get; set; } = new();
    }
}
