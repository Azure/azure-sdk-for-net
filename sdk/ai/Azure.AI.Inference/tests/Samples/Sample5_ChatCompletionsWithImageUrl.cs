// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Pipeline;
using Azure.Core;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Inference.Tests.Samples
{
    public class Sample5_ChatCompletionsWithImageUrl : SamplesBase<InferenceClientTestEnvironment>
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
            System.Console.WriteLine(response.Value.Choices[0].Message.Content);
            #endregion

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
            System.Console.WriteLine(response.Value.Choices[0].Message.Content);
            #endregion

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
