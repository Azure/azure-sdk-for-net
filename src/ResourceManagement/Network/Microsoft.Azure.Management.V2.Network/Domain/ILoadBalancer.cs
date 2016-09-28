// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.V2.Network
{

    using System.Collections.Generic;
    using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
    using Microsoft.Azure.Management.V2.Resource.Core;
    using Microsoft.Azure.Management.V2.Network.LoadBalancer.Update;
    using Microsoft.Azure.Management.Network.Models;
    /// <summary>
    /// Entry point for load balancer management API in Azure.
    /// </summary>
    public interface ILoadBalancer  :
        IGroupableResource,
        IRefreshable<Microsoft.Azure.Management.V2.Network.ILoadBalancer>,
        IWrapper<Microsoft.Azure.Management.Network.Models.LoadBalancerInner>,
        IUpdatable<Microsoft.Azure.Management.V2.Network.LoadBalancer.Update.IUpdate>,
        IHasLoadBalancingRules
    {
        /// <returns>resource IDs of the public IP addresses assigned to the frontends of this load balancer</returns>
        List<string> PublicIpAddressIds { get; }

        /// <returns>TCP probes of this load balancer, indexed by the name</returns>
        IDictionary<string,Microsoft.Azure.Management.V2.Network.ITcpProbe> TcpProbes ();

        /// <returns>HTTP probes of this load balancer, indexed by the name</returns>
        IDictionary<string,Microsoft.Azure.Management.V2.Network.IHttpProbe> HttpProbes ();

        /// <returns>backends for this load balancer to load balance the incoming traffic among, indexed by name</returns>
        IDictionary<string,Microsoft.Azure.Management.V2.Network.IBackend> Backends ();

        /// <returns>inbound NAT rules for this balancer</returns>
        IDictionary<string,Microsoft.Azure.Management.V2.Network.IInboundNatRule> InboundNatRules ();

        /// <returns>frontends for this load balancer, for the incoming traffic to come from.</returns>
        IDictionary<string,Microsoft.Azure.Management.V2.Network.IFrontend> Frontends ();

        /// <returns>inbound NAT pools, indexed by name</returns>
        IDictionary<string,Microsoft.Azure.Management.V2.Network.IInboundNatPool> InboundNatPools ();

    }
}