// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Text.Json;
using Azure.Core;
using Azure.Search.Documents.Indexes.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests.Models
{
    public class NGramTokenFilterTests
    {
        [Test]
        public void CreatesNGramTokenFilterV2()
        {
            NGramTokenFilter sut = new NGramTokenFilter("test");
            Assert.That(sut.ODataType, Is.EqualTo(@"#Microsoft.Azure.Search.NGramTokenFilterV2"));
        }

        [TestCase(@"#Microsoft.Azure.Search.NGramTokenFilter")]
        [TestCase(@"#Microsoft.Azure.Search.NGramTokenFilterV2")]
        public void NGramTokenFilterRoundtrips(string odataType)
        {
            string jsonContent = $@"{{
    ""@odata.type"": ""{odataType}"",
    ""name"": ""test"",
    ""minGram"": 0,
    ""maxGram"": 1
}}";

            JsonDocument jsonDoc = JsonDocument.Parse(jsonContent);
            NGramTokenFilter sut = TokenFilter.DeserializeTokenFilter(jsonDoc.RootElement) as NGramTokenFilter;

            Assert.That(sut, Is.Not.Null);
            Assert.That(sut.ODataType, Is.EqualTo(odataType));
            Assert.That(sut.Name, Is.EqualTo("test"));
            Assert.That(sut.MinGram, Is.EqualTo(0));
            Assert.That(sut.MaxGram, Is.EqualTo(1));

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
