﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
        public string Name { get; internal set; }

        /// <summary>
        /// Abstract base class for defining a distribution mode
        /// Please note <see cref="DistributionMode"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="BestWorkerMode"/>, <see cref="LongestIdleMode"/> and <see cref="RoundRobinMode"/>.
        /// </summary>
        public DistributionMode Mode { get; internal set; }
    }
}
