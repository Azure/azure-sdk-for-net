// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Data.AppConfiguration;

namespace Azure.Projects;

/// <summary>
/// The project client.
/// </summary>
public partial class ProjectClient : ConnectionProvider
{
    private readonly ConnectionCollection _connectionCache = new();

    /// <summary>
    /// Retrieves the connection options for a specified client type and instance ID.
    /// </summary>
    /// <param name="connectionId"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override ClientConnection GetConnection(string connectionId)
    {
        if (_connectionCache.Contains(connectionId))
        {
            return _connectionCache[connectionId];
        }

        if (_config != null)
        {
            ConfigurationSetting setting = _config.GetConfigurationSetting(connectionId);
            string value = setting.Value;
            ClientConnection connetion = new(connectionId, value, _credential);
            _connectionCache.Add(connetion);
            return connetion;
        }

        throw new Exception("Connection not found");
    }

    /// <summary>
    /// Rerurns all connections.
    /// </summary>
    /// <returns></returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override IEnumerable<ClientConnection> GetAllConnections() => _connectionCache;
}
