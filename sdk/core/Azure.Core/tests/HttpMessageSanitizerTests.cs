// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class HttpMessageSanitizerTests
    {
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
            var sanitizer = new HttpMessageSanitizer(new[]
            {
                "A",
                "a1",
                "a-2"
            }, Array.Empty<string>(), "*");

            Assert.AreEqual("http://localhost/" + expected, sanitizer.SanitizeUrl("http://localhost/" + input));
        }

        [Test]
        public void QueryIsSanitizedAppendQuery()
        {
            var sanitizer = new HttpMessageSanitizer(Array.Empty<string>(), Array.Empty<string>(), "*");

            var uriBuilder = new RequestUriBuilder();
            uriBuilder.Reset(new Uri("http://localhost/"));
            uriBuilder.AppendQuery("a", "b");

            Assert.AreEqual("http://localhost/?a=*", sanitizer.SanitizeUrl(uriBuilder.ToString()));
        }
    }
}