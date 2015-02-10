//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Hyak.Common;
using Xunit;

namespace Microsoft.Azure.Common.Tracing.Etw.Test
{
    public class CloudTracingExtensionsTest
    {
        [Fact]
        public void HttpRequestMessageAsFormattedStringThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => TracingExtensions.AsFormattedString((HttpRequestMessage)null));
        }

        [Fact]
        public void HttpRequestMessageAsFormattedStringHandlesEmptyRequests()
        {
            using (var httpRequest = new HttpRequestMessage())
            {
                var formattedString = TracingExtensions.AsFormattedString(httpRequest);

                Assert.Contains("Method: GET", formattedString);
            }
        }

        [Fact]
        public void HttpRequestMessageAsFormattedStringHandlesRequestsWithHeaders()
        {
            using (var httpRequest = new HttpRequestMessage(HttpMethod.Get, "http://www.windowsazure.com/test"))
            {
                httpRequest.Headers.Add("x-ms-version", "2013-11-01");
                var formattedString = TracingExtensions.AsFormattedString(httpRequest);

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
                var formattedString = TracingExtensions.AsFormattedString(httpRequest);

                Assert.Contains("Method: GET", formattedString);
                Assert.Contains("RequestUri: 'http://www.windowsazure.com/test'", formattedString);
                Assert.Contains("<body/>", formattedString);
            }
        }

        [Fact]
        public void HttpResponseMessageAsFormattedStringThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => TracingExtensions.AsFormattedString((HttpResponseMessage)null));
        }

        [Fact]
        public void HttpResponseMessageAsFormattedStringHandlesEmptyRequests()
        {
            using (var httpRequest = new HttpResponseMessage())
            {
                var formattedString = TracingExtensions.AsFormattedString(httpRequest);

                Assert.Contains("StatusCode: 200", formattedString);
            }
        }

        [Fact]
        public void HttpResponseMessageAsFormattedStringHandlesRequestsWithHeaders()
        {
            using (var httpRequest = new HttpResponseMessage(HttpStatusCode.OK))
            {
                httpRequest.Headers.Add("x-ms-version", "2013-11-01");
                var formattedString = TracingExtensions.AsFormattedString(httpRequest);

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
                var formattedString = TracingExtensions.AsFormattedString(httpRequest);

                Assert.Contains("StatusCode: 200", formattedString);
                Assert.Contains("<body/>", formattedString);
            }
        }

        [Fact]
        public void DictionaryAsFormattedStringReturnsEmptyBracesForNull()
        {
            var formattedString = TracingExtensions.AsFormattedString((Dictionary<string, object>)null);

            Assert.Equal("{}", formattedString);
        }

        [Fact]
        public void DictionaryAsFormattedStringReturnsEmptyBracesForEmptySet()
        {
            var formattedString = TracingExtensions.AsFormattedString(new Dictionary<string, object>());

            Assert.Equal("{}", formattedString);
        }

        [Fact]
        public void DictionaryAsFormattedStringReturnsSet()
        {
            var parameters = new Dictionary<string, object>();
            parameters["a"] = 1;
            parameters["b"] = "str";
            parameters["c"] = true;
            var formattedString = TracingExtensions.AsFormattedString(parameters);

            Assert.Equal("{a=1,b=str,c=True}", formattedString);
        }

        [Fact]
        public void DictionaryAsFormattedStringWorksWithNulls()
        {
            var parameters = new Dictionary<string, object>();
            parameters["a"] = 1;
            parameters["b"] = "str";
            parameters["c"] = null;
            var formattedString = TracingExtensions.AsFormattedString(parameters);

            Assert.Equal("{a=1,b=str,c=}", formattedString);
        }
    }
}
