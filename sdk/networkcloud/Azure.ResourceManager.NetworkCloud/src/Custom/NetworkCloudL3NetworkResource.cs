// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.NetworkCloud.Models;

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
        public virtual async Task<Response<NetworkCloudL3NetworkResource>> UpdateAsync(NetworkCloudL3NetworkPatch patch, CancellationToken cancellationToken)
            => await UpdateAsync(patch, null, null, cancellationToken).ConfigureAwait(false);

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
        public virtual Response<NetworkCloudL3NetworkResource> Update(NetworkCloudL3NetworkPatch patch, CancellationToken cancellationToken)
            => Update(patch, null, null, cancellationToken);

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
        public virtual async Task<ArmOperation<NetworkCloudOperationStatusResult>> DeleteWithResponseAsync(WaitUntil waitUntil, CancellationToken cancellationToken)
            => await DeleteAsync(waitUntil, null, null, cancellationToken).ConfigureAwait(false);

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
        public virtual ArmOperation<NetworkCloudOperationStatusResult> DeleteWithResponse(WaitUntil waitUntil, CancellationToken cancellationToken)
            => Delete(waitUntil, null, null, cancellationToken);

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
            using var scope = _networkCloudL3NetworkL3NetworksClientDiagnostics.CreateScope("NetworkCloudL3NetworkResource.Delete");
            scope.Start();
            try
            {
                var response = await _networkCloudL3NetworkL3NetworksRestClient.DeleteAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, null, null, cancellationToken).ConfigureAwait(false);
                var operation = new CustomNetworkCloudArmOperation(_networkCloudL3NetworkL3NetworksClientDiagnostics, Pipeline, _networkCloudL3NetworkL3NetworksRestClient.CreateDeleteRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, null, null).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
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
            using var scope = _networkCloudL3NetworkL3NetworksClientDiagnostics.CreateScope("NetworkCloudL3NetworkResource.Delete");
            scope.Start();
            try
            {
                var response = _networkCloudL3NetworkL3NetworksRestClient.Delete(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, null, null, cancellationToken);
                var operation = new CustomNetworkCloudArmOperation(_networkCloudL3NetworkL3NetworksClientDiagnostics, Pipeline, _networkCloudL3NetworkL3NetworksRestClient.CreateDeleteRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, null, null).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletionResponse(cancellationToken);
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
