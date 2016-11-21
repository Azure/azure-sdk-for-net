///GENMHASH:B6961E0C7CB3A9659DE0E1489F44A936:0B871D5CC01C5634C2C9305DF6429EF2
///Manager()
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uTG9hZEJhbGFuY2VySW1wbA==
namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Collections.Generic;
    using Management.Network.Fluent.Models;
    using LoadBalancer.Update;
    using Resource.Fluent.Core.ResourceActions;
    using Resource.Fluent.Core;
    using Management.Network;
    using System.Threading.Tasks;
    using System.Text;

    /// <summary>
    /// Implementation of the LoadBalancer interface.
    /// </summary>
    public partial class LoadBalancerImpl : GroupableParentResource<
            ILoadBalancer,
            LoadBalancerInner,
            LoadBalancerImpl,
            INetworkManager,
            LoadBalancer.Definition.IWithGroup,
            LoadBalancer.Definition.IWithFrontend,
            LoadBalancer.Definition.IWithCreate,
            IUpdate>,
        ILoadBalancer,
        LoadBalancer.Definition.IDefinition,
        IUpdate
    {
        static string DEFAULT = "default";
        private ILoadBalancersOperations innerCollection;
        private IDictionary<string, string> nicsInBackends = new Dictionary<string, string>();
        private IDictionary<string, string> creatablePIPKeys = new Dictionary<string, string>();

        // Children
        private IDictionary<string, ILoadBalancerBackend> backends;
        private IDictionary<string, ILoadBalancerTcpProbe> tcpProbes;
        private IDictionary<string, ILoadBalancerHttpProbe> httpProbes;
        private IDictionary<string, ILoadBalancingRule> loadBalancingRules;
        private IDictionary<string, ILoadBalancerFrontend> frontends;
        private IDictionary<string, ILoadBalancerInboundNatRule> inboundNatRules;
        private IDictionary<string, ILoadBalancerInboundNatPool> inboundNatPools;

        internal  LoadBalancerImpl (
            string name, 
            LoadBalancerInner innerModel, 
            ILoadBalancersOperations innerCollection, 
            NetworkManager networkManager) : base(name, innerModel, networkManager)
        {
            this.innerCollection = innerCollection;
        }

        ///GENMHASH:4002186478A1CB0B59732EBFB18DEB3A:420B9F8BE887CC0E8BEEE7DBFEAED60C
        override public ILoadBalancer Refresh ()
        {
            var response = this.innerCollection.Get(ResourceGroupName, Name);
            SetInner(response);
            return this;
        }

        ///GENMHASH:6D9F740D6D73C56877B02D9F1C96F6E7:3CAF9C390C7752EBAF91179873ABBC9F
        override protected void InitializeChildrenFromInner ()
        {
            InitializeFrontendsFromInner();
            InitializeProbesFromInner();
            InitializeBackendsFromInner();
            InitializeLoadBalancingRulesFromInner();
            InitializeInboundNatRulesFromInner();
            InitializeInboundNatPoolsFromInner();
        }

        ///GENMHASH:AC21A10EE2E745A89E94E447800452C1:B77F30067A5A83D73E40B1731D81D14A
        override protected void BeforeCreating ()
        {
            // Account for the newly created public IPs
            if (creatablePIPKeys != null)
            {
                foreach (var pipFrontendAssociation in creatablePIPKeys)
                {
                    IPublicIpAddress pip = (IPublicIpAddress)this.CreatedResource(pipFrontendAssociation.Key);
                    if (pip != null)
                    {
                        WithExistingPublicIpAddress(pip.Id, pipFrontendAssociation.Value);
                    }
                }

                creatablePIPKeys.Clear();
            }

            // Reset and update probes
            Inner.Probes = InnersFromWrappers<ProbeInner, ILoadBalancerHttpProbe>(httpProbes.Values);
            Inner.Probes = InnersFromWrappers(tcpProbes.Values, Inner.Probes);

            // Reset and update backends
            Inner.BackendAddressPools = InnersFromWrappers<BackendAddressPoolInner, ILoadBalancerBackend>(backends.Values);

            // Reset and update frontends
            Inner.FrontendIPConfigurations = InnersFromWrappers<FrontendIPConfigurationInner, ILoadBalancerFrontend>(frontends.Values);

            // Reset and update inbound NAT rules
            Inner.InboundNatRules = InnersFromWrappers<InboundNatRuleInner, ILoadBalancerInboundNatRule>(inboundNatRules.Values);
            foreach (var natRule in inboundNatRules.Values) {
                // Clear deleted frontend references
                var frontendRef = natRule.Inner.FrontendIPConfiguration;
                if (frontendRef != null && !this.Frontends().ContainsKey(ResourceUtils.NameFromResourceId(frontendRef.Id)))
                {
                    natRule.Inner.FrontendIPConfiguration = null;
                }
            }

            // Reset and update inbound NAT pools
            Inner.InboundNatPools = InnersFromWrappers<InboundNatPoolInner, ILoadBalancerInboundNatPool>(inboundNatPools.Values);
            foreach (var natPool in inboundNatPools.Values) {
                // Clear deleted frontend references
                var frontendRef = natPool.Inner.FrontendIPConfiguration;
                if (frontendRef != null && !Frontends().ContainsKey(ResourceUtils.NameFromResourceId(frontendRef.Id)))
                {
                    natPool.Inner.FrontendIPConfiguration = null;
                }
            }

            // Reset and update load balancing rules
            Inner.LoadBalancingRules = InnersFromWrappers<LoadBalancingRuleInner, ILoadBalancingRule>(loadBalancingRules.Values);
            foreach (var lbRule in loadBalancingRules.Values) {
                // Clear deleted frontend references
                var frontendRef = lbRule.Inner.FrontendIPConfiguration;
                if (frontendRef != null && !Frontends().ContainsKey(ResourceUtils.NameFromResourceId(frontendRef.Id)))
                {
                    lbRule.Inner.FrontendIPConfiguration = null;
                }

                // Clear deleted backend references
                var backendRef = lbRule.Inner.BackendAddressPool;
                if (backendRef != null && !Backends().ContainsKey(ResourceUtils.NameFromResourceId(backendRef.Id)))
                {
                    lbRule.Inner.BackendAddressPool = null;
                }

                // Clear deleted probe references
                var probeRef = lbRule.Inner.Probe;
                if (probeRef != null 
                    && !HttpProbes().ContainsKey(ResourceUtils.NameFromResourceId(probeRef.Id))
                    && !TcpProbes().ContainsKey(ResourceUtils.NameFromResourceId(probeRef.Id))) {
                    lbRule.Inner.Probe = null;
                }
            }
        }

        ///GENMHASH:F91F57741BB7E185BF012523964DEED0:3651242660180F80ED31BB69FF7A531C
        override protected void AfterCreating ()
        {
            // Update the NICs to point to the backend pool
            if (nicsInBackends != null)
            {
                foreach (var nicInBackend in nicsInBackends)
                {
                    string nicId = nicInBackend.Key;
                    string backendName = nicInBackend.Value;
                    try
                    {
                        var nic = Manager.NetworkInterfaces.GetById(nicId);
                        var nicIp = nic.PrimaryIpConfiguration;
                        nic.Update()
                            .UpdateIpConfiguration(nicIp.Name)
                            .WithExistingLoadBalancerBackend(this, backendName)
                            .Parent()
                        .Apply();
                    }
                    catch
                    {
                        // Skip and continue
                    }
                }

                nicsInBackends.Clear();
                Refresh();
            }
        }

        ///GENMHASH:359B78C1848B4A526D723F29D8C8C558:7501824DEE4570F3E78F9698BA2828B0
        override protected Task<LoadBalancerInner> CreateInner()
        {
            return this.innerCollection.CreateOrUpdateAsync(this.ResourceGroupName, this.Name, this.Inner);
        }

        ///GENMHASH:38719597698E42AABAD5A9917188C155:D9C6887E0B146C62C173F2FC8A940200
        private void InitializeFrontendsFromInner ()
        {
            frontends = new SortedDictionary<string, ILoadBalancerFrontend>();
            IList<FrontendIPConfigurationInner> frontendsInner = this.Inner.FrontendIPConfigurations;
            if (frontendsInner != null)
            {
                foreach (var frontendInner in frontendsInner)
                {
                    var frontend = new LoadBalancerFrontendImpl(frontendInner, this);
                    frontends.Add(frontendInner.Name, frontend);
                }
            }
        }

        ///GENMHASH:38BB8357245354CED812C58E4EC79068:DC3D25D8FDD465052EB41638FB17F9B2
        private void InitializeBackendsFromInner ()
        {
            backends = new SortedDictionary<string, ILoadBalancerBackend>();
            IList<BackendAddressPoolInner> backendsInner = this.Inner.BackendAddressPools;
            if (backendsInner != null)
            {
                foreach (var backendInner in backendsInner)
                {
                    var backend = new LoadBalancerBackendImpl(backendInner, this);
                    backends.Add(backendInner.Name, backend);
                }
            }
        }

        ///GENMHASH:7963C76B84396C00185D8DA2B2F7C665:F1E436F5834A4C1F8A48115529DB0ACD
        private void InitializeLoadBalancingRulesFromInner()
        {
            loadBalancingRules = new SortedDictionary<string, ILoadBalancingRule>();
            IList<LoadBalancingRuleInner> rulesInner = this.Inner.LoadBalancingRules;
            if (rulesInner != null)
            {
                foreach (var ruleInner in rulesInner) {
                    var rule = new LoadBalancingRuleImpl(ruleInner, this);
                    loadBalancingRules.Add(ruleInner.Name, rule);
                }
            }
        }

        ///GENMHASH:12C04D490C1E5A715E97451A0D94F9ED:EF6B6A3CB2DFC605432EDB763513E641
        private void InitializeProbesFromInner ()
        {
            httpProbes = new SortedDictionary<string, ILoadBalancerHttpProbe>();
            tcpProbes = new SortedDictionary<string, ILoadBalancerTcpProbe>();
            if (Inner.Probes != null) {
                foreach (var probeInner in Inner.Probes) {
                    var probe = new LoadBalancerProbeImpl(probeInner, this);
                    if (probeInner.Protocol.Equals(ProbeProtocol.Tcp))
                    {
                        tcpProbes.Add(probeInner.Name, probe);
                    }
                    else if (probeInner.Protocol.Equals(ProbeProtocol.Http))
                    {
                        httpProbes.Add(probeInner.Name, probe);
                    }
                }
            }
        }


        ///GENMHASH:ADBCFE28F7C180796E8BBD413A1F9603:B6E374CF3CE7CCD3A727A0FA7B0194CC
        private void InitializeInboundNatPoolsFromInner ()
        {

            inboundNatPools = new SortedDictionary<string, ILoadBalancerInboundNatPool>();
            if (Inner.InboundNatPools != null) {
                foreach (var inner in Inner.InboundNatPools)
                {
                    var wrapper = new LoadBalancerInboundNatPoolImpl(inner, this);
                    inboundNatPools.Add(inner.Name, wrapper);
                }
            }
        }

        ///GENMHASH:D7F8078784461C05471F1B08FCC5E9D9:A3C76C7153C126B77AA240D3FCFB08EC
        private void InitializeInboundNatRulesFromInner ()
        {
            inboundNatRules = new SortedDictionary<string, ILoadBalancerInboundNatRule>();
            if (Inner.InboundNatRules != null) {
                foreach (var inner in Inner.InboundNatRules) {
                    var rule = new LoadBalancerInboundNatRuleImpl(inner, this);
                    inboundNatRules.Add(inner.Name, rule);
                }
            }
        }

        ///GENMHASH:B9C8411DAA4D113FE18FEEEF1BE8CDB6:4C7FE733A2E6346E63DC67876E17F890
        internal string FutureResourceId()
        {
            return new StringBuilder()
                .Append(base.ResourceIdBase)
                .Append("/providers/Microsoft.Network/loadBalancers/")
                .Append(this.Name)
                .ToString();
        }

        ///GENMHASH:246406B860B0B19EFB0E9B11EC82DA0F:AFEC509255ABE08FC417203DFF8CF829
        internal LoadBalancerImpl WithFrontend (LoadBalancerFrontendImpl frontend)
        {
            if (frontend == null)
                return null;
            else 
            {
                frontends[frontend.Name()] = frontend;
                return this;
            }
        }

        ///GENMHASH:64E42CE15DE3A150EC42DE2481D5E526:CB3A71B025CFA3400615CB6C028C92BB
        internal LoadBalancerImpl WithProbe (LoadBalancerProbeImpl probe)
        {
            if (probe == null)
                return this;
            else if (probe.Protocol().Equals(ProbeProtocol.Http))
            {
                httpProbes[probe.Name()] = probe;
            }
            else if (probe.Protocol().Equals(ProbeProtocol.Tcp))
            {
                tcpProbes[probe.Name()] = probe;
            }
            return this;
        }

        ///GENMHASH:333C1A12C26F7A62DCF62ABD2396653E:86453EFA7B9520152735FB981A0DB7E0
        internal LoadBalancerImpl WithLoadBalancingRule (LoadBalancingRuleImpl loadBalancingRule)
        {
            if (loadBalancingRule == null)
                return null;
            else {
                loadBalancingRules[loadBalancingRule.Name()] = loadBalancingRule;
                return this;
            }
        }

        ///GENMHASH:554A06FC8D7F7A98EA7BBC089864A7E0:811F64EF11CAFFC6E3928C92F87C970A
        internal LoadBalancerImpl WithInboundNatRule (LoadBalancerInboundNatRuleImpl inboundNatRule)
        {
            if (inboundNatRule == null)
                return null;
            else {
                inboundNatRules[inboundNatRule.Name()] = inboundNatRule;
                return this;
            }
        }

        ///GENMHASH:EEDAA901A91D9278E5CB6CC4ECF8561E:15D1B7E0FDC12BCE34A6DF99F6F7DA8B
        internal LoadBalancerImpl WithInboundNatPool (LoadBalancerInboundNatPoolImpl inboundNatPool)
        {
            if (inboundNatPool == null)
                return null;
            else {
                inboundNatPools[inboundNatPool.Name()] = inboundNatPool;
                return this;
            }
        }

        ///GENMHASH:74B04F72B00A53F95B09960843953FAA:B6A0CA4C00D439D0A62611FFBFCB1D01
        internal LoadBalancerImpl WithBackend (LoadBalancerBackendImpl backend)
        {
            if (backend == null)
                return null;
            else {
                backends[backend.Name()] = backend;
                return this;
            }
        }

        ///GENMHASH:9865456A38EDF249959594524980AA77:F11CAC055A6EC52B719989849E641491
        internal LoadBalancerImpl WithNewPublicIpAddress ()
        {
            // Autogenerated DNS leaf label for the PIP
            string dnsLeafLabel = Name.ToLower().Replace(" ", "").Replace("\t", "").Replace("\n", "");
            return WithNewPublicIpAddress(dnsLeafLabel);
        }

        ///GENMHASH:978AA5D6B234EB71E90EC88584153043:71918A84C58B7CADF092181503718A07
        internal LoadBalancerImpl WithNewPublicIpAddress (string dnsLeafLabel)
        {
            var precreatablePIP = Manager.PublicIpAddresses.Define(dnsLeafLabel)
                .WithRegion(Region);
            ICreatable<IPublicIpAddress> creatablePip;
            if (newGroup == null)
            {
                creatablePip = precreatablePIP.WithExistingResourceGroup(ResourceGroupName);
            }
            else
            {
                creatablePip = precreatablePIP.WithNewResourceGroup(newGroup);
            }

            return WithNewPublicIpAddress(creatablePip);
        }

        ///GENMHASH:FE2FB4C2B86589D7D187246933236472:D020A423898DC5D326B0FC06179FDFF6
        internal LoadBalancerImpl WithNewPublicIpAddress (ICreatable<IPublicIpAddress> creatablePIP)
        {
            creatablePIPKeys.Add(creatablePIP.Key, DEFAULT);
            AddCreatableDependency(creatablePIP as IResourceCreator<IResource>);
            return this;
        }

        ///GENMHASH:6FE68F40574F5B84C669001E20CC658F:5F59B9F038073A21E202FA1189301B40
        internal LoadBalancerImpl WithExistingPublicIpAddress (IPublicIpAddress publicIpAddress)
        {
            return WithExistingPublicIpAddress(publicIpAddress.Id, DEFAULT);
        }

        ///GENMHASH:864138CFB5238B5203B5286B54C52AE4:11E731FF72BB432C1D5A698D816EB629
        private LoadBalancerImpl WithExistingPublicIpAddress (string resourceId, string frontendName)
        {
            if (frontendName == null) {
                frontendName = DEFAULT;
            }

            return DefinePublicFrontend(frontendName)
                .WithExistingPublicIpAddress(resourceId)
                .Attach();
        }

        ///GENMHASH:5647899224D30C7B5E1FDCD2D9AAB1DB:E2981ABD5069A930F56B7E822F9B5AD2
        internal LoadBalancerImpl WithExistingSubnet (INetwork network, string subnetName)
        {
            return DefinePrivateFrontend(DEFAULT)
                .WithExistingSubnet(network, subnetName)
                .Attach();
        }

        ///GENMHASH:380B462B2D97E5D84F07F3F7B18F67AF:C52D7AB8B66B03B9F1C3D1A3699B905F
        private LoadBalancerImpl WithExistingVirtualMachine (IHasNetworkInterfaces vm, string backendName)
        {
            if (backendName == null) {
                backendName = DEFAULT;
            }

            DefineBackend(backendName).Attach();

            if (vm.PrimaryNetworkInterfaceId != null) {
                nicsInBackends[vm.PrimaryNetworkInterfaceId] = backendName.ToLower();
            }

            return this;
        }

        ///GENMHASH:DFE9D388863B0ACFAC02ED04C33B6964:030CDA714284493D175D06E0EC0DC0F0
        internal LoadBalancerImpl WithExistingVirtualMachines (params IHasNetworkInterfaces[] vms)
        {
            if (vms != null) {
                foreach (IHasNetworkInterfaces vm in vms) {
                    WithExistingVirtualMachine(vm, null);
                }
            }
            return this;
        }

        ///GENMHASH:681EAD9E22B4456AE914816B5A9E04E5:999E5525EF37760D980CB84E6FED7230
        internal LoadBalancerImpl WithLoadBalancingRule (int frontendPort, string protocol, int backendPort)
        {
            DefineLoadBalancingRule(DEFAULT)
                .WithFrontendPort(frontendPort)
                .WithFrontend(DEFAULT)
                .WithBackendPort(backendPort)
                .WithBackend(DEFAULT)
                .WithProtocol(protocol)
                .WithProbe(DEFAULT)
                .Attach();
            return this;
        }

        ///GENMHASH:A35BE9E6064D3B6774D34DFEA041998E:4BAB91751BCC1B4FF8EBF5F20815D8A8
        internal LoadBalancerImpl WithLoadBalancingRule (int port, string protocol)
        {
            return WithLoadBalancingRule(port, protocol, port);
        }

        ///GENMHASH:DFC0B302155195C00C3D13A6B803B984:A090671271F01103B33881CC6A8FD2B5
        internal LoadBalancerImpl WithTcpProbe (int port)
        {
            return DefineTcpProbe(DEFAULT)
                .WithPort(port)
                .Attach();
        }

        ///GENMHASH:57438CDF8E0AD1C846578BD2FA407389:BBB570164B1B87E87935A91075A29D9F
        internal LoadBalancerImpl WithHttpProbe (string path)
        {
            return DefineHttpProbe(DEFAULT)
                .WithRequestPath(path)
                .WithPort(80)
                .Attach();
        }

        ///GENMHASH:83EB7E99BCC747CE59AF36FB9564E603:F43FF67D037F98DA2675C048997AB3E4
        internal LoadBalancerProbeImpl DefineTcpProbe (string name)
        {
            ILoadBalancerTcpProbe tcpProbe;
            if (!tcpProbes.TryGetValue(name, out tcpProbe))
            {
                ProbeInner inner = new ProbeInner()
                {
                    Name = name,
                    Protocol = ProbeProtocol.Tcp
                };

                return new LoadBalancerProbeImpl(inner, this);
            }
            else
            {
                return (LoadBalancerProbeImpl) tcpProbe;
            }
        }

        ///GENMHASH:10C0BD79848E495E79C3424CBC946E20:FF969980E40890D02E80F73302113402
        internal LoadBalancerProbeImpl DefineHttpProbe (string name)
        {
            ILoadBalancerHttpProbe httpProbe;
            if (!httpProbes.TryGetValue(name, out httpProbe)) {
                ProbeInner inner = new ProbeInner()
                {
                    Name = name,
                    Protocol = ProbeProtocol.Http,
                    Port = 80
                };

                return new LoadBalancerProbeImpl(inner, this);
            } else {
                return (LoadBalancerProbeImpl) httpProbe;
            }
        }

        ///GENMHASH:FE71F2116B051EA0E69747F393350838:381B17D895F64A379B090F1D912B89E6
        internal LoadBalancingRuleImpl DefineLoadBalancingRule (string name)
        {
            ILoadBalancingRule lbRule;
            if (!loadBalancingRules.TryGetValue(name, out lbRule)) {
                LoadBalancingRuleInner inner = new LoadBalancingRuleInner()
                {
                    Name = name
                };

                return new LoadBalancingRuleImpl(inner, this);
            }
            else
            {
                return (LoadBalancingRuleImpl) lbRule;
            }
        }

        ///GENMHASH:6A2AC1CD7146DF56E6C4B83D602BB44B:F4F2535FF206722000C1335B90902873
        internal LoadBalancerInboundNatRuleImpl DefineInboundNatRule (string name)
        {
            ILoadBalancerInboundNatRule natRule;
            if (!inboundNatRules.TryGetValue(name, out natRule))
            {
                InboundNatRuleInner inner = new InboundNatRuleInner()
                {
                    Name = name
                };

                return new LoadBalancerInboundNatRuleImpl(inner, this);
            }
            else
            {
                return (LoadBalancerInboundNatRuleImpl) natRule;
            }
        }

        ///GENMHASH:E255C878339BE0283DF8CD705750D996:4E0599402AB95235FD69889E99B1B4BE
        internal LoadBalancerInboundNatPoolImpl DefineInboundNatPool (string name)
        {
            ILoadBalancerInboundNatPool natPool; 
            if (!inboundNatPools.TryGetValue(name, out natPool))
            {
                InboundNatPoolInner inner = new InboundNatPoolInner()
                {
                    Name = name
                };

                return new LoadBalancerInboundNatPoolImpl(inner, this);
            }
            else
            {
                return (LoadBalancerInboundNatPoolImpl) natPool;
            }
        }

        ///GENMHASH:3D503BA4D8B30DCEC7D11F54DC6A472C:5782B303D9E366A49F3FA833434CFE60
        internal LoadBalancerFrontendImpl DefinePrivateFrontend (string name)
        {
            return DefineFrontend(name);
        }

        ///GENMHASH:7CD5284E5B0D4761F30D51BB0E902F94:5782B303D9E366A49F3FA833434CFE60
        internal LoadBalancerFrontendImpl DefinePublicFrontend (string name)
        {
            return DefineFrontend(name);
        }

        ///GENMHASH:2CAA0883E5A09AD81DE423447D34059F:6E59FBC0A79C2E7A24C0489E77BA5388
        private LoadBalancerFrontendImpl DefineFrontend (string name)
        {
            ILoadBalancerFrontend frontend;
            if (!frontends.TryGetValue(name, out frontend))
            {
                FrontendIPConfigurationInner inner = new FrontendIPConfigurationInner()
                {
                    Name = name
                };

                return new LoadBalancerFrontendImpl(inner, this);
            }
            else
            {
                return (LoadBalancerFrontendImpl) frontend;
            }
        }

        ///GENMHASH:A21060E42B1DFECB63D4D27A101A8941:216CE2EE21AEF8230E16783DACA20570
        internal LoadBalancerBackendImpl DefineBackend (string name)
        {
            ILoadBalancerBackend backend;
            if (!backends.TryGetValue(name, out backend))
            {
                BackendAddressPoolInner inner = new BackendAddressPoolInner()
                {
                    Name = name
                };

                return new LoadBalancerBackendImpl(inner, this);
            }
            else
            {
                return (LoadBalancerBackendImpl) backend;
            }
        }

        ///GENMHASH:65F75FDFA4544CBB0088928EC664A699:45F1C87F10A8330C0D4FC7344A85C99C
        internal LoadBalancerImpl WithoutFrontend (string name)
        {
            frontends.Remove(name);
            return this;
        }

        ///GENMHASH:4AC45533E45499A76EC1612A0EE23033:615DF3D2DB800F69CD9989E6B0004FCB
        internal LoadBalancerImpl WithoutLoadBalancingRule(string name)
        {
            loadBalancingRules.Remove(name);
            return this;
        }

        ///GENMHASH:01FE3EF7AB7F986003E9EEDEFA7C76E6:BAF49A89CE85335BBC4DC913BE5886E9
        internal LoadBalancerImpl WithoutInboundNatRule(string name)
        {
            inboundNatRules.Remove(name);
            return this;
        }

        ///GENMHASH:B63ECBF93DAE93F829555FDE7D92623F:EBC224EB21275F1E7E1DF88A2DAF185F
        internal LoadBalancerImpl WithoutBackend(string name)
        {
            backends.Remove(name);
            return this;
        }

        ///GENMHASH:7208ADA144F2A47AE947A35D969811C8:93A4CB328C3C1964D107DFF10890BBF1
        internal IUpdate WithoutInboundNatPool(string name)
        {
            this.inboundNatPools.Remove(name);
            return this;
        }

        ///GENMHASH:5ECDCD52F7D8B026EB0204682B6DBC78:CD5E24B20805FA56701432EAE0C2AD2F
        internal LoadBalancerImpl WithoutProbe (string name)
        {
            httpProbes.Remove(name);
            tcpProbes.Remove(name);
            return this;
        }

        ///GENMHASH:AC7C85675593DDEC7E88346AF50DCBE2:7F54FABB038BB04070882E6BCDBE2226
        internal LoadBalancerProbeImpl UpdateTcpProbe (string name)
        {
            return TryGetValue<LoadBalancerProbeImpl, ILoadBalancerTcpProbe>(name, tcpProbes);
        }

        ///GENMHASH:77C9DAC5FABBCE9000402FF2D27EA990:F29C0E75E33A5A8904E12A9797829B0A
        internal LoadBalancerBackendImpl UpdateBackend (string name)
        {
            return TryGetValue<LoadBalancerBackendImpl, ILoadBalancerBackend>(name, backends);
        }

        ///GENMHASH:DC06D68BE187D2319D467B4F153BCADA:EE937BC7B114D92CB406766F267EDDE6
        internal LoadBalancerFrontendImpl UpdateInternetFrontend (string name)
        {
            return UpdateFrontend(name);
        }

        ///GENMHASH:B2D72A99C1344D692AC00C2FAC29FF22:EE937BC7B114D92CB406766F267EDDE6
        internal LoadBalancerFrontendImpl UpdateInternalFrontend (string name)
        {
            return UpdateFrontend(name);
        }

        private LoadBalancerFrontendImpl UpdateFrontend (string name)
        {
            return TryGetValue<LoadBalancerFrontendImpl, ILoadBalancerFrontend>(name, frontends);
        }

        private WrapperT TryGetValue<WrapperT, IWrapperT>(string name, IDictionary<string, IWrapperT> dictionary) where WrapperT : IWrapperT
        {
            if (dictionary == null)
            {
                return default(WrapperT);
            }
            else
            {
                IWrapperT wrapper;
                dictionary.TryGetValue(name, out wrapper);
                return (WrapperT) wrapper;
            }
        }

        ///GENMHASH:FF64A88B7DB48446475A5843B0C80C69:2A894F884E7C53F9782BDA764C45693F
        internal LoadBalancerInboundNatRuleImpl UpdateInboundNatRule (string name)
        {
            return TryGetValue<LoadBalancerInboundNatRuleImpl, ILoadBalancerInboundNatRule>(name, inboundNatRules);
        }

        ///GENMHASH:8793B1E32CFB5C74356C07CEB946BF6B:222AF49839A5F8169312A787C78CABCF
        internal LoadBalancerInboundNatPoolImpl UpdateInboundNatPool (string name)
        {
            return TryGetValue<LoadBalancerInboundNatPoolImpl, ILoadBalancerInboundNatPool>(name, inboundNatPools);
        }

        ///GENMHASH:9F586F56E6C7083355E0EAC5CA915017:28A372E1DAA9649031A904BE0FE2EC98
        internal LoadBalancerProbeImpl UpdateHttpProbe (string name)
        {
            return TryGetValue<LoadBalancerProbeImpl, ILoadBalancerHttpProbe>(name, httpProbes);
        }

        ///GENMHASH:F1659EC136C19880BCD775129C7E0971:B68C705837B8D6B33C62F1CCD529C86D
        internal LoadBalancingRuleImpl UpdateLoadBalancingRule (string name)
        {
            return TryGetValue<LoadBalancingRuleImpl, ILoadBalancingRule>(name, loadBalancingRules);
        }

        ///GENMHASH:A45CE73D7318CE351EAF634272B1CA21:AAFEA7A6CB469B72F235861703236767
        internal IDictionary<string, ILoadBalancerBackend> Backends ()
        {
            return backends;
        }

        ///GENMHASH:8A52CACDB59192E1D0B37583E7088612:ABDF5C10B8D024D4FF2F19FCC08D545B
        internal IDictionary<string, ILoadBalancerInboundNatPool> InboundNatPools ()
        {
            return inboundNatPools;
        }

        ///GENMHASH:D2EDA89FB1BC2F4F8DD193121D87D8FA:62FA8A6519E365FE75F168478738E2DF
        internal IDictionary<string, ILoadBalancerTcpProbe> TcpProbes ()
        {
            return tcpProbes;
        }

        ///GENMHASH:3BF87DE2E0C9BBAA60FEF8B345571B0D:78DEDBCE9849DD9B71BA61C7FBEA3261
        internal IDictionary<string, ILoadBalancerFrontend> Frontends ()
        {
            return frontends;
        }

        ///GENMHASH:E8B1A4CD5F6DE0F12BD4A52F19DDADA3:08B702001C3E5904E4105656090C99DB
        internal IDictionary<string, ILoadBalancerInboundNatRule> InboundNatRules ()
        {
            return inboundNatRules;
        }

        ///GENMHASH:24748C01B3C4E2C8AA78FF1218414773:1E910A825FD89730E12401CA3FB434B7
        internal IDictionary<string, ILoadBalancerHttpProbe> HttpProbes ()
        {
            return httpProbes;
        }

        ///GENMHASH:4EDB057B59A7F7BB0C722F8A1399C004:AAA6E6E9080AF0A38342B9778B29320E
        internal IDictionary<string, ILoadBalancingRule> LoadBalancingRules ()
        {
            return loadBalancingRules;
        }

        ///GENMHASH:6352ECA72191EB7B29EABE1E30B18CF4:CF345546D001F32F4850EF402DE6ED22
        internal List<string> PublicIpAddressIds()
        {
            List<string> publicIpAddressIds = new List<string>();
            foreach (ILoadBalancerFrontend frontend in Frontends().Values)
            {
                if (frontend.IsPublic)
                {
                    string pipId = ((ILoadBalancerPublicFrontend)frontend).PublicIpAddressId;
                    publicIpAddressIds.Add(pipId);
                }
            }

            return publicIpAddressIds;
        }
    }
}
