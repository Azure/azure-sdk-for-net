// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Inference.Tests.Samples
{
    public class Sample4_ChatCompletionsWithHistory : SamplesBase<InferenceClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void ChatCompletionsWithHistoryScenario()
        {
            #region Snippet:Azure_AI_Inference_ChatCompletionsWithHistoryScenario
#if SNIPPET
            var endpoint = new Uri(System.Environment.GetEnvironmentVariable("AZURE_AI_CHAT_ENDPOINT"));
            var credential = new AzureKeyCredential(System.Environment.GetEnvironmentVariable("AZURE_AI_CHAT_KEY"));
#else
            var endpoint = new Uri(TestEnvironment.MistralSmallEndpoint);
            var credential = new AzureKeyCredential(TestEnvironment.MistralSmallApiKey);
#endif

            var client = new ChatCompletionsClient(endpoint, credential, new AzureAIInferenceClientOptions());
            var messages = new List<ChatRequestMessage>()
            {
                new ChatRequestSystemMessage("You are an AI assistant that helps people find information. Your replies are short, no more than two sentences."),
                new ChatRequestUserMessage("What year was construction of the international space station mostly done?"),
            };

            var requestOptions = new ChatCompletionsOptions(messages);

            Response<ChatCompletions> response = client.Complete(requestOptions);
            System.Console.WriteLine(response.Value.Content);

            messages.Add(new ChatRequestAssistantMessage(response.Value));
            messages.Add(new ChatRequestUserMessage("And what was the estimated cost to build it?"));

            requestOptions = new ChatCompletionsOptions(messages);
            response = client.Complete(requestOptions);
            System.Console.WriteLine(response.Value.Content);
            #endregion

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Value, Is.InstanceOf<ChatCompletions>());
            Assert.That(response.Value.Id, Is.Not.Null.Or.Empty);
            Assert.That(response.Value.Created, Is.Not.Null.Or.Empty);
            ChatCompletions result = response.Value;
            Assert.That(result.FinishReason, Is.EqualTo(CompletionsFinishReason.Stopped));
            Assert.That(result.Role, Is.EqualTo(ChatRole.Assistant));
            Assert.That(result.Content, Is.Not.Null.Or.Empty);
        }

        [Test]
        [AsyncOnly]
        public async Task ChatCompletionsWithHistoryScenarioAsync()
        {
            #region Snippet:Azure_AI_Inference_ChatCompletionsWithHistoryScenarioAsync
#if SNIPPET
            var endpoint = new Uri(System.Environment.GetEnvironmentVariable("AZURE_AI_CHAT_ENDPOINT"));
            var credential = new AzureKeyCredential(System.Environment.GetEnvironmentVariable("AZURE_AI_CHAT_KEY"));
#else
            var endpoint = new Uri(TestEnvironment.MistralSmallEndpoint);
            var credential = new AzureKeyCredential(TestEnvironment.MistralSmallApiKey);
#endif

            var client = new ChatCompletionsClient(endpoint, credential, new AzureAIInferenceClientOptions());
            var messages = new List<ChatRequestMessage>()
            {
                new ChatRequestSystemMessage("You are an AI assistant that helps people find information. Your replies are short, no more than two sentences."),
                new ChatRequestUserMessage("What year was construction of the international space station mostly done?"),
            };

            var requestOptions = new ChatCompletionsOptions(messages);

            Response<ChatCompletions> response = await client.CompleteAsync(requestOptions);
            System.Console.WriteLine(response.Value.Content);

            messages.Add(new ChatRequestAssistantMessage(response.Value));
            messages.Add(new ChatRequestUserMessage("And what was the estimated cost to build it?"));

            requestOptions = new ChatCompletionsOptions(messages);
            response = await client.CompleteAsync(requestOptions);
            System.Console.WriteLine(response.Value.Content);
            #endregion

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Value, Is.InstanceOf<ChatCompletions>());
            Assert.That(response.Value.Id, Is.Not.Null.Or.Empty);
            Assert.That(response.Value.Created, Is.Not.Null.Or.Empty);
            ChatCompletions result = response.Value;
            Assert.That(result.FinishReason, Is.EqualTo(CompletionsFinishReason.Stopped));
            Assert.That(result.Role, Is.EqualTo(ChatRole.Assistant));
            Assert.That(result.Content, Is.Not.Null.Or.Empty);
        }
    }
}
