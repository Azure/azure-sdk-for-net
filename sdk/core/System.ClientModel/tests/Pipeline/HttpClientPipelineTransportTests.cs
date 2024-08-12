// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ClientModel.Tests;
using ClientModel.Tests.Mocks;
using NUnit.Framework;

namespace System.ClientModel.Tests.Pipeline;

/// <summary>
/// Tests the specific implementation of HttpClientPipelineTransport.
/// </summary>
public class HttpClientPipelineTransportTests : SyncAsyncTestBase
{
    public HttpClientPipelineTransportTests(bool isAsync) : base(isAsync)
    {
    }

    [Test]
    public async Task CanSetRequestUri()
    {
        Uri? requestUri = null;
        var mockHandler = new MockHttpClientHandler(
            httpRequestMessage =>
            {
                requestUri = httpRequestMessage.RequestUri;
            });

        var expectedUri = new Uri("http://example.com:340");
        HttpClientPipelineTransport transport = new(new HttpClient(mockHandler));

        using PipelineMessage message = transport.CreateMessage();
        message.Request.Method = "GET";
        message.Request.Uri = expectedUri;

        await transport.ProcessSyncOrAsync(message, IsAsync);

        Assert.AreEqual(expectedUri, requestUri);
    }

    [Test]
    public async Task ResponseContentNotDisposedWhenStreamIsReplaced()
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

        HttpClientPipelineTransport transport = new(new HttpClient(mockHandler));

        using PipelineMessage message = transport.CreateMessage();
        message.Request.Method = "GET";
        message.Request.Uri = new Uri("https://example.com:340");

        await transport.ProcessSyncOrAsync(message, IsAsync);
        PipelineResponse response = message.Response!;

        response.ContentStream = new MemoryStream();
        response.Dispose();

