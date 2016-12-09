// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using DeploymentSlot.Update;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;

    /// <summary>
    /// An immutable client-side representation of an Azure Web App deployment slot.
    /// </summary>
    public interface IDeploymentSlot  :
        IIndependentChildResource,
        IWebAppBase<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>,
        IUpdatable<DeploymentSlot.Update.IUpdate>
    {
        Microsoft.Azure.Management.AppService.Fluent.IWebApp Parent { get; }
    }
}