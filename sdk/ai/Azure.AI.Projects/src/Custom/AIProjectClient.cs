// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.AI.Inference;
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

        #nullable enable
        public ChatCompletionsClient GetChatCompletionsClient()
        {
            ChatCompletionsClientKey chatCompletionsClientKey = new();
            ChatCompletionsClient chatClient = this.Subclients.GetClient(chatCompletionsClientKey, () => CreateChatCompletionsClient());
            return chatClient;
        }

        private ChatCompletionsClient CreateChatCompletionsClient()
        {
            ClientConnection connection = this.GetConnection(typeof(ChatCompletionsClient).FullName!);

            if (!connection.TryGetLocatorAsUri(out Uri? uri) || uri is null)
            {
                throw new InvalidOperationException("Invalid URI.");
            }

            AzureAIInferenceClientOptions options = new AzureAIInferenceClientOptions();
            // OverrideApiVersionPolicy overrideApiVersionPolicy = new OverrideApiVersionPolicy(AIProjectClientOptions.ServiceVersion.V2025_05_15_Preview.ToString());
            OverrideApiVersionPolicy overrideApiVersionPolicy = new OverrideApiVersionPolicy("2024-05-01-preview");

            options.AddPolicy(overrideApiVersionPolicy, HttpPipelinePosition.PerRetry);
            BearerTokenAuthenticationPolicy tokenPolicy = new BearerTokenAuthenticationPolicy((TokenCredential)connection.Credential!, AuthorizationScopes);
            options.AddPolicy(tokenPolicy, HttpPipelinePosition.PerRetry);

            return connection.CredentialKind switch
            {
                CredentialKind.ApiKeyString => new ChatCompletionsClient(uri, new AzureKeyCredential((string)connection.Credential!)),
                CredentialKind.TokenCredential => new ChatCompletionsClient(uri, (TokenCredential)connection.Credential!, options),
                _ => throw new InvalidOperationException($"Unsupported credential kind: {connection.CredentialKind}")
            };
        }

        private record ChatCompletionsClientKey();

        private class OverrideApiVersionPolicy : HttpPipelinePolicy
        {
            private string ApiVersion { get; }

            public OverrideApiVersionPolicy(string apiVersion)
            {
                ApiVersion = apiVersion;
            }

            public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            {
                message.Request.Uri.Query = $"?api-version={ApiVersion}";
                ProcessNext(message, pipeline);
            }

            public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            {
                message.Request.Uri.Query = $"?api-version={ApiVersion}";
                var task = ProcessNextAsync(message, pipeline);

                return task;
            }
        }
#nullable disable

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
    }
}
