// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.AppService.Fluent.FunctionApp.Definition;
    using Microsoft.Azure.Management.AppService.Fluent.FunctionApp.Update;
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition;
    using Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Storage.Fluent.Models;
    using Microsoft.Azure.Management.Storage.Fluent;

    /// <summary>
    /// The implementation for FunctionApp.
    /// </summary>
    internal partial class FunctionAppImpl  :
        AppServiceBaseImpl<Microsoft.Azure.Management.AppService.Fluent.IFunctionApp,Microsoft.Azure.Management.AppService.Fluent.FunctionAppImpl,FunctionApp.Definition.IWithCreate,FunctionApp.Update.IUpdate>,
        IFunctionApp,
        IDefinition,
        INewAppServicePlanWithGroup,
        IUpdate
    {
        private ICreatable<Microsoft.Azure.Management.Storage.Fluent.IStorageAccount> storageAccountCreatable;
        private IStorageAccount storageAccountToSet;
        private IStorageAccount currentStorageAccount;
                public IStorageAccount StorageAccount()
        {
            //$ return currentStorageAccount;

            return null;
        }

                public FunctionAppImpl WithoutDailyUsageQuota()
        {
            //$ return withDailyUsageQuota(0);

            return this;
        }

                private FunctionAppImpl AutoSetAlwaysOn(PricingTier pricingTier)
        {
            //$ SkuDescription description = pricingTier.ToSkuDescription();
            //$ if (description.Tier().EqualsIgnoreCase("Basic")
            //$ || description.Tier().EqualsIgnoreCase("Standard")
            //$ || description.Tier().EqualsIgnoreCase("Premium")) {
            //$ return withWebAppAlwaysOn(true);
            //$ } else {
            //$ return withWebAppAlwaysOn(false);
            //$ }
            //$ }

            return this;
        }

                public FunctionAppImpl WithDailyUsageQuota(int quota)
        {
            //$ inner().WithDailyMemoryTimeQuota(quota);
            //$ return this;

            return this;
        }

                internal  FunctionAppImpl(string name, SiteInner innerObject, SiteConfigResourceInner configObject, AppServiceManager manager)
        {
            //$ super(name, innerObject, configObject, manager);
            //$ innerObject.WithKind("functionapp");
            //$ }

        }

                public FunctionAppImpl WithNewStorageAccount(string name, SkuName sku)
        {
            //$ StorageAccount.DefinitionStages.WithGroup storageDefine = manager().StorageManager().StorageAccounts()
            //$ .Define(name)
            //$ .WithRegion(regionName());
            //$ if (super.CreatableGroup != null && isInCreateMode()) {
            //$ storageAccountCreatable = storageDefine.WithNewResourceGroup(super.CreatableGroup)
            //$ .WithGeneralPurposeAccountKind()
            //$ .WithSku(sku);
            //$ } else {
            //$ storageAccountCreatable = storageDefine.WithExistingResourceGroup(resourceGroupName())
            //$ .WithGeneralPurposeAccountKind()
            //$ .WithSku(sku);
            //$ }
            //$ addCreatableDependency(storageAccountCreatable);
            //$ return this;

            return this;
        }

                public FunctionAppImpl WithExistingStorageAccount(IStorageAccount storageAccount)
        {
            //$ this.storageAccountToSet = storageAccount;
            //$ return this;

            return this;
        }

                internal FunctionAppImpl WithNewAppServicePlan(OperatingSystem operatingSystem, PricingTier pricingTier)
        {
            //$ return super.WithNewAppServicePlan(operatingSystem, pricingTier).AutoSetAlwaysOn(pricingTier);

            return this;
        }

                public FunctionAppImpl WithRuntimeVersion(string version)
        {
            //$ return withAppSetting("FUNCTIONS_EXTENSION_VERSION", version.StartsWith("~") ? version : "~" + version);

            return this;
        }

                public FunctionAppImpl WithNewConsumptionPlan()
        {
            //$ return withNewAppServicePlan(OperatingSystem.WINDOWS, new PricingTier("Dynamic", "Y1"));

            return this;
        }

                internal async Task<Models.SiteInner> SubmitAppSettingsAsync(SiteInner site, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ if (storageAccountCreatable != null && createdResource(storageAccountCreatable.Key()) != null) {
            //$ storageAccountToSet = (StorageAccount) createdResource(storageAccountCreatable.Key());
            //$ }
            //$ if (storageAccountToSet == null) {
            //$ return super.SubmitAppSettings(site);
            //$ } else {
            //$ return storageAccountToSet.GetKeysAsync()
            //$ .FlatMapIterable(new Func1<List<StorageAccountKey>, Iterable<StorageAccountKey>>() {
            //$ @Override
            //$ public Iterable<StorageAccountKey> call(List<StorageAccountKey> storageAccountKeys) {
            //$ return storageAccountKeys;
            //$ }
            //$ })
            //$ .First().FlatMap(new Func1<StorageAccountKey, Observable<SiteInner>>() {
            //$ @Override
            //$ public Observable<SiteInner> call(StorageAccountKey storageAccountKey) {
            //$ String connectionString = String.Format("DefaultEndpointsProtocol=https;AccountName=%s;AccountKey=%s",
            //$ storageAccountToSet.Name(), storageAccountKey.Value());
            //$ withAppSetting("AzureWebJobsStorage", connectionString);
            //$ withAppSetting("AzureWebJobsDashboard", connectionString);
            //$ withAppSetting("WEBSITE_CONTENTAZUREFILECONNECTIONSTRING", connectionString);
            //$ withAppSetting("WEBSITE_CONTENTSHARE", SdkContext.RandomResourceName(name(), 32));
            //$ return FunctionAppImpl.Super.SubmitAppSettings(site);
            //$ }
            //$ }).DoOnCompleted(new Action0() {
            //$ @Override
            //$ public void call() {
            //$ currentStorageAccount = storageAccountToSet;
            //$ storageAccountToSet = null;
            //$ storageAccountCreatable = null;
            //$ }
            //$ });
            //$ }

            return null;
        }

                public async Task<Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IIndexable> CreateAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ if (inner().ServerFarmId() == null) {
            //$ withNewConsumptionPlan();
            //$ }
            //$ if (currentStorageAccount == null && storageAccountToSet == null && storageAccountCreatable == null) {
            //$ withNewStorageAccount(SdkContext.RandomResourceName(name(), 20), SkuName.STANDARD_GRS);
            //$ }
            //$ return super.CreateAsync();

            return null;
        }

                public FunctionAppImpl WithExistingAppServicePlan(IAppServicePlan appServicePlan)
        {
            //$ public FunctionAppImpl withExistingAppServicePlan(AppServicePlan appServicePlan) {
            //$ super.WithExistingAppServicePlan(appServicePlan);
            //$ return autoSetAlwaysOn(appServicePlan.PricingTier());

            return this;
        }

                public FunctionAppImpl WithLatestRuntimeVersion()
        {
            //$ return withRuntimeVersion("latest");

            return this;
        }

<<<<<<<<<<<<<<<<<<<<<<<<<<<NEW>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///GENMHASH:4127559E520EF0C62C8C8F2CA76EB9B0:8E933437632C54937B05DD12520FEA41
        public FunctionAppImpl WithLatestRuntimeVersion()
        {
            //$ return withRuntimeVersion("latest");

            return this;
        }

<<<<<<<<<<<<<<<<<<<<<<<<<<<NEW>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///GENMHASH:934D38FBA69BF2F25673598C416DD202:04B057A6E745A5FF2E49C5B7A9365A86
        public FunctionAppImpl WithExistingAppServicePlan(IAppServicePlan appServicePlan)
        {
            //$ public FunctionAppImpl withExistingAppServicePlan(AppServicePlan appServicePlan) {
            //$ super.WithExistingAppServicePlan(appServicePlan);
            //$ return autoSetAlwaysOn(appServicePlan.PricingTier());

            return this;
        }

<<<<<<<<<<<<<<<<<<<<<<<<<<<NEW>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///GENMHASH:32A8B56FE180FA4429482D706189DEA2:8759DB56BB529B826F19D598228B75D6
        public async Task<Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IIndexable> CreateAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ if (inner().ServerFarmId() == null) {
            //$ withNewConsumptionPlan();
            //$ }
            //$ if (currentStorageAccount == null && storageAccountToSet == null && storageAccountCreatable == null) {
            //$ withNewStorageAccount(SdkContext.RandomResourceName(name(), 20), SkuName.STANDARD_GRS);
            //$ }
            //$ return super.CreateAsync();

            return null;
        }

<<<<<<<<<<<<<<<<<<<<<<<<<<<NEW>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///GENMHASH:CB483EFD6E3479A51A8504AF23852854:C8627F46458815A36606154EE481D1AC
        internal async Task<Models.SiteInner> SubmitAppSettingsAsync(SiteInner site, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ if (storageAccountCreatable != null && createdResource(storageAccountCreatable.Key()) != null) {
            //$ storageAccountToSet = (StorageAccount) createdResource(storageAccountCreatable.Key());
            //$ }
            //$ if (storageAccountToSet == null) {
            //$ return super.SubmitAppSettings(site);
            //$ } else {
            //$ return storageAccountToSet.GetKeysAsync()
            //$ .FlatMapIterable(new Func1<List<StorageAccountKey>, Iterable<StorageAccountKey>>() {
            //$ @Override
            //$ public Iterable<StorageAccountKey> call(List<StorageAccountKey> storageAccountKeys) {
            //$ return storageAccountKeys;
            //$ }
            //$ })
            //$ .First().FlatMap(new Func1<StorageAccountKey, Observable<SiteInner>>() {
            //$ @Override
            //$ public Observable<SiteInner> call(StorageAccountKey storageAccountKey) {
            //$ String connectionString = String.Format("DefaultEndpointsProtocol=https;AccountName=%s;AccountKey=%s",
            //$ storageAccountToSet.Name(), storageAccountKey.Value());
            //$ withAppSetting("AzureWebJobsStorage", connectionString);
            //$ withAppSetting("AzureWebJobsDashboard", connectionString);
            //$ withAppSetting("WEBSITE_CONTENTAZUREFILECONNECTIONSTRING", connectionString);
            //$ withAppSetting("WEBSITE_CONTENTSHARE", SdkContext.RandomResourceName(name(), 32));
            //$ return FunctionAppImpl.Super.SubmitAppSettings(site);
            //$ }
            //$ }).DoOnCompleted(new Action0() {
            //$ @Override
            //$ public void call() {
            //$ currentStorageAccount = storageAccountToSet;
            //$ storageAccountToSet = null;
            //$ storageAccountCreatable = null;
            //$ }
            //$ });
            //$ }

            return null;
        }

<<<<<<<<<<<<<<<<<<<<<<<<<<<NEW>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///GENMHASH:ACD803326ADA69A6662FDDD5E2F286FC:A94DE4E83DD3F3775E1FA80AD8D2AD85
        public FunctionAppImpl WithNewConsumptionPlan()
        {
            //$ return withNewAppServicePlan(OperatingSystem.WINDOWS, new PricingTier("Dynamic", "Y1"));

            return this;
        }

<<<<<<<<<<<<<<<<<<<<<<<<<<<NEW>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///GENMHASH:C43E27B9176B580ACF7074BBA4C04C9F:10A8166FDEB66EE1F75700A3F53CE6B6
        public FunctionAppImpl WithRuntimeVersion(string version)
        {
            //$ return withAppSetting("FUNCTIONS_EXTENSION_VERSION", version.StartsWith("~") ? version : "~" + version);

            return this;
        }

<<<<<<<<<<<<<<<<<<<<<<<<<<<NEW>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///GENMHASH:28DD1F13A18A7CE526F8BF7BCDE9BE79:61A8884F3EC4F3001B333DCB7A8A733B
        internal FunctionAppImpl WithNewAppServicePlan(OperatingSystem operatingSystem, PricingTier pricingTier)
        {
            //$ return super.WithNewAppServicePlan(operatingSystem, pricingTier).AutoSetAlwaysOn(pricingTier);

            return this;
        }

<<<<<<<<<<<<<<<<<<<<<<<<<<<NEW>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///GENMHASH:8CB9B7EEE4A4226A6F5BBB2958CC5E81:D1A723391B47D625F2CFF2D3B19543CD
        public FunctionAppImpl WithExistingStorageAccount(IStorageAccount storageAccount)
        {
            //$ this.storageAccountToSet = storageAccount;
            //$ return this;

            return this;
        }

<<<<<<<<<<<<<<<<<<<<<<<<<<<NEW>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///GENMHASH:EA08586AA6C99150486BAA02FC8A1302:1750AD6D70660459B23323E8082027EF
        public FunctionAppImpl WithNewStorageAccount(string name, SkuName sku)
        {
            //$ StorageAccount.DefinitionStages.WithGroup storageDefine = manager().StorageManager().StorageAccounts()
            //$ .Define(name)
            //$ .WithRegion(regionName());
            //$ if (super.CreatableGroup != null && isInCreateMode()) {
            //$ storageAccountCreatable = storageDefine.WithNewResourceGroup(super.CreatableGroup)
            //$ .WithGeneralPurposeAccountKind()
            //$ .WithSku(sku);
            //$ } else {
            //$ storageAccountCreatable = storageDefine.WithExistingResourceGroup(resourceGroupName())
            //$ .WithGeneralPurposeAccountKind()
            //$ .WithSku(sku);
            //$ }
            //$ addCreatableDependency(storageAccountCreatable);
            //$ return this;

            return this;
        }

<<<<<<<<<<<<<<<<<<<<<<<<<<<NEW>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///GENMHASH:0060702AD56521F2DB14F80D01DF7A56:ADA82893A08DBD6BE3A801C30D4E5F55
        public FunctionAppImpl WithDailyUsageQuota(int quota)
        {
            //$ inner().WithDailyMemoryTimeQuota(quota);
            //$ return this;

            return this;
        }

<<<<<<<<<<<<<<<<<<<<<<<<<<<NEW>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///GENMHASH:4D6103FA1D986E75929F6BCA5E7ABE6D:72865867319282A6DB3B990F3EDC4622
        private FunctionAppImpl AutoSetAlwaysOn(PricingTier pricingTier)
        {
            //$ SkuDescription description = pricingTier.ToSkuDescription();
            //$ if (description.Tier().EqualsIgnoreCase("Basic")
            //$ || description.Tier().EqualsIgnoreCase("Standard")
            //$ || description.Tier().EqualsIgnoreCase("Premium")) {
            //$ return withWebAppAlwaysOn(true);
            //$ } else {
            //$ return withWebAppAlwaysOn(false);
            //$ }
            //$ }

            return this;
        }

<<<<<<<<<<<<<<<<<<<<<<<<<<<NEW>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///GENMHASH:F55531335A90BF936D9E53049A5D25A5:98775CC167CAF2B8250B24D32FFA92A9
        public FunctionAppImpl WithoutDailyUsageQuota()
        {
            //$ return withDailyUsageQuota(0);

            return this;
        }

<<<<<<<<<<<<<<<<<<<<<<<<<<<NEW>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///GENMHASH:8248E1723DDED65C80D5D302AF0729CD:29988E8B635211098FA6CB64EB8717A1
        public IStorageAccount StorageAccount()
        {
            //$ return currentStorageAccount;

            return null;
        }

    }
}
