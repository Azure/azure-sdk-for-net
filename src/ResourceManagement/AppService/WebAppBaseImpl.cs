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
        private SiteConfigResourceInner _siteConfig;
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
        private WebAppAuthenticationImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> authentication;
        private bool authenticationToUpdate;

        internal SiteConfigResourceInner SiteConfig
        {
            get
            {
                return _siteConfig;
            }
            set
            {
                _siteConfig = value;
            }
        }

        ///GENMHASH:6779D3D3C7AB7AAAE805BA0ABEE95C51:27E486AB74A10242FF421C0798DDC450
        internal abstract Task<StringDictionaryInner> UpdateAppSettingsAsync(StringDictionaryInner inner, CancellationToken cancellationToken = default(CancellationToken));

        ///GENMHASH:400B39C84CFE07A8B031B773061CF1BB:3336437A3EFA0E423BB5363ADD7BA1F0
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

        ///GENMHASH:5347BC9AA33E4B7344CEB8188EA1DAA3:361AE1AC09182E0F87A8F6D59BF17F5C
        public FluentImplT WithoutPython()
        {
            return WithPythonVersion(Fluent.PythonVersion.Parse(""));
        }

        ///GENMHASH:B67E95BCEA89D1B6CBB6849249A60D4F:03059CE12A850A7CCCF1A3E59870EDED
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

        ///GENMHASH:879627C2DAE69433191E7E3A0197FFCB:50FA58870F56D048CFBCFCDB1A5091C6
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
            this.authenticationToUpdate = false;
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

        ///GENMHASH:5091CF7FBD481F6A80C8200D77B918B5:2676D6C589C22A318404C0D6FEBB1458
        public string JavaContainerVersion()
        {
            if (this.SiteConfig == null)
            {
                return null;
            }
            return this.SiteConfig.JavaContainerVersion;
        }

        ///GENMHASH:807E62B6346803DB90804D0DEBD2FCA6:27E486AB74A10242FF421C0798DDC450
        internal abstract Task DeleteSourceControlAsync(CancellationToken cancellationToken = default(CancellationToken));

        ///GENMHASH:B06FC38A7913CA2F028C97DE025DEED3:64057BA87D06462F77EAD057B63F6120
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

        ///GENMHASH:0BD0140B6FBB6AA6B83FE90F95878549:795D3BB5233A7B4C5D83186D286586D7
        public PythonVersion PythonVersion()
        {
            if (this.SiteConfig == null || this.SiteConfig.PythonVersion == null)
            {
                return Fluent.PythonVersion.Off;
            }
            return Fluent.PythonVersion.Parse(this.SiteConfig.PythonVersion);
        }

        ///GENMHASH:C03B1FAF31FB94362C083BAA7332E4A4:8B19C9BFB290F4258B198AA4A8232D84
        public FluentImplT WithoutJava()
        {
            return WithJavaVersion(Fluent.JavaVersion.Parse("")).WithWebContainer(null);
        }

        ///GENMHASH:3A0791A760CE20BB60B662E45E1B5A20:4FF1C3A0EBAB86346DAA7BA2FF1129CE
        public FluentImplT WithPythonVersion(PythonVersion version)
        {
            if (this.SiteConfig == null)
            {
                this.SiteConfig = new SiteConfigResourceInner();
            }
            this.SiteConfig.PythonVersion = version.ToString();
            return (FluentImplT)this;
        }

        ///GENMHASH:E45783E7B404EC0F4EBC4EE6BA7EF55A:35E22FB3218ACDCDE6A7844929967E03
        public FluentImplT WithManagedPipelineMode(ManagedPipelineMode managedPipelineMode)
        {
            if (this.SiteConfig == null)
            {
                this.SiteConfig = new SiteConfigResourceInner();
            }
            this.SiteConfig.ManagedPipelineMode = managedPipelineMode;
            return (FluentImplT)this;
        }

        ///GENMHASH:4002186478A1CB0B59732EBFB18DEB3A:75636395FBDB9C1FA7F5231207B98D55

        public override async Task<FluentT> RefreshAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            ///GENMHASH:9EC0529BA0D08B75AD65E98A4BA01D5D:27E486AB74A10242FF421C0798DDC450
            SiteInner inner = await GetSiteAsync(cancellationToken);
            ///GENMHASH:256905D5B839C64BFE9830503CB5607B:27E486AB74A10242FF421C0798DDC450
            this.SiteConfig = await GetConfigInnerAsync(cancellationToken);
            SetInner(inner);
            await CacheSiteProperties(cancellationToken);
            return this as FluentT;
        }

        ///GENMHASH:10422D744EF1F162EBE8C9A9FA95C4F1:730A847F06F615063704F0C5FFF2B639

        public ISet<string> OutboundIPAddresses()
        {
            return outboundIpAddressesSet;
        }

        public string LinuxFxVersion()
        {
            if (this.SiteConfig == null)
            {
                return null;
            }
            return SiteConfig.LinuxFxVersion;
        }

        ///GENMHASH:4380B7AB34BB7338E16329242A2DB73A:ACAB6B8E224E0172DCF3037479B95B0A
        public bool WebSocketsEnabled()
        {
            if (this.SiteConfig == null || this.SiteConfig.WebSocketsEnabled == null)
            {
                return false;
            }
            return (bool)this.SiteConfig.WebSocketsEnabled;
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

        public async Task CacheSiteProperties(CancellationToken cancellationToken = default(CancellationToken))
        {
            Task<StringDictionaryInner> appSettingsTask = ListAppSettingsAsync(cancellationToken);
            Task<ConnectionStringDictionaryInner> connectionStringsTask = ListConnectionStringsAsync(cancellationToken);
            Task<SlotConfigNamesResourceInner> slotConfigsTask = ListSlotConfigurationsAsync(cancellationToken);
            Task<SiteAuthSettingsInner> authenticationTask = GetAuthenticationAsync(cancellationToken);

            await Task.WhenAll(appSettingsTask, connectionStringsTask, slotConfigsTask, authenticationTask);

            StringDictionaryInner appSettings = appSettingsTask.Result;
            ConnectionStringDictionaryInner connectionStrings = connectionStringsTask.Result;
            SlotConfigNamesResourceInner slotConfigs = slotConfigsTask.Result;
            SiteAuthSettingsInner authInner = authenticationTask.Result;

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

            authentication = new WebAppAuthenticationImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT>(authInner, this);
        }

        ///GENMHASH:21FDAEDB996672BE017C01C5DD8758D4:27E486AB74A10242FF421C0798DDC450
        internal abstract Task<ConnectionStringDictionaryInner> UpdateConnectionStringsAsync(
            ConnectionStringDictionaryInner inner,
            CancellationToken cancellationToken = default(CancellationToken));

        ///GENMHASH:5C64261945401D044556FE57A81F8919:FF5FA095598E35520A42EFBB735AC487
        public HostNameBindingImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> DefineHostnameBinding()
        {
            HostNameBindingInner inner = new HostNameBindingInner()
            {
                SiteName = Name,
                AzureResourceType = AzureResourceType.Website,
                AzureResourceName = Name,
                HostNameType = HostNameType.Verified
            };
            return new HostNameBindingImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT>(
                inner,
                (FluentImplT)this);
        }

        ///GENMHASH:C41BC129D11DD290512802D4F95ED197:013031F4CC26C3B90E69794F1038D33B
        public FluentImplT WithDefaultDocument(string document)
        {
            if (this.SiteConfig == null)
            {
                this.SiteConfig = new SiteConfigResourceInner();
            }
            if (this.SiteConfig.DefaultDocuments == null)
            {
                this.SiteConfig.DefaultDocuments = new List<string>();
            }
            this.SiteConfig.DefaultDocuments.Add(document);
            return (FluentImplT)this;
        }

        ///GENMHASH:75EA0E50B45903417B864DA9C5D01D1C:B2C616DAEE72068CA3942A2BF4BC9ECB
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

        ///GENMHASH:28D9C85008A5FA42084A6F7E18E27138:EA42CE9A58D576BB006C11AB710672FB
        public FluentImplT WithRemoteDebuggingEnabled(RemoteVisualStudioVersion remoteVisualStudioVersion)
        {
            if (this.SiteConfig == null)
            {
                this.SiteConfig = new SiteConfigResourceInner();
            }
            this.SiteConfig.RemoteDebuggingEnabled = true;
            this.SiteConfig.RemoteDebuggingVersion = remoteVisualStudioVersion.ToString();
            return (FluentImplT)this;
        }

        ///GENMHASH:7889230A4E9E7272A9D70286DB690D8E:94B0D757764065B7860AD2852AB07F7E
        public FluentImplT WithoutDefaultDocument(string document)
        {
            if (this.SiteConfig == null)
            {
                this.SiteConfig = new SiteConfigResourceInner();
            }
            if (this.SiteConfig.DefaultDocuments == null)
            {
                this.SiteConfig.DefaultDocuments.Remove(document);
            }
            return (FluentImplT)this;
        }

        ///GENMHASH:1BA412F5F81148A7D5CE917E46EAF27A:92D9EEA0C2036558D58ED13AECCA31C3
        public FluentImplT WithClientCertEnabled(bool enabled)
        {
            Inner.ClientCertEnabled = enabled;
            return (FluentImplT)this;
        }

        ///GENMHASH:843B1707D5538E1793853BD38DCDFC52:C41573D98BF4332B78B04B0D2F4FA92C
        public FluentImplT WithLocalGitSourceControl()
        {
            if (this.SiteConfig == null)
            {
                this.SiteConfig = new SiteConfigResourceInner();
            }
            this.SiteConfig.ScmType = "LocalGit";
            return (FluentImplT)this;
        }

        ///GENMHASH:BEE7B618B5DF7C44777C46BFEC630694:35997061CE30D9AFADF853A44BC04645
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

        ///GENMHASH:7B9E90726FF47A7DBBBA2ECDEF2A3EA5:9EDEDE0F4F481094C0815FBE89B5A385
        public FluentImplT WithRemoteDebuggingDisabled()
        {
            if (this.SiteConfig == null)
            {
                this.SiteConfig = new SiteConfigResourceInner();
            }
            this.SiteConfig.RemoteDebuggingEnabled = false;
            return (FluentImplT)this;
        }

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:A25AA6BA478E9A0DD581F3FB75601E70
        public async override Task<FluentT> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            if (hostNameSslStateMap.Count > 0)
            {
                Inner.HostNameSslStates = new List<HostNameSslState>(hostNameSslStateMap.Values);
            }

            // Web app creation
            Inner.SiteConfig = new Models.SiteConfig();
            var site = await CreateOrUpdateInnerAsync(Inner, cancellationToken)
            .ContinueWith<SiteInner>(t =>
                {
                    var innerSite = t.Result;
                    Inner.SiteConfig = null;
                    return innerSite;
                },
                cancellationToken,
                TaskContinuationOptions.ExecuteSynchronously,
                TaskScheduler.Default)
            .ContinueWith(t =>
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
                    return Task.WhenAll(bindingTasks)
                    .ContinueWith(bindingt =>
                        {
                            // Refresh after hostname bindings
                            return GetSiteAsync(cancellationToken);
                        },
                        cancellationToken,
                        TaskContinuationOptions.ExecuteSynchronously,
                        TaskScheduler.Default).Unwrap();
                },
                cancellationToken,
                TaskContinuationOptions.ExecuteSynchronously,
                TaskScheduler.Default).Unwrap()
            .ContinueWith(t =>
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
                        return Task.WhenAll(certTasks)
                        .ContinueWith(cert =>
                            {
                                return CreateOrUpdateInnerAsync(innerSite, cancellationToken);
                            },
                            cancellationToken,
                            TaskContinuationOptions.ExecuteSynchronously,
                            TaskScheduler.Default).Unwrap();
                    }
                    else
                    {
                        return Task.FromResult(innerSite);
                    }
                },
                cancellationToken,
                TaskContinuationOptions.ExecuteSynchronously,
                TaskScheduler.Default).Unwrap();
            
            // Submit site config
            if (this.SiteConfig != null)
            {
                SiteConfigResourceInner configInner = await CreateOrUpdateSiteConfigAsync(this.SiteConfig, cancellationToken);
                this.SiteConfig = configInner;
            }

            // App settings
            await SubmitAppSettingsAsync(site, cancellationToken);

            // Connection strings
            if (connectionStringsToAdd.Count > 0 || connectionStringsToRemove.Count > 0)
            {
                ConnectionStringDictionaryInner connectionStrings = await ListConnectionStringsAsync(cancellationToken);
                if (connectionStrings == null)
                {
                    connectionStrings = new ConnectionStringDictionaryInner();
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

            // Wait for previous settings to be effective before deployment
            if (sourceControlToDelete || sourceControl != null)
            {
                await SdkContext.DelayProvider.DelayAsync(30 * 1000, cancellationToken);
            }

            // Delete source control
            if (sourceControlToDelete)
            {
                await DeleteSourceControlAsync(cancellationToken);
            }

            // Create source control
            if (sourceControl != null && !sourceControlToDelete)
            {
                await sourceControl.RegisterGithubAccessTokenAsync(cancellationToken);
                ///GENMHASH:88806945F575AAA522C2E09EBC366CC0:27E486AB74A10242FF421C0798DDC450
                await CreateOrUpdateSourceControlAsync(sourceControl.Inner, cancellationToken);
            }

            // authentication
            if (authenticationToUpdate) {
                await UpdateAuthenticationAsync(authentication.Inner, cancellationToken);
            }

            // convert from Inner
            SetInner(site);
            NormalizeProperties();
            await CacheSiteProperties(cancellationToken);

            return this as FluentT;
        }

        internal virtual async Task<SiteInner> SubmitAppSettingsAsync(SiteInner site, CancellationToken cancellationToken)
        {
            if (appSettingsToAdd.Count > 0 || appSettingsToRemove.Count > 0)
            {
                StringDictionaryInner appSettings = await ListAppSettingsAsync(cancellationToken);
                if (appSettings == null)
                {
                    appSettings = new StringDictionaryInner();
                }
                if (appSettings.Properties == null)
                {
                    appSettings.Properties = new Dictionary<string, string>();
                }
                foreach (var appSetting in appSettingsToRemove)
                {
                    appSettings.Properties.Remove(appSetting);
                }
                foreach (var appSetting in appSettingsToAdd)
                {
                    appSettings.Properties[appSetting.Key] = appSetting.Value;
                }
                await UpdateAppSettingsAsync(appSettings, cancellationToken);
            }
            return site;
        }

        ///GENMHASH:339A48BAE1EB5ED9A9975C86986C944F:019E868E4A08A557C6D58D6C887F8914
        public FluentImplT WithDefaultDocuments(IList<string> documents)
        {
            if (this.SiteConfig == null)
            {
                this.SiteConfig = new SiteConfigResourceInner();
            }
            if (this.SiteConfig.DefaultDocuments == null)
            {
                this.SiteConfig.DefaultDocuments = new List<string>();
            }
            ((List<string>) this.SiteConfig.DefaultDocuments).AddRange(documents);
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

        ///GENMHASH:640AF2322AF44FB1653F02E5B958A86A:0A5075F071576A92A870B3FF79D52706
        public FluentImplT WithConnectionString(string name, string value, ConnectionStringType type)
        {
            connectionStringsToAdd[name] = new ConnStringValueTypePair()
            {
                Value = value,
                Type = type
            };
            return (FluentImplT) this;
        }

        ///GENMHASH:D101C73F080409B39A67AF00AD9821C6:123E679DCA04C09E8E07DC6E7894664F
        public ManagedPipelineMode ManagedPipelineMode()
        {
            if (this.SiteConfig == null || this.SiteConfig.ManagedPipelineMode == null) {
                return Models.ManagedPipelineMode.Classic;
            }
            return (ManagedPipelineMode) this.SiteConfig.ManagedPipelineMode;
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

        ///GENMHASH:19DC73910D23C00F8667540D0CBD0AEC:E23AFA4DD63099E4C406231C758F91E4
        public JavaVersion JavaVersion()
        {
            if (this.SiteConfig == null || this.SiteConfig.JavaVersion == null) {
                return Fluent.JavaVersion.Off;
            }
            return Fluent.JavaVersion.Parse(this.SiteConfig.JavaVersion);
        }

        ///GENMHASH:16DA81E02BFF9B1983571901E1CA6AB9:D68A946D17769FFBF0FF5DAAE2212551
        public string DefaultHostName()
        {
            return Inner.DefaultHostName;
        }

        ///GENMHASH:7A3D1E4A59735B1A92153B49F406A2EA:28A9E89FFAE2C02A8D6559195D5529FC
        public FluentImplT WithAppSettings(IDictionary<string,string> settings)
        {
            foreach (KeyValuePair<string, string> setting in settings)
            {
                WithAppSetting(setting.Key, setting.Value);
            }
            return (FluentImplT) this;
        }

        ///GENMHASH:CFB093F74965BAD2150F4041715B9A85:53401E07679E0D67E0D9C7F4FFAF593B
        public string JavaContainer()
        {
            if (this.SiteConfig == null) {
                return null;
            }
            return this.SiteConfig.JavaContainer;
        }

        ///GENMHASH:BFDA79902F6BE9566899DA86DF88D0D8:BDA62FE77DDD9791BF594E8C70B0DF97
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

        ///GENMHASH:23406BAAD05E75776B2C2D57DAD6EC31:1EF21756C66ADE5D95AB8272104B3924
        public IList<string> DefaultDocuments()
        {
            if (this.SiteConfig == null)
            {
                return null;
            }
            return this.SiteConfig.DefaultDocuments;
        }

        ///GENMHASH:48A4E53CFF08718D61958E4C92100018:A9C012D7912C454FA087C8D68B4B602F
        public string MicroService()
        {
            return Inner.MicroService;
        }

        ///GENMHASH:8B6374B8DE9FB105A8A4FE1AC98E0A32:59ABE89788E5ADCDFB7771D2A4549653
        public FluentImplT WithPlatformArchitecture(PlatformArchitecture platform)
        {
            if (this.SiteConfig == null)
            {
                this.SiteConfig = new SiteConfigResourceInner();
            }
            this.SiteConfig.Use32BitWorkerProcess = Fluent.PlatformArchitecture.X86.Equals(platform);
            return (FluentImplT) this;
        }

        ///GENMHASH:0326165974AFF6C272DF7A9B97057A14:566E4209819C87DEC331672295F5DDF7
        public FluentImplT WithNetFrameworkVersion(NetFrameworkVersion version)
        {
            if (this.SiteConfig == null)
            {
                this.SiteConfig = new SiteConfigResourceInner();
            }
            this.SiteConfig.NetFrameworkVersion = version.ToString();
            return (FluentImplT) this;
        }

        ///GENMHASH:A7C75BEA6A6C2CBCEF6C124C164A8BF5:1FF4D5BA862094ABC5B52373AF55536D
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

        ///GENMHASH:B37CF91380CE58F97FF98F833D067DB4:2902F3307D1294D3293754828C3C2392
        public FluentImplT WithoutConnectionString(string name)
        {
            connectionStringsToRemove.Add(name);
            connectionStringStickiness.Remove(name);
            return (FluentImplT) this;
        }

        ///GENMHASH:C8FAEA7DC8B31D619F885C64E56A6686:7D1B09772DF5D11EA432C92D9E893EB2
        public PhpVersion PhpVersion()
        {
            if (this.SiteConfig == null || this.SiteConfig.PhpVersion == null)
            {
                return Fluent.PhpVersion.Off;
            }
            return Fluent.PhpVersion.Parse(this.SiteConfig.PhpVersion);
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

        ///GENMHASH:B2C0373522058958F4115A63609B90C1:3B9E723346BCE1F9D33286828FF0504F
        public HostNameSslBindingImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> DefineSslBinding()
        {
            return new HostNameSslBindingImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT>(
                new HostNameSslState(),
                (FluentImplT) this);
        }

        ///GENMHASH:9C834AC4DD619BA31DBCFAAB13EE9923:D92341EB6ACBF9BC85EE5C8E82E755BB
        public FluentImplT WithClientAffinityEnabled(bool enabled)
        {
            Inner.ClientAffinityEnabled = enabled;
            return (FluentImplT) this;
        }

        ///GENMHASH:E9F49502899B96A687DA858A6BE8647D:6E46732E5E7ACD1E67A42FB29B9A2AEA
        public FluentImplT WithAppDisabledOnCreation()
        {
            Inner.Enabled = false;
            return (FluentImplT) this;
        }

        internal abstract Task<Microsoft.Azure.Management.AppService.Fluent.Models.SlotConfigNamesResourceInner> ListSlotConfigurationsAsync(CancellationToken cancellationToken = default(CancellationToken));

        ///GENMHASH:845984DE82811B6BF5DE9676CE5B433A:E333B3ECA89F7142EFBB8ED6C09C281F
        public FluentImplT WithoutAppSetting(string key)
        {
            appSettingsToRemove.Add(key);
            appSettingStickiness.Remove(key);
            return (FluentImplT) this;
        }

        ///GENMHASH:F49A26C57ADD85EB4F774AACF7455EA0:83C28BA7D84EF699C71803A7D7CFBB80
        public RemoteVisualStudioVersion RemoteDebuggingVersion()
        {
            if (this.SiteConfig == null)
            {
                return null;
            }
            return RemoteVisualStudioVersion.Parse(this.SiteConfig.RemoteDebuggingVersion);
        }

        ///GENMHASH:F5F1D8F285012204F1326EAA44BBE26E:64F71096112779B21E7588E1CF111081
        public WebAppSourceControlImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> DefineSourceControl()
        {
            return new WebAppSourceControlImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT>(
                new SiteSourceControlInner(), this);
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

        ///GENMHASH:78FD17A2E22E150AD12AA226D4123829:20881A157745B3122FA08852FA7B9A5F
        public FluentImplT WithJavaVersion(JavaVersion version)
        {
            if (this.SiteConfig == null)
            {
                this.SiteConfig = new SiteConfigResourceInner();
            }
            this.SiteConfig.JavaVersion = version.ToString();
            return (FluentImplT) this;
        }

        internal abstract Task<SlotConfigNamesResourceInner> UpdateSlotConfigurationsAsync(SlotConfigNamesResourceInner inner, CancellationToken cancellationToken = default(CancellationToken));

        ///GENMHASH:3BE74CEDB189CF13F08D5268649B73D7:FBDC4182C8802269267E808E13D08A16
        public IReadOnlyDictionary<string, IAppSetting> AppSettings()
        {
            return new ReadOnlyDictionary<string, IAppSetting>(cachedAppSettings);
        }

        internal abstract Task<SiteConfigResourceInner> GetConfigInnerAsync(CancellationToken cancellationToken = default(CancellationToken));

        ///GENMHASH:F76B0B1D4816856D9C8EA506F611C03D:2D3BF9E8D775FB6FE81CA6E68F51821E
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

        ///GENMHASH:37E27ADFB836BE1FD0A02912DEE9E60B:35FBE729B5E05F7A5F7D32A4C23D16D7
        public FluentImplT WithStickyAppSettings(IDictionary<string,string> settings)
        {
            WithAppSettings(settings);
            foreach (string key in settings.Keys)
            {
                appSettingStickiness[key] = true;
            }
            return (FluentImplT) this;
        }

        ///GENMHASH:C102774B5B56F13DBA5095A48DC5F846:F6178F0CB26AA5D89FC0751F52A093BD
        public NetFrameworkVersion NetFrameworkVersion()
        {
            if (this.SiteConfig == null)
            {
                return null;
            }
            return Fluent.NetFrameworkVersion.Parse(this.SiteConfig.NetFrameworkVersion);
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

        ///GENMHASH:EDB4EABD52D790D7204DF4CACC39D04A:C925020B1287157BB98149E18416A63F
        public FluentImplT WithAutoSwapSlotName(string slotName)
        {
            if (this.SiteConfig == null)
            {
                this.SiteConfig = new SiteConfigResourceInner();
            }
            this.SiteConfig.AutoSwapSlotName = slotName;
            return (FluentImplT) this;
        }

        ///GENMHASH:750A632B5F062E375E30024C56379A8E:F98F3B7A0499D5EE3A9963286109E6D1
        public string NodeVersion()
        {
            if (this.SiteConfig == null)
            {
                return null;
            }
            return this.SiteConfig.NodeVersion;
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
            SiteConfigResourceInner configObject,
            IAppServiceManager manager)
            : base (name, innerObject, manager)
        {
            if (innerObject != null && innerObject.Kind != null)
            {
                innerObject.Kind = innerObject.Kind.Replace(";", ",");
            }
            this.SiteConfig = configObject;
            NormalizeProperties();
        }

        public override void SetInner(SiteInner innerObject)
        {
            if (innerObject != null && innerObject.Kind != null)
            {
                innerObject.Kind = innerObject.Kind.Replace(";", ",");
            }
            base.SetInner(innerObject);
        }

        ///GENMHASH:3A1ECB38842D1F307BEAA5CE89B8D9A9:5C42B8D5EC49CB7A6DE06E65978C67FF
        public FluentImplT WithScmSiteAlsoStopped(bool scmSiteAlsoStopped)
        {
            Inner.ScmSiteAlsoStopped = scmSiteAlsoStopped;
            return (FluentImplT) this;
        }

        ///GENMHASH:88FB986A040F70D62E535B947213D4C9:1C89F744A8D9C1F5DB0623288789A344
        public string AutoSwapSlotName()
        {
            if (this.SiteConfig == null)
            {
                return null;
            }
            return this.SiteConfig.AutoSwapSlotName;
        }

        ///GENMHASH:C3A15726A3EC798F48295A8FF0867A0B:64440044D8E2B777B70CFCC979127973
        public FluentImplT WithPhpVersion(PhpVersion version)
        {
            if (this.SiteConfig == null)
            {
                this.SiteConfig = new SiteConfigResourceInner();
            }
            this.SiteConfig.PhpVersion = version.ToString();
            return (FluentImplT) this;
        }

        ///GENMHASH:4217B9DCD795EFEFA0771FDE182F0DF5:AEBFCA9CD76563190B8E6FFAC42C860E
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

        ///GENMHASH:B1A8B6AF0882F87FF978C572DA7F4B5C:429417D60E0A61FBA1F29B09E1B0A557
        public FluentImplT WithWebSocketsEnabled(bool enabled)
        {
            if (this.SiteConfig == null)
            {
                this.SiteConfig = new SiteConfigResourceInner();
            }
            this.SiteConfig.WebSocketsEnabled = enabled;
            return (FluentImplT) this;
        }

        ///GENMHASH:DBBC1639A411401B52B0F804284263EE:70126B3DD819B271AE1558799CB9FF14
        public bool AlwaysOn()
        {
            if (this.SiteConfig == null || this.SiteConfig.AlwaysOn == null)
            {
                return false;
            }
            return (bool)this.SiteConfig.AlwaysOn;
        }

        internal abstract Task<SiteConfigResourceInner> CreateOrUpdateSiteConfigAsync(SiteConfigResourceInner siteConfig, CancellationToken cancellationToken = default(CancellationToken));

        ///GENMHASH:FA11486B840C0E86D3D1A446BF2A3C96:33C1F54E166F31D7975C1D7CFEDBE4D3
        public FluentImplT WithStickyAppSetting(string key, string value)
        {
            return WithAppSetting(key, value).WithAppSettingStickiness(key, true);
        }

        ///GENMHASH:58B5A5808212C5DA86843A18CE1F067F:455C7DE078AA851CB5C8F39D0A9260A1
        public string TargetSwapSlot()
        {
            return Inner.TargetSwapSlot;
        }

        ///GENMHASH:3BBC37006EE11765DF55134711F9E6D9:408BCD869DB0D9A064B2707ED604B773
        public FluentImplT WithoutPhp()
        {
            return WithPhpVersion(Fluent.PhpVersion.Parse(""));
        }

        ///GENMHASH:04497E34F1930C831D67A21169FA28E0:5719C33FC3EAF071BCAD1249F58B0A1F
        public string AppServicePlanId()
        {
            return Inner.ServerFarmId;
        }

        ///GENMHASH:F63CA8A7D8722945AE86442FAAE62963:7EB4E2061F48471ACC49772C3793135C
        public bool RemoteDebuggingEnabled()
        {
            if (this.SiteConfig == null || this.SiteConfig.RemoteDebuggingEnabled == null)
            {
                return false;
            }
            return (bool)this.SiteConfig.RemoteDebuggingEnabled;
        }

        ///GENMHASH:13FED596F6C9DDEA581391D2291A4AB1:3E4DE0E9E167232EBC1B15647EFA21AD
        public FluentImplT WithWebContainer(WebContainer webContainer)
        {
            if (this.SiteConfig == null)
            {
                this.SiteConfig = new SiteConfigResourceInner();
            }
            if (webContainer == null)
            {
                this.SiteConfig.JavaContainer = null;
                this.SiteConfig.JavaContainerVersion = null;
            }
            else
            {
                string[] containerInfo = webContainer.ToString().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                this.SiteConfig.JavaContainer = containerInfo[0];
                this.SiteConfig.JavaContainerVersion = containerInfo[1];
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

        ///GENMHASH:C82AC013C402054BF54C48891EAC7C4E:508EE67946380C2FE640CD199C6130F2
        public FluentImplT WithWebAppAlwaysOn(bool alwaysOn)
        {
            if (this.SiteConfig == null)
            {
                this.SiteConfig = new SiteConfigResourceInner();
            }
            this.SiteConfig.AlwaysOn = alwaysOn;
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
        
        ///GENMHASH:23274EA44FADF0D35A6CB3228A47EFD8:9ACE693A325D20B0E77B92545761E40F
        public FluentImplT WithoutAuthentication()
        {
            this.authentication.Inner.Enabled = false;
            authenticationToUpdate = true;
            return (FluentImplT) this;
        }

        ///GENMHASH:F644770BE853EE30024DEE4BE9D96441:049C263D531DF9C62F1DF917EA2491D1
        public OperatingSystem OperatingSystem()
        {
            if (Inner.Kind.ToLower().Contains("linux"))
            {
                return Fluent.OperatingSystem.Linux;
            }
            else
            {
                return Fluent.OperatingSystem.Windows;
            }
        }

        ///GENMHASH:F2F359A4D1C48DF1D575CBA6AD2D6B24:8DED25B1B6AC5BD0C916FD0616562DC8
        public WebAppAuthenticationImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> DefineAuthentication()
        {
            return new WebAppAuthenticationImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT>(new SiteAuthSettingsInner
            {
                Enabled = true
            }, this);
        }
      
       
        ///GENMHASH:8E71F8927E941B28152FA821CDDF0634:27E486AB74A10242FF421C0798DDC450
        internal abstract Task<Models.SiteAuthSettingsInner> GetAuthenticationAsync(CancellationToken cancellationToken = default(CancellationToken));

        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:0365FE7FA5BA46F11AB3094892C8AEC1
        protected abstract Task<Models.SiteInner> GetSiteAsync(CancellationToken cancellationToken = default(CancellationToken));
        
        ///GENMHASH:1B0D5BB9595EC313A20468FF100694B0:D3C435DB0263C2140BE41D5EAE32848D
        public WebAppAuthenticationImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> UpdateAuthentication()
        {
            return authentication;
        }

        ///GENMHASH:21D1748197F7ECC1EFA9660DF579B414:27E486AB74A10242FF421C0798DDC450
        internal abstract Task<Models.SiteAuthSettingsInner> UpdateAuthenticationAsync(SiteAuthSettingsInner inner, CancellationToken cancellationToken = default(CancellationToken));

        ///GENMHASH:C17839133E66320367CE2F5EF66B54F4:6C685EA1512F1D3FDFEFDFE594F83AA2
        public PlatformArchitecture PlatformArchitecture()
        {
            if (_siteConfig.Use32BitWorkerProcess == null || (bool) _siteConfig.Use32BitWorkerProcess)
            {
                return Fluent.PlatformArchitecture.X86;
            }
            else
            {
                return Fluent.PlatformArchitecture.X64;
            }
        }

        ///GENMHASH:1A77ED64E69487E4AA617B8DFCB5EBBB:813687B9CE9E6688BFA2A18264FD8B2D
        internal FluentImplT WithAuthentication(WebAppAuthenticationImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> authentication)
        {
            this.authentication = authentication;
            authenticationToUpdate = true;
            return (FluentImplT) this;
        }

        public abstract Task<IReadOnlyDictionary<string, IHostNameBinding>> GetHostNameBindingsAsync(CancellationToken cancellationToken = default(CancellationToken));
        public abstract Task StartAsync(CancellationToken cancellationToken = default(CancellationToken));
        public abstract Task ApplySlotConfigurationsAsync(string slotName, CancellationToken cancellationToken = default(CancellationToken));
        public abstract Task StopAsync(CancellationToken cancellationToken = default(CancellationToken));
        public abstract Task<IPublishingProfile> GetPublishingProfileAsync(CancellationToken cancellationToken = default(CancellationToken));
        public abstract Task SwapAsync(string slotName, CancellationToken cancellationToken = default(CancellationToken));
        public abstract Task ResetSlotConfigurationsAsync(CancellationToken cancellationToken = default(CancellationToken));
        public abstract Task RestartAsync(CancellationToken cancellationToken = default(CancellationToken));
        public abstract Task<IWebAppSourceControl> GetSourceControlAsync(CancellationToken cancellationToken = default(CancellationToken));


        internal abstract Task<MSDeployStatusInner> CreateMSDeploy(MSDeployInner msDeployInner, CancellationToken cancellationToken);

        public WebDeploymentImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> Deploy()
        {
            return new WebDeploymentImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT>(this);
        }
    }
}
