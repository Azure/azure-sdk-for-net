// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;
using System.Collections.Generic;

namespace Azure.AI.Inference.Tests.Samples
{
    public class Sample10_EmbeddingsWithAoai : SamplesBase<InferenceClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void BasicEmbeddingAoai()
        {
            #region Snippet:Azure_AI_Inference_BasicEmbeddingAoaiScenarioClientCreate
#if SNIPPET
            var endpoint = new Uri(System.Environment.GetEnvironmentVariable("AZURE_OPENAI_EMBEDDINGS_ENDPOINT"));
            var key = System.Environment.GetEnvironmentVariable("AZURE_OPENAI_EMBEDDINGS_KEY");
#else
            var endpoint = new Uri(TestEnvironment.AoaiEmbeddingsEndpoint);
            var key = TestEnvironment.AoaiEmbeddingsKey;
#endif

            // For AOAI, currently the key is passed via a different header not directly handled by the client, however
            // the credential object is still required. So create with a dummy value.
            var credential = new AzureKeyCredential("foo");

            AzureAIInferenceClientOptions clientOptions = new AzureAIInferenceClientOptions();
            clientOptions.AddPolicy(new AddAoaiAuthHeaderPolicy(key), HttpPipelinePosition.PerCall);

            var client = new EmbeddingsClient(endpoint, credential, clientOptions);
            #endregion

            #region Snippet:Azure_AI_Inference_BasicEmbeddingAoai
            var input = new List<string> { "King", "Queen", "Jack", "Page" };
            var requestOptions = new EmbeddingsOptions(input);

            Response<EmbeddingsResult> response = client.Embed(requestOptions);
            foreach (EmbeddingItem item in response.Value.Data)
            {
                List<float> embedding = item.Embedding.ToObjectFromJson<List<float>>();
                Console.WriteLine($"Index: {item.Index}, Embedding: <{string.Join(", ", embedding)}>");
            }
            #endregion

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Value, Is.InstanceOf<EmbeddingsResult>());
            Assert.AreEqual(response.Value.Data.Count, input.Count);
            for (int i = 0; i < input.Count; i++)
            {
                Assert.AreEqual(response.Value.Data[i].Index, i);
                Assert.That(response.Value.Data[i].Embedding, Is.Not.Null.Or.Empty);
                var embedding = response.Value.Data[i].Embedding.ToObjectFromJson<List<float>>();
                Assert.That(embedding.Count, Is.GreaterThan(0));
            }
        }

        [Test]
        [AsyncOnly]
        public async Task BasicEmbeddingAoaiAsync()
        {
#if SNIPPET
            var endpoint = new Uri(System.Environment.GetEnvironmentVariable("AZURE_OPENAI_EMBEDDINGS_ENDPOINT"));
            var key = System.Environment.GetEnvironmentVariable("AZURE_OPENAI_EMBEDDINGS_KEY");
#else
            var endpoint = new Uri(TestEnvironment.AoaiEmbeddingsEndpoint);
            var key = TestEnvironment.AoaiEmbeddingsKey;
#endif

            // For AOAI, currently the key is passed via a different header not directly handled by the client, however
            // the credential object is still required. So create with a dummy value.
            var credential = new AzureKeyCredential("foo");

            AzureAIInferenceClientOptions clientOptions = new AzureAIInferenceClientOptions();
            clientOptions.AddPolicy(new AddAoaiAuthHeaderPolicy(key), HttpPipelinePosition.PerCall);

            var client = new EmbeddingsClient(endpoint, credential, clientOptions);

            #region Snippet:Azure_AI_Inference_BasicEmbeddingAoaiAsync
            var input = new List<string> { "King", "Queen", "Jack", "Page" };
            var requestOptions = new EmbeddingsOptions(input);

            Response<EmbeddingsResult> response = await client.EmbedAsync(requestOptions);
            foreach (EmbeddingItem item in response.Value.Data)
            {
                List<float> embedding = item.Embedding.ToObjectFromJson<List<float>>();
                Console.WriteLine($"Index: {item.Index}, Embedding: <{string.Join(", ", embedding)}>");
            }
            #endregion

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Value, Is.InstanceOf<EmbeddingsResult>());
            Assert.AreEqual(response.Value.Data.Count, input.Count);
            for (int i = 0; i < input.Count; i++)
            {
                Assert.AreEqual(response.Value.Data[i].Index, i);
                Assert.That(response.Value.Data[i].Embedding, Is.Not.Null.Or.Empty);
                var embedding = response.Value.Data[i].Embedding.ToObjectFromJson<List<float>>();
                Assert.That(embedding.Count, Is.GreaterThan(0));
            }
        }

        [Test]
        [SyncOnly]
        public void BasicEmbeddingAoaiWithEntraId()
        {
            #region Snippet:Azure_AI_Inference_EmbeddingWithEntraIdClientCreate
#if SNIPPET
            var endpoint = new Uri(System.Environment.GetEnvironmentVariable("AZURE_OPENAI_EMBEDDINGS_ENDPOINT"));
            var credential = new DefaultAzureCredential(includeInteractiveCredentials: true);
#else
            var endpoint = new Uri(TestEnvironment.AoaiEmbeddingsEndpoint);
            var credential = TestEnvironment.Credential;
#endif
            AzureAIInferenceClientOptions clientOptions = new AzureAIInferenceClientOptions();

            BearerTokenAuthenticationPolicy tokenPolicy = new BearerTokenAuthenticationPolicy(credential, new string[] { "https://cognitiveservices.azure.com/.default" });
            clientOptions.AddPolicy(tokenPolicy, HttpPipelinePosition.PerRetry);

            var client = new EmbeddingsClient(endpoint, credential, clientOptions);
            #endregion

            var input = new List<string> { "King", "Queen", "Jack", "Page" };
            var requestOptions = new EmbeddingsOptions(input);

            Response<EmbeddingsResult> response = client.Embed(requestOptions);
            foreach (EmbeddingItem item in response.Value.Data)
            {
                List<float> embedding = item.Embedding.ToObjectFromJson<List<float>>();
                Console.WriteLine($"Index: {item.Index}, Embedding: <{string.Join(", ", embedding)}>");
            }

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Value, Is.InstanceOf<EmbeddingsResult>());
            Assert.AreEqual(response.Value.Data.Count, input.Count);
            for (int i = 0; i < input.Count; i++)
            {
                Assert.AreEqual(response.Value.Data[i].Index, i);
                Assert.That(response.Value.Data[i].Embedding, Is.Not.Null.Or.Empty);
                var embedding = response.Value.Data[i].Embedding.ToObjectFromJson<List<float>>();
                Assert.That(embedding.Count, Is.GreaterThan(0));
            }
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
