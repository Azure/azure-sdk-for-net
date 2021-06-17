// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests.Utilities
{
    public class SearchExtensionsTests
    {
        [TestCase(null, null)]
        [TestCase(new string[] { }, null)]
        [TestCase(new[] { "a" }, "a")]
        [TestCase(new[] { "a", "b" }, "a,b")]
        [TestCase(new[] { null, "b" }, ",b")]
        public void CommaJoin(IEnumerable<string> source, string expected)
        {
            string actual = source.CommaJoin();
            Assert.AreEqual(expected, actual);
        }
    }
}
