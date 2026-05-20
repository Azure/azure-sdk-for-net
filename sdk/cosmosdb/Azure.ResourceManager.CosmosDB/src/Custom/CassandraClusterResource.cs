// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Workaround for MPG generator bug tracked at:
// https://github.com/Azure/azure-sdk-for-net/issues/59094
//
// The TypeSpec ClusterResource has multiple ArmResourceRead<ClusterResource> operations
// (get, getBackup, getCommandAsync). The MPG generator's ResourceClientProvider picks
// the last Read operation (getBackup) as the canonical read, which causes:
//   - ResourceType set to "Microsoft.DocumentDB/cassandraClusters/backups" (should be "cassandraClusters")
//   - 4-arg CreateResourceIdentifier generated instead of the correct 3-arg version
//   - Get/GetAsync wired to the backup endpoint returning the wrong data
//   - 13 cluster-self methods dropped: Update/Delete/Deallocate/Start/Status/InvokeCommand
//     and AddTag/RemoveTag/SetTags/GetCassandraDataCenter(s)
//
// This file replaces the broken src/Generated/CassandraClusterResource.cs entirely.
// The [assembly: CodeGenSuppressType] attribute below prevents the generator from
// re-creating the broken file on the next generation pass.

#nullable disable

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.CosmosDB.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.CosmosDB
{
    /// <summary>
    /// A class representing a CassandraCluster along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier"/> you can construct a <see cref="CassandraClusterResource"/>
    /// from an instance of <see cref="ArmClient"/> using the GetResource method.
    /// Otherwise you can get one from its parent resource <see cref="ResourceGroupResource"/> using the
    /// GetCassandraClusters method.
    /// </summary>
    /// <remarks>
    /// This is a custom implementation that works around the MPG generator bug described at
    /// https://github.com/Azure/azure-sdk-for-net/issues/59094
    /// </remarks>
    public partial class CassandraClusterResource : ArmResource, System.ClientModel.Primitives.IJsonModel<CassandraClusterData>, System.ClientModel.Primitives.IPersistableModel<CassandraClusterData>
    {
        private readonly ClientDiagnostics _cassandraClustersClientDiagnostics;
        private readonly CassandraClusters _cassandraClustersRestClient;
        private readonly CassandraClusterData _data;

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.DocumentDB/cassandraClusters";

        /// <summary> Initializes a new instance of CassandraClusterResource for mocking. </summary>
        protected CassandraClusterResource()
        {
        }

        /// <summary> Initializes a new instance of <see cref="CassandraClusterResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal CassandraClusterResource(ArmClient client, CassandraClusterData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of <see cref="CassandraClusterResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal CassandraClusterResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            TryGetApiVersion(ResourceType, out string cassandraClusterApiVersion);
            _cassandraClustersClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.CosmosDB", ResourceType.Namespace, Diagnostics);
            _cassandraClustersRestClient = new CassandraClusters(_cassandraClustersClientDiagnostics, Pipeline, Endpoint, cassandraClusterApiVersion ?? "2025-11-01-preview");
            ValidateResourceId(id);
        }

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        public virtual CassandraClusterData Data
        {
            get
            {
                if (!HasData)
                {
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                }
                return _data;
            }
        }

        /// <summary> Generate the resource identifier for this resource. </summary>
        /// <param name="subscriptionId"> The subscriptionId. </param>
        /// <param name="resourceGroupName"> The resourceGroupName. </param>
        /// <param name="clusterName"> The clusterName. </param>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName)
        {
            string resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/cassandraClusters/{clusterName}";
            return new ResourceIdentifier(resourceId);
        }

        /// <param name="id"></param>
        [Conditional("DEBUG")]
        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
            {
                throw new ArgumentException(string.Format("Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
            }
        }

        /// <summary> Gets an object representing a <see cref="CassandraDataCenterCollection"/> along with the instance operations that can be performed on it. </summary>
        /// <returns> Returns a <see cref="CassandraDataCenterCollection"/>. </returns>
        public virtual CassandraDataCenterCollection GetCassandraDataCenters()
        {
            return GetCachedClient(client => new CassandraDataCenterCollection(client, Id));
        }

        /// <summary>
        /// Get the properties of a managed Cassandra data center.
        /// </summary>
        /// <param name="dataCenterName"> Managed Cassandra data center name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="dataCenterName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="dataCenterName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<CassandraDataCenterResource>> GetCassandraDataCenterAsync(string dataCenterName, CancellationToken cancellationToken = default)
        {
            return await GetCassandraDataCenters().GetAsync(dataCenterName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get the properties of a managed Cassandra data center.
        /// </summary>
        /// <param name="dataCenterName"> Managed Cassandra data center name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="dataCenterName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="dataCenterName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual Response<CassandraDataCenterResource> GetCassandraDataCenter(string dataCenterName, CancellationToken cancellationToken = default)
        {
            return GetCassandraDataCenters().Get(dataCenterName, cancellationToken);
        }

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
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<CassandraClusterResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _cassandraClustersClientDiagnostics.CreateScope("CassandraClusterResource.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _cassandraClustersRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<CassandraClusterData> response = Response.FromValue(CassandraClusterData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
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
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<CassandraClusterResource> Get(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _cassandraClustersClientDiagnostics.CreateScope("CassandraClusterResource.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _cassandraClustersRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<CassandraClusterData> response = Response.FromValue(CassandraClusterData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new CassandraClusterResource(Client, response.Value), response.GetRawResponse());
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
        /// <param name="data"> The required parameters for creating or updating a managed Cassandra cluster. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<CassandraClusterResource>> UpdateAsync(WaitUntil waitUntil, CassandraClusterData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using DiagnosticScope scope = _cassandraClustersClientDiagnostics.CreateScope("CassandraClusterResource.Update");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _cassandraClustersRestClient.CreateCreateUpdateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, CassandraClusterData.ToRequestContent(data), context);
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
        /// <param name="data"> The required parameters for creating or updating a managed Cassandra cluster. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<CassandraClusterResource> Update(WaitUntil waitUntil, CassandraClusterData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using DiagnosticScope scope = _cassandraClustersClientDiagnostics.CreateScope("CassandraClusterResource.Update");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _cassandraClustersRestClient.CreateCreateUpdateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, CassandraClusterData.ToRequestContent(data), context);
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
        /// Deletes a managed Cassandra cluster.
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _cassandraClustersClientDiagnostics.CreateScope("CassandraClusterResource.Delete");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _cassandraClustersRestClient.CreateDeleteRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
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
        /// Deletes a managed Cassandra cluster.
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _cassandraClustersClientDiagnostics.CreateScope("CassandraClusterResource.Delete");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _cassandraClustersRestClient.CreateDeleteRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
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

        /// <summary>
        /// Invoke a command like nodetool for cassandra maintenance.
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="body"> Specification which command to run where. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
        public virtual async Task<ArmOperation<CassandraCommandOutput>> InvokeCommandAsync(WaitUntil waitUntil, CassandraCommandPostBody body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            using DiagnosticScope scope = _cassandraClustersClientDiagnostics.CreateScope("CassandraClusterResource.InvokeCommand");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _cassandraClustersRestClient.CreateInvokeCommandAsyncRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, CassandraCommandPostBody.ToRequestContent(body), context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                CosmosDBArmOperation<CassandraCommandOutput> operation = new CosmosDBArmOperation<CassandraCommandOutput>(
                    new CassandraCommandOutputOperationSource(),
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
        /// Invoke a command like nodetool for cassandra maintenance.
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="body"> Specification which command to run where. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
        public virtual ArmOperation<CassandraCommandOutput> InvokeCommand(WaitUntil waitUntil, CassandraCommandPostBody body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            using DiagnosticScope scope = _cassandraClustersClientDiagnostics.CreateScope("CassandraClusterResource.InvokeCommand");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _cassandraClustersRestClient.CreateInvokeCommandAsyncRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, CassandraCommandPostBody.ToRequestContent(body), context);
                Response response = Pipeline.ProcessMessage(message, context);
                CosmosDBArmOperation<CassandraCommandOutput> operation = new CosmosDBArmOperation<CassandraCommandOutput>(
                    new CassandraCommandOutputOperationSource(),
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
        /// Start the Managed Cassandra Cluster and Associated Data Centers. Start will start the host virtual machine of
        /// this cluster and reconnect the data disks.
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> StartAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _cassandraClustersClientDiagnostics.CreateScope("CassandraClusterResource.Start");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _cassandraClustersRestClient.CreateStartRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
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
        /// Start the Managed Cassandra Cluster and Associated Data Centers. Start will start the host virtual machine of
        /// this cluster and reconnect the data disks.
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Start(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _cassandraClustersClientDiagnostics.CreateScope("CassandraClusterResource.Start");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _cassandraClustersRestClient.CreateStartRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
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

        /// <summary>
        /// Get the status of a managed Cassandra cluster.
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<CassandraClusterPublicStatus>> StatusAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _cassandraClustersClientDiagnostics.CreateScope("CassandraClusterResource.Status");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _cassandraClustersRestClient.CreateStatusRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                return Response.FromValue(CassandraClusterPublicStatus.FromResponse(result), result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get the status of a managed Cassandra cluster.
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<CassandraClusterPublicStatus> Status(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _cassandraClustersClientDiagnostics.CreateScope("CassandraClusterResource.Status");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _cassandraClustersRestClient.CreateStatusRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
                Response result = Pipeline.ProcessMessage(message, context);
                return Response.FromValue(CassandraClusterPublicStatus.FromResponse(result), result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Add a tag to the current resource. </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
        public virtual async Task<Response<CassandraClusterResource>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

            using DiagnosticScope scope = _cassandraClustersClientDiagnostics.CreateScope("CassandraClusterResource.AddTag");
            scope.Start();
            try
            {
                if (await CanUseTagResourceAsync(cancellationToken).ConfigureAwait(false))
                {
                    Response<TagResource> originalTags = await GetTagResource().GetAsync(cancellationToken).ConfigureAwait(false);
                    originalTags.Value.Data.TagValues[key] = value;
                    await GetTagResource().CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken).ConfigureAwait(false);
                    RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                    HttpMessage message = _cassandraClustersRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
                    Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                    Response<CassandraClusterData> response = Response.FromValue(CassandraClusterData.FromResponse(result), result);
                    return Response.FromValue(new CassandraClusterResource(Client, response.Value), response.GetRawResponse());
                }
                else
                {
                    CassandraClusterData current = (await GetAsync(cancellationToken: cancellationToken).ConfigureAwait(false)).Value.Data;
                    current.Tags[key] = value;
                    ArmOperation<CassandraClusterResource> result = await UpdateAsync(WaitUntil.Completed, current, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Response.FromValue(result.Value, result.GetRawResponse());
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Add a tag to the current resource. </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
        public virtual Response<CassandraClusterResource> AddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

            using DiagnosticScope scope = _cassandraClustersClientDiagnostics.CreateScope("CassandraClusterResource.AddTag");
            scope.Start();
            try
            {
                if (CanUseTagResource(cancellationToken))
                {
                    Response<TagResource> originalTags = GetTagResource().Get(cancellationToken);
                    originalTags.Value.Data.TagValues[key] = value;
                    GetTagResource().CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken);
                    RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                    HttpMessage message = _cassandraClustersRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
                    Response result = Pipeline.ProcessMessage(message, context);
                    Response<CassandraClusterData> response = Response.FromValue(CassandraClusterData.FromResponse(result), result);
                    return Response.FromValue(new CassandraClusterResource(Client, response.Value), response.GetRawResponse());
                }
                else
                {
                    CassandraClusterData current = Get(cancellationToken: cancellationToken).Value.Data;
                    current.Tags[key] = value;
                    ArmOperation<CassandraClusterResource> result = Update(WaitUntil.Completed, current, cancellationToken: cancellationToken);
                    return Response.FromValue(result.Value, result.GetRawResponse());
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Replace the tags on the resource with the given set. </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tags"/> is null. </exception>
        public virtual async Task<Response<CassandraClusterResource>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));

            using DiagnosticScope scope = _cassandraClustersClientDiagnostics.CreateScope("CassandraClusterResource.SetTags");
            scope.Start();
            try
            {
                if (await CanUseTagResourceAsync(cancellationToken).ConfigureAwait(false))
                {
                    await GetTagResource().DeleteAsync(WaitUntil.Completed, cancellationToken).ConfigureAwait(false);
                    Response<TagResource> originalTags = await GetTagResource().GetAsync(cancellationToken).ConfigureAwait(false);
                    originalTags.Value.Data.TagValues.ReplaceWith(tags);
                    await GetTagResource().CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken).ConfigureAwait(false);
                    RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                    HttpMessage message = _cassandraClustersRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
                    Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                    Response<CassandraClusterData> response = Response.FromValue(CassandraClusterData.FromResponse(result), result);
                    return Response.FromValue(new CassandraClusterResource(Client, response.Value), response.GetRawResponse());
                }
                else
                {
                    CassandraClusterData current = (await GetAsync(cancellationToken: cancellationToken).ConfigureAwait(false)).Value.Data;
                    current.Tags.ReplaceWith(tags);
                    ArmOperation<CassandraClusterResource> result = await UpdateAsync(WaitUntil.Completed, current, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Response.FromValue(result.Value, result.GetRawResponse());
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Replace the tags on the resource with the given set. </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tags"/> is null. </exception>
        public virtual Response<CassandraClusterResource> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));

            using DiagnosticScope scope = _cassandraClustersClientDiagnostics.CreateScope("CassandraClusterResource.SetTags");
            scope.Start();
            try
            {
                if (CanUseTagResource(cancellationToken))
                {
                    GetTagResource().Delete(WaitUntil.Completed, cancellationToken);
                    Response<TagResource> originalTags = GetTagResource().Get(cancellationToken);
                    originalTags.Value.Data.TagValues.ReplaceWith(tags);
                    GetTagResource().CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken);
                    RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                    HttpMessage message = _cassandraClustersRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
                    Response result = Pipeline.ProcessMessage(message, context);
                    Response<CassandraClusterData> response = Response.FromValue(CassandraClusterData.FromResponse(result), result);
                    return Response.FromValue(new CassandraClusterResource(Client, response.Value), response.GetRawResponse());
                }
                else
                {
                    CassandraClusterData current = Get(cancellationToken: cancellationToken).Value.Data;
                    current.Tags.ReplaceWith(tags);
                    ArmOperation<CassandraClusterResource> result = Update(WaitUntil.Completed, current, cancellationToken: cancellationToken);
                    return Response.FromValue(result.Value, result.GetRawResponse());
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Removes a tag by key from the resource. </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        public virtual async Task<Response<CassandraClusterResource>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));

            using DiagnosticScope scope = _cassandraClustersClientDiagnostics.CreateScope("CassandraClusterResource.RemoveTag");
            scope.Start();
            try
            {
                if (await CanUseTagResourceAsync(cancellationToken).ConfigureAwait(false))
                {
                    Response<TagResource> originalTags = await GetTagResource().GetAsync(cancellationToken).ConfigureAwait(false);
                    originalTags.Value.Data.TagValues.Remove(key);
                    await GetTagResource().CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken).ConfigureAwait(false);
                    RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                    HttpMessage message = _cassandraClustersRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
                    Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                    Response<CassandraClusterData> response = Response.FromValue(CassandraClusterData.FromResponse(result), result);
                    return Response.FromValue(new CassandraClusterResource(Client, response.Value), response.GetRawResponse());
                }
                else
                {
                    CassandraClusterData current = (await GetAsync(cancellationToken: cancellationToken).ConfigureAwait(false)).Value.Data;
                    current.Tags.Remove(key);
                    ArmOperation<CassandraClusterResource> result = await UpdateAsync(WaitUntil.Completed, current, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Response.FromValue(result.Value, result.GetRawResponse());
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Removes a tag by key from the resource. </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        public virtual Response<CassandraClusterResource> RemoveTag(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));

            using DiagnosticScope scope = _cassandraClustersClientDiagnostics.CreateScope("CassandraClusterResource.RemoveTag");
            scope.Start();
            try
            {
                if (CanUseTagResource(cancellationToken))
                {
                    Response<TagResource> originalTags = GetTagResource().Get(cancellationToken);
                    originalTags.Value.Data.TagValues.Remove(key);
                    GetTagResource().CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken);
                    RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                    HttpMessage message = _cassandraClustersRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
                    Response result = Pipeline.ProcessMessage(message, context);
                    Response<CassandraClusterData> response = Response.FromValue(CassandraClusterData.FromResponse(result), result);
                    return Response.FromValue(new CassandraClusterResource(Client, response.Value), response.GetRawResponse());
                }
                else
                {
                    CassandraClusterData current = Get(cancellationToken: cancellationToken).Value.Data;
                    current.Tags.Remove(key);
                    ArmOperation<CassandraClusterResource> result = Update(WaitUntil.Completed, current, cancellationToken: cancellationToken);
                    return Response.FromValue(result.Value, result.GetRawResponse());
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
