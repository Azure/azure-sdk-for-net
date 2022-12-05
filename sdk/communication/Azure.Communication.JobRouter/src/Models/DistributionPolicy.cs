// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Communication.JobRouter.Models
{
    [CodeGenModel("DistributionPolicy")]
    [CodeGenSuppress("DistributionPolicy")]
    public partial class DistributionPolicy
    {
        /// <summary> Initializes a new instance of DistributionPolicy. </summary>
        internal DistributionPolicy()
        {
        }
        /// <summary> Initializes a new instance of DistributionPolicy. </summary>
        /// <param name="offerTtl"> The expiry time of any offers created under this policy will be governed by the offer time to live. </param>
        /// <param name="mode"> Abstract base class for defining a distribution mode. </param>
        internal DistributionPolicy(TimeSpan? offerTtl, DistributionMode mode)
        {
            OfferTtl = offerTtl;
            Mode = mode;
        }

        /// <summary> The expiry time of any offers created under this policy will be governed by the offer time to live. </summary>
        public TimeSpan? OfferTtl { get; set; }

        [CodeGenMember("OfferTtlSeconds")]
        internal double? _offerTtlSeconds {
            get
            {
                return OfferTtl?.TotalSeconds is null or 0 ? null : OfferTtl?.TotalSeconds;
            }
            set
            {
                OfferTtl = value != null ? TimeSpan.FromSeconds(value.Value) : null;
            }
        }
    }
}
