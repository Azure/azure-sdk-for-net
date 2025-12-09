// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.ContainerRegistry.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.ContainerRegistry
{
    /// <summary>
    /// A Class representing a ContainerRegistry along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier"/> you can construct a <see cref="ContainerRegistryResource"/>
    /// from an instance of <see cref="ArmClient"/> using the GetContainerRegistryResource method.
    /// Otherwise you can get one from its parent resource <see cref="ResourceGroupResource"/> using the GetContainerRegistry method.
    /// </summary>
    public partial class ContainerRegistryResource : ArmResource
    {
        /// <summary>
        /// Schedules a new run based on the request parameters and add it to the run queue.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/scheduleRun</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Schedules_ScheduleRun</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2019-06-01-preview</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The parameters of a run that needs to scheduled. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated, use `Task<Response<ContainerRegistryRunResource>> ScheduleRunAsync(ContainerRegistryRunContent content, CancellationToken cancellationToken = default)` instead")]
        public virtual Task<ArmOperation<ContainerRegistryRunResource>> ScheduleRunAsync(WaitUntil waitUntil, ContainerRegistryRunContent content, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is no longer supported. Please use `Task<Response<ContainerRegistryRunResource>> ScheduleRunAsync(ContainerRegistryRunContent content, CancellationToken cancellationToken = default)` instead.");
        }

        /// <summary>
        /// Schedules a new run based on the request parameters and add it to the run queue.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/scheduleRun</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Schedules_ScheduleRun</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2019-06-01-preview</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The parameters of a run that needs to scheduled. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated, use `Response<ContainerRegistryRunResource> ScheduleRun(ContainerRegistryRunContent content, CancellationToken cancellationToken = default)` instead")]
        public virtual ArmOperation<ContainerRegistryRunResource> ScheduleRun(WaitUntil waitUntil, ContainerRegistryRunContent content, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is no longer supported. Please use `Response<ContainerRegistryRunResource> ScheduleRun(ContainerRegistryRunContent content, CancellationToken cancellationToken = default)` instead.");
        }
    }
}
