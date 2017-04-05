// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using AppServicePlan.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using ResourceManager.Fluent.Core;

    /// <summary>
    /// Entry point for App Service plan management API.
    /// </summary>
    /// <remarks>
    /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in future releases, including removal, regardless of any compatibility expectations set by the containing library version number.)
    /// </remarks>
    public interface IAppServicePlans  :
        ISupportsCreating<AppServicePlan.Definition.IBlank>,
        ISupportsDeletingById,
        ISupportsListingByResourceGroup<Microsoft.Azure.Management.AppService.Fluent.IAppServicePlan>,
        ISupportsListing<Microsoft.Azure.Management.AppService.Fluent.IAppServicePlan>,
        ISupportsGettingByResourceGroup<Microsoft.Azure.Management.AppService.Fluent.IAppServicePlan>,
        ISupportsGettingById<Microsoft.Azure.Management.AppService.Fluent.IAppServicePlan>,
        ISupportsDeletingByResourceGroup,
        IHasManager<IAppServiceManager>,
        IHasInner<IAppServicePlansOperations>
    {
    }
}