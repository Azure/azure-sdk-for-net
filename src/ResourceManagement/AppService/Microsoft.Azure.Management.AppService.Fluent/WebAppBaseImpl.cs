// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Models;
    using WebAppBase.Definition;
    using WebAppBase.Update;
    using ResourceManager.Fluent;
    using System.Collections.Generic;
    using System;
    using System.Linq;
    using ResourceManager.Fluent.Core.Resource.Update;
    using System.Text.RegularExpressions;
    using System.Collections.ObjectModel;

    /// <summary>
    /// The implementation for WebAppBase.
    /// </summary>
    /// <typeparam name="Fluent">The fluent interface of the web app or deployment slot.</typeparam>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmFwcHNlcnZpY2UuaW1wbGVtZW50YXRpb24uV2ViQXBwQmFzZUltcGw=
    internal abstract partial class WebAppBaseImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> :
        GroupableResource<
            FluentT,
            SiteInner,
            FluentImplT,
            IAppServiceManager,
            DefAfterRegionT,
            DefAfterGroupT,
            IWithCreate<FluentT>,
            UpdateT>,
        IWebAppBase,
        IDefinition<FluentT>,
        IUpdate<FluentT>,
        WebAppBase.Definition.IWithWebContainer<FluentT>,
        WebAppBase.Update.IWithWebContainer<FluentT>
        where FluentImplT : WebAppBaseImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT>, FluentT
        where FluentT : class, IWebAppBase
        where DefAfterRegionT : class
        where DefAfterGroupT : class
        where UpdateT : class, IUpdate<FluentT>
    {
        private IDictionary<string, IAppSetting> cachedAppSettings;
        private IDictionary<string, IConnectionString> cachedConnectionStrings;
        private ISet<string> hostNamesSet;
        private ISet<string> enabledHostNamesSet;
        private ISet<string> trafficManagerHostNamesSet;
        private ISet<string> outboundIpAddressesSet;
        private IDictionary<string, HostNameSslState> hostNameSslStateMap;
        private IDictionary<string, HostNameBindingImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT>> hostNameBindingsToCreate;
        private IList<string> hostNameBindingsToDelete;
        private IDictionary<string, HostNameSslBindingImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT>> sslBindingsToCreate;
        private IDictionary<string, string> appSettingsToAdd;
        private IList<string> appSettingsToRemove;
        private IDictionary<string, bool> appSettingStickiness;
        private IDictionary<string, ConnStringValueTypePair> connectionStringsToAdd;
        private IList<string> connectionStringsToRemove;
        private IDictionary<string, bool> connectionStringStickiness;
        private WebAppSourceControlImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> sourceControl;
        private bool sourceControlToDelete;

        ///GENMHASH:6779D3D3C7AB7AAAE805BA0ABEE95C51:27E486AB74A10242FF421C0798DDC450
        internal abstract Task<StringDictionaryInner> UpdateAppSettingsAsync(StringDictionaryInner inner, CancellationToken cancellationToken = default(CancellationToken));

        ///GENMHASH:400B39C84CFE07A8B031B773061CF1BB:54F16B494685A43639288CB0A223084F
        public FluentImplT WithAppSettingStickiness(string key, bool sticky)
        {
            appSettingStickiness[key] = sticky;
            return (FluentImplT)this;
        }

        ///GENMHASH:2EFCE799E63D7CDD5EDE55B1622770C9:936A41F3229D51DDB490CC6CCD933986
        public string RepositorySiteName()
        {
            return Inner.RepositorySiteName;
        }

        ///GENMHASH:5347BC9AA33E4B7344CEB8188EA1DAA3:B3A0F7D2A1C11139E3140FF2DC919CEB
        public FluentImplT WithoutPython()
        {
            return WithPythonVersion(Fluent.PythonVersion.Parse(""));
        }

        ///GENMHASH:B67E95BCEA89D1B6CBB6849249A60D4F:3A1F8EE2D47ED51D598D727D3C3FAA86
        public FluentImplT WithThirdPartyHostnameBinding(string domain, params string[] hostnames)
        {
            foreach (var hostname in hostnames)
            {
                DefineHostnameBinding()
                    .WithThirdPartyDomain(domain)
                    .WithSubDomain(hostname)
                    .WithDnsRecordType(CustomHostNameDnsRecordType.CName)
                    .Attach();
            }
            return (FluentImplT)this;
        }

        ///GENMHASH:620993DCE6DF78140D8125DD97478452:27E486AB74A10242FF421C0798DDC450
        internal abstract Task<StringDictionaryInner> ListAppSettingsAsync(CancellationToken cancellationToken = default(CancellationToken));

        ///GENMHASH:879627C2DAE69433191E7E3A0197FFCB:97444012B93FEF52369A6C980B714A5A
        private FluentT NormalizeProperties()
        {
            this.hostNameBindingsToCreate = new Dictionary<string, HostNameBindingImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT>>();
            this.hostNameBindingsToDelete = new List<string>();
            this.appSettingsToAdd = new Dictionary<string, string>();
            this.appSettingsToRemove = new List<string>();
            this.appSettingStickiness = new Dictionary<string, bool>();
            this.connectionStringsToAdd = new Dictionary<string, ConnStringValueTypePair>();
            this.connectionStringsToRemove = new List<string>();
            this.connectionStringStickiness = new Dictionary<string, bool>();
            this.sourceControl = null;
            this.sourceControlToDelete = false;
            this.sslBindingsToCreate = new Dictionary<string, HostNameSslBindingImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT>>();
            if (Inner.HostNames != null)
            {
                this.hostNamesSet = new HashSet<string>(Inner.HostNames);
            }
            if (Inner.EnabledHostNames != null)
            {
                this.enabledHostNamesSet = new HashSet<string>(Inner.EnabledHostNames);
            }
            if (Inner.TrafficManagerHostNames != null)
            {
                this.trafficManagerHostNamesSet = new HashSet<string>(Inner.TrafficManagerHostNames);
            }
            if (Inner.OutboundIpAddresses != null)
            {
                this.outboundIpAddressesSet = new HashSet<string>(Regex.Split(Inner.OutboundIpAddresses, ",[ ]*"));
            }
            this.hostNameSslStateMap = new Dictionary<string, Microsoft.Azure.Management.AppService.Fluent.Models.HostNameSslState>();
            if (Inner.HostNameSslStates != null) {
                foreach (var hostNameSslState in Inner.HostNameSslStates)
                {
                    // Server returns null sometimes, invalid on update, so we set default
                    if (hostNameSslState.SslState == null)
                    {
                        hostNameSslState.SslState = SslState.Disabled;
                    }
                    hostNameSslStateMap[hostNameSslState.Name] = hostNameSslState;
                }
            }
            return this as FluentT;
        }

        ///GENMHASH:5091CF7FBD481F6A80C8200D77B918B5:86CEE108C820B076B77DA76828966EDD
        public string JavaContainerVersion()
        {
            if (Inner.SiteConfig == null)
            {
                return null;
            }
            return Inner.SiteConfig.JavaContainerVersion;
        }

        ///GENMHASH:807E62B6346803DB90804D0DEBD2FCA6:27E486AB74A10242FF421C0798DDC450
        internal abstract Task DeleteSourceControlAsync(CancellationToken cancellationToken = default(CancellationToken));

        ///GENMHASH:B06FC38A7913CA2F028C97DE025DEED3:0F7ECBEDACE05420A5D0D277D4704257
        public FluentImplT WithStickyConnectionString(string name, string value, ConnectionStringType type)
        {
            connectionStringsToAdd[name] = new ConnStringValueTypePair()
            {
                Value = value,
                Type = type
            };
            connectionStringStickiness[name] = true;
            return (FluentImplT)this;
        }

        ///GENMHASH:0BD0140B6FBB6AA6B83FE90F95878549:855FB47B5269DBB806FE536172AD4F91
        public PythonVersion PythonVersion()
        {
            if (Inner.SiteConfig == null || Inner.SiteConfig.PythonVersion == null)
            {
                return Fluent.PythonVersion.Off;
            }
            return Fluent.PythonVersion.Parse(Inner.SiteConfig.PythonVersion);
        }

        ///GENMHASH:C03B1FAF31FB94362C083BAA7332E4A4:516E9ADDDB1B086B94A185F8CA729E6B
        public FluentImplT WithoutJava()
        {
            return WithJavaVersion(Fluent.JavaVersion.Parse("")).WithWebContainer(null);
        }

        ///GENMHASH:3A0791A760CE20BB60B662E45E1B5A20:AC8556A885DA9E1351FB1A6C074AA07E
        public FluentImplT WithPythonVersion(PythonVersion version)
        {
            if (Inner.SiteConfig == null)
            {
                Inner.SiteConfig = new SiteConfigInner();
            }
            Inner.SiteConfig.PythonVersion = version.ToString();
            return (FluentImplT)this;
        }

        ///GENMHASH:E45783E7B404EC0F4EBC4EE6BA7EF55A:5ECDDE741F87F4634B0FDC94904B2771
        public FluentImplT WithManagedPipelineMode(ManagedPipelineMode managedPipelineMode)
        {
            if (Inner.SiteConfig == null)
            {
                Inner.SiteConfig = new SiteConfigInner();
            }
            Inner.SiteConfig.ManagedPipelineMode = managedPipelineMode;
            return (FluentImplT)this;
        }

        ///GENMHASH:4002186478A1CB0B59732EBFB18DEB3A:75636395FBDB9C1FA7F5231207B98D55
        public override FluentT Refresh()
        {
            ///GENMHASH:9EC0529BA0D08B75AD65E98A4BA01D5D:27E486AB74A10242FF421C0798DDC450
            SiteInner inner = GetInnerAsync().GetAwaiter().GetResult();
            ///GENMHASH:256905D5B839C64BFE9830503CB5607B:27E486AB74A10242FF421C0798DDC450
            inner.SiteConfig = GetConfigInnerAsync().GetAwaiter().GetResult();
            SetInner(inner);
            CacheAppSettingsAndConnectionStringsAsync().GetAwaiter().GetResult();
            return this as FluentT;
        }

        ///GENMHASH:10422D744EF1F162EBE8C9A9FA95C4F1:730A847F06F615063704F0C5FFF2B639
        public ISet<string> OutboundIpAddresses()
        {
            return outboundIpAddressesSet;
        }

        ///GENMHASH:4380B7AB34BB7338E16329242A2DB73A:399A7EDDE163BD102BD7A221C0EF6472
        public bool WebSocketsEnabled()
        {
            if (Inner.SiteConfig == null || Inner.SiteConfig.WebSocketsEnabled == null)
            {
                return false;
            }
            return (bool)Inner.SiteConfig.WebSocketsEnabled;
        }

        ///GENMHASH:994878BE86A846414AFCBD6D6A774106:7DFE5AF818EC3EFB7C159495BCF92C41
        public int ContainerSize()
        {
            if (Inner.ContainerSize == null)
            {
                return 0;
            }
            else
            {
                return (int)Inner.ContainerSize;
            }
        }

        ///GENMHASH:A0391A0E086361AE06DB925568A86EB3:C70FCB6ABBA310D8130B4F53160A0440
        public async Task CacheAppSettingsAndConnectionStringsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            Task<StringDictionaryInner> appSettingsTask = ListAppSettingsAsync();
            ///GENMHASH:0FE78F842439357DA0333AABD3B95D59:27E486AB74A10242FF421C0798DDC450
            Task<ConnectionStringDictionaryInner> connectionStringsTask = ListConnectionStringsAsync();
            ///GENMHASH:62A0C790E618C837459BE1A5103CA0E5:27E486AB74A10242FF421C0798DDC450
            Task<SlotConfigNamesResourceInner> slotConfigsTask = ListSlotConfigurationsAsync();

            await Task.WhenAll(appSettingsTask, connectionStringsTask, slotConfigsTask);

            StringDictionaryInner appSettings = appSettingsTask.Result;
            ConnectionStringDictionaryInner connectionStrings = connectionStringsTask.Result;
            SlotConfigNamesResourceInner slotConfigs = slotConfigsTask.Result;

            if (appSettings == null || appSettings.Properties == null)
            {
                cachedAppSettings = new Dictionary<string, IAppSetting>();
            }
            else
            {
                cachedAppSettings = appSettings.Properties
                    .Select(p => (IAppSetting)new AppSettingImpl(p.Key, p.Value,
                        slotConfigs.AppSettingNames != null && slotConfigs.AppSettingNames.Contains(p.Key)))
                    .ToDictionary(s => s.Key);
            }

            if (connectionStrings == null || connectionStrings.Properties == null)
            {
                cachedConnectionStrings = new Dictionary<string, IConnectionString>();
            }
            else
            {
                cachedConnectionStrings = connectionStrings.Properties
                    .Select(p => (IConnectionString)new ConnectionStringImpl(p.Key, p.Value,
                        slotConfigs.ConnectionStringNames != null && slotConfigs.ConnectionStringNames.Contains(p.Key)))
                    .ToDictionary(s => s.Name);
            }
        }

        ///GENMHASH:21FDAEDB996672BE017C01C5DD8758D4:27E486AB74A10242FF421C0798DDC450
        internal abstract Task<ConnectionStringDictionaryInner> UpdateConnectionStringsAsync(
            ConnectionStringDictionaryInner inner,
            CancellationToken cancellationToken = default(CancellationToken));

        ///GENMHASH:5C64261945401D044556FE57A81F8919:9E936C439A1F037DD069CDD0064C2AC0
        public HostNameBindingImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> DefineHostnameBinding()
        {
            HostNameBindingInner inner = new HostNameBindingInner()
            {
                SiteName = Name,
                Location = RegionName,
                AzureResourceType = AzureResourceType.Website,
                AzureResourceName = Name,
                HostNameType = HostNameType.Verified
            };
            return new HostNameBindingImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT>(
                inner,
                (FluentImplT)this);
        }

        ///GENMHASH:C41BC129D11DD290512802D4F95ED197:C6674CAD927602613E222F438F228B47
        public FluentImplT WithDefaultDocument(string document)
        {
            if (Inner.SiteConfig == null)
            {
                Inner.SiteConfig = new SiteConfigInner();
            }
            if (Inner.SiteConfig.DefaultDocuments == null)
            {
                Inner.SiteConfig.DefaultDocuments = new List<string>();
            }
            Inner.SiteConfig.DefaultDocuments.Add(document);
            return (FluentImplT)this;
        }

        ///GENMHASH:75EA0E50B45903417B864DA9C5D01D1C:9919B071041D059D4D8D308E1FB5E20E
        public FluentImplT WithConnectionStringStickiness(string name, bool stickiness)
        {
            connectionStringStickiness[name] = stickiness;
            return (FluentImplT)this;
        }

        ///GENMHASH:AC61A00CBD2F6D3CC13EFDD2D085B45C:195DCAB08F9ED1B9468C652A0D922DB9
        public ISet<string> EnabledHostNames()
        {
            return enabledHostNamesSet;
        }

        ///GENMHASH:28D9C85008A5FA42084A6F7E18E27138:AD25C9D393389A67F8973FC859A1C1D2
        public FluentImplT WithRemoteDebuggingEnabled(RemoteVisualStudioVersion remoteVisualStudioVersion)
        {
            if (Inner.SiteConfig == null)
            {
                Inner.SiteConfig = new SiteConfigInner();
            }
            Inner.SiteConfig.RemoteDebuggingEnabled = true;
            Inner.SiteConfig.RemoteDebuggingVersion = remoteVisualStudioVersion.ToString();
            return (FluentImplT)this;
        }

        ///GENMHASH:7889230A4E9E7272A9D70286DB690D8E:53F488EBDEDD2F8F38BF84028D4A7680
        public FluentImplT WithoutDefaultDocument(string document)
        {
            if (Inner.SiteConfig == null)
            {
                Inner.SiteConfig = new SiteConfigInner();
            }
            if (Inner.SiteConfig.DefaultDocuments == null)
            {
                Inner.SiteConfig.DefaultDocuments.Remove(document);
            }
            return (FluentImplT)this;
        }

        ///GENMHASH:1BA412F5F81148A7D5CE917E46EAF27A:22A28B1AE554D533D9E4E3634397A615
        public FluentImplT WithClientCertEnabled(bool enabled)
        {
            Inner.ClientCertEnabled = enabled;
            return (FluentImplT)this;
        }

        ///GENMHASH:843B1707D5538E1793853BD38DCDFC52:E68D654B4C771392BAED7DFAFD6DE33F
        public FluentImplT WithLocalGitSourceControl()
        {
            if (Inner.SiteConfig == null)
            {
                Inner.SiteConfig = new SiteConfigInner();
            }
            Inner.SiteConfig.ScmType = "LocalGit";
            return (FluentImplT)this;
        }

        ///GENMHASH:BEE7B618B5DF7C44777C46BFEC630694:20EB58C3836E816A654AF4F84626B607
        public FluentImplT WithAppSetting(string key, string value)
        {
            appSettingsToAdd[key] = value;
            return (FluentImplT)this;
        }

        ///GENMHASH:42336CC6A1724D1EDE76A585C5A018A2:51AAAD58339A59C1CD8D5EBB75F8FBA7
        public bool IsPremiumApp()
        {
            return Inner.PremiumAppDeployed ?? false;
        }

        ///GENMHASH:7B9E90726FF47A7DBBBA2ECDEF2A3EA5:D06B68E3D50C3AA8EE45FF306EE6CF8F
        public FluentImplT WithRemoteDebuggingDisabled()
        {
            if (Inner.SiteConfig == null)
            {
                Inner.SiteConfig = new SiteConfigInner();
            }
            Inner.SiteConfig.RemoteDebuggingEnabled = false;
            return (FluentImplT)this;
        }

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:DF632029F61029FAC5B2195A4AAC92F5
        public override async Task<FluentT> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            if (hostNameSslStateMap.Count > 0)
            {
                Inner.HostNameSslStates = new List<HostNameSslState>(hostNameSslStateMap.Values);
            }
            bool emptyConfig = Inner.SiteConfig == null;
            if (emptyConfig)
            {
                Inner.SiteConfig = new SiteConfigInner
                {
                    Location = RegionName
                };
            }

            // Web app creation
            ///GENMHASH:07FBC6D492A2E1E463B39D4D7FFC40E9:27E486AB74A10242FF421C0798DDC450
            var site = await CreateOrUpdateInnerAsync(Inner, cancellationToken).ContinueWith<SiteInner>(t =>
            {
                var innerSite = t.Result;
                if (emptyConfig)
                {
                    Inner.SiteConfig = null;
                }
                return innerSite;
            }).ContinueWith(t =>
            {
                // Submit hostname bindings
                var bindingTasks = new List<Task>();
                foreach (var binding in hostNameBindingsToCreate.Values)
                {
                    bindingTasks.Add(binding.CreateAsync(cancellationToken));
                }
                foreach (string binding in hostNameBindingsToDelete)
                {
                    bindingTasks.Add(DeleteHostNameBindingAsync(binding, cancellationToken));
                }
                return Task.WhenAll(bindingTasks).ContinueWith(bindingt =>
                {
                    // Refresh after hostname bindings
                    return GetInnerAsync();
                }).Unwrap();
            }).Unwrap().ContinueWith(t =>
            {
                var innerSite = t.Result;
                // Submit SSL bindings
                var certTasks = new List<Task<IAppServiceCertificate>>();
                foreach (var binding in sslBindingsToCreate.Values)
                {
                    binding.Inner.ToUpdate = true;
                    certTasks.Add(binding.NewCertificateAsync(cancellationToken)());
                    hostNameSslStateMap[binding.Inner.Name] = binding.Inner;
                }
                innerSite.HostNameSslStates = new List<HostNameSslState>(hostNameSslStateMap.Values);
                if (certTasks.Any())
                {
                    return Task.WhenAll(certTasks).ContinueWith(cert =>
                    {
                        return CreateOrUpdateInnerAsync(innerSite, cancellationToken);
                    }).Unwrap();
                }
                else
                {
                    return Task.FromResult(innerSite);
                }
            }).Unwrap();
            
            // Submit site config
            if (Inner.SiteConfig != null)
            {
                ///GENMHASH:6799EDFB0B008F8C0EB7E07EE71E6B34:27E486AB74A10242FF421C0798DDC450
                SiteConfigInner configInner = await CreateOrUpdateSiteConfigAsync(Inner.SiteConfig, cancellationToken);
                site.SiteConfig = configInner;
            }

            // App settings
            if (appSettingsToAdd.Count > 0 || appSettingsToRemove.Count > 0)
            {
                StringDictionaryInner appSettings = await ListAppSettingsAsync(cancellationToken);
                if (appSettings == null)
                {
                    appSettings = new StringDictionaryInner();
                    appSettings.Location = RegionName;
                }
                if (appSettings.Properties == null)
                {
                    appSettings.Properties = new Dictionary<string, string>();
                }
                foreach (var appSetting in appSettingsToAdd)
                {
                    appSettings.Properties[appSetting.Key] = appSetting.Value;
                }
                foreach (var appSetting in appSettingsToRemove)
                {
                    appSettings.Properties.Remove(appSetting);
                }
                appSettings = await UpdateAppSettingsAsync(appSettings, cancellationToken);
            }

            // Connection strings
            if (connectionStringsToAdd.Count > 0 || connectionStringsToRemove.Count > 0)
            {
                ConnectionStringDictionaryInner connectionStrings = await ListConnectionStringsAsync(cancellationToken);
                if (connectionStrings == null)
                {
                    connectionStrings = new ConnectionStringDictionaryInner();
                    connectionStrings.Location = RegionName;
                }
                if (connectionStrings.Properties == null)
                {
                    connectionStrings.Properties = new Dictionary<string, ConnStringValueTypePair>();
                }
                foreach (var connectionString in connectionStringsToAdd)
                {
                    connectionStrings.Properties[connectionString.Key] = connectionString.Value;
                }
                foreach (var connectionString in connectionStringsToRemove)
                {
                    connectionStrings.Properties.Remove(connectionString);
                }
                connectionStrings = await UpdateConnectionStringsAsync(connectionStrings, cancellationToken);
            }

            // app setting and connection string stickiness
            if (appSettingStickiness.Count > 0 || connectionStringStickiness.Count > 0)
            {
                SlotConfigNamesResourceInner slotConfigs = await ListSlotConfigurationsAsync(cancellationToken);
                if (slotConfigs == null)
                {
                    slotConfigs = new SlotConfigNamesResourceInner();
                    slotConfigs.Location = RegionName;
                }
                if (slotConfigs.AppSettingNames == null)
                {
                    slotConfigs.AppSettingNames = new List<string>();
                }
                if (slotConfigs.ConnectionStringNames == null)
                {
                    slotConfigs.ConnectionStringNames = new List<string>();
                }
                var stickyAppSettingKeys = new HashSet<string>(slotConfigs.AppSettingNames);
                var stickyConnectionStringNames = new HashSet<string>(slotConfigs.ConnectionStringNames);
                foreach (var stickiness in appSettingStickiness)
                {
                    if (stickiness.Value)
                    {
                        stickyAppSettingKeys.Add(stickiness.Key);
                    }
                    else
                    {
                        stickyAppSettingKeys.Remove(stickiness.Key);
                    }
                }
                foreach (var stickiness in connectionStringStickiness)
                {
                    if (stickiness.Value)
                    {
                        stickyConnectionStringNames.Add(stickiness.Key);
                    }
                    else
                    {
                        stickyConnectionStringNames.Remove(stickiness.Key);
                    }
                }
                slotConfigs.AppSettingNames = new List<string>(stickyAppSettingKeys);
                slotConfigs.ConnectionStringNames = new List<string>(stickyConnectionStringNames);

                ///GENMHASH:62F8B201D885123D1E906E306D144662:27E486AB74A10242FF421C0798DDC450
                slotConfigs = await UpdateSlotConfigurationsAsync(slotConfigs, cancellationToken);
            }

            // Create source control
            if (sourceControl != null && !sourceControlToDelete)
            {
                await sourceControl.RegisterGithubAccessTokenAsync(cancellationToken);
                ///GENMHASH:88806945F575AAA522C2E09EBC366CC0:27E486AB74A10242FF421C0798DDC450
                await CreateOrUpdateSourceControlAsync(sourceControl.Inner, cancellationToken);
            }

            // Delete source control
            if (sourceControlToDelete)
            {
                await DeleteSourceControlAsync(cancellationToken);
            }

            // convert from Inner
            SetInner(site);
            NormalizeProperties();
            await CacheAppSettingsAndConnectionStringsAsync();

            return this as FluentT;
        }

        ///GENMHASH:339A48BAE1EB5ED9A9975C86986C944F:C86BE9E21375ED5DE08698ADE36B0A6F
        public FluentImplT WithDefaultDocuments(IList<string> documents)
        {
            if (Inner.SiteConfig == null)
            {
                Inner.SiteConfig = new SiteConfigInner();
            }
            if (Inner.SiteConfig.DefaultDocuments == null)
            {
                Inner.SiteConfig.DefaultDocuments = new List<string>();
            }
            ((List<string>) Inner.SiteConfig.DefaultDocuments).AddRange(documents);
            return (FluentImplT)this;
        }

        ///GENMHASH:C28CFF58037291E413815C4EF2BAABEF:EBDDE82BE8301DB6D256FC6EC3761C28
        public SiteAvailabilityState AvailabilityState()
        {
            if (Inner.AvailabilityState == null) 
            {
                return SiteAvailabilityState.Normal;
            }
            return (SiteAvailabilityState) Inner.AvailabilityState;
        }

        ///GENMHASH:9D3A5AED4F45DE4D03626B77E8ADB8A2:9BDB66ADFA5791A2402DF5901EC87936
        public bool HostNamesDisabled()
        {
            return Inner.HostNamesDisabled ?? false;
        }

        ///GENMHASH:640AF2322AF44FB1653F02E5B958A86A:32901B4F001F2D3B8C6B7E60929A323B
        public FluentImplT WithConnectionString(string name, string value, ConnectionStringType type)
        {
            connectionStringsToAdd[name] = new ConnStringValueTypePair()
            {
                Value = value,
                Type = type
            };
            return (FluentImplT) this;
        }

        ///GENMHASH:D101C73F080409B39A67AF00AD9821C6:6F295C3A8A7CB5E19AB918210E36BC1D
        public ManagedPipelineMode ManagedPipelineMode()
        {
            if (Inner.SiteConfig == null || Inner.SiteConfig.ManagedPipelineMode == null) {
                return Models.ManagedPipelineMode.Classic;
            }
            return (ManagedPipelineMode) Inner.SiteConfig.ManagedPipelineMode;
        }

        ///GENMHASH:04BAD2602CA77ACE8B99D7FDF38E6CF1:2CECFA457ECE4652D16C54B3FE56ACBA
        public CloningInfo CloningInfo()
        {
            return Inner.CloningInfo;
        }

        ///GENMHASH:7A9C4AE49E1FF4C1924129FA0CAB5C2E:9F6EAFAD4C4AB8232788CE42F4212939
        public UsageState UsageState()
        {
            if (Inner.UsageState == null)
            {
                return Models.UsageState.Normal;
            }
            return (UsageState) Inner.UsageState;
        }

        ///GENMHASH:6D530E5D2820D0FC31597444F5546CB5:44CE23E03A8BF27E78EB1F1D7D03D969
        public string GatewaySiteName()
        {
            return Inner.GatewaySiteName;
        }

        ///GENMHASH:19DC73910D23C00F8667540D0CBD0AEC:5D6124142B08C7816B4D9A638C461920
        public JavaVersion JavaVersion()
        {
            if (Inner.SiteConfig == null || Inner.SiteConfig.JavaVersion == null) {
                return Fluent.JavaVersion.Off;
            }
            return Fluent.JavaVersion.Parse(Inner.SiteConfig.JavaVersion);
        }

        ///GENMHASH:16DA81E02BFF9B1983571901E1CA6AB9:D68A946D17769FFBF0FF5DAAE2212551
        public string DefaultHostName()
        {
            return Inner.DefaultHostName;
        }

        ///GENMHASH:7A3D1E4A59735B1A92153B49F406A2EA:D3BD1FCEC94D233A323B882DA914CD12
        public FluentImplT WithAppSettings(IDictionary<string,string> settings)
        {
            foreach (KeyValuePair<string, string> setting in settings)
            {
                WithAppSetting(setting.Key, setting.Value);
            }
            return (FluentImplT) this;
        }

        ///GENMHASH:CFB093F74965BAD2150F4041715B9A85:26C83F8A1A14CE55546ED814DB69FDDC
        public string JavaContainer()
        {
            if (Inner.SiteConfig == null) {
                return null;
            }
            return Inner.SiteConfig.JavaContainer;
        }

        ///GENMHASH:BFDA79902F6BE9566899DA86DF88D0D8:DF03AD72AC444A097819590079C05599
        public FluentImplT WithoutSourceControl()
        {
            sourceControlToDelete = true;
            return (FluentImplT) this;
        }

        ///GENMHASH:935E8A144BD263041B17092AD69A49F8:35A7425E491FC92395143FBA3E878748
        public ISet<string> HostNames()
        {
            return hostNamesSet;
        }

        ///GENMHASH:23406BAAD05E75776B2C2D57DAD6EC31:20D62AB87640E86D7C2ED3CD5286A461
        public IList<string> DefaultDocuments()
        {
            if (Inner.SiteConfig == null)
            {
                return null;
            }
            return Inner.SiteConfig.DefaultDocuments;
        }

        ///GENMHASH:48A4E53CFF08718D61958E4C92100018:A9C012D7912C454FA087C8D68B4B602F
        public string MicroService()
        {
            return Inner.MicroService;
        }

        ///GENMHASH:8B6374B8DE9FB105A8A4FE1AC98E0A32:26E0CCD0FFBC820C6C211AAEFBB00D18
        public FluentImplT WithPlatformArchitecture(PlatformArchitecture platform)
        {
            if (Inner.SiteConfig == null)
            {
                Inner.SiteConfig = new SiteConfigInner();
            }
            Inner.SiteConfig.Use32BitWorkerProcess = PlatformArchitecture.X86.Equals(platform);
            return (FluentImplT) this;
        }

        ///GENMHASH:0326165974AFF6C272DF7A9B97057A14:A5822AF23DD5553DE60CAAA635E71F67
        public FluentImplT WithNetFrameworkVersion(NetFrameworkVersion version)
        {
            if (Inner.SiteConfig == null)
            {
                Inner.SiteConfig = new SiteConfigInner();
            }
            Inner.SiteConfig.NetFrameworkVersion = version.ToString();
            return (FluentImplT) this;
        }

        ///GENMHASH:A7C75BEA6A6C2CBCEF6C124C164A8BF5:3146F8F0F41CCE0E8CC45456DD403ED8
        public FluentImplT WithoutHostnameBinding(string hostname)
        {
            hostNameBindingsToDelete.Add(hostname);
            return (FluentImplT) this;
        }

        ///GENMHASH:5ED618DE41DCDE9DBC9F8179EF143BC3:557EA663C067393DFFE5A95D51F6FABC
        public DateTime? LastModifiedTime()
        {
            return Inner.LastModifiedTimeUtc;
        }

        ///GENMHASH:B37CF91380CE58F97FF98F833D067DB4:04E6E9F28F72119837F1EA6B5B69BD0F
        public FluentImplT WithoutConnectionString(string name)
        {
            connectionStringsToRemove.Add(name);
            connectionStringStickiness.Remove(name);
            return (FluentImplT) this;
        }

        ///GENMHASH:C8FAEA7DC8B31D619F885C64E56A6686:9896B5012319AD936FC829F4017BFCF9
        public PhpVersion PhpVersion()
        {
            if (Inner.SiteConfig == null || Inner.SiteConfig.PhpVersion == null)
            {
                return Fluent.PhpVersion.Off;
            }
            return Fluent.PhpVersion.Parse(Inner.SiteConfig.PhpVersion);
        }

        ///GENMHASH:AED7BB300F28210D7E0EDA08BF191BDC:140BC7A2AF1C0E354A00FC241D95FE70
        public ISet<string> TrafficManagerHostNames()
        {
            return trafficManagerHostNamesSet;
        }

        ///GENMHASH:878245C0E417BE8C2AC326900DCD99C2:CCE8D28FDD1DCE271666ADF7E0B188C9
        public bool ScmSiteAlsoStopped()
        {
            return Inner.ScmSiteAlsoStopped ?? false;
        }

        ///GENMHASH:B2C0373522058958F4115A63609B90C1:C3580B34803FD62C1976A18A7581AA0B
        public HostNameSslBindingImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> DefineSslBinding()
        {
            return new HostNameSslBindingImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT>(
                new HostNameSslState(),
                (FluentImplT) this);
        }

        ///GENMHASH:9C834AC4DD619BA31DBCFAAB13EE9923:914A632A86CAEA343D26353F278D7305
        public FluentImplT WithClientAffinityEnabled(bool enabled)
        {
            Inner.ClientAffinityEnabled = enabled;
            return (FluentImplT) this;
        }

        ///GENMHASH:E9F49502899B96A687DA858A6BE8647D:14B808B9FEDFD8512C02B321FDC1D222
        public FluentImplT WithAppDisabledOnCreation()
        {
            Inner.Enabled = false;
            return (FluentImplT) this;
        }

        internal abstract Task<Microsoft.Azure.Management.AppService.Fluent.Models.SlotConfigNamesResourceInner> ListSlotConfigurationsAsync(CancellationToken cancellationToken = default(CancellationToken));

        ///GENMHASH:845984DE82811B6BF5DE9676CE5B433A:6A4C5D736C724933B8B06C102140E89D
        public FluentImplT WithoutAppSetting(string key)
        {
            appSettingsToRemove.Add(key);
            appSettingStickiness.Remove(key);
            return (FluentImplT) this;
        }

        ///GENMHASH:F49A26C57ADD85EB4F774AACF7455EA0:8C65401DDB5F058E55EDB8D8C3E3DFAA
        public RemoteVisualStudioVersion RemoteDebuggingVersion()
        {
            if (Inner.SiteConfig == null)
            {
                return null;
            }
            return RemoteVisualStudioVersion.Parse(Inner.SiteConfig.RemoteDebuggingVersion);
        }

        ///GENMHASH:F5F1D8F285012204F1326EAA44BBE26E:B4CE82C3129D4304A7C71A600E1CA97C
        public WebAppSourceControlImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> DefineSourceControl()
        {
            return new WebAppSourceControlImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT>(
                new SiteSourceControlInner()
                {
                    Location = RegionName
                }, this);
        }

        ///GENMHASH:1703877FCECC33D73EA04EEEF89045EF:A93CDCF3EC94A75CDDBFCAC39CD42834
        public bool Enabled()
        {
            if (Inner.Enabled == null)
            {
                return true;
            }
            return (bool) Inner.Enabled;
        }

        ///GENMHASH:78FD17A2E22E150AD12AA226D4123829:29A4403ED56D639EA144EEEF29FB711D
        public FluentImplT WithJavaVersion(JavaVersion version)
        {
            if (Inner.SiteConfig == null)
            {
                Inner.SiteConfig = new SiteConfigInner();
            }
            Inner.SiteConfig.JavaVersion = version.ToString();
            return (FluentImplT) this;
        }

        internal abstract Task<SlotConfigNamesResourceInner> UpdateSlotConfigurationsAsync(SlotConfigNamesResourceInner inner, CancellationToken cancellationToken = default(CancellationToken));

        ///GENMHASH:3BE74CEDB189CF13F08D5268649B73D7:FBDC4182C8802269267E808E13D08A16
        public IReadOnlyDictionary<string, IAppSetting> AppSettings()
        {
            return new ReadOnlyDictionary<string, IAppSetting>(cachedAppSettings);
        }

        internal abstract Task<SiteConfigInner> GetConfigInnerAsync(CancellationToken cancellationToken = default(CancellationToken));

        ///GENMHASH:F76B0B1D4816856D9C8EA506F611C03D:91C46F0ECB5CC2D51804D2C0710E6211
        public FluentImplT WithoutSslBinding(string hostname)
        {
            if (hostNameSslStateMap.ContainsKey(hostname))
            {
                hostNameSslStateMap[hostname].SslState = SslState.Disabled;
                hostNameSslStateMap[hostname].ToUpdate = true;
            }
            return (FluentImplT) this;
        }

        ///GENMHASH:D40FFC05002182B6125DEE214DFC3DA1:3174BE5D31FA791191831DEA6009CCC4
        public bool ClientCertEnabled()
        {
            return Inner.ClientCertEnabled ?? false;
        }

        ///GENMHASH:37E27ADFB836BE1FD0A02912DEE9E60B:8A1A421381B060FE80BB398E975836CB
        public FluentImplT WithStickyAppSettings(IDictionary<string,string> settings)
        {
            WithAppSettings(settings);
            foreach (string key in settings.Keys)
            {
                appSettingStickiness[key] = true;
            }
            return (FluentImplT) this;
        }

        internal abstract Task<Microsoft.Azure.Management.AppService.Fluent.Models.SiteInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken));

        ///GENMHASH:C102774B5B56F13DBA5095A48DC5F846:1886C5FB5632B7468462889794AFEA08
        public NetFrameworkVersion NetFrameworkVersion()
        {
            if (Inner.SiteConfig == null)
            {
                return null;
            }
            return Fluent.NetFrameworkVersion.Parse(Inner.SiteConfig.NetFrameworkVersion);
        }

        ///GENMHASH:0A3B342EB54A6BB9B919686055C77154:D71C3ABF670D7D6382F65A18153CE77F
        internal WebAppBaseImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> WithNewHostNameSslBinding(HostNameSslBindingImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> hostNameSslBinding)
        {
            if (hostNameSslBinding.NewCertificateAsync() != null)
            {
                sslBindingsToCreate[hostNameSslBinding.Name()] = hostNameSslBinding;
            }
            return this;
        }

        ///GENMHASH:EDB4EABD52D790D7204DF4CACC39D04A:4469898682437D64D221DD7583D2B354
        public FluentImplT WithAutoSwapSlotName(string slotName)
        {
            if (Inner.SiteConfig == null)
            {
                Inner.SiteConfig = new SiteConfigInner();
            }
            Inner.SiteConfig.AutoSwapSlotName = slotName;
            return (FluentImplT) this;
        }

        ///GENMHASH:750A632B5F062E375E30024C56379A8E:39DCD28D9DEDDE14FCCB5F803750A6BE
        public string NodeVersion()
        {
            if (Inner.SiteConfig == null)
            {
                return null;
            }
            return Inner.SiteConfig.NodeVersion;
        }

        internal abstract Task<SiteInner> CreateOrUpdateInnerAsync(SiteInner site, CancellationToken cancellationToken = default(CancellationToken));

        ///GENMHASH:FA07D0476A4A7B9F0FDA17B8DF0095F1:FC345DE9B0C87952B3DE42BCE0488ECD
        public IReadOnlyDictionary<string, IConnectionString> ConnectionStrings()
        {
            return new ReadOnlyDictionary<string, IConnectionString>(cachedConnectionStrings);
        }

        internal abstract Task<SiteSourceControlInner> CreateOrUpdateSourceControlAsync(SiteSourceControlInner inner, CancellationToken cancellationToken = default(CancellationToken));

        ///GENMHASH:B0ECE8043B59B23D8A941C8FB1327608:F6986D710A3CD05509C969004E265D9B
        internal  WebAppBaseImpl(
            string name,
            SiteInner innerObject,
            SiteConfigInner configObject,
            IAppServiceManager manager)
            : base (name, innerObject, manager)
        {
            Inner.SiteConfig = configObject;
            NormalizeProperties();
        }

        ///GENMHASH:3A1ECB38842D1F307BEAA5CE89B8D9A9:37E20E73C6553EB8ECA43CDD3E03DF88
        public FluentImplT WithScmSiteAlsoStopped(bool scmSiteAlsoStopped)
        {
            Inner.ScmSiteAlsoStopped = scmSiteAlsoStopped;
            return (FluentImplT) this;
        }

        ///GENMHASH:88FB986A040F70D62E535B947213D4C9:872EB6D779CA1F073EAE994BA5E1A2D8
        public string AutoSwapSlotName()
        {
            if (Inner.SiteConfig == null)
            {
                return null;
            }
            return Inner.SiteConfig.AutoSwapSlotName;
        }

        ///GENMHASH:C3A15726A3EC798F48295A8FF0867A0B:7C9DD6C2A7609244E63D0353EBF87B3B
        public FluentImplT WithPhpVersion(PhpVersion version)
        {
            if (Inner.SiteConfig == null)
            {
                Inner.SiteConfig = new SiteConfigInner();
            }
            Inner.SiteConfig.PhpVersion = version.ToString();
            return (FluentImplT) this;
        }

        ///GENMHASH:4217B9DCD795EFEFA0771FDE182F0DF5:156FC00C236BFE0C12D023AABE135F63
        public FluentImplT WithManagedHostnameBindings(IAppServiceDomain domain, params string[] hostnames)
        {
            foreach(var hostname in hostnames)  {
                if (hostname.Equals("@") || hostname.Equals(domain.Name, StringComparison.OrdinalIgnoreCase)) {
                    DefineHostnameBinding()
                        .WithAzureManagedDomain(domain)
                        .WithSubDomain(hostname)
                        .WithDnsRecordType(CustomHostNameDnsRecordType.A)
                        .Attach();
                } else {
                    DefineHostnameBinding()
                        .WithAzureManagedDomain(domain)
                        .WithSubDomain(hostname)
                        .WithDnsRecordType(CustomHostNameDnsRecordType.CName)
                        .Attach();
                }
            }
            return (FluentImplT) this;
        }

        ///GENMHASH:AEE17FD09F624712647F5EBCEC141EA5:A2B4C8D5515FE0A160E2214A60FB99A6
        public string State()
        {
            return Inner.State;
        }

        ///GENMHASH:B1A8B6AF0882F87FF978C572DA7F4B5C:CA993290F5DD317A425ED88E1175A1D9
        public FluentImplT WithWebSocketsEnabled(bool enabled)
        {
            if (Inner.SiteConfig == null)
            {
                Inner.SiteConfig = new SiteConfigInner();
            }
            Inner.SiteConfig.WebSocketsEnabled = enabled;
            return (FluentImplT) this;
        }

        ///GENMHASH:DBBC1639A411401B52B0F804284263EE:473779DF0D6351D3FEF135C14773DB4F
        public bool AlwaysOn()
        {
            if (Inner.SiteConfig == null || Inner.SiteConfig.AlwaysOn == null)
            {
                return false;
            }
            return (bool)Inner.SiteConfig.AlwaysOn;
        }

        internal abstract Task<SiteConfigInner> CreateOrUpdateSiteConfigAsync(SiteConfigInner siteConfig, CancellationToken cancellationToken = default(CancellationToken));

        ///GENMHASH:FA11486B840C0E86D3D1A446BF2A3C96:AA358901B07077B2692CB317CAFFF60D
        public FluentImplT WithStickyAppSetting(string key, string value)
        {
            return WithAppSetting(key, value).WithAppSettingStickiness(key, true);
        }

        ///GENMHASH:58B5A5808212C5DA86843A18CE1F067F:455C7DE078AA851CB5C8F39D0A9260A1
        public string TargetSwapSlot()
        {
            return Inner.TargetSwapSlot;
        }

        ///GENMHASH:3BBC37006EE11765DF55134711F9E6D9:86A9DA70332D3F08A24CC84ED1EBFE15
        public FluentImplT WithoutPhp()
        {
            return WithPhpVersion(Fluent.PhpVersion.Parse(""));
        }

        ///GENMHASH:04497E34F1930C831D67A21169FA28E0:5719C33FC3EAF071BCAD1249F58B0A1F
        public string AppServicePlanId()
        {
            return Inner.ServerFarmId;
        }

        ///GENMHASH:F63CA8A7D8722945AE86442FAAE62963:837E0749902A7C8B46678D5899F91E3A
        public bool RemoteDebuggingEnabled()
        {
            if (Inner.SiteConfig == null || Inner.SiteConfig.RemoteDebuggingEnabled == null)
            {
                return false;
            }
            return (bool)Inner.SiteConfig.RemoteDebuggingEnabled;
        }

        ///GENMHASH:13FED596F6C9DDEA581391D2291A4AB1:7DD021B685AC511232E39D9D870512E3
        public FluentImplT WithWebContainer(WebContainer webContainer)
        {
            if (Inner.SiteConfig == null)
            {
                Inner.SiteConfig = new SiteConfigInner();
            }
            if (webContainer == null)
            {
                Inner.SiteConfig.JavaContainer = null;
                Inner.SiteConfig.JavaContainerVersion = null;
            }
            else
            {
                string[] containerInfo = webContainer.ToString().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                Inner.SiteConfig.JavaContainer = containerInfo[0];
                Inner.SiteConfig.JavaContainerVersion = containerInfo[1];
            }
            return (FluentImplT) this;
        }

        internal abstract Task<ConnectionStringDictionaryInner> ListConnectionStringsAsync(CancellationToken cancellationToken = default(CancellationToken));

        ///GENMHASH:6CAC70824B4E95B3FC2D7FE1CE29759E:513EF027EB09EB5FEC6C661F74328B72
        public bool ClientAffinityEnabled()
        {
            return Inner.ClientAffinityEnabled ?? false;
        }

        ///GENMHASH:44E1562BA49E879B6BD3110F47EE24D2:56752CC2EF6BC17A058EFBD8726E81AF
        internal FluentImplT WithHostNameBinding(HostNameBindingImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> hostNameBinding)
        {
            this.hostNameBindingsToCreate[hostNameBinding.Name()] = hostNameBinding;
            return (FluentImplT) this;
        }

        ///GENMHASH:C82AC013C402054BF54C48891EAC7C4E:09A97DDE352A5FE05FF05D87BB65FB03
        public FluentImplT WithWebAppAlwaysOn(bool alwaysOn)
        {
            if (Inner.SiteConfig == null)
            {
                Inner.SiteConfig = new SiteConfigInner();
            }
            Inner.SiteConfig.AlwaysOn = alwaysOn;
            return (FluentImplT) this;
        }

        ///GENMHASH:C2F7B915E364BA07AE840A3986B36AFE:798E625A28DD9AA65131B7A5A1494291
        public IReadOnlyDictionary<string, HostNameSslState> HostNameSslStates()
        {
            return new ReadOnlyDictionary<string, HostNameSslState>(hostNameSslStateMap);
        }

        ///GENMHASH:1BEBA30733974CB2A2FB9AC9E036FA93:72C814A27C1E75E81B6BEEBB5056F950
        public bool IsDefaultContainer()
        {
            return Inner.IsDefaultContainer ?? true;
        }

        ///GENMHASH:09C71E4BDBE3FD33C1FF3F0FCC7511B5:61F56A801796D18DC0D97539EC361EFF
        internal FluentImplT WithSourceControl(WebAppSourceControlImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> sourceControl)
        {
            this.sourceControl = sourceControl;
            return (FluentImplT) this;
        }

        ///GENMHASH:FCAC8C2F8D6E12CB6F5D7787A2837016:27E486AB74A10242FF421C0798DDC450
        internal abstract Task DeleteHostNameBindingAsync(string hostname, CancellationToken cancellationToken = default(CancellationToken));
        public abstract void Stop();
        public abstract Task VerifyDomainOwnershipAsync(string certificateOrderName, string domainVerificationToken, CancellationToken cancellationToken = default(CancellationToken));
        public abstract void ResetSlotConfigurations();
        public abstract void Restart();
        public abstract IPublishingProfile GetPublishingProfile();
        public abstract void ApplySlotConfigurations(string slotName);
        public abstract IReadOnlyDictionary<string, IHostNameBinding> GetHostNameBindings();
        public abstract void VerifyDomainOwnership(string certificateOrderName, string domainVerificationToken);
        public abstract IWebAppSourceControl GetSourceControl();
        public abstract void Start();
        public abstract void Swap(string slotName);

        IUpdate<FluentT> IUpdateWithTags<IUpdate<FluentT>>.WithTags(IDictionary<string, string> tags)
        {
            return WithTags(tags);
        }

        IUpdate<FluentT> IUpdateWithTags<IUpdate<FluentT>>.WithTag(string key, string value)
        {
            return WithTag(key, value);
        }

        IUpdate<FluentT> IUpdateWithTags<IUpdate<FluentT>>.WithoutTag(string key)
        {
            return WithoutTag(key);
        }
    }
}
