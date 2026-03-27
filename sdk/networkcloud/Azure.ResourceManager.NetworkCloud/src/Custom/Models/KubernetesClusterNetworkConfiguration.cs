// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using System.Net;

namespace Azure.ResourceManager.NetworkCloud.Models
{
    // Backward compat: The old Swagger/AutoRest API exposed DnsServiceIP as System.Net.IPAddress
    // and L2ServiceLoadBalancerIPAddressPools with uppercase 'IP'. The new TypeSpec-generated
    // code uses string for DNS IP and different casing. These properties preserve the old API
    // surface to avoid breaking existing consumers.
    public partial class KubernetesClusterNetworkConfiguration
    {
        /// <summary> The IP address assigned to the Kubernetes DNS service. </summary>
        public IPAddress DnsServiceIP { get; set; }

        /// <summary> The configuration of the layer 2 service load balancer IP address pools associated with the Kubernetes cluster. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<IPAddressPool> L2ServiceLoadBalancerIPAddressPools => L2ServiceLoadBalancerIpAddressPools;
    }
}
