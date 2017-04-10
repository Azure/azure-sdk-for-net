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
    using ResourceManager.Fluent.Core;
    using ResourceManager.Fluent;

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
            return currentStorageAccount;
        }

        public FunctionAppImpl WithoutDailyUsageQuota()
        {
            return WithDailyUsageQuota(0);
        }

        private FunctionAppImpl AutoSetAlwaysOn(PricingTier pricingTier)
        {
            SkuDescription description = pricingTier.SkuDescription;
            if (description.Tier.Equals("Basic", StringComparison.OrdinalIgnoreCase)
                || description.Tier.Equals("Standard", StringComparison.OrdinalIgnoreCase)
                || description.Tier.Equals("Premium", StringComparison.OrdinalIgnoreCase))
            {
                return WithWebAppAlwaysOn(true);
            }
            else
            {
                return WithWebAppAlwaysOn(false);
            }
        }

        public FunctionAppImpl WithDailyUsageQuota(int quota)
        {
            Inner.DailyMemoryTimeQuota = quota;
            return this;
        }

        internal  FunctionAppImpl(string name, SiteInner innerObject, SiteConfigResourceInner configObject, IAppServiceManager manager)
            : base(name, innerObject, configObject, manager)
        {
            Inner.Kind = "functionapp";
        }

        public FunctionAppImpl WithNewStorageAccount(string name, Storage.Fluent.Models.SkuName sku)
        {
            Storage.Fluent.StorageAccount.Definition.IWithGroup storageDefine = Manager.StorageManager.StorageAccounts
                .Define(name)
                .WithRegion(RegionName);
            if (newGroup != null && IsInCreateMode) {
                storageAccountCreatable = storageDefine.WithNewResourceGroup(newGroup)
                    .WithGeneralPurposeAccountKind()
                    .WithSku(sku);
            } else {
                storageAccountCreatable = storageDefine.WithExistingResourceGroup(ResourceGroupName)
                    .WithGeneralPurposeAccountKind()
                    .WithSku(sku);
            }
            AddCreatableDependency(storageAccountCreatable as IResourceCreator<IHasId>);
            return this;
        }

        public FunctionAppImpl WithExistingStorageAccount(IStorageAccount storageAccount)
        {
            this.storageAccountToSet = storageAccount;
            return this;
        }

        internal override FunctionAppImpl WithNewAppServicePlan(OperatingSystem operatingSystem, PricingTier pricingTier)
        {
            return base.WithNewAppServicePlan(operatingSystem, pricingTier).AutoSetAlwaysOn(pricingTier);
        }

        public FunctionAppImpl WithRuntimeVersion(string version)
        {
            return WithAppSetting("FUNCTIONS_EXTENSION_VERSION", version.StartsWith("~") ? version : "~" + version);
        }

        public FunctionAppImpl WithNewConsumptionPlan()
        {
            return WithNewAppServicePlan(Fluent.OperatingSystem.Windows, new PricingTier("Dynamic", "Y1"));
        }

        internal override async Task<Models.SiteInner> SubmitAppSettingsAsync(SiteInner site, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (storageAccountCreatable != null && CreatedResource(storageAccountCreatable.Key) != null)
            {
                storageAccountToSet = (IStorageAccount) CreatedResource(storageAccountCreatable.Key);
            }
            if (storageAccountToSet == null)
            {
                return await base.SubmitAppSettingsAsync(site, cancellationToken);
            }
            else
            {
                var keys = await storageAccountToSet.GetKeysAsync(cancellationToken);
                var connectionString = string.Format("DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1}",
                    storageAccountToSet.Name, keys[0].Value);
                WithAppSetting("AzureWebJobsStorage", connectionString);
                WithAppSetting("AzureWebJobsDashboard", connectionString);
                WithAppSetting("WEBSITE_CONTENTAZUREFILECONNECTIONSTRING", connectionString);
                WithAppSetting("WEBSITE_CONTENTSHARE", SdkContext.RandomResourceName(Name, 32));

                // clean up
                currentStorageAccount = storageAccountToSet;
                storageAccountToSet = null;
                storageAccountCreatable = null;

                return await base.SubmitAppSettingsAsync(site, cancellationToken);
            }
        }

        public override async Task<IFunctionApp> CreateAsync(CancellationToken cancellationToken = default(CancellationToken), bool multiThreaded = true)
        {
            if (Inner.ServerFarmId == null)
            {
                WithNewConsumptionPlan();
            }
            if (currentStorageAccount == null && storageAccountToSet == null && storageAccountCreatable == null)
            {
                WithNewStorageAccount(SdkContext.RandomResourceName(Name, 20), Storage.Fluent.Models.SkuName.StandardGRS);
            }
            return await base.CreateAsync(cancellationToken);
        }

        public override FunctionAppImpl WithExistingAppServicePlan(IAppServicePlan appServicePlan)
        {
            base.WithExistingAppServicePlan(appServicePlan);
            return AutoSetAlwaysOn(appServicePlan.PricingTier);
        }

        public FunctionAppImpl WithLatestRuntimeVersion()
        {
            return WithRuntimeVersion("latest");
        }
    }
}
