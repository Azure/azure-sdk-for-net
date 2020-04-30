// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Search.Documents.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests.Models
{
    public class DataSourceTests
    {
        [TestCase(null, null)]
        [TestCase("*", "*")]
        [TestCase("\"0123abcd\"", "\"0123abcd\"")]
        public void ParsesETag(string value, string expected)
        {
            DataSource sut = new DataSource(null, null, DataSourceType.AzureBlob, null, null, null, null, value);
            Assert.AreEqual(expected, sut.ETag?.ToString());
        }
    }
}
