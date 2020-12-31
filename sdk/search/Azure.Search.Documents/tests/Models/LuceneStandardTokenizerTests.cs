// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Text.Json;
using Azure.Core;
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
            Assert.AreEqual(@"#Microsoft.Azure.Search.StandardTokenizerV2", sut.ODataType);
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
            LuceneStandardTokenizer sut = LexicalTokenizer.DeserializeLexicalTokenizer(jsonDoc.RootElement) as LuceneStandardTokenizer;

            Assert.NotNull(sut);
            Assert.AreEqual(odataType, sut.ODataType);
            Assert.AreEqual("test", sut.Name);
            Assert.AreEqual(1, sut.MaxTokenLength);

            using MemoryStream stream = new MemoryStream();
            using (Utf8JsonWriter writer = new Utf8JsonWriter(stream))
            {
                ((IUtf8JsonSerializable)sut).Write(writer);
            }

            stream.Position = 0;

            jsonDoc = JsonDocument.Parse(stream);
            Assert.True(jsonDoc.RootElement.TryGetProperty("@odata.type", out JsonElement odataTypeElem));
            Assert.AreEqual(odataType, odataTypeElem.GetString());
        }
    }
}
