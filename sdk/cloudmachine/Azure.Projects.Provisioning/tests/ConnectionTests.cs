// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Azure.Identity;
using Azure.Messaging.ServiceBus;
using Azure.Projects.Core;
using Azure.Projects.Ofx;
using Azure.Security.KeyVault.Secrets;
using Azure.Storage.Blobs;
using NUnit.Framework;

namespace Azure.Projects.Tests;

public class ConnectionTests
{
    private string projectId = "cm00000000000test";
    [Test]
    public void MinimalProject()
    {
        TestConnectionStore store = new();
        ProjectInfrastructure infrastructure = new(store, projectId);
        infrastructure.Build();

        ProjectClient project = new(projectId, store.Provider);
        var connections = project.GetAllConnections();
        Assert.AreEqual(0, connections.Count());
    }

    [Test]
    public void KeyVault()
    {
        TestConnectionStore store = new();
        ProjectInfrastructure infrastructure = new(store, projectId);
        infrastructure.AddFeature(new KeyVaultFeature());
        infrastructure.Build();

        ProjectClient project = new(projectId, store.Provider);
        var connections = project.GetAllConnections();
        Assert.AreEqual(1, connections.Count());
        PrintConnections(connections);

        SecretClient secrets = project.GetSecretClient();
    }

    [Test]
    public void CloudMachine()
    {
        TestConnectionStore store = new();
        ProjectInfrastructure infrastructure = new(store, projectId);
        infrastructure.AddFeature(new AppConfigurationFeature());
        infrastructure.AddFeature(new OfxFeatures());
        infrastructure.Build();

        ProjectClient project = new(projectId, store.Provider);
        var connections = project.GetAllConnections();
        Assert.AreEqual(5, connections.Count());
        PrintConnections(connections);

        BlobContainerClient blobs = project.GetBlobContainerClient();
        ServiceBusClient sb = project.GetServiceBusClient();
        //ServiceBusSender sender = project.GetServiceBusSender();
        //ServiceBusProcessor processor = project.GetServiceBusProcessor();
        //ConfigurationClient config = project.GetConfigurationClient();
    }

    private static void PrintConnections(IEnumerable<ClientConnection> connections)
    {
        foreach (var connection in connections)
        {
            Console.WriteLine($"{connection.Id} - {connection.Locator}");
        }
    }
}

internal class TestConnectionStore : ConnectionStore
{
    private readonly TestConnectionProvider _provider = new(new AzureDeveloperCliCredential());
    public override void EmitConnection(ProjectInfrastructure infrastructure, string connectionId, string endpoint)
    {
        _provider.AddConnection(connectionId, new ClientConnection(connectionId, endpoint));
    }
    public ClientConnectionProvider Provider => _provider;
}
internal class TestConnectionProvider : ClientConnectionProvider
{
    private readonly Dictionary<string, ClientConnection> _connections = new();
    private readonly TokenCredential _credential;

    public TestConnectionProvider(TokenCredential credential) : base(maxCacheSize: 100)
        => _credential = credential;
    public override ClientConnection GetConnection(string connectionId)
        => _connections[connectionId];

    internal void AddConnection(string connectionId, ClientConnection connection)
    {
        if (connection.Credential == null)
        {
            _connections.Add(connectionId, new ClientConnection(connectionId, connection.Locator, _credential, CredentialKind.TokenCredential));
        }
        else
        {
            _connections.Add(connectionId, connection);
        }
    }
    public override IEnumerable<ClientConnection> GetAllConnections()
        => _connections.Values;
}
