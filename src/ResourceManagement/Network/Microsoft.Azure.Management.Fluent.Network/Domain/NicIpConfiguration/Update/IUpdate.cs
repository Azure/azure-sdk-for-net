// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Update
{

    using Microsoft.Azure.Management.Fluent.Network.HasPublicIpAddress.Update;
    using Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Update;
    using Microsoft.Azure.Management.Fluent.Resource.Core.ChildResourceActions;
    using Microsoft.Azure.Management.Fluent.Network;
    using Microsoft.Azure.Management.Fluent.Network.HasPrivateIpAddress.Update;
    /// <summary>
    /// The stage of the network interface IP configuration update allowing to specify subnet.
    /// </summary>
    public interface IWithSubnet 
    {
        /// <summary>
        /// Associate a subnet with the network interface IP configuration.
        /// </summary>
        /// <param name="name">name the subnet name</param>
        /// <returns>the next stage of the network interface IP configuration update</returns>
        Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Update.IUpdate WithSubnet (string name);

    }
    /// <summary>
    /// The stage of the network interface IP configuration update allowing to specify public IP address.
    /// </summary>
    public interface IWithPublicIpAddress  :
        Microsoft.Azure.Management.Fluent.Network.HasPublicIpAddress.Update.IWithPublicIpAddress<Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Update.IUpdate>
    {
    }
    /// <summary>
    /// The entirety of a network interface IP configuration update as part of a network interface update.
    /// </summary>
    public interface IUpdate  :
        ISettable<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Update.IUpdate>,
        IWithSubnet,
        IWithPrivateIp,
        Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Update.IWithPublicIpAddress,
        IWithLoadBalancer
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
        /// <param name="loadBalancer">loadBalancer an existing load balancer</param>
        /// <param name="backendName">backendName the name of an existing backend on that load balancer</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Update.IUpdate WithExistingLoadBalancerBackend (ILoadBalancer loadBalancer, string backendName);

        /// <summary>
        /// Specifies the load balancer inbound NAT rule to associate this IP configuration with.
        /// </summary>
        /// <param name="loadBalancer">loadBalancer an existing load balancer</param>
        /// <param name="inboundNatRuleName">inboundNatRuleName the name of an existing inbound NAT rule on the selected load balancer</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Update.IUpdate WithExistingLoadBalancerInboundNatRule (ILoadBalancer loadBalancer, string inboundNatRuleName);

        /// <summary>
        /// Removes all the existing associations with load balancer backends.
        /// </summary>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Update.IUpdate WithoutLoadBalancerBackends ();

        /// <summary>
        /// Removes all the existing associations with load balancer inbound NAT rules.
        /// </summary>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Update.IUpdate WithoutLoadBalancerInboundNatRules ();

    }
    /// <summary>
    /// The stage of the network interface IP configuration update allowing to specify private IP.
    /// </summary>
    public interface IWithPrivateIp  :
        IWithPrivateIpAddress<Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Update.IUpdate>
    {
        /// <summary>
        /// Specifies the IP version for the private IP address.
        /// </summary>
        /// <param name="ipVersion">ipVersion an IP version</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Update.IUpdate WithPrivateIpVersion (string ipVersion);

    }
}