// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Concurrent;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

/// <summary>
/// E2E protocol tests verifying that child instrumentation spans (simulating
/// framework libraries like OpenAI SDK and Microsoft Agent Framework) correctly
/// appear as children of the AgentServer span.
/// <para>
/// These tests validate that <c>Activity.Current</c> is properly set to the
/// AgentServer span when handler code executes, so any <see cref="ActivitySource"/>
/// started within the handler automatically inherits the correct trace context.
/// </para>
/// </summary>
[TestFixture]
[NonParallelizable]
public sealed class SpanParentChildHierarchyTests : IDisposable
{
    // Unique source names to isolate from parallel test fixtures
    private readonly string _responsesSourceName;
    private readonly string _openAiSourceName;
    private readonly string _agentFrameworkSourceName;

    private readonly ActivitySource _openAiSource;
    private readonly ActivitySource _agentFrameworkSource;
    private readonly ActivityListener _listener;
    private readonly ConcurrentBag<Activity> _stoppedActivities = new();

    // Captured deterministically inside the handler
    private Activity? _capturedServerActivity;

    private readonly TestHandler _handler;
    private readonly TestWebApplicationFactory _factory;
    private readonly HttpClient _client;

    public SpanParentChildHierarchyTests()
    {
        var id = Guid.NewGuid().ToString("N")[..8];
        _responsesSourceName = $"Test.Hierarchy.Responses.{id}";
        _openAiSourceName = $"Test.Hierarchy.OpenAI.{id}";
        _agentFrameworkSourceName = $"Test.Hierarchy.AgentFramework.{id}";

        _openAiSource = new ActivitySource(_openAiSourceName);
        _agentFrameworkSource = new ActivitySource(_agentFrameworkSourceName);

        var knownSources = new HashSet<string>
        {
            _responsesSourceName,
            _openAiSourceName,
            _agentFrameworkSourceName
        };

        _listener = new ActivityListener
        {
            ShouldListenTo = source => knownSources.Contains(source.Name),
            Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.AllDataAndRecorded,
            ActivityStopped = activity => _stoppedActivities.Add(activity)
        };
        ActivitySource.AddActivityListener(_listener);

        _handler = new TestHandler();
        _factory = new TestWebApplicationFactory(
            _handler,
            configureTestServices: services =>
                services.AddSingleton<ResponsesActivitySource>(
                    new TestableActivitySource(_responsesSourceName)));
        _client = _factory.CreateClient();
    }

    /// <summary>
    /// Test-visible subclass so we can use the protected constructor.
    /// </summary>
    private sealed class TestableActivitySource : ResponsesActivitySource
    {
        public TestableActivitySource(string? name) : base(name) { }
    }

    public void Dispose()
    {
        _client.Dispose();
        _factory.Dispose();
        _listener.Dispose();
        _openAiSource.Dispose();
        _agentFrameworkSource.Dispose();
    }

    // --- Test: Single framework child span ---

