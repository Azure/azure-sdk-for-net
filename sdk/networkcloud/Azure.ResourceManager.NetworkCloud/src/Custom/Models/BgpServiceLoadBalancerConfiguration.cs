// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.ResourceManager.NetworkCloud.Models
{
    // Backward compat: The old Swagger/AutoRest API exposed IPAddressPools as a top-level
    // property. The new TypeSpec-generated code nests or renames this property. This file
    // preserves the old property to avoid breaking existing consumers.
    public partial class BgpServiceLoadBalancerConfiguration
    {
        /// <summary> The list of pools of IP addresses that can be allocated to load balancer services. </summary>
        public IList<IPAddressPool> IPAddressPools { get; }
    }
}
