// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    [TestFixture(true)]
    [TestFixture(false)]
    public class HttpClientTransportTests : PipelineTestBase
    {
        public HttpClientTransportTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task DoesntDisposeContentIfStreamGotReplaced()
        {
            DisposeTrackingHttpContent disposeTrackingContent = new DisposeTrackingHttpContent();

            var mockHandler = new MockHttpClientHandler(
                httpRequestMessage =>
                {
                    return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = disposeTrackingContent
                    });
                });

            var transport = new HttpClientTransport(mockHandler);
            Request request = transport.CreateRequest();
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("https://example.com:340"));

            Response response = await ExecuteRequest(request, transport);

            response.ContentStream = new MemoryStream();
            response.Dispose();

            Assert.False(disposeTrackingContent.IsDisposed);
        }

        [Test]
        public async Task CanGetAndSetUri()
        {
            Uri requestUri = null;
            var mockHandler = new MockHttpClientHandler(
                httpRequestMessage =>
                {
                    requestUri = httpRequestMessage.RequestUri;
                });

            var expectedUri = new Uri("http://example.com:340");
            var transport = new HttpClientTransport(mockHandler);
            Request request = transport.CreateRequest();
            request.Method = RequestMethod.Get;
            request.Uri.Reset(expectedUri);

            Assert.AreEqual(expectedUri.ToString(), request.Uri.ToString());

            await ExecuteRequest(request, transport);

            Assert.AreEqual(expectedUri, requestUri);
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
        public async Task SettingContentHeaderDoesNotSetContent(string headerName, string headerValue, bool contentHeader)
        {
            HttpContent httpMessageContent = null;
            var mockHandler = new MockHttpClientHandler(httpRequestMessage => { httpMessageContent = httpRequestMessage.Content; });

            var transport = new HttpClientTransport(mockHandler);
            Request request = transport.CreateRequest();
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("https://example.com:340"));
            request.Headers.Add(headerName, headerValue);

            await ExecuteRequest(request, transport);

            Assert.Null(httpMessageContent);
        }

        [TestCaseSource(nameof(HeadersWithValuesAndType))]
        public async Task SettingContentStreamPreservesHeaders(string headerName, string headerValue, bool contentHeader)
        {
            var mockHandler = new MockHttpClientHandler(
                httpRequestMessage =>
                {
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

            var transport = new HttpClientTransport(mockHandler);
            Request request = transport.CreateRequest();
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("https://example.com:340"));

            Response response = await ExecuteRequest(request, transport);
            response.ContentStream = new MemoryStream();

            Assert.True(response.Headers.Contains(headerName));

            Assert.True(response.Headers.TryGetValue(headerName, out var value));
            Assert.AreEqual(headerValue, value);

            Assert.True(response.Headers.TryGetValues(headerName, out IEnumerable<string> values));
            CollectionAssert.AreEqual(new[] { headerValue }, values);

            CollectionAssert.Contains(response.Headers, new HttpHeader(headerName, headerValue));
        }

        private static Request CreateRequest(HttpClientTransport transport, byte[] bytes = null)
        {
            Request request = transport.CreateRequest();
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("https://example.com:340"));
            request.Content = RequestContent.Create(bytes ?? Array.Empty<byte>());
            return request;
        }

        public class DisposeTrackingHttpContent : HttpContent
        {
            protected override void Dispose(bool disposing)
            {
                IsDisposed = true;
            }

            protected override Task SerializeToStreamAsync(Stream stream, TransportContext context)
            {
                return Task.CompletedTask;
            }

#if NET5_0
            protected override void SerializeToStream(Stream stream, TransportContext context, CancellationToken cancellationToken)
            {
            }
#endif
            protected override bool TryComputeLength(out long length)
            {
                length = 0;
                return false;
            }

            public bool IsDisposed { get; set; }
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
