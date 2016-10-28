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

        internal string FutureResourceId()
        {
            return new StringBuilder()
                .Append(base.ResourceIdBase)
                .Append("/providers/Microsoft.Network/loadBalancers/")
                .Append(this.Name)
                .ToString();
        }

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

        internal LoadBalancerImpl WithLoadBalancingRule (LoadBalancingRuleImpl loadBalancingRule)
        {
            if (loadBalancingRule == null)
                return null;
            else {
                loadBalancingRules[loadBalancingRule.Name()] = loadBalancingRule;
                return this;
            }
        }

        internal LoadBalancerImpl WithInboundNatRule (LoadBalancerInboundNatRuleImpl inboundNatRule)
        {
            if (inboundNatRule == null)
                return null;
            else {
                inboundNatRules[inboundNatRule.Name()] = inboundNatRule;
                return this;
            }
        }

        internal LoadBalancerImpl WithInboundNatPool (LoadBalancerInboundNatPoolImpl inboundNatPool)
        {
            if (inboundNatPool == null)
                return null;
            else {
                inboundNatPools[inboundNatPool.Name()] = inboundNatPool;
                return this;
            }
        }

        internal LoadBalancerImpl WithBackend (LoadBalancerBackendImpl backend)
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

        internal LoadBalancerFrontendImpl DefinePrivateFrontend (string name)
        {
            return DefineFrontend(name);
        }

        internal LoadBalancerFrontendImpl DefinePublicFrontend (string name)
        {
            return DefineFrontend(name);
        }

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

        internal LoadBalancerProbeImpl UpdateTcpProbe (string name)
        {
            return TryGetValue<LoadBalancerProbeImpl, ILoadBalancerTcpProbe>(name, tcpProbes);
        }

        internal LoadBalancerBackendImpl UpdateBackend (string name)
        {
            return TryGetValue<LoadBalancerBackendImpl, ILoadBalancerBackend>(name, backends);
        }

        internal LoadBalancerFrontendImpl UpdateInternetFrontend (string name)
        {
            return UpdateFrontend(name);
        }

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

        internal LoadBalancerInboundNatRuleImpl UpdateInboundNatRule (string name)
        {
            return TryGetValue<LoadBalancerInboundNatRuleImpl, ILoadBalancerInboundNatRule>(name, inboundNatRules);
        }

        internal LoadBalancerInboundNatPoolImpl UpdateInboundNatPool (string name)
        {
            return TryGetValue<LoadBalancerInboundNatPoolImpl, ILoadBalancerInboundNatPool>(name, inboundNatPools);
        }

        internal LoadBalancerProbeImpl UpdateHttpProbe (string name)
        {
            return TryGetValue<LoadBalancerProbeImpl, ILoadBalancerHttpProbe>(name, httpProbes);
        }

        internal LoadBalancingRuleImpl UpdateLoadBalancingRule (string name)
        {
            return TryGetValue<LoadBalancingRuleImpl, ILoadBalancingRule>(name, loadBalancingRules);
        }

        internal IDictionary<string, ILoadBalancerBackend> Backends ()
        {
            return backends;
        }

        internal IDictionary<string, ILoadBalancerInboundNatPool> InboundNatPools ()
        {
            return inboundNatPools;
        }

        internal IDictionary<string, ILoadBalancerTcpProbe> TcpProbes ()
        {
            return tcpProbes;
        }

        internal IDictionary<string, ILoadBalancerFrontend> Frontends ()
        {
            return frontends;
        }

        internal IDictionary<string, ILoadBalancerInboundNatRule> InboundNatRules ()
        {
            return inboundNatRules;
        }

        internal IDictionary<string, ILoadBalancerHttpProbe> HttpProbes ()
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