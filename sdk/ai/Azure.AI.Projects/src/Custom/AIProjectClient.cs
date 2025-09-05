// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using Azure.Core;

#pragma warning disable AZC0007

namespace Azure.AI.Projects
{
    // Data plane generated client.
    /// <summary> The AzureAI service client. </summary>
    public partial class AIProjectClient : ClientConnectionProvider
    {
        private const int _defaultMaxCacheSize = 100;
        private readonly ClientConnectionCacheManager _cacheManager;
        private static readonly string[] AuthorizationScopes = ["https://ai.azure.com/.default"];

        /// <summary> Initializes a new instance of AIProjectClient for mocking. </summary>
        protected AIProjectClient() : base(maxCacheSize: _defaultMaxCacheSize)
        {
        }

        /// <summary> Initializes a new instance of AIProjectClient. </summary>
        /// <param name="endpoint"> Service endpoint. </param>
        /// <param name="options"> The options for configuring the client. </param>
        internal AIProjectClient(Uri endpoint, AIProjectClientOptions options) : base(_defaultMaxCacheSize)
        {
            options ??= new AIProjectClientOptions();

            _endpoint = endpoint;
            Pipeline = ClientPipeline.Create(options, Array.Empty<PipelinePolicy>(), Array.Empty<PipelinePolicy>(), Array.Empty<PipelinePolicy>());
            _apiVersion = options.Version;
        }

        /// <summary> Initializes a new instance of AIProjectClient. </summary>
        /// <param name="endpoint"> Service endpoint. </param>
        /// <param name="tokenProvider"> A credential provider used to authenticate to the service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="tokenProvider"/> is null. </exception>
        public AIProjectClient(Uri endpoint, AuthenticationTokenProvider tokenProvider) : this(endpoint, tokenProvider, new AIProjectClientOptions())
        {
        }

        /// <summary> Initializes a new instance of AIProjectClient. </summary>
        /// <param name="endpoint"> Service endpoint. </param>
        /// <param name="tokenProvider"> A credential provider used to authenticate to the service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="tokenProvider"/> is null. </exception>
        public AIProjectClient(Uri endpoint, AuthenticationTokenProvider tokenProvider, AIProjectClientOptions options)
            : base(options.ClientCacheSize)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(tokenProvider, nameof(tokenProvider));

            options ??= new AIProjectClientOptions();

            _endpoint = endpoint;
            _tokenProvider = tokenProvider;
            Pipeline = ClientPipeline.Create(options, Array.Empty<PipelinePolicy>(), new PipelinePolicy[] { new BearerTokenPolicy(_tokenProvider, _flows) }, Array.Empty<PipelinePolicy>());
            _apiVersion = options.Version;

            _cacheManager = new ClientConnectionCacheManager(_endpoint, tokenProvider);
        }

        /// <summary>
        /// Retrieves the connection options for a specified client type and instance ID.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override ClientConnection GetConnection(string connectionId) => _cacheManager.GetConnection(connectionId);

        /// <summary>
        /// Retrieves all connection options.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override IEnumerable<ClientConnection> GetAllConnections() => _cacheManager.GetAllConnections();

        /// <summary> Initializes a new instance of AIProjectDatasetsOperations. </summary>
        public virtual AIProjectDatasetsOperations GetAIProjectDatasetsOperationsClient()
        {
            // Custom method to allow for passing of credential used when SAS is not provided.
            return Volatile.Read(ref _cachedAIProjectDatasetsOperations) ?? Interlocked.CompareExchange(ref _cachedAIProjectDatasetsOperations, new AIProjectDatasetsOperations(Pipeline, _endpoint, _apiVersion, _tokenProvider), null) ?? _cachedAIProjectDatasetsOperations;
        }

        /// <summary> Gets the client for managing connections. </summary>
        public virtual AIProjectConnectionsOperations Connections { get => GetAIProjectConnectionsOperationsClient(); }
        /// <summary> Gets the client for managing datasets. </summary>
        public virtual AIProjectDatasetsOperations Datasets { get => GetAIProjectDatasetsOperationsClient(); }
        /// <summary> Gets the client for managing deployments. </summary>
        public virtual AIProjectDeploymentsOperations Deployments { get => GetAIProjectDeploymentsOperationsClient(); }
        /// <summary> Gets the client for managing indexes. </summary>
        public virtual AIProjectIndexesOperations Indexes { get => GetAIProjectIndexesOperationsClient(); }
        /// <summary> Gets the client for telemetry operations. </summary>
        public virtual AIProjectTelemetry Telemetry { get => new AIProjectTelemetry(this); }

        private static ClientPipeline CreatePipeline(PipelinePolicy authenticationPolicy, AIProjectClientOptions options)
        => ClientPipeline.Create(
            options ?? new(),
            perCallPolicies:
            [
                // CreateAddUserAgentHeaderPolicy(options),
                // CreateAddClientRequestIdHeaderPolicy(),
            ],
            perTryPolicies:
            [
                authenticationPolicy,
            ],
            beforeTransportPolicies: []);

        internal static ClientPipeline CreatePipeline(ApiKeyCredential credential, AIProjectClientOptions options = null)
        {
            Argument.AssertNotNull(credential, nameof(credential));
            return CreatePipeline(ApiKeyAuthenticationPolicy.CreateHeaderApiKeyPolicy(credential, "api-key"), options);
        }

        internal static ClientPipeline CreatePipeline(TokenCredential credential, AIProjectClientOptions options = null)
        {
            Argument.AssertNotNull(credential, nameof(credential));
            return CreatePipeline(new AzureTokenAuthenticationPolicy(credential, AuthorizationScopes), options);
        }

        private static PipelineMessageClassifier s_pipelineMessageClassifier;
        internal static PipelineMessageClassifier PipelineMessageClassifier
            => s_pipelineMessageClassifier ??= PipelineMessageClassifier.Create(stackalloc ushort[] { 200, 201 });
    }
}
