// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using Azure.AI.Projects;
using Azure.Core;
using Azure.Identity;
using Microsoft.Extensions.Configuration;

namespace Azure.CloudMachine;

/// <summary>
/// The cloud machine client.
/// </summary>
public partial class CloudMachineClient : ClientWorkspace
{
    /// <summary>
    /// The cloud machine ID.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string Id { get; }

    /// <summary>
    /// subclient connections.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public ConnectionCollection Connections { get; } = [];

    private readonly ReaderWriterLockSlim _connectionsLock = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);
    private readonly ReaderWriterLockSlim _connectionCacheLock = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);
    private readonly Dictionary<ConnectionType, ConnectionResponse> _connectionCache = new Dictionary<ConnectionType, ConnectionResponse>();
    private ConnectionsClient _foundryConnectionsClient;

    /// <summary>
    /// Initializes a new instance of the <see cref="CloudMachineClient"/> class for mocking purposes..
    /// </summary>
    protected CloudMachineClient() :
        this(credential: BuildCredential(default))
    {
        Id = AppConfigHelpers.ReadOrCreateCloudMachineId();
        Messaging = new MessagingServices(this);
        Storage = new StorageServices(this);
    }

#pragma warning disable AZC0007 // DO provide a minimal constructor that takes only the parameters required to connect to the service.
    /// <summary>
    /// Initializes a new instance of the <see cref="CloudMachineClient"/> class.
    /// </summary>
    /// <param name="configuration">The configuration settings.</param>
    /// <param name="credential">The token credential.</param>
    public CloudMachineClient(IConfiguration configuration, TokenCredential credential = default)
#pragma warning restore AZC0007 // DO provide a minimal constructor that takes only the parameters required to connect to the service.
        : base(BuildCredential(credential))
    {
        Id = configuration["CloudMachine:ID"];
        if (Id == null)
        {
            Id = AppConfigHelpers.ReadOrCreateCloudMachineId();
        }

        IConfigurationSection connectionsSection = configuration.GetSection("CloudMachine:Connections");

        foreach (IConfigurationSection connection in connectionsSection.GetChildren())
        {
            string id = connection["Id"];
            if (id == null) continue;
            string locator = connection["Locator"];

            Connections.Add(new ClientConnection(id, locator, ClientAuthenticationMethod.EntraId));
        }

        if (Connections.Contains(typeof(AIProjectClient).FullName))
        {
            ClientConnection connection = Connections[typeof(AIProjectClient).FullName];
            _foundryConnectionsClient = new ConnectionsClient(connection.Locator, Credential);
        }

        Messaging = new MessagingServices(this);
        Storage = new StorageServices(this);
    }

#pragma warning disable AZC0007 // DO provide a minimal constructor that takes only the parameters required to connect to the service.
    /// <summary>
    /// Initializes a new instance of the <see cref="CloudMachineClient"/> class.
    /// </summary>
    /// <param name="connections"></param>
    /// <param name="credential">The token credential.</param>
    // TODO: we need to combine the configuration and the connections into a single parameter.
    public CloudMachineClient(IEnumerable<ClientConnection> connections = default, TokenCredential credential = default)
#pragma warning restore AZC0007 // DO provide a minimal constructor that takes only the parameters required to connect to the service.
        : base(BuildCredential(credential))
    {
        if (connections != default)
        {
            Connections.AddRange(connections);
        }

        if (Connections.Contains(typeof(AIProjectClient).FullName))
        {
            ClientConnection connection = Connections[typeof(AIProjectClient).FullName];
            _foundryConnectionsClient = new ConnectionsClient(connection.Locator, Credential);
        }
        Id = AppConfigHelpers.ReadOrCreateCloudMachineId();
        Messaging = new MessagingServices(this);
        Storage = new StorageServices(this);
    }

    /// <summary>
    /// Gets the messaging services.
    /// </summary>
    public MessagingServices Messaging { get; }

    /// <summary>
    /// Gets the storage services.
    /// </summary>
    public StorageServices Storage { get; }

    /// <summary>
    /// Retrieves the connection options for a specified client type and instance ID.
    /// </summary>
    /// <param name="connectionId"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override ClientConnection GetConnectionOptions(string connectionId)
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

        if (_foundryConnectionsClient == null)
        {
            throw new InvalidOperationException(
                $"Connection '{connectionId}' not found locally, and no Foundry client is configured."
            );
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
                    connection = _foundryConnectionsClient.GetDefaultConnection(connectionType, true);
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
            // This environment variable is set by the CloudMachine App Service feature during provisioning.
            credential = Environment.GetEnvironmentVariable("CLOUDMACHINE_MANAGED_IDENTITY_CLIENT_ID") switch
            {
                string clientId when !string.IsNullOrEmpty(clientId) => new ManagedIdentityCredential(clientId),
                _ => new ChainedTokenCredential(new AzureCliCredential(), new AzureDeveloperCliCredential())
            };
        }

        return credential;
    }

    /// <summary>
    /// Reads or creates the cloud machine ID.
    /// </summary>
    /// <returns></returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static string ReadOrCreateCloudMachineId() => AppConfigHelpers.ReadOrCreateCloudMachineId();

    /// <inheritdoc/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override bool Equals(object obj) => base.Equals(obj);

    /// <inheritdoc/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override int GetHashCode() => base.GetHashCode();

    /// <inheritdoc/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override string ToString() => Id;

    /// <summary>
    /// Retrieves all connection options.
    /// </summary>
    /// <returns></returns>
    public override IEnumerable<ClientConnection> GetAllConnectionOptions()
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
}
