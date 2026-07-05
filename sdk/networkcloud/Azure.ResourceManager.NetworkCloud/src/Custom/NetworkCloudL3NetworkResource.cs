// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.NetworkCloud.Models;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.NetworkCloud
{
    public partial class NetworkCloudL3NetworkResource
    {
        /// <summary>
        /// Update tags associated with the provided layer 3 (L3) network.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/l3Networks/{l3NetworkName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>L3Networks_Update</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudL3NetworkResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="patch"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<NetworkCloudL3NetworkResource>> UpdateAsync(NetworkCloudL3NetworkPatch patch, CancellationToken cancellationToken)
            => await UpdateAsync(patch, null, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Update tags associated with the provided layer 3 (L3) network.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/l3Networks/{l3NetworkName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>L3Networks_Update</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudL3NetworkResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="patch"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<NetworkCloudL3NetworkResource> Update(NetworkCloudL3NetworkPatch patch, CancellationToken cancellationToken)
            => Update(patch, null, cancellationToken);

        /// <summary>
        /// Delete the provided layer 3 (L3) network.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/l3Networks/{l3NetworkName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>L3Networks_Delete</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudL3NetworkResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<NetworkCloudOperationStatusResult>> DeleteWithResponseAsync(WaitUntil waitUntil, CancellationToken cancellationToken)
            => await DeleteAsync(waitUntil, null, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Delete the provided layer 3 (L3) network.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/l3Networks/{l3NetworkName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>L3Networks_Delete</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudL3NetworkResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<NetworkCloudOperationStatusResult> DeleteWithResponse(WaitUntil waitUntil, CancellationToken cancellationToken)
            => Delete(waitUntil, null, cancellationToken);

        /// <summary>
        /// Delete the provided layer 3 (L3) network.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/l3Networks/{l3NetworkName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>L3Networks_Delete</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudL3NetworkResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken)
        {
            var operation = await DeleteAsync(waitUntil, null, cancellationToken).ConfigureAwait(false);
            return new CustomNetworkCloudArmOperationWrapper<NetworkCloudOperationStatusResult>(operation);
        }

        /// <summary>
        /// Delete the provided layer 3 (L3) network.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/l3Networks/{l3NetworkName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>L3Networks_Delete</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudL3NetworkResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken)
        {
            var operation = Delete(waitUntil, null, cancellationToken);
            return new CustomNetworkCloudArmOperationWrapper<NetworkCloudOperationStatusResult>(operation);
        }

        /// <summary>
        /// Update tags associated with the provided layer 3 (L3) network.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/l3Networks/{l3NetworkName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>L3Networks_Update</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudL3NetworkResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="patch"> The request body. </param>
        /// <param name="ifMatch"> The ETag of the transformation. Omit this value to always overwrite the current resource. Specify the last-seen ETag value to prevent accidentally overwriting concurrent changes. </param>
        /// <param name="ifNoneMatch"> Set to '*' to allow a new record set to be created, but to prevent updating an existing resource. Other values will result in error from server as they are not supported. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<NetworkCloudL3NetworkResource> Update(NetworkCloudL3NetworkPatch patch, string ifMatch = null, string ifNoneMatch = null, CancellationToken cancellationToken = default)
            => Update(patch, new MatchConditions { IfMatch = ifMatch != null ? new Azure.ETag(ifMatch) : default(Azure.ETag?), IfNoneMatch = ifNoneMatch != null ? new Azure.ETag(ifNoneMatch) : default(Azure.ETag?) }, cancellationToken);

        /// <summary>
        /// Update tags associated with the provided layer 3 (L3) network.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/l3Networks/{l3NetworkName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>L3Networks_Update</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudL3NetworkResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="patch"> The request body. </param>
        /// <param name="ifMatch"> The ETag of the transformation. Omit this value to always overwrite the current resource. Specify the last-seen ETag value to prevent accidentally overwriting concurrent changes. </param>
        /// <param name="ifNoneMatch"> Set to '*' to allow a new record set to be created, but to prevent updating an existing resource. Other values will result in error from server as they are not supported. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<NetworkCloudL3NetworkResource>> UpdateAsync(NetworkCloudL3NetworkPatch patch, string ifMatch = null, string ifNoneMatch = null, CancellationToken cancellationToken = default)
            => await UpdateAsync(patch, new MatchConditions { IfMatch = ifMatch != null ? new Azure.ETag(ifMatch) : default(Azure.ETag?), IfNoneMatch = ifNoneMatch != null ? new Azure.ETag(ifNoneMatch) : default(Azure.ETag?) }, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Delete the provided layer 3 (L3) network.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/l3Networks/{l3NetworkName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>L3Networks_Delete</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudL3NetworkResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="ifMatch"> The ETag of the transformation. Omit this value to always overwrite the current resource. Specify the last-seen ETag value to prevent accidentally overwriting concurrent changes. </param>
        /// <param name="ifNoneMatch"> Set to '*' to allow a new record set to be created, but to prevent updating an existing resource. Other values will result in error from server as they are not supported. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<NetworkCloudOperationStatusResult> Delete(WaitUntil waitUntil, string ifMatch = null, string ifNoneMatch = null, CancellationToken cancellationToken = default)
            => Delete(waitUntil, new MatchConditions { IfMatch = ifMatch != null ? new Azure.ETag(ifMatch) : default(Azure.ETag?), IfNoneMatch = ifNoneMatch != null ? new Azure.ETag(ifNoneMatch) : default(Azure.ETag?) }, cancellationToken);

        /// <summary>
        /// Delete the provided layer 3 (L3) network.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/l3Networks/{l3NetworkName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>L3Networks_Delete</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudL3NetworkResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="ifMatch"> The ETag of the transformation. Omit this value to always overwrite the current resource. Specify the last-seen ETag value to prevent accidentally overwriting concurrent changes. </param>
        /// <param name="ifNoneMatch"> Set to '*' to allow a new record set to be created, but to prevent updating an existing resource. Other values will result in error from server as they are not supported. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<NetworkCloudOperationStatusResult>> DeleteAsync(WaitUntil waitUntil, string ifMatch = null, string ifNoneMatch = null, CancellationToken cancellationToken = default)
            => await DeleteAsync(waitUntil, new MatchConditions { IfMatch = ifMatch != null ? new Azure.ETag(ifMatch) : default(Azure.ETag?), IfNoneMatch = ifNoneMatch != null ? new Azure.ETag(ifNoneMatch) : default(Azure.ETag?) }, cancellationToken).ConfigureAwait(false);
    }
}
