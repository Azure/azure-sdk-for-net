// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using ClientModel.Tests;
using ClientModel.Tests.Mocks;
using Microsoft.AspNetCore.Http.Features;
using NUnit.Framework;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
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
    public async Task RequestHeaderContentLengthSetWhenNoContent(string method, bool hasContent)
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
    public async Task RequestHeaderContentTypeNullWhenNoContent(string method, bool hasContent)
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

    #endregion

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

    #endregion
}
