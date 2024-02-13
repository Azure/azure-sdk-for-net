// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using ClientModel.Tests;
using ClientModel.Tests.Mocks;
using NUnit.Framework;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

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
