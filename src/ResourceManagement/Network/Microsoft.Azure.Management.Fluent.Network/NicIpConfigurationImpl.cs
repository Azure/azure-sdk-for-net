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
    public partial class NicIpConfigurationImpl :
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

        internal NicIpConfigurationImpl(
            NetworkInterfaceIPConfigurationInner inner,
            NetworkInterfaceImpl parent,
            NetworkManager networkManager,
            bool isInCreateMode) : base(inner, parent)
        {
            this.isInCreateMode = isInCreateMode;
            this.networkManager = networkManager;
        }

        internal static NicIpConfigurationImpl PrepareNicIpConfiguration(string name, NetworkInterfaceImpl parent, NetworkManager networkManager)
        {
            NetworkInterfaceIPConfigurationInner ipConfigurationInner = new NetworkInterfaceIPConfigurationInner();
            ipConfigurationInner.Name = name;
            return new NicIpConfigurationImpl(ipConfigurationInner, parent, networkManager, true);
        }

        public override string Name()
        {
            return Inner.Name;
        }

        internal string PrivateIpAddressVersion()
        {
            return Inner.PrivateIPAddressVersion;
        }

        internal string PublicIpAddressId()
        {
            return (Inner.PublicIPAddress != null) ? Inner.PublicIPAddress.Id : null;
        }

        internal IPublicIpAddress GetPublicIpAddress()
        {
            string id = PublicIpAddressId();
            return (id != null) ? Parent.Manager.PublicIpAddresses.GetById(id) : null;
        }

        internal string SubnetName()
        {
            SubResource subnetRef = Inner.Subnet;
            return (subnetRef != null) ? ResourceUtils.NameFromResourceId(subnetRef.Id) : null;
        }

        internal string NetworkId()
        {
            SubResource subnetRef = Inner.Subnet;
            return (subnetRef != null) ? ResourceUtils.ParentResourcePathFromResourceId(subnetRef.Id) : null;
        }

        internal INetwork GetNetwork()
        {
            return (NetworkId() != null) ? Parent.Manager.Networks.GetById(NetworkId()) : null;
        }

        internal string PrivateIpAddress()
        {
            return Inner.PrivateIPAddress;
        }

        internal string PrivateIpAllocationMethod()
        {
            return Inner.PrivateIPAllocationMethod;
        }

        internal NetworkInterfaceImpl Attach()
        {
            return Parent.WithIpConfiguration(this);
        }

        internal NicIpConfigurationImpl WithNewNetwork(ICreatable<INetwork> creatable)
        {
            creatableVirtualNetworkKey = creatable.Key;
            Parent.AddToCreatableDependencies(creatable as IResourceCreator<Fluent.Resource.Core.IResource>);
            return this;
        }

        internal NicIpConfigurationImpl WithNewNetwork(string name, string addressSpaceCidr)
        {
            Network.Definition.IWithGroup definitionWithGroup = Parent.Manager.Networks
                .Define(name)
                .WithRegion(Parent.RegionName);

            Network.Definition.IWithCreate definitionAfterGroup;
            if (Parent.NewGroup() != null)
            {
                definitionAfterGroup = definitionWithGroup.WithNewResourceGroup(Parent.NewGroup());
            }
            else
            {
                definitionAfterGroup = definitionWithGroup.WithExistingResourceGroup(Parent.ResourceGroupName);
            }

            return WithNewNetwork(definitionAfterGroup.WithAddressSpace(addressSpaceCidr));
        }

        internal NicIpConfigurationImpl WithNewNetwork(string addressSpaceCidr)
        {
            return WithNewNetwork(ResourceNamer.RandomResourceName("vnet", 20), addressSpaceCidr);
        }

        internal NicIpConfigurationImpl WithExistingNetwork(INetwork network)
        {
            existingVirtualNetworkToAssociate = network;
            return this;
        }

        internal NicIpConfigurationImpl WithPrivateIpAddressDynamic()
        {
            Inner.PrivateIPAllocationMethod = IPAllocationMethod.Dynamic;
            Inner.PrivateIPAddress = null;
            return this;
        }

        internal NicIpConfigurationImpl WithPrivateIpAddressStatic(string staticPrivateIpAddress)
        {
            Inner.PrivateIPAllocationMethod = IPAllocationMethod.Static;
            Inner.PrivateIPAddress = staticPrivateIpAddress;
            return this;
        }

        internal NicIpConfigurationImpl WithNewPublicIpAddress(ICreatable<IPublicIpAddress> creatable)
        {
            if (creatablePublicIpKey == null)
            {
                creatablePublicIpKey = creatable.Key;
                Parent.AddToCreatableDependencies(creatable as IResourceCreator<Fluent.Resource.Core.IResource>);
            }

            return this;
        }

        internal NicIpConfigurationImpl WithNewPublicIpAddress()
        {
            string name = ResourceNamer.RandomResourceName("pip", 15);
            return WithNewPublicIpAddress(PrepareCreatablePublicIp(name, name));
        }

        internal NicIpConfigurationImpl WithNewPublicIpAddress(string leafDnsLabel)
        {
            return WithNewPublicIpAddress(
                PrepareCreatablePublicIp(ResourceNamer.RandomResourceName("pip", 15), leafDnsLabel));
        }

        internal NicIpConfigurationImpl WithExistingPublicIpAddress(IPublicIpAddress publicIpAddress)
        {

            return WithExistingPublicIpAddress(publicIpAddress.Id);
        }

        internal NicIpConfigurationImpl WithExistingPublicIpAddress(string resourceId)
        {
            existingPublicIpAddressIdToAssociate = resourceId;
            return this;
        }

        internal NicIpConfigurationImpl WithoutPublicIpAddress()
        {
            removePrimaryPublicIPAssociation = true;
            return this;
        }

        internal NicIpConfigurationImpl WithSubnet(string name)
        {
            subnetToAssociate = name;
            return this;
        }

        internal NicIpConfigurationImpl WithExistingLoadBalancerBackend(ILoadBalancer loadBalancer, string backendName)
        {
            foreach (var pool in loadBalancer.Inner.BackendAddressPools)
            {
                if (pool.Name.Equals(backendName, StringComparison.OrdinalIgnoreCase))
                {
                    EnsureBackendAddressPools().Add(pool);
                    return this;
                }
            }

            return this;
        }

        internal NicIpConfigurationImpl WithExistingLoadBalancerInboundNatRule(ILoadBalancer loadBalancer, string inboundNatRuleName)
        {
            foreach (var rule in loadBalancer.Inner.InboundNatRules)
            {
                if (rule.Name.Equals(inboundNatRuleName, StringComparison.OrdinalIgnoreCase))
                {
                    EnsureInboundNatRules().Add(rule);
                    return this;
                }
            }

            return this;
        }

        private IList<BackendAddressPoolInner> EnsureBackendAddressPools()
        {
            IList<BackendAddressPoolInner> poolRefs = Inner.LoadBalancerBackendAddressPools;
            if (poolRefs == null)
            {
                poolRefs = new List<BackendAddressPoolInner>();
                Inner.LoadBalancerBackendAddressPools = poolRefs;
            }

            return poolRefs;
        }

        private IList<InboundNatRuleInner> EnsureInboundNatRules()
        {
            IList<InboundNatRuleInner> natRefs = Inner.LoadBalancerInboundNatRules;
            if (natRefs == null)
            {
                natRefs = new List<InboundNatRuleInner>();
                Inner.LoadBalancerInboundNatRules = natRefs;
            }

            return natRefs;
        }

        internal static void EnsureConfigurations(List<INicIpConfiguration> nicIpConfigurations)
        {
            foreach (var nicIpConfiguration in nicIpConfigurations)
            {
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
            if (Parent.NewGroup() != null)
            {
                definitionAfterGroup = definitionWithGroup.WithNewResourceGroup(Parent.NewGroup());
            }
            else
            {
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
                    int idx = Inner.Subnet.Id.LastIndexOf('/');
                    subnetInner.Id = Inner.Subnet.Id.Substring(0, idx) + subnetToAssociate;
                }
                else
                {
                    subnetInner.Id = Inner.Subnet.Id;
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
            if (removePrimaryPublicIPAssociation)
            {
                return null;
            }
            else if (creatablePublicIpKey != null)
            {
                pipId = ((IPublicIpAddress)Parent.CreatedDependencyResource(creatablePublicIpKey)).Id;
            }
            else if (existingPublicIpAddressIdToAssociate != null)
            {
                pipId = existingPublicIpAddressIdToAssociate;
            }

            if (pipId != null)
            {
                return networkManager.PublicIpAddresses.GetById(pipId).Inner;
            }
            else if (!isInCreateMode)
            {
                return Inner.PublicIPAddress;
            }
            else
            {
                return null;
            }
        }

        internal NicIpConfigurationImpl WithPrivateIpVersion(string ipVersion)
        {
            Inner.PrivateIPAddressVersion = ipVersion;
            return this;
        }

        internal NicIpConfigurationImpl WithoutLoadBalancerBackends()
        {
            Inner.LoadBalancerBackendAddressPools = null;
            return this;
        }

        internal NicIpConfigurationImpl WithoutLoadBalancerInboundNatRules()
        {
            Inner.LoadBalancerInboundNatRules = null;
            return this;
        }

        internal IList<IInboundNatRule> ListAssociatedLoadBalancerInboundNatRules()
        {
            IList<InboundNatRuleInner> refs = Inner.LoadBalancerInboundNatRules;
            Dictionary<string, ILoadBalancer> loadBalancers = new Dictionary<string, ILoadBalancer>();
            List<IInboundNatRule> rules = new List<IInboundNatRule>();

            if (refs != null)
            {
                foreach (var reference in refs)
                {
                    string loadBalancerId = ResourceUtils.ParentResourcePathFromResourceId(reference.Id);
                    ILoadBalancer loadBalancer;
                    if (!loadBalancers.TryGetValue(loadBalancerId, out loadBalancer))
                    {
                        loadBalancer = Parent.Manager.LoadBalancers.GetById(loadBalancerId);
                        loadBalancers[loadBalancerId] = loadBalancer;
                    }

                    string ruleName = ResourceUtils.NameFromResourceId(reference.Id);
                    rules.Add(loadBalancer.InboundNatRules[ruleName]);
                }
            }

            return rules;
        }

        internal IList<IBackend> ListAssociatedLoadBalancerBackends()
        {
            var backendRefs = Inner.LoadBalancerBackendAddressPools;
            var loadBalancers = new Dictionary<string, ILoadBalancer>();
            var backends = new List<IBackend>();

            if (backendRefs != null)
            {
                foreach (BackendAddressPoolInner backendRef in backendRefs)
                {
                    string loadBalancerId = ResourceUtils.ParentResourcePathFromResourceId(backendRef.Id);
                    ILoadBalancer loadBalancer;
                    if (!loadBalancers.TryGetValue(loadBalancerId, out loadBalancer))
                    {
                        loadBalancer = Parent.Manager.LoadBalancers.GetById(loadBalancerId);
                        loadBalancers[loadBalancerId] = loadBalancer;
                    }

                    string backendName = ResourceUtils.NameFromResourceId(backendRef.Id);

                    IBackend backend;
                    if (loadBalancer.Backends.TryGetValue(backendName, out backend))
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