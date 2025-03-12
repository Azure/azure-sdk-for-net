// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Inference.Tests.Samples
{
    internal class Sample12_ChatCompletionsWithAudioInput : SamplesBase<InferenceClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void AudioUrlInput()
        {
            #region Snippet:Azure_AI_Inference_AudioUrlInput
#if SNIPPET
            var endpoint = new Uri(System.Environment.GetEnvironmentVariable("AZURE_AI_CHAT_ENDPOINT"));
            var credential = new AzureKeyCredential(System.Environment.GetEnvironmentVariable("AZURE_AI_CHAT_KEY"));
#else
            var endpoint = new Uri(TestEnvironment.PhiAudioEndpoint);
            var credential = new AzureKeyCredential(TestEnvironment.PhiAudioKey);
#endif

            var client = new ChatCompletionsClient(endpoint, credential, new AzureAIInferenceClientOptions());

            var requestOptions = new ChatCompletionsOptions()
            {
                Messages =
                {
                    new ChatRequestSystemMessage("You are a helpful assistant that helps provide translations."),
                    new ChatRequestUserMessage(
                        new ChatMessageTextContentItem("Translate this audio for me"),
                        new ChatMessageAudioContentItem(new Uri("https://example.com/audio.mp3"))),
                },
            };

            Response<ChatCompletions> response = client.Complete(requestOptions);
            System.Console.WriteLine(response.Value.Content);

            #endregion

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Value, Is.InstanceOf<ChatCompletions>());
            ChatCompletions result = response.Value;
            Assert.That(result.Id, Is.Not.Null.Or.Empty);
            Assert.That(result.Created, Is.Not.Null.Or.Empty);
            Assert.That(result.FinishReason, Is.EqualTo(CompletionsFinishReason.Stopped));
            Assert.That(result.Role, Is.EqualTo(ChatRole.Assistant));
            Assert.That(result.Content, Is.Not.Null.Or.Empty);
        }

        [Test]
        [AsyncOnly]
        public async Task AudioUrlInputAsync()
        {
            var endpoint = new Uri(TestEnvironment.PhiAudioEndpoint);
            var credential = new AzureKeyCredential(TestEnvironment.PhiAudioKey);

            var client = new ChatCompletionsClient(endpoint, credential, new AzureAIInferenceClientOptions());

            var requestOptions = new ChatCompletionsOptions()
            {
                Messages =
                {
                    new ChatRequestSystemMessage("You are a helpful assistant that helps provide translations."),
                    new ChatRequestUserMessage(
                        new ChatMessageTextContentItem("Translate this audio for me"),
                        new ChatMessageAudioContentItem(new Uri("https://example.com/audio.mp3"))),
                },
            };

            #region Snippet:Azure_AI_Inference_AudioInputAsync

            Response<ChatCompletions> response = await client.CompleteAsync(requestOptions);
            System.Console.WriteLine(response.Value.Content);

            #endregion

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Value, Is.InstanceOf<ChatCompletions>());
            ChatCompletions result = response.Value;
            Assert.That(result.Id, Is.Not.Null.Or.Empty);
            Assert.That(result.Created, Is.Not.Null.Or.Empty);
            Assert.That(result.FinishReason, Is.EqualTo(CompletionsFinishReason.Stopped));
            Assert.That(result.Role, Is.EqualTo(ChatRole.Assistant));
            Assert.That(result.Content, Is.Not.Null.Or.Empty);
        }

        [Test]
        [SyncOnly]
        public void AudioDataInput()
        {
            #region Snippet:Azure_AI_Inference_AudioDataFileInput
#if SNIPPET
            var endpoint = new Uri(System.Environment.GetEnvironmentVariable("AZURE_AI_CHAT_ENDPOINT"));
            var credential = new AzureKeyCredential(System.Environment.GetEnvironmentVariable("AZURE_AI_CHAT_KEY"));

            ChatMessageAudioContentItem audioContentItem = new ChatMessageAudioContentItem("sample_audio.mp3", AudioContentFormat.Mp3);
#else
            var endpoint = new Uri(TestEnvironment.AoaiAudioEndpoint);
            var credential = new AzureKeyCredential(TestEnvironment.AoaiAudioKey);

            ChatMessageAudioContentItem audioContentItem = new ChatMessageAudioContentItem(TestEnvironment.TestAudioMp3InputPath, AudioContentFormat.Mp3);
#endif

            var client = new ChatCompletionsClient(endpoint, credential, new AzureAIInferenceClientOptions());

            var requestOptions = new ChatCompletionsOptions()
            {
                Messages =
                {
                    new ChatRequestSystemMessage("You are a helpful assistant that helps provide translations."),
                    new ChatRequestUserMessage(
                        new ChatMessageTextContentItem("Translate this audio for me"),
                        new ChatMessageAudioContentItem(new Uri("https://example.com/audio.mp3"))),
                },
            };

            Response<ChatCompletions> response = client.Complete(requestOptions);
            System.Console.WriteLine(response.Value.Content);

            #endregion

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Value, Is.InstanceOf<ChatCompletions>());
            ChatCompletions result = response.Value;
            Assert.That(result.Id, Is.Not.Null.Or.Empty);
            Assert.That(result.Created, Is.Not.Null.Or.Empty);
            Assert.That(result.FinishReason, Is.EqualTo(CompletionsFinishReason.Stopped));
            Assert.That(result.Role, Is.EqualTo(ChatRole.Assistant));
            Assert.That(result.Content, Is.Not.Null.Or.Empty);
        }
    }
}
