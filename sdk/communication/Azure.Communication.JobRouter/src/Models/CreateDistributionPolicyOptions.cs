// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
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
        /// <param name="offerTtl"> The amount of time before an offer expires. </param>
        /// <param name="mode"> The amount of time before an offer expires. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="distributionPolicyId"/> is null. </exception>
        public CreateDistributionPolicyOptions(string distributionPolicyId, TimeSpan offerTtl, DistributionMode mode)
        {
            Argument.AssertNotNullOrWhiteSpace(distributionPolicyId, nameof(distributionPolicyId));
            Argument.AssertNotNull(offerTtl, nameof(offerTtl));
            Argument.AssertNotNull(mode, nameof(mode));

            DistributionPolicyId = distributionPolicyId;
            OfferTtl = offerTtl;
            Mode = mode;
        }

        /// <summary>
        /// The Id of this policy.
        /// </summary>
        public string DistributionPolicyId { get; }

        /// <summary>
        /// The amount of time before an offer expires.
        /// </summary>
        public TimeSpan OfferTtl { get; }

        /// <summary>
        /// The policy governing the specific distribution method.
        /// </summary>
        public DistributionMode Mode { get; }

        /// <summary> The human readable name of the policy. </summary>
        public string Name { get; set; }
    }
}
