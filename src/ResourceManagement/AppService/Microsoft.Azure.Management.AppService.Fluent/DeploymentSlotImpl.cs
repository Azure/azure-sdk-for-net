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

        ///GENMHASH:07FBC6D492A2E1E463B39D4D7FFC40E9:4C7545D4B87E729AF03CBCFD92BFD349
        internal async override Task<SiteInner> CreateOrUpdateInnerAsync(SiteInner site, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Manager.Inner.WebApps.CreateOrUpdateSlotAsync(ResourceGroupName, parent.Name, site, Name(), cancellationToken: cancellationToken);
        }

        ///GENMHASH:EB854F18026EDB6E01762FA4580BE789:94C2AB2BE809675E6841AE45278C1F00
        public override void Stop()
        {
            Manager.Inner.WebApps.StopSlot(ResourceGroupName, parent.Name, Name());
        }

        ///GENMHASH:88806945F575AAA522C2E09EBC366CC0:B353870154AE4F874B316FE268431B8E
        internal async override Task<SiteSourceControlInner> CreateOrUpdateSourceControlAsync(SiteSourceControlInner inner, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Manager.Inner.WebApps.CreateOrUpdateSourceControlSlotAsync(ResourceGroupName, parent.Name, inner, Name(), cancellationToken);
        }

        ///GENMHASH:6779D3D3C7AB7AAAE805BA0ABEE95C51:C466CB0A077AFD0746413FA8E50105BA
        internal async override Task<Microsoft.Azure.Management.AppService.Fluent.Models.StringDictionaryInner> UpdateAppSettingsAsync(StringDictionaryInner inner, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Manager.Inner.WebApps.UpdateApplicationSettingsSlotAsync(ResourceGroupName, parent.Name, inner, Name(), cancellationToken);
        }

        ///GENMHASH:16850E2C75364DB3483B86D73CBDEC35:256BDD90CDF5E9C0BF04ED1F7DE5F0E8
        private void CopyConfigurations(SiteConfigInner configInner, IList<Microsoft.Azure.Management.AppService.Fluent.IAppSetting> appSettings, IList<Microsoft.Azure.Management.AppService.Fluent.IConnectionString> connectionStrings)
        {
            Inner.SiteConfig = configInner;
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

        ///GENMHASH:620993DCE6DF78140D8125DD97478452:2CA2963CA04CEA1DDD6D97EE4A2DBA0A
        internal async override Task<Microsoft.Azure.Management.AppService.Fluent.Models.StringDictionaryInner> ListAppSettingsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Manager.Inner.WebApps.ListApplicationSettingsSlotAsync(ResourceGroupName, parent.Name, Name());
        }

        ///GENMHASH:62A0C790E618C837459BE1A5103CA0E5:62654495B4BF32C7D42185FB1022A5EA
        internal async override Task<Microsoft.Azure.Management.AppService.Fluent.Models.SlotConfigNamesResourceInner> ListSlotConfigurationsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Manager.Inner.WebApps.ListSlotConfigurationNamesAsync(ResourceGroupName, parent.Name);
        }

        ///GENMHASH:807E62B6346803DB90804D0DEBD2FCA6:DE181E1B5D74C99ABFB73A5902B0B888
        internal async override Task DeleteSourceControlAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await Manager.Inner.WebApps.DeleteSourceControlSlotAsync(ResourceGroupName, parent.Name, Name());
        }

        ///GENMHASH:F529354C5AB0AFD4EE1F8B0AABF34899:9D5B643E4CC2E0B0C53BBF7A34E7FE45
        public DeploymentSlotImpl WithConfigurationFromWebApp(IWebApp webApp)
        {
            CopyConfigurations(webApp.Inner.SiteConfig, webApp.AppSettings.Values.ToList(), webApp.ConnectionStrings.Values.ToList());
            return this;
        }

        ///GENMHASH:F04F63AA4669C2004D2264538A4A983F:129E57D5B1ECCAA65D812C4E28851FCE
        public DeploymentSlotImpl WithBrandNewConfiguration()
        {
            Inner.SiteConfig = null;

            return this;
        }

        ///GENMHASH:CC6E0592F0BCD4CD83D832B40167E562:BD6D6B256D3D938F979A97A557F32D5A
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
        internal async override Task<Microsoft.Azure.Management.AppService.Fluent.Models.SiteConfigInner> CreateOrUpdateSiteConfigAsync(SiteConfigInner siteConfig, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Manager.Inner.WebApps.CreateOrUpdateConfigurationSlotAsync(ResourceGroupName, parent.Name, siteConfig, Name(), cancellationToken);
        }

        ///GENMHASH:1AD5C303B4B7C1709305A18733B506B2:F5323F81BCDFCE13F33F49F5F885A65F
        public override void ResetSlotConfigurations()
        {
            Manager.Inner.WebApps.ResetSlotConfigurationSlot(ResourceGroupName, parent.Name, Name());
        }

        ///GENMHASH:08CFC096AC6388D1C0E041ECDF099E3D:0D72D3A221EFB4CBD38BE14D627A0290
        public override void Restart()
        {
            Manager.Inner.WebApps.RestartSlot(ResourceGroupName, parent.Name, Name());
        }

        ///GENMHASH:3F0152723C985A22C1032733AB942C96:D8B1F90C4E79A8518B83FEFE201D1063
        public override IPublishingProfile GetPublishingProfile()
        {
            Stream stream = Manager.Inner.WebApps.ListPublishingProfileXmlWithSecretsSlot(ResourceGroupName, Parent().Name, Name());
            StreamReader reader = new StreamReader(stream);
            string xml = reader.ReadToEnd();
            return new PublishingProfileImpl(xml);
        }

        ///GENMHASH:62F8B201D885123D1E906E306D144662:2DE252A4E4CB1A03D80BB639D9CC1D63
        internal async override Task<Microsoft.Azure.Management.AppService.Fluent.Models.SlotConfigNamesResourceInner> UpdateSlotConfigurationsAsync(SlotConfigNamesResourceInner inner, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Manager.Inner.WebApps.UpdateSlotConfigurationNamesAsync(ResourceGroupName, parent.Name, inner, cancellationToken);
        }

        ///GENMHASH:924482EE7AA6A01820720743C2A59A72:0D008A2337F69A2F68CE4B453B68C91F
        public override void ApplySlotConfigurations(string slotName)
        {
            Manager.Inner.WebApps.ApplySlotConfigurationSlot(ResourceGroupName, parent.Name, new CsmSlotEntityInner()
            {
                TargetSlot = slotName
            }, Name());
            Refresh();
        }

        ///GENMHASH:FD5D5A8D6904B467321E345BE1FA424E:8AB87020DE6C711CD971F3D80C33DD83
        public WebAppImpl Parent()
        {
            return parent;
        }

        ///GENMHASH:0FE78F842439357DA0333AABD3B95D59:1921F0155028390EDD9DC6464E29986A
        internal async override Task<Microsoft.Azure.Management.AppService.Fluent.Models.ConnectionStringDictionaryInner> ListConnectionStringsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Manager.Inner.WebApps.ListConnectionStringsSlotAsync(ResourceGroupName, parent.Name, Name());
        }

        ///GENMHASH:21FDAEDB996672BE017C01C5DD8758D4:4D11AFF71F3B252DAF2FF3516CE8079B
        internal async override Task<Microsoft.Azure.Management.AppService.Fluent.Models.ConnectionStringDictionaryInner> UpdateConnectionStringsAsync(ConnectionStringDictionaryInner inner, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Manager.Inner.WebApps.UpdateConnectionStringsSlotAsync(ResourceGroupName, parent.Name, inner, Name(), cancellationToken);
        }

        ///GENMHASH:7165E4A72787EF020E1C59029B4D2D13:A0244A057D0D2A3944D2A1B6B5FC52D6
        internal DeploymentSlotImpl(
            string name,
            SiteInner innerObject,
            SiteConfigInner configObject,
            WebAppImpl parent,
            IAppServiceManager manager)
                    : base(Regex.Replace(name, ".*/", ""), innerObject, configObject, manager)
        {
            this.name = Regex.Replace(name, ".*/", "");
            this.parent = parent;
            Inner.ServerFarmId = parent.AppServicePlanId();
        }

        ///GENMHASH:256905D5B839C64BFE9830503CB5607B:EEE6F5F14FBF97AB824F4DC5BEE421C9
        internal async override Task<Microsoft.Azure.Management.AppService.Fluent.Models.SiteConfigInner> GetConfigInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Manager.Inner.WebApps.GetConfigurationSlotAsync(ResourceGroupName, parent.Name, Name());
        }

        ///GENMHASH:8C5F8B18192B4F8FD7D43AB4D318EA69:B391F0DC172F1C96A8CB5A3DC9D8EAB6
        public override IReadOnlyDictionary<string, Microsoft.Azure.Management.AppService.Fluent.IHostNameBinding> GetHostNameBindings()
        {
            var collectionInner = Manager.Inner.WebApps.ListHostNameBindingsSlot(ResourceGroupName, parent.Name, Name());
            return collectionInner.ToDictionary(input => input.Name.Replace(Name() + "/", ""),
                inner => (IHostNameBinding)new HostNameBindingImpl<IDeploymentSlot, DeploymentSlotImpl, object, object, IUpdate>(
                    inner,
                    this));
        }

        ///GENMHASH:EB8C33DACE377CBB07C354F38C5BEA32:391885361D8D6FDB8CD9E96400E16B73
        public override void VerifyDomainOwnership(string certificateOrderName, string domainVerificationToken)
        {
            VerifyDomainOwnership(certificateOrderName, domainVerificationToken);
        }

        ///GENMHASH:BC96AA8FDB678157AC1E6F0AA511AB65:7FD11F8640B85B9B7322C618E790CC30
        public override IWebAppSourceControl GetSourceControl()
        {
            var siteSourceControlInner = Manager.Inner.WebApps.GetSourceControlSlot(ResourceGroupName, parent.Name, Name());
            return new WebAppSourceControlImpl<IDeploymentSlot, DeploymentSlotImpl, object, object, IUpdate>(
                siteSourceControlInner,
                this);
        }

        ///GENMHASH:9EC0529BA0D08B75AD65E98A4BA01D5D:44153E55F54D6CEBEDD20C31326CBA9E
        internal async override Task<Microsoft.Azure.Management.AppService.Fluent.Models.SiteInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Manager.Inner.WebApps.GetSlotAsync(ResourceGroupName, parent.Name, Name());
        }

        ///GENMHASH:0F38250A3837DF9C2C345D4A038B654B:ACDFDA9555BC8460257AB6B2FB97F4EB
        public override void Start()
        {
            Manager.Inner.WebApps.StartSlot(ResourceGroupName, parent.Name, Name());
        }

        ///GENMHASH:9754CAF64EAC70E3B92A0EEED2DC1120:D7EF25AACEC219C83202353B07AAA174
        public DeploymentSlotImpl WithConfigurationFromParent()
        {
            return WithConfigurationFromWebApp(parent);
        }

        ///GENMHASH:DFC52755A97E7B13EB10FA2EB9538E4A:30D469A4DF2C04EC877197A738D1D873
        public override void Swap(string slotName)
        {
            Manager.Inner.WebApps.SwapSlotSlot(ResourceGroupName, parent.Name, new CsmSlotEntityInner()
            {
                TargetSlot = slotName
            }, Name());

            Refresh();
        }

        ///GENMHASH:68C25D685A0291AC775CEA8FCE1D7E20:19F7AEA76877B47E32F58082C59F91CA
        public DeploymentSlotImpl WithConfigurationFromDeploymentSlot(IDeploymentSlot slot)
        {
            CopyConfigurations(slot.Inner.SiteConfig, slot.AppSettings.Values.ToList(), slot.ConnectionStrings.Values.ToList());
            return this;
        }

        ///GENMHASH:FCAC8C2F8D6E12CB6F5D7787A2837016:6EA475A78A58FF77FEECBC549D8F6A5A
        internal async override Task DeleteHostNameBindingAsync(string hostname, CancellationToken cancellationToken = default(CancellationToken))
        {
            await Manager.Inner.WebApps.DeleteHostNameBindingSlotAsync(ResourceGroupName, parent.Name, Name(), hostname, cancellationToken);
        }
    }
}
