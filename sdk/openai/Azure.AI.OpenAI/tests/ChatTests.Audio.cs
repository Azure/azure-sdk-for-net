// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.OpenAI.Chat;
using OpenAI.Chat;
using OpenAI.TestFramework;

namespace Azure.AI.OpenAI.Tests;

public partial class ChatTests
{
    [RecordedTest]
    public async Task ChatAudioWorks()
    {
        ChatClient client = GetTestClient("chat_audio");

        // Part 1a: exercise non-streaming request for text & audio via a user message with (input) audio content

        BinaryData helloWorldAudioBytes = BinaryData.FromBytes(File.ReadAllBytes(Assets.HelloWorldMp3.RelativePath));
        ChatMessageContentPart helloWorldAudioContentPart = ChatMessageContentPart.CreateInputAudioPart(
            helloWorldAudioBytes,
            ChatInputAudioFormat.Mp3);

        List<ChatMessage> messages = [new UserChatMessage([helloWorldAudioContentPart])];

        ChatCompletionOptions options = new()
        {
            ResponseModalities = ChatResponseModalities.Text | ChatResponseModalities.Audio,
            AudioOptions = new(ChatOutputAudioVoice.Alloy, ChatOutputAudioFormat.Pcm16)
        };

        // Part 1b: verify non-streaming response audio

        ChatCompletion completion = await client.CompleteChatAsync(messages, options);
        Assert.That(completion, Is.Not.Null);
        Assert.That(completion.Content, Has.Count.EqualTo(0));

        ChatOutputAudio outputAudio = completion.OutputAudio;
        Assert.That(outputAudio, Is.Not.Null);
        Assert.That(outputAudio.Id, Is.Not.Null.And.Not.Empty);
        Assert.That(outputAudio.AudioBytes, Is.Not.Null);
        Assert.That(outputAudio.Transcript, Is.Not.Null.And.Not.Empty);
        Assert.That(outputAudio.ExpiresAt, Is.GreaterThan(new DateTimeOffset(2024, 11, 1, 0, 0, 0, TimeSpan.Zero)));

        // Part 2: verify construction of conversation history with past response message audio (via ID)

        AssistantChatMessage audioHistoryMessage = ChatMessage.CreateAssistantMessage(completion);
        Assert.That(audioHistoryMessage, Is.InstanceOf<AssistantChatMessage>());
        Assert.That(audioHistoryMessage.Content, Has.Count.EqualTo(0));

        Assert.That(audioHistoryMessage.OutputAudioReference?.Id, Is.EqualTo(completion.OutputAudio.Id));
        messages.Add(audioHistoryMessage);

        // Part 2b: add another, new audio content part (user message) afterwards

        BinaryData whatsTheWeatherAudioBytes = BinaryData.FromBytes(File.ReadAllBytes(Assets.AudioWhatsTheWeatherPcm16.RelativePath));
        ChatMessageContentPart whatsTheWeatherAudioContentPart = ChatMessageContentPart.CreateInputAudioPart(
            whatsTheWeatherAudioBytes,
            ChatInputAudioFormat.Wav);

        messages.Add(
            new UserChatMessage(
                [
                    "Please answer the following spoken question:",
                    ChatMessageContentPart.CreateInputAudioPart(whatsTheWeatherAudioBytes, ChatInputAudioFormat.Wav),
                ]));

        // Part 3: verify streaming response audio

        string? streamedCorrelationId = null;
        DateTimeOffset? streamedExpiresAt = null;
        StringBuilder streamedTranscriptBuilder = new();
        using MemoryStream outputAudioStream = new();
        ChatTokenUsage? streamedUsage = null;
        await foreach (StreamingChatCompletionUpdate update in client.CompleteChatStreamingAsync(messages, options))
        {
            Assert.That(update.ContentUpdate, Has.Count.EqualTo(0));
            StreamingChatOutputAudioUpdate outputAudioUpdate = update.OutputAudioUpdate;

            if (update.Usage is not null)
            {
                Assert.That(streamedUsage, Is.Null);
                streamedUsage = update.Usage;
            }
            if (outputAudioUpdate is not null)
            {
                string serializedOutputAudioUpdate = ModelReaderWriter.Write(outputAudioUpdate).ToString();
                Assert.That(serializedOutputAudioUpdate, Is.Not.Null.And.Not.Empty);

                if (outputAudioUpdate.Id is not null)
                {
                    Assert.That(streamedCorrelationId, Is.Null.Or.EqualTo(streamedCorrelationId));
                    streamedCorrelationId ??= outputAudioUpdate.Id;
                }
                if (outputAudioUpdate.ExpiresAt.HasValue)
                {
                    Assert.That(streamedExpiresAt.HasValue, Is.False);
                    streamedExpiresAt = outputAudioUpdate.ExpiresAt;
                }
                streamedTranscriptBuilder.Append(outputAudioUpdate.TranscriptUpdate);
                byte[] audioUpdateBytes = outputAudioUpdate.AudioBytesUpdate?.ToArray() ?? [];
                outputAudioStream.Write(audioUpdateBytes, 0, audioUpdateBytes.Length);
            }
        }
        Assert.That(streamedCorrelationId, Is.Not.Null.And.Not.Empty);
        Assert.That(streamedExpiresAt.HasValue, Is.True);
        Assert.That(streamedTranscriptBuilder.ToString(), Is.Not.Null.And.Not.Empty);
        Assert.That(outputAudioStream.Length, Is.GreaterThan(9000));
        Assert.That(streamedUsage?.InputTokenDetails?.AudioTokenCount, Is.GreaterThan(0));
        Assert.That(streamedUsage?.OutputTokenDetails?.AudioTokenCount, Is.GreaterThan(0));
    }
}
