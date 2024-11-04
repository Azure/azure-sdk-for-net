// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Threading;
using Azure.Provisioning.CloudMachine;
using Azure.Provisioning.CloudMachine.KeyVault;
using Azure.Provisioning.CloudMachine.OpenAI;
using Azure.Security.KeyVault.Secrets;
using Azure.CloudMachine.OpenAI;
using Azure.CloudMachine.KeyVault;
using NUnit.Framework;
using OpenAI.Chat;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Microsoft.Extensions.Primitives;
using OpenAI.Embeddings;
using System.Linq;
using System.IO;
using Azure.CloudMachine.OpenAI.Chat;
using Azure.CloudMachine.OpenAI.Embeddings;

namespace Azure.CloudMachine.Tests;

public class CloudMachineTests
{
    [Test]
    [TestCase([new string[] { "-bicep" }])]
    [TestCase([new string[] { "" }])]
    public void Provisioning(string[] args)
    {
        if (CloudMachineInfrastructure.Configure(args, (cm) =>
        {
            cm.AddFeature(new KeyVaultFeature());
            cm.AddFeature(new OpenAIFeature() // TODO: rework it such that models can be added as features
            {
                Chat = new AIModel("gpt-35-turbo", "0125"),
                Embeddings = new AIModel("text-embedding-ada-002", "2")
            });
        }))
            return;

        CloudMachineWorkspace cm = new();
        Console.WriteLine(cm.Id);
        var embeddings = cm.GetOpenAIEmbeddingsClient();
    }

    [Ignore("no recordings yet")]
    [Test]
    [TestCase([new string[] { "-bicep" }])]
    [TestCase([new string[] { "" }])]
    public void Storage(string[] args)
    {
        ManualResetEventSlim eventSlim = new(false);
        if (CloudMachineInfrastructure.Configure(args, (cm) =>
        {
        }))
            return;

        CloudMachineClient cm = new();

        cm.Storage.WhenBlobUploaded((StorageFile file) =>
        {
            var data = file.Download();
            Console.WriteLine(data.ToString());
            Assert.AreEqual("{\"Foo\":5,\"Bar\":true}", data.ToString());
            eventSlim.Set();
        });
        var uploaded = cm.Storage.UploadJson(new
        {
            Foo = 5,
            Bar = true
        });
        BinaryData downloaded = cm.Storage.DownloadBlob(uploaded);
        Console.WriteLine(downloaded.ToString());
        eventSlim.Wait();
    }

    [Ignore("no recordings yet")]
    [Test]
    [TestCase([new string[] { "-bicep" }])]
    [TestCase([new string[] { "" }])]
    public void OpenAI(string[] args)
    {
        if (CloudMachineInfrastructure.Configure(args, (cm) =>
        {
            cm.AddFeature(new OpenAIFeature()
            {
                Chat = new AIModel("gpt-35-turbo", "0125")
            });
        }))
            return;

        CloudMachineWorkspace cm = new();
        ChatClient chat = cm.GetOpenAIChatClient();
        ChatCompletion completion = chat.CompleteChat("Is Azure programming easy?");

        ChatMessageContent content = completion.Content;
        foreach (ChatMessageContentPart part in content)
        {
            Console.WriteLine(part.Text);
        }
    }

    [Ignore("no recordings yet")]
    [Test]
    [TestCase([new string[] { "-bicep" }])]
    [TestCase([new string[] { "" }])]
    public void KeyVault(string[] args)
    {
        if (CloudMachineInfrastructure.Configure(args, (cm) =>
        {
            cm.AddFeature(new KeyVaultFeature());
        }))
            return;

        CloudMachineWorkspace cm = new();
        SecretClient secrets = cm.GetKeyVaultSecretsClient();
        secrets.SetSecret("testsecret", "don't tell anybody");
    }

    [Ignore("no recordings yet")]
    [Test]
    [TestCase([new string[] { "-bicep" }])]
    [TestCase([new string[] { "" }])]
    public void Messaging(string[] args)
    {
        if (CloudMachineInfrastructure.Configure(args))
            return;

        CloudMachineClient cm = new();
        cm.Messaging.WhenMessageReceived(message =>
        {
            Console.WriteLine(message);
            Assert.True(message != null);
        });
        cm.Messaging.SendMessage(new
        {
            Foo = 5,
            Bar = true
        });
    }

