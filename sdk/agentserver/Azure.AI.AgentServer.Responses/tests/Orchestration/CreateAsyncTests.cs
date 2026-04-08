// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.CompilerServices;
using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;

namespace Azure.AI.AgentServer.Responses.Tests.Orchestration;

/// <summary>
/// Tests for <see cref="ResponseOrchestrator.CreateAsync"/> covering all 4 mode combinations:
/// default (non-streaming, non-bg), bg non-streaming, streaming non-bg, streaming + bg.
/// SC-007: Orchestrator testable with mock dependencies in plain xUnit.
/// SC-008: Unit tests cover all mode combinations without HTTP infrastructure.
/// </summary>
public class CreateAsyncTests : IDisposable
{
    private readonly TestHandler _handler;
    private readonly InMemoryResponsesProvider _provider;
    private readonly ResponseExecutionTracker _tracker;
    private readonly ResponseOrchestrator _orchestrator;

    public CreateAsyncTests()
    {
        _handler = new TestHandler();
        _provider = new InMemoryResponsesProvider(
            Options.Create(new InMemoryProviderOptions()), TimeProvider.System);
        _tracker = new ResponseExecutionTracker(NullLogger<ResponseExecutionTracker>.Instance);
        _orchestrator = new ResponseOrchestrator(
            _handler, _provider, new InMemoryCancellationSignalProvider(_provider), new InMemoryStreamProvider(_provider), _tracker,
            NullLogger<ResponseOrchestrator>.Instance);
    }

    [Test]
    public async Task Default_NonStreaming_NonBg_ReturnsCompleted()
    {
        // Default mode: run handler to completion, return final response
        var response = new Models.ResponseObject("resp_create_01", "test") { Status = ResponseStatus.InProgress };
        var completedResponse = new Models.ResponseObject("resp_create_01", "test") { Status = ResponseStatus.Completed };
        _handler.EventFactory = (req, ctx, ct) => YieldEvents(
            new ResponseCreatedEvent(0, response),
            new ResponseCompletedEvent(1, completedResponse));

        var execution = CreateExecution("resp_create_01", isStreaming: false, isBackground: false);
        var context = new ResponseContext("resp_create_01");

        var result = await _orchestrator.CreateAsync(new CreateResponse(), execution, context, CancellationToken.None);

        Assert.That(result.IsStreaming, Is.False);
        Assert.That(result.Response, Is.Not.Null);
    }

    [Test]
    public async Task Background_NonStreaming_ReturnsCompleted()
    {
        // Background non-streaming: same pattern, returns completed result
        var response = new Models.ResponseObject("resp_create_02", "test") { Status = ResponseStatus.InProgress };
        var completedResponse = new Models.ResponseObject("resp_create_02", "test") { Status = ResponseStatus.Completed };
        _handler.EventFactory = (req, ctx, ct) => YieldEvents(
            new ResponseCreatedEvent(0, response),
            new ResponseCompletedEvent(1, completedResponse));

        var execution = CreateExecution("resp_create_02", isStreaming: false, isBackground: true);
        var context = new ResponseContext("resp_create_02");

        var result = await _orchestrator.CreateAsync(new CreateResponse(), execution, context, CancellationToken.None);

        Assert.That(result.IsStreaming, Is.False);
        Assert.That(result.Response, Is.Not.Null);
    }

    [Test]
    public async Task Streaming_NonBg_ReturnsStreamingResult()
    {
        // Streaming mode: returns IAsyncEnumerable of events
        var response = new Models.ResponseObject("resp_create_03", "test") { Status = ResponseStatus.InProgress };
        var completedResponse = new Models.ResponseObject("resp_create_03", "test") { Status = ResponseStatus.Completed };
        _handler.EventFactory = (req, ctx, ct) => YieldEvents(
            new ResponseCreatedEvent(0, response),
            new ResponseCompletedEvent(1, completedResponse));

        var execution = CreateExecution("resp_create_03", isStreaming: true, isBackground: false);
        var context = new ResponseContext("resp_create_03");

        var result = await _orchestrator.CreateAsync(new CreateResponse(), execution, context, CancellationToken.None);

        Assert.That(result.IsStreaming, Is.True);
        Assert.That(result.Events, Is.Not.Null);

        // Consume the stream to verify events are yielded
        var events = new List<ResponseStreamEvent>();
        await foreach (var evt in result.Events!)
        {
            events.Add(evt);
        }

        Assert.That(events.Count, Is.EqualTo(2));
        XAssert.IsType<ResponseCreatedEvent>(events[0]);
        XAssert.IsType<ResponseCompletedEvent>(events[1]);
    }

