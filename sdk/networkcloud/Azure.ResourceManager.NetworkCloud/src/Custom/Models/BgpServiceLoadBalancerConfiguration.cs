// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.NetworkCloud.Models
{
    public partial class BgpServiceLoadBalancerConfiguration
    {
        /// <summary> The association of IP address pools to the communities and peers, allowing for announcement of IPs. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<IPAddressPool> IPAddressPools => IpAddressPools;
    }
}
