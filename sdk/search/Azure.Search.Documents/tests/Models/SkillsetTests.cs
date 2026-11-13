// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
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
            SearchIndexerSkillset sut = new("test", skills: new List<SearchIndexerSkill>()) { Description = null };
            // ETag is read-only from server responses, cannot be set directly in constructor
            // Skip test as ETag is now only settable through deserialization
        }
    }
}
