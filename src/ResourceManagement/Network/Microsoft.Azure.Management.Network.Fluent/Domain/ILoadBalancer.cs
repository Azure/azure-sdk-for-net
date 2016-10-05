// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Fluent.Network
{

    using System.Collections.Generic;
    using Microsoft.Azure.Management.Fluent.Resource.Core.ResourceActions;
    using Microsoft.Azure.Management.Fluent.Resource.Core;
    using Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update;
    /// <summary>
    /// Entry point for load balancer management API in Azure.
    /// </summary>
    public interface ILoadBalancer  :
        IGroupableResource,
        IRefreshable<Microsoft.Azure.Management.Fluent.Network.ILoadBalancer>,
        IWrapper<Microsoft.Azure.Management.Network.Models.LoadBalancerInner>,
        IUpdatable<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>,
        IHasLoadBalancingRules
    {
        /// <returns>resource IDs of the public IP addresses assigned to the frontends of this load balancer</returns>
        System.Collections.Generic.IList<string> PublicIpAddressIds { get; }

        /// <returns>TCP probes of this load balancer, indexed by the name</returns>
        System.Collections.Generic.IDictionary<string,Microsoft.Azure.Management.Fluent.Network.ITcpProbe> TcpProbes { get; }

        /// <returns>HTTP probes of this load balancer, indexed by the name</returns>
        System.Collections.Generic.IDictionary<string,Microsoft.Azure.Management.Fluent.Network.IHttpProbe> HttpProbes { get; }

        /// <returns>backends for this load balancer to load balance the incoming traffic among, indexed by name</returns>
        System.Collections.Generic.IDictionary<string,Microsoft.Azure.Management.Fluent.Network.IBackend> Backends { get; }

        /// <returns>inbound NAT rules for this balancer</returns>
        System.Collections.Generic.IDictionary<string,Microsoft.Azure.Management.Fluent.Network.IInboundNatRule> InboundNatRules { get; }

        /// <returns>frontends for this load balancer, for the incoming traffic to come from.</returns>
        System.Collections.Generic.IDictionary<string,Microsoft.Azure.Management.Fluent.Network.IFrontend> Frontends { get; }

        /// <returns>inbound NAT pools, indexed by name</returns>
        System.Collections.Generic.IDictionary<string,Microsoft.Azure.Management.Fluent.Network.IInboundNatPool> InboundNatPools { get; }

    }
}