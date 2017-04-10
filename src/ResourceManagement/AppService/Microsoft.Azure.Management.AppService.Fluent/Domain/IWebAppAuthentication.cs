// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// A web app authentication configuration in a web app.
    /// </summary>
    /// <remarks>
    /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
    /// future releases, including removal, regardless of any compatibility expectations set by the containing library
    /// version number.).
    /// </remarks>
    public interface IWebAppAuthentication  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.SiteAuthSettingsInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IIndexable,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasParent<Microsoft.Azure.Management.AppService.Fluent.IWebAppBase>
    {
    }
}