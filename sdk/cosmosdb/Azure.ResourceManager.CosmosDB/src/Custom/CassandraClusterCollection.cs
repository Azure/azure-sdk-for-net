// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Microsoft.TypeSpec.Generator.Customizations;

// The MPG generator's ResourceCollectionClientProvider.InitializeMethods iterates the
// resource methods and, for each ResourceOperationKind.Read it encounters, overwrites
// the previously selected canonical Get operation. ClusterResource.tsp declares
// `get`, `getCommandAsync`, and `getBackup` all as ArmResourceRead<ClusterResource, ...>
// on the same resource, so getBackup wins and the generated CassandraClusterCollection.
// Get/GetAsync/GetIfExists/GetIfExistsAsync/Exists/ExistsAsync are all wired to
// GetBackup. That produces wrong return types and CS1503/CS0029 build errors and also
// breaks MockableCosmosDBResourceGroupResource.GetCassandraCluster(string clusterName)
// which expects the canonical cluster Get. Suppress the broken methods and re-emit the
// canonical Get/Exists/GetIfExists overloads using ClusterResources_Get
// (CreateGetRequest).
//
// Tracking issue: https://github.com/Azure/azure-sdk-for-net/issues/59094

namespace Azure.ResourceManager.CosmosDB
{
    [CodeGenSuppress("Get", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetAsync", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("Exists", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("ExistsAsync", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetIfExists", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetIfExistsAsync", typeof(string), typeof(CancellationToken))]
    public partial class CassandraClusterCollection : IEnumerable<CassandraClusterResource>, IAsyncEnumerable<CassandraClusterResource>
    {
        /// <summary>
        /// Get the properties of a managed Cassandra cluster.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/cassandraClusters/{clusterName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> ClusterResources_Get. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="clusterName"> Managed Cassandra cluster name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<CassandraClusterResource>> GetAsync(string clusterName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(clusterName, nameof(clusterName));

            using DiagnosticScope scope = _cassandraClustersClientDiagnostics.CreateScope("CassandraClusterCollection.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _cassandraClustersRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, clusterName, context);
                await Pipeline.SendAsync(message, context.CancellationToken).ConfigureAwait(false);
                Response result = message.Response;
                Response<CassandraClusterData> response = result.Status switch
                {
                    200 => Response.FromValue(CassandraClusterData.FromResponse(result), result),
                    _ => throw new RequestFailedException(result),
                };
                return Response.FromValue(new CassandraClusterResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get the properties of a managed Cassandra cluster.
        /// </summary>
        /// <param name="clusterName"> Managed Cassandra cluster name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<CassandraClusterResource> Get(string clusterName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(clusterName, nameof(clusterName));

            using DiagnosticScope scope = _cassandraClustersClientDiagnostics.CreateScope("CassandraClusterCollection.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _cassandraClustersRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, clusterName, context);
                Pipeline.Send(message, context.CancellationToken);
                Response result = message.Response;
                Response<CassandraClusterData> response = result.Status switch
                {
                    200 => Response.FromValue(CassandraClusterData.FromResponse(result), result),
                    _ => throw new RequestFailedException(result),
                };
                return Response.FromValue(new CassandraClusterResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// </summary>
        /// <param name="clusterName"> Managed Cassandra cluster name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<bool>> ExistsAsync(string clusterName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(clusterName, nameof(clusterName));

            using DiagnosticScope scope = _cassandraClustersClientDiagnostics.CreateScope("CassandraClusterCollection.Exists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken,
                    ErrorOptions = ErrorOptions.NoThrow,
                };
                HttpMessage message = _cassandraClustersRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, clusterName, context);
                await Pipeline.SendAsync(message, context.CancellationToken).ConfigureAwait(false);
                Response result = message.Response;
                return Response.FromValue(result.Status == 200, result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// </summary>
        /// <param name="clusterName"> Managed Cassandra cluster name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<bool> Exists(string clusterName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(clusterName, nameof(clusterName));

            using DiagnosticScope scope = _cassandraClustersClientDiagnostics.CreateScope("CassandraClusterCollection.Exists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken,
                    ErrorOptions = ErrorOptions.NoThrow,
                };
                HttpMessage message = _cassandraClustersRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, clusterName, context);
                Pipeline.Send(message, context.CancellationToken);
                Response result = message.Response;
                return Response.FromValue(result.Status == 200, result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// </summary>
        /// <param name="clusterName"> Managed Cassandra cluster name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<NullableResponse<CassandraClusterResource>> GetIfExistsAsync(string clusterName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(clusterName, nameof(clusterName));

            using DiagnosticScope scope = _cassandraClustersClientDiagnostics.CreateScope("CassandraClusterCollection.GetIfExists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken,
                    ErrorOptions = ErrorOptions.NoThrow,
                };
                HttpMessage message = _cassandraClustersRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, clusterName, context);
                await Pipeline.SendAsync(message, context.CancellationToken).ConfigureAwait(false);
                Response result = message.Response;
                if (result.Status == 404)
                {
                    return new NoValueResponse<CassandraClusterResource>(result);
                }
                if (result.Status != 200)
                {
                    throw new RequestFailedException(result);
                }
                CassandraClusterData data = CassandraClusterData.FromResponse(result);
                return Response.FromValue(new CassandraClusterResource(Client, data), result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// </summary>
        /// <param name="clusterName"> Managed Cassandra cluster name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual NullableResponse<CassandraClusterResource> GetIfExists(string clusterName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(clusterName, nameof(clusterName));

            using DiagnosticScope scope = _cassandraClustersClientDiagnostics.CreateScope("CassandraClusterCollection.GetIfExists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken,
                    ErrorOptions = ErrorOptions.NoThrow,
                };
                HttpMessage message = _cassandraClustersRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, clusterName, context);
                Pipeline.Send(message, context.CancellationToken);
                Response result = message.Response;
                if (result.Status == 404)
                {
                    return new NoValueResponse<CassandraClusterResource>(result);
                }
                if (result.Status != 200)
                {
                    throw new RequestFailedException(result);
                }
                CassandraClusterData data = CassandraClusterData.FromResponse(result);
                return Response.FromValue(new CassandraClusterResource(Client, data), result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Create or update a managed Cassandra cluster. When updating, you must specify all writable properties.
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="clusterName"> Managed Cassandra cluster name. </param>
        /// <param name="data"> The required parameters for creating or updating a managed Cassandra cluster. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clusterName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="clusterName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<ArmOperation<CassandraClusterResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string clusterName, CassandraClusterData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(clusterName, nameof(clusterName));
            Argument.AssertNotNull(data, nameof(data));

            using DiagnosticScope scope = _cassandraClustersClientDiagnostics.CreateScope("CassandraClusterCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _cassandraClustersRestClient.CreateCreateUpdateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, clusterName, CassandraClusterData.ToRequestContent(data), context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                CosmosDBArmOperation<CassandraClusterResource> operation = new CosmosDBArmOperation<CassandraClusterResource>(
                    new CassandraClusterOperationSource(Client),
                    _cassandraClustersClientDiagnostics,
                    Pipeline,
                    message.Request,
                    response,
                    OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
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
        /// Create or update a managed Cassandra cluster. When updating, you must specify all writable properties.
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="clusterName"> Managed Cassandra cluster name. </param>
        /// <param name="data"> The required parameters for creating or updating a managed Cassandra cluster. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clusterName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="clusterName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual ArmOperation<CassandraClusterResource> CreateOrUpdate(WaitUntil waitUntil, string clusterName, CassandraClusterData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(clusterName, nameof(clusterName));
            Argument.AssertNotNull(data, nameof(data));

            using DiagnosticScope scope = _cassandraClustersClientDiagnostics.CreateScope("CassandraClusterCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _cassandraClustersRestClient.CreateCreateUpdateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, clusterName, CassandraClusterData.ToRequestContent(data), context);
                Response response = Pipeline.ProcessMessage(message, context);
                CosmosDBArmOperation<CassandraClusterResource> operation = new CosmosDBArmOperation<CassandraClusterResource>(
                    new CassandraClusterOperationSource(Client),
                    _cassandraClustersClientDiagnostics,
                    Pipeline,
                    message.Request,
                    response,
                    OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    operation.WaitForCompletion(cancellationToken);
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
        /// List all managed Cassandra clusters in this resource group.
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="CassandraClusterResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<CassandraClusterResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new AsyncPageableWrapper<CassandraClusterData, CassandraClusterResource>(
                new CassandraClustersGetByResourceGroupAsyncCollectionResultOfT(_cassandraClustersRestClient, Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, context, "CassandraClusterCollection.GetAll"),
                data => new CassandraClusterResource(Client, data));
        }

        /// <summary>
        /// List all managed Cassandra clusters in this resource group.
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="CassandraClusterResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<CassandraClusterResource> GetAll(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new PageableWrapper<CassandraClusterData, CassandraClusterResource>(
                new CassandraClustersGetByResourceGroupCollectionResultOfT(_cassandraClustersRestClient, Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, context, "CassandraClusterCollection.GetAll"),
                data => new CassandraClusterResource(Client, data));
        }

        IEnumerator<CassandraClusterResource> IEnumerable<CassandraClusterResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<CassandraClusterResource> IAsyncEnumerable<CassandraClusterResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
