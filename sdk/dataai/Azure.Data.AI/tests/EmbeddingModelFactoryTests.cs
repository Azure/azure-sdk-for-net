// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using NUnit.Framework;

namespace Azure.Data.AI.Tests
{
    public class EmbeddingModelFactoryTests
    {
        [Test]
        public void ResultRoundTripPreservesObjectWireConstant()
        {
            var result = ModelReaderWriter.Read<MultimodalEmbeddingResult>(
                BinaryData.FromString("{\"object\":\"list\",\"model\":\"test-model\",\"modelVersion\":\"v1\",\"outputDataKind\":\"float32\",\"data\":[],\"usage\":{\"imageCount\":0}}"),
                ModelReaderWriterOptions.Json,
                AzureDataAIContext.Default);

            using JsonDocument json = Serialize(result);

            Assert.That(json.RootElement.GetProperty("object").GetString(), Is.EqualTo("list"));
            Assert.That(result.OutputDataKind, Is.EqualTo(EmbeddingOutputDataKind.Float32));
        }

        [TestCase(false)]
        [TestCase(true)]
        public void OutputSerializesOptionalFactoryUrl(bool includeUrl)
        {
            Uri url = includeUrl ? new Uri("https://example.blob.core.windows.net/results/output.json") : null;
            var output = InferenceModelFactory.MultimodalEmbeddingOutput(
                id: "output-id", uri: url, recordCount: 3, sizeInBytes: 129960);

            using JsonDocument json = Serialize(output);

            Assert.That(json.RootElement.GetProperty("id").GetString(), Is.EqualTo("output-id"));
            Assert.That(json.RootElement.GetProperty("records").GetInt32(), Is.EqualTo(3));
            Assert.That(json.RootElement.GetProperty("sizeInBytes").GetInt64(), Is.EqualTo(129960));
            Assert.That(json.RootElement.TryGetProperty("recordCount", out _), Is.False);
            Assert.That(json.RootElement.TryGetProperty("bytes", out _), Is.False);
            Assert.That(json.RootElement.GetProperty("url").ValueKind, Is.EqualTo(includeUrl ? JsonValueKind.String : JsonValueKind.Null));
            Assert.That(json.RootElement.GetProperty("url").GetString(), Is.EqualTo(url?.AbsoluteUri));
        }

        [TestCase(null)]
        [TestCase("future-kind")]
        public void BaseItemFactoryAcceptsOptionalDiscriminator(string kind)
        {
            var item = kind == null
                ? InferenceModelFactory.MultimodalEmbeddingItem(index: 1, tokens: 10)
                : InferenceModelFactory.MultimodalEmbeddingItem(index: 1, contentKind: EmbeddingContentKind.Text, tokens: 10, kind: kind);

            Assert.That(item.Index, Is.EqualTo(1));
            Assert.That(item.Tokens, Is.EqualTo(10));

            using JsonDocument json = Serialize(item);

            Assert.That(json.RootElement.GetProperty("kind").GetString(), Is.EqualTo(kind ?? "unknown"));
            if (kind != null)
            {
                var roundTrip = ModelReaderWriter.Read<MultimodalEmbeddingItem>(
                    BinaryData.FromString(json.RootElement.GetRawText()),
                    ModelReaderWriterOptions.Json,
                    AzureDataAIContext.Default);
                using JsonDocument roundTripJson = Serialize(roundTrip);
                Assert.That(roundTripJson.RootElement.GetProperty("kind").GetString(), Is.EqualTo(kind));
                Assert.That(roundTrip.Tokens, Is.EqualTo(10));
            }
        }

        [TestCase(null)]
        [TestCase("[1,2]")]
        [TestCase("\"AACAPw==\"")]
        public void DenseFactoryPayloadSerializesAsJson(string embedding)
        {
            var item = InferenceModelFactory.MultimodalDenseEmbedding(index: 1, embedding: ToBinaryData(embedding));

            using JsonDocument json = Serialize(item);

            Assert.That(json.RootElement.GetProperty("kind").GetString(), Is.EqualTo("dense"));
            AssertPayload(json.RootElement, "embedding", embedding);
        }

        [TestCase(null)]
        [TestCase("[[1,2]]")]
        [TestCase("\"AACAPw==\"")]
        public void MultiVectorFactoryPayloadSerializesAsJson(string multiEmbedding)
        {
            var item = InferenceModelFactory.MultimodalMultiVectorEmbedding(index: 1, multiEmbedding: ToBinaryData(multiEmbedding));

            using JsonDocument json = Serialize(item);

            Assert.That(json.RootElement.GetProperty("kind").GetString(), Is.EqualTo("multi"));
            AssertPayload(json.RootElement, "multiEmbedding", multiEmbedding);
        }

        [TestCase(null, null)]
        [TestCase("[1,2]", null)]
        [TestCase(null, "[[3,4]]")]
        [TestCase("[1,2]", "[[3,4]]")]
        [TestCase("\"AACAPw==\"", "\"AAAAQA==\"")]
        public void CombinedFactoryPayloadsSerializeAsJson(string embedding, string multiEmbedding)
        {
            var item = InferenceModelFactory.MultimodalDenseAndMultiVectorEmbedding(
                index: 1,
                embedding: ToBinaryData(embedding),
                multiEmbedding: ToBinaryData(multiEmbedding));

            using JsonDocument json = Serialize(item);

            Assert.That(json.RootElement.GetProperty("kind").GetString(), Is.EqualTo("dense_multi"));
            AssertPayload(json.RootElement, "embedding", embedding);
            AssertPayload(json.RootElement, "multiEmbedding", multiEmbedding);
        }

        private static BinaryData ToBinaryData(string json) => json == null ? null : BinaryData.FromString(json);

        private static JsonDocument Serialize<T>(T model) =>
            JsonDocument.Parse(ModelReaderWriter.Write(model, ModelReaderWriterOptions.Json, AzureDataAIContext.Default).ToString());

        private static void AssertPayload(JsonElement root, string propertyName, string expectedJson)
        {
            using JsonDocument expected = JsonDocument.Parse(expectedJson ?? "null");
            JsonElement actual = root.GetProperty(propertyName);
            Assert.That(actual.ValueKind, Is.EqualTo(expected.RootElement.ValueKind));
            Assert.That(actual.GetRawText(), Is.EqualTo(expected.RootElement.GetRawText()));
        }
    }
}
