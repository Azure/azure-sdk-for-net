// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using DeploymentSlot.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using ResourceManager.Fluent.Core;

    /// <summary>
    /// Entry point for Azure web app deployment slot management API.
    /// </summary>
    /// <remarks>
    /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in future releases, including removal, regardless of any compatibility expectations set by the containing library version number.)
    /// </remarks>
    public interface IDeploymentSlots  :
        ISupportsCreating<DeploymentSlot.Definition.IBlank>,
        ISupportsListing<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>,
        ISupportsGettingByName<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>,
        ISupportsDeletingById,
        ISupportsGettingById<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>,
        ISupportsDeletingByName,
        IHasManager<IAppServiceManager>,
        IHasInner<IWebAppsOperations>,
        IHasParent<IWebApp>
    {
    }
}