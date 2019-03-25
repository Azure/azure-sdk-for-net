// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Base.Http;
using Azure.Base.Http.Pipeline;
using NUnit.Framework;

namespace Azure.Configuration.Tests
{
    public class HttpClientTransportTests
    {
        public static object[] ContentWithLength =>
            new object[]
            {
                new object[] { HttpPipelineRequestContent.Create(new byte[10]), 10 },
                new object[] { HttpPipelineRequestContent.Create(new byte[10], 5, 5), 5 },
                new object[] { HttpPipelineRequestContent.Create(new ReadOnlyMemory<byte>(new byte[10])), 10 },
                new object[] { HttpPipelineRequestContent.Create(new ReadOnlyMemory<byte>(new byte[10]).Slice(5)), 5 },
                new object[] { HttpPipelineRequestContent.Create(new ReadOnlySequence<byte>(new byte[10])), 10 },
            };

        [TestCaseSource(nameof(ContentWithLength))]
        public async Task ContentLengthIsSetForArrayContent(HttpPipelineRequestContent content, int expectedLength)
        {
            long contentLength = 0;
            var mockHandler = new MockHttpClientHandler(
                httpRequestMessage => contentLength = httpRequestMessage.Content.Headers.ContentLength.Value
                );

            var transport = new HttpClientTransport(new HttpClient(mockHandler));
            var request = transport.CreateRequest(null);
            request.SetRequestLine(HttpVerb.Get, new Uri("http://example.com"));
            request.Content = content;

            await ExecuteRequest(request, transport);

            Assert.AreEqual(expectedLength, contentLength);
        }

        [Test]
        public async Task SettingHeaderOverridesDefaultContentLength()
        {
            long contentLength = 0;
            var mockHandler = new MockHttpClientHandler(
                httpRequestMessage => contentLength = httpRequestMessage.Content.Headers.ContentLength.Value);

            var transport = new HttpClientTransport(new HttpClient(mockHandler));
            var request = transport.CreateRequest(null);
            request.SetRequestLine(HttpVerb.Get, new Uri("http://example.com"));
            request.Content = HttpPipelineRequestContent.Create(new byte[10]);
            request.AddHeader("Content-Length", "50");

            await ExecuteRequest(request, transport);

            Assert.AreEqual(50, contentLength);
        }

        [Test]
        public async Task HostHeaderSetFromUri()
        {
            string host = null;
            Uri uri = null;
            var mockHandler = new MockHttpClientHandler(
                httpRequestMessage => {
                    uri = httpRequestMessage.RequestUri;
                    host = httpRequestMessage.Headers.Host;
                });

            var transport = new HttpClientTransport(new HttpClient(mockHandler));
            var request = transport.CreateRequest(null);
            request.SetRequestLine(HttpVerb.Get, new Uri("http://example.com:340"));

            await ExecuteRequest(request, transport);

            // HttpClientHandler would correctly set Host header from Uri when it's not set explicitly
            Assert.AreEqual("http://example.com:340/", uri.ToString());
            Assert.Null(host);
        }

        [Test]
        public async Task SettingHeaderOverridesDefaultHost()
        {
            string host = null;
            var mockHandler = new MockHttpClientHandler(
                httpRequestMessage => {
                    host = httpRequestMessage.Headers.Host;
                });

            var transport = new HttpClientTransport(new HttpClient(mockHandler));
            var request = transport.CreateRequest(null);
            request.SetRequestLine(HttpVerb.Get, new Uri("http://example.com:340"));
            request.AddHeader("Host", "example.org");

            await ExecuteRequest(request, transport);

            Assert.AreEqual("example.org", host);
        }

        [TestCase(HttpVerb.Delete, "DELETE")]
        [TestCase(HttpVerb.Get, "GET")]
        [TestCase(HttpVerb.Patch, "PATCH")]
        [TestCase(HttpVerb.Post, "POST")]
        [TestCase(HttpVerb.Put, "PUT")]
        public async Task CanGetAndSetMethod(HttpVerb method, string expectedMethod)
        {
            HttpMethod httpMethod = null;
            var mockHandler = new MockHttpClientHandler(
                httpRequestMessage => {
                    httpMethod = httpRequestMessage.Method;
                });

            var transport = new HttpClientTransport(new HttpClient(mockHandler));
            var request = transport.CreateRequest(null);
            request.SetRequestLine(method, new Uri("http://example.com:340"));

            Assert.AreEqual(method, request.Method);

            await ExecuteRequest(request, transport);

            Assert.AreEqual(expectedMethod, httpMethod.Method);
        }

        [Test]
        public async Task CanGetAndSetUri()
        {
            Uri requestUri = null;
            var mockHandler = new MockHttpClientHandler(
                httpRequestMessage => {
                    requestUri = httpRequestMessage.RequestUri;
                });

            var expectedUri = new Uri("http://example.com:340");
            var transport = new HttpClientTransport(new HttpClient(mockHandler));
            var request = transport.CreateRequest(null);
            request.SetRequestLine(HttpVerb.Get, expectedUri);

            Assert.AreEqual(expectedUri, request.Uri);

            await ExecuteRequest(request, transport);

            Assert.AreEqual(expectedUri, requestUri);
        }

