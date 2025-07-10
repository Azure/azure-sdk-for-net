// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Identity;

#pragma warning disable AZC0007

namespace Azure.AI.Projects
{
    // Data plane generated client.
    /// <summary> The AzureAI service client. </summary>
    public partial class AIProjectClient : ClientConnectionProvider
    {
        /// <summary> Initializes a new instance of AIProjectClient for mocking. </summary>
        protected AIProjectClient() : base(maxCacheSize: 100)
        {
        }

        /// <summary> Initializes a new instance of AIProjectClient. </summary>
        /// <param name="endpoint"> Service endpoint. </param>
        /// <param name="options"> The options for configuring the client. </param>
        internal AIProjectClient(Uri endpoint, AIProjectClientOptions options) : base(100)
        {
            options ??= new AIProjectClientOptions();

            _endpoint = endpoint;
            Pipeline = ClientPipeline.Create(options, Array.Empty<PipelinePolicy>(), Array.Empty<PipelinePolicy>(), Array.Empty<PipelinePolicy>());
            _apiVersion = options.Version;
        }

        // /// <summary> Initializes a new instance of AIProjectClient. </summary>
        // /// <param name="endpoint">
        // /// Project endpoint. In the form "https://&lt;your-ai-services-account-name&gt;.services.ai.azure.com/api/projects/_project"
        // /// if your Foundry Hub has only one Project, or to use the default Project in your Hub. Or in the form
        // /// "https://&lt;your-ai-services-account-name&gt;.services.ai.azure.com/api/projects/&lt;your-project-name&gt;" if you want to explicitly
        // /// specify the Foundry Project name.
        // /// </param>
        // /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        // public AIProjectClient(Uri endpoint) : this(endpoint, new DefaultAzureCredential(), new AIProjectClientOptions())
        // {
        // }

        /// <summary> Initializes a new instance of AIProjectClient. </summary>
        /// <param name="endpoint">
        /// Project endpoint. In the form "https://&lt;your-ai-services-account-name&gt;.services.ai.azure.com/api/projects/_project"
        /// if your Foundry Hub has only one Project, or to use the default Project in your Hub. Or in the form
        /// "https://&lt;your-ai-services-account-name&gt;.services.ai.azure.com/api/projects/&lt;your-project-name&gt;" if you want to explicitly
        /// specify the Foundry Project name.
        /// </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        public AIProjectClient(Uri endpoint, TokenCredential credential = null) : this(endpoint, credential, new AIProjectClientOptions())
        {
        }

        // /// <summary> Initializes a new instance of AIProjectClient. </summary>
        // /// <param name="endpoint"> Service endpoint. </param>
        // /// <param name="credential"> Service credential. </param>
        // internal AIProjectClient(Uri endpoint, TokenCredential credential) : this(endpoint, credential, new AIProjectClientOptions())
        // {
        // }

        /// <summary> Initializes a new instance of AIProjectClient. </summary>
        /// <param name="endpoint"> Service endpoint. </param>
        /// <param name="credential"> Service credential. </param>
        /// <param name="options"> The options for configuring the client. </param>
        public AIProjectClient(Uri endpoint, TokenCredential credential, AIProjectClientOptions options)
            : base(100) // Provide a default maxCacheSize, e.g., 100
        {
            options ??= new AIProjectClientOptions();

            _endpoint = endpoint;
            Pipeline = CreatePipeline(credential, options);
            _apiVersion = options.Version; // TODO: remember to change this back
            _tokenCredential = credential;

            _cacheManager = new ConnectionCacheManager(_endpoint, credential);
        }

        private readonly ConnectionCacheManager _cacheManager;
        private readonly TokenCredential _tokenCredential;
        private static readonly string[] AuthorizationScopes = new string[] { "https://ai.azure.com/.default" };

        // /// <summary> Initializes a new instance of AIProjectClient. </summary>
        // /// <param name="endpoint">
        // /// Project endpoint. In the form "https://&lt;your-ai-services-account-name&gt;.services.ai.azure.com/api/projects/_project"
        // /// if your Foundry Hub has only one Project, or to use the default Project in your Hub. Or in the form
        // /// "https://&lt;your-ai-services-account-name&gt;.services.ai.azure.com/api/projects/&lt;your-project-name&gt;" if you want to explicitly
        // /// specify the Foundry Project name.
        // /// </param>
        // /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        // /// <param name="options"> The options for configuring the client. </param>
        // /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        // public AIProjectClient(Uri endpoint, TokenCredential credential, AIProjectClientOptions options)
        //     : base(options.ClientCacheSize)
        // {
        //     Argument.AssertNotNull(endpoint, nameof(endpoint));
        //     Argument.AssertNotNull(credential, nameof(credential));
        //     options ??= new AIProjectClientOptions();

