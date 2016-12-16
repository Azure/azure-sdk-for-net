// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Threading.Tasks;
    using NetworkInterface.Definition;
    using NetworkInterface.Update;
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using System.Collections.Generic;

    internal partial class NetworkInterfaceImpl 
    {
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
        /// <return>The next stage of the network interface definition.</return>
        NetworkInterface.Definition.IWithCreate NetworkInterface.Definition.IWithNetworkSecurityGroup.WithExistingNetworkSecurityGroup(INetworkSecurityGroup networkSecurityGroup)
        {
            return this.WithExistingNetworkSecurityGroup(networkSecurityGroup) as NetworkInterface.Definition.IWithCreate;
        }

        /// <summary>
        /// Create a new network security group to associate with network interface, based on the provided definition.
        /// </summary>
        /// <param name="creatable">A creatable definition for a new network security group.</param>
        /// <return>The next stage of the network interface definition.</return>
        NetworkInterface.Definition.IWithCreate NetworkInterface.Definition.IWithNetworkSecurityGroup.WithNewNetworkSecurityGroup(ICreatable<Microsoft.Azure.Management.Network.Fluent.INetworkSecurityGroup> creatable)
        {
            return this.WithNewNetworkSecurityGroup(creatable) as NetworkInterface.Definition.IWithCreate;
        }

        /// <summary>
        /// Create a new public IP address to associate the network interface's primary IP configuration,
        /// based on the provided definition.
        /// if there is public IP associated with the primary IP configuration then that will be removed in
        /// favour of this.
        /// </summary>
        /// <param name="creatable">A creatable definition for a new public IP.</param>
        /// <return>The next stage of the network interface update.</return>
        NetworkInterface.Update.IUpdate NetworkInterface.Update.IWithPrimaryPublicIpAddress.WithNewPrimaryPublicIpAddress(ICreatable<Microsoft.Azure.Management.Network.Fluent.IPublicIpAddress> creatable)
        {
            return this.WithNewPrimaryPublicIpAddress(creatable) as NetworkInterface.Update.IUpdate;
        }

        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource and associate it
        /// with the network interface's primary IP configuration.
        /// the internal name and DNS label for the public IP address will be derived from the network interface name,
        /// if there is an existing public IP association then that will be removed in favour of this.
        /// </summary>
        /// <return>The next stage of the network interface update.</return>
        NetworkInterface.Update.IUpdate NetworkInterface.Update.IWithPrimaryPublicIpAddress.WithNewPrimaryPublicIpAddress()
        {
            return this.WithNewPrimaryPublicIpAddress() as NetworkInterface.Update.IUpdate;
        }

        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource, with the specified DNS label
        /// and associate it with the network interface's primary IP configuration.
        /// the internal name for the public IP address will be derived from the DNS label, if there is an existing
        /// public IP association then that will be removed in favour of this.
        /// </summary>
        /// <param name="leafDnsLabel">The leaf domain label.</param>
        /// <return>The next stage of the network interface update.</return>
        NetworkInterface.Update.IUpdate NetworkInterface.Update.IWithPrimaryPublicIpAddress.WithNewPrimaryPublicIpAddress(string leafDnsLabel)
        {
            return this.WithNewPrimaryPublicIpAddress(leafDnsLabel) as NetworkInterface.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that remove any public IP associated with the network interface's primary IP configuration.
        /// </summary>
        /// <return>The next stage of the network interface update.</return>
        NetworkInterface.Update.IUpdate NetworkInterface.Update.IWithPrimaryPublicIpAddress.WithoutPrimaryPublicIpAddress()
        {
            return this.WithoutPrimaryPublicIpAddress() as NetworkInterface.Update.IUpdate;
        }

        /// <summary>
        /// Associates an existing public IP address with the network interface's primary IP configuration.
        /// if there is an existing public IP association then that will be removed in favour of this.
        /// </summary>
        /// <param name="publicIpAddress">An existing public IP address.</param>
        /// <return>The next stage of the network interface update.</return>
        NetworkInterface.Update.IUpdate NetworkInterface.Update.IWithPrimaryPublicIpAddress.WithExistingPrimaryPublicIpAddress(IPublicIpAddress publicIpAddress)
        {
            return this.WithExistingPrimaryPublicIpAddress(publicIpAddress) as NetworkInterface.Update.IUpdate;
        }

        /// <summary>
        /// Create a new public IP address to associate with network interface's primary IP configuration, based on
        /// the provided definition.
        /// </summary>
        /// <param name="creatable">A creatable definition for a new public IP.</param>
        /// <return>The next stage of the network interface definition.</return>
        NetworkInterface.Definition.IWithCreate NetworkInterface.Definition.IWithPrimaryPublicIpAddress.WithNewPrimaryPublicIpAddress(ICreatable<Microsoft.Azure.Management.Network.Fluent.IPublicIpAddress> creatable)
        {
            return this.WithNewPrimaryPublicIpAddress(creatable) as NetworkInterface.Definition.IWithCreate;
        }

        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource and associate it
        /// with the network interface's primary IP configuration.
        /// the internal name and DNS label for the public IP address will be derived from the network interface name.
        /// </summary>
        /// <return>The next stage of the network interface definition.</return>
        NetworkInterface.Definition.IWithCreate NetworkInterface.Definition.IWithPrimaryPublicIpAddress.WithNewPrimaryPublicIpAddress()
        {
            return this.WithNewPrimaryPublicIpAddress() as NetworkInterface.Definition.IWithCreate;
        }

        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource, with the specified DNS label
        /// and associate it with the network interface's primary IP configuration.
        /// the internal name for the public IP address will be derived from the DNS label.
        /// </summary>
        /// <param name="leafDnsLabel">The leaf domain label.</param>
        /// <return>The next stage of the network interface definition.</return>
        NetworkInterface.Definition.IWithCreate NetworkInterface.Definition.IWithPrimaryPublicIpAddress.WithNewPrimaryPublicIpAddress(string leafDnsLabel)
        {
            return this.WithNewPrimaryPublicIpAddress(leafDnsLabel) as NetworkInterface.Definition.IWithCreate;
        }

        /// <summary>
        /// Associates an existing public IP address with the network interface's primary IP configuration.
        /// </summary>
        /// <param name="publicIpAddress">An existing public IP address.</param>
        /// <return>The next stage of the network interface definition.</return>
        NetworkInterface.Definition.IWithCreate NetworkInterface.Definition.IWithPrimaryPublicIpAddress.WithExistingPrimaryPublicIpAddress(IPublicIpAddress publicIpAddress)
        {
            return this.WithExistingPrimaryPublicIpAddress(publicIpAddress) as NetworkInterface.Definition.IWithCreate;
        }

        /// <summary>
        /// Enables dynamic private IP address allocation within the specified existing virtual network
        /// subnet for the network interface's primary IP configuration.
        /// </summary>
        /// <return>The next stage of network interface update.</return>
        NetworkInterface.Update.IUpdate NetworkInterface.Update.IWithPrimaryPrivateIp.WithPrimaryPrivateIpAddressDynamic()
        {
            return this.WithPrimaryPrivateIpAddressDynamic() as NetworkInterface.Update.IUpdate;
        }

        /// <summary>
        /// Assigns the specified static private IP address within the specified existing virtual network
        /// subnet to the network interface's primary IP configuration.
        /// </summary>
        /// <param name="staticPrivateIpAddress">
        /// The static IP address within the specified subnet to assign to
        /// the primary IP configuration.
        /// </param>
        /// <return>The next stage of network interface update.</return>
        NetworkInterface.Update.IUpdate NetworkInterface.Update.IWithPrimaryPrivateIp.WithPrimaryPrivateIpAddressStatic(string staticPrivateIpAddress)
        {
            return this.WithPrimaryPrivateIpAddressStatic(staticPrivateIpAddress) as NetworkInterface.Update.IUpdate;
        }

        /// <summary>
        /// Enables dynamic private IP address allocation within the specified existing virtual network
        /// subnet for the network interface's primary IP configuration.
        /// </summary>
        /// <return>The next stage of network interface definition.</return>
        NetworkInterface.Definition.IWithCreate NetworkInterface.Definition.IWithPrimaryPrivateIp.WithPrimaryPrivateIpAddressDynamic()
        {
            return this.WithPrimaryPrivateIpAddressDynamic() as NetworkInterface.Definition.IWithCreate;
        }

        /// <summary>
        /// Assigns the specified static private IP address within the specified existing virtual network
        /// subnet to the network interface's primary IP configuration.
        /// </summary>
        /// <param name="staticPrivateIpAddress">
        /// The static IP address within the specified subnet to assign to
        /// the network interface.
        /// </param>
        /// <return>The next stage of network interface definition.</return>
        NetworkInterface.Definition.IWithCreate NetworkInterface.Definition.IWithPrimaryPrivateIp.WithPrimaryPrivateIpAddressStatic(string staticPrivateIpAddress)
        {
            return this.WithPrimaryPrivateIpAddressStatic(staticPrivateIpAddress) as NetworkInterface.Definition.IWithCreate;
        }

        /// <summary>
        /// Enable IP forwarding in the network interface.
        /// </summary>
        /// <return>The next stage of the network interface definition.</return>
        NetworkInterface.Definition.IWithCreate NetworkInterface.Definition.IWithCreate.WithIpForwarding()
        {
            return this.WithIpForwarding() as NetworkInterface.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the IP address of the custom DNS server to associate with the network interface.
        /// Note this method's effect is additive, i.e. each time it is used, the new dns server is
        /// added to the network interface.
        /// </summary>
        /// <param name="ipAddress">The IP address of the DNS server.</param>
        /// <return>The next stage of the network interface definition.</return>
        NetworkInterface.Definition.IWithCreate NetworkInterface.Definition.IWithCreate.WithDnsServer(string ipAddress)
        {
            return this.WithDnsServer(ipAddress) as NetworkInterface.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the internal DNS name label for the network interface.
        /// </summary>
        /// <param name="dnsNameLabel">The internal DNS name label.</param>
        /// <return>The next stage of the network interface definition.</return>
        NetworkInterface.Definition.IWithCreate NetworkInterface.Definition.IWithCreate.WithInternalDnsNameLabel(string dnsNameLabel)
        {
            return this.WithInternalDnsNameLabel(dnsNameLabel) as NetworkInterface.Definition.IWithCreate;
        }

        /// <summary>
        /// Gets Gets the private IP address allocated to this network interface's primary IP configuration.
        /// The private IP will be within the virtual network subnet of this network interface.
        /// </summary>
        /// <summary>
        /// Gets the private IP addresses.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.INetworkInterface.PrimaryPrivateIp
        {
            get
            {
                return this.PrimaryPrivateIp();
            }
        }

        /// <summary>
        /// Gets the resource ID of the associated virtual machine, or null if none.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.INetworkInterface.VirtualMachineId
        {
            get
            {
                return this.VirtualMachineId();
            }
        }

        /// <summary>
        /// Gets IP addresses of this network interface's DNS servers.
        /// </summary>
        System.Collections.Generic.IList<string> Microsoft.Azure.Management.Network.Fluent.INetworkInterface.DnsServers
        {
            get
            {
                return this.DnsServers() as System.Collections.Generic.IList<string>;
            }
        }

        /// <summary>
        /// Gets Gets the fully qualified domain name of this network interface.
        /// A network interface receives FQDN as a part of assigning it to a virtual machine.
        /// </summary>
        /// <summary>
        /// Gets the qualified domain name.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.INetworkInterface.InternalFqdn
        {
            get
            {
                return this.InternalFqdn();
            }
        }

        /// <summary>
        /// Gets <tt>true</tt> if IP forwarding is enabled in this network interface.
        /// </summary>
        bool Microsoft.Azure.Management.Network.Fluent.INetworkInterface.IsIpForwardingEnabled
        {
            get
            {
                return this.IsIpForwardingEnabled();
            }
        }

        /// <summary>
        /// Gets the MAC Address of the network interface.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.INetworkInterface.MacAddress
        {
            get
            {
                return this.MacAddress();
            }
        }

        /// <summary>
        /// Gets the IP configurations of this network interface, indexed by their names.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.INicIpConfiguration> Microsoft.Azure.Management.Network.Fluent.INetworkInterface.IpConfigurations
        {
            get
            {
                return this.IpConfigurations() as System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.INicIpConfiguration>;
            }
        }

        /// <summary>
        /// Gets applied DNS servers.
        /// </summary>
        System.Collections.Generic.IList<string> Microsoft.Azure.Management.Network.Fluent.INetworkInterface.AppliedDnsServers
        {
            get
            {
                return this.AppliedDnsServers() as System.Collections.Generic.IList<string>;
            }
        }

        /// <summary>
        /// Gets the primary IP configuration of this network interface.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.INicIpConfiguration Microsoft.Azure.Management.Network.Fluent.INetworkInterface.PrimaryIpConfiguration
        {
            get
            {
                return this.PrimaryIpConfiguration() as Microsoft.Azure.Management.Network.Fluent.INicIpConfiguration;
            }
        }

        /// <summary>
        /// Gets the network security group associated this network interface.
        /// This method makes a rest API call to fetch the Network Security Group resource.
        /// </summary>
        /// <return>The network security group associated with this network interface.</return>
        Microsoft.Azure.Management.Network.Fluent.INetworkSecurityGroup Microsoft.Azure.Management.Network.Fluent.INetworkInterface.GetNetworkSecurityGroup()
        {
            return this.GetNetworkSecurityGroup() as Microsoft.Azure.Management.Network.Fluent.INetworkSecurityGroup;
        }

        /// <summary>
        /// Gets the internal domain name suffix.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.INetworkInterface.InternalDomainNameSuffix
        {
            get
            {
                return this.InternalDomainNameSuffix();
            }
        }

        /// <summary>
        /// Gets the private IP allocation method (Dynamic, Static) of this network interface's
        /// primary IP configuration.
        /// </summary>
        IPAllocationMethod Microsoft.Azure.Management.Network.Fluent.INetworkInterface.PrimaryPrivateIpAllocationMethod
        {
            get
            {
                return this.PrimaryPrivateIpAllocationMethod();
            }
        }

        /// <summary>
        /// Gets the Internal DNS name assigned to this network interface.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.INetworkInterface.InternalDnsNameLabel
        {
            get
            {
                return this.InternalDnsNameLabel();
            }
        }

        /// <summary>
        /// Gets the network security group resource id or null if there is no network security group
        /// associated with this network interface.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.INetworkInterface.NetworkSecurityGroupId
        {
            get
            {
                return this.NetworkSecurityGroupId();
            }
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
        /// Starts definition of a secondary IP configuration.
        /// </summary>
        /// <param name="name">Name for the IP configuration.</param>
        /// <return>The first stage of a secondary IP configuration definition.</return>
        NicIpConfiguration.Definition.IBlank<NetworkInterface.Definition.IWithCreate> NetworkInterface.Definition.IWithSecondaryIpConfiguration.DefineSecondaryIpConfiguration(string name)
        {
            return this.DefineSecondaryIpConfiguration(name) as NicIpConfiguration.Definition.IBlank<NetworkInterface.Definition.IWithCreate>;
        }

        /// <summary>
        /// Associate an existing virtual network with the network interface's primary IP configuration.
        /// </summary>
        /// <param name="network">An existing virtual network.</param>
        /// <return>The next stage of the network interface definition.</return>
        NetworkInterface.Definition.IWithPrimaryNetworkSubnet NetworkInterface.Definition.IWithPrimaryNetwork.WithExistingPrimaryNetwork(INetwork network)
        {
            return this.WithExistingPrimaryNetwork(network) as NetworkInterface.Definition.IWithPrimaryNetworkSubnet;
        }

        /// <summary>
        /// Create a new virtual network to associate with the network interface's primary IP configuration,
        /// based on the provided definition.
        /// </summary>
        /// <param name="creatable">A creatable definition for a new virtual network.</param>
        /// <return>The next stage of the network interface definition.</return>
        NetworkInterface.Definition.IWithPrimaryPrivateIp NetworkInterface.Definition.IWithPrimaryNetwork.WithNewPrimaryNetwork(ICreatable<Microsoft.Azure.Management.Network.Fluent.INetwork> creatable)
        {
            return this.WithNewPrimaryNetwork(creatable) as NetworkInterface.Definition.IWithPrimaryPrivateIp;
        }

        /// <summary>
        /// Creates a new virtual network to associate with the network interface's primary IP configuration.
        /// The virtual network will be created in the same resource group and region as of network interface,
        /// it will be created with the specified address space and a default subnet covering the entirety of
        /// the network IP address space.
        /// </summary>
        /// <param name="name">The name of the new virtual network.</param>
        /// <param name="addressSpace">The address space for rhe virtual network.</param>
        /// <return>The next stage of the network interface definition.</return>
        NetworkInterface.Definition.IWithPrimaryPrivateIp NetworkInterface.Definition.IWithPrimaryNetwork.WithNewPrimaryNetwork(string name, string addressSpace)
        {
            return this.WithNewPrimaryNetwork(name, addressSpace) as NetworkInterface.Definition.IWithPrimaryPrivateIp;
        }

        /// <summary>
        /// Creates a new virtual network to associate with the network interface's primary IP configuration.
        /// The virtual network will be created in the same resource group and region as of network interface,
        /// it will be created with the specified address space and a default subnet covering the entirety of
        /// the network IP address space.
        /// </summary>
        /// <param name="addressSpace">The address space for the virtual network.</param>
        /// <return>The next stage of the network interface definition.</return>
        NetworkInterface.Definition.IWithPrimaryPrivateIp NetworkInterface.Definition.IWithPrimaryNetwork.WithNewPrimaryNetwork(string addressSpace)
        {
            return this.WithNewPrimaryNetwork(addressSpace) as NetworkInterface.Definition.IWithPrimaryPrivateIp;
        }

        /// <summary>
        /// Starts update of an IP configuration.
        /// </summary>
        /// <param name="name">Name of the IP configuration.</param>
        /// <return>The first stage of an IP configuration update.</return>
        NicIpConfiguration.Update.IUpdate NetworkInterface.Update.IWithIpConfiguration.UpdateIpConfiguration(string name)
        {
            return this.UpdateIpConfiguration(name) as NicIpConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Starts definition of a secondary IP configuration.
        /// </summary>
        /// <param name="name">Name for the IP configuration.</param>
        /// <return>The first stage of a secondary IP configuration definition.</return>
        NicIpConfiguration.UpdateDefinition.IBlank<NetworkInterface.Update.IUpdate> NetworkInterface.Update.IWithIpConfiguration.DefineSecondaryIpConfiguration(string name)
        {
            return this.DefineSecondaryIpConfiguration(name) as NicIpConfiguration.UpdateDefinition.IBlank<NetworkInterface.Update.IUpdate>;
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
        /// <return>The next stage of the network interface definition.</return>
        NetworkInterface.Definition.IWithPrimaryPrivateIp NetworkInterface.Definition.IWithPrimaryNetworkSubnet.WithSubnet(string name)
        {
            return this.WithSubnet(name) as NetworkInterface.Definition.IWithPrimaryPrivateIp;
        }

        /// <summary>
        /// Refreshes the resource to sync with Azure.
        /// </summary>
        /// <return>The refreshed resource.</return>
        Microsoft.Azure.Management.Network.Fluent.INetworkInterface Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Network.Fluent.INetworkInterface>.Refresh()
        {
            return this.Refresh() as Microsoft.Azure.Management.Network.Fluent.INetworkInterface;
        }

        /// <summary>
        /// Enable IP forwarding in the network interface.
        /// </summary>
        /// <return>The next stage of the network interface update.</return>
        NetworkInterface.Update.IUpdate NetworkInterface.Update.IWithIpForwarding.WithIpForwarding()
        {
            return this.WithIpForwarding() as NetworkInterface.Update.IUpdate;
        }

        /// <summary>
        /// Disable IP forwarding in the network interface.
        /// </summary>
        /// <return>The next stage of the network interface update.</return>
        NetworkInterface.Update.IUpdate NetworkInterface.Update.IWithIpForwarding.WithoutIpForwarding()
        {
            return this.WithoutIpForwarding() as NetworkInterface.Update.IUpdate;
        }
    }
}