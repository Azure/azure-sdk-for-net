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
        private readonly Uri _endpoint;
        private readonly ConcurrentDictionary<ConnectionType, Uri> _connectionCache = new();
        private readonly ConcurrentDictionary<string, ClientConnection> _connections = new();

        public ConnectionCacheManager(Uri endpoint, TokenCredential tokenCredential)
        {
            _endpoint = endpoint;
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
            var connection = _connectionCache.GetOrAdd(connectionType, _endpoint);

            if (string.IsNullOrWhiteSpace(_endpoint.AbsoluteUri))
            {
                throw new ArgumentException($"The AAD authentication target URI is missing or invalid for {connectionId}.");
            }

            var newConnection = new ClientConnection(connectionId, _endpoint.AbsoluteUri, _tokenCredential, CredentialKind.TokenCredential);
            return _connections.GetOrAdd(connectionId, newConnection);
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
                case "Azure.AI.Agents.Persistent.PersistentAgentsClient":
                case "OpenAI.Chat.ChatClient":
                case "OpenAI.Embeddings.EmbeddingClient":
                case "OpenAI.Images.ImageClient":
                    return ConnectionType.AzureOpenAI;

                // AzureAISearch
                case "Azure.Search.Documents.SearchClient":
                case "Azure.Search.Documents.Indexes.SearchIndexClient":
                case "Azure.Search.Documents.Indexes.SearchIndexerClient":
                    return ConnectionType.AzureAISearch;

                case "Azure.AI.Inference.ChatCompletionsClient":
                case "Azure.AI.Inference.EmbeddingsClient":
                case "Azure.AI.Inference.ImageEmbeddingsClient":
                    return new ConnectionType("Inference");

                default:
                    throw new ArgumentException($"Unknown connection type for ID: {connectionId}");
            }
        }
    }
}
