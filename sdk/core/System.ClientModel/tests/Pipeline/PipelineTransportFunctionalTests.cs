// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using ClientModel.Tests;
using ClientModel.Tests.Mocks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Primitives;
using NUnit.Framework;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SyncAsyncTestBase = ClientModel.Tests.SyncAsyncTestBase;

namespace System.ClientModel.Tests.Pipeline;

/// <summary>
/// Tests all transports implementations provide the same functionality.
/// </summary>
public class PipelineTransportFunctionalTests : SyncAsyncTestBase
{
    public PipelineTransportFunctionalTests(bool isAsync) : base(isAsync)
    {
    }

    #region Transport Request tests

    [Test]
    public void GetIsDefaultRequestMethod()
    {
        HttpClientPipelineTransport transport = new();

        using PipelineMessage message = transport.CreateMessage();

        Assert.AreEqual("GET", message.Request.Method);
    }

    [Theory]
    [TestCaseSource(nameof(RequestMethods))]
    public async Task CanSetRequestMethod(string method, bool hasContent = false)
    {
        string httpMethod = string.Empty;
        using TestServer testServer = new TestServer(
            context =>
            {
                httpMethod = context.Request.Method.ToString();
            });

        HttpClientPipelineTransport transport = new();

        using PipelineMessage message = transport.CreateMessage();
        message.Request.Uri = testServer.Address;
        message.Request.Method = method;

        if (hasContent)
        {
            message.Request.Content = BinaryContent.Create(BinaryData.FromString(string.Empty));
        }

        await transport.ProcessSyncOrAsync(message, IsAsync);

        Assert.AreEqual(method, httpMethod);
    }

    [Test]
    public async Task CanSetRequestContent()
    {
        byte[] requestBytes = null!;
        using TestServer testServer = new TestServer(
            context =>
            {
                using var memoryStream = new MemoryStream();
                context.Request.Body.CopyTo(memoryStream);
                requestBytes = memoryStream.ToArray();
            });

        var bytes = Encoding.ASCII.GetBytes("Hello world");
        var content = BinaryContent.Create(BinaryData.FromBytes(bytes));

        HttpClientPipelineTransport transport = new();

        using PipelineMessage message = transport.CreateMessage();
        message.Request.Uri = testServer.Address;
        message.Request.Method = "POST";
        message.Request.Content = content;

        await transport.ProcessSyncOrAsync(message, IsAsync);

        CollectionAssert.AreEqual(bytes, requestBytes);
    }

    [Test]
    [TestCaseSource(nameof(RequestMethods))]
    public async Task CanSetRequestHeaderContentLengthWhenNoContent(string method, bool hasContent)
    {
        HttpClientPipelineTransport transport = new();

        long? contentLength = null;
        using TestServer testServer = new TestServer(
            context =>
            {
                contentLength = context.Request.ContentLength;
            });

        using PipelineMessage message = transport.CreateMessage();
        message.Request.Uri = testServer.Address;
        message.Request.Method = method;
        message.Request.Content = null;

        await transport.ProcessSyncOrAsync(message, IsAsync);

        // for NET462, HttpClient will include zero content-length for DELETEs
#if NET462
        if (method == "DELETE")
        {
            Assert.AreEqual(0, contentLength);

            return;
        }
#endif

        if (method == "DELETE" ||
            method == "GET" ||
            method == "HEAD")
        {
            Assert.Null(contentLength);
        }
        else
        {
            Assert.AreEqual(0, contentLength);
        }
    }

    [Test]
    [TestCaseSource(nameof(RequestMethods))]
    public async Task RequestHeaderContentTypeIsNullWhenNoContent(string method, bool hasContent)
    {
        HttpClientPipelineTransport transport = new();

        string? contentType = null;
        using TestServer testServer = new TestServer(
            context =>
            {
                contentType = context.Request.ContentType;
            });

        using PipelineMessage message = transport.CreateMessage();
        message.Request.Uri = testServer.Address;
        message.Request.Method = method;
        message.Request.Content = null;
        message.Request.Headers.Add("Content-Type", "application/json");

        await transport.ProcessSyncOrAsync(message, IsAsync);

        Assert.Null(contentType);
    }

