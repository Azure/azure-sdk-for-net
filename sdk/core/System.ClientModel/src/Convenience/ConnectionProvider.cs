// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.ComponentModel;

namespace System.ClientModel.Primitives;

/// <summary>
/// Abstract base class for managing client connections.
/// Provides connection options for a specified client type and instance ID.
/// </summary>
public abstract class ConnectionProvider
{
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
    /// Gets a cache for subclients to optimize performance by reusing client instances.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public ClientCache Subclients { get; } = new ClientCache();
}
