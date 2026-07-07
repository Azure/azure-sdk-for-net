// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.IO;
using System.Text.Json;
using Azure.Search.Documents.Indexes.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests.Models
{
    public class KeywordTokenizerTests
    {
        [Test]
        public void CreatesKeywordTokenizerV2()
        {
            KeywordTokenizer sut = new KeywordTokenizer("test");
            // ODataType is now internal, verify the tokenizer was created
            Assert.AreEqual("test", sut.Name);
        }

        [TestCase(@"#Microsoft.Azure.Search.KeywordTokenizer")]
        [TestCase(@"#Microsoft.Azure.Search.KeywordTokenizerV2")]
        public void KeywordTokenizerRoundtrips(string odataType)
        {
            string jsonContent = $@"{{
    ""@odata.type"": ""{odataType}"",
    ""name"": ""test"",
    ""bufferSize"": 1,
    ""maxTokenLength"": 1
}}";

            JsonDocument jsonDoc = JsonDocument.Parse(jsonContent);
            KeywordTokenizer sut = LexicalTokenizer.DeserializeLexicalTokenizer(jsonDoc.RootElement, ModelReaderWriterOptions.Json) as KeywordTokenizer;

            Assert.NotNull(sut);
            // ODataType is now internal
            Assert.AreEqual("test", sut.Name);
            Assert.AreEqual(1, sut.BufferSize);
            Assert.AreEqual(1, sut.MaxTokenLength);

            using MemoryStream stream = new MemoryStream();
            using (Utf8JsonWriter writer = new Utf8JsonWriter(stream))
            {
                ((IJsonModel<KeywordTokenizer>)sut).Write(writer, ModelReaderWriterOptions.Json);
            }

            stream.Position = 0;

            jsonDoc = JsonDocument.Parse(stream);
            Assert.True(jsonDoc.RootElement.TryGetProperty("@odata.type", out JsonElement odataTypeElem));
            Assert.AreEqual(odataType, odataTypeElem.GetString());
            jsonDoc.Dispose();
        }
    }
}
