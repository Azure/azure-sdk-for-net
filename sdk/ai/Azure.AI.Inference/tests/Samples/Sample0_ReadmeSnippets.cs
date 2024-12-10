// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Inference.Tests.Samples
{
    public class Sample0_ReadmeSnippets : SamplesBase<InferenceClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void InitializeChatCompletionsClient()
        {
            #region Snippet:Azure_AI_Inference_InitializeChatCompletionsClient
#if SNIPPET
            var endpoint = new Uri(System.Environment.GetEnvironmentVariable("AZURE_AI_CHAT_ENDPOINT"));
            var credential = new AzureKeyCredential(System.Environment.GetEnvironmentVariable("AZURE_AI_CHAT_KEY"));
#else
            var endpoint = new Uri(TestEnvironment.MistralSmallEndpoint);
            var credential = new AzureKeyCredential(TestEnvironment.MistralSmallApiKey);
#endif

            var client = new ChatCompletionsClient(endpoint, credential, new AzureAIInferenceClientOptions());
            #endregion
        }

        [Test]
        [SyncOnly]
        public void GetModelInfo()
        {
            #region Snippet:Azure_AI_Inference_GetModelInfo
#if SNIPPET
            var endpoint = new Uri(System.Environment.GetEnvironmentVariable("AZURE_AI_CHAT_ENDPOINT"));
            var credential = new AzureKeyCredential(System.Environment.GetEnvironmentVariable("AZURE_AI_CHAT_KEY"));
#else
            var endpoint = new Uri(TestEnvironment.MistralSmallEndpoint);
            var credential = new AzureKeyCredential(TestEnvironment.MistralSmallApiKey);
#endif

            var client = new ChatCompletionsClient(endpoint, credential, new AzureAIInferenceClientOptions());
            Response<ModelInfo> modelInfo = client.GetModelInfo();

            Console.WriteLine($"Model name: {modelInfo.Value.ModelName}");
            Console.WriteLine($"Model type: {modelInfo.Value.ModelType}");
            Console.WriteLine($"Model provider name: {modelInfo.Value.ModelProviderName}");
            #endregion
        }

        [Test]
        [SyncOnly]
        public void ChatCompletionsWithJsonInput()
        {
            #region Snippet:Azure_AI_Inference_ChatCompletionsWithJsonInput
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

            string jsonMessages = "{\"messages\": [{\"role\": \"system\", \"content\": \"You are a helpful assistant.\"}, {\"role\": \"user\", \"content\": \"How many feet are in a mile?\"}]}";
            BinaryData messages = BinaryData.FromString(jsonMessages);
            requestOptions = ModelReaderWriter.Read<ChatCompletionsOptions>(messages);

            Response<ChatCompletions> response = client.Complete(requestOptions);
            System.Console.WriteLine(response.Value.Content);
            #endregion
        }

        [Test]
        [AsyncOnly]
        public async Task ReadmeStreamingChatCompletions()
        {
            #region Snippet:Azure_AI_Inference_ReadmeStreamingChatCompletions
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

            StringBuilder contentBuilder = new();
            await foreach (StreamingChatCompletionsUpdate chatUpdate in response)
            {
                if (!string.IsNullOrEmpty(chatUpdate.ContentUpdate))
                {
                    contentBuilder.Append(chatUpdate.ContentUpdate);
                }
            }

            System.Console.WriteLine(contentBuilder.ToString());
            #endregion
        }

        [Test]
        [SyncOnly]
        public void ChatCompletionsExceptionHandling()
        {
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
                AdditionalProperties = { { "foo", BinaryData.FromString("\"bar\"") } },
            };

            #region Snippet:Azure_AI_Inference_ChatCompletionsExceptionHandling
            try
            {
                client.Complete(requestOptions);
            }
            catch (RequestFailedException e)
            {
                Console.WriteLine($"Exception status code: {e.Status}");
                Console.WriteLine($"Exception message: {e.Message}");
                Assert.IsTrue(e.Message.Contains("Extra inputs are not permitted"));
            }
            #endregion
        }
    }
}
