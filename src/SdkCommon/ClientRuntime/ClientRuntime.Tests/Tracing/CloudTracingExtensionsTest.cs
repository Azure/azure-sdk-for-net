// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Xunit;

namespace Microsoft.Rest.ClientRuntime.Tests.Tracing
{
    public class CloudTracingExtensionsTest
    {
        [Fact]
        public void HttpRequestMessageAsFormattedStringThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => HttpExtensions.AsFormattedString((HttpRequestMessage) null));
        }

        [Fact]
        public void HttpRequestMessageAsFormattedStringHandlesEmptyRequests()
        {
            using (var httpRequest = new HttpRequestMessage())
            {
                var formattedString = httpRequest.AsFormattedString();
                Assert.Contains("Method: GET", formattedString);
            }
        }

        [Fact]
        public void HttpRequestMessageAsFormattedStringHandlesRequestsWithHeaders()
        {
            using (var httpRequest = new HttpRequestMessage(HttpMethod.Get, "http://www.windowsazure.com/test"))
            {
                httpRequest.Headers.Add("x-ms-version", "2013-11-01");
                var formattedString = httpRequest.AsFormattedString();
                Assert.Contains("Method: GET", formattedString);
                Assert.Contains("RequestUri: 'http://www.windowsazure.com/test'", formattedString);
                Assert.Contains("x-ms-version: 2013-11-01", formattedString);
            }
        }

        [Fact]
        public void HttpRequestMessageAsFormattedStringHandlesRequestsWithContent()
        {
            using (var httpRequest = new HttpRequestMessage(HttpMethod.Get, "http://www.windowsazure.com/test"))
            {
                httpRequest.Content = new StringContent("<body/>");
                var formattedString = httpRequest.AsFormattedString();
                Assert.Contains("Method: GET", formattedString);
                Assert.Contains("RequestUri: 'http://www.windowsazure.com/test'", formattedString);
                Assert.Contains("<body/>", formattedString);
            }
        }

        [Fact]
        public void HttpResponseMessageAsFormattedStringThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => HttpExtensions.AsFormattedString((HttpResponseMessage) null));
        }

        [Fact]
        public void HttpResponseMessageAsFormattedStringHandlesEmptyRequests()
        {
            using (var httpRequest = new HttpResponseMessage())
            {
                var formattedString = httpRequest.AsFormattedString();
                Assert.Contains("StatusCode: 200", formattedString);
            }
        }

        [Fact]
        public void HttpResponseMessageAsFormattedStringHandlesRequestsWithHeaders()
        {
            using (var httpRequest = new HttpResponseMessage(HttpStatusCode.OK))
            {
                httpRequest.Headers.Add("x-ms-version", "2013-11-01");
                var formattedString = httpRequest.AsFormattedString();
                Assert.Contains("StatusCode: 200", formattedString);
                Assert.Contains("x-ms-version: 2013-11-01", formattedString);
            }
        }

        [Fact]
        public void HttpResponseMessageAsFormattedStringHandlesRequestsWithContent()
        {
            using (var httpRequest = new HttpResponseMessage(HttpStatusCode.OK))
            {
                httpRequest.Content = new StringContent("<body/>");
                var formattedString = httpRequest.AsFormattedString();
                Assert.Contains("StatusCode: 200", formattedString);
                Assert.Contains("<body/>", formattedString);
            }
        }

        [Fact]
        public void DictionaryAsFormattedStringReturnsEmptyBracesForNull()
        {
            var formattedString = HttpExtensions.AsFormattedString((Dictionary<string, object>) null);
            Assert.Equal("{}", formattedString);
        }

        [Fact]
        public void DictionaryAsFormattedStringReturnsEmptyBracesForEmptySet()
        {
            var formattedString = new Dictionary<string, object>().AsFormattedString();
            Assert.Equal("{}", formattedString);
        }

        [Fact]
        public void DictionaryAsFormattedStringReturnsSet()
        {
            var parameters = new Dictionary<string, object>();
            parameters["a"] = 1;
            parameters["b"] = "str";
            parameters["c"] = true;
            var formattedString = parameters.AsFormattedString();
            Assert.Equal("{a=1,b=str,c=True}", formattedString);
        }

        [Fact]
        public void DictionaryAsFormattedStringWorksWithNulls()
        {
            var parameters = new Dictionary<string, object>();
            parameters["a"] = 1;
            parameters["b"] = "str";
            parameters["c"] = null;
            var formattedString = parameters.AsFormattedString();
            Assert.Equal("{a=1,b=str,c=}", formattedString);
        }
    }
}