        Assert.False(disposeTrackingContent.IsDisposed);
    }

    [TestCaseSource(nameof(HeadersWithValuesAndType))]
    public async Task SettingRequestContentHeaderDoesNotSetContent(string headerName, string headerValue, bool contentHeader)
    {
        HttpContent? httpMessageContent = null;

        var mockHandler = new MockHttpClientHandler(
            httpRequestMessage =>
            {
                httpMessageContent = httpRequestMessage.Content!;
            });

        HttpClientPipelineTransport transport = new(new HttpClient(mockHandler));

        using PipelineMessage message = transport.CreateMessage();
        message.Request.Method = "GET";
        message.Request.Uri = new Uri("https://example.com:340");
        message.Request.Headers.Add(headerName, headerValue);

        await transport.ProcessSyncOrAsync(message, IsAsync);

        Assert.Null(httpMessageContent);
    }

    [TestCaseSource(nameof(HeadersWithValuesAndType))]
    public async Task SettingResponseContentStreamPreservesHeaders(string headerName, string headerValue, bool contentHeader)
    {
        var mockHandler = new MockHttpClientHandler(
            httpRequestMessage =>
            {
                HttpResponseMessage responseMessage = new((HttpStatusCode)200);

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

        HttpClientPipelineTransport transport = new(new HttpClient(mockHandler));

        using PipelineMessage message = transport.CreateMessage();
        message.Request.Method = "GET";
        message.Request.Uri = new Uri("https://example.com:340");

        await transport.ProcessSyncOrAsync(message, IsAsync);

        using PipelineResponse response = message.Response!;
        response.ContentStream = new MemoryStream();

        Assert.True(response.Headers.TryGetValue(headerName, out var value));
        Assert.AreEqual(headerValue, value);

        Assert.True(response.Headers.TryGetValues(headerName, out IEnumerable<string>? values));
        CollectionAssert.AreEqual(new[] { headerValue }, values);

        CollectionAssert.Contains(response.Headers, new KeyValuePair<string, string>(headerName, headerValue));
    }

    [Test]
    [TestCase(true)]
    [TestCase(false)]
    public async Task TransportBuffersBasedOnBufferResponse(bool bufferResponse)
    {
        var mockHandler = new MockHttpClientHandler(
            httpRequestMessage =>
            {
                return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent("Mock content")
                });
            });

        HttpClientPipelineTransport transport = new(new HttpClient(mockHandler));

        using PipelineMessage message = transport.CreateMessage();
        message.Request.Method = "GET";
        message.Request.Uri = new Uri("http://example.com");
        message.BufferResponse = bufferResponse;

        await transport.ProcessSyncOrAsync(message, IsAsync);

        if (bufferResponse)
        {
            Assert.AreEqual(message.Response!.Content.ToString(), "Mock content");
        }
        else
        {
            Assert.Throws<InvalidOperationException>(() => { var content = message.Response!.Content; });
        }
    }

    [Test]
    public async Task BufferedResponseContentContainsResponseContent()
    {
        MockHttpClientHandler mockHandler = new(
            httpRequestMessage =>
            {
                return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent("Mock content")
                });
            });

        HttpClientPipelineTransport transport = new(new HttpClient(mockHandler));

        using PipelineMessage message = transport.CreateMessage();
        message.Request.Method = "GET";
        message.Request.Uri = new Uri("http://example.com");

        await transport.ProcessSyncOrAsync(message, IsAsync);

        Assert.AreEqual("Mock content", message.Response!.Content.ToString());
    }

    [Test]
    public async Task BufferedResponseContentEmptyWhenNoResponseContent()
    {
        MockHttpClientHandler mockHandler = new(
            httpRequestMessage =>
                Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)));

        HttpClientPipelineTransport transport = new(new HttpClient(mockHandler));

        using PipelineMessage message = transport.CreateMessage();
        message.Request.Method = "GET";
        message.Request.Uri = new Uri("http://example.com");

        await transport.ProcessSyncOrAsync(message, IsAsync);

        Assert.AreEqual(0, message.Response!.Content.ToMemory().Length);
    }

    [Test]
    public async Task BufferedResponseContentStreamContainsResponseContent()
    {
        MockHttpClientHandler mockHandler = new(
            httpRequestMessage =>
            {
                return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent("Mock content")
                });
            });

        HttpClientPipelineTransport transport = new(new HttpClient(mockHandler));

        using PipelineMessage message = transport.CreateMessage();
        message.Request.Method = "GET";
        message.Request.Uri = new Uri("http://example.com");

        await transport.ProcessSyncOrAsync(message, IsAsync);

        Assert.AreEqual("Mock content", BinaryData.FromStream(message.Response!.ContentStream!).ToString());
    }

    [Test]
    public async Task BufferedResponseContentStreamEmptyWhenNoResponseContent()
    {
        MockHttpClientHandler mockHandler = new(
            httpRequestMessage =>
                Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)));

        HttpClientPipelineTransport transport = new(new HttpClient(mockHandler));

        using PipelineMessage message = transport.CreateMessage();
        message.Request.Method = "GET";
        message.Request.Uri = new Uri("http://example.com");

        await transport.ProcessSyncOrAsync(message, IsAsync);

        Assert.AreEqual(0, message.Response!.ContentStream!.Length);
    }

    [Test]
    public async Task BufferedResponseContentStreamCanBeReadMultipleTimes()
    {
        MockHttpClientHandler mockHandler = new(
            httpRequestMessage =>
            {
                return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent("Mock content")
                });
            });

        HttpClientPipelineTransport transport = new(new HttpClient(mockHandler));

        using PipelineMessage message = transport.CreateMessage();
        message.Request.Method = "GET";
        message.Request.Uri = new Uri("http://example.com");

        await transport.ProcessSyncOrAsync(message, IsAsync);

        Assert.AreEqual("Mock content", BinaryData.FromStream(message.Response!.ContentStream!).ToString());
        Assert.AreEqual("Mock content", BinaryData.FromStream(message.Response!.ContentStream!).ToString());
        Assert.AreEqual("Mock content", BinaryData.FromStream(message.Response!.ContentStream!).ToString());
    }

    [Test]
    public async Task BufferedResponseContentAvailableAfterResponseDisposed()
    {
        MockHttpClientHandler mockHandler = new(
            httpRequestMessage =>
            {
                return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent("Mock content")
                });
            });

        HttpClientPipelineTransport transport = new(new HttpClient(mockHandler));

        using PipelineMessage message = transport.CreateMessage();
        message.Request.Method = "GET";
        message.Request.Uri = new Uri("http://example.com");

        await transport.ProcessSyncOrAsync(message, IsAsync);

        message.Response!.Dispose();

        Assert.AreEqual("Mock content", message.Response!.Content.ToString());
        Assert.AreEqual("Mock content", BinaryData.FromStream(message.Response!.ContentStream!).ToString());
    }

    [Test]
    public async Task UnbufferedResponseContentThrows()
    {
        MockHttpClientHandler mockHandler = new(
            httpRequestMessage =>
            {
                return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent("Mock content")
                });
            });

        HttpClientPipelineTransport transport = new(new HttpClient(mockHandler));

        using PipelineMessage message = transport.CreateMessage();
        message.Request.Method = "GET";
        message.Request.Uri = new Uri("http://example.com");
        message.BufferResponse = false;

        await transport.ProcessSyncOrAsync(message, IsAsync);

        Assert.Throws<InvalidOperationException>(() => { var content = message.Response!.Content; });
    }

    [Test]
    public async Task UnbufferedResponseContentStreamContainsResponseContent()
    {
        MockHttpClientHandler mockHandler = new(
            httpRequestMessage =>
            {
                return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent("Mock content")
                });
            });

        HttpClientPipelineTransport transport = new(new HttpClient(mockHandler));

        using PipelineMessage message = transport.CreateMessage();
        message.Request.Method = "GET";
        message.Request.Uri = new Uri("http://example.com");
        message.BufferResponse = false;

        await transport.ProcessSyncOrAsync(message, IsAsync);

        Assert.AreEqual("Mock content", BinaryData.FromStream(message.Response!.ContentStream!).ToString());

        // The second time it's read the stream's Position is at the end
        Assert.AreEqual(string.Empty, BinaryData.FromStream(message.Response!.ContentStream!).ToString());
    }

    [Test]
    public async Task UnbufferedResponseContentStreamEmptyIfNoResponseContent()
    {
        MockHttpClientHandler mockHandler = new(
            httpRequestMessage =>
                Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)));

        HttpClientPipelineTransport transport = new(new HttpClient(mockHandler));

        using PipelineMessage message = transport.CreateMessage();
        message.Request.Method = "GET";
        message.Request.Uri = new Uri("http://example.com");
        message.BufferResponse = false;

        await transport.ProcessSyncOrAsync(message, IsAsync);

        Assert.AreEqual(string.Empty, BinaryData.FromStream(message.Response!.ContentStream!).ToString());
    }

    [Test]
    public async Task ResponseReadContentReturnsContentIfBuffered()
    {
        MockHttpClientHandler mockHandler = new(
            httpRequestMessage =>
            {
                return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent("Mock content")
                });
            });

        HttpClientPipelineTransport transport = new(new HttpClient(mockHandler));

        using PipelineMessage message = transport.CreateMessage();
        message.Request.Method = "GET";
        message.Request.Uri = new Uri("http://example.com");
        message.BufferResponse = true;

        await transport.ProcessSyncOrAsync(message, IsAsync);

        BinaryData content = await message.Response!.BufferContentSyncOrAsync(default, IsAsync);

        Assert.AreEqual(message.Response!.Content, content);
    }

    [Test]
    public async Task ResponseReadContentReturnsEmptyWhenNoResponseContent()
    {
        MockHttpClientHandler mockHandler = new(
            httpRequestMessage =>
                Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)));

        HttpClientPipelineTransport transport = new(new HttpClient(mockHandler));

        using PipelineMessage message = transport.CreateMessage();
        message.Request.Method = "GET";
        message.Request.Uri = new Uri("http://example.com");

        await transport.ProcessSyncOrAsync(message, IsAsync);

        BinaryData content = await message.Response!.BufferContentSyncOrAsync(default, IsAsync);

        Assert.AreEqual(0, content.ToMemory().Length);
    }

    [Test]
    public async Task ResponseReadContentReturnsEmptyWhenContentStreamNull()
    {
        MockHttpClientHandler mockHandler = new(
            httpRequestMessage =>
                Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)));

        HttpClientPipelineTransport transport = new(new HttpClient(mockHandler));

        using PipelineMessage message = transport.CreateMessage();
        message.Request.Method = "GET";
        message.Request.Uri = new Uri("http://example.com");

        await transport.ProcessSyncOrAsync(message, IsAsync);

        // Explicitly assign ContentStream via property setter
        message.Response!.ContentStream = null;

        BinaryData content = await message.Response!.BufferContentSyncOrAsync(default, IsAsync);

        Assert.AreEqual(0, content.ToMemory().Length);
    }

    [Test]
    public async Task ResponseReadContentThrowsWhenPositionNonZero()
    {
        MockHttpClientHandler mockHandler = new(
            httpRequestMessage =>
            {
                return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent("Mock content")
                });
            });

        HttpClientPipelineTransport transport = new(new HttpClient(mockHandler));

        using PipelineMessage message = transport.CreateMessage();
        message.Request.Method = "GET";
        message.Request.Uri = new Uri("http://example.com");
        message.BufferResponse = false;

        await transport.ProcessSyncOrAsync(message, IsAsync);

        message.Response!.ContentStream!.ReadByte();

        Assert.ThrowsAsync<InvalidOperationException>(async() => { await message.Response!.BufferContentSyncOrAsync(default, IsAsync); });
    }

    [Test]
    public async Task CachedResponseContentReplacedWhenContentStreamReplaced()
    {
        MockHttpClientHandler mockHandler = new(
            httpRequestMessage =>
            {
                return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent("Mock content - 1")
                });
            });

        HttpClientPipelineTransport transport = new(new HttpClient(mockHandler));

        using PipelineMessage message = transport.CreateMessage();
        message.Request.Method = "GET";
        message.Request.Uri = new Uri("http://example.com");

        await transport.ProcessSyncOrAsync(message, IsAsync);

        // Explicitly assign ContentStream via property setter
        message.Response!.ContentStream = new MemoryStream(Encoding.UTF8.GetBytes("Mock content - 2"));

        Assert.AreEqual("Mock content - 2", message.Response!.Content.ToString());
        Assert.AreEqual("Mock content - 2", BinaryData.FromStream(message.Response!.ContentStream!).ToString());
    }

    #region Helpers

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

    public class DisposeTrackingHttpContent : HttpContent
    {
        protected override void Dispose(bool disposing)
        {
            IsDisposed = true;
        }

        protected override Task SerializeToStreamAsync(Stream stream, TransportContext? context)
        {
            return Task.CompletedTask;
        }

#if NET5_0_OR_GREATER
        protected override void SerializeToStream(Stream stream, TransportContext? context, CancellationToken cancellationToken)
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
    #endregion
}
