// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Projects.Core;
using Azure.Core;
using System.ClientModel.Primitives;

namespace Azure.Projects;

public static class ProjectClientExtensions
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

    public static T AddFeature<T>(this ProjectClient client, T feature) where T : AzureProjectFeature
    {
        ProjectInfrastructure infra = client.GetInfrastructure();
        infra.AddFeature(feature);
        CopyConnections(infra.Connections, client.Connections);
        return feature;
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static ProjectInfrastructure GetInfrastructure(this ProjectClient client)
    {
        return client.Subclients.GetClient(() =>
        {
            ProjectInfrastructure infra = new ProjectInfrastructure(client.Id);
            return infra;
        }, null);
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
