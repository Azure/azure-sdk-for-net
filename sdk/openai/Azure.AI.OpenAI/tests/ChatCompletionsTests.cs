﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.OpenAI.Tests
{
    public class ChatCompletionsTests : OpenAITestBase
    {
        public ChatCompletionsTests(bool isAsync)
            : base(Scenario.ChatCompletions, isAsync) // , RecordedTestMode.Live)
        {
        }

        [RecordedTest]
        [TestCase(Service.Azure)]
        [TestCase(Service.NonAzure)]
        public async Task ChatCompletions(Service serviceTarget)
        {
            OpenAIClient client = GetTestClient(serviceTarget);
            string deploymentOrModelName = GetDeploymentOrModelName(serviceTarget);

            var requestOptions = new ChatCompletionsOptions()
            {
                DeploymentName = deploymentOrModelName,
                Messages =
                {
                    new ChatRequestSystemMessage("You are a helpful assistant."),
                    new ChatRequestUserMessage("Can you help me?"),
                    new ChatRequestAssistantMessage("Of course! What do you need help with?"),
                    new ChatRequestUserMessage("What temperature should I bake pizza at?"),
                },
            };
            Response<ChatCompletions> response = await client.GetChatCompletionsAsync(requestOptions);
            Assert.That(response, Is.Not.Null);
            Assert.That(response.Value, Is.InstanceOf<ChatCompletions>());
            Assert.That(response.Value.Id, Is.Not.Null.Or.Empty);
            Assert.That(response.Value.Created, Is.Not.Null.Or.Empty);
            Assert.That(response.Value.Choices, Is.Not.Null.Or.Empty);
            Assert.That(response.Value.Choices.Count, Is.EqualTo(1));
            ChatChoice choice = response.Value.Choices[0];
            Assert.That(choice.Index, Is.EqualTo(0));
            Assert.That(choice.FinishReason, Is.EqualTo(CompletionsFinishReason.Stopped));
            Assert.That(choice.Message.Role, Is.EqualTo(ChatRole.Assistant));
            Assert.That(choice.Message.Content, Is.Not.Null.Or.Empty);
        }

        [RecordedTest]
        [TestCase(Service.Azure)]
        [TestCase(Service.NonAzure)]
        public async Task ChatCompletionsContentFilterCategories(Service serviceTarget)
        {
            OpenAIClient client = GetTestClient(serviceTarget);
            string deploymentOrModelName = OpenAITestBase.GetDeploymentOrModelName(serviceTarget, Scenario.ChatCompletions);
            var requestOptions = new ChatCompletionsOptions()
            {
                DeploymentName = deploymentOrModelName,
                Messages =
                {
                    new ChatRequestUserMessage("How do I cook a bell pepper?"),
                },
            };
            Response<ChatCompletions> response = await client.GetChatCompletionsAsync(requestOptions);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Value, Is.Not.Null);
            Assert.That(response.Value.Choices, Is.Not.Null.Or.Empty);

            ChatChoice firstChoice = response.Value.Choices[0];
            Assert.That(firstChoice, Is.Not.Null);

            AssertExpectedPromptFilterResults(
                response.Value.PromptFilterResults,
                serviceTarget,
                expectedCount: (requestOptions.ChoiceCount ?? 1));
            AssertExpectedContentFilterResponseResults(firstChoice.ContentFilterResults, serviceTarget);
        }

        [RecordedTest]
        [TestCase(Service.Azure)]
        [TestCase(Service.NonAzure)]
        public async Task StreamingChatCompletions(Service serviceTarget)
        {
            OpenAIClient client = GetTestClient(serviceTarget);
            string deploymentOrModelName = GetDeploymentOrModelName(serviceTarget);

            var requestOptions = new ChatCompletionsOptions()
            {
                DeploymentName = deploymentOrModelName,
                Messages =
                {
                    new ChatRequestSystemMessage("You are a helpful assistant."),
                    new ChatRequestUserMessage("Can you help me?"),
                    new ChatRequestAssistantMessage("Of course! What do you need help with?"),
                    new ChatRequestUserMessage("What temperature should I bake pizza at?"),
                },
                MaxTokens = 512,
            };

            StreamingResponse<StreamingChatCompletionsUpdate> response
                = await client.GetChatCompletionsStreamingAsync(requestOptions);
            Assert.That(response, Is.Not.Null);

            StringBuilder contentBuilder = new();
            bool gotRole = false;
            bool gotRequestContentFilterResults = false;
            bool gotResponseContentFilterResults = false;

            await foreach (StreamingChatCompletionsUpdate chatUpdate in response)
            {
                Assert.That(chatUpdate, Is.Not.Null);

                if (chatUpdate.AzureExtensionsContext?.RequestContentFilterResults is null)
                {
                    Assert.That(chatUpdate.Id, Is.Not.Null.Or.Empty);
                    Assert.That(chatUpdate.Created, Is.GreaterThan(new DateTimeOffset(new DateTime(2023, 1, 1))));
                    Assert.That(chatUpdate.Created, Is.LessThan(DateTimeOffset.UtcNow.AddDays(7)));
                }
                if (chatUpdate.Role.HasValue)
                {
                    Assert.IsFalse(gotRole);
                    Assert.That(chatUpdate.Role.Value, Is.EqualTo(ChatRole.Assistant));
                    gotRole = true;
                }
                if (chatUpdate.ContentUpdate is not null)
                {
                    contentBuilder.Append(chatUpdate.ContentUpdate);
                }
                if (chatUpdate.AzureExtensionsContext?.RequestContentFilterResults is not null)
                {
                    Assert.IsFalse(gotRequestContentFilterResults);
                    Assert.That(chatUpdate.AzureExtensionsContext.RequestContentFilterResults.PromptIndex, Is.EqualTo(0));
                    AssertExpectedContentFilterRequestResults(
                        chatUpdate.AzureExtensionsContext.RequestContentFilterResults.ContentFilterResults,
                        serviceTarget);
                    gotRequestContentFilterResults = true;
                }
                if (chatUpdate.AzureExtensionsContext?.ResponseContentFilterResults is not null)
                {
                    AssertExpectedContentFilterResponseResults(
                        chatUpdate.AzureExtensionsContext.ResponseContentFilterResults,
                        serviceTarget);
                    gotResponseContentFilterResults = true;
                }
            }

            Assert.IsTrue(gotRole);
            Assert.That(contentBuilder.ToString(), Is.Not.Null.Or.Empty);
            if (serviceTarget == Service.Azure)
            {
                Assert.IsTrue(gotRequestContentFilterResults);
                Assert.IsTrue(gotResponseContentFilterResults);
            }
        }
    }
}