    [Test]
    public async Task SettingRequestHeaderContentLengthOverridesDefault()
    {
        long contentLength = 0;
        using TestServer testServer = new TestServer(
            context => contentLength = context.Request.ContentLength!.Value);

        HttpClientPipelineTransport transport = new();

        using PipelineMessage message = transport.CreateMessage();
        message.Request.Uri = testServer.Address;
        message.Request.Method = "POST";
        message.Request.Content = null;

        message.Request.Content = new InvalidSizeContent();
        message.Request.Headers.Add("Content-Length", "50");

        await transport.ProcessSyncOrAsync(message, IsAsync);

        Assert.True(message.Request.Content.TryComputeLength(out var cl));
        Assert.AreEqual(10, cl);
        Assert.AreEqual(50, contentLength);
    }

    [Test]
    public async Task CanSetRequestHeaderContentLengthOverMaxInt()
    {
        long contentLength = 0;
        using TestServer testServer = new TestServer(
            context =>
            {
                contentLength = context.Request.ContentLength!.Value;
                context.Abort();
            });

        HttpClientPipelineTransport transport = new();

        using PipelineMessage message = transport.CreateMessage();
        message.Request.Uri = testServer.Address;
        message.Request.Method = "POST";
        message.Request.Content = null;

        message.Request.Content = new InvalidSizeContent();
        message.Request.Headers.Add("Content-Length", long.MaxValue.ToString());

        try
        {
            await transport.ProcessSyncOrAsync(message, IsAsync);
        }
        catch (Exception)
        {
            // Sending the request fails because of length mismatch
        }

        Assert.AreEqual(long.MaxValue, contentLength);
        Assert.Greater(contentLength, int.MaxValue);
    }

    [Test]
    public async Task RequestHeaderHostIsSetFromUri()
    {
        HostString? host = null;
        string uri = string.Empty;
        using TestServer testServer = new TestServer(
            context =>
            {
                uri = context.Request.GetDisplayUrl();
                host = context.Request.GetTypedHeaders().Host;
            });

        HttpClientPipelineTransport transport = new();

        using PipelineMessage message = transport.CreateMessage();
        message.Request.Uri = testServer.Address;
        message.Request.Method = "GET";

        await transport.ProcessSyncOrAsync(message, IsAsync);

        Assert.AreEqual(testServer.Address.ToString(), uri);
        Assert.AreEqual(testServer.Address.Host + ":" + testServer.Address.Port, host.ToString());
    }

    [Test]
    public async Task SettingRequestHeaderHostOverridesDefault()
    {
        HostString? host = null;
        string uri = string.Empty;
        using TestServer testServer = new TestServer(
            context =>
            {
                uri = context.Request.GetDisplayUrl();
                host = context.Request.GetTypedHeaders().Host;
            });

        HttpClientPipelineTransport transport = new();

        using PipelineMessage message = transport.CreateMessage();
        message.Request.Uri = testServer.Address;
        message.Request.Method = "GET";

        message.Request.Headers.Add("Host", "example.org");

        await transport.ProcessSyncOrAsync(message, IsAsync);

        Assert.AreEqual("http://example.org/", uri);
        Assert.AreEqual("example.org", host.ToString());
    }

    [Test]
    public async Task RequestContentIsNotDisposedOnSend()
    {
        using TestServer testServer = new TestServer(context => { });

        DisposeTrackingContent disposeTrackingContent = new DisposeTrackingContent();

        HttpClientPipelineTransport transport = new();

        using (PipelineMessage message = transport.CreateMessage())
        {
            message.Request.Content = disposeTrackingContent;
            message.Request.Method = "POST";
            message.Request.Uri = testServer.Address;

            await transport.ProcessSyncOrAsync(message, IsAsync);

            Assert.False(disposeTrackingContent.IsDisposed);
        }

        Assert.True(disposeTrackingContent.IsDisposed);
    }