        [Test]
        public async Task CanGetAndSetContent()
        {
            byte[] requestBytes = null;
            var mockHandler = new MockHttpClientHandler(
                async httpRequestMessage => {
                    requestBytes = await httpRequestMessage.Content.ReadAsByteArrayAsync();
                });

            var bytes = Encoding.ASCII.GetBytes("Hello world");
            var content = HttpPipelineRequestContent.Create(bytes);
            var transport = new HttpClientTransport(new HttpClient(mockHandler));
            var request = transport.CreateRequest(null);
            request.SetRequestLine(HttpVerb.Get, new Uri("http://example.com:340"));
            request.Content = content;

            Assert.AreEqual(content, request.Content);

            await ExecuteRequest(request, transport);

            CollectionAssert.AreEqual(bytes, requestBytes);
        }

        public static object[] HeadersWithValuesAndType =>
            new object[]
            {
                new object[] {"Content-Length", "10", true},
                new object[] {"Content-Type", "text/xml", true},
                new object[] {"Date", "11/12/19", false}
            };

        [TestCaseSource(nameof(HeadersWithValuesAndType))]
        public async Task CanGetAndSetRequestHeaders(string headerName, string headerValue, bool contentHeader)
        {
            IEnumerable<string> httpHeaderValues = null;

            var mockHandler = new MockHttpClientHandler(
                httpRequestMessage => {
                    Assert.True(
                        contentHeader
                            ? httpRequestMessage.Content.Headers.TryGetValues(headerName, out httpHeaderValues)
                            : httpRequestMessage.Headers.TryGetValues(headerName, out httpHeaderValues));
                });

            var transport = new HttpClientTransport(new HttpClient(mockHandler));
            var request = transport.CreateRequest(null);
            request.SetRequestLine(HttpVerb.Get, new Uri("http://example.com:340"));
            request.Content = HttpPipelineRequestContent.Create(Array.Empty<byte>());

            request.AddHeader(headerName, headerValue);

            Assert.True(request.TryGetHeader(headerName, out var value));
            Assert.AreEqual(headerValue, value);

            Assert.True(request.TryGetHeader(headerName.ToUpper(), out value));
            Assert.AreEqual(headerValue, value);

            CollectionAssert.AreEqual(new []
            {
                new HttpHeader(headerName, headerValue),
            }, request.GetHeaders());

            await ExecuteRequest(request, transport);

            Assert.AreEqual(headerValue, string.Join(",", httpHeaderValues));
        }

        [TestCaseSource(nameof(HeadersWithValuesAndType))]
        public async Task CanGetAndSetResponseHeaders(string headerName, string headerValue, bool contentHeader)
        {
            var mockHandler = new MockHttpClientHandler(
                httpRequestMessage => {
                    var responseMessage = new HttpResponseMessage((HttpStatusCode)200);

                    if (contentHeader)
                    {
                        responseMessage.Content = new StreamContent(new MemoryStream());
                        Assert.True(responseMessage.Content.Headers.TryAddWithoutValidation(headerName, headerValue));
                    }
                    else
                    {
                        Assert.True(responseMessage.Headers.TryAddWithoutValidation(headerName, headerValue));
                    }

                    return Task.FromResult(responseMessage);
                });

            var transport = new HttpClientTransport(new HttpClient(mockHandler));
            var request = transport.CreateRequest(null);
            request.SetRequestLine(HttpVerb.Get, new Uri("http://example.com:340"));

            var response = await ExecuteRequest(request, transport);

            Assert.True(response.TryGetHeader(headerName, out var value));
            Assert.AreEqual(headerValue, value);

            Assert.True(response.TryGetHeader(headerName.ToUpper(), out value));
            Assert.AreEqual(headerValue, value);

            CollectionAssert.AreEqual(new []
            {
                new HttpHeader(headerName, headerValue),
            }, response.GetHeaders());
        }


        private static async Task<HttpPipelineResponse> ExecuteRequest(HttpPipelineRequest request, HttpClientTransport transport)
        {
            using (var message = new HttpPipelineMessage(CancellationToken.None)
            {
                Request = request
            })
            {
                await transport.ProcessAsync(message);
                return message.Response;
            }
        }

        private class MockHttpClientHandler : HttpMessageHandler
        {
            private readonly Func<HttpRequestMessage, Task<HttpResponseMessage>> _onSend;

            public MockHttpClientHandler(Action<HttpRequestMessage> onSend)
            {
                _onSend = req => {
                    onSend(req);
                    return null;
                };
            }

            public MockHttpClientHandler(Func<HttpRequestMessage, Task<HttpResponseMessage>> onSend)
            {
                _onSend = onSend;
            }

            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                var response = await _onSend(request);

                return response ?? new HttpResponseMessage((HttpStatusCode)200);
            }
        }
    }
}
