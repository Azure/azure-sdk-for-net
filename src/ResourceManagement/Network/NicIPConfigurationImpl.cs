// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Models;
    using NicIPConfiguration.Definition;
    using NicIPConfiguration.UpdateDefinition;
    using ResourceManager.Fluent;
    using ResourceManager.Fluent.Core.ChildResourceActions;
    using ResourceManager.Fluent.Core.ResourceActions;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Implementation for NicIPConfiguration and its create and update interfaces.
    /// </summary>
    
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uTmljSVBDb25maWd1cmF0aW9uSW1wbA==
    internal partial class NicIPConfigurationImpl :
        NicIPConfigurationBaseImpl<NetworkInterfaceImpl, INetworkInterface>,
        INicIPConfiguration,
        IDefinition<NetworkInterface.Definition.IWithCreate>,
        IUpdateDefinition<NetworkInterface.Update.IUpdate>,
        NicIPConfiguration.Update.IUpdate
    {
        private INetworkManager networkManager;
        private bool isInCreateMode;
        private string creatableVirtualNetworkKey;
        private string creatablePublicIPKey;
        private INetwork existingVirtualNetworkToAssociate;
        private string existingPublicIPAddressIdToAssociate;
        private string subnetToAssociate;
        private bool removePrimaryPublicIPAssociation;

        
        ///GENMHASH:1A906542B8D46FF5050C871E33B0E0DF:E7EEE1F7AB5D4421115C2BD2252C5E0D
        internal NicIPConfigurationImpl(
            NetworkInterfaceIPConfigurationInner inner,
            NetworkInterfaceImpl parent,
            INetworkManager networkManager,
            bool isInCreateMode) : base(inner, parent, networkManager)
        {
            this.isInCreateMode = isInCreateMode;
            this.networkManager = networkManager;
        }

        
        ///GENMHASH:EFA3412991D5EA015E3A693B8641059A:6E359ADBD3D05D6ABDAF431DBDE4F635
        internal static NicIPConfigurationImpl PrepareNicIPConfiguration(string name, NetworkInterfaceImpl parent, INetworkManager networkManager)
        {
            NetworkInterfaceIPConfigurationInner ipConfigurationInner = new NetworkInterfaceIPConfigurationInner();
            ipConfigurationInner.Name = name;
            return new NicIPConfigurationImpl(ipConfigurationInner, parent, networkManager, true);
        }

        public override string Name()
        {
            return Inner.Name;
        }

        
        ///GENMHASH:5EF934D4E2CF202DF23C026435D9F6D6:40A9660FDDD1BECDBEBCD406933EBC9B
        internal string PublicIPAddressId()
        {
            return (Inner.PublicIPAddress != null) ? Inner.PublicIPAddress.Id : null;
        }

        
        ///GENMHASH:166583FE514624A3D800151836CD57C1:8F485ACC852168F9BE0310C99854062E
        internal IPublicIPAddress GetPublicIPAddress()
        {
            string id = PublicIPAddressId();
            return (id != null) ? Parent.Manager.PublicIPAddresses.GetById(id) : null;
        }

        
        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:E02BDC0972DED2429D8412C6E416C2BA
        internal NetworkInterfaceImpl Attach()
        {
            return Parent.WithIPConfiguration(this);
        }

        
        ///GENMHASH:DE0F4E4D7BE6C2D424AD89F5B15B8C65:A639D320D78CCD2E721B24D606D36694
        internal NicIPConfigurationImpl WithNewNetwork(ICreatable<INetwork> creatable)
        {
            creatableVirtualNetworkKey = creatable.Key;
            Parent.AddToCreatableDependencies(creatable as IResourceCreator<Management.ResourceManager.Fluent.Core.IHasId>);
            return this;
        }

        
        ///GENMHASH:B5B394278E45FCA8B4503E2FCB31EF46:CC21AC0A859CA80548303077EA4E1648
        internal NicIPConfigurationImpl WithNewNetwork(string name, string addressSpaceCidr)
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
        internal NicIPConfigurationImpl WithNewNetwork(string addressSpaceCidr)
        {
            return WithNewNetwork(SdkContext.RandomResourceName("vnet", 20), addressSpaceCidr);
        }

        
        ///GENMHASH:B54CAD7C3DE0D3C50B8DCF3D902BFB18:84C60D2881F3475627D1A9FAE46DA4DD
        internal NicIPConfigurationImpl WithExistingNetwork(INetwork network)
        {
            existingVirtualNetworkToAssociate = network;
            return this;
        }

        
        ///GENMHASH:26224359DA104EABE1EDF7F491D110F7:BF9C09A5F85740EB1DF5E781C47B92F3
        internal NicIPConfigurationImpl WithPrivateIPAddressDynamic()
        {
            Inner.PrivateIPAllocationMethod = IPAllocationMethod.Dynamic.ToString();
            Inner.PrivateIPAddress = null;
            return this;
        }

        
        ///GENMHASH:9946B3475EBD5468D4462F188EEE86C2:B0B83C63E323AAB22F60069661B51903
        internal NicIPConfigurationImpl WithPrivateIPAddressStatic(string staticPrivateIPAddress)
        {
            Inner.PrivateIPAllocationMethod = IPAllocationMethod.Static.ToString();
            Inner.PrivateIPAddress = staticPrivateIPAddress;
            return this;
        }

        
        ///GENMHASH:52541ED0C8AE1806DF3F2DF0DE092357:C9196B5FC5D2D3679E623C4CBFC0DCED
        internal NicIPConfigurationImpl WithNewPublicIPAddress(ICreatable<IPublicIPAddress> creatable)
        {
            if (creatablePublicIPKey == null)
            {
                creatablePublicIPKey = creatable.Key;
                Parent.AddToCreatableDependencies(creatable as IResourceCreator<Management.ResourceManager.Fluent.Core.IHasId>);
            }

            return this;
        }

        
        ///GENMHASH:1C505DCDEFCB5F029B7A60E2375286BF:3FA7D2EF04027DEAAE836DB63A20039B
        internal NicIPConfigurationImpl WithNewPublicIPAddress()
        {
            string name = SdkContext.RandomResourceName("pip", 15);
            return WithNewPublicIPAddress(PrepareCreatablePublicIP(name, name));
        }


        
        ///GENMHASH:233A62609A15DC3B8EB48DD8DB699DDC:5F2825180653A2E415C39BF41FD682D6
        internal NicIPConfigurationImpl WithNewPublicIPAddress(string leafDnsLabel)
        {
            return WithNewPublicIPAddress(
                PrepareCreatablePublicIP(SdkContext.RandomResourceName("pip", 15), leafDnsLabel));
        }

        
        ///GENMHASH:BE684C4F4845D0C09A9399569DFB7A42:CDAC048B4CBF3DA15B57B59C55815FF9
        internal NicIPConfigurationImpl WithExistingPublicIPAddress(IPublicIPAddress publicIPAddress)
        {
            return WithExistingPublicIPAddress(publicIPAddress.Id);
        }

        
        ///GENMHASH:3C078CA3D79C59C878B566E6BDD55B86:B0EE90118E4A03AFA2010FA1C9E67CB9
        internal NicIPConfigurationImpl WithExistingPublicIPAddress(string resourceId)
        {
            existingPublicIPAddressIdToAssociate = resourceId;
            return this;
        }

        
        ///GENMHASH:C4684C8A47F80967DA864E1AB75147B5:D2568543D2B6FA67EEC6DB9538B32535
        internal NicIPConfigurationImpl WithoutPublicIPAddress()
        {
            removePrimaryPublicIPAssociation = true;
            return this;
        }

        
        ///GENMHASH:0FBBECB150CBC82F165D8BA614AB135A:055A43C17C98D1AD747257B0659283D6
        internal NicIPConfigurationImpl WithSubnet(string name)
        {
            subnetToAssociate = name;
            return this;
        }

        
        ///GENMHASH:D36B69B83A3C752672806F0242C22209:FBE8ED51BA892F18B9FBCE3042C8244C
        internal NicIPConfigurationImpl WithExistingLoadBalancerBackend(ILoadBalancer loadBalancer, string backendName)
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
        internal NicIPConfigurationImpl WithExistingLoadBalancerInboundNatRule(ILoadBalancer loadBalancer, string inboundNatRuleName)
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
            var poolRefs = Inner.LoadBalancerBackendAddressPools;
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

        
        ///GENMHASH:7CC443FD7234FBAB801F3A061377BC25:70718CC85D42345B50C772B8A152E349
        internal static void EnsureConfigurations(List<INicIPConfiguration> nicIPConfigurations)
        {
            foreach (var nicIPConfiguration in nicIPConfigurations)
            {
                NicIPConfigurationImpl config = (NicIPConfigurationImpl)nicIPConfiguration;
                config.Inner.Subnet = config.SubnetToAssociate();
                config.Inner.PublicIPAddress = config.PublicIPToAssociate();
            }
        }

        
        ///GENMHASH:E0B9B91DC16B93A3C858852892F4F123:631C9E4DDFCC0D3FEA55EFC5A50886C4
        private ICreatable<IPublicIPAddress> PrepareCreatablePublicIP(string name, string leafDnsLabel)
        {
            PublicIPAddress.Definition.IWithGroup definitionWithGroup = networkManager.PublicIPAddresses.Define(name)
                .WithRegion(Parent.RegionName);

            PublicIPAddress.Definition.IWithCreate definitionAfterGroup;
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

        ///GENMHASH:D14BFB60D59198612CF4649F7C5412EA:BCFDC718771D33AF794CADC76C0CCD5F
        private SubnetInner SubnetToAssociate()
        {
            SubnetInner subnetInner = new SubnetInner();
            if (isInCreateMode)
            {
                if (creatableVirtualNetworkKey != null)
                {
                    INetwork network = (INetwork)Parent.CreatedDependencyResource(creatableVirtualNetworkKey);
                    subnetInner.Id = network.Inner.Subnets[0].Id;
                    return subnetInner;
                }

                foreach (var subnet in existingVirtualNetworkToAssociate.Inner.Subnets)
                {
                    if (subnet.Name.Equals(subnetToAssociate, StringComparison.OrdinalIgnoreCase))
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
                    subnetInner.Id = Inner.Subnet.Id.Substring(0, idx+1) + subnetToAssociate;
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
        
        ///GENMHASH:B45B91A2577A6C77086C36AFAD21CB6C:0762B331D53D3FF3CD6E97D46248B648
        private SubResource PublicIPToAssociate()
        {
            string pipId = null;
            if (removePrimaryPublicIPAssociation)
            {
                return null;
            }
            else if (creatablePublicIPKey != null)
            {
                pipId = ((IPublicIPAddress)Parent.CreatedDependencyResource(creatablePublicIPKey)).Id;
            }
            else if (existingPublicIPAddressIdToAssociate != null)
            {
                pipId = existingPublicIPAddressIdToAssociate;
            }

            if (pipId != null)
            {
                return new SubResource(pipId);
            }
            else if (!isInCreateMode)
            {
                if (Inner.PublicIPAddress != null)
                {
                    return new SubResource(Inner.PublicIPAddress.Id);
                }
            }
            return null;
        }

        
        ///GENMHASH:DEFD17C7FB8B2DE605F5B8314F21538C:98C9348F48818CBA9BE5411158A7ECB2
        internal NicIPConfigurationImpl WithPrivateIPVersion(IPVersion ipVersion)
        {
            Inner.PrivateIPAddressVersion = ipVersion.ToString();
            return this;
        }

        
        ///GENMHASH:6CB02C98B1D9201E95334813294DA523:DD56D3C148866A86DF7804331EFA54F7
        internal NicIPConfigurationImpl WithoutLoadBalancerBackends()
        {
            Inner.LoadBalancerBackendAddressPools = null;
            return this;
        }

        
        ///GENMHASH:8B463B99540F7AFAB4F1D7B5D595864D:DC3E58307ACC18C04135AB98DDC83680
        internal NicIPConfigurationImpl WithoutLoadBalancerInboundNatRules()
        {
            Inner.LoadBalancerInboundNatRules = null;
            return this;
        }

        NetworkInterface.Update.IUpdate ISettable<NetworkInterface.Update.IUpdate>.Parent()
        {
            return Parent;
        }
    }
}
