// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.V2.Network
{

    using Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Update;
    using Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Management.V2.Network.HasPrivateIpAddress.Definition;
    using Microsoft.Azure.Management.V2.Network.HasPublicIpAddress.Definition;
    using Microsoft.Azure.Management.V2.Network.NicIpConfiguration.UpdateDefinition;
    using System.Collections.Generic;
    using Microsoft.Azure;
    using Microsoft.Azure.Management.V2.Resource.Core;
    using Microsoft.Azure.Management.V2.Network.HasPublicIpAddress.UpdateDefinition;
    using Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Definition;
    using Microsoft.Azure.Management.V2.Resource.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
    using Microsoft.Azure.Management.V2.Network.NetworkInterface.Update;
    using Microsoft.Azure.Management.V2.Network.HasPublicIpAddress.Update;
    using Microsoft.Azure.Management.V2.Network.HasPrivateIpAddress.Update;
    using Microsoft.Azure.Management.V2.Network.HasPrivateIpAddress.UpdateDefinition;
    using Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition;
    using Microsoft.Azure.Management.V2.Resource.Core.ChildResource.Update;
    using Resource.Core.ChildResourceActions;
    using System;
    using Rest.Azure;

    /// <summary>
    /// Implementation for {@link NicIpConfiguration} and its create and update interfaces.
    /// </summary>
    public partial class NicIpConfigurationImpl  :
        ChildResource<Microsoft.Azure.Management.Network.Models.NetworkInterfaceIPConfigurationInner,Microsoft.Azure.Management.V2.Network.NetworkInterfaceImpl,Microsoft.Azure.Management.V2.Network.INetworkInterface>,
        INicIpConfiguration,
        IDefinition<Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition.IWithCreate>,
        IUpdateDefinition<Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate>,
        Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Update.IUpdate
    {
        private NetworkManager networkManager;
        private bool isInCreateMode;
        private string creatableVirtualNetworkKey;
        private string creatablePublicIpKey;
        private INetwork existingVirtualNetworkToAssociate;
        private string existingPublicIpAddressIdToAssociate;
        private string subnetToAssociate;
        private bool removePrimaryPublicIPAssociation;
        protected  NicIpConfigurationImpl (NetworkInterfaceIPConfigurationInner inner, NetworkInterfaceImpl parent, NetworkManager networkManager, bool isInCreateModel) : base(inner.Name, inner, parent)
        {

            //$ NetworkInterfaceImpl parent,
            //$ NetworkManager networkManager,
            //$ final boolean isInCreateModel) {
            //$ super(inner, parent);
            //$ this.isInCreateMode = isInCreateModel;
            //$ this.networkManager = networkManager;
            //$ }

        }

        protected static NicIpConfigurationImpl PrepareNicIpConfiguration (string name, NetworkInterfaceImpl parent, NetworkManager networkManager)
        {

            //$ String name,
            //$ NetworkInterfaceImpl parent,
            //$ final NetworkManager networkManager) {
            //$ NetworkInterfaceIPConfigurationInner ipConfigurationInner = new NetworkInterfaceIPConfigurationInner();
            //$ ipConfigurationInner.withName(name);
            //$ return new NicIpConfigurationImpl(ipConfigurationInner,
            //$ parent,
            //$ networkManager,
            //$ true);
            //$ }

            return null;
        }

        override public string Name
        {
            get
            {
            //$ return inner().name();


                return null;
            }
        }
        public string PrivateIpAddressVersion
        {
            get
            {
            //$ return this.inner().privateIPAddressVersion();


                return null;
            }
        }
        public string PublicIpAddressId
        {
            get
            {
            //$ if (this.inner().publicIPAddress() == null) {
            //$ return null;
            //$ }
            //$ return this.inner().publicIPAddress().id();


                return null;
            }
        }
        public IPublicIpAddress GetPublicIpAddress ()
        {

            //$ String id = publicIpAddressId();
            //$ if (id == null) {
            //$ return null;
            //$ }
            //$ 
            //$ return this.networkManager.publicIpAddresses().getById(id);

            return null;
        }

        public string SubnetName
        {
            get
            {
            //$ SubResource subnetRef = this.inner().subnet();
            //$ if (subnetRef != null) {
            //$ return ResourceUtils.nameFromResourceId(subnetRef.id());
            //$ } else {
            //$ return null;
            //$ }


                return null;
            }
        }
        public string NetworkId
        {
            get
            {
            //$ SubResource subnetRef = this.inner().subnet();
            //$ if (subnetRef != null) {
            //$ return ResourceUtils.parentResourcePathFromResourceId(subnetRef.id());
            //$ } else {
            //$ return null;
            //$ }


                return null;
            }
        }
        public INetwork GetNetwork ()
        {

            //$ String id = this.networkId();
            //$ return this.networkManager.networks().getById(id);

            return null;
        }

        public string PrivateIpAddress
        {
            get
            {
            //$ return this.inner().privateIPAddress();


                return null;
            }
        }
        public string PrivateIpAllocationMethod
        {
            get
            {
            //$ return this.inner().privateIPAllocationMethod();


                return null;
            }
        }
        public NetworkInterfaceImpl Attach ()
        {

            //$ return parent().withIpConfiguration(this);

            return null;
        }

        public NicIpConfigurationImpl WithNewNetwork (ICreatable<Microsoft.Azure.Management.V2.Network.INetwork> creatable)
        {

            //$ this.creatableVirtualNetworkKey = creatable.key();
            //$ this.parent().addToCreatableDependencies(creatable);
            //$ return this;

            return this;
        }

        public NicIpConfigurationImpl WithNewNetwork (string name, string addressSpaceCidr)
        {

            //$ Network.DefinitionStages.WithGroup definitionWithGroup = this.networkManager.networks()
            //$ .define(name)
            //$ .withRegion(this.parent().regionName());
            //$ 
            //$ Network.DefinitionStages.WithCreate definitionAfterGroup;
            //$ if (this.parent().newGroup() != null) {
            //$ definitionAfterGroup = definitionWithGroup.withNewResourceGroup(this.parent().newGroup());
            //$ } else {
            //$ definitionAfterGroup = definitionWithGroup.withExistingResourceGroup(this.parent().resourceGroupName());
            //$ }
            //$ return withNewNetwork(definitionAfterGroup.withAddressSpace(addressSpaceCidr));

            return this;
        }

        public NicIpConfigurationImpl WithNewNetwork (string addressSpaceCidr)
        {

            //$ return withNewNetwork(this.parent().namer.randomName("vnet", 20), addressSpaceCidr);

            return this;
        }

        public NicIpConfigurationImpl WithExistingNetwork (INetwork network)
        {

            //$ this.existingVirtualNetworkToAssociate = network;
            //$ return this;

            return this;
        }

        public NicIpConfigurationImpl WithPrivateIpAddressDynamic ()
        {

            //$ this.inner().withPrivateIPAllocationMethod(IPAllocationMethod.DYNAMIC);
            //$ this.inner().withPrivateIPAddress(null);
            //$ return this;

            return this;
        }

        public NicIpConfigurationImpl WithPrivateIpAddressStatic (string staticPrivateIpAddress)
        {

            //$ this.inner().withPrivateIPAllocationMethod(IPAllocationMethod.STATIC);
            //$ this.inner().withPrivateIPAddress(staticPrivateIpAddress);
            //$ return this;

            return this;
        }

        public NicIpConfigurationImpl WithNewPublicIpAddress (ICreatable<Microsoft.Azure.Management.V2.Network.IPublicIpAddress> creatable)
        {

            //$ if (this.creatablePublicIpKey == null) {
            //$ this.creatablePublicIpKey = creatable.key();
            //$ this.parent().addToCreatableDependencies(creatable);
            //$ }
            //$ return this;

            return this;
        }

        public NicIpConfigurationImpl WithNewPublicIpAddress ()
        {

            //$ String name = this.parent().namer.randomName("pip", 15);
            //$ return withNewPublicIpAddress(prepareCreatablePublicIp(name, name));

            return this;
        }

        public NicIpConfigurationImpl WithNewPublicIpAddress (string leafDnsLabel)
        {

            //$ return withNewPublicIpAddress(prepareCreatablePublicIp(this.parent().namer.randomName("pip", 15), leafDnsLabel));

            return this;
        }

        public NicIpConfigurationImpl WithExistingPublicIpAddress (IPublicIpAddress publicIpAddress)
        {

            //$ return this.withExistingPublicIpAddress(publicIpAddress.id());

            return this;
        }

        public NicIpConfigurationImpl WithExistingPublicIpAddress (string resourceId)
        {

            //$ this.existingPublicIpAddressIdToAssociate = resourceId;
            //$ return this;

            return this;
        }

        public NicIpConfigurationImpl WithoutPublicIpAddress ()
        {

            //$ this.removePrimaryPublicIPAssociation = true;
            //$ return this;

            return this;
        }

        public NicIpConfigurationImpl WithSubnet (string name)
        {

            //$ this.subnetToAssociate = name;
            //$ return this;

            return this;
        }

        public NicIpConfigurationImpl WithExistingLoadBalancerBackend (ILoadBalancer loadBalancer, string backendName)
        {

            //$ for (BackendAddressPoolInner pool : loadBalancer.inner().backendAddressPools()) {
            //$ if (pool.name().equalsIgnoreCase(backendName)) {
            //$ ensureBackendAddressPools().add(pool);
            //$ return this;
            //$ }
            //$ }
            //$ 
            //$ return null;

            return this;
        }

        public NicIpConfigurationImpl WithExistingLoadBalancerInboundNatRule (ILoadBalancer loadBalancer, string inboundNatRuleName)
        {

            //$ for (InboundNatRuleInner rule : loadBalancer.inner().inboundNatRules()) {
            //$ if (rule.name().equalsIgnoreCase(inboundNatRuleName)) {
            //$ ensureInboundNatRules().add(rule);
            //$ return this;
            //$ }
            //$ }
            //$ 
            //$ return null;

            return this;
        }

        private List<Microsoft.Azure.Management.Network.Models.BackendAddressPoolInner> EnsureBackendAddressPools
        {
            get
            {
            //$ List<BackendAddressPoolInner> poolRefs = this.inner().loadBalancerBackendAddressPools();
            //$ if (poolRefs == null) {
            //$ poolRefs = new ArrayList<>();
            //$ this.inner().withLoadBalancerBackendAddressPools(poolRefs);
            //$ }
            //$ return poolRefs;
            //$ }


                return null;
            }
        }
        private List<Microsoft.Azure.Management.Network.Models.InboundNatRuleInner> EnsureInboundNatRules
        {
            get
            {
            //$ List<InboundNatRuleInner> natRefs = this.inner().loadBalancerInboundNatRules();
            //$ if (natRefs == null) {
            //$ natRefs = new ArrayList<>();
            //$ this.inner().withLoadBalancerInboundNatRules(natRefs);
            //$ }
            //$ return natRefs;
            //$ }


                return null;
            }
        }
        protected static void EnsureConfigurations (List<Microsoft.Azure.Management.V2.Network.INicIpConfiguration> nicIpConfigurations)
        {

            //$ for (NicIpConfiguration nicIpConfiguration : nicIpConfigurations) {
            //$ NicIpConfigurationImpl config = (NicIpConfigurationImpl) nicIpConfiguration;
            //$ config.inner().withSubnet(config.subnetToAssociate());
            //$ config.inner().withPublicIPAddress(config.publicIpToAssociate());
            //$ }
            //$ }

        }

        private ICreatable<Microsoft.Azure.Management.V2.Network.IPublicIpAddress> PrepareCreatablePublicIp (string name, string leafDnsLabel)
        {

            //$ PublicIpAddress.DefinitionStages.WithGroup definitionWithGroup = this.networkManager.publicIpAddresses()
            //$ .define(name)
            //$ .withRegion(this.parent().regionName());
            //$ 
            //$ PublicIpAddress.DefinitionStages.WithCreate definitionAfterGroup;
            //$ if (this.parent().newGroup() != null) {
            //$ definitionAfterGroup = definitionWithGroup.withNewResourceGroup(this.parent().newGroup());
            //$ } else {
            //$ definitionAfterGroup = definitionWithGroup.withExistingResourceGroup(this.parent().resourceGroupName());
            //$ }
            //$ return definitionAfterGroup.withLeafDomainLabel(leafDnsLabel);
            //$ }

            return null;
        }

        /// <summary>
        /// Gets the subnet to associate with the IP configuration.
        /// <p>
        /// this method will never return null as subnet is required for a IP configuration, in case of
        /// update mode if user didn't choose to change the subnet then existing subnet will be returned.
        /// Updating the nic subnet has a restriction, the new subnet must reside in the same virtual network
        /// as the current one.
        /// </summary>
        /// <returns>the subnet resource</returns>
        private SubnetInner SubnetToAssociate
        {
            get
            {
            //$ SubnetInner subnetInner = new SubnetInner();
            //$ if (this.isInCreateMode) {
            //$ if (this.creatableVirtualNetworkKey != null) {
            //$ Network network = (Network) parent().createdDependencyResource(this.creatableVirtualNetworkKey);
            //$ subnetInner.withId(network.inner().subnets().get(0).id());
            //$ return subnetInner;
            //$ }
            //$ 
            //$ for (SubnetInner subnet : this.existingVirtualNetworkToAssociate.inner().subnets()) {
            //$ if (subnet.name().compareToIgnoreCase(this.subnetToAssociate) == 0) {
            //$ subnetInner.withId(subnet.id());
            //$ return subnetInner;
            //$ }
            //$ }
            //$ 
            //$ throw new RuntimeException("A subnet with name '" + subnetToAssociate + "' not found under the network '" + this.existingVirtualNetworkToAssociate.name() + "'");
            //$ 
            //$ } else {
            //$ if (subnetToAssociate != null) {
            //$ int idx = this.inner().subnet().id().lastIndexOf('/');
            //$ subnetInner.withId(this.inner().subnet().id().substring(0, idx) + subnetToAssociate);
            //$ } else {
            //$ subnetInner.withId(this.inner().subnet().id());
            //$ }
            //$ return subnetInner;
            //$ }
            //$ }


                return null;
            }
        }
        /// <summary>
        /// Get the SubResource instance representing a public IP that needs to be associated with the
        /// IP configuration.
        /// <p>
        /// null will be returned if withoutPublicIP() is specified in the update fluent chain or user did't
        /// opt for public IP in create fluent chain. In case of update chain, if withoutPublicIP(..) is
        /// not specified then existing associated (if any) public IP will be returned.
        /// </summary>
        /// <returns>public ip SubResource</returns>
        private SubResource PublicIpToAssociate
        {
            get
            {
            //$ String pipId = null;
            //$ if (this.removePrimaryPublicIPAssociation) {
            //$ return null;
            //$ } else if (this.creatablePublicIpKey != null) {
            //$ pipId = ((PublicIpAddress) this.parent()
            //$ .createdDependencyResource(this.creatablePublicIpKey)).id();
            //$ } else if (this.existingPublicIpAddressIdToAssociate != null) {
            //$ pipId = this.existingPublicIpAddressIdToAssociate;
            //$ }
            //$ 
            //$ if (pipId != null) {
            //$ return new SubResource().withId(pipId);
            //$ } else if (!this.isInCreateMode) {
            //$ return this.inner().publicIPAddress();
            //$ } else {
            //$ return null;
            //$ }
            //$ }


                return null;
            }
        }
        public NicIpConfigurationImpl WithPrivateIpVersion (string ipVersion)
        {

            //$ this.inner().withPrivateIPAddressVersion(ipVersion);
            //$ return this;

            return this;
        }

        public NicIpConfigurationImpl WithoutLoadBalancerBackends ()
        {

            //$ this.inner().withLoadBalancerBackendAddressPools(null);
            //$ return this;

            return this;
        }

        public NicIpConfigurationImpl WithoutLoadBalancerInboundNatRules ()
        {

            //$ this.inner().withLoadBalancerInboundNatRules(null);
            //$ return this;

            return this;
        }

        public List<Microsoft.Azure.Management.V2.Network.IInboundNatRule> ListAssociatedLoadBalancerInboundNatRules ()
        {

            //$ final List<InboundNatRuleInner> refs = this.inner().loadBalancerInboundNatRules();
            //$ final Map<String, LoadBalancer> loadBalancers = new HashMap<>();
            //$ final List<InboundNatRule> rules = new ArrayList<>();
            //$ 
            //$ if (refs != null) {
            //$ for (InboundNatRuleInner ref : refs) {
            //$ String loadBalancerId = ResourceUtils.parentResourcePathFromResourceId(ref.id());
            //$ LoadBalancer loadBalancer = loadBalancers.get(loadBalancerId);
            //$ if (loadBalancer == null) {
            //$ loadBalancer = this.parent().manager().loadBalancers().getById(loadBalancerId);
            //$ loadBalancers.put(loadBalancerId, loadBalancer);
            //$ }
            //$ 
            //$ String ruleName = ResourceUtils.nameFromResourceId(ref.id());
            //$ rules.add(loadBalancer.inboundNatRules().get(ruleName));
            //$ }
            //$ }
            //$ 
            //$ return Collections.unmodifiableList(rules);

            return null;
        }

        public List<Microsoft.Azure.Management.V2.Network.IBackend> ListAssociatedLoadBalancerBackends ()
        {

            //$ final List<BackendAddressPoolInner> backendRefs = this.inner().loadBalancerBackendAddressPools();
            //$ final Map<String, LoadBalancer> loadBalancers = new HashMap<>();
            //$ final List<Backend> backends = new ArrayList<>();
            //$ 
            //$ if (backendRefs != null) {
            //$ for (BackendAddressPoolInner backendRef : backendRefs) {
            //$ String loadBalancerId = ResourceUtils.parentResourcePathFromResourceId(backendRef.id());
            //$ LoadBalancer loadBalancer = loadBalancers.get(loadBalancerId);
            //$ if (loadBalancer == null) {
            //$ loadBalancer = this.parent().manager().loadBalancers().getById(loadBalancerId);
            //$ loadBalancers.put(loadBalancerId, loadBalancer);
            //$ }
            //$ 
            //$ String backendName = ResourceUtils.nameFromResourceId(backendRef.id());
            //$ backends.add(loadBalancer.backends().get(backendName));
            //$ }
            //$ }
            //$ 
            //$ return Collections.unmodifiableList(backends);

            return null;
        }

        NetworkInterface.Update.IUpdate ISettable<NetworkInterface.Update.IUpdate>.Parent()
        {
            throw new NotImplementedException();
        }
    }
}