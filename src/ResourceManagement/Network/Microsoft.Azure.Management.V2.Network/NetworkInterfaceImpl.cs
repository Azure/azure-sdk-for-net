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
    using System.Collections.ObjectModel;

    /// <summary>
    /// Implementation for {@link NetworkInterface} and its create and update interfaces.
    /// </summary>
    public partial class NetworkInterfaceImpl :
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
        private INetworkInterfacesOperations client;
        private string nicName;
        private NicIpConfigurationImpl nicPrimaryIpConfiguration;
        private IList<INicIpConfiguration> nicIpConfigurations;
        private string creatableNetworkSecurityGroupKey;
        private INetworkSecurityGroup existingNetworkSecurityGroupToAssociate;
        private IPublicIpAddress primaryPublicIp;
        private INetwork primaryNetwork;
        private INetworkSecurityGroup networkSecurityGroup;
        private ResourceNamer namer;

        internal NetworkInterfaceImpl(string name, NetworkInterfaceInner innerModel, INetworkInterfacesOperations client, NetworkManager networkManager) :
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
            return new ReadOnlyCollection<INicIpConfiguration>(this.nicIpConfigurations);
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

    }
}