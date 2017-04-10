// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent.FunctionApp.Update
{
    using Microsoft.Azure.Management.AppService.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Storage.Fluent.Models;
    using Microsoft.Azure.Management.Storage.Fluent;
    using Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update;

    /// <summary>
    /// A function app update allowing app service plan to be set.
    /// </summary>
    public interface IWithAppServicePlan 
    {
        /// <summary>
        /// Creates a new shared app service plan.
        /// </summary>
        /// <return>The next stage of the function app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.FunctionApp.Update.IUpdate WithNewSharedAppServicePlan();

        /// <summary>
        /// Creates a new free app service plan. This will fail if there are 10 or more
        /// free plans in the current subscription.
        /// </summary>
        /// <return>The next stage of the function app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.FunctionApp.Update.IUpdate WithNewFreeAppServicePlan();

        /// <summary>
        /// Creates a new app service plan to use.
        /// </summary>
        /// <param name="pricingTier">The sku of the app service plan.</param>
        /// <return>The next stage of the function app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.FunctionApp.Update.IUpdate WithNewAppServicePlan(PricingTier pricingTier);

        /// <summary>
        /// Creates a new app service plan to use.
        /// </summary>
        /// <param name="appServicePlanCreatable">The new app service plan creatable.</param>
        /// <return>The next stage of the function app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.FunctionApp.Update.IUpdate WithNewAppServicePlan(ICreatable<Microsoft.Azure.Management.AppService.Fluent.IAppServicePlan> appServicePlanCreatable);

        /// <summary>
        /// Creates a new consumption plan to use.
        /// </summary>
        /// <return>The next stage of the function app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.FunctionApp.Update.IUpdate WithNewConsumptionPlan();

        /// <summary>
        /// Uses an existing app service plan for the function app.
        /// </summary>
        /// <param name="appServicePlan">The existing app service plan.</param>
        /// <return>The next stage of the function app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.FunctionApp.Update.IUpdate WithExistingAppServicePlan(IAppServicePlan appServicePlan);
    }

    /// <summary>
    /// A function app definition allowing storage account to be specified.
    /// A storage account is required for storing function execution runtime,
    /// triggers, and logs.
    /// </summary>
    public interface IWithStorageAccount 
    {
        /// <summary>
        /// Creates a new storage account to use for the function app.
        /// </summary>
        /// <param name="name">The name of the storage account.</param>
        /// <param name="sku">The sku of the storage account.</param>
        /// <return>The next stage of the function app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.FunctionApp.Update.IUpdate WithNewStorageAccount(string name, SkuName sku);

        /// <summary>
        /// Specifies the storage account to use for the function app.
        /// </summary>
        /// <param name="storageAccount">The storage account to use.</param>
        /// <return>The next stage of the function app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.FunctionApp.Update.IUpdate WithExistingStorageAccount(IStorageAccount storageAccount);
    }

    /// <summary>
    /// The template for a function app update operation, containing all the settings that can be modified.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IFunctionApp>,
        Microsoft.Azure.Management.AppService.Fluent.FunctionApp.Update.IWithAppServicePlan,
        Microsoft.Azure.Management.AppService.Fluent.FunctionApp.Update.IWithRuntimeVersion,
        Microsoft.Azure.Management.AppService.Fluent.FunctionApp.Update.IWithStorageAccount,
        Microsoft.Azure.Management.AppService.Fluent.FunctionApp.Update.IWithDailyUsageQuota
    {
    }

    /// <summary>
    /// A function app definition allowing daily usage quota to be specified.
    /// </summary>
    public interface IWithDailyUsageQuota 
    {
        /// <summary>
        /// Specifies the daily usage data cap.
        /// </summary>
        /// <return>The next stage of the function app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.FunctionApp.Update.IUpdate WithoutDailyUsageQuota();

        /// <summary>
        /// Specifies the daily usage data cap.
        /// </summary>
        /// <param name="quota">The daily usage quota.</param>
        /// <return>The next stage of the function app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.FunctionApp.Update.IUpdate WithDailyUsageQuota(int quota);
    }

    /// <summary>
    /// A function app update allowing runtime version to be specified.
    /// </summary>
    public interface IWithRuntimeVersion 
    {
        /// <summary>
        /// Specifies the runtime version for the function app.
        /// </summary>
        /// <param name="version">The version of the Azure Functions runtime.</param>
        /// <return>The next stage of the function app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.FunctionApp.Update.IUpdate WithRuntimeVersion(string version);

        /// <summary>
        /// Uses the latest runtime version for the function app.
        /// </summary>
        /// <return>The next stage of the function app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.FunctionApp.Update.IUpdate WithLatestRuntimeVersion();
    }
}