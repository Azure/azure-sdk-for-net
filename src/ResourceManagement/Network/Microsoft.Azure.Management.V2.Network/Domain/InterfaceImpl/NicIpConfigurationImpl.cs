/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Network
{

    using Microsoft.Azure.Management.V2.Resource.Core.ChildResource.Update;
    using Microsoft.Azure.Management.V2.Resource.Core;
    using Microsoft.Azure.Management.V2.Network.NicIpConfiguration.UpdateDefinition;
    using Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Definition;
    using Microsoft.Azure.Management.Network.Models;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Update;
    using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
    using Microsoft.Azure.Management.V2.Resource.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition;
    using Microsoft.Azure.Management.V2.Network.NetworkInterface.Update;
    using Microsoft.Azure;
    public partial class NicIpConfigurationImpl 
    {
        /// <summary>
        /// Specifies that remove any public IP associated with the IP configuration.
        /// </summary>
        /// <returns>the next stage of the network interface IP configuration update</returns>
        Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Update.IUpdate Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Update.IWithPublicIpAddress.WithoutPublicIpAddress () {
            return this.WithoutPublicIpAddress() as Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Create a new public IP address to associate the network interface IP configuration with,
        /// based on the provided definition.
        /// <p>
        /// If there is public IP associated with the IP configuration then that will be removed in
        /// favour of this.
        /// </summary>
        /// <param name="creatable">creatable a creatable definition for a new public IP</param>
        /// <returns>the next stage of the network interface IP configuration update</returns>
        Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Update.IUpdate Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Update.IWithPublicIpAddress.WithNewPublicIpAddress (ICreatable<Microsoft.Azure.Management.V2.Network.IPublicIpAddress> creatable) {
            return this.WithNewPublicIpAddress( creatable) as Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource and associate it
        /// with the IP configuration.
        /// <p>
        /// The internal name and DNS label for the public IP address will be derived from the network interface
        /// name, if there is an existing public IP association then that will be removed in favour of this.
        /// </summary>
        /// <returns>the next stage of the network interface IP configuration update</returns>
        Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Update.IUpdate Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Update.IWithPublicIpAddress.WithNewPublicIpAddress () {
            return this.WithNewPublicIpAddress() as Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource, with the specified DNS
        /// label and associate it with the IP configuration.
        /// <p>
        /// The internal name for the public IP address will be derived from the DNS label, if there is an existing
        /// public IP association then that will be removed in favour of this
        /// </summary>
        /// <param name="leafDnsLabel">leafDnsLabel the leaf domain label</param>
        /// <returns>the next stage of the network interface IP configuration update</returns>
        Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Update.IUpdate Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Update.IWithPublicIpAddress.WithNewPublicIpAddress (string leafDnsLabel) {
            return this.WithNewPublicIpAddress( leafDnsLabel) as Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Create a new virtual network to associate with the  network interface IP configuration,
        /// based on the provided definition.
        /// </summary>
        /// <param name="creatable">creatable a creatable definition for a new virtual network</param>
        /// <returns>the next stage of the network interface IP configuration definition</returns>
        Microsoft.Azure.Management.V2.Network.NicIpConfiguration.UpdateDefinition.IWithPrivateIp<Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate> Microsoft.Azure.Management.V2.Network.NicIpConfiguration.UpdateDefinition.IWithNetwork<Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate>.WithNewNetwork (ICreatable<Microsoft.Azure.Management.V2.Network.INetwork> creatable) {
            return this.WithNewNetwork( creatable) as Microsoft.Azure.Management.V2.Network.NicIpConfiguration.UpdateDefinition.IWithPrivateIp<Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate>;
        }

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
        Microsoft.Azure.Management.V2.Network.NicIpConfiguration.UpdateDefinition.IWithPrivateIp<Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate> Microsoft.Azure.Management.V2.Network.NicIpConfiguration.UpdateDefinition.IWithNetwork<Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate>.WithNewNetwork (string name, string addressSpace) {
            return this.WithNewNetwork( name,  addressSpace) as Microsoft.Azure.Management.V2.Network.NicIpConfiguration.UpdateDefinition.IWithPrivateIp<Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate>;
        }

        /// <summary>
        /// Creates a new virtual network to associate with the network interface IP configuration.
        /// <p>
        /// the virtual network will be created in the same resource group and region as of parent network interface,
        /// it will be created with the specified address space and a default subnet covering the entirety of the
        /// network IP address space.
        /// </summary>
        /// <param name="addressSpace">addressSpace the address space for the virtual network</param>
        /// <returns>the next stage of the network interface IP configuration definition</returns>
        Microsoft.Azure.Management.V2.Network.NicIpConfiguration.UpdateDefinition.IWithPrivateIp<Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate> Microsoft.Azure.Management.V2.Network.NicIpConfiguration.UpdateDefinition.IWithNetwork<Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate>.WithNewNetwork (string addressSpace) {
            return this.WithNewNetwork( addressSpace) as Microsoft.Azure.Management.V2.Network.NicIpConfiguration.UpdateDefinition.IWithPrivateIp<Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate>;
        }

        /// <summary>
        /// Associate an existing virtual network with the network interface IP configuration.
        /// </summary>
        /// <param name="network">network an existing virtual network</param>
        /// <returns>the next stage of the network interface IP configuration definition</returns>
        Microsoft.Azure.Management.V2.Network.NicIpConfiguration.UpdateDefinition.IWithSubnet<Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate> Microsoft.Azure.Management.V2.Network.NicIpConfiguration.UpdateDefinition.IWithNetwork<Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate>.WithExistingNetwork (INetwork network) {
            return this.WithExistingNetwork( network) as Microsoft.Azure.Management.V2.Network.NicIpConfiguration.UpdateDefinition.IWithSubnet<Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate>;
        }

        /// <summary>
        /// Create a new virtual network to associate with the  network interface IP configuration,
        /// based on the provided definition.
        /// </summary>
        /// <param name="creatable">creatable a creatable definition for a new virtual network</param>
        /// <returns>the next stage of the network interface IP configuration definition</returns>
        Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Definition.IWithPrivateIp<Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate> Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Definition.IWithNetwork<Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate>.WithNewNetwork (ICreatable<Microsoft.Azure.Management.V2.Network.INetwork> creatable) {
            return this.WithNewNetwork( creatable) as Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Definition.IWithPrivateIp<Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate>;
        }

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
        Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Definition.IWithPrivateIp<Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate> Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Definition.IWithNetwork<Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate>.WithNewNetwork (string name, string addressSpace) {
            return this.WithNewNetwork( name,  addressSpace) as Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Definition.IWithPrivateIp<Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate>;
        }

        /// <summary>
        /// Creates a new virtual network to associate with the network interface IP configuration.
        /// <p>
        /// the virtual network will be created in the same resource group and region as of parent network interface,
        /// it will be created with the specified address space and a default subnet covering the entirety of the
        /// network IP address space.
        /// </summary>
        /// <param name="addressSpace">addressSpace the address space for the virtual network</param>
        /// <returns>the next stage of the network interface IP configuration definition</returns>
        Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Definition.IWithPrivateIp<Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate> Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Definition.IWithNetwork<Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate>.WithNewNetwork (string addressSpace) {
            return this.WithNewNetwork( addressSpace) as Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Definition.IWithPrivateIp<Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate>;
        }

        /// <summary>
        /// Associate an existing virtual network with the network interface IP configuration.
        /// </summary>
        /// <param name="network">network an existing virtual network</param>
        /// <returns>the next stage of the network interface IP configuration definition</returns>
        Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Definition.IWithSubnet<Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate> Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Definition.IWithNetwork<Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate>.WithExistingNetwork (INetwork network) {
            return this.WithExistingNetwork( network) as Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Definition.IWithSubnet<Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate>;
        }

        /// <summary>
        /// Assigns the specified static private IP address within the specified existing virtual network
        /// subnet to the network interface IP configuration.
        /// </summary>
        /// <param name="staticPrivateIpAddress">staticPrivateIpAddress the static IP address within the specified subnet to assign to</param>
        /// <param name="the">the network interface</param>
        /// <returns>the next stage of network interface IP configuration definition</returns>
        Microsoft.Azure.Management.V2.Network.NicIpConfiguration.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate> Microsoft.Azure.Management.V2.Network.NicIpConfiguration.UpdateDefinition.IWithPrivateIp<Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate>.WithPrivateIpAddressStatic (string staticPrivateIpAddress) {
            return this.WithPrivateIpAddressStatic( staticPrivateIpAddress) as Microsoft.Azure.Management.V2.Network.NicIpConfiguration.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate>;
        }

        /// <summary>
        /// Enables dynamic private IP address allocation within the specified existing virtual network
        /// subnet for the network interface IP configuration.
        /// </summary>
        /// <returns>the next stage of network interface IP configuration definition</returns>
        Microsoft.Azure.Management.V2.Network.NicIpConfiguration.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate> Microsoft.Azure.Management.V2.Network.NicIpConfiguration.UpdateDefinition.IWithPrivateIp<Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate>.WithPrivateIpAddressDynamic () {
            return this.WithPrivateIpAddressDynamic() as Microsoft.Azure.Management.V2.Network.NicIpConfiguration.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate>;
        }

        /// <summary>
        /// Assigns the specified static private IP address within the specified existing virtual network
        /// subnet to the network interface IP configuration.
        /// </summary>
        /// <param name="staticPrivateIpAddress">staticPrivateIpAddress the static IP address within the specified subnet to assign to</param>
        /// <param name="the">the network interface</param>
        /// <returns>the next stage of network interface IP configuration definition</returns>
        Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Definition.IWithAttach<Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate> Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Definition.IWithPrivateIp<Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate>.WithPrivateIpAddressStatic (string staticPrivateIpAddress) {
            return this.WithPrivateIpAddressStatic( staticPrivateIpAddress) as Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Definition.IWithAttach<Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate>;
        }

        /// <summary>
        /// Enables dynamic private IP address allocation within the specified existing virtual network
        /// subnet for the network interface IP configuration.
        /// </summary>
        /// <returns>the next stage of network interface IP configuration definition</returns>
        Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Definition.IWithAttach<Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate> Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Definition.IWithPrivateIp<Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate>.WithPrivateIpAddressDynamic () {
            return this.WithPrivateIpAddressDynamic() as Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Definition.IWithAttach<Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate>;
        }

        /// <returns>the resource id of the virtual network subnet associated with this IP configuration.</returns>
        string Microsoft.Azure.Management.V2.Network.INicIpConfiguration.SubnetId
        {
            get
            {
                return this.SubnetId as string;
            }
        }
        /// <summary>
        /// Gets the public IP address associated with this IP configuration.
        /// <p>
        /// This method makes a rest API call to fetch the public IP.
        /// </summary>
        /// <returns>the public IP associated with this IP configuration or null if there is no public IP associated</returns>
        Microsoft.Azure.Management.V2.Network.IPublicIpAddress Microsoft.Azure.Management.V2.Network.INicIpConfiguration.PublicIpAddress () {
            return this.PublicIpAddress() as Microsoft.Azure.Management.V2.Network.IPublicIpAddress;
        }

        /// <summary>
        /// Gets the resource id of the public IP address associated with this IP configuration.
        /// </summary>
        /// <returns>public IP resource ID or null if there is no public IP associated</returns>
        string Microsoft.Azure.Management.V2.Network.INicIpConfiguration.PublicIpAddressId
        {
            get
            {
                return this.PublicIpAddressId as string;
            }
        }
        /// <returns>the private IP allocation method (Dynamic, Static)</returns>
        string Microsoft.Azure.Management.V2.Network.INicIpConfiguration.PrivateIpAllocationMethod
        {
            get
            {
                return this.PrivateIpAllocationMethod as string;
            }
        }
        /// <summary>
        /// Gets the private IP address allocated to this IP configuration.
        /// <p>
        /// The private IP will be within the virtual network subnet of this IP configuration.
        /// </summary>
        /// <returns>the private IP addresses</returns>
        string Microsoft.Azure.Management.V2.Network.INicIpConfiguration.PrivateIp
        {
            get
            {
                return this.PrivateIp as string;
            }
        }
        /// <summary>
        /// Gets the virtual network associated with this IP configuration.
        /// <p>
        /// This method makes a rest API call to fetch the public IP.
        /// </summary>
        /// <returns>the virtual network associated with this this IP configuration.</returns>
        Microsoft.Azure.Management.V2.Network.INetwork Microsoft.Azure.Management.V2.Network.INicIpConfiguration.Network () {
            return this.Network() as Microsoft.Azure.Management.V2.Network.INetwork;
        }

        Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate Microsoft.Azure.Management.V2.Resource.Core.ChildResource.Update.IInUpdate<Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate>.Attach () {
            return this.Attach() as Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate;
        }

        Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate Microsoft.Azure.Management.V2.Resource.Core.ChildResource.Definition.IInDefinition<Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate>.Attach () {
            return this.Attach() as Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate;
        }

        /// <returns>the name of the child resource</returns>
        string Microsoft.Azure.Management.V2.Resource.Core.IChildResource.Name
        {
            get
            {
                return this.Name as string;
            }
        }
        /// <summary>
        /// Specifies the load balancer to associate this IP configuration with.
        /// </summary>
        /// <param name="loadBalancer">loadBalancer an existing load balancer</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Update.IWithBackendAddressPool Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Update.IWithLoadBalancer.WithExistingLoadBalancer (ILoadBalancer loadBalancer) {
            return this.WithExistingLoadBalancer( loadBalancer) as Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Update.IWithBackendAddressPool;
        }

        /// <summary>
        /// Associates an existing public IP address with the network interface IP configuration.
        /// </summary>
        /// <param name="publicIpAddress">publicIpAddress an existing public IP address</param>
        /// <returns>the next stage of the IP configuration definition</returns>
        Microsoft.Azure.Management.V2.Network.NicIpConfiguration.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate> Microsoft.Azure.Management.V2.Network.NicIpConfiguration.UpdateDefinition.IWithPublicIpAddress<Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate>.WithExistingPublicIpAddress (IPublicIpAddress publicIpAddress) {
            return this.WithExistingPublicIpAddress( publicIpAddress) as Microsoft.Azure.Management.V2.Network.NicIpConfiguration.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate>;
        }

        /// <summary>
        /// Create a new public IP address to associate with the network interface IP configuration,
        /// based on the provided definition.
        /// </summary>
        /// <param name="creatable">creatable a creatable definition for a new public IP</param>
        /// <returns>the next stage of the network interface IP configuration definition</returns>
        Microsoft.Azure.Management.V2.Network.NicIpConfiguration.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate> Microsoft.Azure.Management.V2.Network.NicIpConfiguration.UpdateDefinition.IWithPublicIpAddress<Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate>.WithNewPublicIpAddress (ICreatable<Microsoft.Azure.Management.V2.Network.IPublicIpAddress> creatable) {
            return this.WithNewPublicIpAddress( creatable) as Microsoft.Azure.Management.V2.Network.NicIpConfiguration.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate>;
        }

        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource and associate it
        /// with with the network interface IP configuration.
        /// <p>
        /// The internal name and DNS label for the public IP address will be derived from the network interface name.
        /// </summary>
        /// <returns>the next stage of the network interface IP configuration definition</returns>
        Microsoft.Azure.Management.V2.Network.NicIpConfiguration.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate> Microsoft.Azure.Management.V2.Network.NicIpConfiguration.UpdateDefinition.IWithPublicIpAddress<Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate>.WithNewPublicIpAddress () {
            return this.WithNewPublicIpAddress() as Microsoft.Azure.Management.V2.Network.NicIpConfiguration.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate>;
        }

        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource, with the specified DNS label
        /// and associate it with the network interface IP configuration.
        /// <p>
        /// The internal name for the public IP address will be derived from the DNS label.
        /// </summary>
        /// <param name="leafDnsLabel">leafDnsLabel the leaf domain label</param>
        /// <returns>tthe next stage of the IP configuration definition</returns>
        Microsoft.Azure.Management.V2.Network.NicIpConfiguration.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate> Microsoft.Azure.Management.V2.Network.NicIpConfiguration.UpdateDefinition.IWithPublicIpAddress<Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate>.WithNewPublicIpAddress (string leafDnsLabel) {
            return this.WithNewPublicIpAddress( leafDnsLabel) as Microsoft.Azure.Management.V2.Network.NicIpConfiguration.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate>;
        }

        /// <summary>
        /// Associates an existing public IP address with the network interface IP configuration.
        /// </summary>
        /// <param name="publicIpAddress">publicIpAddress an existing public IP address</param>
        /// <returns>the next stage of the IP configuration definition</returns>
        Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Definition.IWithAttach<Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate> Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Definition.IWithPublicIpAddress<Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate>.WithExistingPublicIpAddress (IPublicIpAddress publicIpAddress) {
            return this.WithExistingPublicIpAddress( publicIpAddress) as Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Definition.IWithAttach<Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate>;
        }

        /// <summary>
        /// Create a new public IP address to associate with the network interface IP configuration,
        /// based on the provided definition.
        /// </summary>
        /// <param name="creatable">creatable a creatable definition for a new public IP</param>
        /// <returns>the next stage of the network interface IP configuration definition</returns>
        Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Definition.IWithAttach<Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate> Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Definition.IWithPublicIpAddress<Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate>.WithNewPublicIpAddress (ICreatable<Microsoft.Azure.Management.V2.Network.IPublicIpAddress> creatable) {
            return this.WithNewPublicIpAddress( creatable) as Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Definition.IWithAttach<Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate>;
        }

        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource and associate it
        /// with with the network interface IP configuration.
        /// <p>
        /// The internal name and DNS label for the public IP address will be derived from the network interface name.
        /// </summary>
        /// <returns>the next stage of the network interface IP configuration definition</returns>
        Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Definition.IWithAttach<Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate> Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Definition.IWithPublicIpAddress<Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate>.WithNewPublicIpAddress () {
            return this.WithNewPublicIpAddress() as Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Definition.IWithAttach<Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate>;
        }

        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource, with the specified DNS label
        /// and associate it with the network interface IP configuration.
        /// <p>
        /// The internal name for the public IP address will be derived from the DNS label.
        /// </summary>
        /// <param name="leafDnsLabel">leafDnsLabel the leaf domain label</param>
        /// <returns>tthe next stage of the IP configuration definition</returns>
        Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Definition.IWithAttach<Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate> Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Definition.IWithPublicIpAddress<Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate>.WithNewPublicIpAddress (string leafDnsLabel) {
            return this.WithNewPublicIpAddress( leafDnsLabel) as Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Definition.IWithAttach<Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate>;
        }

        /// <summary>
        /// Assigns the specified static private IP address within the specified existing virtual network
        /// subnet to the network interface IP configuration.
        /// </summary>
        /// <param name="staticPrivateIpAddress">staticPrivateIpAddress the static IP address within the specified subnet to assign to</param>
        /// <param name="the">the  IP configuration</param>
        /// <returns>the next stage of the network interface IP configuration update</returns>
        Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Update.IUpdate Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Update.IWithPrivateIp.WithPrivateIpAddressStatic (string staticPrivateIpAddress) {
            return this.WithPrivateIpAddressStatic( staticPrivateIpAddress) as Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Enables dynamic private IP address allocation within the specified existing virtual network
        /// subnet to the network interface IP configuration.
        /// </summary>
        /// <returns>the next stage of the network interface IP configuration update</returns>
        Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Update.IUpdate Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Update.IWithPrivateIp.WithPrivateIpAddressDynamic () {
            return this.WithPrivateIpAddressDynamic() as Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Adds this network interface's IP configuration to the provided back end address pool of
        /// the specified load balancer.
        /// </summary>
        /// <param name="name">name the name of an existing load balancer back end address pool</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Update.IUpdate Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Update.IWithBackendAddressPool.WithBackendAddressPool (string name) {
            return this.WithBackendAddressPool( name) as Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Associate a subnet with the network interface IP configuration.
        /// </summary>
        /// <param name="name">name the subnet name</param>
        /// <returns>the next stage of the network interface IP configuration definition</returns>
        Microsoft.Azure.Management.V2.Network.NicIpConfiguration.UpdateDefinition.IWithPrivateIp<Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate> Microsoft.Azure.Management.V2.Network.NicIpConfiguration.UpdateDefinition.IWithSubnet<Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate>.WithSubnet (string name) {
            return this.WithSubnet( name) as Microsoft.Azure.Management.V2.Network.NicIpConfiguration.UpdateDefinition.IWithPrivateIp<Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate>;
        }

        /// <summary>
        /// Associate a subnet with the network interface IP configuration.
        /// </summary>
        /// <param name="name">name the subnet name</param>
        /// <returns>the next stage of the network interface IP configuration definition</returns>
        Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Definition.IWithPrivateIp<Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate> Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Definition.IWithSubnet<Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate>.WithSubnet (string name) {
            return this.WithSubnet( name) as Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Definition.IWithPrivateIp<Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate>;
        }

        /// <summary>
        /// Associate a subnet with the network interface IP configuration.
        /// </summary>
        /// <param name="name">name the subnet name</param>
        /// <returns>the next stage of the network interface IP configuration update</returns>
        Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Update.IUpdate Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Update.IWithSubnet.WithSubnet (string name) {
            return this.WithSubnet( name) as Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Update.IUpdate;
        }

    }
}