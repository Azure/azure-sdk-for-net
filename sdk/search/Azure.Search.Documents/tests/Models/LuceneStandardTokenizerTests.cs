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
            Assert.That(sut.ODataType, Is.EqualTo(@"#Microsoft.Azure.Search.StandardTokenizerV2"));
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

            Assert.That(sut, Is.Not.Null);
            Assert.That(sut.ODataType, Is.EqualTo(odataType));
            Assert.That(sut.Name, Is.EqualTo("test"));
            Assert.That(sut.MaxTokenLength, Is.EqualTo(1));

            using MemoryStream stream = new MemoryStream();
            using (Utf8JsonWriter writer = new Utf8JsonWriter(stream))
            {
                ((IUtf8JsonSerializable)sut).Write(writer);
            }

            stream.Position = 0;

            jsonDoc = JsonDocument.Parse(stream);
            Assert.That(jsonDoc.RootElement.TryGetProperty("@odata.type", out JsonElement odataTypeElem), Is.True);
            Assert.That(odataTypeElem.GetString(), Is.EqualTo(odataType));
            jsonDoc.Dispose();
        }
    }
}