    [Ignore("no recordings yet")]
    [Test]
    [TestCase([new string[] { "-bicep" }])]
    [TestCase([new string[] { "" }])]
    public void Demo(string[] args)
    {
        if (CloudMachineInfrastructure.Configure(args))
            return;

        CloudMachineClient cm = new();

        // setup
        cm.Messaging.WhenMessageReceived((string message) => cm.Storage.UploadBinaryData(BinaryData.FromString(message)));
        cm.Storage.WhenBlobUploaded((StorageFile file) =>
        {
            var content = file.Download();
            ChatCompletion completion = cm.GetOpenAIChatClient().CompleteChat(content.ToString());
            Console.WriteLine(completion.Content[0].Text);
        });

        // go!
        cm.Messaging.SendMessage("Tell me something about Redmond, WA.");
    }

    [Ignore("no recordings yet")]
    [Test]
    public void EmbeddingsDemo()
    {
        string[] testMessages = [
            "When did the continuation policy change for DefaultAzureCredential?",
            "Do I love Seattle?",
            "What is the current time?",
            "What's the weather in Seattle?",
            "Do you think I would like the weather there?",
        ];

        CloudMachineClient cm = new(default, new MockConfiguration("cmec4615e3fdfa44e"));
        var chat = cm.GetOpenAIChatClient();
        var embeddings = cm.GetOpenAIEmbeddingsClient();

        // helpers
        ChatTools tools = new(typeof(MyFunctions));
        EmbeddingsVectorbase vectors = new(embeddings, null, 1000);
        vectors.Add("I love Seattle.");
        vectors.Add(File.ReadAllText(@"C:\Users\chriss\Desktop\Identity-README.md"));

        ChatCompletionOptions options = new();
        foreach (var definition in tools.Definitions)
        {
            options.Tools.Add(definition);
        }
        options.ToolChoice = ChatToolChoice.CreateAutoChoice();

        List<ChatMessage> prompt = new();

        foreach (var testMessage in testMessages)
        {
            Console.WriteLine($"u: {testMessage}");
            IEnumerable<VectorbaseEntry> relatedItems = vectors.Find(testMessage);
            foreach (VectorbaseEntry relatedItem in relatedItems)
            {
                prompt.Add(ChatMessage.CreateSystemMessage(relatedItem.Data.ToString()));
            }

            prompt.Add(ChatMessage.CreateUserMessage(testMessage));
            CallOpenAI();
            // filter the prompt to only include the user message
            var responses = prompt.Where(message => message is AssistantChatMessage).Select(m => m.Content[0].Text).ToList();
        }
        void CallOpenAI()
        {
            bool requiresAction;
            do
            {
                requiresAction = false;
                var completion = chat.CompleteChat(prompt, options).Value;
                switch (completion.FinishReason)
                {
                    case ChatFinishReason.ToolCalls:
                        // TODO: figure out why the model is returning bogus tool call results.
                        // prompt.Add(new AssistantChatMessage(completion));
                        // IEnumerable<ToolChatMessage> callResults = tools.CallAll(completion.ToolCalls);
                        // prompt.AddRange(callResults);
                        requiresAction = true;
                        break;
                    case ChatFinishReason.Length:
                        Console.WriteLine("Incomplete model output due to MaxTokens parameter or token limit exceeded.");
                        break;
                    case ChatFinishReason.ContentFilter:
                        Console.WriteLine("Omitted content due to a content filter flag.");
                        break;
                    case ChatFinishReason.Stop:
                        prompt.Add(new AssistantChatMessage(completion));
                        break;
                    default:
                        throw new NotImplementedException("Unknown finish reason.");
                }
            } while (requiresAction);
        }
    }

    public static class MyFunctions
    {
        [System.ComponentModel.Description("Returns the current weather at the specified location")]
        public static string GetCurrentWeather(string location, string? unit = default) => $"1 million degrees {unit}";

        [System.ComponentModel.Description("Returns the user's current location")]
        public static string GetCurrentLocation() => "Planet Earth";

        [System.ComponentModel.Description("Returns the current time.")]
        public static string GetCurrentTime() => DateTimeOffset.Now.ToString("t");
    }

    private class MockConfiguration : IConfiguration
    {
        private readonly string _cmId;

        public MockConfiguration(string cmId)
        {
            _cmId = cmId;
        }

        public string? this[string key] { get => _cmId; set => throw new NotImplementedException(); }

        public IEnumerable<IConfigurationSection> GetChildren() => throw new NotImplementedException();

        public IChangeToken GetReloadToken() => throw new NotImplementedException();

        public IConfigurationSection GetSection(string key) => throw new NotImplementedException();
    }
}
