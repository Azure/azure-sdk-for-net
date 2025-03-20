// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Pipeline;
using Azure.Core;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using System.IO;

namespace Azure.AI.Inference.Tests.Samples
{
    public class Sample5_ChatCompletionsWithImages : SamplesBase<InferenceClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void ChatCompletionsWithImageUrlScenario()
        {
            #region Snippet:Azure_AI_Inference_ChatCompletionsWithImageUrlScenario
#if SNIPPET
            var endpoint = new Uri(System.Environment.GetEnvironmentVariable("AZURE_AI_CHAT_ENDPOINT"));
            var credential = new AzureKeyCredential(System.Environment.GetEnvironmentVariable("AZURE_AI_CHAT_KEY"));

            var client = new ChatCompletionsClient(endpoint, credential, new AzureAIInferenceClientOptions());

            ChatMessageImageContentItem imageContentItem =
                new ChatMessageImageContentItem(
                    new Uri("https://example.com/image.jpg"),
                    ChatMessageImageDetailLevel.Low
                );
#else
            var endpoint = new Uri(TestEnvironment.AoaiEndpoint);
            var credential = new AzureKeyCredential("foo");
            var key = TestEnvironment.AoaiKey;

            AzureAIInferenceClientOptions clientOptions = new AzureAIInferenceClientOptions();
            clientOptions.AddPolicy(new AddAoaiAuthHeaderPolicy(key), HttpPipelinePosition.PerCall);

            var client = new ChatCompletionsClient(endpoint, credential, clientOptions);

            ChatMessageImageContentItem imageContentItem =
                new ChatMessageImageContentItem(
                    new Uri("https://aka.ms/azsdk/azure-ai-inference/csharp/tests/juggling_balls.png"),
                    ChatMessageImageDetailLevel.Low
                );
#endif

            var requestOptions = new ChatCompletionsOptions()
            {
                Messages =
                {
                    new ChatRequestSystemMessage("You are a helpful assistant that helps describe images."),
                    new ChatRequestUserMessage(
                        new ChatMessageTextContentItem("describe this image"),
                        imageContentItem),
                },
            };

