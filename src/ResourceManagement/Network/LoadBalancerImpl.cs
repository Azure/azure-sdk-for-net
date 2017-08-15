// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Collections.Generic;
    using Models;
    using LoadBalancer.Update;
    using ResourceManager.Fluent.Core.ResourceActions;
    using ResourceManager.Fluent.Core;
    using System.Threading.Tasks;
    using System.Text;
    using System;
    using System.Threading;
    using Microsoft.Azure.Management.ResourceManager.Fluent;

    /// <summary>
    /// Implementation of the LoadBalancer interface.
    /// </summary>
    
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uTG9hZEJhbGFuY2VySW1wbA==
    internal partial class LoadBalancerImpl : GroupableParentResource<
            ILoadBalancer,
            LoadBalancerInner,
            LoadBalancerImpl,
            INetworkManager,
            LoadBalancer.Definition.IWithGroup,
            LoadBalancer.Definition.IWithLBRuleOrNat,
            LoadBalancer.Definition.IWithCreate,
            IUpdate>,
        ILoadBalancer,
        LoadBalancer.Definition.IDefinition,
        IUpdate
    {
        private IDictionary<string, string> nicsInBackends = new Dictionary<string, string>();
        private IDictionary<string, string> creatablePIPKeys = new Dictionary<string, string>();

        // Children
        private Dictionary<string, ILoadBalancerBackend> backends;
        private Dictionary<string, ILoadBalancerTcpProbe> tcpProbes;
        private Dictionary<string, ILoadBalancerHttpProbe> httpProbes;
        private Dictionary<string, ILoadBalancingRule> loadBalancingRules;
        private Dictionary<string, ILoadBalancerFrontend> frontends;
        private Dictionary<string, ILoadBalancerInboundNatRule> inboundNatRules;
        private Dictionary<string, ILoadBalancerInboundNatPool> inboundNatPools;

        

        ///GENMHASH:5DE6261BE9537FC28D38F310CA911C9C:3881994DCADCE14215F82F0CC81BDD88
        internal  LoadBalancerImpl (
            string name,
            LoadBalancerInner innerModel,
            INetworkManager networkManager) : base(name, innerModel, networkManager)
        {
        }

        
        ///GENMHASH:5A2D79502EDA81E37A36694062AEDC65:07F76B91153B1FE6C709A470C5523630
        override public async Task<ILoadBalancer> RefreshAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var response = await GetInnerAsync(cancellationToken);
            SetInner(response);
            InitializeChildrenFromInner();
            return this;
        }

        
        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:5EE0BCA571B986920B8777C47D7E1803
        protected override async Task<LoadBalancerInner> GetInnerAsync(CancellationToken cancellationToken)
        {
            return await Manager.Inner.LoadBalancers.GetAsync(ResourceGroupName, Name, cancellationToken: cancellationToken);
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

        
        ///GENMHASH:AC21A10EE2E745A89E94E447800452C1:5EB77CF275BEAA2D6C9B6E198BAA8385
        override protected void BeforeCreating ()
        {
            // Account for the newly created public IPs
            if (creatablePIPKeys != null)
            {
                foreach (var pipFrontendAssociation in creatablePIPKeys)
                {
                    IPublicIPAddress pip = (IPublicIPAddress)CreatedResource(pipFrontendAssociation.Key);
                    if (pip != null)
                    {
                        WithExistingPublicIPAddress(pip.Id, pipFrontendAssociation.Value);
                    }
                }

                creatablePIPKeys.Clear();
            }

            // Reset and update probes
            var innerProbes = InnersFromWrappers<ProbeInner, ILoadBalancerHttpProbe>(httpProbes.Values);
            Inner.Probes = InnersFromWrappers(tcpProbes.Values, innerProbes) ?? new List<ProbeInner>();

            // Reset and update backends
            Inner.BackendAddressPools = InnersFromWrappers<BackendAddressPoolInner, ILoadBalancerBackend>(backends.Values) ?? new List<BackendAddressPoolInner>();

            // Reset and update frontends
            Inner.FrontendIPConfigurations = InnersFromWrappers<FrontendIPConfigurationInner, ILoadBalancerFrontend>(frontends.Values) ?? new List<FrontendIPConfigurationInner>();

            // Reset and update inbound NAT rules
            Inner.InboundNatRules = InnersFromWrappers<InboundNatRuleInner, ILoadBalancerInboundNatRule>(inboundNatRules.Values) ?? new List<InboundNatRuleInner>();
            foreach (var natRule in inboundNatRules.Values) {
                // Clear deleted frontend references
                var frontendRef = natRule.Inner.FrontendIPConfiguration;
                if (frontendRef != null && !Frontends().ContainsKey(ResourceUtils.NameFromResourceId(frontendRef.Id)))
                {
                    natRule.Inner.FrontendIPConfiguration = null;
                }
            }

            // Reset and update inbound NAT pools
            Inner.InboundNatPools = InnersFromWrappers<InboundNatPoolInner, ILoadBalancerInboundNatPool>(inboundNatPools.Values) ?? new List<InboundNatPoolInner>();
            foreach (var natPool in inboundNatPools.Values) {
                // Clear deleted frontend references
                var frontendRef = natPool.Inner.FrontendIPConfiguration;
                if (frontendRef != null && !Frontends().ContainsKey(ResourceUtils.NameFromResourceId(frontendRef.Id)))
                {
                    natPool.Inner.FrontendIPConfiguration = null;
                }
            }

            // Reset and update load balancing rules
            Inner.LoadBalancingRules = InnersFromWrappers<LoadBalancingRuleInner, ILoadBalancingRule>(loadBalancingRules.Values) ?? new List<LoadBalancingRuleInner>();
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

        
        ///GENMHASH:F91F57741BB7E185BF012523964DEED0:155419C0A489C0D4A6C42A2A3A4D483A
        override protected void AfterCreating ()
        {
            // Update the NICs to point to the backend pool
            if (nicsInBackends != null)
            {
                List<Exception> nicExceptions = new List<Exception>();

                // Update the NICs to point to the backend pool
                foreach (var nicInBackend in nicsInBackends)
                {
                    string nicId = nicInBackend.Key;
                    string backendName = nicInBackend.Value;
                    try
                    {
                        var nic = Manager.NetworkInterfaces.GetById(nicId);
                        var nicIP = nic.PrimaryIPConfiguration;
                        nic.Update()
                            .UpdateIPConfiguration(nicIP.Name)
                            .WithExistingLoadBalancerBackend(this, backendName)
                            .Parent()
                        .Apply();
                    }
                    catch (Exception e)
                    {
                        // Aggregate the exceptions
                        nicExceptions.Add(e);
                    }
                }

                if (nicExceptions.Count > 0)
                {
                    throw new AggregateException(nicExceptions);
                }

                nicsInBackends.Clear();
                Refresh();
            }
        }

        
        ///GENMHASH:359B78C1848B4A526D723F29D8C8C558:9E4F8026252C92149A652BE4B5C7D722
        protected async override Task<LoadBalancerInner> CreateInnerAsync(CancellationToken cancellationToken)
        {
            return await Manager.Inner.LoadBalancers.CreateOrUpdateAsync(ResourceGroupName, Name, Inner, cancellationToken);
        }

        
        ///GENMHASH:38719597698E42AABAD5A9917188C155:D9C6887E0B146C62C173F2FC8A940200
        private void InitializeFrontendsFromInner ()
        {
            frontends = new Dictionary<string, ILoadBalancerFrontend>();
            IList<FrontendIPConfigurationInner> frontendsInner = Inner.FrontendIPConfigurations;
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
            backends = new Dictionary<string, ILoadBalancerBackend>();
            IList<BackendAddressPoolInner> backendsInner = Inner.BackendAddressPools;
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
            loadBalancingRules = new Dictionary<string, ILoadBalancingRule>();
            IList<LoadBalancingRuleInner> rulesInner = Inner.LoadBalancingRules;
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
            httpProbes = new Dictionary<string, ILoadBalancerHttpProbe>();
            tcpProbes = new Dictionary<string, ILoadBalancerTcpProbe>();
            if (Inner.Probes != null) {
                foreach (var probeInner in Inner.Probes) {
                    var probe = new LoadBalancerProbeImpl(probeInner, this);
                    if (ProbeProtocol.Tcp.Equals(probeInner.Protocol))
                    {
                        tcpProbes.Add(probeInner.Name, probe);
                    }
                    else if (ProbeProtocol.Http.Equals(probeInner.Protocol))
                    {
                        httpProbes.Add(probeInner.Name, probe);
                    }
                }
            }
        }

        
        ///GENMHASH:ADBCFE28F7C180796E8BBD413A1F9603:B6E374CF3CE7CCD3A727A0FA7B0194CC
        private void InitializeInboundNatPoolsFromInner ()
        {

            inboundNatPools = new Dictionary<string, ILoadBalancerInboundNatPool>();
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
            inboundNatRules = new Dictionary<string, ILoadBalancerInboundNatRule>();
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
                .Append(ResourceIdBase)
                .Append("/providers/Microsoft.Network/loadBalancers/")
                .Append(Name)
                .ToString();
        }

        
        ///GENMHASH:246406B860B0B19EFB0E9B11EC82DA0F:833B17009FF35743D36834ABBB879D14
        internal LoadBalancerImpl WithFrontend (LoadBalancerFrontendImpl frontend)
        {
            if (frontend != null)
            {
                frontends[frontend.Name()] = frontend;
            }
            return this;
        }

        
        ///GENMHASH:64E42CE15DE3A150EC42DE2481D5E526:8896B384A4EC2FA65D253008E5E42E2B
        internal LoadBalancerImpl WithProbe (LoadBalancerProbeImpl probe)
        {
            if (probe == null)
                return this;
            else if (ProbeProtocol.Http.Equals(probe.Protocol()))
            {
                httpProbes[probe.Name()] = probe;
            }
            else if (ProbeProtocol.Tcp.Equals(probe.Protocol()))
            {
                tcpProbes[probe.Name()] = probe;
            }
            return this;
        }

        
        ///GENMHASH:333C1A12C26F7A62DCF62ABD2396653E:88D8263D5E5F61392470C09B0EF1938B
        internal LoadBalancerImpl WithLoadBalancingRule (LoadBalancingRuleImpl loadBalancingRule)
        {
            if (loadBalancingRule != null)
            {
                loadBalancingRules[loadBalancingRule.Name()] = loadBalancingRule;
            }
            return this;
        }

        
        ///GENMHASH:554A06FC8D7F7A98EA7BBC089864A7E0:00D1EA5928DEA90E2505BE70BA76372C
        internal LoadBalancerImpl WithInboundNatRule (LoadBalancerInboundNatRuleImpl inboundNatRule)
        {
            if (inboundNatRule != null)
            {
                inboundNatRules[inboundNatRule.Name()] = inboundNatRule;
            }
            return this;
        }

        
        ///GENMHASH:EEDAA901A91D9278E5CB6CC4ECF8561E:98640888B807006233FAB29F0223B74D
        internal LoadBalancerImpl WithInboundNatPool (LoadBalancerInboundNatPoolImpl inboundNatPool)
        {
            if (inboundNatPool != null)
            {
                inboundNatPools[inboundNatPool.Name()] = inboundNatPool;
            }
            return this;
        }

        
        ///GENMHASH:74B04F72B00A53F95B09960843953FAA:4F027AEBFAC53ECDC5ED96364FD97831
        internal LoadBalancerImpl WithBackend (LoadBalancerBackendImpl backend)
        {
            if (backend != null)
            {
                backends[backend.Name()] = backend;
            }
            return this;
        }

        
        ///GENMHASH:380B462B2D97E5D84F07F3F7B18F67AF:9A9DA0D7B5F5A30A997CC412F2B0BE8B
        internal LoadBalancerImpl WithExistingVirtualMachine(IHasNetworkInterfaces vm, string backendName)
        {
            if (backendName != null)
            {
                DefineBackend(backendName).Attach();
                if (vm.PrimaryNetworkInterfaceId != null)
                {
                    nicsInBackends[vm.PrimaryNetworkInterfaceId] = backendName.ToLower();
                }
            }
            return this;
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
                    Protocol = ProbeProtocol.Tcp.ToString()
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
                    Protocol = ProbeProtocol.Http.ToString(),
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

        
        ///GENMHASH:2CAA0883E5A09AD81DE423447D34059F:D0940B5B5FD34ED81BC375276F675E4B
        private LoadBalancerFrontendImpl DefineFrontend (string name)
        {
            ILoadBalancerFrontend frontend;
            if (!frontends.TryGetValue(name, out frontend))
            {
                // Create if non-existent
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

        
        ///GENMHASH:A21060E42B1DFECB63D4D27A101A8941:1DF3A4D565AC34CCC74741C6C36C9C4B
        internal LoadBalancerBackendImpl DefineBackend (string name)
        {
            ILoadBalancerBackend backend;
            if (!backends.TryGetValue(name, out backend))
            {
                // Create if non-existent
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
        internal IReadOnlyDictionary<string, ILoadBalancerBackend> Backends ()
        {
            return backends;
        }

        
        ///GENMHASH:8A52CACDB59192E1D0B37583E7088612:ABDF5C10B8D024D4FF2F19FCC08D545B
        internal IReadOnlyDictionary<string, ILoadBalancerInboundNatPool> InboundNatPools ()
        {
            return inboundNatPools;
        }

        
        ///GENMHASH:D2EDA89FB1BC2F4F8DD193121D87D8FA:62FA8A6519E365FE75F168478738E2DF
        internal IDictionary<string, ILoadBalancerTcpProbe> TcpProbes ()
        {
            return tcpProbes;
        }

        
        ///GENMHASH:3BF87DE2E0C9BBAA60FEF8B345571B0D:78DEDBCE9849DD9B71BA61C7FBEA3261
        internal IReadOnlyDictionary<string, ILoadBalancerFrontend> Frontends ()
        {
            return frontends;
        }

        
        ///GENMHASH:E8B1A4CD5F6DE0F12BD4A52F19DDADA3:08B702001C3E5904E4105656090C99DB
        internal IReadOnlyDictionary<string, ILoadBalancerInboundNatRule> InboundNatRules ()
        {
            return inboundNatRules;
        }

        
        ///GENMHASH:24748C01B3C4E2C8AA78FF1218414773:1E910A825FD89730E12401CA3FB434B7
        internal IReadOnlyDictionary<string, ILoadBalancerHttpProbe> HttpProbes ()
        {
            return httpProbes;
        }

        
        ///GENMHASH:4EDB057B59A7F7BB0C722F8A1399C004:AAA6E6E9080AF0A38342B9778B29320E
        internal IReadOnlyDictionary<string, ILoadBalancingRule> LoadBalancingRules ()
        {
            return loadBalancingRules;
        }

        
        ///GENMHASH:327A257714E97E0CC9195D07369866F6:4D7D14E19D9E3A3FB56435CFB0209907
        internal IReadOnlyDictionary<string, ILoadBalancerPublicFrontend> PublicFrontends()
        {
            Dictionary<string, ILoadBalancerPublicFrontend> publicFrontends = new Dictionary<string, ILoadBalancerPublicFrontend>();
            foreach (var frontend in Frontends().Values)
            {
                if (frontend.IsPublic)
                {
                    publicFrontends[frontend.Name] = (ILoadBalancerPublicFrontend)frontend;
                }
            }
            return publicFrontends;
        }

        
        ///GENMHASH:49DF224622C157AFD9E284E410CDBB09:11DED4206FF1CBB0CC83F0C2CE7AE6E2
        internal IReadOnlyList<string> PublicIPAddressIds()
        {
            List<string> publicIPAddressIds = new List<string>();
            foreach (ILoadBalancerFrontend frontend in Frontends().Values)
            {
                if (frontend.IsPublic)
                {
                    string pipId = ((ILoadBalancerPublicFrontend)frontend).PublicIPAddressId;
                    publicIPAddressIds.Add(pipId);
                }
            }

            return publicIPAddressIds;
        }


        
        ///GENMHASH:19F616FD24A9FEB061A4AD97B44DD095:345305550E7CF60E8C5F17B68CA0E7FE
        internal ILoadBalancerPrivateFrontend EnsurePrivateFrontendWithSubnet(string networkId, string subnetName)
        {
            var frontend = FindPrivateFrontendWithSubnet(networkId, subnetName);
            if (networkId == null || subnetName == null)
            {
                return null;
            }
            else if (frontend != null)
            {
                return frontend;
            }
            else
            {
                // Create new frontend
                LoadBalancerFrontendImpl fe = this.EnsureUniqueFrontend()
                    .WithExistingSubnet(networkId, subnetName)
                    .WithPrivateIPAddressDynamic();
                    fe.Attach();
                    return fe;
            }
        }

        
        ///GENMHASH:A6CD452F7C969940992AA0D7720B2914:EE937BC7B114D92CB406766F267EDDE6
        internal LoadBalancerFrontendImpl UpdatePublicFrontend(string name)
        {
            return UpdateFrontend(name);
        }

        
        ///GENMHASH:7A47EDC250FB1D65BD3C85FBA997065A:EE937BC7B114D92CB406766F267EDDE6
        internal LoadBalancerFrontendImpl UpdatePrivateFrontend(string name)
        {
            return UpdateFrontend(name);
        }

        
        ///GENMHASH:2B1D79EF0701484A69266710AE199343:AC8E9ABFEAE77AB7D8C62DCAA21B656D
        internal IReadOnlyDictionary<string, ILoadBalancerPrivateFrontend> PrivateFrontends()
        {
            Dictionary<string, ILoadBalancerPrivateFrontend> privateFrontends = new Dictionary<string, ILoadBalancerPrivateFrontend>();
            foreach (var frontend in Frontends().Values)
            {
                if (!frontend.IsPublic)
                {
                    privateFrontends[frontend.Name] = (ILoadBalancerPrivateFrontend)frontend;
                }
            }

            return privateFrontends;
        }

        
        ///GENMHASH:0F90AC639E99A672487C916042DA1057:E5371A50C84CD990F8AB546C8D62DD21
        internal LoadBalancerImpl WithExistingPublicIPAddress(string resourceId, string frontendName)
        {
            if (frontendName == null)
            {
                return EnsureUniqueFrontend()
                    .WithExistingPublicIPAddress(resourceId)
                    .Parent;
            }
            else
            {
                return DefinePublicFrontend(frontendName)
                    .WithExistingPublicIPAddress(resourceId)
                    .Attach();
            }
        }

        
        ///GENMHASH:27A109C0DDBADE2383C4EF4AD6402921:A0B87FE96153C9B2635B99AD88333E3E
        internal ILoadBalancerPrivateFrontend FindPrivateFrontendWithSubnet(string networkId, string subnetName)
        {
            if (null == networkId || null == subnetName)
            {
                return null;
            }

            // Use existing frontend already pointing at this PIP, if any
            foreach (var frontend in PrivateFrontends().Values)
            {
                if (frontend.NetworkId == null || frontend.SubnetName == null)
                {
                    continue;
                }
                else if (networkId.Equals(frontend.NetworkId, StringComparison.CurrentCultureIgnoreCase) && subnetName.Equals(frontend.SubnetName, StringComparison.CurrentCultureIgnoreCase))
                {
                    return frontend;
                }
            }
            return null;
        }

        
        ///GENMHASH:78875D7320F151C84C51611FC09D4CC2:3EAA4712B5C494AD4AB8E1AA820E5A1C
        protected LoadBalancerFrontendImpl EnsureUniqueFrontend()
        {
            string name = SdkContext.RandomResourceName("frontend", 20);
            LoadBalancerFrontendImpl frontend = DefineFrontend(name);
            frontend.Attach();
            return frontend;
        }

        
        ///GENMHASH:DAC7C95BFBE152B599EE795AE6AFEF02:B63A71AAE81F86EEB4A9F4709EF1253D
        internal ILoadBalancerPublicFrontend FindFrontendByPublicIPAddress(IPublicIPAddress publicIPAddress)
        {
            if (publicIPAddress == null)
            {
                return null;
            }
            else
            {
                return FindFrontendByPublicIPAddress(publicIPAddress.Id);
            }
        }

        
        ///GENMHASH:F6E2C642138E5C0CE20400B169E547D5:36649E376630773BA2F2A2C441C790C6
        internal ILoadBalancerPublicFrontend FindFrontendByPublicIPAddress(string pipId)
        {
            if (pipId == null)
            {
                return null;
            }

            // Use existing frontend already pointing at this PIP, if any
            foreach (var frontend in PublicFrontends().Values)
            {
                if (frontend.PublicIPAddressId == null)
                {
                    continue;
                }
                else if (pipId.Equals(frontend.PublicIPAddressId, StringComparison.CurrentCultureIgnoreCase))
                {
                    return frontend;
                }
            }
            return null;
        }

        
        ///GENMHASH:51714851388882936938461B23BE6E15:647F71B404B60D09BE9E1A19A4240853
        internal LoadBalancerBackendImpl EnsureUniqueBackend()
        {
            string name = SdkContext.RandomResourceName("backend", 20);
            LoadBalancerBackendImpl backend = DefineBackend(name);
            backend.Attach();
            return backend;
        }

        
        ///GENMHASH:5368AC7579C6EE249C0AD6A90678BF35:DBC4E47BA426D019C948CDD4FF3805F0
        internal ILoadBalancerPublicFrontend EnsurePublicFrontendWithPip(string pipId)
        {
            var frontend = FindFrontendByPublicIPAddress(pipId);
            if (pipId == null)
            {
                return null;
            }
            else if (frontend != null)
            {
                return frontend;
            }
            else
            {
                // Create new frontend
                LoadBalancerFrontendImpl fe = EnsureUniqueFrontend()
                    .WithExistingPublicIPAddress(pipId);
                fe.Attach();
                return fe;
            }
        }

        
        ///GENMHASH:735F89D9F262D35C21C704F4E6923010:4B39DEE3BEA30CE34F8B69B44F6D8AA6
        internal SubResource EnsureFrontendRef(string name)
        {
            // Ensure existence of frontend, creating one if needed
            LoadBalancerFrontendImpl frontend;
            if (name == null)
            {
                frontend = EnsureUniqueFrontend();
            }
            else
            {
                frontend = DefineFrontend(name);
                frontend.Attach();
            }

            // Return frontend reference
            return new SubResource(id: FutureResourceId() + "/frontendIPConfigurations/" + frontend.Name());
        }

        
        ///GENMHASH:0DD84D78FBDC44F17C987B4E4F0943A1:72AF6C9B67EFB1A3C9DC1BFCEB5C0559
        internal LoadBalancerImpl WithNewPublicIPAddress(ICreatable<IPublicIPAddress> creatablePip, string frontendName)
        {
            string existingPipFrontendName = null;
            creatablePIPKeys.TryGetValue(creatablePip.Key, out existingPipFrontendName);
            if (frontendName == null)
            {
                if (existingPipFrontendName != null)
                {
                    // Reuse frontend already associated with this PIP
                    frontendName = existingPipFrontendName;
                }
                else
                {
                    // Auto-named unique frontend
                    frontendName = EnsureUniqueFrontend().Name();
                }
            }

            if (existingPipFrontendName == null)
            {
                // No frontend associated with this PIP yet so create new association
                creatablePIPKeys[creatablePip.Key] = frontendName;
                AddCreatableDependency(creatablePip as IResourceCreator <IHasId>);
            }
            else if (!existingPipFrontendName.Equals(frontendName, StringComparison.CurrentCultureIgnoreCase))
            {
                // Existing PIP definition already in use but under a different frontend, so error
                throw new ArgumentOutOfRangeException("This public IP address definition is already associated with a frontend under a different name.");
            }

            return this;
        }

        
        ///GENMHASH:E7EE7F252C6DAC731132F0637AF275BB:E6A59D91BAA41B3643CF4769E510F3A6
        internal LoadBalancerImpl WithNewPublicIPAddress(string dnsLeafLabel, string frontendName)
        {
            var precreatablePIP = Manager.PublicIPAddresses.Define(dnsLeafLabel)
                .WithRegion(RegionName);
            ICreatable<IPublicIPAddress> creatablePip;
            if (newGroup == null)
            {
                creatablePip = precreatablePIP.WithExistingResourceGroup(ResourceGroupName).WithLeafDomainLabel(dnsLeafLabel);
            }
            else
            {
                creatablePip = precreatablePIP.WithNewResourceGroup(newGroup).WithLeafDomainLabel(dnsLeafLabel);
            }
            return WithNewPublicIPAddress(creatablePip, frontendName);
        }
    }
}
