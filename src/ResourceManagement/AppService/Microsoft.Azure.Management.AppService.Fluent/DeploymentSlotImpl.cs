// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using DeploymentSlot.Definition;
    using DeploymentSlot.Update;
    using Models;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The implementation for DeploymentSlot.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmFwcHNlcnZpY2UuaW1wbGVtZW50YXRpb24uRGVwbG95bWVudFNsb3RJbXBs
    internal partial class DeploymentSlotImpl :
        WebAppBaseImpl<
            IDeploymentSlot,
            DeploymentSlotImpl,
            object,
            object,
            IUpdate>,
        IDeploymentSlot,
        IDefinition,
        IUpdate
    {
        private WebAppImpl parent;
        private string name;

        ///GENMHASH:07FBC6D492A2E1E463B39D4D7FFC40E9:6015327ABEB713972CA126D7A0F3C232
        internal async override Task<SiteInner> CreateOrUpdateInnerAsync(SiteInner site, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Manager.Inner.WebApps.CreateOrUpdateSlotAsync(ResourceGroupName, parent.Name, site, Name(), cancellationToken: cancellationToken);
        }

        ///GENMHASH:EB854F18026EDB6E01762FA4580BE789:E08F92567FBEC84BEB0BF3AD4DF89EDC
        public override void Stop()
        {
            Manager.Inner.WebApps.StopSlot(ResourceGroupName, parent.Name, Name());
        }

        ///GENMHASH:88806945F575AAA522C2E09EBC366CC0:648365CFF3D36F6215B51C13E63240EA
        internal async override Task<SiteSourceControlInner> CreateOrUpdateSourceControlAsync(SiteSourceControlInner inner, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Manager.Inner.WebApps.CreateOrUpdateSourceControlSlotAsync(ResourceGroupName, parent.Name, inner, Name(), cancellationToken);
        }

        ///GENMHASH:6779D3D3C7AB7AAAE805BA0ABEE95C51:53A4EABE2126D220941754E8D00A25CF
        internal async override Task<Microsoft.Azure.Management.AppService.Fluent.Models.StringDictionaryInner> UpdateAppSettingsAsync(StringDictionaryInner inner, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Manager.Inner.WebApps.UpdateApplicationSettingsSlotAsync(ResourceGroupName, parent.Name, inner, Name(), cancellationToken);
        }

        ///GENMHASH:16850E2C75364DB3483B86D73CBDEC35:256BDD90CDF5E9C0BF04ED1F7DE5F0E8
        private void CopyConfigurations(SiteConfigResourceInner configInner, IList<Microsoft.Azure.Management.AppService.Fluent.IAppSetting> appSettings, IList<Microsoft.Azure.Management.AppService.Fluent.IConnectionString> connectionStrings)
        {
            this.SiteConfig = configInner;
            // app settings
            foreach (var appSetting in appSettings)
            {
                if (appSetting.Sticky)
                {
                    WithStickyAppSetting(appSetting.Key, appSetting.Value);
                }
                else
                {
                    WithAppSetting(appSetting.Key, appSetting.Value);
                }
            }
            // connection strings
            foreach (var connectionString in connectionStrings)
            {
                if (connectionString.Sticky)
                {
                    WithStickyConnectionString(connectionString.Name, connectionString.Value, connectionString.Type);
                }
                else
                {
                    WithConnectionString(connectionString.Name, connectionString.Value, connectionString.Type);
                }
            }
        }

        ///GENMHASH:620993DCE6DF78140D8125DD97478452:897C9FB93A39950E97CA9111CAE33AAD
        internal async override Task<Microsoft.Azure.Management.AppService.Fluent.Models.StringDictionaryInner> ListAppSettingsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Manager.Inner.WebApps.ListApplicationSettingsSlotAsync(ResourceGroupName, parent.Name, Name());
        }

        ///GENMHASH:62A0C790E618C837459BE1A5103CA0E5:DADE97E21BF8291BE266AB1DFA8E92FC
        internal async override Task<Microsoft.Azure.Management.AppService.Fluent.Models.SlotConfigNamesResourceInner> ListSlotConfigurationsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Manager.Inner.WebApps.ListSlotConfigurationNamesAsync(ResourceGroupName, parent.Name);
        }

        ///GENMHASH:807E62B6346803DB90804D0DEBD2FCA6:3660A2CDB06ACF2E101AA99CFACF48CD
        internal async override Task DeleteSourceControlAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await Manager.Inner.WebApps.DeleteSourceControlSlotAsync(ResourceGroupName, parent.Name, Name());
        }

        ///GENMHASH:F529354C5AB0AFD4EE1F8B0AABF34899:D375F18C8B128D8FF0869B061F7CD9E9
        public DeploymentSlotImpl WithConfigurationFromWebApp(IWebApp webApp)
        {
            CopyConfigurations(((WebAppImpl) webApp).SiteConfig, webApp.AppSettings.Values.ToList(), webApp.ConnectionStrings.Values.ToList());
            return this;
        }

        ///GENMHASH:F04F63AA4669C2004D2264538A4A983F:DD495ED57FC66742E9F007B2F5A0E60A
        public DeploymentSlotImpl WithBrandNewConfiguration()
        {
            Inner.SiteConfig = new Models.SiteConfig();

            return this;
        }

        ///GENMHASH:CC6E0592F0BCD4CD83D832B40167E562:BBBE3BCF158566C63DBA770C071B146A
        public async override Task VerifyDomainOwnershipAsync(string certificateOrderName, string domainVerificationToken, CancellationToken cancellationToken = default(CancellationToken))
        {
            IdentifierInner identifierInner = new IdentifierInner()
            {
                IdentifierId = domainVerificationToken,
                Location = "global"
            };

            await Manager.Inner.WebApps.CreateOrUpdateDomainOwnershipIdentifierSlotAsync(ResourceGroupName, parent.Name, Name(), identifierInner, certificateOrderName, cancellationToken);
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:2436A145BB7A20817F8EDCB98EB71DCC
        new public string Name()
        {
            return name;
        }

        ///GENMHASH:6799EDFB0B008F8C0EB7E07EE71E6B34:1FEB5AC5504703AC62EC7802B4BCBC4F

        internal async override Task<Microsoft.Azure.Management.AppService.Fluent.Models.SiteConfigResourceInner> CreateOrUpdateSiteConfigAsync(SiteConfigResourceInner siteConfig, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Manager.Inner.WebApps.CreateOrUpdateConfigurationSlotAsync(ResourceGroupName, parent.Name, siteConfig, Name(), cancellationToken);
        }

        ///GENMHASH:1AD5C303B4B7C1709305A18733B506B2:0BA6545E2E5A5E654CE278DD5968E11F
        public override void ResetSlotConfigurations()
        {
            Manager.Inner.WebApps.ResetSlotConfigurationSlot(ResourceGroupName, parent.Name, Name());
        }

        ///GENMHASH:08CFC096AC6388D1C0E041ECDF099E3D:44C76716F153B9042AE98C1BCBC503F2
        public override void Restart()
        {
            Manager.Inner.WebApps.RestartSlot(ResourceGroupName, parent.Name, Name());
        }

        ///GENMHASH:3F0152723C985A22C1032733AB942C96:6FCE951A1B9813960CE8873DF107297F
        public override IPublishingProfile GetPublishingProfile()
        {
            Stream stream = Manager.Inner.WebApps.ListPublishingProfileXmlWithSecretsSlot(ResourceGroupName, Parent().Name, Name());
            StreamReader reader = new StreamReader(stream);
            string xml = reader.ReadToEnd();
            return new PublishingProfileImpl(xml, this);
        }

        ///GENMHASH:62F8B201D885123D1E906E306D144662:88BEE6CEAD1A9FC39C629C20B3DA3F56
        internal async override Task<Microsoft.Azure.Management.AppService.Fluent.Models.SlotConfigNamesResourceInner> UpdateSlotConfigurationsAsync(SlotConfigNamesResourceInner inner, CancellationToken cancellationToken = default(CancellationToken))
        {
<<<<<<<<<<<<<<<<<<<<<<<<<<<CHANGED>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //$ return manager().Inner().WebApps().UpdateSlotConfigurationNamesAsync(resourceGroupName(), parent().Name(), inner);

<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

            return await Manager.Inner.WebApps.UpdateSlotConfigurationNamesAsync(ResourceGroupName, parent.Name, inner, cancellationToken);
        }

        ///GENMHASH:924482EE7AA6A01820720743C2A59A72:E50B17913B8A65047092DD2C6D6AFE8C
        public override void ApplySlotConfigurations(string slotName)
        {
<<<<<<<<<<<<<<<<<<<<<<<<<<<CHANGED>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //$ applySlotConfigurationsAsync(slotName).ToObservable().ToBlocking().Subscribe();

<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

            Manager.Inner.WebApps.ApplySlotConfigurationSlot(ResourceGroupName, parent.Name, new CsmSlotEntityInner()
            {
                TargetSlot = slotName
            }, Name());
            Refresh();
        }

        ///GENMHASH:FD5D5A8D6904B467321E345BE1FA424E:7D20AFF6B32FFD01B49036D5C89ED11D
        public WebAppImpl Parent()
        {
<<<<<<<<<<<<<<<<<<<<<<<<<<<CHANGED>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //$ return this.parent;

<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

            return parent;
        }

        ///GENMHASH:0FE78F842439357DA0333AABD3B95D59:93410E420C7CA4E29C47B730671408CF
        internal async override Task<Microsoft.Azure.Management.AppService.Fluent.Models.ConnectionStringDictionaryInner> ListConnectionStringsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
<<<<<<<<<<<<<<<<<<<<<<<<<<<CHANGED>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //$ return manager().Inner().WebApps().ListConnectionStringsSlotAsync(resourceGroupName(), parent().Name(), name());

<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

            return await Manager.Inner.WebApps.ListConnectionStringsSlotAsync(ResourceGroupName, parent.Name, Name());
        }

        ///GENMHASH:21FDAEDB996672BE017C01C5DD8758D4:42826DB217BC1AEE5AAA977944F4318D
        internal async override Task<Microsoft.Azure.Management.AppService.Fluent.Models.ConnectionStringDictionaryInner> UpdateConnectionStringsAsync(ConnectionStringDictionaryInner inner, CancellationToken cancellationToken = default(CancellationToken))
        {
<<<<<<<<<<<<<<<<<<<<<<<<<<<CHANGED>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //$ return manager().Inner().WebApps().UpdateConnectionStringsSlotAsync(resourceGroupName(), parent().Name(), name(), inner);

<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

            return await Manager.Inner.WebApps.UpdateConnectionStringsSlotAsync(ResourceGroupName, parent.Name, inner, Name(), cancellationToken);
        }

        ///GENMHASH:7165E4A72787EF020E1C59029B4D2D13:A0244A057D0D2A3944D2A1B6B5FC52D6

