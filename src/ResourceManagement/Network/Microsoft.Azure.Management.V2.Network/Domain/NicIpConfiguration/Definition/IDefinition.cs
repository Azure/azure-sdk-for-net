// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Definition
{

    using Microsoft.Azure.Management.V2.Network;
    using Microsoft.Azure.Management.V2.Network.HasPrivateIpAddress.Definition;
    using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
    using Microsoft.Azure.Management.V2.Resource.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.V2.Network.HasPublicIpAddress.Definition;
    /// <summary>
    /// The stage of the network interface IP configuration definition allowing to specify subnet.
    /// 
    /// @param <ParentT> the return type of the final {@link Attachable#attach()}
    /// </summary>
    public interface IWithSubnet<ParentT> 
    {
        /// <summary>
        /// Associate a subnet with the network interface IP configuration.
        /// </summary>
        /// <param name="name">name the subnet name</param>
        /// <returns>the next stage of the network interface IP configuration definition</returns>
        IWithPrivateIp<ParentT> WithSubnet (string name);

    }
    /// <summary>
    /// The stage of the network interface IP configuration definition allowing to specify the load balancer
    /// to associate this IP configuration with.
    /// 
    /// @param <ParentT> the return type of the final {@link Attachable#attach()}
    /// </summary>
    public interface IWithLoadBalancer<ParentT> 
    {
        /// <summary>
        /// Specifies the load balancer backend to associate this IP configuration with.
        /// </summary>
        /// <param name="loadBalancer">loadBalancer an existing load balancer</param>
        /// <param name="backendName">backendName the name of an existing backend on that load balancer</param>
        /// <returns>the next stage of the update</returns>
        IWithAttach<ParentT> WithExistingLoadBalancerBackend (ILoadBalancer loadBalancer, string backendName);

        /// <summary>
        /// Specifies the load balancer inbound NAT rule to associate this IP configuration with.
        /// </summary>
        /// <param name="loadBalancer">loadBalancer an existing load balancer</param>
        /// <param name="inboundNatRuleName">inboundNatRuleName the name of an existing inbound NAT rule on the selected load balancer</param>
        /// <returns>the next stage of the update</returns>
        IWithAttach<ParentT> WithExistingLoadBalancerInboundNatRule (ILoadBalancer loadBalancer, string inboundNatRuleName);

    }
    /// <summary>
    /// The stage of the network interface IP configuration definition allowing to specify private IP address
    /// within a virtual network subnet.
    /// 
    /// @param <ParentT> the return type of the final {@link Attachable#attach()}
    /// </summary>
    public interface IWithPrivateIp<ParentT>  :
        IWithPrivateIpAddress<Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Definition.IWithAttach<ParentT>>
    {
        /// <summary>
        /// Specifies the IP version for the private IP address.
        /// </summary>
        /// <param name="ipVersion">ipVersion an IP version</param>
        /// <returns>the next stage of the definition</returns>
        IWithAttach<ParentT> WithPrivateIpVersion (string ipVersion);

    }
    /// <summary>
    /// The first stage of network interface IP configuration definition.
    /// 
    /// @param <ParentT> the return type of the final {@link Attachable#attach()}
    /// </summary>
    public interface IBlank<ParentT>  :
        IWithNetwork<ParentT>
    {
    }
    /// <summary>
    /// The stage of the network interface IP configuration definition allowing to specify the virtual network.
    /// 
    /// @param <ParentT> the return type of the final {@link Attachable#attach()}
    /// </summary>
    public interface IWithNetwork<ParentT> 
    {
        /// <summary>
        /// Create a new virtual network to associate with the  network interface IP configuration,
        /// based on the provided definition.
        /// </summary>
        /// <param name="creatable">creatable a creatable definition for a new virtual network</param>
        /// <returns>the next stage of the network interface IP configuration definition</returns>
        IWithPrivateIp<ParentT> WithNewNetwork (ICreatable<Microsoft.Azure.Management.V2.Network.INetwork> creatable);

        /// <summary>
        /// Creates a new virtual network to associate with the network interface IP configuration.
        /// <p>
        /// the virtual network will be created in the same resource group and region as of parent
        /// network interface, it will be created with the specified address space and a default subnet
        /// covering the entirety of the network IP address space.
        /// </summary>
        /// <param name="name">name the name of the new virtual network</param>
        /// <param name="addressSpace">addressSpace the address space for rhe virtual network</param>
        /// <returns>the next stage of the network interface IP configuration definition</returns>
        IWithPrivateIp<ParentT> WithNewNetwork (string name, string addressSpace);

        /// <summary>
        /// Creates a new virtual network to associate with the network interface IP configuration.
        /// <p>
        /// the virtual network will be created in the same resource group and region as of parent network interface,
        /// it will be created with the specified address space and a default subnet covering the entirety of the
        /// network IP address space.
        /// </summary>
        /// <param name="addressSpace">addressSpace the address space for the virtual network</param>
        /// <returns>the next stage of the network interface IP configuration definition</returns>
        IWithPrivateIp<ParentT> WithNewNetwork (string addressSpace);

        /// <summary>
        /// Associate an existing virtual network with the network interface IP configuration.
        /// </summary>
        /// <param name="network">network an existing virtual network</param>
        /// <returns>the next stage of the network interface IP configuration definition</returns>
        IWithSubnet<ParentT> WithExistingNetwork (INetwork network);

    }
    /// <summary>
    /// The final stage of network interface IP configuration.
    /// <p>
    /// At this stage, any remaining optional settings can be specified, or the network interface IP configuration
    /// definition can be attached to the parent network interface definition using {@link WithAttach#attach()}.
    /// 
    /// @param <ParentT> the return type of the final {@link Attachable#attach()}
    /// </summary>
    public interface IWithAttach<ParentT>  :
        IInDefinition<ParentT>,
        Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Definition.IWithPublicIpAddress<ParentT>,
        IWithLoadBalancer<ParentT>
    {
    }
    /// <summary>
    /// The entirety of the network interface IP configuration definition.
    /// @param <ParentT> the return type of the final {@link Attachable#attach()}
    /// </summary>
    public interface IDefinition<ParentT>  :
        IBlank<ParentT>,
        IWithAttach<ParentT>,
        IWithNetwork<ParentT>,
        IWithSubnet<ParentT>,
        IWithPrivateIp<ParentT>
    {
    }
    /// <summary>
    /// The stage of the network interface IP configuration definition allowing to associate it with
    /// a public IP address.
    /// 
    /// @param <ParentT> the return type of the final {@link Attachable#attach()}
    /// </summary>
    public interface IWithPublicIpAddress<ParentT>  :
        Microsoft.Azure.Management.V2.Network.HasPublicIpAddress.Definition.IWithPublicIpAddress<Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Definition.IWithAttach<ParentT>>
    {
    }
}