// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace System.ClientModel.Primitives;

/// <summary>
/// Abstract base class for managing client connections.
/// Provides connection options for a specified client type and instance ID.
/// </summary>
public abstract class ClientConnectionProvider
{
    private readonly ClientCache _subclients;

    /// <summary>
    /// Initializes a new instance of the ConnectionProvider class.
    /// </summary>
    /// <param name="maxCacheSize">The maximum number of subclients to store in the cache.</param>
    protected ClientConnectionProvider(int maxCacheSize)
    {
        _subclients = new ClientCache(maxCacheSize);
    }

    /// <summary>
    /// Retrieves the connection settings associated with a given connection ID.
    /// </summary>
    /// <param name="connectionId">The unique identifier for the connection.</param>
    /// <returns>The <see cref="ClientConnection"/> instance containing authentication and endpoint details.</returns>
    public abstract ClientConnection GetConnection(string connectionId);

    /// <summary>
    /// Retrieves all available client connections managed by this provider.
    /// </summary>
    /// <returns>A collection of <see cref="ClientConnection"/> instances.</returns>
    public abstract IEnumerable<ClientConnection> GetAllConnections();

    /// <summary>
    /// Gets the cache for subclients to optimize performance by reusing client instances.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public ClientCache Subclients => _subclients;
}
