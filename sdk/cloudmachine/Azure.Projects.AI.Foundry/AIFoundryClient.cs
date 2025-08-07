// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using Azure.AI.Projects;
using Azure.Core;
using Azure.Identity;

namespace Azure.Projects.Foundry
{
    /// <summary>
    /// The AI Foundry client.
    /// </summary>
    public class AIFoundryClient : ConnectionProvider
    {
        /// <summary>
        /// Protects the <see cref="Connections"/> collection from concurrent access. Separated from <see cref="_connectionCacheLock"/> to reduce contention.
        /// </summary>
        private readonly ReaderWriterLockSlim _connectionsLock = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);

        /// <summary>
        /// Protects the <see cref="_connectionCache"/> dictionary from concurrent access. Separated from <see cref="_connectionsLock"/> to improve concurrency in read-heavy scenarios.
        /// </summary>
        private readonly ReaderWriterLockSlim _connectionCacheLock = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);

        private readonly TokenCredential Credential = BuildCredential(default);

        /// <summary>
        /// Subclient connections.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ConnectionCollection Connections { get; } = [];

        private readonly ConnectionsClient _connectionsClient;

        private readonly Dictionary<ConnectionType, ConnectionResponse> _connectionCache = new();

        /// <summary>
        /// Initializes a new instance of the <see cref="AIFoundryClient"/> class for mocking purposes.
        /// </summary>
        protected AIFoundryClient()
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
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException("Connection string cannot be null or empty.", nameof(connectionString));
            }

            // Initialize with a basic connection for AIProjectClient.
            Connections.Add(new ClientConnection(typeof(AIProjectClient).FullName, connectionString));
            _connectionsClient = new ConnectionsClient(connectionString, Credential);
        }

        /// <summary>
        /// Retrieves the connection options for a specified client type and instance ID.
        /// </summary>
        /// <param name="connectionId">The connection ID.</param>
        /// <returns>The connection options for the specified client type and instance ID.</returns>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override ClientConnection GetConnection(string connectionId)
        {
            // First, try to read from the Connections collection with a read lock.
            _connectionsLock.EnterReadLock();
            try
            {
                if (Connections.Contains(connectionId))
                {
                    return Connections[connectionId];
                }
            }
            finally
            {
                _connectionsLock.ExitReadLock();
            }

            // Get the connection type based on the Connection ID.
            ConnectionType connectionType = GetConnectionTypeFromId(connectionId);

            // Check if the connection details are already cached (read lock).
            ConnectionResponse connection = null;
            _connectionCacheLock.EnterReadLock();
            try
            {
                _connectionCache.TryGetValue(connectionType, out connection);
            }
            finally
            {
                _connectionCacheLock.ExitReadLock();
            }

            // If not in cache, acquire a write lock to populate it.
            if (connection == null)
            {
                _connectionCacheLock.EnterWriteLock();
                try
                {
                    // Double-check in case another thread already added it.
                    if (!_connectionCache.TryGetValue(connectionType, out connection))
                    {
                        connection = _connectionsClient.GetDefaultConnection(connectionType, true);
                        _connectionCache[connectionType] = connection;
                    }
                }
                finally
                {
                    _connectionCacheLock.ExitWriteLock();
                }
            }

            // If the connection uses API key auth, validate and add if needed.
            if (connection.Properties is ConnectionPropertiesApiKeyAuth apiKeyAuthProperties)
            {
                if (string.IsNullOrWhiteSpace(apiKeyAuthProperties.Target))
                {
                    throw new ArgumentException(
                        $"The API key authentication target URI is missing or invalid for {connectionId}.");
                }

                if (apiKeyAuthProperties.Credentials == null
                    || string.IsNullOrWhiteSpace(apiKeyAuthProperties.Credentials.Key))
                {
                    throw new ArgumentException($"The API key is missing or invalid for {connectionId}.");
                }

                // Build the new connection object.
                var newConnection = new ClientConnection(connectionId, apiKeyAuthProperties.Target, apiKeyAuthProperties.Credentials.Key);

                // Now we need to re-check and possibly add to Connections under a write lock.
                _connectionsLock.EnterUpgradeableReadLock();
                try
                {
                    if (Connections.Contains(connectionId))
                    {
                        return Connections[connectionId];
                    }
                    else
                    {
                        _connectionsLock.EnterWriteLock();
                        try
                        {
                            // Double-check again after acquiring write lock.
                            if (!Connections.Contains(connectionId))
                            {
                                Connections.Add(newConnection);
                                return newConnection;
                            }
                            else
                            {
                                return Connections[connectionId]; // Some thread beat us to it.
                            }
                        }
                        finally
                        {
                            _connectionsLock.ExitWriteLock();
                        }
                    }
                }
                finally
                {
                    _connectionsLock.ExitUpgradeableReadLock();
                }
            }
            else
            {
                throw new ArgumentException(
                    $"Cannot connect with {connectionId}! Ensure valid API key authentication."
                );
            }
        }

        /// <summary>
        /// /// Rerurns all connections.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override IEnumerable<ClientConnection> GetAllConnections()
        {
            _connectionsLock.EnterReadLock();
            try
            {
                return Connections;
            }
            finally
            {
                _connectionsLock.ExitReadLock();
            }
        }

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
