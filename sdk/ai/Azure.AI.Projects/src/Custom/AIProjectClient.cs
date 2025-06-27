// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Identity;

namespace Azure.AI.Projects
{
    // Data plane generated client.
    /// <summary> The AzureAI service client. </summary>
    public partial class AIProjectClient : ClientConnectionProvider
    {
        private readonly ConnectionCacheManager _cacheManager;

        /// <summary> Initializes a new instance of AIProjectClient for mocking. </summary>
        protected AIProjectClient() : base(maxCacheSize: 100)
        {
        }

        /// <summary> Initializes a new instance of AzureAIClient. </summary>
        /// <param name="endpoint">
        /// Project endpoint. In the form "https://&lt;your-ai-services-account-name&gt;.services.ai.azure.com/api/projects/_project"
        /// if your Foundry Hub has only one Project, or to use the default Project in your Hub. Or in the form
        /// "https://&lt;your-ai-services-account-name&gt;.services.ai.azure.com/api/projects/&lt;your-project-name&gt;" if you want to explicitly
        /// specify the Foundry Project name.
        /// </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        public AIProjectClient(Uri endpoint, TokenCredential credential = null) : this(endpoint, BuildCredential(credential), new AIProjectClientOptions())
        {
        }

        /// <summary> Initializes a new instance of AIProjectClient. </summary>
        /// <param name="endpoint">
        /// Project endpoint. In the form "https://&lt;your-ai-services-account-name&gt;.services.ai.azure.com/api/projects/_project"
        /// if your Foundry Hub has only one Project, or to use the default Project in your Hub. Or in the form
        /// "https://&lt;your-ai-services-account-name&gt;.services.ai.azure.com/api/projects/&lt;your-project-name&gt;" if you want to explicitly
        /// specify the Foundry Project name.
        /// </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public AIProjectClient(Uri endpoint, TokenCredential credential, AIProjectClientOptions options)
            : base(options.ClientCacheSize)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new AIProjectClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _tokenCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new BearerTokenAuthenticationPolicy(_tokenCredential, AuthorizationScopes) }, new ResponseClassifier());
            _endpoint = endpoint;

            _cacheManager = new ConnectionCacheManager(_endpoint, _tokenCredential);
        }

        /// <summary>
        /// Retrieves the connection options for a specified client type and instance ID.
        /// </summary>
        public override ClientConnection GetConnection(string connectionId) => _cacheManager.GetConnection(connectionId);

        /// <summary>
        /// Retrieves all connection options.
        /// </summary>
        public override IEnumerable<ClientConnection> GetAllConnections() => _cacheManager.GetAllConnections();

        private static TokenCredential BuildCredential(TokenCredential credential)
        {
            if (credential != null)
            {
                return credential;
            }

            string clientId = Environment.GetEnvironmentVariable("CLOUDMACHINE_MANAGED_IDENTITY_CLIENT_ID");

            return !string.IsNullOrEmpty(clientId)
                ? new ManagedIdentityCredential(clientId)
                : new ChainedTokenCredential(new AzureCliCredential(), new AzureDeveloperCliCredential());
        }

        /// <summary> Initializes a new instance of Connections. </summary>
        /// <param name="apiVersion"> The API version to use for this operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="apiVersion"/> is null. </exception>
        internal virtual Connections GetConnectionsClient(string apiVersion = "2025-05-15-preview")
        {
            Argument.AssertNotNull(apiVersion, nameof(apiVersion));

            return new Connections(ClientDiagnostics, _pipeline, _tokenCredential, _endpoint, apiVersion);
        }

        /// <summary> Initializes a new instance of Evaluations. </summary>
        /// <param name="apiVersion"> The API version to use for this operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="apiVersion"/> is null. </exception>
        internal virtual Evaluations GetEvaluationsClient(string apiVersion = "2025-05-15-preview")
        {
            Argument.AssertNotNull(apiVersion, nameof(apiVersion));

            return new Evaluations(ClientDiagnostics, _pipeline, _tokenCredential, _endpoint, apiVersion);
        }

        /// <summary> Initializes a new instance of Datasets. </summary>
        /// <param name="apiVersion"> The API version to use for this operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="apiVersion"/> is null. </exception>
        internal virtual Datasets GetDatasetsClient(string apiVersion = "2025-05-15-preview")
        {
            Argument.AssertNotNull(apiVersion, nameof(apiVersion));

            return new Datasets(ClientDiagnostics, _pipeline, _tokenCredential, _endpoint, apiVersion);
        }

        /// <summary> Initializes a new instance of Indexes. </summary>
        /// <param name="apiVersion"> The API version to use for this operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="apiVersion"/> is null. </exception>
        internal virtual Indexes GetIndexesClient(string apiVersion = "2025-05-15-preview")
        {
            Argument.AssertNotNull(apiVersion, nameof(apiVersion));

            return new Indexes(ClientDiagnostics, _pipeline, _tokenCredential, _endpoint, apiVersion);
        }

        /// <summary> Initializes a new instance of Deployments. </summary>
        /// <param name="apiVersion"> The API version to use for this operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="apiVersion"/> is null. </exception>
        internal virtual Deployments GetDeploymentsClient(string apiVersion = "2025-05-15-preview")
        {
            Argument.AssertNotNull(apiVersion, nameof(apiVersion));

            return new Deployments(ClientDiagnostics, _pipeline, _tokenCredential, _endpoint, apiVersion);
        }

        /// <summary> Initializes a new instance of RedTeams. </summary>
        /// <param name="apiVersion"> The API version to use for this operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="apiVersion"/> is null. </exception>
        internal virtual RedTeams GetRedTeamsClient(string apiVersion = "2025-05-15-preview")
        {
            Argument.AssertNotNull(apiVersion, nameof(apiVersion));

            return new RedTeams(ClientDiagnostics, _pipeline, _tokenCredential, _endpoint, apiVersion);
        }

        public Connections Connections { get => GetConnectionsClient(); }
        public Datasets Datasets { get => GetDatasetsClient(); }
        public Deployments Deployments { get => GetDeploymentsClient(); }
        public Evaluations Evaluations { get => GetEvaluationsClient(); }
        public Indexes Indexes { get => GetIndexesClient(); }
        public Telemetry Telemetry { get => new Telemetry(this); }
    }
}
