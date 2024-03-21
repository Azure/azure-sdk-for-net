// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.OpenAI.Tests;

public class ChatWithVisionTests : OpenAITestBase
{
    public ChatWithVisionTests(bool isAsync)
        : base(Scenario.VisionPreview, isAsync) // , RecordedTestMode.Live)
    {
    }

    [RecordedTest]
    [TestCase(Service.Azure)]
    [TestCase(Service.NonAzure)]
    public async Task ChatWithImages(Service serviceTarget)
    {
        OpenAIClient client = GetTestClient(serviceTarget);
        string deploymentOrModelName = GetDeploymentOrModelName(serviceTarget);
        var requestOptions = new ChatCompletionsOptions()
        {
            DeploymentName = deploymentOrModelName,
            Messages =
            {
                new ChatRequestSystemMessage("You are a helpful assistant that helps describe images."),
                new ChatRequestUserMessage(
                    new ChatMessageTextContentItem("describe this image"),
                    new ChatMessageImageContentItem(
                        new Uri("https://www.bing.com/th?id=OHR.BradgateFallow_EN-US3932725763_1920x1080.jpg"),
                        ChatMessageImageDetailLevel.Low)),
            },
            MaxTokens = 2048,
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

        // Check temporarily disabled for Azure
        if (serviceTarget != Service.Azure)
        {
            Assert.That(choice.FinishReason != null || choice.FinishDetails != null);
            if (choice.FinishReason == null)
            {
                Assert.That(choice.FinishDetails, Is.InstanceOf<StopFinishDetails>());
            }
            else if (choice.FinishDetails == null)
            {
                Assert.That(choice.FinishReason == CompletionsFinishReason.Stopped);
            }
        }

        Assert.That(choice.Message.Role, Is.EqualTo(ChatRole.Assistant));
        Assert.That(choice.Message.Content, Is.Not.Null.Or.Empty);
    }
}
