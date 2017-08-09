// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Definition
{
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Network.Fluent.NicIPConfiguration.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition;

    /// <summary>
    /// The stage of the network interface definition allowing to specify subnet.
    /// </summary>
    public interface IWithPrimaryNetworkSubnet 
    {
        /// <summary>
        /// Associate a subnet with the network interface's primary IP configuration.
        /// </summary>
        /// <param name="name">The subnet name.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Definition.IWithPrimaryPrivateIP WithSubnet(string name);
    }

    /// <summary>
    /// The stage of the network interface definition allowing to associate public IP address with it's primary
    /// IP configuration.
    /// </summary>
    public interface IWithPrimaryPublicIPAddress 
    {
        /// <summary>
        /// Associates an existing public IP address with the network interface's primary IP configuration.
        /// </summary>
        /// <param name="publicIPAddress">An existing public IP address.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Definition.IWithCreate WithExistingPrimaryPublicIPAddress(IPublicIPAddress publicIPAddress);

        /// <summary>
        /// Create a new public IP address to associate with network interface's primary IP configuration, based on
        /// the provided definition.
        /// </summary>
        /// <param name="creatable">A creatable definition for a new public IP.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Definition.IWithCreate WithNewPrimaryPublicIPAddress(ICreatable<Microsoft.Azure.Management.Network.Fluent.IPublicIPAddress> creatable);

        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource and associate it
        /// with the network interface's primary IP configuration.
        /// the internal name and DNS label for the public IP address will be derived from the network interface name.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Definition.IWithCreate WithNewPrimaryPublicIPAddress();

        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource, with the specified DNS label
        /// and associate it with the network interface's primary IP configuration.
        /// the internal name for the public IP address will be derived from the DNS label.
        /// </summary>
        /// <param name="leafDnsLabel">The leaf domain label.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Definition.IWithCreate WithNewPrimaryPublicIPAddress(string leafDnsLabel);
    }

    /// <summary>
    /// The stage of the network interface definition allowing to specify private IP address within
    /// a virtual network subnet.
    /// </summary>
    public interface IWithPrimaryPrivateIP 
    {
        /// <summary>
        /// Enables dynamic private IP address allocation within the specified existing virtual network
        /// subnet for the network interface's primary IP configuration.
        /// </summary>
        /// <return>The next stage of network interface definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Definition.IWithCreate WithPrimaryPrivateIPAddressDynamic();

        /// <summary>
        /// Assigns the specified static private IP address within the specified existing virtual network
        /// subnet to the network interface's primary IP configuration.
        /// </summary>
        /// <param name="staticPrivateIPAddress">
        /// The static IP address within the specified subnet to assign to
        /// the network interface.
        /// </param>
        /// <return>The next stage of network interface definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Definition.IWithCreate WithPrimaryPrivateIPAddressStatic(string staticPrivateIPAddress);
    }

    /// <summary>
    /// The stage of the network interface definition allowing to associate a network security group.
    /// </summary>
    public interface IWithNetworkSecurityGroup 
    {
        /// <summary>
        /// Create a new network security group to associate with network interface, based on the provided definition.
        /// </summary>
        /// <param name="creatable">A creatable definition for a new network security group.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Definition.IWithCreate WithNewNetworkSecurityGroup(ICreatable<Microsoft.Azure.Management.Network.Fluent.INetworkSecurityGroup> creatable);

        /// <summary>
        /// Associates an existing network security group with the network interface.
        /// </summary>
        /// <param name="networkSecurityGroup">An existing network security group.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Definition.IWithCreate WithExistingNetworkSecurityGroup(INetworkSecurityGroup networkSecurityGroup);
    }

    /// <summary>
    /// The stage of the network interface definition allowing to specify the virtual network for
    /// primary IP configuration.
    /// </summary>
    public interface IWithPrimaryNetwork 
    {
        /// <summary>
        /// Associate an existing virtual network with the network interface's primary IP configuration.
        /// </summary>
        /// <param name="network">An existing virtual network.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Definition.IWithPrimaryNetworkSubnet WithExistingPrimaryNetwork(INetwork network);

        /// <summary>
        /// Create a new virtual network to associate with the network interface's primary IP configuration,
        /// based on the provided definition.
        /// </summary>
        /// <param name="creatable">A creatable definition for a new virtual network.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Definition.IWithPrimaryPrivateIP WithNewPrimaryNetwork(ICreatable<Microsoft.Azure.Management.Network.Fluent.INetwork> creatable);

        /// <summary>
        /// Creates a new virtual network to associate with the network interface's primary IP configuration.
        /// The virtual network will be created in the same resource group and region as of network interface,
        /// it will be created with the specified address space and a default subnet covering the entirety of
        /// the network IP address space.
        /// </summary>
        /// <param name="name">The name of the new virtual network.</param>
        /// <param name="addressSpace">The address space for rhe virtual network.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Definition.IWithPrimaryPrivateIP WithNewPrimaryNetwork(string name, string addressSpace);

        /// <summary>
        /// Creates a new virtual network to associate with the network interface's primary IP configuration.
        /// The virtual network will be created in the same resource group and region as of network interface,
        /// it will be created with the specified address space and a default subnet covering the entirety of
        /// the network IP address space.
        /// </summary>
        /// <param name="addressSpace">The address space for the virtual network.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Definition.IWithPrimaryPrivateIP WithNewPrimaryNetwork(string addressSpace);
    }

    /// <summary>
    /// The stage of the network interface definition allowing to enable accelerated networking.
    /// </summary>
    public interface IWithAcceleratedNetworking  :
        Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Definition.IWithAcceleratedNetworkingBeta
    {
    }

    /// <summary>
    /// The stage of the network interface definition allowing to associate a secondary IP configurations.
    /// </summary>
    public interface IWithSecondaryIPConfiguration 
    {
        /// <summary>
        /// Starts definition of a secondary IP configuration.
        /// </summary>
        /// <param name="name">Name for the IP configuration.</param>
        /// <return>The first stage of a secondary IP configuration definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NicIPConfiguration.Definition.IBlank<Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Definition.IWithCreate> DefineSecondaryIPConfiguration(string name);
    }

    /// <summary>
    /// The entirety of the network interface definition.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Definition.IBlank,
        Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Definition.IWithGroup,
        Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Definition.IWithPrimaryNetwork,
        Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Definition.IWithPrimaryNetworkSubnet,
        Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Definition.IWithPrimaryPrivateIP,
        Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Definition.IWithCreate
    {
    }

    /// <summary>
    /// The stage of the network interface definition allowing to specify the resource group.
    /// </summary>
    public interface IWithGroup  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition.IWithGroup<Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Definition.IWithPrimaryNetwork>
    {
    }

    /// <summary>
    /// The stage of the network interface definition which contains all the minimum required inputs for
    /// the resource to be created, but also allows
    /// for any other optional settings to be specified.
    /// </summary>
    public interface IWithCreate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Network.Fluent.INetworkInterface>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithTags<Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Definition.IWithCreate>,
        Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Definition.IWithPrimaryPublicIPAddress,
        Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Definition.IWithNetworkSecurityGroup,
        Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Definition.IWithSecondaryIPConfiguration,
        Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Definition.IWithAcceleratedNetworking,
        Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Definition.IWithLoadBalancer
    {
        /// <summary>
        /// Specifies the internal DNS name label for the network interface.
        /// </summary>
        /// <param name="dnsNameLabel">The internal DNS name label.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Definition.IWithCreate WithInternalDnsNameLabel(string dnsNameLabel);

        /// <summary>
        /// Enables IP forwarding in the network interface.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Definition.IWithCreate WithIPForwarding();

        /// <summary>
        /// Specifies the IP address of the custom DNS server to associate with the network interface.
        /// Note this method's effect is additive, i.e. each time it is used, the new dns server is
        /// added to the network interface.
        /// </summary>
        /// <param name="ipAddress">The IP address of the DNS server.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Definition.IWithCreate WithDnsServer(string ipAddress);
    }

    /// <summary>
    /// The first stage of the network interface.
    /// </summary>
    public interface IBlank  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithRegion<Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Definition.IWithGroup>
    {
    }

    /// <summary>
    /// The stage of the network interface definition allowing to associate it with a load balancer.
    /// </summary>
    public interface IWithLoadBalancer 
    {
        /// <summary>
        /// Associates the network interface's primary IP configuration with a backend of an existing load balancer.
        /// </summary>
        /// <param name="loadBalancer">An existing load balancer.</param>
        /// <param name="backendName">The name of an existing backend on that load balancer.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Definition.IWithCreate WithExistingLoadBalancerBackend(ILoadBalancer loadBalancer, string backendName);

        /// <summary>
        /// Associates the network interface's primary IP configuration with an inbound NAT rule of an existing load balancer.
        /// </summary>
        /// <param name="loadBalancer">An existing load balancer.</param>
        /// <param name="inboundNatRuleName">The name of an existing inbound NAT rule on the selected load balancer.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Definition.IWithCreate WithExistingLoadBalancerInboundNatRule(ILoadBalancer loadBalancer, string inboundNatRuleName);
    }

    /// <summary>
    /// The stage of the network interface definition allowing to enable accelerated networking.
    /// </summary>
    public interface IWithAcceleratedNetworkingBeta  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Enables accelerated networking.
        /// Note that additional steps need to be taken in the virtual machine itself for the virtual machine associated with this network interface to be able to
        /// take advantage of accelerated networking. This feature might not be available in some regions, virtual machine sizes, or operating system versions.
        /// It can be enabled only during the creation of a network interface, not during an update.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Definition.IWithCreate WithAcceleratedNetworking();
    }
}