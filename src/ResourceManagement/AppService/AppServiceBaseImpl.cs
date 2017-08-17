// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;
    using ResourceManager.Fluent.Core;
    using System.IO;
    using ResourceManager.Fluent;
    using ResourceManager.Fluent.Models;
    using System.Linq;
    using System;

    /// <summary>
    /// The base implementation for web apps and function apps.
    /// </summary>
    /// <typeparam name="FluentT">The fluent interface, WebApp or FunctionApp.</typeparam>
    /// <typeparam name="FluentImplT">The implementation class for FluentT.</typeparam>
    /// <typeparam name="FluentWithCreateT">The definition stage that derives from Creatable.</typeparam>
    /// <typeparam name="FluentUpdateT">The definition stage that derives from Appliable.</typeparam>
    internal abstract partial class AppServiceBaseImpl<FluentT,FluentImplT,FluentWithCreateT, DefAfterRegionT, DefAfterGroupT, UpdateT>  :
        WebAppBaseImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT>
        where FluentImplT : AppServiceBaseImpl<FluentT, FluentImplT, FluentWithCreateT, DefAfterRegionT, DefAfterGroupT, UpdateT>, FluentT
        where FluentT : class, IWebAppBase
        where DefAfterRegionT : class
        where DefAfterGroupT : class
        where UpdateT : class, WebAppBase.Update.IUpdate<FluentT>
    {
        private AppServicePlanImpl appServicePlan;

        ///GENMHASH:07FBC6D492A2E1E463B39D4D7FFC40E9:66A6C8EDFAA0E618EA9FC53E296A637E

        internal async override Task<SiteInner> CreateOrUpdateInnerAsync(SiteInner site, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Manager.Inner.WebApps.CreateOrUpdateAsync(ResourceGroupName, Name, site, cancellationToken: cancellationToken);
        }

        ///GENMHASH:EB854F18026EDB6E01762FA4580BE789:E0C4A1757552CAB0ED8F92E2EB35D2E2

        public override void Stop()
        {
            Extensions.Synchronize(() => Manager.Inner.WebApps.StopAsync(ResourceGroupName, Name));
        }

        ///GENMHASH:6779D3D3C7AB7AAAE805BA0ABEE95C51:512E3D0409D7A159D1D192520CB3A8DB

        internal async override Task<StringDictionaryInner> UpdateAppSettingsAsync(StringDictionaryInner inner, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Manager.Inner.WebApps.UpdateApplicationSettingsAsync(ResourceGroupName, Name, inner, cancellationToken);
        }

        ///GENMHASH:88806945F575AAA522C2E09EBC366CC0:FDA787AD964B4EF34BCD2352730B6528

        internal async override Task<SiteSourceControlInner> CreateOrUpdateSourceControlAsync(SiteSourceControlInner inner, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Manager.Inner.WebApps.CreateOrUpdateSourceControlAsync(ResourceGroupName, Name, inner, cancellationToken);
        }

        ///GENMHASH:620993DCE6DF78140D8125DD97478452:5A132EFB7A05E4DC22E7252CDF660609


        internal async override Task<StringDictionaryInner> ListAppSettingsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Manager.Inner.WebApps.ListApplicationSettingsAsync(ResourceGroupName, Name);
        }

        ///GENMHASH:62A0C790E618C837459BE1A5103CA0E5:E67D9CD74CA1A0DECF6EE2FD2CA91749

        internal async override Task<SlotConfigNamesResourceInner> ListSlotConfigurationsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Manager.Inner.WebApps.ListSlotConfigurationNamesAsync(ResourceGroupName, Name);
        }

        ///GENMHASH:807E62B6346803DB90804D0DEBD2FCA6:DE0948CBC34F6D6B889CD89BA36F4D94

        internal async override Task DeleteSourceControlAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await Manager.Inner.WebApps.DeleteSourceControlAsync(ResourceGroupName, Name);
        }

        ///GENMHASH:981FA7F7C88705FACC2675A0E796937F:791F75E9324E0F8CD9B54F2D9EF56E3D
        public FluentImplT WithNewAppServicePlan(string name)
        {
            appServicePlan = (AppServicePlanImpl)Manager.AppServicePlans.Define(name);
            string id = ResourceUtils.ConstructResourceId(Manager.SubscriptionId,
            ResourceGroupName, "Microsoft.Web", "serverFarms", name, "");
            Inner.ServerFarmId = id;
            return (FluentImplT) this;
        }

        ///GENMHASH:CC6E0592F0BCD4CD83D832B40167E562:30CA9232F1D7C8ACB181740BD31D7B58
        public async override Task VerifyDomainOwnershipAsync(string certificateOrderName, string domainVerificationToken, CancellationToken cancellationToken = default(CancellationToken))
        {
            IdentifierInner identifierInner = new IdentifierInner()
            {
                IdentifierId = domainVerificationToken
            };
            await Manager.Inner.WebApps.CreateOrUpdateDomainOwnershipIdentifierAsync(ResourceGroupName, Name, certificateOrderName, identifierInner, cancellationToken);
        }

        ///GENMHASH:6799EDFB0B008F8C0EB7E07EE71E6B34:9AA0391980CD01ABEA62130DB5348393
        internal async override Task<SiteConfigResourceInner> CreateOrUpdateSiteConfigAsync(SiteConfigResourceInner siteConfig, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Manager.Inner.WebApps.CreateOrUpdateConfigurationAsync(ResourceGroupName, Name, siteConfig, cancellationToken);
        }

        ///GENMHASH:1AD5C303B4B7C1709305A18733B506B2:B2AAE3FC1D57B875FAA6AD38F9DB069C
        public override void ResetSlotConfigurations()
        {
            Extensions.Synchronize(() => Manager.Inner.WebApps.ResetProductionSlotConfigAsync(ResourceGroupName, Name));
        }

        ///GENMHASH:2EDD4B59BAFACBDD881E1EB427AFB76D:6899DBE410B89E7D8EEB69725B8CE588
        public FluentImplT WithPricingTier(PricingTier pricingTier)
        {
            appServicePlan.WithRegion(RegionName);
            appServicePlan.WithPricingTier(pricingTier);
            if (newGroup != null && IsInCreateMode)
            {
                appServicePlan.WithNewResourceGroup(ResourceGroupName);
                ((IndexableRefreshableWrapper<IResourceGroup, ResourceGroupInner>)newGroup).Inner.Location = RegionName;
            }
            else
            {
                appServicePlan.WithExistingResourceGroup(ResourceGroupName);
            }
            AddCreatableDependency(appServicePlan);
            return (FluentImplT)this;
        }

        ///GENMHASH:08CFC096AC6388D1C0E041ECDF099E3D:192EA146CBED61BBAAC7B336DA07F261
        public override void Restart()
        {
            Extensions.Synchronize(() => Manager.Inner.WebApps.RestartAsync(ResourceGroupName, Name));
        }

        ///GENMHASH:3F0152723C985A22C1032733AB942C96:9A3E19132DCD027C4BA1BBB085642F29
        public override IPublishingProfile GetPublishingProfile()
        {
            Stream stream = Extensions.Synchronize(() => Manager.Inner.WebApps.ListPublishingProfileXmlWithSecretsAsync(ResourceGroupName, Name, new CsmPublishingProfileOptionsInner()));
            StreamReader reader = new StreamReader(stream);
            string xml = reader.ReadToEnd();
            return new PublishingProfileImpl(xml);
        }

        ///GENMHASH:62F8B201D885123D1E906E306D144662:E1F277FB3368B266611D1FAD9307CC48
        internal async override Task<SlotConfigNamesResourceInner> UpdateSlotConfigurationsAsync(SlotConfigNamesResourceInner inner, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Manager.Inner.WebApps.UpdateSlotConfigurationNamesAsync(ResourceGroupName, Name, inner, cancellationToken);
        }

        ///GENMHASH:924482EE7AA6A01820720743C2A59A72:AA2A43E94B10FDB1A9E9E89ED9CA279B
        public override void ApplySlotConfigurations(string slotName)
        {
            Extensions.Synchronize(() => Manager.Inner.WebApps.ApplySlotConfigToProductionAsync(ResourceGroupName, Name, new CsmSlotEntityInner()
            {
                TargetSlot = slotName
            }));
            Refresh();
        }

        ///GENMHASH:21FDAEDB996672BE017C01C5DD8758D4:B4D4D99FF69FD9180176D4E47741258C
        internal async override Task<ConnectionStringDictionaryInner> UpdateConnectionStringsAsync(ConnectionStringDictionaryInner inner, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Manager.Inner.WebApps.UpdateConnectionStringsAsync(ResourceGroupName, Name, inner, cancellationToken);
        }

        ///GENMHASH:0FE78F842439357DA0333AABD3B95D59:1EF461DA96453123EA3CCA0E640170EC
        internal async override Task<ConnectionStringDictionaryInner> ListConnectionStringsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Manager.Inner.WebApps.ListConnectionStringsAsync(ResourceGroupName, Name);
        }

        ///GENMHASH:BC033DDD8D749B9BBCDC5BADD5CF2B94:9F4E7075C3242FB2777F45453DB418B6
        public FluentImplT WithFreePricingTier()
        {
            return WithPricingTier(new PricingTier("Free", "F1"));
        }

        ///GENMHASH:256905D5B839C64BFE9830503CB5607B:7AC64BDE9A6045728A97AD3B7E256F87
        internal async override Task<SiteConfigResourceInner> GetConfigInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Manager.Inner.WebApps.GetConfigurationAsync(ResourceGroupName, Name);
        }

        ///GENMHASH:934D38FBA69BF2F25673598C416DD202:E29466D1FE6AACE8059987F066EC1188
        public virtual FluentImplT WithExistingAppServicePlan(IAppServicePlan appServicePlan)
        {
            Inner.ServerFarmId = appServicePlan.Id;
            WithOperatingSystem(appServicePlan.OperatingSystem);
            if (newGroup != null && IsInCreateMode)
            {
                ((IndexableRefreshableWrapper<IResourceGroup, ResourceGroupInner>)newGroup).Inner.Location = appServicePlan.RegionName;
            }
            this.WithRegion(appServicePlan.RegionName);
            return (FluentImplT) this;
        }

        ///GENMHASH:8C5F8B18192B4F8FD7D43AB4D318EA69:E232113DB866C8D255AE12F7A61042E8
        public override IReadOnlyDictionary<string, IHostNameBinding> GetHostNameBindings()
        {
            var collectionInner = Extensions.Synchronize(() => Manager.Inner.WebApps.ListHostNameBindingsAsync(ResourceGroupName, Name));
            var hostNameBindings = new List<IHostNameBinding>();
            foreach (var inner in collectionInner)
            {
                hostNameBindings.Add(new HostNameBindingImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT>(
                    inner,
                    (FluentImplT) this));
            }
            return hostNameBindings.ToDictionary(b => b.Name.Replace(Name + "/", ""));
        }

        ///GENMHASH:EB8C33DACE377CBB07C354F38C5BEA32:391885361D8D6FDB8CD9E96400E16B73
        public override void VerifyDomainOwnership(string certificateOrderName, string domainVerificationToken)
        {
            Extensions.Synchronize(() => VerifyDomainOwnershipAsync(certificateOrderName, domainVerificationToken));
        }

        ///GENMHASH:9EC0529BA0D08B75AD65E98A4BA01D5D:AD50571B7362BCAADE526027DA36B58F
        protected async override Task<SiteInner> GetSiteAsync(CancellationToken cancellationToken)
        {
            return await Manager.Inner.WebApps.GetAsync(ResourceGroupName, Name, cancellationToken);
        }

        ///GENMHASH:BC96AA8FDB678157AC1E6F0AA511AB65:20A70C4EEFBA9DE9AD6AA6D9133187D7
        public override IWebAppSourceControl GetSourceControl()
        {
            SiteSourceControlInner siteSourceControlInner = Extensions.Synchronize(() => Manager.Inner.WebApps.GetSourceControlAsync(ResourceGroupName, Name));
            return new WebAppSourceControlImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT>(siteSourceControlInner, (FluentImplT) this);
        }

        ///GENMHASH:0F38250A3837DF9C2C345D4A038B654B:57465AB4A649A705C9DC2183EE743214
        public override void Start()
        {
            Extensions.Synchronize(() => Manager.Inner.WebApps.StartAsync(ResourceGroupName, Name));
        }

        ///GENMHASH:B22FA99F4432342EBBDB2AB426A8D2A2:DB92CE96AE133E965FE6DE31D475D7ED
        internal AppServiceBaseImpl(
            string name,
            SiteInner innerObject,
            SiteConfigResourceInner configObject,
            IAppServiceManager manager)
            : base (name, innerObject, configObject, manager)
        {
        }

        ///GENMHASH:DFC52755A97E7B13EB10FA2EB9538E4A:FCF3A2AD2F52743B995DDA1FE7D020CB
        public override void Swap(string slotName)
        {
            Extensions.Synchronize(() => Manager.Inner.WebApps.SwapSlotWithProductionAsync(ResourceGroupName, Name, new CsmSlotEntityInner
            {
                TargetSlot = slotName
            }));
            Refresh();
        }

        ///GENMHASH:FCAC8C2F8D6E12CB6F5D7787A2837016:932BF8229CACF0E669A4DDE8FAEB10D4
        internal async override Task DeleteHostNameBindingAsync(string hostname, CancellationToken cancellationToken = default(CancellationToken))
        {
            await Manager.Inner.WebApps.DeleteHostNameBindingAsync(ResourceGroupName, Name, hostname, cancellationToken);
        }
        
        internal virtual FluentImplT WithNewAppServicePlan(OperatingSystem operatingSystem, PricingTier pricingTier)
        {
            return WithNewAppServicePlan(NewDefaultAppServicePlan().WithOperatingSystem(operatingSystem).WithPricingTier(pricingTier));
        }

        private FluentImplT WithOperatingSystem(OperatingSystem os)
        {
            if (os == Microsoft.Azure.Management.AppService.Fluent.OperatingSystem.Linux)
            {
                Inner.Reserved = true;
                Inner.Kind = Inner.Kind + ",linux";
            }
            return (FluentImplT)this;
        }

        public FluentImplT WithNewAppServicePlan(ICreatable<Microsoft.Azure.Management.AppService.Fluent.IAppServicePlan> appServicePlanCreatable)
        {
            AddCreatableDependency(appServicePlanCreatable as IResourceCreator<IHasId>);
            string id = ResourceUtils.ConstructResourceId(this.Manager.SubscriptionId,
            ResourceGroupName, "Microsoft.Web", "serverFarms", appServicePlanCreatable.Name, "");
            Inner.ServerFarmId = id;
            WithOperatingSystem(((AppServicePlanImpl)appServicePlanCreatable).OperatingSystem());
            return (FluentImplT)this;
        }

        private AppServicePlanImpl NewDefaultAppServicePlan()
        {
            String planName = SdkContext.RandomResourceName(Name + "plan", 32);
            AppServicePlanImpl appServicePlan = (AppServicePlanImpl) (this.Manager.AppServicePlans
            .Define(planName))
            .WithRegion(RegionName);
            if (newGroup != null && IsInCreateMode) {
                appServicePlan = appServicePlan.WithNewResourceGroup(newGroup) as AppServicePlanImpl;
            } else {
                appServicePlan = appServicePlan.WithExistingResourceGroup(ResourceGroupName) as AppServicePlanImpl;
            }
            return appServicePlan;
        }

        internal override async Task<Models.SiteAuthSettingsInner> UpdateAuthenticationAsync(SiteAuthSettingsInner inner, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Manager.Inner.WebApps.UpdateAuthSettingsAsync(ResourceGroupName, Name, inner, cancellationToken);
        }

        public FluentImplT WithNewSharedAppServicePlan()
        {
            return WithNewAppServicePlan(Fluent.OperatingSystem.Windows, new PricingTier("Shared", "D1"));
        }
        
        public FluentImplT WithNewFreeAppServicePlan()
        {
            return WithNewAppServicePlan(Fluent.OperatingSystem.Windows, new PricingTier("Free", "F1"));
        }
        

        ///GENMHASH:80973546C834C7C29422D77A01231051:254A5188A8B9B221986ACC09C33E3859
        public FluentImplT WithNewAppServicePlan(PricingTier pricingTier)
        {
            return WithNewAppServicePlan(OperatingSystem(), pricingTier);
        }

        ///GENMHASH:D5AD274A3026D80CDF6A0DD97D9F20D4:4A2ED55DAB8B08E815B4AB5554D9C60C
        public override async Task StartAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await Manager.Inner.WebApps.StartAsync(ResourceGroupName, Name, cancellationToken);
            await RefreshAsync(cancellationToken);
        }

        ///GENMHASH:8E71F8927E941B28152FA821CDDF0634:5EC2069F42116C38D303F70C89D7F575
        internal override async Task<Models.SiteAuthSettingsInner> GetAuthenticationAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Manager.Inner.WebApps.GetAuthSettingsAsync(ResourceGroupName, Name, cancellationToken);
        }

        ///GENMHASH:AE14C7C2170289895AEFF07E3516A2FC:186BCABCD05AC9B90A2EF619765A0DFE
        public override async Task ResetSlotConfigurationsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await Manager.Inner.WebApps.ResetProductionSlotConfigAsync(ResourceGroupName, Name, cancellationToken);
            await RefreshAsync(cancellationToken);
        }

        ///GENMHASH:E7F5C40042323022AA5171FA979A6E79:27DA6227AE38DA9C9AC067D20F4EEEAC
        public override async Task SwapAsync(string slotName, CancellationToken cancellationToken = default(CancellationToken))
        {
            await Manager.Inner.WebApps.SwapSlotWithProductionAsync(ResourceGroupName, Name, new CsmSlotEntityInner
            {
                TargetSlot = slotName
            }, cancellationToken);
            await RefreshAsync(cancellationToken);
        }

        ///GENMHASH:E10A5B0FD0E95947B1A669D51E6BD5C9:977A64CFAC7B27FE0960C4DC670C662E
        public override async Task<System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.AppService.Fluent.IHostNameBinding>> GetHostNameBindingsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var bindingsList = await PagedCollection<IHostNameBinding, HostNameBindingInner>.LoadPage(
                async (cancellation) => await Manager.Inner.WebApps.ListHostNameBindingsAsync(ResourceGroupName, Name, cancellation),
                Manager.Inner.WebApps.ListHostNameBindingsNextAsync,
                (inner) => new HostNameBindingImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT>(inner, (FluentImplT) this),
                true, cancellationToken);
            return bindingsList.ToDictionary(binding => binding.Name.Replace(this.Name + "/", ""));
        }

        public async override Task ApplySlotConfigurationsAsync(string slotName, CancellationToken cancellationToken = default(CancellationToken))
        {
            await Manager.Inner.WebApps.ApplySlotConfigToProductionAsync(ResourceGroupName, Name, new CsmSlotEntityInner
            {
                TargetSlot = slotName
            }, cancellationToken);
            await RefreshAsync(cancellationToken);
        }

        public async override Task StopAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await Manager.Inner.WebApps.StopAsync(ResourceGroupName, Name, cancellationToken);
            await RefreshAsync(cancellationToken);
        }

        public async override Task<IPublishingProfile> GetPublishingProfileAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            Stream stream = await Manager.Inner.WebApps.ListPublishingProfileXmlWithSecretsAsync(ResourceGroupName, Name, new CsmPublishingProfileOptionsInner(), cancellationToken);
            StreamReader reader = new StreamReader(stream);
            string xml = reader.ReadToEnd();
            return new PublishingProfileImpl(xml);
        }

        public async override Task RestartAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await Manager.Inner.WebApps.RestartAsync(ResourceGroupName, Name, null, null, cancellationToken);
            await RefreshAsync(cancellationToken);
        }

        public async override Task<IWebAppSourceControl> GetSourceControlAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return new WebAppSourceControlImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT>
                (await Manager.Inner.WebApps.GetSourceControlAsync(ResourceGroupName, Name, cancellationToken), this);
        }

        protected async override Task<SiteInner> GetInnerAsync(CancellationToken cancellationToken)
        {
            return await Manager.Inner.WebApps.GetAsync(ResourceGroupName, Name, cancellationToken);
        }

        internal override async Task<MSDeployStatusInner> CreateMSDeploy(MSDeployInner msDeployInner, CancellationToken cancellationToken)
        {
            return await Manager.Inner.WebApps.CreateMSDeployOperationAsync(ResourceGroupName, Name, msDeployInner, cancellationToken);
        }
    }
}
