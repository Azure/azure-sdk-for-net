// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using ClientModel.Tests.Mocks;
using Microsoft.AspNetCore.Http;
using Moq;
using NUnit.Framework;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using SyncAsyncTestBase = ClientModel.Tests.SyncAsyncTestBase;

namespace System.ClientModel.Tests.Pipeline;

public class ClientPipelineFunctionalTests : SyncAsyncTestBase
{
    public ClientPipelineFunctionalTests(bool isAsync) : base(isAsync)
    {
    }

    #region Test default buffering behavior

    [Test]
    public async Task SendRequestBuffersResponse()
    {
        byte[] buffer = { 0 };

        using TestServer testServer = new TestServer(
            async context =>
            {
                for (int i = 0; i < 1000; i++)
                {
                    await context.Response.Body.WriteAsync(buffer, 0, 1);
                }
            });

        ClientPipeline pipeline = ClientPipeline.Create();

        // Make sure we dispose things correctly and not exhaust the connection pool
        for (int i = 0; i < 100; i++)
        {
            using PipelineMessage message = pipeline.CreateMessage();
            message.Request.Uri = testServer.Address;

            await pipeline.SendSyncOrAsync(message, IsAsync);

            using PipelineResponse response = message.Response!;

            Assert.AreEqual(response.ContentStream!.Length, 1000);
            Assert.AreEqual(response.Content.ToMemory().Length, 1000);
        }
    }

    [TestCase(200)]
    [TestCase(404)]
    public async Task BufferedResponseStreamReadableAfterMessageDisposed(int status)
    {
        byte[] buffer = { 0 };

        ClientPipeline pipeline = ClientPipeline.Create();

        int bodySize = 1000;

        using TestServer testServer = new TestServer(
            async context =>
            {
                context.Response.StatusCode = status;
                for (int i = 0; i < bodySize; i++)
                {
                    await context.Response.Body.WriteAsync(buffer, 0, 1);
                }
            });

        var requestCount = 100;
        for (int i = 0; i < requestCount; i++)
        {
            PipelineResponse response;
            using (PipelineMessage message = pipeline.CreateMessage())
            {
                message.Request.Uri = testServer.Address;
                message.BufferResponse = true;

                await pipeline.SendSyncOrAsync(message, IsAsync);

                response = message.Response!;
            }

            MemoryStream memoryStream = new();
            await response.ContentStream!.CopyToAsync(memoryStream);
            Assert.AreEqual(memoryStream.Length, bodySize);
        }
    }

    [Test]
    public async Task NonBufferedResponseDisposedAfterMessageDisposed()
    {
        byte[] buffer = { 0 };

        ClientPipeline pipeline = ClientPipeline.Create();

        int bodySize = 1000;

        using TestServer testServer = new TestServer(
            async context =>
            {
                for (int i = 0; i < bodySize; i++)
                {
                    await context.Response.Body.WriteAsync(buffer, 0, 1);
                }
            });

        var requestCount = 100;
        for (int i = 0; i < requestCount; i++)
        {
            PipelineResponse response;
            Mock<Stream>? disposeTrackingStream = null;
            using (PipelineMessage message = pipeline.CreateMessage())
            {
                message.Request.Uri = testServer.Address;
                message.BufferResponse = false;

                await pipeline.SendSyncOrAsync(message, IsAsync);

                response = message.Response!;
                var originalStream = response.ContentStream;
                disposeTrackingStream = new Mock<Stream>();
                disposeTrackingStream
                    .Setup(s => s.Close())
                    .Callback(originalStream!.Close)
                    .Verifiable();
                response.ContentStream = disposeTrackingStream.Object;
            }

            disposeTrackingStream.Verify();
        }
    }

    [Test]
    public async Task NonBufferedFailedResponseStreamDisposed()
    {
        byte[] buffer = { 0 };

        ClientPipeline pipeline = ClientPipeline.Create();

        int bodySize = 1000;
        int reqNum = 0;

        using TestServer testServer = new TestServer(
            async context =>
            {
                if (Interlocked.Increment(ref reqNum) % 2 == 0)
                {
                    // Respond with 503 to every other request to force a retry
                    context.Response.StatusCode = 503;
                }

                for (int i = 0; i < bodySize; i++)
                {
                    await context.Response.Body.WriteAsync(buffer, 0, 1);
                }
            });

        // Make sure we dispose things correctly and not exhaust the connection pool
        var requestCount = 100;
        for (int i = 0; i < requestCount; i++)
        {
            using PipelineMessage message = pipeline.CreateMessage();
            message.Request.Uri = testServer.Address;
            message.BufferResponse = false;

            await pipeline.SendSyncOrAsync(message, IsAsync);

            Assert.AreEqual(message.Response!.ContentStream!.CanSeek, false);
            Assert.Throws<InvalidOperationException>(() => { var content = message.Response.Content; });
        }

        Assert.Greater(reqNum, requestCount);
    }

