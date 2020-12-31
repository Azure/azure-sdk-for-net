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
            Assert.AreEqual(@"#Microsoft.Azure.Search.NGramTokenFilterV2", sut.ODataType);
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

            Assert.NotNull(sut);
            Assert.AreEqual(odataType, sut.ODataType);
            Assert.AreEqual("test", sut.Name);
            Assert.AreEqual(0, sut.MinGram);
            Assert.AreEqual(1, sut.MaxGram);

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
