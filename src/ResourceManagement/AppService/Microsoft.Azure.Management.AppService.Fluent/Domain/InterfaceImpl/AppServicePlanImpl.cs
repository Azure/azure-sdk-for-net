// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Appservice.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using AppServicePlan.Definition;
    using AppServicePlan.Update;
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.Resource.Fluent;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;

    internal partial class AppServicePlanImpl 
    {
        int Microsoft.Azure.Management.Appservice.Fluent.IAppServicePlan.NumberOfWebApps
        {
            get
            {
                return this.NumberOfWebApps();
            }
        }

        int Microsoft.Azure.Management.Appservice.Fluent.IAppServicePlan.Capacity
        {
            get
            {
                return this.Capacity();
            }
        }

        int Microsoft.Azure.Management.Appservice.Fluent.IAppServicePlan.MaxInstances
        {
            get
            {
                return this.MaxInstances();
            }
        }

        Microsoft.Azure.Management.Appservice.Fluent.AppServicePricingTier Microsoft.Azure.Management.Appservice.Fluent.IAppServicePlan.PricingTier
        {
            get
            {
                return this.PricingTier() as Microsoft.Azure.Management.Appservice.Fluent.AppServicePricingTier;
            }
        }

        bool Microsoft.Azure.Management.Appservice.Fluent.IAppServicePlan.PerSiteScaling
        {
            get
            {
                return this.PerSiteScaling();
            }
        }

        /// <summary>
        /// Specifies the pricing tier for the app service plan.
        /// </summary>
        /// <param name="pricingTier">The pricing tier enum.</param>
        AppServicePlan.Update.IUpdate AppServicePlan.Update.IWithPricingTier.WithPricingTier(AppServicePricingTier pricingTier)
        {
            return this.WithPricingTier(pricingTier) as AppServicePlan.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the pricing tier for the app service plan.
        /// </summary>
        /// <param name="pricingTier">The pricing tier enum.</param>
        AppServicePlan.Definition.IWithCreate AppServicePlan.Definition.IWithPricingTier.WithPricingTier(AppServicePricingTier pricingTier)
        {
            return this.WithPricingTier(pricingTier) as AppServicePlan.Definition.IWithCreate;
        }

        /// <summary>
        /// Refreshes the resource to sync with Azure.
        /// </summary>
        Microsoft.Azure.Management.Appservice.Fluent.IAppServicePlan Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Appservice.Fluent.IAppServicePlan>.Refresh()
        {
            return this.Refresh() as Microsoft.Azure.Management.Appservice.Fluent.IAppServicePlan;
        }

        /// <summary>
        /// Specifies whether per-site scaling will be turned on.
        /// </summary>
        /// <param name="perSiteScaling">If each site can be scaled individually.</param>
        AppServicePlan.Update.IUpdate AppServicePlan.Update.IWithPerSiteScaling.WithPerSiteScaling(bool perSiteScaling)
        {
            return this.WithPerSiteScaling(perSiteScaling) as AppServicePlan.Update.IUpdate;
        }

        /// <summary>
        /// Specifies whether per-site scaling will be turned on.
        /// </summary>
        /// <param name="perSiteScaling">If each site can be scaled individually.</param>
        AppServicePlan.Definition.IWithCreate AppServicePlan.Definition.IWithPerSiteScaling.WithPerSiteScaling(bool perSiteScaling)
        {
            return this.WithPerSiteScaling(perSiteScaling) as AppServicePlan.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the maximum number of instances running for this app service plan.
        /// </summary>
        /// <param name="capacity">The maximum number of instances.</param>
        AppServicePlan.Update.IUpdate AppServicePlan.Update.IWithCapacity.WithCapacity(int capacity)
        {
            return this.WithCapacity(capacity) as AppServicePlan.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the maximum number of instances running for this app service plan.
        /// </summary>
        /// <param name="capacity">The maximum number of instances.</param>
        AppServicePlan.Definition.IWithCreate AppServicePlan.Definition.IWithCapacity.WithCapacity(int capacity)
        {
            return this.WithCapacity(capacity) as AppServicePlan.Definition.IWithCreate;
        }
    }
}