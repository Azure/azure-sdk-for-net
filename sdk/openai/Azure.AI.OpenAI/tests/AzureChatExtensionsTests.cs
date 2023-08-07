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
    public async Task StubbedTestForDevelopment(OpenAIClientServiceTarget serviceTarget)
    {
        OpenAIClient client = GetTestClient(serviceTarget);
        string deploymentOrModelName = OpenAITestBase.GetDeploymentOrModelName(
            serviceTarget,
            OpenAIClientScenario.ChatCompletions);

        var requestOptions = new ChatCompletionsOptions()
        {
            Messages =
            {
                new ChatMessage(ChatRole.System, "You are a helpful assistant."),
                new ChatMessage(ChatRole.User, "What's the best kind of pizza?"),
            },
            MaxTokens = 512,
            AzureExtensionsOptions = new()
            {
                Extensions =
                {
                    new AzureChatExtensionConfiguration()
                    {
                        Type = "TestAzureChatExtensionType",
                        Parameters = BinaryData.FromObjectAsJson(new
                        {
                            SomeProperty = "SomeValue",
                        },
                        new JsonSerializerOptions() {  PropertyNamingPolicy = JsonNamingPolicy.CamelCase }),
                    },
                }
            },
        };

        Response<ChatCompletions> response = await client.GetChatCompletionsAsync(deploymentOrModelName, requestOptions);
        Assert.That(response, Is.Not.Null);

        AzureChatExtensionsMessageContext context = response.Value.Choices[0].Message.AzureExtensionsContext;
        Assert.That(context, Is.Not.Null);
        Assert.That(context.Messages, Is.Not.Null.Or.Empty);
    }
}
