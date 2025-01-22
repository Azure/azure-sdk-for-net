// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.AI.Inference;
using Azure.AI.OpenAI;
using Azure.AI.Projects;
using Azure.Core;
using Azure.Identity;
using Azure.Search.Documents;
using Azure.Search.Documents.Indexes;
using OpenAI.Chat;
using OpenAI.Embeddings;

namespace Azure.CloudMachine
{
    /// <summary>
    /// The AI Foundry client.
    /// </summary>
    public class AIFoundryClient : ClientWorkspace
    {
        /// <summary>
        /// subclient connections.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ConnectionCollection Connections { get; } = [];

        /// <summary>
        /// Initializes a new instance of the <see cref="AIFoundryClient"/> class for mocking purposes..
        /// </summary>
        protected AIFoundryClient() : base(BuildCredential(default))
        {
        }

#pragma warning disable AZC0007 // DO provide a minimal constructor that takes only the parameters required to connect to the service.
        /// <summary>
        /// Initializes a new instance of the <see cref="AIFoundryClient"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string for the AI Foundry client.</param>
        /// <param name="credential">The token credential (optional).</param>
        public AIFoundryClient(string connectionString, TokenCredential credential = default)
#pragma warning restore AZC0007 // DO provide a minimal constructor that takes only the parameters required to connect to the service.
            : base(BuildCredential(credential))
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException("Connection string cannot be null or empty.", nameof(connectionString));
            }

            AddAIProjectsConnections(connectionString);

            // Add connections using AI Projects connections API
            ConnectionsClient connectionsClient = new ConnectionsClient(connectionString, Credential);
            AddInferenceConnection(connectionsClient);
            AddAzureOpenAIConnection(connectionsClient);
            AddAzureAISearchConnection(connectionsClient);
        }

        private void AddAIProjectsConnections(string connectionString)
        {
            Connections.Add(new ClientConnection(typeof(AgentsClient).FullName, connectionString));
            Connections.Add(new ClientConnection(typeof(EvaluationsClient).FullName, connectionString));
        }

        private void AddInferenceConnection(ConnectionsClient connectionsClient)
        {
            ConnectionResponse connection = connectionsClient.GetDefaultConnection(ConnectionType.Serverless, true);

            if (connection.Properties is ConnectionPropertiesApiKeyAuth apiKeyAuthProperties)
            {
                if (string.IsNullOrWhiteSpace(apiKeyAuthProperties.Target))
                {
                    throw new ArgumentException("The API key authentication target URI is missing or invalid.");
                }
                if (apiKeyAuthProperties.Credentials == null || string.IsNullOrWhiteSpace(apiKeyAuthProperties.Credentials.Key))
                {
                    throw new ArgumentException("The API key is missing or invalid.");
                }

                Connections.Add(new ClientConnection(typeof(ChatCompletionsClient).FullName, apiKeyAuthProperties.Target, apiKeyAuthProperties.Credentials.Key));
                Connections.Add(new ClientConnection(typeof(EmbeddingsClient).FullName, apiKeyAuthProperties.Target, apiKeyAuthProperties.Credentials.Key));
            }
            else
            {
                throw new ArgumentException("Cannot connect with Inference! Ensure valid Api Key authentication.");
            }
        }

        private void AddAzureOpenAIConnection(ConnectionsClient connectionsClient)
        {
            ConnectionResponse connection = connectionsClient.GetDefaultConnection(ConnectionType.AzureOpenAI, true);

            if (connection.Properties is ConnectionPropertiesApiKeyAuth apiKeyAuthProperties)
            {
                if (string.IsNullOrWhiteSpace(apiKeyAuthProperties.Target))
                {
                    throw new ArgumentException("The API key authentication target URI is missing or invalid.");
                }
                if (apiKeyAuthProperties.Credentials == null || string.IsNullOrWhiteSpace(apiKeyAuthProperties.Credentials.Key))
                {
                    throw new ArgumentException("The API key is missing or invalid.");
                }

                Connections.Add(new ClientConnection(id: typeof(AzureOpenAIClient).FullName, locator: apiKeyAuthProperties.Target, apiKey: apiKeyAuthProperties.Credentials.Key));
                Connections.Add(new ClientConnection(typeof(ChatClient).FullName, ""));
                Connections.Add(new ClientConnection(typeof(EmbeddingClient).FullName,""));
            }
            else
            {
                throw new ArgumentException("Cannot connect with Azure OpenAI! Ensure valid Api Key authentication.");
            }
        }

        private void AddAzureAISearchConnection(ConnectionsClient connectionsClient)
        {
            ConnectionResponse connection = connectionsClient.GetDefaultConnection(ConnectionType.AzureAISearch, true);

            if (connection.Properties is ConnectionPropertiesApiKeyAuth apiKeyAuthProperties)
            {
                if (string.IsNullOrWhiteSpace(apiKeyAuthProperties.Target))
                {
                    throw new ArgumentException("The API key authentication target URI is missing or invalid.");
                }
                if (apiKeyAuthProperties.Credentials == null || string.IsNullOrWhiteSpace(apiKeyAuthProperties.Credentials.Key))
                {
                    throw new ArgumentException("The API key is missing or invalid.");
                }

                Connections.Add(new ClientConnection(typeof(SearchClient).FullName, apiKeyAuthProperties.Target, apiKeyAuthProperties.Credentials.Key));
                Connections.Add(new ClientConnection(typeof(SearchIndexClient).FullName, apiKeyAuthProperties.Target, apiKeyAuthProperties.Credentials.Key));
                Connections.Add(new ClientConnection(typeof(SearchIndexerClient).FullName, apiKeyAuthProperties.Target, apiKeyAuthProperties.Credentials.Key));
            }
            else
            {
                throw new ArgumentException("Cannot connect with Inference! Ensure valid Api Key authentication.");
            }
        }

        /// <summary>
        /// Retrieves the connection options for a specified client type and instance ID.
        /// </summary>
        /// <param name="connectionId">The connection ID.</param>
        /// <returns>The connection options for the specified client type and instance ID.</returns>
        public override ClientConnection GetConnectionOptions(string connectionId)
        {
            return Connections[connectionId];
        }

        /// <summary>
        /// Retrieves all connection options.
        /// </summary>
        /// <returns>All connection options.</returns>
        public override IEnumerable<ClientConnection> GetAllConnectionOptions()
        {
            return Connections;
        }

        private static TokenCredential BuildCredential(TokenCredential credential)
        {
            if (credential == default)
            {
                credential = Environment.GetEnvironmentVariable("CLOUDMACHINE_MANAGED_IDENTITY_CLIENT_ID") switch
                {
                    string clientId when !string.IsNullOrEmpty(clientId) => new ManagedIdentityCredential(clientId),
                    _ => new ChainedTokenCredential(new AzureCliCredential(), new AzureDeveloperCliCredential())
                };
            }

            return credential;
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();
    }
}
