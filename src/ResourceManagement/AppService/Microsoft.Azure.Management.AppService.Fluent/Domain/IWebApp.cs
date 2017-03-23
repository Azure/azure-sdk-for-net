// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using WebApp.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// An immutable client-side representation of an Azure Web App.
    /// </summary>
    public interface IWebApp  :
        IWebAppBase,
        IRefreshable<Microsoft.Azure.Management.AppService.Fluent.IWebApp>,
        IUpdatable<WebApp.Update.IUpdate>
    {
        /// <summary>
        /// Gets the entry point to deployment slot management API under the web app.
        /// </summary>
        Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlots DeploymentSlots { get; }
    }
}