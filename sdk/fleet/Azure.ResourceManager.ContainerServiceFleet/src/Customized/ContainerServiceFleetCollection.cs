// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.ContainerServiceFleet
{
    // Because of a breaking change, it was manually added back to ensure compatibility.
    public partial class ContainerServiceFleetCollection
    {
        /// <summary>
        /// Creates or updates a Fleet.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/fleets/{fleetName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Fleets_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-04-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ContainerServiceFleetResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="fleetName"> The name of the Fleet resource. </param>
        /// <param name="data"> Resource create parameters. </param>
        /// <param name="ifMatch"> The request should only proceed if an entity matches this string. </param>
        /// <param name="ifNoneMatch"> The request should only proceed if no entity matches this string. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fleetName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fleetName"/> or <paramref name="data"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<ContainerServiceFleetResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string fleetName, ContainerServiceFleetData data, string ifMatch = null, string ifNoneMatch = null, CancellationToken cancellationToken = default)
        {
            return await CreateOrUpdateAsync(waitUntil, fleetName, data, ETagHelper.ToMatchConditions(ifMatch, ifNoneMatch), cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Creates or updates a Fleet.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/fleets/{fleetName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Fleets_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-04-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ContainerServiceFleetResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="fleetName"> The name of the Fleet resource. </param>
        /// <param name="data"> Resource create parameters. </param>
        /// <param name="ifMatch"> The request should only proceed if an entity matches this string. </param>
        /// <param name="ifNoneMatch"> The request should only proceed if no entity matches this string. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fleetName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fleetName"/> or <paramref name="data"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<ContainerServiceFleetResource> CreateOrUpdate(WaitUntil waitUntil, string fleetName, ContainerServiceFleetData data, string ifMatch = null, string ifNoneMatch = null, CancellationToken cancellationToken = default)
        {
            return CreateOrUpdate(waitUntil, fleetName, data, ETagHelper.ToMatchConditions(ifMatch, ifNoneMatch), cancellationToken);
        }
    }
}