    [TestCaseSource(nameof(HeadersWithValues))]
    public async Task CanAddRequestHeaders(string headerName, string headerValue, bool contentHeader, bool supportsMultiple)
    {
        StringValues httpHeaderValues = default;

        using TestServer testServer = new TestServer(
            context =>
            {
                Assert.True(context.Request.Headers.TryGetValue(headerName, out httpHeaderValues));
            });

        HttpClientPipelineTransport transport = new();

        using PipelineMessage message = transport.CreateMessage();
        message.Request.Uri = testServer.Address;
        message.Request.Method = "POST";
        message.Request.Headers.Add(headerName, headerValue);

        if (contentHeader)
        {
            message.Request.Content = BinaryContent.Create(BinaryData.FromBytes(new byte[16]));
        }

        Assert.True(message.Request.Headers.TryGetValue(headerName, out var value));
        Assert.AreEqual(headerValue, value);

        Assert.True(message.Request.Headers.TryGetValue(headerName.ToUpper(), out value));
        Assert.AreEqual(headerValue, value);

        CollectionAssert.AreEqual(
            new[] { new KeyValuePair<string, string>(headerName, headerValue) },
            message.Request.Headers);

        await transport.ProcessSyncOrAsync(message, IsAsync);

        Assert.AreEqual(headerValue, string.Join(",", httpHeaderValues));
    }

    [TestCaseSource(nameof(HeadersWithValues))]
    public async Task CanAddRequestHeadersUppercase(string headerName, string headerValue, bool contentHeader, bool supportsMultiple)
        => await CanAddRequestHeaders(headerName.ToUpperInvariant(), headerValue, contentHeader, supportsMultiple);

    [TestCaseSource(nameof(HeadersWithValues))]
    public void RequestHeaderTryGetReturnsFalseWhenNotFound(string headerName, string headerValue, bool contentHeader, bool supportsMultiple)
    {
        HttpClientPipelineTransport transport = new();

        using PipelineMessage message = transport.CreateMessage();

        Assert.False(message.Request.Headers.TryGetValue(headerName, out string? value));
        Assert.IsNull(value);

        Assert.False(message.Request.Headers.TryGetValues(headerName, out IEnumerable<string>? values));
        Assert.IsNull(values);
    }

    [TestCaseSource(nameof(HeadersWithValues))]
    public async Task CanAddMultipleValuesToRequestHeader(string headerName, string headerValue, bool contentHeader, bool supportsMultiple)
    {
        if (!supportsMultiple) return;

        var anotherHeaderValue = headerValue + "1";
        var joinedHeaderValues = headerValue + "," + anotherHeaderValue;

        StringValues httpHeaderValues = default;

        using TestServer testServer = new TestServer(
            context =>
            {
                Assert.True(context.Request.Headers.TryGetValue(headerName, out httpHeaderValues));
            });

        HttpClientPipelineTransport transport = new();

        using PipelineMessage message = transport.CreateMessage();
        message.Request.Uri = testServer.Address;
        message.Request.Method = "POST";
        message.Request.Headers.Add(headerName, headerValue);
        message.Request.Headers.Add(headerName, anotherHeaderValue);
        message.Request.Content = BinaryContent.Create(BinaryData.FromBytes(Array.Empty<byte>()));

        Assert.True(message.Request.Headers.TryGetValue(headerName, out var value));
        Assert.AreEqual(joinedHeaderValues, value);

        Assert.True(message.Request.Headers.TryGetValues(headerName, out IEnumerable<string>? values));
        CollectionAssert.AreEqual(new[] { headerValue, anotherHeaderValue }, values);

        CollectionAssert.AreEqual(
            new[] { new KeyValuePair<string, string>(headerName, joinedHeaderValues), },
            message.Request.Headers);

        await transport.ProcessSyncOrAsync(message, IsAsync);

        StringAssert.Contains(headerValue, httpHeaderValues.ToString());
        StringAssert.Contains(anotherHeaderValue, httpHeaderValues.ToString());
    }

