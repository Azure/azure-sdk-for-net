// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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

        private readonly ConnectionsClient _connectionsClient;

        private readonly Dictionary<ConnectionType, ConnectionResponse> _connectionCache = new();

        /// <summary>
        /// Initializes a new instance of the <see cref="AIFoundryClient"/> class for mocking purposes.
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

            Connections.Add(new ClientConnection(typeof(AIProjectClient).FullName, connectionString));

            _connectionsClient = new ConnectionsClient(connectionString, Credential);
        }

        /// <summary>
        /// Retrieves the connection options for a specified client type and instance ID.
        /// </summary>
        /// <param name="connectionId">The connection ID.</param>
        /// <returns>The connection options for the specified client type and instance ID.</returns>
        public override ClientConnection GetConnectionOptions(string connectionId)
        {
            // Check if the connection already exists
            if (Connections.Contains(connectionId))
            {
                return Connections[connectionId];
            }

            // Determine the connection type based on the connection ID
            ConnectionType connectionType = GetConnectionTypeFromId(connectionId);

            // Check if the connection details are already cached
            if (!_connectionCache.TryGetValue(connectionType, out ConnectionResponse connection))
            {
                connection = _connectionsClient.GetDefaultConnection(connectionType, true);
                _connectionCache[connectionType] = connection;
            }

            if (connection.Properties is ConnectionPropertiesApiKeyAuth apiKeyAuthProperties)
            {
                if (string.IsNullOrWhiteSpace(apiKeyAuthProperties.Target))
                {
                    throw new ArgumentException($"The API key authentication target URI is missing or invalid for {connectionId}.");
                }

                if (apiKeyAuthProperties.Credentials == null || string.IsNullOrWhiteSpace(apiKeyAuthProperties.Credentials.Key))
                {
                    throw new ArgumentException($"The API key is missing or invalid {connectionId}.");
                }

                Connections.Add(new ClientConnection(connectionId, apiKeyAuthProperties.Target, apiKeyAuthProperties.Credentials.Key));

                return Connections[connectionId];
            }
            else
            {
                throw new ArgumentException($"Cannot connect with {connectionId}! Ensure valid Api Key authentication.");
            }
        }

        private ConnectionType GetConnectionTypeFromId(string connectionId)
        {
            if (new[]
            {
                typeof(AzureOpenAIClient).FullName,
                typeof(ChatClient).FullName,
                typeof(EmbeddingClient).FullName
            }.Contains(connectionId))
            {
                return ConnectionType.AzureOpenAI;
            }
            else if (new[]
            {
                typeof(ChatCompletionsClient).FullName,
                typeof(EmbeddingsClient).FullName
            }.Contains(connectionId))
            {
                return ConnectionType.Serverless;
            }
            else if (new[]
            {
                typeof(SearchClient).FullName,
                typeof(SearchIndexClient).FullName,
                typeof(SearchIndexerClient).FullName
            }.Contains(connectionId))
            {
                return ConnectionType.AzureAISearch;
            }
            else
            {
                throw new ArgumentException($"Unknown connection type for ID: {connectionId}");
            }
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
