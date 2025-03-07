// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.ClientModel.Primitives;
using System.Linq;
using System.Text.Json;
using Azure.Core;
using Azure.Identity;
using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

[assembly: NonParallelizable]

namespace Azure.Projects.Tests;

public class ConnectionTests
{
    [Test]
    [TestCase([new string[0]])]
    public void TwoClients(string[] args)
    {
        ProjectInfrastructure infra = new();
        infra.AddOfx();
        if (args.Contains("-azd")) Azd.Init(infra);

        ProjectClient client = infra.GetClient();

        ValidateClient(client);
    }

    // this tests the scenario where provisioning is done in one app, but runtime is done by another app
    // the connections needs to be serialized and deserialized
    [Test]
    public void TwoApps()
    {
        // app 1 (with a dependency on the CDK)
        ProjectInfrastructure infra = new();
        infra.AddOfx();
        //if (args.Contains("-azd")) Azd.Init(infra);
        BinaryData serializedConnections = BinaryData.FromObjectAsJson(infra.Connections);

        // app 2 (no dependency on the CDK)
        ConnectionCollection deserializedConnections = JsonSerializer.Deserialize<ConnectionCollection>(serializedConnections)!;
        ProjectClient client = new(deserializedConnections);

        ValidateClient(client);
    }

    // TODO: maybe this is too hacky. do we really need this?
    [Test]
    [TestCase([new string[0]])]
    public void SingleClientAdd(string[] args)
    {
        ProjectClient client = new();

        if (args.Contains("-azd")) Azd.Init(client);
    }

    [Test]
    public void ConfigurationDemo()
    {
        ProjectInfrastructure infra = new();

        IConfiguration configuration = new ConfigurationBuilder()
            .AddProjectClientConfiguration(infra)
            .Build();

        ProjectClient client = new(configuration);
    }

    [Test]
    public void ConfigurationLowLevel()
    {
        ConnectionCollection connections = new();
        connections.Add(new ClientConnection(
            id: "Azure.AI.OpenAI.AzureOpenAIClient",
            locator: "https://cm2c54b6e4637f4b1.openai.azure.com",
            credential: new DefaultAzureCredential())
        );

        IConfiguration configuration = new ConfigurationBuilder()
            .AddAzureProjectConnections(connections)
            .AddProjectId("aaaa-bbbb-cccc-dddd")
            .Build();

        var locator = configuration["AzureProject:Connections:Azure.AI.OpenAI.AzureOpenAIClient:Locator"];
        Assert.AreEqual("https://cm2c54b6e4637f4b1.openai.azure.com", locator);
        var id = configuration["AzureProject:Id"];
        Assert.AreEqual("aaaa-bbbb-cccc-dddd", id);

        ProjectClient client = new(configuration);
        Assert.AreEqual("aaaa-bbbb-cccc-dddd", client.Id);

        ClientConnection connection = client.Connections["Azure.AI.OpenAI.AzureOpenAIClient"];
        Assert.AreEqual("https://cm2c54b6e4637f4b1.openai.azure.com", connection.Locator);
        Assert.AreEqual("aaaa-bbbb-cccc-dddd", client.Id);
    }

    private static void ValidateClient(ProjectClient client)
    {
        StorageServices storage = client.Storage;
        BlobContainerClient container = storage.GetContainer(default);
        MessagingServices messaging = client.Messaging;
    }
}
