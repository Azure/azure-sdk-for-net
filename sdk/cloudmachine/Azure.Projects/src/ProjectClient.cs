// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.Identity;

namespace Azure.Projects;

/// <summary>
/// The project client.
/// </summary>
public partial class ProjectClient : ClientConnectionProvider
{
    private readonly TokenCredential _credential = BuildCredential(default);
    private readonly ClientConnectionProvider _connections;

    /// <summary>
    /// The project ID.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string ProjectId { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ProjectClient"/>.
    /// </summary>
    public ProjectClient() : base(maxCacheSize: 100)
    {
        // TODO: should it ever create?
        ProjectId = ReadOrCreateProjectId();
        _connections = new AppConfigConnectionProvider(new Uri($"https://{ProjectId}.azconfig.io"), _credential);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ProjectClient"/> with the specified connection provider.
    /// </summary>
    /// <param name="projectId"></param>
    /// <param name="connections"></param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public ProjectClient(string projectId, ClientConnectionProvider connections) : base(maxCacheSize: 100)
    {
        if (connections == null)
        {
            connections = new AppConfigConnectionProvider(new Uri($"https://{projectId}.azconfig.io"), _credential);
        }
        ProjectId = projectId;
        _connections = connections;
    }

    /// <summary>
    /// Retrieves the connection options for a specified client type and instance ID.
    /// </summary>
    /// <param name="connectionId"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override ClientConnection GetConnection(string connectionId)
        => _connections.GetConnection(connectionId);

    /// <summary>
    /// Rerurns all connections.
    /// </summary>
    /// <returns></returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override IEnumerable<ClientConnection> GetAllConnections() => _connections.GetAllConnections();

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
}
