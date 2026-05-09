// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;

using CreateResponseRequest = Azure.AI.AgentServer.Responses.CreateResponseRequest;

namespace Azure.AI.AgentServer.Responses.Tests.Orchestration;

/// <summary>
/// Tests for <see cref="ResponseOrchestrator.FinalizeExecutionAsync"/> covering the shared
/// finally-block logic: publisher completion, conditional persistence, and eager tracker eviction.
/// This logic was previously duplicated in the endpoint handler (bg branch, default branch) and SseResult.
/// </summary>
public class FinalizeExecutionTests : IDisposable
{
    private readonly TestHandler _handler;
    private readonly InMemoryResponsesProvider _provider;
    private readonly ResponseExecutionTracker _tracker;
    private readonly ResponseOrchestrator _orchestrator;

    public FinalizeExecutionTests()
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
    public async Task FinalizeExecution_CompletesPublisher()
    {
        var (execution, publisher) = await CreateExecutionWithPublisher("resp_fin_01");
        execution.Response = new Models.ResponseObject("resp_fin_01", "test") { Status = ResponseStatus.InProgress };
        execution.Response.SetCompleted();

        // Subscribe before finalize so we can observe OnCompleted
        var (events, observer) = await SubscribeToEvents("resp_fin_01");

        await _orchestrator.FinalizeExecutionAsync(execution, publisher);

        // Publisher should have been completed — observer's Completed task resolves
        await observer.Completed.WaitAsync(TimeSpan.FromSeconds(5));
    }

    [Test]
    public async Task FinalizeExecution_BackgroundWithStore_UpdatesResponse()
    {
        var (execution, publisher) = await CreateExecutionWithPublisher("resp_fin_02",
            isBackground: true, store: true);
        execution.Response = new Models.ResponseObject("resp_fin_02", "test") { Status = ResponseStatus.InProgress };
        execution.Response.SetCompleted();

        // First create the response so UpdateResponseAsync can find it
        await _provider.CreateResponseAsync(new CreateResponseRequest(execution.Response, null, null), IsolationContext.Empty);

        await _orchestrator.FinalizeExecutionAsync(execution, publisher);

        // Should call UpdateResponseAsync (bg=true: Create already happened at response.created)
        var stored = await _provider.GetResponseAsync("resp_fin_02", IsolationContext.Empty);
        Assert.That(stored, Is.Not.Null);
        Assert.That(stored!.Status, Is.EqualTo(ResponseStatus.Completed));
    }

    [Test]
    public async Task FinalizeExecution_NonBgWithStore_CreatesResponse_WhenNonCancelledTerminal()
    {
        var (execution, publisher) = await CreateExecutionWithPublisher("resp_fin_03",
            isBackground: false, store: true);
        execution.Response = new Models.ResponseObject("resp_fin_03", "test") { Status = ResponseStatus.InProgress };
        execution.Response.SetCompleted();

        await _orchestrator.FinalizeExecutionAsync(execution, publisher);

        // Should call CreateResponseAsync (bg=false: single persist at terminal state)
        var stored = await _provider.GetResponseAsync("resp_fin_03", IsolationContext.Empty);
        Assert.That(stored, Is.Not.Null);
    }

    [Test]
    public async Task FinalizeExecution_NonBgCancelled_DoesNotPersist()
    {
        var (execution, publisher) = await CreateExecutionWithPublisher("resp_fin_04",
            isBackground: false, store: true);
        execution.Response = new Models.ResponseObject("resp_fin_04", "test") { Status = ResponseStatus.InProgress };
        execution.Response.SetCancelled();

        await _orchestrator.FinalizeExecutionAsync(execution, publisher);

        // Cancelled non-bg responses are not persisted
        Assert.ThrowsAsync<ResourceNotFoundException>(
            () => _provider.GetResponseAsync("resp_fin_04", IsolationContext.Empty));
    }

    [Test]
    public async Task FinalizeExecution_NoStore_DoesNotPersist()
    {
        var (execution, publisher) = await CreateExecutionWithPublisher("resp_fin_05",
            isBackground: false, store: false);
        execution.Response = new Models.ResponseObject("resp_fin_05", "test") { Status = ResponseStatus.InProgress };
        execution.Response.SetCompleted();

        await _orchestrator.FinalizeExecutionAsync(execution, publisher);

        // store=false -> no persistence
        Assert.ThrowsAsync<ResourceNotFoundException>(
            () => _provider.GetResponseAsync("resp_fin_05", IsolationContext.Empty));
    }

    [Test]
    public async Task FinalizeExecution_EvictsFromTracker()
    {
        var (execution, publisher) = await CreateExecutionWithPublisher("resp_fin_06");
        execution.Response = new Models.ResponseObject("resp_fin_06", "test") { Status = ResponseStatus.InProgress };
        execution.Response.SetCompleted();

        await _orchestrator.FinalizeExecutionAsync(execution, publisher);

        Assert.That(_tracker.TryGet("resp_fin_06", out _), Is.False,
            "Completed execution should be evicted from tracker");
    }

    [Test]
    public async Task FinalizeExecution_SignalsFinalizedAfterEviction()
    {
        var (execution, publisher) = await CreateExecutionWithPublisher("resp_fin_08");
        execution.Response = new Models.ResponseObject("resp_fin_08", "test") { Status = ResponseStatus.InProgress };
        execution.Response.SetCompleted();

        await _orchestrator.FinalizeExecutionAsync(execution, publisher);

        Assert.That(execution.FinalizedSignal.Task.IsCompletedSuccessfully, Is.True);
    }

    [Test]
    public async Task FinalizeExecution_PreCreatedNotSeen_DoesNotPersist()
    {
        var (execution, publisher) = await CreateExecutionWithPublisher("resp_fin_07",
            isBackground: true, store: true);
        // Models.ResponseObject stays null — response.created was never emitted

        await _orchestrator.FinalizeExecutionAsync(execution, publisher);

        // Models.ResponseObject is null -> no persistence regardless of store/bg
        Assert.ThrowsAsync<ResourceNotFoundException>(
            () => _provider.GetResponseAsync("resp_fin_07", IsolationContext.Empty));
    }

    private async Task<(ResponseExecution Execution, IAsyncObserver<ResponseStreamEvent> Publisher)>
        CreateExecutionWithPublisher(string responseId,
            bool isBackground = false, bool store = true)
    {
        var execution = _tracker.Create(responseId, isBackground, store: store);
        var publisher = await _provider.CreateEventPublisherAsync(responseId);
        return (execution, publisher);
    }

    private async Task<(List<ResponseStreamEvent> Events, CollectingObserver Observer)>
        SubscribeToEvents(string responseId)
    {
        var events = new List<ResponseStreamEvent>();
        var observer = new CollectingObserver(events);
        await _provider.SubscribeToEventsAsync(responseId, observer);
        return (events, observer);
    }

    public void Dispose()
    {
        _provider.Dispose();
        _tracker.Dispose();
    }
}
