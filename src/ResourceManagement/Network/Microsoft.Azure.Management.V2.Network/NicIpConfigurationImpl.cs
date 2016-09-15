/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/

namespace Microsoft.Azure.Management.V2.Network
{

    using NicIpConfiguration.Update;
    using NicIpConfiguration.Definition;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.V2.Resource.Core.ChildResource.Definition;
    using NicIpConfiguration.UpdateDefinition;
    using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
    using Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Management.V2.Resource.Core;
    using NetworkInterface.Update;
    using Microsoft.Azure;
    using Microsoft.Azure.Management.V2.Resource.Core.ChildResource.Update;
    using NetworkInterface.Definition;
    using Microsoft.Rest.Azure;
    using Resource.Core.ChildResourceActions;
    using System;

    /// <summary>
    /// Implementation for {@link NicIpConfiguration} and its create and update interfaces.
    /// </summary>
    public partial class NicIpConfigurationImpl :
        ChildResource<NetworkInterfaceIPConfigurationInner, NetworkInterfaceImpl>,
        INicIpConfiguration,
        NicIpConfiguration.Definition.IDefinition<NetworkInterface.Definition.IWithCreate>,
        NicIpConfiguration.UpdateDefinition.IUpdateDefinition<NetworkInterface.Update.IUpdate>,
        NicIpConfiguration.Update.IUpdate
    {
        private INetworkManager NetworkManager;
        private bool isInCreateMode;
        private string creatableVirtualNetworkKey;
        private string creatablePublicIpKey;
        private INetwork existingVirtualNetworkToAssociate;
        private IPublicIpAddress existingPublicIpAddressToAssociate;
        private string subnetToAssociate;
        private bool removePrimaryPublicIPAssociation;
        private ILoadBalancer loadBalancerToAssociate;

        internal NicIpConfigurationImpl(NetworkInterfaceIPConfigurationInner inner, NetworkInterfaceImpl parent, INetworkManager NetworkManager, bool isInCreateModel) :
            base(inner.Id, inner, parent)
        {
            this.isInCreateMode = isInCreateModel;
            this.NetworkManager = NetworkManager;
        }

        internal static NicIpConfigurationImpl PrepareNicIpConfiguration(string name, NetworkInterfaceImpl parent, INetworkManager NetworkManager)
        {
            NetworkInterfaceIPConfigurationInner ipConfigurationInner = new NetworkInterfaceIPConfigurationInner();
            ipConfigurationInner.Name = name;
            return new NicIpConfigurationImpl(ipConfigurationInner,
                parent,
                NetworkManager,
                true);
        }

        public string Name
        {
            get
            {
                return Inner.Name;
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
        public IPublicIpAddress PublicIpAddress()
        {
            string id = this.Inner.PublicIPAddress.Id;
            if (id == null)
            {
                return null;
            }

            return this.NetworkManager.PublicIpAddresses.GetByGroup(
                ResourceUtils.GroupFromResourceId(id), ResourceUtils.NameFromResourceId(id));
        }

        public string SubnetId
        {
            get
            {
                return this.Inner.Subnet.Id;
            }
        }
        public INetwork Network()
        {
            string id = this.SubnetId;
            return this.NetworkManager.Networks.GetByGroup(ResourceUtils.GroupFromResourceId(id),
                ResourceUtils.ExtractFromResourceId(id, "virtualNetworks"));
        }

        public string PrivateIp
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
        public NetworkInterfaceImpl Attach()
        {
            return Parent.WithIpConfiguration(this);
        }

        public NicIpConfigurationImpl WithNewNetwork(ICreatable<INetwork> creatable)
        {
            this.creatableVirtualNetworkKey = creatable.Key;
            this.Parent.AddToCreatableDependencies(creatable);
            return this;
        }

        public NicIpConfigurationImpl WithNewNetwork(string name, string addressSpaceCidr)
        {

            var definitionWithGroup = this.NetworkManager.Networks
                .Define(name)
                .WithRegion(this.Parent.RegionName);

            V2.Network.Network.Definition.IWithCreate definitionAfterGroup;
            if (this.Parent.NewGroup() != null)
            {
                definitionAfterGroup = definitionWithGroup.WithNewResourceGroup(this.Parent.NewGroup());
            }
            else
            {
                definitionAfterGroup = definitionWithGroup.WithExistingResourceGroup(this.Parent.ResourceGroupName);
            }

            return WithNewNetwork(definitionAfterGroup.WithAddressSpace(addressSpaceCidr));
        }

        public NicIpConfigurationImpl WithNewNetwork(string addressSpaceCidr)
        {
            return WithNewNetwork(this.Parent.Namer.RandomName("vnet", 20), addressSpaceCidr);
        }

        public NicIpConfigurationImpl WithExistingNetwork(INetwork network)
        {
            this.existingVirtualNetworkToAssociate = network;
            return this;
        }

        public NicIpConfigurationImpl WithPrivateIpAddressDynamic()
        {
            this.Inner.PrivateIPAllocationMethod = IPAllocationMethod.Dynamic;
            this.Inner.PrivateIPAddress = null;
            return this;
        }

        public NicIpConfigurationImpl WithPrivateIpAddressStatic(string staticPrivateIpAddress)
        {
            this.Inner.PrivateIPAllocationMethod = IPAllocationMethod.Static;
            this.Inner.PrivateIPAddress = staticPrivateIpAddress;
            return this;
        }

        public NicIpConfigurationImpl WithNewPublicIpAddress(ICreatable<IPublicIpAddress> creatable)
        {
            if (this.creatablePublicIpKey == null)
            {
                this.creatablePublicIpKey = creatable.Key;
                this.Parent.AddToCreatableDependencies(creatable);
            }
            return this;
        }

        public NicIpConfigurationImpl WithNewPublicIpAddress()
        {
            string name = this.Parent.Namer.RandomName("pip", 15);
            return WithNewPublicIpAddress(PrepareCreatablePublicIp(name, name));
        }

        public NicIpConfigurationImpl WithNewPublicIpAddress(string leafDnsLabel)
        {
            return WithNewPublicIpAddress(PrepareCreatablePublicIp(this.Parent.Namer.RandomName("pip", 15), leafDnsLabel));
        }

        public NicIpConfigurationImpl WithExistingPublicIpAddress(IPublicIpAddress publicIpAddress)
        {
            this.existingPublicIpAddressToAssociate = publicIpAddress;
            return this;
        }

        public NicIpConfigurationImpl WithoutPublicIpAddress()
        {
            this.removePrimaryPublicIPAssociation = true;
            return this;
        }

        public NicIpConfigurationImpl WithSubnet(string name)
        {
            this.subnetToAssociate = name;
            return this;
        }

        public NicIpConfigurationImpl WithExistingLoadBalancer(ILoadBalancer loadBalancer)
        {
            this.loadBalancerToAssociate = loadBalancer;
            return this;
        }

        public NicIpConfigurationImpl WithBackendAddressPool(string name)
        {
            foreach (BackendAddressPoolInner pool in this.loadBalancerToAssociate.Inner.BackendAddressPools)
            {
                if (pool.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    EnsureBackendAddressPools.Add(pool);
                    return this;
                }
            }

            return this;
        }

        private IList<BackendAddressPoolInner> EnsureBackendAddressPools
        {
            get
            {
                IList<BackendAddressPoolInner> poolRefs = this.Inner.LoadBalancerBackendAddressPools;
                if (poolRefs == null)
                {
                    poolRefs = new List<BackendAddressPoolInner>();
                    this.Inner.LoadBalancerBackendAddressPools = poolRefs;
                }

                return poolRefs;
            }
        }
        internal static void EnsureConfigurations(IList<INicIpConfiguration> nicIpConfigurations)
        {
            foreach (INicIpConfiguration nicIpConfiguration in nicIpConfigurations)
            {
                NicIpConfigurationImpl config = (NicIpConfigurationImpl)nicIpConfiguration;
                config.Inner.Subnet = config.SubnetToAssociate;
                config.Inner.PublicIPAddress = config.PublicIpToAssociate;
            }
        }

        private ICreatable<IPublicIpAddress> PrepareCreatablePublicIp(string name, string leafDnsLabel)
        {

            var definitionWithGroup = this.NetworkManager.PublicIpAddresses
                .Define(name)
                .WithRegion(this.Parent.RegionName);

            PublicIpAddress.Definition.IWithCreate definitionAfterGroup;
            if (this.Parent.NewGroup() != null)
            {
                definitionAfterGroup = definitionWithGroup.WithNewResourceGroup(this.Parent.NewGroup());
            }
            else
            {
                definitionAfterGroup = definitionWithGroup.WithExistingResourceGroup(this.Parent.ResourceGroupName);
            }

            return definitionAfterGroup.WithLeafDomainLabel(leafDnsLabel);
        }

        NetworkInterface.Update.IUpdate ISettable<NetworkInterface.Update.IUpdate>.Parent()
        {
            return base.Parent;
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
                SubnetInner subnetInner = new SubnetInner();
                if (this.isInCreateMode)
                {
                    if (this.creatableVirtualNetworkKey != null)
                    {
                        INetwork network = (INetwork)this.Parent.CreatedDependencyResource(this.creatableVirtualNetworkKey);
                        subnetInner.Id = network.Inner.Subnets[0].Id;
                        return subnetInner;
                    }

                    foreach (SubnetInner subnet in this.existingVirtualNetworkToAssociate.Inner.Subnets)
                    {
                        if (subnet.Name.Equals(this.subnetToAssociate, StringComparison.OrdinalIgnoreCase))
                        {
                            subnetInner.Id = subnet.Id;
                            return subnetInner;
                        }
                    }

                    throw new Exception(string.Format("A subnet with name '{0}' not found under the network '{0}'",
                        this.subnetToAssociate,
                        this.existingVirtualNetworkToAssociate.Name));

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
        private PublicIPAddressInner PublicIpToAssociate
        {
            get
            {
                if (this.removePrimaryPublicIPAssociation)
                {
                    return null;
                }

                PublicIPAddressInner publicIPAddressInner = null;
                if (this.creatablePublicIpKey != null)
                {
                    IPublicIpAddress publicIpAddress = (IPublicIpAddress)this.Parent
                        .CreatedDependencyResource(this.creatablePublicIpKey);
                    publicIPAddressInner = publicIpAddress.Inner;
                }

                if (this.existingPublicIpAddressToAssociate != null)
                {
                    publicIPAddressInner = this.existingPublicIpAddressToAssociate.Inner;
                }

                if (publicIPAddressInner != null)
                {
                    //TODO: validate that this is correct
                    return publicIPAddressInner;
                    //SubResource subResource = new SubResource();
                    //subResource.withId(publicIPAddressInner.id());
                    //return subResource;
                }

                if (!this.isInCreateMode)
                {
                    return this.Inner.PublicIPAddress;
                }

                return null;
            }
        }
    }
}