// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.ContainerRegistry.Models;

namespace Azure.ResourceManager.ContainerRegistry
{
    /// <summary>
    /// A Class representing a ContainerRegistryTask along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier"/> you can construct a <see cref="ContainerRegistryTaskResource"/>
    /// from an instance of <see cref="ArmClient"/> using the GetContainerRegistryTaskResource method.
    /// Otherwise you can get one from its parent resource <see cref="ContainerRegistryResource"/> using the GetContainerRegistryTask method.
    /// </summary>
    public partial class ContainerRegistryTaskResource : ArmResource
    {
        /// <summary>
        /// Updates a task with the specified parameters.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/tasks/{taskName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Tasks_Update</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2019-06-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ContainerRegistryTaskResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="patch"> The parameters for updating a task. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated, use `Task<Response<ContainerRegistryTaskResource>> UpdateAsync(ContainerRegistryTaskPatch patch, CancellationToken cancellationToken = default)` instead")]
        public virtual Task<ArmOperation<ContainerRegistryTaskResource>> UpdateAsync(WaitUntil waitUntil, ContainerRegistryTaskPatch patch, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is no longer supported. Please use `Task<Response<ContainerRegistryTaskResource>> UpdateAsync(ContainerRegistryTaskPatch patch, CancellationToken cancellationToken = default)` instead.");
        }

        /// <summary>
        /// Updates a task with the specified parameters.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/tasks/{taskName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Tasks_Update</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2019-06-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ContainerRegistryTaskResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="patch"> The parameters for updating a task. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated, use `Response<ContainerRegistryTaskResource> Update(ContainerRegistryTaskPatch patch, CancellationToken cancellationToken = default)` instead")]
        public virtual ArmOperation<ContainerRegistryTaskResource> Update(WaitUntil waitUntil, ContainerRegistryTaskPatch patch, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is no longer supported. Please use `Response<ContainerRegistryTaskResource> Update(ContainerRegistryTaskPatch patch, CancellationToken cancellationToken = default)` instead.");
        }
    }
}
