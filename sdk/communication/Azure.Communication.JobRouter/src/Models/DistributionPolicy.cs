// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.JobRouter
{
    public partial class DistributionPolicy
    {
        /// <summary> Initializes a new instance of DistributionPolicy. </summary>
        /// <param name="offerTtlSeconds"> The expiry time of any offers created under this policy will be governed by the offer time to live. </param>
        /// <param name="mode"> Abstract base class for defining a distribution mode. </param>
        internal DistributionPolicy(double? offerTtlSeconds, DistributionMode mode)
        {
            OfferTtlSeconds = offerTtlSeconds;
            Mode = mode;
        }
    }
}
