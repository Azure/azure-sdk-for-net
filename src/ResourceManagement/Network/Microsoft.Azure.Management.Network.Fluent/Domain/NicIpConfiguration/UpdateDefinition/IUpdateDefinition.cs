// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.NicIPConfiguration.UpdateDefinition
{
    using Microsoft.Azure.Management.Network.Fluent.HasPublicIPAddress.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Network.Fluent.HasPrivateIPAddress.UpdateDefinition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Update;

    /// <summary>
    /// The stage of the network interface IP configuration definition allowing to associate it with
    /// a public IP address.
    /// </summary>
    /// <typeparam name="Parent">The return type of the final Attachable.attach().</typeparam>
    public interface IWithPublicIPAddress<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.HasPublicIPAddress.UpdateDefinition.IWithPublicIPAddress<Microsoft.Azure.Management.Network.Fluent.NicIPConfiguration.UpdateDefinition.IWithAttach<ParentT>>
    {
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
        Microsoft.Azure.Management.Network.Fluent.NicIPConfiguration.UpdateDefinition.IWithPrivateIP<ParentT> WithSubnet(string name);
    }

    /// <summary>
    /// The stage of the network interface IP configuration definition allowing to specify the load balancer
    /// to associate this IP configuration with.
    /// </summary>
    /// <typeparam name="Parent">The return type of the final Attachable.attach().</typeparam>
    public interface IWithLoadBalancer<ParentT> 
    {
        /// <summary>
        /// Specifies the load balancer to associate this IP configuration with.
        /// </summary>
        /// <param name="loadBalancer">An existing load balancer.</param>
        /// <param name="backendName">The name of an existing backend on that load balancer.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.NicIPConfiguration.UpdateDefinition.IWithAttach<ParentT> WithExistingLoadBalancerBackend(ILoadBalancer loadBalancer, string backendName);

        /// <summary>
        /// Specifies the load balancer inbound NAT rule to associate this IP configuration with.
        /// </summary>
        /// <param name="loadBalancer">An existing load balancer.</param>
        /// <param name="inboundNatRuleName">The name of an existing inbound NAT rule on the selected load balancer.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.NicIPConfiguration.UpdateDefinition.IWithAttach<ParentT> WithExistingLoadBalancerInboundNatRule(ILoadBalancer loadBalancer, string inboundNatRuleName);
    }

    /// <summary>
    /// The entirety of a network interface IP configuration definition as part of a network interface update.
    /// </summary>
    /// <typeparam name="Parent">The return type of the final UpdateDefinitionStages.WithAttach.attach().</typeparam>
    public interface IUpdateDefinition<ParentT>  :
        IBlank<ParentT>,
        IWithAttach<ParentT>,
        IWithNetwork<ParentT>,
        IWithPrivateIP<ParentT>,
        IWithSubnet<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.NicIPConfiguration.UpdateDefinition.IWithPublicIPAddress<ParentT>
    {
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
        Microsoft.Azure.Management.Network.Fluent.NicIPConfiguration.UpdateDefinition.IWithPrivateIP<ParentT> WithNewNetwork(ICreatable<Microsoft.Azure.Management.Network.Fluent.INetwork> creatable);

        /// <summary>
        /// Creates a new virtual network to associate with the network interface IP configuration.
        /// the virtual network will be created in the same resource group and region as of parent
        /// network interface, it will be created with the specified address space and a default subnet
        /// covering the entirety of the network IP address space.
        /// </summary>
        /// <param name="name">The name of the new virtual network.</param>
        /// <param name="addressSpace">The address space for rhe virtual network.</param>
        /// <return>The next stage of the network interface IP configuration definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NicIPConfiguration.UpdateDefinition.IWithPrivateIP<ParentT> WithNewNetwork(string name, string addressSpace);

        /// <summary>
        /// Creates a new virtual network to associate with the network interface IP configuration.
        /// the virtual network will be created in the same resource group and region as of parent network interface,
        /// it will be created with the specified address space and a default subnet covering the entirety of the
        /// network IP address space.
        /// </summary>
        /// <param name="addressSpace">The address space for the virtual network.</param>
        /// <return>The next stage of the network interface IP configuration definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NicIPConfiguration.UpdateDefinition.IWithPrivateIP<ParentT> WithNewNetwork(string addressSpace);

        /// <summary>
        /// Associate an existing virtual network with the network interface IP configuration.
        /// </summary>
        /// <param name="network">An existing virtual network.</param>
        /// <return>The next stage of the network interface IP configuration definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NicIPConfiguration.UpdateDefinition.IWithSubnet<ParentT> WithExistingNetwork(INetwork network);
    }

    /// <summary>
    /// The stage of the network interface IP configuration definition allowing to specify private IP address
    /// within a virtual network subnet.
    /// </summary>
    /// <typeparam name="Parent">The return type of the final Attachable.attach().</typeparam>
    public interface IWithPrivateIP<ParentT>  :
        IWithPrivateIPAddress<Microsoft.Azure.Management.Network.Fluent.NicIPConfiguration.UpdateDefinition.IWithAttach<ParentT>>
    {
        /// <summary>
        /// Specifies the IP version for the private IP address.
        /// </summary>
        /// <param name="ipVersion">An IP version.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NicIPConfiguration.UpdateDefinition.IWithAttach<ParentT> WithPrivateIPVersion(string ipVersion);
    }

    /// <summary>
    /// The final stage of network interface IP configuration.
    /// At this stage, any remaining optional settings can be specified, or the network interface IP configuration
    /// definition can be attached to the parent network interface definition using WithAttach.attach().
    /// </summary>
    /// <typeparam name="Parent">The return type of the final WithAttach.attach().</typeparam>
    public interface IWithAttach<ParentT>  :
        IInUpdate<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.NicIPConfiguration.UpdateDefinition.IWithPublicIPAddress<ParentT>
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
}