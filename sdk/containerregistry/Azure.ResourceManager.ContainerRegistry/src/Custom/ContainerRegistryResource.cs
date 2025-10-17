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
    // The `ScheduleRun` operation is no longer LRO, add these method back for compatibility reason.
    public partial class ContainerRegistryResource
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
        public virtual async Task<ArmOperation<ContainerRegistryRunResource>> ScheduleRunAsync(WaitUntil waitUntil, ContainerRegistryRunContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = _schedulesClientDiagnostics.CreateScope("ContainerRegistryResource.ScheduleRun");
            scope.Start();
            try
            {
                var response = await _schedulesRestClient.ScheduleRunAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, content, cancellationToken).ConfigureAwait(false);
                var operation = new ContainerRegistryArmOperation<ContainerRegistryRunResource>(Response.FromValue(new ContainerRegistryRunResource(Client, response), response.GetRawResponse()));
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
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
        public virtual ArmOperation<ContainerRegistryRunResource> ScheduleRun(WaitUntil waitUntil, ContainerRegistryRunContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = _schedulesClientDiagnostics.CreateScope("ContainerRegistryResource.ScheduleRun");
            scope.Start();
            try
            {
                var response = _schedulesRestClient.ScheduleRun(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, content, cancellationToken);
                var operation = new ContainerRegistryArmOperation<ContainerRegistryRunResource>(Response.FromValue(new ContainerRegistryRunResource(Client, response), response.GetRawResponse()));
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
