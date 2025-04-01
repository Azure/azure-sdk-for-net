// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Collections.Generic;
using NUnit.Framework;

namespace System.ClientModel.Tests.Internal
{
    public class PipelineMessageSanitizerTests
    {
        [Test]
        [TestCase("?a", "?a")]
        [TestCase("?a=b", "?a=b")]
        [TestCase("?a=b&", "?a=b&")]
        [TestCase("?d=b&", "?d=*&")]
        [TestCase("?d=a", "?d=*")]
        [TestCase("?a=b&d", "?a=b&d")]
        [TestCase("?a=b&d=1&", "?a=b&d=*&")]
        [TestCase("?a=b&d=1&a1", "?a=b&d=*&a1")]
        [TestCase("?a=b&d=1&a1=", "?a=b&d=*&a1=")]
        [TestCase("?a=b&d=11&a1=&", "?a=b&d=*&a1=&")]
        [TestCase("?d&d&d&", "?d&d&d&")]
        [TestCase("?a&a&a&a", "?a&a&a&a")]
        [TestCase("?&&&&&&&", "?&&&&&&&")]
        [TestCase("?d", "?d")]
        public void QueryIsSanitized(string input, string expected)
        {
            var sanitizer = new PipelineMessageSanitizer(["A", "a1", "a-2"], [], "*");

            Assert.AreEqual("http://localhost/" + expected, sanitizer.SanitizeUrl("http://localhost/" + input));
        }

        [Test]
        public void HeaderIsSanitized()
        {
            var sanitizer = new PipelineMessageSanitizer([], [ "header-1" ], "*");

            Assert.AreEqual("value1", sanitizer.SanitizeHeader("header-1", "value1"));
            Assert.AreEqual("*", sanitizer.SanitizeHeader("header-2", "value2"));
        }

        [Test]
        public void EverythingIsSanitizedWithNoAllowedHeadersOrQueries()
        {
            var sanitizer = new PipelineMessageSanitizer([], [], "*");

            var uri = new Uri("http://localhost/?a=b");

            Assert.AreEqual("http://localhost/?a=*", sanitizer.SanitizeUrl(uri.ToString()));
            Assert.AreEqual("*", sanitizer.SanitizeHeader("header", "value"));
        }
    }
}
