// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Search.Documents.Indexes.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests.Models
{
    public class SkillsetTests
    {
        [TestCase(null, null)]
        [TestCase("*", "*")]
        [TestCase("\"0123abcd\"", "\"0123abcd\"")]
        public void ParsesETag(string value, string expected)
        {
            SearchIndexerSkillset sut = new(name: null, description: null, skills: null, cognitiveServicesAccount: null, knowledgeStore: null, indexProjection: null, etag: value, encryptionKey: null);

            Assert.AreEqual(expected, sut.ETag?.ToString());
        }
    }
}
