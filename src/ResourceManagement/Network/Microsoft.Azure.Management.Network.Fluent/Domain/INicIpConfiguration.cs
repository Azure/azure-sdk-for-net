// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// An IP configuration in a network interface.
    /// </summary>
    public interface INicIpConfiguration  :
        IWrapper<Models.NetworkInterfaceIPConfigurationInner>,
        IChildResource<Microsoft.Azure.Management.Network.Fluent.INetworkInterface>,
        IHasPrivateIpAddress,
        IHasPublicIpAddress,
        IHasSubnet
    {
        /// <return>The virtual network associated with this IP configuration.</return>
        Microsoft.Azure.Management.Network.Fluent.INetwork GetNetwork();

        /// <return>The load balancer backends associated with this network interface IP configuration.</return>
        System.Collections.Generic.IList<Microsoft.Azure.Management.Network.Fluent.ILoadBalancerBackend> ListAssociatedLoadBalancerBackends();

        /// <return>The load balancer inbound NAT rules associated with this network interface IP configuration.</return>
        System.Collections.Generic.IList<Microsoft.Azure.Management.Network.Fluent.ILoadBalancerInboundNatRule> ListAssociatedLoadBalancerInboundNatRules();

        /// <summary>
        /// Gets private IP address version.
        /// </summary>
        IPVersion PrivateIpAddressVersion { get; }
    }
}