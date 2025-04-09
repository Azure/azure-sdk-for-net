// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Threading;
using Azure.AI.Models;
using Azure.AI.OpenAI;
using Azure.Data.AppConfiguration;
using Azure.Messaging.ServiceBus;
using Azure.Projects.AI;
using Azure.Projects.Ofx;
using Azure.Security.KeyVault.Secrets;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using NUnit.Framework;
using OpenAI.Chat;
using OpenAI.Embeddings;

namespace Azure.Projects.Tests;

public class E2ETests
{
    private static string allProjectId = "cm00000000000test";
    private static string oneProjectId = "cm00000000002test";

    [TestCase("-bicep")]
    //[TestCase("")]
    public void OpenAI(string arg)
    {
        ProjectInfrastructure infra = new(allProjectId);
        infra.AddFeature(new OpenAIModelFeature("gpt-4o-mini", "2024-07-18"));
        if (infra.TryExecuteCommand([arg])) return;

        ProjectClient project = new(allProjectId, default);
        ChatClient chat = project.GetOpenAIChatClient();
    }

    [TestCase("-bicep")]
    //[TestCase("")]
    public void MaaS(string arg)
    {
        ProjectInfrastructure infra = new(oneProjectId);
        infra.AddFeature(new AIModelsFeature("DeepSeek-V3", "1"));
        if (infra.TryExecuteCommand([arg])) return;

        ProjectClient project = new(oneProjectId, default);
        ModelsClient maas = project.GetModelsClient();
        ChatClient chat = maas.GetChatClient(oneProjectId + "_chat");
        string text = chat.CompleteChat("list all noble gases").AsText();
        Console.WriteLine(text);
    }

    [TestCase("-bicep")]
    //[TestCase("")]
    public void KeyVault(string arg)
    {
        ProjectInfrastructure infra = new(allProjectId);
        infra.AddFeature(new KeyVaultFeature());
        if (infra.TryExecuteCommand([arg])) return;

        ProjectClient project = new(allProjectId, default);
        SecretClient secrets = project.GetSecretClient();
    }

    [TestCase("-bicep")]
    //[TestCase("")]
    public void All (string arg)
    {
        ProjectInfrastructure infrastructure = new(allProjectId);
        AddAllFeratures(infrastructure);

        if (infrastructure.TryExecuteCommand([arg]))
            return;

        ProjectClient project = new(allProjectId, default);
        SecretClient secrets = project.GetSecretClient();
        BlobContainerClient defaultContainer = project.GetBlobContainerClient();
        BlobContainerClient testContainer = project.GetBlobContainerClient("test");
        ConfigurationClient config = project.GetConfigurationClient();
        ChatClient chat = project.GetOpenAIChatClient();
        EmbeddingClient embedding = project.GetOpenAIEmbeddingClient();
        //AzureOpenAIClient openAIClient = project.GetAzureOpenAIClient();
        ServiceBusClient sb = project.GetServiceBusClient();
        ServiceBusSender sender = project.GetServiceBusSender("cm_servicebus_topic_private", "cm_servicebus_subscription_private");
        //ServiceBusReceiver receiver = project.GetServiceBusReceiver("cm_servicebus_topic_private", "cm_servicebus_subscription_private");

        try
        {
            testContainer.UploadBlob("test", BinaryData.FromString("test"));
            BlobDownloadResult result = testContainer.GetBlobClient("test").DownloadContent();
            Assert.AreEqual("test", result.Content.ToString());
        }
        finally
        {
            testContainer.DeleteBlobIfExists("test");
        }
    }

    [TestCase("-bicep")]
    //[TestCase("")]
    public void Ofx(string arg)
    {
        ProjectInfrastructure infrastructure = new(allProjectId);
        infrastructure.AddFeature(new OfxFeatures());

        if (infrastructure.TryExecuteCommand([arg]))
            return;

        OfxClient project = new(allProjectId, default);
        string? uploadedPath = null;
        long done = 0;
        try
        {
            project.Storage.WhenUploaded((file) =>
            {
                string downloaded = file.Download().ToString();
                Assert.AreEqual("hello world", downloaded);
                Interlocked.Increment(ref done);
            });

            uploadedPath = project.Storage.Upload(BinaryData.FromString("hello world"));
            string downloaded = project.Storage.Download(uploadedPath).ToString();
            Assert.AreEqual("hello world", downloaded);
            while (Interlocked.Read(ref done)==0);
        }
        finally
        {
            if (uploadedPath!=null) project.Storage.Delete(uploadedPath);
        }
    }

    internal void AddAllFeratures(ProjectInfrastructure infrastructure)
    {
        infrastructure.AddFeature(new OfxFeatures());
        infrastructure.AddFeature(new KeyVaultFeature());
        infrastructure.AddFeature(new OpenAIChatFeature("gpt-35-turbo", "0125"));
        infrastructure.AddFeature(new OpenAIEmbeddingFeature("text-embedding-ada-002", "2"));
        infrastructure.AddFeature(new BlobContainerFeature("test", false));
    }
}
