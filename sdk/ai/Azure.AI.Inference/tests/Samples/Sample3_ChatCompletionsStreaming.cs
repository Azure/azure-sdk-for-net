// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Inference.Tests.Samples
{
    public class Sample3_ChatCompletionsStreaming : SamplesBase<InferenceClientTestEnvironment>
    {
        [Test]
        [AsyncOnly]
        public async Task HelloWorldStreamingScenarioAsync()
        {
            #region Snippet:Azure_AI_Inference_HelloWorldStreamingScenarioAsync
#if SNIPPET
            var endpoint = new Uri(System.Environment.GetEnvironmentVariable("AZURE_AI_CHAT_ENDPOINT"));
            var credential = new AzureKeyCredential(System.Environment.GetEnvironmentVariable("AZURE_AI_CHAT_KEY"));
#else
            var endpoint = new Uri(TestEnvironment.MistralSmallEndpoint);
            var credential = new AzureKeyCredential(TestEnvironment.MistralSmallApiKey);
#endif

            var client = new ChatCompletionsClient(endpoint, credential, new AzureAIInferenceClientOptions());

            var requestOptions = new ChatCompletionsOptions()
            {
                Messages =
                {
                    new ChatRequestSystemMessage("You are a helpful assistant."),
                    new ChatRequestUserMessage("How many feet are in a mile?"),
                },
            };

            StreamingResponse<StreamingChatCompletionsUpdate> response = await client.CompleteStreamingAsync(requestOptions);
            #endregion

            Assert.That(response, Is.Not.Null);

            #region Snippet:Azure_AI_Inference_HelloWorldStreamingScenarioAsync_ProcessResponse
            StringBuilder contentBuilder = new();
#if !SNIPPET
            string id = null;
            string model = null;
            bool gotRole = false;
#endif
            await foreach (StreamingChatCompletionsUpdate chatUpdate in response)
            {
#if !SNIPPET
                Assert.That(chatUpdate, Is.Not.Null);

                Assert.That(chatUpdate.Id, Is.Not.Null.Or.Empty);
                if (chatUpdate.Id == "")
                {
                    Assert.That(chatUpdate.ContentUpdate, Is.Null.Or.Empty);
                    continue;
                }

                Assert.That(chatUpdate.Created, Is.GreaterThan(new DateTimeOffset(new DateTime(2023, 1, 1))));
                Assert.That(chatUpdate.Created, Is.LessThan(DateTimeOffset.UtcNow.AddDays(7)));

                if (!string.IsNullOrEmpty(chatUpdate.Id))
                {
                    Assert.That((id is null) || (id == chatUpdate.Id));
                    id = chatUpdate.Id;
                }
                if (!string.IsNullOrEmpty(chatUpdate.Model))
                {
                    Assert.That((model is null) || (model == chatUpdate.Model));
                    model = chatUpdate.Model;
                }
                if (chatUpdate.Role.HasValue)
                {
                    Assert.IsFalse(gotRole);
                    Assert.That(chatUpdate.Role.Value, Is.EqualTo(ChatRole.Assistant));
                    gotRole = true;
                }
#endif
                if (!string.IsNullOrEmpty(chatUpdate.ContentUpdate))
                {
                    contentBuilder.Append(chatUpdate.ContentUpdate);
                }
            }
#if !SNIPPET
            Assert.IsTrue(!string.IsNullOrEmpty(id));
            Assert.IsTrue(!string.IsNullOrEmpty(model));
            Assert.IsTrue(gotRole);
            var result = contentBuilder.ToString();
            Assert.That(result, Is.Not.Null.Or.Empty);
#endif
            System.Console.WriteLine(contentBuilder.ToString());
            #endregion
        }
    }
}