<<<<<<<<<<<<<<<<<<<<<<<<<<<DELETED>>>>>>>>>>>>>>>>>>>>>>>>>>>
        internal DeploymentSlotImpl(
            string name,
            SiteInner innerObject,
            SiteConfigResourceInner configObject,
            WebAppImpl parent,
            IAppServiceManager manager)
                    : base(Regex.Replace(name, ".*/", ""), innerObject, configObject, manager)
        {
            this.name = Regex.Replace(name, ".*/", "");
            this.parent = parent;
            Inner.ServerFarmId = parent.AppServicePlanId();
        }

        ///GENMHASH:256905D5B839C64BFE9830503CB5607B:2A8EC434FA469B509BF4B734F95469CD
        internal async override Task<SiteConfigResourceInner> GetConfigInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
<<<<<<<<<<<<<<<<<<<<<<<<<<<CHANGED>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //$ return manager().Inner().WebApps().GetConfigurationSlotAsync(resourceGroupName(), parent().Name(), name());

<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

            return await Manager.Inner.WebApps.GetConfigurationSlotAsync(ResourceGroupName, parent.Name, Name());
        }

        ///GENMHASH:8C5F8B18192B4F8FD7D43AB4D318EA69:3D9AAF779EB9D14F1D1CEB4D1C1D5CA2
        public override IReadOnlyDictionary<string, Microsoft.Azure.Management.AppService.Fluent.IHostNameBinding> GetHostNameBindings()
        {
<<<<<<<<<<<<<<<<<<<<<<<<<<<CHANGED>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //$ return getHostNameBindingsAsync().ToBlocking().Single();

<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

            var collectionInner = Manager.Inner.WebApps.ListHostNameBindingsSlot(ResourceGroupName, parent.Name, Name());
            return collectionInner.ToDictionary(input => input.Name.Replace(Name() + "/", ""),
                inner => (IHostNameBinding)new HostNameBindingImpl<IDeploymentSlot, DeploymentSlotImpl, object, object, IUpdate>(
                    inner,
                    this));
        }

        ///GENMHASH:EB8C33DACE377CBB07C354F38C5BEA32:40B9A5AF5E2BAAC912A2E077A8B03C22
        public override void VerifyDomainOwnership(string certificateOrderName, string domainVerificationToken)
        {
<<<<<<<<<<<<<<<<<<<<<<<<<<<CHANGED>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //$ verifyDomainOwnershipAsync(certificateOrderName, domainVerificationToken).ToObservable().ToBlocking().Subscribe();

<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

            VerifyDomainOwnership(certificateOrderName, domainVerificationToken);
        }

        ///GENMHASH:BC96AA8FDB678157AC1E6F0AA511AB65:55CBEA763E5EA0A02A785BC1273C63B0
        public override IWebAppSourceControl GetSourceControl()
        {
<<<<<<<<<<<<<<<<<<<<<<<<<<<CHANGED>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //$ return getSourceControlAsync().ToBlocking().Single();

<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

            var siteSourceControlInner = Manager.Inner.WebApps.GetSourceControlSlot(ResourceGroupName, parent.Name, Name());
            return new WebAppSourceControlImpl<IDeploymentSlot, DeploymentSlotImpl, object, object, IUpdate>(
                siteSourceControlInner,
                this);
        }

        ///GENMHASH:9EC0529BA0D08B75AD65E98A4BA01D5D:88C44586E83A2B7A08C556A1E66B6647
        protected async override Task<Microsoft.Azure.Management.AppService.Fluent.Models.SiteInner> GetSiteAsync(CancellationToken cancellationToken)
        {
<<<<<<<<<<<<<<<<<<<<<<<<<<<CHANGED>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //$ return manager().Inner().WebApps().GetSlotAsync(resourceGroupName(), this.parent().Name(), name());

<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

            return await Manager.Inner.WebApps.GetSlotAsync(ResourceGroupName, parent.Name, Name(), cancellationToken);
        }

        ///GENMHASH:0F38250A3837DF9C2C345D4A038B654B:01DA6136E32014808DDE7F0C637CF668
        public override void Start()
        {
<<<<<<<<<<<<<<<<<<<<<<<<<<<CHANGED>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //$ startAsync().ToObservable().ToBlocking().Subscribe();

<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

            Manager.Inner.WebApps.StartSlot(ResourceGroupName, parent.Name, Name());
        }

        ///GENMHASH:9754CAF64EAC70E3B92A0EEED2DC1120:F4C48AA95D98CB150D145294CB2F63A3
        public DeploymentSlotImpl WithConfigurationFromParent()
        {
<<<<<<<<<<<<<<<<<<<<<<<<<<<CHANGED>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //$ return withConfigurationFromWebApp(this.parent());

<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

            return WithConfigurationFromWebApp(parent);
        }

        ///GENMHASH:DFC52755A97E7B13EB10FA2EB9538E4A:31BC86C370122E939BA1BA0EC17B6967
        public override void Swap(string slotName)
        {
<<<<<<<<<<<<<<<<<<<<<<<<<<<CHANGED>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //$ swapAsync(slotName).ToObservable().ToBlocking().Subscribe();

<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

            Manager.Inner.WebApps.SwapSlotSlot(ResourceGroupName, parent.Name, new CsmSlotEntityInner()
            {
                TargetSlot = slotName
            }, Name());

            Refresh();
        }

        ///GENMHASH:68C25D685A0291AC775CEA8FCE1D7E20:2E6C811242BD3A1510505903152E128D
        public DeploymentSlotImpl WithConfigurationFromDeploymentSlot(IDeploymentSlot slot)
        {
<<<<<<<<<<<<<<<<<<<<<<<<<<<CHANGED>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //$ copyConfigurations(((WebAppBaseImpl) slot).SiteConfig, slot.AppSettings().Values(), slot.ConnectionStrings().Values());
            //$ return this;

<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

            CopyConfigurations(((DeploymentSlotImpl) slot).SiteConfig, slot.AppSettings.Values.ToList(), slot.ConnectionStrings.Values.ToList());
            return this;
        }

        ///GENMHASH:FCAC8C2F8D6E12CB6F5D7787A2837016:8A3C0887B28AA9A7371C1C4B64C83BCF
        internal async override Task DeleteHostNameBindingAsync(string hostname, CancellationToken cancellationToken = default(CancellationToken))
        {
<<<<<<<<<<<<<<<<<<<<<<<<<<<CHANGED>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //$ return manager().Inner().WebApps().DeleteHostNameBindingSlotAsync(resourceGroupName(), parent().Name(), name(), hostname);

<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

            await Manager.Inner.WebApps.DeleteHostNameBindingSlotAsync(ResourceGroupName, parent.Name, Name(), hostname, cancellationToken);
        }

