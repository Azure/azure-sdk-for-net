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
    public class Sample9_Embeddings : SamplesBase<InferenceClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void BasicEmbedding()
        {
            #region Snippet:Azure_AI_Inference_BasicEmbedding
#if SNIPPET
            var endpoint = new Uri(System.Environment.GetEnvironmentVariable("AZURE_AI_EMBEDDINGS_ENDPOINT"));
            var credential = new AzureKeyCredential(System.Environment.GetEnvironmentVariable("AZURE_AI_EMBEDDINGS_KEY"));
#else
            var endpoint = new Uri(TestEnvironment.CohereEmbeddingEndpoint);
            var credential = new AzureKeyCredential(TestEnvironment.CohereEmbeddingApiKey);
#endif

            var client = new EmbeddingsClient(endpoint, credential, new AzureAIInferenceClientOptions());

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
            Assert.That(response.Value.Id, Is.Not.Null.Or.Empty);
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
        public async Task BasicEmbeddingAsync()
        {
            #region Snippet:Azure_AI_Inference_BasicEmbeddingAsync
#if SNIPPET
            var endpoint = new Uri(System.Environment.GetEnvironmentVariable("AZURE_AI_EMBEDDINGS_ENDPOINT"));
            var credential = new AzureKeyCredential(System.Environment.GetEnvironmentVariable("AZURE_AI_EMBEDDINGS_KEY"));
#else
            var endpoint = new Uri(TestEnvironment.CohereEmbeddingEndpoint);
            var credential = new AzureKeyCredential(TestEnvironment.CohereEmbeddingApiKey);
#endif

            var client = new EmbeddingsClient(endpoint, credential, new AzureAIInferenceClientOptions());

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
            Assert.That(response.Value.Id, Is.Not.Null.Or.Empty);
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
        public void BasicEmbeddingBase64()
        {
#if SNIPPET
            var endpoint = new Uri(System.Environment.GetEnvironmentVariable("AZURE_AI_EMBEDDINGS_ENDPOINT"));
            var credential = new AzureKeyCredential(System.Environment.GetEnvironmentVariable("AZURE_AI_EMBEDDINGS_KEY"));
#else
            var endpoint = new Uri(TestEnvironment.CohereEmbeddingEndpoint);
            var credential = new AzureKeyCredential(TestEnvironment.CohereEmbeddingApiKey);
#endif

            var client = new EmbeddingsClient(endpoint, credential, new AzureAIInferenceClientOptions());

            #region Snippet:Azure_AI_Inference_Base64Embedding
            var input = new List<string> { "King", "Queen", "Jack", "Page" };
            var requestOptions = new EmbeddingsOptions(input)
            {
                EncodingFormat = EmbeddingEncodingFormat.Base64,
            };

            Response<EmbeddingsResult> response = client.Embed(requestOptions);
            foreach (EmbeddingItem item in response.Value.Data)
            {
                string embedding = item.Embedding.ToObjectFromJson<string>();
                Console.WriteLine($"Index: {item.Index}, Embedding: {embedding}");
            }
            #endregion

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Value, Is.InstanceOf<EmbeddingsResult>());
            Assert.That(response.Value.Id, Is.Not.Null.Or.Empty);
            Assert.AreEqual(response.Value.Data.Count, input.Count);
            for (int i = 0; i < input.Count; i++)
            {
                Assert.AreEqual(response.Value.Data[i].Index, i);
                Assert.That(response.Value.Data[i].Embedding, Is.Not.Null.Or.Empty);
                var embedding = response.Value.Data[i].Embedding.ToObjectFromJson<string>();
                Assert.That(embedding, Is.Not.Null.Or.Empty);
            }
        }
    }
}
