// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Azure.AI.OpenAI.Chat;
using OpenAI.Chat;
using OpenAI.TestFramework;

namespace Azure.AI.OpenAI.Tests;

public partial class ChatTests
{
    [RecordedTest]
    [TestCase(true)]
    [TestCase(false)]
    public async Task ChatWithImages(bool useUri)
    {
        var imageAsset = Assets.DogAndCat;
        ChatClient client = GetTestClient("vision");

        ChatMessageContentPart imagePart;
        if (useUri)
        {
            imagePart = ChatMessageContentPart.CreateImagePart(
                imageAsset.Url, ChatImageDetailLevel.Low);
        }
        else
        {
            using var stream = File.OpenRead(imageAsset.RelativePath);
            var imageData = BinaryData.FromStream(stream);

            imagePart = ChatMessageContentPart.CreateImagePart(
                imageData, imageAsset.MimeType, ChatImageDetailLevel.Low);
        }

        ChatMessage[] messages =
        [
            new SystemChatMessage("You are a helpful assistant that helps describe images."),
            new UserChatMessage(imagePart, ChatMessageContentPart.CreateTextPart("describe this image"))
        ];

        ChatCompletionOptions options = new()
        {
            MaxOutputTokenCount = 2048,
        };

        var response = await client.CompleteChatAsync(messages, options);
        Assert.That(response, Is.Not.Null);

        Assert.That(response.Value.Id, Is.Not.Null.Or.Empty);
        Assert.That(response.Value.CreatedAt, Is.GreaterThan(START_2024));
        Assert.That(response.Value.FinishReason, Is.EqualTo(ChatFinishReason.Stop));
        Assert.That(response.Value.Role, Is.EqualTo(ChatMessageRole.Assistant));
        Assert.That(response.Value.Usage, Is.Not.Null);
        Assert.That(response.Value.Usage.InputTokenCount, Is.GreaterThan(10));
        Assert.That(response.Value.Usage.OutputTokenCount, Is.GreaterThan(10));
        Assert.That(response.Value.Usage.TotalTokenCount, Is.GreaterThan(20));

        Assert.That(response.Value.Content, Has.Count.EqualTo(1));
        ChatMessageContentPart choice = response.Value.Content[0];
        Assert.That(choice.Kind, Is.EqualTo(ChatMessageContentPartKind.Text));
        Assert.That(choice.Text, Is.Not.Null.Or.Empty);
        Assert.That(choice.Text.ToLowerInvariant(), Does.Contain("dog").Or.Contain("cat"));

        // TODO FIXME: Some models (e.g. gpt-4o either randomly return prompt filters with some missing entries)
        var promptFilter = response.Value.GetRequestContentFilterResult();
        Assert.That(promptFilter, Is.Not.Null);
        //Assert.That(promptFilter.Hate, Is.Not.Null);
        //Assert.That(promptFilter.Hate.Filtered, Is.False);
        //Assert.That(promptFilter.Hate.Severity, Is.EqualTo(ContentFilterSeverity.Safe));

        var responseFilter = response.Value.GetResponseContentFilterResult();
        Assert.That(responseFilter, Is.Not.Null);
        Assert.That(responseFilter.Hate, Is.Not.Null);
        Assert.That(responseFilter.Hate.Filtered, Is.False);
        Assert.That(responseFilter.Hate.Severity, Is.EqualTo(ContentFilterSeverity.Safe));
    }

    [RecordedTest]
    [TestCase(true)]
    [TestCase(false)]
    public async Task ChatWithImagesStreaming(bool useUri)
    {
        bool foundPromptFilter = false;
        bool foundResponseFilter = false;
        ChatTokenUsage? usage = null;
        StringBuilder content = new();

        ChatClient client = GetTestClient("vision");

        ChatMessageContentPart imagePart;
        var imageAsset = Assets.DogAndCat;
        if (useUri)
        {
            imagePart = ChatMessageContentPart.CreateImagePart(
                imageAsset.Url, ChatImageDetailLevel.Low);
        }
        else
        {
            using var stream = File.OpenRead(imageAsset.RelativePath);
            var imageData = BinaryData.FromStream(stream);

            imagePart = ChatMessageContentPart.CreateImagePart(
                imageData, imageAsset.MimeType, ChatImageDetailLevel.Low);
        }

        ChatMessage[] messages =
        [
            new SystemChatMessage("You are a helpful assistant that helps describe images."),
            new UserChatMessage(imagePart, ChatMessageContentPart.CreateTextPart("describe this image"))
        ];

        ChatCompletionOptions options = new()
        {
            MaxOutputTokenCount = 2048,
        };

        AsyncCollectionResult<StreamingChatCompletionUpdate> response = client.CompleteChatStreamingAsync(messages, options);
        Assert.That(response, Is.Not.Null);

        await foreach (StreamingChatCompletionUpdate update in response)
        {
            ValidateUpdate(update, content, ref foundPromptFilter, ref foundResponseFilter, ref usage);
        }

        // Assert.That(usage, Is.Not.Null);

        // TODO FIXME: gpt-4o models seem to return inconsistent prompt filters to skip this for now
        //Assert.That(foundPromptFilter, Is.True);

        Assert.That(content, Has.Length.GreaterThan(0));

        string c = content.ToString().ToLowerInvariant();
        Assert.That(c, Does.Contain("dog").Or.Contain("cat"));
    }

    [RecordedTest]
    [Ignore("File input not yet supported as of 2025-03-01-preview")]
    public async Task ChatWithBinaryFileContent()
    {
        ChatMessageContentPart binaryFileContentPart
            = ChatMessageContentPart.CreateFilePart(
                fileBytes: BinaryData.FromStream(
                    File.OpenRead(
                        Path.Combine("Assets", "files_travis_favorite_food.pdf"))),
                fileBytesMediaType: "application/pdf",
                "test_travis_favorite_food.pdf");
        Assert.That(binaryFileContentPart.FileBytes, Is.Not.Null);
        Assert.That(binaryFileContentPart.FileBytesMediaType, Is.EqualTo("application/pdf"));
        Assert.That(binaryFileContentPart.Filename, Is.EqualTo("test_travis_favorite_food.pdf"));
        Assert.That(binaryFileContentPart.FileId, Is.Null);

        ChatClient client = GetTestClient();

        ChatCompletion completion = await client.CompleteChatAsync(
            [
                ChatMessage.CreateUserMessage(
                    "Based on the following, what food should I order for whom?",
                    binaryFileContentPart)
            ]);
        Assert.That(completion?.Content, Is.Not.Null.And.Not.Empty);
        Assert.That(completion?.Content[0].Text?.ToLower(), Does.Contain("pizza"));
    }
}
