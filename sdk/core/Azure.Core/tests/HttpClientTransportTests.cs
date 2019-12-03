// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class HttpClientTransportTests : PipelineTestBase
    {
        public static object[] ContentWithLength =>
            new object[]
            {
                new object[] { RequestContent.Create(new byte[10]), 10 },
                new object[] { RequestContent.Create(new byte[10], 5, 5), 5 },
                new object[] { RequestContent.Create(new ReadOnlyMemory<byte>(new byte[10])), 10 },
                new object[] { RequestContent.Create(new ReadOnlyMemory<byte>(new byte[10]).Slice(5)), 5 },
                new object[] { RequestContent.Create(new ReadOnlySequence<byte>(new byte[10])), 10 },
            };

        [TestCaseSource(nameof(ContentWithLength))]
        public async Task ContentLengthIsSetForArrayContent(RequestContent content, int expectedLength)
        {
            long contentLength = 0;
            var mockHandler = new MockHttpClientHandler(
                httpRequestMessage => contentLength = httpRequestMessage.Content.Headers.ContentLength.Value
                );

            var transport = new HttpClientTransport(new HttpClient(mockHandler));
            Request request = transport.CreateRequest();
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("https://example.com"));
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
            Request request = transport.CreateRequest();
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("https://example.com"));
            request.Content = RequestContent.Create(new byte[10]);
            request.Headers.Add("Content-Length", "50");

            await ExecuteRequest(request, transport);

            Assert.AreEqual(50, contentLength);
        }

        [Test]
        public async Task HostHeaderSetFromUri()
        {
            string host = null;
            Uri uri = null;
            var mockHandler = new MockHttpClientHandler(
                httpRequestMessage =>
                {
                    uri = httpRequestMessage.RequestUri;
                    host = httpRequestMessage.Headers.Host;
                });

            var transport = new HttpClientTransport(new HttpClient(mockHandler));
            Request request = transport.CreateRequest();
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("http://example.com:340"));

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
                httpRequestMessage =>
                {
                    host = httpRequestMessage.Headers.Host;
                });

            var transport = new HttpClientTransport(new HttpClient(mockHandler));
            Request request = transport.CreateRequest();
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("https://example.com:340"));
            request.Headers.Add("Host", "example.org");

            await ExecuteRequest(request, transport);

            Assert.AreEqual("example.org", host);
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

            var transport = new HttpClientTransport(new HttpClient(mockHandler));
            Request request = transport.CreateRequest();
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("https://example.com:340"));

            Response response = await ExecuteRequest(request, transport);

            response.ContentStream = new MemoryStream();
            response.Dispose();

            Assert.False(disposeTrackingContent.IsDisposed);
        }

        public static object[][] Methods => new[]
        {
            new object[] { RequestMethod.Delete, "DELETE" },
            new object[] { RequestMethod.Get, "GET" },
            new object[] { RequestMethod.Patch, "PATCH" },
            new object[] { RequestMethod.Post, "POST" },
            new object[] { RequestMethod.Put, "PUT" },
            new object[] { RequestMethod.Head, "HEAD" },
            new object[] { new RequestMethod("custom"), "CUSTOM" },
        };

        [Theory]
        [TestCaseSource(nameof(Methods))]
        public async Task CanGetAndSetMethod(RequestMethod method, string expectedMethod)
        {
            HttpMethod httpMethod = null;
            var mockHandler = new MockHttpClientHandler(
                httpRequestMessage =>
                {
                    httpMethod = httpRequestMessage.Method;
                });

            var transport = new HttpClientTransport(new HttpClient(mockHandler));
            Request request = transport.CreateRequest();
            request.Method = method;
            request.Uri.Reset(new Uri("https://example.com:340"));

            Assert.AreEqual(method, request.Method);

            await ExecuteRequest(request, transport);

            Assert.AreEqual(expectedMethod, httpMethod.Method);
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
            var transport = new HttpClientTransport(new HttpClient(mockHandler));
            Request request = transport.CreateRequest();
            request.Method = RequestMethod.Get;
            request.Uri.Reset(expectedUri);

            Assert.AreEqual(expectedUri.ToString(), request.Uri.ToString());

            await ExecuteRequest(request, transport);

            Assert.AreEqual(expectedUri, requestUri);
        }

        [Test]
        public async Task CanGetAndSetContent()
        {
            byte[] requestBytes = null;
            var mockHandler = new MockHttpClientHandler(
                async httpRequestMessage =>
                {
                    requestBytes = await httpRequestMessage.Content.ReadAsByteArrayAsync();
                });

            var bytes = Encoding.ASCII.GetBytes("Hello world");
            var content = RequestContent.Create(bytes);
            var transport = new HttpClientTransport(new HttpClient(mockHandler));
            Request request = transport.CreateRequest();
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("https://example.com:340"));
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
        public async Task CanGetAndAddRequestHeaders(string headerName, string headerValue, bool contentHeader)
        {
            IEnumerable<string> httpHeaderValues = null;

            var mockHandler = new MockHttpClientHandler(
                httpRequestMessage =>
                {
                    Assert.True(
                        httpRequestMessage.Headers.TryGetValues(headerName, out httpHeaderValues) ||
                        httpRequestMessage.Content.Headers.TryGetValues(headerName, out httpHeaderValues));
                });

            var transport = new HttpClientTransport(new HttpClient(mockHandler));
            Request request = CreateRequest(transport);

            request.Headers.Add(headerName, headerValue);

            Assert.True(request.Headers.TryGetValue(headerName, out var value));
            Assert.AreEqual(headerValue, value);

            Assert.True(request.Headers.TryGetValue(headerName.ToUpper(), out value));
            Assert.AreEqual(headerValue, value);

            CollectionAssert.AreEqual(new[]
            {
                new HttpHeader(headerName, headerValue),
            }, request.Headers);

            await ExecuteRequest(request, transport);

            Assert.AreEqual(headerValue, string.Join(",", httpHeaderValues));
        }

        [TestCaseSource(nameof(HeadersWithValuesAndType))]
        public async Task CanSetRequestHeaders(string headerName, string headerValue, bool contentHeader)
        {
            IEnumerable<string> httpHeaderValues = null;

            var mockHandler = new MockHttpClientHandler(
                httpRequestMessage =>
                {
                    Assert.True(
                        httpRequestMessage.Headers.TryGetValues(headerName, out httpHeaderValues) ||
                        httpRequestMessage.Content.Headers.TryGetValues(headerName, out httpHeaderValues));
                });

            var transport = new HttpClientTransport(new HttpClient(mockHandler));
            Request request = CreateRequest(transport);

            request.Headers.Add(headerName, "Random value");
            request.Headers.SetValue(headerName, headerValue);

            Assert.True(request.Headers.TryGetValue(headerName, out var value));
            Assert.AreEqual(headerValue, value);

            Assert.True(request.Headers.TryGetValue(headerName.ToUpper(), out value));
            Assert.AreEqual(headerValue, value);

            CollectionAssert.AreEqual(new[]
            {
                new HttpHeader(headerName, headerValue),
            }, request.Headers);

            await ExecuteRequest(request, transport);

            Assert.AreEqual(headerValue, string.Join(",", httpHeaderValues));
        }

        [TestCaseSource(nameof(HeadersWithValuesAndType))]
        public async Task CanRemoveHeaders(string headerName, string headerValue, bool contentHeader)
        {
            var mockHandler = new MockHttpClientHandler(
                httpRequestMessage =>
                {
                    Assert.False(
                        httpRequestMessage.Headers.TryGetValues(headerName, out _) &&
                        httpRequestMessage.Content.Headers.TryGetValues(headerName, out _));
                });

            var transport = new HttpClientTransport(new HttpClient(mockHandler));
            Request request = CreateRequest(transport);

            request.Headers.Add(headerName, headerValue);
            Assert.True(request.Headers.Remove(headerName));
            Assert.False(request.Headers.Remove(headerName));

            Assert.False(request.Headers.TryGetValue(headerName, out _));
            Assert.False(request.Headers.TryGetValue(headerName.ToUpper(), out _));
            Assert.False(request.Headers.Contains(headerName.ToUpper()));

            await ExecuteRequest(request, transport);
        }

        [TestCaseSource(nameof(HeadersWithValuesAndType))]
        public async Task CanGetAndSetResponseHeaders(string headerName, string headerValue, bool contentHeader)
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

            var transport = new HttpClientTransport(new HttpClient(mockHandler));
            Request request = transport.CreateRequest();
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("https://example.com:340"));

            Response response = await ExecuteRequest(request, transport);

            Assert.True(response.Headers.TryGetValue(headerName, out var value));
            Assert.AreEqual(headerValue, value);

            Assert.True(response.Headers.TryGetValue(headerName.ToUpper(), out value));
            Assert.AreEqual(headerValue, value);

            CollectionAssert.Contains(response.Headers, new HttpHeader(headerName, headerValue));
        }

        [TestCaseSource(nameof(HeadersWithValuesAndType))]
        public void TryGetReturnsCorrectValuesWhenNotFound(string headerName, string headerValue, bool contentHeader)
        {
            var transport = new HttpClientTransport();
            Request request = CreateRequest(transport);

            Assert.False(request.Headers.TryGetValue(headerName, out string value));
            Assert.IsNull(value);

            Assert.False(request.Headers.TryGetValues(headerName, out IEnumerable<string> values));
            Assert.IsNull(values);
        }

        [TestCaseSource(nameof(HeadersWithValuesAndType))]
        public async Task SettingContentHeaderDoesNotSetContent(string headerName, string headerValue, bool contentHeader)
        {
            HttpContent httpMessageContent = null;
            var mockHandler = new MockHttpClientHandler(httpRequestMessage => { httpMessageContent = httpRequestMessage.Content; });

            var transport = new HttpClientTransport(new HttpClient(mockHandler));
            Request request = transport.CreateRequest();
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("https://example.com:340"));
            request.Headers.Add(headerName, headerValue);

            await ExecuteRequest(request, transport);

            Assert.Null(httpMessageContent);
        }

        [TestCaseSource(nameof(HeadersWithValuesAndType))]
        public async Task CanAddMultipleValuesToRequestHeader(string headerName, string headerValue, bool contentHeader)
        {
            var anotherHeaderValue = headerValue + "1";
            var joinedHeaderValues = headerValue + "," + anotherHeaderValue;

            IEnumerable<string> httpHeaderValues = null;

            var mockHandler = new MockHttpClientHandler(
                httpRequestMessage =>
                {
                    Assert.True(
                        httpRequestMessage.Headers.TryGetValues(headerName, out httpHeaderValues) ||
                        httpRequestMessage.Content.Headers.TryGetValues(headerName, out httpHeaderValues));
                });

            var transport = new HttpClientTransport(new HttpClient(mockHandler));
            Request request = CreateRequest(transport);

            request.Headers.Add(headerName, headerValue);
            request.Headers.Add(headerName, anotherHeaderValue);

            Assert.True(request.Headers.Contains(headerName));

            Assert.True(request.Headers.TryGetValue(headerName, out var value));
            Assert.AreEqual(joinedHeaderValues, value);

            Assert.True(request.Headers.TryGetValues(headerName, out IEnumerable<string> values));
            CollectionAssert.AreEqual(new[] { headerValue, anotherHeaderValue }, values);

            CollectionAssert.AreEqual(new[]
            {
                new HttpHeader(headerName, joinedHeaderValues),
            }, request.Headers);

            await ExecuteRequest(request, transport);

            CollectionAssert.AreEqual(new[] { headerValue, anotherHeaderValue }, httpHeaderValues);
        }

        [TestCaseSource(nameof(HeadersWithValuesAndType))]
        public async Task CanGetAndSetMultiValueResponseHeaders(string headerName, string headerValue, bool contentHeader)
        {
            var anotherHeaderValue = headerValue + "1";
            var joinedHeaderValues = headerValue + "," + anotherHeaderValue;

            var mockHandler = new MockHttpClientHandler(
                httpRequestMessage =>
                {
                    var responseMessage = new HttpResponseMessage((HttpStatusCode)200);

                    if (contentHeader)
                    {
                        responseMessage.Content = new StreamContent(new MemoryStream());
                        Assert.True(responseMessage.Content.Headers.TryAddWithoutValidation(headerName, headerValue));
                        Assert.True(responseMessage.Content.Headers.TryAddWithoutValidation(headerName, anotherHeaderValue));
                    }
                    else
                    {
                        Assert.True(responseMessage.Headers.TryAddWithoutValidation(headerName, headerValue));
                        Assert.True(responseMessage.Headers.TryAddWithoutValidation(headerName, anotherHeaderValue));
                    }

                    return Task.FromResult(responseMessage);
                });

            var transport = new HttpClientTransport(new HttpClient(mockHandler));
            Request request = transport.CreateRequest();
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("https://example.com:340"));

            Response response = await ExecuteRequest(request, transport);

            Assert.True(response.Headers.Contains(headerName));

            Assert.True(response.Headers.TryGetValue(headerName, out var value));
            Assert.AreEqual(joinedHeaderValues, value);

            Assert.True(response.Headers.TryGetValues(headerName, out IEnumerable<string> values));
            CollectionAssert.AreEqual(new[] { headerValue, anotherHeaderValue }, values);

            CollectionAssert.Contains(response.Headers, new HttpHeader(headerName, joinedHeaderValues));
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

            var transport = new HttpClientTransport(new HttpClient(mockHandler));
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

        [Test]
        public async Task RequestAndResponseHasRequestId()
        {
            var mockHandler = new MockHttpClientHandler(httpRequestMessage => { });

            var transport = new HttpClientTransport(new HttpClient(mockHandler));
            Request request = transport.CreateRequest();
            Assert.IsNotEmpty(request.ClientRequestId);
            Assert.True(Guid.TryParse(request.ClientRequestId, out _));
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("https://example.com:340"));

            Response response = await ExecuteRequest(request, transport);
            Assert.AreEqual(request.ClientRequestId, response.ClientRequestId);
        }

        [Test]
        public async Task RequestIdCanBeOverriden()
        {
            var mockHandler = new MockHttpClientHandler(httpRequestMessage => { });

            var transport = new HttpClientTransport(new HttpClient(mockHandler));
            Request request = transport.CreateRequest();

            request.ClientRequestId = "123";
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("https://example.com:340"));

            Response response = await ExecuteRequest(request, transport);
            Assert.AreEqual(request.ClientRequestId, response.ClientRequestId);
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
            Request request = transport.CreateRequest();
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("https://example.com:340"));

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
            Request request = transport.CreateRequest();
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("https://example.com:340"));

            Response response = await ExecuteRequest(request, transport);

            content.CreateContentReadStreamAsyncCompletionSource.SetResult(null);
            Stream stream = response.ContentStream;

            Assert.AreSame(content.MemoryStream, stream);
        }

        [Test]
        public async Task ReasonPhraseIsExposed()
        {
            var httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK)
            {
                ReasonPhrase = "Custom ReasonPhrase"
            };
            var mockHandler = new MockHttpClientHandler(httpRequestMessage => Task.FromResult(httpResponseMessage));

            var transport = new HttpClientTransport(new HttpClient(mockHandler));
            Request request = transport.CreateRequest();
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("https://example.com:340"));

            Response response = await ExecuteRequest(request, transport);

            Assert.AreEqual("Custom ReasonPhrase", response.ReasonPhrase);
        }

        [Test]
        public async Task StreamRequestContentCanBeSentMultipleTimes()
        {
            var requests = new List<HttpRequestMessage>();
            var httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK);

            var mockHandler = new MockHttpClientHandler(httpRequestMessage =>
            {
                requests.Add(httpRequestMessage);
                return Task.FromResult(httpResponseMessage);
            });

            var transport = new HttpClientTransport(new HttpClient(mockHandler));
            Request request = transport.CreateRequest();
            request.Content = RequestContent.Create(new MemoryStream(new byte[] { 1, 2, 3 }));
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("https://example.com:340"));

            await ExecuteRequest(request, transport);
            await ExecuteRequest(request, transport);

            Assert.AreEqual(2, requests.Count);
        }

        [Test]
        public async Task RequestContentIsNotDisposedOnSend()
        {
            var requests = new List<HttpRequestMessage>();
            var httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK);

            var mockHandler = new MockHttpClientHandler(httpRequestMessage =>
            {
                requests.Add(httpRequestMessage);
                return Task.FromResult(httpResponseMessage);
            });

            DisposeTrackingContent disposeTrackingContent = new DisposeTrackingContent();
            var transport = new HttpClientTransport(new HttpClient(mockHandler));

            using (Request request = transport.CreateRequest())
            {
                request.Content = disposeTrackingContent;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri("https://example.com:340"));

                await ExecuteRequest(request, transport);
                Assert.False(disposeTrackingContent.IsDisposed);
            }

            Assert.True(disposeTrackingContent.IsDisposed);
        }

        public class DisposeTrackingContent : RequestContent
        {
            public override Task WriteToAsync(Stream stream, CancellationToken cancellation)
            {
                return Task.CompletedTask;
            }

            public override void WriteTo(Stream stream, CancellationToken cancellation)
            {
            }

            public override bool TryComputeLength(out long length)
            {
                length = 0;
                return false;
            }

            public override void Dispose()
            {
                IsDisposed = true;
            }

            public bool IsDisposed { get; set; }
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
