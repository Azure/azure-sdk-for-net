// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent.WebApp.Definition
{
    using Microsoft.Azure.Management.AppService.Fluent;
    using Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.GroupableResource.Definition;

    /// <summary>
    /// As web app definition allowing more information of a new app service plan to be set.
    /// </summary>
    public interface IWithNewAppServicePlan 
    {
        /// <summary>
        /// Creates a new app service plan to use.
        /// </summary>
        /// <param name="pricingTier">The pricing tier to use.</param>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithHostNameBinding<Microsoft.Azure.Management.AppService.Fluent.IWebApp> WithPricingTier(AppServicePricingTier pricingTier);

        /// <summary>
        /// Creates a new free app service plan to use. No custom domains or SSL bindings are available in this plan.
        /// </summary>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<Microsoft.Azure.Management.AppService.Fluent.IWebApp> WithFreePricingTier();
    }

    /// <summary>
    /// A web app definition allowing new app service plan's region to be set.
    /// </summary>
    public interface IWithRegion  :
        IDefinitionWithRegion<Microsoft.Azure.Management.AppService.Fluent.WebApp.Definition.IWithNewAppServicePlan>
    {
    }

    /// <summary>
    /// A web app definition allowing app service plan to be set.
    /// </summary>
    public interface IWithAppServicePlan 
    {
        /// <summary>
        /// Creates a new app service plan to use.
        /// </summary>
        /// <return>The next stage of the web app definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebApp.Definition.IWithRegion WithNewAppServicePlan(string name);

        /// <summary>
        /// Uses an existing app service plan for the web app.
        /// </summary>
        /// <param name="appServicePlan">The existing app service plan.</param>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithHostNameBinding<Microsoft.Azure.Management.AppService.Fluent.IWebApp> WithExistingAppServicePlan(IAppServicePlan appServicePlan);
    }

    /// <summary>
    /// The first stage of the web app definition.
    /// </summary>
    public interface IBlank  :
        IWithGroup<Microsoft.Azure.Management.AppService.Fluent.WebApp.Definition.IWithAppServicePlan>
    {
    }

    /// <summary>
    /// Container interface for all the definitions that need to be implemented.
    /// </summary>
    public interface IDefinition  :
        IBlank,
        IWithRegion,
        IWithAppServicePlan,
        IWithNewAppServicePlan
    {
    }
}