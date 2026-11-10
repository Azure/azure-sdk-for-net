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
            var result = ModelReaderWriter.Read<EmbeddingResult>(
                BinaryData.FromString("{\"object\":\"list\",\"model\":\"test-model\",\"modelVersion\":\"v1\",\"outputDataKind\":\"float32\",\"data\":[],\"usage\":{\"type\":\"multimodal\",\"imageCount\":0}}"),
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
            Assert.That(json.RootElement.GetProperty("recordCount").GetInt32(), Is.EqualTo(3));
            Assert.That(json.RootElement.GetProperty("sizeInBytes").GetInt64(), Is.EqualTo(129960));
            Assert.That(json.RootElement.TryGetProperty("records", out _), Is.False);
            Assert.That(json.RootElement.TryGetProperty("bytes", out _), Is.False);
            Assert.That(json.RootElement.GetProperty("url").ValueKind, Is.EqualTo(includeUrl ? JsonValueKind.String : JsonValueKind.Null));
            Assert.That(json.RootElement.GetProperty("url").GetString(), Is.EqualTo(url?.AbsoluteUri));
        }

        [TestCase(null)]
        [TestCase("future-kind")]
        public void BaseItemFactoryAcceptsOptionalDiscriminator(string kind)
        {
            var item = kind == null
                ? InferenceModelFactory.EmbeddingItem(index: 1, id: "item-1")
                : InferenceModelFactory.EmbeddingItem(type: kind, index: 1, id: "item-1");

            Assert.That(item.Index, Is.EqualTo(1));
            Assert.That(item.Id, Is.EqualTo("item-1"));

            using JsonDocument json = Serialize(item);

            Assert.That(json.RootElement.GetProperty("type").GetString(), Is.EqualTo(kind ?? "unknown"));
            var roundTrip = ModelReaderWriter.Read<EmbeddingItem>(
                BinaryData.FromString(json.RootElement.GetRawText()),
                ModelReaderWriterOptions.Json,
                AzureDataAIContext.Default);
            using JsonDocument roundTripJson = Serialize(roundTrip);
            Assert.That(roundTripJson.RootElement.GetProperty("type").GetString(), Is.EqualTo(kind ?? "unknown"));
            Assert.That(roundTrip.Index, Is.EqualTo(1));
            Assert.That(roundTrip.Id, Is.EqualTo("item-1"));
        }

        [TestCase(null)]
        [TestCase("future-usage")]
        public void BaseUsageFactoryAcceptsOptionalDiscriminator(string type)
        {
            var usage = InferenceModelFactory.EmbeddingUsage(type: type, promptTokens: 3, totalTokens: 5);

            using JsonDocument json = Serialize(usage);

            Assert.That(json.RootElement.GetProperty("type").GetString(), Is.EqualTo(type ?? "unknown"));
            Assert.That(json.RootElement.GetProperty("promptTokens").GetInt64(), Is.EqualTo(3));
            Assert.That(json.RootElement.GetProperty("totalTokens").GetInt64(), Is.EqualTo(5));
        }

        [Test]
        public void GenericResultRoundTripsFutureImplementations()
        {
            var result = ModelReaderWriter.Read<EmbeddingResult>(
                BinaryData.FromString("{\"object\":\"list\",\"model\":\"future-model\",\"modelVersion\":\"v2\",\"outputDataKind\":\"float32\",\"data\":[{\"type\":\"text\",\"index\":0,\"id\":\"text-1\",\"embedding\":[1,2],\"customMetadata\":{\"count\":3}}],\"usage\":{\"type\":\"text\",\"promptTokens\":7,\"totalTokens\":9,\"customCount\":2}}"),
                ModelReaderWriterOptions.Json,
                AzureDataAIContext.Default);

            Assert.That(result.Data[0], Is.Not.InstanceOf<MultimodalDenseEmbedding>());
            Assert.That(result.Data[0].Index, Is.Zero);
            Assert.That(result.Data[0].Id, Is.EqualTo("text-1"));
            Assert.That(result.Usage, Is.Not.InstanceOf<MultimodalEmbeddingUsage>());
            Assert.That(result.Usage.PromptTokens, Is.EqualTo(7));
            Assert.That(result.Usage.TotalTokens, Is.EqualTo(9));

            using JsonDocument json = Serialize(result);
            JsonElement item = json.RootElement.GetProperty("data")[0];
            Assert.That(item.GetProperty("type").GetString(), Is.EqualTo("text"));
            Assert.That(item.GetProperty("embedding")[1].GetInt32(), Is.EqualTo(2));
            Assert.That(item.GetProperty("customMetadata").GetProperty("count").GetInt32(), Is.EqualTo(3));
            JsonElement usage = json.RootElement.GetProperty("usage");
            Assert.That(usage.GetProperty("type").GetString(), Is.EqualTo("text"));
            Assert.That(usage.GetProperty("customCount").GetInt32(), Is.EqualTo(2));
        }

        [TestCase(null)]
        [TestCase("[1,2]")]
        [TestCase("\"AACAPw==\"")]
        public void DenseFactoryPayloadSerializesAsJson(string embedding)
        {
            var item = InferenceModelFactory.MultimodalDenseEmbedding(index: 1, embedding: ToBinaryData(embedding));

            using JsonDocument json = Serialize(item);

            Assert.That(json.RootElement.GetProperty("kind").GetString(), Is.EqualTo("dense"));
            Assert.That(json.RootElement.GetProperty("type").GetString(), Is.EqualTo("multimodal_dense"));
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
            Assert.That(json.RootElement.GetProperty("type").GetString(), Is.EqualTo("multimodal_multi"));
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
            Assert.That(json.RootElement.GetProperty("type").GetString(), Is.EqualTo("multimodal_dense_multi"));
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
