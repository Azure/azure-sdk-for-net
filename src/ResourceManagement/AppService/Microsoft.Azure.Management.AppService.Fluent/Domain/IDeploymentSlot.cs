// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using DeploymentSlot.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Models;

    /// <summary>
    /// An immutable client-side representation of an Azure Web App deployment slot.
    /// </summary>
    /// <remarks>
    /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in future releases, including removal, regardless of any compatibility expectations set by the containing library version number.)
    /// </remarks>
    public interface IDeploymentSlot  :
        IIndependentChildResource<IAppServiceManager, SiteInner>,
        IWebAppBase,
        IRefreshable<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>,
        IUpdatable<DeploymentSlot.Update.IUpdate>,
        IHasParent<IWebApp>
    {
    }
}