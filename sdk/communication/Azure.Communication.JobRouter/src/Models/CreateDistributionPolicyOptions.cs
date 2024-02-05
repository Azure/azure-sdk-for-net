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
        /// Initializes a new instance of CreateDistributionPolicyOptions.
        /// </summary>
        /// <param name="distributionPolicyId"> Id of a distribution policy. </param>
        /// <param name="offerExpiresAfter"> Length of time after which any offers created under this policy will be expired. </param>
        /// <param name="mode"> Mode governing the specific distribution method. </param>
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
        /// Id of a distribution policy.
        /// </summary>
        public string DistributionPolicyId { get; }

        /// <summary>
        /// Length of time after which any offers created under this policy will be expired.
        /// </summary>
        public TimeSpan OfferExpiresAfter { get; }

        /// <summary>
        /// Mode governing the specific distribution method.
        /// </summary>
        public DistributionMode Mode { get; }

        /// <summary> Friendly name of this policy. </summary>
        public string Name { get; set; }

        /// <summary>
        /// The content to send as the request conditions of the request.
        /// </summary>
        public RequestConditions RequestConditions { get; set; } = new();
    }
}
