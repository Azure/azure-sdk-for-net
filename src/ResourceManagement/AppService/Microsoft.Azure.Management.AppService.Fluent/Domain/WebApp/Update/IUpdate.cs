// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent.WebApp.Update
{
    using Microsoft.Azure.Management.AppService.Fluent;
    using Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update;

    /// <summary>
    /// As web app update allowing more information of a new app service plan to be set.
    /// </summary>
    public interface IWithNewAppServicePlan 
    {
        /// <summary>
        /// Creates a new app service plan to use.
        /// </summary>
        /// <param name="pricingTier">The pricing tier to use.</param>
        Microsoft.Azure.Management.AppService.Fluent.WebApp.Update.IUpdate WithPricingTier(AppServicePricingTier pricingTier);

        /// <summary>
        /// Creates a new free app service plan to use. No custom domains or SSL bindings are available in this plan.
        /// </summary>
        Microsoft.Azure.Management.AppService.Fluent.WebApp.Update.IUpdate WithFreePricingTier();
    }

    /// <summary>
    /// The template for a web app update operation, containing all the settings that can be modified.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IWebApp>,
        IWithAppServicePlan,
        IWithNewAppServicePlan
    {
    }

    /// <summary>
    /// A web app update allowing app service plan to be set.
    /// </summary>
    public interface IWithAppServicePlan 
    {
        /// <summary>
        /// Creates a new app service plan to use.
        /// </summary>
        /// <return>The next stage of the web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebApp.Update.IWithNewAppServicePlan WithNewAppServicePlan(string name);

        /// <summary>
        /// Uses an existing app service plan for the web app.
        /// </summary>
        /// <param name="appServicePlan">The existing app service plan.</param>
        Microsoft.Azure.Management.AppService.Fluent.WebApp.Update.IUpdate WithExistingAppServicePlan(IAppServicePlan appServicePlan);
    }
}