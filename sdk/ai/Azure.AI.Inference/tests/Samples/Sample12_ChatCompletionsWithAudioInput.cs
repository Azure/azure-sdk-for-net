// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
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

            ChatMessageAudioContentItem audioContentItem = new ChatMessageAudioContentItem(new Uri("https://example.com/audio.mp3"));
#else
            var endpoint = new Uri(TestEnvironment.PhiAudioEndpoint);
            var credential = new AzureKeyCredential(TestEnvironment.PhiAudioKey);

            ChatMessageAudioContentItem audioContentItem = new ChatMessageAudioContentItem(new Uri("https://github.com/Azure/azure-sdk-for-net/raw/refs/heads/main/sdk/ai/Azure.AI.Inference/tests/Data/hello_how_are_you.mp3"));
#endif

            var client = new ChatCompletionsClient(endpoint, credential, new AzureAIInferenceClientOptions());

            var requestOptions = new ChatCompletionsOptions()
            {
                Messages =
                {
                    new ChatRequestSystemMessage("You are a helpful assistant that helps provide translations."),
                    new ChatRequestUserMessage(
                        new ChatMessageTextContentItem("Translate this audio for me"),
                        audioContentItem),
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

            ChatMessageAudioContentItem audioContentItem = new ChatMessageAudioContentItem(new Uri("https://github.com/Azure/azure-sdk-for-net/raw/refs/heads/main/sdk/ai/Azure.AI.Inference/tests/Data/hello_how_are_you.mp3"));

            var requestOptions = new ChatCompletionsOptions()
            {
                Messages =
                {
                    new ChatRequestSystemMessage("You are a helpful assistant that helps provide translations."),
                    new ChatRequestUserMessage(
                        new ChatMessageTextContentItem("Translate this audio for me"),
                        audioContentItem),
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

            var client = new ChatCompletionsClient(endpoint, credential, new AzureAIInferenceClientOptions());
#else
            var endpoint = new Uri(TestEnvironment.AoaiAudioEndpoint);
            var credential = new AzureKeyCredential(TestEnvironment.AoaiAudioKey);

            ChatMessageAudioContentItem audioContentItem = new ChatMessageAudioContentItem(TestEnvironment.TestAudioMp3InputPath, AudioContentFormat.Mp3);

            var clientOptions = new AzureAIInferenceClientOptions();

            OverrideApiVersionPolicy overrideApiVersionPolicy = new OverrideApiVersionPolicy("2024-11-01-preview");
            clientOptions.AddPolicy(overrideApiVersionPolicy, HttpPipelinePosition.PerRetry);

            var client = new ChatCompletionsClient(endpoint, credential, clientOptions);
#endif

            var requestOptions = new ChatCompletionsOptions()
            {
                Messages =
                {
                    new ChatRequestSystemMessage("You are a helpful assistant that helps provide translations."),
                    new ChatRequestUserMessage(
                        new ChatMessageTextContentItem("Translate this audio for me"),
                        audioContentItem),
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

        private class OverrideApiVersionPolicy : HttpPipelinePolicy
        {
            private string ApiVersion { get; }

            public OverrideApiVersionPolicy(string apiVersion)
            {
                ApiVersion = apiVersion;
            }

            public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            {
                message.Request.Uri.Query = $"?api-version={ApiVersion}";
                ProcessNext(message, pipeline);
            }

            public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            {
                message.Request.Uri.Query = $"?api-version={ApiVersion}";
                var task = ProcessNextAsync(message, pipeline);

                return task;
            }
        }
    }
}
