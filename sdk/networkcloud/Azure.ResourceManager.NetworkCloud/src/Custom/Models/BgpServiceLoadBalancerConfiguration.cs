// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.ResourceManager.NetworkCloud.Models
{
    public partial class BgpServiceLoadBalancerConfiguration
    {
        /// <summary> The list of pools of IP addresses that can be allocated to load balancer services. </summary>
        public IList<IPAddressPool> IPAddressPools { get; }
    }
}
