// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.IO;
using System.Text.Json;
using Azure.Search.Documents.Indexes.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests.Models
{
    public class LuceneStandardTokenizerTests
    {
        [Test]
        public void CreatesLuceneStandardTokenizerV2()
        {
            LuceneStandardTokenizer sut = new LuceneStandardTokenizer("test");
            // ODataType is now internal, verify the tokenizer was created
            Assert.AreEqual("test", sut.Name);
        }

        [TestCase(@"#Microsoft.Azure.Search.StandardTokenizer")]
        [TestCase(@"#Microsoft.Azure.Search.StandardTokenizerV2")]
        public void LuceneStandardTokenizerRoundtrips(string odataType)
        {
            string jsonContent = $@"{{
    ""@odata.type"": ""{odataType}"",
    ""name"": ""test"",
    ""maxTokenLength"": 1
}}";

            JsonDocument jsonDoc = JsonDocument.Parse(jsonContent);
            LuceneStandardTokenizer sut = LexicalTokenizer.DeserializeLexicalTokenizer(jsonDoc.RootElement, ModelReaderWriterOptions.Json) as LuceneStandardTokenizer;

            Assert.NotNull(sut);
            // ODataType is now internal
            Assert.AreEqual("test", sut.Name);
            Assert.AreEqual(1, sut.MaxTokenLength);

            using MemoryStream stream = new MemoryStream();
            using (Utf8JsonWriter writer = new Utf8JsonWriter(stream))
            {
                ((IJsonModel<LuceneStandardTokenizer>)sut).Write(writer, ModelReaderWriterOptions.Json);
            }

            stream.Position = 0;

            jsonDoc = JsonDocument.Parse(stream);
            Assert.True(jsonDoc.RootElement.TryGetProperty("@odata.type", out JsonElement odataTypeElem));
            Assert.AreEqual(odataType, odataTypeElem.GetString());
            jsonDoc.Dispose();
        }
    }
}
