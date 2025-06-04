// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Inference.Tests.Samples
{
    public class Sample11_ImageEmbeddings : SamplesBase<InferenceClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void BasicEmbedding()
        {
            #region Snippet:Azure_AI_Inference_BasicImageEmbedding
#if SNIPPET
            var endpoint = new Uri(System.Environment.GetEnvironmentVariable("AZURE_AI_IMAGE_EMBEDDINGS_ENDPOINT"));
            var credential = new AzureKeyCredential(System.Environment.GetEnvironmentVariable("AZURE_AI_IMAGE_EMBEDDINGS_KEY"));
#else
            var endpoint = new Uri(TestEnvironment.CohereEmbeddingEndpoint);
            var credential = new AzureKeyCredential(TestEnvironment.CohereEmbeddingApiKey);
#endif

            var client = new ImageEmbeddingsClient(endpoint, credential, new AzureAIInferenceClientOptions());

            List<ImageEmbeddingInput> input = new List<ImageEmbeddingInput>
            {
#if SNIPPET
                ImageEmbeddingInput.Load(imageFilePath:"sampleImage.png", imageFormat:"png")
#else
                ImageEmbeddingInput.Load(TestEnvironment.TestImagePngInputPath, "png"),
#endif
            };

            var requestOptions = new ImageEmbeddingsOptions(input);

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
        public async Task BasicImageEmbeddingAsync()
        {
            #region Snippet:Azure_AI_Inference_BasicImageEmbeddingAsync
#if SNIPPET
            var endpoint = new Uri(System.Environment.GetEnvironmentVariable("AZURE_AI_IMAGE_EMBEDDINGS_ENDPOINT"));
            var credential = new AzureKeyCredential(System.Environment.GetEnvironmentVariable("AZURE_AI_IMAGE_EMBEDDINGS_KEY"));
#else
            var endpoint = new Uri(TestEnvironment.CohereEmbeddingEndpoint);
            var credential = new AzureKeyCredential(TestEnvironment.CohereEmbeddingApiKey);
#endif

            var client = new ImageEmbeddingsClient(endpoint, credential, new AzureAIInferenceClientOptions());

            List<ImageEmbeddingInput> input = new List<ImageEmbeddingInput>
            {
#if SNIPPET
                ImageEmbeddingInput.Load(imageFilePath:"sampleImage.png", imageFormat:"png")
#else
                ImageEmbeddingInput.Load(TestEnvironment.TestImagePngInputPath, "png"),
#endif
            };

            var requestOptions = new ImageEmbeddingsOptions(input);

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
            var endpoint = new Uri(System.Environment.GetEnvironmentVariable("AZURE_AI_IMAGE_EMBEDDINGS_ENDPOINT"));
            var credential = new AzureKeyCredential(System.Environment.GetEnvironmentVariable("AZURE_AI_IMAGE_EMBEDDINGS_KEY"));
#else
            var endpoint = new Uri(TestEnvironment.CohereEmbeddingEndpoint);
            var credential = new AzureKeyCredential(TestEnvironment.CohereEmbeddingApiKey);
#endif

            var client = new ImageEmbeddingsClient(endpoint, credential, new AzureAIInferenceClientOptions());

            #region Snippet:Azure_AI_Inference_Base64ImageEmbedding
            List<ImageEmbeddingInput> input = new List<ImageEmbeddingInput>
            {
#if SNIPPET
                ImageEmbeddingInput.Load(imageFilePath:"sampleImage.png", imageFormat:"png")
#else
                ImageEmbeddingInput.Load(TestEnvironment.TestImagePngInputPath, "png"),
#endif
            };

            var requestOptions = new ImageEmbeddingsOptions(input)
            {
                EncodingFormat = EmbeddingEncodingFormat.Base64,
            };

            Response<EmbeddingsResult> response = client.Embed(requestOptions);
            foreach (EmbeddingItem item in response.Value.Data)
            {
                string embedding = item.Embedding.ToObjectFromJson<string>();
                Console.WriteLine($"Index: {item.Index}, Embedding: <{embedding}>");
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