    [Test]
    public void TimesOutResponseBuffering()
    {
        var testDoneTcs = new CancellationTokenSource();
        ClientPipelineOptions options = new()
        {
            NetworkTimeout = TimeSpan.FromMilliseconds(500),
            RetryPolicy = new MockRetryPolicy(maxRetries: 0, i => TimeSpan.FromMilliseconds(10)),
        };
        ClientPipeline pipeline = ClientPipeline.Create(options);

        using TestServer testServer = new TestServer(
            async _ =>
            {
                await Task.Delay(Timeout.Infinite, testDoneTcs.Token);
            });

        using PipelineMessage message = pipeline.CreateMessage();
        message.Request.Uri = testServer.Address;
        message.BufferResponse = true;

        var exception = Assert.ThrowsAsync<TaskCanceledException>(async () => await pipeline.SendSyncOrAsync(message, IsAsync));
        Assert.AreEqual("The operation was cancelled because it exceeded the configured timeout of 0:00:00.5. ", exception!.Message);

        testDoneTcs.Cancel();
    }

    [Test]
    public void TimesOutBodyBuffering()
    {
        var testDoneTcs = new CancellationTokenSource();
        ClientPipelineOptions options = new()
        {
            NetworkTimeout = TimeSpan.FromMilliseconds(500),
            RetryPolicy = new MockRetryPolicy(maxRetries: 0, i => TimeSpan.FromMilliseconds(10)),
        };
        ClientPipeline pipeline = ClientPipeline.Create(options);

        using TestServer testServer = new TestServer(
            async context =>
            {
                context.Response.StatusCode = 200;
                context.Response.Headers.ContentLength = 10;
                await context.Response.WriteAsync("1");
                await context.Response.Body.FlushAsync();

                await Task.Delay(Timeout.Infinite, testDoneTcs.Token);
            });

        using PipelineMessage message = pipeline.CreateMessage();
        message.Request.Uri = testServer.Address;
        message.BufferResponse = true;

        var exception = Assert.ThrowsAsync<TaskCanceledException>(async () => await pipeline.SendSyncOrAsync(message, IsAsync));
        Assert.AreEqual("The operation was cancelled because it exceeded the configured timeout of 0:00:00.5. ", exception!.Message);

        testDoneTcs.Cancel();
    }

    [Test]
    public async Task TimesOutNonBufferedBodyReads()
    {
        var testDoneTcs = new CancellationTokenSource();

        ClientPipelineOptions options = new()
        {
            NetworkTimeout = TimeSpan.FromMilliseconds(500),
        };
        ClientPipeline pipeline = ClientPipeline.Create(options);

        using TestServer testServer = new TestServer(
            async context =>
            {
                context.Response.StatusCode = 200;
                context.Response.Headers.Add("Connection", "close");
                await context.Response.WriteAsync("1");
                await context.Response.Body.FlushAsync();

                await Task.Delay(Timeout.Infinite, testDoneTcs.Token);
            });

        using PipelineMessage message = pipeline.CreateMessage();
        message.Request.Uri = testServer.Address;
        message.BufferResponse = false;

        await pipeline.SendSyncOrAsync(message, IsAsync);

        Assert.AreEqual(message.Response!.Status, 200);
        var responseContentStream = message.Response.ContentStream;
        Assert.Throws<InvalidOperationException>(() => { var content = message.Response.Content; });
        var buffer = new byte[10];
        Assert.AreEqual(1, await responseContentStream!.ReadAsync(buffer, 0, 1));
        var exception = Assert.ThrowsAsync<TaskCanceledException>(async () => await responseContentStream.ReadAsync(buffer, 0, 10));
        Assert.AreEqual("The operation was cancelled because it exceeded the configured timeout of 0:00:00.5. ", exception!.Message);

        testDoneTcs.Cancel();
    }

    #endregion

    #region Test default retry behavior

    [Test]
    public async Task RetriesTransportFailures()
    {
        int i = 0;

        ClientPipeline pipeline = ClientPipeline.Create();

        using TestServer testServer = new TestServer(
            context =>
            {
                if (Interlocked.Increment(ref i) == 1)
                {
                    context.Abort();
                }
                else
                {
                    context.Response.StatusCode = 201;
                }
                return Task.CompletedTask;
            });

        using PipelineMessage message = pipeline.CreateMessage();
        message.Request.Uri = testServer.Address;
        message.BufferResponse = false;

        await pipeline.SendSyncOrAsync(message, IsAsync);

        Assert.AreEqual(message.Response!.Status, 201);
        Assert.AreEqual(2, i);
    }

