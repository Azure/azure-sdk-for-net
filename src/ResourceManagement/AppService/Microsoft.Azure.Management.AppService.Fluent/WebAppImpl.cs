// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.AppService.Fluent;
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using WebApp.Definition;
    using WebApp.Update;
    using System.Collections.Generic;
    using Resource.Fluent.Core.ResourceActions;
    using Resource.Fluent.Core.Resource.Update;
    using System;
    using System.Linq;
    using Resource.Fluent.Core;
    using Resource.Fluent.Models;
    using System.IO;
    using System.Text;
    using Resource.Fluent;
    using WebAppBase.Update;

    /// <summary>
    /// The implementation for WebApp.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmFwcHNlcnZpY2UuaW1wbGVtZW50YXRpb24uV2ViQXBwSW1wbA==
    internal partial class WebAppImpl  :
        WebAppBaseImpl<
            IWebApp,
            WebAppImpl,
            WebApp.Definition.IWithNewAppServicePlan,
            WebApp.Definition.IWithAppServicePlan,
            WebApp.Update.IUpdate>,
        IWebApp,
        IDefinition,
        WebApp.Update.IUpdate,
        WebApp.Definition.IWithNewAppServicePlan,
        WebApp.Update.IWithAppServicePlan,
        WebApp.Update.IWithNewAppServicePlan
    {
        private IDeploymentSlots deploymentSlots;
        private AppServicePlanImpl appServicePlan;
        ///GENMHASH:07FBC6D492A2E1E463B39D4D7FFC40E9:66A6C8EDFAA0E618EA9FC53E296A637E
        internal override async Task<Microsoft.Azure.Management.AppService.Fluent.Models.SiteInner> CreateOrUpdateInnerAsync(SiteInner site, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await client.CreateOrUpdateAsync(ResourceGroupName, Name, site, cancellationToken: cancellationToken);
        }

        ///GENMHASH:EB854F18026EDB6E01762FA4580BE789:24EB3922A5529BDA8E8EB7736FC75359
        public override void Stop()
        {
            client.Stop(ResourceGroupName, Name);

        }

        ///GENMHASH:6779D3D3C7AB7AAAE805BA0ABEE95C51:512E3D0409D7A159D1D192520CB3A8DB
        internal override async Task<Microsoft.Azure.Management.AppService.Fluent.Models.StringDictionaryInner> UpdateAppSettingsAsync(StringDictionaryInner inner, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await client.UpdateApplicationSettingsAsync(ResourceGroupName, Name, inner);
        }

        ///GENMHASH:88806945F575AAA522C2E09EBC366CC0:FDA787AD964B4EF34BCD2352730B6528
        internal override async Task<Microsoft.Azure.Management.AppService.Fluent.Models.SiteSourceControlInner> CreateOrUpdateSourceControlAsync(SiteSourceControlInner inner, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await client.CreateOrUpdateSourceControlAsync(ResourceGroupName, Name, inner);
        }

        ///GENMHASH:620993DCE6DF78140D8125DD97478452:5A132EFB7A05E4DC22E7252CDF660609
        internal override async Task<Microsoft.Azure.Management.AppService.Fluent.Models.StringDictionaryInner> ListAppSettingsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await client.ListApplicationSettingsAsync(ResourceGroupName, Name);
        }

        ///GENMHASH:62A0C790E618C837459BE1A5103CA0E5:E67D9CD74CA1A0DECF6EE2FD2CA91749
        internal override async Task<Microsoft.Azure.Management.AppService.Fluent.Models.SlotConfigNamesResourceInner> ListSlotConfigurationsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await client.ListSlotConfigurationNamesAsync(ResourceGroupName, Name);
        }

        ///GENMHASH:807E62B6346803DB90804D0DEBD2FCA6:DE0948CBC34F6D6B889CD89BA36F4D94
        internal override async Task DeleteSourceControlAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await client.DeleteSourceControlAsync(ResourceGroupName, Name);
        }

        ///GENMHASH:CF27BBA612E1A2ABC8C2A6B8E0D936B0:7E977531CD59BD2933F963708B65758E
        public IDeploymentSlots DeploymentSlots()
        {
            if (deploymentSlots == null)
            {
                deploymentSlots = new DeploymentSlotsImpl(this, client, Manager, serviceClient);
            }
            return deploymentSlots;
        }

        ///GENMHASH:981FA7F7C88705FACC2675A0E796937F:791F75E9324E0F8CD9B54F2D9EF56E3D
        public WebAppImpl WithNewAppServicePlan(string name)
        {
            appServicePlan = (AppServicePlanImpl) Manager.AppServicePlans.Define(name);
            String id = ResourceUtils.ConstructResourceId(Manager.SubscriptionId,
            ResourceGroupName, "Microsoft.Web", "serverFarms", name, "");
            Inner.ServerFarmId = id;
            return this;
        }

        ///GENMHASH:CC6E0592F0BCD4CD83D832B40167E562:30CA9232F1D7C8ACB181740BD31D7B58
        public override async Task VerifyDomainOwnershipAsync(string certificateOrderName, string domainVerificationToken, CancellationToken cancellationToken = default(CancellationToken))
        {
            IdentifierInner identifierInner = new IdentifierInner()
            {
                Location = "global",
                IdentifierId = domainVerificationToken
            };
            await client.CreateOrUpdateDomainOwnershipIdentifierAsync(ResourceGroupName, Name, certificateOrderName, identifierInner);
        }

        ///GENMHASH:6799EDFB0B008F8C0EB7E07EE71E6B34:9AA0391980CD01ABEA62130DB5348393
        internal override async Task<Microsoft.Azure.Management.AppService.Fluent.Models.SiteConfigInner> CreateOrUpdateSiteConfigAsync(SiteConfigInner siteConfig, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await client.CreateOrUpdateConfigurationAsync(ResourceGroupName, Name, siteConfig);
        }

        ///GENMHASH:1AD5C303B4B7C1709305A18733B506B2:B2AAE3FC1D57B875FAA6AD38F9DB069C
        public override void ResetSlotConfigurations()
        {
            client.ResetProductionSlotConfig(ResourceGroupName, Name);
        }

        ///GENMHASH:2EDD4B59BAFACBDD881E1EB427AFB76D:6899DBE410B89E7D8EEB69725B8CE588
        public WebAppImpl WithPricingTier(AppServicePricingTier pricingTier)
        {
            appServicePlan.WithRegion(RegionName);
            appServicePlan.WithPricingTier(pricingTier);
            if (newGroup != null && IsInCreateMode)
            {
                appServicePlan.WithNewResourceGroup(ResourceGroupName);
                ((IndexableRefreshableWrapper<IResourceGroup, ResourceGroupInner>) newGroup).Inner.Location = RegionName;
            }
            else
            {
                appServicePlan.WithExistingResourceGroup(ResourceGroupName);
            }
            AddCreatableDependency(appServicePlan);
            return this;
        }

        ///GENMHASH:08CFC096AC6388D1C0E041ECDF099E3D:33CF86F287A6C8F3D875788B7BD8FF97
        public override void Restart()
        {
            client.Restart(ResourceGroupName, Name);
        }

        ///GENMHASH:3F0152723C985A22C1032733AB942C96:8F1022C470B3D47CCE03F40EE94D5CA0
        public override IPublishingProfile GetPublishingProfile()
        {
            Stream stream = client.ListPublishingProfileXmlWithSecrets(ResourceGroupName, Name);
            StreamReader reader = new StreamReader(stream);
            string xml = reader.ReadToEnd();
            return new PublishingProfileImpl(xml);
        }

        ///GENMHASH:62F8B201D885123D1E906E306D144662:E1F277FB3368B266611D1FAD9307CC48
        internal override async Task<Microsoft.Azure.Management.AppService.Fluent.Models.SlotConfigNamesResourceInner> UpdateSlotConfigurationsAsync(SlotConfigNamesResourceInner inner, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await client.UpdateSlotConfigurationNamesAsync(ResourceGroupName, Name, inner);
        }

        ///GENMHASH:924482EE7AA6A01820720743C2A59A72:AA2A43E94B10FDB1A9E9E89ED9CA279B
        public override void ApplySlotConfigurations(string slotName)
        {
            client.ApplySlotConfigToProduction(ResourceGroupName, Name, new CsmSlotEntityInner()
            {
                TargetSlot = slotName
            });
            Refresh();
        }

        ///GENMHASH:21FDAEDB996672BE017C01C5DD8758D4:B4D4D99FF69FD9180176D4E47741258C
        internal override async Task<Microsoft.Azure.Management.AppService.Fluent.Models.ConnectionStringDictionaryInner> UpdateConnectionStringsAsync(ConnectionStringDictionaryInner inner, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await client.UpdateConnectionStringsAsync(ResourceGroupName, Name, inner);
        }

        ///GENMHASH:0FE78F842439357DA0333AABD3B95D59:1EF461DA96453123EA3CCA0E640170EC
        internal override async Task<Microsoft.Azure.Management.AppService.Fluent.Models.ConnectionStringDictionaryInner> ListConnectionStringsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await client.ListConnectionStringsAsync(ResourceGroupName, Name);
        }

        ///GENMHASH:BC033DDD8D749B9BBCDC5BADD5CF2B94:9F4E7075C3242FB2777F45453DB418B6
        public WebAppImpl WithFreePricingTier()
        {
            return WithPricingTier(AppServicePricingTier.Free_F1);
        }

        ///GENMHASH:256905D5B839C64BFE9830503CB5607B:7AC64BDE9A6045728A97AD3B7E256F87
        internal override async Task<Microsoft.Azure.Management.AppService.Fluent.Models.SiteConfigInner> GetConfigInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await client.GetConfigurationAsync(ResourceGroupName, Name);
        }

        ///GENMHASH:934D38FBA69BF2F25673598C416DD202:85DAB0E9BE7E95CC74BF232794CEE142
        public WebAppImpl WithExistingAppServicePlan(IAppServicePlan appServicePlan)
        {
            Inner.ServerFarmId = appServicePlan.Id;
            if (newGroup != null && IsInCreateMode) {
                ((IndexableRefreshableWrapper<IResourceGroup,ResourceGroupInner>) newGroup).Inner.Location = appServicePlan.RegionName;
            }
            this.WithRegion(appServicePlan.RegionName);
            return this;
        }

        ///GENMHASH:8C5F8B18192B4F8FD7D43AB4D318EA69:E232113DB866C8D255AE12F7A61042E8
        public override IReadOnlyDictionary<string,Microsoft.Azure.Management.AppService.Fluent.IHostNameBinding> GetHostNameBindings()
        {
            var collectionInner = client.ListHostNameBindings(ResourceGroupName, Name);
            var hostNameBindings = new List<IHostNameBinding>();
            foreach(var inner in collectionInner)
            {
                hostNameBindings.Add(new HostNameBindingImpl<IWebApp, WebAppImpl, WebApp.Definition.IWithNewAppServicePlan, WebApp.Definition.IWithAppServicePlan, IUpdate>(inner, this, client));
            }
            return hostNameBindings.ToDictionary(b => b.Name.Replace(Name + "/", ""));
        }

        ///GENMHASH:EB8C33DACE377CBB07C354F38C5BEA32:391885361D8D6FDB8CD9E96400E16B73
        public override void VerifyDomainOwnership(string certificateOrderName, string domainVerificationToken)
        {
            VerifyDomainOwnershipAsync(certificateOrderName, domainVerificationToken).GetAwaiter().GetResult();
        }

        ///GENMHASH:9EC0529BA0D08B75AD65E98A4BA01D5D:AD50571B7362BCAADE526027DA36B58F
        internal override async Task<Microsoft.Azure.Management.AppService.Fluent.Models.SiteInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await client.GetAsync(ResourceGroupName, Name);
        }

        ///GENMHASH:BC96AA8FDB678157AC1E6F0AA511AB65:20A70C4EEFBA9DE9AD6AA6D9133187D7
        public override IWebAppSourceControl GetSourceControl()
        {
            SiteSourceControlInner siteSourceControlInner = client.GetSourceControl(ResourceGroupName, Name);
            return new WebAppSourceControlImpl<IWebApp, WebAppImpl, WebApp.Definition.IWithNewAppServicePlan,
                WebApp.Definition.IWithAppServicePlan, IUpdate>(siteSourceControlInner, this, serviceClient);
        }

        ///GENMHASH:0F38250A3837DF9C2C345D4A038B654B:9994372E1F96BEEC17672ADA17707ABA
        public override void Start()
        {
            client.Start(ResourceGroupName, Name);
        }

        ///GENMHASH:B22FA99F4432342EBBDB2AB426A8D2A2:DB92CE96AE133E965FE6DE31D475D7ED
        internal WebAppImpl(string name, SiteInner innerObject, SiteConfigInner configObject, IWebAppsOperations client, AppServiceManager manager, WebSiteManagementClient serviceClient)
            : base (name, innerObject, configObject, client, manager, serviceClient)
        {
        }

        ///GENMHASH:DFC52755A97E7B13EB10FA2EB9538E4A:FCF3A2AD2F52743B995DDA1FE7D020CB
        public override void Swap(string slotName)
        {
            client.SwapSlotWithProduction(ResourceGroupName, Name, new CsmSlotEntityInner
            {
                TargetSlot = slotName
            });
            Refresh();
        }

        ///GENMHASH:FCAC8C2F8D6E12CB6F5D7787A2837016:932BF8229CACF0E669A4DDE8FAEB10D4
        internal override async Task DeleteHostNameBindingAsync(string hostname, CancellationToken cancellationToken = default(CancellationToken))
        {
            await client.DeleteHostNameBindingAsync(ResourceGroupName, Name, hostname);
        }
    }
}