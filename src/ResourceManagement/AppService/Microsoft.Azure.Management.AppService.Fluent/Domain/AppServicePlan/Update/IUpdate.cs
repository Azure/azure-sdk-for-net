// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Appservice.Fluent.AppServicePlan.Update
{
    using Microsoft.Azure.Management.Appservice.Fluent;
    using Microsoft.Azure.Management.Resource.Fluent.Core.Resource.Update;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;

    /// <summary>
    /// An app service plan update allowing per site scaling configuration to be set.
    /// </summary>
    public interface IWithPerSiteScaling 
    {
        /// <summary>
        /// Specifies whether per-site scaling will be turned on.
        /// </summary>
        /// <param name="perSiteScaling">If each site can be scaled individually.</param>
        Microsoft.Azure.Management.Appservice.Fluent.AppServicePlan.Update.IUpdate WithPerSiteScaling(bool perSiteScaling);
    }

    /// <summary>
    /// The template for a site update operation, containing all the settings that can be modified.
    /// </summary>
    public interface IUpdate  :
        IAppliable<Microsoft.Azure.Management.Appservice.Fluent.IAppServicePlan>,
        IWithCapacity,
        IWithPerSiteScaling,
        IWithPricingTier,
        IUpdateWithTags<Microsoft.Azure.Management.Appservice.Fluent.AppServicePlan.Update.IUpdate>
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
        Microsoft.Azure.Management.Appservice.Fluent.AppServicePlan.Update.IUpdate WithPricingTier(AppServicePricingTier pricingTier);
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
        Microsoft.Azure.Management.Appservice.Fluent.AppServicePlan.Update.IUpdate WithCapacity(int capacity);
    }
}