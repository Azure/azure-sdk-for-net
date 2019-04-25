// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class HttpClientTransportTests: PipelineTestBase
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
            request.SetRequestLine(HttpPipelineMethod.Get, new Uri("http://example.com"));
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
            request.SetRequestLine(HttpPipelineMethod.Get, new Uri("http://example.com"));
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
            request.SetRequestLine(HttpPipelineMethod.Get, new Uri("http://example.com:340"));

            await ExecuteRequest(request, transport);

            // HttpClientHandler would correctly set Host header from UriBuilder when it's not set explicitly
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
            request.SetRequestLine(HttpPipelineMethod.Get, new Uri("http://example.com:340"));
            request.AddHeader("Host", "example.org");

            await ExecuteRequest(request, transport);

            Assert.AreEqual("example.org", host);
        }

        [TestCase(HttpPipelineMethod.Delete, "DELETE")]
        [TestCase(HttpPipelineMethod.Get, "GET")]
        [TestCase(HttpPipelineMethod.Patch, "PATCH")]
        [TestCase(HttpPipelineMethod.Post, "POST")]
        [TestCase(HttpPipelineMethod.Put, "PUT")]
        public async Task CanGetAndSetMethod(HttpPipelineMethod method, string expectedMethod)
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
            request.SetRequestLine(HttpPipelineMethod.Get, expectedUri);

            Assert.AreEqual(expectedUri.ToString(), request.UriBuilder.ToString());

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
            request.SetRequestLine(HttpPipelineMethod.Get, new Uri("http://example.com:340"));
            request.Content = content;

            Assert.AreEqual(content, request.Content);

            await ExecuteRequest(request, transport);

            CollectionAssert.AreEqual(bytes, requestBytes);
        }

        public static object[] HeadersWithValuesAndType =>
            new object[]
            {
                new object[] { "Allow", "adcde", true },
                new object[] { "Content-Disposition", "adcde", true },
                new object[] { "Content-Encoding", "adcde", true },
                new object[] { "Content-Language", "en-US", true },
                new object[] { "Content-Length", "16", true },
                new object[] { "Content-Location", "adcde", true },
                new object[] { "Content-MD5", "adcde", true },
                new object[] { "Content-Range", "adcde", true },
                new object[] { "Content-Type", "text/xml", true },
                new object[] { "Expires", "11/12/19", true },
                new object[] { "Last-Modified", "11/12/19", true },
                new object[] { "Date", "11/12/19", false },
                new object[] { "Custom-Header", "11/12/19", false }
            };

        [TestCaseSource(nameof(HeadersWithValuesAndType))]
        public async Task CanGetAndSetRequestHeaders(string headerName, string headerValue, bool contentHeader)
        {
            IEnumerable<string> httpHeaderValues = null;

            var mockHandler = new MockHttpClientHandler(
                httpRequestMessage => {
                    Assert.True(
                        httpRequestMessage.Headers.TryGetValues(headerName, out httpHeaderValues) ||
                        httpRequestMessage.Content.Headers.TryGetValues(headerName, out httpHeaderValues));
                });

            var transport = new HttpClientTransport(new HttpClient(mockHandler));
            var request = transport.CreateRequest(null);
            request.SetRequestLine(HttpPipelineMethod.Get, new Uri("http://example.com:340"));
            request.Content = HttpPipelineRequestContent.Create(Array.Empty<byte>());

            request.AddHeader(headerName, headerValue);

            Assert.True(request.TryGetHeader(headerName, out var value));
            Assert.AreEqual(headerValue, value);

            Assert.True(request.TryGetHeader(headerName.ToUpper(), out value));
            Assert.AreEqual(headerValue, value);

            CollectionAssert.AreEqual(new []
            {
                new HttpHeader(headerName, headerValue),
            }, request.Headers);

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
            request.SetRequestLine(HttpPipelineMethod.Get, new Uri("http://example.com:340"));

            var response = await ExecuteRequest(request, transport);

            Assert.True(response.TryGetHeader(headerName, out var value));
            Assert.AreEqual(headerValue, value);

            Assert.True(response.TryGetHeader(headerName.ToUpper(), out value));
            Assert.AreEqual(headerValue, value);

            CollectionAssert.Contains(response.Headers, new HttpHeader(headerName, headerValue));
        }

        [TestCaseSource(nameof(HeadersWithValuesAndType))]
        public async Task SettingContentHeaderDoesNotSetContent(string headerName, string headerValue, bool contentHeader)
        {
            HttpContent httpMessageContent = null;
            var mockHandler = new MockHttpClientHandler(httpRequestMessage => { httpMessageContent = httpRequestMessage.Content; });

            var transport = new HttpClientTransport(new HttpClient(mockHandler));
            var request = transport.CreateRequest(null);
            request.SetRequestLine(HttpPipelineMethod.Get, new Uri("http://example.com:340"));
            request.AddHeader(headerName, headerValue);

            await ExecuteRequest(request, transport);

            Assert.Null(httpMessageContent);
        }

        [Test]
        public async Task RequestAndResponseHasRequestId()
        {
            var mockHandler = new MockHttpClientHandler(httpRequestMessage => { });

            var transport = new HttpClientTransport(new HttpClient(mockHandler));
            var request = transport.CreateRequest(null);
            Assert.IsNotEmpty(request.RequestId);
            Assert.True(Guid.TryParse(request.RequestId, out _));
            request.SetRequestLine(HttpPipelineMethod.Get, new Uri("http://example.com:340"));

            var response =  await ExecuteRequest(request, transport);
            Assert.AreEqual(request.RequestId, response.RequestId);
        }

        [Test]
        public async Task RequestIdCanBeOverriden()
        {
            var mockHandler = new MockHttpClientHandler(httpRequestMessage => { });

            var transport = new HttpClientTransport(new HttpClient(mockHandler));
            var request = transport.CreateRequest(null);

            request.RequestId = "123";
            request.SetRequestLine(HttpPipelineMethod.Get, new Uri("http://example.com:340"));

            var response =  await ExecuteRequest(request, transport);
            Assert.AreEqual(request.RequestId, response.RequestId);
        }

        [Test]
        public async Task ContentStreamIsReturnedSynchronously()
        {
            var content = new AsyncContent()
            {
                MemoryStream = new MemoryStream(new byte[] { 1, 2, 3, 4, 5 })
            };
            var httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = content
            };
            var mockHandler = new MockHttpClientHandler(httpRequestMessage => Task.FromResult(httpResponseMessage));

            var transport = new HttpClientTransport(new HttpClient(mockHandler));
            Request request = transport.CreateRequest(null);
            request.SetRequestLine(HttpPipelineMethod.Get, new Uri("http://example.com:340"));

            Response response = await ExecuteRequest(request, transport);

            byte[] data = new byte[5];
            Stream stream = response.ContentStream;
            Task<int> firstRead = stream.ReadAsync(data, 0, 5);

            Assert.False(firstRead.IsCompleted);

            content.CreateContentReadStreamAsyncCompletionSource.SetResult(null);
            Assert.AreEqual(5, await firstRead);

            // Exercise stream features
            stream.Position = 3;
            stream.Seek(-1, SeekOrigin.Current);
            var secondReadLength = await stream.ReadAsync(data, 0, 5);

            Assert.AreEqual(3, secondReadLength);
            Assert.False(stream.CanWrite);
            Assert.True(stream.CanSeek);
            Assert.True(stream.CanRead);
            Assert.Throws<NotSupportedException>(() => stream.Write(null, 0, 0));
            Assert.Throws<NotSupportedException>(() => stream.SetLength(5));
        }

        [Test]
        public async Task OriginalContentStreamIsReturnedIfNotAsync()
        {
            var content = new AsyncContent()
            {
                MemoryStream = new MemoryStream(new byte[] { 1, 2, 3, 4, 5 })
            };
            var httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = content
            };
            var mockHandler = new MockHttpClientHandler(httpRequestMessage => Task.FromResult(httpResponseMessage));

            var transport = new HttpClientTransport(new HttpClient(mockHandler));
            Request request = transport.CreateRequest(null);
            request.SetRequestLine(HttpPipelineMethod.Get, new Uri("http://example.com:340"));

            Response response = await ExecuteRequest(request, transport);

            byte[] data = new byte[5];

            content.CreateContentReadStreamAsyncCompletionSource.SetResult(null);
            Stream stream = response.ContentStream;

            Assert.AreSame(content.MemoryStream, stream);
        }

        private class AsyncContent : HttpContent
        {
            public TaskCompletionSource<object> CreateContentReadStreamAsyncCompletionSource = new TaskCompletionSource<object>(TaskCreationOptions.RunContinuationsAsynchronously);

            public MemoryStream MemoryStream { get; set; }

            protected override async Task SerializeToStreamAsync(Stream stream, TransportContext context)
            {
                await CreateContentReadStreamAsyncCompletionSource.Task;
                await MemoryStream.CopyToAsync(stream);
            }

            protected override async Task<Stream> CreateContentReadStreamAsync()
            {
                await CreateContentReadStreamAsyncCompletionSource.Task;
                return MemoryStream;
            }

            protected override bool TryComputeLength(out long length)
            {
                length = -1;
                return false;
            }
        }
    }
}
