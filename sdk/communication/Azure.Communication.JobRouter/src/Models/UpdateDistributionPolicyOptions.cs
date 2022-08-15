// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    /// <summary>
    /// Options for updating distribution policy.
    /// </summary>
    public class UpdateDistributionPolicyOptions
    {
        /// <summary>
        /// Public constructor.
        /// </summary>
        /// <param name="distributionPolicyId"> Id of the policy. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="distributionPolicyId"/> is null. </exception>
        public UpdateDistributionPolicyOptions(string distributionPolicyId)
        {
            Argument.AssertNotNullOrWhiteSpace(distributionPolicyId, nameof(distributionPolicyId));

            DistributionPolicyId = distributionPolicyId;
        }

        /// <summary>
        /// The Id of this policy.
        /// </summary>
        public string DistributionPolicyId { get; }

        /// <summary> The human readable name of the policy. </summary>
        public string Name { get; set; }

        /// <summary>
        /// The amount of time before an offer expires.
        /// </summary>
        public TimeSpan OfferTtl { get; set; }

        /// <summary> Abstract base class for defining a distribution mode. </summary>
        public DistributionMode Mode { get; set; }
    }
}
