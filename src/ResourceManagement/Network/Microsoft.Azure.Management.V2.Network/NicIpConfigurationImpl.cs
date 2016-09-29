// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.V2.Network
{
    using Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Management.V2.Network.NicIpConfiguration.UpdateDefinition;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.V2.Resource.Core;
    using Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Definition;
    using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
    using Resource.Core.ChildResourceActions;
    using System;
    using Rest.Azure;
    using Resource;

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

        protected  NicIpConfigurationImpl (NetworkInterfaceIPConfigurationInner inner, NetworkInterfaceImpl parent, NetworkManager networkManager, bool isInCreateMode) : base(inner.Name, inner, parent)
        {
            this.isInCreateMode = isInCreateMode;
            this.networkManager = networkManager;

        }

        protected static NicIpConfigurationImpl PrepareNicIpConfiguration (string name, NetworkInterfaceImpl parent, NetworkManager networkManager)
        {
            NetworkInterfaceIPConfigurationInner ipConfigurationInner = new NetworkInterfaceIPConfigurationInner();
            ipConfigurationInner.Name = name;
            return new NicIpConfigurationImpl(ipConfigurationInner, parent, networkManager, true);
        }

        override public string Name
        {
            get
            {
                return Inner.Name;
            }
        }

        public string PrivateIpAddressVersion
        {
            get
            {
                return this.Inner.PrivateIPAddressVersion;
            }
        }

        public string PublicIpAddressId
        {
            get
            {
                if (this.Inner.PublicIPAddress == null)
                {
                    return null;
                }

                return this.Inner.PublicIPAddress.Id;
            }
        }

        public IPublicIpAddress GetPublicIpAddress ()
        {

            string id = PublicIpAddressId;
            if (id == null) {
            return null;
            }
            
            return this.networkManager.PublicIpAddresses.GetById(id);
        }

        public string SubnetName
        {
            get
            {
            SubResource subnetRef = this.Inner.Subnet;
            if (subnetRef != null) {
            return ResourceUtils.NameFromResourceId(subnetRef.Id);
            } else {
            return null;
            }
            }
        }

        public string NetworkId
        {
            get
            {
                SubResource subnetRef = this.Inner.Subnet;
                if (subnetRef != null)
                {
                    return ResourceUtils.ParentResourcePathFromResourceId(subnetRef.Id);
                }
                else
                {
                    return null;
                }
            }
        }

        public INetwork GetNetwork ()
        {

            string id = this.NetworkId;
            return this.networkManager.Networks.GetById(id);
        }

        public string PrivateIpAddress
        {
            get
            {
            return this.Inner.PrivateIPAddress;
            }
        }

        public string PrivateIpAllocationMethod
        {
            get
            {
            return this.Inner.PrivateIPAllocationMethod;
            }
        }

        public NetworkInterfaceImpl Attach ()
        {
            return Parent.WithIpConfiguration(this);
        }

        public NicIpConfigurationImpl WithNewNetwork (ICreatable<Microsoft.Azure.Management.V2.Network.INetwork> creatable)
        {

            this.creatableVirtualNetworkKey = creatable.Key;
            this.Parent.AddToCreatableDependencies(creatable as ICreatable<V2.Resource.Core.IResource>);
            return this;
        }

        public NicIpConfigurationImpl WithNewNetwork (string name, string addressSpaceCidr)
        {

            Network.Definition.IWithGroup definitionWithGroup = this.networkManager.Networks
                .Define(name)
                .WithRegion(this.Parent.RegionName);
            
            Network.Definition.IWithCreate definitionAfterGroup;
            if (this.Parent.NewGroup() != null) {
                definitionAfterGroup = definitionWithGroup.WithNewResourceGroup(this.Parent.NewGroup());
            } else {
                definitionAfterGroup = definitionWithGroup.WithExistingResourceGroup(this.Parent.ResourceGroupName);
            }

            return WithNewNetwork(definitionAfterGroup.WithAddressSpace(addressSpaceCidr));
        }

        public NicIpConfigurationImpl WithNewNetwork (string addressSpaceCidr)
        {
            return WithNewNetwork(ResourceNamer.RandomResourceName("vnet", 20), addressSpaceCidr);
        }

        public NicIpConfigurationImpl WithExistingNetwork (INetwork network)
        {
            this.existingVirtualNetworkToAssociate = network;
            return this;
        }

        public NicIpConfigurationImpl WithPrivateIpAddressDynamic ()
        {
            this.Inner.PrivateIPAllocationMethod = IPAllocationMethod.Dynamic;
            this.Inner.PrivateIPAddress = null;
            return this;
        }

        public NicIpConfigurationImpl WithPrivateIpAddressStatic (string staticPrivateIpAddress)
        {
            this.Inner.PrivateIPAllocationMethod = IPAllocationMethod.Static;
            this.Inner.PrivateIPAddress = staticPrivateIpAddress;
            return this;
        }

        public NicIpConfigurationImpl WithNewPublicIpAddress (ICreatable<Microsoft.Azure.Management.V2.Network.IPublicIpAddress> creatable)
        {
            if (this.creatablePublicIpKey == null) {
                this.creatablePublicIpKey = creatable.Key;
                this.Parent.AddToCreatableDependencies(creatable as ICreatable<V2.Resource.Core.IResource>);
            }

            return this;
        }

        public NicIpConfigurationImpl WithNewPublicIpAddress ()
        {

            string name = ResourceNamer.RandomResourceName("pip", 15);
            return WithNewPublicIpAddress(PrepareCreatablePublicIp(name, name));
        }

        public NicIpConfigurationImpl WithNewPublicIpAddress (string leafDnsLabel)
        {

            return WithNewPublicIpAddress(PrepareCreatablePublicIp(ResourceNamer.RandomResourceName("pip", 15), leafDnsLabel));
        }

        public NicIpConfigurationImpl WithExistingPublicIpAddress (IPublicIpAddress publicIpAddress)
        {

            return this.WithExistingPublicIpAddress(publicIpAddress.Id);
        }

        public NicIpConfigurationImpl WithExistingPublicIpAddress (string resourceId)
        {
            this.existingPublicIpAddressIdToAssociate = resourceId;
            return this;
        }

        public NicIpConfigurationImpl WithoutPublicIpAddress ()
        {
            this.removePrimaryPublicIPAssociation = true;
            return this;
        }

        public NicIpConfigurationImpl WithSubnet (string name)
        {
            this.subnetToAssociate = name;
            return this;
        }

        public NicIpConfigurationImpl WithExistingLoadBalancerBackend (ILoadBalancer loadBalancer, string backendName)
        {

            foreach (var pool in loadBalancer.Inner.BackendAddressPools) {
                if (pool.Name.Equals(backendName, StringComparison.OrdinalIgnoreCase)) {
                    EnsureBackendAddressPools.Add(pool);
                    return this;
                }
            }

            return this;
        }

        public NicIpConfigurationImpl WithExistingLoadBalancerInboundNatRule (ILoadBalancer loadBalancer, string inboundNatRuleName)
        {

            foreach (var rule in loadBalancer.Inner.InboundNatRules) {
                if (rule.Name.Equals(inboundNatRuleName, StringComparison.OrdinalIgnoreCase)) {
                    EnsureInboundNatRules.Add(rule);
                    return this;
                }
            }
            
            return this;
        }

        private IList<Microsoft.Azure.Management.Network.Models.BackendAddressPoolInner> EnsureBackendAddressPools
        {
            get
            {
            IList<BackendAddressPoolInner> poolRefs = this.Inner.LoadBalancerBackendAddressPools;
            if (poolRefs == null) {
                poolRefs = new List<BackendAddressPoolInner>();
                this.Inner.LoadBalancerBackendAddressPools = poolRefs;
            }

            return poolRefs;
            }
        }
        private IList<Microsoft.Azure.Management.Network.Models.InboundNatRuleInner> EnsureInboundNatRules
        {
            get
            {
            IList<InboundNatRuleInner> natRefs = this.Inner.LoadBalancerInboundNatRules;
            if (natRefs == null) {
            natRefs = new List<InboundNatRuleInner>();
            this.Inner.LoadBalancerInboundNatRules = natRefs;
                }

                return natRefs;
            }
        }
        protected static void EnsureConfigurations(List<Microsoft.Azure.Management.V2.Network.INicIpConfiguration> nicIpConfigurations)
        {

            foreach (var nicIpConfiguration in nicIpConfigurations) {
                NicIpConfigurationImpl config = (NicIpConfigurationImpl)nicIpConfiguration;
                config.Inner.Subnet = config.SubnetToAssociate();
                config.Inner.PublicIPAddress = config.PublicIpToAssociate();
            }
        }

        private ICreatable<Microsoft.Azure.Management.V2.Network.IPublicIpAddress> PrepareCreatablePublicIp(string name, string leafDnsLabel)
        {
            PublicIpAddress.Definition.IWithGroup definitionWithGroup = this.networkManager.PublicIpAddresses
                .Define(name)
                .WithRegion(this.Parent.RegionName);

            PublicIpAddress.Definition.IWithCreate definitionAfterGroup;
            if (this.Parent.NewGroup() != null) {
                definitionAfterGroup = definitionWithGroup.WithNewResourceGroup(this.Parent.NewGroup());
            } else {
                definitionAfterGroup = definitionWithGroup.WithExistingResourceGroup(this.Parent.ResourceGroupName);
            }

            return definitionAfterGroup.WithLeafDomainLabel(leafDnsLabel);
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
        private SubnetInner SubnetToAssociate()
        {
                SubnetInner subnetInner = new SubnetInner();
                if (this.isInCreateMode)
                {
                    if (this.creatableVirtualNetworkKey != null)
                    {
                        INetwork network = (INetwork)Parent.CreatedDependencyResource(this.creatableVirtualNetworkKey);
                        subnetInner.Id = network.Inner.Subnets[0].Id;
                        return subnetInner;
                    }

                    foreach (var subnet in this.existingVirtualNetworkToAssociate.Inner.Subnets)
                    {
                        if (subnet.Name.Equals(this.subnetToAssociate, StringComparison.OrdinalIgnoreCase))
                        {
                            subnetInner.Id = subnet.Id;
                            return subnetInner;
                        }
                    }

                    throw new Exception("A subnet with name '" + subnetToAssociate + "' not found under the network '" + this.existingVirtualNetworkToAssociate.Name + "'");

                }
                else
                {
                    if (subnetToAssociate != null)
                    {
                        int idx = this.Inner.Subnet.Id.LastIndexOf('/');
                        subnetInner.Id = this.Inner.Subnet.Id.Substring(0, idx) + subnetToAssociate;
                    }
                    else
                    {
                        subnetInner.Id = this.Inner.Subnet.Id;
                    }
                    return subnetInner;
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
        private PublicIPAddressInner PublicIpToAssociate()
        {
            string pipId = null;
            if (this.removePrimaryPublicIPAssociation)
            {
                return null;
            }
            else if (this.creatablePublicIpKey != null)
            {
                pipId = ((IPublicIpAddress)this.Parent.CreatedDependencyResource(this.creatablePublicIpKey)).Id;
            }
            else if (this.existingPublicIpAddressIdToAssociate != null)
            {
                pipId = this.existingPublicIpAddressIdToAssociate;
            }

            if (pipId != null)
            {
                return this.networkManager.PublicIpAddresses.GetById(pipId).Inner;
            }
            else if (!this.isInCreateMode)
            {
                return Inner.PublicIPAddress;
            }
            else
            {
                return null;
            }
        }

        public NicIpConfigurationImpl WithPrivateIpVersion (string ipVersion)
        {
            this.Inner.PrivateIPAddressVersion = ipVersion;
            return this;
        }

        public NicIpConfigurationImpl WithoutLoadBalancerBackends ()
        {

            this.Inner.LoadBalancerBackendAddressPools = null;
            return this;
        }

        public NicIpConfigurationImpl WithoutLoadBalancerInboundNatRules ()
        {

            this.Inner.LoadBalancerInboundNatRules = null;
            return this;
    }

        public IList<Microsoft.Azure.Management.V2.Network.IInboundNatRule> ListAssociatedLoadBalancerInboundNatRules()
        {

            IList<InboundNatRuleInner> refs = this.Inner.LoadBalancerInboundNatRules;
            Dictionary<string, ILoadBalancer> loadBalancers = new Dictionary<string, ILoadBalancer>();
            List<IInboundNatRule> rules = new List<IInboundNatRule>();

            if (refs != null) {
                foreach (var reference in refs) {
                    string loadBalancerId = ResourceUtils.ParentResourcePathFromResourceId(reference.Id);
                    ILoadBalancer loadBalancer = loadBalancers[loadBalancerId];
                    if (loadBalancer == null) {
                        loadBalancer = this.Parent.Manager.LoadBalancers.GetById(loadBalancerId);
                        loadBalancers[loadBalancerId] = loadBalancer;
                    }

                    string ruleName = ResourceUtils.NameFromResourceId(reference.Id);
                    rules.Add(loadBalancer.InboundNatRules()[ruleName]);
                }
            }

            return rules;
        }

        public IList<Microsoft.Azure.Management.V2.Network.IBackend> ListAssociatedLoadBalancerBackends()
        {
            var backendRefs = this.Inner.LoadBalancerBackendAddressPools;
            var loadBalancers = new Dictionary<string, ILoadBalancer>();
            var backends = new List<IBackend>();

            if (backendRefs != null) {
                foreach (BackendAddressPoolInner backendRef in backendRefs) {
                    string loadBalancerId = ResourceUtils.ParentResourcePathFromResourceId(backendRef.Id);
                    var loadBalancer = loadBalancers[loadBalancerId];
                    if (loadBalancer == null) {
                        loadBalancer = this.Parent.Manager.LoadBalancers.GetById(loadBalancerId);
                        loadBalancers[loadBalancerId] = loadBalancer;
                    }

                    string backendName = ResourceUtils.NameFromResourceId(backendRef.Id);
                    backends.Add(loadBalancer.Backends()[backendName]);
                }
            }

            return backends;
        }

        NetworkInterface.Update.IUpdate ISettable<NetworkInterface.Update.IUpdate>.Parent()
        {
            return base.Parent;
        }
    }
}