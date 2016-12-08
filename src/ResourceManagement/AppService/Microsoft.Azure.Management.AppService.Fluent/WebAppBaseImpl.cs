// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Appservice.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using WebAppBase.Definition;
    using WebAppBase.Update;
    using Microsoft.Azure.Management.Resource.Fluent;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using System.Collections.Generic;
    using System;

    /// <summary>
    /// The implementation for WebAppBase.
    /// </summary>
    /// <typeparam name="Fluent">The fluent interface of the web app or deployment slot.</typeparam>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmFwcHNlcnZpY2UuaW1wbGVtZW50YXRpb24uV2ViQXBwQmFzZUltcGw=
    internal abstract partial class WebAppBaseImpl<FluentT,FluentImplT>  :
        GroupableResource<FluentT,Microsoft.Azure.Management.AppService.Fluent.Models.SiteInner,FluentImplT,Microsoft.Azure.Management.AppService.Fluent.Models.AppServiceManager>,
        IWebAppBase<FluentT>,
        IDefinition<FluentT>,
        IUpdate<FluentT>,
        IWithWebContainer<FluentT>
    {
        final WebAppsInner client;
        final WebSiteManagementClientImpl serviceClient;
         IDictionary<string,Microsoft.Azure.Management.Appservice.Fluent.IAppSetting> cachedAppSettings;
         IDictionary<string,Microsoft.Azure.Management.Appservice.Fluent.IConnectionString> cachedConnectionStrings;
        private ISet<string> hostNamesSet;
        private ISet<string> enabledHostNamesSet;
        private ISet<string> trafficManagerHostNamesSet;
        private ISet<string> outboundIpAddressesSet;
        private IDictionary<string,Microsoft.Azure.Management.AppService.Fluent.Models.HostNameSslState> hostNameSslStateMap;
        private IDictionary<string,Microsoft.Azure.Management.Appservice.Fluent.HostNameBindingImpl<FluentT,FluentImplT>> hostNameBindingsToCreate;
        private IList<string> hostNameBindingsToDelete;
        private IDictionary<string,Microsoft.Azure.Management.Appservice.Fluent.HostNameSslBindingImpl<FluentT,FluentImplT>> sslBindingsToCreate;
        private IDictionary<string,string> appSettingsToAdd;
        private IList<string> appSettingsToRemove;
        private IDictionary<string,bool> appSettingStickiness;
        private IDictionary<string,Microsoft.Azure.Management.AppService.Fluent.Models.ConnStringValueTypePair> connectionStringsToAdd;
        private IList<string> connectionStringsToRemove;
        private IDictionary<string,bool> connectionStringStickiness;
        private WebAppSourceControlImpl<FluentT,FluentImplT> sourceControl;
        private bool sourceControlToDelete;
        ///GENMHASH:6779D3D3C7AB7AAAE805BA0ABEE95C51:27E486AB74A10242FF421C0798DDC450
        internal abstract async Task<Microsoft.Azure.Management.AppService.Fluent.Models.StringDictionaryInner> UpdateAppSettingsAsync(StringDictionaryInner inner, CancellationToken cancellationToken = default(CancellationToken));

        ///GENMHASH:400B39C84CFE07A8B031B773061CF1BB:54F16B494685A43639288CB0A223084F
        public FluentImplT WithAppSettingStickiness(string key, bool sticky)
        {
            //$ public FluentImplT withAppSettingStickiness(String key, boolean sticky) {
            //$ appSettingStickiness.Put(key, sticky);
            //$ return (FluentImplT) this;

            return default(FluentImplT);
        }

        ///GENMHASH:2EFCE799E63D7CDD5EDE55B1622770C9:936A41F3229D51DDB490CC6CCD933986
        public string RepositorySiteName()
        {
            //$ return Inner.RepositorySiteName();

            return null;
        }

        ///GENMHASH:5347BC9AA33E4B7344CEB8188EA1DAA3:B3A0F7D2A1C11139E3140FF2DC919CEB
        public FluentImplT WithoutPython()
        {
            //$ return withPythonVersion(new PythonVersion(""));

            return default(FluentImplT);
        }

        ///GENMHASH:B67E95BCEA89D1B6CBB6849249A60D4F:3A1F8EE2D47ED51D598D727D3C3FAA86
        public FluentImplT WithThirdPartyHostnameBinding(string domain, params string[] hostnames)
        {
            //$ public FluentImplT withThirdPartyHostnameBinding(String domain, String... hostnames) {
            //$ foreach(var hostname in hostnames)  {
            //$ defineHostnameBinding()
            //$ .WithThirdPartyDomain(domain)
            //$ .WithSubDomain(hostname)
            //$ .WithDnsRecordType(CustomHostNameDnsRecordType.CNAME)
            //$ .Attach();
            //$ }
            //$ return (FluentImplT) this;

            return default(FluentImplT);
        }

        ///GENMHASH:620993DCE6DF78140D8125DD97478452:27E486AB74A10242FF421C0798DDC450
        internal abstract async Task<Microsoft.Azure.Management.AppService.Fluent.Models.StringDictionaryInner> ListAppSettingsAsync(CancellationToken cancellationToken = default(CancellationToken));

        ///GENMHASH:879627C2DAE69433191E7E3A0197FFCB:97444012B93FEF52369A6C980B714A5A
        private FluentT NormalizeProperties()
        {
            //$ this.hostNameBindingsToCreate = new HashMap<>();
            //$ this.hostNameBindingsToDelete = new ArrayList<>();
            //$ this.appSettingsToAdd = new HashMap<>();
            //$ this.appSettingsToRemove = new ArrayList<>();
            //$ this.appSettingStickiness = new HashMap<>();
            //$ this.connectionStringsToAdd = new HashMap<>();
            //$ this.connectionStringsToRemove = new ArrayList<>();
            //$ this.connectionStringStickiness = new HashMap<>();
            //$ this.sourceControl = null;
            //$ this.sourceControlToDelete = false;
            //$ this.sslBindingsToCreate = new HashMap<>();
            //$ if (Inner.HostNames() != null) {
            //$ this.hostNamesSet = Sets.NewHashSet(Inner.HostNames());
            //$ }
            //$ if (Inner.EnabledHostNames() != null) {
            //$ this.enabledHostNamesSet = Sets.NewHashSet(Inner.EnabledHostNames());
            //$ }
            //$ if (Inner.TrafficManagerHostNames() != null) {
            //$ this.trafficManagerHostNamesSet = Sets.NewHashSet(Inner.TrafficManagerHostNames());
            //$ }
            //$ if (Inner.OutboundIpAddresses() != null) {
            //$ this.outboundIpAddressesSet = Sets.NewHashSet(Inner.OutboundIpAddresses().Split(",[ ]*"));
            //$ }
            //$ this.hostNameSslStateMap = new HashMap<>();
            //$ if (Inner.HostNameSslStates() != null) {
            //$ foreach(var hostNameSslState in Inner.HostNameSslStates())  {
            //$ // Server returns null sometimes, invalid on update, so we set default
            //$ if (hostNameSslState.SslState() == null) {
            //$ hostNameSslState.WithSslState(SslState.DISABLED);
            //$ }
            //$ hostNameSslStateMap.Put(hostNameSslState.Name(), hostNameSslState);
            //$ }
            //$ }
            //$ return (FluentT) this;

            return default(FluentT);
        }

        ///GENMHASH:5091CF7FBD481F6A80C8200D77B918B5:86CEE108C820B076B77DA76828966EDD
        public string JavaContainerVersion()
        {
            //$ if (Inner.SiteConfig() == null) {
            //$ return null;
            //$ }
            //$ return Inner.SiteConfig().JavaContainerVersion();

            return null;
        }

        ///GENMHASH:807E62B6346803DB90804D0DEBD2FCA6:27E486AB74A10242FF421C0798DDC450
        internal abstract async Task DeleteSourceControlAsync(CancellationToken cancellationToken = default(CancellationToken));

        ///GENMHASH:B06FC38A7913CA2F028C97DE025DEED3:0F7ECBEDACE05420A5D0D277D4704257
        public FluentImplT WithStickyConnectionString(string name, string value, ConnectionStringType type)
        {
            //$ public FluentImplT withStickyConnectionString(String name, String value, ConnectionStringType type) {
            //$ connectionStringsToAdd.Put(name, new ConnStringValueTypePair().WithValue(value).WithType(type));
            //$ connectionStringStickiness.Put(name, true);
            //$ return (FluentImplT) this;

            return default(FluentImplT);
        }

        ///GENMHASH:0BD0140B6FBB6AA6B83FE90F95878549:855FB47B5269DBB806FE536172AD4F91
        public PythonVersion PythonVersion()
        {
            //$ if (Inner.SiteConfig() == null || Inner.SiteConfig().PythonVersion() == null) {
            //$ return PythonVersion.OFF;
            //$ }
            //$ return new PythonVersion(Inner.SiteConfig().PythonVersion());

            return null;
        }

        ///GENMHASH:C03B1FAF31FB94362C083BAA7332E4A4:516E9ADDDB1B086B94A185F8CA729E6B
        public FluentImplT WithoutJava()
        {
            //$ return withJavaVersion(new JavaVersion("")).WithWebContainer(null);

            return default(FluentImplT);
        }

        ///GENMHASH:3A0791A760CE20BB60B662E45E1B5A20:AC8556A885DA9E1351FB1A6C074AA07E
        public FluentImplT WithPythonVersion(PythonVersion version)
        {
            //$ public FluentImplT withPythonVersion(PythonVersion version) {
            //$ if (Inner.SiteConfig() == null) {
            //$ Inner.WithSiteConfig(new SiteConfigInner());
            //$ }
            //$ Inner.SiteConfig().WithPythonVersion(version.ToString());
            //$ return (FluentImplT) this;

            return default(FluentImplT);
        }

        ///GENMHASH:E45783E7B404EC0F4EBC4EE6BA7EF55A:5ECDDE741F87F4634B0FDC94904B2771
        public FluentImplT WithManagedPipelineMode(ManagedPipelineMode managedPipelineMode)
        {
            //$ public FluentImplT withManagedPipelineMode(ManagedPipelineMode managedPipelineMode) {
            //$ if (Inner.SiteConfig() == null) {
            //$ Inner.WithSiteConfig(new SiteConfigInner());
            //$ }
            //$ Inner.SiteConfig().WithManagedPipelineMode(managedPipelineMode);
            //$ return (FluentImplT) this;

            return default(FluentImplT);
        }

        ///GENMHASH:4002186478A1CB0B59732EBFB18DEB3A:75636395FBDB9C1FA7F5231207B98D55
        public FluentT Refresh()
        {
            //$ SiteInner inner = getInner().ToBlocking().Single();
            //$ inner.WithSiteConfig(getConfigInner().ToBlocking().Single());
            //$ setInner(inner);
            //$ return this.CacheAppSettingsAndConnectionStrings().ToBlocking().Single();

            return default(FluentT);
        }

        ///GENMHASH:10422D744EF1F162EBE8C9A9FA95C4F1:730A847F06F615063704F0C5FFF2B639
        public ISet<string> OutboundIpAddresses()
        {
            //$ return Collections.UnmodifiableSet(outboundIpAddressesSet);

            return null;
        }

        ///GENMHASH:4380B7AB34BB7338E16329242A2DB73A:399A7EDDE163BD102BD7A221C0EF6472
        public bool WebSocketsEnabled()
        {
            //$ if (Inner.SiteConfig() == null) {
            //$ return false;
            //$ }
            //$ return Utils.ToPrimitiveBoolean(Inner.SiteConfig().WebSocketsEnabled());

            return false;
        }

        ///GENMHASH:994878BE86A846414AFCBD6D6A774106:76D5065C8B4CBF008709864E3A6AFAA4
        public int ContainerSize()
        {
            //$ return Inner.ContainerSize();

            return 0;
        }

        ///GENMHASH:A0391A0E086361AE06DB925568A86EB3:D99F39EFAEA0FEA27CFADE7E7F5F87A9
        internal async Task<FluentT> CacheAppSettingsAndConnectionStringsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ FluentT self = (FluentT) this;
            //$ return Observable.Zip(listAppSettings(), listConnectionStrings(), listSlotConfigurations(), new Func3<StringDictionaryInner, ConnectionStringDictionaryInner, SlotConfigNamesResourceInner, FluentT>() {
            //$ @Override
            //$ public FluentT call( StringDictionaryInner appSettingsInner,  ConnectionStringDictionaryInner connectionStringsInner,  SlotConfigNamesResourceInner slotConfigs) {
            //$ cachedAppSettings = new HashMap<>();
            //$ cachedConnectionStrings = new HashMap<>();
            //$ if (appSettingsInner != null && appSettingsInner.Properties() != null) {
            //$ cachedAppSettings = Maps.AsMap(appSettingsInner.Properties().KeySet(), new Function<String, AppSetting>() {
            //$ @Override
            //$ public AppSetting apply(String input) {
            //$ return new AppSettingImpl(input, appSettingsInner.Properties().Get(input),
            //$ slotConfigs.AppSettingNames() != null && slotConfigs.AppSettingNames().Contains(input));
            //$ }
            //$ });
            //$ }
            //$ if (connectionStringsInner != null && connectionStringsInner.Properties() != null) {
            //$ cachedConnectionStrings = Maps.AsMap(connectionStringsInner.Properties().KeySet(), new Function<String, ConnectionString>() {
            //$ @Override
            //$ public ConnectionString apply(String input) {
            //$ return new ConnectionStringImpl(input, connectionStringsInner.Properties().Get(input), slotConfigs.ConnectionStringNames().Contains(input));
            //$ }
            //$ });
            //$ }
            //$ return self;
            //$ }
            //$ });

            return null;
        }

        ///GENMHASH:21FDAEDB996672BE017C01C5DD8758D4:27E486AB74A10242FF421C0798DDC450
        internal abstract async Task<Microsoft.Azure.Management.AppService.Fluent.Models.ConnectionStringDictionaryInner> UpdateConnectionStringsAsync(ConnectionStringDictionaryInner inner, CancellationToken cancellationToken = default(CancellationToken));

        ///GENMHASH:5C64261945401D044556FE57A81F8919:9E936C439A1F037DD069CDD0064C2AC0
        public HostNameBindingImpl<FluentT,FluentImplT> DefineHostnameBinding()
        {
            //$ public HostNameBindingImpl<FluentT, FluentImplT> defineHostnameBinding() {
            //$ HostNameBindingInner inner = new HostNameBindingInner();
            //$ inner.WithSiteName(name());
            //$ inner.WithLocation(regionName());
            //$ inner.WithAzureResourceType(AzureResourceType.WEBSITE);
            //$ inner.WithAzureResourceName(name());
            //$ inner.WithHostNameType(HostNameType.VERIFIED);
            //$ return new HostNameBindingImpl<>(inner, (FluentImplT) this, client);

            return null;
        }

        ///GENMHASH:C41BC129D11DD290512802D4F95ED197:C6674CAD927602613E222F438F228B47
        public FluentImplT WithDefaultDocument(string document)
        {
            //$ public FluentImplT withDefaultDocument(String document) {
            //$ if (Inner.SiteConfig() == null) {
            //$ Inner.WithSiteConfig(new SiteConfigInner());
            //$ }
            //$ if (Inner.SiteConfig().DefaultDocuments() == null) {
            //$ Inner.SiteConfig().WithDefaultDocuments(new ArrayList<String>());
            //$ }
            //$ Inner.SiteConfig().DefaultDocuments().Add(document);
            //$ return (FluentImplT) this;

            return default(FluentImplT);
        }

        ///GENMHASH:75EA0E50B45903417B864DA9C5D01D1C:9919B071041D059D4D8D308E1FB5E20E
        public FluentImplT WithConnectionStringStickiness(string name, bool stickiness)
        {
            //$ public FluentImplT withConnectionStringStickiness(String name, boolean stickiness) {
            //$ connectionStringStickiness.Put(name, stickiness);
            //$ return (FluentImplT) this;

            return default(FluentImplT);
        }

        ///GENMHASH:AC61A00CBD2F6D3CC13EFDD2D085B45C:195DCAB08F9ED1B9468C652A0D922DB9
        public ISet<string> EnabledHostNames()
        {
            //$ if (enabledHostNamesSet == null) {
            //$ return null;
            //$ }
            //$ return Collections.UnmodifiableSet(enabledHostNamesSet);

            return null;
        }

        ///GENMHASH:28D9C85008A5FA42084A6F7E18E27138:AD25C9D393389A67F8973FC859A1C1D2
        public FluentImplT WithRemoteDebuggingEnabled(RemoteVisualStudioVersion remoteVisualStudioVersion)
        {
            //$ public FluentImplT withRemoteDebuggingEnabled(RemoteVisualStudioVersion remoteVisualStudioVersion) {
            //$ if (Inner.SiteConfig() == null) {
            //$ Inner.WithSiteConfig(new SiteConfigInner());
            //$ }
            //$ Inner.SiteConfig().WithRemoteDebuggingEnabled(true);
            //$ Inner.SiteConfig().WithRemoteDebuggingVersion(remoteVisualStudioVersion.ToString());
            //$ return (FluentImplT) this;

            return default(FluentImplT);
        }

        ///GENMHASH:7889230A4E9E7272A9D70286DB690D8E:53F488EBDEDD2F8F38BF84028D4A7680
        public FluentImplT WithoutDefaultDocument(string document)
        {
            //$ public FluentImplT withoutDefaultDocument(String document) {
            //$ if (Inner.SiteConfig() == null) {
            //$ Inner.WithSiteConfig(new SiteConfigInner());
            //$ }
            //$ if (Inner.SiteConfig().DefaultDocuments() != null) {
            //$ Inner.SiteConfig().DefaultDocuments().Remove(document);
            //$ }
            //$ return (FluentImplT) this;

            return default(FluentImplT);
        }

        ///GENMHASH:1BA412F5F81148A7D5CE917E46EAF27A:22A28B1AE554D533D9E4E3634397A615
        public FluentImplT WithClientCertEnabled(bool enabled)
        {
            //$ public FluentImplT withClientCertEnabled(boolean enabled) {
            //$ Inner.WithClientCertEnabled(enabled);
            //$ return (FluentImplT) this;

            return default(FluentImplT);
        }

        ///GENMHASH:843B1707D5538E1793853BD38DCDFC52:E68D654B4C771392BAED7DFAFD6DE33F
        public FluentImplT WithLocalGitSourceControl()
        {
            //$ public FluentImplT withLocalGitSourceControl() {
            //$ if (Inner.SiteConfig() == null) {
            //$ Inner.WithSiteConfig(new SiteConfigInner());
            //$ }
            //$ Inner.SiteConfig().WithScmType("LocalGit");
            //$ return (FluentImplT) this;

            return default(FluentImplT);
        }

        ///GENMHASH:BEE7B618B5DF7C44777C46BFEC630694:20EB58C3836E816A654AF4F84626B607
        public FluentImplT WithAppSetting(string key, string value)
        {
            //$ public FluentImplT withAppSetting(String key, String value) {
            //$ appSettingsToAdd.Put(key, value);
            //$ return (FluentImplT) this;

            return default(FluentImplT);
        }

        ///GENMHASH:42336CC6A1724D1EDE76A585C5A018A2:306B7C561A246A23FDBF8B69DCA91F1C
        public bool IsPremiumApp()
        {
            //$ return Inner.PremiumAppDeployed();

            return false;
        }

        ///GENMHASH:7B9E90726FF47A7DBBBA2ECDEF2A3EA5:D06B68E3D50C3AA8EE45FF306EE6CF8F
        public FluentImplT WithRemoteDebuggingDisabled()
        {
            //$ public FluentImplT withRemoteDebuggingDisabled() {
            //$ if (Inner.SiteConfig() == null) {
            //$ Inner.WithSiteConfig(new SiteConfigInner());
            //$ }
            //$ Inner.SiteConfig().WithRemoteDebuggingEnabled(false);
            //$ return (FluentImplT) this;

            return default(FluentImplT);
        }

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:CEC809FD4F53D4DA22F61A1AC8FF20DD
        public async Task<FluentT> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ if (hostNameSslStateMap.Size() > 0) {
            //$ Inner.WithHostNameSslStates(new ArrayList<>(hostNameSslStateMap.Values()));
            //$ }
            //$ Observable<String> locationObs = Observable.Just(Inner.Location());
            //$ if (Inner.Location() == null) {
            //$ locationObs = myManager.AppServicePlans().GetByIdAsync(Inner.ServerFarmId())
            //$ .Map(new Func1<AppServicePlan, String>() {
            //$ @Override
            //$ public String call(AppServicePlan appServicePlan) {
            //$ return appServicePlan.RegionName();
            //$ }
            //$ });
            //$ }
            //$ locationObs = locationObs.Map(new Func1<String, String>() {
            //$ @Override
            //$ public String call(String s) {
            //$ Inner.WithLocation(s);
            //$ if (sourceControl != null) {
            //$ sourceControl.Inner.WithLocation(s);
            //$ }
            //$ if (Inner.SiteConfig() != null) {
            //$ Inner.SiteConfig().WithLocation(s);
            //$ }
            //$ return s;
            //$ }
            //$ });
            //$ // Construct web app observable
            //$ return locationObs.FlatMap(new Func1<String, Observable<SiteInner>>() {
            //$ @Override
            //$ public Observable<SiteInner> call(String s) {
            //$ // Need to send an empty config object for deployment slot
            //$ // creation, otherwise the parent configs are copied
            //$ boolean emptyConfig = Inner.SiteConfig() == null;
            //$ if (emptyConfig) {
            //$ Inner.WithSiteConfig(new SiteConfigInner());
            //$ Inner.SiteConfig().WithLocation(regionName());
            //$ }
            //$ return createOrUpdateInner(Inner)
            //$ .Map(new Func1<SiteInner, SiteInner>() {
            //$ @Override
            //$ public SiteInner call(SiteInner siteInner) {
            //$ if (emptyConfig) {
            //$ Inner.WithSiteConfig(null);
            //$ }
            //$ return siteInner;
            //$ }
            //$ });
            //$ }
            //$ })
            //$ // Submit hostname bindings
            //$ .FlatMap(new Func1<SiteInner, Observable<SiteInner>>() {
            //$ @Override
            //$ public Observable<SiteInner> call( SiteInner site) {
            //$ List<Observable<HostNameBinding>> bindingObservables = new ArrayList<>();
            //$ for (HostNameBindingImpl<FluentT, FluentImplT> binding: hostNameBindingsToCreate.Values()) {
            //$ bindingObservables.Add(Utils.<HostNameBinding>rootResource(binding.CreateAsync()));
            //$ }
            //$ foreach(var binding in hostNameBindingsToDelete)  {
            //$ bindingObservables.Add(deleteHostNameBinding(binding).Map(new Func1<Object, HostNameBinding>() {
            //$ @Override
            //$ public HostNameBinding call(Object o) {
            //$ return null;
            //$ }
            //$ }));
            //$ }
            //$ if (bindingObservables.IsEmpty()) {
            //$ return Observable.Just(site);
            //$ } else {
            //$ return Observable.Zip(bindingObservables, new FuncN<SiteInner>() {
            //$ @Override
            //$ public SiteInner call(Object... args) {
            //$ return site;
            //$ }
            //$ });
            //$ }
            //$ }
            //$ })
            //$ // refresh after hostname bindings
            //$ .FlatMap(new Func1<SiteInner, Observable<SiteInner>>() {
            //$ @Override
            //$ public Observable<SiteInner> call(SiteInner site) {
            //$ return getInner();
            //$ }
            //$ })
            //$ // Submit SSL bindings
            //$ .FlatMap(new Func1<SiteInner, Observable<SiteInner>>() {
            //$ @Override
            //$ public Observable<SiteInner> call( SiteInner siteInner) {
            //$ List<Observable<AppServiceCertificate>> certs = new ArrayList<>();
            //$ for ( HostNameSslBindingImpl<FluentT, FluentImplT> binding : sslBindingsToCreate.Values()) {
            //$ certs.Add(binding.NewCertificate());
            //$ hostNameSslStateMap.Put(binding.Inner.Name(), binding.Inner.WithToUpdate(true));
            //$ }
            //$ siteInner.WithHostNameSslStates(new ArrayList<>(hostNameSslStateMap.Values()));
            //$ if (certs.IsEmpty()) {
            //$ return Observable.Just(siteInner);
            //$ } else {
            //$ return Observable.Zip(certs, new FuncN<SiteInner>() {
            //$ @Override
            //$ public SiteInner call(Object... args) {
            //$ return siteInner;
            //$ }
            //$ }).FlatMap(new Func1<SiteInner, Observable<SiteInner>>() {
            //$ @Override
            //$ public Observable<SiteInner> call(SiteInner inner) {
            //$ return createOrUpdateInner(inner);
            //$ }
            //$ });
            //$ }
            //$ }
            //$ })
            //$ // submit config
            //$ .FlatMap(new Func1<SiteInner, Observable<SiteInner>>() {
            //$ @Override
            //$ public Observable<SiteInner> call( SiteInner siteInner) {
            //$ if (Inner.SiteConfig() == null) {
            //$ return Observable.Just(siteInner);
            //$ }
            //$ return createOrUpdateSiteConfig(Inner.SiteConfig())
            //$ .FlatMap(new Func1<SiteConfigInner, Observable<SiteInner>>() {
            //$ @Override
            //$ public Observable<SiteInner> call(SiteConfigInner siteConfigInner) {
            //$ siteInner.WithSiteConfig(siteConfigInner);
            //$ return Observable.Just(siteInner);
            //$ }
            //$ });
            //$ }
            //$ })
            //$ // app settings
            //$ .FlatMap(new Func1<SiteInner, Observable<SiteInner>>() {
            //$ @Override
            //$ public Observable<SiteInner> call( SiteInner inner) {
            //$ Observable<SiteInner> observable = Observable.Just(inner);
            //$ if (!appSettingsToAdd.IsEmpty() || !appSettingsToRemove.IsEmpty()) {
            //$ observable = listAppSettings()
            //$ .FlatMap(new Func1<StringDictionaryInner, Observable<StringDictionaryInner>>() {
            //$ @Override
            //$ public Observable<StringDictionaryInner> call(StringDictionaryInner stringDictionaryInner) {
            //$ if (stringDictionaryInner == null) {
            //$ stringDictionaryInner = new StringDictionaryInner();
            //$ stringDictionaryInner.WithLocation(regionName());
            //$ }
            //$ if (stringDictionaryInner.Properties() == null) {
            //$ stringDictionaryInner.WithProperties(new HashMap<String, String>());
            //$ }
            //$ stringDictionaryInner.Properties().PutAll(appSettingsToAdd);
            //$ foreach(var appSettingKey in appSettingsToRemove)  {
            //$ stringDictionaryInner.Properties().Remove(appSettingKey);
            //$ }
            //$ return updateAppSettings(stringDictionaryInner);
            //$ }
            //$ }).Map(new Func1<StringDictionaryInner, SiteInner>() {
            //$ @Override
            //$ public SiteInner call(StringDictionaryInner stringDictionaryInner) {
            //$ return inner;
            //$ }
            //$ });
            //$ }
            //$ return observable;
            //$ }
            //$ })
            //$ // connection strings
            //$ .FlatMap(new Func1<SiteInner, Observable<SiteInner>>() {
            //$ @Override
            //$ public Observable<SiteInner> call( SiteInner inner) {
            //$ Observable<SiteInner> observable = Observable.Just(inner);
            //$ if (!connectionStringsToAdd.IsEmpty() || !connectionStringsToRemove.IsEmpty()) {
            //$ observable = listConnectionStrings()
            //$ .FlatMap(new Func1<ConnectionStringDictionaryInner, Observable<ConnectionStringDictionaryInner>>() {
            //$ @Override
            //$ public Observable<ConnectionStringDictionaryInner> call(ConnectionStringDictionaryInner dictionaryInner) {
            //$ if (dictionaryInner == null) {
            //$ dictionaryInner = new ConnectionStringDictionaryInner();
            //$ dictionaryInner.WithLocation(regionName());
            //$ }
            //$ if (dictionaryInner.Properties() == null) {
            //$ dictionaryInner.WithProperties(new HashMap<String, ConnStringValueTypePair>());
            //$ }
            //$ dictionaryInner.Properties().PutAll(connectionStringsToAdd);
            //$ foreach(var connectionString in connectionStringsToRemove)  {
            //$ dictionaryInner.Properties().Remove(connectionString);
            //$ }
            //$ return updateConnectionStrings(dictionaryInner);
            //$ }
            //$ }).Map(new Func1<ConnectionStringDictionaryInner, SiteInner>() {
            //$ @Override
            //$ public SiteInner call(ConnectionStringDictionaryInner stringDictionaryInner) {
            //$ return inner;
            //$ }
            //$ });
            //$ }
            //$ return observable;
            //$ }
            //$ })
            //$ // app setting & connection string stickiness
            //$ .FlatMap(new Func1<SiteInner, Observable<SiteInner>>() {
            //$ @Override
            //$ public Observable<SiteInner> call( SiteInner inner) {
            //$ Observable<SiteInner> observable = Observable.Just(inner);
            //$ if (!appSettingStickiness.IsEmpty() || !connectionStringStickiness.IsEmpty()) {
            //$ observable = listSlotConfigurations()
            //$ .FlatMap(new Func1<SlotConfigNamesResourceInner, Observable<SlotConfigNamesResourceInner>>() {
            //$ @Override
            //$ public Observable<SlotConfigNamesResourceInner> call(SlotConfigNamesResourceInner slotConfigNamesResourceInner) {
            //$ if (slotConfigNamesResourceInner == null) {
            //$ slotConfigNamesResourceInner = new SlotConfigNamesResourceInner();
            //$ slotConfigNamesResourceInner.WithLocation(regionName());
            //$ }
            //$ if (slotConfigNamesResourceInner.AppSettingNames() == null) {
            //$ slotConfigNamesResourceInner.WithAppSettingNames(new ArrayList<String>());
            //$ }
            //$ if (slotConfigNamesResourceInner.ConnectionStringNames() == null) {
            //$ slotConfigNamesResourceInner.WithConnectionStringNames(new ArrayList<String>());
            //$ }
            //$ Set<String> stickyAppSettingKeys = new HashSet<>(slotConfigNamesResourceInner.AppSettingNames());
            //$ Set<String> stickyConnectionStringNames = new HashSet<>(slotConfigNamesResourceInner.ConnectionStringNames());
            //$ for (Map.Entry<String, Boolean> stickiness : appSettingStickiness.EntrySet()) {
            //$ if (stickiness.GetValue()) {
            //$ stickyAppSettingKeys.Add(stickiness.GetKey());
            //$ } else {
            //$ stickyAppSettingKeys.Remove(stickiness.GetKey());
            //$ }
            //$ }
            //$ for (Map.Entry<String, Boolean> stickiness : connectionStringStickiness.EntrySet()) {
            //$ if (stickiness.GetValue()) {
            //$ stickyConnectionStringNames.Add(stickiness.GetKey());
            //$ } else {
            //$ stickyConnectionStringNames.Remove(stickiness.GetKey());
            //$ }
            //$ }
            //$ slotConfigNamesResourceInner.WithAppSettingNames(new ArrayList<>(stickyAppSettingKeys));
            //$ slotConfigNamesResourceInner.WithConnectionStringNames(new ArrayList<>(stickyConnectionStringNames));
            //$ return updateSlotConfigurations(slotConfigNamesResourceInner);
            //$ }
            //$ }).Map(new Func1<SlotConfigNamesResourceInner, SiteInner>() {
            //$ @Override
            //$ public SiteInner call(SlotConfigNamesResourceInner slotConfigNamesResourceInner) {
            //$ return inner;
            //$ }
            //$ });
            //$ }
            //$ return observable;
            //$ }
            //$ })
            //$ // create source control
            //$ .FlatMap(new Func1<SiteInner, Observable<SiteInner>>() {
            //$ @Override
            //$ public Observable<SiteInner> call( SiteInner inner) {
            //$ if (sourceControl == null || sourceControlToDelete) {
            //$ return Observable.Just(inner);
            //$ }
            //$ return sourceControl.RegisterGithubAccessToken()
            //$ .FlatMap(new Func1<SourceControlInner, Observable<SiteSourceControlInner>>() {
            //$ @Override
            //$ public Observable<SiteSourceControlInner> call(SourceControlInner sourceControlInner) {
            //$ return createOrUpdateSourceControl(sourceControl.Inner);
            //$ }
            //$ })
            //$ .Map(new Func1<SiteSourceControlInner, SiteInner>() {
            //$ @Override
            //$ public SiteInner call(SiteSourceControlInner siteSourceControlInner) {
            //$ return inner;
            //$ }
            //$ });
            //$ }
            //$ })
            //$ // delete source control
            //$ .FlatMap(new Func1<SiteInner, Observable<SiteInner>>() {
            //$ @Override
            //$ public Observable<SiteInner> call( SiteInner inner) {
            //$ if (!sourceControlToDelete) {
            //$ return Observable.Just(inner);
            //$ }
            //$ return deleteSourceControl().Map(new Func1<Void, SiteInner>() {
            //$ @Override
            //$ public SiteInner call(Void aVoid) {
            //$ return inner;
            //$ }
            //$ });
            //$ }
            //$ })
            //$ // convert from inner
            //$ .Map(new Func1<SiteInner, FluentT>() {
            //$ @Override
            //$ public FluentT call(SiteInner siteInner) {
            //$ setInner(siteInner);
            //$ return normalizeProperties();
            //$ }
            //$ }).FlatMap(new Func1<FluentT, Observable<FluentT>>() {
            //$ @Override
            //$ public Observable<FluentT> call(FluentT fluentT) {
            //$ return cacheAppSettingsAndConnectionStrings();
            //$ }
            //$ });

            return null;
        }

        ///GENMHASH:339A48BAE1EB5ED9A9975C86986C944F:C86BE9E21375ED5DE08698ADE36B0A6F
        public FluentImplT WithDefaultDocuments(IList<string> documents)
        {
            //$ public FluentImplT withDefaultDocuments(List<String> documents) {
            //$ if (Inner.SiteConfig() == null) {
            //$ Inner.WithSiteConfig(new SiteConfigInner());
            //$ }
            //$ if (Inner.SiteConfig().DefaultDocuments() == null) {
            //$ Inner.SiteConfig().WithDefaultDocuments(new ArrayList<String>());
            //$ }
            //$ Inner.SiteConfig().DefaultDocuments().AddAll(documents);
            //$ return (FluentImplT) this;

            return default(FluentImplT);
        }

        ///GENMHASH:C28CFF58037291E413815C4EF2BAABEF:EBDDE82BE8301DB6D256FC6EC3761C28
        public SiteAvailabilityState AvailabilityState()
        {
            //$ return Inner.AvailabilityState();

            return SiteAvailabilityState.NORMAL;
        }

        ///GENMHASH:9D3A5AED4F45DE4D03626B77E8ADB8A2:D9D302D7384414CD7579755B13976527
        public bool HostNamesDisabled()
        {
            //$ return false;

            return false;
        }

        ///GENMHASH:640AF2322AF44FB1653F02E5B958A86A:32901B4F001F2D3B8C6B7E60929A323B
        public FluentImplT WithConnectionString(string name, string value, ConnectionStringType type)
        {
            //$ public FluentImplT withConnectionString(String name, String value, ConnectionStringType type) {
            //$ connectionStringsToAdd.Put(name, new ConnStringValueTypePair().WithValue(value).WithType(type));
            //$ return (FluentImplT) this;

            return default(FluentImplT);
        }

        ///GENMHASH:D101C73F080409B39A67AF00AD9821C6:6F295C3A8A7CB5E19AB918210E36BC1D
        public ManagedPipelineMode ManagedPipelineMode()
        {
            //$ if (Inner.SiteConfig() == null) {
            //$ return null;
            //$ }
            //$ return Inner.SiteConfig().ManagedPipelineMode();

            return ManagedPipelineMode.INTEGRATED;
        }

        ///GENMHASH:04BAD2602CA77ACE8B99D7FDF38E6CF1:2CECFA457ECE4652D16C54B3FE56ACBA
        public CloningInfo CloningInfo()
        {
            //$ return Inner.CloningInfo();

            return null;
        }

        ///GENMHASH:7A9C4AE49E1FF4C1924129FA0CAB5C2E:9F6EAFAD4C4AB8232788CE42F4212939
        public UsageState UsageState()
        {
            //$ return Inner.UsageState();

            return UsageState.NORMAL;
        }

        ///GENMHASH:6D530E5D2820D0FC31597444F5546CB5:44CE23E03A8BF27E78EB1F1D7D03D969
        public string GatewaySiteName()
        {
            //$ return Inner.GatewaySiteName();

            return null;
        }

        ///GENMHASH:19DC73910D23C00F8667540D0CBD0AEC:5D6124142B08C7816B4D9A638C461920
        public JavaVersion JavaVersion()
        {
            //$ if (Inner.SiteConfig() == null || Inner.SiteConfig().JavaVersion() == null) {
            //$ return JavaVersion.OFF;
            //$ }
            //$ return new JavaVersion(Inner.SiteConfig().JavaVersion());

            return null;
        }

        ///GENMHASH:16DA81E02BFF9B1983571901E1CA6AB9:D68A946D17769FFBF0FF5DAAE2212551
        public string DefaultHostName()
        {
            //$ return Inner.DefaultHostName();

            return null;
        }

        ///GENMHASH:7A3D1E4A59735B1A92153B49F406A2EA:D3BD1FCEC94D233A323B882DA914CD12
        public FluentImplT WithAppSettings(IDictionary<string,string> settings)
        {
            //$ public FluentImplT withAppSettings(Map<String, String> settings) {
            //$ appSettingsToAdd.PutAll(settings);
            //$ return (FluentImplT) this;

            return default(FluentImplT);
        }

        ///GENMHASH:CFB093F74965BAD2150F4041715B9A85:26C83F8A1A14CE55546ED814DB69FDDC
        public string JavaContainer()
        {
            //$ if (Inner.SiteConfig() == null) {
            //$ return null;
            //$ }
            //$ return Inner.SiteConfig().JavaContainer();

            return null;
        }

        ///GENMHASH:BFDA79902F6BE9566899DA86DF88D0D8:DF03AD72AC444A097819590079C05599
        public FluentImplT WithoutSourceControl()
        {
            //$ public FluentImplT withoutSourceControl() {
            //$ sourceControlToDelete = true;
            //$ return (FluentImplT) this;

            return default(FluentImplT);
        }

        ///GENMHASH:935E8A144BD263041B17092AD69A49F8:35A7425E491FC92395143FBA3E878748
        public ISet<string> HostNames()
        {
            //$ return Collections.UnmodifiableSet(hostNamesSet);

            return null;
        }

        ///GENMHASH:23406BAAD05E75776B2C2D57DAD6EC31:20D62AB87640E86D7C2ED3CD5286A461
        public IList<string> DefaultDocuments()
        {
            //$ if (Inner.SiteConfig() == null) {
            //$ return null;
            //$ }
            //$ return Collections.UnmodifiableList(Inner.SiteConfig().DefaultDocuments());

            return null;
        }

        ///GENMHASH:48A4E53CFF08718D61958E4C92100018:A9C012D7912C454FA087C8D68B4B602F
        public string MicroService()
        {
            //$ return Inner.MicroService();

            return null;
        }

        ///GENMHASH:8B6374B8DE9FB105A8A4FE1AC98E0A32:26E0CCD0FFBC820C6C211AAEFBB00D18
        public FluentImplT WithPlatformArchitecture(PlatformArchitecture platform)
        {
            //$ public FluentImplT withPlatformArchitecture(PlatformArchitecture platform) {
            //$ if (Inner.SiteConfig() == null) {
            //$ Inner.WithSiteConfig(new SiteConfigInner());
            //$ }
            //$ Inner.SiteConfig().WithUse32BitWorkerProcess(platform.Equals(PlatformArchitecture.X86));
            //$ return (FluentImplT) this;

            return default(FluentImplT);
        }

        ///GENMHASH:0326165974AFF6C272DF7A9B97057A14:A5822AF23DD5553DE60CAAA635E71F67
        public FluentImplT WithNetFrameworkVersion(NetFrameworkVersion version)
        {
            //$ public FluentImplT withNetFrameworkVersion(NetFrameworkVersion version) {
            //$ if (Inner.SiteConfig() == null) {
            //$ Inner.WithSiteConfig(new SiteConfigInner());
            //$ }
            //$ Inner.SiteConfig().WithNetFrameworkVersion(version.ToString());
            //$ return (FluentImplT) this;

            return default(FluentImplT);
        }

        ///GENMHASH:A7C75BEA6A6C2CBCEF6C124C164A8BF5:3146F8F0F41CCE0E8CC45456DD403ED8
        public FluentImplT WithoutHostnameBinding(string hostname)
        {
            //$ public FluentImplT withoutHostnameBinding(String hostname) {
            //$ hostNameBindingsToDelete.Add(hostname);
            //$ return (FluentImplT) this;

            return default(FluentImplT);
        }

        ///GENMHASH:5ED618DE41DCDE9DBC9F8179EF143BC3:557EA663C067393DFFE5A95D51F6FABC
        public DateTime LastModifiedTime()
        {
            //$ return Inner.LastModifiedTimeUtc();

            return DateTime.Now;
        }

        ///GENMHASH:B37CF91380CE58F97FF98F833D067DB4:04E6E9F28F72119837F1EA6B5B69BD0F
        public FluentImplT WithoutConnectionString(string name)
        {
            //$ public FluentImplT withoutConnectionString(String name) {
            //$ connectionStringsToRemove.Add(name);
            //$ connectionStringStickiness.Remove(name);
            //$ return (FluentImplT) this;

            return default(FluentImplT);
        }

        ///GENMHASH:C8FAEA7DC8B31D619F885C64E56A6686:9896B5012319AD936FC829F4017BFCF9
        public PhpVersion PhpVersion()
        {
            //$ if (Inner.SiteConfig() == null || Inner.SiteConfig().PhpVersion() == null) {
            //$ return PhpVersion.OFF;
            //$ }
            //$ return new PhpVersion(Inner.SiteConfig().PhpVersion());

            return null;
        }

        ///GENMHASH:AED7BB300F28210D7E0EDA08BF191BDC:140BC7A2AF1C0E354A00FC241D95FE70
        public ISet<string> TrafficManagerHostNames()
        {
            //$ return Collections.UnmodifiableSet(trafficManagerHostNamesSet);

            return null;
        }

        ///GENMHASH:878245C0E417BE8C2AC326900DCD99C2:CCE8D28FDD1DCE271666ADF7E0B188C9
        public bool ScmSiteAlsoStopped()
        {
            //$ return Inner.ScmSiteAlsoStopped();

            return false;
        }

        ///GENMHASH:B2C0373522058958F4115A63609B90C1:C3580B34803FD62C1976A18A7581AA0B
        public HostNameSslBindingImpl<FluentT,FluentImplT> DefineSslBinding()
        {
            //$ public HostNameSslBindingImpl<FluentT, FluentImplT> defineSslBinding() {
            //$ return new HostNameSslBindingImpl<>(new HostNameSslState(), (FluentImplT) this, myManager);

            return null;
        }

        ///GENMHASH:9C834AC4DD619BA31DBCFAAB13EE9923:914A632A86CAEA343D26353F278D7305
        public FluentImplT WithClientAffinityEnabled(bool enabled)
        {
            //$ public FluentImplT withClientAffinityEnabled(boolean enabled) {
            //$ Inner.WithClientAffinityEnabled(enabled);
            //$ return (FluentImplT) this;

            return default(FluentImplT);
        }

        ///GENMHASH:E9F49502899B96A687DA858A6BE8647D:14B808B9FEDFD8512C02B321FDC1D222
        public FluentImplT WithAppDisabledOnCreation()
        {
            //$ public FluentImplT withAppDisabledOnCreation() {
            //$ Inner.WithEnabled(false);
            //$ return (FluentImplT) this;

            return default(FluentImplT);
        }

        ///GENMHASH:62A0C790E618C837459BE1A5103CA0E5:27E486AB74A10242FF421C0798DDC450
        internal abstract async Task<Microsoft.Azure.Management.AppService.Fluent.Models.SlotConfigNamesResourceInner> ListSlotConfigurationsAsync(CancellationToken cancellationToken = default(CancellationToken));

        ///GENMHASH:845984DE82811B6BF5DE9676CE5B433A:6A4C5D736C724933B8B06C102140E89D
        public FluentImplT WithoutAppSetting(string key)
        {
            //$ public FluentImplT withoutAppSetting(String key) {
            //$ appSettingsToRemove.Add(key);
            //$ appSettingStickiness.Remove(key);
            //$ return (FluentImplT) this;

            return default(FluentImplT);
        }

        ///GENMHASH:F49A26C57ADD85EB4F774AACF7455EA0:8C65401DDB5F058E55EDB8D8C3E3DFAA
        public RemoteVisualStudioVersion RemoteDebuggingVersion()
        {
            //$ if (Inner.SiteConfig() == null) {
            //$ return null;
            //$ }
            //$ return new RemoteVisualStudioVersion(Inner.SiteConfig().RemoteDebuggingVersion());

            return null;
        }

        ///GENMHASH:F5F1D8F285012204F1326EAA44BBE26E:D7E5D52A8F2DD57221DA3F2B254FDF7F
        public WebAppSourceControlImpl<FluentT,FluentImplT> DefineSourceControl()
        {
            //$ return new WebAppSourceControlImpl<>(new SiteSourceControlInner(), this, serviceClient);

            return null;
        }

        ///GENMHASH:1703877FCECC33D73EA04EEEF89045EF:A93CDCF3EC94A75CDDBFCAC39CD42834
        public bool Enabled()
        {
            //$ return Inner.Enabled();

            return false;
        }

        ///GENMHASH:78FD17A2E22E150AD12AA226D4123829:29A4403ED56D639EA144EEEF29FB711D
        public FluentImplT WithJavaVersion(JavaVersion version)
        {
            //$ public FluentImplT withJavaVersion(JavaVersion version) {
            //$ if (Inner.SiteConfig() == null) {
            //$ Inner.WithSiteConfig(new SiteConfigInner());
            //$ }
            //$ Inner.SiteConfig().WithJavaVersion(version.ToString());
            //$ return (FluentImplT) this;

            return default(FluentImplT);
        }

        ///GENMHASH:62F8B201D885123D1E906E306D144662:27E486AB74A10242FF421C0798DDC450
        internal abstract async Task<Microsoft.Azure.Management.AppService.Fluent.Models.SlotConfigNamesResourceInner> UpdateSlotConfigurationsAsync(SlotConfigNamesResourceInner inner, CancellationToken cancellationToken = default(CancellationToken));

        ///GENMHASH:3BE74CEDB189CF13F08D5268649B73D7:FBDC4182C8802269267E808E13D08A16
        public IReadOnlyDictionary<string,Microsoft.Azure.Management.Appservice.Fluent.IAppSetting> AppSettings()
        {
            //$ return cachedAppSettings;

            return null;
        }

        ///GENMHASH:256905D5B839C64BFE9830503CB5607B:27E486AB74A10242FF421C0798DDC450
        internal abstract async Task<Microsoft.Azure.Management.AppService.Fluent.Models.SiteConfigInner> GetConfigInnerAsync(CancellationToken cancellationToken = default(CancellationToken));

        ///GENMHASH:F76B0B1D4816856D9C8EA506F611C03D:91C46F0ECB5CC2D51804D2C0710E6211
        public FluentImplT WithoutSslBinding(string hostname)
        {
            //$ public FluentImplT withoutSslBinding(String hostname) {
            //$ if (hostNameSslStateMap.ContainsKey(hostname)) {
            //$ hostNameSslStateMap.Get(hostname).WithSslState(SslState.DISABLED).WithToUpdate(true);
            //$ }
            //$ return (FluentImplT) this;

            return default(FluentImplT);
        }

        ///GENMHASH:D40FFC05002182B6125DEE214DFC3DA1:3174BE5D31FA791191831DEA6009CCC4
        public bool ClientCertEnabled()
        {
            //$ return Inner.ClientCertEnabled();

            return false;
        }

        ///GENMHASH:37E27ADFB836BE1FD0A02912DEE9E60B:8A1A421381B060FE80BB398E975836CB
        public FluentImplT WithStickyAppSettings(IDictionary<string,string> settings)
        {
            //$ public FluentImplT withStickyAppSettings(Map<String, String> settings) {
            //$ withAppSettings(settings);
            //$ appSettingStickiness.PutAll(Maps.AsMap(settings.KeySet(), new Function<String, Boolean>() {
            //$ @Override
            //$ public Boolean apply(String input) {
            //$ return true;
            //$ }
            //$ }));
            //$ return (FluentImplT) this;

            return default(FluentImplT);
        }

        ///GENMHASH:9EC0529BA0D08B75AD65E98A4BA01D5D:27E486AB74A10242FF421C0798DDC450
        internal abstract async Task<Microsoft.Azure.Management.AppService.Fluent.Models.SiteInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken));

        ///GENMHASH:C102774B5B56F13DBA5095A48DC5F846:1886C5FB5632B7468462889794AFEA08
        public NetFrameworkVersion NetFrameworkVersion()
        {
            //$ if (Inner.SiteConfig() == null) {
            //$ return null;
            //$ }
            //$ return new NetFrameworkVersion(Inner.SiteConfig().NetFrameworkVersion());

            return null;
        }

        ///GENMHASH:0A3B342EB54A6BB9B919686055C77154:D71C3ABF670D7D6382F65A18153CE77F
        internal WebAppBaseImpl<FluentT,FluentImplT> WithNewHostNameSslBinding(HostNameSslBindingImpl<FluentT,FluentImplT> hostNameSslBinding)
        {
            //$ if (hostNameSslBinding.NewCertificate() != null) {
            //$ sslBindingsToCreate.Put(hostNameSslBinding.Name(), hostNameSslBinding);
            //$ }
            //$ return this;
            //$ }

            return this;
        }

        ///GENMHASH:EDB4EABD52D790D7204DF4CACC39D04A:4469898682437D64D221DD7583D2B354
        public FluentImplT WithAutoSwapSlotName(string slotName)
        {
            //$ public FluentImplT withAutoSwapSlotName(String slotName) {
            //$ if (Inner.SiteConfig() == null) {
            //$ Inner.WithSiteConfig(new SiteConfigInner());
            //$ }
            //$ Inner.SiteConfig().WithAutoSwapSlotName(slotName);
            //$ return (FluentImplT) this;

            return default(FluentImplT);
        }

        ///GENMHASH:750A632B5F062E375E30024C56379A8E:39DCD28D9DEDDE14FCCB5F803750A6BE
        public string NodeVersion()
        {
            //$ if (Inner.SiteConfig() == null) {
            //$ return null;
            //$ }
            //$ return Inner.SiteConfig().NodeVersion();

            return null;
        }

        ///GENMHASH:07FBC6D492A2E1E463B39D4D7FFC40E9:27E486AB74A10242FF421C0798DDC450
        internal abstract async Task<Microsoft.Azure.Management.AppService.Fluent.Models.SiteInner> CreateOrUpdateInnerAsync(SiteInner site, CancellationToken cancellationToken = default(CancellationToken));

        ///GENMHASH:FA07D0476A4A7B9F0FDA17B8DF0095F1:FC345DE9B0C87952B3DE42BCE0488ECD
        public IReadOnlyDictionary<string,Microsoft.Azure.Management.Appservice.Fluent.IConnectionString> ConnectionStrings()
        {
            //$ return cachedConnectionStrings;

            return null;
        }

        ///GENMHASH:88806945F575AAA522C2E09EBC366CC0:27E486AB74A10242FF421C0798DDC450
        internal abstract async Task<Microsoft.Azure.Management.AppService.Fluent.Models.SiteSourceControlInner> CreateOrUpdateSourceControlAsync(SiteSourceControlInner inner, CancellationToken cancellationToken = default(CancellationToken));

        ///GENMHASH:B0ECE8043B59B23D8A941C8FB1327608:F6986D710A3CD05509C969004E265D9B
        internal  WebAppBaseImpl(string name, SiteInner innerObject, SiteConfigInner configObject, WebAppsInner client, AppServiceManager manager, WebSiteManagementClientImpl serviceClient)
        {
            //$ super(name, innerObject, manager);
            //$ this.client = client;
            //$ this.serviceClient = serviceClient;
            //$ this.Inner.WithSiteConfig(configObject);
            //$ normalizeProperties();
            //$ }

        }

        ///GENMHASH:3A1ECB38842D1F307BEAA5CE89B8D9A9:37E20E73C6553EB8ECA43CDD3E03DF88
        public FluentImplT WithScmSiteAlsoStopped(bool scmSiteAlsoStopped)
        {
            //$ public FluentImplT withScmSiteAlsoStopped(boolean scmSiteAlsoStopped) {
            //$ Inner.WithScmSiteAlsoStopped(scmSiteAlsoStopped);
            //$ return (FluentImplT) this;

            return default(FluentImplT);
        }

        ///GENMHASH:88FB986A040F70D62E535B947213D4C9:872EB6D779CA1F073EAE994BA5E1A2D8
        public string AutoSwapSlotName()
        {
            //$ if (Inner.SiteConfig() == null) {
            //$ return null;
            //$ }
            //$ return Inner.SiteConfig().AutoSwapSlotName();

            return null;
        }

        ///GENMHASH:C3A15726A3EC798F48295A8FF0867A0B:7C9DD6C2A7609244E63D0353EBF87B3B
        public FluentImplT WithPhpVersion(PhpVersion version)
        {
            //$ public FluentImplT withPhpVersion(PhpVersion version) {
            //$ if (Inner.SiteConfig() == null) {
            //$ Inner.WithSiteConfig(new SiteConfigInner());
            //$ }
            //$ Inner.SiteConfig().WithPhpVersion(version.ToString());
            //$ return (FluentImplT) this;

            return default(FluentImplT);
        }

        ///GENMHASH:4217B9DCD795EFEFA0771FDE182F0DF5:156FC00C236BFE0C12D023AABE135F63
        public FluentImplT WithManagedHostnameBindings(IAppServiceDomain domain, params string[] hostnames)
        {
            //$ public FluentImplT withManagedHostnameBindings(AppServiceDomain domain, String... hostnames) {
            //$ foreach(var hostname in hostnames)  {
            //$ if (hostname.Equals("@") || hostname.EqualsIgnoreCase(domain.Name())) {
            //$ defineHostnameBinding()
            //$ .WithAzureManagedDomain(domain)
            //$ .WithSubDomain(hostname)
            //$ .WithDnsRecordType(CustomHostNameDnsRecordType.A)
            //$ .Attach();
            //$ } else {
            //$ defineHostnameBinding()
            //$ .WithAzureManagedDomain(domain)
            //$ .WithSubDomain(hostname)
            //$ .WithDnsRecordType(CustomHostNameDnsRecordType.CNAME)
            //$ .Attach();
            //$ }
            //$ }
            //$ return (FluentImplT) this;

            return default(FluentImplT);
        }

        ///GENMHASH:AEE17FD09F624712647F5EBCEC141EA5:A2B4C8D5515FE0A160E2214A60FB99A6
        public string State()
        {
            //$ return Inner.State();

            return null;
        }

        ///GENMHASH:B1A8B6AF0882F87FF978C572DA7F4B5C:CA993290F5DD317A425ED88E1175A1D9
        public FluentImplT WithWebSocketsEnabled(bool enabled)
        {
            //$ public FluentImplT withWebSocketsEnabled(boolean enabled) {
            //$ if (Inner.SiteConfig() == null) {
            //$ Inner.WithSiteConfig(new SiteConfigInner());
            //$ }
            //$ Inner.SiteConfig().WithWebSocketsEnabled(enabled);
            //$ return (FluentImplT) this;

            return default(FluentImplT);
        }

        ///GENMHASH:DBBC1639A411401B52B0F804284263EE:473779DF0D6351D3FEF135C14773DB4F
        public bool AlwaysOn()
        {
            //$ if (Inner.SiteConfig() == null) {
            //$ return false;
            //$ }
            //$ return Utils.ToPrimitiveBoolean(Inner.SiteConfig().AlwaysOn());

            return false;
        }

        ///GENMHASH:6799EDFB0B008F8C0EB7E07EE71E6B34:27E486AB74A10242FF421C0798DDC450
        internal abstract async Task<Microsoft.Azure.Management.AppService.Fluent.Models.SiteConfigInner> CreateOrUpdateSiteConfigAsync(SiteConfigInner siteConfig, CancellationToken cancellationToken = default(CancellationToken));

        ///GENMHASH:FA11486B840C0E86D3D1A446BF2A3C96:AA358901B07077B2692CB317CAFFF60D
        public FluentImplT WithStickyAppSetting(string key, string value)
        {
            //$ withAppSetting(key, value);
            //$ return withAppSettingStickiness(key, true);

            return default(FluentImplT);
        }

        ///GENMHASH:58B5A5808212C5DA86843A18CE1F067F:455C7DE078AA851CB5C8F39D0A9260A1
        public string TargetSwapSlot()
        {
            //$ return Inner.TargetSwapSlot();

            return null;
        }

        ///GENMHASH:3BBC37006EE11765DF55134711F9E6D9:86A9DA70332D3F08A24CC84ED1EBFE15
        public FluentImplT WithoutPhp()
        {
            //$ return withPhpVersion(new PhpVersion(""));

            return default(FluentImplT);
        }

        ///GENMHASH:04497E34F1930C831D67A21169FA28E0:5719C33FC3EAF071BCAD1249F58B0A1F
        public string AppServicePlanId()
        {
            //$ return Inner.ServerFarmId();

            return null;
        }

        ///GENMHASH:F63CA8A7D8722945AE86442FAAE62963:837E0749902A7C8B46678D5899F91E3A
        public bool RemoteDebuggingEnabled()
        {
            //$ if (Inner.SiteConfig() == null) {
            //$ return false;
            //$ }
            //$ return Utils.ToPrimitiveBoolean(Inner.SiteConfig().RemoteDebuggingEnabled());

            return false;
        }

        ///GENMHASH:13FED596F6C9DDEA581391D2291A4AB1:7DD021B685AC511232E39D9D870512E3
        public FluentImplT WithWebContainer(WebContainer webContainer)
        {
            //$ public FluentImplT withWebContainer(WebContainer webContainer) {
            //$ if (Inner.SiteConfig() == null) {
            //$ Inner.WithSiteConfig(new SiteConfigInner());
            //$ }
            //$ if (webContainer == null) {
            //$ Inner.SiteConfig().WithJavaContainer(null);
            //$ Inner.SiteConfig().WithJavaContainerVersion(null);
            //$ } else {
            //$ String[] containerInfo = webContainer.ToString().Split(" ");
            //$ Inner.SiteConfig().WithJavaContainer(containerInfo[0]);
            //$ Inner.SiteConfig().WithJavaContainerVersion(containerInfo[1]);
            //$ }
            //$ return (FluentImplT) this;

            return default(FluentImplT);
        }

        ///GENMHASH:0FE78F842439357DA0333AABD3B95D59:27E486AB74A10242FF421C0798DDC450
        internal abstract async Task<Microsoft.Azure.Management.AppService.Fluent.Models.ConnectionStringDictionaryInner> ListConnectionStringsAsync(CancellationToken cancellationToken = default(CancellationToken));

        ///GENMHASH:6CAC70824B4E95B3FC2D7FE1CE29759E:513EF027EB09EB5FEC6C661F74328B72
        public bool ClientAffinityEnabled()
        {
            //$ return Inner.ClientAffinityEnabled();

            return false;
        }

        ///GENMHASH:44E1562BA49E879B6BD3110F47EE24D2:56752CC2EF6BC17A058EFBD8726E81AF
        internal FluentImplT WithHostNameBinding(HostNameBindingImpl<FluentT,FluentImplT> hostNameBinding)
        {
            //$ this.hostNameBindingsToCreate.Put(
            //$ hostNameBinding.Name(),
            //$ hostNameBinding);
            //$ return (FluentImplT) this;

            return default(FluentImplT);
        }

        ///GENMHASH:C82AC013C402054BF54C48891EAC7C4E:09A97DDE352A5FE05FF05D87BB65FB03
        public FluentImplT WithWebAppAlwaysOn(bool alwaysOn)
        {
            //$ public FluentImplT withWebAppAlwaysOn(boolean alwaysOn) {
            //$ if (Inner.SiteConfig() == null) {
            //$ Inner.WithSiteConfig(new SiteConfigInner());
            //$ }
            //$ Inner.SiteConfig().WithAlwaysOn(alwaysOn);
            //$ return (FluentImplT) this;

            return default(FluentImplT);
        }

        ///GENMHASH:C2F7B915E364BA07AE840A3986B36AFE:798E625A28DD9AA65131B7A5A1494291
        public IReadOnlyDictionary<string,Microsoft.Azure.Management.AppService.Fluent.Models.HostNameSslState> HostNameSslStates()
        {
            //$ return Collections.UnmodifiableMap(hostNameSslStateMap);

            return null;
        }

        ///GENMHASH:1BEBA30733974CB2A2FB9AC9E036FA93:72C814A27C1E75E81B6BEEBB5056F950
        public bool IsDefaultContainer()
        {
            //$ return Inner.IsDefaultContainer();

            return false;
        }

        ///GENMHASH:09C71E4BDBE3FD33C1FF3F0FCC7511B5:61F56A801796D18DC0D97539EC361EFF
        internal FluentImplT WithSourceControl(WebAppSourceControlImpl<FluentT,FluentImplT> sourceControl)
        {
            //$ this.sourceControl = sourceControl;
            //$ return (FluentImplT) this;

            return default(FluentImplT);
        }

        ///GENMHASH:FCAC8C2F8D6E12CB6F5D7787A2837016:27E486AB74A10242FF421C0798DDC450
        internal abstract async Task DeleteHostNameBindingAsync(string hostname, CancellationToken cancellationToken = default(CancellationToken));
    }
}