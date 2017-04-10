// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent.AppServicePlan.Update
{
    using Microsoft.Azure.Management.AppService.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// An app service plan update allowing per site scaling configuration to be set.
    /// </summary>
    public interface IWithPerSiteScaling 
    {
        /// <summary>
        /// Specifies whether per-site scaling will be turned on.
        /// </summary>
        /// <param name="perSiteScaling">If each site can be scaled individually.</param>
        /// <return>The next stage of the app service plan update.</return>
        Microsoft.Azure.Management.AppService.Fluent.AppServicePlan.Update.IUpdate WithPerSiteScaling(bool perSiteScaling);
    }

    /// <summary>
    /// The template for a site update operation, containing all the settings that can be modified.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.AppService.Fluent.IAppServicePlan>,
        Microsoft.Azure.Management.AppService.Fluent.AppServicePlan.Update.IWithCapacity,
        Microsoft.Azure.Management.AppService.Fluent.AppServicePlan.Update.IWithPerSiteScaling,
        Microsoft.Azure.Management.AppService.Fluent.AppServicePlan.Update.IWithPricingTier,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update.IUpdateWithTags<Microsoft.Azure.Management.AppService.Fluent.AppServicePlan.Update.IUpdate>
    {
    }

    /// <summary>
    /// An app service plan definition allowing pricing tier to be set.
    /// </summary>
    public interface IWithPricingTier 
    {
        /// <summary>
        /// Specifies the pricing tier for the app service plan.
        /// </summary>
        /// <param name="pricingTier">The pricing tier enum.</param>
        /// <return>The next stage of the app service plan update.</return>
        Microsoft.Azure.Management.AppService.Fluent.AppServicePlan.Update.IUpdate WithPricingTier(PricingTier pricingTier);
    }

    /// <summary>
    /// An app service plan definition allowing instance capacity to be set.
    /// </summary>
    public interface IWithCapacity 
    {
        /// <summary>
        /// Specifies the maximum number of instances running for this app service plan.
        /// </summary>
        /// <param name="capacity">The maximum number of instances.</param>
        /// <return>The next stage of an app service plan update.</return>
        Microsoft.Azure.Management.AppService.Fluent.AppServicePlan.Update.IUpdate WithCapacity(int capacity);
    }
}