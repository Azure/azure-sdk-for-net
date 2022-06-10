// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Communication.JobRouter
{
    /// <summary>
    /// Options for updating distribution policy.
    /// </summary>
    public class UpdateDistributionPolicyOptions
    {
        /// <summary> The human readable name of the policy. </summary>
        public string Name { get; set; }
        /// <summary> The expiry time of any offers created under this policy will be governed by the offer time to live. </summary>
        public double? OfferTtlSeconds { get; set; }
        /// <summary> Abstract base class for defining a distribution mode. </summary>
        public DistributionMode Mode { get; set; }
    }
}
