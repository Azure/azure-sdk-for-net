// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Inference.Tests
{
    public class EmbeddingClientTests : RecordedTestBase<InferenceClientTestEnvironment>
    {
        public EmbeddingClientTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task TestEmbed()
        {
            var cohereEmbeddingEndpoint = new Uri(TestEnvironment.CohereEmbeddingEndpoint);
            var cohereEmbeddingCredential = new AzureKeyCredential(TestEnvironment.CohereEmbeddingApiKey);

            var client = CreateClient(cohereEmbeddingEndpoint, cohereEmbeddingCredential, new AzureAIInferenceClientOptions());

            var input = new List<string> { "King", "Queen", "Jack", "Page" };
            var requestOptions = new EmbeddingsOptions(input);

            Response<EmbeddingsResult> response = await client.EmbedAsync(requestOptions);

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

        [RecordedTest]
        public async Task TestEmbedWithBase64()
        {
            var cohereEmbeddingEndpoint = new Uri(TestEnvironment.CohereEmbeddingEndpoint);
            var cohereEmbeddingCredential = new AzureKeyCredential(TestEnvironment.CohereEmbeddingApiKey);

            var client = CreateClient(cohereEmbeddingEndpoint, cohereEmbeddingCredential, new AzureAIInferenceClientOptions());

            var input = new List<string> { "King", "Queen", "Jack", "Page" };
            var requestOptions = new EmbeddingsOptions(input)
            {
                EncodingFormat = EmbeddingEncodingFormat.Base64,
            };

            var response = await client.EmbedAsync(requestOptions);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Value, Is.InstanceOf<EmbeddingsResult>());
            Assert.That(response.Value.Id, Is.Not.Null.Or.Empty);
            Assert.AreEqual(response.Value.Data.Count, input.Count);
            for (int i = 0; i < input.Count; i++)
            {
                Assert.AreEqual(response.Value.Data[i].Index, i);
                Assert.That(response.Value.Data[i].Embedding, Is.Not.Null.Or.Empty);
                var stringEmbedding = response.Value.Data[i].Embedding.ToObjectFromJson<string>();
                Assert.That(stringEmbedding, Is.Not.Null.Or.Empty);
            }
            Assert.That(response.Value.Usage.PromptTokens, Is.GreaterThan(0));
            Assert.That(response.Value.Usage.TotalTokens, Is.GreaterThan(0));
        }

        #region Helpers
        private EmbeddingsClient CreateClient(Uri endpoint, AzureKeyCredential credential, AzureAIInferenceClientOptions clientOptions)
        {
            return InstrumentClient(new EmbeddingsClient(endpoint, credential, InstrumentClientOptions(clientOptions)));
        }

        private EmbeddingsClient CreateClient(Uri endpoint, TokenCredential credential, AzureAIInferenceClientOptions clientOptions)
        {
            return InstrumentClient(new EmbeddingsClient(endpoint, credential, InstrumentClientOptions(clientOptions)));
        }
        #endregion
    }
}
