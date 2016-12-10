// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.NicIpConfiguration.Definition
{
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.Network.Fluent.HasPrivateIpAddress.Definition;
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Network.Fluent.HasPublicIpAddress.Definition;

    /// <summary>
    /// The final stage of network interface IP configuration.
    /// At this stage, any remaining optional settings can be specified, or the network interface IP configuration
    /// definition can be attached to the parent network interface definition using WithAttach.attach().
    /// </summary>
    /// <typeparam name="Parent">The return type of the final WithAttach.attach().</typeparam>
    public interface IWithAttach<ParentT>  :
        IInDefinition<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.NicIpConfiguration.Definition.IWithPublicIpAddress<ParentT>,
        IWithLoadBalancer<ParentT>
    {
    }

    /// <summary>
    /// The stage of the network interface IP configuration definition allowing to specify private IP address
    /// within a virtual network subnet.
    /// </summary>
    /// <typeparam name="Parent">The return type of the final Attachable.attach().</typeparam>
    public interface IWithPrivateIp<ParentT>  :
        IWithPrivateIpAddress<Microsoft.Azure.Management.Network.Fluent.NicIpConfiguration.Definition.IWithAttach<ParentT>>
    {
        /// <summary>
        /// Specifies the IP version for the private IP address.
        /// </summary>
        /// <param name="ipVersion">An IP version.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NicIpConfiguration.Definition.IWithAttach<ParentT> WithPrivateIpVersion(string ipVersion);
    }

    /// <summary>
    /// The stage of the network interface IP configuration definition allowing to specify the virtual network.
    /// </summary>
    /// <typeparam name="Parent">The return type of the final Attachable.attach().</typeparam>
    public interface IWithNetwork<ParentT> 
    {
        /// <summary>
        /// Create a new virtual network to associate with the  network interface IP configuration,
        /// based on the provided definition.
        /// </summary>
        /// <param name="creatable">A creatable definition for a new virtual network.</param>
        /// <return>The next stage of the network interface IP configuration definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NicIpConfiguration.Definition.IWithPrivateIp<ParentT> WithNewNetwork(ICreatable<Microsoft.Azure.Management.Network.Fluent.INetwork> creatable);

        /// <summary>
        /// Creates a new virtual network to associate with the network interface IP configuration.
        /// the virtual network will be created in the same resource group and region as of parent
        /// network interface, it will be created with the specified address space and a default subnet
        /// covering the entirety of the network IP address space.
        /// </summary>
        /// <param name="name">The name of the new virtual network.</param>
        /// <param name="addressSpace">The address space for rhe virtual network.</param>
        /// <return>The next stage of the network interface IP configuration definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NicIpConfiguration.Definition.IWithPrivateIp<ParentT> WithNewNetwork(string name, string addressSpace);

        /// <summary>
        /// Creates a new virtual network to associate with the network interface IP configuration.
        /// the virtual network will be created in the same resource group and region as of parent network interface,
        /// it will be created with the specified address space and a default subnet covering the entirety of the
        /// network IP address space.
        /// </summary>
        /// <param name="addressSpace">The address space for the virtual network.</param>
        /// <return>The next stage of the network interface IP configuration definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NicIpConfiguration.Definition.IWithPrivateIp<ParentT> WithNewNetwork(string addressSpace);

        /// <summary>
        /// Associate an existing virtual network with the network interface IP configuration.
        /// </summary>
        /// <param name="network">An existing virtual network.</param>
        /// <return>The next stage of the network interface IP configuration definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NicIpConfiguration.Definition.IWithSubnet<ParentT> WithExistingNetwork(INetwork network);
    }

    /// <summary>
    /// The stage of the network interface IP configuration definition allowing to specify subnet.
    /// </summary>
    /// <typeparam name="Parent">The return type of the final Attachable.attach().</typeparam>
    public interface IWithSubnet<ParentT> 
    {
        /// <summary>
        /// Associate a subnet with the network interface IP configuration.
        /// </summary>
        /// <param name="name">The subnet name.</param>
        /// <return>The next stage of the network interface IP configuration definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NicIpConfiguration.Definition.IWithPrivateIp<ParentT> WithSubnet(string name);
    }

    /// <summary>
    /// The stage of the network interface IP configuration definition allowing to specify the load balancer
    /// to associate this IP configuration with.
    /// </summary>
    /// <typeparam name="Parent">The return type of the final Attachable.attach().</typeparam>
    public interface IWithLoadBalancer<ParentT> 
    {
        /// <summary>
        /// Specifies the load balancer backend to associate this IP configuration with.
        /// </summary>
        /// <param name="loadBalancer">An existing load balancer.</param>
        /// <param name="backendName">The name of an existing backend on that load balancer.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.NicIpConfiguration.Definition.IWithAttach<ParentT> WithExistingLoadBalancerBackend(ILoadBalancer loadBalancer, string backendName);

        /// <summary>
        /// Specifies the load balancer inbound NAT rule to associate this IP configuration with.
        /// </summary>
        /// <param name="loadBalancer">An existing load balancer.</param>
        /// <param name="inboundNatRuleName">The name of an existing inbound NAT rule on the selected load balancer.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.NicIpConfiguration.Definition.IWithAttach<ParentT> WithExistingLoadBalancerInboundNatRule(ILoadBalancer loadBalancer, string inboundNatRuleName);
    }

    /// <summary>
    /// The stage of the network interface IP configuration definition allowing to associate it with
    /// a public IP address.
    /// </summary>
    /// <typeparam name="Parent">The return type of the final Attachable.attach().</typeparam>
    public interface IWithPublicIpAddress<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.HasPublicIpAddress.Definition.IWithPublicIpAddress<Microsoft.Azure.Management.Network.Fluent.NicIpConfiguration.Definition.IWithAttach<ParentT>>
    {
    }

    /// <summary>
    /// The first stage of network interface IP configuration definition.
    /// </summary>
    /// <typeparam name="Parent">The return type of the final Attachable.attach().</typeparam>
    public interface IBlank<ParentT>  :
        IWithNetwork<ParentT>
    {
    }

    /// <summary>
    /// The entirety of the network interface IP configuration definition.
    /// </summary>
    /// <typeparam name="Parent">The return type of the final Attachable.attach().</typeparam>
    public interface IDefinition<ParentT>  :
        IBlank<ParentT>,
        IWithAttach<ParentT>,
        IWithNetwork<ParentT>,
        IWithSubnet<ParentT>,
        IWithPrivateIp<ParentT>
    {
    }
}