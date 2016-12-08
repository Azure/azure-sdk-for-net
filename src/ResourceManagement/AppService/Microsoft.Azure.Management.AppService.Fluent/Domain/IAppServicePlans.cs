// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Appservice.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using AppServicePlan.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;

    /// <summary>
    /// Entry point for app service plan management API.
    /// </summary>
    public interface IAppServicePlans  :
        ISupportsCreating<AppServicePlan.Definition.IBlank>,
        ISupportsDeletingById,
        ISupportsListingByGroup<Microsoft.Azure.Management.Appservice.Fluent.IAppServicePlan>,
        ISupportsGettingByGroup<Microsoft.Azure.Management.Appservice.Fluent.IAppServicePlan>,
        ISupportsGettingById<Microsoft.Azure.Management.Appservice.Fluent.IAppServicePlan>,
        ISupportsDeletingByGroup
    {
        /// <summary>
        /// Gets the information about a resource from Azure based on the resource name and the name of its resource group.
        /// </summary>
        /// <param name="id">The app service plan resource ID.</param>
        Task<Microsoft.Azure.Management.Appservice.Fluent.IAppServicePlan> GetByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken));
    }
}