<<<<<<<<<<<<<<<<<<<<<<<<<<<NEW>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///GENMHASH:4F0DD1E3F09332DAEE78A7163765E0EA:914E3D3E4490586830155D1809FE1EBE
        public async Task<Microsoft.Azure.Management.AppService.Fluent.IPublishingProfile> GetPublishingProfileAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return manager().Inner().WebApps().ListPublishingProfileXmlWithSecretsSlotAsync(resourceGroupName(), this.parent().Name(), name())
            //$ .Map(new Func1<InputStream, PublishingProfile>() {
            //$ @Override
            //$ public PublishingProfile call(InputStream stream) {
            //$ try {
            //$ String xml = CharStreams.ToString(new InputStreamReader(stream));
            //$ return new PublishingProfileImpl(xml, DeploymentSlotImpl.This);
            //$ } catch (IOException e) {
            //$ throw new RuntimeException(e);
            //$ }
            //$ }
            //$ });
            //$ }

            return null;
        }

<<<<<<<<<<<<<<<<<<<<<<<<<<<NEW>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///GENMHASH:2BE74359D5F3E0281DC4391F52057FEB:382359AAE8A506B868C501437F47C279
        public async Task<Microsoft.Azure.Management.AppService.Fluent.IWebAppSourceControl> GetSourceControlAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return manager().Inner().WebApps().GetSourceControlSlotAsync(resourceGroupName(), parent().Name(), name())
            //$ .Map(new Func1<SiteSourceControlInner, WebAppSourceControl>() {
            //$ @Override
            //$ public WebAppSourceControl call(SiteSourceControlInner siteSourceControlInner) {
            //$ return new WebAppSourceControlImpl<>(siteSourceControlInner, DeploymentSlotImpl.This);
            //$ }
            //$ });

            return null;
        }

