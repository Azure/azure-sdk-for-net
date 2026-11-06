// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Concurrent;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Text.Json;
using Azure.AI.AgentServer.A2A.Internal;
using global::A2A;
using global::A2A.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using OpenTelemetry;
using OpenTelemetry.Trace;

namespace Azure.AI.AgentServer.A2A.Tests;

[TestFixture]
[NonParallelizable]
public class RequestTracingTests
{
    [TestCase("""{"jsonrpc":"2.0","id":"rpc-1","method":"\uD800","params":{}}""")]
    [TestCase("""{"jsonrpc":"2.0","id":"rpc-1","method":"SendMessage","params":{"message":{"messageId":"\uD800","role":"ROLE_USER","parts":[{"text":"hello"}]}}}""")]
    [TestCase("""{"jsonrpc":"2.0","id":"rpc-1","method":"SendMessage","params":{"tenant":"\uD800","message":{"messageId":"m","role":"ROLE_USER","parts":[{"text":"hello"}]}}}""")]
    [TestCase("""{"jsonrpc":"2.0","id":"rpc-1","method":"SendMessage","params":{"message":{"messageId":"m","role":"ROLE_USER","referenceTaskIds":["\uD800"],"parts":[{"text":"hello"}]}}}""")]
    public async Task DiagnosticInspectionPreservesNativeValidationErrors(string body)
    {
        await using var native = await CreateAppAsync(nativeOnly: true);
        await using var foundry = await CreateAppAsync();
        using var nativeClient = native.GetTestClient();
        using var foundryClient = foundry.GetTestClient();
        using var expected = await nativeClient.PostAsync("/a2a", new StringContent(body, Encoding.UTF8, "application/json"));
        using var actual = await foundryClient.PostAsync("/a2a", new StringContent(body, Encoding.UTF8, "application/json"));
        Assert.That(actual.StatusCode, Is.EqualTo(expected.StatusCode));
        using var expectedJson = JsonDocument.Parse(await expected.Content.ReadAsStringAsync());
        using var actualJson = JsonDocument.Parse(await actual.Content.ReadAsStringAsync());
        Assert.That(actualJson.RootElement.GetProperty("error").GetProperty("code").GetInt32(),
            Is.EqualTo(expectedJson.RootElement.GetProperty("error").GetProperty("code").GetInt32()));
        Assert.That(actualJson.RootElement.GetProperty("id").GetRawText(),
            Is.EqualTo(expectedJson.RootElement.GetProperty("id").GetRawText()));
    }

    [TestCase(false)]
    [TestCase(true)]
    public async Task IncomingTraceContextIsPreservedWithOrWithoutHttpInstrumentation(bool httpInstrumentation)
    {
        const string traceId = "0123456789abcdef0123456789abcdef";
        const string parentId = "0123456789abcdef";
        var stopped = new ConcurrentQueue<System.Diagnostics.Activity>();
        var httpStopped = new TaskCompletionSource<System.Diagnostics.Activity>(TaskCreationOptions.RunContinuationsAsynchronously);
        using var listener = Listen(stopped, httpInstrumentation, httpStopped);
        var capture = new RequestCapture();
        await using var app = await CreateAppAsync(capture: capture, clearRequestActivity: !httpInstrumentation);
        using var client = app.GetTestClient();
        using var request = new HttpRequestMessage(HttpMethod.Post, "/a2a")
        {
            Content = HostingTests.Rpc("SendMessage", HostingTests.MessageParams),
        };
        request.Headers.Add("traceparent", $"00-{traceId}-{parentId}-01");
        request.Headers.Add("tracestate", "vendor=opaque");
        request.Headers.Add("baggage", "review-key=review-value");
        using var response = await client.SendAsync(request);
        await response.Content.ReadAsStringAsync();
        var operation = stopped.Single(span => span.OperationName == "SendMessage");
        Assert.That(operation.TraceId.ToString(), Is.EqualTo(traceId));
        Assert.That(operation.TraceStateString, Is.EqualTo("vendor=opaque"));
        if (httpInstrumentation)
        {
            var http = await httpStopped.Task.WaitAsync(TimeSpan.FromSeconds(10));
            Assert.That(http.ParentSpanId.ToString(), Is.EqualTo(parentId));
            Assert.That(operation.ParentSpanId, Is.EqualTo(http.SpanId));
        }
        else
        {
            Assert.That(operation.ParentSpanId.ToString(), Is.EqualTo(parentId));
        }
        Assert.That(capture.TraceId, Is.EqualTo(traceId));
        Assert.That(capture.Baggage, Is.EqualTo("review-value"));
        Assert.That(Baggage.GetBaggage("review-key"), Is.Null);
        Assert.That(System.Diagnostics.Activity.Current?.GetBaggageItem("review-key"), Is.Null);
    }

    [TestCase(null, "1.0")]
    [TestCase("invalid", "1.0")]
    public async Task InvalidOrMissingTraceparentDoesNotRejectTheRequest(string? traceparent, string version)
    {
        var stopped = new ConcurrentQueue<System.Diagnostics.Activity>();
        using var listener = Listen(stopped);
        await using var app = await CreateAppAsync();
        using var client = app.GetTestClient();
        using var request = new HttpRequestMessage(HttpMethod.Post, "/a2a")
        {
            Content = HostingTests.Rpc("SendMessage", HostingTests.MessageParams),
        };
        if (traceparent is not null)
        { request.Headers.Add("traceparent", traceparent); }
        request.Headers.Add("A2A-Version", version);
        using var response = await client.SendAsync(request);
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(await response.Content.ReadAsStringAsync(), Does.Contain("\"result\""));
        Assert.That(stopped.Single(span => span.OperationName == "SendMessage").TraceId, Is.Not.EqualTo(default(ActivityTraceId)));
    }

