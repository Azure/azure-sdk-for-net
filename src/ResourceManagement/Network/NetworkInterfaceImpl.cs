// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent
{

    using NetworkInterface.Update;
    using Models;
    using NetworkInterface.Definition;
    using System.Collections.Generic;
    using ResourceManager.Fluent.Core.ResourceActions;
    using ResourceManager.Fluent;
    using ResourceManager.Fluent.Core;
    using System.Threading.Tasks;
    using System.Threading;
    using System.Linq;

    /// <summary>
    /// Implementation for NetworkInterface and its create and update interfaces.
    /// </summary>

    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uTmV0d29ya0ludGVyZmFjZUltcGw=
    internal partial class NetworkInterfaceImpl :
        GroupableParentResource<INetworkInterface,
                NetworkInterfaceInner,
                NetworkInterfaceImpl,
                INetworkManager,
                IWithGroup,
                IWithPrimaryNetwork,
                IWithCreate,
                IUpdate>,
            INetworkInterface,
            IDefinition,
            IUpdate

    {
        // the name of the network interface.
        private string nicName;
        // references to all ip configuration.
        private IDictionary<string, INicIPConfiguration> nicIPConfigurations;
        // unique key of a creatable network security group to be associated with the network interface.
        private string creatableNetworkSecurityGroupKey;
        // reference to an network security group to be associated with the network interface.
        private INetworkSecurityGroup existingNetworkSecurityGroupToAssociate;
        // cached related resources.
        private INetworkSecurityGroup networkSecurityGroup;
        // used to generate unique name for any dependency resources.
        protected IResourceNamer namer;


        ///GENMHASH:65C397CE75C49F5C8F4B1B9AFD998ED2:1F34FA1F9AACB7FF3B7E1E7C20D33BBA
        internal NetworkInterfaceImpl(string name, NetworkInterfaceInner innerModel, INetworkManager networkManager)
            : base(name, innerModel, networkManager)
        {
            nicName = name;
            namer = SdkContext.CreateResourceNamer(nicName);
            InitializeChildrenFromInner();
        }


        ///GENMHASH:3FAB18211D6DAAAEF5CA426426D16F0C:2C534296A81FFF5FDA417E7C6EF1ED71
        internal NetworkInterfaceImpl WithNewPrimaryNetwork(ICreatable<INetwork> creatable)
        {
            PrimaryIPConfiguration().WithNewNetwork(creatable);
            return this;
        }


        ///GENMHASH:0994141806BE37BB879E10A9CBFBE5DD:F48449FFB80E09E4E70B4A3EE6C4058D
        internal NetworkInterfaceImpl WithNewPrimaryNetwork(string name, string addressSpaceCidr)
        {
            PrimaryIPConfiguration().WithNewNetwork(name, addressSpaceCidr);
            return this;
        }


        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:8D46C597761FD1535A13C483B7750827
        protected override async Task<NetworkInterfaceInner> GetInnerAsync(CancellationToken cancellationToken)
        {
            return await Manager.Inner.NetworkInterfaces.GetAsync(ResourceGroupName, Name, cancellationToken: cancellationToken);
        }


        ///GENMHASH:C8A4DDE66256242DF61087375BF710B0:02EECE9F34AF7E3733A09A941662D988
        internal NetworkInterfaceImpl WithNewPrimaryNetwork(string addressSpaceCidr)
        {
            PrimaryIPConfiguration().WithNewNetwork(addressSpaceCidr);
            return this;
        }


        ///GENMHASH:EE2847D8AC43E9B7C3BFB967F80560D4:877E86309CA874856E0DF89BA733BDC1
        internal NetworkInterfaceImpl WithExistingPrimaryNetwork(INetwork network)
        {
            PrimaryIPConfiguration().WithExistingNetwork(network);
            return this;
        }


        ///GENMHASH:014382FDED5874494781F50E65D3FDE3:9BD9E715610FF4BAB7CDA4E9D03C9AA0
        internal NetworkInterfaceImpl WithNewPrimaryPublicIPAddress(ICreatable<IPublicIPAddress> creatable)
        {
            PrimaryIPConfiguration().WithNewPublicIPAddress(creatable);
            return this;
        }


        ///GENMHASH:493C4B7BDF89C914E95EEE1D0DE7160E:32A2D3F4C9C8F5B0FDF3408F9D1F54DC
        internal NetworkInterfaceImpl WithNewPrimaryPublicIPAddress(string leafDnsLabel)
        {
            PrimaryIPConfiguration().WithNewPublicIPAddress(leafDnsLabel);
            return this;
        }

        /// <summary>
        /// Gets a new IP configuration child resource NicIPConfiguration wrapping NetworkInterfaceIPConfigurationInner.
        /// </summary>
        /// <param name="name">name the name for the new ip configuration</param>
        /// <returns>NicIPConfiguration</returns>

        ///GENMHASH:A51CE48925B788F198FDE3FE4EB5A4C4:D6C23BED8CC0D3D29D563B8BE47B4997
        private NicIPConfigurationImpl PrepareNewNicIPConfiguration(string name)
        {
            NicIPConfigurationImpl nicIPConfiguration = NicIPConfigurationImpl.PrepareNicIPConfiguration(name, this, Manager);
            return nicIPConfiguration;
        }


        ///GENMHASH:3AAE2F1D370F1B47CE756627E937038D:C2E0AC9E2C66569820DF9EE965656894
        internal NetworkInterfaceImpl WithIPConfiguration(NicIPConfigurationImpl nicIPConfiguration)
        {
            nicIPConfigurations[nicIPConfiguration.Name()] = nicIPConfiguration;
            return this;
        }

        ///GENMHASH:1A5C835DC24ABE531CD7B4E1F2C4F391:7BDC77D7459BF06955C66D87C1E7832C
        internal NicIPConfigurationImpl PrimaryIPConfiguration()
        {
            NicIPConfigurationImpl primaryIPConfig = null;
            if (nicIPConfigurations.Count == 0)
            {
                // If no primary IP config found yet, then create one automatically, otherwise the NIC is in a bad state
                primaryIPConfig = PrepareNewNicIPConfiguration("primary");
                primaryIPConfig.Inner.Primary = true;
                WithIPConfiguration(primaryIPConfig);
            }
            else if (nicIPConfigurations.Count == 1)
            {
                // If there is only one IP config, assume it is primary, regardless of the Primary flag
                primaryIPConfig = (NicIPConfigurationImpl)nicIPConfigurations.Values.First();
            }
            else
            {
                // If multiple IP configs, then find the one marked as primary
                foreach(var ipConfig in nicIPConfigurations.Values)
                {
                    if (ipConfig.IsPrimary)
                    {
                        primaryIPConfig = (NicIPConfigurationImpl) ipConfig;
                        break;
                    }
                }
            }

            // Return the found primary IP config, including null, if no primary IP config can be identified
            // in which case the NIC is in a bad state anyway
            return primaryIPConfig;
        }

        ///GENMHASH:D36B69B83A3C752672806F0242C22209:C9F7B6D7FF25E43C6C647B548EFCCBA2
        internal NetworkInterfaceImpl WithExistingLoadBalancerBackend(ILoadBalancer loadBalancer, string backendName)
        {
            PrimaryIPConfiguration().WithExistingLoadBalancerBackend(loadBalancer, backendName);
            return this;
        }


        ///GENMHASH:03CBA85933E5B90121E4F4AE70F457EE:FBA6BB987E8BDDB4C30B12D3DBC9DC01
        internal NetworkInterfaceImpl WithExistingLoadBalancerInboundNatRule(ILoadBalancer loadBalancer, string inboundNatRuleName)
        {
            PrimaryIPConfiguration().WithExistingLoadBalancerInboundNatRule(loadBalancer, inboundNatRuleName);
            return this;
        }


        ///GENMHASH:6CB02C98B1D9201E95334813294DA523:D91EFFACBE4A9DB5EF5B06EDEAA86F71
        internal IUpdate WithoutLoadBalancerBackends()
        {
            ///GENMHASH:8535B0E23E6704558262509B5A55B45D:2F1DC6F810C13419D8F0C1AA31511B29
            foreach (var ipConfig in IPConfigurations().Values)
            {
                UpdateIPConfiguration(ipConfig.Name)
                   .WithoutLoadBalancerBackends();
            }

            return this;
        }


        ///GENMHASH:29B510787D5B3AC2E6EF73E981110D75:BAB1A1A5F2AD368879DFA9DC2F3D6201
        internal NicIPConfigurationImpl DefineSecondaryIPConfiguration(string name)
        {
            return PrepareNewNicIPConfiguration(name);
        }


        ///GENMHASH:8B463B99540F7AFAB4F1D7B5D595864D:21DE182ABDEF8F657EEA1AEFE6F66E7F
        internal IUpdate WithoutLoadBalancerInboundNatRules()
        {
            foreach (var ipConfig in IPConfigurations().Values)
            {
                UpdateIPConfiguration(ipConfig.Name)
                    .WithoutLoadBalancerInboundNatRules();
            }

            return this;
        }



        ///GENMHASH:C4EC6370EB949D529215661725947771:5148D341C610B8C1AB1E282C59DB8FD3
        internal NetworkInterfaceImpl WithNewPrimaryPublicIPAddress()
        {
            PrimaryIPConfiguration().WithNewPublicIPAddress();
            return this;
        }


        ///GENMHASH:91AD2D8A284AC441A66693B1ADA12AA5:F3D6BA6EA22019BE1CFEE55BADDB03FA
        internal NetworkInterfaceImpl WithoutPrimaryPublicIPAddress()
        {
            PrimaryIPConfiguration().WithoutPublicIPAddress();
            return this;
        }


        ///GENMHASH:8FC05031058012246BAA83A815D4D8FB:37FCC8D93CF67DD30C6ADCDA2115A8F2
        internal NetworkInterfaceImpl WithExistingPrimaryPublicIPAddress(IPublicIPAddress publicIPAddress)
        {
            PrimaryIPConfiguration().WithExistingPublicIPAddress(publicIPAddress);
            return this;
        }


        ///GENMHASH:5CAED1973ED6282363B75129CA1E901E:1EDE66003646D3FD6EF82D7DEE3D700C
        internal NetworkInterfaceImpl WithPrimaryPrivateIPAddressDynamic()
        {
            PrimaryIPConfiguration().WithPrivateIPAddressDynamic();
            return this;
        }


        ///GENMHASH:00FB0FFC956EAEC709E255C99D715642:BA835A6F9AA5D00691DB60C87A5B7659
        internal NetworkInterfaceImpl WithPrimaryPrivateIPAddressStatic(string staticPrivateIPAddress)
        {
            PrimaryIPConfiguration().WithPrivateIPAddressStatic(staticPrivateIPAddress);
            return this;
        }


        ///GENMHASH:57034924A790F6746C59AFD837045739:49734EEA751CB09B1B581F6F3AC76156
        internal NetworkInterfaceImpl WithNewNetworkSecurityGroup(ICreatable<INetworkSecurityGroup> creatable)
        {
            if (creatableNetworkSecurityGroupKey == null)
            {
                creatableNetworkSecurityGroupKey = creatable.Key;
                AddCreatableDependency(creatable as IResourceCreator<IHasId>);
            }

            return this;
        }


        ///GENMHASH:9BCDEB79AFC04D55B9BC280847723DFC:7E388FA346F0E33887182060FBAF25FB
        internal NetworkInterfaceImpl WithExistingNetworkSecurityGroup(INetworkSecurityGroup networkSecurityGroup)
        {
            existingNetworkSecurityGroupToAssociate = networkSecurityGroup;
            return this;
        }


        ///GENMHASH:31626FBDA69232B7DD9945ADF14E191A:245758B25F0370039EC9345CF6DFAC4C
        internal NetworkInterfaceImpl WithoutNetworkSecurityGroup()
        {
            Inner.NetworkSecurityGroup = null;
            return this;
        }


        ///GENMHASH:A575CF497D369A49B15095D3A59FC3F0:72F0625BD38CF1B5FE7AAAB355901844
        internal NicIPConfigurationImpl UpdateIPConfiguration(string name)
        {
            return (NicIPConfigurationImpl)nicIPConfigurations[name];
        }


        ///GENMHASH:85887A166AFB54C3F5ACDB7C4E0D09E2:BC7B9CE4DF8F5CF674BD242D689847EB
        internal NetworkInterfaceImpl WithIPForwarding()
        {
            Inner.EnableIPForwarding = true;
            return this;
        }


        ///GENMHASH:B6F8BA13322FBCE7F33110D4DF0063A0:716A100C1E652320029DE104B3F3ACAF
        internal NetworkInterfaceImpl WithoutIPConfiguration(string name)
        {
            nicIPConfigurations.Remove(name);
            return this;
        }


        ///GENMHASH:FD3C9A3D7CA049EF53508FB15A6763C3:2E1455D3F01711104A5EEA9DD0BD0D37
        internal NetworkInterfaceImpl WithoutIPForwarding()
        {
            Inner.EnableIPForwarding = false;
            return this;
        }


        ///GENMHASH:C46E686F6BFED9BDC32DE6EB942E24F4:5DA1232CCC52BF8BBDDDC0D51DE2189A
        internal NetworkInterfaceImpl WithDnsServer(string ipAddress)
        {
            DnsServerIPs.Add(ipAddress);
            return this;
        }


        ///GENMHASH:BE22C0B9325B4C1589049D401C88C656:C95856C142EAC77C74D5B91874006C26
        internal NetworkInterfaceImpl WithoutDnsServer(string ipAddress)
        {
            DnsServerIPs.Remove(ipAddress);
            return this;
        }


        ///GENMHASH:B5D0BEC334A2545AEB57083EF9E7D3D8:9B31C60286E10C0B8E75B7368E1DBDC6
        internal NetworkInterfaceImpl WithAzureDnsServer()
        {
            DnsServerIPs.Clear();
            return this;
        }


        ///GENMHASH:0FBBECB150CBC82F165D8BA614AB135A:DA5D2D52ADDD2EE36CB7782617219FEF
        internal NetworkInterfaceImpl WithSubnet(string name)
        {
            PrimaryIPConfiguration().WithSubnet(name);
            return this;
        }


        ///GENMHASH:FDFBE4AC2A815BC5ED9C61213C2A6070:450E9FE3E20364B98D321B9668124A61
        internal NetworkInterfaceImpl WithInternalDnsNameLabel(string dnsNameLabel)
        {
            Inner.DnsSettings.InternalDnsNameLabel = dnsNameLabel;
            return this;
        }


        ///GENMHASH:3E35FB42190F8D9DBB9DAD636FA3EDE3:687D257893DF69A84BCC9D6FC3EA33D5
        internal string VirtualMachineId()
        {
            return (Inner.VirtualMachine != null) ? Inner.VirtualMachine.Id : null;
        }


        ///GENMHASH:0BD4C4C178DAB2C4BDA6BE54D2B912D5:8574363DCCF2F083DA5ADD2B4079AAAA
        internal bool IsIPForwardingEnabled()
        {
            return (Inner.EnableIPForwarding.HasValue) ? Inner.EnableIPForwarding.Value : false;
        }


        ///GENMHASH:58FE825A07E34384FA845B00D2554839:C3490FB601F6C84962573C9CA536B1DE
        internal string MacAddress()
        {
            return Inner.MacAddress;
        }


        ///GENMHASH:349C4E09DD850CE224A3467EF70DD6FF:A93BB7B6EE2CF70BA8CD229E2D28058E
        internal string InternalDnsNameLabel()
        {
            return (Inner.DnsSettings != null) ? Inner.DnsSettings.InternalDnsNameLabel : null;
        }


        ///GENMHASH:E0135EB00D1A398C77458FC7B4F10581:32E851D3244AD103A5EAB9B002E22D0C
        internal string InternalDomainNameSuffix()
        {
            return (Inner.DnsSettings != null) ? Inner.DnsSettings.InternalDomainNameSuffix : null;
        }


        ///GENMHASH:9647B31AF7C6E31D3F4BB97FF05EB53A:09E7A363E9118CFD8751EA41C3C67496
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


        ///GENMHASH:F024226BEBD3E09E89CF44CD0AC59AE1:E07E902BD7AB49BA796B3A335B6D2AA0
        internal string InternalFqdn()
        {
            return (Inner.DnsSettings != null) ? Inner.DnsSettings.InternalFqdn : null;
        }


        ///GENMHASH:B1AD13DA0902D51846B309BF1324B456:D8A5A5DCA213B9C68C3EE5D7C1AB3B0D
        internal IList<string> DnsServers()
        {
            return DnsServerIPs;
        }


        ///GENMHASH:2332F9479F460CE970138ADD35B5AF72:A253F778BE50B0C776CC63ECDB4E0FC6
        internal string PrimaryPrivateIP()
        {
            return PrimaryIPConfiguration().PrivateIPAddress();
        }


        ///GENMHASH:35898863669BD2284D4018DCF2B2BA41:DC9E7080C8387177436AA447774ACAB9
        internal IPAllocationMethod PrimaryPrivateIPAllocationMethod()
        {
            return PrimaryIPConfiguration().PrivateIPAllocationMethod();
        }

        internal IDictionary<string, INicIPConfiguration> IPConfigurations()
        {
            return nicIPConfigurations;
        }


        ///GENMHASH:A9777D8010E6AF7B603113E49858FE75:0A1C32015C3FE7888D450702542868EA
        internal string NetworkSecurityGroupId()
        {
            return (Inner.NetworkSecurityGroup != null) ? Inner.NetworkSecurityGroup.Id : null;
        }


        ///GENMHASH:2E4015B29759BBD97527EBAE809B083C:3A31AFD1DFD5FF7364435492A5063098
        internal INetworkSecurityGroup GetNetworkSecurityGroup()
        {
            if (networkSecurityGroup == null && NetworkSecurityGroupId() != null)
            {
                string id = NetworkSecurityGroupId();
                networkSecurityGroup = Manager
                    .NetworkSecurityGroups
                    .GetByResourceGroup(ResourceUtils.GroupFromResourceId(id), ResourceUtils.NameFromResourceId(id));
            }
            return networkSecurityGroup;
        }

        /// <returns>the list of DNS server IPs from the DNS settings</returns>

        ///GENMHASH:286FDAB5963B6F7C00ABEDCF6FE545B5:C8A1E211AE92B97C661E3D7541994267
        private IList<string> DnsServerIPs
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


        ///GENMHASH:6D9F740D6D73C56877B02D9F1C96F6E7:5CCB2A8EEB0CC1B9E938900812D6B964
        override protected void InitializeChildrenFromInner()
        {
            nicIPConfigurations = new Dictionary<string, INicIPConfiguration>();
            IList<NetworkInterfaceIPConfigurationInner> inners = Inner.IpConfigurations;
            if (inners != null)
            {
                foreach (NetworkInterfaceIPConfigurationInner inner in inners)
                {
                    NicIPConfigurationImpl nicIPConfiguration = new NicIPConfigurationImpl(inner, this, Manager, false);
                    nicIPConfigurations.Add(nicIPConfiguration.Name(), nicIPConfiguration);
                }
            }
        }


        ///GENMHASH:7F6A7E961EA5A11F2B8013E54123A7D0:9C961E2C320E3354B3C71EF99831C7AB
        private void ClearCachedRelatedResources()
        {
            networkSecurityGroup = null;
        }


        ///GENMHASH:C67758EF2E365B570BC697E1F615237E:D9E5129DA20E099859BE4DEE002923C8
        internal IHasId CreatedDependencyResource(string key)
        {
            return CreatedResource(key);
        }


        ///GENMHASH:30845DAECBF61D7211678C9DC6EC7B14:80D31269AE598B94897682B4DE95A6D1
        internal ICreatable<IResourceGroup> NewGroup()
        {
            return newGroup;
        }


        ///GENMHASH:359B78C1848B4A526D723F29D8C8C558:614D1EE9141244028C6FDB340013FE1D
        protected async override Task<NetworkInterfaceInner> CreateInnerAsync(CancellationToken cancellationToken)
        {
            return await Manager.Inner.NetworkInterfaces.CreateOrUpdateAsync(ResourceGroupName, Name, Inner, cancellationToken);
        }


        ///GENMHASH:F91F57741BB7E185BF012523964DEED0:26BB61AD1C4F8E3F1AD2EA55120B6EE2
        override protected void AfterCreating()
        {
            ClearCachedRelatedResources();
        }


        ///GENMHASH:AC21A10EE2E745A89E94E447800452C1:AE9E4236A459ED3A7B2F266E3CEED6AD
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
                Inner.NetworkSecurityGroup = new SubResource(networkSecurityGroup.Id);
            }

            NicIPConfigurationImpl.EnsureConfigurations(new List<INicIPConfiguration>(nicIPConfigurations.Values));

            // Reset and update IP configs
            Inner.IpConfigurations =
                InnersFromWrappers<NetworkInterfaceIPConfigurationInner, INicIPConfiguration>(nicIPConfigurations.Values);
        }


        ///GENMHASH:4A422DC2657B1BB27BB580555739E1BC:FC7B116552CE8C8D172AF7124F9B7092
        internal void AddToCreatableDependencies(IResourceCreator<IHasId> creatableResource)
        {
            AddCreatableDependency(creatableResource);
        }


        ///GENMHASH:12A96DCD541F4DFA7FEEBD0904E70907:D7A193E70AE82B258FA6BE65249EF8F3
        public NetworkInterfaceImpl WithoutAcceleratedNetworking()
        {
            Inner.EnableAcceleratedNetworking = false;
            return this;
        }


        ///GENMHASH:FC029B56426CB2BA739B4DBD40ECED47:38C266FAF73EE2B36653A8316233F345
        public bool IsAcceleratedNetworkingEnabled()
        {
            return (Inner.EnableAcceleratedNetworking.HasValue) ? Inner.EnableAcceleratedNetworking.Value : false;
        }


        ///GENMHASH:B2C899358BC305CC881C08A436A0A383:7706FC77F478E5D40F3DF81847DF2E8A
        public NetworkInterfaceImpl WithAcceleratedNetworking()
        {
            Inner.EnableAcceleratedNetworking = true;
            return this;
        }
    }
}