<<<<<<<<<<<<<<<<<<<<<<<<<<<NEW>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///GENMHASH:FEB63CBC1CA7D22A121F19D94AB44052:4EE46F34B076F4B43C1E61C5E9ADD07C
        public async Task RestartAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return manager().Inner().WebApps().RestartSlotAsync(resourceGroupName(), this.parent().Name(), name())
            //$ .FlatMap(new Func1<Void, Observable<?>>() {
            //$ @Override
            //$ public Observable<?> call(Void aVoid) {
            //$ return refreshAsync();
            //$ }
            //$ }).ToCompletable();

            return null;
        }

<<<<<<<<<<<<<<<<<<<<<<<<<<<NEW>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///GENMHASH:D6FBED7FC7CBF34940541851FF5C3CC1:06F0D66A362CC364C51A49E48E7CA53B
        public async Task StopAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return manager().Inner().WebApps().StopSlotAsync(resourceGroupName(), this.parent().Name(), name())
            //$ .FlatMap(new Func1<Void, Observable<?>>() {
            //$ @Override
            //$ public Observable<?> call(Void aVoid) {
            //$ return refreshAsync();
            //$ }
            //$ }).ToCompletable();

            return null;
        }

<<<<<<<<<<<<<<<<<<<<<<<<<<<NEW>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///GENMHASH:21D1748197F7ECC1EFA9660DF579B414:5C0A7336725B7FB6E200C1ED27F5CB4C
        internal async Task<Models.SiteAuthSettingsInner> UpdateAuthenticationAsync(SiteAuthSettingsInner inner, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return manager().Inner().WebApps().UpdateAuthSettingsSlotAsync(resourceGroupName(), parent().Name(), name(), inner);

            return null;
        }

