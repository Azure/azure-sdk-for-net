// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Appservice.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using WebApp.Definition;
    using WebApp.Update;
    using System.Collections.Generic;

    /// <summary>
    /// The implementation for WebApp.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmFwcHNlcnZpY2UuaW1wbGVtZW50YXRpb24uV2ViQXBwSW1wbA==
    internal partial class WebAppImpl  :
        WebAppBaseImpl<Microsoft.Azure.Management.Appservice.Fluent.IWebApp,Microsoft.Azure.Management.Appservice.Fluent.WebAppImpl>,
        IWebApp,
        IDefinition,
        IUpdate,
        IWithNewAppServicePlan
    {
        private DeploymentSlots deploymentSlots;
        private AppServicePlanImpl appServicePlan;
        ///GENMHASH:07FBC6D492A2E1E463B39D4D7FFC40E9:66A6C8EDFAA0E618EA9FC53E296A637E
        internal async Task<Microsoft.Azure.Management.AppService.Fluent.Models.SiteInner> CreateOrUpdateInnerAsync(SiteInner site, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return client.CreateOrUpdateAsync(resourceGroupName(), name(), site);

            return null;
        }

        ///GENMHASH:EB854F18026EDB6E01762FA4580BE789:24EB3922A5529BDA8E8EB7736FC75359
        public void Stop()
        {
            //$ client.Stop(resourceGroupName(), name());

        }

        ///GENMHASH:6779D3D3C7AB7AAAE805BA0ABEE95C51:512E3D0409D7A159D1D192520CB3A8DB
        internal async Task<Microsoft.Azure.Management.AppService.Fluent.Models.StringDictionaryInner> UpdateAppSettingsAsync(StringDictionaryInner inner, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return client.UpdateApplicationSettingsAsync(resourceGroupName(), name(), inner);

            return null;
        }

        ///GENMHASH:88806945F575AAA522C2E09EBC366CC0:FDA787AD964B4EF34BCD2352730B6528
        internal async Task<Microsoft.Azure.Management.AppService.Fluent.Models.SiteSourceControlInner> CreateOrUpdateSourceControlAsync(SiteSourceControlInner inner, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return client.CreateOrUpdateSourceControlAsync(resourceGroupName(), name(), inner);

            return null;
        }

        ///GENMHASH:620993DCE6DF78140D8125DD97478452:5A132EFB7A05E4DC22E7252CDF660609
        internal async Task<Microsoft.Azure.Management.AppService.Fluent.Models.StringDictionaryInner> ListAppSettingsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return client.ListApplicationSettingsAsync(resourceGroupName(), name());

            return null;
        }

        ///GENMHASH:62A0C790E618C837459BE1A5103CA0E5:E67D9CD74CA1A0DECF6EE2FD2CA91749
        internal async Task<Microsoft.Azure.Management.AppService.Fluent.Models.SlotConfigNamesResourceInner> ListSlotConfigurationsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return client.ListSlotConfigurationNamesAsync(resourceGroupName(), name());

            return null;
        }

        ///GENMHASH:807E62B6346803DB90804D0DEBD2FCA6:DE0948CBC34F6D6B889CD89BA36F4D94
        internal async Task DeleteSourceControlAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return client.DeleteSourceControlAsync(resourceGroupName(), name()).Map(new Func1<Object, Void>() {
            //$ @Override
            //$ public Void call(Object o) {
            //$ return null;
            //$ }
            //$ });

            return null;
        }

        ///GENMHASH:CF27BBA612E1A2ABC8C2A6B8E0D936B0:7E977531CD59BD2933F963708B65758E
        public DeploymentSlots DeploymentSlots()
        {
            //$ if (deploymentSlots == null) {
            //$ deploymentSlots = new DeploymentSlotsImpl(this, client, myManager, serviceClient);
            //$ }
            //$ return deploymentSlots;

            return null;
        }

        ///GENMHASH:981FA7F7C88705FACC2675A0E796937F:791F75E9324E0F8CD9B54F2D9EF56E3D
        public WebAppImpl WithNewAppServicePlan(string name)
        {
            //$ appServicePlan = (AppServicePlanImpl) myManager.AppServicePlans().Define(name);
            //$ String id = ResourceUtils.ConstructResourceId(myManager.SubscriptionId(),
            //$ resourceGroupName(), "Microsoft.Web", "serverFarms", name, "");
            //$ Inner.WithServerFarmId(id);
            //$ return this;

            return this;
        }

        ///GENMHASH:CC6E0592F0BCD4CD83D832B40167E562:30CA9232F1D7C8ACB181740BD31D7B58
        public async Task VerifyDomainOwnershipAsync(string certificateOrderName, string domainVerificationToken, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ IdentifierInner identifierInner = new IdentifierInner().WithIdentifierId(domainVerificationToken);
            //$ identifierInner.WithLocation("global");
            //$ return client.CreateOrUpdateDomainOwnershipIdentifierAsync(resourceGroupName(), name(), certificateOrderName, identifierInner)
            //$ .Map(new Func1<IdentifierInner, Void>() {
            //$ @Override
            //$ public Void call(IdentifierInner identifierInner) {
            //$ return null;
            //$ }
            //$ });

            return null;
        }

        ///GENMHASH:6799EDFB0B008F8C0EB7E07EE71E6B34:9AA0391980CD01ABEA62130DB5348393
        internal async Task<Microsoft.Azure.Management.AppService.Fluent.Models.SiteConfigInner> CreateOrUpdateSiteConfigAsync(SiteConfigInner siteConfig, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return client.CreateOrUpdateConfigurationAsync(resourceGroupName(), name(), siteConfig);

            return null;
        }

        ///GENMHASH:1AD5C303B4B7C1709305A18733B506B2:B2AAE3FC1D57B875FAA6AD38F9DB069C
        public void ResetSlotConfigurations()
        {
            //$ client.ResetProductionSlotConfig(resourceGroupName(), name());

        }

        ///GENMHASH:2EDD4B59BAFACBDD881E1EB427AFB76D:6899DBE410B89E7D8EEB69725B8CE588
        public WebAppImpl WithPricingTier(AppServicePricingTier pricingTier)
        {
            //$ public WebAppImpl withPricingTier(AppServicePricingTier pricingTier) {
            //$ appServicePlan = appServicePlan
            //$ .WithRegion(region())
            //$ .WithPricingTier(pricingTier);
            //$ if (super.CreatableGroup != null && isInCreateMode()) {
            //$ appServicePlan = appServicePlan.WithNewResourceGroup(resourceGroupName());
            //$ ((Wrapper<ResourceGroupInner>) super.CreatableGroup).Inner.WithLocation(regionName());
            //$ } else {
            //$ appServicePlan = appServicePlan.WithExistingResourceGroup(resourceGroupName());
            //$ }
            //$ if (isInCreateMode()) {
            //$ addCreatableDependency(appServicePlan);
            //$ } else {
            //$ addAppliableDependency(appServicePlan);
            //$ }
            //$ return this;

            return this;
        }

        ///GENMHASH:08CFC096AC6388D1C0E041ECDF099E3D:33CF86F287A6C8F3D875788B7BD8FF97
        public void Restart()
        {
            //$ client.Restart(resourceGroupName(), name());

        }

        ///GENMHASH:3F0152723C985A22C1032733AB942C96:8F1022C470B3D47CCE03F40EE94D5CA0
        public IPublishingProfile GetPublishingProfile()
        {
            //$ InputStream stream = client.ListPublishingProfileXmlWithSecrets(resourceGroupName(), name());
            //$ try {
            //$ String xml = CharStreams.ToString(new InputStreamReader(stream));
            //$ return new PublishingProfileImpl(xml);
            //$ } catch (IOException e) {
            //$ throw new RuntimeException(e);
            //$ }

            return null;
        }

        ///GENMHASH:62F8B201D885123D1E906E306D144662:E1F277FB3368B266611D1FAD9307CC48
        internal async Task<Microsoft.Azure.Management.AppService.Fluent.Models.SlotConfigNamesResourceInner> UpdateSlotConfigurationsAsync(SlotConfigNamesResourceInner inner, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return client.UpdateSlotConfigurationNamesAsync(resourceGroupName(), name(), inner);

            return null;
        }

        ///GENMHASH:924482EE7AA6A01820720743C2A59A72:AA2A43E94B10FDB1A9E9E89ED9CA279B
        public void ApplySlotConfigurations(string slotName)
        {
            //$ client.ApplySlotConfigToProduction(resourceGroupName(), name(), new CsmSlotEntityInner().WithTargetSlot(slotName));
            //$ refresh();

        }

        ///GENMHASH:21FDAEDB996672BE017C01C5DD8758D4:B4D4D99FF69FD9180176D4E47741258C
        internal async Task<Microsoft.Azure.Management.AppService.Fluent.Models.ConnectionStringDictionaryInner> UpdateConnectionStringsAsync(ConnectionStringDictionaryInner inner, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return client.UpdateConnectionStringsAsync(resourceGroupName(), name(), inner);

            return null;
        }

        ///GENMHASH:0FE78F842439357DA0333AABD3B95D59:1EF461DA96453123EA3CCA0E640170EC
        internal async Task<Microsoft.Azure.Management.AppService.Fluent.Models.ConnectionStringDictionaryInner> ListConnectionStringsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return client.ListConnectionStringsAsync(resourceGroupName(), name());

            return null;
        }

        ///GENMHASH:BC033DDD8D749B9BBCDC5BADD5CF2B94:9F4E7075C3242FB2777F45453DB418B6
        public WebAppImpl WithFreePricingTier()
        {
            //$ return withPricingTier(AppServicePricingTier.FREE_F1);

            return this;
        }

        ///GENMHASH:256905D5B839C64BFE9830503CB5607B:7AC64BDE9A6045728A97AD3B7E256F87
        internal async Task<Microsoft.Azure.Management.AppService.Fluent.Models.SiteConfigInner> GetConfigInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return client.GetConfigurationAsync(resourceGroupName(), name());

            return null;
        }

        ///GENMHASH:934D38FBA69BF2F25673598C416DD202:85DAB0E9BE7E95CC74BF232794CEE142
        public WebAppImpl WithExistingAppServicePlan(IAppServicePlan appServicePlan)
        {
            //$ public WebAppImpl withExistingAppServicePlan(AppServicePlan appServicePlan) {
            //$ Inner.WithServerFarmId(appServicePlan.Id());
            //$ if (super.CreatableGroup != null && isInCreateMode()) {
            //$ ((Wrapper<ResourceGroupInner>) super.CreatableGroup).Inner.WithLocation(appServicePlan.RegionName());
            //$ }
            //$ return this;

            return this;
        }

        ///GENMHASH:8C5F8B18192B4F8FD7D43AB4D318EA69:E232113DB866C8D255AE12F7A61042E8
        public IReadOnlyDictionary<string,Microsoft.Azure.Management.Appservice.Fluent.IHostNameBinding> GetHostNameBindings()
        {
            //$ List<HostNameBindingInner> collectionInner = client.ListHostNameBindings(resourceGroupName(), name());
            //$ List<HostNameBinding> hostNameBindings = new ArrayList<>();
            //$ foreach(var inner in collectionInner)  {
            //$ hostNameBindings.Add(new HostNameBindingImpl<>(inner, this, client));
            //$ }
            //$ return Collections.UnmodifiableMap(Maps.UniqueIndex(hostNameBindings, new Function<HostNameBinding, String>() {
            //$ @Override
            //$ public String apply(HostNameBinding input) {
            //$ return input.Name().Replace(name() + "/", "");
            //$ }
            //$ }));

            return null;
        }

        ///GENMHASH:EB8C33DACE377CBB07C354F38C5BEA32:391885361D8D6FDB8CD9E96400E16B73
        public void VerifyDomainOwnership(string certificateOrderName, string domainVerificationToken)
        {
            //$ verifyDomainOwnershipAsync(certificateOrderName, domainVerificationToken).ToBlocking().Subscribe();

        }

        ///GENMHASH:9EC0529BA0D08B75AD65E98A4BA01D5D:AD50571B7362BCAADE526027DA36B58F
        internal async Task<Microsoft.Azure.Management.AppService.Fluent.Models.SiteInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return client.GetAsync(resourceGroupName(), name());

            return null;
        }

        ///GENMHASH:BC96AA8FDB678157AC1E6F0AA511AB65:20A70C4EEFBA9DE9AD6AA6D9133187D7
        public IWebAppSourceControl GetSourceControl()
        {
            //$ SiteSourceControlInner siteSourceControlInner = client.GetSourceControl(resourceGroupName(), name());
            //$ return new WebAppSourceControlImpl<>(siteSourceControlInner, this, serviceClient);

            return null;
        }

        ///GENMHASH:0F38250A3837DF9C2C345D4A038B654B:9994372E1F96BEEC17672ADA17707ABA
        public void Start()
        {
            //$ client.Start(resourceGroupName(), name());

        }

        ///GENMHASH:B22FA99F4432342EBBDB2AB426A8D2A2:DB92CE96AE133E965FE6DE31D475D7ED
        internal  WebAppImpl(string name, SiteInner innerObject, SiteConfigInner configObject, WebAppsInner client, AppServiceManager manager, WebSiteManagementClientImpl serviceClient)
        {
            //$ super(name, innerObject, configObject, client, manager, serviceClient);
            //$ }

        }

        ///GENMHASH:DFC52755A97E7B13EB10FA2EB9538E4A:FCF3A2AD2F52743B995DDA1FE7D020CB
        public void Swap(string slotName)
        {
            //$ client.SwapSlotWithProduction(resourceGroupName(), name(), new CsmSlotEntityInner().WithTargetSlot(slotName));
            //$ refresh();

        }

        ///GENMHASH:FCAC8C2F8D6E12CB6F5D7787A2837016:932BF8229CACF0E669A4DDE8FAEB10D4
        internal async Task DeleteHostNameBindingAsync(string hostname, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return client.DeleteHostNameBindingAsync(resourceGroupName(), name(), hostname);

            return null;
        }
    }
}