// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Definition;
    using Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Update;
    using Microsoft.Azure.Management.Network.Fluent.NicIPConfiguration.Definition;
    using Microsoft.Azure.Management.Network.Fluent.NicIPConfiguration.Update;
    using Microsoft.Azure.Management.Network.Fluent.NicIPConfiguration.UpdateDefinition;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;

    internal partial class NetworkInterfaceImpl 
    {
        /// <summary>
        /// Disables accelerated networking.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        NetworkInterface.Update.IUpdate NetworkInterface.Update.IWithAcceleratedNetworkingBeta.WithoutAcceleratedNetworking()
        {
            return this.WithoutAcceleratedNetworking() as NetworkInterface.Update.IUpdate;
        }

        /// <summary>
        /// Enables accelerated networking.
        /// Note that additional steps need to be taken in the virtual machine itself for the virtual machine associated with this network interface to be able to
        /// take advantage of accelerated networking. This feature might not be available in some regions, virtual machine sizes, or operating system versions.
        /// It can be enabled only during the creation of a network interface, not during an update.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        NetworkInterface.Definition.IWithCreate NetworkInterface.Definition.IWithAcceleratedNetworkingBeta.WithAcceleratedNetworking()
        {
            return this.WithAcceleratedNetworking() as NetworkInterface.Definition.IWithCreate;
        }

        /// <summary>
        /// Removes a DNS server associated with the network interface.
        /// </summary>
        /// <param name="ipAddress">The IP address of the DNS server.</param>
        /// <return>The next stage of the network interface update.</return>
        NetworkInterface.Update.IUpdate NetworkInterface.Update.IWithDnsServer.WithoutDnsServer(string ipAddress)
        {
            return this.WithoutDnsServer(ipAddress) as NetworkInterface.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the IP address of the custom DNS server to associate with the network interface.
        /// Note this method's effect is additive, i.e. each time it is used, the new dns server is
        /// added to the network interface.
        /// </summary>
        /// <param name="ipAddress">The IP address of the DNS server.</param>
        /// <return>The next stage of the network interface update.</return>
        NetworkInterface.Update.IUpdate NetworkInterface.Update.IWithDnsServer.WithDnsServer(string ipAddress)
        {
            return this.WithDnsServer(ipAddress) as NetworkInterface.Update.IUpdate;
        }

        /// <summary>
        /// Specifies to use the default Azure DNS server for the network interface.
        /// Using azure DNS server will remove any custom DNS server associated with this network interface.
        /// </summary>
        /// <return>The next stage of the network interface update.</return>
        NetworkInterface.Update.IUpdate NetworkInterface.Update.IWithDnsServer.WithAzureDnsServer()
        {
            return this.WithAzureDnsServer() as NetworkInterface.Update.IUpdate;
        }

        /// <summary>
        /// Associates an existing network security group with the network interface.
        /// </summary>
        /// <param name="networkSecurityGroup">An existing network security group.</param>
        /// <return>The next stage of the network interface update.</return>
        NetworkInterface.Update.IUpdate NetworkInterface.Update.IWithNetworkSecurityGroup.WithExistingNetworkSecurityGroup(INetworkSecurityGroup networkSecurityGroup)
        {
            return this.WithExistingNetworkSecurityGroup(networkSecurityGroup) as NetworkInterface.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that remove any network security group associated with the network interface.
        /// </summary>
        /// <return>The next stage of the network interface update.</return>
        NetworkInterface.Update.IUpdate NetworkInterface.Update.IWithNetworkSecurityGroup.WithoutNetworkSecurityGroup()
        {
            return this.WithoutNetworkSecurityGroup() as NetworkInterface.Update.IUpdate;
        }

        /// <summary>
        /// Create a new network security group to associate with network interface, based on the provided definition.
        /// </summary>
        /// <param name="creatable">A creatable definition for a new network security group.</param>
        /// <return>The next stage of the network interface update.</return>
        NetworkInterface.Update.IUpdate NetworkInterface.Update.IWithNetworkSecurityGroup.WithNewNetworkSecurityGroup(ICreatable<Microsoft.Azure.Management.Network.Fluent.INetworkSecurityGroup> creatable)
        {
            return this.WithNewNetworkSecurityGroup(creatable) as NetworkInterface.Update.IUpdate;
        }

        /// <summary>
        /// Associates an existing network security group with the network interface.
        /// </summary>
        /// <param name="networkSecurityGroup">An existing network security group.</param>
        /// <return>The next stage of the definition.</return>
        NetworkInterface.Definition.IWithCreate NetworkInterface.Definition.IWithNetworkSecurityGroup.WithExistingNetworkSecurityGroup(INetworkSecurityGroup networkSecurityGroup)
        {
            return this.WithExistingNetworkSecurityGroup(networkSecurityGroup) as NetworkInterface.Definition.IWithCreate;
        }

        /// <summary>
        /// Create a new network security group to associate with network interface, based on the provided definition.
        /// </summary>
        /// <param name="creatable">A creatable definition for a new network security group.</param>
        /// <return>The next stage of the definition.</return>
        NetworkInterface.Definition.IWithCreate NetworkInterface.Definition.IWithNetworkSecurityGroup.WithNewNetworkSecurityGroup(ICreatable<Microsoft.Azure.Management.Network.Fluent.INetworkSecurityGroup> creatable)
        {
            return this.WithNewNetworkSecurityGroup(creatable) as NetworkInterface.Definition.IWithCreate;
        }

        /// <summary>
        /// Enables IP forwarding in the network interface.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        NetworkInterface.Definition.IWithCreate NetworkInterface.Definition.IWithCreate.WithIPForwarding()
        {
            return this.WithIPForwarding() as NetworkInterface.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the IP address of the custom DNS server to associate with the network interface.
        /// Note this method's effect is additive, i.e. each time it is used, the new dns server is
        /// added to the network interface.
        /// </summary>
        /// <param name="ipAddress">The IP address of the DNS server.</param>
        /// <return>The next stage of the definition.</return>
        NetworkInterface.Definition.IWithCreate NetworkInterface.Definition.IWithCreate.WithDnsServer(string ipAddress)
        {
            return this.WithDnsServer(ipAddress) as NetworkInterface.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the internal DNS name label for the network interface.
        /// </summary>
        /// <param name="dnsNameLabel">The internal DNS name label.</param>
        /// <return>The next stage of the definition.</return>
        NetworkInterface.Definition.IWithCreate NetworkInterface.Definition.IWithCreate.WithInternalDnsNameLabel(string dnsNameLabel)
        {
            return this.WithInternalDnsNameLabel(dnsNameLabel) as NetworkInterface.Definition.IWithCreate;
        }

        /// <summary>
        /// Gets the primary IP configuration of this network interface.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.INicIPConfiguration Microsoft.Azure.Management.Network.Fluent.INetworkInterface.PrimaryIPConfiguration
        {
            get
            {
                return this.PrimaryIPConfiguration() as Microsoft.Azure.Management.Network.Fluent.INicIPConfiguration;
            }
        }

        /// <summary>
        /// Gets the IP configurations of this network interface, indexed by their names.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.INicIPConfiguration> Microsoft.Azure.Management.Network.Fluent.INetworkInterface.IPConfigurations
        {
            get
            {
                return this.IPConfigurations() as System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.INicIPConfiguration>;
            }
        }

        /// <summary>
        /// Enable IP forwarding in the network interface.
        /// </summary>
        /// <return>The next stage of the network interface update.</return>
        NetworkInterface.Update.IUpdate NetworkInterface.Update.IWithIPForwarding.WithIPForwarding()
        {
            return this.WithIPForwarding() as NetworkInterface.Update.IUpdate;
        }

        /// <summary>
        /// Disable IP forwarding in the network interface.
        /// </summary>
        /// <return>The next stage of the network interface update.</return>
        NetworkInterface.Update.IUpdate NetworkInterface.Update.IWithIPForwarding.WithoutIPForwarding()
        {
            return this.WithoutIPForwarding() as NetworkInterface.Update.IUpdate;
        }

        /// <summary>
        /// Starts definition of a secondary IP configuration.
        /// </summary>
        /// <param name="name">Name for the IP configuration.</param>
        /// <return>The first stage of a secondary IP configuration definition.</return>
        NicIPConfiguration.Definition.IBlank<NetworkInterface.Definition.IWithCreate> NetworkInterface.Definition.IWithSecondaryIPConfiguration.DefineSecondaryIPConfiguration(string name)
        {
            return this.DefineSecondaryIPConfiguration(name) as NicIPConfiguration.Definition.IBlank<NetworkInterface.Definition.IWithCreate>;
        }

        /// <summary>
        /// Assigns the specified static private IP address within the specified existing virtual network
        /// subnet to the network interface's primary IP configuration.
        /// </summary>
        /// <param name="staticPrivateIPAddress">
        /// The static IP address within the specified subnet to assign to
        /// the primary IP configuration.
        /// </param>
        /// <return>The next stage of network interface update.</return>
        NetworkInterface.Update.IUpdate NetworkInterface.Update.IWithPrimaryPrivateIP.WithPrimaryPrivateIPAddressStatic(string staticPrivateIPAddress)
        {
            return this.WithPrimaryPrivateIPAddressStatic(staticPrivateIPAddress) as NetworkInterface.Update.IUpdate;
        }

        /// <summary>
        /// Enables dynamic private IP address allocation within the specified existing virtual network
        /// subnet for the network interface's primary IP configuration.
        /// </summary>
        /// <return>The next stage of network interface update.</return>
        NetworkInterface.Update.IUpdate NetworkInterface.Update.IWithPrimaryPrivateIP.WithPrimaryPrivateIPAddressDynamic()
        {
            return this.WithPrimaryPrivateIPAddressDynamic() as NetworkInterface.Update.IUpdate;
        }

        /// <summary>
        /// Assigns the specified static private IP address within the specified existing virtual network
        /// subnet to the network interface's primary IP configuration.
        /// </summary>
        /// <param name="staticPrivateIPAddress">
        /// The static IP address within the specified subnet to assign to
        /// the network interface.
        /// </param>
        /// <return>The next stage of network interface definition.</return>
        NetworkInterface.Definition.IWithCreate NetworkInterface.Definition.IWithPrimaryPrivateIP.WithPrimaryPrivateIPAddressStatic(string staticPrivateIPAddress)
        {
            return this.WithPrimaryPrivateIPAddressStatic(staticPrivateIPAddress) as NetworkInterface.Definition.IWithCreate;
        }

        /// <summary>
        /// Enables dynamic private IP address allocation within the specified existing virtual network
        /// subnet for the network interface's primary IP configuration.
        /// </summary>
        /// <return>The next stage of network interface definition.</return>
        NetworkInterface.Definition.IWithCreate NetworkInterface.Definition.IWithPrimaryPrivateIP.WithPrimaryPrivateIPAddressDynamic()
        {
            return this.WithPrimaryPrivateIPAddressDynamic() as NetworkInterface.Definition.IWithCreate;
        }

        /// <summary>
        /// Associates the network interface's primary IP configuration with an inbound NAT rule of an existing load balancer.
        /// </summary>
        /// <param name="loadBalancer">An existing load balancer.</param>
        /// <param name="inboundNatRuleName">The name of an existing inbound NAT rule on the selected load balancer.</param>
        /// <return>The next stage of the update.</return>
        NetworkInterface.Update.IUpdate NetworkInterface.Update.IWithLoadBalancer.WithExistingLoadBalancerInboundNatRule(ILoadBalancer loadBalancer, string inboundNatRuleName)
        {
            return this.WithExistingLoadBalancerInboundNatRule(loadBalancer, inboundNatRuleName) as NetworkInterface.Update.IUpdate;
        }

        /// <summary>
        /// Associates the network interface's primary IP configuration with a backend of an existing load balancer.
        /// </summary>
        /// <param name="loadBalancer">An existing load balancer.</param>
        /// <param name="backendName">The name of an existing backend on that load balancer.</param>
        /// <return>The next stage of the update.</return>
        NetworkInterface.Update.IUpdate NetworkInterface.Update.IWithLoadBalancer.WithExistingLoadBalancerBackend(ILoadBalancer loadBalancer, string backendName)
        {
            return this.WithExistingLoadBalancerBackend(loadBalancer, backendName) as NetworkInterface.Update.IUpdate;
        }

        /// <summary>
        /// Removes all the existing associations with any load balancer backends.
        /// </summary>
        /// <return>The next stage of the update.</return>
        NetworkInterface.Update.IUpdate NetworkInterface.Update.IWithLoadBalancer.WithoutLoadBalancerBackends()
        {
            return this.WithoutLoadBalancerBackends() as NetworkInterface.Update.IUpdate;
        }

        /// <summary>
        /// Removes all the existing associations with any load balancer inbound NAT rules.
        /// </summary>
        /// <return>The next stage of the update.</return>
        NetworkInterface.Update.IUpdate NetworkInterface.Update.IWithLoadBalancer.WithoutLoadBalancerInboundNatRules()
        {
            return this.WithoutLoadBalancerInboundNatRules() as NetworkInterface.Update.IUpdate;
        }

        /// <summary>
        /// Associates the network interface's primary IP configuration with an inbound NAT rule of an existing load balancer.
        /// </summary>
        /// <param name="loadBalancer">An existing load balancer.</param>
        /// <param name="inboundNatRuleName">The name of an existing inbound NAT rule on the selected load balancer.</param>
        /// <return>The next stage of the definition.</return>
        NetworkInterface.Definition.IWithCreate NetworkInterface.Definition.IWithLoadBalancer.WithExistingLoadBalancerInboundNatRule(ILoadBalancer loadBalancer, string inboundNatRuleName)
        {
            return this.WithExistingLoadBalancerInboundNatRule(loadBalancer, inboundNatRuleName) as NetworkInterface.Definition.IWithCreate;
        }

        /// <summary>
        /// Associates the network interface's primary IP configuration with a backend of an existing load balancer.
        /// </summary>
        /// <param name="loadBalancer">An existing load balancer.</param>
        /// <param name="backendName">The name of an existing backend on that load balancer.</param>
        /// <return>The next stage of the definition.</return>
        NetworkInterface.Definition.IWithCreate NetworkInterface.Definition.IWithLoadBalancer.WithExistingLoadBalancerBackend(ILoadBalancer loadBalancer, string backendName)
        {
            return this.WithExistingLoadBalancerBackend(loadBalancer, backendName) as NetworkInterface.Definition.IWithCreate;
        }

        /// <summary>
        /// Associate an existing virtual network with the network interface's primary IP configuration.
        /// </summary>
        /// <param name="network">An existing virtual network.</param>
        /// <return>The next stage of the definition.</return>
        NetworkInterface.Definition.IWithPrimaryNetworkSubnet NetworkInterface.Definition.IWithPrimaryNetwork.WithExistingPrimaryNetwork(INetwork network)
        {
            return this.WithExistingPrimaryNetwork(network) as NetworkInterface.Definition.IWithPrimaryNetworkSubnet;
        }

        /// <summary>
        /// Create a new virtual network to associate with the network interface's primary IP configuration,
        /// based on the provided definition.
        /// </summary>
        /// <param name="creatable">A creatable definition for a new virtual network.</param>
        /// <return>The next stage of the definition.</return>
        NetworkInterface.Definition.IWithPrimaryPrivateIP NetworkInterface.Definition.IWithPrimaryNetwork.WithNewPrimaryNetwork(ICreatable<Microsoft.Azure.Management.Network.Fluent.INetwork> creatable)
        {
            return this.WithNewPrimaryNetwork(creatable) as NetworkInterface.Definition.IWithPrimaryPrivateIP;
        }

        /// <summary>
        /// Creates a new virtual network to associate with the network interface's primary IP configuration.
        /// The virtual network will be created in the same resource group and region as of network interface,
        /// it will be created with the specified address space and a default subnet covering the entirety of
        /// the network IP address space.
        /// </summary>
        /// <param name="name">The name of the new virtual network.</param>
        /// <param name="addressSpace">The address space for rhe virtual network.</param>
        /// <return>The next stage of the definition.</return>
        NetworkInterface.Definition.IWithPrimaryPrivateIP NetworkInterface.Definition.IWithPrimaryNetwork.WithNewPrimaryNetwork(string name, string addressSpace)
        {
            return this.WithNewPrimaryNetwork(name, addressSpace) as NetworkInterface.Definition.IWithPrimaryPrivateIP;
        }

        /// <summary>
        /// Creates a new virtual network to associate with the network interface's primary IP configuration.
        /// The virtual network will be created in the same resource group and region as of network interface,
        /// it will be created with the specified address space and a default subnet covering the entirety of
        /// the network IP address space.
        /// </summary>
        /// <param name="addressSpace">The address space for the virtual network.</param>
        /// <return>The next stage of the definition.</return>
        NetworkInterface.Definition.IWithPrimaryPrivateIP NetworkInterface.Definition.IWithPrimaryNetwork.WithNewPrimaryNetwork(string addressSpace)
        {
            return this.WithNewPrimaryNetwork(addressSpace) as NetworkInterface.Definition.IWithPrimaryPrivateIP;
        }

        /// <summary>
        /// Gets the resource ID of the associated virtual machine, or null if none.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.INetworkInterfaceBase.VirtualMachineId
        {
            get
            {
                return this.VirtualMachineId();
            }
        }

        /// <summary>
        /// Gets IP addresses of this network interface's DNS servers.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<string> Microsoft.Azure.Management.Network.Fluent.INetworkInterfaceBase.DnsServers
        {
            get
            {
                return this.DnsServers() as System.Collections.Generic.IReadOnlyList<string>;
            }
        }

        /// <summary>
        /// Gets the fully qualified domain name of this network interface.
        /// A network interface receives FQDN as a part of assigning it to a virtual machine.
        /// </summary>
        /// <summary>
        /// Gets the qualified domain name.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.INetworkInterfaceBase.InternalFqdn
        {
            get
            {
                return this.InternalFqdn();
            }
        }

        /// <summary>
        /// Gets true if accelerated networkin is enabled for this network interface.
        /// </summary>
        bool Microsoft.Azure.Management.Network.Fluent.INetworkInterfaceBaseBeta.IsAcceleratedNetworkingEnabled
        {
            get
            {
                return this.IsAcceleratedNetworkingEnabled();
            }
        }

        /// <summary>
        /// Gets the private IP address allocated to this network interface's primary IP configuration.
        /// The private IP will be within the virtual network subnet of this network interface.
        /// </summary>
        /// <summary>
        /// Gets the private IP addresses.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.INetworkInterfaceBase.PrimaryPrivateIP
        {
            get
            {
                return this.PrimaryPrivateIP();
            }
        }

        /// <summary>
        /// Gets true if IP forwarding is enabled in this network interface.
        /// </summary>
        bool Microsoft.Azure.Management.Network.Fluent.INetworkInterfaceBase.IsIPForwardingEnabled
        {
            get
            {
                return this.IsIPForwardingEnabled();
            }
        }

        /// <summary>
        /// Gets the MAC Address of the network interface.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.INetworkInterfaceBase.MacAddress
        {
            get
            {
                return this.MacAddress();
            }
        }

        /// <summary>
        /// Gets applied DNS servers.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<string> Microsoft.Azure.Management.Network.Fluent.INetworkInterfaceBase.AppliedDnsServers
        {
            get
            {
                return this.AppliedDnsServers() as System.Collections.Generic.IReadOnlyList<string>;
            }
        }

        /// <summary>
        /// Gets the private IP allocation method (Dynamic, Static) of this network interface's
        /// primary IP configuration.
        /// </summary>
        Models.IPAllocationMethod Microsoft.Azure.Management.Network.Fluent.INetworkInterfaceBase.PrimaryPrivateIPAllocationMethod
        {
            get
            {
                return this.PrimaryPrivateIPAllocationMethod() as Models.IPAllocationMethod;
            }
        }

        /// <summary>
        /// Gets the network security group associated this network interface.
        /// This method makes a rest API call to fetch the Network Security Group resource.
        /// </summary>
        /// <return>The network security group associated with this network interface.</return>
        Microsoft.Azure.Management.Network.Fluent.INetworkSecurityGroup Microsoft.Azure.Management.Network.Fluent.INetworkInterfaceBase.GetNetworkSecurityGroup()
        {
            return this.GetNetworkSecurityGroup() as Microsoft.Azure.Management.Network.Fluent.INetworkSecurityGroup;
        }

        /// <summary>
        /// Gets the internal domain name suffix.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.INetworkInterfaceBase.InternalDomainNameSuffix
        {
            get
            {
                return this.InternalDomainNameSuffix();
            }
        }

        /// <summary>
        /// Gets the Internal DNS name assigned to this network interface.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.INetworkInterfaceBase.InternalDnsNameLabel
        {
            get
            {
                return this.InternalDnsNameLabel();
            }
        }

        /// <summary>
        /// Gets the network security group resource id associated with this network interface.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.INetworkInterfaceBase.NetworkSecurityGroupId
        {
            get
            {
                return this.NetworkSecurityGroupId();
            }
        }

        /// <summary>
        /// Associate a subnet with the network interface.
        /// </summary>
        /// <param name="name">The subnet name.</param>
        /// <return>The next stage of the network interface update.</return>
        NetworkInterface.Update.IUpdate NetworkInterface.Update.IWithPrimaryNetworkSubnet.WithSubnet(string name)
        {
            return this.WithSubnet(name) as NetworkInterface.Update.IUpdate;
        }

        /// <summary>
        /// Associate a subnet with the network interface's primary IP configuration.
        /// </summary>
        /// <param name="name">The subnet name.</param>
        /// <return>The next stage of the definition.</return>
        NetworkInterface.Definition.IWithPrimaryPrivateIP NetworkInterface.Definition.IWithPrimaryNetworkSubnet.WithSubnet(string name)
        {
            return this.WithSubnet(name) as NetworkInterface.Definition.IWithPrimaryPrivateIP;
        }

        /// <summary>
        /// Starts update of an IP configuration.
        /// </summary>
        /// <param name="name">Name of the IP configuration.</param>
        /// <return>The first stage of the update.</return>
        NicIPConfiguration.Update.IUpdate NetworkInterface.Update.IWithIPConfiguration.UpdateIPConfiguration(string name)
        {
            return this.UpdateIPConfiguration(name) as NicIPConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Starts definition of a secondary IP configuration.
        /// </summary>
        /// <param name="name">Name for the IP configuration.</param>
        /// <return>The first stage of the update.</return>
        NicIPConfiguration.UpdateDefinition.IBlank<NetworkInterface.Update.IUpdate> NetworkInterface.Update.IWithIPConfiguration.DefineSecondaryIPConfiguration(string name)
        {
            return this.DefineSecondaryIPConfiguration(name) as NicIPConfiguration.UpdateDefinition.IBlank<NetworkInterface.Update.IUpdate>;
        }

        /// <summary>
        /// Removes the specified IP configuration.
        /// </summary>
        /// <param name="name">The name of an existing IP configuration.</param>
        /// <return>The next stage of the update.</return>
        NetworkInterface.Update.IUpdate NetworkInterface.Update.IWithIPConfiguration.WithoutIPConfiguration(string name)
        {
            return this.WithoutIPConfiguration(name) as NetworkInterface.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that remove any public IP associated with the network interface's primary IP configuration.
        /// </summary>
        /// <return>The next stage of the network interface update.</return>
        NetworkInterface.Update.IUpdate NetworkInterface.Update.IWithPrimaryPublicIPAddress.WithoutPrimaryPublicIPAddress()
        {
            return this.WithoutPrimaryPublicIPAddress() as NetworkInterface.Update.IUpdate;
        }

        /// <summary>
        /// Associates an existing public IP address with the network interface's primary IP configuration.
        /// if there is an existing public IP association then that will be removed in favour of this.
        /// </summary>
        /// <param name="publicIPAddress">An existing public IP address.</param>
        /// <return>The next stage of the network interface update.</return>
        NetworkInterface.Update.IUpdate NetworkInterface.Update.IWithPrimaryPublicIPAddress.WithExistingPrimaryPublicIPAddress(IPublicIPAddress publicIPAddress)
        {
            return this.WithExistingPrimaryPublicIPAddress(publicIPAddress) as NetworkInterface.Update.IUpdate;
        }

        /// <summary>
        /// Create a new public IP address to associate the network interface's primary IP configuration,
        /// based on the provided definition.
        /// if there is public IP associated with the primary IP configuration then that will be removed in
        /// favour of this.
        /// </summary>
        /// <param name="creatable">A creatable definition for a new public IP.</param>
        /// <return>The next stage of the network interface update.</return>
        NetworkInterface.Update.IUpdate NetworkInterface.Update.IWithPrimaryPublicIPAddress.WithNewPrimaryPublicIPAddress(ICreatable<Microsoft.Azure.Management.Network.Fluent.IPublicIPAddress> creatable)
        {
            return this.WithNewPrimaryPublicIPAddress(creatable) as NetworkInterface.Update.IUpdate;
        }

        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource and associate it
        /// with the network interface's primary IP configuration.
        /// the internal name and DNS label for the public IP address will be derived from the network interface name,
        /// if there is an existing public IP association then that will be removed in favour of this.
        /// </summary>
        /// <return>The next stage of the network interface update.</return>
        NetworkInterface.Update.IUpdate NetworkInterface.Update.IWithPrimaryPublicIPAddress.WithNewPrimaryPublicIPAddress()
        {
            return this.WithNewPrimaryPublicIPAddress() as NetworkInterface.Update.IUpdate;
        }

        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource, with the specified DNS label
        /// and associate it with the network interface's primary IP configuration.
        /// the internal name for the public IP address will be derived from the DNS label, if there is an existing
        /// public IP association then that will be removed in favour of this.
        /// </summary>
        /// <param name="leafDnsLabel">The leaf domain label.</param>
        /// <return>The next stage of the network interface update.</return>
        NetworkInterface.Update.IUpdate NetworkInterface.Update.IWithPrimaryPublicIPAddress.WithNewPrimaryPublicIPAddress(string leafDnsLabel)
        {
            return this.WithNewPrimaryPublicIPAddress(leafDnsLabel) as NetworkInterface.Update.IUpdate;
        }

        /// <summary>
        /// Associates an existing public IP address with the network interface's primary IP configuration.
        /// </summary>
        /// <param name="publicIPAddress">An existing public IP address.</param>
        /// <return>The next stage of the definition.</return>
        NetworkInterface.Definition.IWithCreate NetworkInterface.Definition.IWithPrimaryPublicIPAddress.WithExistingPrimaryPublicIPAddress(IPublicIPAddress publicIPAddress)
        {
            return this.WithExistingPrimaryPublicIPAddress(publicIPAddress) as NetworkInterface.Definition.IWithCreate;
        }

        /// <summary>
        /// Create a new public IP address to associate with network interface's primary IP configuration, based on
        /// the provided definition.
        /// </summary>
        /// <param name="creatable">A creatable definition for a new public IP.</param>
        /// <return>The next stage of the definition.</return>
        NetworkInterface.Definition.IWithCreate NetworkInterface.Definition.IWithPrimaryPublicIPAddress.WithNewPrimaryPublicIPAddress(ICreatable<Microsoft.Azure.Management.Network.Fluent.IPublicIPAddress> creatable)
        {
            return this.WithNewPrimaryPublicIPAddress(creatable) as NetworkInterface.Definition.IWithCreate;
        }

        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource and associate it
        /// with the network interface's primary IP configuration.
        /// the internal name and DNS label for the public IP address will be derived from the network interface name.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        NetworkInterface.Definition.IWithCreate NetworkInterface.Definition.IWithPrimaryPublicIPAddress.WithNewPrimaryPublicIPAddress()
        {
            return this.WithNewPrimaryPublicIPAddress() as NetworkInterface.Definition.IWithCreate;
        }

        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource, with the specified DNS label
        /// and associate it with the network interface's primary IP configuration.
        /// the internal name for the public IP address will be derived from the DNS label.
        /// </summary>
        /// <param name="leafDnsLabel">The leaf domain label.</param>
        /// <return>The next stage of the definition.</return>
        NetworkInterface.Definition.IWithCreate NetworkInterface.Definition.IWithPrimaryPublicIPAddress.WithNewPrimaryPublicIPAddress(string leafDnsLabel)
        {
            return this.WithNewPrimaryPublicIPAddress(leafDnsLabel) as NetworkInterface.Definition.IWithCreate;
        }

        /// <summary>
        /// Refreshes the resource to sync with Azure.
        /// </summary>
        /// <return>The Observable to refreshed resource.</return>
        async Task<Microsoft.Azure.Management.Network.Fluent.INetworkInterface> Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Network.Fluent.INetworkInterface>.RefreshAsync(CancellationToken cancellationToken)
        {
            return await this.RefreshAsync(cancellationToken) as Microsoft.Azure.Management.Network.Fluent.INetworkInterface;
        }
    }
}