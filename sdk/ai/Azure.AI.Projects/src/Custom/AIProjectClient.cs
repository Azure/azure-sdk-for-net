// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
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

        /// <summary> Initializes a new instance of AIProjectClient for mocking. </summary>
        protected AIProjectClient() : base(maxCacheSize: _defaultMaxCacheSize)
        {
        }

        public AIProjectClient(Uri endpoint, AuthenticationTokenProvider tokenProvider) : this(endpoint, tokenProvider, new AIProjectClientOptions())
        {
        }

        public AIProjectClient(Uri endpoint, AuthenticationTokenProvider tokenProvider, AIProjectClientOptions options)
            : base(_defaultMaxCacheSize)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(tokenProvider, nameof(tokenProvider));

            options ??= new AIProjectClientOptions();

            _endpoint = endpoint;
            _tokenProvider = tokenProvider;
            Pipeline = ClientPipeline.Create(options, Array.Empty<PipelinePolicy>(), new PipelinePolicy[] { new BearerTokenPolicy(_tokenProvider, _flows) }, Array.Empty<PipelinePolicy>());
            _apiVersion = options.Version;
        }

        private readonly ConnectionCacheManager _cacheManager;
        private readonly TokenCredential _tokenCredential;
        private static readonly string[] AuthorizationScopes = ["https://ai.azure.com/.default"];

        /// <summary>
        /// Retrieves the connection options for a specified client type and instance ID.
        /// </summary>
        public override ClientConnection GetConnection(string connectionId) => _cacheManager.GetConnection(connectionId);

        /// <summary>
        /// Retrieves all connection options.
        /// </summary>
        public override IEnumerable<ClientConnection> GetAllConnections() => _cacheManager.GetAllConnections();

        public ConnectionsOperations Connections { get => GetConnectionsOperationsClient(); }
        public DatasetsOperations Datasets { get => GetDatasetsOperationsClient(); }
        public DeploymentsOperations Deployments { get => GetDeploymentsOperationsClient(); }
        public IndexesOperations Indexes { get => GetIndexesOperationsClient(); }
        public Telemetry Telemetry { get => new Telemetry(this); }
    }
}
