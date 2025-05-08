// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Concurrent;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System;
using Azure.Core;
using System.Linq;

namespace Azure.AI.Projects
{
    /// <summary>
    /// Manages connection caching and synchronization.
    /// </summary>
    internal class ConnectionCacheManager
    {
        private readonly TokenCredential _tokenCredential;
        private readonly Connections _connectionsClient;
        private readonly ConcurrentDictionary<ConnectionType, Connection> _connectionCache = new();
        private readonly ConcurrentDictionary<string, ClientConnection> _connections = new();

        public ConnectionCacheManager(Connections connectionsClient, TokenCredential tokenCredential)
        {
            _connectionsClient = connectionsClient;
            _tokenCredential = tokenCredential;
        }

        /// <summary>
        /// Retrieves the connection for a given connection ID.
        /// </summary>
        public ClientConnection GetConnection(string connectionId)
        {
            if (_connections.TryGetValue(connectionId, out var existingConnection))
            {
                return existingConnection;
            }

            var connectionType = GetConnectionTypeFromId(connectionId);
            var connection = _connectionCache.GetOrAdd(connectionType, type =>
                _connectionsClient.GetConnections(type, true).FirstOrDefault());

            if (connection.Credentials.Type == CredentialType.ApiKey)
            {
                if (string.IsNullOrWhiteSpace(connection.Target))
                {
                    throw new ArgumentException($"The API key authentication target URI is missing or invalid for {connectionId}.");
                }

                ApiKeyCredentials apiKeyCredentials = connection.Credentials as ApiKeyCredentials;

                if (apiKeyCredentials.ApiKey is null or { Length: 0 })
                {
                    throw new ArgumentException($"The API key is missing or invalid for {connectionId}.");
                }

                var newConnection = new ClientConnection(connectionId, connection.Target, apiKeyCredentials.ApiKey, CredentialKind.ApiKeyString);
                return _connections.GetOrAdd(connectionId, newConnection);
            }
            else if (connection.Credentials.Type == CredentialType.EntraId)
            {
                if (string.IsNullOrWhiteSpace(connection.Target))
                {
                    throw new ArgumentException($"The AAD authentication target URI is missing or invalid for {connectionId}.");
                }

                var newConnection = new ClientConnection(connectionId, connection.Target, _tokenCredential, CredentialKind.TokenCredential);
                return _connections.GetOrAdd(connectionId, newConnection);
            }

            throw new ArgumentException($"Cannot connect with {connectionId}! Unknown authentication type.");
        }

        /// <summary>
        /// Retrieves all stored connections.
        /// </summary>
        public IEnumerable<ClientConnection> GetAllConnections() => _connections.Values;

        /// <summary>
        /// Determines the connection type from the connection ID.
        /// </summary>
        private ConnectionType GetConnectionTypeFromId(string connectionId)
        {
            switch (connectionId)
            {
                // AzureOpenAI
                case "Azure.AI.OpenAI.AzureOpenAIClient":
                case "Azure.AI.Agents.Persistent":
                case "OpenAI.Chat.ChatClient":
                case "OpenAI.Embeddings.EmbeddingClient":
                    return ConnectionType.AzureOpenAI;

                // AzureAISearch
                case "Azure.Search.Documents.SearchClient":
                case "Azure.Search.Documents.Indexes.SearchIndexClient":
                case "Azure.Search.Documents.Indexes.SearchIndexerClient":
                    return ConnectionType.AzureAISearch;

                default:
                    throw new ArgumentException($"Unknown connection type for ID: {connectionId}");
            }
        }
    }
}
