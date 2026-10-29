// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Collections.Concurrent;
using System.Text;
using System.Runtime.CompilerServices;
using global::A2A;
using Azure.AI.AgentServer.A2A.Internal;
using Azure.AI.AgentServer.A2A.Tests.Snippets;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace Azure.AI.AgentServer.A2A.Tests;

[TestFixture]
public class TracingTests
{
    [TestCase("\n\n")]
    [TestCase("\r\n\r\n")]
    public void SseObservationHandlesChunkBoundariesAndOversizedEvents(string boundary)
    {
        using var source = new ActivitySource($"test.{Guid.NewGuid():N}");
        using var listener = new ActivityListener
        {
            ShouldListenTo = s => s == source,
            Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.AllData,
        };
        ActivitySource.AddActivityListener(listener);
        using var span = source.StartActivity("stream")!;
        var context = new DefaultHttpContext();
        context.Response.ContentType = "text/event-stream";
        using var observer = new A2AResponseObserver(context, "SendStreamingMessage", span, null, false);
        observer.Observe(Encoding.UTF8.GetBytes("data: " + new string('x', A2AResponseObserver.MaxPayloadBytes + 1) + boundary));
        var valid = Encoding.UTF8.GetBytes("data: {\"result\":{\"task\":{\"id\":\"returned-task\"}}}" + boundary);
        foreach (byte value in valid)
        {
            observer.Observe(new[] { value });
        }

        observer.Complete();
        Assert.That(span.GetTagItem("a2a.task.id"), Is.EqualTo("returned-task"));
        Assert.That(span.Status, Is.Not.EqualTo(ActivityStatusCode.Error));
    }

    [TestCase("SendMessage", """{"result":{"task":{"id":"t1"}}}""", "t1")]
    [TestCase("SendMessage", """{"result":{"message":{"taskId":"t2"}}}""", "t2")]
    [TestCase("ListTasks", """{"result":{"tasks":[{"id":"t3"}]}}""", null)]
    [TestCase("GetTask", """{"error":{"code":-32001}}""", null)]
    public void UnaryObservationUsesNativeShapes(string method, string payload, string? taskId)
    {
        using var source = new ActivitySource($"test.{Guid.NewGuid():N}");
        using var listener = new ActivityListener
        {
            ShouldListenTo = s => s == source,
            Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.AllData,
        };
        ActivitySource.AddActivityListener(listener);
        using var span = source.StartActivity(method)!;
        var context = new DefaultHttpContext();
        context.Response.ContentType = "application/json";
        using var observer = new A2AResponseObserver(context, method, span, null, false);
        observer.Observe(Encoding.UTF8.GetBytes(payload));
        observer.Complete();
        Assert.That(span.GetTagItem("a2a.task.id"), Is.EqualTo(taskId));
        Assert.That(span.Status == ActivityStatusCode.Error, Is.EqualTo(method == "GetTask"));
    }

    [Test]
    public void SseApplicationErrorsDoNotMarkHttp200SpanFailed()
    {
        using var span = new System.Diagnostics.Activity("stream").Start();
        var context = new DefaultHttpContext();
        context.Response.ContentType = "text/event-stream";
        using var observer = new A2AResponseObserver(context, "SendStreamingMessage", span, null, false);
        observer.Observe("data: {\"error\":{\"code\":-32603}}\n\n"u8);
        observer.Complete();
        Assert.That(span.Status, Is.Not.EqualTo(ActivityStatusCode.Error));
    }

    [Test]
    public void TransmissionFailuresMarkBothSpansUnlessCancellationWasRequested(
        [Values("write", "write-array", "write-memory", "flush", "flush-async")] string path,
        [Values("failure", "request-cancelled", "write-cancelled")] string outcome)
    {
        using var operation = new System.Diagnostics.Activity("operation").Start();
        using var invocation = new System.Diagnostics.Activity("invocation").Start();
        using var requestCancellation = new CancellationTokenSource();
        using var writeCancellation = new CancellationTokenSource();
        bool expectedCancellation = outcome != "failure";
        if (outcome == "request-cancelled") { requestCancellation.Cancel(); }
        if (outcome == "write-cancelled") { writeCancellation.Cancel(); }
        var context = new DefaultHttpContext();
        context.Response.ContentType = "text/event-stream";
        context.RequestAborted = requestCancellation.Token;
        using var observer = new A2AResponseObserver(context, "SendStreamingMessage", operation, invocation, true);
        Exception failure = expectedCancellation
            ? new OperationCanceledException()
            : new IOException("Response transport failed");
        using var output = new FailingResponseStream(failure);
        using var stream = new ObservingWriteStream(output, observer);
        Func<Task> action = path switch
        {
            "write" => () => { stream.Write(new byte[1], 0, 1); return Task.CompletedTask; },
            "write-array" => () => stream.WriteAsync(new byte[1], 0, 1, writeCancellation.Token),
            "write-memory" => () => stream.WriteAsync(new byte[1].AsMemory(), writeCancellation.Token).AsTask(),
            "flush" => () => { stream.Flush(); return Task.CompletedTask; },
            "flush-async" => () => stream.FlushAsync(writeCancellation.Token),
            _ => throw new ArgumentOutOfRangeException(nameof(path)),
        };
        var actual = Assert.CatchAsync(async () => await action());
        if (expectedCancellation)
        {
            Assert.That(actual, Is.InstanceOf<OperationCanceledException>());
        }
        else
        {
            Assert.That(actual, Is.SameAs(failure));
        }
        bool cancelled = outcome == "request-cancelled"
            || (outcome == "write-cancelled" && path is "write-array" or "write-memory" or "flush-async");
        foreach (var span in new[] { operation, invocation })
        {
            Assert.That(span.Status == ActivityStatusCode.Error, Is.EqualTo(!cancelled));
            Assert.That(span.GetTagItem("error.type"), Is.EqualTo(cancelled ? null : failure.GetType().FullName));
        }
    }

