// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.Core;

/// <summary>
/// Retrieves the connection options for a specified client type and instance ID.
/// Represents a workspace for client operations.
/// </summary>
public abstract class ClientWorkspace
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ClientWorkspace"/> class with the specified token credential.
    /// </summary>
    /// <param name="credential"></param>
    protected ClientWorkspace(TokenCredential credential)
    {
        Credential = credential;
    }

    /// <summary>
    /// Retrieves the connection options for a specified client type and instance ID.
    /// </summary>
    /// <param name="connectionId"></param>
    /// <returns>The connection options for the specified client type and instance ID.</returns>
    public abstract ClientConnection GetConnectionOptions(string connectionId);

    /// <summary>
    /// Retrieves all connection options.
    /// </summary>
    /// <returns></returns>
    public abstract IEnumerable<ClientConnection> GetAllConnectionOptions();

    /// <summary>
    /// Gets the token credential.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public TokenCredential Credential { get; }

    /// <summary>
    /// Gets the cache of subclients.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public ClientCache Subclients { get; } = new ClientCache();
}
