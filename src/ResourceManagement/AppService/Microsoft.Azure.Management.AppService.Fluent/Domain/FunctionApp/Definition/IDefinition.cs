// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent.FunctionApp.Definition
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.AppService.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition;
    using Microsoft.Azure.Management.Storage.Fluent.Models;
    using Microsoft.Azure.Management.Storage.Fluent;

    /// <summary>
    /// A function app definition allowing runtime version to be specified.
    /// </summary>
    public interface IWithRuntimeVersion 
    {
        /// <summary>
        /// Specifies the runtime version for the function app.
        /// </summary>
        /// <param name="version">The version of the Azure Functions runtime.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.FunctionApp.Definition.IWithCreate WithRuntimeVersion(string version);

        /// <summary>
        /// Uses the latest runtime version for the function app.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.FunctionApp.Definition.IWithCreate WithLatestRuntimeVersion();
    }

    /// <summary>
    /// A function app definition allowing resource group to be specified when an existing app service plan is used.
    /// </summary>
    public interface IExistingAppServicePlanWithGroup  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition.IWithGroup<Microsoft.Azure.Management.AppService.Fluent.FunctionApp.Definition.IWithCreate>
    {
    }

    /// <summary>
    /// A function app definition allowing resource group to be specified when a new app service plan is to be created.
    /// </summary>
    public interface INewAppServicePlanWithGroup 
    {
        /// <summary>
        /// Creates a new resource group to put the resource in.
        /// The group will be created in the same location as the resource.
        /// </summary>
        /// <param name="name">The name of the new group.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.FunctionApp.Definition.IWithCreate WithNewResourceGroup(string name);

        /// <summary>
        /// Creates a new resource group to put the resource in.
        /// The group will be created in the same location as the resource.
        /// The group's name is automatically derived from the resource's name.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.FunctionApp.Definition.IWithCreate WithNewResourceGroup();

        /// <summary>
        /// Creates a new resource group to put the resource in, based on the definition specified.
        /// </summary>
        /// <param name="groupDefinition">A creatable definition for a new resource group.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.FunctionApp.Definition.IWithCreate WithNewResourceGroup(ICreatable<Microsoft.Azure.Management.ResourceManager.Fluent.IResourceGroup> groupDefinition);

        /// <summary>
        /// Associates the resource with an existing resource group.
        /// </summary>
        /// <param name="groupName">The name of an existing resource group to put this resource in.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.FunctionApp.Definition.IWithCreate WithExistingResourceGroup(string groupName);

        /// <summary>
        /// Associates the resource with an existing resource group.
        /// </summary>
        /// <param name="group">An existing resource group to put the resource in.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.FunctionApp.Definition.IWithCreate WithExistingResourceGroup(IResourceGroup group);
    }

    /// <summary>
    /// A function app definition allowing app service plan to be set.
    /// </summary>
    public interface IWithNewAppServicePlan 
    {
        /// <summary>
        /// Creates a new shared app service plan.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.FunctionApp.Definition.IWithCreate WithNewSharedAppServicePlan();

        /// <summary>
        /// Creates a new free app service plan. This will fail if there are 10 or more
        /// free plans in the current subscription.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.FunctionApp.Definition.IWithCreate WithNewFreeAppServicePlan();

        /// <summary>
        /// Creates a new app service plan to use.
        /// </summary>
        /// <param name="pricingTier">The sku of the app service plan.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.FunctionApp.Definition.IWithCreate WithNewAppServicePlan(PricingTier pricingTier);

        /// <summary>
        /// Creates a new app service plan to use.
        /// </summary>
        /// <param name="appServicePlanCreatable">The new app service plan creatable.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.FunctionApp.Definition.IWithCreate WithNewAppServicePlan(ICreatable<Microsoft.Azure.Management.AppService.Fluent.IAppServicePlan> appServicePlanCreatable);

        /// <summary>
        /// Creates a new consumption plan to use.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.FunctionApp.Definition.IWithCreate WithNewConsumptionPlan();
    }

    /// <summary>
    /// Container interface for all the definitions that need to be implemented.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.AppService.Fluent.FunctionApp.Definition.IBlank,
        Microsoft.Azure.Management.AppService.Fluent.FunctionApp.Definition.IExistingAppServicePlanWithGroup,
        Microsoft.Azure.Management.AppService.Fluent.FunctionApp.Definition.IWithStorageAccount,
        Microsoft.Azure.Management.AppService.Fluent.FunctionApp.Definition.IWithCreate
    {
    }

    /// <summary>
    /// The first stage of the function app definition.
    /// </summary>
    public interface IBlank  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithRegion<Microsoft.Azure.Management.AppService.Fluent.FunctionApp.Definition.INewAppServicePlanWithGroup>
    {
        /// <summary>
        /// Uses an existing app service plan for the function app.
        /// </summary>
        /// <param name="appServicePlan">The existing app service plan.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.FunctionApp.Definition.IExistingAppServicePlanWithGroup WithExistingAppServicePlan(IAppServicePlan appServicePlan);
    }

    /// <summary>
    /// A function app definition with sufficient inputs to create a new
    /// function app in the cloud, but exposing additional optional
    /// inputs to specify.
    /// </summary>
    public interface IWithCreate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.AppService.Fluent.IFunctionApp>,
        Microsoft.Azure.Management.AppService.Fluent.FunctionApp.Definition.IWithNewAppServicePlan,
        Microsoft.Azure.Management.AppService.Fluent.FunctionApp.Definition.IWithStorageAccount,
        Microsoft.Azure.Management.AppService.Fluent.FunctionApp.Definition.IWithRuntimeVersion,
        Microsoft.Azure.Management.AppService.Fluent.FunctionApp.Definition.IWithDailyUsageQuota,
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<Microsoft.Azure.Management.AppService.Fluent.IFunctionApp>
    {
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
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.FunctionApp.Definition.IWithCreate WithNewStorageAccount(string name, SkuName sku);

        /// <summary>
        /// Specifies the storage account to use for the function app.
        /// </summary>
        /// <param name="storageAccount">The storage account to use.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.FunctionApp.Definition.IWithCreate WithExistingStorageAccount(IStorageAccount storageAccount);
    }

    /// <summary>
    /// A function app definition allowing daily usage quota to be specified.
    /// </summary>
    public interface IWithDailyUsageQuota 
    {
        /// <summary>
        /// Specifies the daily usage data cap.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.FunctionApp.Definition.IWithCreate WithoutDailyUsageQuota();

        /// <summary>
        /// Specifies the daily usage data cap.
        /// </summary>
        /// <param name="quota">The daily usage quota.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.FunctionApp.Definition.IWithCreate WithDailyUsageQuota(int quota);
    }
}