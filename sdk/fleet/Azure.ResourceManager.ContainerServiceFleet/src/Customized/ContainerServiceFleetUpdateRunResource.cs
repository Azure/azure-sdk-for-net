// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.ContainerServiceFleet.Models;

namespace Azure.ResourceManager.ContainerServiceFleet
{
    // Because of a breaking change, it was manually added back to ensure compatibility.
    public partial class ContainerServiceFleetUpdateRunResource
    {
        /// <summary>
        /// Delete a UpdateRun
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/fleets/{fleetName}/updateRuns/{updateRunName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>UpdateRuns_Delete</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-04-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ContainerServiceFleetUpdateRunResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="ifMatch"> The request should only proceed if an entity matches this string. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, string ifMatch = null, CancellationToken cancellationToken = default)
        {
            return await DeleteAsync(waitUntil, ETagHelper.ToETag(ifMatch), cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Delete a UpdateRun
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/fleets/{fleetName}/updateRuns/{updateRunName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>UpdateRuns_Delete</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-04-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ContainerServiceFleetUpdateRunResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="ifMatch"> The request should only proceed if an entity matches this string. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation Delete(WaitUntil waitUntil, string ifMatch = null, CancellationToken cancellationToken = default)
        {
            return Delete(waitUntil, ETagHelper.ToETag(ifMatch), cancellationToken);
        }

        /// <summary>
        /// Create a UpdateRun
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/fleets/{fleetName}/updateRuns/{updateRunName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>UpdateRuns_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-04-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ContainerServiceFleetUpdateRunResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> Resource create parameters. </param>
        /// <param name="ifMatch"> The request should only proceed if an entity matches this string. </param>
        /// <param name="ifNoneMatch"> The request should only proceed if no entity matches this string. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<ContainerServiceFleetUpdateRunResource>> UpdateAsync(WaitUntil waitUntil, ContainerServiceFleetUpdateRunData data, string ifMatch = null, string ifNoneMatch = null, CancellationToken cancellationToken = default)
        {
            return await UpdateAsync(waitUntil, data, ETagHelper.ToMatchConditions(ifMatch, ifNoneMatch), cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a UpdateRun
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/fleets/{fleetName}/updateRuns/{updateRunName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>UpdateRuns_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-04-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ContainerServiceFleetUpdateRunResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> Resource create parameters. </param>
        /// <param name="ifMatch"> The request should only proceed if an entity matches this string. </param>
        /// <param name="ifNoneMatch"> The request should only proceed if no entity matches this string. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<ContainerServiceFleetUpdateRunResource> Update(WaitUntil waitUntil, ContainerServiceFleetUpdateRunData data, string ifMatch = null, string ifNoneMatch = null, CancellationToken cancellationToken = default)
        {
            return Update(waitUntil, data, ETagHelper.ToMatchConditions(ifMatch, ifNoneMatch), cancellationToken);
        }

        /// <summary>
        /// Skips one or a combination of member/group/stage/afterStageWait(s) of an update run.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/fleets/{fleetName}/updateRuns/{updateRunName}/skip</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>UpdateRuns_Skip</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-04-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ContainerServiceFleetUpdateRunResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="body"> The content of the action request. </param>
        /// <param name="ifMatch"> The request should only proceed if an entity matches this string. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<ContainerServiceFleetUpdateRunResource>> SkipAsync(WaitUntil waitUntil, ContainerServiceFleetSkipProperties body, string ifMatch = null, CancellationToken cancellationToken = default)
        {
            return await SkipAsync(waitUntil, body, ETagHelper.ToETag(ifMatch), cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Skips one or a combination of member/group/stage/afterStageWait(s) of an update run.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/fleets/{fleetName}/updateRuns/{updateRunName}/skip</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>UpdateRuns_Skip</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-04-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ContainerServiceFleetUpdateRunResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="body"> The content of the action request. </param>
        /// <param name="ifMatch"> The request should only proceed if an entity matches this string. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<ContainerServiceFleetUpdateRunResource> Skip(WaitUntil waitUntil, ContainerServiceFleetSkipProperties body, string ifMatch = null, CancellationToken cancellationToken = default)
        {
            return Skip(waitUntil, body, ETagHelper.ToETag(ifMatch), cancellationToken);
        }

        /// <summary>
        /// Starts an UpdateRun.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/fleets/{fleetName}/updateRuns/{updateRunName}/start</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>UpdateRuns_Start</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-04-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ContainerServiceFleetUpdateRunResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="ifMatch"> The request should only proceed if an entity matches this string. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<ContainerServiceFleetUpdateRunResource>> StartAsync(WaitUntil waitUntil, string ifMatch = null, CancellationToken cancellationToken = default)
        {
            return await StartAsync(waitUntil, ETagHelper.ToETag(ifMatch), cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Starts an UpdateRun.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/fleets/{fleetName}/updateRuns/{updateRunName}/start</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>UpdateRuns_Start</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-04-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ContainerServiceFleetUpdateRunResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="ifMatch"> The request should only proceed if an entity matches this string. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<ContainerServiceFleetUpdateRunResource> Start(WaitUntil waitUntil, string ifMatch = null, CancellationToken cancellationToken = default)
        {
            return Start(waitUntil, ETagHelper.ToETag(ifMatch), cancellationToken);
        }

        /// <summary>
        /// Stops an UpdateRun.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/fleets/{fleetName}/updateRuns/{updateRunName}/stop</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>UpdateRuns_Stop</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-04-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ContainerServiceFleetUpdateRunResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="ifMatch"> The request should only proceed if an entity matches this string. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<ContainerServiceFleetUpdateRunResource>> StopAsync(WaitUntil waitUntil, string ifMatch = null, CancellationToken cancellationToken = default)
        {
            return await StopAsync(waitUntil, ETagHelper.ToETag(ifMatch), cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Stops an UpdateRun.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/fleets/{fleetName}/updateRuns/{updateRunName}/stop</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>UpdateRuns_Stop</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-04-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ContainerServiceFleetUpdateRunResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="ifMatch"> The request should only proceed if an entity matches this string. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<ContainerServiceFleetUpdateRunResource> Stop(WaitUntil waitUntil, string ifMatch = null, CancellationToken cancellationToken = default)
        {
            return Stop(waitUntil, ETagHelper.ToETag(ifMatch), cancellationToken);
        }
    }
}
