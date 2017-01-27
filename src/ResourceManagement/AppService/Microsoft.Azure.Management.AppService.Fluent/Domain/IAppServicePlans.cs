// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using AppServicePlan.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;
    using Resource.Fluent.Core;

    /// <summary>
    /// Entry point for app service plan management API.
    /// </summary>
    public interface IAppServicePlans  :
        ISupportsCreating<AppServicePlan.Definition.IBlank>,
        ISupportsDeletingById,
        ISupportsListingByGroup<Microsoft.Azure.Management.AppService.Fluent.IAppServicePlan>,
        ISupportsGettingByGroup<Microsoft.Azure.Management.AppService.Fluent.IAppServicePlan>,
        ISupportsGettingById<Microsoft.Azure.Management.AppService.Fluent.IAppServicePlan>,
        ISupportsDeletingByGroup,
        IHasManager<IAppServiceManager>
    {
        /// <summary>
        /// Gets the information about a resource from Azure based on the resource name and the name of its resource group.
        /// </summary>
        /// <param name="id">The app service plan resource ID.</param>
        /// <return>An immutable representation of the resource.</return>
        Task<Microsoft.Azure.Management.AppService.Fluent.IAppServicePlan> GetByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken));
    }
}