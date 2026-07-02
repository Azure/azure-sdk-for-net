// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Avs.Models;

namespace Azure.ResourceManager.Avs
{
    public partial class AvsPrivateCloudClusterResource
    {
        /// <summary>
        /// List hosts by zone in a cluster
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AVS/privateClouds/{privateCloudName}/clusters/{clusterName}/listZones</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Clusters_ListZones</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AvsPrivateCloudClusterResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="AvsClusterZone"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<AvsClusterZone> GetZonesAsync(CancellationToken cancellationToken = default)
        {
            return PageableHelpers.CreateAsyncEnumerable(async _ =>
            {
                using DiagnosticScope scope = _clustersClientDiagnostics.CreateScope("AvsPrivateCloudClusterResource.GetZones");
                scope.Start();
                var response = await GetClusterZonesAsync(cancellationToken).ConfigureAwait(false);
                return Page<AvsClusterZone>.FromValues(response.Value.Zones, continuationToken: null, response.GetRawResponse());
            }, null);
        }

        /// <summary>
        /// List hosts by zone in a cluster
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AVS/privateClouds/{privateCloudName}/clusters/{clusterName}/listZones</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Clusters_ListZones</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AvsPrivateCloudClusterResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="AvsClusterZone"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<AvsClusterZone> GetZones(CancellationToken cancellationToken = default)
        {
            return PageableHelpers.CreateEnumerable(_ =>
            {
                using DiagnosticScope scope = _clustersClientDiagnostics.CreateScope("AvsPrivateCloudClusterResource.GetZones");
                scope.Start();
                var response = GetClusterZones(cancellationToken);
                return Page<AvsClusterZone>.FromValues(response.Value.Zones, continuationToken: null, response.GetRawResponse());
            }, null);
        }
    }
}
