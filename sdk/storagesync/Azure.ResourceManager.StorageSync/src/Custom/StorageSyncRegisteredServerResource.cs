// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.StorageSync.Models;

namespace Azure.ResourceManager.StorageSync
{
    /// <summary>
    /// A Class representing a StorageSyncRegisteredServer along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="StorageSyncRegisteredServerResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetStorageSyncRegisteredServerResource method.
    /// Otherwise you can get one from its parent resource <see cref="StorageSyncServiceResource" /> using the GetStorageSyncRegisteredServer method.
    /// </summary>
    public partial class StorageSyncRegisteredServerResource : ArmResource
    {
        /// <summary>
        /// Add a new registered server.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.StorageSync/storageSyncServices/{storageSyncServiceName}/registeredServers/{serverId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RegisteredServers_Create</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2022-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="StorageSyncRegisteredServerResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> Body of Registered Server object. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method no longer works in all API versions. Please use the different UpdateAsync instead.", false)]
        public virtual async Task<ArmOperation<StorageSyncRegisteredServerResource>> UpdateAsync(WaitUntil waitUntil, StorageSyncRegisteredServerCreateOrUpdateContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = _storageSyncRegisteredServerRegisteredServersClientDiagnostics.CreateScope("StorageSyncRegisteredServerResource.Update");
            scope.Start();
            try
            {
                var response = await _storageSyncRegisteredServerRegisteredServersRestClient.CreateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Guid.Parse(Id.Name), content, cancellationToken).ConfigureAwait(false);
                var operation = new StorageSyncArmOperation<StorageSyncRegisteredServerResource>(new StorageSyncRegisteredServerOperationSource(Client), _storageSyncRegisteredServerRegisteredServersClientDiagnostics, Pipeline, _storageSyncRegisteredServerRegisteredServersRestClient.CreateCreateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Guid.Parse(Id.Name), content).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Add a new registered server.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.StorageSync/storageSyncServices/{storageSyncServiceName}/registeredServers/{serverId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RegisteredServers_Create</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2022-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="StorageSyncRegisteredServerResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> Body of Registered Server object. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method no longer works in all API versions. Please use the different Update instead.", false)]
        public virtual ArmOperation<StorageSyncRegisteredServerResource> Update(WaitUntil waitUntil, StorageSyncRegisteredServerCreateOrUpdateContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = _storageSyncRegisteredServerRegisteredServersClientDiagnostics.CreateScope("StorageSyncRegisteredServerResource.Update");
            scope.Start();
            try
            {
                var response = _storageSyncRegisteredServerRegisteredServersRestClient.Create(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Guid.Parse(Id.Name), content, cancellationToken);
                var operation = new StorageSyncArmOperation<StorageSyncRegisteredServerResource>(new StorageSyncRegisteredServerOperationSource(Client), _storageSyncRegisteredServerRegisteredServersClientDiagnostics, Pipeline, _storageSyncRegisteredServerRegisteredServersRestClient.CreateCreateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Guid.Parse(Id.Name), content).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletion(cancellationToken);
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
