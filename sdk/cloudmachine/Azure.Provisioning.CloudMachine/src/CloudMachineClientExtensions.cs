// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.CloudMachine.Core;
using Azure.Core;

namespace Azure.CloudMachine;

public static class CloudMachineClientExtensions
{
    private static void Configure(this ProjectClient client, Action<ProjectInfrastructure>? configure = default)
    {
        ProjectInfrastructure cmi = new(client.Id);
        if (configure != default)
        {
            configure(cmi);
        }
        foreach (ClientConnection clientConnection in cmi.Connections)
        {
            client.Connections.Add(clientConnection);
        }
        Azd.Init(cmi);
    }

    public static T AddFeature<T>(this ProjectClient client, T feature) where T : CloudMachineFeature
    {
        ProjectInfrastructure infra = client.GetInfrastructure();
        infra.AddFeature(feature);
        CopyConnections(infra.Connections, client.Connections);
        return feature;
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static ProjectInfrastructure GetInfrastructure(this ProjectClient client)
    {
        return client.Subclients.Get(() =>
        {
            ProjectInfrastructure infra = new ProjectInfrastructure(client.Id);
            return infra;
        });
    }

    private static void CopyConnections(ConnectionCollection from, ConnectionCollection to)
    {
        foreach (var connection in from)
        {
            if (!to.Contains(connection)) {
                to.Add(connection);
            }
        }
    }
}
