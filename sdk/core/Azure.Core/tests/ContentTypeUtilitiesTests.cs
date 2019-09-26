// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Pipeline;
using Azure.Core.Testing;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class ContentTypeUtilitiesTests
    {
        [Theory]
        [TestCase(null, false, null)]
        [TestCase("text/json", true, "Unicode (UTF-8)")]
        [TestCase("text/xml", true, "Unicode (UTF-8)")]
        [TestCase("application/json", true, "Unicode (UTF-8)")]
        [TestCase("application/xml", true, "Unicode (UTF-8)")]
        [TestCase("something/else+json", true, "Unicode (UTF-8)")]
        [TestCase("something/else+xml", true, "Unicode (UTF-8)")]
        [TestCase("random/thing; charset=utf-8", true, "Unicode (UTF-8)")]

        public void DetectsTextContentTypes(string contentType, bool isText, string expectedEncoding)
        {
            Assert.AreEqual(isText, ContentTypeUtilities.TryGetTextEncoding(contentType, out System.Text.Encoding encoding));
            Assert.AreEqual(encoding?.EncodingName, expectedEncoding);
        }
    }
}
