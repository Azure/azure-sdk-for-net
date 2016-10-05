// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Fluent.Network
{

    using NetworkInterface.Update;
    using Management.Network.Models;
    using NetworkInterface.Definition;
    using System.Collections.Generic;
    using Resource.Core.ResourceActions;
    using Resource;
    using Resource.Core;
    using Management.Network;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for NetworkInterface and its create and update interfaces.
    /// </summary>
    public partial class NetworkInterfaceImpl :
        GroupableParentResource<INetworkInterface,
                NetworkInterfaceInner,
                Rest.Azure.Resource,
                NetworkInterfaceImpl,
                NetworkManager,
                IWithGroup,
                IWithPrimaryNetwork,
                IWithCreate,
                IUpdate>,
            INetworkInterface,
            IDefinition,
            IUpdate

    {
        private INetworkInterfacesOperations innerCollection;
        private string nicName;
        protected ResourceNamer namer;
        private NicIpConfigurationImpl nicPrimaryIpConfiguration;
        private IDictionary<string, INicIpConfiguration> nicIpConfigurations;
        private string creatableNetworkSecurityGroupKey;
        private INetworkSecurityGroup existingNetworkSecurityGroupToAssociate;
        private INetworkSecurityGroup networkSecurityGroup;

        internal NetworkInterfaceImpl(
            string name,
            NetworkInterfaceInner innerModel,
            INetworkInterfacesOperations client,
            NetworkManager networkManager) : base(name, innerModel, networkManager)
        {
            this.innerCollection = client;
            this.nicName = name;
            this.namer = new ResourceNamer(this.nicName);
            InitializeChildrenFromInner();
        }

        internal NetworkInterfaceImpl WithNewPrimaryNetwork(ICreatable<INetwork> creatable)
        {
            PrimaryIpConfiguration().WithNewNetwork(creatable);
            return this;
        }

        internal NetworkInterfaceImpl WithNewPrimaryNetwork(string name, string addressSpaceCidr)
        {
            PrimaryIpConfiguration().WithNewNetwork(name, addressSpaceCidr);
            return this;
        }

        public override INetworkInterface Refresh()
        {
            var response = this.innerCollection.Get(ResourceGroupName, nicName);
            SetInner(response);
            return this;
        }

        internal NetworkInterfaceImpl WithNewPrimaryNetwork(string addressSpaceCidr)
        {
            PrimaryIpConfiguration().WithNewNetwork(addressSpaceCidr);
            return this;
        }

        internal NetworkInterfaceImpl WithExistingPrimaryNetwork(INetwork network)
        {
            PrimaryIpConfiguration().WithExistingNetwork(network);
            return this;
        }

        internal NetworkInterfaceImpl WithNewPrimaryPublicIpAddress(ICreatable<IPublicIpAddress> creatable)
        {
            PrimaryIpConfiguration().WithNewPublicIpAddress(creatable);
            return this;
        }

        internal NetworkInterfaceImpl WithNewPrimaryPublicIpAddress()
        {
            PrimaryIpConfiguration().WithNewPublicIpAddress();
            return this;
        }

        internal NetworkInterfaceImpl WithNewPrimaryPublicIpAddress(string leafDnsLabel)
        {
            PrimaryIpConfiguration().WithNewPublicIpAddress(leafDnsLabel);
            return this;
        }

        internal NetworkInterfaceImpl WithExistingLoadBalancerBackend(ILoadBalancer loadBalancer, string backendName)
        {
            PrimaryIpConfiguration().WithExistingLoadBalancerBackend(loadBalancer, backendName);
            return this;
        }

        internal NetworkInterfaceImpl WithExistingLoadBalancerInboundNatRule(ILoadBalancer loadBalancer, string inboundNatRuleName)
        {
            PrimaryIpConfiguration().WithExistingLoadBalancerInboundNatRule(loadBalancer, inboundNatRuleName);
            return this;
        }

        internal IUpdate WithoutLoadBalancerBackends()
        {
            foreach (var ipConfig in IpConfigurations().Values)
            {
                UpdateIpConfiguration(ipConfig.Name)
                   .WithoutLoadBalancerBackends();
            }

            return this;
        }

        internal IUpdate WithoutLoadBalancerInboundNatRules()
        {
            foreach (var ipConfig in IpConfigurations().Values)
            {
                UpdateIpConfiguration(ipConfig.Name)
                    .WithoutLoadBalancerInboundNatRules();
            }

            return this;
        }

        internal NetworkInterfaceImpl WithoutPrimaryPublicIpAddress()
        {
            this.PrimaryIpConfiguration().WithoutPublicIpAddress();
            return this;
        }

        internal NetworkInterfaceImpl WithExistingPrimaryPublicIpAddress(IPublicIpAddress publicIpAddress)
        {
            this.PrimaryIpConfiguration().WithExistingPublicIpAddress(publicIpAddress);
            return this;
        }

        internal NetworkInterfaceImpl WithPrimaryPrivateIpAddressDynamic()
        {
            this.PrimaryIpConfiguration().WithPrivateIpAddressDynamic();
            return this;
        }

        internal NetworkInterfaceImpl WithPrimaryPrivateIpAddressStatic(string staticPrivateIpAddress)
        {
            this.PrimaryIpConfiguration().WithPrivateIpAddressStatic(staticPrivateIpAddress);
            return this;
        }

        internal NetworkInterfaceImpl WithNewNetworkSecurityGroup(ICreatable<INetworkSecurityGroup> creatable)
        {
            if (this.creatableNetworkSecurityGroupKey == null)
            {
                this.creatableNetworkSecurityGroupKey = creatable.Key;
                this.AddCreatableDependency(creatable as IResourceCreator<Fluent.Resource.Core.IResource>);
            }

            return this;
        }

        internal NetworkInterfaceImpl WithExistingNetworkSecurityGroup(INetworkSecurityGroup networkSecurityGroup)
        {
            this.existingNetworkSecurityGroupToAssociate = networkSecurityGroup;
            return this;
        }

        internal NetworkInterfaceImpl WithoutNetworkSecurityGroup()
        {
            this.Inner.NetworkSecurityGroup = null;
            return this;
        }

        internal NicIpConfigurationImpl DefineSecondaryIpConfiguration(string name)
        {
            return PrepareNewNicIpConfiguration(name);
        }

        internal NicIpConfigurationImpl UpdateIpConfiguration(string name)
        {
            return (NicIpConfigurationImpl)this.nicIpConfigurations[name];
        }

        internal NetworkInterfaceImpl WithIpForwarding()
        {
            Inner.EnableIPForwarding = true;
            return this;
        }

        internal NetworkInterfaceImpl WithoutIpConfiguration(string name)
        {
            nicIpConfigurations.Remove(name);
            return this;
        }

        internal NetworkInterfaceImpl WithoutIpForwarding()
        {
            Inner.EnableIPForwarding = false;
            return this;
        }

        internal NetworkInterfaceImpl WithDnsServer(string ipAddress)
        {
            DnsServerIps.Add(ipAddress);
            return this;
        }

        internal NetworkInterfaceImpl WithoutDnsServer(string ipAddress)
        {
            DnsServerIps.Remove(ipAddress);
            return this;
        }

        internal NetworkInterfaceImpl WithAzureDnsServer()
        {
            DnsServerIps.Clear();
            return this;
        }

        internal NetworkInterfaceImpl WithSubnet(string name)
        {
            PrimaryIpConfiguration().WithSubnet(name);
            return this;
        }

        internal NetworkInterfaceImpl WithInternalDnsNameLabel(string dnsNameLabel)
        {
            Inner.DnsSettings.InternalDnsNameLabel = dnsNameLabel;
            return this;
        }

        internal string VirtualMachineId()
        {
            return (Inner.VirtualMachine != null) ? Inner.VirtualMachine.Id : null;
        }

        internal bool IsIpForwardingEnabled()
        {
            return (Inner.EnableIPForwarding.HasValue) ? Inner.EnableIPForwarding.Value : false;
        }

        internal string MacAddress()
        {
            return Inner.MacAddress;
        }

        internal string InternalDnsNameLabel()
        {
            return (Inner.DnsSettings != null) ? Inner.DnsSettings.InternalDnsNameLabel : null;
        }

        internal string InternalDomainNameSuffix()
        {
            return (Inner.DnsSettings != null) ? Inner.DnsSettings.InternalDomainNameSuffix : null;
        }

        internal IList<string> AppliedDnsServers()
        {
            List<string> dnsServers = new List<string>();
            if (Inner.DnsSettings == null)
                return dnsServers;
            else if (Inner.DnsSettings.AppliedDnsServers == null)
                return dnsServers;
            else
                return Inner.DnsSettings.AppliedDnsServers;
        }

        internal string InternalFqdn()
        {
            return (Inner.DnsSettings != null) ? Inner.DnsSettings.InternalFqdn : null;
        }

        internal IList<string> DnsServers()
        {
            return DnsServerIps;
        }

        internal string PrimaryPrivateIp()
        {
            return PrimaryIpConfiguration().PrivateIpAddress();
        }

        internal string PrimaryPrivateIpAllocationMethod()
        {
            return PrimaryIpConfiguration().PrivateIpAllocationMethod();
        }

        internal IDictionary<string, INicIpConfiguration> IpConfigurations()
        {
            return nicIpConfigurations;
        }

        internal string NetworkSecurityGroupId()
        {
            return (Inner.NetworkSecurityGroup != null) ? Inner.NetworkSecurityGroup.Id : null;
        }

        internal INetworkSecurityGroup GetNetworkSecurityGroup()
        {
            if (networkSecurityGroup == null && NetworkSecurityGroupId() != null)
            {
                string id = NetworkSecurityGroupId();
                networkSecurityGroup = base.Manager
                    .NetworkSecurityGroups
                    .GetByGroup(ResourceUtils.GroupFromResourceId(id), ResourceUtils.NameFromResourceId(id));
            }
            return networkSecurityGroup;
        }

        /// <returns>the primary IP configuration of the network interface</returns>
        internal NicIpConfigurationImpl PrimaryIpConfiguration()
        {
            if (nicPrimaryIpConfiguration != null)
            {
                return nicPrimaryIpConfiguration;
            }

            if (IsInCreateMode)
            {
                nicPrimaryIpConfiguration = PrepareNewNicIpConfiguration("primary");
                WithIpConfiguration(nicPrimaryIpConfiguration);
            }
            else
            {
                // TODO: Currently Azure supports only one IP configuration and that is the primary
                // hence we pick the first one here.
                // when Azure support multiple IP configurations then there will be a flag in
                // the IPConfiguration or a property in the network interface to identify the
                // primary so below logic will be changed.
                nicPrimaryIpConfiguration = (NicIpConfigurationImpl)new List<INicIpConfiguration>(
                    nicIpConfigurations.Values)[0];
            }
            return nicPrimaryIpConfiguration;
        }

        /// <returns>the list of DNS server IPs from the DNS settings</returns>
        private IList<string> DnsServerIps
        {
            get
            {
                List<string> dnsServers = new List<string>();
                if (Inner.DnsSettings == null)
                    return dnsServers;
                else if (Inner.DnsSettings.DnsServers == null)
                    return dnsServers;
                else
                    return Inner.DnsSettings.DnsServers;
            }
        }

        override protected void InitializeChildrenFromInner()
        {
            nicIpConfigurations = new Dictionary<string, INicIpConfiguration>();
            IList<NetworkInterfaceIPConfigurationInner> inners = Inner.IpConfigurations;
            if (inners != null)
            {
                foreach (NetworkInterfaceIPConfigurationInner inner in inners)
                {
                    NicIpConfigurationImpl nicIpConfiguration = new NicIpConfigurationImpl(inner, this, Manager, false);
                    nicIpConfigurations.Add(nicIpConfiguration.Name(), nicIpConfiguration);
                }
            }
        }

        /// <summary>
        /// Gets a new IP configuration child resource NicIpConfiguration wrapping NetworkInterfaceIPConfigurationInner.
        /// </summary>
        /// <param name="name">name the name for the new ip configuration</param>
        /// <returns>NicIpConfiguration</returns>
        private NicIpConfigurationImpl PrepareNewNicIpConfiguration(string name)
        {
            NicIpConfigurationImpl nicIpConfiguration = NicIpConfigurationImpl.PrepareNicIpConfiguration(name, this, Manager);
            return nicIpConfiguration;
        }

        private void ClearCachedRelatedResources()
        {
            networkSecurityGroup = null;
            nicPrimaryIpConfiguration = null;
        }

        internal NetworkInterfaceImpl WithIpConfiguration(NicIpConfigurationImpl nicIpConfiguration)
        {
            nicIpConfigurations.Add(nicIpConfiguration.Name(), nicIpConfiguration);
            return this;
        }

        internal void AddToCreatableDependencies(IResourceCreator<Fluent.Resource.Core.IResource> creatableResource)
        {
            AddCreatableDependency(creatableResource);
        }

        internal Fluent.Resource.Core.IResource CreatedDependencyResource(string key)
        {
            return CreatedResource(key);
        }

        internal ICreatable<IResourceGroup> NewGroup()
        {
            return newGroup;
        }

        override protected Task<NetworkInterfaceInner> CreateInner()
        {
            return innerCollection.CreateOrUpdateAsync(ResourceGroupName, Name, Inner);
        }

        override protected void AfterCreating()
        {
            ClearCachedRelatedResources();
        }

        override protected void BeforeCreating()
        {
            INetworkSecurityGroup networkSecurityGroup = null;
            if (creatableNetworkSecurityGroupKey != null)
            {
                networkSecurityGroup = (INetworkSecurityGroup)this.CreatedResource(creatableNetworkSecurityGroupKey);
            }
            else if (existingNetworkSecurityGroupToAssociate != null)
            {
                networkSecurityGroup = existingNetworkSecurityGroupToAssociate;
            }

            // Associate an NSG if needed
            if (networkSecurityGroup != null)
            {
                Inner.NetworkSecurityGroup =
                    Manager.NetworkSecurityGroups.GetById(networkSecurityGroup.Id).Inner;
            }

            NicIpConfigurationImpl.EnsureConfigurations(new List<INicIpConfiguration>(nicIpConfigurations.Values));

            // Reset and update IP configs
            Inner.IpConfigurations =
                InnersFromWrappers<NetworkInterfaceIPConfigurationInner, INicIpConfiguration>(nicIpConfigurations.Values);
        }
    }
}