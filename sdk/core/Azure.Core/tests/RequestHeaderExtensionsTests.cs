// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class RequestHeaderExtensionsTests
    {
        [TestCaseSource(nameof(ETagRequestHeaderCases))]
        public void AddETagRequestHeader(string original, string expected)
        {
            var request = new MockRequest();
            request.Headers.Add("If-Match", new ETag(original));
            Assert.That(request.Headers.TryGetValue("If-Match", out string value), Is.True);
            Assert.That(value, Is.EqualTo(expected));
        }

        [TestCaseSource(nameof(ETagRequestHeaderCases))]
        public void AddETagMatchConditionsRequestHeader(string original, string expected)
        {
            var request = new MockRequest();
            request.Headers.Add(new MatchConditions
            {
                IfMatch = new ETag(original),
                IfNoneMatch = new ETag(original)
            });
            Assert.That(request.Headers.TryGetValue("If-Match", out string ifMatchValue), Is.True);
            Assert.That(request.Headers.TryGetValue("If-None-Match", out string ifNoneMatchValue), Is.True);
            Assert.That(ifMatchValue, Is.EqualTo(expected));
            Assert.That(ifNoneMatchValue, Is.EqualTo(expected));
        }

        [TestCaseSource(nameof(ETagRequestHeaderCases))]
        public void AddETagRequestConditionsRequestHeader(string original, string expected)
        {
            var request = new MockRequest();
            request.Headers.Add(new RequestConditions
            {
                IfMatch = new ETag(original),
                IfNoneMatch = new ETag(original)
            });
            Assert.That(request.Headers.TryGetValue("If-Match", out string ifMatchValue), Is.True);
            Assert.That(request.Headers.TryGetValue("If-None-Match", out string ifNoneMatchValue), Is.True);
            Assert.That(ifMatchValue, Is.EqualTo(expected));
            Assert.That(ifNoneMatchValue, Is.EqualTo(expected));
        }

        private static readonly object[] ETagRequestHeaderCases =
        {
            new string[] { "*", "*" },
            new string[] { "\"\"", "\"\"" },
            new string[] { "\"abcedfg\"", "\"abcedfg\"" },
            new string[] { "W/\"weakETag\"", "W/\"weakETag\"" },
            new string[] { "abcedfg", "\"abcedfg\"" },
            new string[] { "abcedfg\"", "\"abcedfg\"\""},
            new string[] { "\"abcedfg", "\"\"abcedfg\""},
            new string[] { "W/weakETag\"", "\"W/weakETag\"\"" },
        };
    }
}