<<<<<<<<<<<<<<<<<<<<<<<<<<<NEW>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///GENMHASH:DEC174D8970BF9488F3C635245A48467:C2605F11054FC66A805BECBAE7DAAB1F
        public async Task ApplySlotConfigurationsAsync(string slotName, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return manager().Inner().WebApps().ApplySlotConfigurationSlotAsync(resourceGroupName(), this.parent().Name(), name(), new CsmSlotEntityInner().WithTargetSlot(slotName))
            //$ .FlatMap(new Func1<Void, Observable<?>>() {
            //$ @Override
            //$ public Observable<?> call(Void aVoid) {
            //$ return refreshAsync();
            //$ }
            //$ }).ToCompletable();

            return null;
        }

<<<<<<<<<<<<<<<<<<<<<<<<<<<NEW>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///GENMHASH:A8A7ED895B55687EE960176ECD2570B6:A1DEA977D740E0ACAD3D94D991CA9F7F
        internal async Task<Models.SiteConfigResourceInner> CreateOrUpdateSiteConfigAsync(SiteConfigResourceInner siteConfig, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return manager().Inner().WebApps().CreateOrUpdateConfigurationSlotAsync(resourceGroupName(), this.parent().Name(), name(), siteConfig);

            return null;
        }

<<<<<<<<<<<<<<<<<<<<<<<<<<<NEW>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///GENMHASH:D5AD274A3026D80CDF6A0DD97D9F20D4:4895185A183470C4839F69A47A61C826
        public async Task StartAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return manager().Inner().WebApps().StartSlotAsync(resourceGroupName(), this.parent().Name(), name())
            //$ .FlatMap(new Func1<Void, Observable<?>>() {
            //$ @Override
            //$ public Observable<?> call(Void aVoid) {
            //$ return refreshAsync();
            //$ }
            //$ }).ToCompletable();

            return null;
        }

