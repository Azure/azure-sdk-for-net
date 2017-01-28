// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Models;
    using NicIpConfiguration.UpdateDefinition;
    using System.Collections.Generic;
    using Resource.Fluent.Core;
    using NicIpConfiguration.Definition;
    using Resource.Fluent.Core.ResourceActions;
    using Resource.Fluent.Core.ChildResourceActions;
    using System;
    using Resource.Fluent;
    using Management.Fluent.Network;

    /// <summary>
    /// Implementation for NicIpConfiguration and its create and update interfaces.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uTmljSXBDb25maWd1cmF0aW9uSW1wbA==
    internal partial class NicIpConfigurationImpl :
        NicIpConfigurationBaseImpl<NetworkInterfaceImpl, INetworkInterface>,
        INicIpConfiguration,
        IDefinition<NetworkInterface.Definition.IWithCreate>,
        IUpdateDefinition<NetworkInterface.Update.IUpdate>,
        NicIpConfiguration.Update.IUpdate
    {
        private INetworkManager networkManager;
        private bool isInCreateMode;
        private string creatableVirtualNetworkKey;
        private string creatablePublicIpKey;
        private INetwork existingVirtualNetworkToAssociate;
        private string existingPublicIpAddressIdToAssociate;
        private string subnetToAssociate;
        private bool removePrimaryPublicIPAssociation;

        ///GENMHASH:92E4980351E0DE705DF924453E21E605:E7EEE1F7AB5D4421115C2BD2252C5E0D
        internal NicIpConfigurationImpl(
            NetworkInterfaceIPConfigurationInner inner,
            NetworkInterfaceImpl parent,
            INetworkManager networkManager,
            bool isInCreateMode) : base(inner, parent, networkManager)
        {
            this.isInCreateMode = isInCreateMode;
            this.networkManager = networkManager;
        }

        ///GENMHASH:283CFC6EBD90D03165F029795BB0A81D:755A70E8170ABE5AC23D42E03EE7336A
        internal static NicIpConfigurationImpl PrepareNicIpConfiguration(string name, NetworkInterfaceImpl parent, INetworkManager networkManager)
        {
            NetworkInterfaceIPConfigurationInner ipConfigurationInner = new NetworkInterfaceIPConfigurationInner();
            ipConfigurationInner.Name = name;
            return new NicIpConfigurationImpl(ipConfigurationInner, parent, networkManager, true);
        }

        public override string Name()
        {
            return Inner.Name;
        }

        ///GENMHASH:8E78B2392D3D6F9CD12A41F263DE68A1:40A9660FDDD1BECDBEBCD406933EBC9B
        internal string PublicIpAddressId()
        {
            return (Inner.PublicIPAddress != null) ? Inner.PublicIPAddress.Id : null;
        }

        ///GENMHASH:377296039E5241FB1B02988EFB811F77:AB140A12F9E596E2CB0F642A8D348B46
        internal IPublicIpAddress GetPublicIpAddress()
        {
            string id = PublicIpAddressId();
            return (id != null) ? Parent.Manager.PublicIpAddresses.GetById(id) : null;
        }

        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:4652AD8DEBE2130BB62A479BB6FEAD47
        internal NetworkInterfaceImpl Attach()
        {
            return Parent.WithIpConfiguration(this);
        }

        ///GENMHASH:DE0F4E4D7BE6C2D424AD89F5B15B8C65:A639D320D78CCD2E721B24D606D36694
        internal NicIpConfigurationImpl WithNewNetwork(ICreatable<INetwork> creatable)
        {
            creatableVirtualNetworkKey = creatable.Key;
            Parent.AddToCreatableDependencies(creatable as IResourceCreator<Management.Resource.Fluent.Core.IHasId>);
            return this;
        }

        ///GENMHASH:B5B394278E45FCA8B4503E2FCB31EF46:CC21AC0A859CA80548303077EA4E1648
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

        ///GENMHASH:73C84BBD3D307731A80C2DAF5F9B5EB0:591AFF02B37C91A947B66FA2CFEFFB51
        internal NicIpConfigurationImpl WithNewNetwork(string addressSpaceCidr)
        {
            return WithNewNetwork(SdkContext.RandomResourceName("vnet", 20), addressSpaceCidr);
        }

        ///GENMHASH:B54CAD7C3DE0D3C50B8DCF3D902BFB18:84C60D2881F3475627D1A9FAE46DA4DD
        internal NicIpConfigurationImpl WithExistingNetwork(INetwork network)
        {
            existingVirtualNetworkToAssociate = network;
            return this;
        }

        ///GENMHASH:EA98B464B10BD645EE3B0689825B43B8:BF9C09A5F85740EB1DF5E781C47B92F3
        internal NicIpConfigurationImpl WithPrivateIpAddressDynamic()
        {
            Inner.PrivateIPAllocationMethod = IPAllocationMethod.Dynamic.ToString();
            Inner.PrivateIPAddress = null;
            return this;
        }

        ///GENMHASH:6CDEF6BE4432158ED3F8917E000EAD56:98FC652F984FD82C56939807419E1B17
        internal NicIpConfigurationImpl WithPrivateIpAddressStatic(string staticPrivateIpAddress)
        {
            Inner.PrivateIPAllocationMethod = IPAllocationMethod.Static.ToString();
            Inner.PrivateIPAddress = staticPrivateIpAddress;
            return this;
        }

        ///GENMHASH:FE2FB4C2B86589D7D187246933236472:FAE89A61E89DFEABF380DF820A5ACC01
        internal NicIpConfigurationImpl WithNewPublicIpAddress(ICreatable<IPublicIpAddress> creatable)
        {
            if (creatablePublicIpKey == null)
            {
                creatablePublicIpKey = creatable.Key;
                Parent.AddToCreatableDependencies(creatable as IResourceCreator<Management.Resource.Fluent.Core.IHasId>);
            }

            return this;
        }

        ///GENMHASH:9865456A38EDF249959594524980AA77:7B29468CDC459656909C083DB3E8BC68
        internal NicIpConfigurationImpl WithNewPublicIpAddress()
        {
            string name = SdkContext.RandomResourceName("pip", 15);
            return WithNewPublicIpAddress(PrepareCreatablePublicIp(name, name));
        }

        ///GENMHASH:978AA5D6B234EB71E90EC88584153043:1835AC76D7C732B190DA61AA166DF5E5
        internal NicIpConfigurationImpl WithNewPublicIpAddress(string leafDnsLabel)
        {
            return WithNewPublicIpAddress(
                PrepareCreatablePublicIp(SdkContext.RandomResourceName("pip", 15), leafDnsLabel));
        }

        ///GENMHASH:6FE68F40574F5B84C669001E20CC658F:1D98EE3582EA8AC346853CFC679265D2
        internal NicIpConfigurationImpl WithExistingPublicIpAddress(IPublicIpAddress publicIpAddress)
        {

            return WithExistingPublicIpAddress(publicIpAddress.Id);
        }

        ///GENMHASH:DD83F863BB3E548AA6773EF2F2FDD700:1F2CFFCD82BB739E1AB254EDFD81BAFC
        internal NicIpConfigurationImpl WithExistingPublicIpAddress(string resourceId)
        {
            existingPublicIpAddressIdToAssociate = resourceId;
            return this;
        }

        ///GENMHASH:1B49C92CBA9BDBBF9FBFD26544224384:D2568543D2B6FA67EEC6DB9538B32535
        internal NicIpConfigurationImpl WithoutPublicIpAddress()
        {
            removePrimaryPublicIPAssociation = true;
            return this;
        }

        ///GENMHASH:0FBBECB150CBC82F165D8BA614AB135A:055A43C17C98D1AD747257B0659283D6
        internal NicIpConfigurationImpl WithSubnet(string name)
        {
            subnetToAssociate = name;
            return this;
        }

        ///GENMHASH:D36B69B83A3C752672806F0242C22209:FBE8ED51BA892F18B9FBCE3042C8244C
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

        ///GENMHASH:03CBA85933E5B90121E4F4AE70F457EE:95BCC3AF459B4DC5CF3EC334E7D52AE2
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

        ///GENMHASH:63C8240EDA17974D47E176085F22436A:2D595A527D306417A72C1C52A5906DB3
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

        ///GENMHASH:16FE220D08C6A172C95B9CD77E1507B6:580E52612CECAE1F93702F42EBA77132
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

        ///GENMHASH:F0EFC1121F2CA438614E95E86C18505F:39E41A58CFED77300407A3F20BC69F43
        internal static void EnsureConfigurations(List<INicIpConfiguration> nicIpConfigurations)
        {
            foreach (var nicIpConfiguration in nicIpConfigurations)
            {
                NicIpConfigurationImpl config = (NicIpConfigurationImpl)nicIpConfiguration;
                config.Inner.Subnet = config.SubnetToAssociate();
                config.Inner.PublicIPAddress = config.PublicIpToAssociate();
            }
        }

        ///GENMHASH:914020627FB9358A7D31FEE90CA38704:880DBC5A2E3782D786F8E47E6C363C0F
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

        ///GENMHASH:D14BFB60D59198612CF4649F7C5412EA:CB9711B0085B05FCA1A439986E7C8A08
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

        ///GENMHASH:8D4DC1646027B23F9B0747B303606F35:FB5ABEA0B3E44F5F78C6CEF057F7B8BD
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

        ///GENMHASH:F4D09499BC5D2BC9FBFD23F99BF3219B:98C9348F48818CBA9BE5411158A7ECB2
        internal NicIpConfigurationImpl WithPrivateIpVersion(string ipVersion)
        {
            Inner.PrivateIPAddressVersion = ipVersion;
            return this;
        }

        ///GENMHASH:6CB02C98B1D9201E95334813294DA523:DD56D3C148866A86DF7804331EFA54F7
        internal NicIpConfigurationImpl WithoutLoadBalancerBackends()
        {
            Inner.LoadBalancerBackendAddressPools = null;
            return this;
        }

        ///GENMHASH:8B463B99540F7AFAB4F1D7B5D595864D:DC3E58307ACC18C04135AB98DDC83680
        internal NicIpConfigurationImpl WithoutLoadBalancerInboundNatRules()
        {
            Inner.LoadBalancerInboundNatRules = null;
            return this;
        }

        NetworkInterface.Update.IUpdate ISettable<NetworkInterface.Update.IUpdate>.Parent()
        {
            return Parent;
        }

        /// <summary>
        /// true if this is the primary ip configuration.
        /// </summary>
        bool Microsoft.Azure.Management.Network.Fluent.INicIpConfigurationBase.IsPrimary
        {
            get
            {
                return this.IsPrimary();
            }
        }
    }
}
