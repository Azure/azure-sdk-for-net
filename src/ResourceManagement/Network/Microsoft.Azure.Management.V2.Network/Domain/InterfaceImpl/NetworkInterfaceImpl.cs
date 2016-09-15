/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Network
{

    using Microsoft.Azure.Management.V2.Resource.Core;
    using Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition;
    using System.Threading;
    using Microsoft.Rest;
    using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.V2.Resource;
    using Microsoft.Azure.Management.V2.Network.NetworkInterface.Update;
    using System.Threading.Tasks;
    public partial class NetworkInterfaceImpl 
    {
        /// <summary>
        /// Removes a DNS server associated with the network interface.
        /// </summary>
        /// <param name="ipAddress">ipAddress the IP address of the DNS server</param>
        /// <returns>the next stage of the network interface update</returns>
        Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IWithDnsServer.WithoutDnsServer (string ipAddress) {
            return this.WithoutDnsServer( ipAddress) as Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the IP address of the custom DNS server to associate with the network interface.
        /// <p>
        /// Note this method's effect is additive, i.e. each time it is used, the new dns server is
        /// added to the network interface.
        /// </summary>
        /// <param name="ipAddress">ipAddress the IP address of the DNS server</param>
        /// <returns>the next stage of the network interface update</returns>
        Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IWithDnsServer.WithDnsServer (string ipAddress) {
            return this.WithDnsServer( ipAddress) as Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate;
        }

        /// <summary>
        /// Specifies to use the default Azure DNS server for the network interface.
        /// <p>
        /// Using azure DNS server will remove any custom DNS server associated with this network interface.
        /// </summary>
        /// <returns>the next stage of the network interface update</returns>
        Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IWithDnsServer.WithAzureDnsServer () {
            return this.WithAzureDnsServer() as Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate;
        }

        /// <summary>
        /// Associates an existing network security group with the network interface.
        /// </summary>
        /// <param name="networkSecurityGroup">networkSecurityGroup an existing network security group</param>
        /// <returns>the next stage of the network interface update</returns>
        Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IWithNetworkSecurityGroup.WithExistingNetworkSecurityGroup (INetworkSecurityGroup networkSecurityGroup) {
            return this.WithExistingNetworkSecurityGroup( networkSecurityGroup) as Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that remove any network security group associated with the network interface.
        /// </summary>
        /// <returns>the next stage of the network interface update</returns>
        Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IWithNetworkSecurityGroup.WithoutNetworkSecurityGroup () {
            return this.WithoutNetworkSecurityGroup() as Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate;
        }

        /// <summary>
        /// Create a new network security group to associate with network interface, based on the provided definition.
        /// </summary>
        /// <param name="creatable">creatable a creatable definition for a new network security group</param>
        /// <returns>the next stage of the network interface update</returns>
        Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IWithNetworkSecurityGroup.WithNewNetworkSecurityGroup (ICreatable<Microsoft.Azure.Management.V2.Network.INetworkSecurityGroup> creatable) {
            return this.WithNewNetworkSecurityGroup( creatable) as Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate;
        }

        /// <summary>
        /// Associates an existing network security group with the network interface.
        /// </summary>
        /// <param name="networkSecurityGroup">networkSecurityGroup an existing network security group</param>
        /// <returns>the next stage of the network interface definition</returns>
        Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithNetworkSecurityGroup.WithExistingNetworkSecurityGroup (INetworkSecurityGroup networkSecurityGroup) {
            return this.WithExistingNetworkSecurityGroup( networkSecurityGroup) as Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate;
        }

        /// <summary>
        /// Create a new network security group to associate with network interface, based on the provided definition.
        /// </summary>
        /// <param name="creatable">creatable a creatable definition for a new network security group</param>
        /// <returns>the next stage of the network interface definition</returns>
        Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithNetworkSecurityGroup.WithNewNetworkSecurityGroup (ICreatable<Microsoft.Azure.Management.V2.Network.INetworkSecurityGroup> creatable) {
            return this.WithNewNetworkSecurityGroup( creatable) as Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate;
        }

        /// <summary>
        /// Create a new public IP address to associate the network interface's primary IP configuration,
        /// based on the provided definition.
        /// <p>
        /// if there is public IP associated with the primary IP configuration then that will be removed in
        /// favour of this
        /// </summary>
        /// <param name="creatable">creatable a creatable definition for a new public IP</param>
        /// <returns>the next stage of the network interface update</returns>
        Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IWithPrimaryPublicIpAddress.WithNewPrimaryPublicIpAddress (ICreatable<Microsoft.Azure.Management.V2.Network.IPublicIpAddress> creatable) {
            return this.WithNewPrimaryPublicIpAddress( creatable) as Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate;
        }

        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource and associate it
        /// with the network interface's primary IP configuration.
        /// <p>
        /// the internal name and DNS label for the public IP address will be derived from the network interface name,
        /// if there is an existing public IP association then that will be removed in favour of this
        /// </summary>
        /// <returns>the next stage of the network interface update</returns>
        Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IWithPrimaryPublicIpAddress.WithNewPrimaryPublicIpAddress () {
            return this.WithNewPrimaryPublicIpAddress() as Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate;
        }

        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource, with the specified DNS label
        /// and associate it with the network interface's primary IP configuration.
        /// <p>
        /// the internal name for the public IP address will be derived from the DNS label, if there is an existing
        /// public IP association then that will be removed in favour of this
        /// </summary>
        /// <param name="leafDnsLabel">leafDnsLabel the leaf domain label</param>
        /// <returns>the next stage of the network interface update</returns>
        Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IWithPrimaryPublicIpAddress.WithNewPrimaryPublicIpAddress (string leafDnsLabel) {
            return this.WithNewPrimaryPublicIpAddress( leafDnsLabel) as Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that remove any public IP associated with the network interface's primary IP configuration.
        /// </summary>
        /// <returns>the next stage of the network interface update</returns>
        Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IWithPrimaryPublicIpAddress.WithoutPrimaryPublicIpAddress () {
            return this.WithoutPrimaryPublicIpAddress() as Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate;
        }

        /// <summary>
        /// Associates an existing public IP address with the network interface's primary IP configuration.
        /// if there is an existing public IP association then that will be removed in favour of this
        /// </summary>
        /// <param name="publicIpAddress">publicIpAddress an existing public IP address</param>
        /// <returns>the next stage of the network interface update</returns>
        Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IWithPrimaryPublicIpAddress.WithExistingPrimaryPublicIpAddress (IPublicIpAddress publicIpAddress) {
            return this.WithExistingPrimaryPublicIpAddress( publicIpAddress) as Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate;
        }

        /// <summary>
        /// Create a new public IP address to associate with network interface's primary IP configuration, based on
        /// the provided definition.
        /// </summary>
        /// <param name="creatable">creatable a creatable definition for a new public IP</param>
        /// <returns>the next stage of the network interface definition</returns>
        Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithPrimaryPublicIpAddress.WithNewPrimaryPublicIpAddress (ICreatable<Microsoft.Azure.Management.V2.Network.IPublicIpAddress> creatable) {
            return this.WithNewPrimaryPublicIpAddress( creatable) as Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate;
        }

        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource and associate it
        /// with the network interface's primary IP configuration.
        /// <p>
        /// the internal name and DNS label for the public IP address will be derived from the network interface name
        /// </summary>
        /// <returns>the next stage of the network interface definition</returns>
        Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithPrimaryPublicIpAddress.WithNewPrimaryPublicIpAddress () {
            return this.WithNewPrimaryPublicIpAddress() as Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate;
        }

        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource, with the specified DNS label
        /// and associate it with the network interface's primary IP configuration.
        /// <p>
        /// the internal name for the public IP address will be derived from the DNS label
        /// </summary>
        /// <param name="leafDnsLabel">leafDnsLabel the leaf domain label</param>
        /// <returns>the next stage of the network interface definition</returns>
        Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithPrimaryPublicIpAddress.WithNewPrimaryPublicIpAddress (string leafDnsLabel) {
            return this.WithNewPrimaryPublicIpAddress( leafDnsLabel) as Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate;
        }

        /// <summary>
        /// Associates an existing public IP address with the network interface's primary IP configuration.
        /// </summary>
        /// <param name="publicIpAddress">publicIpAddress an existing public IP address</param>
        /// <returns>the next stage of the network interface definition</returns>
        Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithPrimaryPublicIpAddress.WithExistingPrimaryPublicIpAddress (IPublicIpAddress publicIpAddress) {
            return this.WithExistingPrimaryPublicIpAddress( publicIpAddress) as Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate;
        }

        /// <summary>
        /// Enables dynamic private IP address allocation within the specified existing virtual network
        /// subnet for the network interface's primary IP configuration.
        /// </summary>
        /// <returns>the next stage of network interface update</returns>
        Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IWithPrimaryPrivateIp.WithPrimaryPrivateIpAddressDynamic () {
            return this.WithPrimaryPrivateIpAddressDynamic() as Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate;
        }

        /// <summary>
        /// Assigns the specified static private IP address within the specified existing virtual network
        /// subnet to the network interface's primary IP configuration.
        /// </summary>
        /// <param name="staticPrivateIpAddress">staticPrivateIpAddress the static IP address within the specified subnet to assign to</param>
        /// <param name="the">the primary IP configuration</param>
        /// <returns>the next stage of network interface update</returns>
        Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IWithPrimaryPrivateIp.WithPrimaryPrivateIpAddressStatic (string staticPrivateIpAddress) {
            return this.WithPrimaryPrivateIpAddressStatic( staticPrivateIpAddress) as Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate;
        }

        /// <summary>
        /// Enables dynamic private IP address allocation within the specified existing virtual network
        /// subnet for the network interface's primary IP configuration.
        /// </summary>
        /// <returns>the next stage of network interface definition</returns>
        Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithPrimaryPrivateIp.WithPrimaryPrivateIpAddressDynamic () {
            return this.WithPrimaryPrivateIpAddressDynamic() as Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate;
        }

        /// <summary>
        /// Assigns the specified static private IP address within the specified existing virtual network
        /// subnet to the network interface's primary IP configuration.
        /// </summary>
        /// <param name="staticPrivateIpAddress">staticPrivateIpAddress the static IP address within the specified subnet to assign to</param>
        /// <param name="the">the network interface</param>
        /// <returns>the next stage of network interface definition</returns>
        Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithPrimaryPrivateIp.WithPrimaryPrivateIpAddressStatic (string staticPrivateIpAddress) {
            return this.WithPrimaryPrivateIpAddressStatic( staticPrivateIpAddress) as Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate;
        }

        /// <summary>
        /// Enable IP forwarding in the network interface.
        /// </summary>
        /// <returns>the next stage of the network interface definition</returns>
        Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate.WithIpForwarding () {
            return this.WithIpForwarding() as Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the IP address of the custom DNS server to associate with the network interface.
        /// <p>
        /// Note this method's effect is additive, i.e. each time it is used, the new dns server is
        /// added to the network interface.
        /// </summary>
        /// <param name="ipAddress">ipAddress the IP address of the DNS server</param>
        /// <returns>the next stage of the network interface definition</returns>
        Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate.WithDnsServer (string ipAddress) {
            return this.WithDnsServer( ipAddress) as Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the internal DNS name label for the network interface.
        /// </summary>
        /// <param name="dnsNameLabel">dnsNameLabel the internal DNS name label</param>
        /// <returns>the next stage of the network interface definition</returns>
        Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate.WithInternalDnsNameLabel (string dnsNameLabel) {
            return this.WithInternalDnsNameLabel( dnsNameLabel) as Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate;
        }

        /// <summary>
        /// Gets the public IP address associated with this network interface.
        /// <p>
        /// This method makes a rest API call to fetch the public IP.
        /// </summary>
        /// <returns>the public IP associated with this network interface</returns>
        Microsoft.Azure.Management.V2.Network.IPublicIpAddress Microsoft.Azure.Management.V2.Network.INetworkInterface.PrimaryPublicIpAddress () {
            return this.PrimaryPublicIpAddress() as Microsoft.Azure.Management.V2.Network.IPublicIpAddress;
        }

        /// <summary>
        /// Gets the private IP address allocated to this network interface's primary IP configuration.
        /// <p>
        /// The private IP will be within the virtual network subnet of this network interface.
        /// </summary>
        /// <returns>the private IP addresses</returns>
        string Microsoft.Azure.Management.V2.Network.INetworkInterface.PrimaryPrivateIp
        {
            get
            {
                return this.PrimaryPrivateIp as string;
            }
        }
        /// <returns>IP addresses of this network interface's DNS servers</returns>
        System.Collections.Generic.IList<string> Microsoft.Azure.Management.V2.Network.INetworkInterface.DnsServers
        {
            get
            {
                return this.DnsServers as System.Collections.Generic.IList<string>;
            }
        }
        /// <summary>
        /// Gets the virtual network associated this network interface's primary IP configuration.
        /// <p>
        /// This method makes a rest API call to fetch the virtual network.
        /// </summary>
        /// <returns>the virtual network associated with this network interface.</returns>
        Microsoft.Azure.Management.V2.Network.INetwork Microsoft.Azure.Management.V2.Network.INetworkInterface.PrimaryNetwork () {
            return this.PrimaryNetwork() as Microsoft.Azure.Management.V2.Network.INetwork;
        }

        /// <summary>
        /// Gets the fully qualified domain name of this network interface.
        /// <p>
        /// A network interface receives FQDN as a part of assigning it to a virtual machine.
        /// </summary>
        /// <returns>the qualified domain name</returns>
        string Microsoft.Azure.Management.V2.Network.INetworkInterface.InternalFqdn
        {
            get
            {
                return this.InternalFqdn as string;
            }
        }
        /// <returns><tt>true</tt> if IP forwarding is enabled in this network interface</returns>
        bool? Microsoft.Azure.Management.V2.Network.INetworkInterface.IsIpForwardingEnabled
        {
            get
            {
                return this.IsIpForwardingEnabled;
            }
        }
        /// <returns>the MAC Address of the network interface</returns>
        string Microsoft.Azure.Management.V2.Network.INetworkInterface.MacAddress
        {
            get
            {
                return this.MacAddress as string;
            }
        }
        /// <returns>the IP configurations of this network interface</returns>
        System.Collections.Generic.IList<Microsoft.Azure.Management.V2.Network.INicIpConfiguration> Microsoft.Azure.Management.V2.Network.INetworkInterface.IpConfigurations () {
            return this.IpConfigurations() as System.Collections.Generic.IList<Microsoft.Azure.Management.V2.Network.INicIpConfiguration>;
        }

        /// <returns>the primary IP configuration of this network interface</returns>
        Microsoft.Azure.Management.V2.Network.INicIpConfiguration Microsoft.Azure.Management.V2.Network.INetworkInterface.PrimaryIpConfiguration () {
            return this.PrimaryIpConfiguration() as Microsoft.Azure.Management.V2.Network.INicIpConfiguration;
        }

        /// <returns>the private IP allocation method (Dynamic, Static) of this network interface's</returns>
        /// <returns>primary IP configuration.</returns>
        string Microsoft.Azure.Management.V2.Network.INetworkInterface.PrimaryPrivateIpAllocationMethod
        {
            get
            {
                return this.PrimaryPrivateIpAllocationMethod as string;
            }
        }
        /// <returns>the Internal DNS name assigned to this network interface</returns>
        string Microsoft.Azure.Management.V2.Network.INetworkInterface.InternalDnsNameLabel
        {
            get
            {
                return this.InternalDnsNameLabel as string;
            }
        }
        /// <summary>
        /// Gets the network security group associated this network interface.
        /// <p>
        /// This method makes a rest API call to fetch the Network Security Group resource.
        /// </summary>
        /// <returns>the network security group associated with this network interface.</returns>
        Microsoft.Azure.Management.V2.Network.INetworkSecurityGroup Microsoft.Azure.Management.V2.Network.INetworkInterface.NetworkSecurityGroup () {
            return this.NetworkSecurityGroup() as Microsoft.Azure.Management.V2.Network.INetworkSecurityGroup;
        }

        /// <returns>the network security group resource id or null if there is no network security group</returns>
        /// <returns>associated with this network interface.</returns>
        string Microsoft.Azure.Management.V2.Network.INetworkInterface.NetworkSecurityGroupId
        {
            get
            {
                return this.NetworkSecurityGroupId as string;
            }
        }
        /// <returns>the resource id of the virtual network subnet associated with this network interface.</returns>
        string Microsoft.Azure.Management.V2.Network.INetworkInterface.PrimarySubnetId
        {
            get
            {
                return this.PrimarySubnetId as string;
            }
        }
        /// <summary>
        /// Execute the update request asynchronously.
        /// </summary>
        /// <param name="cancellationToken">cancellationToken the cancellation token</param>
        /// <returns>the handle to the REST call</returns>
        async Task<Microsoft.Azure.Management.V2.Network.INetworkInterface> Microsoft.Azure.Management.V2.Resource.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.V2.Network.INetworkInterface>.ApplyAsync (CancellationToken cancellationToken = default(CancellationToken), bool multiThreaded = true) {
            return await this.ApplyAsync() as INetworkInterface;
        }

        /// <summary>
        /// Execute the update request.
        /// </summary>
        /// <returns>the updated resource</returns>
        Microsoft.Azure.Management.V2.Network.INetworkInterface Microsoft.Azure.Management.V2.Resource.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.V2.Network.INetworkInterface>.Apply () {
            return this.Apply() as Microsoft.Azure.Management.V2.Network.INetworkInterface;
        }

        /// <summary>
        /// Starts definition of a secondary IP configuration.
        /// </summary>
        /// <param name="name">name name for the IP configuration</param>
        /// <returns>the first stage of a secondary IP configuration definition</returns>
        Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Definition.IBlank<Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate> Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithSecondaryIpConfiguration.DefineSecondaryIpConfiguration (string name) {
            return this.DefineSecondaryIpConfiguration( name) as Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Definition.IBlank<Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate>;
        }

        /// <summary>
        /// Associate an existing virtual network with the network interface's primary IP configuration.
        /// </summary>
        /// <param name="network">network an existing virtual network</param>
        /// <returns>the next stage of the network interface definition</returns>
        Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithPrimaryNetworkSubnet Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithPrimaryNetwork.WithExistingPrimaryNetwork (INetwork network) {
            return this.WithExistingPrimaryNetwork( network) as Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithPrimaryNetworkSubnet;
        }

        /// <summary>
        /// Create a new virtual network to associate with the network interface's primary IP configuration,
        /// based on the provided definition.
        /// </summary>
        /// <param name="creatable">creatable a creatable definition for a new virtual network</param>
        /// <returns>the next stage of the network interface definition</returns>
        Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithPrimaryPrivateIp Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithPrimaryNetwork.WithNewPrimaryNetwork (ICreatable<Microsoft.Azure.Management.V2.Network.INetwork> creatable) {
            return this.WithNewPrimaryNetwork( creatable) as Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithPrimaryPrivateIp;
        }

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
        Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithPrimaryPrivateIp Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithPrimaryNetwork.WithNewPrimaryNetwork (string name, string addressSpace) {
            return this.WithNewPrimaryNetwork( name,  addressSpace) as Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithPrimaryPrivateIp;
        }

        /// <summary>
        /// Creates a new virtual network to associate with the network interface's primary IP configuration.
        /// <p>
        /// The virtual network will be created in the same resource group and region as of network interface,
        /// it will be created with the specified address space and a default subnet covering the entirety of
        /// the network IP address space.
        /// </summary>
        /// <param name="addressSpace">addressSpace the address space for the virtual network</param>
        /// <returns>the next stage of the network interface definition</returns>
        Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithPrimaryPrivateIp Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithPrimaryNetwork.WithNewPrimaryNetwork (string addressSpace) {
            return this.WithNewPrimaryNetwork( addressSpace) as Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithPrimaryPrivateIp;
        }

        /// <summary>
        /// Starts update of an IP configuration.
        /// </summary>
        /// <param name="name">name name of the IP configuration</param>
        /// <returns>the first stage of an IP configuration update</returns>
        Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Update.IUpdate Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IWithIpConfiguration.UpdateIpConfiguration (string name) {
            return this.UpdateIpConfiguration( name) as Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Starts definition of a secondary IP configuration.
        /// </summary>
        /// <param name="name">name name for the IP configuration</param>
        /// <returns>the first stage of a secondary IP configuration definition</returns>
        Microsoft.Azure.Management.V2.Network.NicIpConfiguration.UpdateDefinition.IBlank<Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate> Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IWithIpConfiguration.DefineSecondaryIpConfiguration (string name) {
            return this.DefineSecondaryIpConfiguration( name) as Microsoft.Azure.Management.V2.Network.NicIpConfiguration.UpdateDefinition.IBlank<Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate>;
        }

        /// <summary>
        /// Associate a subnet with the network interface.
        /// </summary>
        /// <param name="name">name the subnet name</param>
        /// <returns>the next stage of the network interface update</returns>
        Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IWithPrimaryNetworkSubnet.WithSubnet (string name) {
            return this.WithSubnet( name) as Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate;
        }

        /// <summary>
        /// Associate a subnet with the network interface's primary IP configuration.
        /// </summary>
        /// <param name="name">name the subnet name</param>
        /// <returns>the next stage of the network interface definition</returns>
        Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithPrimaryPrivateIp Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithPrimaryNetworkSubnet.WithSubnet (string name) {
            return this.WithSubnet( name) as Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithPrimaryPrivateIp;
        }

        /// <summary>
        /// Refreshes the resource to sync with Azure.
        /// </summary>
        /// <returns>the refreshed resource</returns>
        Microsoft.Azure.Management.V2.Network.INetworkInterface Microsoft.Azure.Management.V2.Resource.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.V2.Network.INetworkInterface>.Refresh () {
            return this.Refresh() as Microsoft.Azure.Management.V2.Network.INetworkInterface;
        }

        /// <summary>
        /// Enable IP forwarding in the network interface.
        /// </summary>
        /// <returns>the next stage of the network interface update</returns>
        Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IWithIpForwarding.WithIpForwarding () {
            return this.WithIpForwarding() as Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate;
        }

        /// <summary>
        /// Disable IP forwarding in the network interface.
        /// </summary>
        /// <returns>the next stage of the network interface update</returns>
        Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IWithIpForwarding.WithoutIpForwarding () {
            return this.WithoutIpForwarding() as Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate;
        }

    }
}