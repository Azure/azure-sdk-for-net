// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.StorageCache.Models;

namespace Azure.ResourceManager.StorageCache
{
    public partial class StorageCacheResource : ArmResource
    {
        /// <summary>
        /// Update a Cache instance.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.StorageCache/caches/{cacheName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Caches_Update</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="data"> Object containing the user-selectable properties of the Cache. If read-only properties are included, they must match the existing values of those properties. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<StorageCacheResource>> UpdateAsync(StorageCacheData data, CancellationToken cancellationToken = default)
        {
            ArmOperation<StorageCacheResource> operation = await this.UpdateAsync(WaitUntil.Completed, data, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(operation.Value, operation.GetRawResponse());
        }

        /// <summary>
        /// Update a Cache instance.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.StorageCache/caches/{cacheName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Caches_Update</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="data"> Object containing the user-selectable properties of the Cache. If read-only properties are included, they must match the existing values of those properties. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<StorageCacheResource> Update(StorageCacheData data, CancellationToken cancellationToken = default)
        {
            ArmOperation<StorageCacheResource> operation = this.Update(WaitUntil.Completed, data, cancellationToken);
            return Response.FromValue(operation.Value, operation.GetRawResponse());
        }

        //Customization for array as body.
        /// <summary>
        /// Update cache space allocation.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.StorageCache/caches/{cacheName}/spaceAllocation</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Caches_SpaceAllocation</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2026-01-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="StorageCacheResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="spaceAllocation"> List containing storage target cache space percentage allocations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> UpdateSpaceAllocationAsync(WaitUntil waitUntil, IEnumerable<StorageTargetSpaceAllocation> spaceAllocation = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _cachesClientDiagnostics.CreateScope("StorageCacheResource.UpdateSpaceAllocation");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _cachesRestClient.CreateUpdateSpaceAllocationRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, CreateSpaceAllocationContent(spaceAllocation), context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                StorageCacheArmOperation operation = new StorageCacheArmOperation(_cachesClientDiagnostics, Pipeline, message.Request, response, OperationFinalStateVia.AzureAsyncOperation);
                if (waitUntil == WaitUntil.Completed)
                {
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Update cache space allocation.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.StorageCache/caches/{cacheName}/spaceAllocation</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Caches_SpaceAllocation</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2026-01-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="StorageCacheResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="spaceAllocation"> List containing storage target cache space percentage allocations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation UpdateSpaceAllocation(WaitUntil waitUntil, IEnumerable<StorageTargetSpaceAllocation> spaceAllocation = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _cachesClientDiagnostics.CreateScope("StorageCacheResource.UpdateSpaceAllocation");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _cachesRestClient.CreateUpdateSpaceAllocationRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, CreateSpaceAllocationContent(spaceAllocation), context);
                Response response = Pipeline.ProcessMessage(message, context);
                StorageCacheArmOperation operation = new StorageCacheArmOperation(_cachesClientDiagnostics, Pipeline, message.Request, response, OperationFinalStateVia.AzureAsyncOperation);
                if (waitUntil == WaitUntil.Completed)
                {
                    operation.WaitForCompletionResponse(cancellationToken);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private static RequestContent CreateSpaceAllocationContent(IEnumerable<StorageTargetSpaceAllocation> spaceAllocation)
        {
            if (spaceAllocation is null)
            {
                return null;
            }
            using MemoryStream stream = new MemoryStream();
            using (Utf8JsonWriter writer = new Utf8JsonWriter(stream))
            {
                writer.WriteStartArray();
                foreach (StorageTargetSpaceAllocation item in spaceAllocation)
                {
                    writer.WriteObjectValue(item, ModelSerializationExtensions.WireOptions);
                }
                writer.WriteEndArray();
            }
            return RequestContent.Create(BinaryData.FromBytes(stream.ToArray()));
        }
    }
}
