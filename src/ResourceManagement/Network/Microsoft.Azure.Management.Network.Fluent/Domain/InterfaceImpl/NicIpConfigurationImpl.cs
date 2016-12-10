// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure;
    using NetworkInterface.Definition;
    using NetworkInterface.Update;
    using NicIpConfiguration.Definition;
    using NicIpConfiguration.Update;
    using NicIpConfiguration.UpdateDefinition;
    using Models;
    using HasPrivateIpAddress.Definition;
    using HasPrivateIpAddress.UpdateDefinition;
    using HasPrivateIpAddress.Update;
    using HasPublicIpAddress.Definition;
    using HasPublicIpAddress.UpdateDefinition;
    using HasPublicIpAddress.Update;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Update;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using System.Collections.Generic;

    internal partial class NicIpConfigurationImpl 
    {
        /// <summary>
        /// Gets the name of the subnet associated with this resource.
        /// </summary>
        string Microsoft.Azure.Management.Resource.Fluent.Core.IHasSubnet.SubnetName
        {
            get
            {
                return this.SubnetName();
            }
        }

        /// <summary>
        /// Gets the resource ID of the virtual network whose subnet is associated with this resource.
        /// </summary>
        string Microsoft.Azure.Management.Resource.Fluent.Core.IHasSubnet.NetworkId
        {
            get
            {
                return this.NetworkId();
            }
        }

        /// <return>The load balancer inbound NAT rules associated with this network interface IP configuration.</return>
        System.Collections.Generic.IList<Microsoft.Azure.Management.Network.Fluent.ILoadBalancerInboundNatRule> Microsoft.Azure.Management.Network.Fluent.INicIpConfiguration.ListAssociatedLoadBalancerInboundNatRules()
        {
            return this.ListAssociatedLoadBalancerInboundNatRules() as System.Collections.Generic.IList<Microsoft.Azure.Management.Network.Fluent.ILoadBalancerInboundNatRule>;
        }

        /// <return>The load balancer backends associated with this network interface IP configuration.</return>
        System.Collections.Generic.IList<Microsoft.Azure.Management.Network.Fluent.ILoadBalancerBackend> Microsoft.Azure.Management.Network.Fluent.INicIpConfiguration.ListAssociatedLoadBalancerBackends()
        {
            return this.ListAssociatedLoadBalancerBackends() as System.Collections.Generic.IList<Microsoft.Azure.Management.Network.Fluent.ILoadBalancerBackend>;
        }

        /// <return>The virtual network associated with this IP configuration.</return>
        Microsoft.Azure.Management.Network.Fluent.INetwork Microsoft.Azure.Management.Network.Fluent.INicIpConfiguration.GetNetwork()
        {
            return this.GetNetwork() as Microsoft.Azure.Management.Network.Fluent.INetwork;
        }

        /// <summary>
        /// Gets private IP address version.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.INicIpConfiguration.PrivateIpAddressVersion
        {
            get
            {
                return this.PrivateIpAddressVersion();
            }
        }

        /// <summary>
        /// Specifies the IP version for the private IP address.
        /// </summary>
        /// <param name="ipVersion">An IP version.</param>
        /// <return>The next stage of the definition.</return>
        NicIpConfiguration.UpdateDefinition.IWithAttach<NetworkInterface.Update.IUpdate> NicIpConfiguration.UpdateDefinition.IWithPrivateIp<NetworkInterface.Update.IUpdate>.WithPrivateIpVersion(string ipVersion)
        {
            return this.WithPrivateIpVersion(ipVersion) as NicIpConfiguration.UpdateDefinition.IWithAttach<NetworkInterface.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the IP version for the private IP address.
        /// </summary>
        /// <param name="ipVersion">An IP version.</param>
        /// <return>The next stage of the definition.</return>
        NicIpConfiguration.Definition.IWithAttach<NetworkInterface.Definition.IWithCreate> NicIpConfiguration.Definition.IWithPrivateIp<NetworkInterface.Definition.IWithCreate>.WithPrivateIpVersion(string ipVersion)
        {
            return this.WithPrivateIpVersion(ipVersion) as NicIpConfiguration.Definition.IWithAttach<NetworkInterface.Definition.IWithCreate>;
        }

        /// <summary>
        /// Removes all the existing associations with load balancer backends.
        /// </summary>
        /// <return>The next stage of the update.</return>
        NicIpConfiguration.Update.IUpdate NicIpConfiguration.Update.IWithLoadBalancer.WithoutLoadBalancerBackends()
        {
            return this.WithoutLoadBalancerBackends() as NicIpConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Removes all the existing associations with load balancer inbound NAT rules.
        /// </summary>
        /// <return>The next stage of the update.</return>
        NicIpConfiguration.Update.IUpdate NicIpConfiguration.Update.IWithLoadBalancer.WithoutLoadBalancerInboundNatRules()
        {
            return this.WithoutLoadBalancerInboundNatRules() as NicIpConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the load balancer inbound NAT rule to associate this IP configuration with.
        /// </summary>
        /// <param name="loadBalancer">An existing load balancer.</param>
        /// <param name="inboundNatRuleName">The name of an existing inbound NAT rule on the selected load balancer.</param>
        /// <return>The next stage of the update.</return>
        NicIpConfiguration.Update.IUpdate NicIpConfiguration.Update.IWithLoadBalancer.WithExistingLoadBalancerInboundNatRule(ILoadBalancer loadBalancer, string inboundNatRuleName)
        {
            return this.WithExistingLoadBalancerInboundNatRule(loadBalancer, inboundNatRuleName) as NicIpConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the load balancer to associate this IP configuration with.
        /// </summary>
        /// <param name="loadBalancer">An existing load balancer.</param>
        /// <param name="backendName">The name of an existing backend on that load balancer.</param>
        /// <return>The next stage of the update.</return>
        NicIpConfiguration.Update.IUpdate NicIpConfiguration.Update.IWithLoadBalancer.WithExistingLoadBalancerBackend(ILoadBalancer loadBalancer, string backendName)
        {
            return this.WithExistingLoadBalancerBackend(loadBalancer, backendName) as NicIpConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Assigns the specified static private IP address within the associated subnet.
        /// </summary>
        /// <param name="ipAddress">A static IP address within the associated private IP range.</param>
        /// <return>The next stage of the update.</return>
        NicIpConfiguration.Update.IUpdate HasPrivateIpAddress.Update.IWithPrivateIpAddress<NicIpConfiguration.Update.IUpdate>.WithPrivateIpAddressStatic(string ipAddress)
        {
            return this.WithPrivateIpAddressStatic(ipAddress) as NicIpConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Enables dynamic private IP address allocation within the associated subnet.
        /// </summary>
        /// <return>The next stage of the update.</return>
        NicIpConfiguration.Update.IUpdate HasPrivateIpAddress.Update.IWithPrivateIpAddress<NicIpConfiguration.Update.IUpdate>.WithPrivateIpAddressDynamic()
        {
            return this.WithPrivateIpAddressDynamic() as NicIpConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Assigns the specified static private IP address within the associated subnet.
        /// </summary>
        /// <param name="ipAddress">A static IP address within the associated private IP range.</param>
        /// <return>The next stage of the definition.</return>
        NicIpConfiguration.UpdateDefinition.IWithAttach<NetworkInterface.Update.IUpdate> HasPrivateIpAddress.UpdateDefinition.IWithPrivateIpAddress<NicIpConfiguration.UpdateDefinition.IWithAttach<NetworkInterface.Update.IUpdate>>.WithPrivateIpAddressStatic(string ipAddress)
        {
            return this.WithPrivateIpAddressStatic(ipAddress) as NicIpConfiguration.UpdateDefinition.IWithAttach<NetworkInterface.Update.IUpdate>;
        }

        /// <summary>
        /// Enables dynamic private IP address allocation within the associated subnet.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        NicIpConfiguration.UpdateDefinition.IWithAttach<NetworkInterface.Update.IUpdate> HasPrivateIpAddress.UpdateDefinition.IWithPrivateIpAddress<NicIpConfiguration.UpdateDefinition.IWithAttach<NetworkInterface.Update.IUpdate>>.WithPrivateIpAddressDynamic()
        {
            return this.WithPrivateIpAddressDynamic() as NicIpConfiguration.UpdateDefinition.IWithAttach<NetworkInterface.Update.IUpdate>;
        }

        /// <summary>
        /// Assigns the specified static private IP address within the associated subnet.
        /// </summary>
        /// <param name="ipAddress">A static IP address within the associated private IP range.</param>
        /// <return>The next stage of the definition.</return>
        NicIpConfiguration.Definition.IWithAttach<NetworkInterface.Definition.IWithCreate> HasPrivateIpAddress.Definition.IWithPrivateIpAddress<NicIpConfiguration.Definition.IWithAttach<NetworkInterface.Definition.IWithCreate>>.WithPrivateIpAddressStatic(string ipAddress)
        {
            return this.WithPrivateIpAddressStatic(ipAddress) as NicIpConfiguration.Definition.IWithAttach<NetworkInterface.Definition.IWithCreate>;
        }

        /// <summary>
        /// Enables dynamic private IP address allocation within the associated subnet.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        NicIpConfiguration.Definition.IWithAttach<NetworkInterface.Definition.IWithCreate> HasPrivateIpAddress.Definition.IWithPrivateIpAddress<NicIpConfiguration.Definition.IWithAttach<NetworkInterface.Definition.IWithCreate>>.WithPrivateIpAddressDynamic()
        {
            return this.WithPrivateIpAddressDynamic() as NicIpConfiguration.Definition.IWithAttach<NetworkInterface.Definition.IWithCreate>;
        }

        /// <summary>
        /// Associate a subnet with the network interface IP configuration.
        /// </summary>
        /// <param name="name">The subnet name.</param>
        /// <return>The next stage of the network interface IP configuration definition.</return>
        NicIpConfiguration.UpdateDefinition.IWithPrivateIp<NetworkInterface.Update.IUpdate> NicIpConfiguration.UpdateDefinition.IWithSubnet<NetworkInterface.Update.IUpdate>.WithSubnet(string name)
        {
            return this.WithSubnet(name) as NicIpConfiguration.UpdateDefinition.IWithPrivateIp<NetworkInterface.Update.IUpdate>;
        }

        /// <summary>
        /// Associate a subnet with the network interface IP configuration.
        /// </summary>
        /// <param name="name">The subnet name.</param>
        /// <return>The next stage of the network interface IP configuration definition.</return>
        NicIpConfiguration.Definition.IWithPrivateIp<NetworkInterface.Definition.IWithCreate> NicIpConfiguration.Definition.IWithSubnet<NetworkInterface.Definition.IWithCreate>.WithSubnet(string name)
        {
            return this.WithSubnet(name) as NicIpConfiguration.Definition.IWithPrivateIp<NetworkInterface.Definition.IWithCreate>;
        }

        /// <summary>
        /// Gets the private IP address associated with this resource.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IHasPrivateIpAddress.PrivateIpAddress
        {
            get
            {
                return this.PrivateIpAddress();
            }
        }

        /// <summary>
        /// Gets the private IP address allocation method within the associated subnet.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IHasPrivateIpAddress.PrivateIpAllocationMethod
        {
            get
            {
                return this.PrivateIpAllocationMethod();
            }
        }

        /// <summary>
        /// Creates a new public IP address to associate with the resource.
        /// </summary>
        /// <param name="creatable">A creatable definition for a new public IP.</param>
        /// <return>The next stage of the definition.</return>
        NicIpConfiguration.Update.IUpdate HasPublicIpAddress.Update.IWithNewPublicIpAddressNoDnsLabel<NicIpConfiguration.Update.IUpdate>.WithNewPublicIpAddress(ICreatable<Microsoft.Azure.Management.Network.Fluent.IPublicIpAddress> creatable)
        {
            return this.WithNewPublicIpAddress(creatable) as NicIpConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource and associates it with the resource.
        /// The internal name and DNS label for the public IP address will be derived from the resource's name.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        NicIpConfiguration.Update.IUpdate HasPublicIpAddress.Update.IWithNewPublicIpAddressNoDnsLabel<NicIpConfiguration.Update.IUpdate>.WithNewPublicIpAddress()
        {
            return this.WithNewPublicIpAddress() as NicIpConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Creates a new public IP address to associate with the resource.
        /// </summary>
        /// <param name="creatable">A creatable definition for a new public IP.</param>
        /// <return>The next stage of the definition.</return>
        NicIpConfiguration.UpdateDefinition.IWithAttach<NetworkInterface.Update.IUpdate> HasPublicIpAddress.UpdateDefinition.IWithNewPublicIpAddressNoDnsLabel<NicIpConfiguration.UpdateDefinition.IWithAttach<NetworkInterface.Update.IUpdate>>.WithNewPublicIpAddress(ICreatable<Microsoft.Azure.Management.Network.Fluent.IPublicIpAddress> creatable)
        {
            return this.WithNewPublicIpAddress(creatable) as NicIpConfiguration.UpdateDefinition.IWithAttach<NetworkInterface.Update.IUpdate>;
        }

        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource and associates it with the resource.
        /// The internal name and DNS label for the public IP address will be derived from the resource's name.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        NicIpConfiguration.UpdateDefinition.IWithAttach<NetworkInterface.Update.IUpdate> HasPublicIpAddress.UpdateDefinition.IWithNewPublicIpAddressNoDnsLabel<NicIpConfiguration.UpdateDefinition.IWithAttach<NetworkInterface.Update.IUpdate>>.WithNewPublicIpAddress()
        {
            return this.WithNewPublicIpAddress() as NicIpConfiguration.UpdateDefinition.IWithAttach<NetworkInterface.Update.IUpdate>;
        }

        /// <summary>
        /// Creates a new public IP address to associate with the resource.
        /// </summary>
        /// <param name="creatable">A creatable definition for a new public IP.</param>
        /// <return>The next stage of the definition.</return>
        NicIpConfiguration.Definition.IWithAttach<NetworkInterface.Definition.IWithCreate> HasPublicIpAddress.Definition.IWithNewPublicIpAddressNoDnsLabel<NicIpConfiguration.Definition.IWithAttach<NetworkInterface.Definition.IWithCreate>>.WithNewPublicIpAddress(ICreatable<Microsoft.Azure.Management.Network.Fluent.IPublicIpAddress> creatable)
        {
            return this.WithNewPublicIpAddress(creatable) as NicIpConfiguration.Definition.IWithAttach<NetworkInterface.Definition.IWithCreate>;
        }

        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource and associates it with the resource.
        /// The internal name and DNS label for the public IP address will be derived from the resource's name.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        NicIpConfiguration.Definition.IWithAttach<NetworkInterface.Definition.IWithCreate> HasPublicIpAddress.Definition.IWithNewPublicIpAddressNoDnsLabel<NicIpConfiguration.Definition.IWithAttach<NetworkInterface.Definition.IWithCreate>>.WithNewPublicIpAddress()
        {
            return this.WithNewPublicIpAddress() as NicIpConfiguration.Definition.IWithAttach<NetworkInterface.Definition.IWithCreate>;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource update.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        NetworkInterface.Update.IUpdate Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Update.IInUpdate<NetworkInterface.Update.IUpdate>.Attach()
        {
            return this.Attach() as NetworkInterface.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the IP version for the private IP address.
        /// </summary>
        /// <param name="ipVersion">An IP version.</param>
        /// <return>The next stage of the update.</return>
        NicIpConfiguration.Update.IUpdate NicIpConfiguration.Update.IWithPrivateIp.WithPrivateIpVersion(string ipVersion)
        {
            return this.WithPrivateIpVersion(ipVersion) as NicIpConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the load balancer inbound NAT rule to associate this IP configuration with.
        /// </summary>
        /// <param name="loadBalancer">An existing load balancer.</param>
        /// <param name="inboundNatRuleName">The name of an existing inbound NAT rule on the selected load balancer.</param>
        /// <return>The next stage of the update.</return>
        NicIpConfiguration.Definition.IWithAttach<NetworkInterface.Definition.IWithCreate> NicIpConfiguration.Definition.IWithLoadBalancer<NetworkInterface.Definition.IWithCreate>.WithExistingLoadBalancerInboundNatRule(ILoadBalancer loadBalancer, string inboundNatRuleName)
        {
            return this.WithExistingLoadBalancerInboundNatRule(loadBalancer, inboundNatRuleName) as NicIpConfiguration.Definition.IWithAttach<NetworkInterface.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the load balancer backend to associate this IP configuration with.
        /// </summary>
        /// <param name="loadBalancer">An existing load balancer.</param>
        /// <param name="backendName">The name of an existing backend on that load balancer.</param>
        /// <return>The next stage of the update.</return>
        NicIpConfiguration.Definition.IWithAttach<NetworkInterface.Definition.IWithCreate> NicIpConfiguration.Definition.IWithLoadBalancer<NetworkInterface.Definition.IWithCreate>.WithExistingLoadBalancerBackend(ILoadBalancer loadBalancer, string backendName)
        {
            return this.WithExistingLoadBalancerBackend(loadBalancer, backendName) as NicIpConfiguration.Definition.IWithAttach<NetworkInterface.Definition.IWithCreate>;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        NetworkInterface.Definition.IWithCreate Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Definition.IInDefinition<NetworkInterface.Definition.IWithCreate>.Attach()
        {
            return this.Attach() as NetworkInterface.Definition.IWithCreate;
        }

        /// <summary>
        /// Removes the existing reference to a public IP address.
        /// </summary>
        /// <return>The next stage of the update.</return>
        NicIpConfiguration.Update.IUpdate HasPublicIpAddress.Update.IWithExistingPublicIpAddress<NicIpConfiguration.Update.IUpdate>.WithoutPublicIpAddress()
        {
            return this.WithoutPublicIpAddress() as NicIpConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Associates an existing public IP address with the resource.
        /// </summary>
        /// <param name="publicIpAddress">An existing public IP address.</param>
        /// <return>The next stage of the update.</return>
        NicIpConfiguration.Update.IUpdate HasPublicIpAddress.Update.IWithExistingPublicIpAddress<NicIpConfiguration.Update.IUpdate>.WithExistingPublicIpAddress(IPublicIpAddress publicIpAddress)
        {
            return this.WithExistingPublicIpAddress(publicIpAddress) as NicIpConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Associates an existing public IP address with the resource.
        /// </summary>
        /// <param name="resourceId">The resource ID of an existing public IP address.</param>
        /// <return>The next stage of the definition.</return>
        NicIpConfiguration.Update.IUpdate HasPublicIpAddress.Update.IWithExistingPublicIpAddress<NicIpConfiguration.Update.IUpdate>.WithExistingPublicIpAddress(string resourceId)
        {
            return this.WithExistingPublicIpAddress(resourceId) as NicIpConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Associates an existing public IP address with the resource.
        /// </summary>
        /// <param name="publicIpAddress">An existing public IP address.</param>
        /// <return>The next stage of the definition.</return>
        NicIpConfiguration.UpdateDefinition.IWithAttach<NetworkInterface.Update.IUpdate> HasPublicIpAddress.UpdateDefinition.IWithExistingPublicIpAddress<NicIpConfiguration.UpdateDefinition.IWithAttach<NetworkInterface.Update.IUpdate>>.WithExistingPublicIpAddress(IPublicIpAddress publicIpAddress)
        {
            return this.WithExistingPublicIpAddress(publicIpAddress) as NicIpConfiguration.UpdateDefinition.IWithAttach<NetworkInterface.Update.IUpdate>;
        }

        /// <summary>
        /// Associates an existing public IP address with the resource.
        /// </summary>
        /// <param name="resourceId">The resource ID of an existing public IP address.</param>
        /// <return>The next stage of the definition.</return>
        NicIpConfiguration.UpdateDefinition.IWithAttach<NetworkInterface.Update.IUpdate> HasPublicIpAddress.UpdateDefinition.IWithExistingPublicIpAddress<NicIpConfiguration.UpdateDefinition.IWithAttach<NetworkInterface.Update.IUpdate>>.WithExistingPublicIpAddress(string resourceId)
        {
            return this.WithExistingPublicIpAddress(resourceId) as NicIpConfiguration.UpdateDefinition.IWithAttach<NetworkInterface.Update.IUpdate>;
        }

        /// <summary>
        /// Associates an existing public IP address with the resource.
        /// </summary>
        /// <param name="publicIpAddress">An existing public IP address.</param>
        /// <return>The next stage of the definition.</return>
        NicIpConfiguration.Definition.IWithAttach<NetworkInterface.Definition.IWithCreate> HasPublicIpAddress.Definition.IWithExistingPublicIpAddress<NicIpConfiguration.Definition.IWithAttach<NetworkInterface.Definition.IWithCreate>>.WithExistingPublicIpAddress(IPublicIpAddress publicIpAddress)
        {
            return this.WithExistingPublicIpAddress(publicIpAddress) as NicIpConfiguration.Definition.IWithAttach<NetworkInterface.Definition.IWithCreate>;
        }

        /// <summary>
        /// Associates an existing public IP address with the resource.
        /// </summary>
        /// <param name="resourceId">The resource ID of an existing public IP address.</param>
        /// <return>The next stage of the definition.</return>
        NicIpConfiguration.Definition.IWithAttach<NetworkInterface.Definition.IWithCreate> HasPublicIpAddress.Definition.IWithExistingPublicIpAddress<NicIpConfiguration.Definition.IWithAttach<NetworkInterface.Definition.IWithCreate>>.WithExistingPublicIpAddress(string resourceId)
        {
            return this.WithExistingPublicIpAddress(resourceId) as NicIpConfiguration.Definition.IWithAttach<NetworkInterface.Definition.IWithCreate>;
        }

        /// <summary>
        /// Gets the resource ID of the associated public IP address.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IHasPublicIpAddress.PublicIpAddressId
        {
            get
            {
                return this.PublicIpAddressId();
            }
        }

        /// <return>The associated public IP address.</return>
        Microsoft.Azure.Management.Network.Fluent.IPublicIpAddress Microsoft.Azure.Management.Network.Fluent.IHasPublicIpAddress.GetPublicIpAddress()
        {
            return this.GetPublicIpAddress() as Microsoft.Azure.Management.Network.Fluent.IPublicIpAddress;
        }

        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource, with the specified DNS label
        /// and associates it with the resource.
        /// The internal name for the public IP address will be derived from the DNS label.
        /// </summary>
        /// <param name="leafDnsLabel">The leaf domain label.</param>
        /// <return>The next stage of the definition.</return>
        NicIpConfiguration.Update.IUpdate HasPublicIpAddress.Update.IWithNewPublicIpAddress<NicIpConfiguration.Update.IUpdate>.WithNewPublicIpAddress(string leafDnsLabel)
        {
            return this.WithNewPublicIpAddress(leafDnsLabel) as NicIpConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource, with the specified DNS label
        /// and associates it with the resource.
        /// The internal name for the public IP address will be derived from the DNS label.
        /// </summary>
        /// <param name="leafDnsLabel">The leaf domain label.</param>
        /// <return>The next stage of the definition.</return>
        NicIpConfiguration.UpdateDefinition.IWithAttach<NetworkInterface.Update.IUpdate> HasPublicIpAddress.UpdateDefinition.IWithNewPublicIpAddress<NicIpConfiguration.UpdateDefinition.IWithAttach<NetworkInterface.Update.IUpdate>>.WithNewPublicIpAddress(string leafDnsLabel)
        {
            return this.WithNewPublicIpAddress(leafDnsLabel) as NicIpConfiguration.UpdateDefinition.IWithAttach<NetworkInterface.Update.IUpdate>;
        }

        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource, with the specified DNS label
        /// and associates it with the resource.
        /// The internal name for the public IP address will be derived from the DNS label.
        /// </summary>
        /// <param name="leafDnsLabel">The leaf domain label.</param>
        /// <return>The next stage of the definition.</return>
        NicIpConfiguration.Definition.IWithAttach<NetworkInterface.Definition.IWithCreate> HasPublicIpAddress.Definition.IWithNewPublicIpAddress<NicIpConfiguration.Definition.IWithAttach<NetworkInterface.Definition.IWithCreate>>.WithNewPublicIpAddress(string leafDnsLabel)
        {
            return this.WithNewPublicIpAddress(leafDnsLabel) as NicIpConfiguration.Definition.IWithAttach<NetworkInterface.Definition.IWithCreate>;
        }

        /// <summary>
        /// Associate a subnet with the network interface IP configuration.
        /// </summary>
        /// <param name="name">The subnet name.</param>
        /// <return>The next stage of the network interface IP configuration update.</return>
        NicIpConfiguration.Update.IUpdate NicIpConfiguration.Update.IWithSubnet.WithSubnet(string name)
        {
            return this.WithSubnet(name) as NicIpConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Gets the name of the resource.
        /// </summary>
        string Microsoft.Azure.Management.Resource.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name();
            }
        }

        /// <summary>
        /// Create a new virtual network to associate with the  network interface IP configuration,
        /// based on the provided definition.
        /// </summary>
        /// <param name="creatable">A creatable definition for a new virtual network.</param>
        /// <return>The next stage of the network interface IP configuration definition.</return>
        NicIpConfiguration.UpdateDefinition.IWithPrivateIp<NetworkInterface.Update.IUpdate> NicIpConfiguration.UpdateDefinition.IWithNetwork<NetworkInterface.Update.IUpdate>.WithNewNetwork(ICreatable<Microsoft.Azure.Management.Network.Fluent.INetwork> creatable)
        {
            return this.WithNewNetwork(creatable) as NicIpConfiguration.UpdateDefinition.IWithPrivateIp<NetworkInterface.Update.IUpdate>;
        }

        /// <summary>
        /// Creates a new virtual network to associate with the network interface IP configuration.
        /// the virtual network will be created in the same resource group and region as of parent
        /// network interface, it will be created with the specified address space and a default subnet
        /// covering the entirety of the network IP address space.
        /// </summary>
        /// <param name="name">The name of the new virtual network.</param>
        /// <param name="addressSpace">The address space for rhe virtual network.</param>
        /// <return>The next stage of the network interface IP configuration definition.</return>
        NicIpConfiguration.UpdateDefinition.IWithPrivateIp<NetworkInterface.Update.IUpdate> NicIpConfiguration.UpdateDefinition.IWithNetwork<NetworkInterface.Update.IUpdate>.WithNewNetwork(string name, string addressSpace)
        {
            return this.WithNewNetwork(name, addressSpace) as NicIpConfiguration.UpdateDefinition.IWithPrivateIp<NetworkInterface.Update.IUpdate>;
        }

        /// <summary>
        /// Creates a new virtual network to associate with the network interface IP configuration.
        /// the virtual network will be created in the same resource group and region as of parent network interface,
        /// it will be created with the specified address space and a default subnet covering the entirety of the
        /// network IP address space.
        /// </summary>
        /// <param name="addressSpace">The address space for the virtual network.</param>
        /// <return>The next stage of the network interface IP configuration definition.</return>
        NicIpConfiguration.UpdateDefinition.IWithPrivateIp<NetworkInterface.Update.IUpdate> NicIpConfiguration.UpdateDefinition.IWithNetwork<NetworkInterface.Update.IUpdate>.WithNewNetwork(string addressSpace)
        {
            return this.WithNewNetwork(addressSpace) as NicIpConfiguration.UpdateDefinition.IWithPrivateIp<NetworkInterface.Update.IUpdate>;
        }

        /// <summary>
        /// Associate an existing virtual network with the network interface IP configuration.
        /// </summary>
        /// <param name="network">An existing virtual network.</param>
        /// <return>The next stage of the network interface IP configuration definition.</return>
        NicIpConfiguration.UpdateDefinition.IWithSubnet<NetworkInterface.Update.IUpdate> NicIpConfiguration.UpdateDefinition.IWithNetwork<NetworkInterface.Update.IUpdate>.WithExistingNetwork(INetwork network)
        {
            return this.WithExistingNetwork(network) as NicIpConfiguration.UpdateDefinition.IWithSubnet<NetworkInterface.Update.IUpdate>;
        }

        /// <summary>
        /// Create a new virtual network to associate with the  network interface IP configuration,
        /// based on the provided definition.
        /// </summary>
        /// <param name="creatable">A creatable definition for a new virtual network.</param>
        /// <return>The next stage of the network interface IP configuration definition.</return>
        NicIpConfiguration.Definition.IWithPrivateIp<NetworkInterface.Definition.IWithCreate> NicIpConfiguration.Definition.IWithNetwork<NetworkInterface.Definition.IWithCreate>.WithNewNetwork(ICreatable<Microsoft.Azure.Management.Network.Fluent.INetwork> creatable)
        {
            return this.WithNewNetwork(creatable) as NicIpConfiguration.Definition.IWithPrivateIp<NetworkInterface.Definition.IWithCreate>;
        }

        /// <summary>
        /// Creates a new virtual network to associate with the network interface IP configuration.
        /// the virtual network will be created in the same resource group and region as of parent
        /// network interface, it will be created with the specified address space and a default subnet
        /// covering the entirety of the network IP address space.
        /// </summary>
        /// <param name="name">The name of the new virtual network.</param>
        /// <param name="addressSpace">The address space for rhe virtual network.</param>
        /// <return>The next stage of the network interface IP configuration definition.</return>
        NicIpConfiguration.Definition.IWithPrivateIp<NetworkInterface.Definition.IWithCreate> NicIpConfiguration.Definition.IWithNetwork<NetworkInterface.Definition.IWithCreate>.WithNewNetwork(string name, string addressSpace)
        {
            return this.WithNewNetwork(name, addressSpace) as NicIpConfiguration.Definition.IWithPrivateIp<NetworkInterface.Definition.IWithCreate>;
        }

        /// <summary>
        /// Creates a new virtual network to associate with the network interface IP configuration.
        /// the virtual network will be created in the same resource group and region as of parent network interface,
        /// it will be created with the specified address space and a default subnet covering the entirety of the
        /// network IP address space.
        /// </summary>
        /// <param name="addressSpace">The address space for the virtual network.</param>
        /// <return>The next stage of the network interface IP configuration definition.</return>
        NicIpConfiguration.Definition.IWithPrivateIp<NetworkInterface.Definition.IWithCreate> NicIpConfiguration.Definition.IWithNetwork<NetworkInterface.Definition.IWithCreate>.WithNewNetwork(string addressSpace)
        {
            return this.WithNewNetwork(addressSpace) as NicIpConfiguration.Definition.IWithPrivateIp<NetworkInterface.Definition.IWithCreate>;
        }

        /// <summary>
        /// Associate an existing virtual network with the network interface IP configuration.
        /// </summary>
        /// <param name="network">An existing virtual network.</param>
        /// <return>The next stage of the network interface IP configuration definition.</return>
        NicIpConfiguration.Definition.IWithSubnet<NetworkInterface.Definition.IWithCreate> NicIpConfiguration.Definition.IWithNetwork<NetworkInterface.Definition.IWithCreate>.WithExistingNetwork(INetwork network)
        {
            return this.WithExistingNetwork(network) as NicIpConfiguration.Definition.IWithSubnet<NetworkInterface.Definition.IWithCreate>;
        }
    }
}