// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using AppServicePlan.Update;
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;

    /// <summary>
    /// An immutable client-side representation of an Azure App Service Plan.
    /// </summary>
    public interface IAppServicePlan  :
        IGroupableResource,
        IHasName,
        IRefreshable<Microsoft.Azure.Management.AppService.Fluent.IAppServicePlan>,
        IUpdatable<AppServicePlan.Update.IUpdate>,
        IWrapper<Microsoft.Azure.Management.AppService.Fluent.Models.AppServicePlanInner>
    {
        bool PerSiteScaling { get; }

        int NumberOfWebApps { get; }

        int MaxInstances { get; }

        int Capacity { get; }

        Microsoft.Azure.Management.AppService.Fluent.AppServicePricingTier PricingTier { get; }
    }
}