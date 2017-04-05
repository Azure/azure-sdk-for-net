// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using WebApp.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using ResourceManager.Fluent.Core;

    /// <summary>
    /// Entry point for web app management API.
    /// </summary>
    public interface IWebApps  :
        ISupportsCreating<WebApp.Definition.IBlank>,
        ISupportsDeletingById,
        ISupportsListingByResourceGroup<Microsoft.Azure.Management.AppService.Fluent.IWebApp>,
        ISupportsListing<Microsoft.Azure.Management.AppService.Fluent.IWebApp>,
        ISupportsGettingByResourceGroup<Microsoft.Azure.Management.AppService.Fluent.IWebApp>,
        ISupportsGettingById<Microsoft.Azure.Management.AppService.Fluent.IWebApp>,
        ISupportsDeletingByResourceGroup,
        IHasManager<IAppServiceManager>,
        IHasInner<IWebAppsOperations>
    {
    }
}