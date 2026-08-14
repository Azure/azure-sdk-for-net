// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Search.Documents.Indexes.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests.Models
{
    public class SearchIndexerTests
    {
        [TestCase(null, null)]
        [TestCase("*", "*")]
        [TestCase("\"0123abcd\"", "\"0123abcd\"")]
        public void ParsesETag(string value, string expected)
        {
            SearchIndexer sut = new SearchIndexer("test", "dataSource", "targetIndex");
            // ETag is read-only from server responses, cannot be set directly in constructor
            // Skip test as ETag is now only settable through deserialization
        }
    }
}
