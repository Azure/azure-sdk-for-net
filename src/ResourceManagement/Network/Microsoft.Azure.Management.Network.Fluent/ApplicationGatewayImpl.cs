// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Threading.Tasks;
    using Microsoft.Azure;
    using ApplicationGateway.Definition;
    using ApplicationGateway.Update;
    using Models;
    using HasPrivateIpAddress.Definition;
    using HasPublicIpAddress.Definition;
    using HasPublicIpAddress.Update;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.HasSubnet.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.HasSubnet.Update;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using System.Collections.Generic;
    using System.Threading;
    using Resource.Fluent;

    /// <summary>
    /// Implementation of the ApplicationGateway interface.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uQXBwbGljYXRpb25HYXRld2F5SW1wbA==
    internal partial class ApplicationGatewayImpl :
        GroupableParentResource<Microsoft.Azure.Management.Network.Fluent.IApplicationGateway,
            Models.ApplicationGatewayInner,
            Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayImpl,
            INetworkManager,
            ApplicationGateway.Definition.IWithGroup,
            Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithRequestRoutingRule,
            ApplicationGateway.Definition.IWithCreate,
            ApplicationGateway.Update.IUpdate>,
        IApplicationGateway,
        IDefinition,
        IUpdate
    {
        private IDictionary<string, Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayIpConfiguration> ipConfigs;
        private IDictionary<string, Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayFrontend> frontends;
        private IDictionary<string, Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayBackend> backends;
        private IDictionary<string, Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayBackendHttpConfiguration> backendHttpConfigs;
        private IDictionary<string, Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayListener> listeners;
        private IDictionary<string, Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayRequestRoutingRule> rules;
        private IDictionary<string, Microsoft.Azure.Management.Network.Fluent.IApplicationGatewaySslCertificate> sslCerts;
        private string DEFAULT;
        private IApplicationGatewaysOperations innerCollection;
        private ApplicationGatewayFrontendImpl defaultPrivateFrontend;
        private ApplicationGatewayFrontendImpl defaultPublicFrontend;
        private IDictionary<string, string> creatablePipsByFrontend;
        private ICreatable<Microsoft.Azure.Management.Network.Fluent.INetwork> creatableNetwork;
        private ICreatable<Microsoft.Azure.Management.Network.Fluent.IPublicIpAddress> creatablePip;
        ///GENMHASH:335DEBA2C3ED42B7D6D726224668713C:5F7D61C72418DAEB7F935725E2A62AFF
        public ApplicationGatewayListenerImpl DefineListener(string name)
        {
            //$ ApplicationGatewayListener httpListener = this.listeners.Get(name);
            //$ if (httpListener == null) {
            //$ ApplicationGatewayHttpListenerInner inner = new ApplicationGatewayHttpListenerInner()
            //$ .WithName(name);
            //$ return new ApplicationGatewayListenerImpl(inner, this);
            //$ } else {
            //$ return (ApplicationGatewayListenerImpl) httpListener;
            //$ }

            return null;
        }

        ///GENMHASH:3BF87DE2E0C9BBAA60FEF8B345571B0D:78DEDBCE9849DD9B71BA61C7FBEA3261
        public IReadOnlyDictionary<string, Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayFrontend> Frontends()
        {
            //$ return Collections.UnmodifiableMap(this.frontends);

            return null;
        }

        ///GENMHASH:0A25F8D30AF64565545B20B215964E6B:7FF7C66C33A802B8668BFAC46B248EE8
        public ApplicationGatewayImpl WithSize(ApplicationGatewaySkuName skuName)
        {
            //$ int count;
            //$ // Preserve instance count if already set
            //$ if (this.Sku() != null) {
            //$ count = this.Sku().Capacity();
            //$ } else {
            //$ count = 1; // Default instance count
            //$ }
            //$ 
            //$ ApplicationGatewaySku sku = new ApplicationGatewaySku()
            //$ .WithName(skuName)
            //$ .WithCapacity(count);
            //$ this.Inner.WithSku(sku);
            //$ return this;

            return this;
        }

        ///GENMHASH:691BBD1A543FA3E8C9A27D451AEF177E:FC8B3AE517369B64F33F8DC475426F01
        public IReadOnlyDictionary<string, Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayRequestRoutingRule> RequestRoutingRules()
        {
            //$ return Collections.UnmodifiableMap(this.rules);

            return null;
        }

        ///GENMHASH:6409DA3F27E7CD8F90997F2AD668CE00:41A39172A229BE80EACCBF48C5405C39
        public ApplicationGatewayBackendHttpConfigurationImpl DefineBackendHttpConfiguration(string name)
        {
            //$ ApplicationGatewayBackendHttpConfiguration httpConfig = this.backendHttpConfigs.Get(name);
            //$ if (httpConfig == null) {
            //$ ApplicationGatewayBackendHttpSettingsInner inner = new ApplicationGatewayBackendHttpSettingsInner()
            //$ .WithName(name)
            //$ .WithPort(80); // Default port
            //$ return new ApplicationGatewayBackendHttpConfigurationImpl(inner, this);
            //$ } else {
            //$ return (ApplicationGatewayBackendHttpConfigurationImpl) httpConfig;
            //$ }

            return null;
        }

        ///GENMHASH:8535B0E23E6704558262509B5A55B45D:B0B422F1B1E66AA120E54D492AF6FDE5
        public IReadOnlyDictionary<string, Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayIpConfiguration> IpConfigurations()
        {
            //$ return Collections.UnmodifiableMap(this.ipConfigs);

            return null;
        }

        ///GENMHASH:A21060E42B1DFECB63D4D27A101A8941:5B99013747311ACBEED53F35BF26AD98
        public ApplicationGatewayBackendImpl DefineBackend(string name)
        {
            //$ ApplicationGatewayBackend backend = this.backends.Get(name);
            //$ if (backend == null) {
            //$ ApplicationGatewayBackendAddressPoolInner inner = new ApplicationGatewayBackendAddressPoolInner()
            //$ .WithName(name);
            //$ return new ApplicationGatewayBackendImpl(inner, this);
            //$ } else {
            //$ return (ApplicationGatewayBackendImpl) backend;
            //$ }

            return null;
        }

        ///GENMHASH:6FE68F40574F5B84C669001E20CC658F:B03DC94A2FEC619005CBF1692FC52F0D
        public ApplicationGatewayImpl WithExistingPublicIpAddress(IPublicIpAddress publicIpAddress)
        {
            //$ ensureDefaultPublicFrontend().WithExistingPublicIpAddress(publicIpAddress);
            //$ return this;

            return this;
        }

        ///GENMHASH:DD83F863BB3E548AA6773EF2F2FDD700:ABD548EA6D6FF93E5050DE383F0864FE
        public ApplicationGatewayImpl WithExistingPublicIpAddress(string resourceId)
        {
            //$ ensureDefaultPublicFrontend().WithExistingPublicIpAddress(resourceId);
            //$ return this;

            return this;
        }

        ///GENMHASH:1C444C90348D7064AB23705C542DDF18:9AE479D53BC930F7515CB230EE4EB7EF
        public string NetworkId()
        {
            //$ SubResource subnetRef = defaultSubnetRef();
            //$ if (subnetRef == null) {
            //$ return null;
            //$ } else {
            //$ return ResourceUtils.ParentResourceIdFromResourceId(subnetRef.Id());
            //$ }

            return null;
        }

        ///GENMHASH:F792F6C8C594AA68FA7A0FCA92F55B55:43E446F640DC3345BDBD9A3378F2018A
        public ApplicationGatewaySku Sku()
        {
            //$ return this.Inner.Sku();

            return null;
        }

        ///GENMHASH:5D0DD8101FDDEC22F1DD348B5DADC47F:0DDB5F3E565736FD6F95B08EE958E156
        public ApplicationGatewayIpConfigurationImpl DefineDefaultIpConfiguration()
        {
            //$ return ensureDefaultIpConfig();

            return null;
        }

        ///GENMHASH:CC9715A22AECD112176C927FAD1E7A41:878620025FD4DBD54E68E653EC6A401A
        private ApplicationGatewayIpConfigurationImpl EnsureDefaultIpConfig()
        {
            //$ ApplicationGatewayIpConfigurationImpl ipConfig = (ApplicationGatewayIpConfigurationImpl) defaultIpConfiguration();
            //$ if (ipConfig == null) {
            //$ String name = ResourceNamer.RandomResourceName("ipcfg", 11);
            //$ ipConfig = this.DefineIpConfiguration(name);
            //$ ipConfig.Attach();
            //$ }
            //$ return ipConfig;
            //$ }

            return null;
        }

        ///GENMHASH:A0A23179FBDC541925212899C1A48667:2ECFEA1CD411E1F5B44424C5D9DDACA5
        public ApplicationGatewayImpl WithoutBackendIpAddress(string ipAddress)
        {
            //$ foreach(var backend in this.backends.Values())  {
            //$ ApplicationGatewayBackendImpl backendImpl = (ApplicationGatewayBackendImpl) backend;
            //$ backendImpl.WithoutIpAddress(ipAddress);
            //$ }
            //$ return this;

            return this;
        }

        ///GENMHASH:E1FFDF5A7DA768AA3F4DBC943784DF12:60FA949AF41551509BEDF0FF5451A6CB
        public IReadOnlyDictionary<string, Microsoft.Azure.Management.Network.Fluent.IApplicationGatewaySslCertificate> SslCertificates()
        {
            //$ return Collections.UnmodifiableMap(this.sslCerts);

            return null;
        }

        ///GENMHASH:378C5280A44231F5593B789FF6A1BF16:24E45B50AE0887B03C04922FC3F414DC
        private ICreatable<Microsoft.Azure.Management.Network.Fluent.INetwork> EnsureDefaultNetworkDefinition()
        {
            //$ if (this.creatableNetwork == null) {
            //$ String vnetName = ResourceNamer.RandomResourceName("vnet", 10);
            //$ this.creatableNetwork = this.Manager().Networks().Define(vnetName)
            //$ .WithRegion(this.Region())
            //$ .WithExistingResourceGroup(this.ResourceGroupName())
            //$ .WithAddressSpace("10.0.0.0/24")
            //$ .WithSubnet(DEFAULT, "10.0.0.0/25")
            //$ .WithSubnet("apps", "10.0.0.128/25");
            //$ }
            //$ 
            //$ return this.creatableNetwork;
            //$ }

            return null;
        }

        ///GENMHASH:A45CE73D7318CE351EAF634272B1CA21:AAFEA7A6CB469B72F235861703236767
        public IReadOnlyDictionary<string, Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayBackend> Backends()
        {
            //$ return Collections.UnmodifiableMap(this.backends);

            return null;
        }

        ///GENMHASH:F0126379A1F65359204BD22C7CF55E7C:BE15CAD584433DEAF8B46C62642E8728
        public IReadOnlyDictionary<string, int> FrontendPorts()
        {
            //$ Map<String, Integer> ports = new TreeMap<>();
            //$ if (this.Inner.FrontendPorts() != null) {
            //$ foreach(var portInner in this.Inner.FrontendPorts())  {
            //$ ports.Put(portInner.Name(), portInner.Port());
            //$ }
            //$ }
            //$ return Collections.UnmodifiableMap(ports);

            return null;
        }

        ///GENMHASH:8AA9D9D4B919CCB8947405FAA41035E2:6566E7A57F604BD33E81174C58827CA7
        public string PrivateIpAddress()
        {
            //$ ApplicationGatewayFrontend frontend = defaultPrivateFrontend();
            //$ if (frontend == null) {
            //$ return null;
            //$ } else {
            //$ return frontend.PrivateIpAddress();
            //$ }

            return null;
        }

        ///GENMHASH:FD3BFA79E44BF0C0FD92A0CE7B31B143:4D125EAA0586FE83630989875156AFFD
        internal ApplicationGatewayImpl WithHttpListener(ApplicationGatewayListenerImpl httpListener)
        {
            //$ if (httpListener == null) {
            //$ return null;
            //$ } else {
            //$ this.listeners.Put(httpListener.Name(), httpListener);
            //$ return this;
            //$ }
            //$ }

            return this;
        }

        ///GENMHASH:9EE982E7421C1A20C7BB22556011B5DC:6EF4C8270DB03AC45C57FAD9087BD439
        internal ApplicationGatewayImpl WithRequestRoutingRule(ApplicationGatewayRequestRoutingRuleImpl rule)
        {
            //$ if (rule == null) {
            //$ return null;
            //$ } else {
            //$ this.rules.Put(rule.Name(), rule);
            //$ return this;
            //$ }
            //$ }

            return this;
        }

        ///GENMHASH:D10DEC59828FEAE61D059EA56D310BFE:AB6C127A63CD705630463C82659E7115
        private void InitializeConfigsFromInner()
        {
            //$ this.ipConfigs = new TreeMap<>();
            //$ List<ApplicationGatewayIPConfigurationInner> inners = this.Inner.GatewayIPConfigurations();
            //$ if (inners != null) {
            //$ foreach(var inner in inners)  {
            //$ ApplicationGatewayIpConfigurationImpl config = new ApplicationGatewayIpConfigurationImpl(inner, this);
            //$ this.ipConfigs.Put(inner.Name(), config);
            //$ }
            //$ }
            //$ }

        }

        ///GENMHASH:9407377DFC5566D93476B1B7D2246504:B92120874A64FEDF5BAA29C6F88C6CAD
        public ApplicationGatewayFrontendImpl UpdateFrontend(string frontendName)
        {
            //$ return (ApplicationGatewayFrontendImpl) this.frontends.Get(frontendName);

            return null;
        }

        ///GENMHASH:C19382933BDE655D0F0F95CD9474DFE7:FEE32912F8CE067CB20B5A239BD484D3
        public ApplicationGatewaySkuName Size()
        {
            //$ if (this.Sku() != null && this.Sku().Name() != null) {
            //$ return this.Sku().Name();
            //$ } else {
            //$ return ApplicationGatewaySkuName.STANDARD_SMALL;
            //$ }

            return null;
        }

        ///GENMHASH:709E56A3C42D339048D2196CAAA5ED3F:D1F930D6EF465080D5C775FDA7AD0C5D
        private void InitializeHttpListenersFromInner()
        {
            //$ this.listeners = new TreeMap<>();
            //$ List<ApplicationGatewayHttpListenerInner> inners = this.Inner.HttpListeners();
            //$ if (inners != null) {
            //$ foreach(var inner in inners)  {
            //$ ApplicationGatewayListenerImpl httpListener = new ApplicationGatewayListenerImpl(inner, this);
            //$ this.listeners.Put(inner.Name(), httpListener);
            //$ }
            //$ }
            //$ }

        }

        ///GENMHASH:A81618A68C4004FA1972411DF3C316A8:5AE9871F13F11A8541911E75B3398DEF
        public ApplicationGatewayImpl WithoutPublicFrontend()
        {
            //$ // Ensure no frontend is public
            //$ foreach(var frontend in this.frontends.Values())  {
            //$ frontend.Inner.WithPublicIPAddress(null);
            //$ }
            //$ this.defaultPublicFrontend = null;
            //$ return this;

            return this;
        }

        ///GENMHASH:56D5F87F4F5A3E1857D2D243C076EE30:59E2C0788337FAEAF9283E6BBEF1463E
        public ApplicationGatewayOperationalState OperationalState()
        {
            //$ return this.Inner.OperationalState();

            return null;
        }

        ///GENMHASH:B63ECBF93DAE93F829555FDE7D92623F:42006D4B61D56FE465F7DF0F31BA69B1
        public ApplicationGatewayImpl WithoutBackend(string backendName)
        {
            //$ this.backends.Remove(backendName);
            //$ return this;

            return this;
        }

        ///GENMHASH:90B03712BB750F79C07AC1E18C347CD2:C2BD141C1F4FD24259AF9553C95455F4
        public ApplicationGatewayFrontendImpl UpdatePublicFrontend()
        {
            //$ return (ApplicationGatewayFrontendImpl) defaultPublicFrontend();

            return null;
        }

        ///GENMHASH:6A7F875381DF37D9F784810F1A3E35BE:E241825902218A85919F43AD19902242
        public bool IsPrivate()
        {
            //$ foreach(var frontend in this.frontends.Values())  {
            //$ if (!frontend.IsPublic()) {
            //$ return true;
            //$ }
            //$ }
            //$ return false;

            return false;
        }

        ///GENMHASH:B9C8411DAA4D113FE18FEEEF1BE8CDB6:EBBE4DB86B4401A7F0C2E50102BABB4B
        internal string FutureResourceId()
        {
            //$ return new StringBuilder()
            //$ .Append(super.ResourceIdBase())
            //$ .Append("/providers/Microsoft.Network/applicationGateways/")
            //$ .Append(this.Name()).ToString();
            //$ }

            return null;
        }

        ///GENMHASH:0F667C94F2289EF36EC5F8C809B0D66D:306E4286FAAC968E4A4EDC3FC553DD22
        internal ApplicationGatewayFrontendImpl EnsureDefaultPrivateFrontend()
        {
            //$ ApplicationGatewayFrontendImpl frontend = (ApplicationGatewayFrontendImpl) defaultPrivateFrontend();
            //$ if (frontend != null) {
            //$ return frontend;
            //$ } else {
            //$ String name = ResourceNamer.RandomResourceName("frontend", 14);
            //$ frontend = (ApplicationGatewayFrontendImpl) this.DefineFrontend(name);
            //$ frontend.Attach();
            //$ this.defaultPrivateFrontend = frontend;
            //$ return frontend;
            //$ }
            //$ }

            return null;
        }

        ///GENMHASH:37B3BFB70B7A5569F82FB660A259D248:B96C331B6626B3CE74B216B7FE183B6D
        public IApplicationGatewayFrontend DefaultPublicFrontend()
        {
            //$ // Default means the only public one or the one tracked as default, if more than one public present
            //$ if (this.PublicFrontends().Size() == 1) {
            //$ this.defaultPublicFrontend = (ApplicationGatewayFrontendImpl) this.PublicFrontends().Values().Iterator().Next();
            //$ } else if (this.frontends().Size() == 0) {
            //$ this.defaultPublicFrontend = null;
            //$ }
            //$ 
            //$ return this.defaultPublicFrontend;

            return null;
        }

        ///GENMHASH:1F12F15BC25B4A670CBA526BA2A27CC0:CC90A63D0E46102BDCA3DC06F4351E69
        private void InitializeSslCertificatesFromInner()
        {
            //$ this.sslCerts = new TreeMap<>();
            //$ List<ApplicationGatewaySslCertificateInner> inners = this.Inner.SslCertificates();
            //$ if (inners != null) {
            //$ foreach(var inner in inners)  {
            //$ ApplicationGatewaySslCertificateImpl cert = new ApplicationGatewaySslCertificateImpl(inner, this);
            //$ this.sslCerts.Put(inner.Name(), cert);
            //$ }
            //$ }
            //$ }

        }

        ///GENMHASH:E348AD1CD59015734202262D2BA6F046:55E548B15E635A8197D52049D3FAB8D3
        internal ApplicationGatewayImpl(string name, ApplicationGatewayInner innerModel, IApplicationGatewaysOperations innerCollection, INetworkManager networkManager) : base(name, innerModel, networkManager)
        {
            //$ {
            //$ super(name, innerModel, networkManager);
            //$ this.innerCollection = innerCollection;
            //$ }

        }

        ///GENMHASH:77914F0D4FB485205682C4181EFAACC8:875B0523271DDA40BF052DD20E89DCA7
        public IReadOnlyDictionary<string, Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayListener> Listeners()
        {
            //$ return Collections.UnmodifiableMap(this.listeners);

            return null;
        }

        ///GENMHASH:AA53287F5186B0525C5149BB8A3CC41C:783C00636BC9E9FE9A9092254C16B672
        internal ApplicationGatewayImpl WithSslCertificate(ApplicationGatewaySslCertificateImpl cert)
        {
            //$ if (cert == null) {
            //$ return null;
            //$ } else {
            //$ this.sslCerts.Put(cert.Name(), cert);
            //$ return this;
            //$ }
            //$ }

            return this;
        }

        ///GENMHASH:F91F57741BB7E185BF012523964DEED0:27E486AB74A10242FF421C0798DDC450
        protected override void AfterCreating()
        {
            //$ 

        }

        ///GENMHASH:4002186478A1CB0B59732EBFB18DEB3A:96A74C51AAF39DA86E198A67D990E237
        public override IApplicationGateway Refresh()
        {
            //$ ApplicationGatewayInner inner = this.innerCollection.Get(this.ResourceGroupName(), this.Name());
            //$ this.SetInner(inner);
            //$ initializeChildrenFromInner();
            //$ return this;

            return this;
        }

        ///GENMHASH:3DBBB35580E0023332C1FB4E78C36EC4:8BC4FF2E70BFA1D6AB1B2664C2AB7FA1
        public ApplicationGatewayRequestRoutingRuleImpl DefineRequestRoutingRule(string name)
        {
            //$ ApplicationGatewayRequestRoutingRule rule = this.rules.Get(name);
            //$ if (rule == null) {
            //$ ApplicationGatewayRequestRoutingRuleInner inner = new ApplicationGatewayRequestRoutingRuleInner()
            //$ .WithName(name);
            //$ return new ApplicationGatewayRequestRoutingRuleImpl(inner, this);
            //$ } else {
            //$ return (ApplicationGatewayRequestRoutingRuleImpl) rule;
            //$ }

            return null;
        }

        ///GENMHASH:CD498C02D42C73AD0C1FF12493E2A9B8:CD5E24B4D8E0D679C5291E15ABECB279
        public int InstanceCount()
        {
            //$ if (this.Sku() != null && this.Sku().Capacity() != null) {
            //$ return this.Sku().Capacity();
            //$ } else {
            //$ return 1;
            //$ }

            return 0;
        }

        ///GENMHASH:DA0903CF2B09DA8DCF45A148EE669133:309987F9DF4AFE44584BBBA0780FD4DD
        internal ApplicationGatewayFrontendImpl EnsureDefaultPublicFrontend()
        {
            //$ ApplicationGatewayFrontendImpl frontend = (ApplicationGatewayFrontendImpl) defaultPublicFrontend();
            //$ if (frontend != null) {
            //$ return frontend;
            //$ } else {
            //$ String name = ResourceNamer.RandomResourceName("frontend", 14);
            //$ frontend = (ApplicationGatewayFrontendImpl) this.DefineFrontend(name);
            //$ frontend.Attach();
            //$ this.defaultPublicFrontend = frontend;
            //$ return frontend;
            //$ }
            //$ }

            return null;
        }

        ///GENMHASH:405FE49F57EE4AB4C0F91D84030D1DDA:F543E5F094A29330FBE6AE2B7D8F7B7A
        public ApplicationGatewayIpConfigurationImpl UpdateIpConfiguration(string ipConfigurationName)
        {
            //$ return (ApplicationGatewayIpConfigurationImpl) this.ipConfigs.Get(ipConfigurationName);

            return null;
        }

        ///GENMHASH:AEECF1FD9CF2F7E0FFAE9F2627E6B3FC:5EF4F345F37B15B88D7920245D112B33
        public ApplicationGatewaySslCertificateImpl DefineSslCertificate(string name)
        {
            //$ ApplicationGatewaySslCertificate cert = this.sslCerts.Get(name);
            //$ if (cert == null) {
            //$ ApplicationGatewaySslCertificateInner inner = new ApplicationGatewaySslCertificateInner()
            //$ .WithName(name);
            //$ return new ApplicationGatewaySslCertificateImpl(inner, this);
            //$ } else {
            //$ return (ApplicationGatewaySslCertificateImpl) cert;
            //$ }

            return null;
        }

        ///GENMHASH:140689F6718EC0DE59ED2724FEF8B493:FFD69AF34CCA85347AFB30F010027480
        public ApplicationGatewaySslPolicy SslPolicy()
        {
            //$ return this.Inner.SslPolicy();

            return null;
        }

        ///GENMHASH:6A7BE130A21D7CF301EAC3B7AFC03BC7:89DB414F8973677B8ED5DBFA5338F186
        public ApplicationGatewayListenerImpl UpdateListener(string name)
        {
            //$ return (ApplicationGatewayListenerImpl) this.listeners.Get(name);

            return null;
        }

        ///GENMHASH:DF33B11AB8B490CB0B236CD72B44740F:806736DF09AB90BDDD8E032352FC75F7
        public IApplicationGatewayListener ListenerByPortNumber(int portNumber)
        {
            //$ ApplicationGatewayListener listener = null;
            //$ foreach(var l in this.listeners.Values())  {
            //$ if (l.FrontendPortNumber() == portNumber) {
            //$ listener = l;
            //$ break;
            //$ }
            //$ }
            //$ return listener;

            return null;
        }

        ///GENMHASH:639D88327F2B6C934F976C743B318B50:3E294A29C2E6177D4AADBC61A2C83DBC
        public ApplicationGatewayImpl WithoutBackendHttpConfiguration(string name)
        {
            //$ this.backendHttpConfigs.Remove(name);
            //$ return this;

            return this;
        }

        ///GENMHASH:43D0A80DA689D640320A61D90075ADE8:53F2B2F3AF405296F17DB8BE5C792D5E
        internal ApplicationGatewayImpl WithBackendHttpConfiguration(ApplicationGatewayBackendHttpConfigurationImpl httpConfig)
        {
            //$ if (httpConfig == null) {
            //$ return null;
            //$ } else {
            //$ this.backendHttpConfigs.Put(httpConfig.Name(), httpConfig);
            //$ return this;
            //$ }
            //$ }

            return this;
        }

        ///GENMHASH:B68122A3AE9F806751DFE2AC77E699AF:5A184EBE0BAD48996EE3C74365B62FA5
        public ApplicationGatewayIpConfigurationImpl UpdateDefaultIpConfiguration()
        {
            //$ return (ApplicationGatewayIpConfigurationImpl) this.DefaultIpConfiguration();

            return null;
        }

        ///GENMHASH:4AC8CF7D9CB1EC685C6E9B19CE307C6F:EA1960DD08CE81963CC51EC4948132A2
        private SubResource DefaultSubnetRef()
        {
            //$ ApplicationGatewayIpConfiguration ipConfig = defaultIpConfiguration();
            //$ if (ipConfig == null) {
            //$ return null;
            //$ } else {
            //$ return ipConfig.Inner.Subnet();
            //$ }
            //$ }

            return null;
        }

        ///GENMHASH:284892F1C09754FA6CF4266448D10168:B11C94B89F9445AECA704E38ECA98A15
        public IApplicationGatewayFrontend DefaultPrivateFrontend()
        {
            //$ // Default means the only private one or the one tracked as default, if more than one private present
            //$ if (this.PrivateFrontends().Size() == 1) {
            //$ this.defaultPrivateFrontend = (ApplicationGatewayFrontendImpl) this.PrivateFrontends().Values().Iterator().Next();
            //$ } else if (this.frontends().Size() == 0) {
            //$ this.defaultPrivateFrontend = null;
            //$ }
            //$ 
            //$ return this.defaultPrivateFrontend;

            return null;
        }

        ///GENMHASH:D232B3BB0D86D13CC0B242F4000DBF07:97DF71BC11CE54F5F4736C975A273A63
        private ICreatable<Microsoft.Azure.Management.Network.Fluent.IPublicIpAddress> EnsureDefaultPipDefinition()
        {
            //$ if (this.creatablePip == null) {
            //$ String pipName = ResourceNamer.RandomResourceName("pip", 9);
            //$ this.creatablePip = this.Manager().PublicIpAddresses().Define(pipName)
            //$ .WithRegion(this.RegionName())
            //$ .WithExistingResourceGroup(this.ResourceGroupName());
            //$ }
            //$ 
            //$ return this.creatablePip;
            //$ }

            return null;
        }

        ///GENMHASH:E38530BE2EC4569C8D62DB8CEB4AD38F:90CC3E1EEF35BDBB9152B8B5149B04E0
        private ApplicationGatewayIpConfigurationImpl DefineIpConfiguration(string name)
        {
            //$ ApplicationGatewayIpConfiguration config = this.ipConfigs.Get(name);
            //$ if (config == null) {
            //$ ApplicationGatewayIPConfigurationInner inner = new ApplicationGatewayIPConfigurationInner()
            //$ .WithName(name);
            //$ return new ApplicationGatewayIpConfigurationImpl(inner, this);
            //$ } else {
            //$ return (ApplicationGatewayIpConfigurationImpl) config;
            //$ }
            //$ }

            return null;
        }

        ///GENMHASH:99A00736DF753F6060C6104537FAB411:D9EF6ECF075F0671DA3E7309852CB983
        public ApplicationGatewayImpl WithoutFrontendPort(string name)
        {
            //$ if (this.Inner.FrontendPorts() == null) {
            //$ return this;
            //$ }
            //$ 
            //$ for (int i = 0; i < this.Inner.FrontendPorts().Size(); i++) {
            //$ ApplicationGatewayFrontendPortInner inner = this.Inner.FrontendPorts().Get(i);
            //$ if (inner.Name().EqualsIgnoreCase(name)) {
            //$ this.Inner.FrontendPorts().Remove(i);
            //$ break;
            //$ }
            //$ }
            //$ 
            //$ return this;

            return this;
        }

        ///GENMHASH:668234534FB4FFFD8523AC34BA26B3DC:81C6EB67B9E5A0F963383F80948256A2
        public ApplicationGatewayImpl WithoutFrontendPort(int portNumber)
        {
            //$ for (int i = 0; i < this.Inner.FrontendPorts().Size(); i++) {
            //$ ApplicationGatewayFrontendPortInner inner = this.Inner.FrontendPorts().Get(i);
            //$ if (inner.Port().Equals(portNumber)) {
            //$ this.Inner.FrontendPorts().Remove(i);
            //$ break;
            //$ }
            //$ }
            //$ 
            //$ return this;

            return this;
        }

        ///GENMHASH:6CDEF6BE4432158ED3F8917E000EAD56:DB1402301D8518CEB5A0AE73F525CC10
        public ApplicationGatewayImpl WithPrivateIpAddressStatic(string ipAddress)
        {
            //$ ensureDefaultPrivateFrontend().WithPrivateIpAddressStatic(ipAddress);
            //$ return this;

            return this;
        }

        ///GENMHASH:C000D62B14DEB58BED734D8C97CBA337:B6A0CA4C00D439D0A62611FFBFCB1D01
        internal ApplicationGatewayImpl WithBackend(ApplicationGatewayBackendImpl backend)
        {
            //$ if (backend == null) {
            //$ return null;
            //$ } else {
            //$ this.backends.Put(backend.Name(), backend);
            //$ return this;
            //$ }
            //$ }

            return this;
        }

        ///GENMHASH:4DB70C23295D0F053459FB0473314A93:7A5B03571727B37E62AC3357D157E863
        public ApplicationGatewayImpl WithoutCertificate(string name)
        {
            //$ this.sslCerts.Remove(name);
            //$ return this;

            return this;
        }

        ///GENMHASH:77C9DAC5FABBCE9000402FF2D27EA990:6BF21BB8CB142597A825567301634266
        public ApplicationGatewayBackendImpl UpdateBackend(string name)
        {
            //$ return (ApplicationGatewayBackendImpl) this.backends.Get(name);

            return null;
        }

        ///GENMHASH:57B5349245E8E0AED639AD6C90041662:15B0E79628926A104F3E67AB78CAA58A
        public IReadOnlyDictionary<string, Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayBackendHttpConfiguration> BackendHttpConfigurations()
        {
            //$ return Collections.UnmodifiableMap(this.backendHttpConfigs);

            return null;
        }

        ///GENMHASH:38719597698E42AABAD5A9917188C155:5FA623156A2242C0CC7212EF7D654C87
        private void InitializeFrontendsFromInner()
        {
            //$ this.frontends = new TreeMap<>();
            //$ List<ApplicationGatewayFrontendIPConfigurationInner> inners = this.Inner.FrontendIPConfigurations();
            //$ if (inners != null) {
            //$ foreach(var inner in inners)  {
            //$ ApplicationGatewayFrontendImpl frontend = new ApplicationGatewayFrontendImpl(inner, this);
            //$ this.frontends.Put(inner.Name(), frontend);
            //$ }
            //$ }
            //$ }

        }

        ///GENMHASH:38BB8357245354CED812C58E4EC79068:D0C7FA8A585A667919422AC63F659988
        private void InitializeBackendsFromInner()
        {
            //$ this.backends = new TreeMap<>();
            //$ List<ApplicationGatewayBackendAddressPoolInner> inners = this.Inner.BackendAddressPools();
            //$ if (inners != null) {
            //$ foreach(var inner in inners)  {
            //$ ApplicationGatewayBackendImpl backend = new ApplicationGatewayBackendImpl(inner, this);
            //$ this.backends.Put(inner.Name(), backend);
            //$ }
            //$ }
            //$ }

        }

        ///GENMHASH:EE79C3B68C4C6A99234BB004EDCAD67A:75C2DBDE4D61EDB193493A39766B60EE
        public ApplicationGatewayImpl WithExistingSubnet(ISubnet subnet)
        {
            //$ ensureDefaultIpConfig().WithExistingSubnet(subnet);
            //$ return this;

            return this;
        }

        ///GENMHASH:5647899224D30C7B5E1FDCD2D9AAB1DB:E44EB8F969AE406A3CE854143982FB65
        public ApplicationGatewayImpl WithExistingSubnet(INetwork network, string subnetName)
        {
            //$ ensureDefaultIpConfig().WithExistingSubnet(network, subnetName);
            //$ return this;

            return this;
        }

        ///GENMHASH:E8683B20FED733D23930E96CCD1EB0A2:7246BAAE40C91731DF4E96029B3FA2BA
        public ApplicationGatewayImpl WithExistingSubnet(string networkResourceId, string subnetName)
        {
            //$ ensureDefaultIpConfig().WithExistingSubnet(networkResourceId, subnetName);
            //$ return this;

            return this;
        }

        ///GENMHASH:26736A6ADD939D26955E1B3CFAB3B027:E89C02FDC5725B8AD23DCBADA1105204
        public IPAllocationMethod PrivateIpAllocationMethod()
        {
            //$ ApplicationGatewayFrontend frontend = defaultPrivateFrontend();
            //$ if (frontend == null) {
            //$ return null;
            //$ } else {
            //$ return frontend.PrivateIpAllocationMethod();
            //$ }

            return null;
        }

        ///GENMHASH:94ACA3B358939F31F4F3966CDB1B73A4:7D7FC963A56E00888DE266506161CB7C
        public ApplicationGatewayImpl WithInstanceCount(int capacity)
        {
            //$ if (this.Inner.Sku() == null) {
            //$ this.WithSize(ApplicationGatewaySkuName.STANDARD_SMALL);
            //$ }
            //$ 
            //$ this.Inner.Sku().WithCapacity(capacity);
            //$ return this;

            return this;
        }

        ///GENMHASH:52092E76C641F5B4C13B8CD22D11A1C5:4116AC8D08FAEE8EE2AF72A493453127
        public ApplicationGatewayImpl WithoutBackendFqdn(string fqdn)
        {
            //$ foreach(var backend in this.backends.Values())  {
            //$ ApplicationGatewayBackendImpl backendImpl = (ApplicationGatewayBackendImpl) backend;
            //$ backendImpl.WithoutFqdn(fqdn);
            //$ }
            //$ return this;

            return this;
        }

        ///GENMHASH:3D14082AEAA37FD69BCA1BF0129B05FF:A0722D26BD371E7333E649E461013B02
        public ApplicationGatewayRequestRoutingRuleImpl UpdateRequestRoutingRule(string name)
        {
            //$ return (ApplicationGatewayRequestRoutingRuleImpl) this.rules.Get(name);

            return null;
        }

        ///GENMHASH:BAA3D51CA88C44942207E1ACEC857C51:83FF9E6570D6D323728B8D648A3FAFF9
        public ApplicationGatewayFrontendImpl DefinePublicFrontend()
        {
            //$ return ensureDefaultPublicFrontend();

            return null;
        }

        ///GENMHASH:2B1D79EF0701484A69266710AE199343:CEBE13FB015F4714AF252F0350B6B583
        public IReadOnlyDictionary<string, Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayFrontend> PrivateFrontends()
        {
            //$ Map<String, ApplicationGatewayFrontend> privateFrontends = new TreeMap<>();
            //$ foreach(var frontend in this.frontends().Values())  {
            //$ if (frontend.IsPrivate()) {
            //$ privateFrontends.Put(frontend.Name(), frontend);
            //$ }
            //$ }
            //$ 
            //$ return Collections.UnmodifiableMap(privateFrontends);

            return null;
        }

        ///GENMHASH:14670FFEE8D86F167A4246AFE76F91E6:8F8A962E6738F94558583D11555C6B53
        private void InitializeRequestRoutingRulesFromInner()
        {
            //$ this.rules = new TreeMap<>();
            //$ List<ApplicationGatewayRequestRoutingRuleInner> inners = this.Inner.RequestRoutingRules();
            //$ if (inners != null) {
            //$ foreach(var inner in inners)  {
            //$ ApplicationGatewayRequestRoutingRuleImpl rule = new ApplicationGatewayRequestRoutingRuleImpl(inner, this);
            //$ this.rules.Put(inner.Name(), rule);
            //$ }
            //$ }
            //$ }

        }

        ///GENMHASH:3AEE65B42CA330A187F9ED489D04EF17:BB6B3B198CEC808EF295F8AE72D11548
        public ApplicationGatewayImpl WithoutRequestRoutingRule(string name)
        {
            //$ this.rules.Remove(name);
            //$ return this;

            return this;
        }

        ///GENMHASH:80375A07B813FDE5A15028546D4FB694:477643FBA49E84CA226936A812310F65
        internal ApplicationGatewayImpl WithConfig(ApplicationGatewayIpConfigurationImpl config)
        {
            //$ if (config == null) {
            //$ return null;
            //$ } else {
            //$ this.ipConfigs.Put(config.Name(), config);
            //$ return this;
            //$ }
            //$ }

            return this;
        }

        ///GENMHASH:AC21A10EE2E745A89E94E447800452C1:2E5EA5B659E60C29EEED049E3FE11D8B
        protected override void BeforeCreating()
        {
            //$ // Process created PIPs
            //$ for (Entry<String, String> frontendPipPair : this.creatablePipsByFrontend.EntrySet()) {
            //$ Resource createdPip = this.CreatedResource(frontendPipPair.GetValue());
            //$ this.UpdateFrontend(frontendPipPair.GetKey()).WithExistingPublicIpAddress(createdPip.Id());
            //$ }
            //$ this.creatablePipsByFrontend.Clear();
            //$ 
            //$ // Reset and update IP configs
            //$ ensureDefaultIpConfig();
            //$ this.Inner.WithGatewayIPConfigurations(innersFromWrappers(this.ipConfigs.Values()));
            //$ 
            //$ this.Inner.WithFrontendIPConfigurations(innersFromWrappers(this.frontends.Values()));
            //$ 
            //$ // Reset and update backends
            //$ this.Inner.WithBackendAddressPools(innersFromWrappers(this.backends.Values()));
            //$ 
            //$ // Reset and update backend HTTP settings configs
            //$ this.Inner.WithBackendHttpSettingsCollection(innersFromWrappers(this.backendHttpConfigs.Values()));
            //$ 
            //$ // Reset and update HTTP listeners
            //$ this.Inner.WithHttpListeners(innersFromWrappers(this.listeners.Values()));
            //$ foreach(var listener in this.listeners.Values())  {
            //$ SubResource ref;
            //$ 
            //$ // Clear deleted frontend references
            //$ ref = listener.Inner.FrontendIPConfiguration();
            //$ if (ref != null
            //$ && !this.frontends().ContainsKey(ResourceUtils.NameFromResourceId(ref.Id()))) {
            //$ listener.Inner.WithFrontendIPConfiguration(null);
            //$ }
            //$ 
            //$ // Clear deleted frontend port references
            //$ ref = listener.Inner.FrontendPort();
            //$ if (ref != null
            //$ && !this.FrontendPorts().ContainsKey(ResourceUtils.NameFromResourceId(ref.Id()))) {
            //$ listener.Inner.WithFrontendPort(null);
            //$ }
            //$ 
            //$ // Clear deleted SSL certificate references
            //$ ref = listener.Inner.SslCertificate();
            //$ if (ref != null
            //$ && !this.SslCertificates().ContainsKey(ResourceUtils.NameFromResourceId(ref.Id()))) {
            //$ listener.Inner.WithSslCertificate(null);
            //$ }
            //$ }
            //$ 
            //$ // Reset and update request routing rules
            //$ this.Inner.WithRequestRoutingRules(innersFromWrappers(this.rules.Values()));
            //$ foreach(var rule in this.rules.Values())  {
            //$ SubResource ref;
            //$ 
            //$ // Clear deleted backends
            //$ ref = rule.Inner.BackendAddressPool();
            //$ if (ref != null
            //$ && !this.backends().ContainsKey(ResourceUtils.NameFromResourceId(ref.Id()))) {
            //$ rule.Inner.WithBackendAddressPool(null);
            //$ }
            //$ 
            //$ // Clear deleted backend HTTP configs
            //$ ref = rule.Inner.BackendHttpSettings();
            //$ if (ref != null
            //$ && !this.BackendHttpConfigurations().ContainsKey(ResourceUtils.NameFromResourceId(ref.Id()))) {
            //$ rule.Inner.WithBackendHttpSettings(null);
            //$ }
            //$ 
            //$ // Clear deleted frontend HTTP listeners
            //$ ref = rule.Inner.HttpListener();
            //$ if (ref != null
            //$ && !this.listeners().ContainsKey(ResourceUtils.NameFromResourceId(ref.Id()))) {
            //$ rule.Inner.WithHttpListener(null);
            //$ }
            //$ }
            //$ 
            //$ // Reset and update SSL certs
            //$ this.Inner.WithSslCertificates(innersFromWrappers(this.sslCerts.Values()));

        }

        ///GENMHASH:7B8AA96C3162D1728416030E94CB731F:AFEC509255ABE08FC417203DFF8CF829
        internal ApplicationGatewayImpl WithFrontend(ApplicationGatewayFrontendImpl frontend)
        {
            //$ if (frontend == null) {
            //$ return null;
            //$ } else {
            //$ this.frontends.Put(frontend.Name(), frontend);
            //$ return this;
            //$ }
            //$ }

            return this;
        }

        ///GENMHASH:FE2FB4C2B86589D7D187246933236472:D02F16FB7F9F848339457F517542934A
        public ApplicationGatewayImpl WithNewPublicIpAddress(ICreatable<Microsoft.Azure.Management.Network.Fluent.IPublicIpAddress> creatable)
        {
            //$ String name = ensureDefaultPublicFrontend().Name();
            //$ this.creatablePipsByFrontend.Put(name, creatable.Key());
            //$ this.AddCreatableDependency(creatable);
            //$ return this;

            return this;
        }

        ///GENMHASH:9865456A38EDF249959594524980AA77:4ACB26EDB3DFCE615E1000808D779EBD
        public ApplicationGatewayImpl WithNewPublicIpAddress()
        {
            //$ ensureDefaultPublicFrontend();
            //$ return this;

            return this;
        }

        /// <summary>
        /// Determines whether the app gateway child that can be found using a name or a port number can be created,
        /// or it already exists, or there is a clash.
        /// </summary>
        /// <param name="byName">Object found by name.</param>
        /// <param name="byPort">Object found by port.</param>
        /// <param name="name">The desired name of the object.</param>
        /// <return>True if already found, false if ok to create, null if conflict.</return>
        ///GENMHASH:644A3298215000D78F5173C9BC6F440E:9BEBC7254CB4CA864A9951088E837542
        internal bool NeedToCreate<T>(T byName, T byPort, string name)
        {
            //$ if (byName != null && byPort != null) {
            //$ // If objects with this name and/or port already exist...
            //$ if (byName == byPort) {
            //$ // ...And it is the same object, then do nothing
            //$ return false;
            //$ } else {
            //$ // ...But if they are inconsistent, then fail fast
            //$ return null;
            //$ }
            //$ } else if (byPort != null) {
            //$ // If no object with the requested name, but the port number is found...
            //$ if (name == null) {
            //$ // ...And no name is requested, then do nothing, because the object already exists
            //$ return false;
            //$ } else {
            //$ // ...But if a clashing name is requested, then fail fast
            //$ return null;
            //$ }
            //$ } else {
            //$ // Ok to create the object
            //$ return true;
            //$ }
            //$ }

            return false;
        }

        ///GENMHASH:7C4E822443AEFDF724B915FEB1AC8939:758E11F2064BDF9569DB0F6BEDA69EF2
        private static ApplicationGatewayFrontendImpl UseSubnetFromIpConfigForFrontend(ApplicationGatewayIpConfigurationImpl ipConfig, ApplicationGatewayFrontendImpl frontend)
        {
            //$ {
            //$ if (frontend != null) {
            //$ frontend.WithExistingSubnet(ipConfig.NetworkId(), ipConfig.SubnetName());
            //$ if (frontend.PrivateIpAddress() == null) {
            //$ frontend.WithPrivateIpAddressDynamic();
            //$ } else if (frontend.PrivateIpAllocationMethod() == null) {
            //$ frontend.WithPrivateIpAddressDynamic();
            //$ }
            //$ }
            //$ return frontend;
            //$ }

            return null;
        }

        ///GENMHASH:18F12733B6D16771FA686008216DE902:497D5BA64B46BCAD73B9D4148D1EA0E5
        public ApplicationGatewayBackendHttpConfigurationImpl UpdateBackendHttpConfiguration(string name)
        {
            //$ return (ApplicationGatewayBackendHttpConfigurationImpl) this.backendHttpConfigs.Get(name);

            return null;
        }

        ///GENMHASH:C57133CD301470A479B3BA07CD283E86:AD561DB8BFA1E730BA1B2810E86A05D2
        public string SubnetName()
        {
            //$ SubResource subnetRef = defaultSubnetRef();
            //$ if (subnetRef == null) {
            //$ return null;
            //$ } else {
            //$ return ResourceUtils.NameFromResourceId(subnetRef.Id());
            //$ }

            return null;
        }

        ///GENMHASH:A0174786468BD0401BEEB279F03A9F28:8E183AA7B177F20F15999B009DA993FE
        public ApplicationGatewayImpl WithoutListener(string name)
        {
            //$ this.listeners.Remove(name);
            //$ return this;

            return this;
        }

        ///GENMHASH:2CAA0883E5A09AD81DE423447D34059F:5D6EB88CFD9F858A269954D227220035
        private ApplicationGatewayFrontendImpl DefineFrontend(string name)
        {
            //$ ApplicationGatewayFrontend frontend = this.frontends.Get(name);
            //$ if (frontend == null) {
            //$ ApplicationGatewayFrontendIPConfigurationInner inner = new ApplicationGatewayFrontendIPConfigurationInner()
            //$ .WithName(name);
            //$ return new ApplicationGatewayFrontendImpl(inner, this);
            //$ } else {
            //$ return (ApplicationGatewayFrontendImpl) frontend;
            //$ }
            //$ }

            return null;
        }

        ///GENMHASH:237C0D1ED9460213CBE7249D1C6CA8F9:C10C08F4EDAF857C90407183880ADDB6
        public ApplicationGatewayImpl WithoutPrivateFrontend()
        {
            //$ // Ensure no frontend is private
            //$ foreach(var frontend in this.frontends.Values())  {
            //$ frontend.Inner.WithSubnet(null).WithPrivateIPAddress(null).WithPrivateIPAllocationMethod(null);
            //$ }
            //$ this.defaultPrivateFrontend = null;
            //$ return this;

            return this;
        }

        ///GENMHASH:F756CBB3F13EF6198269C107AED6F9A2:F819A402FF29D3234FF975971868AD05
        public ApplicationGatewayTier Tier()
        {
            //$ if (this.Sku() != null && this.Sku().Tier() != null) {
            //$ return this.Sku().Tier();
            //$ } else {
            //$ return ApplicationGatewayTier.STANDARD;
            //$ }

            return null;
        }

        ///GENMHASH:2911D7234EA1C2B2AC65B607D78B6E4A:1BA96F7ED47F4A48A42FC00578BB3810
        public bool IsPublic()
        {
            //$ foreach(var frontend in this.frontends.Values())  {
            //$ if (frontend.IsPublic()) {
            //$ return true;
            //$ }
            //$ }
            //$ return false;

            return false;
        }

        ///GENMHASH:EA98B464B10BD645EE3B0689825B43B8:9153A57100FB410376A86235E5F5CDBD
        public ApplicationGatewayImpl WithPrivateIpAddressDynamic()
        {
            //$ ensureDefaultPrivateFrontend().WithPrivateIpAddressDynamic();
            //$ return this;

            return this;
        }

        ///GENMHASH:2572DE01031DBF4160442C8972FF5A5E:82DF98F81461A048AF4598C642544BE3
        public string FrontendPortNameFromNumber(int portNumber)
        {
            //$ String portName = null;
            //$ for (Entry<String, Integer> portEntry : this.FrontendPorts().EntrySet()) {
            //$ if (portNumber == portEntry.GetValue()) {
            //$ portName = portEntry.GetKey();
            //$ break;
            //$ }
            //$ }
            //$ return portName;

            return null;
        }

        ///GENMHASH:3EB46226E14C9B9CCFF912B0282CE5C1:05D1016177B6A6A6C2D59D08E19394C9
        private void InitializeBackendHttpConfigsFromInner()
        {
            //$ this.backendHttpConfigs = new TreeMap<>();
            //$ List<ApplicationGatewayBackendHttpSettingsInner> inners = this.Inner.BackendHttpSettingsCollection();
            //$ if (inners != null) {
            //$ foreach(var inner in inners)  {
            //$ ApplicationGatewayBackendHttpConfigurationImpl httpConfig = new ApplicationGatewayBackendHttpConfigurationImpl(inner, this);
            //$ this.backendHttpConfigs.Put(inner.Name(), httpConfig);
            //$ }
            //$ }
            //$ }

        }

        ///GENMHASH:359B78C1848B4A526D723F29D8C8C558:257D937A0F04955A15D8633AF5E905F3
        override protected Task<Models.ApplicationGatewayInner> CreateInner()
        {
            //$ // Determine if a default public frontend PIP should be created
            //$ ApplicationGatewayFrontendImpl defaultPublicFrontend = (ApplicationGatewayFrontendImpl) defaultPublicFrontend();
            //$ Observable<Resource> pipObservable;
            //$ if (defaultPublicFrontend != null && defaultPublicFrontend.PublicIpAddressId() == null) {
            //$ // If public frontend requested but no PIP specified, then create a default PIP
            //$ pipObservable = Utils.<PublicIpAddress>rootResource(ensureDefaultPipDefinition()
            //$ .CreateAsync()).Map(new Func1<PublicIpAddress, Resource>() {
            //$ @Override
            //$ public Resource call(PublicIpAddress publicIpAddress) {
            //$ defaultPublicFrontend.WithExistingPublicIpAddress(publicIpAddress);
            //$ return publicIpAddress;
            //$ }
            //$ });
            //$ } else {
            //$ // If no public frontend requested, skip creating the PIP
            //$ pipObservable = Observable.Empty();
            //$ }
            //$ 
            //$ // Determine if default VNet should be created
            //$ ApplicationGatewayIpConfigurationImpl defaultIpConfig = ensureDefaultIpConfig();
            //$ ApplicationGatewayFrontendImpl defaultPrivateFrontend = (ApplicationGatewayFrontendImpl) defaultPrivateFrontend();
            //$ Observable<Resource> networkObservable;
            //$ if (defaultIpConfig.SubnetName() != null) {
            //$ // If default IP config already has a subnet assigned to it...
            //$ if (defaultPrivateFrontend != null) {
            //$ // ...And a private frontend is requested, then use the same vnet for the private frontend
            //$ useSubnetFromIpConfigForFrontend(defaultIpConfig, defaultPrivateFrontend);
            //$ }
            //$ // ...And no need to create a default VNet
            //$ networkObservable = Observable.Empty(); // ...And don't create another VNet
            //$ } else {
            //$ // But if default IP config does not have a subnet specified, then create a default VNet
            //$ networkObservable = Utils.<Network>rootResource(ensureDefaultNetworkDefinition()
            //$ .CreateAsync()).Map(new Func1<Network, Resource>() {
            //$ @Override
            //$ public Resource call(Network network) {
            //$ //... and assign the created VNet to the default IP config
            //$ defaultIpConfig.WithExistingSubnet(network, DEFAULT);
            //$ if (defaultPrivateFrontend != null) {
            //$ // If a private frontend is also requested, then use the same VNet for the private frontend as for the IP config
            //$ /* TODO: Not sure if the assumption of the same subnet for the frontend and the IP config will hold in
            //$ * the future, but the existing ARM template for App Gateway for some reason uses the same subnet for the
            //$ * IP config and the private frontend. Also, trying to use different subnets results in server error today saying they
            //$ * have to be the same. This may need to be revisited in the future however, as this is somewhat inconsistent
            //$ * with what the documentation says.
            //$ */
            //$ useSubnetFromIpConfigForFrontend(defaultIpConfig, defaultPrivateFrontend);
            //$ }
            //$ return network;
            //$ }
            //$ });
            //$ }
            //$ 
            //$ return Observable.Merge(networkObservable, pipObservable)
            //$ .DefaultIfEmpty(null)
            //$ .Last().FlatMap(new Func1<Resource, Observable<ApplicationGatewayInner>>() {
            //$ @Override
            //$ public Observable<ApplicationGatewayInner> call(Resource resource) {
            //$ return innerCollection.CreateOrUpdateAsync(resourceGroupName(), name(), Inner);
            //$ }
            //$ });

            return null;
        }

        ///GENMHASH:7C5A670BDA8BF576E8AFC752CD10A797:A955581589FA3AB5F9E850A8EC96F11A
        public ApplicationGatewayImpl WithPrivateFrontend()
        {
            //$ /* NOTE: This logic is a workaround for the unusual Azure API logic:
            //$ * - although app gateway API definition allows multiple IP configs, only one is allowed by the service currently;
            //$ * - although app gateway frontend API definition allows for multiple frontends, only one is allowed by the service today;
            //$ * - and although app gateway API definition allows different subnets to be specified between the IP configs and frontends, the service
            //$ * requires the frontend and the containing subnet to be one and the same currently.
            //$ *
            //$ * So the logic here attempts to figure out from the API what that containing subnet for the app gateway is so that the user wouldn't
            //$ * have to re-enter it redundantly when enabling a private frontend, since only that one subnet is supported anyway.
            //$ *
            //$ * TODO: When the underlying Azure API is reworked to make more sense, or the app gateway service starts supporting the functionality
            //$ * that the underlying API implies is supported, this model and implementation should be revisited.
            //$ */
            //$ ensureDefaultPrivateFrontend();
            //$ return this;

            return this;
        }

        ///GENMHASH:6D9F740D6D73C56877B02D9F1C96F6E7:40A35D1A3A7CCDCE21CBF18A30149CF3
        protected override void InitializeChildrenFromInner()
        {
            //$ initializeConfigsFromInner();
            //$ initializeFrontendsFromInner();
            //$ initializeBackendsFromInner();
            //$ initializeBackendHttpConfigsFromInner();
            //$ initializeHttpListenersFromInner();
            //$ initializeRequestRoutingRulesFromInner();
            //$ initializeSslCertificatesFromInner();
            //$ this.defaultPrivateFrontend = null;
            //$ this.defaultPublicFrontend = null;

        }

        ///GENMHASH:1E7046ABBFA82B3370C0EE4358FCAAB3:0BE350F61261249195A1647DAD43D2AB
        public ApplicationGatewayImpl WithFrontendPort(int portNumber)
        {
            //$ return withFrontendPort(portNumber, null);

            return this;
        }

        ///GENMHASH:328B229A953520EB99975ECA4DEB46B7:E963FDA43A79265B89CA4E5FE8DAEB76
        public ApplicationGatewayImpl WithFrontendPort(int portNumber, string name)
        {
            //$ // Ensure inner ports list initialized
            //$ List<ApplicationGatewayFrontendPortInner> frontendPorts = this.Inner.FrontendPorts();
            //$ if (frontendPorts == null) {
            //$ frontendPorts = new ArrayList<ApplicationGatewayFrontendPortInner>();
            //$ this.Inner.WithFrontendPorts(frontendPorts);
            //$ }
            //$ 
            //$ // Attempt to find inner port by name if provided, or port number otherwise
            //$ ApplicationGatewayFrontendPortInner frontendPortByName = null;
            //$ ApplicationGatewayFrontendPortInner frontendPortByNumber = null;
            //$ foreach(var inner in this.Inner.FrontendPorts())  {
            //$ if (name != null && name.EqualsIgnoreCase(inner.Name())) {
            //$ frontendPortByName = inner;
            //$ }
            //$ if (inner.Port() == portNumber) {
            //$ frontendPortByNumber = inner;
            //$ }
            //$ }
            //$ 
            //$ Boolean needToCreate = this.NeedToCreate(frontendPortByName, frontendPortByNumber, name);
            //$ if (Boolean.TRUE.Equals(needToCreate)) {
            //$ // If no conflict, create a new port
            //$ if (name == null) {
            //$ // No name specified, so auto-name it
            //$ name = ResourceNamer.RandomResourceName("port", 9);
            //$ }
            //$ 
            //$ frontendPortByName = new ApplicationGatewayFrontendPortInner()
            //$ .WithName(name)
            //$ .WithPort(portNumber);
            //$ frontendPorts.Add(frontendPortByName);
            //$ return this;
            //$ } else if (Boolean.FALSE.Equals(needToCreate)) {
            //$ // If found matching port, then nothing needs to happen
            //$ return this;
            //$ } else {
            //$ // If name conflict for the same port number, then fail
            //$ return null;
            //$ }

            return this;
        }

        ///GENMHASH:605022D847E1CBA530EBD654136D8064:B699ABF72548606674C97317B2B20760
        public IApplicationGatewayIpConfiguration DefaultIpConfiguration()
        {
            //$ // Default means the only one
            //$ if (this.ipConfigs.Size() == 1) {
            //$ return this.ipConfigs.Values().Iterator().Next();
            //$ } else {
            //$ return null;
            //$ }

            return null;
        }

        ///GENMHASH:65F75FDFA4544CBB0088928EC664A699:2CC325C7E7DA0C579A9F5409C52333F5
        public ApplicationGatewayImpl WithoutFrontend(string frontendName)
        {
            //$ this.frontends.Remove(frontendName);
            //$ return this;

            return this;
        }

        ///GENMHASH:327A257714E97E0CC9195D07369866F6:AC0B304DE3854395AFFCFBF726105B2C
        public IReadOnlyDictionary<string, Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayFrontend> PublicFrontends()
        {
            //$ Map<String, ApplicationGatewayFrontend> publicFrontends = new TreeMap<>();
            //$ foreach(var frontend in this.frontends().Values())  {
            //$ if (frontend.IsPublic()) {
            //$ publicFrontends.Put(frontend.Name(), frontend);
            //$ }
            //$ }
            //$ 
            //$ return Collections.UnmodifiableMap(publicFrontends);

            return null;
        }

        ///GENMHASH:A3E0AFFD41A48AADA625D444BDC4B639:D755BC44A5AE232FE3D5AB7294B7260E
        public ApplicationGatewayImpl WithoutIpConfiguration(string ipConfigurationName)
        {
            //$ this.ipConfigs.Remove(ipConfigurationName);
            //$ return this;

            return this;
        }

        ///GENMHASH:854F62AEEE32605D0082690205B49C3B:68548DB0EF9B6E0869FDD4F8A24E25F9
        public ApplicationGatewayFrontendImpl DefinePrivateFrontend()
        {
            //$ return ensureDefaultPrivateFrontend();

            return null;
        }

        ///GENMHASH:1B49C92CBA9BDBBF9FBFD26544224384:8B6E82EE2C6ECB762256E74C48B124D1
        public IUpdate WithoutPublicIpAddress()
        {
            //$ return this.WithoutPublicFrontend();

            return null;
        }
    }
}