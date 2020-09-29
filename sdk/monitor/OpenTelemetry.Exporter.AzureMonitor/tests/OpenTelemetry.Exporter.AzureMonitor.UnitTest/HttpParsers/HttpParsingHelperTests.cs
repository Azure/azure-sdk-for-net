// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using OpenTelemetry.Exporter.AzureMonitor.HttpParsers;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Microsoft.ApplicationInsights.Tests
{
    public class HttpParsingHelperTests
    {
        [Fact]
        public void SplitTests()
        {
            var delimiters = new char[] { '/' };
            AssertAreDeepEqual(HttpParsingHelper.Split("a/bb/ccc/dddd", delimiters, 0, -1), "a", "bb", "ccc", "dddd");
            AssertAreDeepEqual(HttpParsingHelper.Split("/a/bb/ccc/dddd", delimiters, 0, -1), string.Empty, "a", "bb", "ccc", "dddd");
            AssertAreDeepEqual(HttpParsingHelper.Split("/a/bb/ccc/dddd", delimiters, 1, -1), "a", "bb", "ccc", "dddd");
            AssertAreDeepEqual(HttpParsingHelper.Split("/a/bb/ccc/dddd/", delimiters, 1, -1), "a", "bb", "ccc", "dddd", string.Empty);
            AssertAreDeepEqual(HttpParsingHelper.Split("/a/bb/ccc/dddd?ee", delimiters, 1, 14), "a", "bb", "ccc", "dddd");
            AssertAreDeepEqual(HttpParsingHelper.Split("/a/bb/ccc/dddd", delimiters, 3, 8), "bb", "cc");
            AssertAreDeepEqual(HttpParsingHelper.Split("/a//bb//ccc//dddd/", delimiters, 1, -1), "a", string.Empty, "bb", string.Empty, "ccc", string.Empty, "dddd", string.Empty);
        }

        [Fact]
        public void TokenizeRequestPathTests()
        {
            AssertAreDeepEqual(HttpParsingHelper.TokenizeRequestPath("a/bb/ccc/dddd"), "a", "bb", "ccc", "dddd");
            AssertAreDeepEqual(HttpParsingHelper.TokenizeRequestPath("/a/bb/ccc/dddd"), "a", "bb", "ccc", "dddd");
            AssertAreDeepEqual(HttpParsingHelper.TokenizeRequestPath("/a/bb/ccc/dddd/"), "a", "bb", "ccc", "dddd", string.Empty);
            AssertAreDeepEqual(HttpParsingHelper.TokenizeRequestPath("/a/bb/ccc/dddd?ee"), "a", "bb", "ccc", "dddd");
            AssertAreDeepEqual(HttpParsingHelper.TokenizeRequestPath("/a/bb/ccc/dddd/?ee"), "a", "bb", "ccc", "dddd", string.Empty);
            AssertAreDeepEqual(HttpParsingHelper.TokenizeRequestPath("/a/bb/ccc/dddd#ee"), "a", "bb", "ccc", "dddd");
            AssertAreDeepEqual(HttpParsingHelper.TokenizeRequestPath("/a/bb/ccc/dddd?ee/ff"), "a", "bb", "ccc", "dddd");
        }

        [Fact]
        public void ExtractQuryParametersTests()
        {
            Assert.Null(HttpParsingHelper.ExtractQuryParameters("a/bb/ccc/dddd"));
            Assert.Null(HttpParsingHelper.ExtractQuryParameters("a/bb/ccc/dddd?"));
            Assert.Null(HttpParsingHelper.ExtractQuryParameters("a/bb/ccc/dddd?#x=y"));
            AssertQueryParametersAreValid(HttpParsingHelper.ExtractQuryParameters("a/bb/ccc/dddd?x"), "x", null);
            AssertQueryParametersAreValid(HttpParsingHelper.ExtractQuryParameters("a/bb/ccc/dddd?x#y=z"), "x", null);
            AssertQueryParametersAreValid(HttpParsingHelper.ExtractQuryParameters("/a/bb/ccc/dddd?x=&w=z"), "x", string.Empty, "w", "z");
            AssertQueryParametersAreValid(HttpParsingHelper.ExtractQuryParameters("/a/bb/ccc/dddd?x=y&w=z"), "x", "y", "w", "z");
            AssertQueryParametersAreValid(HttpParsingHelper.ExtractQuryParameters("/a/bb/ccc/dddd?x=y&w=z#0=1"), "x", "y", "w", "z");
            AssertQueryParametersAreValid(HttpParsingHelper.ExtractQuryParameters("/a/bb/ccc/dddd/?x=y&w=z#0=1"), "x", "y", "w", "z");
        }

        [Fact]
        public void ParseResourcePathTests()
        {
            AssertRequestPathIsValid(HttpParsingHelper.ParseResourcePath("a/bb/ccc"), "a", "bb", "ccc", null);
            AssertRequestPathIsValid(HttpParsingHelper.ParseResourcePath("a/bb/ccc/"), "a", "bb", "ccc", string.Empty);
            AssertRequestPathIsValid(HttpParsingHelper.ParseResourcePath("/a/bb/ccc/dddd"), "a", "bb", "ccc", "dddd");
            AssertRequestPathIsValid(HttpParsingHelper.ParseResourcePath("/a/bb/ccc/dddd/"), "a", "bb", "ccc", "dddd");
            AssertRequestPathIsValid(HttpParsingHelper.ParseResourcePath("/a/bb/a/dddd"), "a", "bb", "a", "dddd");
            AssertRequestPathIsValid(HttpParsingHelper.ParseResourcePath("/a/bb/ccc/dddd?ee"), "a", "bb", "ccc", "dddd");
            AssertRequestPathIsValid(HttpParsingHelper.ParseResourcePath("/a/bb/ccc#ee/ff"), "a", "bb", "ccc", null);
            AssertRequestPathIsValid(HttpParsingHelper.ParseResourcePath("/a/bb/ccc/?ee/ff"), "a", "bb", "ccc", string.Empty);
        }

        [Fact]
        public void BuildOperationMonikerTests()
        {
            ValidateBuildOperationMoniker("PUT", "a/bb/ccc", "PUT /a/*/ccc");
            ValidateBuildOperationMoniker("PUT", "a/bb/ccc/", "PUT /a/*/ccc/*");
            ValidateBuildOperationMoniker("GET", "/a/bb/ccc/dddd", "GET /a/*/ccc/*");
            ValidateBuildOperationMoniker("GET", "/a/bb/ccc/dddd/", "GET /a/*/ccc/*");
            ValidateBuildOperationMoniker("PUT", "/a/bb/a/dddd", "PUT /a/*/a/*");
            ValidateBuildOperationMoniker("PUT", "/a/bb/ccc/dddd?ee", "PUT /a/*/ccc/*");
            ValidateBuildOperationMoniker("PUT", "/a/bb/ccc#ee/ff", "PUT /a/*/ccc");
            ValidateBuildOperationMoniker("PUT", "/a/bb/ccc/?ee/ff", "PUT /a/*/ccc/*");
        }

        private static void ValidateBuildOperationMoniker(string verb, string url, string expectedMoniker)
        {
            var resourcePath = HttpParsingHelper.ParseResourcePath(url);
            Assert.Equal(expectedMoniker, HttpParsingHelper.BuildOperationMoniker(verb, resourcePath));
        }

        private static void AssertQueryParametersAreValid(Dictionary<string, string> queryParameters, params string[] expected)
        {
            Assert.Equal(expected.Length, 2 * queryParameters.Count);
            for (int i = 0; i < expected.Length / 2; i++)
            {
                string value = null;
                string key = expected[2 * i];
                Assert.True(queryParameters.TryGetValue(key, out value));
                Assert.Equal(expected[(2 * i) + 1], value);
            }
        }

        private static void AssertRequestPathIsValid(List<KeyValuePair<string, string>> resourcePath, params string[] expected)
        {
            List<string> actual = resourcePath.SelectMany(kvp => new[] { kvp.Key, kvp.Value }).ToList();

            AssertAreDeepEqual(actual, expected);
        }

        private static void AssertAreDeepEqual(List<string> actual, params string[] expected)
        {
            AssertAreDeepEqual(actual, new List<string>(expected));
        }

        private static void AssertAreDeepEqual(List<string> actual, List<string> expected)
        {
            Assert.Equal(expected.Count, actual.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.Equal(expected[i], actual[i]);
            }
        }
    }
}
