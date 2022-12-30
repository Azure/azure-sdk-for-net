// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using Azure.Core;
using Azure.ResourceManager.AppService.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.AppService
{
    /// <summary>
    /// A Class representing an AppServicePlan along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct an <see cref="AppServicePlanResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetAppServicePlanResource method.
    /// Otherwise you can get one from its parent resource <see cref="ResourceGroupResource" /> using the GetAppServicePlan method.
    /// </summary>
    public partial class AppServicePlanResource : ArmResource
    {
        /// <summary>
        /// Description for Get all apps associated with an App Service plan.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/serverfarms/{name}/sites
        /// Operation Id: AppServicePlans_ListWebApps
        /// </summary>
        /// <param name="skipToken"> Skip to a web app in the list of webapps associated with app service plan. If specified, the resulting list will contain web apps starting from (including) the skipToken. Otherwise, the resulting list contains web apps from the start of the list. </param>
        /// <param name="filter"> Supported filter: $filter=state eq running. Returns only web apps that are currently running. </param>
        /// <param name="top"> List page size. If specified, results are paged. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="WebSiteData" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<WebSiteData> GetWebAppsAsync(string skipToken = null, string filter = null, string top = null, CancellationToken cancellationToken = default) =>
            GetWebAppsAsync(new AppServicePlanResourceGetWebAppsOptions
            {
                SkipToken = skipToken,
                Filter = filter,
                Top = top
            }, cancellationToken);

        /// <summary>
        /// Description for Get all apps associated with an App Service plan.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/serverfarms/{name}/sites
        /// Operation Id: AppServicePlans_ListWebApps
        /// </summary>
        /// <param name="skipToken"> Skip to a web app in the list of webapps associated with app service plan. If specified, the resulting list will contain web apps starting from (including) the skipToken. Otherwise, the resulting list contains web apps from the start of the list. </param>
        /// <param name="filter"> Supported filter: $filter=state eq running. Returns only web apps that are currently running. </param>
        /// <param name="top"> List page size. If specified, results are paged. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="WebSiteData" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<WebSiteData> GetWebApps(string skipToken = null, string filter = null, string top = null, CancellationToken cancellationToken = default) =>
            GetWebApps(new AppServicePlanResourceGetWebAppsOptions
            {
                SkipToken = skipToken,
                Filter = filter,
                Top = top
            }, cancellationToken);
    }
}
