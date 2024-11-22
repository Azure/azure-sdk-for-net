// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Inference.Tests.Samples
{
    public class Sample6_ChatCompletionsWithAdditionalProperties : SamplesBase<InferenceClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void ChatCompletionsWithAdditionalPropertiesScenario()
        {
            #region Snippet:Azure_AI_Inference_ChatCompletionsWithAdditionalPropertiesScenario
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
                AdditionalProperties = { { "foo", BinaryData.FromString("\"bar\"") } }, // Optional, add additional properties to the request to pass to the model
            };
#if SNIPPET
            Response<ChatCompletions> response = client.Complete(requestOptions);
            System.Console.WriteLine(response.Value.Choices[0].Message.Content);
#else
            // For testing, we don't have valid additional parameters to pass through, so we just test that it throws appropriately.
            var exceptionThrown = false;
            try
            {
                client.Complete(requestOptions);
            }
            catch (Exception e)
            {
                exceptionThrown = true;
                Assert.IsTrue(e.Message.Contains("Extra inputs are not permitted"));
            }
            Assert.IsTrue(exceptionThrown);
#endif
            #endregion
        }

        [Test]
        [AsyncOnly]
        public async Task ChatCompletionsWithAdditionalPropertiesScenarioAsync()
        {
            #region Snippet:Azure_AI_Inference_ChatCompletionsWithAdditionalPropertiesScenarioAsync
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
                AdditionalProperties = { { "foo", BinaryData.FromString("\"bar\"") } }, // Optional, add additional properties to the request to pass to the model
            };
#if SNIPPET
            Response<ChatCompletions> response = await client.CompleteAsync(requestOptions);
            System.Console.WriteLine(response.Value.Choices[0].Message.Content);
#else
            // For testing, we don't have valid additional parameters to pass through, so we just test that it throws appropriately.
            var exceptionThrown = false;
            try
            {
                await client.CompleteAsync(requestOptions);
            }
            catch (Exception e)
            {
                exceptionThrown = true;
                Assert.IsTrue(e.Message.Contains("Extra inputs are not permitted"));
            }
            Assert.IsTrue(exceptionThrown);
#endif
            #endregion
        }
    }
}
