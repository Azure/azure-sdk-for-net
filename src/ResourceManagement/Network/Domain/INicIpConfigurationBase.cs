// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// The base IP configuration shared across IP configurations in regular and virtual machine scale set
    /// network interface.
    /// </summary>
    public interface INicIPConfigurationBase  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasSubnet,
        Microsoft.Azure.Management.Network.Fluent.IHasPrivateIPAddress,
        Microsoft.Azure.Management.Network.Fluent.INicIPConfigurationBaseBeta
    {
        /// <summary>
        /// Gets true if this is the primary IP configuration.
        /// </summary>
        bool IsPrimary { get; }

        /// <return>The virtual network associated with this IP configuration.</return>
        Microsoft.Azure.Management.Network.Fluent.INetwork GetNetwork();

        /// <return>The load balancer backends associated with this network interface IP configuration.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Network.Fluent.ILoadBalancerBackend> ListAssociatedLoadBalancerBackends();

        /// <summary>
        /// Gets private IP address version.
        /// </summary>
        Models.IPVersion PrivateIPAddressVersion { get; }

        /// <return>The load balancer inbound NAT rules associated with this network interface IP configuration.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Network.Fluent.ILoadBalancerInboundNatRule> ListAssociatedLoadBalancerInboundNatRules();

        /// <return>
        /// The network security group, if any, associated with the subnet, if any, assigned to this network interface IP configuration
        /// (Note that this results in additional calls to Azure.).
        /// </return>
        Microsoft.Azure.Management.Network.Fluent.INetworkSecurityGroup GetNetworkSecurityGroup();
    }
}