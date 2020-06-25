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

        [TestCase(null, new string[] { })]
        [TestCase("a", new[] { "a" })]
        [TestCase("a,b", new[] { "a", "b" })]
        [TestCase("a, b", new[] { "a", " b" })]
        [TestCase(",b", new[] { "", "b" })]
        [TestCase("a,b,c", new[] { "a", "b", "c" })]
        public void CommaSplitBasic(string source, string[] expected)
        {
            CollectionAssert.AreEqual(expected, SearchExtensions.CommaSplit(source));
        }

        [TestCase("BaseRate asc", new[] { "BaseRate asc" })]
        [TestCase("Rating desc,BaseRate", new[] { "Rating desc", "BaseRate" })]
        [TestCase(
            "Rating desc,geo.distance(Location, geography'POINT(-122.131577 47.678581)') asc",
            new[]
            {
                "Rating desc",
                "geo.distance(Location, geography'POINT(-122.131577 47.678581)') asc"
            })]
        [TestCase(
            "search.score() desc,Rating desc,geo.distance(Location, geography'POINT(-122.131577 47.678581)') asc",
            new[]
            {
                "search.score() desc",
                "Rating desc",
                "geo.distance(Location, geography'POINT(-122.131577 47.678581)') asc"
            })]
        [TestCase("'inside literal , ( )'','", new[] { "'inside literal , ( )'','" })]
        [TestCase(",BaseRate asc", new[] { "BaseRate asc" })]
        public void CommaSplitClauses(string odata, string[] expected)
        {
            CollectionAssert.AreEqual(expected, SearchExtensions.CommaSplit(odata, hasODataFunctions: true));
        }
    }
}