    [Test]
    public async Task RetriesTimeoutsServerTimeouts()
    {
        var testDoneTcs = new CancellationTokenSource();
        int i = 0;

        ClientPipelineOptions options = new() { NetworkTimeout = TimeSpan.FromMilliseconds(500) };
        ClientPipeline pipeline = ClientPipeline.Create(options);

        using TestServer testServer = new TestServer(
            async context =>
            {
                if (Interlocked.Increment(ref i) == 1)
                {
                    await Task.Delay(Timeout.Infinite, testDoneTcs.Token);
                }
                else
                {
                    context.Response.StatusCode = 201;
                }
            });

        using PipelineMessage message = pipeline.CreateMessage();
        message.Request.Uri = testServer.Address;
        message.BufferResponse = false;

        await pipeline.SendSyncOrAsync(message, IsAsync);

        Assert.AreEqual(message.Response!.Status, 201);
        Assert.AreEqual(2, i);

        testDoneTcs.Cancel();
    }

    [Test]
    public async Task DoesntRetryClientCancellation()
    {
        var testDoneTcs = new CancellationTokenSource();
        int i = 0;

        ClientPipeline pipeline = ClientPipeline.Create();
        TaskCompletionSource<object> tcs = new TaskCompletionSource<object>(TaskCreationOptions.RunContinuationsAsynchronously);

        using TestServer testServer = new TestServer(
            async context =>
            {
                Interlocked.Increment(ref i);
                tcs.SetResult(null!);
                await Task.Delay(Timeout.Infinite, testDoneTcs.Token);
            });

        var cts = new CancellationTokenSource();

        using PipelineMessage message = pipeline.CreateMessage();
        message.Request.Uri = testServer.Address;
        message.BufferResponse = false;

        // Set CancellationToken on the message.
        RequestOptions options = new() { CancellationToken = cts.Token };
        message.Apply(options);

        var task = Task.Run(() => pipeline.SendSyncOrAsync(message, IsAsync));

        // Wait for server to receive a request
        await tcs.Task;

        cts.Cancel();

        TaskCanceledException? exception = Assert.ThrowsAsync<TaskCanceledException>(async () => await task);
        Assert.AreEqual("The operation was canceled.", exception!.Message);
        Assert.AreEqual(1, i);

        testDoneTcs.Cancel();
    }

    [Test]
    public async Task RetriesBufferedBodyTimeout()
    {
        var testDoneTcs = new CancellationTokenSource();
        int i = 0;
        ClientPipelineOptions options = new() { NetworkTimeout = TimeSpan.FromMilliseconds(500) };
        ClientPipeline pipeline = ClientPipeline.Create(options);

        using TestServer testServer = new TestServer(
            async context =>
            {
                if (Interlocked.Increment(ref i) == 1)
                {
                    context.Response.StatusCode = 200;
                    context.Response.Headers.ContentLength = 10;
                    await context.Response.WriteAsync("1");
                    await context.Response.Body.FlushAsync();

                    await Task.Delay(Timeout.Infinite, testDoneTcs.Token);
                }
                else
                {
                    context.Response.StatusCode = 201;
                    await context.Response.WriteAsync("Hello world!");
                }
            });

        using PipelineMessage message = pipeline.CreateMessage();
        message.Request.Uri = testServer.Address;
        message.BufferResponse = true;

        await pipeline.SendSyncOrAsync(message, IsAsync);

        Assert.AreEqual(message.Response!.Status, 201);
        Assert.AreEqual("Hello world!", await new StreamReader(message.Response.ContentStream!).ReadToEndAsync());
        Assert.AreEqual("Hello world!", message.Response.Content.ToString());
        Assert.AreEqual(2, i);

        testDoneTcs.Cancel();
    }

    #endregion

    #region Test parallel connections

    [Test]
    public async Task Opens50ParallelConnections()
    {
        // Running 50 sync requests on the threadpool would cause starvation
        // and the test would take 20 sec to finish otherwise
        ThreadPool.SetMinThreads(100, 100);

        ClientPipeline pipeline = ClientPipeline.Create();
        int reqNum = 0;

        TaskCompletionSource<object> requestsTcs = new(TaskCreationOptions.RunContinuationsAsynchronously);

        using TestServer testServer = new TestServer(
            async context =>
            {
                if (Interlocked.Increment(ref reqNum) == 50)
                {
                    requestsTcs.SetResult(true);
                }

                await requestsTcs.Task;
            });

        var requestCount = 50;
        List<Task> requests = new List<Task>();
        for (int i = 0; i < requestCount; i++)
        {
            PipelineMessage message = pipeline.CreateMessage();
            message.Request.Uri = testServer.Address;

            requests.Add(Task.Run(() => pipeline.SendSyncOrAsync(message, IsAsync)));
        }

        await Task.WhenAll(requests);
    }

    #endregion
}
