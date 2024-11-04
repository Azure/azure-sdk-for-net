// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.AI.Inference;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.Projects
{
    /// <summary> The Inference sub-client. </summary>
    public partial class InferenceClient
    {
        private static readonly string[] AuthorizationScopes = new string[] { "https://management.azure.com/.default" };
        private readonly TokenCredential _tokenCredential;
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _subscriptionId;
        private readonly string _resourceGroupName;
        private readonly string _projectName;
        private readonly string _apiVersion;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal AIProjectClient AIProjectClient => new AIProjectClient(ClientDiagnostics, _pipeline, _tokenCredential, _endpoint, _subscriptionId, _resourceGroupName, _projectName);

        /// <summary> Initializes a new instance of ConnectionsClient for mocking. </summary>
        protected InferenceClient()
        {
        }

        /// <summary> Initializes a new instance of InferenceClient. </summary>
        /// <param name="connectionString">The Azure AI Studio project connection string, in the form `endpoint;subscription_id;resource_group_name;project_name`.</param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="connectionString"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="connectionString"/> </exception>
        public InferenceClient(string connectionString, TokenCredential credential) : this(connectionString, credential, new AIProjectClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of InferenceClient.
        /// </summary>
        /// <param name="connectionString">The Azure AI Studio project connection string, in the form `endpoint;subscription_id;resource_group_name;project_name`.</param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="connectionString"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="connectionString"/> is an empty string. </exception>
        public InferenceClient(string connectionString, TokenCredential credential, AIProjectClientOptions options)
             : this(new Uri(ClientHelper.ParseConnectionString(connectionString, "endpoint")),
                  ClientHelper.ParseConnectionString(connectionString, "subscriptionId"),
                  ClientHelper.ParseConnectionString(connectionString, "resourceGroupName"),
                  ClientHelper.ParseConnectionString(connectionString, "projectName"),
                  credential,
                  options)
        {
        }

        /// <summary> Initializes a new instance of InferenceClient. </summary>
        /// <param name="endpoint"> The Azure AI Studio project endpoint, in the form `https://&lt;azure-region&gt;.api.azureml.ms` or `https://&lt;private-link-guid&gt;.&lt;azure-region&gt;.api.azureml.ms`, where &lt;azure-region&gt; is the Azure region where the project is deployed (e.g. westus) and &lt;private-link-guid&gt; is the GUID of the Enterprise private link. </param>
        /// <param name="subscriptionId"> The Azure subscription ID. </param>
        /// <param name="resourceGroupName"> The name of the Azure Resource Group. </param>
        /// <param name="projectName"> The Azure AI Studio project name. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/>, <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="projectName"/> or <paramref name="credential"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="projectName"/> is an empty string, and was expected to be non-empty. </exception>
        public InferenceClient(Uri endpoint, string subscriptionId, string resourceGroupName, string projectName, TokenCredential credential) : this(endpoint, subscriptionId, resourceGroupName, projectName, credential, new AIProjectClientOptions())
        {
        }

        /// <summary> Initializes a new instance of InferenceClient. </summary>
        /// <param name="endpoint"> The Azure AI Studio project endpoint, in the form `https://&lt;azure-region&gt;.api.azureml.ms` or `https://&lt;private-link-guid&gt;.&lt;azure-region&gt;.api.azureml.ms`, where &lt;azure-region&gt; is the Azure region where the project is deployed (e.g. westus) and &lt;private-link-guid&gt; is the GUID of the Enterprise private link. </param>
        /// <param name="subscriptionId"> The Azure subscription ID. </param>
        /// <param name="resourceGroupName"> The name of the Azure Resource Group. </param>
        /// <param name="projectName"> The Azure AI Studio project name. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/>, <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="projectName"/> or <paramref name="credential"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="projectName"/> is an empty string, and was expected to be non-empty. </exception>
        public InferenceClient(Uri endpoint, string subscriptionId, string resourceGroupName, string projectName, TokenCredential credential, AIProjectClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new AIProjectClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _tokenCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new BearerTokenAuthenticationPolicy(_tokenCredential, AuthorizationScopes) }, new ResponseClassifier());
            _endpoint = endpoint;
            _subscriptionId = subscriptionId;
            _resourceGroupName = resourceGroupName;
            _projectName = projectName;
            _apiVersion = options.Version;
        }

        /// <summary> Initializes a new instance of InferenceClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="tokenCredential"> The token credential to copy. </param>
        /// <param name="endpoint"> The Azure AI Studio project endpoint, in the form `https://&lt;azure-region&gt;.api.azureml.ms` or `https://&lt;private-link-guid&gt;.&lt;azure-region&gt;.api.azureml.ms`, where &lt;azure-region&gt; is the Azure region where the project is deployed (e.g. westus) and &lt;private-link-guid&gt; is the GUID of the Enterprise private link. </param>
        /// <param name="subscriptionId"> The Azure subscription ID. </param>
        /// <param name="resourceGroupName"> The name of the Azure Resource Group. </param>
        /// <param name="projectName"> The Azure AI Studio project name. </param>
        /// <param name="apiVersion"> The API version to use for this operation. </param>
        internal InferenceClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, TokenCredential tokenCredential, Uri endpoint, string subscriptionId, string resourceGroupName, string projectName, string apiVersion)
        {
            ClientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
            _tokenCredential = tokenCredential;
            _endpoint = endpoint;
            _subscriptionId = subscriptionId;
            _resourceGroupName = resourceGroupName;
            _projectName = projectName;
            _apiVersion = apiVersion;
        }

        /// <summary> Initializes a new instance of Inference's ChatCompletionsClient. </summary>
        public virtual ChatCompletionsClient GetChatCompletionsClient()
        {
            var connectionsClient = AIProjectClient.GetConnectionsClient();
            ConnectionsListSecretsResponse connectionSecret = connectionsClient.GetDefaultConnection(ConnectionType.Serverless, true);

            if (connectionSecret.Properties is ConnectionPropertiesApiKeyAuth apiKeyAuthProperties)
            {
                if (string.IsNullOrWhiteSpace(apiKeyAuthProperties.Target))
                {
                    throw new ArgumentException("The API key authentication target URI is missing or invalid.");
                }

                if (!Uri.TryCreate(apiKeyAuthProperties.Target, UriKind.Absolute, out var endpoint))
                {
                    throw new UriFormatException("Invalid URI format in API key authentication target.");
                }

                var credential = new AzureKeyCredential(apiKeyAuthProperties.Credentials.Key);
                return new ChatCompletionsClient(endpoint, credential, new AzureAIInferenceClientOptions());
            }
            else
            {
                throw new ArgumentException("Cannot connect with Inference! Ensure valid ConnectionPropertiesApiKeyAuth.");
            }
        }

        /// <summary> Initializes a new instance of Inference's EmbeddingsClient. </summary>
        public virtual EmbeddingsClient GetEmbeddingsClient()
        {
            var connectionsClient = AIProjectClient.GetConnectionsClient();
            ConnectionsListSecretsResponse connectionSecret = connectionsClient.GetDefaultConnection(ConnectionType.Serverless, true);

            if (connectionSecret.Properties is ConnectionPropertiesApiKeyAuth apiKeyAuthProperties)
            {
                if (string.IsNullOrWhiteSpace(apiKeyAuthProperties.Target))
                {
                    throw new ArgumentException("The API key authentication target URI is missing or invalid.");
                }

                if (!Uri.TryCreate(apiKeyAuthProperties.Target, UriKind.Absolute, out var endpoint))
                {
                    throw new UriFormatException("Invalid URI format in API key authentication target.");
                }

                var credential = new AzureKeyCredential(apiKeyAuthProperties.Credentials.Key);
                return new EmbeddingsClient(endpoint, credential, new AzureAIInferenceClientOptions());
            }
            else
            {
                throw new ArgumentException("Cannot connect with Inference! Ensure valid ConnectionPropertiesApiKeyAuth.");
            }
        }
    }
}
