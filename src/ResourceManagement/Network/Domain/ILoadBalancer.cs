// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;

    /// <summary>
    /// Entry point for load balancer management API in Azure.
    /// </summary>
    public interface ILoadBalancer  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IGroupableResource<Microsoft.Azure.Management.Network.Fluent.INetworkManager,Models.LoadBalancerInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Network.Fluent.ILoadBalancer>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<LoadBalancer.Update.IUpdate>,
        Microsoft.Azure.Management.Network.Fluent.IHasLoadBalancingRules
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
        /// Gets HTTP probes of this load balancer, indexed by the name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.ILoadBalancerHttpProbe> HttpProbes { get; }

        /// <summary>
        /// Gets resource IDs of the public IP addresses assigned to the frontends of this load balancer.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<string> PublicIPAddressIds { get; }

        /// <summary>
        /// Gets frontends for this load balancer, for the incoming traffic to come from.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.ILoadBalancerFrontend> Frontends { get; }

        /// <summary>
        /// Gets public (Internet-facing) frontends.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.ILoadBalancerPublicFrontend> PublicFrontends { get; }

        /// <summary>
        /// Gets TCP probes of this load balancer, indexed by the name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.ILoadBalancerTcpProbe> TcpProbes { get; }

        /// <summary>
        /// Gets private (internal) frontends.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.ILoadBalancerPrivateFrontend> PrivateFrontends { get; }

        /// <summary>
        /// Gets backends for this load balancer to load balance the incoming traffic among, indexed by name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.ILoadBalancerBackend> Backends { get; }

        /// <summary>
        /// Searches for the public frontend that is associated with the provided public IP address, if one exists.
        /// </summary>
        /// <param name="publicIPAddress">A public IP address to search by.</param>
        /// <return>A public frontend associated with the provided public IP address.</return>
        Microsoft.Azure.Management.Network.Fluent.ILoadBalancerPublicFrontend FindFrontendByPublicIPAddress(IPublicIPAddress publicIPAddress);

        /// <summary>
        /// Searches for the public frontend that is associated with the provided public IP address, if one exists.
        /// </summary>
        /// <param name="publicIPAddressId">The resource ID of a public IP address to search by.</param>
        /// <return>A public frontend associated with the provided public IP address.</return>
        Microsoft.Azure.Management.Network.Fluent.ILoadBalancerPublicFrontend FindFrontendByPublicIPAddress(string publicIPAddressId);
    }
}