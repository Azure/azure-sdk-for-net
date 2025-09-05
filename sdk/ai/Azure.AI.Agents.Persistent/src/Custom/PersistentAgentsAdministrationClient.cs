// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure.AI.Agents.Persistent.Telemetry;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.Agents.Persistent
{
    public partial class PersistentAgentsAdministrationClient
    {
        private static readonly bool s_is_test_run = AppContextSwitchHelper.GetConfigValue(
            PersistentAgentsConstants.UseOldConnectionString,
            PersistentAgentsConstants.UseOldConnectionStringEnvVar);
        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal virtual ClientDiagnostics ClientDiagnostics { get; }
        // TODO: Replace project connections string by PROJECT_ENDPOINT when 1DP will be available.
        //var connectionString = TestEnvironment.PROJECT_ENDPOINT;

        /// <summary> Initializes a new instance of AzureAIClient. </summary>
        /// <param name="endpoint"> The Azure AI Foundry project endpoint, in the form `https://&lt;aiservices-id&gt;.services.ai.azure.com/api/projects/&lt;project-name&gt;`</param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        /// <exception cref="ArgumentException"> is an empty string, and was expected to be non-empty. </exception>
        public PersistentAgentsAdministrationClient(string endpoint, TokenCredential credential) : this(endpoint, credential, new PersistentAgentsAdministrationClientOptions())
        {
        }

        /// <summary> Initializes a new instance of AzureAIClient. </summary>
        /// <param name="endpoint"> The Azure AI Foundry project endpoint, in the form `https://&lt;aiservices-id&gt;.services.ai.azure.com/api/projects/&lt;project-name&gt;`</param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/>, or <paramref name="credential"/> is null. </exception>
        /// <exception cref="ArgumentException"> is an empty string, and was expected to be non-empty. </exception>
        public PersistentAgentsAdministrationClient(string endpoint, TokenCredential credential, PersistentAgentsAdministrationClientOptions options)
        {
            // TODO: Remve this code when 1DP endpoint will be available and just call the upsteam constructor.
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new PersistentAgentsAdministrationClientOptions();

            if (s_is_test_run && endpoint.Split(';').Length == 4)
            {
                ClientDiagnostics = new ClientDiagnostics(options, true);
                _tokenCredential = credential;
                _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new BearerTokenAuthenticationPolicy(_tokenCredential, ["https://management.azure.com/.default"]) }, new ResponseClassifier());
                _endpoint = new Uri($"{ClientHelper.ParseConnectionString(endpoint, "endpoint")}/agents/v1.0/subscriptions/{ClientHelper.ParseConnectionString(endpoint, "subscriptionid")}/resourceGroups/{ClientHelper.ParseConnectionString(endpoint, "resourcegroupname")}/providers/Microsoft.MachineLearningServices/workspaces/{ClientHelper.ParseConnectionString(endpoint, "projectname")}");
                _apiVersion = options.Version;
            }
            else
            {
                ClientDiagnostics = new ClientDiagnostics(options, true);
                _tokenCredential = credential;
                _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new BearerTokenAuthenticationPolicy(_tokenCredential, AuthorizationScopes) }, new ResponseClassifier());
                _endpoint = new Uri(endpoint);
                _apiVersion = options.Version;
            }
        }

        /*
         * CUSTOM CODE DESCRIPTION:
         *
         * Generated methods that return trivial response value types (e.g. "DeletionStatus" that has nothing but a
         * "Deleted" property) are shimmed to directly use the underlying data as their response value type.
         *
         */

        /// <summary> Deletes an agent. </summary>
        /// <param name="agentId"> The ID of the agent to delete. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="agentId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="agentId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Response<bool> DeleteAgent(string agentId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("PersistentAgentsClient.DeleteAgent");
            scope.Start();
            Response<InternalAgentDeletionStatus> baseResponse = InternalDeleteAgent(agentId, cancellationToken);
            bool simplifiedValue =
                baseResponse.GetRawResponse() != null
                && !baseResponse.GetRawResponse().IsError
                && baseResponse.Value != null
                && baseResponse.Value.Deleted;
            return Response.FromValue(simplifiedValue, baseResponse.GetRawResponse());
        }

        /// <summary> Deletes an agent. </summary>
        /// <param name="agentId"> The ID of the agent to delete. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="agentId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="agentId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<Response<bool>> DeleteAgentAsync(
            string agentId,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("PersistentAgentsClient.DeleteAgent");
            scope.Start();
            Response<InternalAgentDeletionStatus> baseResponse
                = await InternalDeleteAgentAsync(agentId, cancellationToken).ConfigureAwait(false);
            bool simplifiedValue =
                baseResponse.GetRawResponse() != null
                && !baseResponse.GetRawResponse().IsError
                && baseResponse.Value != null
                && baseResponse.Value.Deleted;
            return Response.FromValue(simplifiedValue, baseResponse.GetRawResponse());
        }

        /// <summary> Initializes a new instance of ThreadsClient. </summary>
        internal virtual Threads GetThreadsClient()
        {
            return Volatile.Read(ref _cachedThreads) ?? Interlocked.CompareExchange(ref _cachedThreads, new Threads(ClientDiagnostics, _pipeline, _tokenCredential, _endpoint, _apiVersion), null) ?? _cachedThreads;
        }

        /// <summary> Initializes a new instance of ThreadMessagesClient. </summary>
        internal virtual ThreadMessages GetThreadMessagesClient()
        {
            return Volatile.Read(ref _cachedThreadMessages) ?? Interlocked.CompareExchange(ref _cachedThreadMessages, new ThreadMessages(ClientDiagnostics, _pipeline, _tokenCredential, _endpoint, _apiVersion), null) ?? _cachedThreadMessages;
        }

        /// <summary> Initializes a new instance of RunsClient. </summary>
        internal virtual ThreadRuns GetThreadRunsClient()
        {
            return Volatile.Read(ref _cachedThreadRuns) ?? Interlocked.CompareExchange(ref _cachedThreadRuns, new ThreadRuns(ClientDiagnostics, _pipeline, _tokenCredential, _endpoint, _apiVersion, GetThreadRunStepsClient()), null) ?? _cachedThreadRuns;
        }

        /// <summary> Initializes a new instance of RunStepsClient. </summary>
        internal virtual ThreadRunSteps GetThreadRunStepsClient()
        {
            return Volatile.Read(ref _cachedThreadRunSteps) ?? Interlocked.CompareExchange(ref _cachedThreadRunSteps, new ThreadRunSteps(ClientDiagnostics, _pipeline, _tokenCredential, _endpoint, _apiVersion), null) ?? _cachedThreadRunSteps;
        }

        /// <summary> Initializes a new instance of FilesClient. </summary>
        internal virtual PersistentAgentsFiles GetPersistentAgentsFilesClient()
        {
            return Volatile.Read(ref _cachedPersistentAgentsFiles) ?? Interlocked.CompareExchange(ref _cachedPersistentAgentsFiles, new PersistentAgentsFiles(ClientDiagnostics, _pipeline, _tokenCredential, _endpoint, _apiVersion), null) ?? _cachedPersistentAgentsFiles;
        }

        /// <summary> Initializes a new instance of VectorStoresClient. </summary>
        internal virtual VectorStores GetVectorStoresClient()
        {
            return Volatile.Read(ref _cachedVectorStores) ?? Interlocked.CompareExchange(ref _cachedVectorStores, new VectorStores(ClientDiagnostics, _pipeline, _tokenCredential, _endpoint, _apiVersion, GetVectorStoreFilesClient(), GetVectorStoreFileBatchesClient()), null) ?? _cachedVectorStores;
        }

        /// <summary> Initializes a new instance of VectorStoreFilesClient. </summary>
        internal virtual VectorStoreFiles GetVectorStoreFilesClient()
        {
            return Volatile.Read(ref _cachedVectorStoreFiles) ?? Interlocked.CompareExchange(ref _cachedVectorStoreFiles, new VectorStoreFiles(ClientDiagnostics, _pipeline, _tokenCredential, _endpoint, _apiVersion), null) ?? _cachedVectorStoreFiles;
        }

        /// <summary> Initializes a new instance of VectorStoreFileBatchesClient. </summary>
        internal virtual VectorStoreFileBatches GetVectorStoreFileBatchesClient()
        {
            return Volatile.Read(ref _cachedVectorStoreFileBatches) ?? Interlocked.CompareExchange(ref _cachedVectorStoreFileBatches, new VectorStoreFileBatches(ClientDiagnostics, _pipeline, _tokenCredential, _endpoint, _apiVersion), null) ?? _cachedVectorStoreFileBatches;
        }

        /// <summary> Gets a list of agents that were previously created. </summary>
        /// <param name="limit"> A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 20. </param>
        /// <param name="order"> Sort order by the created_at timestamp of the objects. asc for ascending order and desc for descending order. </param>
        /// <param name="after"> A cursor for use in pagination. after is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include after=obj_foo in order to fetch the next page of the list. </param>
        /// <param name="before"> A cursor for use in pagination. before is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include before=obj_foo in order to fetch the previous page of the list. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<PersistentAgent> GetAgentsAsync(int? limit = null, ListSortOrder? order = null, string after = null, string before = null, CancellationToken cancellationToken = default)
        {
            RequestContext context = cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null;
            HttpMessage PageRequest(int? pageSizeHint, string continuationToken) => CreateGetAgentsRequest(
                limit: limit,
                order: order?.ToString(),
                after: continuationToken,
                before: before,
                context: context);
            return new ContinuationTokenPageableAsync<PersistentAgent>(
                createPageRequest: PageRequest,
                valueFactory: e => PersistentAgent.DeserializePersistentAgent(e),
                pipeline: _pipeline,
                clientDiagnostics: ClientDiagnostics,
                scopeName: "ThreadMessagesClient.GetMessages",
                requestContext: context,
                after: after
            );
        }

        /// <summary> Gets a list of agents that were previously created. </summary>
        /// <param name="limit"> A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 20. </param>
        /// <param name="order"> Sort order by the created_at timestamp of the objects. asc for ascending order and desc for descending order. </param>
        /// <param name="after"> A cursor for use in pagination. after is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include after=obj_foo in order to fetch the next page of the list. </param>
        /// <param name="before"> A cursor for use in pagination. before is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include before=obj_foo in order to fetch the previous page of the list. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<PersistentAgent> GetAgents(int? limit = null, ListSortOrder? order = null, string after = null, string before = null, CancellationToken cancellationToken = default)
        {
            RequestContext context = cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null;
            HttpMessage PageRequest(int? pageSizeHint, string continuationToken) => CreateGetAgentsRequest(
                limit: limit,
                order: order?.ToString(),
                after: continuationToken,
                before: before,
                context: context);
            return new ContinuationTokenPageable<PersistentAgent>(
                createPageRequest: PageRequest,
                valueFactory: e => PersistentAgent.DeserializePersistentAgent(e),
                pipeline: _pipeline,
                clientDiagnostics: ClientDiagnostics,
                scopeName: "ThreadMessagesClient.GetMessages",
                requestContext: context,
                after: after
            );
        }

        /// <summary>
        /// [Protocol Method] Gets a list of agents that were previously created.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetAgentsAsync(int?,ListSortOrder?,string,string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="limit"> A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 20. </param>
        /// <param name="order"> Sort order by the created_at timestamp of the objects. asc for ascending order and desc for descending order. Allowed values: "asc" | "desc". </param>
        /// <param name="after"> A cursor for use in pagination. after is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include after=obj_foo in order to fetch the next page of the list. </param>
        /// <param name="before"> A cursor for use in pagination. before is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include before=obj_foo in order to fetch the previous page of the list. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="AsyncPageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        internal virtual AsyncPageable<BinaryData> GetAgentsAsync(int? limit, string order, string after, string before, RequestContext context)
        {
            // This method is not yet supported, because it is using generated implementation of parser,
            // which is currently do not support next token.
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetAgentsRequest(limit, order, after, before, context);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, null, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "PersistentAgentsAdministrationClient.GetAgents", "data", null, context);
        }

        /// <summary>
        /// [Protocol Method] Gets a list of agents that were previously created.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetAgents(int?,ListSortOrder?,string,string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="limit"> A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 20. </param>
        /// <param name="order"> Sort order by the created_at timestamp of the objects. asc for ascending order and desc for descending order. Allowed values: "asc" | "desc". </param>
        /// <param name="after"> A cursor for use in pagination. after is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include after=obj_foo in order to fetch the next page of the list. </param>
        /// <param name="before"> A cursor for use in pagination. before is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include before=obj_foo in order to fetch the previous page of the list. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Pageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        internal virtual Pageable<BinaryData> GetAgents(int? limit, string order, string after, string before, RequestContext context)
        {
            // This method is not yet supported, because it is using generated implementation of parser,
            // which is currently do not support next token.
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetAgentsRequest(limit, order, after, before, context);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, null, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "PersistentAgentsAdministrationClient.GetAgents", "data", null, context);
        }

        /// <summary>
        /// [Protocol Method] Retrieves an existing agent.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetAgentAsync(string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="agentId"> Identifier of the agent. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="agentId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="agentId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<Response> GetAgentAsync(string agentId, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(agentId, nameof(agentId));

            using var scope = ClientDiagnostics.CreateScope("PersistentAgentsAdministration.GetAgent");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetAgentRequest(agentId, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Retrieves an existing agent.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetAgent(string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="agentId"> Identifier of the agent. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="agentId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="agentId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Response GetAgent(string agentId, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(agentId, nameof(agentId));

            using var scope = ClientDiagnostics.CreateScope("PersistentAgentsAdministration.GetAgent");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetAgentRequest(agentId, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Creates a new agent.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="CreateAgentAsync(string,string,string,string,IEnumerable{ToolDefinition},ToolResources,float?,float?,BinaryData,IReadOnlyDictionary{string,string},CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response> CreateAgentAsync(RequestContent content, RequestContext context = null)
        {
            using var otelScope = OpenTelemetryScope.StartCreateAgent(content, _endpoint);
            Argument.AssertNotNull(content, nameof(content));

            try
            {
                using HttpMessage message = CreateCreateAgentRequest(content, context);
                var response = await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                otelScope?.RecordCreateAgentResponse(response);
                return response;
            }
            catch (Exception e)
            {
                otelScope?.RecordError(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Creates a new agent.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="CreateAgent(string,string,string,string,IEnumerable{ToolDefinition},ToolResources,float?,float?,BinaryData,IReadOnlyDictionary{string,string},CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response CreateAgent(RequestContent content, RequestContext context = null)
        {
            using var otelScope = OpenTelemetryScope.StartCreateAgent(content, _endpoint);
            Argument.AssertNotNull(content, nameof(content));

            try
            {
                using HttpMessage message = CreateCreateAgentRequest(content, context);
                var response = _pipeline.ProcessMessage(message, context);
                otelScope?.RecordCreateAgentResponse(response);
                return response;
            }
            catch (Exception e)
            {
                otelScope?.RecordError(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Modifies an existing agent.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="UpdateAgentAsync(string,string,string,string,string,IEnumerable{ToolDefinition},ToolResources,float?,float?,BinaryData,IReadOnlyDictionary{string,string},CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="assistantId"> The ID of the agent to modify. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="assistantId"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="assistantId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response> UpdateAgentAsync(string assistantId, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(assistantId, nameof(assistantId));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("PersistentAgentsAdministrationClient.UpdateAgent");
            scope.Start();
            try
            {
                using HttpMessage message = CreateUpdateAgentRequest(assistantId, content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Modifies an existing agent.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="UpdateAgent(string,string,string,string,string,IEnumerable{ToolDefinition},ToolResources,float?,float?,BinaryData,IReadOnlyDictionary{string,string},CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="assistantId"> The ID of the agent to modify. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="assistantId"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="assistantId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response UpdateAgent(string assistantId, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(assistantId, nameof(assistantId));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("PersistentAgentsAdministrationClient.UpdateAgent");
            scope.Start();
            try
            {
                using HttpMessage message = CreateUpdateAgentRequest(assistantId, content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Creates a new agent thread and immediately starts a run using that new thread.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="CreateThreadAndRunAsync(string,PersistentAgentThreadCreationOptions,string,string,IEnumerable{ToolDefinition},ToolResources,bool?,float?,float?,int?,int?,Truncation,BinaryData,BinaryData,bool?,IReadOnlyDictionary{string,string},CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        internal virtual async Task<Response> CreateThreadAndRunAsync(RequestContent content, RequestContext context = null)
        {
            using var otelScope = OpenTelemetryScope.StartCreateRun(content, _endpoint);
            Argument.AssertNotNull(content, nameof(content));

            try
            {
                using HttpMessage message = CreateCreateThreadAndRunRequest(content, context);
                var response = await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                otelScope?.RecordCreateRunResponse(response);
                return response;
            }
            catch (Exception e)
            {
                otelScope?.RecordError(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Creates a new agent thread and immediately starts a run using that new thread.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="CreateThreadAndRun(string,PersistentAgentThreadCreationOptions,string,string,IEnumerable{ToolDefinition},ToolResources,bool?,float?,float?,int?,int?,Truncation,BinaryData,BinaryData,bool?,IReadOnlyDictionary{string,string},CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        internal virtual Response CreateThreadAndRun(RequestContent content, RequestContext context = null)
        {
            using var otelScope = OpenTelemetryScope.StartCreateRun(content, _endpoint);
            Argument.AssertNotNull(content, nameof(content));

            try
            {
                using HttpMessage message = CreateCreateThreadAndRunRequest(content, context);
                var response = _pipeline.ProcessMessage(message, context);
                otelScope?.RecordCreateRunResponse(response);
                return response;
            }
            catch (Exception e)
            {
                otelScope?.RecordError(e);
                throw;
            }
        }
    }
}
