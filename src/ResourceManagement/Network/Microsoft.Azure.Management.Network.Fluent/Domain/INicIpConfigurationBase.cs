// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using System.Collections.Generic;

    /// <summary>
    /// The base IP configuration shared across IP configurations in regular and virtual machine scale set
    /// network interface.
    /// </summary>
    public interface INicIPConfigurationBase 
    {
        /// <summary>
        /// Gets true if this is the primary ip configuration.
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
    }
}