// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Definition;
    using Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Update;
    using Microsoft.Azure.Management.Network.Fluent.NicIPConfiguration.Definition;
    using Microsoft.Azure.Management.Network.Fluent.NicIPConfiguration.Update;
    using Microsoft.Azure.Management.Network.Fluent.NicIPConfiguration.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.HasPrivateIPAddress.Definition;
    using Microsoft.Azure.Management.Network.Fluent.HasPrivateIPAddress.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.HasPrivateIPAddress.Update;
    using Microsoft.Azure.Management.Network.Fluent.HasPublicIPAddress.Definition;
    using Microsoft.Azure.Management.Network.Fluent.HasPublicIPAddress.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.HasPublicIPAddress.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;

    internal partial class NicIPConfigurationImpl 
    {
        /// <return>The associated public IP address.</return>
        Microsoft.Azure.Management.Network.Fluent.IPublicIPAddress Microsoft.Azure.Management.Network.Fluent.IHasPublicIPAddress.GetPublicIPAddress()
        {
            return this.GetPublicIPAddress() as Microsoft.Azure.Management.Network.Fluent.IPublicIPAddress;
        }

        /// <summary>
        /// Gets the resource ID of the associated public IP address.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IHasPublicIPAddress.PublicIPAddressId
        {
            get
            {
                return this.PublicIPAddressId();
            }
        }

        /// <summary>
        /// Specifies the IP version for the private IP address.
        /// </summary>
        /// <param name="ipVersion">An IP version.</param>
        /// <return>The next stage of the update.</return>
        NicIPConfiguration.Update.IUpdate NicIPConfiguration.Update.IWithPrivateIP.WithPrivateIPVersion(IPVersion ipVersion)
        {
            return this.WithPrivateIPVersion(ipVersion) as NicIPConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the IP version for the private IP address.
        /// </summary>
        /// <param name="ipVersion">An IP version.</param>
        /// <return>The next stage of the definition.</return>
        NicIPConfiguration.UpdateDefinition.IWithAttach<NetworkInterface.Update.IUpdate> NicIPConfiguration.UpdateDefinition.IWithPrivateIP<NetworkInterface.Update.IUpdate>.WithPrivateIPVersion(IPVersion ipVersion)
        {
            return this.WithPrivateIPVersion(ipVersion) as NicIPConfiguration.UpdateDefinition.IWithAttach<NetworkInterface.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the IP version for the private IP address.
        /// </summary>
        /// <param name="ipVersion">An IP version.</param>
        /// <return>The next stage of the definition.</return>
        NicIPConfiguration.Definition.IWithAttach<NetworkInterface.Definition.IWithCreate> NicIPConfiguration.Definition.IWithPrivateIP<NetworkInterface.Definition.IWithCreate>.WithPrivateIPVersion(IPVersion ipVersion)
        {
            return this.WithPrivateIPVersion(ipVersion) as NicIPConfiguration.Definition.IWithAttach<NetworkInterface.Definition.IWithCreate>;
        }

        /// <summary>
        /// Create a new virtual network to associate with the  network interface IP configuration,
        /// based on the provided definition.
        /// </summary>
        /// <param name="creatable">A creatable definition for a new virtual network.</param>
        /// <return>The next stage of the definition.</return>
        NicIPConfiguration.UpdateDefinition.IWithPrivateIP<NetworkInterface.Update.IUpdate> NicIPConfiguration.UpdateDefinition.IWithNetwork<NetworkInterface.Update.IUpdate>.WithNewNetwork(ICreatable<Microsoft.Azure.Management.Network.Fluent.INetwork> creatable)
        {
            return this.WithNewNetwork(creatable) as NicIPConfiguration.UpdateDefinition.IWithPrivateIP<NetworkInterface.Update.IUpdate>;
        }

        /// <summary>
        /// Creates a new virtual network to associate with the network interface IP configuration.
        /// the virtual network will be created in the same resource group and region as of parent
        /// network interface, it will be created with the specified address space and a default subnet
        /// covering the entirety of the network IP address space.
        /// </summary>
        /// <param name="name">The name of the new virtual network.</param>
        /// <param name="addressSpace">The address space for rhe virtual network.</param>
        /// <return>The next stage of the definition.</return>
        NicIPConfiguration.UpdateDefinition.IWithPrivateIP<NetworkInterface.Update.IUpdate> NicIPConfiguration.UpdateDefinition.IWithNetwork<NetworkInterface.Update.IUpdate>.WithNewNetwork(string name, string addressSpace)
        {
            return this.WithNewNetwork(name, addressSpace) as NicIPConfiguration.UpdateDefinition.IWithPrivateIP<NetworkInterface.Update.IUpdate>;
        }

        /// <summary>
        /// Creates a new virtual network to associate with the network interface IP configuration.
        /// the virtual network will be created in the same resource group and region as of parent network interface,
        /// it will be created with the specified address space and a default subnet covering the entirety of the
        /// network IP address space.
        /// </summary>
        /// <param name="addressSpace">The address space for the virtual network.</param>
        /// <return>The next stage of the definition.</return>
        NicIPConfiguration.UpdateDefinition.IWithPrivateIP<NetworkInterface.Update.IUpdate> NicIPConfiguration.UpdateDefinition.IWithNetwork<NetworkInterface.Update.IUpdate>.WithNewNetwork(string addressSpace)
        {
            return this.WithNewNetwork(addressSpace) as NicIPConfiguration.UpdateDefinition.IWithPrivateIP<NetworkInterface.Update.IUpdate>;
        }

        /// <summary>
        /// Associate an existing virtual network with the network interface IP configuration.
        /// </summary>
        /// <param name="network">An existing virtual network.</param>
        /// <return>The next stage of the definition.</return>
        NicIPConfiguration.UpdateDefinition.IWithSubnet<NetworkInterface.Update.IUpdate> NicIPConfiguration.UpdateDefinition.IWithNetwork<NetworkInterface.Update.IUpdate>.WithExistingNetwork(INetwork network)
        {
            return this.WithExistingNetwork(network) as NicIPConfiguration.UpdateDefinition.IWithSubnet<NetworkInterface.Update.IUpdate>;
        }

        /// <summary>
        /// Create a new virtual network to associate with the  network interface IP configuration,
        /// based on the provided definition.
        /// </summary>
        /// <param name="creatable">A creatable definition for a new virtual network.</param>
        /// <return>The next stage of the definition.</return>
        NicIPConfiguration.Definition.IWithPrivateIP<NetworkInterface.Definition.IWithCreate> NicIPConfiguration.Definition.IWithNetwork<NetworkInterface.Definition.IWithCreate>.WithNewNetwork(ICreatable<Microsoft.Azure.Management.Network.Fluent.INetwork> creatable)
        {
            return this.WithNewNetwork(creatable) as NicIPConfiguration.Definition.IWithPrivateIP<NetworkInterface.Definition.IWithCreate>;
        }

        /// <summary>
        /// Creates a new virtual network to associate with the network interface IP configuration.
        /// the virtual network will be created in the same resource group and region as of parent
        /// network interface, it will be created with the specified address space and a default subnet
        /// covering the entirety of the network IP address space.
        /// </summary>
        /// <param name="name">The name of the new virtual network.</param>
        /// <param name="addressSpace">The address space for rhe virtual network.</param>
        /// <return>The next stage of the definition.</return>
        NicIPConfiguration.Definition.IWithPrivateIP<NetworkInterface.Definition.IWithCreate> NicIPConfiguration.Definition.IWithNetwork<NetworkInterface.Definition.IWithCreate>.WithNewNetwork(string name, string addressSpace)
        {
            return this.WithNewNetwork(name, addressSpace) as NicIPConfiguration.Definition.IWithPrivateIP<NetworkInterface.Definition.IWithCreate>;
        }

        /// <summary>
        /// Creates a new virtual network to associate with the network interface IP configuration.
        /// the virtual network will be created in the same resource group and region as of parent network interface,
        /// it will be created with the specified address space and a default subnet covering the entirety of the
        /// network IP address space.
        /// </summary>
        /// <param name="addressSpace">The address space for the virtual network.</param>
        /// <return>The next stage of the definition.</return>
        NicIPConfiguration.Definition.IWithPrivateIP<NetworkInterface.Definition.IWithCreate> NicIPConfiguration.Definition.IWithNetwork<NetworkInterface.Definition.IWithCreate>.WithNewNetwork(string addressSpace)
        {
            return this.WithNewNetwork(addressSpace) as NicIPConfiguration.Definition.IWithPrivateIP<NetworkInterface.Definition.IWithCreate>;
        }

        /// <summary>
        /// Associate an existing virtual network with the network interface IP configuration.
        /// </summary>
        /// <param name="network">An existing virtual network.</param>
        /// <return>The next stage of the definition.</return>
        NicIPConfiguration.Definition.IWithSubnet<NetworkInterface.Definition.IWithCreate> NicIPConfiguration.Definition.IWithNetwork<NetworkInterface.Definition.IWithCreate>.WithExistingNetwork(INetwork network)
        {
            return this.WithExistingNetwork(network) as NicIPConfiguration.Definition.IWithSubnet<NetworkInterface.Definition.IWithCreate>;
        }

        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource, with the specified DNS label
        /// and associates it with the resource.
        /// The internal name for the public IP address will be derived from the DNS label.
        /// </summary>
        /// <param name="leafDnsLabel">The leaf domain label.</param>
        /// <return>The next stage of the definition.</return>
        NicIPConfiguration.Update.IUpdate HasPublicIPAddress.Update.IWithNewPublicIPAddress<NicIPConfiguration.Update.IUpdate>.WithNewPublicIPAddress(string leafDnsLabel)
        {
            return this.WithNewPublicIPAddress(leafDnsLabel) as NicIPConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource, with the specified DNS label
        /// and associates it with the resource.
        /// The internal name for the public IP address will be derived from the DNS label.
        /// </summary>
        /// <param name="leafDnsLabel">The leaf domain label.</param>
        /// <return>The next stage of the definition.</return>
        NicIPConfiguration.UpdateDefinition.IWithAttach<NetworkInterface.Update.IUpdate> HasPublicIPAddress.UpdateDefinition.IWithNewPublicIPAddress<NicIPConfiguration.UpdateDefinition.IWithAttach<NetworkInterface.Update.IUpdate>>.WithNewPublicIPAddress(string leafDnsLabel)
        {
            return this.WithNewPublicIPAddress(leafDnsLabel) as NicIPConfiguration.UpdateDefinition.IWithAttach<NetworkInterface.Update.IUpdate>;
        }

        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource, with the specified DNS label
        /// and associates it with the resource.
        /// The internal name for the public IP address will be derived from the DNS label.
        /// </summary>
        /// <param name="leafDnsLabel">The leaf domain label.</param>
        /// <return>The next stage of the definition.</return>
        NicIPConfiguration.Definition.IWithAttach<NetworkInterface.Definition.IWithCreate> HasPublicIPAddress.Definition.IWithNewPublicIPAddress<NicIPConfiguration.Definition.IWithAttach<NetworkInterface.Definition.IWithCreate>>.WithNewPublicIPAddress(string leafDnsLabel)
        {
            return this.WithNewPublicIPAddress(leafDnsLabel) as NicIPConfiguration.Definition.IWithAttach<NetworkInterface.Definition.IWithCreate>;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource update.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        NetworkInterface.Update.IUpdate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update.IInUpdate<NetworkInterface.Update.IUpdate>.Attach()
        {
            return this.Attach() as NetworkInterface.Update.IUpdate;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        NetworkInterface.Definition.IWithCreate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<NetworkInterface.Definition.IWithCreate>.Attach()
        {
            return this.Attach() as NetworkInterface.Definition.IWithCreate;
        }

        /// <summary>
        /// Enables dynamic private IP address allocation within the associated subnet.
        /// </summary>
        /// <return>The next stage of the update.</return>
        NicIPConfiguration.Update.IUpdate HasPrivateIPAddress.Update.IWithPrivateIPAddress<NicIPConfiguration.Update.IUpdate>.WithPrivateIPAddressDynamic()
        {
            return this.WithPrivateIPAddressDynamic() as NicIPConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Assigns the specified static private IP address within the associated subnet.
        /// </summary>
        /// <param name="ipAddress">A static IP address within the associated private IP range.</param>
        /// <return>The next stage of the update.</return>
        NicIPConfiguration.Update.IUpdate HasPrivateIPAddress.Update.IWithPrivateIPAddress<NicIPConfiguration.Update.IUpdate>.WithPrivateIPAddressStatic(string ipAddress)
        {
            return this.WithPrivateIPAddressStatic(ipAddress) as NicIPConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Enables dynamic private IP address allocation within the associated subnet.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        NicIPConfiguration.UpdateDefinition.IWithAttach<NetworkInterface.Update.IUpdate> HasPrivateIPAddress.UpdateDefinition.IWithPrivateIPAddress<NicIPConfiguration.UpdateDefinition.IWithAttach<NetworkInterface.Update.IUpdate>>.WithPrivateIPAddressDynamic()
        {
            return this.WithPrivateIPAddressDynamic() as NicIPConfiguration.UpdateDefinition.IWithAttach<NetworkInterface.Update.IUpdate>;
        }

        /// <summary>
        /// Assigns the specified static private IP address within the associated subnet.
        /// </summary>
        /// <param name="ipAddress">A static IP address within the associated private IP range.</param>
        /// <return>The next stage of the definition.</return>
        NicIPConfiguration.UpdateDefinition.IWithAttach<NetworkInterface.Update.IUpdate> HasPrivateIPAddress.UpdateDefinition.IWithPrivateIPAddress<NicIPConfiguration.UpdateDefinition.IWithAttach<NetworkInterface.Update.IUpdate>>.WithPrivateIPAddressStatic(string ipAddress)
        {
            return this.WithPrivateIPAddressStatic(ipAddress) as NicIPConfiguration.UpdateDefinition.IWithAttach<NetworkInterface.Update.IUpdate>;
        }

        /// <summary>
        /// Enables dynamic private IP address allocation within the associated subnet.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        NicIPConfiguration.Definition.IWithAttach<NetworkInterface.Definition.IWithCreate> HasPrivateIPAddress.Definition.IWithPrivateIPAddress<NicIPConfiguration.Definition.IWithAttach<NetworkInterface.Definition.IWithCreate>>.WithPrivateIPAddressDynamic()
        {
            return this.WithPrivateIPAddressDynamic() as NicIPConfiguration.Definition.IWithAttach<NetworkInterface.Definition.IWithCreate>;
        }

        /// <summary>
        /// Assigns the specified static private IP address within the associated subnet.
        /// </summary>
        /// <param name="ipAddress">A static IP address within the associated private IP range.</param>
        /// <return>The next stage of the definition.</return>
        NicIPConfiguration.Definition.IWithAttach<NetworkInterface.Definition.IWithCreate> HasPrivateIPAddress.Definition.IWithPrivateIPAddress<NicIPConfiguration.Definition.IWithAttach<NetworkInterface.Definition.IWithCreate>>.WithPrivateIPAddressStatic(string ipAddress)
        {
            return this.WithPrivateIPAddressStatic(ipAddress) as NicIPConfiguration.Definition.IWithAttach<NetworkInterface.Definition.IWithCreate>;
        }

        /// <summary>
        /// Removes all the existing associations with load balancer backends.
        /// </summary>
        /// <return>The next stage of the update.</return>
        NicIPConfiguration.Update.IUpdate NicIPConfiguration.Update.IWithLoadBalancer.WithoutLoadBalancerBackends()
        {
            return this.WithoutLoadBalancerBackends() as NicIPConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Removes all the existing associations with load balancer inbound NAT rules.
        /// </summary>
        /// <return>The next stage of the update.</return>
        NicIPConfiguration.Update.IUpdate NicIPConfiguration.Update.IWithLoadBalancer.WithoutLoadBalancerInboundNatRules()
        {
            return this.WithoutLoadBalancerInboundNatRules() as NicIPConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the load balancer inbound NAT rule to associate this IP configuration with.
        /// </summary>
        /// <param name="loadBalancer">An existing load balancer.</param>
        /// <param name="inboundNatRuleName">The name of an existing inbound NAT rule on the selected load balancer.</param>
        /// <return>The next stage of the update.</return>
        NicIPConfiguration.Update.IUpdate NicIPConfiguration.Update.IWithLoadBalancer.WithExistingLoadBalancerInboundNatRule(ILoadBalancer loadBalancer, string inboundNatRuleName)
        {
            return this.WithExistingLoadBalancerInboundNatRule(loadBalancer, inboundNatRuleName) as NicIPConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the load balancer to associate this IP configuration with.
        /// </summary>
        /// <param name="loadBalancer">An existing load balancer.</param>
        /// <param name="backendName">The name of an existing backend on that load balancer.</param>
        /// <return>The next stage of the update.</return>
        NicIPConfiguration.Update.IUpdate NicIPConfiguration.Update.IWithLoadBalancer.WithExistingLoadBalancerBackend(ILoadBalancer loadBalancer, string backendName)
        {
            return this.WithExistingLoadBalancerBackend(loadBalancer, backendName) as NicIPConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the load balancer inbound NAT rule to associate this IP configuration with.
        /// </summary>
        /// <param name="loadBalancer">An existing load balancer.</param>
        /// <param name="inboundNatRuleName">The name of an existing inbound NAT rule on the selected load balancer.</param>
        /// <return>The next stage of the update.</return>
        NicIPConfiguration.Definition.IWithAttach<NetworkInterface.Definition.IWithCreate> NicIPConfiguration.Definition.IWithLoadBalancer<NetworkInterface.Definition.IWithCreate>.WithExistingLoadBalancerInboundNatRule(ILoadBalancer loadBalancer, string inboundNatRuleName)
        {
            return this.WithExistingLoadBalancerInboundNatRule(loadBalancer, inboundNatRuleName) as NicIPConfiguration.Definition.IWithAttach<NetworkInterface.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the load balancer backend to associate this IP configuration with.
        /// </summary>
        /// <param name="loadBalancer">An existing load balancer.</param>
        /// <param name="backendName">The name of an existing backend on that load balancer.</param>
        /// <return>The next stage of the update.</return>
        NicIPConfiguration.Definition.IWithAttach<NetworkInterface.Definition.IWithCreate> NicIPConfiguration.Definition.IWithLoadBalancer<NetworkInterface.Definition.IWithCreate>.WithExistingLoadBalancerBackend(ILoadBalancer loadBalancer, string backendName)
        {
            return this.WithExistingLoadBalancerBackend(loadBalancer, backendName) as NicIPConfiguration.Definition.IWithAttach<NetworkInterface.Definition.IWithCreate>;
        }

        /// <summary>
        /// Creates a new public IP address to associate with the resource.
        /// </summary>
        /// <param name="creatable">A creatable definition for a new public IP.</param>
        /// <return>The next stage of the definition.</return>
        NicIPConfiguration.Update.IUpdate HasPublicIPAddress.Update.IWithNewPublicIPAddressNoDnsLabel<NicIPConfiguration.Update.IUpdate>.WithNewPublicIPAddress(ICreatable<Microsoft.Azure.Management.Network.Fluent.IPublicIPAddress> creatable)
        {
            return this.WithNewPublicIPAddress(creatable) as NicIPConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource and associates it with the resource.
        /// The internal name and DNS label for the public IP address will be derived from the resource's name.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        NicIPConfiguration.Update.IUpdate HasPublicIPAddress.Update.IWithNewPublicIPAddressNoDnsLabel<NicIPConfiguration.Update.IUpdate>.WithNewPublicIPAddress()
        {
            return this.WithNewPublicIPAddress() as NicIPConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Creates a new public IP address to associate with the resource.
        /// </summary>
        /// <param name="creatable">A creatable definition for a new public IP.</param>
        /// <return>The next stage of the definition.</return>
        NicIPConfiguration.UpdateDefinition.IWithAttach<NetworkInterface.Update.IUpdate> HasPublicIPAddress.UpdateDefinition.IWithNewPublicIPAddressNoDnsLabel<NicIPConfiguration.UpdateDefinition.IWithAttach<NetworkInterface.Update.IUpdate>>.WithNewPublicIPAddress(ICreatable<Microsoft.Azure.Management.Network.Fluent.IPublicIPAddress> creatable)
        {
            return this.WithNewPublicIPAddress(creatable) as NicIPConfiguration.UpdateDefinition.IWithAttach<NetworkInterface.Update.IUpdate>;
        }

        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource and associates it with the resource.
        /// The internal name and DNS label for the public IP address will be derived from the resource's name.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        NicIPConfiguration.UpdateDefinition.IWithAttach<NetworkInterface.Update.IUpdate> HasPublicIPAddress.UpdateDefinition.IWithNewPublicIPAddressNoDnsLabel<NicIPConfiguration.UpdateDefinition.IWithAttach<NetworkInterface.Update.IUpdate>>.WithNewPublicIPAddress()
        {
            return this.WithNewPublicIPAddress() as NicIPConfiguration.UpdateDefinition.IWithAttach<NetworkInterface.Update.IUpdate>;
        }

        /// <summary>
        /// Creates a new public IP address to associate with the resource.
        /// </summary>
        /// <param name="creatable">A creatable definition for a new public IP.</param>
        /// <return>The next stage of the definition.</return>
        NicIPConfiguration.Definition.IWithAttach<NetworkInterface.Definition.IWithCreate> HasPublicIPAddress.Definition.IWithNewPublicIPAddressNoDnsLabel<NicIPConfiguration.Definition.IWithAttach<NetworkInterface.Definition.IWithCreate>>.WithNewPublicIPAddress(ICreatable<Microsoft.Azure.Management.Network.Fluent.IPublicIPAddress> creatable)
        {
            return this.WithNewPublicIPAddress(creatable) as NicIPConfiguration.Definition.IWithAttach<NetworkInterface.Definition.IWithCreate>;
        }

        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource and associates it with the resource.
        /// The internal name and DNS label for the public IP address will be derived from the resource's name.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        NicIPConfiguration.Definition.IWithAttach<NetworkInterface.Definition.IWithCreate> HasPublicIPAddress.Definition.IWithNewPublicIPAddressNoDnsLabel<NicIPConfiguration.Definition.IWithAttach<NetworkInterface.Definition.IWithCreate>>.WithNewPublicIPAddress()
        {
            return this.WithNewPublicIPAddress() as NicIPConfiguration.Definition.IWithAttach<NetworkInterface.Definition.IWithCreate>;
        }

        /// <summary>
        /// Removes the existing reference to a public IP address.
        /// </summary>
        /// <return>The next stage of the update.</return>
        NicIPConfiguration.Update.IUpdate HasPublicIPAddress.Update.IWithExistingPublicIPAddress<NicIPConfiguration.Update.IUpdate>.WithoutPublicIPAddress()
        {
            return this.WithoutPublicIPAddress() as NicIPConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Associates an existing public IP address with the resource.
        /// </summary>
        /// <param name="publicIPAddress">An existing public IP address.</param>
        /// <return>The next stage of the update.</return>
        NicIPConfiguration.Update.IUpdate HasPublicIPAddress.Update.IWithExistingPublicIPAddress<NicIPConfiguration.Update.IUpdate>.WithExistingPublicIPAddress(IPublicIPAddress publicIPAddress)
        {
            return this.WithExistingPublicIPAddress(publicIPAddress) as NicIPConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Associates an existing public IP address with the resource.
        /// </summary>
        /// <param name="resourceId">The resource ID of an existing public IP address.</param>
        /// <return>The next stage of the definition.</return>
        NicIPConfiguration.Update.IUpdate HasPublicIPAddress.Update.IWithExistingPublicIPAddress<NicIPConfiguration.Update.IUpdate>.WithExistingPublicIPAddress(string resourceId)
        {
            return this.WithExistingPublicIPAddress(resourceId) as NicIPConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Associates an existing public IP address with the resource.
        /// </summary>
        /// <param name="publicIPAddress">An existing public IP address.</param>
        /// <return>The next stage of the definition.</return>
        NicIPConfiguration.UpdateDefinition.IWithAttach<NetworkInterface.Update.IUpdate> HasPublicIPAddress.UpdateDefinition.IWithExistingPublicIPAddress<NicIPConfiguration.UpdateDefinition.IWithAttach<NetworkInterface.Update.IUpdate>>.WithExistingPublicIPAddress(IPublicIPAddress publicIPAddress)
        {
            return this.WithExistingPublicIPAddress(publicIPAddress) as NicIPConfiguration.UpdateDefinition.IWithAttach<NetworkInterface.Update.IUpdate>;
        }

        /// <summary>
        /// Associates an existing public IP address with the resource.
        /// </summary>
        /// <param name="resourceId">The resource ID of an existing public IP address.</param>
        /// <return>The next stage of the definition.</return>
        NicIPConfiguration.UpdateDefinition.IWithAttach<NetworkInterface.Update.IUpdate> HasPublicIPAddress.UpdateDefinition.IWithExistingPublicIPAddress<NicIPConfiguration.UpdateDefinition.IWithAttach<NetworkInterface.Update.IUpdate>>.WithExistingPublicIPAddress(string resourceId)
        {
            return this.WithExistingPublicIPAddress(resourceId) as NicIPConfiguration.UpdateDefinition.IWithAttach<NetworkInterface.Update.IUpdate>;
        }

        /// <summary>
        /// Associates an existing public IP address with the resource.
        /// </summary>
        /// <param name="publicIPAddress">An existing public IP address.</param>
        /// <return>The next stage of the definition.</return>
        NicIPConfiguration.Definition.IWithAttach<NetworkInterface.Definition.IWithCreate> HasPublicIPAddress.Definition.IWithExistingPublicIPAddress<NicIPConfiguration.Definition.IWithAttach<NetworkInterface.Definition.IWithCreate>>.WithExistingPublicIPAddress(IPublicIPAddress publicIPAddress)
        {
            return this.WithExistingPublicIPAddress(publicIPAddress) as NicIPConfiguration.Definition.IWithAttach<NetworkInterface.Definition.IWithCreate>;
        }

        /// <summary>
        /// Associates an existing public IP address with the resource.
        /// </summary>
        /// <param name="resourceId">The resource ID of an existing public IP address.</param>
        /// <return>The next stage of the definition.</return>
        NicIPConfiguration.Definition.IWithAttach<NetworkInterface.Definition.IWithCreate> HasPublicIPAddress.Definition.IWithExistingPublicIPAddress<NicIPConfiguration.Definition.IWithAttach<NetworkInterface.Definition.IWithCreate>>.WithExistingPublicIPAddress(string resourceId)
        {
            return this.WithExistingPublicIPAddress(resourceId) as NicIPConfiguration.Definition.IWithAttach<NetworkInterface.Definition.IWithCreate>;
        }

        /// <summary>
        /// Associate a subnet with the network interface IP configuration.
        /// </summary>
        /// <param name="name">The subnet name.</param>
        /// <return>The next stage of the definition.</return>
        NicIPConfiguration.UpdateDefinition.IWithPrivateIP<NetworkInterface.Update.IUpdate> NicIPConfiguration.UpdateDefinition.IWithSubnet<NetworkInterface.Update.IUpdate>.WithSubnet(string name)
        {
            return this.WithSubnet(name) as NicIPConfiguration.UpdateDefinition.IWithPrivateIP<NetworkInterface.Update.IUpdate>;
        }

        /// <summary>
        /// Associate a subnet with the network interface IP configuration.
        /// </summary>
        /// <param name="name">The subnet name.</param>
        /// <return>The next stage of the definition.</return>
        NicIPConfiguration.Definition.IWithPrivateIP<NetworkInterface.Definition.IWithCreate> NicIPConfiguration.Definition.IWithSubnet<NetworkInterface.Definition.IWithCreate>.WithSubnet(string name)
        {
            return this.WithSubnet(name) as NicIPConfiguration.Definition.IWithPrivateIP<NetworkInterface.Definition.IWithCreate>;
        }

        /// <summary>
        /// Associate a subnet with the network interface IP configuration.
        /// </summary>
        /// <param name="name">The subnet name.</param>
        /// <return>The next stage of the network interface IP configuration update.</return>
        NicIPConfiguration.Update.IUpdate NicIPConfiguration.Update.IWithSubnet.WithSubnet(string name)
        {
            return this.WithSubnet(name) as NicIPConfiguration.Update.IUpdate;
        }
    }
}