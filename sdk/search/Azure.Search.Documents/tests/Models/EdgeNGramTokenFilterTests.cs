// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Text.Json;
using Azure.Core;
using Azure.Search.Documents.Indexes.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests.Models
{
    public class EdgeNGramTokenFilterTests
    {
        [Test]
        public void CreatesEdgeNGramTokenFilterV2()
        {
            EdgeNGramTokenFilter sut = new EdgeNGramTokenFilter("test");
            Assert.That(sut.ODataType, Is.EqualTo(@"#Microsoft.Azure.Search.EdgeNGramTokenFilterV2"));
        }

        [TestCase(@"#Microsoft.Azure.Search.EdgeNGramTokenFilter")]
        [TestCase(@"#Microsoft.Azure.Search.EdgeNGramTokenFilterV2")]
        public void EdgeNGramTokenFilterRoundtrips(string odataType)
        {
            string jsonContent = $@"{{
    ""@odata.type"": ""{odataType}"",
    ""name"": ""test"",
    ""minGram"": 0,
    ""maxGram"": 1,
    ""side"": ""front""
}}";

            JsonDocument jsonDoc = JsonDocument.Parse(jsonContent);
            EdgeNGramTokenFilter sut = TokenFilter.DeserializeTokenFilter(jsonDoc.RootElement) as EdgeNGramTokenFilter;

            Assert.That(sut, Is.Not.Null);
            Assert.That(sut.ODataType, Is.EqualTo(odataType));
            Assert.That(sut.Name, Is.EqualTo("test"));
            Assert.That(sut.MinGram, Is.EqualTo(0));
            Assert.That(sut.MaxGram, Is.EqualTo(1));
            Assert.That(sut.Side, Is.EqualTo(EdgeNGramTokenFilterSide.Front));

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
