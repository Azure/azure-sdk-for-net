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
            Assert.That(sut.ODataType, Is.EqualTo(@"#Microsoft.Azure.Search.PathHierarchyTokenizerV2"));
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

            Assert.That(sut, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(sut.ODataType, Is.EqualTo(@"#Microsoft.Azure.Search.PathHierarchyTokenizerV2"));
                Assert.That(sut.Name, Is.EqualTo("test"));
                Assert.That(sut.Delimiter, Is.EqualTo('/'));
                Assert.That(sut.MaxTokenLength, Is.EqualTo(300));
                Assert.That(sut.NumberOfTokensToSkip, Is.EqualTo(0));
                Assert.That(sut.Replacement, Is.EqualTo('/'));
                Assert.That(sut.ReverseTokenOrder, Is.EqualTo(false));
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
                Assert.That(odataTypeElem.GetString(), Is.EqualTo(@"#Microsoft.Azure.Search.PathHierarchyTokenizerV2"));
            });
            jsonDoc.Dispose();
        }
    }
}
