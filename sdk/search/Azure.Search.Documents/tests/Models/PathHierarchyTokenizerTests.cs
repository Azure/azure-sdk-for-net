// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Text.Json;
using Azure.Core;
using Azure.Search.Documents.Indexes.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests.Models
{
    public class PathHierarchyTokenizerTests
    {
        [Test]
        public void CreatesPathHierarchyTokenizerV2()
        {
            PathHierarchyTokenizer sut = new PathHierarchyTokenizer("test");
            Assert.AreEqual(@"#Microsoft.Azure.Search.PathHierarchyTokenizerV2", sut.ODataType);
        }

        [Test]
        public void PathHierarchyTokenizerRoundtrips()
        {
            string jsonContent = @"{
    ""@odata.type"": ""#Microsoft.Azure.Search.PathHierarchyTokenizerV2"",
    ""name"": ""test"",
    ""delimiter"": ""/"",
    ""maxTokenLength"": 300,
    ""skip"": 0,
    ""replacement"": ""/"",
    ""reverse"": false
}";

            JsonDocument jsonDoc = JsonDocument.Parse(jsonContent);
            PathHierarchyTokenizer sut = LexicalTokenizer.DeserializeLexicalTokenizer(jsonDoc.RootElement) as PathHierarchyTokenizer;

            Assert.NotNull(sut);
            Assert.AreEqual(@"#Microsoft.Azure.Search.PathHierarchyTokenizerV2", sut.ODataType);
            Assert.AreEqual("test", sut.Name);
            Assert.AreEqual('/', sut.Delimiter);
            Assert.AreEqual(300, sut.MaxTokenLength);
            Assert.AreEqual(0, sut.NumberOfTokensToSkip);
            Assert.AreEqual('/', sut.Replacement);
            Assert.AreEqual(false, sut.ReverseTokenOrder);

            using MemoryStream stream = new MemoryStream();
            using (Utf8JsonWriter writer = new Utf8JsonWriter(stream))
            {
                ((IUtf8JsonSerializable)sut).Write(writer);
            }

            stream.Position = 0;

            jsonDoc = JsonDocument.Parse(stream);
            Assert.True(jsonDoc.RootElement.TryGetProperty("@odata.type", out JsonElement odataTypeElem));
            Assert.AreEqual(@"#Microsoft.Azure.Search.PathHierarchyTokenizerV2", odataTypeElem.GetString());
        }
    }
}
