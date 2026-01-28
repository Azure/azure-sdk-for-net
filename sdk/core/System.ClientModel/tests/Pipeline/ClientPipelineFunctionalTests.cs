// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.TestFramework;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using ClientModel.Tests;
using ClientModel.Tests.Mocks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using SyncAsyncTestBase = ClientModel.Tests.SyncAsyncTestBase;

namespace System.ClientModel.Tests.Pipeline;

public class ClientPipelineFunctionalTests : SyncAsyncTestBase
{
    private const string LoggingPolicyCategoryName = "System.ClientModel.Primitives.MessageLoggingPolicy";
    private const string PipelineTransportCategoryName = "System.ClientModel.Primitives.PipelineTransport";
    private const string RetryPolicyCategoryName = "System.ClientModel.Primitives.ClientRetryPolicy";

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

            Assert.That(response.ContentStream!.Length, Is.EqualTo(1000));
            Assert.That(response.Content.ToMemory().Length, Is.EqualTo(1000));
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
            Assert.That(bodySize, Is.EqualTo(memoryStream.Length));
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

            Assert.That(message.Response!.ContentStream!.CanSeek, Is.EqualTo(false));
            Assert.Throws<InvalidOperationException>(() => { var content = message.Response.Content; });
        }

        Assert.That(reqNum, Is.GreaterThan(requestCount));
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
        Assert.That(exception!.Message, Is.EqualTo("The operation was cancelled because it exceeded the configured timeout of 0:00:00.5. The default timeout can be adjusted by passing a custom ClientPipelineOptions.NetworkTimeout value to the client's constructor. See https://aka.ms/net/scm/configure/networktimeout for more information."));

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
        Assert.That(exception!.Message, Is.EqualTo("The operation was cancelled because it exceeded the configured timeout of 0:00:00.5. The default timeout can be adjusted by passing a custom ClientPipelineOptions.NetworkTimeout value to the client's constructor. See https://aka.ms/net/scm/configure/networktimeout for more information."));

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

        Assert.That(message.Response!.Status, Is.EqualTo(200));
        var responseContentStream = message.Response.ContentStream;
        Assert.Throws<InvalidOperationException>(() => { var content = message.Response.Content; });
        var buffer = new byte[10];
        Assert.That(await responseContentStream!.ReadAsync(buffer, 0, 1), Is.EqualTo(1));
#pragma warning disable CA2022 // This test is validating an exception is thrown and doesn't need to check the return value of ReadAsync.
        var exception = Assert.ThrowsAsync<TaskCanceledException>(async () => await responseContentStream.ReadAsync(buffer, 0, 10));
