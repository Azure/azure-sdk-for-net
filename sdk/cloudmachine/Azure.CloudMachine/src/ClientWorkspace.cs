// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Core;

/// <summary>
/// Retrieves the connection options for a specified client type and instance ID.
/// Represents a workspace for client operations.
/// </summary>
public abstract class ClientWorkspace
{
    /// <summary>
    /// Retrieves the connection options for a specified client type and instance ID.
    /// </summary>
    /// <param name="clientType">The type of the client.</param>
    /// <param name="instanceId">The instance ID of the client.</param>
    /// <returns>The connection options for the specified client type and instance ID.</returns>
    public abstract ClientConnectionOptions GetConnectionOptions(Type clientType, string instanceId = default);

    /// <summary>
    /// Gets the cache of subclients.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public ClientCache Subclients { get; } = new ClientCache();
}
