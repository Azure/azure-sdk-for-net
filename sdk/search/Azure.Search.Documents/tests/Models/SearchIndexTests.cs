// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Search.Documents.Indexes.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests.Models
{
    public class SearchIndexTests
    {
        [TestCase(null, null)]
        [TestCase("*", "*")]
        [TestCase("\"0123abcd\"", "\"0123abcd\"")]
        public void ParsesETag(string value, string expected)
        {
            SearchIndex sut = new SearchIndex(null, new SearchField[0], null, null, null, null, null, null, null, null, null, null, value);
            Assert.AreEqual(expected, sut.ETag?.ToString());
        }
    }
}
