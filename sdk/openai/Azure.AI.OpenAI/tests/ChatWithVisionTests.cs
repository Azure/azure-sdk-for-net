// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
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
    // [TestCase(Service.Azure)]
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
                        new Uri("https://pixabay.com/get/geda00efcc8ef894b12c436613df5a3dd9baa2e733227c533d39fbb3474f33f0e90ffb27b80837c636a074d19aa882bcf4ff8f5bf18645eef88188e73927c383a33ecbe1a8cc4b40139c0132f4ee418d9_640.jpg"))),
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
        Assert.That(choice.FinishDetails, Is.InstanceOf<StopFinishDetails>());
        Assert.That(choice.Message.Role, Is.EqualTo(ChatRole.Assistant));
        Assert.That(choice.Message.Content, Is.Not.Null.Or.Empty);
    }
}
