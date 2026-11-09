// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Search.Documents.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests.Models
{
    public class QueryAnswerResultTests
    {
        [TestCase("{}", null, false)]
        [TestCase(@"{""highlights"":null}", null, true)]
        [TestCase(@"{""highlights"":""""}", "", true)]
        [TestCase(@"{""highlights"":""<em>answer</em>""}", "<em>answer</em>", true)]
        public void HighlightsPresenceRoundtrips(string json, string expectedHighlights, bool isDefined)
        {
            foreach (ModelReaderWriterOptions options in new[]
                {
                    ModelReaderWriterOptions.Json,
                    new ModelReaderWriterOptions("W")
                })
            {
                QueryAnswerResult answer = ModelReaderWriter.Read<QueryAnswerResult>(BinaryData.FromString(json), options);
                Assert.AreEqual(expectedHighlights, answer.Highlights);

                BinaryData data = ModelReaderWriter.Write(answer, ModelReaderWriterOptions.Json);
                using JsonDocument document = JsonDocument.Parse(data);
                Assert.AreEqual(isDefined, document.RootElement.TryGetProperty("highlights", out JsonElement highlights));
                if (isDefined)
                {
                    Assert.AreEqual(expectedHighlights, highlights.GetString());
                }

                QueryAnswerResult roundtripped = ModelReaderWriter.Read<QueryAnswerResult>(data, ModelReaderWriterOptions.Json);
                Assert.AreEqual(data.ToString(), ModelReaderWriter.Write(roundtripped, ModelReaderWriterOptions.Json).ToString());
            }
        }

        [TestCase("{}")]
        [TestCase(@"{""highlights"":null}")]
        [TestCase(@"{""highlights"":""""}")]
        [TestCase(@"{""highlights"":""<em>answer</em>""}")]
        public void WireSerializationOmitsHighlights(string json)
        {
            ModelReaderWriterOptions options = new ModelReaderWriterOptions("W");
            QueryAnswerResult answer = ModelReaderWriter.Read<QueryAnswerResult>(BinaryData.FromString(json), options);

            using JsonDocument document = JsonDocument.Parse(ModelReaderWriter.Write(answer, options));
            Assert.IsFalse(document.RootElement.TryGetProperty("highlights", out _));
        }

        [TestCase(null, false)]
        [TestCase("", true)]
        [TestCase("<em>answer</em>", true)]
        public void FactoryHighlightsSerializeWhenPopulated(string highlights, bool isDefined)
        {
            QueryAnswerResult answer = SearchModelFactory.QueryAnswerResult(
                highlights: highlights,
                additionalProperties: (IReadOnlyDictionary<string, object>)null);

            using JsonDocument document = JsonDocument.Parse(ModelReaderWriter.Write(answer, ModelReaderWriterOptions.Json));
            Assert.AreEqual(isDefined, document.RootElement.TryGetProperty("highlights", out JsonElement serializedHighlights));
            if (isDefined)
            {
                Assert.AreEqual(highlights, serializedHighlights.GetString());
            }
        }

        [Test]
        public void NullHighlightsRoundtripPreservesOtherProperties()
        {
            const string json = @"{""score"":0.75,""key"":""document"",""text"":""answer"",""highlights"":null,""extra"":""custom""}";
            QueryAnswerResult answer = ModelReaderWriter.Read<QueryAnswerResult>(BinaryData.FromString(json), ModelReaderWriterOptions.Json);

            Assert.AreEqual(0.75, answer.Score);
            Assert.AreEqual("document", answer.Key);
            Assert.AreEqual("answer", answer.Text);
            Assert.AreEqual("custom", answer.AdditionalProperties["extra"]);

            using JsonDocument document = JsonDocument.Parse(ModelReaderWriter.Write(answer, ModelReaderWriterOptions.Json));
            JsonElement root = document.RootElement;
            Assert.AreEqual(0.75, root.GetProperty("score").GetDouble());
            Assert.AreEqual("document", root.GetProperty("key").GetString());
            Assert.AreEqual("answer", root.GetProperty("text").GetString());
            Assert.AreEqual(JsonValueKind.Null, root.GetProperty("highlights").ValueKind);
            Assert.AreEqual("custom", root.GetProperty("extra").GetString());
        }
    }
}
