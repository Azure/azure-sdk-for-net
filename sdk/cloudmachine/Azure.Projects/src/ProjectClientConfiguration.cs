// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;

namespace Azure.Core;

/// <summary>
/// extensions.
/// </summary>
public static class ProjectClientConfiguration
{
    /// <summary>
    /// Adds a connection to the collection.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="connections"></param>
    /// <returns></returns>
    public static IConfigurationBuilder AddAzureProjectConnections(this IConfigurationBuilder builder, ConnectionCollection connections)
    {
        var source = new ConnectionCollectionConfigurationSource(connections);
        builder.Add(source);
        return builder;
    }
    /// <summary>
    /// Adds a connection to the collection.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    public static IConfigurationBuilder AddProjectId(this IConfigurationBuilder builder, string id)
    {
        var source = new CmidConfigurationSource(id);
        builder.Add(source);
        return builder;
    }
}

internal class ConnectionCollectionConfigurationProvider : IConfigurationProvider
{
    private readonly ConnectionCollection _connections;
    public ConnectionCollectionConfigurationProvider(ConnectionCollection connections)
        => _connections = connections;

    public IEnumerable<string> GetChildKeys(IEnumerable<string> earlierKeys, string parentPath)
    {
        foreach (string earlierKey in earlierKeys)
        {
            yield return earlierKey;
        }
        foreach (ClientConnection connection in _connections)
        {
            yield return connection.Id;
        }
    }

    public IChangeToken GetReloadToken() => null;
    public void Load() { }
    public void Set(string key, string value) => throw new NotImplementedException();
    public bool TryGet(string key, out string value)
    {
        string[] path = key.Split(':');

        if (path.Length != 4 ||
            !path[0].Equals("AzureProject", StringComparison.InvariantCultureIgnoreCase) ||
            !path[1].Equals("Connections", StringComparison.InvariantCultureIgnoreCase))
        {
            value = null;
            return false;
        }

        if (!_connections.Contains(path[2]))
        {
            value = null;
            return false;
        }

        string id = path[2];
        ClientConnection connection = _connections[id];
        var property = path[3].ToLowerInvariant();

        switch (property)
        {
            case "id":
                value = connection.Id;
                return true;
            case "locator":
                value = connection.Locator;
                return true;
            case "authentication":
                value = connection.Authentication.ToString();
                return true;
            default:
                value = null;
                return false;
        }
    }
}
internal class ConnectionCollectionConfigurationSource : IConfigurationSource
{
    private readonly ConnectionCollection _connections;
    public ConnectionCollectionConfigurationSource(ConnectionCollection connections)
        => _connections = connections;

    public IConfigurationProvider Build(IConfigurationBuilder builder)
        => new ConnectionCollectionConfigurationProvider(_connections);
}

internal class CmidConfigurationProvider(string cmid) : IConfigurationProvider
{
    public IEnumerable<string> GetChildKeys(IEnumerable<string> earlierKeys, string parentPath)
    {
        if (parentPath.Equals("AzureProject", StringComparison.InvariantCultureIgnoreCase))
            return earlierKeys.Append("ID"); // todo: should this check if ID is not already in earlier keys
        else
            return earlierKeys;
    }

    public IChangeToken GetReloadToken() => null;
    public void Load() {}
    public void Set(string key, string value)
        => new NotSupportedException();

    public bool TryGet(string key, out string value)
    {
        if (!key.Equals("AzureProject:ID", StringComparison.InvariantCultureIgnoreCase))
        {
            value = null;
            return false;
        }
        value = cmid;
        return true;
    }
}
internal class CmidConfigurationSource(string cmid) : IConfigurationSource
{
    public IConfigurationProvider Build(IConfigurationBuilder builder)
        => new CmidConfigurationProvider(cmid);
}
