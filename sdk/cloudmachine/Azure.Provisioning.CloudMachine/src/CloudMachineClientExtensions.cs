// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.CloudMachine.Core;
using Azure.Core;

namespace Azure.CloudMachine;

public static class CloudMachineClientExtensions
{
    private static void Configure(this CloudMachineClient client, Action<CloudMachineInfrastructure>? configure = default)
    {
        CloudMachineInfrastructure cmi = new(client.Id);
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

    public static T AddFeature<T>(this CloudMachineClient client, T feature) where T : CloudMachineFeature
    {
        CloudMachineInfrastructure infra = client.GetInfrastructure();
        infra.AddFeature(feature);
        CopyConnections(infra.Connections, client.Connections);
        return feature;
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static CloudMachineInfrastructure GetInfrastructure(this CloudMachineClient client)
    {
        return client.Subclients.Get(() =>
        {
            CloudMachineInfrastructure infra = new CloudMachineInfrastructure(client.Id);
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