    [TestCase(true)]
    [TestCase(false)]
    public async Task OnlyRecordingRequestsInstallResponseObservation(bool recording)
    {
        using var provider = Sdk.CreateTracerProviderBuilder()
            .AddSource(A2ARpcResult.SourceName)
            .SetSampler(recording ? new AlwaysOnSampler() : new AlwaysOffSampler())
            .Build();
        var capture = new RequestCapture();
        await using var app = await CreateAppAsync(capture: capture, clearRequestActivity: true);
        using var client = app.GetTestClient();
        client.DefaultRequestHeaders.Add("traceparent", "00-0123456789abcdef0123456789abcdef-0123456789abcdef-00");
        using var response = await client.PostAsync("/a2a", HostingTests.Rpc("SendMessage", HostingTests.MessageParams));
        Assert.That(await response.Content.ReadAsStringAsync(), Does.Contain("hello"));
        Assert.That(capture.ResponseObserved, Is.EqualTo(recording));
        Assert.That(capture.TraceId, Is.EqualTo("0123456789abcdef0123456789abcdef"));
    }

    [TestCase(null, "", "1.0")]
    [TestCase(null, "?a2a-version=99.0", "1.0")]
    [TestCase(null, "?a2a-version=0.3", "1.0")]
    [TestCase("1.0", "", "1.0")]
    [TestCase("1.0", "?a2a-version=99.0", "1.0")]
    [TestCase("0.3", "?a2a-version=1.0", "0.3")]
    [TestCase("", "", "1.0")]
    [TestCase("99.0", "", null)]
    [TestCase("1.0|1.0", "", "1.0")]
    [TestCase("1.0|0.3", "", null)]
    [TestCase("1.0|99.0", "", null)]
    public async Task VersionTelemetryUsesNativeHeaderSelectionNotIgnoredQuery(
        string? header, string query, string? expectedVersion)
    {
        var stopped = new ConcurrentQueue<System.Diagnostics.Activity>();
        using var listener = Listen(stopped);
        await using var app = await CreateAppAsync();
        await using var native = await CreateAppAsync(nativeOnly: true);
        foreach (var target in new[] { native, app })
        {
            using var client = target.GetTestClient();
            using var request = new HttpRequestMessage(HttpMethod.Post, "/a2a" + query)
            {
                Content = HostingTests.Rpc("SendMessage", HostingTests.MessageParams),
            };
            if (header is not null)
            { request.Headers.Add("A2A-Version", header.Split('|')); }
            using var response = await client.SendAsync(request);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            using var body = JsonDocument.Parse(await response.Content.ReadAsStringAsync());
            Assert.That(body.RootElement.TryGetProperty("error", out _),
                Is.EqualTo(header?.Contains("99.0", StringComparison.Ordinal) == true));
        }
        var span = stopped.Single(activity => activity.OperationName == "SendMessage");
        Assert.That(span.GetTagItem("a2a.protocol.version"), Is.EqualTo(expectedVersion));
    }

    private static ActivityListener Listen(
        ConcurrentQueue<System.Diagnostics.Activity> stopped,
        bool httpInstrumentation = false,
        TaskCompletionSource<System.Diagnostics.Activity>? httpStopped = null)
    {
        var listener = new ActivityListener
        {
            ShouldListenTo = source => source.Name == A2ARpcResult.SourceName
                || (httpInstrumentation && source.Name == "Microsoft.AspNetCore"),
            Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.AllData,
            ActivityStopped = activity =>
            {
                stopped.Enqueue(activity);
                if (activity.Source.Name == "Microsoft.AspNetCore")
                { httpStopped?.TrySetResult(activity); }
            },
        };
        ActivitySource.AddActivityListener(listener);
        return listener;
    }

    private static async Task<WebApplication> CreateAppAsync(
        bool nativeOnly = false, RequestCapture? capture = null, bool clearRequestActivity = false)
    {
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseTestServer();
        if (nativeOnly)
        { builder.Services.AddA2AAgent<InspectingAgent>(HostingTests.CreateCard()); }
        else
        { builder.Services.AddFoundryA2A<InspectingAgent>(HostingTests.CreateCard()); }
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddSingleton(capture ?? new RequestCapture());
        var app = builder.Build();
        if (clearRequestActivity)
        {
            app.Use(async (context, next) =>
            {
                var previous = System.Diagnostics.Activity.Current;
                System.Diagnostics.Activity.Current = null;
                try
                { await next(context); }
                finally { System.Diagnostics.Activity.Current = previous; }
            });
        }
        if (nativeOnly)
        { app.MapA2A("/a2a"); }
        else
        { app.MapFoundryA2A(); }
        await app.StartAsync();
        return app;
    }

    private sealed class RequestCapture
    {
        public bool ResponseObserved { get; set; }
        public string? TraceId { get; set; }
        public string? Baggage { get; set; }
    }

    private sealed class InspectingAgent(IHttpContextAccessor accessor, RequestCapture capture) : IAgentHandler
    {
        public async Task ExecuteAsync(global::A2A.RequestContext context, AgentEventQueue eventQueue, CancellationToken cancellationToken)
        {
            await Task.Yield();
            capture.ResponseObserved = accessor.HttpContext!.Response.Body is ObservingWriteStream;
            capture.TraceId = System.Diagnostics.Activity.Current?.TraceId.ToString();
            capture.Baggage = System.Diagnostics.Activity.Current?.GetBaggageItem("review-key");
            await new MessageResponder(eventQueue, context.ContextId).ReplyAsync(
                context.UserText ?? string.Empty, cancellationToken: cancellationToken);
        }
    }
}
