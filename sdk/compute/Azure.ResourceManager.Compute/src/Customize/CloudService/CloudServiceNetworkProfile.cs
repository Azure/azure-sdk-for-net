// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Compute.Models
{
    /// <summary> This type is obsolete. Cloud Services (classic) are no longer supported for new customers. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("CloudService operations are no longer supported.")]
    public partial class CloudServiceNetworkProfile
    {
        /// <summary> Initializes a new instance of CloudServiceNetworkProfile. </summary>
        public CloudServiceNetworkProfile()
        {
        }

        /// <summary> The load balancer configurations. </summary>
        public IList<CloudServiceLoadBalancerConfiguration> LoadBalancerConfigurations { get; set; }

        /// <summary> The swappable cloud service ID. </summary>
        public ResourceIdentifier SwappableCloudServiceId { get; set; }

        /// <summary> The slot type. </summary>
        public CloudServiceSlotType? SlotType { get; set; }
    }
}
