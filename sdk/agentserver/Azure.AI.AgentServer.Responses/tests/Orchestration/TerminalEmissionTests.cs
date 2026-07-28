// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core.Streaming;
using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Internal.Resilience;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;

namespace Azure.AI.AgentServer.Responses.Tests.Orchestration;

/// <summary>
/// Tests for the terminal emission helper methods on <see cref="ResponseOrchestrator"/>:
/// EmitTerminalFailureAsync and EmitTerminalCancellationAsync.
///
/// These methods consolidate the duplicated SetFailed/SetCancelled + event creation
/// + publisher push pattern that was previously duplicated 10+ times.
/// Note: The SDK never emits response.incomplete — that is purely handler-driven.
/// </summary>
public class TerminalEmissionTests : IDisposable
{
    private readonly TestHandler _handler;
    private readonly InMemoryResponsesProvider _provider;
    private readonly ResponseExecutionTracker _tracker;
    private readonly IEventStreamRegistry _eventStreamRegistry;
    private readonly ResponseOrchestrator _orchestrator;

    public TerminalEmissionTests()
    {
        _handler = new TestHandler();
        _provider = new InMemoryResponsesProvider(
            Options.Create(new InMemoryProviderOptions()), TimeProvider.System);
        _tracker = new ResponseExecutionTracker(NullLogger<ResponseExecutionTracker>.Instance);
        _eventStreamRegistry = TestEventStreams.CreateInMemoryRegistry();
        _orchestrator = new ResponseOrchestrator(
            _handler, _provider, new InMemoryCancellationSignalProvider(_provider), _eventStreamRegistry, _tracker,
            NullLogger<ResponseOrchestrator>.Instance,
            Options.Create(new ResponsesServerOptions()));
    }

    [Test]
    public async Task EmitTerminalFailure_SetsResponseStatusToFailed()
    {
        var (execution, publisher) = await CreateExecutionWithPublisher("resp_fail_01");

        await _orchestrator.EmitTerminalFailureAsync(execution, publisher);

        Assert.That(execution.Response.Status, Is.EqualTo(ResponseStatus.Failed));
    }

    [Test]
    public async Task EmitTerminalFailure_PushesResponseFailedEventToPublisher()
    {
        var (execution, publisher) = await CreateExecutionWithPublisher("resp_fail_02");
        var (events, observer) = await SubscribeToEvents("resp_fail_02");

        await _orchestrator.EmitTerminalFailureAsync(execution, publisher);
        await publisher.OnCompletedAsync();
        await observer.Completed.WaitAsync(TimeSpan.FromSeconds(5));

        XAssert.Single(events);
        XAssert.IsType<ResponseFailedEvent>(events[0]);
    }

    [Test]
    public async Task EmitTerminalCancellation_SetsResponseStatusToCancelled()
    {
        var (execution, publisher) = await CreateExecutionWithPublisher("resp_cancel_01");

        await _orchestrator.EmitTerminalCancellationAsync(execution, publisher);

        Assert.That(execution.Response.Status, Is.EqualTo(ResponseStatus.Cancelled));
    }

    [Test]
    public async Task EmitTerminalCancellation_PushesResponseFailedEventToPublisher()
    {
        var (execution, publisher) = await CreateExecutionWithPublisher("resp_cancel_02");
        var (events, observer) = await SubscribeToEvents("resp_cancel_02");

        await _orchestrator.EmitTerminalCancellationAsync(execution, publisher);
        await publisher.OnCompletedAsync();
        await observer.Completed.WaitAsync(TimeSpan.FromSeconds(5));

        XAssert.Single(events);
        // Cancelled responses emit ResponseFailedEvent per existing protocol
        XAssert.IsType<ResponseFailedEvent>(events[0]);
    }

    [Test]
    public async Task EmitTerminalFailure_SnapshotsResponseInEvent()
    {
        var (execution, publisher) = await CreateExecutionWithPublisher("resp_snap_01");
        var (events, observer) = await SubscribeToEvents("resp_snap_01");

        await _orchestrator.EmitTerminalFailureAsync(execution, publisher);
        await publisher.OnCompletedAsync();
        await observer.Completed.WaitAsync(TimeSpan.FromSeconds(5));

        var failedEvt = XAssert.IsType<ResponseFailedEvent>(events[0]);
        // The event should carry a snapshot, not the mutable reference
        Assert.That(failedEvt.Response, Is.Not.SameAs(execution.Response));
        Assert.That(failedEvt.Response.Status, Is.EqualTo(ResponseStatus.Failed));
    }

    private async Task<(ResponseExecution Execution, IAsyncObserver<ResponseStreamEvent> Publisher)>
        CreateExecutionWithPublisher(string responseId)
    {
        var execution = _tracker.Create(responseId);
        execution.Response = new Models.ResponseObject(responseId, "test") { Status = ResponseStatus.InProgress };
        var publisher = await TestEventStreams.CreatePublisherAsync(_eventStreamRegistry, responseId);
        return (execution, publisher);
    }

    private Task<(List<ResponseStreamEvent> Events, TestSubscription Observer)>
        SubscribeToEvents(string responseId)
    {
        var events = new List<ResponseStreamEvent>();
        var subscription = TestEventStreams.Subscribe(_eventStreamRegistry, responseId, events);
        return Task.FromResult((events, subscription));
    }

    public void Dispose()
    {
        _provider.Dispose();
        _tracker.Dispose();
    }
}
