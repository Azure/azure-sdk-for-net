// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using Azure.Projects.OpenAI;
using NUnit.Framework;
using OpenAI.Chat;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Microsoft.Extensions.Primitives;
using System.Linq;
using System.IO;

namespace Azure.Projects.Tests;

public partial class AzureProjectsTests
{
    [Ignore("no recordings yet")]
    [Test]
    public void RagDemo()
    {
        string[] testMessages = [
            "When did the continuation policy change for DefaultAzureCredential?",
            "Do I love Seattle?",
            "What is the current time?",
            "What's the weather in Seattle?",
            "Do you think I would like the weather there?",
        ];

        ProjectClient cm = new(new MockConfiguration("cmec4615e3fdfa44e"), default);
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
