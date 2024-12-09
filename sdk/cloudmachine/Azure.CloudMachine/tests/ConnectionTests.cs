// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Linq;
using System.Text.Json;
using Azure.CloudMachine.OpenAI;
using Azure.Core;
using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenAI.Chat;

[assembly: NonParallelizable]

namespace Azure.CloudMachine.Tests;

public class ConnectionTests
{
    [Test]
    [TestCase([new string[0]])]
    public void TwoClients(string[] args)
    {
        CloudMachineInfrastructure infra = new();
        infra.AddFeature(new OpenAIModelFeature("gpt-35-turbo", "0125"));
        if (args.Contains("-azd")) Azd.Init(infra);

        CloudMachineClient client = infra.GetClient();

        ValidateClient(client);
    }

    // this tests the scenario where provisioning is done in one app, but runtime is done by another app
    // the connections needs to be serialized and deserialized
    [Test]
    public void TwoApps()
    {
        // app 1 (with a dependency on the CDK)
        CloudMachineInfrastructure infra = new();
        infra.AddFeature(new OpenAIModelFeature("gpt-35-turbo", "0125"));
        //if (args.Contains("-azd")) Azd.Init(infra);
        BinaryData serializedConnections = BinaryData.FromObjectAsJson(infra.Connections);

        // app 2 (no dependency on the CDK)
        ConnectionCollection deserializedConnections = JsonSerializer.Deserialize<ConnectionCollection>(serializedConnections)!;
        CloudMachineClient client = new(deserializedConnections);

        ValidateClient(client);
    }

    // TODO: maybe this is too hacky. do we really need this?
    [Test]
    [TestCase([new string[0]])]
    public void SingleClientAdd(string[] args)
    {
        CloudMachineClient client = new();
        client.AddFeature(new OpenAIModelFeature("gpt-35-turbo", "0125"));

        if (args.Contains("-azd")) Azd.Init(client);

        ChatClient chat = client.GetOpenAIChatClient();
    }

    [Test]
    public void ConfigurationDemo()
    {
        CloudMachineInfrastructure infra = new();
        infra.AddFeature(new OpenAIModelFeature("gpt-35-turbo", "0125"));

        IConfiguration configuration = new ConfigurationBuilder()
            .AddCloudMachineConfiguration(infra)
            .Build();

        CloudMachineClient client = new(configuration);
        ChatClient chat = client.GetOpenAIChatClient();
    }

    [Test]
    public void ConfigurationLowLevel()
    {
        ConnectionCollection connections = new();
        connections.Add(new ClientConnection(
            id: "Azure.AI.OpenAI.AzureOpenAIClient",
            locator: "https://cm2c54b6e4637f4b1.openai.azure.com",
            auth: ClientAuthenticationMethod.EntraId));

        IConfiguration configuration = new ConfigurationBuilder()
            .AddCloudMachineConnections(connections)
            .AddCloudMachineId("aaaa-bbbb-cccc-dddd")
            .Build();

        var locator = configuration["CloudMachine:Connections:Azure.AI.OpenAI.AzureOpenAIClient:Locator"];
        Assert.AreEqual("https://cm2c54b6e4637f4b1.openai.azure.com", locator);
        var id = configuration["CloudMachine:Id"];
        Assert.AreEqual("aaaa-bbbb-cccc-dddd", id);

        CloudMachineClient client = new(configuration);
        Assert.AreEqual("aaaa-bbbb-cccc-dddd", client.Id);

        ClientConnection connection = client.Connections["Azure.AI.OpenAI.AzureOpenAIClient"];
        Assert.AreEqual("https://cm2c54b6e4637f4b1.openai.azure.com", connection.Locator);
        Assert.AreEqual("aaaa-bbbb-cccc-dddd", client.Id);
    }

    private static void ValidateClient(CloudMachineClient client)
    {
        ChatClient chat = client.GetOpenAIChatClient();
        StorageServices storage = client.Storage;
        BlobContainerClient container = storage.GetContainer(default);
        MessagingServices messaging = client.Messaging;
    }
}
