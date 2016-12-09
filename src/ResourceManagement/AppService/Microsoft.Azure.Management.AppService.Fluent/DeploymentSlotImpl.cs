// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using DeploymentSlot.Definition;
    using DeploymentSlot.Update;
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// The implementation for DeploymentSlot.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmFwcHNlcnZpY2UuaW1wbGVtZW50YXRpb24uRGVwbG95bWVudFNsb3RJbXBs
    internal partial class DeploymentSlotImpl  :
        WebAppBaseImpl<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot,Microsoft.Azure.Management.AppService.Fluent.DeploymentSlotImpl>,
        IDeploymentSlot,
        IDefinition,
        IUpdate
    {
        private WebAppImpl parent;
        private string name;
        ///GENMHASH:07FBC6D492A2E1E463B39D4D7FFC40E9:4C7545D4B87E729AF03CBCFD92BFD349
        internal override async Task<Microsoft.Azure.Management.AppService.Fluent.Models.SiteInner> CreateOrUpdateInnerAsync(SiteInner site, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return client.CreateOrUpdateSlotAsync(resourceGroupName(), parent.Name(), name(), site);

            return null;
        }

        ///GENMHASH:EB854F18026EDB6E01762FA4580BE789:A86CDF620EDA507B778768789373ADBB
        public void Stop()
        {
            //$ client.StopSlot(resourceGroupName(), parent.Name(), name());

        }

        ///GENMHASH:88806945F575AAA522C2E09EBC366CC0:B353870154AE4F874B316FE268431B8E
        internal override async Task<Microsoft.Azure.Management.AppService.Fluent.Models.SiteSourceControlInner> CreateOrUpdateSourceControlAsync(SiteSourceControlInner inner, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return client.CreateOrUpdateSourceControlSlotAsync(resourceGroupName(), parent().Name(), name(), inner);

            return null;
        }

        ///GENMHASH:6779D3D3C7AB7AAAE805BA0ABEE95C51:C466CB0A077AFD0746413FA8E50105BA
        internal override async Task<Microsoft.Azure.Management.AppService.Fluent.Models.StringDictionaryInner> UpdateAppSettingsAsync(StringDictionaryInner inner, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return client.UpdateApplicationSettingsSlotAsync(resourceGroupName(), parent().Name(), name(), inner);

            return null;
        }

        ///GENMHASH:4E8B46C3D832DF7965F98193C5152D88:256BDD90CDF5E9C0BF04ED1F7DE5F0E8
        private void CopyConfigurations(SiteConfigInner configInner, IList<Microsoft.Azure.Management.AppService.Fluent.IAppSetting> appSettings, IList<Microsoft.Azure.Management.AppService.Fluent.IConnectionString> connectionStrings)
        {
            //$ Inner.WithSiteConfig(configInner);
            //$ // app settings
            //$ foreach(var appSetting in appSettings)  {
            //$ if (appSetting.Sticky()) {
            //$ withStickyAppSetting(appSetting.Key(), appSetting.Value());
            //$ } else {
            //$ withAppSetting(appSetting.Key(), appSetting.Value());
            //$ }
            //$ }
            //$ // connection strings
            //$ foreach(var connectionString in connectionStrings)  {
            //$ if (connectionString.Sticky()) {
            //$ withStickyConnectionString(connectionString.Name(), connectionString.Value(), connectionString.Type());
            //$ } else {
            //$ withConnectionString(connectionString.Name(), connectionString.Value(), connectionString.Type());
            //$ }
            //$ }
            //$ }

        }

        ///GENMHASH:620993DCE6DF78140D8125DD97478452:2CA2963CA04CEA1DDD6D97EE4A2DBA0A
        internal override async Task<Microsoft.Azure.Management.AppService.Fluent.Models.StringDictionaryInner> ListAppSettingsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return client.ListApplicationSettingsSlotAsync(resourceGroupName(), parent().Name(), name());

            return null;
        }

        ///GENMHASH:62A0C790E618C837459BE1A5103CA0E5:62654495B4BF32C7D42185FB1022A5EA
        internal override async Task<Microsoft.Azure.Management.AppService.Fluent.Models.SlotConfigNamesResourceInner> ListSlotConfigurationsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return client.ListSlotConfigurationNamesAsync(resourceGroupName(), parent().Name());

            return null;
        }

        ///GENMHASH:807E62B6346803DB90804D0DEBD2FCA6:DE181E1B5D74C99ABFB73A5902B0B888
        internal override async Task DeleteSourceControlAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return client.DeleteSourceControlSlotAsync(resourceGroupName(), parent().Name(), name()).Map(new Func1<Object, Void>() {
            //$ @Override
            //$ public Void call(Object o) {
            //$ return null;
            //$ }
            //$ });

            return;
        }

        ///GENMHASH:F529354C5AB0AFD4EE1F8B0AABF34899:9D5B643E4CC2E0B0C53BBF7A34E7FE45
        public DeploymentSlotImpl WithConfigurationFromWebApp(IWebApp webApp)
        {
            //$ copyConfigurations(webApp.Inner.SiteConfig(), webApp.AppSettings().Values(), webApp.ConnectionStrings().Values());
            //$ return this;

            return this;
        }

        ///GENMHASH:F04F63AA4669C2004D2264538A4A983F:129E57D5B1ECCAA65D812C4E28851FCE
        public DeploymentSlotImpl WithBrandNewConfiguration()
        {
            //$ Inner.WithSiteConfig(null);
            //$ return this;

            return this;
        }

        ///GENMHASH:CC6E0592F0BCD4CD83D832B40167E562:BD6D6B256D3D938F979A97A557F32D5A
        public async Task VerifyDomainOwnershipAsync(string certificateOrderName, string domainVerificationToken, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ IdentifierInner identifierInner = new IdentifierInner().WithIdentifierId(domainVerificationToken);
            //$ identifierInner.WithLocation("global");
            //$ return client.CreateOrUpdateDomainOwnershipIdentifierSlotAsync(resourceGroupName(), parent().Name(), name(), certificateOrderName, identifierInner)
            //$ .Map(new Func1<IdentifierInner, Void>() {
            //$ @Override
            //$ public Void call(IdentifierInner identifierInner) {
            //$ return null;
            //$ }
            //$ });

            return;
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:2436A145BB7A20817F8EDCB98EB71DCC
        public string Name()
        {
            //$ return name;

            return null;
        }

        ///GENMHASH:6799EDFB0B008F8C0EB7E07EE71E6B34:1FEB5AC5504703AC62EC7802B4BCBC4F
        internal async Task<Microsoft.Azure.Management.AppService.Fluent.Models.SiteConfigInner> CreateOrUpdateSiteConfigAsync(SiteConfigInner siteConfig, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return client.CreateOrUpdateConfigurationSlotAsync(resourceGroupName(), parent.Name(), name(), siteConfig);

            return null;
        }

        ///GENMHASH:1AD5C303B4B7C1709305A18733B506B2:F5323F81BCDFCE13F33F49F5F885A65F
        public void ResetSlotConfigurations()
        {
            //$ client.ResetSlotConfigurationSlot(resourceGroupName(), parent().Name(), name());

        }

        ///GENMHASH:08CFC096AC6388D1C0E041ECDF099E3D:E28B203912044121783F6310242520DA
        public void Restart()
        {
            //$ client.RestartSlot(resourceGroupName(), parent.Name(), name());

        }

        ///GENMHASH:3F0152723C985A22C1032733AB942C96:0F92CEDBB6FBA622A8EB7A1971ABB63D
        public IPublishingProfile GetPublishingProfile()
        {
            //$ InputStream stream = client.ListPublishingProfileXmlWithSecretsSlot(resourceGroupName(), parent().Name(), name());
            //$ try {
            //$ String xml = CharStreams.ToString(new InputStreamReader(stream));
            //$ return new PublishingProfileImpl(xml);
            //$ } catch (IOException e) {
            //$ throw new RuntimeException(e);
            //$ }

            return null;
        }

        ///GENMHASH:62F8B201D885123D1E906E306D144662:2DE252A4E4CB1A03D80BB639D9CC1D63
        internal async Task<Microsoft.Azure.Management.AppService.Fluent.Models.SlotConfigNamesResourceInner> UpdateSlotConfigurationsAsync(SlotConfigNamesResourceInner inner, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return client.UpdateSlotConfigurationNamesAsync(resourceGroupName(), parent().Name(), inner);

            return null;
        }

        ///GENMHASH:924482EE7AA6A01820720743C2A59A72:0D008A2337F69A2F68CE4B453B68C91F
        public void ApplySlotConfigurations(string slotName)
        {
            //$ client.ApplySlotConfigurationSlot(resourceGroupName(), parent().Name(), name(), new CsmSlotEntityInner().WithTargetSlot(slotName));
            //$ refresh();

        }

        ///GENMHASH:FD5D5A8D6904B467321E345BE1FA424E:8AB87020DE6C711CD971F3D80C33DD83
        public WebAppImpl Parent()
        {
            //$ return parent;

            return null;
        }

        ///GENMHASH:0FE78F842439357DA0333AABD3B95D59:1921F0155028390EDD9DC6464E29986A
        internal async Task<Microsoft.Azure.Management.AppService.Fluent.Models.ConnectionStringDictionaryInner> ListConnectionStringsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return client.ListConnectionStringsSlotAsync(resourceGroupName(), parent().Name(), name());

            return null;
        }

        ///GENMHASH:21FDAEDB996672BE017C01C5DD8758D4:4D11AFF71F3B252DAF2FF3516CE8079B
        internal async Task<Microsoft.Azure.Management.AppService.Fluent.Models.ConnectionStringDictionaryInner> UpdateConnectionStringsAsync(ConnectionStringDictionaryInner inner, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return client.UpdateConnectionStringsSlotAsync(resourceGroupName(), parent().Name(), name(), inner);

            return null;
        }

        ///GENMHASH:7165E4A72787EF020E1C59029B4D2D13:47A3B406E5605E5ECAF2C6AD49296A9F
        internal DeploymentSlotImpl(string name, SiteInner innerObject, SiteConfigInner configObject, WebAppImpl parent, WebAppsOperations client, AppServiceManager manager, WebSiteManagementClient serviceClient)
            : base (name.ReplaceAll(".*/", ""), innerObject, configObject, client, manager, serviceClient)
        {
            //$ super(name.ReplaceAll(".*/", ""), innerObject, configObject, client, manager, serviceClient);
            //$ this.name = name.ReplaceAll(".*/", "");
            //$ this.parent = parent;
            //$ Inner.WithServerFarmId(parent.AppServicePlanId());
            //$ }

        }

        ///GENMHASH:256905D5B839C64BFE9830503CB5607B:EEE6F5F14FBF97AB824F4DC5BEE421C9
        internal async Task<Microsoft.Azure.Management.AppService.Fluent.Models.SiteConfigInner> GetConfigInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return client.GetConfigurationSlotAsync(resourceGroupName(), parent().Name(), name());

            return null;
        }

        ///GENMHASH:8C5F8B18192B4F8FD7D43AB4D318EA69:B391F0DC172F1C96A8CB5A3DC9D8EAB6
        public IReadOnlyDictionary<string,Microsoft.Azure.Management.AppService.Fluent.IHostNameBinding> GetHostNameBindings()
        {
            //$ List<HostNameBindingInner> collectionInner = client.ListHostNameBindingsSlot(resourceGroupName(), parent.Name(), name());
            //$ List<HostNameBinding> hostNameBindings = new ArrayList<>();
            //$ foreach(var inner in collectionInner)  {
            //$ hostNameBindings.Add(new HostNameBindingImpl<>(inner, this, client));
            //$ }
            //$ return Maps.UniqueIndex(hostNameBindings, new Function<HostNameBinding, String>() {
            //$ @Override
            //$ public String apply(HostNameBinding input) {
            //$ return input.Name().Replace(name() + "/", "");
            //$ }
            //$ });

            return null;
        }

        ///GENMHASH:EB8C33DACE377CBB07C354F38C5BEA32:391885361D8D6FDB8CD9E96400E16B73
        public void VerifyDomainOwnership(string certificateOrderName, string domainVerificationToken)
        {
            //$ verifyDomainOwnershipAsync(certificateOrderName, domainVerificationToken).ToBlocking().Subscribe();

        }

        ///GENMHASH:BC96AA8FDB678157AC1E6F0AA511AB65:7FD11F8640B85B9B7322C618E790CC30
        public IWebAppSourceControl GetSourceControl()
        {
            //$ SiteSourceControlInner siteSourceControlInner = client.GetSourceControlSlot(resourceGroupName(), parent().Name(), name());
            //$ return new WebAppSourceControlImpl<>(siteSourceControlInner, this, serviceClient);

            return null;
        }

        ///GENMHASH:9EC0529BA0D08B75AD65E98A4BA01D5D:44153E55F54D6CEBEDD20C31326CBA9E
        internal async Task<Microsoft.Azure.Management.AppService.Fluent.Models.SiteInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return client.GetSlotAsync(resourceGroupName(), parent.Name(), name());

            return null;
        }

        ///GENMHASH:0F38250A3837DF9C2C345D4A038B654B:C11CD62012747112F730C878E811FD3B
        public void Start()
        {
            //$ client.StartSlot(resourceGroupName(), parent.Name(), name());

        }

        ///GENMHASH:9754CAF64EAC70E3B92A0EEED2DC1120:D7EF25AACEC219C83202353B07AAA174
        public DeploymentSlotImpl WithConfigurationFromParent()
        {
            //$ return withConfigurationFromWebApp(parent);

            return this;
        }

        ///GENMHASH:DFC52755A97E7B13EB10FA2EB9538E4A:30D469A4DF2C04EC877197A738D1D873
        public void Swap(string slotName)
        {
            //$ client.SwapSlotSlot(resourceGroupName(), parent().Name(), name(), new CsmSlotEntityInner().WithTargetSlot(slotName));
            //$ refresh();

        }

        ///GENMHASH:68C25D685A0291AC775CEA8FCE1D7E20:19F7AEA76877B47E32F58082C59F91CA
        public DeploymentSlotImpl WithConfigurationFromDeploymentSlot(IDeploymentSlot slot)
        {
            //$ copyConfigurations(slot.Inner.SiteConfig(), slot.AppSettings().Values(), slot.ConnectionStrings().Values());
            //$ return this;

            return this;
        }

        ///GENMHASH:FCAC8C2F8D6E12CB6F5D7787A2837016:6EA475A78A58FF77FEECBC549D8F6A5A
        internal async Task DeleteHostNameBindingAsync(string hostname, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return client.DeleteHostNameBindingSlotAsync(resourceGroupName(), parent().Name(), name(), hostname);

            return null;
        }
    }
}