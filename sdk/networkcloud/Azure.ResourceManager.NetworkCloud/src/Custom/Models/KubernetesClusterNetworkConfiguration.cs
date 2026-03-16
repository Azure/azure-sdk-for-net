// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using System.Net;

namespace Azure.ResourceManager.NetworkCloud.Models
{
    public partial class KubernetesClusterNetworkConfiguration
    {
        /// <summary> The IP address assigned to the Kubernetes DNS service. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IPAddress DnsServiceIP
        {
            get => DnsServiceIp;
            set => DnsServiceIp = value;
        }

        /// <summary> The configuration of the layer 2 service load balancer IP address pools associated with the Kubernetes cluster. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<IPAddressPool> L2ServiceLoadBalancerIPAddressPools => L2ServiceLoadBalancerIpAddressPools;
    }
}
