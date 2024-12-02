// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Linq;
using System.Text.Json;
using Azure.CloudMachine.KeyVault;
using Azure.CloudMachine.OpenAI;
using Azure.Storage.Blobs;
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
        CloudMachineClient client = new(connections: deserializedConnections);

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
    public void SingleClientConfigure()
    {
        CloudMachineClient client = new();
        client.Configure((infrastructure) =>
        {
            infrastructure.AddFeature(new KeyVaultFeature());
            infrastructure.AddFeature(new OpenAIModelFeature("gpt-35-turbo", "0125"));
            infrastructure.AddFeature(new OpenAIModelFeature("text-embedding-ada-002", "2", AIModelKind.Embedding));
        });
        ValidateClient(client);
        var embeddings = client.GetOpenAIEmbeddingsClient();
    }

    private static void ValidateClient(CloudMachineClient client)
    {
        ChatClient chat = client.GetOpenAIChatClient();
        StorageServices storage = client.Storage;
        BlobContainerClient container = storage.GetContainer(default);
        MessagingServices messaging = client.Messaging;
    }
}
