// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Fluent.Network
{

    using Microsoft.Azure.Management.Fluent.Network.HasPublicIpAddress.Update;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Fluent.Resource.Core.ResourceActions;
    using Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Update;
    using Microsoft.Azure.Management.Fluent.Resource.Core.ChildResource.Update;
    using Microsoft.Azure.Management.Fluent.Network.HasPublicIpAddress.Definition;
    using Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.UpdateDefinition;
    using Microsoft.Azure.Management.Fluent.Network.HasPublicIpAddress.UpdateDefinition;
    using Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Definition;
    using Microsoft.Azure;
    using Microsoft.Azure.Management.Fluent.Network.HasPrivateIpAddress.Definition;
    using Microsoft.Azure.Management.Fluent.Resource.Core;
    using Microsoft.Azure.Management.Fluent.Network.HasPrivateIpAddress.Update;
    using Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Definition;
    using Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Update;
    using Microsoft.Azure.Management.Fluent.Resource.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.Fluent.Network.HasPrivateIpAddress.UpdateDefinition;
    public partial class NicIpConfigurationImpl 
    {
        /// <summary>
        /// Creates a new public IP address to associate with the resource, based on the provided definition.
        /// </summary>
        /// <param name="creatable">creatable a creatable definition for a new public IP address</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Update.IUpdate Microsoft.Azure.Management.Fluent.Network.HasPublicIpAddress.Update.IWithNewPublicIpAddress<Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Update.IUpdate>.WithNewPublicIpAddress(ICreatable<Microsoft.Azure.Management.Fluent.Network.IPublicIpAddress> creatable) { 
            return this.WithNewPublicIpAddress( creatable) as Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource and associates it with the resource.
        /// <p>
        /// The internal name and DNS label for the public IP address will be derived from the resource's name.
        /// </summary>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Update.IUpdate Microsoft.Azure.Management.Fluent.Network.HasPublicIpAddress.Update.IWithNewPublicIpAddress<Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Update.IUpdate>.WithNewPublicIpAddress() { 
            return this.WithNewPublicIpAddress() as Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource, with the specified DNS label
        /// and associates it with the resource.
        /// <p>
        /// The internal name for the public IP address will be derived from the DNS label.
        /// </summary>
        /// <param name="leafDnsLabel">leafDnsLabel the leaf domain label</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Update.IUpdate Microsoft.Azure.Management.Fluent.Network.HasPublicIpAddress.Update.IWithNewPublicIpAddress<Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Update.IUpdate>.WithNewPublicIpAddress(string leafDnsLabel) { 
            return this.WithNewPublicIpAddress( leafDnsLabel) as Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Creates a new public IP address to associate with the resource, based on the provided definition.
        /// </summary>
        /// <param name="creatable">creatable a creatable definition for a new public IP address</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Update.IUpdate> Microsoft.Azure.Management.Fluent.Network.HasPublicIpAddress.UpdateDefinition.IWithNewPublicIpAddress<Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Update.IUpdate>>.WithNewPublicIpAddress(ICreatable<Microsoft.Azure.Management.Fluent.Network.IPublicIpAddress> creatable) { 
            return this.WithNewPublicIpAddress( creatable) as Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Update.IUpdate>;
        }

        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource and associates it with the resource.
        /// <p>
        /// The internal name and DNS label for the public IP address will be derived from the resource's name.
        /// </summary>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Update.IUpdate> Microsoft.Azure.Management.Fluent.Network.HasPublicIpAddress.UpdateDefinition.IWithNewPublicIpAddress<Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Update.IUpdate>>.WithNewPublicIpAddress() { 
            return this.WithNewPublicIpAddress() as Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Update.IUpdate>;
        }

        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource, with the specified DNS label
        /// and associates it with the resource.
        /// <p>
        /// The internal name for the public IP address will be derived from the DNS label.
        /// </summary>
        /// <param name="leafDnsLabel">leafDnsLabel the leaf domain label</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Update.IUpdate> Microsoft.Azure.Management.Fluent.Network.HasPublicIpAddress.UpdateDefinition.IWithNewPublicIpAddress<Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Update.IUpdate>>.WithNewPublicIpAddress(string leafDnsLabel) { 
            return this.WithNewPublicIpAddress( leafDnsLabel) as Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Update.IUpdate>;
        }

        /// <summary>
        /// Creates a new public IP address to associate with the resource.
        /// </summary>
        /// <param name="creatable">creatable a creatable definition for a new public IP</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Definition.IWithCreate> Microsoft.Azure.Management.Fluent.Network.HasPublicIpAddress.Definition.IWithNewPublicIpAddress<Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Definition.IWithCreate>>.WithNewPublicIpAddress(ICreatable<Microsoft.Azure.Management.Fluent.Network.IPublicIpAddress> creatable) { 
            return this.WithNewPublicIpAddress( creatable) as Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Definition.IWithCreate>;
        }

        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource and associates it with the resource.
        /// <p>
        /// The internal name and DNS label for the public IP address will be derived from the resource's name.
        /// </summary>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Definition.IWithCreate> Microsoft.Azure.Management.Fluent.Network.HasPublicIpAddress.Definition.IWithNewPublicIpAddress<Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Definition.IWithCreate>>.WithNewPublicIpAddress() { 
            return this.WithNewPublicIpAddress() as Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Definition.IWithCreate>;
        }

        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource, with the specified DNS label
        /// and associates it with the resource.
        /// <p>
        /// The internal name for the public IP address will be derived from the DNS label.
        /// </summary>
        /// <param name="leafDnsLabel">leafDnsLabel the leaf domain label</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Definition.IWithCreate> Microsoft.Azure.Management.Fluent.Network.HasPublicIpAddress.Definition.IWithNewPublicIpAddress<Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Definition.IWithCreate>>.WithNewPublicIpAddress(string leafDnsLabel) { 
            return this.WithNewPublicIpAddress( leafDnsLabel) as Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the IP version for the private IP address.
        /// </summary>
        /// <param name="ipVersion">ipVersion an IP version</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Update.IUpdate> Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.UpdateDefinition.IWithPrivateIp<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Update.IUpdate>.WithPrivateIpVersion(string ipVersion) { 
            return this.WithPrivateIpVersion( ipVersion) as Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the IP version for the private IP address.
        /// </summary>
        /// <param name="ipVersion">ipVersion an IP version</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Definition.IWithCreate> Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Definition.IWithPrivateIp<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Definition.IWithCreate>.WithPrivateIpVersion(string ipVersion) { 
            return this.WithPrivateIpVersion( ipVersion) as Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Definition.IWithCreate>;
        }

        /// <summary>
        /// Create a new virtual network to associate with the  network interface IP configuration,
        /// based on the provided definition.
        /// </summary>
        /// <param name="creatable">creatable a creatable definition for a new virtual network</param>
        /// <returns>the next stage of the network interface IP configuration definition</returns>
        Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.UpdateDefinition.IWithPrivateIp<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Update.IUpdate> Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.UpdateDefinition.IWithNetwork<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Update.IUpdate>.WithNewNetwork(ICreatable<Microsoft.Azure.Management.Fluent.Network.INetwork> creatable) { 
            return this.WithNewNetwork( creatable) as Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.UpdateDefinition.IWithPrivateIp<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Update.IUpdate>;
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
        Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.UpdateDefinition.IWithPrivateIp<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Update.IUpdate> Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.UpdateDefinition.IWithNetwork<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Update.IUpdate>.WithNewNetwork(string name, string addressSpace) { 
            return this.WithNewNetwork( name,  addressSpace) as Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.UpdateDefinition.IWithPrivateIp<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Update.IUpdate>;
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
        Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.UpdateDefinition.IWithPrivateIp<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Update.IUpdate> Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.UpdateDefinition.IWithNetwork<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Update.IUpdate>.WithNewNetwork(string addressSpace) { 
            return this.WithNewNetwork( addressSpace) as Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.UpdateDefinition.IWithPrivateIp<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Update.IUpdate>;
        }

        /// <summary>
        /// Associate an existing virtual network with the network interface IP configuration.
        /// </summary>
        /// <param name="network">network an existing virtual network</param>
        /// <returns>the next stage of the network interface IP configuration definition</returns>
        Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.UpdateDefinition.IWithSubnet<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Update.IUpdate> Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.UpdateDefinition.IWithNetwork<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Update.IUpdate>.WithExistingNetwork(INetwork network) { 
            return this.WithExistingNetwork( network) as Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.UpdateDefinition.IWithSubnet<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Update.IUpdate>;
        }

        /// <summary>
        /// Create a new virtual network to associate with the  network interface IP configuration,
        /// based on the provided definition.
        /// </summary>
        /// <param name="creatable">creatable a creatable definition for a new virtual network</param>
        /// <returns>the next stage of the network interface IP configuration definition</returns>
        Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Definition.IWithPrivateIp<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Definition.IWithCreate> Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Definition.IWithNetwork<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Definition.IWithCreate>.WithNewNetwork(ICreatable<Microsoft.Azure.Management.Fluent.Network.INetwork> creatable) { 
            return this.WithNewNetwork( creatable) as Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Definition.IWithPrivateIp<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Definition.IWithCreate>;
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
        Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Definition.IWithPrivateIp<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Definition.IWithCreate> Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Definition.IWithNetwork<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Definition.IWithCreate>.WithNewNetwork(string name, string addressSpace) { 
            return this.WithNewNetwork( name,  addressSpace) as Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Definition.IWithPrivateIp<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Definition.IWithCreate>;
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
        Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Definition.IWithPrivateIp<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Definition.IWithCreate> Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Definition.IWithNetwork<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Definition.IWithCreate>.WithNewNetwork(string addressSpace) { 
            return this.WithNewNetwork( addressSpace) as Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Definition.IWithPrivateIp<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Definition.IWithCreate>;
        }

        /// <summary>
        /// Associate an existing virtual network with the network interface IP configuration.
        /// </summary>
        /// <param name="network">network an existing virtual network</param>
        /// <returns>the next stage of the network interface IP configuration definition</returns>
        Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Definition.IWithSubnet<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Definition.IWithCreate> Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Definition.IWithNetwork<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Definition.IWithCreate>.WithExistingNetwork(INetwork network) { 
            return this.WithExistingNetwork( network) as Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Definition.IWithSubnet<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Definition.IWithCreate>;
        }

        /// <returns>the resource ID of the associated public IP address</returns>
        string Microsoft.Azure.Management.Fluent.Network.IHasPublicIpAddress.PublicIpAddressId
        {
            get
            { 
            return this.PublicIpAddressId() as string;
            }
        }
        /// <returns>the associated public IP address</returns>
        Microsoft.Azure.Management.Fluent.Network.IPublicIpAddress Microsoft.Azure.Management.Fluent.Network.IHasPublicIpAddress.GetPublicIpAddress() { 
            return this.GetPublicIpAddress() as Microsoft.Azure.Management.Fluent.Network.IPublicIpAddress;
        }

        /// <returns>the load balancer inbound NAT rules associated with this network interface IP configuration</returns>
        System.Collections.Generic.IList<Microsoft.Azure.Management.Fluent.Network.IInboundNatRule> Microsoft.Azure.Management.Fluent.Network.INicIpConfiguration.ListAssociatedLoadBalancerInboundNatRules() { 
            return this.ListAssociatedLoadBalancerInboundNatRules() as System.Collections.Generic.IList<Microsoft.Azure.Management.Fluent.Network.IInboundNatRule>;
        }

        /// <returns>the load balancer backends associated with this network interface IP configuration</returns>
        System.Collections.Generic.IList<Microsoft.Azure.Management.Fluent.Network.IBackend> Microsoft.Azure.Management.Fluent.Network.INicIpConfiguration.ListAssociatedLoadBalancerBackends() { 
            return this.ListAssociatedLoadBalancerBackends() as System.Collections.Generic.IList<Microsoft.Azure.Management.Fluent.Network.IBackend>;
        }

        /// <returns>the virtual network associated with this IP configuration</returns>
        Microsoft.Azure.Management.Fluent.Network.INetwork Microsoft.Azure.Management.Fluent.Network.INicIpConfiguration.GetNetwork() { 
            return this.GetNetwork() as Microsoft.Azure.Management.Fluent.Network.INetwork;
        }

        /// <returns>private IP address version</returns>
        string Microsoft.Azure.Management.Fluent.Network.INicIpConfiguration.PrivateIpAddressVersion
        {
            get
            { 
            return this.PrivateIpAddressVersion() as string;
            }
        }
        /// <summary>
        /// Attaches the child definition to the parent resource update.
        /// </summary>
        /// <returns>the next stage of the parent definition</returns>
        Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Update.IUpdate Microsoft.Azure.Management.Fluent.Resource.Core.ChildResource.Update.IInUpdate<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Update.IUpdate>.Attach() { 
            return this.Attach() as Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Update.IUpdate;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <returns>the next stage of the parent definition</returns>
        Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Definition.IWithCreate Microsoft.Azure.Management.Fluent.Resource.Core.ChildResource.Definition.IInDefinition<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Definition.IWithCreate>.Attach() { 
            return this.Attach() as Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Definition.IWithCreate;
        }

        /// <summary>
        /// Removes all the existing associations with load balancer backends.
        /// </summary>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Update.IUpdate Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Update.IWithLoadBalancer.WithoutLoadBalancerBackends() { 
            return this.WithoutLoadBalancerBackends() as Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Removes all the existing associations with load balancer inbound NAT rules.
        /// </summary>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Update.IUpdate Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Update.IWithLoadBalancer.WithoutLoadBalancerInboundNatRules() { 
            return this.WithoutLoadBalancerInboundNatRules() as Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the load balancer inbound NAT rule to associate this IP configuration with.
        /// </summary>
        /// <param name="loadBalancer">loadBalancer an existing load balancer</param>
        /// <param name="inboundNatRuleName">inboundNatRuleName the name of an existing inbound NAT rule on the selected load balancer</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Update.IUpdate Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Update.IWithLoadBalancer.WithExistingLoadBalancerInboundNatRule(ILoadBalancer loadBalancer, string inboundNatRuleName) { 
            return this.WithExistingLoadBalancerInboundNatRule( loadBalancer,  inboundNatRuleName) as Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the load balancer to associate this IP configuration with.
        /// </summary>
        /// <param name="loadBalancer">loadBalancer an existing load balancer</param>
        /// <param name="backendName">backendName the name of an existing backend on that load balancer</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Update.IUpdate Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Update.IWithLoadBalancer.WithExistingLoadBalancerBackend(ILoadBalancer loadBalancer, string backendName) { 
            return this.WithExistingLoadBalancerBackend( loadBalancer,  backendName) as Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Assigns the specified static private IP address within the associated subnet.
        /// </summary>
        /// <param name="ipAddress">ipAddress a static IP address within the associated private IP range</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Update.IUpdate Microsoft.Azure.Management.Fluent.Network.HasPrivateIpAddress.Update.IWithPrivateIpAddress<Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Update.IUpdate>.WithPrivateIpAddressStatic(string ipAddress) { 
            return this.WithPrivateIpAddressStatic( ipAddress) as Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Enables dynamic private IP address allocation within the associated subnet.
        /// </summary>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Update.IUpdate Microsoft.Azure.Management.Fluent.Network.HasPrivateIpAddress.Update.IWithPrivateIpAddress<Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Update.IUpdate>.WithPrivateIpAddressDynamic() { 
            return this.WithPrivateIpAddressDynamic() as Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Assigns the specified static private IP address within the associated subnet.
        /// </summary>
        /// <param name="ipAddress">ipAddress a static IP address within the associated private IP range</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Update.IUpdate> Microsoft.Azure.Management.Fluent.Network.HasPrivateIpAddress.UpdateDefinition.IWithPrivateIpAddress<Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Update.IUpdate>>.WithPrivateIpAddressStatic(string ipAddress) { 
            return this.WithPrivateIpAddressStatic( ipAddress) as Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Update.IUpdate>;
        }

        /// <summary>
        /// Enables dynamic private IP address allocation within the associated subnet.
        /// </summary>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Update.IUpdate> Microsoft.Azure.Management.Fluent.Network.HasPrivateIpAddress.UpdateDefinition.IWithPrivateIpAddress<Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Update.IUpdate>>.WithPrivateIpAddressDynamic() { 
            return this.WithPrivateIpAddressDynamic() as Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Update.IUpdate>;
        }

        /// <summary>
        /// Assigns the specified static private IP address within the associated subnet.
        /// </summary>
        /// <param name="ipAddress">ipAddress a static IP address within the associated private IP range</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Definition.IWithCreate> Microsoft.Azure.Management.Fluent.Network.HasPrivateIpAddress.Definition.IWithPrivateIpAddress<Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Definition.IWithCreate>>.WithPrivateIpAddressStatic(string ipAddress) { 
            return this.WithPrivateIpAddressStatic( ipAddress) as Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Definition.IWithCreate>;
        }

        /// <summary>
        /// Enables dynamic private IP address allocation within the associated subnet.
        /// </summary>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Definition.IWithCreate> Microsoft.Azure.Management.Fluent.Network.HasPrivateIpAddress.Definition.IWithPrivateIpAddress<Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Definition.IWithCreate>>.WithPrivateIpAddressDynamic() { 
            return this.WithPrivateIpAddressDynamic() as Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the load balancer inbound NAT rule to associate this IP configuration with.
        /// </summary>
        /// <param name="loadBalancer">loadBalancer an existing load balancer</param>
        /// <param name="inboundNatRuleName">inboundNatRuleName the name of an existing inbound NAT rule on the selected load balancer</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Definition.IWithCreate> Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Definition.IWithLoadBalancer<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Definition.IWithCreate>.WithExistingLoadBalancerInboundNatRule(ILoadBalancer loadBalancer, string inboundNatRuleName) { 
            return this.WithExistingLoadBalancerInboundNatRule( loadBalancer,  inboundNatRuleName) as Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the load balancer backend to associate this IP configuration with.
        /// </summary>
        /// <param name="loadBalancer">loadBalancer an existing load balancer</param>
        /// <param name="backendName">backendName the name of an existing backend on that load balancer</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Definition.IWithCreate> Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Definition.IWithLoadBalancer<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Definition.IWithCreate>.WithExistingLoadBalancerBackend(ILoadBalancer loadBalancer, string backendName) { 
            return this.WithExistingLoadBalancerBackend( loadBalancer,  backendName) as Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Definition.IWithCreate>;
        }

        /// <returns>the name of the subnet associated with this resource</returns>
        string Microsoft.Azure.Management.Fluent.Resource.Core.IHasSubnet.SubnetName
        {
            get
            { 
            return this.SubnetName() as string;
            }
        }
        /// <returns>the resource ID of the virtual network whose subnet is associated with this resource</returns>
        string Microsoft.Azure.Management.Fluent.Resource.Core.IHasSubnet.NetworkId
        {
            get
            { 
            return this.NetworkId() as string;
            }
        }
        /// <returns>the private IP address associated with this resource</returns>
        string Microsoft.Azure.Management.Fluent.Network.IHasPrivateIpAddress.PrivateIpAddress
        {
            get
            { 
            return this.PrivateIpAddress() as string;
            }
        }
        /// <returns>the private IP address allocation method within the associated subnet</returns>
        string Microsoft.Azure.Management.Fluent.Network.IHasPrivateIpAddress.PrivateIpAllocationMethod
        {
            get
            { 
            return this.PrivateIpAllocationMethod() as string;
            }
        }
        /// <summary>
        /// Specifies the IP version for the private IP address.
        /// </summary>
        /// <param name="ipVersion">ipVersion an IP version</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Update.IUpdate Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Update.IWithPrivateIp.WithPrivateIpVersion(string ipVersion) { 
            return this.WithPrivateIpVersion( ipVersion) as Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Removes the existing reference to a public IP address.
        /// </summary>
        /// <returns>the next stage of the update.</returns>
        Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Update.IUpdate Microsoft.Azure.Management.Fluent.Network.HasPublicIpAddress.Update.IWithExistingPublicIpAddress<Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Update.IUpdate>.WithoutPublicIpAddress() { 
            return this.WithoutPublicIpAddress() as Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Associates an existing public IP address with the resource.
        /// </summary>
        /// <param name="publicIpAddress">publicIpAddress an existing public IP address</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Update.IUpdate Microsoft.Azure.Management.Fluent.Network.HasPublicIpAddress.Update.IWithExistingPublicIpAddress<Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Update.IUpdate>.WithExistingPublicIpAddress(IPublicIpAddress publicIpAddress) { 
            return this.WithExistingPublicIpAddress( publicIpAddress) as Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Associates an existing public IP address with the resource.
        /// </summary>
        /// <param name="resourceId">resourceId the resource ID of an existing public IP address</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Update.IUpdate Microsoft.Azure.Management.Fluent.Network.HasPublicIpAddress.Update.IWithExistingPublicIpAddress<Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Update.IUpdate>.WithExistingPublicIpAddress(string resourceId) { 
            return this.WithExistingPublicIpAddress( resourceId) as Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Associates an existing public IP address with the resource.
        /// </summary>
        /// <param name="publicIpAddress">publicIpAddress an existing public IP address</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Update.IUpdate> Microsoft.Azure.Management.Fluent.Network.HasPublicIpAddress.UpdateDefinition.IWithExistingPublicIpAddress<Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Update.IUpdate>>.WithExistingPublicIpAddress(IPublicIpAddress publicIpAddress) { 
            return this.WithExistingPublicIpAddress( publicIpAddress) as Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Update.IUpdate>;
        }

        /// <summary>
        /// Associates an existing public IP address with the resource.
        /// </summary>
        /// <param name="resourceId">resourceId the resource ID of an existing public IP address</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Update.IUpdate> Microsoft.Azure.Management.Fluent.Network.HasPublicIpAddress.UpdateDefinition.IWithExistingPublicIpAddress<Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Update.IUpdate>>.WithExistingPublicIpAddress(string resourceId) { 
            return this.WithExistingPublicIpAddress( resourceId) as Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Update.IUpdate>;
        }

        /// <summary>
        /// Associates an existing public IP address with the resource.
        /// </summary>
        /// <param name="publicIpAddress">publicIpAddress an existing public IP address</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Definition.IWithCreate> Microsoft.Azure.Management.Fluent.Network.HasPublicIpAddress.Definition.IWithExistingPublicIpAddress<Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Definition.IWithCreate>>.WithExistingPublicIpAddress(IPublicIpAddress publicIpAddress) { 
            return this.WithExistingPublicIpAddress( publicIpAddress) as Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Definition.IWithCreate>;
        }

        /// <summary>
        /// Associates an existing public IP address with the resource.
        /// </summary>
        /// <param name="resourceId">resourceId the resource ID of an existing public IP address</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Definition.IWithCreate> Microsoft.Azure.Management.Fluent.Network.HasPublicIpAddress.Definition.IWithExistingPublicIpAddress<Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Definition.IWithCreate>>.WithExistingPublicIpAddress(string resourceId) { 
            return this.WithExistingPublicIpAddress( resourceId) as Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Definition.IWithCreate>;
        }

        /// <summary>
        /// Associate a subnet with the network interface IP configuration.
        /// </summary>
        /// <param name="name">name the subnet name</param>
        /// <returns>the next stage of the network interface IP configuration definition</returns>
        Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.UpdateDefinition.IWithPrivateIp<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Update.IUpdate> Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.UpdateDefinition.IWithSubnet<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Update.IUpdate>.WithSubnet(string name) { 
            return this.WithSubnet( name) as Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.UpdateDefinition.IWithPrivateIp<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Update.IUpdate>;
        }

        /// <summary>
        /// Associate a subnet with the network interface IP configuration.
        /// </summary>
        /// <param name="name">name the subnet name</param>
        /// <returns>the next stage of the network interface IP configuration definition</returns>
        Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Definition.IWithPrivateIp<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Definition.IWithCreate> Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Definition.IWithSubnet<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Definition.IWithCreate>.WithSubnet(string name) { 
            return this.WithSubnet( name) as Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Definition.IWithPrivateIp<Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Definition.IWithCreate>;
        }

        /// <returns>the name of this child object</returns>
        string Microsoft.Azure.Management.Fluent.Resource.Core.IChildResource<Microsoft.Azure.Management.Fluent.Network.INetworkInterface>.Name
        {
            get
            { 
            return this.Name() as string;
            }
        }
        /// <summary>
        /// Associate a subnet with the network interface IP configuration.
        /// </summary>
        /// <param name="name">name the subnet name</param>
        /// <returns>the next stage of the network interface IP configuration update</returns>
        Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Update.IUpdate Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Update.IWithSubnet.WithSubnet(string name) { 
            return this.WithSubnet( name) as Microsoft.Azure.Management.Fluent.Network.NicIpConfiguration.Update.IUpdate;
        }

    }
}