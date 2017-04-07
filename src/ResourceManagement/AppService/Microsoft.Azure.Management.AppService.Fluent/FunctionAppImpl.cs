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
    using System;

    /// <summary>
    /// The implementation for FunctionApp.
    /// </summary>
    internal partial class FunctionAppImpl  :
        AppServiceBaseImpl<IFunctionApp,FunctionAppImpl,IWithCreate, INewAppServicePlanWithGroup, IWithCreate, IUpdate>,
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

        internal  FunctionAppImpl(string name, SiteInner innerObject, SiteConfigResourceInner configObject, IAppServiceManager manager)
            : base(name, innerObject, configObject, manager)
        {
            //$ super(name, innerObject, configObject, manager);
            //$ innerObject.WithKind("functionapp");
            //$ }

        }

        public FunctionAppImpl WithNewStorageAccount(string name, Storage.Fluent.Models.SkuName sku)
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

        public override Task ApplySlotConfigurationsAsync(string slotName, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public override Task StopAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public override Task<IPublishingProfile> GetPublishingProfileAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public override Task RestartAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public override Task<IWebAppSourceControl> GetSourceControlAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        protected override Task<SiteInner> GetInnerAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