<<<<<<<<<<<<<<<<<<<<<<<<<<<NEW>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///GENMHASH:8E71F8927E941B28152FA821CDDF0634:FE3484EE3177CF2A5BBF1D4825D24686
        internal async Task<Models.SiteAuthSettingsInner> GetAuthenticationAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return manager().Inner().WebApps().GetAuthSettingsSlotAsync(resourceGroupName(), parent().Name(), name());

            return null;
        }

<<<<<<<<<<<<<<<<<<<<<<<<<<<NEW>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///GENMHASH:AE14C7C2170289895AEFF07E3516A2FC:0A62D57A2A28811F577B31E7B80922B8
        public async Task ResetSlotConfigurationsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return manager().Inner().WebApps().ResetSlotConfigurationSlotAsync(resourceGroupName(), this.parent().Name(), name())
            //$ .FlatMap(new Func1<Void, Observable<?>>() {
            //$ @Override
            //$ public Observable<?> call(Void aVoid) {
            //$ return refreshAsync();
            //$ }
            //$ }).ToCompletable();

            return null;
        }

<<<<<<<<<<<<<<<<<<<<<<<<<<<NEW>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///GENMHASH:76AEBCD715B20346607E894C7654D2CA:8D94A81D4639359EB1DD5E5F5E51448B
        private void CopyConfigurations(SiteConfigResourceInner configInner, IList<Microsoft.Azure.Management.AppService.Fluent.IAppSetting> appSettings, IList<Microsoft.Azure.Management.AppService.Fluent.IConnectionString> connectionStrings)
        {
            //$ this.SiteConfig = configInner;
            //$ // app settings
            //$ for (AppSetting appSetting : appSettings) {
            //$ if (appSetting.Sticky()) {
            //$ withStickyAppSetting(appSetting.Key(), appSetting.Value());
            //$ } else {
            //$ withAppSetting(appSetting.Key(), appSetting.Value());
            //$ }
            //$ }
            //$ // connection strings
            //$ for (ConnectionString connectionString : connectionStrings) {
            //$ if (connectionString.Sticky()) {
            //$ withStickyConnectionString(connectionString.Name(), connectionString.Value(), connectionString.Type());
            //$ } else {
            //$ withConnectionString(connectionString.Name(), connectionString.Value(), connectionString.Type());
            //$ }
            //$ }
            //$ }

        }

