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

    public enum ImageTestSourceKind
    {
        UsingInternetLocation,
        UsingStream,
        UsingBinaryData,
    }

    [RecordedTest]
    [TestCase(Service.Azure, ImageTestSourceKind.UsingInternetLocation)]
    [TestCase(Service.Azure, ImageTestSourceKind.UsingStream)]
    [TestCase(Service.Azure, ImageTestSourceKind.UsingBinaryData)]
    [TestCase(Service.NonAzure, ImageTestSourceKind.UsingInternetLocation)]
    [TestCase(Service.NonAzure, ImageTestSourceKind.UsingStream)]
    [TestCase(Service.NonAzure, ImageTestSourceKind.UsingBinaryData)]
    public async Task ChatWithImages(Service serviceTarget, ImageTestSourceKind imageSourceKind)
    {
        OpenAIClient client = GetTestClient(serviceTarget);
        string deploymentOrModelName = GetDeploymentOrModelName(serviceTarget);

        ChatMessageImageContentItem imageContentItem = imageSourceKind switch
        {
            ImageTestSourceKind.UsingInternetLocation => new(GetTestImageInternetUri(), ChatMessageImageDetailLevel.Low),
            ImageTestSourceKind.UsingStream => new(GetTestImageStream("image/jpg"), "image/jpg", ChatMessageImageDetailLevel.Low),
            ImageTestSourceKind.UsingBinaryData => new(GetTestImageData("image/jpg"), "image/jpg", ChatMessageImageDetailLevel.Low),
            _ => throw new ArgumentException(nameof(imageSourceKind)),
        };

        var requestOptions = new ChatCompletionsOptions()
        {
            DeploymentName = deploymentOrModelName,
            Messages =
            {
                new ChatRequestSystemMessage("You are a helpful assistant that helps describe images."),
                new ChatRequestUserMessage(
                    new ChatMessageTextContentItem("describe this image"),
                    imageContentItem),
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

        Assert.That(choice.FinishReason, Is.EqualTo(CompletionsFinishReason.Stopped));
        Assert.That(choice.Message.Role, Is.EqualTo(ChatRole.Assistant));
        Assert.That(choice.Message.Content, Is.Not.Null.Or.Empty);
    }
}
