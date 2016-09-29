// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Fluent.Network
{

    using Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Update;
    using Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Management.Fluent.Network.NetworkInterface.Definition;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Fluent.Resource.Core.ResourceActions;
    using Microsoft.Azure.Management.Fluent.Resource;
    using Microsoft.Azure.Management.Fluent.Resource.Core;
    using Management.Network;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for {@link NetworkInterface} and its create and update interfaces.
    /// </summary>
    public partial class NetworkInterfaceImpl :
        GroupableParentResource<INetworkInterface,
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
        private INetworkInterfacesOperations innerCollection;
        private string nicName;
        protected ResourceNamer namer;
        private NicIpConfigurationImpl nicPrimaryIpConfiguration;
        private IDictionary<string,Microsoft.Azure.Management.Fluent.Network.INicIpConfiguration> nicIpConfigurations;
        private string creatableNetworkSecurityGroupKey;
        private INetworkSecurityGroup existingNetworkSecurityGroupToAssociate;
        private INetworkSecurityGroup networkSecurityGroup;
        internal  NetworkInterfaceImpl(
            string name,
            NetworkInterfaceInner innerModel,
            INetworkInterfacesOperations client,
            NetworkManager networkManager) : base(name, innerModel, networkManager)
        {

            //$ NetworkInterfaceInner innerModel,
            //$ final NetworkInterfacesInner client,
            //$ final NetworkManager networkManager) {
            //$ super(name, innerModel, networkManager);
            //$ this.innerCollection = client;
            //$ this.nicName = name;
            //$ this.namer = new ResourceNamer(this.nicName);
            //$ initializeChildrenFromInner();
            //$ }

        }

        public NetworkInterfaceImpl WithNewPrimaryNetwork (ICreatable<Microsoft.Azure.Management.Fluent.Network.INetwork> creatable)
        {

            //$ this.primaryIpConfiguration().withNewNetwork(creatable);
            //$ return this;

            return this;
        }

        public NetworkInterfaceImpl WithNewPrimaryNetwork(string name, string addressSpaceCidr)
        {

            //$ this.primaryIpConfiguration().withNewNetwork(name, addressSpaceCidr);
            //$ return this;
            return this;
        }

        public override INetworkInterface Refresh()
        {
            var response = this.innerCollection.Get(ResourceGroupName, nicName);
            SetInner(response);
            return this;
        }

        public NetworkInterfaceImpl WithNewPrimaryNetwork (string addressSpaceCidr)
        {

            //$ this.primaryIpConfiguration().withNewNetwork(addressSpaceCidr);
            //$ return this;

            return this;
        }

        public NetworkInterfaceImpl WithExistingPrimaryNetwork (INetwork network)
        {

            //$ this.primaryIpConfiguration().withExistingNetwork(network);
            //$ return this;

            return this;
        }

        public NetworkInterfaceImpl WithNewPrimaryPublicIpAddress (ICreatable<Microsoft.Azure.Management.Fluent.Network.IPublicIpAddress> creatable)
        {

            //$ this.primaryIpConfiguration().withNewPublicIpAddress(creatable);
            //$ return this;

            return this;
        }

        public NetworkInterfaceImpl WithNewPrimaryPublicIpAddress ()
        {

            //$ this.primaryIpConfiguration().withNewPublicIpAddress();
            //$ return this;

            return this;
        }

        public NetworkInterfaceImpl WithNewPrimaryPublicIpAddress (string leafDnsLabel)
        {

            //$ this.primaryIpConfiguration().withNewPublicIpAddress(leafDnsLabel);
            //$ return this;

            return this;
        }

        public NetworkInterfaceImpl WithExistingLoadBalancerBackend (ILoadBalancer loadBalancer, string backendName)
        {

            //$ this.primaryIpConfiguration().withExistingLoadBalancerBackend(loadBalancer, backendName);
            //$ return this;

            return this;
        }

        public NetworkInterfaceImpl WithExistingLoadBalancerInboundNatRule (ILoadBalancer loadBalancer, string inboundNatRuleName)
        {

            //$ this.primaryIpConfiguration().withExistingLoadBalancerInboundNatRule(loadBalancer, inboundNatRuleName);
            //$ return this;

            return this;
        }

        public IUpdate WithoutLoadBalancerBackends ()
        {

            //$ for (NicIpConfiguration ipConfig : this.ipConfigurations().values()) {
            //$ this.updateIpConfiguration(ipConfig.name())
            //$ .withoutLoadBalancerBackends();
            //$ }
            //$ return this;

            return null;
        }

        public IUpdate WithoutLoadBalancerInboundNatRules ()
        {

            //$ for (NicIpConfiguration ipConfig : this.ipConfigurations().values()) {
            //$ this.updateIpConfiguration(ipConfig.name())
            //$ .withoutLoadBalancerInboundNatRules();
            //$ }
            //$ return this;

            return null;
        }

        public NetworkInterfaceImpl WithoutPrimaryPublicIpAddress ()
        {

            //$ this.primaryIpConfiguration().withoutPublicIpAddress();
            //$ return this;

            return this;
        }

        public NetworkInterfaceImpl WithExistingPrimaryPublicIpAddress (IPublicIpAddress publicIpAddress)
        {

            //$ this.primaryIpConfiguration().withExistingPublicIpAddress(publicIpAddress);
            //$ return this;

            return this;
        }

        public NetworkInterfaceImpl WithPrimaryPrivateIpAddressDynamic ()
        {

            //$ this.primaryIpConfiguration().withPrivateIpAddressDynamic();
            //$ return this;

            return this;
        }

        public NetworkInterfaceImpl WithPrimaryPrivateIpAddressStatic (string staticPrivateIpAddress)
        {

            //$ this.primaryIpConfiguration().withPrivateIpAddressStatic(staticPrivateIpAddress);
            //$ return this;

            return this;
        }

        public NetworkInterfaceImpl WithNewNetworkSecurityGroup (ICreatable<Microsoft.Azure.Management.Fluent.Network.INetworkSecurityGroup> creatable)
        {

            //$ if (this.creatableNetworkSecurityGroupKey == null) {
            //$ this.creatableNetworkSecurityGroupKey = creatable.key();
            //$ this.addCreatableDependency(creatable);
            //$ }
            //$ return this;

            return this;
        }

        public NetworkInterfaceImpl WithExistingNetworkSecurityGroup (INetworkSecurityGroup networkSecurityGroup)
        {

            //$ this.existingNetworkSecurityGroupToAssociate = networkSecurityGroup;
            //$ return this;

            return this;
        }

        public NetworkInterfaceImpl WithoutNetworkSecurityGroup ()
        {

            //$ this.inner().withNetworkSecurityGroup(null);
            //$ return this;

            return this;
        }

        public NicIpConfigurationImpl DefineSecondaryIpConfiguration (string name)
        {

            //$ return prepareNewNicIpConfiguration(name);

            return null;
        }

        public NicIpConfigurationImpl UpdateIpConfiguration (string name)
        {

            //$ return (NicIpConfigurationImpl) this.nicIpConfigurations.get(name);

            return null;
        }

        public NetworkInterfaceImpl WithIpForwarding ()
        {

            //$ this.inner().withEnableIPForwarding(true);
            //$ return this;

            return this;
        }

        public NetworkInterfaceImpl WithoutIpConfiguration (string name)
        {

            //$ this.nicIpConfigurations.remove(name);
            //$ return this;
            //$ }

            return this;
        }

        public NetworkInterfaceImpl WithoutIpForwarding ()
        {

            //$ this.inner().withEnableIPForwarding(false);
            //$ return this;

            return this;
        }

        public NetworkInterfaceImpl WithDnsServer (string ipAddress)
        {

            //$ this.dnsServerIps().add(ipAddress);
            //$ return this;

            return this;
        }

        public NetworkInterfaceImpl WithoutDnsServer (string ipAddress)
        {

            //$ this.dnsServerIps().remove(ipAddress);
            //$ return this;

            return this;
        }

        public NetworkInterfaceImpl WithAzureDnsServer ()
        {

            //$ this.dnsServerIps().clear();
            //$ return this;

            return this;
        }

        public NetworkInterfaceImpl WithSubnet (string name)
        {

            //$ this.primaryIpConfiguration().withSubnet(name);
            //$ return this;

            return this;
        }

        public NetworkInterfaceImpl WithInternalDnsNameLabel (string dnsNameLabel)
        {

            //$ this.inner().dnsSettings().withInternalDnsNameLabel(dnsNameLabel);
            //$ return this;

            return this;
        }

        public string VirtualMachineId
        {
            get
            {
            //$ if (this.inner().virtualMachine() != null) {
            //$ return this.inner().virtualMachine().id();
            //$ } else {
            //$ return null;
            //$ }


                return null;
            }
        }
        public bool? IsIpForwardingEnabled
        {
            get
            {
            //$ return Utils.toPrimitiveBoolean(this.inner().enableIPForwarding());


                return null;
            }
        }
        public string MacAddress
        {
            get
            {
            //$ return this.inner().macAddress();


                return null;
            }
        }
        public string InternalDnsNameLabel
        {
            get
            {
            //$ return this.inner().dnsSettings().internalDnsNameLabel();


                return null;
            }
        }
        public string InternalDomainNameSuffix
        {
            get
            {
            //$ return this.inner().dnsSettings().internalDomainNameSuffix();


                return null;
            }
        }
        public List<string> AppliedDnsServers
        {
            get
            {
            //$ return Collections.unmodifiableList(this.inner().dnsSettings().appliedDnsServers());


                return null;
            }
        }
        public string InternalFqdn
        {
            get
            {
            //$ return this.inner().dnsSettings().internalFqdn();


                return null;
            }
        }
        public List<string> DnsServers
        {
            get
            {
            //$ return this.dnsServerIps();


                return null;
            }
        }
        public string PrimaryPrivateIp
        {
            get
            {
            //$ return this.primaryIpConfiguration().privateIpAddress();


                return null;
            }
        }
        public string PrimaryPrivateIpAllocationMethod
        {
            get
            {
            //$ return this.primaryIpConfiguration().privateIpAllocationMethod();


                return null;
            }
        }
        public IDictionary<string,Microsoft.Azure.Management.Fluent.Network.INicIpConfiguration> IpConfigurations ()
        {

            //$ return Collections.unmodifiableMap(this.nicIpConfigurations);

            return null;
        }

        public string NetworkSecurityGroupId
        {
            get
            {
            //$ if (this.inner().networkSecurityGroup() != null) {
            //$ return this.inner().networkSecurityGroup().id();
            //$ }
            //$ return null;


                return null;
            }
        }
        public INetworkSecurityGroup GetNetworkSecurityGroup ()
        {

            //$ if (this.networkSecurityGroup == null && this.networkSecurityGroupId() != null) {
            //$ String id = this.networkSecurityGroupId();
            //$ this.networkSecurityGroup = super.myManager
            //$ .networkSecurityGroups()
            //$ .getByGroup(ResourceUtils.groupFromResourceId(id),
            //$ ResourceUtils.nameFromResourceId(id));
            //$ }
            //$ return this.networkSecurityGroup;

            return null;
        }

        /// <returns>the primary IP configuration of the network interface</returns>
        public NicIpConfigurationImpl PrimaryIpConfiguration ()
        {

            //$ if (this.nicPrimaryIpConfiguration != null) {
            //$ return this.nicPrimaryIpConfiguration;
            //$ }
            //$ 
            //$ if (isInCreateMode()) {
            //$ this.nicPrimaryIpConfiguration = prepareNewNicIpConfiguration("primary");
            //$ withIpConfiguration(this.nicPrimaryIpConfiguration);
            //$ } else {
            //$ // TODO: Currently Azure supports only one IP configuration and that is the primary
            //$ // hence we pick the first one here.
            //$ // when Azure support multiple IP configurations then there will be a flag in
            //$ // the IPConfiguration or a property in the network interface to identify the
            //$ // primary so below logic will be changed.
            //$ this.nicPrimaryIpConfiguration = (NicIpConfigurationImpl) new ArrayList<NicIpConfiguration>(
            //$ this.nicIpConfigurations.values()).get(0);
            //$ }
            //$ return this.nicPrimaryIpConfiguration;
            //$ }

            return null;
        }

        /// <returns>the list of DNS server IPs from the DNS settings</returns>
        private List<string> DnsServerIps
        {
            get
            {
            //$ if (this.inner().dnsSettings().dnsServers() == null) {
            //$ this.inner().dnsSettings().withDnsServers(new ArrayList<String>());
            //$ }
            //$ return this.inner().dnsSettings().dnsServers();
            //$ }


                return null;
            }
        }
        override protected void InitializeChildrenFromInner ()
        {

            //$ this.nicIpConfigurations = new TreeMap<>();
            //$ List<NetworkInterfaceIPConfigurationInner> inners = this.inner().ipConfigurations();
            //$ if (inners != null) {
            //$ for (NetworkInterfaceIPConfigurationInner inner : inners) {
            //$ NicIpConfigurationImpl  nicIpConfiguration = new NicIpConfigurationImpl(inner, this, super.myManager, false);
            //$ this.nicIpConfigurations.put(nicIpConfiguration.name(), nicIpConfiguration);
            //$ }
            //$ }

        }

        /// <summary>
        /// Gets a new IP configuration child resource {@link NicIpConfiguration} wrapping {@link NetworkInterfaceIPConfigurationInner}.
        /// </summary>
        /// <param name="name">name the name for the new ip configuration</param>
        /// <returns>{@link NicIpConfiguration}</returns>
        private NicIpConfigurationImpl PrepareNewNicIpConfiguration (string name)
        {

            //$ NicIpConfigurationImpl nicIpConfiguration = NicIpConfigurationImpl.prepareNicIpConfiguration(
            //$ name,
            //$ this,
            //$ super.myManager
            //$ );
            //$ return nicIpConfiguration;
            //$ }

            return null;
        }

        private void ClearCachedRelatedResources ()
        {

            //$ this.networkSecurityGroup = null;
            //$ this.nicPrimaryIpConfiguration = null;
            //$ }

        }

        internal NetworkInterfaceImpl WithIpConfiguration (NicIpConfigurationImpl nicIpConfiguration)
        {

            //$ this.nicIpConfigurations.put(nicIpConfiguration.name(), nicIpConfiguration);
            //$ return this;
            //$ }

            return this;
        }

        internal void AddToCreatableDependencies (ICreatable<IResource> creatableResource)
        {

            //$ super.addCreatableDependency(creatableResource);
            //$ }

        }

        internal IResource CreatedDependencyResource (string key)
        {

            //$ return super.createdResource(key);
            //$ }

            return null;
        }

        internal ICreatable<Microsoft.Azure.Management.Fluent.Resource.IResourceGroup> NewGroup ()
        {

            //$ return this.creatableGroup;
            //$ }

            return null;
        }

        override protected Task<NetworkInterfaceInner> CreateInner()
        {
            //$ return this.innerCollection.createOrUpdateAsync(this.resourceGroupName(), this.name(), this.inner());


                return null;
        }
        override protected void AfterCreating ()
        {

            //$ clearCachedRelatedResources();

        }

        internal NetworkManager Manager
        {
            get
            {
            //$ return this.myManager;
            //$ }


                return null;
            }
        }
        override protected void BeforeCreating ()
        {

            //$ NetworkSecurityGroup networkSecurityGroup = null;
            //$ if (creatableNetworkSecurityGroupKey != null) {
            //$ networkSecurityGroup = (NetworkSecurityGroup) this.createdResource(creatableNetworkSecurityGroupKey);
            //$ } else if (existingNetworkSecurityGroupToAssociate != null) {
            //$ networkSecurityGroup = existingNetworkSecurityGroupToAssociate;
            //$ }
            //$ 
            //$ // Associate an NSG if needed
            //$ if (networkSecurityGroup != null) {
            //$ this.inner().withNetworkSecurityGroup(new SubResource().withId(networkSecurityGroup.id()));
            //$ }
            //$ 
            //$ NicIpConfigurationImpl.ensureConfigurations(this.nicIpConfigurations.values());
            //$ 
            //$ // Reset and update IP configs
            //$ this.inner().withIpConfigurations(innersFromWrappers(this.nicIpConfigurations.values()));

        }

    }
}