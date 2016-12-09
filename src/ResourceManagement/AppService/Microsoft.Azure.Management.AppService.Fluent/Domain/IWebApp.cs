// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using WebApp.Update;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;

    /// <summary>
    /// An immutable client-side representation of an Azure Web App.
    /// </summary>
    public interface IWebApp  :
        IWebAppBase<Microsoft.Azure.Management.AppService.Fluent.IWebApp>,
        IUpdatable<WebApp.Update.IUpdate>
    {
        Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlots DeploymentSlots { get; }
    }
}