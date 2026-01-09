// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Text.Json;
using Azure.Core;
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
            Assert.That(sut.ODataType, Is.EqualTo(@"#Microsoft.Azure.Search.KeywordTokenizerV2"));
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
            KeywordTokenizer sut = LexicalTokenizer.DeserializeLexicalTokenizer(jsonDoc.RootElement) as KeywordTokenizer;

            Assert.That(sut, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(sut.ODataType, Is.EqualTo(odataType));
                Assert.That(sut.Name, Is.EqualTo("test"));
                Assert.That(sut.BufferSize, Is.EqualTo(1));
                Assert.That(sut.MaxTokenLength, Is.EqualTo(1));
            });

            using MemoryStream stream = new MemoryStream();
            using (Utf8JsonWriter writer = new Utf8JsonWriter(stream))
            {
                ((IUtf8JsonSerializable)sut).Write(writer);
            }

            stream.Position = 0;

            jsonDoc = JsonDocument.Parse(stream);
            Assert.Multiple(() =>
            {
                Assert.That(jsonDoc.RootElement.TryGetProperty("@odata.type", out JsonElement odataTypeElem), Is.True);
                Assert.That(odataTypeElem.GetString(), Is.EqualTo(odataType));
            });
            jsonDoc.Dispose();
        }
    }
}
