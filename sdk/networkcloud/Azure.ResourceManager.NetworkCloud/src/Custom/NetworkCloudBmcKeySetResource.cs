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
    public partial class NetworkCloudBmcKeySetResource
    {
        /// <summary>
        /// Patch properties of baseboard management controller key set for the provided cluster, or update the tags associated with it. Properties and tag updates can be done independently.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/clusters/{clusterName}/bmcKeySets/{bmcKeySetName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BmcKeySets_Update</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudBmcKeySetResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="patch"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        public virtual async Task<ArmOperation<NetworkCloudBmcKeySetResource>> UpdateAsync(WaitUntil waitUntil, NetworkCloudBmcKeySetPatch patch, CancellationToken cancellationToken)
            => await UpdateAsync(waitUntil, patch, null, null, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Patch properties of baseboard management controller key set for the provided cluster, or update the tags associated with it. Properties and tag updates can be done independently.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/clusters/{clusterName}/bmcKeySets/{bmcKeySetName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BmcKeySets_Update</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudBmcKeySetResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="patch"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        public virtual ArmOperation<NetworkCloudBmcKeySetResource> Update(WaitUntil waitUntil, NetworkCloudBmcKeySetPatch patch, CancellationToken cancellationToken)
            => Update(waitUntil, patch, null, null, cancellationToken);

        /// <summary>
        /// Delete the baseboard management controller key set of the provided cluster.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/clusters/{clusterName}/bmcKeySets/{bmcKeySetName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BmcKeySets_Delete</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudBmcKeySetResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation<NetworkCloudOperationStatusResult>> DeleteWithResponseAsync(WaitUntil waitUntil, CancellationToken cancellationToken)
            => await DeleteAsync(waitUntil, null, null, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Delete the baseboard management controller key set of the provided cluster.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/clusters/{clusterName}/bmcKeySets/{bmcKeySetName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BmcKeySets_Delete</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudBmcKeySetResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation<NetworkCloudOperationStatusResult> DeleteWithResponse(WaitUntil waitUntil, CancellationToken cancellationToken)
            => Delete(waitUntil, null, null, cancellationToken);

        /// <summary>
        /// Delete the baseboard management controller key set of the provided cluster.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/clusters/{clusterName}/bmcKeySets/{bmcKeySetName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BmcKeySets_Delete</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudBmcKeySetResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken)
        {
            using var scope = _networkCloudBmcKeySetBmcKeySetsClientDiagnostics.CreateScope("NetworkCloudBmcKeySetResource.Delete");
            scope.Start();
            try
            {
                var response = await _networkCloudBmcKeySetBmcKeySetsRestClient.DeleteAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, null, null, cancellationToken).ConfigureAwait(false);
                var operation = new CustomNetworkCloudArmOperation(_networkCloudBmcKeySetBmcKeySetsClientDiagnostics, Pipeline, _networkCloudBmcKeySetBmcKeySetsRestClient.CreateDeleteRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, null, null).Request, response, OperationFinalStateVia.Location);
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
        /// Delete the baseboard management controller key set of the provided cluster.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/clusters/{clusterName}/bmcKeySets/{bmcKeySetName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BmcKeySets_Delete</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudBmcKeySetResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken)
        {
            using var scope = _networkCloudBmcKeySetBmcKeySetsClientDiagnostics.CreateScope("NetworkCloudBmcKeySetResource.Delete");
            scope.Start();
            try
            {
                var response = _networkCloudBmcKeySetBmcKeySetsRestClient.Delete(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, null, null, cancellationToken);
                var operation = new CustomNetworkCloudArmOperation(_networkCloudBmcKeySetBmcKeySetsClientDiagnostics, Pipeline, _networkCloudBmcKeySetBmcKeySetsRestClient.CreateDeleteRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, null, null).Request, response, OperationFinalStateVia.Location);
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
