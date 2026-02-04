// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.ResourceManager.ServiceFabricManagedClusters.Models;
using System.Threading.Tasks;
using System.Threading;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.ServiceFabricManagedClusters
{
    public partial class ServiceFabricManagedNodeTypeResource
    {
        /// <summary>
        /// Update the configuration of a node type of a given managed cluster, only updating tags.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceFabric/managedClusters/{clusterName}/nodeTypes/{nodeTypeName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NodeTypes_Update</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ServiceFabricManagedNodeTypeResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="patch"> The parameters to update the node type configuration. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ServiceFabricManagedNodeTypeResource> Update(ServiceFabricManagedNodeTypePatch patch, CancellationToken cancellationToken = default)
        {
            var operation = Update(WaitUntil.Completed, patch, cancellationToken);
            return Response.FromValue(operation.Value, operation.GetRawResponse());
        }

        /// <summary>
        /// Update the configuration of a node type of a given managed cluster, only updating tags.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceFabric/managedClusters/{clusterName}/nodeTypes/{nodeTypeName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NodeTypes_Update</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ServiceFabricManagedNodeTypeResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="patch"> The parameters to update the node type configuration. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<ServiceFabricManagedNodeTypeResource>> UpdateAsync(ServiceFabricManagedNodeTypePatch patch, CancellationToken cancellationToken = default)
        {
            var operation = await UpdateAsync(WaitUntil.Completed, patch, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(operation.Value, operation.GetRawResponse());
        }
    }
}
