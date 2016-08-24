/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition
{

    using Microsoft.Azure.Management.V2.Resource.Core.GroupableResource.Definition;
    using Microsoft.Azure.Management.V2.Network;
    using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
    using Microsoft.Azure.Management.V2.Resource.Core.Resource.Definition;
    using Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Definition;
    /// <summary>
    /// The stage of the network interface definition allowing to specify the resource group.
    /// </summary>
    public interface IWithGroup  :
        Microsoft.Azure.Management.V2.Resource.Core.GroupableResource.Definition.IWithGroup<Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithPrimaryNetwork>
    {
    }
    /// <summary>
    /// The stage of the network interface definition allowing to associate a network security group.
    /// </summary>
    public interface IWithNetworkSecurityGroup 
    {
        /// <summary>
        /// Create a new network security group to associate with network interface, based on the provided definition.
        /// </summary>
        /// <param name="creatable">creatable a creatable definition for a new network security group</param>
        /// <returns>the next stage of the network interface definition</returns>
        IWithCreate WithNewNetworkSecurityGroup (ICreatable<Microsoft.Azure.Management.V2.Network.INetworkSecurityGroup> creatable);

        /// <summary>
        /// Associates an existing network security group with the network interface.
        /// </summary>
        /// <param name="networkSecurityGroup">networkSecurityGroup an existing network security group</param>
        /// <returns>the next stage of the network interface definition</returns>
        IWithCreate WithExistingNetworkSecurityGroup (INetworkSecurityGroup networkSecurityGroup);

    }
    /// <summary>
    /// The first stage of the network interface.
    /// </summary>
    public interface IBlank  :
        IDefinitionWithRegion<Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithGroup>
    {
    }
    /// <summary>
    /// The entirety of the network interface definition.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IBlank,
        Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithGroup,
        IWithPrimaryNetwork,
        IWithPrimaryNetworkSubnet,
        IWithPrimaryPrivateIp,
        IWithCreate
    {
    }
    /// <summary>
    /// The stage of the network interface definition allowing to specify private IP address within
    /// a virtual network subnet.
    /// </summary>
    public interface IWithPrimaryPrivateIp 
    {
        /// <summary>
        /// Enables dynamic private IP address allocation within the specified existing virtual network
        /// subnet for the network interface's primary IP configuration.
        /// </summary>
        /// <returns>the next stage of network interface definition</returns>
        IWithCreate WithPrimaryPrivateIpAddressDynamic ();

        /// <summary>
        /// Assigns the specified static private IP address within the specified existing virtual network
        /// subnet to the network interface's primary IP configuration.
        /// </summary>
        /// <param name="staticPrivateIpAddress">staticPrivateIpAddress the static IP address within the specified subnet to assign to</param>
        /// <param name="the">the network interface</param>
        /// <returns>the next stage of network interface definition</returns>
        IWithCreate WithPrimaryPrivateIpAddressStatic (string staticPrivateIpAddress);

    }
    /// <summary>
    /// The stage of the network interface definition allowing to specify the virtual network for
    /// primary IP configuration.
    /// </summary>
    public interface IWithPrimaryNetwork 
    {
        /// <summary>
        /// Create a new virtual network to associate with the network interface's primary IP configuration,
        /// based on the provided definition.
        /// </summary>
        /// <param name="creatable">creatable a creatable definition for a new virtual network</param>
        /// <returns>the next stage of the network interface definition</returns>
        IWithPrimaryPrivateIp WithNewPrimaryNetwork (ICreatable<Microsoft.Azure.Management.V2.Network.INetwork> creatable);

        /// <summary>
        /// Creates a new virtual network to associate with the network interface's primary IP configuration.
        /// <p>
        /// The virtual network will be created in the same resource group and region as of network interface,
        /// it will be created with the specified address space and a default subnet covering the entirety of
        /// the network IP address space.
        /// </summary>
        /// <param name="name">name the name of the new virtual network</param>
        /// <param name="addressSpace">addressSpace the address space for rhe virtual network</param>
        /// <returns>the next stage of the network interface definition</returns>
        IWithPrimaryPrivateIp WithNewPrimaryNetwork (string name, string addressSpace);

        /// <summary>
        /// Creates a new virtual network to associate with the network interface's primary IP configuration.
        /// <p>
        /// The virtual network will be created in the same resource group and region as of network interface,
        /// it will be created with the specified address space and a default subnet covering the entirety of
        /// the network IP address space.
        /// </summary>
        /// <param name="addressSpace">addressSpace the address space for the virtual network</param>
        /// <returns>the next stage of the network interface definition</returns>
        IWithPrimaryPrivateIp WithNewPrimaryNetwork (string addressSpace);

        /// <summary>
        /// Associate an existing virtual network with the network interface's primary IP configuration.
        /// </summary>
        /// <param name="network">network an existing virtual network</param>
        /// <returns>the next stage of the network interface definition</returns>
        IWithPrimaryNetworkSubnet WithExistingPrimaryNetwork (INetwork network);

    }
    /// <summary>
    /// The stage of the network interface definition allowing to associate a secondary IP configurations.
    /// </summary>
    public interface IWithSecondaryIpConfiguration 
    {
        /// <summary>
        /// Starts definition of a secondary IP configuration.
        /// </summary>
        /// <param name="name">name name for the IP configuration</param>
        /// <returns>the first stage of a secondary IP configuration definition</returns>
        Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Definition.IBlank<Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate> DefineSecondaryIpConfiguration (string name);

    }
    /// <summary>
    /// The stage of the network interface definition allowing to specify subnet.
    /// </summary>
    public interface IWithPrimaryNetworkSubnet 
    {
        /// <summary>
        /// Associate a subnet with the network interface's primary IP configuration.
        /// </summary>
        /// <param name="name">name the subnet name</param>
        /// <returns>the next stage of the network interface definition</returns>
        IWithPrimaryPrivateIp WithSubnet (string name);

    }
    /// <summary>
    /// The stage of the network interface definition allowing to associate public IP address with it's primary
    /// IP configuration.
    /// </summary>
    public interface IWithPrimaryPublicIpAddress 
    {
        /// <summary>
        /// Create a new public IP address to associate with network interface's primary IP configuration, based on
        /// the provided definition.
        /// </summary>
        /// <param name="creatable">creatable a creatable definition for a new public IP</param>
        /// <returns>the next stage of the network interface definition</returns>
        IWithCreate WithNewPrimaryPublicIpAddress (ICreatable<Microsoft.Azure.Management.V2.Network.IPublicIpAddress> creatable);

        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource and associate it
        /// with the network interface's primary IP configuration.
        /// <p>
        /// the internal name and DNS label for the public IP address will be derived from the network interface name
        /// </summary>
        /// <returns>the next stage of the network interface definition</returns>
        IWithCreate WithNewPrimaryPublicIpAddress ();

        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource, with the specified DNS label
        /// and associate it with the network interface's primary IP configuration.
        /// <p>
        /// the internal name for the public IP address will be derived from the DNS label
        /// </summary>
        /// <param name="leafDnsLabel">leafDnsLabel the leaf domain label</param>
        /// <returns>the next stage of the network interface definition</returns>
        IWithCreate WithNewPrimaryPublicIpAddress (string leafDnsLabel);

        /// <summary>
        /// Associates an existing public IP address with the network interface's primary IP configuration.
        /// </summary>
        /// <param name="publicIpAddress">publicIpAddress an existing public IP address</param>
        /// <returns>the next stage of the network interface definition</returns>
        IWithCreate WithExistingPrimaryPublicIpAddress (IPublicIpAddress publicIpAddress);

    }
    /// <summary>
    /// The stage of the network interface definition which contains all the minimum required inputs for
    /// the resource to be created (via {@link WithCreate#create()}), but also allows
    /// for any other optional settings to be specified.
    /// </summary>
    public interface IWithCreate  :
        ICreatable<Microsoft.Azure.Management.V2.Network.INetworkInterface>,
        IDefinitionWithTags<Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate>,
        IWithPrimaryPublicIpAddress,
        IWithNetworkSecurityGroup,
        IWithSecondaryIpConfiguration
    {
        /// <summary>
        /// Enable IP forwarding in the network interface.
        /// </summary>
        /// <returns>the next stage of the network interface definition</returns>
        IWithCreate WithIpForwarding ();

        /// <summary>
        /// Specifies the IP address of the custom DNS server to associate with the network interface.
        /// <p>
        /// Note this method's effect is additive, i.e. each time it is used, the new dns server is
        /// added to the network interface.
        /// </summary>
        /// <param name="ipAddress">ipAddress the IP address of the DNS server</param>
        /// <returns>the next stage of the network interface definition</returns>
        IWithCreate WithDnsServer (string ipAddress);

        /// <summary>
        /// Specifies the internal DNS name label for the network interface.
        /// </summary>
        /// <param name="dnsNameLabel">dnsNameLabel the internal DNS name label</param>
        /// <returns>the next stage of the network interface definition</returns>
        IWithCreate WithInternalDnsNameLabel (string dnsNameLabel);

    }
}