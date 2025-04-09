// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading;
using Azure.AI.Projects;
using Azure.Core;

namespace Azure.Projects.AIFoundry
{
    /// <summary>
    /// Provides concurrency-safe caching of Foundry connection responses
    /// and transforms them into <see cref="ClientConnection"/> objects.
    /// </summary>
    internal class AIFoundryConnections
    {
        private readonly ConnectionsClient _connectionsClient;
        private readonly ReaderWriterLockSlim _cacheLock = new(LockRecursionPolicy.NoRecursion);
        private readonly Dictionary<ConnectionType, ConnectionResponse> _connectionCache = new();

        /// <summary>
        /// Creates a new <see cref="AIFoundryConnections"/> that uses the specified
        /// Foundry connection string and token credential for authentication.
        /// </summary>
        /// <param name="foundryConnectionString">The Foundry connection string.</param>
        /// <param name="credential">The token credential to use for authentication.</param>
        public AIFoundryConnections(string foundryConnectionString, TokenCredential credential)
        {
            _connectionsClient = new ConnectionsClient(foundryConnectionString, credential);
        }

        /// <summary>
        /// Returns a <see cref="ClientConnection"/> for the specified connectionId,
        /// retrieving or caching it from the Foundry <see cref="ConnectionsClient"/>.
        /// </summary>
        /// <param name="connectionId">The well-known ID of the Foundry connection.</param>
        /// <returns>A <see cref="ClientConnection"/> representing the Foundry resource.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown if the Foundry connection is not found, or if it doesn’t use a valid API key auth.
        /// </exception>
        public ClientConnection GetConnection(string connectionId)
        {
            // 1) Get ConnectionType
            ConnectionType connectionType = GetConnectionTypeFromId(connectionId);

            // 2) Check cache
            ConnectionResponse response;
            _cacheLock.EnterReadLock();
            try
            {
                _connectionCache.TryGetValue(connectionType, out response);
            }
            finally
            {
                _cacheLock.ExitReadLock();
            }

            // 3) If not cached, retrieve from Foundry
            if (response == null)
            {
                _cacheLock.EnterWriteLock();
                try
                {
                    if (!_connectionCache.TryGetValue(connectionType, out response))
                    {
                        response = _connectionsClient.GetDefaultConnection(connectionType, true);
                        _connectionCache[connectionType] = response;
                    }
                }
                finally
                {
                    _cacheLock.ExitWriteLock();
                }
            }

            // 4) Validate response, build a ClientConnection
            if (response.Properties is ConnectionPropertiesApiKeyAuth apiKeyAuth)
            {
                if (string.IsNullOrWhiteSpace(apiKeyAuth.Target))
                {
                    throw new ArgumentException($"The API key target URI is missing or invalid for '{connectionId}'.");
                }
                if (apiKeyAuth.Credentials?.Key is null or { Length: 0 })
                {
                    throw new ArgumentException($"The API key is missing or invalid for '{connectionId}'.");
                }

                return new ClientConnection(connectionId, apiKeyAuth.Target, apiKeyAuth.Credentials.Key);
            }
            else
            {
                throw new ArgumentException(
                    $"Connection '{connectionId}' does not use valid API key authentication."
                );
            }
        }

        /// <summary>
        /// Converts a Foundry-style connection ID into an enum <see cref="ConnectionType"/>.
        /// </summary>
        /// <param name="connectionId">The known string ID (e.g. "Azure.AI.OpenAI.AzureOpenAIClient").</param>
        /// <returns>A <see cref="ConnectionType"/> indicating which Foundry connection to retrieve.</returns>
        /// <exception cref="ArgumentException">Thrown if the <paramref name="connectionId"/> is unknown.</exception>
        private ConnectionType GetConnectionTypeFromId(string connectionId)
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
                    return ConnectionType.Serverless;

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
