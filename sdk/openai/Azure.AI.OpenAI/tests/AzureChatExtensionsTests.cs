// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.OpenAI.Tests;

public class AzureChatExtensionsTests : OpenAITestBase
{
    public AzureChatExtensionsTests(bool isAsync)
        : base(isAsync)//, RecordedTestMode.Live)
    {
    }

    [RecordedTest]
    [TestCase(OpenAIClientServiceTarget.Azure)]
    public async Task BasicSearchExtensionWorks(OpenAIClientServiceTarget serviceTarget)
    {
        OpenAIClient client = GetTestClient(serviceTarget);
        string deploymentOrModelName = OpenAITestBase.GetDeploymentOrModelName(
            serviceTarget,
            OpenAIClientScenario.ChatCompletions);

        var requestOptions = new ChatCompletionsOptions()
        {
            Messages =
            {
                new ChatMessage(ChatRole.User, "What does PR complete mean?"),
            },
            MaxTokens = 512,
            AzureExtensionsOptions = new()
            {
                Extensions =
                {
                    new AzureChatExtensionConfiguration()
                    {
                        Type = "AzureCognitiveSearch",
                        Parameters = BinaryData.FromObjectAsJson(new
                        {
                            Endpoint = "https://openaisdktestsearch.search.windows.net",
                            IndexName = "openai-test-index-carbon-wiki",
                            Key = GetCognitiveSearchApiKey(),
                        },
                        new JsonSerializerOptions() {  PropertyNamingPolicy = JsonNamingPolicy.CamelCase }),
                    },
                }
            },
        };

        Response<ChatCompletions> response = await client.GetChatCompletionsAsync(deploymentOrModelName, requestOptions);
        Assert.That(response, Is.Not.Null);
        Assert.That(response.Value, Is.Not.Null);
        Assert.That(response.Value.Choices, Is.Not.Null.Or.Empty);

        ChatChoice firstChoice = response.Value.Choices[0];
        Assert.That(firstChoice, Is.Not.Null);
        Assert.That(firstChoice.FinishReason, Is.EqualTo(CompletionsFinishReason.Stopped));
        Assert.That(firstChoice.Message.Role, Is.EqualTo(ChatRole.Assistant));

        AzureChatExtensionsMessageContext context = firstChoice.Message.AzureExtensionsContext;
        Assert.That(context, Is.Not.Null);
        Assert.That(context.Messages, Is.Not.Null.Or.Empty);
        Assert.That(context.Messages.First().Role, Is.EqualTo(new ChatRole("tool")));
        Assert.That(context.Messages.First().Content, Is.Not.Null.Or.Empty);
        Assert.That(context.Messages.First().Content.Contains("citations"));
    }
}
