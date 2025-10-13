// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Elastic.Models;

namespace Azure.ResourceManager.Elastic
{
    /// <summary>
    /// A Class representing an ElasticMonitorResource along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier"/> you can construct an ElasticMonitorResource
    /// from an instance of <see cref="ArmClient"/> using the GetElasticMonitorResource method.
    /// Otherwise you can get one from its parent resource using the GetElasticMonitorResource method.
    /// </summary>
    public partial class ElasticMonitorResource
    {
        /// <summary>
        /// Update the resource
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Elastic/monitors/{monitorName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Monitors_Update</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="patch"> The resource properties to be updated. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        public virtual Response<ElasticMonitorResource> Update(ElasticMonitorPatch patch, CancellationToken cancellationToken = default)
        {
            // Call the existing Update method with WaitUntil.Completed and extract the Value
            var operation = Update(patch, cancellationToken);
            return Response.FromValue(operation.Value, operation.GetRawResponse());
        }

        /// <summary>
        /// Update the resource
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Elastic/monitors/{monitorName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Monitors_Update</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="patch"> The resource properties to be updated. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        public virtual async Task<Response<ElasticMonitorResource>> UpdateAsync(ElasticMonitorPatch patch, CancellationToken cancellationToken = default)
        {
            // Call the existing UpdateAsync method with WaitUntil.Completed and extract the Value
            var operation = await UpdateAsync(patch, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(operation.Value, operation.GetRawResponse());
        }
    }
}