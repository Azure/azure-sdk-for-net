// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Pipeline;
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
        [TestCase("application/json; odata.metadata=minimal", true, "Unicode (UTF-8)")]
        [TestCase("application/json; odata.metadata=full", true, "Unicode (UTF-8)")]
        [TestCase("application/json; odata.metadata=none", true, "Unicode (UTF-8)")]
        [TestCase("application/x-www-form-urlencoded", true, "Unicode (UTF-8)")]
        [TestCase("application/x-www-form-urlencoded; charset=utf-8", true, "Unicode (UTF-8)")]

        // No other explicit encoding besides "utf-8" is supported, so falls through to defaulting to "utf-8" based on Content-Type.
        [TestCase("application/x-www-form-urlencoded; charset=us-ascii", true, "Unicode (UTF-8)")]

        public void DetectsTextContentTypes(string contentType, bool isText, string expectedEncoding)
        {
            Assert.That(ContentTypeUtilities.TryGetTextEncoding(contentType, out System.Text.Encoding encoding), Is.EqualTo(isText));
            Assert.That(expectedEncoding, Is.EqualTo(encoding?.EncodingName));
        }
    }
}
