﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel.Design;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.Agents.Persistent
{
    [CodeGenClient("PersistentAgentsAdministrationClient")]
    public partial class PersistentAgentsAdministration
    {
        private static readonly bool s_is_test_run = AppContextSwitchHelper.GetConfigValue(
            PersistantAgensConstants.UseOldConnectionString,
            PersistantAgensConstants.UseOldConnectionStringEnvVar);
        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal virtual ClientDiagnostics ClientDiagnostics { get; }
        // TODO: Replace project connections string by PROJECT_ENDPOINT when 1DP will be available.
        //var connectionString = TestEnvironment.PROJECT_ENDPOINT;

        /// <summary> Initializes a new instance of AzureAIClient. </summary>
        /// <param name="endpoint"> The Azure AI Foundry project endpoint, in the form `https://&lt;aiservices-id&gt;.services.ai.azure.com/api/projects/&lt;project-name&gt;`</param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        /// <exception cref="ArgumentException"> is an empty string, and was expected to be non-empty. </exception>
        public PersistentAgentsAdministration(string endpoint, TokenCredential credential) : this(endpoint, credential, new PersistentAgentsAdministrationClientOptions())
        {
        }

        /// <summary> Initializes a new instance of AzureAIClient. </summary>
        /// <param name="endpoint"> The Azure AI Foundry project endpoint, in the form `https://&lt;aiservices-id&gt;.services.ai.azure.com/api/projects/&lt;project-name&gt;`</param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/>, or <paramref name="credential"/> is null. </exception>
        /// <exception cref="ArgumentException"> is an empty string, and was expected to be non-empty. </exception>
        public PersistentAgentsAdministration(string endpoint, TokenCredential credential, PersistentAgentsAdministrationClientOptions options)
        {
            // TODO: Remve this code when 1DP endpoint will be available and just call the upsteam constructor.
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));

            if (s_is_test_run && endpoint.Split(';').Length == 4)
            {
                options ??= new PersistentAgentsAdministrationClientOptions(PersistentAgentsAdministrationClientOptions.ServiceVersion.V2025_05_01);
                ClientDiagnostics = new ClientDiagnostics(options, true);
                _tokenCredential = credential;
                _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new BearerTokenAuthenticationPolicy(_tokenCredential, ["https://management.azure.com/.default"]) }, new ResponseClassifier());
                _endpoint = new Uri($"{ClientHelper.ParseConnectionString(endpoint, "endpoint")}/agents/v1.0/subscriptions/{ClientHelper.ParseConnectionString(endpoint, "subscriptionid")}/resourceGroups/{ClientHelper.ParseConnectionString(endpoint, "resourcegroupname")}/providers/Microsoft.MachineLearningServices/workspaces/{ClientHelper.ParseConnectionString(endpoint, "projectname")}");
                _apiVersion = options.Version;
            }
            else
            {
                options ??= new PersistentAgentsAdministrationClientOptions();
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
            return Volatile.Read(ref _cachedThreadRuns) ?? Interlocked.CompareExchange(ref _cachedThreadRuns, new ThreadRuns(ClientDiagnostics, _pipeline, _tokenCredential, _endpoint, _apiVersion), null) ?? _cachedThreadRuns;
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
            return Volatile.Read(ref _cachedVectorStores) ?? Interlocked.CompareExchange(ref _cachedVectorStores, new VectorStores(ClientDiagnostics, _pipeline, _tokenCredential, _endpoint, _apiVersion), null) ?? _cachedVectorStores;
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
            HttpMessage PageRequest(int? pageSizeHint, string continuationToken) => CreateGetAgentsRequest(limit, order?.ToString(), continuationToken, before, context);
            return new ContinuationTokenPageableAsync<PersistentAgent>(
                createPageRequest: PageRequest,
                valueFactory: e => PersistentAgent.DeserializePersistentAgent(e),
                pipeline: _pipeline,
                clientDiagnostics: ClientDiagnostics,
                scopeName: "ThreadMessagesClient.GetMessages",
                requestContext: context
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
            HttpMessage PageRequest(int? pageSizeHint, string continuationToken) => CreateGetAgentsRequest(limit, order?.ToString(), continuationToken, before, context);
            return new ContinuationTokenPageable<PersistentAgent>(
                createPageRequest: PageRequest,
                valueFactory: e => PersistentAgent.DeserializePersistentAgent(e),
                pipeline: _pipeline,
                clientDiagnostics: ClientDiagnostics,
                scopeName: "ThreadMessagesClient.GetMessages",
                requestContext: context
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
    }
}
