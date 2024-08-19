// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Pipeline;
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

        [Test]
        public void ApiVersionIsNotSanitizedByDefault()
        {
            HttpMessageSanitizer sanitizer = ClientDiagnostics.CreateMessageSanitizer(ClientOptions.Default.Diagnostics);
            var uriBuilder = new RequestUriBuilder();
            uriBuilder.Reset(new Uri("http://localhost/"));
            uriBuilder.AppendQuery("api-version", "2021-11-01");

            Assert.AreEqual("http://localhost/?api-version=2021-11-01", sanitizer.SanitizeUrl(uriBuilder.ToString()));
        }

        [Test]
        public void AddingApiVersionManuallyStillWorks()
        {
            var options = new DefaultClientOptions();
            options.Diagnostics.LoggedQueryParameters.Add("api-version");

            HttpMessageSanitizer sanitizer = ClientDiagnostics.CreateMessageSanitizer(options.Diagnostics);
            var uriBuilder = new RequestUriBuilder();
            uriBuilder.Reset(new Uri("http://localhost/"));
            uriBuilder.AppendQuery("api-version", "2021-11-01");

            Assert.AreEqual("http://localhost/?api-version=2021-11-01", sanitizer.SanitizeUrl(uriBuilder.ToString()));
        }

        [Test]
        public void CanRemoveApiVersionFromLoggedQueryParams()
        {
            var options = new DefaultClientOptions();
            options.Diagnostics.LoggedQueryParameters.Remove("api-version");

            HttpMessageSanitizer sanitizer = ClientDiagnostics.CreateMessageSanitizer(options.Diagnostics);
            var uriBuilder = new RequestUriBuilder();
            uriBuilder.Reset(new Uri("http://localhost/"));
            uriBuilder.AppendQuery("api-version", "2021-11-01");

            Assert.AreEqual("http://localhost/?api-version=REDACTED", sanitizer.SanitizeUrl(uriBuilder.ToString()));
        }
    }
}