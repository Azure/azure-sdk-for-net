// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using Azure.AI.Inference;
using Azure.Core;

namespace Azure.AI.Projects
{
    // Data plane generated client.
    /// <summary> The AzureAI service client. </summary>
    public partial class AIProjectClient
    {
        /// <summary> Initializes a new instance of AzureAIClient. </summary>
        /// <param name="connectionString">The Azure AI Foundry project connection string, in the form `endpoint;subscription_id;resource_group_name;project_name`.</param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="connectionString"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="connectionString"/> </exception>
        public AIProjectClient(string connectionString, TokenCredential credential) : this(connectionString, credential, new AIProjectClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of AzureAIClient.
        /// </summary>
        /// <param name="connectionString">The Azure AI Foundry project connection string, in the form `endpoint;subscription_id;resource_group_name;project_name`.</param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="connectionString"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="connectionString"/> is an empty string. </exception>
        public AIProjectClient(string connectionString, TokenCredential credential, AIProjectClientOptions options)
             : this(new Uri(ClientHelper.ParseConnectionString(connectionString, "endpoint")),
                  ClientHelper.ParseConnectionString(connectionString, "subscriptionId"),
                  ClientHelper.ParseConnectionString(connectionString, "ResourceGroupName"),
                  ClientHelper.ParseConnectionString(connectionString, "ProjectName"),
                  credential,
                  options)
        {
        }

        private ChatCompletionsClient _chatCompletionsClient;
        private EmbeddingsClient _embeddingsClient;

        /// <summary> Initializes a new instance of Inference's ChatCompletionsClient. </summary>
        public virtual ChatCompletionsClient GetChatCompletionsClient()
        {
            return _chatCompletionsClient ??= InitializeInferenceClient((endpoint, credential) =>
                new ChatCompletionsClient(endpoint, credential, new AzureAIInferenceClientOptions()));
        }

        /// <summary> Initializes a new instance of Inference's EmbeddingsClient. </summary>
        public virtual EmbeddingsClient GetEmbeddingsClient()
        {
            return _embeddingsClient ??= InitializeInferenceClient((endpoint, credential) =>
                new EmbeddingsClient(endpoint, credential, new AzureAIInferenceClientOptions()));
        }

        /// <summary> Initializes a new instance of Inference client. </summary>
        private T InitializeInferenceClient<T>(Func<Uri, AzureKeyCredential, T> clientFactory)
        {
            var connectionsClient = GetConnectionsClient();

            // Back-door way to access the old behavior where each AI model (non-OpenAI) was hosted on
            // a separate "Serverless" connection. This is now deprecated.
            bool useServerlessConnection = Environment.GetEnvironmentVariable("USE_SERVERLESS_CONNECTION") == "true";
            ConnectionType connectionType = useServerlessConnection ? ConnectionType.Serverless : ConnectionType.AzureAIServices;

            ConnectionResponse connection = connectionsClient.GetDefaultConnection(connectionType, true);

            if (connection.Properties is ConnectionPropertiesApiKeyAuth apiKeyAuthProperties)
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
                if (!useServerlessConnection)
                {
                    // Be sure to use the Azure resource name here, not the connection name. Connection name is something that
                    // admins can pick when they manually create a new connection (or use bicep). Get the Azure resource name
                    // from the end of the connection id.
                    var azureResourceName = connection.Id.Split('/').Last();
                    endpoint = new Uri($"https://{azureResourceName}.services.ai.azure.com/models");
                }
                return clientFactory(endpoint, credential);
            }
            else
            {
                throw new ArgumentException("Cannot connect with Inference! Ensure valid ConnectionPropertiesApiKeyAuth.");
            }
        }
    }
}
