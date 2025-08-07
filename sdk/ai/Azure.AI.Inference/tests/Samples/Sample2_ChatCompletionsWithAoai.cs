// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Inference.Tests.Samples
{
    public class Sample2_ChatCompletionsWithAoai : SamplesBase<InferenceClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void HelloWorldAoaiScenario()
        {
            #region Snippet:Azure_AI_Inference_HelloWorldAoaiScenarioClientCreate
#if SNIPPET
            var endpoint = new Uri(System.Environment.GetEnvironmentVariable("AZURE_OPENAI_CHAT_ENDPOINT"));
            var key = System.Environment.GetEnvironmentVariable("AZURE_OPENAI_CHAT_KEY");
#else
            var endpoint = new Uri(TestEnvironment.AoaiEndpoint);
            var key = TestEnvironment.AoaiKey;
#endif

            // For AOAI, currently the key is passed via a different header not directly handled by the client, however
            // the credential object is still required. So create with a dummy value.
            var credential = new AzureKeyCredential("foo");

            AzureAIInferenceClientOptions clientOptions = new AzureAIInferenceClientOptions();
            clientOptions.AddPolicy(new AddAoaiAuthHeaderPolicy(key), HttpPipelinePosition.PerCall);

            var client = new ChatCompletionsClient(endpoint, credential, clientOptions);
            #endregion

            #region Snippet:Azure_AI_Inference_HelloWorldAoaiScenarioCompleteRequest
            var requestOptions = new ChatCompletionsOptions()
            {
                Messages =
                {
                    new ChatRequestSystemMessage("You are a helpful assistant."),
                    new ChatRequestUserMessage("How many feet are in a mile?"),
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
        public async Task HelloWorldAoaiScenarioAsync()
        {
#if SNIPPET
            var endpoint = new Uri(System.Environment.GetEnvironmentVariable("AZURE_OPENAI_CHAT_ENDPOINT"));
            var key = System.Environment.GetEnvironmentVariable("AZURE_OPENAI_CHAT_KEY");
#else
            var endpoint = new Uri(TestEnvironment.AoaiEndpoint);
            var key = TestEnvironment.AoaiKey;
#endif

            // For AOAI, currently the key is passed via a different header not directly handled by the client, however
            // the credential object is still required. So create with a dummy value.
            var credential = new AzureKeyCredential("foo");

            AzureAIInferenceClientOptions clientOptions = new AzureAIInferenceClientOptions();
            clientOptions.AddPolicy(new AddAoaiAuthHeaderPolicy(key), HttpPipelinePosition.PerCall);

            var client = new ChatCompletionsClient(endpoint, credential, clientOptions);

            #region Snippet:Azure_AI_Inference_HelloWorldAoaiScenarioCompleteRequestAsync
            var requestOptions = new ChatCompletionsOptions()
            {
                Messages =
                {
                    new ChatRequestSystemMessage("You are a helpful assistant."),
                    new ChatRequestUserMessage("How many feet are in a mile?"),
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
        public void HelloWorldScenarioWithEntraId()
        {
            #region Snippet:Azure_AI_Inference_HelloWorldScenarioWithEntraIdClientCreate
#if SNIPPET
            var endpoint = new Uri(System.Environment.GetEnvironmentVariable("AZURE_OPENAI_CHAT_ENDPOINT"));
            var credential = new DefaultAzureCredential(includeInteractiveCredentials: true);
#else
            var endpoint = new Uri(TestEnvironment.AoaiEndpoint);
            var credential = TestEnvironment.Credential;
#endif

            AzureAIInferenceClientOptions clientOptions = new AzureAIInferenceClientOptions();

            BearerTokenAuthenticationPolicy tokenPolicy = new BearerTokenAuthenticationPolicy(credential, new string[] { "https://cognitiveservices.azure.com/.default" });
            clientOptions.AddPolicy(tokenPolicy, HttpPipelinePosition.PerRetry);

            var client = new ChatCompletionsClient(endpoint, credential, clientOptions);
            #endregion

            var requestOptions = new ChatCompletionsOptions()
            {
                Messages =
                {
                    new ChatRequestSystemMessage("You are a helpful assistant."),
                    new ChatRequestUserMessage("How many feet are in a mile?"),
                },
            };

            Response<ChatCompletions> response = client.Complete(requestOptions);
            System.Console.WriteLine(response.Value.Content);

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
        public async Task HelloWorldScenarioAsyncWithEntraId()
        {
#if SNIPPET
            var endpoint = new Uri(System.Environment.GetEnvironmentVariable("AZURE_OPENAI_CHAT_ENDPOINT"));
            var credential = new DefaultAzureCredential(includeInteractiveCredentials: true);
#else
            var endpoint = new Uri(TestEnvironment.AoaiEndpoint);
            var credential = TestEnvironment.Credential;

#endif

            AzureAIInferenceClientOptions clientOptions = new AzureAIInferenceClientOptions();

            BearerTokenAuthenticationPolicy tokenPolicy = new BearerTokenAuthenticationPolicy(credential, new string[] { "https://cognitiveservices.azure.com/.default" });
            clientOptions.AddPolicy(tokenPolicy, HttpPipelinePosition.PerRetry);

            var client = new ChatCompletionsClient(endpoint, credential, clientOptions);

            var requestOptions = new ChatCompletionsOptions()
            {
                Messages =
                {
                    new ChatRequestSystemMessage("You are a helpful assistant."),
                    new ChatRequestUserMessage("How many feet are in a mile?"),
                },
            };

            Response<ChatCompletions> response = await client.CompleteAsync(requestOptions);
            System.Console.WriteLine(response.Value.Content);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Value, Is.InstanceOf<ChatCompletions>());
            Assert.That(response.Value.Id, Is.Not.Null.Or.Empty);
            Assert.That(response.Value.Created, Is.Not.Null.Or.Empty);
            ChatCompletions result = response.Value;
            Assert.That(result.FinishReason, Is.EqualTo(CompletionsFinishReason.Stopped));
            Assert.That(result.Role, Is.EqualTo(ChatRole.Assistant));
            Assert.That(result.Content, Is.Not.Null.Or.Empty);
        }

        #region Snippet:Azure_AI_Inference_AoaiAuthHeaderPolicy
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
        #endregion
    }
}
