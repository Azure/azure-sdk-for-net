// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.Core;

namespace Azure.AI.Inference.Tests
{
    public class ImageEmbeddingClientTests : RecordedTestBase<InferenceClientTestEnvironment>
    {
        public ImageEmbeddingClientTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task TestEmbed()
        {
            if (Mode == RecordedTestMode.Playback)
            {
                Assert.Inconclusive("Unable to run test with file path in playback mode.");
            }

            var cohereEmbeddingEndpoint = new Uri(TestEnvironment.CohereEmbeddingEndpoint);
            var cohereEmbeddingCredential = new AzureKeyCredential(TestEnvironment.CohereEmbeddingApiKey);

            var client = CreateClient(cohereEmbeddingEndpoint, cohereEmbeddingCredential, new AzureAIInferenceClientOptions());

            List<ImageEmbeddingInput> input = new List<ImageEmbeddingInput>
            {
                ImageEmbeddingInput.Load(TestEnvironment.TestImagePngInputPath, "png"),
            };

            var requestOptions = new ImageEmbeddingsOptions(input);

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
            if (Mode == RecordedTestMode.Playback)
            {
                Assert.Inconclusive("Unable to run test with file path in playback mode.");
            }

            var cohereEmbeddingEndpoint = new Uri(TestEnvironment.CohereEmbeddingEndpoint);
            var cohereEmbeddingCredential = new AzureKeyCredential(TestEnvironment.CohereEmbeddingApiKey);

            var client = CreateClient(cohereEmbeddingEndpoint, cohereEmbeddingCredential, new AzureAIInferenceClientOptions());

            List<ImageEmbeddingInput> input = new List<ImageEmbeddingInput>
            {
                ImageEmbeddingInput.Load(TestEnvironment.TestImagePngInputPath, "png"),
            };

            var requestOptions = new ImageEmbeddingsOptions(input)
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
        private ImageEmbeddingsClient CreateClient(Uri endpoint, AzureKeyCredential credential, AzureAIInferenceClientOptions clientOptions)
        {
            return InstrumentClient(new ImageEmbeddingsClient(endpoint, credential, InstrumentClientOptions(clientOptions)));
        }

        private ImageEmbeddingsClient CreateClient(Uri endpoint, TokenCredential credential, AzureAIInferenceClientOptions clientOptions)
        {
            return InstrumentClient(new ImageEmbeddingsClient(endpoint, credential, InstrumentClientOptions(clientOptions)));
        }
        #endregion
    }
}
