// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Pipeline;
using System.Linq;
using NUnit.Framework;

namespace System.ClientModel.Tests
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
            var sanitizer = new PipelineMessageSanitizer(new[]
            {
                "A",
                "a1",
                "a-2"
            }, Array.Empty<string>(), "*");

            Assert.AreEqual("http://localhost/" + expected, sanitizer.SanitizeUrl("http://localhost/" + input));
        }

        [Test]
        public void HeaderIsSanitized()
        {
            var sanitizer = new PipelineMessageSanitizer(Array.Empty<string>(), new[]
            {
                "header-1"
            }, "*");

            Assert.AreEqual("value1", sanitizer.SanitizeHeader("header-1", "value1"));
            Assert.AreEqual("*", sanitizer.SanitizeHeader("header-2", "value2"));
        }

        [Test]
        public void QueryIsSanitizedAppendQuery()
        {
            var sanitizer = new PipelineMessageSanitizer(Array.Empty<string>(), Array.Empty<string>(), "*");

            var uri = new Uri("http://localhost/?a=b");

            Assert.AreEqual("http://localhost/?a=*", sanitizer.SanitizeUrl(uri.ToString()));
        }

        [Test]
        public void ApiVersionIsNotSanitizedByDefault()
        {
            var sanitizer = new PipelineMessageSanitizer(Array.Empty<string>(), Array.Empty<string>());
            var uri = new Uri("http://localhost/?api-version=2021-11-01");

            Assert.AreEqual("http://localhost/?api-version=2021-11-01", sanitizer.SanitizeUrl(uri.ToString()));
        }

        [Test]
        public void CanRemoveApiVersionFromLoggedQueryParams()
        {
            var sanitizer = new PipelineMessageSanitizer(Array.Empty<string>(), Array.Empty<string>());

            var uri = new Uri("http://localhost/?api-version=2021-11-01");

            Assert.AreEqual("http://localhost/?api-version=REDACTED", sanitizer.SanitizeUrl(uri.ToString()));
        }

        [Test]
        public void AddingAdditionalQueryWorks()
        {
            var sanitizer = new PipelineMessageSanitizer(Array.Empty<string>(), Array.Empty<string>());

            var uri = new Uri("http://localhost/?mode=test");

            Assert.AreEqual("http://localhost/?mode=test", sanitizer.SanitizeUrl(uri.ToString()));
        }
    }
}
