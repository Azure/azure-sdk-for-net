// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Core.Tests;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class HttpPipelineHttpClientHandlerTests
    {
        private static (string, string)[] s_testHeaders = new (string, string)[]
        {
            ("Accept", "application/json"),
            ("Referer", "adcde"),
            ("User-Agent", "adcde"),
            ("Custom-Header", "foo"),
            ("MultiValue-Header", "foo"),
            ("MultiValue-Header", "bar"),
            ("Range", "bytes=0-100"),
            ("Date", "Tue, 12 Nov 2019 08:00:00 GMT")
        };

        private static (string, string)[] s_testContentHeaders = new (string, string)[]
        {
            ("Content-Disposition", "adcde"),
            ("Content-Encoding", "adcde"),
            ("Content-Language", "en-US"),
            ("Content-Location", "adcde"),
            ("Content-MD5", "eyJrZXkiOiJ2YWx1ZSJ9"),
            ("Content-Length", "14"),
        };

        private static (string, string)[] s_testResponseContentHeaders = new (string, string)[]
        {
            ("Last-Modified", "11/12/19"),
            ("Expires", "11/12/19"),
            ("Allow", "\"GET\", \"POST\", \"HEAD\""),
        };

        [Test]
        public async Task ValidateRequestHeaders()
        {
            var mockTransport = new MockTransport(new MockResponse(200));
            var client = CreateHttpClient(mockTransport);

            var content = new StringContent("{\"key\":\"value\"}", Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(HttpMethod.Post, "https://foo.com");

            request.Content = content;

            foreach (var header in s_testContentHeaders)
            {
                request.Content.Headers.Add(header.Item1, header.Item2);
            }

            foreach (var header in s_testHeaders)
            {
                request.Headers.Add(header.Item1, header.Item2);
            }

            await client.SendAsync(request);
            var result = mockTransport.SingleRequest;

            foreach (var expHeader in request.Headers)
            {
                Assert.IsTrue(result.Headers.TryGetValues(expHeader.Key, out IEnumerable<string> actValues));

                CollectionAssert.AreEquivalent(expHeader.Value, actValues);
            }

            foreach (var expHeader in request.Content.Headers)
            {
                Assert.IsTrue(result.Headers.TryGetValues(expHeader.Key, out IEnumerable<string> actValues));

                CollectionAssert.AreEquivalent(expHeader.Value, actValues);
            }

            // assert no additional headers have been added
            foreach (var header in result.Headers)
            {
                if (s_testHeaders.Any(h => h.Item1 == header.Name))
                {
                    Assert.IsTrue(request.Headers.Contains(header.Name));
                }
                else
                {
                    Assert.IsTrue(request.Content.Headers.Contains(header.Name));
                }
            }
        }

        [Test]
        public async Task ValidateResponseHeaders()
        {
            var response = new MockResponse(200);

            response.SetContent("{\"key\":\"value\"}");

            foreach (var header in s_testHeaders.Concat(s_testContentHeaders).Concat(s_testResponseContentHeaders))
            {
                response.AddHeader(new HttpHeader(header.Item1, header.Item2));
            }

            var mockTransport = new MockTransport(response);
            var client = CreateHttpClient(mockTransport);

            var httpResponseMessage = await client.GetAsync("http://foo.com/");

            Assert.AreEqual((int)httpResponseMessage.StatusCode, 200);
            foreach (var header in httpResponseMessage.Headers)
            {
                Assert.IsTrue(response.Headers.TryGetValues(header.Key, out IEnumerable<string> actValues));

                CollectionAssert.AreEquivalent(header.Value, actValues);
            }

            foreach (var header in httpResponseMessage.Content.Headers)
            {
                Assert.IsTrue(response.Headers.TryGetValues(header.Key, out IEnumerable<string> actValues));

                CollectionAssert.AreEquivalent(header.Value, actValues);
            }

            // assert all headers have been accounted for
            foreach (var header in response.Headers)
            {
                if (s_testHeaders.Any(h => h.Item1 == header.Name))
                {
                    Assert.IsTrue(httpResponseMessage.Headers.Contains(header.Name));
                }
                else
                {
                    Assert.IsTrue(httpResponseMessage.Content.Headers.Contains(header.Name));
                }
            }
        }

        private static HttpClient CreateHttpClient(MockTransport mockTransport)
        {
            var client = new HttpClient(new HttpPipelineMessageHandler(new HttpPipeline(mockTransport)));
            return client;
        }
    }
}