#pragma warning restore CA2022
        Assert.That(exception!.Message, Is.EqualTo("The operation was cancelled because it exceeded the configured timeout of 0:00:00.5. The default timeout can be adjusted by passing a custom ClientPipelineOptions.NetworkTimeout value to the client's constructor. See https://aka.ms/net/scm/configure/networktimeout for more information."));

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

        Assert.That(message.Response!.Status, Is.EqualTo(201));
        Assert.That(i, Is.EqualTo(2));
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

        Assert.That(message.Response!.Status, Is.EqualTo(201));
        Assert.That(i, Is.EqualTo(2));

        testDoneTcs.Cancel();
    }

    [Test]
    public async Task DoesNotRetryClientCancellation()
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
        Assert.That(exception!.Message, Is.EqualTo("The operation was canceled."));
        Assert.That(i, Is.EqualTo(1));

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

        Assert.That(message.Response!.Status, Is.EqualTo(201));
        Assert.That(await new StreamReader(message.Response.ContentStream!).ReadToEndAsync(), Is.EqualTo("Hello world!"));
        Assert.That(message.Response.Content.ToString(), Is.EqualTo("Hello world!"));
        Assert.That(i, Is.EqualTo(2));

        testDoneTcs.Cancel();
    }

    #endregion

    #region Test default logging policy behavior

    [Test]
    public async Task LogsRequestAndResponseToEventSource()
    {
        using TestClientEventListener eventListener = new();

        ClientPipeline pipeline = ClientPipeline.Create();

        using TestServer testServer = new(
            async context =>
            {
                context.Response.StatusCode = 201;
                await context.Response.WriteAsync("Hello World!");
            });

        using PipelineMessage message = pipeline.CreateMessage();
        message.Request.Uri = testServer.Address;
        message.BufferResponse = true;

        await pipeline.SendSyncOrAsync(message, IsAsync);

        // Request
        EventWrittenEventArgs args = eventListener.SingleEventById(1, e => e.EventSource.Name == "System.ClientModel");
        Assert.That(args.Level, Is.EqualTo(EventLevel.Informational));
        Assert.That(args.EventName, Is.EqualTo("Request"));

        // Response
        args = eventListener.SingleEventById(5, e => e.EventSource.Name == "System.ClientModel");
        Assert.That(args.Level, Is.EqualTo(EventLevel.Informational));
        Assert.That(args.EventName, Is.EqualTo("Response"));
        Assert.That(args.GetProperty<int>("status"), Is.EqualTo(201));

        // No other events should have been logged
        Assert.That(eventListener.EventData.Count(), Is.EqualTo(2));
    }

    [Test]
    public void LogsRequestAndExceptionResponseToEventSource()
    {
        using TestClientEventListener eventListener = new();

        ClientPipeline pipeline = ClientPipeline.Create();

        using TestServer testServer = new(
            async context =>
            {
                await context.Response.WriteAsync("Hello World!");
                throw new Exception("Error");
            });

        using PipelineMessage message = pipeline.CreateMessage();
        message.Request.Uri = testServer.Address;
        message.BufferResponse = true;

        Assert.ThrowsAsync<AggregateException>(async () => await pipeline.SendSyncOrAsync(message, IsAsync));

        // Request Events
        IEnumerable<EventWrittenEventArgs> args = eventListener.EventsById(1);
        Assert.That(args.Count(), Is.EqualTo(4));

        // Exception Response Events
        args = eventListener.EventsById(18);
        Assert.That(args.Count(), Is.EqualTo(4));
        foreach (EventWrittenEventArgs responseEventArgs in args)
        {
            Assert.That(responseEventArgs.Level, Is.EqualTo(EventLevel.Informational));
            Assert.That(responseEventArgs.EventName, Is.EqualTo("ExceptionResponse"));
            Assert.That((responseEventArgs.GetProperty<string>("exception")).Contains("Exception"), Is.True);
        }

        // 4 request events, 3 request retrying, 4 exception response
        Assert.That(eventListener.EventData.Count(), Is.EqualTo(11));
    }

    [Test]
    public async Task LogsRequestAndRetryToEventSource()
    {
        using TestClientEventListener eventListener = new();

        ClientPipeline pipeline = ClientPipeline.Create();

        int responseNum = 0;
        using TestServer testServer = new(
            async context =>
            {
                switch (responseNum)
                {
                    case 0:
                        context.Response.StatusCode = 429;
                        await context.Response.WriteAsync("Try again");
                        break;
                    default:
                        context.Response.StatusCode = 201;
                        await context.Response.WriteAsync("Success");
                        break;
                }
                responseNum++;
            });

        using PipelineMessage message = pipeline.CreateMessage();
        message.Request.Uri = testServer.Address;
        message.BufferResponse = true;

        await pipeline.SendSyncOrAsync(message, IsAsync);

        // Request Events
        IEnumerable<EventWrittenEventArgs> args = eventListener.EventsById(1);
        Assert.That(args.Count(), Is.EqualTo(2));

        // Retry event
        EventWrittenEventArgs arg = eventListener.SingleEventById(10);
        Assert.That(arg.EventName, Is.EqualTo("RequestRetrying"));

        // Error response event
        arg = eventListener.SingleEventById(8);
        Assert.That(arg.EventName, Is.EqualTo("ErrorResponse"));

        // Response event
        arg = eventListener.SingleEventById(5);
        Assert.That(arg.EventName, Is.EqualTo("Response"));

        // No other events should have been logged
        Assert.That(eventListener.EventData.Count(), Is.EqualTo(5));
    }

    [Test]
    public async Task LogsRequestAndResponseToILogger()
    {
        using TestLoggingFactory factory = new(LogLevel.Debug);
        ClientPipelineOptions options = new() { ClientLoggingOptions = new() { LoggerFactory = factory } };
        ClientPipeline pipeline = ClientPipeline.Create(options);

        using TestServer testServer = new(
            async context =>
            {
                context.Response.StatusCode = 201;
                await context.Response.WriteAsync("Hello World!");
            });

        using PipelineMessage message = pipeline.CreateMessage();
        message.Request.Uri = testServer.Address;
        message.BufferResponse = true;

        await pipeline.SendSyncOrAsync(message, IsAsync);

        // Message logger
        TestLogger messageLogger = factory.GetLogger(LoggingPolicyCategoryName);

        // Request
        LoggerEvent log = messageLogger.SingleEventById(1);
        Assert.That(log.LogLevel, Is.EqualTo(LogLevel.Information));
        Assert.That(log.EventId.Name, Is.EqualTo("Request"));

        // Response
        log = messageLogger.SingleEventById(5);
        Assert.That(log.LogLevel, Is.EqualTo(LogLevel.Information));
        Assert.That(log.EventId.Name, Is.EqualTo("Response"));
        Assert.That(log.GetValueFromArguments<int>("status"), Is.EqualTo(201));

        // No other events should have been logged
        Assert.That(messageLogger.Logs.Count(), Is.EqualTo(2));
    }

    [Test]
    public void LogsRequestAndExceptionResponseToILogger()
    {
        using TestLoggingFactory factory = new(LogLevel.Debug);
        ClientPipelineOptions options = new() { ClientLoggingOptions = new() { LoggerFactory = factory } };
        ClientPipeline pipeline = ClientPipeline.Create(options);

        using TestServer testServer = new(
            async context =>
            {
                await context.Response.WriteAsync("Hello World!");
                context.Abort();
            });

        using PipelineMessage message = pipeline.CreateMessage();
        message.Request.Uri = testServer.Address;
        message.BufferResponse = true;

        Assert.ThrowsAsync<AggregateException>(async () => await pipeline.SendSyncOrAsync(message, IsAsync));

        // Message logger
        TestLogger messageLogger = factory.GetLogger(LoggingPolicyCategoryName);

        // Transport Logger
        TestLogger transportLogger = factory.GetLogger(PipelineTransportCategoryName);

        // Request Events
        IEnumerable<LoggerEvent> logs = messageLogger.EventsById(1);
        Assert.That(logs.Count(), Is.EqualTo(4));

        // Exception Response Events
        logs = transportLogger.EventsById(18);
        Assert.That(logs.Count(), Is.EqualTo(4));
        foreach (LoggerEvent responseEventLog in logs)
        {
            Assert.That(responseEventLog.LogLevel, Is.EqualTo(LogLevel.Information));
            Assert.That(responseEventLog.EventId.Name, Is.EqualTo("ExceptionResponse"));
        }

        // No other events should have been logged
        Assert.That(messageLogger.Logs.Count(), Is.EqualTo(4));
        Assert.That(transportLogger.Logs.Count(), Is.EqualTo(4));
    }

    [Test]
    public async Task LogsRequestAndRetryToILogger()
    {
        using TestLoggingFactory factory = new(LogLevel.Debug);
        ClientPipelineOptions options = new() { ClientLoggingOptions = new() { LoggerFactory = factory } };
        ClientPipeline pipeline = ClientPipeline.Create(options);

        int responseNum = 0;
        using TestServer testServer = new(
            async context =>
            {
                switch (responseNum)
                {
                    case 0:
                        context.Response.StatusCode = 429;
                        await context.Response.WriteAsync("Try again");
                        break;
                    default:
                        context.Response.StatusCode = 201;
                        await context.Response.WriteAsync("Success");
                        break;
                }
                responseNum++;
            });

        using PipelineMessage message = pipeline.CreateMessage();
        message.Request.Uri = testServer.Address;
        message.BufferResponse = true;

        await pipeline.SendSyncOrAsync(message, IsAsync);

        // Message logger
        TestLogger messageLogger = factory.GetLogger(LoggingPolicyCategoryName);

        // Retry Logger
        TestLogger retryLogger = factory.GetLogger(RetryPolicyCategoryName);

        // Request Events
        IEnumerable<LoggerEvent> args = messageLogger.EventsById(1);
        Assert.That(args.Count(), Is.EqualTo(2));

        // Retry event
        LoggerEvent arg = retryLogger.SingleEventById(10);
        Assert.That(arg.EventId.Name, Is.EqualTo("RequestRetrying"));

        // Error response event
        arg = messageLogger.SingleEventById(8);
        Assert.That(arg.EventId.Name, Is.EqualTo("ErrorResponse"));

        // Response event
        arg = messageLogger.SingleEventById(5);
        Assert.That(arg.EventId.Name, Is.EqualTo("Response"));

        // No other events should have been logged
        Assert.That(messageLogger.Logs.Count(), Is.EqualTo(4));
        Assert.That(retryLogger.Logs.Count(), Is.EqualTo(1));
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
