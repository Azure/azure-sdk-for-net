/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/

namespace Microsoft.Azure.Management.V2.Network
{

    using Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.V2.Network.NetworkInterface.Update;
    using System.Threading;
    using Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
    using Microsoft.Azure.Management.V2.Resource.Core;
    using Microsoft.Rest;
    using Microsoft.Azure.Management.V2.Resource;
    using System.Threading.Tasks;
    using Management.Network;
    using System;

    /// <summary>
    /// Implementation for {@link NetworkInterface} and its create and update interfaces.
    /// </summary>
    public class NetworkInterfaceImpl :
        GroupableResource<INetworkInterface,
            NetworkInterfaceInner,
            Rest.Azure.Resource,
            NetworkInterfaceImpl,
            INetworkManager,
            NetworkInterface.Definition.IWithGroup,
            NetworkInterface.Definition.IWithPrimaryNetwork,
            NetworkInterface.Definition.IWithCreate,
            NetworkInterface.Update.IUpdate>,
        INetworkInterface,
        IDefinition,
         NetworkInterface.Update.IUpdate
    {
        private NetworkInterfacesOperations client;
        private string nicName;
        private NicIpConfigurationImpl nicPrimaryIpConfiguration;
        private IList<INicIpConfiguration> nicIpConfigurations;
        private string creatableNetworkSecurityGroupKey;
        private INetworkSecurityGroup existingNetworkSecurityGroupToAssociate;
        private IPublicIpAddress primaryPublicIp;
        private INetwork primaryNetwork;
        private INetworkSecurityGroup networkSecurityGroup;
        private ResourceNamer namer;

        private NetworkInterfaceImpl(string name, NetworkInterfaceInner innerModel, NetworkInterfacesOperations client, NetworkManager networkManager) :
             base(name, innerModel, networkManager)
        {

            this.client = client;
            this.nicName = name;
            this.namer = new ResourceNamer(this.nicName);
            this.InitializeNicIpConfigurations();
        }

        public ResourceNamer Namer
        {
            get
            {
                return this.namer;
            }
        }

        public async override Task<INetworkInterface> Refresh()
        {
            var response = await client.GetWithHttpMessagesAsync(this.ResourceGroupName, this.nicName);
            SetInner(response.Body);
            return this;
        }

        public NetworkInterfaceImpl WithNewPrimaryNetwork(ICreatable<INetwork> creatable)
        {
            this.PrimaryIpConfiguration().WithNewNetwork(creatable);
            return this;
        }

        public NetworkInterfaceImpl WithNewPrimaryNetwork(string name, string addressSpaceCidr)
        {
            this.PrimaryIpConfiguration().WithNewNetwork(name, addressSpaceCidr);
            return this;
        }

        public NetworkInterfaceImpl WithNewPrimaryNetwork(string addressSpaceCidr)
        {
            this.PrimaryIpConfiguration().WithNewNetwork(addressSpaceCidr);
            return this;
        }

        public NetworkInterfaceImpl WithExistingPrimaryNetwork(INetwork network)
        {
            this.PrimaryIpConfiguration().WithExistingNetwork(network);
            return this;
        }

        public NetworkInterfaceImpl WithNewPrimaryPublicIpAddress(ICreatable<IPublicIpAddress> creatable)
        {

            this.PrimaryIpConfiguration().WithNewPublicIpAddress(creatable);
            return this;
        }

        public NetworkInterfaceImpl WithNewPrimaryPublicIpAddress()
        {
            this.PrimaryIpConfiguration().WithNewPublicIpAddress();
            return this;
        }

        public NetworkInterfaceImpl WithNewPrimaryPublicIpAddress(string leafDnsLabel)
        {
            this.PrimaryIpConfiguration().WithNewPublicIpAddress(leafDnsLabel);
            return this;
        }

        public NetworkInterfaceImpl WithoutPrimaryPublicIpAddress()
        {
            this.PrimaryIpConfiguration().WithoutPublicIpAddress();
            return this;
        }

        public NetworkInterfaceImpl WithExistingPrimaryPublicIpAddress(IPublicIpAddress publicIpAddress)
        {
            this.PrimaryIpConfiguration().WithExistingPublicIpAddress(publicIpAddress);
            return this;
        }

        public NetworkInterfaceImpl WithPrimaryPrivateIpAddressDynamic()
        {
            this.PrimaryIpConfiguration().WithPrivateIpAddressDynamic();
            return this;
        }

        public NetworkInterfaceImpl WithPrimaryPrivateIpAddressStatic(string staticPrivateIpAddress)
        {
            this.PrimaryIpConfiguration().WithPrivateIpAddressStatic(staticPrivateIpAddress);
            return this;
        }

        public NetworkInterfaceImpl WithNewNetworkSecurityGroup(ICreatable<INetworkSecurityGroup> creatable)
        {
            if (this.creatableNetworkSecurityGroupKey == null)
            {
                this.creatableNetworkSecurityGroupKey = creatable.Key;
                this.AddCreatableDependency(creatable as IResourceCreator<IResource>);
            }

            return this;
        }

        public NetworkInterfaceImpl WithExistingNetworkSecurityGroup(INetworkSecurityGroup networkSecurityGroup)
        {

            this.existingNetworkSecurityGroupToAssociate = networkSecurityGroup;
            return this;
        }

        public NetworkInterfaceImpl WithoutNetworkSecurityGroup()
        {
            this.Inner.NetworkSecurityGroup = null;
            return this;
        }

        public NicIpConfiguration.UpdateDefinition.IBlank<NetworkInterface.Update.IUpdate> DefineSecondaryIpConfiguration(string name)
        {
            return PrepareNewNicIpConfiguration(name);
        }

        public NicIpConfiguration.Update.IUpdate UpdateIpConfiguration(string name)
        {

            foreach (INicIpConfiguration nicIpConfiguration in this.nicIpConfigurations)
            {
                if (name.Equals(nicIpConfiguration.Name, StringComparison.OrdinalIgnoreCase))
                {
                    return (NicIpConfigurationImpl)nicIpConfiguration;
                }
            }

            throw new Exception("IP configuration '" + name + "' not found");
        }

        public NetworkInterfaceImpl WithIpForwarding()
        {
            this.Inner.EnableIPForwarding = true;
            return this;
        }

        public NetworkInterfaceImpl WithoutIpForwarding()
        {
            this.Inner.EnableIPForwarding = false;
            return this;
        }

        public NetworkInterfaceImpl WithDnsServer(string ipAddress)
        {
            this.DnsServerIps.Add(ipAddress);
            return this;
        }

        public NetworkInterfaceImpl WithoutDnsServer(string ipAddress)
        {
            this.DnsServerIps.Remove(ipAddress);
            return this;
        }

        public NetworkInterfaceImpl WithAzureDnsServer()
        {
            this.DnsServerIps.Clear();
            return this;
        }

        public NetworkInterfaceImpl WithSubnet(string name)
        {
            this.PrimaryIpConfiguration().WithSubnet(name);
            return this;
        }

        public NetworkInterfaceImpl WithInternalDnsNameLabel(string dnsNameLabel)
        {
            this.Inner.DnsSettings.InternalDnsNameLabel = dnsNameLabel;
            return this;
        }

        public bool? IsIpForwardingEnabled
        {
            get
            {
                return this.Inner.EnableIPForwarding;
            }
        }
        public string MacAddress
        {
            get
            {
                return this.Inner.MacAddress;
            }
        }
        public string InternalDnsNameLabel
        {
            get
            {
                return this.Inner.DnsSettings.InternalDnsNameLabel;
            }
        }
        public string InternalFqdn
        {
            get
            {
                return this.Inner.DnsSettings.InternalFqdn;
            }
        }
        public IList<string> DnsServers
        {
            get
            {
                return this.DnsServerIps;


                return null;
            }
        }
        public IPublicIpAddress PrimaryPublicIpAddress()
        {

            if (this.primaryPublicIp == null)
            {
                this.primaryPublicIp = this.PrimaryIpConfiguration().PublicIpAddress();
            }
            return primaryPublicIp;
        }

        public string PrimarySubnetId
        {
            get
            {
                return this.PrimaryIpConfiguration().SubnetId;
            }
        }
        public INetwork PrimaryNetwork()
        {
            if (this.primaryNetwork == null)
            {
                this.primaryNetwork = this.PrimaryIpConfiguration().Network();
            }
            return this.primaryNetwork;
        }

        public string PrimaryPrivateIp
        {
            get
            {
                return this.PrimaryIpConfiguration().PrivateIp;
            }
        }

        public string PrimaryPrivateIpAllocationMethod
        {
            get
            {
                return this.PrimaryIpConfiguration().PrivateIpAllocationMethod;
            }
        }
        public IList<INicIpConfiguration> IpConfigurations()
        {
            //TODO: make readonly collection
            return this.nicIpConfigurations;
        }

        public string NetworkSecurityGroupId
        {
            get
            {
                if (this.Inner.NetworkSecurityGroup != null)
                {
                    return this.Inner.NetworkSecurityGroup.Id;
                }

                return null;
            }
        }
        public INetworkSecurityGroup NetworkSecurityGroup()
        {

            if (this.networkSecurityGroup == null && this.NetworkSecurityGroup().Id != null)
            {
                String id = this.NetworkSecurityGroup().Id;
                    this.networkSecurityGroup = base.MyManager
                        .NetworkSecurityGroups
                        .GetByGroup(ResourceUtils.GroupFromResourceId(id),
                            ResourceUtils.NameFromResourceId(id));
            }

            return this.networkSecurityGroup;
        }

        /// <returns>the primary IP configuration of the network interface</returns>
        public NicIpConfigurationImpl PrimaryIpConfiguration()
        {

            if (this.nicPrimaryIpConfiguration != null)
            {
                return this.nicPrimaryIpConfiguration;
            }

            if (this.IsInCreateMode)
            {
                this.nicPrimaryIpConfiguration = PrepareNewNicIpConfiguration("primary-nic-config");
                WithIpConfiguration(this.nicPrimaryIpConfiguration);
            }
            else
            {
                // Currently Azure supports only one IP configuration and that is the primary
                // hence we pick the first one here.
                // when Azure support multiple IP configurations then there will be a flag in
                // the IPConfiguration or a property in the network interface to identify the
                // primary so below logic will be changed.
                this.nicPrimaryIpConfiguration = (NicIpConfigurationImpl)this.nicIpConfigurations[0];
            }

            return this.nicPrimaryIpConfiguration;
        }
        
        public async override Task<INetworkInterface> CreateResourceAsync(CancellationToken cancellationToken)
        {

            NetworkInterfaceImpl self = this;
            NicIpConfigurationImpl.EnsureConfigurations(this.nicIpConfigurations);
            var data= await this.client.CreateOrUpdateAsync(this.ResourceGroupName, this.nicName, this.Inner);
            this.SetInner(data);
            this.ClearCachedRelatedResources();
            this.InitializeNicIpConfigurations();

            return this;
        }

        /// <returns>the list of DNS server IPs from the DNS settings</returns>
        private IList<string> DnsServerIps
        {
            get
            {
                if (this.Inner.DnsSettings.DnsServers == null)
                {
                    this.Inner.DnsSettings.DnsServers = new List<string>();
                }

                return this.Inner.DnsSettings.DnsServers;
            }
        }
        /// <summary>
        /// Initializes the list of {@link NicIpConfiguration} that wraps {@link NetworkInterfaceInner#IpConfigurations()}.
        /// </summary>
        private void InitializeNicIpConfigurations()
        {
            if (this.Inner.IpConfigurations == null)
            {
                this.Inner.IpConfigurations = new List<NetworkInterfaceIPConfigurationInner>();
            }

            this.nicIpConfigurations = new List<INicIpConfiguration>();
            foreach (NetworkInterfaceIPConfigurationInner ipConfig in this.Inner.IpConfigurations)
            {
                NicIpConfigurationImpl nicIpConfiguration = new NicIpConfigurationImpl(ipConfig,
                    this,
                    base.MyManager,
                    false);
                this.nicIpConfigurations.Add(nicIpConfiguration);
            }
        }

        /// <summary>
        /// Gets a new IP configuration child resource {@link NicIpConfiguration} wrapping {@link NetworkInterfaceIPConfiguration}.
        /// </summary>
        /// <param name="name">name the name for the new ip configuration</param>
        /// <returns>{@link NicIpConfiguration}</returns>
        private NicIpConfigurationImpl PrepareNewNicIpConfiguration(string name)
        {

            NicIpConfigurationImpl nicIpConfiguration = NicIpConfigurationImpl.PrepareNicIpConfiguration(
                name,
                this,
                base.MyManager);
            return nicIpConfiguration;
        }

        private void ClearCachedRelatedResources()
        {
            this.primaryPublicIp = null;
            this.primaryNetwork = null;
            this.networkSecurityGroup = null;
            this.nicPrimaryIpConfiguration = null;
        }

        internal NetworkInterfaceImpl WithIpConfiguration(NicIpConfigurationImpl nicIpConfiguration)
        {
            this.nicIpConfigurations.Add(nicIpConfiguration);
            this.Inner.IpConfigurations.Add(nicIpConfiguration.Inner);
            return this;
        }

        internal void AddToCreatableDependencies<T>(ICreatable<T> creatableResource) where T : IResource
        {

            base.AddCreatableDependency(creatableResource as IResourceCreator<IResource>);

        }

        internal IResource CreatedDependencyResource(string key)
        {

            return base.CreatedResource(key);
        }

        internal ICreatable<IResourceGroup> NewGroup()
        {
            return this.newGroup;
        }

        /// <summary>
        /// Removes a DNS server associated with the network interface.
        /// </summary>
        /// <param name="ipAddress">ipAddress the IP address of the DNS server</param>
        /// <returns>the next stage of the network interface update</returns>
        Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IWithDnsServer.WithoutDnsServer(string ipAddress)
        {
            return this.WithoutDnsServer(ipAddress) as Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the IP address of the custom DNS server to associate with the network interface.
        /// <p>
        /// Note this method's effect is additive, i.e. each time it is used, the new dns server is
        /// added to the network interface.
        /// </summary>
        /// <param name="ipAddress">ipAddress the IP address of the DNS server</param>
        /// <returns>the next stage of the network interface update</returns>
        Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IWithDnsServer.WithDnsServer(string ipAddress)
        {
            return this.WithDnsServer(ipAddress) as Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate;
        }

        /// <summary>
        /// Specifies to use the default Azure DNS server for the network interface.
        /// <p>
        /// Using azure DNS server will remove any custom DNS server associated with this network interface.
        /// </summary>
        /// <returns>the next stage of the network interface update</returns>
        Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IWithDnsServer.WithAzureDnsServer()
        {
            return this.WithAzureDnsServer() as Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate;
        }

        /// <summary>
        /// Associates an existing network security group with the network interface.
        /// </summary>
        /// <param name="networkSecurityGroup">networkSecurityGroup an existing network security group</param>
        /// <returns>the next stage of the network interface update</returns>
        Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IWithNetworkSecurityGroup.WithExistingNetworkSecurityGroup(INetworkSecurityGroup networkSecurityGroup)
        {
            return this.WithExistingNetworkSecurityGroup(networkSecurityGroup) as Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that remove any network security group associated with the network interface.
        /// </summary>
        /// <returns>the next stage of the network interface update</returns>
        Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IWithNetworkSecurityGroup.WithoutNetworkSecurityGroup()
        {
            return this.WithoutNetworkSecurityGroup() as Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate;
        }

        /// <summary>
        /// Create a new network security group to associate with network interface, based on the provided definition.
        /// </summary>
        /// <param name="creatable">creatable a creatable definition for a new network security group</param>
        /// <returns>the next stage of the network interface update</returns>
        Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IWithNetworkSecurityGroup.WithNewNetworkSecurityGroup(ICreatable<INetworkSecurityGroup> creatable)
        {
            return this.WithNewNetworkSecurityGroup(creatable) as Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate;
        }

        /// <summary>
        /// Associates an existing network security group with the network interface.
        /// </summary>
        /// <param name="networkSecurityGroup">networkSecurityGroup an existing network security group</param>
        /// <returns>the next stage of the network interface definition</returns>
        Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithNetworkSecurityGroup.WithExistingNetworkSecurityGroup(INetworkSecurityGroup networkSecurityGroup)
        {
            return this.WithExistingNetworkSecurityGroup(networkSecurityGroup) as Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate;
        }

        /// <summary>
        /// Create a new network security group to associate with network interface, based on the provided definition.
        /// </summary>
        /// <param name="creatable">creatable a creatable definition for a new network security group</param>
        /// <returns>the next stage of the network interface definition</returns>
        Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithNetworkSecurityGroup.WithNewNetworkSecurityGroup(ICreatable<INetworkSecurityGroup> creatable)
        {
            return this.WithNewNetworkSecurityGroup(creatable) as Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate;
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
        Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IWithPrimaryPublicIpAddress.WithNewPrimaryPublicIpAddress(ICreatable<IPublicIpAddress> creatable)
        {
            return this.WithNewPrimaryPublicIpAddress(creatable) as Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate;
        }

        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource and associate it
        /// with the network interface's primary IP configuration.
        /// <p>
        /// the internal name and DNS label for the public IP address will be derived from the network interface name,
        /// if there is an existing public IP association then that will be removed in favour of this
        /// </summary>
        /// <returns>the next stage of the network interface update</returns>
        Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IWithPrimaryPublicIpAddress.WithNewPrimaryPublicIpAddress()
        {
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
        Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IWithPrimaryPublicIpAddress.WithNewPrimaryPublicIpAddress(string leafDnsLabel)
        {
            return this.WithNewPrimaryPublicIpAddress(leafDnsLabel) as Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that remove any public IP associated with the network interface's primary IP configuration.
        /// </summary>
        /// <returns>the next stage of the network interface update</returns>
        Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IWithPrimaryPublicIpAddress.WithoutPrimaryPublicIpAddress()
        {
            return this.WithoutPrimaryPublicIpAddress() as Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate;
        }

        /// <summary>
        /// Associates an existing public IP address with the network interface's primary IP configuration.
        /// if there is an existing public IP association then that will be removed in favour of this
        /// </summary>
        /// <param name="publicIpAddress">publicIpAddress an existing public IP address</param>
        /// <returns>the next stage of the network interface update</returns>
        Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IWithPrimaryPublicIpAddress.WithExistingPrimaryPublicIpAddress(IPublicIpAddress publicIpAddress)
        {
            return this.WithExistingPrimaryPublicIpAddress(publicIpAddress) as Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate;
        }

        /// <summary>
        /// Create a new public IP address to associate with network interface's primary IP configuration, based on
        /// the provided definition.
        /// </summary>
        /// <param name="creatable">creatable a creatable definition for a new public IP</param>
        /// <returns>the next stage of the network interface definition</returns>
        Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithPrimaryPublicIpAddress.WithNewPrimaryPublicIpAddress(ICreatable<IPublicIpAddress> creatable)
        {
            return this.WithNewPrimaryPublicIpAddress(creatable) as Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate;
        }

        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource and associate it
        /// with the network interface's primary IP configuration.
        /// <p>
        /// the internal name and DNS label for the public IP address will be derived from the network interface name
        /// </summary>
        /// <returns>the next stage of the network interface definition</returns>
        Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithPrimaryPublicIpAddress.WithNewPrimaryPublicIpAddress()
        {
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
        Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithPrimaryPublicIpAddress.WithNewPrimaryPublicIpAddress(string leafDnsLabel)
        {
            return this.WithNewPrimaryPublicIpAddress(leafDnsLabel) as Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate;
        }

        /// <summary>
        /// Associates an existing public IP address with the network interface's primary IP configuration.
        /// </summary>
        /// <param name="publicIpAddress">publicIpAddress an existing public IP address</param>
        /// <returns>the next stage of the network interface definition</returns>
        Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithPrimaryPublicIpAddress.WithExistingPrimaryPublicIpAddress(IPublicIpAddress publicIpAddress)
        {
            return this.WithExistingPrimaryPublicIpAddress(publicIpAddress) as Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate;
        }

        /// <summary>
        /// Enables dynamic private IP address allocation within the specified existing virtual network
        /// subnet for the network interface's primary IP configuration.
        /// </summary>
        /// <returns>the next stage of network interface update</returns>
        Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IWithPrimaryPrivateIp.WithPrimaryPrivateIpAddressDynamic()
        {
            return this.WithPrimaryPrivateIpAddressDynamic() as Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate;
        }

        /// <summary>
        /// Assigns the specified static private IP address within the specified existing virtual network
        /// subnet to the network interface's primary IP configuration.
        /// </summary>
        /// <param name="staticPrivateIpAddress">staticPrivateIpAddress the static IP address within the specified subnet to assign to</param>
        /// <param name="the">the primary IP configuration</param>
        /// <returns>the next stage of network interface update</returns>
        Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IWithPrimaryPrivateIp.WithPrimaryPrivateIpAddressStatic(string staticPrivateIpAddress)
        {
            return this.WithPrimaryPrivateIpAddressStatic(staticPrivateIpAddress) as Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate;
        }

        /// <summary>
        /// Enables dynamic private IP address allocation within the specified existing virtual network
        /// subnet for the network interface's primary IP configuration.
        /// </summary>
        /// <returns>the next stage of network interface definition</returns>
        Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithPrimaryPrivateIp.WithPrimaryPrivateIpAddressDynamic()
        {
            return this.WithPrimaryPrivateIpAddressDynamic() as Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate;
        }

        /// <summary>
        /// Assigns the specified static private IP address within the specified existing virtual network
        /// subnet to the network interface's primary IP configuration.
        /// </summary>
        /// <param name="staticPrivateIpAddress">staticPrivateIpAddress the static IP address within the specified subnet to assign to</param>
        /// <param name="the">the network interface</param>
        /// <returns>the next stage of network interface definition</returns>
        Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithPrimaryPrivateIp.WithPrimaryPrivateIpAddressStatic(string staticPrivateIpAddress)
        {
            return this.WithPrimaryPrivateIpAddressStatic(staticPrivateIpAddress) as Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate;
        }

        /// <summary>
        /// Enable IP forwarding in the network interface.
        /// </summary>
        /// <returns>the next stage of the network interface definition</returns>
        Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate.WithIpForwarding()
        {
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
        Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate.WithDnsServer(string ipAddress)
        {
            return this.WithDnsServer(ipAddress) as Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the internal DNS name label for the network interface.
        /// </summary>
        /// <param name="dnsNameLabel">dnsNameLabel the internal DNS name label</param>
        /// <returns>the next stage of the network interface definition</returns>
        Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate.WithInternalDnsNameLabel(string dnsNameLabel)
        {
            return this.WithInternalDnsNameLabel(dnsNameLabel) as Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate;
        }

        /// <summary>
        /// Gets the public IP address associated with this network interface.
        /// <p>
        /// This method makes a rest API call to fetch the public IP.
        /// </summary>
        /// <returns>the public IP associated with this network interface</returns>
        Microsoft.Azure.Management.V2.Network.IPublicIpAddress Microsoft.Azure.Management.V2.Network.INetworkInterface.PrimaryPublicIpAddress
        {
            get
            {
                return this.PrimaryPublicIpAddress() as Microsoft.Azure.Management.V2.Network.IPublicIpAddress;
            }
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
        Microsoft.Azure.Management.V2.Network.INetwork Microsoft.Azure.Management.V2.Network.INetworkInterface.PrimaryNetwork
        {
            get
            {
                return this.PrimaryNetwork() as Microsoft.Azure.Management.V2.Network.INetwork;
            }
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
        System.Collections.Generic.IList<INicIpConfiguration> Microsoft.Azure.Management.V2.Network.INetworkInterface.IpConfigurations()
        {
            return this.IpConfigurations() as System.Collections.Generic.IList<INicIpConfiguration>;
        }

        /// <returns>the primary IP configuration of this network interface</returns>
        Microsoft.Azure.Management.V2.Network.INicIpConfiguration Microsoft.Azure.Management.V2.Network.INetworkInterface.PrimaryIpConfiguration
        {
            get
            {
                return this.PrimaryIpConfiguration() as Microsoft.Azure.Management.V2.Network.INicIpConfiguration;
            }
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
        Microsoft.Azure.Management.V2.Network.INetworkSecurityGroup Microsoft.Azure.Management.V2.Network.INetworkInterface.NetworkSecurityGroup
        {
            get
            {
                return this.NetworkSecurityGroup() as Microsoft.Azure.Management.V2.Network.INetworkSecurityGroup;
            }
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
        /// Starts definition of a secondary IP configuration.
        /// </summary>
        /// <param name="name">name name for the IP configuration</param>
        /// <returns>the first stage of a secondary IP configuration definition</returns>
        Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Definition.IBlank<IWithCreate> Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithSecondaryIpConfiguration.DefineSecondaryIpConfiguration(string name)
        {
            return this.DefineSecondaryIpConfiguration(name) as Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Definition.IBlank<IWithCreate>;
        }

        /// <summary>
        /// Associate an existing virtual network with the network interface's primary IP configuration.
        /// </summary>
        /// <param name="network">network an existing virtual network</param>
        /// <returns>the next stage of the network interface definition</returns>
        Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithPrimaryNetworkSubnet Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithPrimaryNetwork.WithExistingPrimaryNetwork(INetwork network)
        {
            return this.WithExistingPrimaryNetwork(network) as Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithPrimaryNetworkSubnet;
        }

        /// <summary>
        /// Create a new virtual network to associate with the network interface's primary IP configuration,
        /// based on the provided definition.
        /// </summary>
        /// <param name="creatable">creatable a creatable definition for a new virtual network</param>
        /// <returns>the next stage of the network interface definition</returns>
        Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithPrimaryPrivateIp Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithPrimaryNetwork.WithNewPrimaryNetwork(ICreatable<INetwork> creatable)
        {
            return this.WithNewPrimaryNetwork(creatable) as Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithPrimaryPrivateIp;
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
        Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithPrimaryPrivateIp Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithPrimaryNetwork.WithNewPrimaryNetwork(string name, string addressSpace)
        {
            return this.WithNewPrimaryNetwork(name, addressSpace) as Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithPrimaryPrivateIp;
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
        Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithPrimaryPrivateIp Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithPrimaryNetwork.WithNewPrimaryNetwork(string addressSpace)
        {
            return this.WithNewPrimaryNetwork(addressSpace) as Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithPrimaryPrivateIp;
        }

        /// <summary>
        /// Starts update of an IP configuration.
        /// </summary>
        /// <param name="name">name name of the IP configuration</param>
        /// <returns>the first stage of an IP configuration update</returns>
        Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Update.IUpdate Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IWithIpConfiguration.UpdateIpConfiguration(string name)
        {
            return this.UpdateIpConfiguration(name) as Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Starts definition of a secondary IP configuration.
        /// </summary>
        /// <param name="name">name name for the IP configuration</param>
        /// <returns>the first stage of a secondary IP configuration definition</returns>
        Microsoft.Azure.Management.V2.Network.NicIpConfiguration.UpdateDefinition.IBlank<IUpdate> Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IWithIpConfiguration.DefineSecondaryIpConfiguration(string name)
        {
            return this.DefineSecondaryIpConfiguration(name) as Microsoft.Azure.Management.V2.Network.NicIpConfiguration.UpdateDefinition.IBlank<IUpdate>;
        }

        /// <summary>
        /// Associate a subnet with the network interface.
        /// </summary>
        /// <param name="name">name the subnet name</param>
        /// <returns>the next stage of the network interface update</returns>
        Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IWithPrimaryNetworkSubnet.WithSubnet(string name)
        {
            return this.WithSubnet(name) as Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate;
        }

        /// <summary>
        /// Associate a subnet with the network interface's primary IP configuration.
        /// </summary>
        /// <param name="name">name the subnet name</param>
        /// <returns>the next stage of the network interface definition</returns>
        Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithPrimaryPrivateIp Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithPrimaryNetworkSubnet.WithSubnet(string name)
        {
            return this.WithSubnet(name) as Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithPrimaryPrivateIp;
        }
        
        /// <summary>
        /// Enable IP forwarding in the network interface.
        /// </summary>
        /// <returns>the next stage of the network interface update</returns>
        Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IWithIpForwarding.WithIpForwarding()
        {
            return this.WithIpForwarding() as Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate;
        }

        /// <summary>
        /// Disable IP forwarding in the network interface.
        /// </summary>
        /// <returns>the next stage of the network interface update</returns>
        Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IWithIpForwarding.WithoutIpForwarding()
        {
            return this.WithoutIpForwarding() as Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate;
        }
    }
}