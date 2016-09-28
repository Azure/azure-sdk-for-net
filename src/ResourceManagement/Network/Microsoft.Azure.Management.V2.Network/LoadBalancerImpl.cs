// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.V2.Network
{

    using System.Collections.Generic;
    using Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Management.V2.Network.LoadBalancer.Definition;
    using Microsoft.Azure.Management.V2.Network.LoadBalancer.Update;
    using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
    using Microsoft.Azure.Management.V2.Resource.Core;
    using Management.Network;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation of the LoadBalancer interface.
    /// </summary>
    public partial class LoadBalancerImpl : GroupableParentResource<
            ILoadBalancer,
            LoadBalancerInner,
            Rest.Azure.Resource,
            LoadBalancerImpl,
            INetworkManager,
            LoadBalancer.Definition.IWithGroup,
            LoadBalancer.Definition.IWithFrontend,
            LoadBalancer.Definition.IWithCreate,
            LoadBalancer.Update.IUpdate>,
        ILoadBalancer,
        IDefinition,
        IUpdate
    {
        static string DEFAULT;
        private ILoadBalancersOperations innerCollection;
        private IDictionary<string,string> nicsInBackends;
        private IDictionary<string,string> creatablePIPKeys;
        private IDictionary<string,Microsoft.Azure.Management.V2.Network.IBackend> backends;
        private IDictionary<string,Microsoft.Azure.Management.V2.Network.ITcpProbe> tcpProbes;
        private IDictionary<string,Microsoft.Azure.Management.V2.Network.IHttpProbe> httpProbes;
        private IDictionary<string,Microsoft.Azure.Management.V2.Network.ILoadBalancingRule> loadBalancingRules;
        private IDictionary<string,Microsoft.Azure.Management.V2.Network.IFrontend> frontends;
        private IDictionary<string,Microsoft.Azure.Management.V2.Network.IInboundNatRule> inboundNatRules;
        private IDictionary<string,Microsoft.Azure.Management.V2.Network.IInboundNatPool> inboundNatPools;
        internal  LoadBalancerImpl (
            string name, 
            LoadBalancerInner innerModel, 
            ILoadBalancersOperations innerCollection, 
            NetworkManager networkManager) : base(name, innerModel, networkManager)
        {

            //$ final LoadBalancerInner innerModel,
            //$ final LoadBalancersInner innerCollection,
            //$ final NetworkManager networkManager) {
            //$ super(name, innerModel, networkManager);
            //$ this.innerCollection = innerCollection;
            //$ }

        }

        override public ILoadBalancer Refresh ()
        {
            var response = this.innerCollection.Get(this.ResourceGroupName, this.Name);
            SetInner(response);
            return this;
        }

        override protected void InitializeChildrenFromInner ()
        {

            //$ initializeFrontendsFromInner();
            //$ initializeProbesFromInner();
            //$ initializeBackendsFromInner();
            //$ initializeLoadBalancingRulesFromInner();
            //$ initializeInboundNatRulesFromInner();
            //$ initializeInboundNatPoolsFromInner();

        }

        override protected void BeforeCreating ()
        {

            //$ // Account for the newly created public IPs
            //$ for (Entry<String, String> pipFrontendAssociation : this.creatablePIPKeys.entrySet()) {
            //$ PublicIpAddress pip = (PublicIpAddress) this.createdResource(pipFrontendAssociation.getKey());
            //$ if (pip != null) {
            //$ withExistingPublicIpAddress(pip.id(), pipFrontendAssociation.getValue());
            //$ }
            //$ }
            //$ this.creatablePIPKeys.clear();
            //$ 
            //$ // Reset and update probes
            //$ this.inner().withProbes(innersFromWrappers(this.httpProbes.values()));
            //$ this.inner().withProbes(innersFromWrappers(this.tcpProbes.values(), this.inner().probes()));
            //$ 
            //$ // Reset and update backends
            //$ this.inner().withBackendAddressPools(innersFromWrappers(this.backends.values()));
            //$ 
            //$ // Reset and update frontends
            //$ this.inner().withFrontendIPConfigurations(innersFromWrappers(this.frontends.values()));
            //$ 
            //$ // Reset and update inbound NAT rules
            //$ this.inner().withInboundNatRules(innersFromWrappers(this.inboundNatRules.values()));
            //$ for (InboundNatRule natRule : this.inboundNatRules.values()) {
            //$ // Clear deleted frontend references
            //$ SubResource frontendRef = natRule.inner().frontendIPConfiguration();
            //$ if (frontendRef != null
            //$ && !this.frontends().containsKey(ResourceUtils.nameFromResourceId(frontendRef.id()))) {
            //$ natRule.inner().withFrontendIPConfiguration(null);
            //$ }
            //$ }
            //$ 
            //$ // Reset and update inbound NAT pools
            //$ this.inner().withInboundNatPools(innersFromWrappers(this.inboundNatPools.values()));
            //$ for (InboundNatPool natPool : this.inboundNatPools.values()) {
            //$ // Clear deleted frontend references
            //$ SubResource frontendRef = natPool.inner().frontendIPConfiguration();
            //$ if (frontendRef != null
            //$ && !this.frontends().containsKey(ResourceUtils.nameFromResourceId(frontendRef.id()))) {
            //$ natPool.inner().withFrontendIPConfiguration(null);
            //$ }
            //$ }
            //$ 
            //$ // Reset and update load balancing rules
            //$ this.inner().withLoadBalancingRules(innersFromWrappers(this.loadBalancingRules.values()));
            //$ for (LoadBalancingRule lbRule : this.loadBalancingRules.values()) {
            //$ // Clear deleted frontend references
            //$ SubResource frontendRef = lbRule.inner().frontendIPConfiguration();
            //$ if (frontendRef != null
            //$ && !this.frontends().containsKey(ResourceUtils.nameFromResourceId(frontendRef.id()))) {
            //$ lbRule.inner().withFrontendIPConfiguration(null);
            //$ }
            //$ 
            //$ // Clear deleted backend references
            //$ SubResource backendRef = lbRule.inner().backendAddressPool();
            //$ if (backendRef != null
            //$ && !this.backends().containsKey(ResourceUtils.nameFromResourceId(backendRef.id()))) {
            //$ lbRule.inner().withBackendAddressPool(null);
            //$ }
            //$ 
            //$ // Clear deleted probe references
            //$ SubResource probeRef = lbRule.inner().probe();
            //$ if (probeRef != null
            //$ && !this.httpProbes().containsKey(ResourceUtils.nameFromResourceId(probeRef.id()))
            //$ && !this.tcpProbes().containsKey(ResourceUtils.nameFromResourceId(probeRef.id()))) {
            //$ lbRule.inner().withProbe(null);
            //$ }
            //$ }

        }

        override protected void AfterCreating ()
        {

            //$ // Update the NICs to point to the backend pool
            //$ for (Entry<String, String> nicInBackend : this.nicsInBackends.entrySet()) {
            //$ String nicId = nicInBackend.getKey();
            //$ String backendName = nicInBackend.getValue();
            //$ try {
            //$ NetworkInterface nic = this.manager().networkInterfaces().getById(nicId);
            //$ NicIpConfiguration nicIp = nic.primaryIpConfiguration();
            //$ nic.update()
            //$ .updateIpConfiguration(nicIp.name())
            //$ .withExistingLoadBalancerBackend(this, backendName)
            //$ .parent()
            //$ .apply();
            //$ this.nicsInBackends.clear();
            //$ this.refresh();
            //$ } catch (Exception e) {
            //$ e.printStackTrace();
            //$ }
            //$ }

        }

        override protected Task<LoadBalancerInner> CreateInner()
        {
            //$ return this.innerCollection.createOrUpdateAsync(this.resourceGroupName(), this.name(), this.inner());


                return null;
        }
        private void InitializeFrontendsFromInner ()
        {

            //$ this.frontends = new TreeMap<>();
            //$ List<FrontendIPConfigurationInner> frontendsInner = this.inner().frontendIPConfigurations();
            //$ if (frontendsInner != null) {
            //$ for (FrontendIPConfigurationInner frontendInner : frontendsInner) {
            //$ FrontendImpl frontend = new FrontendImpl(frontendInner, this);
            //$ this.frontends.put(frontendInner.name(), frontend);
            //$ }
            //$ }
            //$ }

        }

        private void InitializeBackendsFromInner ()
        {

            //$ this.backends = new TreeMap<>();
            //$ List<BackendAddressPoolInner> backendsInner = this.inner().backendAddressPools();
            //$ if (backendsInner != null) {
            //$ for (BackendAddressPoolInner backendInner : backendsInner) {
            //$ BackendImpl backend = new BackendImpl(backendInner, this);
            //$ this.backends.put(backendInner.name(), backend);
            //$ }
            //$ }
            //$ }

        }

        private void InitializeProbesFromInner ()
        {

            //$ this.httpProbes = new TreeMap<>();
            //$ this.tcpProbes = new TreeMap<>();
            //$ if (this.inner().probes() != null) {
            //$ for (ProbeInner probeInner : this.inner().probes()) {
            //$ ProbeImpl probe = new ProbeImpl(probeInner, this);
            //$ if (probeInner.protocol().equals(ProbeProtocol.TCP)) {
            //$ this.tcpProbes.put(probeInner.name(), probe);
            //$ } else if (probeInner.protocol().equals(ProbeProtocol.HTTP)) {
            //$ this.httpProbes.put(probeInner.name(), probe);
            //$ }
            //$ }
            //$ }
            //$ }

        }

        private void InitializeLoadBalancingRulesFromInner ()
        {

            //$ this.loadBalancingRules = new TreeMap<>();
            //$ List<LoadBalancingRuleInner> rulesInner = this.inner().loadBalancingRules();
            //$ if (rulesInner != null) {
            //$ for (LoadBalancingRuleInner ruleInner : rulesInner) {
            //$ LoadBalancingRuleImpl rule = new LoadBalancingRuleImpl(ruleInner, this);
            //$ this.loadBalancingRules.put(ruleInner.name(), rule);
            //$ }
            //$ }
            //$ }

        }

        private void InitializeInboundNatPoolsFromInner ()
        {

            //$ this.inboundNatPools = new TreeMap<>();
            //$ List<InboundNatPoolInner> inners = this.inner().inboundNatPools();
            //$ if (inners != null) {
            //$ for (InboundNatPoolInner inner : inners) {
            //$ InboundNatPoolImpl wrapper = new InboundNatPoolImpl(inner, this);
            //$ this.inboundNatPools.put(wrapper.name(), wrapper);
            //$ }
            //$ }
            //$ }

        }

        private void InitializeInboundNatRulesFromInner ()
        {

            //$ this.inboundNatRules = new TreeMap<>();
            //$ List<InboundNatRuleInner> rulesInner = this.inner().inboundNatRules();
            //$ if (rulesInner != null) {
            //$ for (InboundNatRuleInner ruleInner : rulesInner) {
            //$ InboundNatRuleImpl rule = new InboundNatRuleImpl(ruleInner, this);
            //$ this.inboundNatRules.put(ruleInner.name(), rule);
            //$ }
            //$ }
            //$ }

        }

        internal NetworkManager Manager
        {
            get
            {
            //$ return this.myManager;
            //$ }


                return null;
            }
        }
        internal string FutureResourceId
        {
            get
            {
            //$ return new StringBuilder()
            //$ .append(super.resourceIdBase())
            //$ .append("/providers/Microsoft.Network/loadBalancers/")
            //$ .append(this.name()).toString();
            //$ }


                return null;
            }
        }
        internal LoadBalancerImpl WithFrontend (FrontendImpl frontend)
        {

            //$ this.frontends.put(frontend.name(), frontend);
            //$ return this;
            //$ }

            return this;
        }

        internal LoadBalancerImpl WithProbe (ProbeImpl probe)
        {

            //$ if (probe.protocol() == ProbeProtocol.HTTP) {
            //$ httpProbes.put(probe.name(), probe);
            //$ } else if (probe.protocol() == ProbeProtocol.TCP) {
            //$ tcpProbes.put(probe.name(), probe);
            //$ }
            //$ return this;
            //$ }

            return this;
        }

        internal LoadBalancerImpl WithLoadBalancingRule (LoadBalancingRuleImpl loadBalancingRule)
        {

            //$ this.loadBalancingRules.put(loadBalancingRule.name(), loadBalancingRule);
            //$ return this;
            //$ }

            return this;
        }

        internal LoadBalancerImpl WithInboundNatRule (InboundNatRuleImpl inboundNatRule)
        {

            //$ this.inboundNatRules.put(inboundNatRule.name(), inboundNatRule);
            //$ return this;
            //$ }

            return this;
        }

        internal LoadBalancerImpl WithInboundNatPool (InboundNatPoolImpl inboundNatPool)
        {

            //$ this.inboundNatPools.put(inboundNatPool.name(), inboundNatPool);
            //$ return this;
            //$ }

            return this;
        }

        internal LoadBalancerImpl WithBackend (BackendImpl backend)
        {

            //$ this.backends.put(backend.name(), backend);
            //$ return this;
            //$ }

            return this;
        }

        public LoadBalancerImpl WithNewPublicIpAddress ()
        {

            //$ // Autogenerated DNS leaf label for the PIP
            //$ String dnsLeafLabel = this.name().toLowerCase().replace("\\s", "");
            //$ return withNewPublicIpAddress(dnsLeafLabel);

            return this;
        }

        public LoadBalancerImpl WithNewPublicIpAddress (string dnsLeafLabel)
        {

            //$ WithGroup precreatablePIP = manager().publicIpAddresses().define(dnsLeafLabel)
            //$ .withRegion(this.regionName());
            //$ Creatable<PublicIpAddress> creatablePip;
            //$ if (super.creatableGroup == null) {
            //$ creatablePip = precreatablePIP.withExistingResourceGroup(this.resourceGroupName());
            //$ } else {
            //$ creatablePip = precreatablePIP.withNewResourceGroup(super.creatableGroup);
            //$ }
            //$ 
            //$ return withNewPublicIpAddress(creatablePip);

            return this;
        }

        public LoadBalancerImpl WithNewPublicIpAddress (ICreatable<Microsoft.Azure.Management.V2.Network.IPublicIpAddress> creatablePIP)
        {

            //$ this.creatablePIPKeys.put(creatablePIP.key(), DEFAULT);
            //$ this.addCreatableDependency(creatablePIP);
            //$ return this;

            return this;
        }

        public LoadBalancerImpl WithExistingPublicIpAddress (IPublicIpAddress publicIpAddress)
        {

            //$ return withExistingPublicIpAddress(publicIpAddress.id(), DEFAULT);

            return this;
        }

        private LoadBalancerImpl WithExistingPublicIpAddress (string resourceId, string frontendName)
        {

            //$ if (frontendName == null) {
            //$ frontendName = DEFAULT;
            //$ }
            //$ 
            //$ return this.definePublicFrontend(frontendName)
            //$ .withExistingPublicIpAddress(resourceId)
            //$ .attach();
            //$ }

            return this;
        }

        public LoadBalancerImpl WithExistingSubnet (INetwork network, string subnetName)
        {

            //$ return this.definePrivateFrontend(DEFAULT)
            //$ .withExistingSubnet(network, subnetName)
            //$ .attach();

            return this;
        }

        private LoadBalancerImpl WithExistingVirtualMachine (IHasNetworkInterfaces vm, string backendName)
        {

            //$ if (backendName == null) {
            //$ backendName = DEFAULT;
            //$ }
            //$ 
            //$ this.defineBackend(backendName).attach();
            //$ if (vm.primaryNetworkInterfaceId() != null) {
            //$ this.nicsInBackends.put(vm.primaryNetworkInterfaceId(), backendName.toLowerCase());
            //$ }
            //$ 
            //$ return this;
            //$ }

            return this;
        }

        public LoadBalancerImpl WithExistingVirtualMachines (params IHasNetworkInterfaces[] vms)
        {

            //$ if (vms != null) {
            //$ for (HasNetworkInterfaces vm : vms) {
            //$ withExistingVirtualMachine(vm, null);
            //$ }
            //$ }
            //$ return this;

            return this;
        }

        public LoadBalancerImpl WithLoadBalancingRule (int frontendPort, string protocol, int backendPort)
        {

            //$ this.defineLoadBalancingRule(DEFAULT)
            //$ .withFrontendPort(frontendPort)
            //$ .withFrontend(DEFAULT)
            //$ .withBackendPort(backendPort)
            //$ .withBackend(DEFAULT)
            //$ .withProtocol(protocol)
            //$ .withProbe(DEFAULT)
            //$ .attach();
            //$ return this;

            return this;
        }

        public LoadBalancerImpl WithLoadBalancingRule (int port, string protocol)
        {

            //$ return withLoadBalancingRule(port, protocol, port);

            return this;
        }

        public LoadBalancerImpl WithTcpProbe (int port)
        {

            //$ return this.defineTcpProbe(DEFAULT)
            //$ .withPort(port)
            //$ .attach();

            return this;
        }

        public LoadBalancerImpl WithHttpProbe (string path)
        {

            //$ return this.defineHttpProbe(DEFAULT)
            //$ .withRequestPath(path)
            //$ .withPort(80)
            //$ .attach();

            return this;
        }

        public ProbeImpl DefineTcpProbe (string name)
        {

            //$ Probe probe = this.tcpProbes.get(name);
            //$ if (probe == null) {
            //$ ProbeInner inner = new ProbeInner()
            //$ .withName(name)
            //$ .withProtocol(ProbeProtocol.TCP);
            //$ return new ProbeImpl(inner, this);
            //$ } else {
            //$ return (ProbeImpl) probe;
            //$ }

            return null;
        }

        public ProbeImpl DefineHttpProbe (string name)
        {

            //$ Probe probe = this.httpProbes.get(name);
            //$ if (probe == null) {
            //$ ProbeInner inner = new ProbeInner()
            //$ .withName(name)
            //$ .withProtocol(ProbeProtocol.HTTP)
            //$ .withPort(80);
            //$ return new ProbeImpl(inner, this);
            //$ } else {
            //$ return (ProbeImpl) probe;
            //$ }

            return null;
        }

        public LoadBalancingRuleImpl DefineLoadBalancingRule (string name)
        {

            //$ LoadBalancingRule lbRule = this.loadBalancingRules.get(name);
            //$ if (lbRule == null) {
            //$ LoadBalancingRuleInner inner = new LoadBalancingRuleInner()
            //$ .withName(name);
            //$ return new LoadBalancingRuleImpl(inner, this);
            //$ } else {
            //$ return (LoadBalancingRuleImpl) lbRule;
            //$ }

            return null;
        }

        public InboundNatRuleImpl DefineInboundNatRule (string name)
        {

            //$ InboundNatRule natRule = this.inboundNatRules.get(name);
            //$ if (natRule == null) {
            //$ InboundNatRuleInner inner = new InboundNatRuleInner()
            //$ .withName(name);
            //$ return new InboundNatRuleImpl(inner, this);
            //$ } else {
            //$ return (InboundNatRuleImpl) natRule;
            //$ }

            return null;
        }

        public InboundNatPoolImpl DefineInboundNatPool (string name)
        {

            //$ InboundNatPool natPool = this.inboundNatPools.get(name);
            //$ if (natPool == null) {
            //$ InboundNatPoolInner inner = new InboundNatPoolInner()
            //$ .withName(name);
            //$ return new InboundNatPoolImpl(inner, this);
            //$ } else {
            //$ return (InboundNatPoolImpl) natPool;
            //$ }

            return null;
        }

        public FrontendImpl DefinePrivateFrontend (string name)
        {

            //$ return defineFrontend(name);

            return null;
        }

        public FrontendImpl DefinePublicFrontend (string name)
        {

            //$ return defineFrontend(name);

            return null;
        }

        private FrontendImpl DefineFrontend (string name)
        {

            //$ Frontend frontend = this.frontends.get(name);
            //$ if (frontend == null) {
            //$ FrontendIPConfigurationInner inner = new FrontendIPConfigurationInner()
            //$ .withName(name);
            //$ return new FrontendImpl(inner, this);
            //$ } else {
            //$ return (FrontendImpl) frontend;
            //$ }
            //$ }

            return null;
        }

        public BackendImpl DefineBackend (string name)
        {

            //$ Backend backend = this.backends.get(name);
            //$ if (backend == null) {
            //$ BackendAddressPoolInner inner = new BackendAddressPoolInner()
            //$ .withName(name);
            //$ return new BackendImpl(inner, this);
            //$ } else {
            //$ return (BackendImpl) backend;
            //$ }

            return null;
        }

        public LoadBalancerImpl WithoutFrontend (string name)
        {

            //$ Frontend frontend = this.frontends.get(name);
            //$ this.frontends.remove(name);
            //$ 
            //$ final String frontendId;
            //$ if (frontend != null) {
            //$ frontendId = frontend.inner().id();
            //$ } else {
            //$ frontendId = null;
            //$ }
            //$ 
            //$ // Remove references from inbound NAT rules
            //$ List<InboundNatRuleInner> natRulesInner = this.inner().inboundNatRules();
            //$ if (natRulesInner != null && frontendId != null) {
            //$ for (InboundNatRuleInner natRuleInner : natRulesInner) {
            //$ final SubResource frontendRef = natRuleInner.frontendIPConfiguration();
            //$ if (frontendRef != null && frontendRef.id().equalsIgnoreCase(frontendId)) {
            //$ natRuleInner.withFrontendIPConfiguration(null);
            //$ }
            //$ }
            //$ }
            //$ 
            //$ return this;

            return this;
        }

        public LoadBalancerImpl WithoutProbe (string name)
        {

            //$ if (this.httpProbes.containsKey(name)) {
            //$ this.httpProbes.remove(name);
            //$ } else if (this.tcpProbes.containsKey(name)) {
            //$ this.tcpProbes.remove(name);
            //$ }
            //$ 
            //$ List<ProbeInner> probes = this.inner().probes();
            //$ if (probes != null) {
            //$ for (int i = 0; i < probes.size(); i++) {
            //$ if (probes.get(i).name().equalsIgnoreCase(name)) {
            //$ probes.remove(i);
            //$ break;
            //$ }
            //$ }
            //$ }
            //$ 
            //$ return this;

            return this;
        }

        public ProbeImpl UpdateTcpProbe (string name)
        {

            //$ return (ProbeImpl) this.tcpProbes.get(name);

            return null;
        }

        public BackendImpl UpdateBackend (string name)
        {

            //$ return (BackendImpl) this.backends.get(name);

            return null;
        }

        public FrontendImpl UpdateInternetFrontend (string name)
        {

            //$ return (FrontendImpl) this.frontends.get(name);

            return null;
        }

        public FrontendImpl UpdateInternalFrontend (string name)
        {

            //$ return (FrontendImpl) this.frontends.get(name);

            return null;
        }

        public InboundNatRuleImpl UpdateInboundNatRule (string name)
        {

            //$ return (InboundNatRuleImpl) this.inboundNatRules.get(name);

            return null;
        }

        public InboundNatPoolImpl UpdateInboundNatPool (string name)
        {

            //$ return (InboundNatPoolImpl) this.inboundNatPools.get(name);

            return null;
        }

        public ProbeImpl UpdateHttpProbe (string name)
        {

            //$ return (ProbeImpl) this.httpProbes.get(name);

            return null;
        }

        public LoadBalancingRuleImpl UpdateLoadBalancingRule (string name)
        {

            //$ return (LoadBalancingRuleImpl) this.loadBalancingRules.get(name);

            return null;
        }

        public LoadBalancerImpl WithoutLoadBalancingRule (string name)
        {

            //$ this.loadBalancingRules.remove(name);
            //$ return this;

            return this;
        }

        public LoadBalancerImpl WithoutInboundNatRule (string name)
        {

            //$ this.inboundNatRules.remove(name);
            //$ return this;

            return this;
        }

        public LoadBalancerImpl WithoutBackend (string name)
        {

            //$ this.backends.remove(name);
            //$ return this;

            return this;
        }

        public IUpdate WithoutInboundNatPool (string name)
        {

            //$ this.inboundNatPools.remove(name);
            //$ return this;

            return null;
        }

        public IDictionary<string,Microsoft.Azure.Management.V2.Network.IBackend> Backends ()
        {

            //$ return Collections.unmodifiableMap(this.backends);

            return null;
        }

        public IDictionary<string,Microsoft.Azure.Management.V2.Network.IInboundNatPool> InboundNatPools ()
        {

            //$ return Collections.unmodifiableMap(this.inboundNatPools);

            return null;
        }

        public IDictionary<string,Microsoft.Azure.Management.V2.Network.ITcpProbe> TcpProbes ()
        {

            //$ return Collections.unmodifiableMap(this.tcpProbes);

            return null;
        }

        public IDictionary<string,Microsoft.Azure.Management.V2.Network.IFrontend> Frontends ()
        {

            //$ return Collections.unmodifiableMap(this.frontends);

            return null;
        }

        public IDictionary<string,Microsoft.Azure.Management.V2.Network.IInboundNatRule> InboundNatRules ()
        {

            //$ return Collections.unmodifiableMap(this.inboundNatRules);

            return null;
        }

        public IDictionary<string,Microsoft.Azure.Management.V2.Network.IHttpProbe> HttpProbes ()
        {

            //$ return Collections.unmodifiableMap(this.httpProbes);

            return null;
        }

        public IDictionary<string,Microsoft.Azure.Management.V2.Network.ILoadBalancingRule> LoadBalancingRules ()
        {

            //$ return Collections.unmodifiableMap(this.loadBalancingRules);

            return null;
        }

        public List<string> PublicIpAddressIds
        {
            get
            {
            //$ List<String> publicIpAddressIds = new ArrayList<>();
            //$ for (Frontend frontend : this.frontends().values()) {
            //$ if (frontend.isPublic()) {
            //$ String pipId = ((PublicFrontend) frontend).publicIpAddressId();
            //$ publicIpAddressIds.add(pipId);
            //$ }
            //$ }
            //$ return Collections.unmodifiableList(publicIpAddressIds);


                return null;
            }
        }
    }
}