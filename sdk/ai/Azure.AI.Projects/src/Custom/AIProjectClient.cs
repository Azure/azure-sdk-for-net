// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

global using System.ClientModel;
global using System.ClientModel.Primitives;
global using System.ComponentModel;

using Azure.AI.Projects.OpenAI;

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
        private ProjectOpenAIClient _cachedOpenAIClient;
        private readonly TelemetryDetails _telemetryDetails;

        /// <summary> Initializes a new instance of AIProjectClient for mocking. </summary>
        protected AIProjectClient()
            : base(maxCacheSize: _defaultMaxCacheSize)
        {
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

            _apiVersion = options.Version;
            _endpoint = endpoint;
            _tokenProvider = tokenProvider;
            _telemetryDetails = new(typeof(AIProjectAgentsOperations).Assembly, options?.UserAgentApplicationId);

            PipelinePolicyHelpers.AddQueryParameterPolicy(options, "api-version", _apiVersion);
            PipelinePolicyHelpers.AddRequestHeaderPolicy(options, "User-Agent", _telemetryDetails.UserAgent.ToString());
            PipelinePolicyHelpers.AddRequestHeaderPolicy(options, "x-ms-client-request-id", () => Guid.NewGuid().ToString().ToLowerInvariant());
            PipelinePolicyHelpers.OpenAI.AddResponseItemInputTransformPolicy(options);
            PipelinePolicyHelpers.OpenAI.AddErrorTransformPolicy(options);
            PipelinePolicyHelpers.OpenAI.AddAzureFinetuningParityPolicy(options);

            Pipeline = ClientPipeline.Create(options, Array.Empty<PipelinePolicy>(), new PipelinePolicy[] { new BearerTokenPolicy(_tokenProvider, _flows) }, Array.Empty<PipelinePolicy>());

            _cacheManager = new ClientConnectionCacheManager(_endpoint, Pipeline, tokenProvider);
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

        /// <summary> Initializes a new instance of AIProjectConnectionsOperations. </summary>
        internal AIProjectConnectionsOperations GetAIProjectConnectionsOperationsClient()
        {
            return Volatile.Read(ref _cachedAIProjectConnectionsOperations) ?? Interlocked.CompareExchange(ref _cachedAIProjectConnectionsOperations, new AIProjectConnectionsOperations(Pipeline, _endpoint, _apiVersion), null) ?? _cachedAIProjectConnectionsOperations;
        }

        /// <summary> Initializes a new instance of AIProjectIndexesOperations. </summary>
        internal AIProjectIndexesOperations GetAIProjectIndexesOperationsClient()
        {
            return Volatile.Read(ref _cachedAIProjectIndexesOperations) ?? Interlocked.CompareExchange(ref _cachedAIProjectIndexesOperations, new AIProjectIndexesOperations(Pipeline, _endpoint, _apiVersion), null) ?? _cachedAIProjectIndexesOperations;
        }

        /// <summary> Initializes a new instance of AIProjectDeploymentsOperations. </summary>
        internal AIProjectDeploymentsOperations GetAIProjectDeploymentsOperationsClient()
        {
            return Volatile.Read(ref _cachedAIProjectDeploymentsOperations) ?? Interlocked.CompareExchange(ref _cachedAIProjectDeploymentsOperations, new AIProjectDeploymentsOperations(Pipeline, _endpoint, _apiVersion), null) ?? _cachedAIProjectDeploymentsOperations;
        }

        /// <summary> Initializes a new instance of AIProjectDatasetsOperations. </summary>
        internal AIProjectDatasetsOperations GetAIProjectDatasetsOperationsClient()
        {
            // Custom method to allow for passing of credential used when SAS is not provided.
            return Volatile.Read(ref _cachedAIProjectDatasetsOperations) ?? Interlocked.CompareExchange(ref _cachedAIProjectDatasetsOperations, new AIProjectDatasetsOperations(Pipeline, _endpoint, _apiVersion, _tokenProvider), null) ?? _cachedAIProjectDatasetsOperations;
        }

        internal ProjectOpenAIClient GetCachedOpenAIClient()
        {
            return Volatile.Read(ref _cachedOpenAIClient) ?? Interlocked.CompareExchange(ref _cachedOpenAIClient, this.GetProjectOpenAIClient(), null) ?? _cachedOpenAIClient;
        }

        /// <summary> Initializes a new instance of RedTeams. </summary>
        internal virtual RedTeams GetRedTeamsClient()
        {
            return Volatile.Read(ref _cachedRedTeams) ?? Interlocked.CompareExchange(ref _cachedRedTeams, new RedTeams(Pipeline, _endpoint, _apiVersion), null) ?? _cachedRedTeams;
        }

        /// <summary> Initializes a new instance of EvaluationRules. </summary>
        internal virtual EvaluationRules GetEvaluationRulesClient()
        {
            return Volatile.Read(ref _cachedEvaluationRules) ?? Interlocked.CompareExchange(ref _cachedEvaluationRules, new EvaluationRules(Pipeline, _endpoint, _apiVersion), null) ?? _cachedEvaluationRules;
        }

        /// <summary> Initializes a new instance of EvaluationTaxonomies. </summary>
        internal virtual EvaluationTaxonomies GetEvaluationTaxonomiesClient()
        {
            return Volatile.Read(ref _cachedEvaluationTaxonomies) ?? Interlocked.CompareExchange(ref _cachedEvaluationTaxonomies, new EvaluationTaxonomies(Pipeline, _endpoint, _apiVersion), null) ?? _cachedEvaluationTaxonomies;
        }

        /// <summary> Initializes a new instance of Evaluators. </summary>
        internal virtual Evaluators GetEvaluatorsClient()
        {
            return Volatile.Read(ref _cachedEvaluators) ?? Interlocked.CompareExchange(ref _cachedEvaluators, new Evaluators(Pipeline, _endpoint, _apiVersion), null) ?? _cachedEvaluators;
        }

        /// <summary> Initializes a new instance of Insights. </summary>
        internal virtual Insights GetInsightsClient()
        {
            return Volatile.Read(ref _cachedInsights) ?? Interlocked.CompareExchange(ref _cachedInsights, new Insights(Pipeline, _endpoint, _apiVersion), null) ?? _cachedInsights;
        }

        /// <summary> Initializes a new instance of Schedules. </summary>
        internal virtual Schedules GetSchedulesClient()
        {
            return Volatile.Read(ref _cachedSchedules) ?? Interlocked.CompareExchange(ref _cachedSchedules, new Schedules(Pipeline, _endpoint, _apiVersion), null) ?? _cachedSchedules;
        }

        /// <summary> Initializes a new instance of AIProjectAgentsOperations. </summary>
        internal virtual AIProjectAgentsOperations GetAIProjectAgentsOperationsClient()
        {
            return Volatile.Read(ref _cachedAIProjectAgentsOperations) ?? Interlocked.CompareExchange(ref _cachedAIProjectAgentsOperations, new AIProjectAgentsOperations(Pipeline, _endpoint, _apiVersion), null) ?? _cachedAIProjectAgentsOperations;
        }

        /// <summary> Initializes a new instance of AIProjectMemoryStoresOperations. </summary>
        internal virtual AIProjectMemoryStoresOperations GetAIProjectMemoryStoresOperationsClient()
        {
            return Volatile.Read(ref _cachedAIProjectMemoryStoresOperations) ?? Interlocked.CompareExchange(ref _cachedAIProjectMemoryStoresOperations, new AIProjectMemoryStoresOperations(Pipeline, _endpoint, _apiVersion), null) ?? _cachedAIProjectMemoryStoresOperations;
        }

        /// <summary> Gets the client for managing connections. </summary>
        public virtual AIProjectConnectionsOperations Connections { get => GetAIProjectConnectionsOperationsClient(); }
        /// <summary> Gets the client for managing datasets. </summary>
        public virtual AIProjectDatasetsOperations Datasets { get => GetAIProjectDatasetsOperationsClient(); }
        /// <summary> Gets the client for managing deployments. </summary>
        public virtual AIProjectDeploymentsOperations Deployments { get => GetAIProjectDeploymentsOperationsClient(); }
        /// <summary> Gets the client for managing indexes. </summary>
        public virtual AIProjectIndexesOperations Indexes { get => GetAIProjectIndexesOperationsClient(); }
        public virtual ProjectOpenAIClient OpenAI => GetCachedOpenAIClient();
        public virtual AIProjectAgentsOperations Agents => GetAIProjectAgentsOperationsClient();
        public virtual AIProjectMemoryStoresOperations MemoryStores => GetAIProjectMemoryStoresOperationsClient();
        public RedTeams RedTeams => GetRedTeamsClient();
        public EvaluationRules EvaluationRules => GetEvaluationRulesClient();
        public EvaluationTaxonomies EvaluationTaxonomies => GetEvaluationTaxonomiesClient();
        public Evaluators Evaluators => GetEvaluatorsClient();
        public Insights Insights => GetInsightsClient();
        public Schedules Schedules => GetSchedulesClient();
        /// <summary> Gets the client for telemetry operations. </summary>
        public virtual AIProjectTelemetry Telemetry { get => new AIProjectTelemetry(this); }

        private static PipelineMessageClassifier s_pipelineMessageClassifier;
        internal static PipelineMessageClassifier PipelineMessageClassifier
            => s_pipelineMessageClassifier ??= PipelineMessageClassifier.Create(stackalloc ushort[] { 200, 201 });
    }
}
