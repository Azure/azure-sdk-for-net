// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Azure.AI.Projects
{
    /// <summary>
    /// Manages connection caching and synchronization.
    /// </summary>
    internal class ClientConnectionCacheManager
    {
        private readonly ClientPipeline _pipeline;
        private readonly AuthenticationTokenProvider _tokenProvider;
        private readonly Uri _endpoint;
        private readonly ConcurrentDictionary<ConnectionType, Uri> _connectionCache = new();
        private readonly ConcurrentDictionary<string, ClientConnection> _connections = new();

        public ClientConnectionCacheManager(Uri endpoint, ClientPipeline pipeline, AuthenticationTokenProvider tokenProvider)
        {
            _pipeline = pipeline;
            _endpoint = endpoint;
            _tokenProvider = tokenProvider;
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

            ClientConnection? newConnection = null;

            if (connectionType == "DirectPipelinePassthrough")
            {
                newConnection = new(connectionId, _endpoint.AbsoluteUri.TrimEnd('/') + "/openai", _pipeline, CredentialKind.None);
            }
            else
            {
                newConnection = new(connectionId, _endpoint.AbsoluteUri, _tokenProvider, CredentialKind.TokenCredential);
            }

            return _connections.GetOrAdd(connectionId, newConnection.Value);
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

                case "Internal.DirectPipelinePassthrough":
                    return new("DirectPipelinePassthrough");

                default:
                    throw new ArgumentException($"Unknown connection type for ID: {connectionId}");
            }
        }
    }
}
