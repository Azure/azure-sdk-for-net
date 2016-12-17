// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using WebApp.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;

    /// <summary>
    /// Entry point for web app management API.
    /// </summary>
    public interface IWebApps  :
        ISupportsCreating<WebApp.Definition.IBlank>,
        ISupportsDeletingById,
        ISupportsListingByGroup<Microsoft.Azure.Management.AppService.Fluent.IWebApp>,
        ISupportsGettingByGroup<Microsoft.Azure.Management.AppService.Fluent.IWebApp>,
        ISupportsGettingById<Microsoft.Azure.Management.AppService.Fluent.IWebApp>,
        ISupportsDeletingByGroup
    {
    }
}