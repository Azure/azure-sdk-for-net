// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.Agents.Persistent
{
    public partial class PersistentAgentsAdministrationClient
    {
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
        public PersistentAgentsAdministrationClient(string endpoint, AzureKeyCredential credential, PersistentAgentsAdministrationClientOptions options) : this(new Uri(endpoint), credential, options)
        {
        }

        /// <summary> Initializes a new instance of AzureAIClient. </summary>
        /// <param name="endpoint"> The Azure AI Foundry project endpoint, in the form `https://&lt;aiservices-id&gt;.services.ai.azure.com/api/projects/&lt;project-name&gt;`</param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        /// <exception cref="ArgumentException"> is an empty string, and was expected to be non-empty. </exception>
        public PersistentAgentsAdministrationClient(string endpoint, AzureKeyCredential credential) : this(endpoint, credential, new PersistentAgentsAdministrationClientOptions())
        {
        }
        /// <summary> Initializes a new instance of AzureAIClient. </summary>
        /// <param name="endpoint"> The Azure AI Foundry project endpoint, in the form `https://&lt;aiservices-id&gt;.services.ai.azure.com/api/projects/&lt;project-name&gt;`</param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/>, or <paramref name="credential"/> is null. </exception>
        /// <exception cref="ArgumentException"> is an empty string, and was expected to be non-empty. </exception>
        public PersistentAgentsAdministrationClient(string endpoint, TokenCredential credential, PersistentAgentsAdministrationClientOptions options) //: this(new Uri(endpoint), credential, options)
        {
            // TODO: Remve this code when 1DP endpoint will be available and just call the upsteam constructor.
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new PersistentAgentsAdministrationClientOptions();

            if (endpoint.Split(';').Length != 4)
            {
                ClientDiagnostics = new ClientDiagnostics(options, true);
                _tokenCredential = credential;
                _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new AzureKeyCredentialPolicy(_keyCredential, AuthorizationHeader, AuthorizationApiKeyPrefix) }, new ResponseClassifier());
                _endpoint = new Uri(endpoint);
                _apiVersion = options.Version;
            }
            else
            {
                ClientDiagnostics = new ClientDiagnostics(options, true);
                _tokenCredential = credential;
                _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new BearerTokenAuthenticationPolicy(_tokenCredential, ["https://management.azure.com/.default"]) }, new ResponseClassifier());
                _endpoint = new Uri($"{ClientHelper.ParseConnectionString(endpoint, "endpoint")}/agents/v1.0/subscriptions/{ClientHelper.ParseConnectionString(endpoint, "subscriptionid")}/resourceGroups/{ClientHelper.ParseConnectionString(endpoint, "resourcegroupname")}/providers/Microsoft.MachineLearningServices/workspaces/{ClientHelper.ParseConnectionString(endpoint, "projectname")}");
                _apiVersion = options.Version;
            }
        }

        // /// <inheritdoc cref="InternalGetAgents(int?, ListSortOrder?, string, string, CancellationToken)"/>
        //public virtual Response<PageableList<PersistentAgent>> GetAgents(
        //    int? limit = null,
        //    ListSortOrder? order = null,
        //    string after = null,
        //    string before = null,
        //    CancellationToken cancellationToken = default)
        //{
        //    using DiagnosticScope scope = ClientDiagnostics.CreateScope("PersistentAgentsClient.GetAgents");
        //    scope.Start();
        //    Response<InternalOpenAIPageableListOfAgent> baseResponse = InternalGetAgents(limit, order, after, before, cancellationToken);
        //    return Response.FromValue(PageableList<PersistentAgent>.Create(baseResponse.Value), baseResponse.GetRawResponse());
        //}

        ///// <inheritdoc cref="InternalGetAgentsAsync(int?, ListSortOrder?, string, string, CancellationToken)"/>
        //public virtual async Task<Response<PageableList<PersistentAgent>>> GetAgentsAsync(
        //    int? limit = null,
        //    ListSortOrder? order = null,
        //    string after = null,
        //    string before = null,
        //    CancellationToken cancellationToken = default)
        //{
        //    using DiagnosticScope scope = ClientDiagnostics.CreateScope("PersistentAgentsClient.GetAgents");
        //    scope.Start();
        //    Response<InternalOpenAIPageableListOfAgent> baseResponse
        //        = await InternalGetAgentsAsync(limit, order, after, before, cancellationToken).ConfigureAwait(false);
        //    return Response.FromValue(PageableList<PersistentAgent>.Create(baseResponse.Value), baseResponse.GetRawResponse());
        //}

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
        internal virtual ThreadsClient GetThreadsClient()
        {
            return Volatile.Read(ref _cachedThreadsClient) ?? Interlocked.CompareExchange(ref _cachedThreadsClient, new ThreadsClient(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, _apiVersion), null) ?? _cachedThreadsClient;
        }

        /// <summary> Initializes a new instance of ThreadMessagesClient. </summary>
        internal virtual ThreadMessagesClient GetThreadMessagesClient()
        {
            return Volatile.Read(ref _cachedThreadMessagesClient) ?? Interlocked.CompareExchange(ref _cachedThreadMessagesClient, new ThreadMessagesClient(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, _apiVersion), null) ?? _cachedThreadMessagesClient;
        }

        /// <summary> Initializes a new instance of RunsClient. </summary>
        internal virtual ThreadRunsClient GetThreadRunsClient()
        {
            return Volatile.Read(ref _cachedThreadRunsClient) ?? Interlocked.CompareExchange(ref _cachedThreadRunsClient, new ThreadRunsClient(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, _apiVersion), null) ?? _cachedThreadRunsClient;
        }

        /// <summary> Initializes a new instance of RunStepsClient. </summary>
        internal virtual ThreadRunStepsClient GetThreadRunStepsClient()
        {
            return Volatile.Read(ref _cachedThreadRunStepsClient) ?? Interlocked.CompareExchange(ref _cachedThreadRunStepsClient, new ThreadRunStepsClient(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, _apiVersion), null) ?? _cachedThreadRunStepsClient;
        }

        /// <summary> Initializes a new instance of FilesClient. </summary>
        internal virtual PersistentAgentsFilesClient GetPersistentAgentsFilesClient()
        {
            return Volatile.Read(ref _cachedPersistentAgentsFilesClient) ?? Interlocked.CompareExchange(ref _cachedPersistentAgentsFilesClient, new PersistentAgentsFilesClient(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, _apiVersion), null) ?? _cachedPersistentAgentsFilesClient;
        }

        /// <summary> Initializes a new instance of VectorStoresClient. </summary>
        internal virtual VectorStoresClient GetVectorStoresClient()
        {
            return Volatile.Read(ref _cachedVectorStoresClient) ?? Interlocked.CompareExchange(ref _cachedVectorStoresClient, new VectorStoresClient(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, _apiVersion), null) ?? _cachedVectorStoresClient;
        }

        /// <summary> Initializes a new instance of VectorStoreFilesClient. </summary>
        internal virtual VectorStoreFilesClient GetVectorStoreFilesClient()
        {
            return Volatile.Read(ref _cachedVectorStoreFilesClient) ?? Interlocked.CompareExchange(ref _cachedVectorStoreFilesClient, new VectorStoreFilesClient(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, _apiVersion), null) ?? _cachedVectorStoreFilesClient;
        }

        /// <summary> Initializes a new instance of VectorStoreFileBatchesClient. </summary>
        internal virtual VectorStoreFileBatchesClient GetVectorStoreFileBatchesClient()
        {
            return Volatile.Read(ref _cachedVectorStoreFileBatchesClient) ?? Interlocked.CompareExchange(ref _cachedVectorStoreFileBatchesClient, new VectorStoreFileBatchesClient(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, _apiVersion), null) ?? _cachedVectorStoreFileBatchesClient;
        }
    }
}