    [TestCaseSource(nameof(HeadersWithValues))]
    public async Task CanRemoveRequestHeaders(string headerName, string headerValue, bool contentHeader, bool supportsMultiple)
    {
        // Some headers are required
        bool checkOnServer = headerName != "Content-Length" && headerName != "Host";

        using TestServer testServer = new TestServer(
            context =>
            {
                if (checkOnServer)
                {
                    Assert.False(context.Request.Headers.TryGetValue(headerName, out _));
                }
            });

        HttpClientPipelineTransport transport = new();

        using PipelineMessage message = transport.CreateMessage();
        message.Request.Uri = testServer.Address;
        message.Request.Method = "POST";
        message.Request.Content = BinaryContent.Create(BinaryData.FromBytes(Array.Empty<byte>()));

        message.Request.Headers.Add(headerName, headerValue);
        Assert.True(message.Request.Headers.Remove(headerName));
        Assert.False(message.Request.Headers.Remove(headerName));

        Assert.False(message.Request.Headers.TryGetValue(headerName, out _));
        Assert.False(message.Request.Headers.TryGetValue(headerName.ToUpper(), out _));

        await transport.ProcessSyncOrAsync(message, IsAsync);
    }

    [TestCaseSource(nameof(HeadersWithValues))]
    public async Task CanSetRequestHeaders(string headerName, string headerValue, bool contentHeader, bool supportsMultiple)
    {
        StringValues httpHeaderValues = default;

        using TestServer testServer = new TestServer(
            context =>
            {
                Assert.True(context.Request.Headers.TryGetValue(headerName, out httpHeaderValues));
            });

        HttpClientPipelineTransport transport = new();

        using PipelineMessage message = transport.CreateMessage();
        message.Request.Uri = testServer.Address;
        message.Request.Method = "POST";
        message.Request.Content = BinaryContent.Create(BinaryData.FromBytes(Array.Empty<byte>()));

        message.Request.Headers.Add(headerName, "Random value");
        message.Request.Headers.Set(headerName, headerValue);

        if (contentHeader)
        {
            message.Request.Content = BinaryContent.Create(BinaryData.FromBytes(new byte[16]));
        }

        Assert.True(message.Request.Headers.TryGetValue(headerName, out var value));
        Assert.AreEqual(headerValue, value);

        Assert.True(message.Request.Headers.TryGetValue(headerName.ToUpper(), out value));
        Assert.AreEqual(headerValue, value);

        CollectionAssert.AreEqual(new[]{new KeyValuePair<string, string>(headerName, headerValue),},
            message.Request.Headers);

        await transport.ProcessSyncOrAsync(message, IsAsync);

        Assert.AreEqual(headerValue, string.Join(",", httpHeaderValues));
    }

    #endregion

    #region Transport Response tests
    [Theory]
    [TestCase(200)]
    [TestCase(300)]
    [TestCase(400)]
    [TestCase(500)]
    public async Task CanGetResponseStatus(int code)
    {
        using TestServer testServer = new TestServer(
            context =>
            {
                context.Response.StatusCode = code;
            });

        HttpClientPipelineTransport transport = new();
        using PipelineMessage message = transport.CreateMessage();
        message.Request.Uri = testServer.Address;

        await transport.ProcessSyncOrAsync(message, IsAsync);

        Assert.AreEqual(code, message.Response!.Status);
    }

    [Test]
    public async Task CanGetResponseReasonPhrase()
    {
        using TestServer testServer = new TestServer(context =>
        {
            context.Response
                .HttpContext
                .Features
                .Get<IHttpResponseFeature>()
                .ReasonPhrase = "Custom ReasonPhrase";
        });

        HttpClientPipelineTransport transport = new();
        using PipelineMessage message = transport.CreateMessage();
        message.Request.Method = "GET";
        message.Request.Uri = testServer.Address;

        await transport.ProcessSyncOrAsync(message, IsAsync);

        Assert.AreEqual("Custom ReasonPhrase", message.Response!.ReasonPhrase);
    }