    [Test]
    public async Task ChildInstrumentationSpan_IsChildOfAgentServerSpan()
    {
        _handler.EventFactory = (request, context, ct) =>
            HandlerWithOpenAiSpan(request, context, ct);

        using var content = new StringContent(
            """{"model":"test"}""",
            System.Text.Encoding.UTF8,
            "application/json");
        using var response = await _client.PostAsync("/responses", content);

        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));

        // Find the AgentServer (parent) and OpenAI-like (child) activities
        var serverSpan = _stoppedActivities.FirstOrDefault(
            a => a.Source.Name == _responsesSourceName);
        var childSpan = _stoppedActivities.FirstOrDefault(
            a => a.Source.Name == _openAiSourceName);

        Assert.That(serverSpan, Is.Not.Null, "AgentServer span should be captured");
        Assert.That(childSpan, Is.Not.Null, "Child instrumentation span should be captured");

        // Core assertion: child's ParentSpanId matches the server span's SpanId
        Assert.That(childSpan!.ParentSpanId, Is.EqualTo(serverSpan!.SpanId),
            "Child span's ParentSpanId should equal the AgentServer span's SpanId");

        // All spans share the same TraceId
        Assert.That(childSpan.TraceId, Is.EqualTo(serverSpan.TraceId),
            "Child and server spans should share the same TraceId");

        // The server span captured inside the handler matches
        Assert.That(_capturedServerActivity, Is.Not.Null,
            "Activity.Current should be non-null inside the handler");
        Assert.That(_capturedServerActivity!.SpanId, Is.EqualTo(serverSpan.SpanId),
            "Activity.Current in handler should be the AgentServer span");
    }

    // --- Test: Multiple framework spans share trace context ---

    [Test]
    public async Task MultipleChildSpans_ShareSameTraceIdWithServerSpan()
    {
        _handler.EventFactory = (request, context, ct) =>
            HandlerWithMultipleFrameworkSpans(request, context, ct);

        using var content = new StringContent(
            """{"model":"test"}""",
            System.Text.Encoding.UTF8,
            "application/json");
        using var response = await _client.PostAsync("/responses", content);

        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));

        var serverSpan = _stoppedActivities.FirstOrDefault(
            a => a.Source.Name == _responsesSourceName);
        var openAiSpan = _stoppedActivities.FirstOrDefault(
            a => a.Source.Name == _openAiSourceName);
        var agentFrameworkSpan = _stoppedActivities.FirstOrDefault(
            a => a.Source.Name == _agentFrameworkSourceName);

        Assert.That(serverSpan, Is.Not.Null, "AgentServer span should be captured");
        Assert.That(openAiSpan, Is.Not.Null, "OpenAI-like span should be captured");
        Assert.That(agentFrameworkSpan, Is.Not.Null, "AgentFramework-like span should be captured");

        // Both children share the same TraceId as the server span
        Assert.That(openAiSpan!.TraceId, Is.EqualTo(serverSpan!.TraceId));
        Assert.That(agentFrameworkSpan!.TraceId, Is.EqualTo(serverSpan.TraceId));

        // Both are direct children of the server span
        Assert.That(openAiSpan.ParentSpanId, Is.EqualTo(serverSpan.SpanId),
            "OpenAI-like span should be child of AgentServer span");
        Assert.That(agentFrameworkSpan.ParentSpanId, Is.EqualTo(serverSpan.SpanId),
            "AgentFramework-like span should be child of AgentServer span");
    }

    // --- Test: Nested hierarchy (3 levels) ---

    [Test]
    public async Task NestedChildSpans_FormCorrectThreeLevelHierarchy()
    {
        _handler.EventFactory = (request, context, ct) =>
            HandlerWithNestedSpans(request, context, ct);

        using var content = new StringContent(
            """{"model":"test"}""",
            System.Text.Encoding.UTF8,
            "application/json");
        using var response = await _client.PostAsync("/responses", content);

        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));

        var serverSpan = _stoppedActivities.FirstOrDefault(
            a => a.Source.Name == _responsesSourceName);
        var agentFrameworkSpan = _stoppedActivities.FirstOrDefault(
            a => a.Source.Name == _agentFrameworkSourceName);
        var openAiSpan = _stoppedActivities.FirstOrDefault(
            a => a.Source.Name == _openAiSourceName);

        Assert.That(serverSpan, Is.Not.Null, "AgentServer span should be captured");
        Assert.That(agentFrameworkSpan, Is.Not.Null, "AgentFramework-like span should be captured");
        Assert.That(openAiSpan, Is.Not.Null, "OpenAI-like span should be captured");

        // All three share the same TraceId
        Assert.That(agentFrameworkSpan!.TraceId, Is.EqualTo(serverSpan!.TraceId));
        Assert.That(openAiSpan!.TraceId, Is.EqualTo(serverSpan.TraceId));

        // AgentFramework span is child of server span (level 2)
        Assert.That(agentFrameworkSpan.ParentSpanId, Is.EqualTo(serverSpan.SpanId),
            "AgentFramework span should be child of AgentServer span");

        // OpenAI span is child of AgentFramework span (level 3)
        Assert.That(openAiSpan.ParentSpanId, Is.EqualTo(agentFrameworkSpan.SpanId),
            "OpenAI span should be child of AgentFramework span");
    }

    // --- Test: Context flows across async boundaries ---

    [Test]
    public async Task ChildSpan_PreservesParentAcrossAsyncBoundary()
    {
        _handler.EventFactory = (request, context, ct) =>
            HandlerWithAsyncBoundarySpan(request, context, ct);

        using var content = new StringContent(
            """{"model":"test"}""",
            System.Text.Encoding.UTF8,
            "application/json");
        using var response = await _client.PostAsync("/responses", content);

        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));

        var serverSpan = _stoppedActivities.FirstOrDefault(
            a => a.Source.Name == _responsesSourceName);
        var childSpan = _stoppedActivities.FirstOrDefault(
            a => a.Source.Name == _openAiSourceName);

        Assert.That(serverSpan, Is.Not.Null, "AgentServer span should be captured");
        Assert.That(childSpan, Is.Not.Null, "Child span should be captured after async boundary");

        Assert.That(childSpan!.ParentSpanId, Is.EqualTo(serverSpan!.SpanId),
            "Child span should be child of AgentServer span even after await Task.Yield()");
        Assert.That(childSpan.TraceId, Is.EqualTo(serverSpan.TraceId));
    }

    // --- Handler implementations ---

    private async IAsyncEnumerable<ResponseStreamEvent> HandlerWithOpenAiSpan(
        CreateResponse request,
        ResponseContext context,
        [EnumeratorCancellation] CancellationToken ct)
    {
        _capturedServerActivity = Activity.Current;

        // Simulate OpenAI SDK creating a child span
        using var childActivity = _openAiSource.StartActivity(
            "chat openai/gpt-4o",
            ActivityKind.Client);

        // Yield default lifecycle
        var response = new ResponseObject(context.ResponseId, request.Model ?? "test-model");
        yield return new ResponseCreatedEvent(0, response);
        response.SetCompleted();
        yield return new ResponseCompletedEvent(0, response);
    }

    private async IAsyncEnumerable<ResponseStreamEvent> HandlerWithMultipleFrameworkSpans(
        CreateResponse request,
        ResponseContext context,
        [EnumeratorCancellation] CancellationToken ct)
    {
        // Simulate Agent Framework creating a span
        using (var frameworkActivity = _agentFrameworkSource.StartActivity(
            "invoke_agent my-agent",
            ActivityKind.Internal))
        {
            // Simulate framework doing some work (no-op)
        }

        // Simulate OpenAI SDK creating a separate span (sequential, not nested)
        using (var openAiActivity = _openAiSource.StartActivity(
            "chat openai/gpt-4o",
            ActivityKind.Client))
        {
            // Simulate SDK call
        }

        var response = new ResponseObject(context.ResponseId, request.Model ?? "test-model");
        yield return new ResponseCreatedEvent(0, response);
        response.SetCompleted();
        yield return new ResponseCompletedEvent(0, response);
    }

    private async IAsyncEnumerable<ResponseStreamEvent> HandlerWithNestedSpans(
        CreateResponse request,
        ResponseContext context,
        [EnumeratorCancellation] CancellationToken ct)
    {
        // Level 2: Agent Framework span (child of AgentServer span)
        using var frameworkActivity = _agentFrameworkSource.StartActivity(
            "invoke_agent my-agent",
            ActivityKind.Internal);

        // Level 3: OpenAI span (child of AgentFramework span)
        using var openAiActivity = _openAiSource.StartActivity(
            "chat openai/gpt-4o",
            ActivityKind.Client);

        var response = new ResponseObject(context.ResponseId, request.Model ?? "test-model");
        yield return new ResponseCreatedEvent(0, response);
        response.SetCompleted();
        yield return new ResponseCompletedEvent(0, response);
    }

    private async IAsyncEnumerable<ResponseStreamEvent> HandlerWithAsyncBoundarySpan(
        CreateResponse request,
        ResponseContext context,
        [EnumeratorCancellation] CancellationToken ct)
    {
        // Cross an async boundary to verify context propagation
        await Task.Yield();

        // After the async boundary, Activity.Current should still be the server span
        using var childActivity = _openAiSource.StartActivity(
            "chat openai/gpt-4o",
            ActivityKind.Client);

        var response = new ResponseObject(context.ResponseId, request.Model ?? "test-model");
        yield return new ResponseCreatedEvent(0, response);
        response.SetCompleted();
        yield return new ResponseCompletedEvent(0, response);
    }
}
