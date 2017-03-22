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
    public interface IDeploymentSlot  :
        IIndependentChildResource<IAppServiceManager, SiteInner>,
        IWebAppBase,
        IRefreshable<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>,
        IUpdatable<DeploymentSlot.Update.IUpdate>,
        IHasParent<IWebApp>
    {
    }
}