        //     // ClientDiagnostics = new ClientDiagnostics(options, true);
        //     var actualCredential = BuildCredential(credential);
        //     _tokenCredential = actualCredential;
        //     Pipeline = ClientPipeline.Create(options, Array.Empty<PipelinePolicy>(), Array.Empty<PipelinePolicy>(), Array.Empty<PipelinePolicy>());
        //     _endpoint = endpoint;

        //     _cacheManager = new ConnectionCacheManager(_endpoint, _tokenCredential);
        // }

        // // /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        // // internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary>
        /// Retrieves the connection options for a specified client type and instance ID.
        /// </summary>
        public override ClientConnection GetConnection(string connectionId) => _cacheManager.GetConnection(connectionId);

        /// <summary>
        /// Retrieves all connection options.
        /// </summary>
        public override IEnumerable<ClientConnection> GetAllConnections() => _cacheManager.GetAllConnections();

        // private static TokenCredential BuildCredential(TokenCredential credential)
        // {
        //     if (credential != null)
        //     {
        //         return credential;
        //     }

        //     string clientId = Environment.GetEnvironmentVariable("CLOUDMACHINE_MANAGED_IDENTITY_CLIENT_ID");

        //     return !string.IsNullOrEmpty(clientId)
        //         ? new ManagedIdentityCredential(clientId)
        //         : new ChainedTokenCredential(new AzureCliCredential(), new AzureDeveloperCliCredential());
        // }

        /// <summary> Initializes a new instance of Connections. </summary>
        public virtual Connections GetConnectionsClient()
        {
            return Volatile.Read(ref _cachedConnections) ?? Interlocked.CompareExchange(ref _cachedConnections, new Connections(Pipeline, _endpoint, _apiVersion), null) ?? _cachedConnections;
        }

        /// <summary> Initializes a new instance of Datasets. </summary>
        public virtual Datasets GetDatasetsClient()
        {
            return Volatile.Read(ref _cachedDatasets) ?? Interlocked.CompareExchange(ref _cachedDatasets, new Datasets(Pipeline, _endpoint, _apiVersion), null) ?? _cachedDatasets;
        }

        /// <summary> Initializes a new instance of Indexes. </summary>
        public virtual Indexes GetIndexesClient()
        {
            return Volatile.Read(ref _cachedIndexes) ?? Interlocked.CompareExchange(ref _cachedIndexes, new Indexes(Pipeline, _endpoint, _apiVersion), null) ?? _cachedIndexes;
        }

        /// <summary> Initializes a new instance of Deployments. </summary>
        public virtual Deployments GetDeploymentsClient()
        {
            return Volatile.Read(ref _cachedDeployments) ?? Interlocked.CompareExchange(ref _cachedDeployments, new Deployments(Pipeline, _endpoint, _apiVersion), null) ?? _cachedDeployments;
        }

        public Connections Connections { get => GetConnectionsClient(); }
        public Datasets Datasets { get => GetDatasetsClient(); }
        public Deployments Deployments { get => GetDeploymentsClient(); }
        public Indexes Indexes { get => GetIndexesClient(); }
        public Telemetry Telemetry { get => new Telemetry(this); }

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

        // private static PipelinePolicy CreateAddUserAgentHeaderPolicy(AIProjectClientOptions options = null)
        // {
        //     Core.TelemetryDetails telemetryDetails = new(typeof(AIProjectClient).Assembly, options?.UserAgentApplicationId);
        //     return new GenericActionPipelinePolicy(
        //         requestAction: request =>
        //         {
        //             if (request?.Headers?.TryGetValue(s_userAgentHeaderKey, out string _) == false)
        //             {
        //                 request.Headers.Set(s_userAgentHeaderKey, telemetryDetails.ToString());
        //             }
        //         });
        // }

        // private static PipelinePolicy CreateAddClientRequestIdHeaderPolicy()
        // {
        //     return new GenericActionPipelinePolicy(request =>
        //     {
        //         if (request?.Headers is not null)
        //         {
        //             string requestId = request.Headers.TryGetValue(s_clientRequestIdHeaderKey, out string existingHeader) == true
        //                 ? existingHeader
        //                 : Guid.NewGuid().ToString().ToLowerInvariant();
        //             request.Headers.Set(s_clientRequestIdHeaderKey, requestId);
        //         }
        //     });
        // }

        // private static readonly string s_userAgentHeaderKey = "User-Agent";
        // private static readonly string s_clientRequestIdHeaderKey = "x-ms-client-request-id";
        private static PipelineMessageClassifier s_pipelineMessageClassifier;
        internal static PipelineMessageClassifier PipelineMessageClassifier
            => s_pipelineMessageClassifier ??= PipelineMessageClassifier.Create(stackalloc ushort[] { 200, 201 });
    }
}