            Response<ChatCompletions> response = client.Complete(requestOptions);
            System.Console.WriteLine(response.Value.Content);
            #endregion

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Value, Is.InstanceOf<ChatCompletions>());
            Assert.That(response.Value.Id, Is.Not.Null.Or.Empty);
            Assert.That(response.Value.Created, Is.Not.Null.Or.Empty);
            ChatCompletions result = response.Value;
            Assert.That(result.FinishReason, Is.EqualTo(CompletionsFinishReason.Stopped));
            Assert.That(result.Role, Is.EqualTo(ChatRole.Assistant));
            Assert.That(result.Content, Is.Not.Null.Or.Empty);
        }

        [Test]
        [AsyncOnly]
        public async Task ChatCompletionsWithImageUrlScenarioAsync()
        {
            #region Snippet:Azure_AI_Inference_ChatCompletionsWithImageUrlScenarioAsync
#if SNIPPET
            var endpoint = new Uri(System.Environment.GetEnvironmentVariable("AZURE_AI_CHAT_ENDPOINT"));
            var credential = new AzureKeyCredential(System.Environment.GetEnvironmentVariable("AZURE_AI_CHAT_KEY"));

            var client = new ChatCompletionsClient(endpoint, credential, new AzureAIInferenceClientOptions());

            ChatMessageImageContentItem imageContentItem =
                new ChatMessageImageContentItem(
                    new Uri("https://example.com/image.jpg"),
                    ChatMessageImageDetailLevel.Low
                );
#else
            var endpoint = new Uri(TestEnvironment.AoaiEndpoint);
            var credential = new AzureKeyCredential("foo");
            var key = TestEnvironment.AoaiKey;

            AzureAIInferenceClientOptions clientOptions = new AzureAIInferenceClientOptions();
            clientOptions.AddPolicy(new AddAoaiAuthHeaderPolicy(key), HttpPipelinePosition.PerCall);

            var client = new ChatCompletionsClient(endpoint, credential, clientOptions);

            ChatMessageImageContentItem imageContentItem =
                new ChatMessageImageContentItem(
                    new Uri("https://aka.ms/azsdk/azure-ai-inference/csharp/tests/juggling_balls.png"),
                    ChatMessageImageDetailLevel.Low
                );
#endif

            var requestOptions = new ChatCompletionsOptions()
            {
                Messages =
                {
                    new ChatRequestSystemMessage("You are a helpful assistant that helps describe images."),
                    new ChatRequestUserMessage(
                        new ChatMessageTextContentItem("describe this image"),
                        imageContentItem),
                },
            };

            Response<ChatCompletions> response = await client.CompleteAsync(requestOptions);
            System.Console.WriteLine(response.Value.Content);
            #endregion

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Value, Is.InstanceOf<ChatCompletions>());
            Assert.That(response.Value.Id, Is.Not.Null.Or.Empty);
            Assert.That(response.Value.Created, Is.Not.Null.Or.Empty);
            ChatCompletions result = response.Value;
            Assert.That(result.FinishReason, Is.EqualTo(CompletionsFinishReason.Stopped));
            Assert.That(result.Role, Is.EqualTo(ChatRole.Assistant));
            Assert.That(result.Content, Is.Not.Null.Or.Empty);
        }

        [Test]
        [SyncOnly]
        public void ChatCompletionsWithImageStreamScenario()
        {
            var endpoint = new Uri(TestEnvironment.AoaiEndpoint);
            var credential = new AzureKeyCredential("foo");
            var key = TestEnvironment.AoaiKey;

            AzureAIInferenceClientOptions clientOptions = new AzureAIInferenceClientOptions();
            clientOptions.AddPolicy(new AddAoaiAuthHeaderPolicy(key), HttpPipelinePosition.PerCall);

            var client = new ChatCompletionsClient(endpoint, credential, clientOptions);

            #region Snippet:Azure_AI_Inference_ChatCompletionsWithImageStreamScenario
#if SNIPPET
            Stream imageStream = File.OpenRead("sample_image_path");

            ChatMessageImageContentItem imageContentItem =
                new ChatMessageImageContentItem(
                    imageStream,
                    "image/jpg",
                    ChatMessageImageDetailLevel.Low
                );
#else
            Stream imageStream = File.OpenRead(TestEnvironment.TestImagePngInputPath);

            ChatMessageImageContentItem imageContentItem =
                new ChatMessageImageContentItem(
                    imageStream,
                    "image/jpg",
                    ChatMessageImageDetailLevel.Low
                );
#endif

            var requestOptions = new ChatCompletionsOptions()
            {
                Messages =
                {
                    new ChatRequestSystemMessage("You are a helpful assistant that helps describe images."),
                    new ChatRequestUserMessage(
                        new ChatMessageTextContentItem("describe this image"),
                        imageContentItem),
                },
            };

            Response<ChatCompletions> response = client.Complete(requestOptions);
            System.Console.WriteLine(response.Value.Content);
            #endregion

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Value, Is.InstanceOf<ChatCompletions>());
            Assert.That(response.Value.Id, Is.Not.Null.Or.Empty);
            Assert.That(response.Value.Created, Is.Not.Null.Or.Empty);
            ChatCompletions result = response.Value;
            Assert.That(result.FinishReason, Is.EqualTo(CompletionsFinishReason.Stopped));
            Assert.That(result.Role, Is.EqualTo(ChatRole.Assistant));
            Assert.That(result.Content, Is.Not.Null.Or.Empty);
        }

        [Test]
        [SyncOnly]
        public void ChatCompletionsWithImagePathScenario()
        {
            var endpoint = new Uri(TestEnvironment.AoaiEndpoint);
            var credential = new AzureKeyCredential("foo");
            var key = TestEnvironment.AoaiKey;

            AzureAIInferenceClientOptions clientOptions = new AzureAIInferenceClientOptions();
            clientOptions.AddPolicy(new AddAoaiAuthHeaderPolicy(key), HttpPipelinePosition.PerCall);

            var client = new ChatCompletionsClient(endpoint, credential, clientOptions);

            #region Snippet:Azure_AI_Inference_ChatCompletionsWithImagePathScenario
#if SNIPPET
            ChatMessageImageContentItem imageContentItem =
                new ChatMessageImageContentItem(
                    "sample_image_path",
                    "image/jpg",
                    ChatMessageImageDetailLevel.Low
                );
#else
            ChatMessageImageContentItem imageContentItem =
                new ChatMessageImageContentItem(
                    TestEnvironment.TestImagePngInputPath,
                    "image/png",
                    ChatMessageImageDetailLevel.Low
                );
#endif
            #endregion

            var requestOptions = new ChatCompletionsOptions()
            {
                Messages =
                {
                    new ChatRequestSystemMessage("You are a helpful assistant that helps describe images."),
                    new ChatRequestUserMessage(
                        new ChatMessageTextContentItem("describe this image"),
                        imageContentItem),
                },
            };

            var response = client.Complete(requestOptions);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Value, Is.InstanceOf<ChatCompletions>());
            Assert.That(response.Value.Id, Is.Not.Null.Or.Empty);
            Assert.That(response.Value.Created, Is.Not.Null.Or.Empty);
            var result = response.Value;
            Assert.That(result.FinishReason, Is.EqualTo(CompletionsFinishReason.Stopped));
            Assert.That(result.Role, Is.EqualTo(ChatRole.Assistant));
            Assert.That(result.Content, Is.Not.Null.Or.Empty);
        }

        private class AddAoaiAuthHeaderPolicy : HttpPipelinePolicy
        {
            public string AoaiKey { get; }

            public AddAoaiAuthHeaderPolicy(string key)
            {
                AoaiKey = key;
            }

            public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            {
                // Add your desired header name and value
                message.Request.Headers.Add("api-key", AoaiKey);

                ProcessNext(message, pipeline);
            }

            public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            {
                // Add your desired header name and value
                message.Request.Headers.Add("api-key", AoaiKey);

                return ProcessNextAsync(message, pipeline);
            }
        }
    }
}
