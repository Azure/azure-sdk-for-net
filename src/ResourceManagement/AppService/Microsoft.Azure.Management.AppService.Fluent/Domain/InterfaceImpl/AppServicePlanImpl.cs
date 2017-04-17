// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.AppService.Fluent.AppServicePlan.Definition;
    using Microsoft.Azure.Management.AppService.Fluent.AppServicePlan.Update;
    using Microsoft.Azure.Management.AppService.Fluent.Models;

    internal partial class AppServicePlanImpl 
    {
        /// <summary>
        /// Gets maximum number of instances that can be assigned.
        /// </summary>
        int Microsoft.Azure.Management.AppService.Fluent.IAppServicePlan.Capacity
        {
            get
            {
                return this.Capacity();
            }
        }

        /// <summary>
        /// Gets the operating system the web app is running on.
        /// </summary>
        Microsoft.Azure.Management.AppService.Fluent.OperatingSystem Microsoft.Azure.Management.AppService.Fluent.IAppServicePlan.OperatingSystem
        {
            get
            {
                return this.OperatingSystem();
            }
        }

        /// <summary>
        /// Gets the pricing tier information of the App Service Plan.
        /// </summary>
        Microsoft.Azure.Management.AppService.Fluent.PricingTier Microsoft.Azure.Management.AppService.Fluent.IAppServicePlan.PricingTier
        {
            get
            {
                return this.PricingTier() as Microsoft.Azure.Management.AppService.Fluent.PricingTier;
            }
        }

        /// <summary>
        /// Gets number of web apps assigned to this App Service Plan.
        /// </summary>
        int Microsoft.Azure.Management.AppService.Fluent.IAppServicePlan.NumberOfWebApps
        {
            get
            {
                return this.NumberOfWebApps();
            }
        }

        /// <summary>
        /// Gets if apps assigned to this App Service Plan can be scaled independently.
        /// </summary>
        bool Microsoft.Azure.Management.AppService.Fluent.IAppServicePlan.PerSiteScaling
        {
            get
            {
                return this.PerSiteScaling();
            }
        }

        /// <summary>
        /// Gets maximum number of instances that can be assigned.
        /// </summary>
        int Microsoft.Azure.Management.AppService.Fluent.IAppServicePlan.MaxInstances
        {
            get
            {
                return this.MaxInstances();
            }
        }

        /// <summary>
        /// Specifies the pricing tier for the app service plan.
        /// </summary>
        /// <param name="pricingTier">The pricing tier enum.</param>
        /// <return>The next stage of the app service plan update.</return>
        AppServicePlan.Update.IUpdate AppServicePlan.Update.IWithPricingTier.WithPricingTier(PricingTier pricingTier)
        {
            return this.WithPricingTier(pricingTier) as AppServicePlan.Update.IUpdate;
        }

        /// <summary>
        /// Specifies free pricing tier for the app service plan.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        AppServicePlan.Definition.IWithCreate AppServicePlan.Definition.IWithPricingTier.WithFreePricingTier()
        {
            return this.WithFreePricingTier() as AppServicePlan.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies shared pricing tier for the app service plan.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        AppServicePlan.Definition.IWithCreate AppServicePlan.Definition.IWithPricingTier.WithSharedPricingTier()
        {
            return this.WithSharedPricingTier() as AppServicePlan.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the pricing tier for the app service plan.
        /// </summary>
        /// <param name="pricingTier">The pricing tier enum.</param>
        /// <return>The next stage of the definition.</return>
        AppServicePlan.Definition.IWithOperatingSystem AppServicePlan.Definition.IWithPricingTier.WithPricingTier(PricingTier pricingTier)
        {
            return this.WithPricingTier(pricingTier) as AppServicePlan.Definition.IWithOperatingSystem;
        }

        /// <summary>
        /// Specifies whether per-site scaling will be turned on.
        /// </summary>
        /// <param name="perSiteScaling">If each site can be scaled individually.</param>
        /// <return>The next stage of the app service plan update.</return>
        AppServicePlan.Update.IUpdate AppServicePlan.Update.IWithPerSiteScaling.WithPerSiteScaling(bool perSiteScaling)
        {
            return this.WithPerSiteScaling(perSiteScaling) as AppServicePlan.Update.IUpdate;
        }

        /// <summary>
        /// Specifies whether per-site scaling will be turned on.
        /// </summary>
        /// <param name="perSiteScaling">If each site can be scaled individually.</param>
        /// <return>The next stage of the definition.</return>
        AppServicePlan.Definition.IWithCreate AppServicePlan.Definition.IWithPerSiteScaling.WithPerSiteScaling(bool perSiteScaling)
        {
            return this.WithPerSiteScaling(perSiteScaling) as AppServicePlan.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the maximum number of instances running for this app service plan.
        /// </summary>
        /// <param name="capacity">The maximum number of instances.</param>
        /// <return>The next stage of an app service plan update.</return>
        AppServicePlan.Update.IUpdate AppServicePlan.Update.IWithCapacity.WithCapacity(int capacity)
        {
            return this.WithCapacity(capacity) as AppServicePlan.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the maximum number of instances running for this app service plan.
        /// </summary>
        /// <param name="capacity">The maximum number of instances.</param>
        /// <return>The next stage of an app service plan definition.</return>
        AppServicePlan.Definition.IWithCreate AppServicePlan.Definition.IWithCapacity.WithCapacity(int capacity)
        {
            return this.WithCapacity(capacity) as AppServicePlan.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the operating system of the app service plan.
        /// </summary>
        /// <param name="operatingSystem">The operating system.</param>
        /// <return>The next stage of the definition.</return>
        AppServicePlan.Definition.IWithCreate AppServicePlan.Definition.IWithOperatingSystem.WithOperatingSystem(OperatingSystem operatingSystem)
        {
            return this.WithOperatingSystem(operatingSystem) as AppServicePlan.Definition.IWithCreate;
        }
    }
}