// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.Elastic.Models;

namespace Azure.ResourceManager.Elastic
{
    // Added these methods due to the patch operation changed to LRO in api version 2025-06-01
    public partial class ElasticMonitorResource
    {
        /// <summary>
        /// Update a monitor resource.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Elastic/monitors/{monitorName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Monitors_Update</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-03-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ElasticMonitorResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="patch"> Elastic resource model update parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<ElasticMonitorResource>> UpdateAsync(ElasticMonitorPatch patch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(patch, nameof(patch));
            var response = await UpdateAsync(WaitUntil.Completed, patch, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new ElasticMonitorResource(Client, response.Value.Data), response.GetRawResponse());
        }

        /// <summary>
        /// Update a monitor resource.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Elastic/monitors/{monitorName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Monitors_Update</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-03-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ElasticMonitorResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="patch"> Elastic resource model update parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ElasticMonitorResource> Update(ElasticMonitorPatch patch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(patch, nameof(patch));
            var response = Update(WaitUntil.Completed, patch, cancellationToken);
            return Response.FromValue(new ElasticMonitorResource(Client, response.Value.Data), response.GetRawResponse());
        }
    }
}
