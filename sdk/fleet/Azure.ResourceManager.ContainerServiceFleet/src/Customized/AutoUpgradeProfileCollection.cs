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
    public partial class AutoUpgradeProfileCollection
    {
        /// <summary>
        /// Create a AutoUpgradeProfile
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/fleets/{fleetName}/autoUpgradeProfiles/{autoUpgradeProfileName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AutoUpgradeProfiles_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-04-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AutoUpgradeProfileResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="autoUpgradeProfileName"> The name of the AutoUpgradeProfile resource. </param>
        /// <param name="data"> Resource create parameters. </param>
        /// <param name="ifMatch"> The request should only proceed if an entity matches this string. </param>
        /// <param name="ifNoneMatch"> The request should only proceed if no entity matches this string. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="autoUpgradeProfileName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="autoUpgradeProfileName"/> or <paramref name="data"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<AutoUpgradeProfileResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string autoUpgradeProfileName, AutoUpgradeProfileData data, string ifMatch = null, string ifNoneMatch = null, CancellationToken cancellationToken = default)
        {
            return await CreateOrUpdateAsync(waitUntil, autoUpgradeProfileName, data, ETagHelper.ToMatchConditions(ifMatch, ifNoneMatch), cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a AutoUpgradeProfile
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/fleets/{fleetName}/autoUpgradeProfiles/{autoUpgradeProfileName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AutoUpgradeProfiles_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-04-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AutoUpgradeProfileResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="autoUpgradeProfileName"> The name of the AutoUpgradeProfile resource. </param>
        /// <param name="data"> Resource create parameters. </param>
        /// <param name="ifMatch"> The request should only proceed if an entity matches this string. </param>
        /// <param name="ifNoneMatch"> The request should only proceed if no entity matches this string. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="autoUpgradeProfileName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="autoUpgradeProfileName"/> or <paramref name="data"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<AutoUpgradeProfileResource> CreateOrUpdate(WaitUntil waitUntil, string autoUpgradeProfileName, AutoUpgradeProfileData data, string ifMatch = null, string ifNoneMatch = null, CancellationToken cancellationToken = default)
        {
            return CreateOrUpdate(waitUntil, autoUpgradeProfileName, data, ETagHelper.ToMatchConditions(ifMatch, ifNoneMatch), cancellationToken);
        }

        /// <summary>
        /// List AutoUpgradeProfile resources by Fleet
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/fleets/{fleetName}/autoUpgradeProfiles</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AutoUpgradeProfiles_ListByFleet</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-04-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AutoUpgradeProfileResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="AutoUpgradeProfileResource"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<AutoUpgradeProfileResource> GetAllAsync(CancellationToken cancellationToken)
        {
            return GetAllAsync(null, null, cancellationToken);
        }

        /// <summary>
        /// List AutoUpgradeProfile resources by Fleet
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/fleets/{fleetName}/autoUpgradeProfiles</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AutoUpgradeProfiles_ListByFleet</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-04-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AutoUpgradeProfileResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="AutoUpgradeProfileResource"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<AutoUpgradeProfileResource> GetAll(CancellationToken cancellationToken)
        {
            return GetAll(null, null, cancellationToken);
        }
    }
}
