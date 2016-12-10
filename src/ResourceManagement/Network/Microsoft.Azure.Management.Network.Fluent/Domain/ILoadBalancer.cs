// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using LoadBalancer.Update;
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using System.Collections.Generic;

    /// <summary>
    /// Entry point for load balancer management API in Azure.
    /// </summary>
    public interface ILoadBalancer  :
        IGroupableResource,
        IRefreshable<Microsoft.Azure.Management.Network.Fluent.ILoadBalancer>,
        IWrapper<Models.LoadBalancerInner>,
        IUpdatable<LoadBalancer.Update.IUpdate>,
        IHasLoadBalancingRules
    {
        /// <summary>
        /// Gets inbound NAT pools, indexed by name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.ILoadBalancerInboundNatPool> InboundNatPools { get; }

        /// <summary>
        /// Gets inbound NAT rules for this balancer.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.ILoadBalancerInboundNatRule> InboundNatRules { get; }

        /// <summary>
        /// Gets resource IDs of the public IP addresses assigned to the frontends of this load balancer.
        /// </summary>
        System.Collections.Generic.IList<string> PublicIpAddressIds { get; }

        /// <summary>
        /// Gets HTTP probes of this load balancer, indexed by the name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.ILoadBalancerHttpProbe> HttpProbes { get; }

        /// <summary>
        /// Gets frontends for this load balancer, for the incoming traffic to come from.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.ILoadBalancerFrontend> Frontends { get; }

        /// <summary>
        /// Gets TCP probes of this load balancer, indexed by the name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.ILoadBalancerTcpProbe> TcpProbes { get; }

        /// <summary>
        /// Gets backends for this load balancer to load balance the incoming traffic among, indexed by name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.ILoadBalancerBackend> Backends { get; }
    }
}