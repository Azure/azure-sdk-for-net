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
            Assert.AreEqual(@"#Microsoft.Azure.Search.EdgeNGramTokenFilterV2", sut.ODataType);
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

            Assert.NotNull(sut);
            Assert.AreEqual(odataType, sut.ODataType);
            Assert.AreEqual("test", sut.Name);
            Assert.AreEqual(0, sut.MinGram);
            Assert.AreEqual(1, sut.MaxGram);
            Assert.AreEqual(EdgeNGramTokenFilterSide.Front, sut.Side);

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
