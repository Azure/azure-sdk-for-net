// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using DeploymentSlot.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;

    /// <summary>
    /// Entry point for storage accounts management API.
    /// </summary>
    public interface IDeploymentSlots  :
        ISupportsCreating<DeploymentSlot.Definition.IBlank>,
        ISupportsListing<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>,
        ISupportsGettingByName<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>,
        ISupportsDeletingById,
        ISupportsGettingById<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>,
        ISupportsDeletingByName
    {
    }
}