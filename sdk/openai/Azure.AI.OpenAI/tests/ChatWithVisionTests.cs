// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.Mime;
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

    public enum ImageInputKind
    {
        InternetUrl,
        LocalJpegData,
        LocalPngData
    }

    public enum ImageDetailKind
    {
        None,
        Low,
        High
    };

    [RecordedTest]
    [TestCase(Service.Azure, ImageInputKind.InternetUrl)]
    [TestCase(Service.Azure, ImageInputKind.LocalJpegData)]
    [TestCase(Service.Azure, ImageInputKind.LocalPngData)]
    [TestCase(Service.Azure, ImageInputKind.LocalPngData, ImageDetailKind.Low)]
    [TestCase(Service.NonAzure, ImageInputKind.InternetUrl)]
    [TestCase(Service.NonAzure, ImageInputKind.LocalJpegData)]
    [TestCase(Service.NonAzure, ImageInputKind.LocalPngData)]
    [TestCase(Service.NonAzure, ImageInputKind.LocalPngData, ImageDetailKind.Low)]
    public async Task ChatWithImages(Service serviceTarget, ImageInputKind imageInputKind, ImageDetailKind detailKind = ImageDetailKind.None)
    {
        OpenAIClient client = GetTestClient(serviceTarget);
        string deploymentOrModelName = GetDeploymentOrModelName(serviceTarget);

        ChatMessageImageContentItem imageContentItem = imageInputKind switch
        {
            ImageInputKind.InternetUrl => new(GetTestImageInternetUrl()),
            ImageInputKind.LocalJpegData => new(GetTestImageData(MediaTypeNames.Image.Jpeg)),
            ImageInputKind.LocalPngData => detailKind switch
            {
                ImageDetailKind.None => new(GetTestImageData("image/png"), "image/png"),
                ImageDetailKind.Low => new(GetTestImageData("image/png"), "image/png", ChatMessageImageDetailLevel.Low),
                ImageDetailKind.High => new(GetTestImageData("image/png"), "image/png", ChatMessageImageDetailLevel.High),
            _ => throw new NotImplementedException($"Unsupported detail kind: {detailKind}")
            },
            _ => throw new NotImplementedException($"Unsupported input kind: {imageInputKind}")
        };
        ;

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

        Assert.That(choice.FinishReason != null || choice.FinishDetails != null);
        if (choice.FinishReason == null)
        {
            Assert.That(choice.FinishDetails, Is.InstanceOf<StopFinishDetails>());
        }
        else if (choice.FinishDetails == null)
        {
            Assert.That(choice.FinishReason == CompletionsFinishReason.Stopped);
        }

        Assert.That(choice.Message.Role, Is.EqualTo(ChatRole.Assistant));
        Assert.That(choice.Message.Content, Is.Not.Null.Or.Empty);
    }
}
