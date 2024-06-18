﻿using System;
using System.ClientModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Azure.AI.OpenAI.Chat;
using Azure.Core.TestFramework;
using OpenAI.Chat;

namespace Azure.AI.OpenAI.Tests
{
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
                imagePart = ChatMessageContentPart.CreateImageMessageContentPart(
                    imageAsset.Url, ImageChatMessageContentPartDetail.Low);
            }
            else
            {
                using var stream = File.OpenRead(imageAsset.RelativePath);
                var imageData = BinaryData.FromStream(stream);

                imagePart = ChatMessageContentPart.CreateImageMessageContentPart(
                    imageData, imageAsset.MimeType, ImageChatMessageContentPartDetail.Low);
            }

            ChatMessage[] messages =
            [
                new SystemChatMessage("You are a helpful assistant that helps describe images."),
                new UserChatMessage(imagePart, ChatMessageContentPart.CreateTextMessageContentPart("describe this image"))
            ];

            ChatCompletionOptions options = new()
            {
                MaxTokens = 2048,
            };

            var response = await client.CompleteChatAsync(messages, options);
            Assert.That(response, Is.Not.Null);

            Assert.That(response.Value.Id, Is.Not.Null.Or.Empty);
            Assert.That(response.Value.CreatedAt, Is.GreaterThan(new DateTimeOffset(2024, 01, 01, 00, 00, 00, TimeSpan.Zero)));
            Assert.That(response.Value.FinishReason, Is.EqualTo(ChatFinishReason.Stop));
            Assert.That(response.Value.Role, Is.EqualTo(ChatMessageRole.Assistant));
            Assert.That(response.Value.Usage, Is.Not.Null);
            Assert.That(response.Value.Usage.InputTokens, Is.GreaterThan(10));
            Assert.That(response.Value.Usage.OutputTokens, Is.GreaterThan(10));
            Assert.That(response.Value.Usage.TotalTokens, Is.GreaterThan(20));

            Assert.That(response.Value.Content, Has.Count.EqualTo(1));
            ChatMessageContentPart choice = response.Value.Content[0];
            Assert.That(choice.Kind, Is.EqualTo(ChatMessageContentPartKind.Text));
            Assert.That(choice.Text, Is.Not.Null.Or.Empty);
            Assert.That(choice.Text.ToLowerInvariant(), Does.Contain("dog").Or.Contain("cat"));

            // TODO FIXME: Some models (e.g. gpt-4o either randomly return prompt filters with some missing entries)
            var promptFilter = response.Value.GetContentFilterResultForPrompt();
            Assert.That(promptFilter, Is.Not.Null);
            //Assert.That(promptFilter.Hate, Is.Not.Null);
            //Assert.That(promptFilter.Hate.Filtered, Is.False);
            //Assert.That(promptFilter.Hate.Severity, Is.EqualTo(ContentFilterSeverity.Safe));

            var responseFilter = response.Value.GetContentFilterResultForResponse();
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
            StringBuilder content = new();

            ChatClient client = GetTestClient("vision");

            ChatMessageContentPart imagePart;
            var imageAsset = Assets.DogAndCat;
            if (useUri)
            {
                imagePart = ChatMessageContentPart.CreateImageMessageContentPart(
                    imageAsset.Url, ImageChatMessageContentPartDetail.Low);
            }
            else
            {
                using var stream = File.OpenRead(imageAsset.RelativePath);
                var imageData = BinaryData.FromStream(stream);

                imagePart = ChatMessageContentPart.CreateImageMessageContentPart(
                    imageData, imageAsset.MimeType, ImageChatMessageContentPartDetail.Low);
            }

            ChatMessage[] messages =
            [
                new SystemChatMessage("You are a helpful assistant that helps describe images."),
                new UserChatMessage(imagePart, ChatMessageContentPart.CreateTextMessageContentPart("describe this image"))
            ];

            ChatCompletionOptions options = new()
            {
                MaxTokens = 2048,
            };

            AsyncResultCollection<StreamingChatCompletionUpdate> response = SyncOrAsync(client,
                c => c.CompleteChatStreaming(messages, options),
                c => c.CompleteChatStreamingAsync(messages, options));
            Assert.That(response, Is.Not.Null);

            await foreach (StreamingChatCompletionUpdate update in response)
            {
                ValidateUpdate(update, content, ref foundPromptFilter, ref foundResponseFilter);
            }

            // TOOD FIXME: gpt-4o models seem to return inconsistent prompt filters to skip this for now
            //Assert.That(foundPromptFilter, Is.True);
            Assert.That(foundResponseFilter, Is.True);
            Assert.That(content, Has.Length.GreaterThan(0));

            string c = content.ToString().ToLowerInvariant();
            Assert.That(c, Does.Contain("dog").Or.Contain("cat"));
        }
    }
}
