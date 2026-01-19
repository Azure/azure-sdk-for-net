// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.ServiceFabricManagedClusters.Models;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.ServiceFabricManagedClusters
{
    public partial class ServiceFabricManagedApplicationResource : ArmResource
    {
        /// <summary>
        /// Updates the tags of an application resource of a given managed cluster.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceFabric/managedClusters/{clusterName}/applications/{applicationName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ApplicationResource_Update</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ServiceFabricManagedApplicationResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="patch"> The application resource updated tags. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<ServiceFabricManagedApplicationResource>> UpdateAsync(ServiceFabricManagedApplicationPatch patch, CancellationToken cancellationToken = default)
        {
            var response = await UpdateAsync(WaitUntil.Completed, patch, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(response.Value, null);
        }

        /// <summary>
        /// Updates the tags of an application resource of a given managed cluster.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceFabric/managedClusters/{clusterName}/applications/{applicationName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ApplicationResource_Update</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ServiceFabricManagedApplicationResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="patch"> The application resource updated tags. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ServiceFabricManagedApplicationResource> Update(ServiceFabricManagedApplicationPatch patch, CancellationToken cancellationToken = default)
        {
            return Response.FromValue(Update(WaitUntil.Completed, patch, cancellationToken).Value, null);
        }
    }
}
