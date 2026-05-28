// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.CosmosDB
{
    // Spec 2025-11-01-preview adds an `x-ms-force-deallocate` header that MPG would surface as a
    // preview-only 3rd parameter on Deallocate, widening the 1.4.0 GA signature. Per PR #57018
    // review feedback, suppress that overload and re-emit the 2-param form (header hard-coded null).
    // See https://github.com/Azure/azure-sdk-for-net/pull/57018#discussion_r3308790636
    [CodeGenSuppress("DeallocateAsync", typeof(WaitUntil), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("Deallocate", typeof(WaitUntil), typeof(string), typeof(CancellationToken))]
    public partial class CassandraClusterResource
    {
        /// <summary>
        /// Deallocate the Managed Cassandra Cluster and Associated Data Centers. Deallocation will deallocate the host virtual machine of this cluster, and reserved the data disk. This won't do anything on an already deallocated cluster. Use Start to restart the cluster.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/cassandraClusters/{clusterName}/deallocate. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> ClusterResources_Deallocate. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="CassandraClusterResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> DeallocateAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _cassandraClustersClientDiagnostics.CreateScope("CassandraClusterResource.Deallocate");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _cassandraClustersRestClient.CreateDeallocateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, null, context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                CosmosDBArmOperation operation = new CosmosDBArmOperation(_cassandraClustersClientDiagnostics, Pipeline, message.Request, response, OperationFinalStateVia.Location);
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
        /// Deallocate the Managed Cassandra Cluster and Associated Data Centers. Deallocation will deallocate the host virtual machine of this cluster, and reserved the data disk. This won't do anything on an already deallocated cluster. Use Start to restart the cluster.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/cassandraClusters/{clusterName}/deallocate. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> ClusterResources_Deallocate. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="CassandraClusterResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Deallocate(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _cassandraClustersClientDiagnostics.CreateScope("CassandraClusterResource.Deallocate");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _cassandraClustersRestClient.CreateDeallocateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, null, context);
                Response response = Pipeline.ProcessMessage(message, context);
                CosmosDBArmOperation operation = new CosmosDBArmOperation(_cassandraClustersClientDiagnostics, Pipeline, message.Request, response, OperationFinalStateVia.Location);
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
    }
}