<<<<<<<<<<<<<<<<<<<<<<<<<<<NEW>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///GENMHASH:E7F5C40042323022AA5171FA979A6E79:3FE2818FBB1E53B61C9410D539937251
        public async Task SwapAsync(string slotName, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return manager().Inner().WebApps().SwapSlotSlotAsync(resourceGroupName(), this.parent().Name(), name(), new CsmSlotEntityInner().WithTargetSlot(slotName))
            //$ .FlatMap(new Func1<Void, Observable<?>>() {
            //$ @Override
            //$ public Observable<?> call(Void aVoid) {
            //$ return refreshAsync();
            //$ }
            //$ }).ToCompletable();

            return null;
        }

<<<<<<<<<<<<<<<<<<<<<<<<<<<NEW>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///GENMHASH:E10A5B0FD0E95947B1A669D51E6BD5C9:881BEC2EF02A1B077151181C52C03DD3
        public async Task<System.Collections.Generic.IDictionary<string,Microsoft.Azure.Management.AppService.Fluent.IHostNameBinding>> GetHostNameBindingsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return this.Manager().Inner().WebApps().ListHostNameBindingsSlotAsync(resourceGroupName(), parent().Name(), name())
            //$ .FlatMap(new Func1<Page<HostNameBindingInner>, Observable<HostNameBindingInner>>() {
            //$ @Override
            //$ public Observable<HostNameBindingInner> call(Page<HostNameBindingInner> hostNameBindingInnerPage) {
            //$ return Observable.From(hostNameBindingInnerPage.Items());
            //$ }
            //$ })
            //$ .Map(new Func1<HostNameBindingInner, HostNameBinding>() {
            //$ @Override
            //$ public HostNameBinding call(HostNameBindingInner hostNameBindingInner) {
            //$ return new HostNameBindingImpl<>(hostNameBindingInner, DeploymentSlotImpl.This);
            //$ }
            //$ }).ToList()
            //$ .Map(new Func1<List<HostNameBinding>, Map<String, HostNameBinding>>() {
            //$ @Override
            //$ public Map<String, HostNameBinding> call(List<HostNameBinding> hostNameBindings) {
            //$ return Collections.UnmodifiableMap(Maps.UniqueIndex(hostNameBindings, new Function<HostNameBinding, String>() {
            //$ @Override
            //$ public String apply(HostNameBinding input) {
            //$ return input.Name().Replace(name() + "/", "");
            //$ }
            //$ }));
            //$ }
            //$ });

            return null;
        }

    }
}
