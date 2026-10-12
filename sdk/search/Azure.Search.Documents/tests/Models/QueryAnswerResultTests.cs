// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.Search.Documents.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests.Models
{
    public class QueryAnswerResultTests
    {
        [TestCase(null, JsonValueKind.Undefined)]
        [TestCase("null", JsonValueKind.Null)]
        [TestCase("\"highlighted answer\"", JsonValueKind.String)]
        public void RoundtripPreservesHighlightsPresence(string highlightsJson, JsonValueKind expectedKind)
        {
            string json = highlightsJson == null ? "{}" : "{\"highlights\":" + highlightsJson + "}";
            QueryAnswerResult answer = ModelReaderWriter.Read<QueryAnswerResult>(BinaryData.FromString(json), ModelReaderWriterOptions.Json);

            using JsonDocument document = JsonDocument.Parse(ModelReaderWriter.Write(answer, ModelReaderWriterOptions.Json).ToMemory());
            bool isDefined = document.RootElement.TryGetProperty("highlights", out JsonElement highlights);
            Assert.AreEqual(expectedKind != JsonValueKind.Undefined, isDefined);
            Assert.AreEqual(expectedKind, highlights.ValueKind);
            if (expectedKind == JsonValueKind.String)
            {
                Assert.AreEqual("highlighted answer", answer.Highlights);
                Assert.AreEqual(answer.Highlights, highlights.GetString());
            }
        }

        [TestCase("null")]
        [TestCase("\"highlighted answer\"")]
        public void WireSerializationOmitsHighlights(string highlightsJson)
        {
            QueryAnswerResult answer = ModelReaderWriter.Read<QueryAnswerResult>(
                BinaryData.FromString("{\"highlights\":" + highlightsJson + "}"), ModelReaderWriterOptions.Json);

            using JsonDocument document = JsonDocument.Parse(ModelReaderWriter.Write(answer, new ModelReaderWriterOptions("W")).ToMemory());
            Assert.IsFalse(document.RootElement.TryGetProperty("highlights", out _));
        }
    }
}
