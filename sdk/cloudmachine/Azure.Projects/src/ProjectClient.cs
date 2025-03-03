// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.Identity;
using Microsoft.Extensions.Configuration;

namespace Azure.Projects;

/// <summary>
/// The project client.
/// </summary>
public partial class ProjectClient : ConnectionProvider
{
    /// <summary>
    /// The project ID.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string Id { get; }

    /// <summary>
    /// subclient connections.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public ConnectionCollection Connections { get; } = [];

    private readonly TokenCredential Credential = BuildCredential(default);

    /// <summary>
    /// Initializes a new instance of the <see cref="ProjectClient"/> class for mocking purposes..
    /// </summary>
    protected ProjectClient() :
        this(credential: BuildCredential(default))
    {
        Id = AppConfigHelpers.ReadOrCreateProjectId();
        Messaging = new MessagingServices(this);
        Storage = new StorageServices(this);
    }

#pragma warning disable AZC0007 // DO provide a minimal constructor that takes only the parameters required to connect to the service.
    /// <summary>
    /// Initializes a new instance of the <see cref="ProjectClient"/> class.
    /// </summary>
    /// <param name="configuration">The configuration settings.</param>
    /// <param name="credential">The token credential.</param>
    public ProjectClient(IConfiguration configuration, TokenCredential credential = default)
#pragma warning restore AZC0007 // DO provide a minimal constructor that takes only the parameters required to connect to the service.
    {
        Id = configuration["AzureProject:ID"];
        if (Id == null)
        {
            Id = AppConfigHelpers.ReadOrCreateProjectId();
        }

        IConfigurationSection connectionsSection = configuration.GetSection("AzureProject:Connections");

        foreach (IConfigurationSection connection in connectionsSection.GetChildren())
        {
            string id = connection["Id"];
            if (id == null) continue;
            string locator = connection["Locator"];

            Connections.Add(new ClientConnection(id, locator, ClientAuthenticationMethod.Credential));
        }

        Messaging = new MessagingServices(this);
        Storage = new StorageServices(this);
    }

#pragma warning disable AZC0007 // DO provide a minimal constructor that takes only the parameters required to connect to the service.
    /// <summary>
    /// Initializes a new instance of the <see cref="ProjectClient"/> class.
    /// </summary>
    /// <param name="connections"></param>
    /// <param name="credential">The token credential.</param>
    // TODO: we need to combine the configuration and the connections into a single parameter.
    public ProjectClient(IEnumerable<ClientConnection> connections = default, TokenCredential credential = default)
#pragma warning restore AZC0007 // DO provide a minimal constructor that takes only the parameters required to connect to the service.
    {
        if (connections != null)
        {
            foreach (ClientConnection connection in connections)
            {
                if (connection.Authentication == ClientAuthenticationMethod.Credential)
                {
                    if (connection.Credential == null)
                    {
                        var copy = new ClientConnection(connection.Id, connection.Locator, Credential);
                        Connections.Add(copy);
                    }
                    else if (connection.Credential is ClientAuthenticationMethod)
                    {
                        var auth = (ClientAuthenticationMethod)connection.Credential;
                        if (auth == ClientAuthenticationMethod.Credential)
                        {
                            var copy = new ClientConnection(connection.Id, connection.Locator, Credential);
                            Connections.Add(copy);
                            continue;
                        }
                        else
                            throw new NotImplementedException();
                    }
                }
                else
                {
                    Connections.Add(connection);
                }
            }
        }

        Id = AppConfigHelpers.ReadOrCreateProjectId();
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
    public override ClientConnection GetConnection(string connectionId) => Connections[connectionId];

    /// <summary>
    /// Rerurns all connections.
    /// </summary>
    /// <returns></returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override IEnumerable<ClientConnection> GetAllConnections() => Connections;

    private static TokenCredential BuildCredential(TokenCredential credential)
    {
        if (credential == default)
        {
            // This environment variable is set by the Project App Service feature during provisioning.
            credential = Environment.GetEnvironmentVariable("CLOUDMACHINE_MANAGED_IDENTITY_CLIENT_ID") switch
            {
                string clientId when !string.IsNullOrEmpty(clientId) => new ManagedIdentityCredential(clientId),
                _ => new ChainedTokenCredential(new AzureCliCredential(), new AzureDeveloperCliCredential())
            };
        }

        return credential;
    }

    /// <summary>
    /// Reads or creates the project ID.
    /// </summary>
    /// <returns></returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static string ReadOrCreateProjectId() => AppConfigHelpers.ReadOrCreateProjectId();

    /// <inheritdoc/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override bool Equals(object obj) => base.Equals(obj);

    /// <inheritdoc/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override int GetHashCode() => base.GetHashCode();

    /// <inheritdoc/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override string ToString() => Id;
}