    [TestCaseSource(nameof(HeadersWithValues))]
    public async Task CanGetResponseHeaders(string headerName, string headerValue, bool contentHeader, bool supportsMultiple)
    {
        using TestServer testServer = new TestServer(
            context =>
            {
                context.Response.Headers.Add(headerName, headerValue);
                context.Response.WriteAsync("1234567890123456");
            });

        HttpClientPipelineTransport transport = new();

        using PipelineMessage message = transport.CreateMessage();
        message.Request.Uri = testServer.Address;
        message.Request.Method = "POST";
        message.Request.Content = BinaryContent.Create(BinaryData.FromBytes(Array.Empty<byte>()));

        await transport.ProcessSyncOrAsync(message, IsAsync);

        using PipelineResponse response = message.Response!;

        Assert.True(
            response.Headers.TryGetValue(headerName, out _),
            $"response.Headers contains the following headers: {string.Join(", ", response.Headers.Select(h => $"\"{h.Key}\": \"{h.Value}\""))}");

        Assert.True(response.Headers.TryGetValue(headerName, out var value));
        Assert.AreEqual(headerValue, value);

        Assert.True(response.Headers.TryGetValues(headerName, out IEnumerable<string>? values));
        CollectionAssert.AreEqual(new[] { headerValue }, values);

        CollectionAssert.Contains(response.Headers, new KeyValuePair<string, string>(headerName, headerValue));
    }

    [TestCaseSource(nameof(HeadersWithValues))]
    public async Task CanSetMultiValueResponseHeaders(string headerName, string headerValue, bool contentHeader, bool supportsMultiple)
    {
        if (!supportsMultiple) return;

        var anotherHeaderValue = headerValue + "1";
        var joinedHeaderValues = headerValue + "," + anotherHeaderValue;

        using TestServer testServer = new TestServer(
            context =>
            {
                context.Response.Headers.Add(headerName,
                    new StringValues(new[]
                    {
                            headerValue,
                            anotherHeaderValue
                    }));
            });

        HttpClientPipelineTransport transport = new();

        using PipelineMessage message = transport.CreateMessage();
        message.Request.Uri = testServer.Address;
        message.Request.Method = "POST";
        message.Request.Content = BinaryContent.Create(BinaryData.FromBytes(Array.Empty<byte>()));

        await transport.ProcessSyncOrAsync(message, IsAsync);

        using PipelineResponse response = message.Response!;

        Assert.True(response.Headers.TryGetValue(headerName, out var value));
        Assert.AreEqual(joinedHeaderValues, value);

        Assert.True(response.Headers.TryGetValues(headerName, out IEnumerable<string>? values));
        CollectionAssert.AreEqual(new[] { headerValue, anotherHeaderValue }, values);

        CollectionAssert.Contains(response.Headers, new KeyValuePair<string, string>(headerName, joinedHeaderValues));
    }

    [Test]
    public async Task ResponseHeadersAreSplit()
    {
        using TestServer testServer = new TestServer(
            async context =>
            {
                context.Response.Headers.Add("Sync-Token", new[] { "A", "B" });
                byte[] buffer = Encoding.UTF8.GetBytes("Hello");
                await context.Response.Body.WriteAsync(buffer, 0, buffer.Length);
            });

        HttpClientPipelineTransport transport = new();

        using PipelineMessage message = transport.CreateMessage();
        message.Request.Uri = testServer.Address;

        await transport.ProcessSyncOrAsync(message, IsAsync);

        using PipelineResponse response = message.Response!;

        Assert.True(response.Headers.TryGetValues("Sync-Token", out IEnumerable<string>? tokens));
        Assert.AreEqual(2, tokens!.Count());
        CollectionAssert.AreEqual(new[] { "A", "B" }, tokens);
    }

    [Test]
    public async Task ResponseHeadersAreNotSplit()
    {
        using TestServer testServer = new TestServer(
            async context =>
            {
                context.Response.Headers.Add("Sync-Token", "A,B");
                byte[] buffer = Encoding.UTF8.GetBytes("Hello");
                await context.Response.Body.WriteAsync(buffer, 0, buffer.Length);
            });

        HttpClientPipelineTransport transport = new();

        using PipelineMessage message = transport.CreateMessage();
        message.Request.Uri = testServer.Address;

        await transport.ProcessSyncOrAsync(message, IsAsync);

        using PipelineResponse response = message.Response!;

        Assert.True(response.Headers.TryGetValues("Sync-Token", out IEnumerable<string>? tokens));
        Assert.AreEqual(1, tokens!.Count());
        CollectionAssert.AreEqual(new[] { "A,B" }, tokens);
    }

    #endregion

    [Test]
    public void TransportExceptionsAreWrapped()
    {
        using TestServer testServer = new TestServer(
            context =>
            {
                context.Abort();
                return Task.CompletedTask;
            });

        HttpClientPipelineTransport transport = new();

        using PipelineMessage message = transport.CreateMessage();
        message.Request.Uri = testServer.Address;

        ClientRequestException? exception = Assert.ThrowsAsync<ClientRequestException>(async ()
            => await transport.ProcessSyncOrAsync(message, IsAsync));

        Assert.IsNotEmpty(exception!.Message);
        Assert.AreEqual(0, exception.Status);
    }

    #region Helpers

    public static object[][] RequestMethods => new[]
    {
            new object[] { "DELETE", false },
            new object[] { "GET", false },
            new object[] { "PATCH", false },
            new object[] { "POST", true },
            new object[] { "PUT", true },
            new object[] { "HEAD", false },
            new object[] { "CUSTOM", false },
        };

    public static object[] HeadersWithValues =>
       new object[]
       {
                // Name, value, is content, supports multiple
                new object[] { "Allow", "adcde", true, true },
                new object[] { "Accept", "adcde", true, true },
                new object[] { "Referer", "adcde", true, true },
                new object[] { "User-Agent", "adcde", true, true },
                new object[] { "Content-Disposition", "adcde", true, true },
                new object[] { "Content-Encoding", "adcde", true, true },
                new object[] { "Content-Language", "en-US", true, true },
                new object[] { "Content-Location", "adcde", true, true },
                new object[] { "Content-MD5", "adcde", true, true },
                new object[] { "Content-Range", "adcde", true, true },
                new object[] { "Content-Type", "text/xml", true, true },
                new object[] { "Expires", "11/12/19", true, true },
                new object[] { "Last-Modified", "11/12/19", true, true },
                new object[] { "If-Modified-Since", "Tue, 12 Nov 2019 08:00:00 GMT", false, false },
                new object[] { "Custom-Header", "11/12/19", false, true },
                new object[] { "Expect", "text/json", false, true },
                new object[] { "Host", "example.com", false, false },
                new object[] { "Keep-Alive", "true", false, true },
                new object[] { "Referer", "example.com", false, true },
                new object[] { "WWW-Authenticate", "Basic realm=\"Access to the staging site\", charset=\"UTF-8\"", false, true },
                new object[] { "Custom-Header", "11/12/19", false, true },
                new object[] { "Range", "bytes=0-", false, false },
                new object[] { "Range", "bytes=0-100", false, false },
                new object[] { "Content-Length", "16", true, false },
                new object[] { "Date", "Tue, 12 Nov 2019 08:00:00 GMT", false, false },
        };

    public class DisposeTrackingContent : BinaryContent
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

    private class InvalidSizeContent : BinaryContent
    {
        private static readonly BinaryContent _innerContent = BinaryContent.Create(BinaryData.FromBytes(new byte[50]));

        public override void Dispose()
        {
        }

        public override bool TryComputeLength(out long length)
        {
            length = 10;
            return true;
        }

        public override void WriteTo(Stream stream, CancellationToken cancellation)
        {
            _innerContent.WriteTo(stream, cancellation);
        }

        public override Task WriteToAsync(Stream stream, CancellationToken cancellation)
        {
            return _innerContent.WriteToAsync(stream, cancellation);
        }
    }

    #endregion
}