    [TestCase(false)]
    [TestCase(true)]
    public async Task NativeTransportCannotHideTransmissionFailuresFromTracing(bool failOnFlush)
    {
        var stopped = new ConcurrentQueue<System.Diagnostics.Activity>();
        using var listener = new ActivityListener
        {
            ShouldListenTo = source => source.Name == A2ARpcResult.SourceName,
            Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.AllData,
            ActivityStopped = stopped.Enqueue,
        };
        ActivitySource.AddActivityListener(listener);
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseTestServer();
        builder.Services.AddFoundryA2A<ReadMeSnippets.TaskAgent>(HostingTests.CreateCard());
        builder.Services.AddSingleton<IA2ARequestHandler, FailingNativeServer>();
        await using var app = builder.Build();
        app.Use(async (context, next) =>
        {
            var original = context.Response.Body;
            using var broken = new FailingResponseStream(new IOException("Response failed"), failOnFlush);
            context.Response.Body = broken;
            try { await next(context); }
            finally { context.Response.Body = original; }
        });
        app.MapFoundryA2A();
        await app.StartAsync();
        using var client = app.GetTestClient();
        using var response = await client.PostAsync("/a2a", HostingTests.Rpc("SendStreamingMessage", HostingTests.MessageParams));
        await response.Content.ReadAsStringAsync();
        var operation = stopped.Single(span => span.OperationName == "SendStreamingMessage");
        Assert.That(operation.Status, Is.EqualTo(ActivityStatusCode.Error));
        Assert.That(operation.GetTagItem("error.type"), Is.EqualTo(typeof(IOException).FullName));
    }

    private sealed class FailingNativeServer(
        IAgentHandler handler,
        ITaskStore store,
        ChannelEventNotifier notifier,
        ILogger<A2AServer> logger,
        A2AServerOptions options) : A2AServer(handler, store, notifier, logger, options)
    {
        public override async IAsyncEnumerable<StreamResponse> SendStreamingMessageAsync(
            SendMessageRequest request, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            yield return new StreamResponse { Task = FoundryTaskStoreTests.CreateTask("task-1") };
            await Task.Yield();
            throw new InvalidOperationException("Failure after the initial event");
        }
    }

    private sealed class FailingResponseStream(Exception failure, bool failOnFlush = false) : MemoryStream
    {
        public override void Write(byte[] buffer, int offset, int count)
        {
            if (!failOnFlush) { throw failure; }
            base.Write(buffer, offset, count);
        }

        public override ValueTask WriteAsync(ReadOnlyMemory<byte> buffer, CancellationToken cancellationToken = default)
        {
            if (!failOnFlush) { return ValueTask.FromException(failure); }
            return base.WriteAsync(buffer, cancellationToken);
        }

        public override void Flush() => throw failure;
        public override Task FlushAsync(CancellationToken cancellationToken) => Task.FromException(failure);
    }

    [Test]
    public async Task ObserverForwardsBytesUnchanged()
    {
        using var services = new ServiceCollection().AddLogging().BuildServiceProvider();
        var context = new DefaultHttpContext { RequestServices = services };
        context.Response.ContentType = "text/event-stream";
        using var observer = new A2AResponseObserver(context, "SendStreamingMessage", null, null, false);
        using var output = new MemoryStream();
        using var stream = new ObservingWriteStream(output, observer);
        byte[] bytes = Encoding.UTF8.GetBytes("data: {\"result\":{\"task\":{\"id\":\"t1\"}}}\r\n\r\n");
        await stream.WriteAsync(bytes);
        observer.Complete();
        Assert.That(output.ToArray(), Is.EqualTo(bytes));
    }

    [TestCase(A2AResponseObserver.MaxPayloadBytes, "\n\n", true)]
    [TestCase(A2AResponseObserver.MaxPayloadBytes, "\r\n\r\n", true)]
    [TestCase(A2AResponseObserver.MaxPayloadBytes + 1, "\n\n", false)]
    [TestCase(A2AResponseObserver.MaxPayloadBytes + 1, "\r\n\r\n", false)]
    public void SseEventLimitExcludesFraming(int size, string boundary, bool observed)
    {
        using var span = new System.Diagnostics.Activity("edge").Start();
        var context = new DefaultHttpContext();
        context.Response.ContentType = "text/event-stream";
        using var observer = new A2AResponseObserver(context, "SendStreamingMessage", span, null, false);
        const string content = """data: {"result":{"task":{"id":"edge-task"}}}""";
        string data = content + new string(' ', size - content.Length) + boundary;
        observer.Observe(Encoding.UTF8.GetBytes(data));
        observer.Complete();
        Assert.That(span.GetTagItem("a2a.task.id"), Is.EqualTo(observed ? "edge-task" : null));
    }
}
