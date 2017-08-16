// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using DeploymentSlot.Definition;
    using DeploymentSlot.Update;
    using Models;
    using ResourceManager.Fluent.Core;
    using System;
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
            Extensions.Synchronize(() => Manager.Inner.WebApps.StopSlotAsync(ResourceGroupName, parent.Name, Name()));
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
                IdentifierId = domainVerificationToken
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
            Extensions.Synchronize(() => Manager.Inner.WebApps.ResetSlotConfigurationSlotAsync(ResourceGroupName, parent.Name, Name()));
        }

        ///GENMHASH:08CFC096AC6388D1C0E041ECDF099E3D:44C76716F153B9042AE98C1BCBC503F2
        public override void Restart()
        {
            Extensions.Synchronize(() => Manager.Inner.WebApps.RestartSlotAsync(ResourceGroupName, parent.Name, Name()));
        }

        ///GENMHASH:3F0152723C985A22C1032733AB942C96:6FCE951A1B9813960CE8873DF107297F
        public override IPublishingProfile GetPublishingProfile()
        {
            Stream stream = Extensions.Synchronize(() => Manager.Inner.WebApps.ListPublishingProfileXmlWithSecretsSlotAsync(ResourceGroupName, Parent().Name, new CsmPublishingProfileOptionsInner(), Name()));
            StreamReader reader = new StreamReader(stream);
            string xml = reader.ReadToEnd();
            return new PublishingProfileImpl(xml);
        }

        ///GENMHASH:62F8B201D885123D1E906E306D144662:88BEE6CEAD1A9FC39C629C20B3DA3F56
        internal async override Task<Microsoft.Azure.Management.AppService.Fluent.Models.SlotConfigNamesResourceInner> UpdateSlotConfigurationsAsync(SlotConfigNamesResourceInner inner, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Manager.Inner.WebApps.UpdateSlotConfigurationNamesAsync(ResourceGroupName, parent.Name, inner, cancellationToken);
        }

        ///GENMHASH:924482EE7AA6A01820720743C2A59A72:E50B17913B8A65047092DD2C6D6AFE8C
        public override void ApplySlotConfigurations(string slotName)
        {
            Extensions.Synchronize(() => Manager.Inner.WebApps.ApplySlotConfigurationSlotAsync(ResourceGroupName, parent.Name, new CsmSlotEntityInner()
            {
                TargetSlot = slotName
            }, Name()));
            Refresh();
        }

        ///GENMHASH:FD5D5A8D6904B467321E345BE1FA424E:7D20AFF6B32FFD01B49036D5C89ED11D
        public WebAppImpl Parent()
        {
            return parent;
        }

        ///GENMHASH:0FE78F842439357DA0333AABD3B95D59:93410E420C7CA4E29C47B730671408CF
        internal async override Task<Microsoft.Azure.Management.AppService.Fluent.Models.ConnectionStringDictionaryInner> ListConnectionStringsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Manager.Inner.WebApps.ListConnectionStringsSlotAsync(ResourceGroupName, parent.Name, Name());
        }

        ///GENMHASH:21FDAEDB996672BE017C01C5DD8758D4:42826DB217BC1AEE5AAA977944F4318D
        internal async override Task<Microsoft.Azure.Management.AppService.Fluent.Models.ConnectionStringDictionaryInner> UpdateConnectionStringsAsync(ConnectionStringDictionaryInner inner, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Manager.Inner.WebApps.UpdateConnectionStringsSlotAsync(ResourceGroupName, parent.Name, inner, Name(), cancellationToken);
        }

        ///GENMHASH:7165E4A72787EF020E1C59029B4D2D13:A0244A057D0D2A3944D2A1B6B5FC52D6

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

        ///GENMHASH:256905D5B839C64BFE9830503CB5607B:EEE6F5F14FBF97AB824F4DC5BEE421C9
        internal async override Task<SiteConfigResourceInner> GetConfigInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Manager.Inner.WebApps.GetConfigurationSlotAsync(ResourceGroupName, parent.Name, Name());
        }

        ///GENMHASH:8C5F8B18192B4F8FD7D43AB4D318EA69:3D9AAF779EB9D14F1D1CEB4D1C1D5CA2
        public override IReadOnlyDictionary<string, Microsoft.Azure.Management.AppService.Fluent.IHostNameBinding> GetHostNameBindings()
        {
            var collectionInner = Extensions.Synchronize(() => Manager.Inner.WebApps.ListHostNameBindingsSlotAsync(ResourceGroupName, parent.Name, Name()));
            return collectionInner.ToDictionary(input => input.Name.Replace(Name() + "/", ""),
                inner => (IHostNameBinding)new HostNameBindingImpl<IDeploymentSlot, DeploymentSlotImpl, object, object, IUpdate>(
                    inner,
                    this));
        }

        ///GENMHASH:EB8C33DACE377CBB07C354F38C5BEA32:40B9A5AF5E2BAAC912A2E077A8B03C22
        public override void VerifyDomainOwnership(string certificateOrderName, string domainVerificationToken)
        {
            VerifyDomainOwnership(certificateOrderName, domainVerificationToken);
        }

        ///GENMHASH:BC96AA8FDB678157AC1E6F0AA511AB65:55CBEA763E5EA0A02A785BC1273C63B0
        public override IWebAppSourceControl GetSourceControl()
        {
            var siteSourceControlInner = Extensions.Synchronize(() => Manager.Inner.WebApps.GetSourceControlSlotAsync(ResourceGroupName, parent.Name, Name()));
            return new WebAppSourceControlImpl<IDeploymentSlot, DeploymentSlotImpl, object, object, IUpdate>(
                siteSourceControlInner,
                this);
        }

        ///GENMHASH:9EC0529BA0D08B75AD65E98A4BA01D5D:88C44586E83A2B7A08C556A1E66B6647
        protected async override Task<Microsoft.Azure.Management.AppService.Fluent.Models.SiteInner> GetSiteAsync(CancellationToken cancellationToken)
        {
            return await Manager.Inner.WebApps.GetSlotAsync(ResourceGroupName, parent.Name, Name(), cancellationToken);
        }

        ///GENMHASH:0F38250A3837DF9C2C345D4A038B654B:01DA6136E32014808DDE7F0C637CF668
        public override void Start()
        {
            Extensions.Synchronize(() => Manager.Inner.WebApps.StartSlotAsync(ResourceGroupName, parent.Name, Name()));
        }

        ///GENMHASH:9754CAF64EAC70E3B92A0EEED2DC1120:F4C48AA95D98CB150D145294CB2F63A3
        public DeploymentSlotImpl WithConfigurationFromParent()
        {
            return WithConfigurationFromWebApp(parent);
        }

        ///GENMHASH:DFC52755A97E7B13EB10FA2EB9538E4A:31BC86C370122E939BA1BA0EC17B6967
        public override void Swap(string slotName)
        {
            Extensions.Synchronize(() => Manager.Inner.WebApps.SwapSlotSlotAsync(ResourceGroupName, parent.Name, new CsmSlotEntityInner()
            {
                TargetSlot = slotName
            }, Name()));

            Refresh();
        }

        ///GENMHASH:68C25D685A0291AC775CEA8FCE1D7E20:2E6C811242BD3A1510505903152E128D
        public DeploymentSlotImpl WithConfigurationFromDeploymentSlot(IDeploymentSlot slot)
        {
            CopyConfigurations(((DeploymentSlotImpl) slot).SiteConfig, slot.AppSettings.Values.ToList(), slot.ConnectionStrings.Values.ToList());
            return this;
        }

        ///GENMHASH:FCAC8C2F8D6E12CB6F5D7787A2837016:8A3C0887B28AA9A7371C1C4B64C83BCF
        internal async override Task DeleteHostNameBindingAsync(string hostname, CancellationToken cancellationToken = default(CancellationToken))
        {
            await Manager.Inner.WebApps.DeleteHostNameBindingSlotAsync(ResourceGroupName, parent.Name, Name(), hostname, cancellationToken);
        }

        public async override Task ApplySlotConfigurationsAsync(string slotName, CancellationToken cancellationToken = default(CancellationToken))
        {
            await Manager.Inner.WebApps.ApplySlotConfigurationSlotAsync(ResourceGroupName, parent.Name, new CsmSlotEntityInner
            {
                TargetSlot = slotName
            }, Name() , cancellationToken);
            await RefreshAsync(cancellationToken);
        }

        public async override Task StopAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await Manager.Inner.WebApps.StopSlotAsync(ResourceGroupName, parent.Name, Name(), cancellationToken);
            await RefreshAsync(cancellationToken);
        }

        public async override Task<IPublishingProfile> GetPublishingProfileAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            Stream stream = await Manager.Inner.WebApps.ListPublishingProfileXmlWithSecretsSlotAsync(ResourceGroupName, parent.Name, new CsmPublishingProfileOptionsInner(), Name(), cancellationToken);
            StreamReader reader = new StreamReader(stream);
            string xml = reader.ReadToEnd();
            return new PublishingProfileImpl(xml);
        }

        public async override Task RestartAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await Manager.Inner.WebApps.RestartSlotAsync(ResourceGroupName, parent.Name, Name(), null, null, cancellationToken);
            await RefreshAsync(cancellationToken);
        }

        public async override Task<IWebAppSourceControl> GetSourceControlAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return new WebAppSourceControlImpl<IDeploymentSlot, DeploymentSlotImpl, object, object, IUpdate>
                (await Manager.Inner.WebApps.GetSourceControlSlotAsync(ResourceGroupName, parent.Name, Name(), cancellationToken), this);
        }

        protected async override Task<SiteInner> GetInnerAsync(CancellationToken cancellationToken)
        {
            return await Manager.Inner.WebApps.GetSlotAsync(ResourceGroupName, parent.Name, Name(), cancellationToken);
        }

        internal async override Task<SiteAuthSettingsInner> GetAuthenticationAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Manager.Inner.WebApps.GetAuthSettingsSlotAsync(ResourceGroupName, parent.Name, Name(), cancellationToken);
        }

        internal async override Task<SiteAuthSettingsInner> UpdateAuthenticationAsync(SiteAuthSettingsInner inner, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Manager.Inner.WebApps.UpdateAuthSettingsSlotAsync(ResourceGroupName, parent.Name, inner, Name(), cancellationToken);
        }

        public async override Task<IReadOnlyDictionary<string, IHostNameBinding>> GetHostNameBindingsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var bindingsList = await PagedCollection<IHostNameBinding, HostNameBindingInner>.LoadPage(
                async (cancellation) => await Manager.Inner.WebApps.ListHostNameBindingsSlotAsync(ResourceGroupName, parent.Name, Name(), cancellation),
                Manager.Inner.WebApps.ListHostNameBindingsSlotNextAsync,
                (inner) => new HostNameBindingImpl<IDeploymentSlot, DeploymentSlotImpl, object, object, IUpdate>(inner, this),
                true, cancellationToken);
            return bindingsList.ToDictionary(binding => binding.Name.Replace(this.Name() + "/", ""));
        }

        public async override Task StartAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await Manager.Inner.WebApps.StartSlotAsync(ResourceGroupName, parent.Name, Name(), cancellationToken);
            await RefreshAsync(cancellationToken);
        }

        public async override Task SwapAsync(string slotName, CancellationToken cancellationToken = default(CancellationToken))
        {
            await Manager.Inner.WebApps.SwapSlotSlotAsync(ResourceGroupName, parent.Name, new CsmSlotEntityInner
            {
                TargetSlot = slotName
            }, Name(), cancellationToken);
            await RefreshAsync(cancellationToken);
        }

        public async override Task ResetSlotConfigurationsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await Manager.Inner.WebApps.ResetSlotConfigurationSlotAsync(ResourceGroupName, parent.Name, Name(), cancellationToken);
            await RefreshAsync(cancellationToken);
        }

        internal override async Task<MSDeployStatusInner> CreateMSDeploy(MSDeployInner msDeployInner, CancellationToken cancellationToken)
        {
            return await Manager.Inner.WebApps.CreateMSDeployOperationSlotAsync(ResourceGroupName, parent.Name, Name(), msDeployInner, cancellationToken);
        }
    }
}
