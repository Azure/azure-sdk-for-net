// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using Azure.CloudMachine.OpenAI;
using NUnit.Framework;
using OpenAI.Chat;
using System.Text.Json;
using Azure.Storage.Blobs;
using Azure.CloudMachine.KeyVault;

namespace Azure.CloudMachine.Tests;

public class ConnectionTests
{
    private static void ValidateClient(CloudMachineClient client)
    {
        ChatClient chat = client.GetOpenAIChatClient();
        StorageServices storage = client.Storage;
        BlobContainerClient container = storage.GetContainer(default);
        MessagingServices messaging = client.Messaging;
    }

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
        CloudMachineClient client = new(connections: deserializedConnections);

        ValidateClient(client);
    }

    [Test]
    public void TwoClients()
    {
        CloudMachineInfrastructure infra = new();
        infra.AddFeature(new OpenAIModelFeature("gpt-35-turbo", "0125"));

        CloudMachineClient client = infra.GetClient();

        ValidateClient(client);
    }

    [Test]
    public void SingleClientAdd()
    {
        CloudMachineClient client = new();
        client.AddFeature(new OpenAIModelFeature("gpt-35-turbo", "0125"));
        //if (args.Contains("-azd")) Azd.Init(client);

        ChatClient chat = client.GetOpenAIChatClient();
    }

    [Test]
    public void SingleClientConfigure()
    {
        CloudMachineClient client = new();
        client.Configure((infrastructure) =>
        {
            infrastructure.AddFeature(new OpenAIModelFeature("gpt-35-turbo", "0125"));
        });
        ValidateClient(client);
    }

    [Test]
    public void Configuration()
    {
        CloudMachineCommands.Execute(["-bicep"], (infrastructure) =>
        {
            infrastructure.AddFeature(new KeyVaultFeature());
            infrastructure.AddFeature(new OpenAIModelFeature("gpt-35-turbo", "0125"));
            infrastructure.AddFeature(new OpenAIModelFeature("text-embedding-ada-002", "2", AIModelKind.Embedding));
        }, exitProcessIfHandled: false);

        CloudMachineClient cm = new();
        Console.WriteLine(cm.Id);
        var embeddings = cm.GetOpenAIEmbeddingsClient();
    }
}
