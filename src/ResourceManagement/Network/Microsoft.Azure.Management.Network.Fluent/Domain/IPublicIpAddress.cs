// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{

    using Microsoft.Azure.Management.Network.Fluent.PublicIpAddress.Update;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    /// <summary>
    /// Public IP address.
    /// </summary>
    public interface IPublicIpAddress  :
        IGroupableResource,
        IRefreshable<Microsoft.Azure.Management.Network.Fluent.IPublicIpAddress>,
        IWrapper<Microsoft.Azure.Management.Network.Fluent.Models.PublicIPAddressInner>,
        IUpdatable<Microsoft.Azure.Management.Network.Fluent.PublicIpAddress.Update.IUpdate>
    {
        /// <returns>the IP version of the public IP address</returns>
        string Version { get; }

        /// <returns>the assigned IP address</returns>
        string IpAddress { get; }

        /// <returns>the assigned leaf domain label</returns>
        string LeafDomainLabel { get; }

        /// <returns>the assigned FQDN (fully qualified domain name)</returns>
        string Fqdn { get; }

        /// <returns>the assigned reverse FQDN, if any</returns>
        string ReverseFqdn { get; }

        /// <returns>the IP address allocation method (Static/Dynamic)</returns>
        string IpAllocationMethod { get; }

        /// <returns>the idle connection timeout setting (in minutes)</returns>
        int IdleTimeoutInMinutes { get; }

        /// <returns>the load balancer public frontend that this public IP address is assigned to</returns>
        Microsoft.Azure.Management.Network.Fluent.IPublicFrontend GetAssignedLoadBalancerFrontend();

        /// <returns>true if this public IP address is assigned to a load balancer</returns>
        bool HasAssignedLoadBalancer { get; }

        /// <returns>the network interface IP configuration that this public IP address is assigned to</returns>
        Microsoft.Azure.Management.Network.Fluent.INicIpConfiguration GetAssignedNetworkInterfaceIpConfiguration();

        /// <returns>true if this public IP address is assigned to a network interface</returns>
        bool HasAssignedNetworkInterface { get; }

    }
}