// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using PublicIpAddress.Update;
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;

    /// <summary>
    /// Public IP address.
    /// </summary>
    public interface IPublicIpAddress  :
        IGroupableResource,
        IRefreshable<Microsoft.Azure.Management.Network.Fluent.IPublicIpAddress>,
        IWrapper<Models.PublicIPAddressInner>,
        IUpdatable<PublicIpAddress.Update.IUpdate>
    {
        /// <summary>
        /// Gets the assigned reverse FQDN, if any.
        /// </summary>
        string ReverseFqdn { get; }

        /// <summary>
        /// Gets the assigned FQDN (fully qualified domain name).
        /// </summary>
        string Fqdn { get; }

        /// <summary>
        /// Gets true if this public IP address is assigned to a network interface.
        /// </summary>
        bool HasAssignedNetworkInterface { get; }

        /// <summary>
        /// Gets the assigned IP address.
        /// </summary>
        string IpAddress { get; }

        /// <summary>
        /// Gets the IP address allocation method (Static/Dynamic).
        /// </summary>
        string IpAllocationMethod { get; }

        /// <summary>
        /// Gets the idle connection timeout setting (in minutes).
        /// </summary>
        int IdleTimeoutInMinutes { get; }

        /// <summary>
        /// Gets the assigned leaf domain label.
        /// </summary>
        string LeafDomainLabel { get; }

        /// <return>The network interface IP configuration that this public IP address is assigned to.</return>
        Microsoft.Azure.Management.Network.Fluent.INicIpConfiguration GetAssignedNetworkInterfaceIpConfiguration();

        /// <return>The load balancer public frontend that this public IP address is assigned to.</return>
        Microsoft.Azure.Management.Network.Fluent.ILoadBalancerPublicFrontend GetAssignedLoadBalancerFrontend();

        /// <summary>
        /// Gets the IP version of the public IP address.
        /// </summary>
        string Version { get; }

        /// <summary>
        /// Gets true if this public IP address is assigned to a load balancer.
        /// </summary>
        bool HasAssignedLoadBalancer { get; }
    }
}