// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Concurrent;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System;
using Azure.Core;

namespace Azure.AI.Projects
{
    /// <summary>
    /// Manages connection caching and synchronization.
    /// </summary>
    internal class ConnectionCacheManager
    {
        private readonly TokenCredential _tokenCredential;
        private readonly ConnectionsClient _connectionsClient;
        private readonly ConcurrentDictionary<ConnectionType, ConnectionResponse> _connectionCache = new();
        private readonly ConcurrentDictionary<string, ClientConnection> _connections = new();

        public ConnectionCacheManager(ConnectionsClient connectionsClient, TokenCredential tokenCredential)
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

            ConnectionType connectionType = GetConnectionTypeFromId(connectionId);
            ConnectionResponse connection = _connectionCache.GetOrAdd(connectionType, type =>
                _connectionsClient.GetDefaultConnection(type, true));
            ClientConnection newConnection = GetConnection(connection, connectionId, false).Value;
            return _connections.GetOrAdd(connectionId, newConnection);
        }

        private ClientConnection? GetConnection(ConnectionResponse connection, string connectionId, bool skipBroken)
        {
            if (connection.Properties.AuthType == AuthenticationType.ApiKey)
            {
                ConnectionPropertiesApiKeyAuth apiKeyAuthProperties = connection.Properties as ConnectionPropertiesApiKeyAuth;
                if (string.IsNullOrWhiteSpace(apiKeyAuthProperties.Target))
                {
                    return returnNullOrThrow($"The API key authentication target URI is missing or invalid for {connectionId}.", skipBroken);
                }

                if (apiKeyAuthProperties.Credentials?.Key is null or { Length: 0 })
                {
                    return returnNullOrThrow($"The API key is missing or invalid for {connectionId}.", skipBroken);
                }

                return new ClientConnection(connectionId, CorrectUriMayBe(apiKeyAuthProperties.Target, connection.Properties.Category), apiKeyAuthProperties.Credentials.Key);
            }
            else if (connection.Properties.AuthType == AuthenticationType.EntraId)
            {
                InternalConnectionPropertiesAADAuth aadAuthProperties = connection.Properties as InternalConnectionPropertiesAADAuth;
                if (string.IsNullOrWhiteSpace(aadAuthProperties.Target))
                {
                    return returnNullOrThrow($"The AAD authentication target URI is missing or invalid for {connectionId}.", skipBroken);
                }

                return new ClientConnection(connectionId, CorrectUriMayBe(aadAuthProperties.Target, connection.Properties.Category), _tokenCredential);
            }

            throw new ArgumentException($"Cannot connect with {connectionId}! Unknown authentication type.");
        }

        private static ClientConnection? returnNullOrThrow(string exceptionString, bool skip)
        {
            if (skip)
            {
                return null;
            }
            throw new ArgumentException(exceptionString);
        }

        private static string CorrectUriMayBe(string uri, ConnectionType connType)
        {
            return  connType == ConnectionType.AzureAIServices ? uri + "models/" : uri;
        }

        /// <summary>
        /// Retrieves all connections.
        /// </summary>
        public IEnumerable<ClientConnection> GetAllConnections()
        {
            List<ClientConnection> lstConnections = [];
            ListConnectionsResponse resp = _connectionsClient.GetConnections();
            foreach (ConnectionResponse conn in resp.Value)
            {
                ConnectionResponse connWithSecrets = _connectionsClient.GetConnectionWithSecrets(
                    connectionName: conn.Name,
                    ignored: "true");
                ClientConnection? clientConn = GetConnection(connWithSecrets, conn.Name, true);
                if (clientConn.HasValue)
                    lstConnections.Add(clientConn.Value);
            }
            return lstConnections;
        }

        /// <summary>
        /// Determines the connection type from the connection ID.
        /// </summary>
        private static ConnectionType GetConnectionTypeFromId(string connectionId)
        {
            switch (connectionId)
            {
                // AzureOpenAI
                case "Azure.AI.OpenAI.AzureOpenAIClient":
                case "OpenAI.Chat.ChatClient":
                case "OpenAI.Embeddings.EmbeddingClient":
                    return ConnectionType.AzureOpenAI;

                // Inference
                case "Azure.AI.Inference.ChatCompletionsClient":
                case "Azure.AI.Inference.EmbeddingsClient":
                    return ConnectionType.AzureAIServices;

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