    [Test]
    public async Task Streaming_Background_ReturnsStreamingResult()
    {
        // Streaming + background: same as streaming, yields events
        var response = new Models.ResponseObject("resp_create_04", "test") { Status = ResponseStatus.InProgress };
        var completedResponse = new Models.ResponseObject("resp_create_04", "test") { Status = ResponseStatus.Completed };
        _handler.EventFactory = (req, ctx, ct) => YieldEvents(
            new ResponseCreatedEvent(0, response),
            new ResponseCompletedEvent(1, completedResponse));

        var execution = CreateExecution("resp_create_04", isStreaming: true, isBackground: true);
        var context = new ResponseContext("resp_create_04");

        var result = await _orchestrator.CreateAsync(new CreateResponse(), execution, context, CancellationToken.None);

        Assert.That(result.IsStreaming, Is.True);
        Assert.That(result.Events, Is.Not.Null);

        var events = new List<ResponseStreamEvent>();
        await foreach (var evt in result.Events!)
        {
            events.Add(evt);
        }

        Assert.That(events.Count, Is.EqualTo(2));
    }

    [Test]
    public async Task Default_HandlerException_ReturnsCompletedWithFailedResponse()
    {
        // Error during non-streaming: error recovery runs, returns completed with failed response
        _handler.EventFactory = (req, ctx, ct) => ThrowAfterCreated(ctx.ResponseId);

        var execution = CreateExecution("resp_create_05", isStreaming: false, isBackground: false);
        var context = new ResponseContext("resp_create_05");

        var result = await _orchestrator.CreateAsync(new CreateResponse(), execution, context, CancellationToken.None);

        Assert.That(result.IsStreaming, Is.False);
        Assert.That(result.Response, Is.Not.Null);
        Assert.That(result.Response!.Status, Is.EqualTo(ResponseStatus.Failed));
    }

    [Test]
    public async Task Default_CompletedResult_FinalizesExecution()
    {
        // Non-streaming: after completion, execution should be finalized
        var response = new Models.ResponseObject("resp_create_06", "test") { Status = ResponseStatus.InProgress };
        var completedResponse = new Models.ResponseObject("resp_create_06", "test") { Status = ResponseStatus.Completed };
        _handler.EventFactory = (req, ctx, ct) => YieldEvents(
            new ResponseCreatedEvent(0, response),
            new ResponseCompletedEvent(1, completedResponse));

        var execution = CreateExecution("resp_create_06", isStreaming: false, isBackground: false);
        var context = new ResponseContext("resp_create_06");

        await _orchestrator.CreateAsync(new CreateResponse(), execution, context, CancellationToken.None);

        // FinalizeExecution should have called MarkCompleted
        Assert.That(execution.CompletedAt, Is.Not.Null);
    }

    [Test]
    public async Task Streaming_AfterConsumption_FinalizesExecution()
    {
        // Streaming: finalization happens after the stream is fully consumed
        var response = new Models.ResponseObject("resp_create_07", "test") { Status = ResponseStatus.InProgress };
        var completedResponse = new Models.ResponseObject("resp_create_07", "test") { Status = ResponseStatus.Completed };
        _handler.EventFactory = (req, ctx, ct) => YieldEvents(
            new ResponseCreatedEvent(0, response),
            new ResponseCompletedEvent(1, completedResponse));

        var execution = CreateExecution("resp_create_07", isStreaming: true, isBackground: false);
        var context = new ResponseContext("resp_create_07");

        var result = await _orchestrator.CreateAsync(new CreateResponse(), execution, context, CancellationToken.None);

        // Before consuming: not finalized yet
        Assert.That(execution.CompletedAt, Is.Null);

        // Consume the stream
        await foreach (var _ in result.Events!)
        { }

        // After consuming: should be finalized
        Assert.That(execution.CompletedAt, Is.Not.Null);
    }

    [Test]
    public async Task Default_NoTerminalEvent_SetsResponseFailed()
    {
        // B32/S-015: handler ends without emitting a terminal event
        var response = new Models.ResponseObject("resp_create_08", "test") { Status = ResponseStatus.InProgress };
        _handler.EventFactory = (req, ctx, ct) => YieldEvents(
            new ResponseCreatedEvent(0, response),
            new ResponseInProgressEvent(1, response));
        // No completed/failed/incomplete event

        var execution = CreateExecution("resp_create_08", isStreaming: false, isBackground: false);
        var context = new ResponseContext("resp_create_08");

        var result = await _orchestrator.CreateAsync(new CreateResponse(), execution, context, CancellationToken.None);

        // Should detect no terminal event and set failed
        Assert.That(result.Response!.Status, Is.EqualTo(ResponseStatus.Failed));
    }

    // --- Helpers ---

    private ResponseExecution CreateExecution(string responseId,
        bool isStreaming = false, bool isBackground = false, bool store = true)
    {
        return _tracker.Create(responseId, isBackground, isStreaming, store);
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> YieldEvents(
        params ResponseStreamEvent[] events)
    {
        foreach (var evt in events)
        {
            yield return evt;
        }

        await Task.CompletedTask;
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> ThrowAfterCreated(
        string responseId)
    {
        var response = new Models.ResponseObject(responseId, "test") { Status = ResponseStatus.InProgress };
        yield return new ResponseCreatedEvent(0, response);
        await Task.CompletedTask;
        throw new InvalidOperationException("handler error");
    }

    public void Dispose()
    {
        _provider.Dispose();
        _tracker.Dispose();
    }
}
