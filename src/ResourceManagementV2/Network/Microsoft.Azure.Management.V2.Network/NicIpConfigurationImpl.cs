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
    public class NicIpConfigurationImpl :
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

        /// <summary>
        /// Specifies that remove any public IP associated with the IP configuration.
        /// </summary>
        /// <returns>the next stage of the network interface IP configuration update</returns>
        NicIpConfiguration.Update.IUpdate NicIpConfiguration.Update.IWithPublicIpAddress.WithoutPublicIpAddress()
        {
            return this.WithoutPublicIpAddress() as NicIpConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Create a new public IP address to associate the network interface IP configuration with,
        /// based on the provided definition.
        /// <p>
        /// If there is public IP associated with the IP configuration then that will be removed in
        /// favour of this.
        /// </summary>
        /// <param name="creatable">creatable a creatable definition for a new public IP</param>
        /// <returns>the next stage of the network interface IP configuration update</returns>
        NicIpConfiguration.Update.IUpdate NicIpConfiguration.Update.IWithPublicIpAddress.WithNewPublicIpAddress(ICreatable<IPublicIpAddress> creatable)
        {
            return this.WithNewPublicIpAddress(creatable) as NicIpConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource and associate it
        /// with the IP configuration.
        /// <p>
        /// The internal name and DNS label for the public IP address will be derived from the network interface
        /// name, if there is an existing public IP association then that will be removed in favour of this.
        /// </summary>
        /// <returns>the next stage of the network interface IP configuration update</returns>
        NicIpConfiguration.Update.IUpdate NicIpConfiguration.Update.IWithPublicIpAddress.WithNewPublicIpAddress()
        {
            return this.WithNewPublicIpAddress() as NicIpConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource, with the specified DNS
        /// label and associate it with the IP configuration.
        /// <p>
        /// The internal name for the public IP address will be derived from the DNS label, if there is an existing
        /// public IP association then that will be removed in favour of this
        /// </summary>
        /// <param name="leafDnsLabel">leafDnsLabel the leaf domain label</param>
        /// <returns>the next stage of the network interface IP configuration update</returns>
        NicIpConfiguration.Update.IUpdate NicIpConfiguration.Update.IWithPublicIpAddress.WithNewPublicIpAddress(string leafDnsLabel)
        {
            return this.WithNewPublicIpAddress(leafDnsLabel) as NicIpConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Create a new virtual network to associate with the  network interface IP configuration,
        /// based on the provided definition.
        /// </summary>
        /// <param name="creatable">creatable a creatable definition for a new virtual network</param>
        /// <returns>the next stage of the network interface IP configuration definition</returns>
        NicIpConfiguration.UpdateDefinition.IWithPrivateIp<NetworkInterface.Update.IUpdate> NicIpConfiguration.UpdateDefinition.IWithNetwork<NetworkInterface.Update.IUpdate>.WithNewNetwork(ICreatable<INetwork> creatable)
        {
            return this.WithNewNetwork(creatable) as NicIpConfiguration.UpdateDefinition.IWithPrivateIp<NetworkInterface.Update.IUpdate>;
        }

        /// <summary>
        /// Creates a new virtual network to associate with the network interface IP configuration.
        /// <p>
        /// the virtual network will be created in the same resource group and region as of parent
        /// network interface, it will be created with the specified address space and a default subnet
        /// covering the entirety of the network IP address space.
        /// </summary>
        /// <param name="name">name the name of the new virtual network</param>
        /// <param name="addressSpace">addressSpace the address space for rhe virtual network</param>
        /// <returns>the next stage of the network interface IP configuration definition</returns>
        NicIpConfiguration.UpdateDefinition.IWithPrivateIp<NetworkInterface.Update.IUpdate> NicIpConfiguration.UpdateDefinition.IWithNetwork<NetworkInterface.Update.IUpdate>.WithNewNetwork(string name, string addressSpace)
        {
            return this.WithNewNetwork(name, addressSpace) as NicIpConfiguration.UpdateDefinition.IWithPrivateIp<NetworkInterface.Update.IUpdate>;
        }

        /// <summary>
        /// Creates a new virtual network to associate with the network interface IP configuration.
        /// <p>
        /// the virtual network will be created in the same resource group and region as of parent network interface,
        /// it will be created with the specified address space and a default subnet covering the entirety of the
        /// network IP address space.
        /// </summary>
        /// <param name="addressSpace">addressSpace the address space for the virtual network</param>
        /// <returns>the next stage of the network interface IP configuration definition</returns>
        NicIpConfiguration.UpdateDefinition.IWithPrivateIp<NetworkInterface.Update.IUpdate> NicIpConfiguration.UpdateDefinition.IWithNetwork<NetworkInterface.Update.IUpdate>.WithNewNetwork(string addressSpace)
        {
            return this.WithNewNetwork(addressSpace) as NicIpConfiguration.UpdateDefinition.IWithPrivateIp<NetworkInterface.Update.IUpdate>;
        }

        /// <summary>
        /// Associate an existing virtual network with the network interface IP configuration.
        /// </summary>
        /// <param name="network">network an existing virtual network</param>
        /// <returns>the next stage of the network interface IP configuration definition</returns>
        NicIpConfiguration.UpdateDefinition.IWithSubnet<NetworkInterface.Update.IUpdate> NicIpConfiguration.UpdateDefinition.IWithNetwork<NetworkInterface.Update.IUpdate>.WithExistingNetwork(INetwork network)
        {
            return this.WithExistingNetwork(network) as NicIpConfiguration.UpdateDefinition.IWithSubnet<NetworkInterface.Update.IUpdate>;
        }

        /// <summary>
        /// Create a new virtual network to associate with the  network interface IP configuration,
        /// based on the provided definition.
        /// </summary>
        /// <param name="creatable">creatable a creatable definition for a new virtual network</param>
        /// <returns>the next stage of the network interface IP configuration definition</returns>
        NicIpConfiguration.Definition.IWithPrivateIp<NetworkInterface.Definition.IWithCreate> NicIpConfiguration.Definition.IWithNetwork<NetworkInterface.Definition.IWithCreate>.WithNewNetwork(ICreatable<INetwork> creatable)
        {
            return this.WithNewNetwork(creatable) as NicIpConfiguration.Definition.IWithPrivateIp<NetworkInterface.Definition.IWithCreate>;
        }

        /// <summary>
        /// Creates a new virtual network to associate with the network interface IP configuration.
        /// <p>
        /// the virtual network will be created in the same resource group and region as of parent
        /// network interface, it will be created with the specified address space and a default subnet
        /// covering the entirety of the network IP address space.
        /// </summary>
        /// <param name="name">name the name of the new virtual network</param>
        /// <param name="addressSpace">addressSpace the address space for rhe virtual network</param>
        /// <returns>the next stage of the network interface IP configuration definition</returns>
        NicIpConfiguration.Definition.IWithPrivateIp<NetworkInterface.Definition.IWithCreate> NicIpConfiguration.Definition.IWithNetwork<NetworkInterface.Definition.IWithCreate>.WithNewNetwork(string name, string addressSpace)
        {
            return this.WithNewNetwork(name, addressSpace) as NicIpConfiguration.Definition.IWithPrivateIp<NetworkInterface.Definition.IWithCreate>;
        }

        /// <summary>
        /// Creates a new virtual network to associate with the network interface IP configuration.
        /// <p>
        /// the virtual network will be created in the same resource group and region as of parent network interface,
        /// it will be created with the specified address space and a default subnet covering the entirety of the
        /// network IP address space.
        /// </summary>
        /// <param name="addressSpace">addressSpace the address space for the virtual network</param>
        /// <returns>the next stage of the network interface IP configuration definition</returns>
        NicIpConfiguration.Definition.IWithPrivateIp<NetworkInterface.Definition.IWithCreate> NicIpConfiguration.Definition.IWithNetwork<NetworkInterface.Definition.IWithCreate>.WithNewNetwork(string addressSpace)
        {
            return this.WithNewNetwork(addressSpace) as NicIpConfiguration.Definition.IWithPrivateIp<NetworkInterface.Definition.IWithCreate>;
        }

        /// <summary>
        /// Associate an existing virtual network with the network interface IP configuration.
        /// </summary>
        /// <param name="network">network an existing virtual network</param>
        /// <returns>the next stage of the network interface IP configuration definition</returns>
        NicIpConfiguration.Definition.IWithSubnet<NetworkInterface.Definition.IWithCreate> NicIpConfiguration.Definition.IWithNetwork<NetworkInterface.Definition.IWithCreate>.WithExistingNetwork(INetwork network)
        {
            return this.WithExistingNetwork(network) as NicIpConfiguration.Definition.IWithSubnet<NetworkInterface.Definition.IWithCreate>;
        }

        /// <summary>
        /// Assigns the specified static private IP address within the specified existing virtual network
        /// subnet to the network interface IP configuration.
        /// </summary>
        /// <param name="staticPrivateIpAddress">staticPrivateIpAddress the static IP address within the specified subnet to assign to</param>
        /// <param name="the">the network interface</param>
        /// <returns>the next stage of network interface IP configuration definition</returns>
        NicIpConfiguration.UpdateDefinition.IWithAttach<NetworkInterface.Update.IUpdate> NicIpConfiguration.UpdateDefinition.IWithPrivateIp<NetworkInterface.Update.IUpdate>.WithPrivateIpAddressStatic(string staticPrivateIpAddress)
        {
            return this.WithPrivateIpAddressStatic(staticPrivateIpAddress) as NicIpConfiguration.UpdateDefinition.IWithAttach<NetworkInterface.Update.IUpdate>;
        }

        /// <summary>
        /// Enables dynamic private IP address allocation within the specified existing virtual network
        /// subnet for the network interface IP configuration.
        /// </summary>
        /// <returns>the next stage of network interface IP configuration definition</returns>
        NicIpConfiguration.UpdateDefinition.IWithAttach<NetworkInterface.Update.IUpdate> NicIpConfiguration.UpdateDefinition.IWithPrivateIp<NetworkInterface.Update.IUpdate>.WithPrivateIpAddressDynamic()
        {
            return this.WithPrivateIpAddressDynamic() as NicIpConfiguration.UpdateDefinition.IWithAttach<NetworkInterface.Update.IUpdate>;
        }

        /// <summary>
        /// Assigns the specified static private IP address within the specified existing virtual network
        /// subnet to the network interface IP configuration.
        /// </summary>
        /// <param name="staticPrivateIpAddress">staticPrivateIpAddress the static IP address within the specified subnet to assign to</param>
        /// <param name="the">the network interface</param>
        /// <returns>the next stage of network interface IP configuration definition</returns>
        NicIpConfiguration.Definition.IWithAttach<NetworkInterface.Definition.IWithCreate> NicIpConfiguration.Definition.IWithPrivateIp<NetworkInterface.Definition.IWithCreate>.WithPrivateIpAddressStatic(string staticPrivateIpAddress)
        {
            return this.WithPrivateIpAddressStatic(staticPrivateIpAddress) as NicIpConfiguration.Definition.IWithAttach<NetworkInterface.Definition.IWithCreate>;
        }

        /// <summary>
        /// Enables dynamic private IP address allocation within the specified existing virtual network
        /// subnet for the network interface IP configuration.
        /// </summary>
        /// <returns>the next stage of network interface IP configuration definition</returns>
        NicIpConfiguration.Definition.IWithAttach<NetworkInterface.Definition.IWithCreate> NicIpConfiguration.Definition.IWithPrivateIp<NetworkInterface.Definition.IWithCreate>.WithPrivateIpAddressDynamic()
        {
            return this.WithPrivateIpAddressDynamic() as NicIpConfiguration.Definition.IWithAttach<NetworkInterface.Definition.IWithCreate>;
        }

        /// <returns>the resource id of the virtual network subnet associated with this IP configuration.</returns>
        string INicIpConfiguration.SubnetId
        {
            get
            {
                return this.SubnetId as string;
            }
        }
        /// <summary>
        /// Gets the public IP address associated with this IP configuration.
        /// <p>
        /// This method makes a rest API call to fetch the public IP.
        /// </summary>
        /// <returns>the public IP associated with this IP configuration or null if there is no public IP associated</returns>
        IPublicIpAddress INicIpConfiguration.PublicIpAddress
        {
            get
            {
                return this.PublicIpAddress() as IPublicIpAddress;
            }
        }

        /// <summary>
        /// Gets the resource id of the public IP address associated with this IP configuration.
        /// </summary>
        /// <returns>public IP resource ID or null if there is no public IP associated</returns>
        string INicIpConfiguration.PublicIpAddressId
        {
            get
            {
                return this.PublicIpAddressId as string;
            }
        }
        /// <returns>the private IP allocation method (Dynamic, Static)</returns>
        string INicIpConfiguration.PrivateIpAllocationMethod
        {
            get
            {
                return this.PrivateIpAllocationMethod as string;
            }
        }
        /// <summary>
        /// Gets the private IP address allocated to this IP configuration.
        /// <p>
        /// The private IP will be within the virtual network subnet of this IP configuration.
        /// </summary>
        /// <returns>the private IP addresses</returns>
        string INicIpConfiguration.PrivateIp
        {
            get
            {
                return this.PrivateIp as string;
            }
        }
        /// <summary>
        /// Gets the virtual network associated with this IP configuration.
        /// <p>
        /// This method makes a rest API call to fetch the public IP.
        /// </summary>
        /// <returns>the virtual network associated with this this IP configuration.</returns>
        INetwork INicIpConfiguration.Network
        {
            get
            {
                return this.Network() as INetwork;
            }
        }

        NetworkInterface.Update.IUpdate Microsoft.Azure.Management.V2.Resource.Core.ChildResource.Update.IInUpdate<NetworkInterface.Update.IUpdate>.Attach()
        {
            return this.Attach() as NetworkInterface.Update.IUpdate;
        }

        NetworkInterface.Definition.IWithCreate Microsoft.Azure.Management.V2.Resource.Core.ChildResource.Definition.IInDefinition<NetworkInterface.Definition.IWithCreate>.Attach()
        {
            return this.Attach() as NetworkInterface.Definition.IWithCreate;
        }

        /// <returns>the name of the child resource</returns>
        string Microsoft.Azure.Management.V2.Resource.Core.IChildResource.Name
        {
            get
            {
                return this.Name as string;
            }
        }
        /// <summary>
        /// Specifies the load balancer to associate this IP configuration with.
        /// </summary>
        /// <param name="loadBalancer">loadBalancer an existing load balancer</param>
        /// <returns>the next stage of the update</returns>
        NicIpConfiguration.Update.IWithBackendAddressPool NicIpConfiguration.Update.IWithLoadBalancer.WithExistingLoadBalancer(ILoadBalancer loadBalancer)
        {
            return this.WithExistingLoadBalancer(loadBalancer) as NicIpConfiguration.Update.IWithBackendAddressPool;
        }

        /// <summary>
        /// Associates an existing public IP address with the network interface IP configuration.
        /// </summary>
        /// <param name="publicIpAddress">publicIpAddress an existing public IP address</param>
        /// <returns>the next stage of the IP configuration definition</returns>
        NicIpConfiguration.UpdateDefinition.IWithAttach<NetworkInterface.Update.IUpdate> NicIpConfiguration.UpdateDefinition.IWithPublicIpAddress<NetworkInterface.Update.IUpdate>.WithExistingPublicIpAddress(IPublicIpAddress publicIpAddress)
        {
            return this.WithExistingPublicIpAddress(publicIpAddress) as NicIpConfiguration.UpdateDefinition.IWithAttach<NetworkInterface.Update.IUpdate>;
        }

        /// <summary>
        /// Create a new public IP address to associate with the network interface IP configuration,
        /// based on the provided definition.
        /// </summary>
        /// <param name="creatable">creatable a creatable definition for a new public IP</param>
        /// <returns>the next stage of the network interface IP configuration definition</returns>
        NicIpConfiguration.UpdateDefinition.IWithAttach<NetworkInterface.Update.IUpdate> NicIpConfiguration.UpdateDefinition.IWithPublicIpAddress<NetworkInterface.Update.IUpdate>.WithNewPublicIpAddress(ICreatable<IPublicIpAddress> creatable)
        {
            return this.WithNewPublicIpAddress(creatable) as NicIpConfiguration.UpdateDefinition.IWithAttach<NetworkInterface.Update.IUpdate>;
        }

        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource and associate it
        /// with with the network interface IP configuration.
        /// <p>
        /// The internal name and DNS label for the public IP address will be derived from the network interface name.
        /// </summary>
        /// <returns>the next stage of the network interface IP configuration definition</returns>
        NicIpConfiguration.UpdateDefinition.IWithAttach<NetworkInterface.Update.IUpdate> NicIpConfiguration.UpdateDefinition.IWithPublicIpAddress<NetworkInterface.Update.IUpdate>.WithNewPublicIpAddress()
        {
            return this.WithNewPublicIpAddress() as NicIpConfiguration.UpdateDefinition.IWithAttach<NetworkInterface.Update.IUpdate>;
        }

        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource, with the specified DNS label
        /// and associate it with the network interface IP configuration.
        /// <p>
        /// The internal name for the public IP address will be derived from the DNS label.
        /// </summary>
        /// <param name="leafDnsLabel">leafDnsLabel the leaf domain label</param>
        /// <returns>tthe next stage of the IP configuration definition</returns>
        NicIpConfiguration.UpdateDefinition.IWithAttach<NetworkInterface.Update.IUpdate> NicIpConfiguration.UpdateDefinition.IWithPublicIpAddress<NetworkInterface.Update.IUpdate>.WithNewPublicIpAddress(string leafDnsLabel)
        {
            return this.WithNewPublicIpAddress(leafDnsLabel) as NicIpConfiguration.UpdateDefinition.IWithAttach<NetworkInterface.Update.IUpdate>;
        }

        /// <summary>
        /// Associates an existing public IP address with the network interface IP configuration.
        /// </summary>
        /// <param name="publicIpAddress">publicIpAddress an existing public IP address</param>
        /// <returns>the next stage of the IP configuration definition</returns>
        NicIpConfiguration.Definition.IWithAttach<NetworkInterface.Definition.IWithCreate> NicIpConfiguration.Definition.IWithPublicIpAddress<NetworkInterface.Definition.IWithCreate>.WithExistingPublicIpAddress(IPublicIpAddress publicIpAddress)
        {
            return this.WithExistingPublicIpAddress(publicIpAddress) as NicIpConfiguration.Definition.IWithAttach<NetworkInterface.Definition.IWithCreate>;
        }

        /// <summary>
        /// Create a new public IP address to associate with the network interface IP configuration,
        /// based on the provided definition.
        /// </summary>
        /// <param name="creatable">creatable a creatable definition for a new public IP</param>
        /// <returns>the next stage of the network interface IP configuration definition</returns>
        NicIpConfiguration.Definition.IWithAttach<NetworkInterface.Definition.IWithCreate> NicIpConfiguration.Definition.IWithPublicIpAddress<NetworkInterface.Definition.IWithCreate>.WithNewPublicIpAddress(ICreatable<IPublicIpAddress> creatable)
        {
            return this.WithNewPublicIpAddress(creatable) as NicIpConfiguration.Definition.IWithAttach<NetworkInterface.Definition.IWithCreate>;
        }

        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource and associate it
        /// with with the network interface IP configuration.
        /// <p>
        /// The internal name and DNS label for the public IP address will be derived from the network interface name.
        /// </summary>
        /// <returns>the next stage of the network interface IP configuration definition</returns>
        NicIpConfiguration.Definition.IWithAttach<NetworkInterface.Definition.IWithCreate> NicIpConfiguration.Definition.IWithPublicIpAddress<NetworkInterface.Definition.IWithCreate>.WithNewPublicIpAddress()
        {
            return this.WithNewPublicIpAddress() as NicIpConfiguration.Definition.IWithAttach<NetworkInterface.Definition.IWithCreate>;
        }

        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource, with the specified DNS label
        /// and associate it with the network interface IP configuration.
        /// <p>
        /// The internal name for the public IP address will be derived from the DNS label.
        /// </summary>
        /// <param name="leafDnsLabel">leafDnsLabel the leaf domain label</param>
        /// <returns>tthe next stage of the IP configuration definition</returns>
        NicIpConfiguration.Definition.IWithAttach<NetworkInterface.Definition.IWithCreate> NicIpConfiguration.Definition.IWithPublicIpAddress<NetworkInterface.Definition.IWithCreate>.WithNewPublicIpAddress(string leafDnsLabel)
        {
            return this.WithNewPublicIpAddress(leafDnsLabel) as NicIpConfiguration.Definition.IWithAttach<NetworkInterface.Definition.IWithCreate>;
        }

        /// <summary>
        /// Assigns the specified static private IP address within the specified existing virtual network
        /// subnet to the network interface IP configuration.
        /// </summary>
        /// <param name="staticPrivateIpAddress">staticPrivateIpAddress the static IP address within the specified subnet to assign to</param>
        /// <param name="the">the  IP configuration</param>
        /// <returns>the next stage of the network interface IP configuration update</returns>
        NicIpConfiguration.Update.IUpdate NicIpConfiguration.Update.IWithPrivateIp.WithPrivateIpAddressStatic(string staticPrivateIpAddress)
        {
            return this.WithPrivateIpAddressStatic(staticPrivateIpAddress) as NicIpConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Enables dynamic private IP address allocation within the specified existing virtual network
        /// subnet to the network interface IP configuration.
        /// </summary>
        /// <returns>the next stage of the network interface IP configuration update</returns>
        NicIpConfiguration.Update.IUpdate NicIpConfiguration.Update.IWithPrivateIp.WithPrivateIpAddressDynamic()
        {
            return this.WithPrivateIpAddressDynamic() as NicIpConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Adds this network interface's IP configuration to the provided back end address pool of
        /// the specified load balancer.
        /// </summary>
        /// <param name="name">name the name of an existing load balancer back end address pool</param>
        /// <returns>the next stage of the update</returns>
        NicIpConfiguration.Update.IUpdate NicIpConfiguration.Update.IWithBackendAddressPool.WithBackendAddressPool(string name)
        {
            return this.WithBackendAddressPool(name) as NicIpConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Associate a subnet with the network interface IP configuration.
        /// </summary>
        /// <param name="name">name the subnet name</param>
        /// <returns>the next stage of the network interface IP configuration definition</returns>
        NicIpConfiguration.UpdateDefinition.IWithPrivateIp<NetworkInterface.Update.IUpdate> NicIpConfiguration.UpdateDefinition.IWithSubnet<NetworkInterface.Update.IUpdate>.WithSubnet(string name)
        {
            return this.WithSubnet(name) as NicIpConfiguration.UpdateDefinition.IWithPrivateIp<NetworkInterface.Update.IUpdate>;
        }

        /// <summary>
        /// Associate a subnet with the network interface IP configuration.
        /// </summary>
        /// <param name="name">name the subnet name</param>
        /// <returns>the next stage of the network interface IP configuration definition</returns>
        NicIpConfiguration.Definition.IWithPrivateIp<NetworkInterface.Definition.IWithCreate> NicIpConfiguration.Definition.IWithSubnet<NetworkInterface.Definition.IWithCreate>.WithSubnet(string name)
        {
            return this.WithSubnet(name) as NicIpConfiguration.Definition.IWithPrivateIp<NetworkInterface.Definition.IWithCreate>;
        }

        /// <summary>
        /// Associate a subnet with the network interface IP configuration.
        /// </summary>
        /// <param name="name">name the subnet name</param>
        /// <returns>the next stage of the network interface IP configuration update</returns>
        NicIpConfiguration.Update.IUpdate NicIpConfiguration.Update.IWithSubnet.WithSubnet(string name)
        {
            return this.WithSubnet(name) as NicIpConfiguration.Update.IUpdate;
        }

        NetworkInterface.Update.IUpdate ISettable<NetworkInterface.Update.IUpdate>.Parent()
        {
            return this.Parent;
        }
    }
}