// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Fluent.Network
{
    using Management.Network.Models;
    using NicIpConfiguration.UpdateDefinition;
    using System.Collections.Generic;
    using Resource.Core;
    using NicIpConfiguration.Definition;
    using Resource.Core.ResourceActions;
    using Resource.Core.ChildResourceActions;
    using System;
    using Rest.Azure;
    using Resource;

    /// <summary>
    /// Implementation for NicIpConfiguration and its create and update interfaces.
    /// </summary>
    public partial class NicIpConfigurationImpl  :
        ChildResource<NetworkInterfaceIPConfigurationInner, NetworkInterfaceImpl, INetworkInterface>,
        INicIpConfiguration,
        IDefinition<NetworkInterface.Definition.IWithCreate>,
        IUpdateDefinition<NetworkInterface.Update.IUpdate>,
        NicIpConfiguration.Update.IUpdate
    {
        private NetworkManager networkManager;
        private bool isInCreateMode;
        private string creatableVirtualNetworkKey;
        private string creatablePublicIpKey;
        private INetwork existingVirtualNetworkToAssociate;
        private string existingPublicIpAddressIdToAssociate;
        private string subnetToAssociate;
        private bool removePrimaryPublicIPAssociation;

        protected  NicIpConfigurationImpl (
            NetworkInterfaceIPConfigurationInner inner, 
            NetworkInterfaceImpl parent, 
            NetworkManager networkManager, 
            bool isInCreateMode) : base(inner.Name, inner, parent)
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
                return Inner.PrivateIPAddressVersion;
            }
        }

        public string PublicIpAddressId
        {
            get
            {
                return (Inner.PublicIPAddress != null) ? Inner.PublicIPAddress.Id : null;
            }
        }

        public IPublicIpAddress GetPublicIpAddress ()
        {
            string id = PublicIpAddressId;
            return (id != null) ? Parent.Manager.PublicIpAddresses.GetById(id) : null;
        }

        public string SubnetName
        {
            get
            {
                SubResource subnetRef = Inner.Subnet;
                return (subnetRef != null) ? ResourceUtils.NameFromResourceId(subnetRef.Id) : null;
            }
        }

        public string NetworkId
        {
            get
            {
                SubResource subnetRef = Inner.Subnet;
                return (subnetRef != null) ? ResourceUtils.ParentResourcePathFromResourceId(subnetRef.Id) : null;
            }
        }

        public INetwork GetNetwork ()
        {
            return Parent.Manager.Networks.GetById(NetworkId);
        }

        public string PrivateIpAddress
        {
            get
            {
                return Inner.PrivateIPAddress;
            }
        }

        public string PrivateIpAllocationMethod
        {
            get
            {
                return Inner.PrivateIPAllocationMethod;
            }
        }

        public NetworkInterfaceImpl Attach ()
        {
            return Parent.WithIpConfiguration(this);
        }

        public NicIpConfigurationImpl WithNewNetwork (ICreatable<INetwork> creatable)
        {
            creatableVirtualNetworkKey = creatable.Key;
            Parent.AddToCreatableDependencies(creatable as ICreatable<Fluent.Resource.Core.IResource>);
            return this;
        }

        public NicIpConfigurationImpl WithNewNetwork (string name, string addressSpaceCidr)
        {
            Network.Definition.IWithGroup definitionWithGroup = Parent.Manager.Networks
                .Define(name)
                .WithRegion(Parent.RegionName);
            
            Network.Definition.IWithCreate definitionAfterGroup;
            if (Parent.NewGroup() != null) {
                definitionAfterGroup = definitionWithGroup.WithNewResourceGroup(Parent.NewGroup());
            } else {
                definitionAfterGroup = definitionWithGroup.WithExistingResourceGroup(Parent.ResourceGroupName);
            }

            return WithNewNetwork(definitionAfterGroup.WithAddressSpace(addressSpaceCidr));
        }

        public NicIpConfigurationImpl WithNewNetwork (string addressSpaceCidr)
        {
            return WithNewNetwork(ResourceNamer.RandomResourceName("vnet", 20), addressSpaceCidr);
        }

        public NicIpConfigurationImpl WithExistingNetwork (INetwork network)
        {
            existingVirtualNetworkToAssociate = network;
            return this;
        }

        public NicIpConfigurationImpl WithPrivateIpAddressDynamic ()
        {
            Inner.PrivateIPAllocationMethod = IPAllocationMethod.Dynamic;
            Inner.PrivateIPAddress = null;
            return this;
        }

        public NicIpConfigurationImpl WithPrivateIpAddressStatic (string staticPrivateIpAddress)
        {
            Inner.PrivateIPAllocationMethod = IPAllocationMethod.Static;
            Inner.PrivateIPAddress = staticPrivateIpAddress;
            return this;
        }

        public NicIpConfigurationImpl WithNewPublicIpAddress (ICreatable<IPublicIpAddress> creatable)
        {
            if (creatablePublicIpKey == null) {
                creatablePublicIpKey = creatable.Key;
                Parent.AddToCreatableDependencies(creatable as ICreatable<Fluent.Resource.Core.IResource>);
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

            return WithExistingPublicIpAddress(publicIpAddress.Id);
        }

        public NicIpConfigurationImpl WithExistingPublicIpAddress (string resourceId)
        {
            existingPublicIpAddressIdToAssociate = resourceId;
            return this;
        }

        public NicIpConfigurationImpl WithoutPublicIpAddress ()
        {
            removePrimaryPublicIPAssociation = true;
            return this;
        }

        public NicIpConfigurationImpl WithSubnet (string name)
        {
            subnetToAssociate = name;
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
                IList<BackendAddressPoolInner> poolRefs = Inner.LoadBalancerBackendAddressPools;
                if (poolRefs == null) {
                    poolRefs = new List<BackendAddressPoolInner>();
                    Inner.LoadBalancerBackendAddressPools = poolRefs;
                }

                return poolRefs;
            }
        }

        private IList<InboundNatRuleInner> EnsureInboundNatRules
        {
            get
            {
                IList<InboundNatRuleInner> natRefs = Inner.LoadBalancerInboundNatRules;
                if (natRefs == null) {
                    natRefs = new List<InboundNatRuleInner>();
                    Inner.LoadBalancerInboundNatRules = natRefs;
                }

                return natRefs;
            }
        }

        protected static void EnsureConfigurations(List<INicIpConfiguration> nicIpConfigurations)
        {
            foreach (var nicIpConfiguration in nicIpConfigurations) {
                NicIpConfigurationImpl config = (NicIpConfigurationImpl)nicIpConfiguration;
                config.Inner.Subnet = config.SubnetToAssociate();
                config.Inner.PublicIPAddress = config.PublicIpToAssociate();
            }
        }

        private ICreatable<IPublicIpAddress> PrepareCreatablePublicIp(string name, string leafDnsLabel)
        {
            PublicIpAddress.Definition.IWithGroup definitionWithGroup = this.networkManager.PublicIpAddresses.Define(name)
                .WithRegion(this.Parent.RegionName);

            PublicIpAddress.Definition.IWithCreate definitionAfterGroup;
            if (Parent.NewGroup() != null) {
                definitionAfterGroup = definitionWithGroup.WithNewResourceGroup(Parent.NewGroup());
            } else {
                definitionAfterGroup = definitionWithGroup.WithExistingResourceGroup(Parent.ResourceGroupName);
            }

            return definitionAfterGroup.WithLeafDomainLabel(leafDnsLabel);
        }

        /// <summary>
        /// Gets the subnet to associate with the IP configuration.
        /// <p>
        /// This method will never return null as subnet is required for a IP configuration, in case of
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
            Inner.PrivateIPAddressVersion = ipVersion;
            return this;
        }

        public NicIpConfigurationImpl WithoutLoadBalancerBackends ()
        {
            Inner.LoadBalancerBackendAddressPools = null;
            return this;
        }

        public NicIpConfigurationImpl WithoutLoadBalancerInboundNatRules ()
        {
            Inner.LoadBalancerInboundNatRules = null;
            return this;
        }

        public IList<IInboundNatRule> ListAssociatedLoadBalancerInboundNatRules()
        {
            IList<InboundNatRuleInner> refs = Inner.LoadBalancerInboundNatRules;
            Dictionary<string, ILoadBalancer> loadBalancers = new Dictionary<string, ILoadBalancer>();
            List<IInboundNatRule> rules = new List<IInboundNatRule>();

            if (refs != null) {
                foreach (var reference in refs) {
                    string loadBalancerId = ResourceUtils.ParentResourcePathFromResourceId(reference.Id);
                    ILoadBalancer loadBalancer;
                    if (!loadBalancers.TryGetValue(loadBalancerId, out loadBalancer))
                    {
                        loadBalancer = Parent.Manager.LoadBalancers.GetById(loadBalancerId);
                        loadBalancers[loadBalancerId] = loadBalancer;
                    }

                    string ruleName = ResourceUtils.NameFromResourceId(reference.Id);
                    rules.Add(loadBalancer.InboundNatRules()[ruleName]);
                }
            }

            return rules;
        }

        public IList<IBackend> ListAssociatedLoadBalancerBackends()
        {
            var backendRefs = Inner.LoadBalancerBackendAddressPools;
            var loadBalancers = new Dictionary<string, ILoadBalancer>();
            var backends = new List<IBackend>();

            if (backendRefs != null) {
                foreach (BackendAddressPoolInner backendRef in backendRefs) {
                    string loadBalancerId = ResourceUtils.ParentResourcePathFromResourceId(backendRef.Id);
                    ILoadBalancer loadBalancer;
                    if (!loadBalancers.TryGetValue(loadBalancerId, out loadBalancer))
                    {
                        loadBalancer = Parent.Manager.LoadBalancers.GetById(loadBalancerId);
                        loadBalancers[loadBalancerId] = loadBalancer;
                    }

                    string backendName = ResourceUtils.NameFromResourceId(backendRef.Id);

                    IBackend backend;
                    if(loadBalancer.Backends().TryGetValue(backendName, out backend))
                        backends.Add(backend);
                }
            }

            return backends;
        }

        NetworkInterface.Update.IUpdate ISettable<NetworkInterface.Update.IUpdate>.Parent()
        {
            return Parent;
        }
    }
}