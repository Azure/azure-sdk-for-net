// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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
            Microsoft.Azure.Management.Resource.Fluent.Resource,
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
        private IDictionary<string, IBackend> backends;
        private IDictionary<string, ITcpProbe> tcpProbes;
        private IDictionary<string, IHttpProbe> httpProbes;
        private IDictionary<string, ILoadBalancingRule> loadBalancingRules;
        private IDictionary<string, IFrontend> frontends;
        private IDictionary<string, IInboundNatRule> inboundNatRules;
        private IDictionary<string, IInboundNatPool> inboundNatPools;

        internal  LoadBalancerImpl (
            string name, 
            LoadBalancerInner innerModel, 
            ILoadBalancersOperations innerCollection, 
            NetworkManager networkManager) : base(name, innerModel, networkManager)
        {
            this.innerCollection = innerCollection;
        }

        override public ILoadBalancer Refresh ()
        {
            var response = this.innerCollection.Get(ResourceGroupName, Name);
            SetInner(response);
            return this;
        }

        override protected void InitializeChildrenFromInner ()
        {
            InitializeFrontendsFromInner();
            InitializeProbesFromInner();
            InitializeBackendsFromInner();
            InitializeLoadBalancingRulesFromInner();
            InitializeInboundNatRulesFromInner();
            InitializeInboundNatPoolsFromInner();
        }

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
            Inner.Probes = InnersFromWrappers<ProbeInner, IHttpProbe>(httpProbes.Values);
            Inner.Probes = InnersFromWrappers(tcpProbes.Values, Inner.Probes);

            // Reset and update backends
            Inner.BackendAddressPools = InnersFromWrappers<BackendAddressPoolInner, IBackend>(backends.Values);

            // Reset and update frontends
            Inner.FrontendIPConfigurations = InnersFromWrappers<FrontendIPConfigurationInner, IFrontend>(frontends.Values);

            // Reset and update inbound NAT rules
            Inner.InboundNatRules = InnersFromWrappers<InboundNatRuleInner, IInboundNatRule>(inboundNatRules.Values);
            foreach (var natRule in inboundNatRules.Values) {
                // Clear deleted frontend references
                var frontendRef = natRule.Inner.FrontendIPConfiguration;
                if (frontendRef != null && !this.Frontends().ContainsKey(ResourceUtils.NameFromResourceId(frontendRef.Id)))
                {
                    natRule.Inner.FrontendIPConfiguration = null;
                }
            }

            // Reset and update inbound NAT pools
            Inner.InboundNatPools = InnersFromWrappers<InboundNatPoolInner, IInboundNatPool>(inboundNatPools.Values);
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

        override protected Task<LoadBalancerInner> CreateInner()
        {
            return this.innerCollection.CreateOrUpdateAsync(this.ResourceGroupName, this.Name, this.Inner);
        }

        private void InitializeFrontendsFromInner ()
        {
            frontends = new SortedDictionary<string, IFrontend>();
            IList<FrontendIPConfigurationInner> frontendsInner = this.Inner.FrontendIPConfigurations;
            if (frontendsInner != null)
            {
                foreach (var frontendInner in frontendsInner)
                {
                    var frontend = new FrontendImpl(frontendInner, this);
                    frontends.Add(frontendInner.Name, frontend);
                }
            }
        }

        private void InitializeBackendsFromInner ()
        {
            backends = new SortedDictionary<string, IBackend>();
            IList<BackendAddressPoolInner> backendsInner = this.Inner.BackendAddressPools;
            if (backendsInner != null)
            {
                foreach (var backendInner in backendsInner)
                {
                    var backend = new BackendImpl(backendInner, this);
                    backends.Add(backendInner.Name, backend);
                }
            }
        }

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

        private void InitializeProbesFromInner ()
        {
            httpProbes = new SortedDictionary<string, IHttpProbe>();
            tcpProbes = new SortedDictionary<string, ITcpProbe>();
            if (Inner.Probes != null) {
                foreach (var probeInner in Inner.Probes) {
                    var probe = new ProbeImpl(probeInner, this);
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


        private void InitializeInboundNatPoolsFromInner ()
        {

            inboundNatPools = new SortedDictionary<string, IInboundNatPool>();
            if (Inner.InboundNatPools != null) {
                foreach (var inner in Inner.InboundNatPools)
                {
                    var wrapper = new InboundNatPoolImpl(inner, this);
                    inboundNatPools.Add(inner.Name, wrapper);
                }
            }
        }

        private void InitializeInboundNatRulesFromInner ()
        {
            inboundNatRules = new SortedDictionary<string, IInboundNatRule>();
            if (Inner.InboundNatRules != null) {
                foreach (var inner in Inner.InboundNatRules) {
                    var rule = new InboundNatRuleImpl(inner, this);
                    inboundNatRules.Add(inner.Name, rule);
                }
            }
        }

        internal string FutureResourceId()
        {
            return new StringBuilder()
                .Append(base.ResourceIdBase)
                .Append("/providers/Microsoft.Network/loadBalancers/")
                .Append(this.Name)
                .ToString();
        }

        internal LoadBalancerImpl WithFrontend (FrontendImpl frontend)
        {
            if (frontend == null)
                return null;
            else 
            {
                frontends[frontend.Name()] = frontend;
                return this;
            }
        }

        internal LoadBalancerImpl WithProbe (ProbeImpl probe)
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

        internal LoadBalancerImpl WithLoadBalancingRule (LoadBalancingRuleImpl loadBalancingRule)
        {
            if (loadBalancingRule == null)
                return null;
            else {
                loadBalancingRules[loadBalancingRule.Name()] = loadBalancingRule;
                return this;
            }
        }

        internal LoadBalancerImpl WithInboundNatRule (InboundNatRuleImpl inboundNatRule)
        {
            if (inboundNatRule == null)
                return null;
            else {
                inboundNatRules[inboundNatRule.Name()] = inboundNatRule;
                return this;
            }
        }

        internal LoadBalancerImpl WithInboundNatPool (InboundNatPoolImpl inboundNatPool)
        {
            if (inboundNatPool == null)
                return null;
            else {
                inboundNatPools[inboundNatPool.Name()] = inboundNatPool;
                return this;
            }
        }

        internal LoadBalancerImpl WithBackend (BackendImpl backend)
        {
            if (backend == null)
                return null;
            else {
                backends[backend.Name()] = backend;
                return this;
            }
        }

        internal LoadBalancerImpl WithNewPublicIpAddress ()
        {
            // Autogenerated DNS leaf label for the PIP
            string dnsLeafLabel = Name.ToLower().Replace(" ", "").Replace("\t", "").Replace("\n", "");
            return WithNewPublicIpAddress(dnsLeafLabel);
        }

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

        internal LoadBalancerImpl WithNewPublicIpAddress (ICreatable<IPublicIpAddress> creatablePIP)
        {
            creatablePIPKeys.Add(creatablePIP.Key, DEFAULT);
            AddCreatableDependency(creatablePIP as IResourceCreator<IResource>);
            return this;
        }

        internal LoadBalancerImpl WithExistingPublicIpAddress (IPublicIpAddress publicIpAddress)
        {
            return WithExistingPublicIpAddress(publicIpAddress.Id, DEFAULT);
        }

        private LoadBalancerImpl WithExistingPublicIpAddress (string resourceId, string frontendName)
        {
            if (frontendName == null) {
                frontendName = DEFAULT;
            }

            return DefinePublicFrontend(frontendName)
                .WithExistingPublicIpAddress(resourceId)
                .Attach();
        }

        internal LoadBalancerImpl WithExistingSubnet (INetwork network, string subnetName)
        {
            return DefinePrivateFrontend(DEFAULT)
                .WithExistingSubnet(network, subnetName)
                .Attach();
        }

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

        internal LoadBalancerImpl WithExistingVirtualMachines (params IHasNetworkInterfaces[] vms)
        {
            if (vms != null) {
                foreach (IHasNetworkInterfaces vm in vms) {
                    WithExistingVirtualMachine(vm, null);
                }
            }
            return this;
        }

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

        internal LoadBalancerImpl WithLoadBalancingRule (int port, string protocol)
        {
            return WithLoadBalancingRule(port, protocol, port);
        }

        internal LoadBalancerImpl WithTcpProbe (int port)
        {
            return DefineTcpProbe(DEFAULT)
                .WithPort(port)
                .Attach();
        }

        internal LoadBalancerImpl WithHttpProbe (string path)
        {
            return DefineHttpProbe(DEFAULT)
                .WithRequestPath(path)
                .WithPort(80)
                .Attach();
        }

        internal ProbeImpl DefineTcpProbe (string name)
        {
            ITcpProbe tcpProbe;
            if (!tcpProbes.TryGetValue(name, out tcpProbe))
            {
                ProbeInner inner = new ProbeInner()
                {
                    Name = name,
                    Protocol = ProbeProtocol.Tcp
                };

                return new ProbeImpl(inner, this);
            }
            else
            {
                return (ProbeImpl) tcpProbe;
            }
        }

        internal ProbeImpl DefineHttpProbe (string name)
        {
            IHttpProbe httpProbe;
            if (!httpProbes.TryGetValue(name, out httpProbe)) {
                ProbeInner inner = new ProbeInner()
                {
                    Name = name,
                    Protocol = ProbeProtocol.Http,
                    Port = 80
                };

                return new ProbeImpl(inner, this);
            } else {
                return (ProbeImpl) httpProbe;
            }
        }

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

        internal InboundNatRuleImpl DefineInboundNatRule (string name)
        {
            IInboundNatRule natRule;
            if (!inboundNatRules.TryGetValue(name, out natRule))
            {
                InboundNatRuleInner inner = new InboundNatRuleInner()
                {
                    Name = name
                };

                return new InboundNatRuleImpl(inner, this);
            }
            else
            {
                return (InboundNatRuleImpl) natRule;
            }
        }

        internal InboundNatPoolImpl DefineInboundNatPool (string name)
        {
            IInboundNatPool natPool; 
            if (!inboundNatPools.TryGetValue(name, out natPool))
            {
                InboundNatPoolInner inner = new InboundNatPoolInner()
                {
                    Name = name
                };

                return new InboundNatPoolImpl(inner, this);
            }
            else
            {
                return (InboundNatPoolImpl) natPool;
            }
        }

        internal FrontendImpl DefinePrivateFrontend (string name)
        {
            return DefineFrontend(name);
        }

        internal FrontendImpl DefinePublicFrontend (string name)
        {
            return DefineFrontend(name);
        }

        private FrontendImpl DefineFrontend (string name)
        {
            IFrontend frontend;
            if (!frontends.TryGetValue(name, out frontend))
            {
                FrontendIPConfigurationInner inner = new FrontendIPConfigurationInner()
                {
                    Name = name
                };

                return new FrontendImpl(inner, this);
            }
            else
            {
                return (FrontendImpl) frontend;
            }
        }

        internal BackendImpl DefineBackend (string name)
        {
            IBackend backend;
            if (!backends.TryGetValue(name, out backend))
            {
                BackendAddressPoolInner inner = new BackendAddressPoolInner()
                {
                    Name = name
                };

                return new BackendImpl(inner, this);
            }
            else
            {
                return (BackendImpl) backend;
            }
        }

        internal LoadBalancerImpl WithoutFrontend (string name)
        {
            frontends.Remove(name);
            return this;
        }

        internal LoadBalancerImpl WithoutLoadBalancingRule(string name)
        {
            loadBalancingRules.Remove(name);
            return this;
        }

        internal LoadBalancerImpl WithoutInboundNatRule(string name)
        {
            inboundNatRules.Remove(name);
            return this;
        }

        internal LoadBalancerImpl WithoutBackend(string name)
        {
            backends.Remove(name);
            return this;
        }

        internal IUpdate WithoutInboundNatPool(string name)
        {
            this.inboundNatPools.Remove(name);
            return this;
        }

        internal LoadBalancerImpl WithoutProbe (string name)
        {
            httpProbes.Remove(name);
            tcpProbes.Remove(name);
            return this;
        }

        internal ProbeImpl UpdateTcpProbe (string name)
        {
            return TryGetValue<ProbeImpl, ITcpProbe>(name, tcpProbes);
        }

        internal BackendImpl UpdateBackend (string name)
        {
            return TryGetValue<BackendImpl, IBackend>(name, backends);
        }

        internal FrontendImpl UpdateInternetFrontend (string name)
        {
            return UpdateFrontend(name);
        }

        internal FrontendImpl UpdateInternalFrontend (string name)
        {
            return UpdateFrontend(name);
        }

        private FrontendImpl UpdateFrontend (string name)
        {
            return TryGetValue<FrontendImpl, IFrontend>(name, frontends);
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

        internal InboundNatRuleImpl UpdateInboundNatRule (string name)
        {
            return TryGetValue<InboundNatRuleImpl, IInboundNatRule>(name, inboundNatRules);
        }

        internal InboundNatPoolImpl UpdateInboundNatPool (string name)
        {
            return TryGetValue<InboundNatPoolImpl, IInboundNatPool>(name, inboundNatPools);
        }

        internal ProbeImpl UpdateHttpProbe (string name)
        {
            return TryGetValue<ProbeImpl, IHttpProbe>(name, httpProbes);
        }

        internal LoadBalancingRuleImpl UpdateLoadBalancingRule (string name)
        {
            return TryGetValue<LoadBalancingRuleImpl, ILoadBalancingRule>(name, loadBalancingRules);
        }

        internal IDictionary<string, IBackend> Backends ()
        {
            return backends;
        }

        internal IDictionary<string, IInboundNatPool> InboundNatPools ()
        {
            return inboundNatPools;
        }

        internal IDictionary<string, ITcpProbe> TcpProbes ()
        {
            return tcpProbes;
        }

        internal IDictionary<string, IFrontend> Frontends ()
        {
            return frontends;
        }

        internal IDictionary<string, IInboundNatRule> InboundNatRules ()
        {
            return inboundNatRules;
        }

        internal IDictionary<string, IHttpProbe> HttpProbes ()
        {
            return httpProbes;
        }

        internal IDictionary<string, ILoadBalancingRule> LoadBalancingRules ()
        {
            return loadBalancingRules;
        }

        internal List<string> PublicIpAddressIds()
        {
            List<string> publicIpAddressIds = new List<string>();
            foreach (IFrontend frontend in Frontends().Values)
            {
                if (frontend.IsPublic)
                {
                    string pipId = ((IPublicFrontend)frontend).PublicIpAddressId;
                    publicIpAddressIds.Add(pipId);
                }
            }

            return publicIpAddressIds;
        }
    }
}