// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent.ContainerService.Update
{
    using Microsoft.Azure.Management.Compute.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// The stage of the container service definition allowing to specific diagnostic settings.
    /// </summary>
    public interface IWithUpdateAgentPoolCount 
    {
        /// <summary>
        /// Enables diagnostics.
        /// </summary>
        /// <param name="agentCount">
        /// The number of agents (VMs) to host docker containers.
        /// Allowed values must be in the range of 1 to 100 (inclusive).
        /// The default value is 1.
        /// </param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.ContainerService.Update.IUpdate WithAgentVMCount(int agentCount);
    }

    /// <summary>
    /// The template for an update operation, containing all the settings that
    /// can be modified.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update.IUpdateWithTags<Microsoft.Azure.Management.Compute.Fluent.ContainerService.Update.IUpdate>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.Compute.Fluent.IContainerService>,
        Microsoft.Azure.Management.Compute.Fluent.ContainerService.Update.IWithUpdateAgentPoolCount,
        Microsoft.Azure.Management.Compute.Fluent.ContainerService.Update.IWithDiagnostics
    {
    }

    /// <summary>
    /// The stage of the container service definition allowing to specific diagnostic settings.
    /// </summary>
    public interface IWithDiagnostics 
    {
        /// <summary>
        /// Disables diagnostics.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.ContainerService.Update.IUpdate WithoutDiagnostics();

        /// <summary>
        /// Enables diagnostics.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.ContainerService.Update.IUpdate WithDiagnostics();
    }
}