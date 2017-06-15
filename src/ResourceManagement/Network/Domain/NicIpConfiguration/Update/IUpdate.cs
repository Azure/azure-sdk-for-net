// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.NicIPConfiguration.Update
{
    using Microsoft.Azure.Management.Network.Fluent.HasPublicIPAddress.Update;
    using Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions;
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.Network.Fluent.HasPrivateIPAddress.Update;

    /// <summary>
    /// The stage of the network interface IP configuration update allowing to specify public IP address.
    /// </summary>
    public interface IWithPublicIPAddress  :
        Microsoft.Azure.Management.Network.Fluent.HasPublicIPAddress.Update.IWithPublicIPAddress<Microsoft.Azure.Management.Network.Fluent.NicIPConfiguration.Update.IUpdate>
    {
    }

    /// <summary>
    /// The entirety of a network interface IP configuration update as part of a network interface update.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions.ISettable<Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Update.IUpdate>,
        Microsoft.Azure.Management.Network.Fluent.NicIPConfiguration.Update.IWithSubnet,
        Microsoft.Azure.Management.Network.Fluent.NicIPConfiguration.Update.IWithPrivateIP,
        Microsoft.Azure.Management.Network.Fluent.NicIPConfiguration.Update.IWithPublicIPAddress,
        Microsoft.Azure.Management.Network.Fluent.NicIPConfiguration.Update.IWithLoadBalancer
    {
    }

    /// <summary>
    /// The stage of the network interface's IP configuration allowing to specify the load balancer
    /// to associate this IP configuration with.
    /// </summary>
    public interface IWithLoadBalancer 
    {
        /// <summary>
        /// Specifies the load balancer to associate this IP configuration with.
        /// </summary>
        /// <param name="loadBalancer">An existing load balancer.</param>
        /// <param name="backendName">The name of an existing backend on that load balancer.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.NicIPConfiguration.Update.IUpdate WithExistingLoadBalancerBackend(ILoadBalancer loadBalancer, string backendName);

        /// <summary>
        /// Specifies the load balancer inbound NAT rule to associate this IP configuration with.
        /// </summary>
        /// <param name="loadBalancer">An existing load balancer.</param>
        /// <param name="inboundNatRuleName">The name of an existing inbound NAT rule on the selected load balancer.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.NicIPConfiguration.Update.IUpdate WithExistingLoadBalancerInboundNatRule(ILoadBalancer loadBalancer, string inboundNatRuleName);

        /// <summary>
        /// Removes all the existing associations with load balancer inbound NAT rules.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.NicIPConfiguration.Update.IUpdate WithoutLoadBalancerInboundNatRules();

        /// <summary>
        /// Removes all the existing associations with load balancer backends.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.NicIPConfiguration.Update.IUpdate WithoutLoadBalancerBackends();
    }

    /// <summary>
    /// The stage of the network interface IP configuration update allowing to specify subnet.
    /// </summary>
    public interface IWithSubnet 
    {
        /// <summary>
        /// Associate a subnet with the network interface IP configuration.
        /// </summary>
        /// <param name="name">The subnet name.</param>
        /// <return>The next stage of the network interface IP configuration update.</return>
        Microsoft.Azure.Management.Network.Fluent.NicIPConfiguration.Update.IUpdate WithSubnet(string name);
    }

    /// <summary>
    /// The stage of the network interface IP configuration update allowing to specify private IP.
    /// </summary>
    public interface IWithPrivateIP  :
        Microsoft.Azure.Management.Network.Fluent.HasPrivateIPAddress.Update.IWithPrivateIPAddress<Microsoft.Azure.Management.Network.Fluent.NicIPConfiguration.Update.IUpdate>
    {
        /// <summary>
        /// Specifies the IP version for the private IP address.
        /// </summary>
        /// <param name="ipVersion">An IP version.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.NicIPConfiguration.Update.IUpdate WithPrivateIPVersion(IPVersion ipVersion);
    }
}