// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.V2.Network
{

    using Microsoft.Azure.Management.V2.Resource.Core;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Network.Models;
    /// <summary>
    /// An IP configuration in a network interface.
    /// </summary>
    public interface INicIpConfiguration  :
        IWrapper<Microsoft.Azure.Management.Network.Models.NetworkInterfaceIPConfigurationInner>,
        IChildResource<Microsoft.Azure.Management.V2.Network.INetworkInterface>,
        IHasPrivateIpAddress,
        IHasPublicIpAddress,
        IHasSubnet
    {
        /// <returns>the virtual network associated with this IP configuration</returns>
        INetwork GetNetwork ();

        /// <returns>private IP address version</returns>
        string PrivateIpAddressVersion { get; }

        /// <returns>the load balancer backends associated with this network interface IP configuration</returns>
        List<Microsoft.Azure.Management.V2.Network.IBackend> ListAssociatedLoadBalancerBackends ();

        /// <returns>the load balancer inbound NAT rules associated with this network interface IP configuration</returns>
        List<Microsoft.Azure.Management.V2.Network.IInboundNatRule> ListAssociatedLoadBalancerInboundNatRules ();

    }
}