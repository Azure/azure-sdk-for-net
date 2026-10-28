// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Text;
using Azure.AI.AgentServer.A2A.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
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
